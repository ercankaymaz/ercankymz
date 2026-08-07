// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.appModes
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buClass;
using System;
using System.Reflection;

#nullable disable
namespace buCadCamResVer5;

public class appModes
{
  public bool TimePeriodExpire = false;
  public bool NoValidLicense = false;
  public bool DeveloperMode = false;
  public bool DeveloperPCMode = false;
  public bool LibraryMode = false;
  public bool NestingModeForce = false;
  public bool ImageProcessMode = false;
  public bool ImagingMode = false;
  public bool FootMode = false;
  public bool FootBasicMode = false;
  public bool Motion = false;
  public bool Mode2D = false;
  public bool HardKeyCmdEnable = false;
  public bool HardKeyPowerNestEnable = false;
  public bool TimeMode = false;
  public bool ExpireModeEnable = false;
  public bool DemoMode = false;
  public bool ModuleWork = false;
  public bool WorkAtMotionPC = false;
  public bool OemMode = false;
  public bool CustomMenu1 = false;
  public bool CustomMenu2 = false;
  public bool CustomMenu3 = false;
  public bool CustomMenu4 = false;
  public bool Object = false;
  public bool Kinematic = false;
  public bool Shape3D = false;
  public bool EventPage = true;
  public bool DrawingPage = true;
  public DateTime ExpireDateTime = new DateTime();
  public DiemakerModes DiemakerMode = new DiemakerModes();
  public SurfaceModes SurfaceMode = new SurfaceModes();
  public RoboticModes RoboticMode = new RoboticModes();
  public FileOpenModesOptions FileOpenMode = new FileOpenModesOptions();
  public FileSaveModesOptions FileSaveMode = new FileSaveModesOptions();
  public ViewerModes ViewerMode = new ViewerModes();
  public DrawModes DrawMode = new DrawModes();
  public Temp2Modes Temp2Mode = new Temp2Modes();
  public SpinningModes MetalSpinningMode = new SpinningModes();
  public PipeBendModes PipeBendMode = new PipeBendModes();
  public WireBendModes WireBendMode = new WireBendModes();
  public LaserRouterDiamekerModes LaserRouterDiamekerMode = new LaserRouterDiamekerModes();
  public CutterModes CutterMode = new CutterModes();
  public GlassCutModes GlassCutMode = new GlassCutModes();
  public LeatherModes LeatherMode = new LeatherModes();
  public TuftingModes TuftingMode = new TuftingModes();
  public JewelModes JewelMode = new JewelModes();
  public QuiltingModes QuiltingMode = new QuiltingModes();
  public SewingModes SewingMode = new SewingModes();
  public FoamCuttingModes FoamCuttingMode = new FoamCuttingModes();
  public MarbleModes MarbleMode = new MarbleModes();
  public ProfileModes ProfileMode = new ProfileModes();
  public FlexoModes FlexoMode = new FlexoModes();
  public WoodModes WoodMode = new WoodModes();
  public CompositeModes CompositeMode = new CompositeModes();
  public NestingModes NestingMode = new NestingModes();
  public GrindingModes GrindingMode = new GrindingModes();
  public DrillModes DrillMode = new DrillModes();
  public ModuleWorksModes ModuleWorkMode = new ModuleWorksModes();
  public PunchModes PunchMode = new PunchModes();
  public Printer3DModes Printer3DMode = new Printer3DModes();
  public DoorModes DoorMode = new DoorModes();
  public RollerBendModes RollerBendMode = new RollerBendModes();
  public ToolGrindingModes ToolGrindingMode = new ToolGrindingModes();
  public int NumberOfDemoRun = 0;
  public int NumberOfDemoOpenFile = 0;
  public bool isPowerNestDongleAvailable = false;
  public bool isPowerNestDongleInited = false;
  public bool isCMDDongleAvailable = false;
  public bool isCMDDongleInited = false;

  public appModes()
  {
  }

  public appModes(appModes data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null))
      return;
    if (this.GetType() == CopiedClass.GetType())
    {
      FieldInfo[] fields = this.GetType().GetFields();
      if (fields != null)
      {
        for (int index = 0; index <= fields.Length - 1; ++index)
        {
          string name = fields[index].Name;
          object obj = fields[index].GetValue(CopiedClass);
          fields[index].SetValue((object) this, obj);
        }
      }
    }
    this.CompositeMode = new CompositeModes(data.CompositeMode);
    this.CutterMode = new CutterModes(data.CutterMode);
    this.DiemakerMode = new DiemakerModes(data.DiemakerMode);
    this.DrawMode = new DrawModes(data.DrawMode);
    this.DrillMode = new DrillModes(data.DrillMode);
    this.FileOpenMode = new FileOpenModesOptions(data.FileOpenMode);
    this.FileSaveMode = new FileSaveModesOptions(data.FileSaveMode);
    this.FlexoMode = new FlexoModes(data.FlexoMode);
    this.GlassCutMode = new GlassCutModes(data.GlassCutMode);
    this.GrindingMode = new GrindingModes(data.GrindingMode);
    this.JewelMode = new JewelModes(data.JewelMode);
    this.LaserRouterDiamekerMode = new LaserRouterDiamekerModes(data.LaserRouterDiamekerMode);
    this.LeatherMode = new LeatherModes(data.LeatherMode);
    this.MarbleMode = new MarbleModes(data.MarbleMode);
    this.MetalSpinningMode = new SpinningModes(data.MetalSpinningMode);
    this.ModuleWorkMode = new ModuleWorksModes(data.ModuleWorkMode);
    this.NestingMode = new NestingModes(data.NestingMode);
    this.PipeBendMode = new PipeBendModes(data.PipeBendMode);
    this.ProfileMode = new ProfileModes(data.ProfileMode);
    this.PunchMode = new PunchModes(data.PunchMode);
    this.QuiltingMode = new QuiltingModes(data.QuiltingMode);
    this.RoboticMode = new RoboticModes(data.RoboticMode);
    this.Temp2Mode = new Temp2Modes(data.Temp2Mode);
    this.TuftingMode = new TuftingModes(data.TuftingMode);
    this.ViewerMode = new ViewerModes(data.ViewerMode);
    this.WireBendMode = new WireBendModes(data.WireBendMode);
    this.WoodMode = new WoodModes(data.WoodMode);
    this.SewingMode = new SewingModes(data.SewingMode);
    this.FoamCuttingMode = new FoamCuttingModes(data.FoamCuttingMode);
    this.Printer3DMode = new Printer3DModes(data.Printer3DMode);
    this.DoorMode = new DoorModes(data.DoorMode);
    this.SurfaceMode = new SurfaceModes(data.SurfaceMode);
    this.RollerBendMode = new RollerBendModes(data.RollerBendMode);
    this.ToolGrindingMode = new ToolGrindingModes(data.ToolGrindingMode);
  }
}
