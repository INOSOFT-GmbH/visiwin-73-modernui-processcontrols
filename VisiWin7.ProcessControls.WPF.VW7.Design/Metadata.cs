using Microsoft.Windows.Design.Features;
using Microsoft.Windows.Design.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using VisiWin.Controls.Design;
using VisiWin.WpfPropertyGrid;
using VisiWin7.ProcessControls.WPF.Controls;
using VisiWin7.ProcessControls.WPF.VW7.Design.Initializer;

// The ProvideMetadata assembly-level attribute indicates to designers
// that this assembly contains a class that provides an attribute table. 
[assembly: ProvideMetadata(typeof(VisiWin7.ProcessControls.WPF.VW7.Design.Metadata))]
namespace VisiWin7.ProcessControls.WPF.VW7.Design
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
                builder.AddCallback(typeof(ThickPipe), blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(ThickPipeInitializer))));
                builder.AddCallback(typeof(ThickPipeThreeWay), blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(ThickPipeThreeWayInitializer))));
                builder.AddCallback(typeof(ThickPipeCorner), blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(ThickPipeCornerInitializer))));
                builder.AddCallback(typeof(ThinPipe), blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(ThinPipeInitializer))));
                builder.AddCallback(typeof(ThinPipeBridge), blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(ThinPipeBridgeInitializer))));
                builder.AddCallback(typeof(ThinPipeConnection), blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(ThinPipeConnectionInitializer))));
                builder.AddCallback(typeof(Stirer), blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(StirerInitializer))));
                builder.AddCallback(typeof(HeatExchanger), blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(HeatExchangerInitializer))));
                builder.AddCallback(typeof(HeatExchangerTubes), blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(HeatExchangerTubesInitializer))));
                builder.AddCallback(typeof(HeatExchangerWithoutCrossingFlow), blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(HeatExchangerWithoutCrossingFlowInitializer))));
                builder.AddCallback(typeof(Motor), blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(MotorInitializer))));
                builder.AddCallback(typeof(Turbine), blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(TurbineInitializer))));
                builder.AddCallback(typeof(ScrewConveyor), blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(ScrewConveyorInitializer))));
                builder.AddCallback(typeof(CeilingConveyor), blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(CeilingConveyorInitializer))));
                builder.AddCallback(typeof(Scale), blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(ScaleInitializer))));
                
                builder.AddCustomAttributes(typeof(BeltConveyor), nameof(BeltConveyor.StructVariableName),
                    new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings { ItemComplexFilter = ItemComplexFilter.Structure }));
                builder.AddCustomAttributes(typeof(Arrow), nameof(Arrow.StructVariableName),
                    new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings { ItemComplexFilter = ItemComplexFilter.Structure }));
                builder.AddCustomAttributes(typeof(Pump), nameof(Pump.StructVariableName),
                    new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings { ItemComplexFilter = ItemComplexFilter.Structure }));
                builder.AddCustomAttributes(typeof(Compressor), nameof(Compressor.StructVariableName),
                    new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings { ItemComplexFilter = ItemComplexFilter.Structure }));
                builder.AddCustomAttributes(typeof(Fan), nameof(Fan.StructVariableName),
                    new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings { ItemComplexFilter = ItemComplexFilter.Structure }));
                builder.AddCustomAttributes(typeof(Tank), nameof(Tank.StructVariableName),
                    new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings { ItemComplexFilter = ItemComplexFilter.Structure }));
                builder.AddCustomAttributes(typeof(RoundTank), nameof(RoundTank.StructVariableName),
                    new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings { ItemComplexFilter = ItemComplexFilter.Structure }));
                builder.AddCustomAttributes(typeof(Silo), nameof(Silo.StructVariableName),
                    new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings { ItemComplexFilter = ItemComplexFilter.Structure }));
                builder.AddCustomAttributes(typeof(Valve), nameof(Valve.StructVariableName),
                    new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings { ItemComplexFilter = ItemComplexFilter.Structure }));
                builder.AddCustomAttributes(typeof(BallValve), nameof(BallValve.StructVariableName),
                    new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings { ItemComplexFilter = ItemComplexFilter.Structure }));
                builder.AddCustomAttributes(typeof(GlobeValve), nameof(GlobeValve.StructVariableName),
                    new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings { ItemComplexFilter = ItemComplexFilter.Structure }));
                builder.AddCustomAttributes(typeof(MotorValve), nameof(MotorValve.StructVariableName),
                    new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings { ItemComplexFilter = ItemComplexFilter.Structure }));
                builder.AddCustomAttributes(typeof(AngleValve), nameof(AngleValve.StructVariableName),
                    new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings { ItemComplexFilter = ItemComplexFilter.Structure }));
                builder.AddCustomAttributes(typeof(FlapValve), nameof(FlapValve.StructVariableName),
                    new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings { ItemComplexFilter = ItemComplexFilter.Structure }));
                builder.AddCustomAttributes(typeof(GateValve), nameof(GateValve.StructVariableName),
                    new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings { ItemComplexFilter = ItemComplexFilter.Structure }));
                builder.AddCustomAttributes(typeof(PistonValve), nameof(PistonValve.StructVariableName),
                    new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings { ItemComplexFilter = ItemComplexFilter.Structure }));
                builder.AddCustomAttributes(typeof(ThreeWayValve), nameof(ThreeWayValve.StructVariableName),
                    new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings { ItemComplexFilter = ItemComplexFilter.Structure }));
                builder.AddCustomAttributes(typeof(Burner), nameof(Burner.StructVariableName),
                    new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings { ItemComplexFilter = ItemComplexFilter.Structure }));
                builder.AddCustomAttributes(typeof(Cooler), nameof(Cooler.StructVariableName),
                    new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings { ItemComplexFilter = ItemComplexFilter.Structure }));
                builder.AddCustomAttributes(typeof(CoolingTower), nameof(CoolingTower.StructVariableName),
                    new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings { ItemComplexFilter = ItemComplexFilter.Structure }));
                builder.AddCustomAttributes(typeof(CoolingTowerWithInlet), nameof(CoolingTowerWithInlet.StructVariableName),
                    new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings { ItemComplexFilter = ItemComplexFilter.Structure }));
                builder.AddCustomAttributes(typeof(SprayCoolingTower), nameof(SprayCoolingTower.StructVariableName),
                    new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings { ItemComplexFilter = ItemComplexFilter.Structure }));
                builder.AddCustomAttributes(typeof(RotaryFeeder), nameof(RotaryFeeder.StructVariableName),
                    new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings { ItemComplexFilter = ItemComplexFilter.Structure }));
                builder.AddCustomAttributes(typeof(Diverter), nameof(Diverter.StructVariableName),
                    new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings { ItemComplexFilter = ItemComplexFilter.Structure }));
                builder.AddCustomAttributes(typeof(Centrifugal), nameof(Centrifugal.StructVariableName),
                    new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings { ItemComplexFilter = ItemComplexFilter.Structure }));
                builder.AddCustomAttributes(typeof(ThickPipe), nameof(ThickPipe.StructVariableName),
                    new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings { ItemComplexFilter = ItemComplexFilter.Structure }));
                builder.AddCustomAttributes(typeof(ThickPipeThreeWay), nameof(ThickPipeThreeWay.StructVariableName),
                    new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings { ItemComplexFilter = ItemComplexFilter.Structure }));
                builder.AddCustomAttributes(typeof(ThickPipeCorner), nameof(ThickPipeCorner.StructVariableName),
                    new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings { ItemComplexFilter = ItemComplexFilter.Structure }));
                builder.AddCustomAttributes(typeof(ThinPipe), nameof(ThinPipe.StructVariableName),
                    new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings { ItemComplexFilter = ItemComplexFilter.Structure }));
                builder.AddCustomAttributes(typeof(ThinPipeBridge), nameof(ThinPipeBridge.StructVariableName),
                    new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings { ItemComplexFilter = ItemComplexFilter.Structure }));
                builder.AddCustomAttributes(typeof(ThinPipeConnection), nameof(ThinPipeConnection.StructVariableName),
                    new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings { ItemComplexFilter = ItemComplexFilter.Structure }));
                builder.AddCustomAttributes(typeof(Stirer), nameof(Stirer.StructVariableName),
                    new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings { ItemComplexFilter = ItemComplexFilter.Structure }));
                builder.AddCustomAttributes(typeof(Scale), nameof(Scale.StructVariableName),
                    new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings { ItemComplexFilter = ItemComplexFilter.Structure }));
                builder.AddCustomAttributes(typeof(HeatExchangerTubes), nameof(HeatExchangerTubes.StructVariableName),
                    new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings { ItemComplexFilter = ItemComplexFilter.Structure }));
                builder.AddCustomAttributes(typeof(HeatExchangerTubes), nameof(HeatExchangerTubes.StructVariableName),
                    new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings { ItemComplexFilter = ItemComplexFilter.Structure }));
                builder.AddCustomAttributes(typeof(HeatExchangerTubes), nameof(HeatExchangerTubes.StructVariableName),
                    new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings { ItemComplexFilter = ItemComplexFilter.Structure }));
                builder.AddCustomAttributes(typeof(Motor), nameof(Motor.StructVariableName),
                    new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings { ItemComplexFilter = ItemComplexFilter.Structure }));
                builder.AddCustomAttributes(typeof(Turbine), nameof(Turbine.StructVariableName),
                    new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings { ItemComplexFilter = ItemComplexFilter.Structure }));
                builder.AddCustomAttributes(typeof(ScrewConveyor), nameof(ScrewConveyor.StructVariableName),
                    new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings { ItemComplexFilter = ItemComplexFilter.Structure }));
                builder.AddCustomAttributes(typeof(CeilingConveyor), nameof(CeilingConveyor.StructVariableName),
                    new ItemSelectionDialogSettingsAttribute(new ItemSelectionDialogSettings { ItemComplexFilter = ItemComplexFilter.Structure }));


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
                this.SetCustomAttributes(builder, typeof(ThickPipe));
                this.SetCustomAttributes(builder, typeof(ThickPipeThreeWay));
                this.SetCustomAttributes(builder, typeof(ThickPipeCorner));
                this.SetCustomAttributes(builder, typeof(ThinPipe));
                this.SetCustomAttributes(builder, typeof(ThinPipeBridge));
                this.SetCustomAttributes(builder, typeof(ThinPipeConnection));
                this.SetCustomAttributes(builder, typeof(Stirer));
                this.SetCustomAttributes(builder, typeof(Motor));
                this.SetCustomAttributes(builder, typeof(Turbine));
                this.SetCustomAttributes(builder, typeof(ScrewConveyor));
                this.SetCustomAttributes(builder, typeof(CeilingConveyor));
                this.SetCustomAttributes(builder, typeof(Scale));

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
                        builder.AddCustomAttributes(type, info.Name, new EditorAttribute(typeof(VariableNameDialogPropertyEditor), typeof(DialogPropertyEditor)));
                        builder.AddCustomAttributes(type, new DuplicateWithVariableSelectionAttribute(nameof(ProcessControlBase.StructVariableName)));

                        continue;

                    case nameof(ProcessControlBase.LocalizableLabelText):
                        builder.AddCustomAttributes(type, info.Name, new EditorAttribute(typeof(TextDialogPropertyEditor), typeof(DialogPropertyEditor)));

                        continue;
                }
            }
        }
    }
}
