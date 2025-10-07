using System;
using System.Threading;
using System.Threading.Tasks;

namespace VisiWin7.ProcessControls.WPF.Async
{
    /// <summary>
    /// Provides an async-compatible mutual exclusion lock.
    /// This lock can be used to synchronize access to a resource in both synchronous and asynchronous code.
    /// </summary>
    public sealed class AsyncLock
    {
        /// <summary>
        /// A cached task that returns the releaser disposable object.
        /// </summary>
        private readonly Task<IDisposable> releaser;

        /// <summary>
        /// The semaphore used to control access to the critical section.
        /// </summary>
        private readonly SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncLock"/> class.
        /// </summary>
        public AsyncLock()
        {
            this.releaser = Task.FromResult((IDisposable)new Releaser(this));
        }

        /// <summary>
        /// Asynchronously acquires the lock.
        /// Returns an <see cref="IDisposable"/> that releases the lock when disposed.
        /// </summary>
        /// <returns>
        /// A task that completes when the lock has been acquired, yielding an <see cref="IDisposable"/>
        /// that will release the lock upon disposal.
        /// </returns>
        public Task<IDisposable> LockAsync()
        {
            var wait = this.semaphore.WaitAsync();
            return wait.IsCompleted
                       ? this.releaser
                       : wait.ContinueWith((_, state) => (IDisposable)state, this.releaser.Result, CancellationToken.None,
                           TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);
        }

        /// <summary>
        /// Synchronously acquires the lock.
        /// Returns an <see cref="IDisposable"/> that releases the lock when disposed.
        /// </summary>
        /// <returns>
        /// An <see cref="IDisposable"/> that will release the lock upon disposal.
        /// </returns>
        public IDisposable Lock()
        {
            this.semaphore.Wait();
            return this.releaser.Result;
        }

        /// <summary>
        /// An <see cref="IDisposable"/> implementation that releases the lock when disposed.
        /// </summary>
        private sealed class Releaser : IDisposable
        {
            /// <summary>
            /// The <see cref="AsyncLock"/> instance to release.
            /// </summary>
            private readonly AsyncLock toRelease;

            /// <summary>
            /// Initializes a new instance of the <see cref="Releaser"/> class.
            /// </summary>
            /// <param name="toRelease">The <see cref="AsyncLock"/> to release when disposed.</param>
            internal Releaser(AsyncLock toRelease)
            {
                this.toRelease = toRelease;
            }

            /// <summary>
            /// Releases the lock by releasing the underlying semaphore.
            /// </summary>
            public void Dispose()
            {
                this.toRelease.semaphore.Release();
            }
        }
    }
}
