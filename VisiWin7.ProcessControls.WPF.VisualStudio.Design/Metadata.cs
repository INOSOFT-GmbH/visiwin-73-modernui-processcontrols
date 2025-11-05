using Microsoft.Windows.Design.Features;
using Microsoft.Windows.Design.Metadata;
using Microsoft.Windows.Design.PropertyEditing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows;
using VisiWin.Controls.Design;
using VisiWin.WPF.View.VisualStudio.Design;
using VisiWin7.ProcessControls.WPF.Controls;
using VisiWin7.ProcessControls.WPF.VW7.Design.Initializer;


// The ProvideMetadata assembly-level attribute indicates to designers
// that this assembly contains a class that provides an attribute table. 
[assembly: ProvideMetadata(typeof(VisiWin7.ProcessControls.WPF.VisualStudio.Design.Metadata))]
namespace VisiWin7.ProcessControls.WPF.VisualStudio.Design
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

                PropertyGridAdjuster.SetPropertyAttributes(builder);
                                
                #region ProcessControls
                this.SetCustomAttributes(builder, typeof(BeltConveyor));
                this.SetCustomAttributes(builder, typeof(Arrow));
                this.SetCustomAttributes(builder, typeof(Pump));
                this.SetCustomAttributes(builder, typeof(Compressor));
                this.SetCustomAttributes(builder, typeof(Fan));
                this.SetCustomAttributes(builder, typeof(Tank));
                this.SetCustomAttributes(builder, typeof(RoundTank));
                this.SetCustomAttributes(builder, typeof(Silo));
                this.SetCustomAttributes(builder, typeof(Valve));
                this.SetCustomAttributes(builder, typeof(BallValve));
                this.SetCustomAttributes(builder, typeof(GlobeValve));
                this.SetCustomAttributes(builder, typeof(MotorValve));
                this.SetCustomAttributes(builder, typeof(AngleValve));
                this.SetCustomAttributes(builder, typeof(FlapValve));
                this.SetCustomAttributes(builder, typeof(GateValve));
                this.SetCustomAttributes(builder, typeof(PistonValve));
                this.SetCustomAttributes(builder, typeof(ThreeWayValve));
                this.SetCustomAttributes(builder, typeof(HeatExchanger));
                this.SetCustomAttributes(builder, typeof(HeatExchangerTubes));
                this.SetCustomAttributes(builder, typeof(HeatExchangerWithoutCrossingFlow));
                this.SetCustomAttributes(builder, typeof(Burner));
                this.SetCustomAttributes(builder, typeof(Cooler));
                this.SetCustomAttributes(builder, typeof(CoolingTower));
                this.SetCustomAttributes(builder, typeof(CoolingTowerWithInlet));
                this.SetCustomAttributes(builder, typeof(SprayCoolingTower));
                this.SetCustomAttributes(builder, typeof(RotaryFeeder));
                this.SetCustomAttributes(builder, typeof(Diverter));
                this.SetCustomAttributes(builder, typeof(Centrifugal));
                this.SetCustomAttributes(builder, typeof(Pipe));
                this.SetCustomAttributes(builder, typeof(PipeBridge));
                this.SetCustomAttributes(builder, typeof(PipeConnection));
                this.SetCustomAttributes(builder, typeof(Stirer));
                this.SetCustomAttributes(builder, typeof(Motor));
                this.SetCustomAttributes(builder, typeof(Turbine));
                this.SetCustomAttributes(builder, typeof(ScrewConveyor));
                this.SetCustomAttributes(builder, typeof(CeilingConveyor));
                this.SetCustomAttributes(builder, typeof(Scale));
                #endregion

                builder.AddCallback(typeof(BeltConveyor), blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(BeltConveyorInitializer))));
                builder.AddCallback(typeof(Arrow), blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(ArrowInitializer))));
                builder.AddCallback(typeof(Pump), blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(PumpInitializer))));
                builder.AddCallback(typeof(Compressor), blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(CompressorInitializer))));
                builder.AddCallback(typeof(Fan), blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(FanInitializer))));
                builder.AddCallback(typeof(Tank), blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(TankInitializer))));
                builder.AddCallback(typeof(RoundTank), blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(RoundTankInitializer))));
                builder.AddCallback(typeof(Silo), blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(SiloInitializer))));
                builder.AddCallback(typeof(Valve), blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(ValveInitializer))));
                builder.AddCallback(typeof(BallValve), blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(BallValveInitializer))));
                builder.AddCallback(typeof(GlobeValve), blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(GlobeValveInitializer))));
                builder.AddCallback(typeof(MotorValve), blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(MotorValveInitializer))));
                builder.AddCallback(typeof(AngleValve), blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(AngleValveInitializer))));
                builder.AddCallback(typeof(FlapValve), blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(FlapValveInitializer))));
                builder.AddCallback(typeof(GateValve), blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(GateValveInitializer))));
                builder.AddCallback(typeof(PistonValve), blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(PistonValveInitializer))));
                builder.AddCallback(typeof(ThreeWayValve), blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(ThreeWayValveInitializer))));
                builder.AddCallback(typeof(Burner), blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(BurnerInitializer))));
                builder.AddCallback(typeof(Cooler), blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(CoolerInitializer))));
                builder.AddCallback(typeof(CoolingTower), blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(CoolingTowerInitializer))));
                builder.AddCallback(typeof(CoolingTowerWithInlet), blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(CoolingTowerWithInletInitializer))));
                builder.AddCallback(typeof(SprayCoolingTower), blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(SprayCoolingTowerInitializer))));
                builder.AddCallback(typeof(RotaryFeeder), blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(RotaryFeederInitializer))));
                builder.AddCallback(typeof(Diverter), blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(DiverterInitializer))));
                builder.AddCallback(typeof(Centrifugal), blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(CentrifugalInitializer))));
                builder.AddCallback(typeof(Pipe), blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(PipeInitializer))));
                builder.AddCallback(typeof(PipeBridge), blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(PipeBridgeInitializer))));
                builder.AddCallback(typeof(PipeConnection), blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(PipeConnectionInitializer))));
                builder.AddCallback(typeof(Stirer), blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(StirerInitializer))));
                builder.AddCallback(typeof(HeatExchanger), blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(HeatExchangerInitializer))));
                builder.AddCallback(typeof(HeatExchangerTubes), blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(HeatExchangerTubesInitializer))));
                builder.AddCallback(typeof(HeatExchangerWithoutCrossingFlow), blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(HeatExchangerWithoutCrossingFlowInitializer))));
                builder.AddCallback(typeof(Motor), blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(MotorInitializer))));
                builder.AddCallback(typeof(Turbine), blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(TurbineInitializer))));
                builder.AddCallback(typeof(ScrewConveyor), blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(ScrewConveyorInitializer))));
                builder.AddCallback(typeof(CeilingConveyor), blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(CeilingConveyorInitializer))));
                builder.AddCallback(typeof(Scale), blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(ScaleInitializer))));

                builder.AddCustomAttributes(typeof(BeltConveyor), "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Conveyor" }
                    }));
                builder.AddCustomAttributes(typeof(Arrow), "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Pipe" }
                    }));
                builder.AddCustomAttributes(typeof(Pump), "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Pump" }
                    }));
                builder.AddCustomAttributes(typeof(Compressor), "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Pump" }
                    }));
                builder.AddCustomAttributes(typeof(Fan), "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Pump" }
                    }));
                builder.AddCustomAttributes(typeof(Tank), "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Tank" }
                    }));
                builder.AddCustomAttributes(typeof(RoundTank), "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Tank" }
                    }));
                builder.AddCustomAttributes(typeof(Silo), "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Tank" }
                    }));
                builder.AddCustomAttributes(typeof(Valve), "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Valve" }
                    }));
                builder.AddCustomAttributes(typeof(BallValve), "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Valve" }
                    }));
                builder.AddCustomAttributes(typeof(GlobeValve), "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Valve" }
                    }));
                builder.AddCustomAttributes(typeof(MotorValve), "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Valve" }
                    }));
                builder.AddCustomAttributes(typeof(AngleValve), "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Valve" }
                    }));
                builder.AddCustomAttributes(typeof(FlapValve), "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Valve" }
                    }));
                builder.AddCustomAttributes(typeof(GateValve), "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Valve" }
                    }));
                builder.AddCustomAttributes(typeof(PistonValve), "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Valve" }
                    }));
                builder.AddCustomAttributes(typeof(ThreeWayValve), "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "ThreeWayValve" }
                    }));
                builder.AddCustomAttributes(typeof(Burner), "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Exchanger" }
                    }));
                builder.AddCustomAttributes(typeof(Cooler), "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Exchanger" }
                    }));
                builder.AddCustomAttributes(typeof(CoolingTower), "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Exchanger" }
                    }));
                builder.AddCustomAttributes(typeof(CoolingTowerWithInlet), "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Exchanger" }
                    }));
                builder.AddCustomAttributes(typeof(SprayCoolingTower), "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Exchanger" }
                    }));
                builder.AddCustomAttributes(typeof(RotaryFeeder), "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "MechanicalEquipment" }
                    }));
                builder.AddCustomAttributes(typeof(Diverter), "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "MechanicalEquipment" }
                    }));
                builder.AddCustomAttributes(typeof(Centrifugal), "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "MechanicalEquipment" }
                    }));
                builder.AddCustomAttributes(typeof(Pipe), "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Pipe" }
                    }));
                builder.AddCustomAttributes(typeof(PipeBridge), "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Pipe" }
                    }));
                builder.AddCustomAttributes(typeof(PipeConnection), "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Pipe" }
                    }));
                builder.AddCustomAttributes(typeof(Stirer), "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "MechanicalEquipment" }
                    }));
                builder.AddCustomAttributes(typeof(Scale), "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "MechanicalEquipment" }
                    }));
                builder.AddCustomAttributes(typeof(HeatExchanger), "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Exchanger" }
                    }));
                builder.AddCustomAttributes(typeof(HeatExchangerTubes), "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Exchanger" }
                    }));
                builder.AddCustomAttributes(typeof(HeatExchangerWithoutCrossingFlow), "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Exchanger" }
                    }));
                builder.AddCustomAttributes(typeof(Motor), "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Engine" }
                    }));
                builder.AddCustomAttributes(typeof(Turbine), "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Engine" }
                    }));
                builder.AddCustomAttributes(typeof(ScrewConveyor), "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Conveyor" }
                    }));
                builder.AddCustomAttributes(typeof(CeilingConveyor), "StructVariableName", new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings
                    {
                        ItemComplexFilter = ItemComplexFilter.Structure,
                        StructureNamesFilter = new List<string> { "Conveyor" }
                    }));

                return builder.CreateTable();
            }
        }

        private void SetCustomAttributes(AttributeTableBuilder builder, Type type)
        {
            List<PropertyInfo> propertyInfos = type.GetProperties().ToList();

            foreach (PropertyInfo info in propertyInfos)
            {
                switch (info.Name)
                {
                    case nameof(ProcessControlBase.StructVariableName):
                        builder.AddCustomAttributes(type, info.Name, PropertyValueEditor.CreateEditorAttribute(typeof(VariableNameDialogPropertyEditor)));
                        continue;

                    case nameof(ProcessControlBase.LocalizableLabelText):
                        builder.AddCustomAttributes(type, info.Name, PropertyValueEditor.CreateEditorAttribute(typeof(TextDialogPropertyEditor)));
                        continue;
                }
            }
        }
    }
}