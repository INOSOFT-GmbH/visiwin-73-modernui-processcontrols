using System.Collections.Generic;
using System.Windows;
using Microsoft.VisualStudio.DesignTools.Extensibility.Features;
using Microsoft.VisualStudio.DesignTools.Extensibility.Metadata;
using Microsoft.VisualStudio.DesignTools.Extensibility.PropertyEditing;
using VisiWin.Controls.Design;
using VisiWinNET.Development;
using VisiWin7.ProcessControls.WPF.VW7.Design.Initializer;

// The ProvideMetadata assembly-level attribute indicates to designers
// that this assembly contains a class that provides an attribute table. 
[assembly: ProvideMetadata(typeof(HMI.Components.Design.Metadata))]
namespace HMI.Components.Design
{
    // Container for any general design-time metadata to initialize.
    // Designers look for a type in the design-time assembly that 
    // implements IProvideAttributeTable. If found, designers instantiate 
    // this class and access its AttributeTable property automatically.
    public class Metadata : IProvideAttributeTable
    {
        // Accessed by the designer to register any design-time metadata.
        public AttributeTable AttributeTable
        {
            get
            {
                AttributeTableBuilder builder = new AttributeTableBuilder();

                #region ProcessControls
                this.SetCustomAttributes(builder, "VisiWin7.ProcessControls.WPF.Controls.BeltConveyor");
                this.SetCustomAttributes(builder, "VisiWin7.ProcessControls.WPF.Controls.Arrow");
                this.SetCustomAttributes(builder, "VisiWin7.ProcessControls.WPF.Controls.Pump");
                this.SetCustomAttributes(builder, "VisiWin7.ProcessControls.WPF.Controls.Compressor");
                this.SetCustomAttributes(builder, "VisiWin7.ProcessControls.WPF.Controls.Fan");
                this.SetCustomAttributes(builder, "VisiWin7.ProcessControls.WPF.Controls.Tank");
                this.SetCustomAttributes(builder, "VisiWin7.ProcessControls.WPF.Controls.RoundTank");
                this.SetCustomAttributes(builder, "VisiWin7.ProcessControls.WPF.Controls.Silo");
                this.SetCustomAttributes(builder, "VisiWin7.ProcessControls.WPF.Controls.Valve");
                this.SetCustomAttributes(builder, "VisiWin7.ProcessControls.WPF.Controls.BallValve");
                this.SetCustomAttributes(builder, "VisiWin7.ProcessControls.WPF.Controls.GlobeValve");
                this.SetCustomAttributes(builder, "VisiWin7.ProcessControls.WPF.Controls.MotorValve");
                this.SetCustomAttributes(builder, "VisiWin7.ProcessControls.WPF.Controls.AngleValve");
                this.SetCustomAttributes(builder, "VisiWin7.ProcessControls.WPF.Controls.FlapValve");
                this.SetCustomAttributes(builder, "VisiWin7.ProcessControls.WPF.Controls.GateValve");
                this.SetCustomAttributes(builder, "VisiWin7.ProcessControls.WPF.Controls.PistonValve");
                this.SetCustomAttributes(builder, "VisiWin7.ProcessControls.WPF.Controls.ThreeWayValve");
                this.SetCustomAttributes(builder, "VisiWin7.ProcessControls.WPF.Controls.HeatExchanger");
                this.SetCustomAttributes(builder, "VisiWin7.ProcessControls.WPF.Controls.HeatExchangerTubes");
                this.SetCustomAttributes(builder, "VisiWin7.ProcessControls.WPF.Controls.HeatExchangerWithoutCrossingFlow");
                this.SetCustomAttributes(builder, "VisiWin7.ProcessControls.WPF.Controls.Burner");
                this.SetCustomAttributes(builder, "VisiWin7.ProcessControls.WPF.Controls.Cooler");
                this.SetCustomAttributes(builder, "VisiWin7.ProcessControls.WPF.Controls.CoolingTower");
                this.SetCustomAttributes(builder, "VisiWin7.ProcessControls.WPF.Controls.CoolingTowerWithInlet");
                this.SetCustomAttributes(builder, "VisiWin7.ProcessControls.WPF.Controls.SprayCoolingTower");
                this.SetCustomAttributes(builder, "VisiWin7.ProcessControls.WPF.Controls.RotaryFeeder");
                this.SetCustomAttributes(builder, "VisiWin7.ProcessControls.WPF.Controls.Diverter");
                this.SetCustomAttributes(builder, "VisiWin7.ProcessControls.WPF.Controls.Centrifugal");
                this.SetCustomAttributes(builder, "VisiWin7.ProcessControls.WPF.Controls.Pipe");
                this.SetCustomAttributes(builder, "VisiWin7.ProcessControls.WPF.Controls.PipeBridge");
                this.SetCustomAttributes(builder, "VisiWin7.ProcessControls.WPF.Controls.PipeConnection");
                this.SetCustomAttributes(builder, "VisiWin7.ProcessControls.WPF.Controls.Stirer");
                this.SetCustomAttributes(builder, "VisiWin7.ProcessControls.WPF.Controls.Motor");
                this.SetCustomAttributes(builder, "VisiWin7.ProcessControls.WPF.Controls.Turbine");
                this.SetCustomAttributes(builder, "VisiWin7.ProcessControls.WPF.Controls.ScrewConveyor");
                this.SetCustomAttributes(builder, "VisiWin7.ProcessControls.WPF.Controls.CeilingConveyor");
                this.SetCustomAttributes(builder, "VisiWin7.ProcessControls.WPF.Controls.Scale");
                #endregion

                // Initializer registrations
                builder.AddCallback("VisiWin7.ProcessControls.WPF.Controls.BeltConveyor", blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(BeltConveyorInitializer))));
                builder.AddCallback("VisiWin7.ProcessControls.WPF.Controls.Arrow", blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(ArrowInitializer))));
                builder.AddCallback("VisiWin7.ProcessControls.WPF.Controls.Pump", blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(PumpInitializer))));
                builder.AddCallback("VisiWin7.ProcessControls.WPF.Controls.Compressor", blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(CompressorInitializer))));
                builder.AddCallback("VisiWin7.ProcessControls.WPF.Controls.Fan", blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(FanInitializer))));
                builder.AddCallback("VisiWin7.ProcessControls.WPF.Controls.Tank", blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(TankInitializer))));
                builder.AddCallback("VisiWin7.ProcessControls.WPF.Controls.RoundTank", blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(RoundTankInitializer))));
                builder.AddCallback("VisiWin7.ProcessControls.WPF.Controls.Silo", blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(SiloInitializer))));
                builder.AddCallback("VisiWin7.ProcessControls.WPF.Controls.Valve", blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(ValveInitializer))));
                builder.AddCallback("VisiWin7.ProcessControls.WPF.Controls.BallValve", blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(BallValveInitializer))));
                builder.AddCallback("VisiWin7.ProcessControls.WPF.Controls.GlobeValve", blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(GlobeValveInitializer))));
                builder.AddCallback("VisiWin7.ProcessControls.WPF.Controls.MotorValve", blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(MotorValveInitializer))));
                builder.AddCallback("VisiWin7.ProcessControls.WPF.Controls.AngleValve", blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(AngleValveInitializer))));
                builder.AddCallback("VisiWin7.ProcessControls.WPF.Controls.FlapValve", blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(FlapValveInitializer))));
                builder.AddCallback("VisiWin7.ProcessControls.WPF.Controls.GateValve", blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(GateValveInitializer))));
                builder.AddCallback("VisiWin7.ProcessControls.WPF.Controls.PistonValve", blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(PistonValveInitializer))));
                builder.AddCallback("VisiWin7.ProcessControls.WPF.Controls.ThreeWayValve", blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(ThreeWayValveInitializer))));
                builder.AddCallback("VisiWin7.ProcessControls.WPF.Controls.Burner", blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(BurnerInitializer))));
                builder.AddCallback("VisiWin7.ProcessControls.WPF.Controls.Cooler", blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(CoolerInitializer))));
                builder.AddCallback("VisiWin7.ProcessControls.WPF.Controls.CoolingTower", blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(CoolingTowerInitializer))));
                builder.AddCallback("VisiWin7.ProcessControls.WPF.Controls.CoolingTowerWithInlet", blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(CoolingTowerWithInletInitializer))));
                builder.AddCallback("VisiWin7.ProcessControls.WPF.Controls.SprayCoolingTower", blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(SprayCoolingTowerInitializer))));
                builder.AddCallback("VisiWin7.ProcessControls.WPF.Controls.RotaryFeeder", blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(RotaryFeederInitializer))));
                builder.AddCallback("VisiWin7.ProcessControls.WPF.Controls.Diverter", blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(DiverterInitializer))));
                builder.AddCallback("VisiWin7.ProcessControls.WPF.Controls.Centrifugal", blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(CentrifugalInitializer))));
                builder.AddCallback("VisiWin7.ProcessControls.WPF.Controls.Pipe", blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(PipeInitializer))));
                builder.AddCallback("VisiWin7.ProcessControls.WPF.Controls.PipeBridge", blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(PipeBridgeInitializer))));
                builder.AddCallback("VisiWin7.ProcessControls.WPF.Controls.PipeConnection", blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(PipeConnectionInitializer))));
                builder.AddCallback("VisiWin7.ProcessControls.WPF.Controls.Stirer", blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(StirerInitializer))));
                builder.AddCallback("VisiWin7.ProcessControls.WPF.Controls.HeatExchanger", blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(HeatExchangerInitializer))));
                builder.AddCallback("VisiWin7.ProcessControls.WPF.Controls.HeatExchangerTubes", blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(HeatExchangerTubesInitializer))));
                builder.AddCallback("VisiWin7.ProcessControls.WPF.Controls.HeatExchangerWithoutCrossingFlow", blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(HeatExchangerWithoutCrossingFlowInitializer))));
                builder.AddCallback("VisiWin7.ProcessControls.WPF.Controls.Motor", blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(MotorInitializer))));
                builder.AddCallback("VisiWin7.ProcessControls.WPF.Controls.Turbine", blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(TurbineInitializer))));
                builder.AddCallback("VisiWin7.ProcessControls.WPF.Controls.ScrewConveyor", blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(ScrewConveyorInitializer))));
                builder.AddCallback("VisiWin7.ProcessControls.WPF.Controls.CeilingConveyor", blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(CeilingConveyorInitializer))));
                builder.AddCallback("VisiWin7.ProcessControls.WPF.Controls.Scale", blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(ScaleInitializer))));

                builder.AddCustomAttributes("VisiWin7.ProcessControls.WPF.Controls.BeltConveyor", "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Conveyor" }
                    }));
                builder.AddCustomAttributes("VisiWin7.ProcessControls.WPF.Controls.Arrow", "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Pipe" }
                    }));
                builder.AddCustomAttributes("VisiWin7.ProcessControls.WPF.Controls.Pump", "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Pump" }
                    }));
                builder.AddCustomAttributes("VisiWin7.ProcessControls.WPF.Controls.Compressor", "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Pump" }
                    }));
                builder.AddCustomAttributes("VisiWin7.ProcessControls.WPF.Controls.Fan", "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Pump" }
                    }));
                builder.AddCustomAttributes("VisiWin7.ProcessControls.WPF.Controls.Tank", "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Tank" }
                    }));
                builder.AddCustomAttributes("VisiWin7.ProcessControls.WPF.Controls.RoundTank", "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Tank" }
                    }));
                builder.AddCustomAttributes("VisiWin7.ProcessControls.WPF.Controls.Silo", "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Tank" }
                    }));
                builder.AddCustomAttributes("VisiWin7.ProcessControls.WPF.Controls.Valve", "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Valve" }
                    }));
                builder.AddCustomAttributes("VisiWin7.ProcessControls.WPF.Controls.BallValve", "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Valve" }
                    }));
                builder.AddCustomAttributes("VisiWin7.ProcessControls.WPF.Controls.GlobeValve", "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Valve" }
                    }));
                builder.AddCustomAttributes("VisiWin7.ProcessControls.WPF.Controls.MotorValve", "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Valve" }
                    }));
                builder.AddCustomAttributes("VisiWin7.ProcessControls.WPF.Controls.AngleValve", "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Valve" }
                    }));
                builder.AddCustomAttributes("VisiWin7.ProcessControls.WPF.Controls.FlapValve", "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Valve" }
                    }));
                builder.AddCustomAttributes("VisiWin7.ProcessControls.WPF.Controls.GateValve", "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Valve" }
                    }));
                builder.AddCustomAttributes("VisiWin7.ProcessControls.WPF.Controls.PistonValve", "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Valve" }
                    }));
                builder.AddCustomAttributes("VisiWin7.ProcessControls.WPF.Controls.ThreeWayValve", "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "ThreeWayValve" }
                    }));
                builder.AddCustomAttributes("VisiWin7.ProcessControls.WPF.Controls.Burner", "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Exchanger" }
                    }));
                builder.AddCustomAttributes("VisiWin7.ProcessControls.WPF.Controls.Cooler", "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Exchanger" }
                    }));
                builder.AddCustomAttributes("VisiWin7.ProcessControls.WPF.Controls.CoolingTower", "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Exchanger" }
                    }));
                builder.AddCustomAttributes("VisiWin7.ProcessControls.WPF.Controls.CoolingTowerWithInlet", "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Exchanger" }
                    }));
                builder.AddCustomAttributes("VisiWin7.ProcessControls.WPF.Controls.SprayCoolingTower", "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Exchanger" }
                    }));
                builder.AddCustomAttributes("VisiWin7.ProcessControls.WPF.Controls.RotaryFeeder", "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "MechanicalEquipment" }
                    }));
                builder.AddCustomAttributes("VisiWin7.ProcessControls.WPF.Controls.Diverter", "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "MechanicalEquipment" }
                    }));
                builder.AddCustomAttributes("VisiWin7.ProcessControls.WPF.Controls.Centrifugal", "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "MechanicalEquipment" }
                    }));
                builder.AddCustomAttributes("VisiWin7.ProcessControls.WPF.Controls.Pipe", "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Pipe" }
                    }));
                builder.AddCustomAttributes("VisiWin7.ProcessControls.WPF.Controls.PipeBridge", "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Pipe" }
                    }));
                builder.AddCustomAttributes("VisiWin7.ProcessControls.WPF.Controls.PipeConnection", "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Pipe" }
                    }));
                builder.AddCustomAttributes("VisiWin7.ProcessControls.WPF.Controls.Stirer", "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "MechanicalEquipment" }
                    }));
                builder.AddCustomAttributes("VisiWin7.ProcessControls.WPF.Controls.Scale", "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "MechanicalEquipment" }
                    }));
                builder.AddCustomAttributes("VisiWin7.ProcessControls.WPF.Controls.HeatExchanger", "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Exchanger" }
                    }));
                builder.AddCustomAttributes("VisiWin7.ProcessControls.WPF.Controls.HeatExchangerTubes", "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Exchanger" }
                    }));
                builder.AddCustomAttributes("VisiWin7.ProcessControls.WPF.Controls.HeatExchangerWithoutCrossingFlow", "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Exchanger" }
                    }));
                builder.AddCustomAttributes("VisiWin7.ProcessControls.WPF.Controls.Motor", "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Engine" }
                    }));
                builder.AddCustomAttributes("VisiWin7.ProcessControls.WPF.Controls.Turbine", "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Engine" }
                    }));
                builder.AddCustomAttributes("VisiWin7.ProcessControls.WPF.Controls.ScrewConveyor", "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Conveyor" }
                    }));
                builder.AddCustomAttributes("VisiWin7.ProcessControls.WPF.Controls.CeilingConveyor", "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Conveyor" }
                    }));

                return builder.CreateTable();
            }
        }

        private void SetCustomAttributes(AttributeTableBuilder builder, string type)
        {
            builder.AddCustomAttributes(type, "StructVariableName", PropertyValueEditor.CreateEditorAttribute(typeof(VariableNameDialogPropertyEditor)));
            builder.AddCustomAttributes(type, "LocalizableLabelText", PropertyValueEditor.CreateEditorAttribute(typeof(TextDialogPropertyEditor)));
        }
    }
}
