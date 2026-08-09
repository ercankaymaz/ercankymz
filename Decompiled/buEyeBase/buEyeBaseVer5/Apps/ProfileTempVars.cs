using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;
using buClass.Apps;
using buEyeBaseVer5.buEntities;
using devDept.Geometry;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class ProfileTempVars : buSerilization5
{
	public static string strRectangle = "Rectangle";

	public static string strCircle = "Circle";

	public static string strEllipse = "Ellipse";

	public static string strHole = "Hole";

	public static string strKeyHole = "Key Hole";

	public static string strRoundRect = "Round Rect";

	public static string strSlot = "Slot";

	public static string strNotch = "Notch";

	public static string strFreeDraw = "Free";

	public static string strText = "Text";

	public static string strCut = "Cut";

	public static string strPoylgon = "Polygon";

	public static string LayerNameProfile = "Profile";

	public static string LayerNameOperation = "Operation";

	public static string LayerNameCam = "Cam";

	public static string LayerNameContour = "Contour";

	public static string LastCreatedProfileEntityName = "";

	public static int LastCreatedProfileEntityIndex = -1;

	public static bool OperationEditing = false;

	public static bool MultiOperationStarted = false;

	public static bool ClamperMoved = false;

	public static double TemplateXOffset = 0.0;

	public static bool TemplateScaleUseX = false;

	public static bool TemplateScaleUseYZ = false;

	public static double TemplateXScaleRatio = 1.0;

	public static double TemplateYZScaleRatio = 1.0;

	public static int MainBottomTabIndex = 0;

	public static double PlaneIncrement = 1.0;

	public static int PlaneSelectedIndex = -1;

	public static bool PlaneInited = false;

	public static bool DepthInited = false;

	public static bool TemplateMode = false;

	public static bool CamAssinged = false;

	public static bool DepthForced = false;

	public static int DepthSelectedIndex = -1;

	public static bool RotateKeyKole = false;

	public static bool ChangeCamDir = false;

	public static Pnt6DSimMove P6SimMachine = new Pnt6DSimMove();

	public static Pnt6D P6SimTool = new Pnt6D();

	public static Point3D P3SimTool = new Point3D();

	public static Point3D PntPatternDxf = new Point3D();

	public static OrientationAngle PAngleSimTool = new OrientationAngle();

	public bool AutoToolFind = false;

	public bool ShowProgressCam = true;

	public bool MeasureActive = false;

	public bool DrawMouseDown = false;

	public static bool PatternDxfOperation = false;

	public buShape lastShape = null;

	public static ProfileOperation CreatingOperation = null;

	public Point3D pntMouseDown = null;

	public ViewportRefType ViewportRef = ViewportRefType.Editor;

	public planeBoxNames activePlane = planeBoxNames.Top;

	public ProfileJobType JobItemType = ProfileJobType.Left;

	public int selectedProfileIndex = -1;

	public int selectedItemIndex = -1;

	public static bool DontMoveClamperForPark = false;

	public int LastGCodeLine = 10;

	public static ProfileMultiSelectedOperation MultiSelectedProps = new ProfileMultiSelectedOperation();

	public static List<ProfileOperation> SelectedOperations = new List<ProfileOperation>();

	public static List<DepthPositions> OperationDepths = new List<DepthPositions>();

	public List<MacroItem> Macros = new List<MacroItem>();

	public static List<ProfileClamper> LastClampers = new List<ProfileClamper>();

	public ProfileTempVars()
	{
	}

	public ProfileTempVars(ProfileTempVars data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null) || !(GetType() == CopiedClass.GetType()))
		{
			return;
		}
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
}
