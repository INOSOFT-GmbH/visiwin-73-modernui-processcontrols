using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Threading;
using HMI;
using VisiWin.ApplicationFramework;
using VisiWin.ApplicationManager;
using VisiWin.Diagnostics;
using VisiWin.Project;
using NLog;
using NLog.Targets;

namespace HMI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
		private ApplicationInitializer applicationInitializer;
        private SplashScreen splashScreen;

        protected override void OnStartup(StartupEventArgs e)
        {
            var applicationManager = (ApplicationManager) this.FindResource("ApplicationManager");
            var projectName = ApplicationInitializer.GetProjectNameFromRuntimeSettings() ?? applicationManager?.ProjectName;

            if (applicationManager?.HandleApplicationException ?? true)
            {
                AppDomain.CurrentDomain.UnhandledException += this.CurrentDomain_UnhandledException;
                Current.DispatcherUnhandledException += this.Current_DispatcherUnhandledException;
            }

            if (applicationManager?.SplashWindowEnabled ?? true)
            {
                this.splashScreen = new SplashScreen("/Images/Splashscreen.png");
                this.splashScreen.Show(false);
            }

            ApplicationService.UseTouchkeyboard = applicationManager?.UseTouchkeyboard ?? true;

            this.applicationInitializer = new ApplicationInitializer(projectName);
            this.applicationInitializer.Initialize();

            var projectService = ApplicationService.GetService<IProjectService>();
            projectService.WindowsKeysDisabled = applicationManager?.WindowsKeysDisabled ?? false;
            projectService.RunProjectCompleted += this.OnRunProjectCompleted;

            var startDelay = applicationManager?.StartDelay ?? 0;
            var projectParams = applicationManager?.ProjectStartParameters != null && applicationManager.ProjectStartParameters.Count > 0 ? applicationManager.ProjectStartParameters : null;
            
            projectService.RunProjectAsync(projectName, startDelay, projectParams);

            base.OnStartup(e);
        }

        private void Current_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            ApplicationService.Log(EventSource.Application, EventCategory.Fatal, "UnhandledDispatcherException : " + e.Exception);
            e.Handled = true;
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = e.ExceptionObject as Exception;
            ApplicationService.Log(EventSource.Application, EventCategory.Fatal, "UnhandledThreadException : " + ex);
        }

        private void OnRunProjectCompleted(object sender, RunProjectCompletedEventArgs e)
        {
            var projectService = (IProjectService)sender;
            projectService.RunProjectCompleted -= this.OnRunProjectCompleted;

            if (!e.Connected)
            {
                var fileTarget = LogManager.Configuration?.FindTargetByName("vwLogFile") as FileTarget;
                var fileName = fileTarget?.FileName?.Render(new LogEventInfo() { TimeStamp = DateTime.Now });
                var message = $"The application could not be started due to an error. More information can be found in the Log file. ";
                if (fileName != null)
                {
                    message += $"({fileName})";
                }
                ApplicationService.Log(EventSource.Project, EventCategory.Fatal, e.Error?.ToString());
                MessageBox.Show(message, "Startup failed");
                Environment.Exit(-1);
            }
            else
            {
                this.MainWindow = new MainWindow();
                this.applicationInitializer.InitializeMainWindow(this.MainWindow);
                this.MainWindow.Show();
            }

        if (this.splashScreen!= null)
            {
                this.splashScreen.Close(TimeSpan.FromMilliseconds(200));
                this.splashScreen = null;
            }
        }
    }
}
