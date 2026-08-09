using System;
using System.Reflection;
using buClass;

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

	public DateTime ExpireDateTime = default(DateTime);

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
		buSerilization.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null))
		{
			return;
		}
		if (GetType() == CopiedClass.GetType())
		{
			FieldInfo[] fields = GetType().GetFields();
			if (fields != null)
			{
				for (int i = 0; i <= fields.Length - 1; i++)
				{
					_ = fields[i].Name;
					object value = fields[i].GetValue(CopiedClass);
					fields[i].SetValue(this, value);
				}
			}
		}
		CompositeMode = new CompositeModes(data.CompositeMode);
		CutterMode = new CutterModes(data.CutterMode);
		DiemakerMode = new DiemakerModes(data.DiemakerMode);
		DrawMode = new DrawModes(data.DrawMode);
		DrillMode = new DrillModes(data.DrillMode);
		FileOpenMode = new FileOpenModesOptions(data.FileOpenMode);
		FileSaveMode = new FileSaveModesOptions(data.FileSaveMode);
		FlexoMode = new FlexoModes(data.FlexoMode);
		GlassCutMode = new GlassCutModes(data.GlassCutMode);
		GrindingMode = new GrindingModes(data.GrindingMode);
		JewelMode = new JewelModes(data.JewelMode);
		LaserRouterDiamekerMode = new LaserRouterDiamekerModes(data.LaserRouterDiamekerMode);
		LeatherMode = new LeatherModes(data.LeatherMode);
		MarbleMode = new MarbleModes(data.MarbleMode);
		MetalSpinningMode = new SpinningModes(data.MetalSpinningMode);
		ModuleWorkMode = new ModuleWorksModes(data.ModuleWorkMode);
		NestingMode = new NestingModes(data.NestingMode);
		PipeBendMode = new PipeBendModes(data.PipeBendMode);
		ProfileMode = new ProfileModes(data.ProfileMode);
		PunchMode = new PunchModes(data.PunchMode);
		QuiltingMode = new QuiltingModes(data.QuiltingMode);
		RoboticMode = new RoboticModes(data.RoboticMode);
		Temp2Mode = new Temp2Modes(data.Temp2Mode);
		TuftingMode = new TuftingModes(data.TuftingMode);
		ViewerMode = new ViewerModes(data.ViewerMode);
		WireBendMode = new WireBendModes(data.WireBendMode);
		WoodMode = new WoodModes(data.WoodMode);
		SewingMode = new SewingModes(data.SewingMode);
		FoamCuttingMode = new FoamCuttingModes(data.FoamCuttingMode);
		Printer3DMode = new Printer3DModes(data.Printer3DMode);
		DoorMode = new DoorModes(data.DoorMode);
		SurfaceMode = new SurfaceModes(data.SurfaceMode);
		RollerBendMode = new RollerBendModes(data.RollerBendMode);
		ToolGrindingMode = new ToolGrindingModes(data.ToolGrindingMode);
	}
}
