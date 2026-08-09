using System.Runtime.CompilerServices;
using System.Text;
using buClass;
using devDept.Geometry;

namespace buEyeBaseVer5.buEntities;

public class CustomData
{
	[CompilerGenerated]
	private string string_0 = "";

	[CompilerGenerated]
	private string string_1 = "";

	[CompilerGenerated]
	private string string_2 = "";

	[CompilerGenerated]
	private string string_3 = "";

	[CompilerGenerated]
	private int int_0 = -1;

	[CompilerGenerated]
	private int int_1 = -1;

	[CompilerGenerated]
	private int int_2 = -1;

	[CompilerGenerated]
	private int int_3 = -1;

	[CompilerGenerated]
	private int int_4 = -1;

	[CompilerGenerated]
	private bool bool_0;

	[CompilerGenerated]
	private bool bool_1 = true;

	[CompilerGenerated]
	private bool bool_2 = false;

	[CompilerGenerated]
	private double double_0;

	[CompilerGenerated]
	private double double_1;

	[CompilerGenerated]
	private double double_2;

	[CompilerGenerated]
	private double double_3;

	[CompilerGenerated]
	private entitySortDirection entitySortDirection_0 = entitySortDirection.Normal;

	[CompilerGenerated]
	private entityTypeDefination entityTypeDefination_0 = entityTypeDefination.None;

	[CompilerGenerated]
	private string string_4;

	[CompilerGenerated]
	private string string_5;

	[CompilerGenerated]
	private double double_4;

	[CompilerGenerated]
	private double double_5;

	[CompilerGenerated]
	private double double_6;

	[CompilerGenerated]
	private double double_7;

	[CompilerGenerated]
	private double double_8;

	[CompilerGenerated]
	private double double_9;

	[CompilerGenerated]
	private double double_10;

	[CompilerGenerated]
	private double double_11;

	[CompilerGenerated]
	private int int_5;

	[CompilerGenerated]
	private int int_6 = 1;

	[CompilerGenerated]
	private Point3D point3D_0;

	[CompilerGenerated]
	private entitySplineType entitySplineType_0;

	[CompilerGenerated]
	private int int_7;

	[CompilerGenerated]
	private tuftingStitchModeType tuftingStitchModeType_0 = tuftingStitchModeType.None;

	[CompilerGenerated]
	private double double_12 = 0.0;

	[CompilerGenerated]
	private double double_13 = 0.0;

	[CompilerGenerated]
	private string string_6 = "";

	[CompilerGenerated]
	private string string_7 = "";

	[CompilerGenerated]
	private int int_8 = -1;

	[CompilerGenerated]
	private int int_9 = -1;

	[CompilerGenerated]
	private int int_10 = -1;

	[CompilerGenerated]
	private int int_11 = -1;

	[CompilerGenerated]
	private int int_12 = -1;

	public string Tags
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		set
		{
			string_0 = value;
		}
	}

	public string SceneName
	{
		[CompilerGenerated]
		get
		{
			return string_1;
		}
		[CompilerGenerated]
		set
		{
			string_1 = value;
		}
	}

	public string EntityName
	{
		[CompilerGenerated]
		get
		{
			return string_2;
		}
		[CompilerGenerated]
		set
		{
			string_2 = value;
		}
	}

	public string ActionName
	{
		[CompilerGenerated]
		get
		{
			return string_3;
		}
		[CompilerGenerated]
		set
		{
			string_3 = value;
		}
	}

	public int ItemID
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		set
		{
			int_0 = value;
		}
	}

	public int CamID
	{
		[CompilerGenerated]
		get
		{
			return int_1;
		}
		[CompilerGenerated]
		set
		{
			int_1 = value;
		}
	}

	public int GroupIdIndex
	{
		[CompilerGenerated]
		get
		{
			return int_2;
		}
		[CompilerGenerated]
		set
		{
			int_2 = value;
		}
	}

	public int OriginalEntityIndex
	{
		[CompilerGenerated]
		get
		{
			return int_3;
		}
		[CompilerGenerated]
		set
		{
			int_3 = value;
		}
	}

	public int RefIndex
	{
		[CompilerGenerated]
		get
		{
			return int_4;
		}
		[CompilerGenerated]
		set
		{
			int_4 = value;
		}
	}

	public bool CamSelected
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}

	public bool CamSelectable
	{
		[CompilerGenerated]
		get
		{
			return bool_1;
		}
		[CompilerGenerated]
		set
		{
			bool_1 = value;
		}
	}

	public bool DontUseForCalculation
	{
		[CompilerGenerated]
		get
		{
			return bool_2;
		}
		[CompilerGenerated]
		set
		{
			bool_2 = value;
		}
	}

	public double CamFeedrate
	{
		[CompilerGenerated]
		get
		{
			return double_0;
		}
		[CompilerGenerated]
		set
		{
			double_0 = value;
		}
	}

	public double OrientationA
	{
		[CompilerGenerated]
		get
		{
			return double_1;
		}
		[CompilerGenerated]
		set
		{
			double_1 = value;
		}
	}

	public double OrientationB
	{
		[CompilerGenerated]
		get
		{
			return double_2;
		}
		[CompilerGenerated]
		set
		{
			double_2 = value;
		}
	}

	public double OrientationC
	{
		[CompilerGenerated]
		get
		{
			return double_3;
		}
		[CompilerGenerated]
		set
		{
			double_3 = value;
		}
	}

	public entitySortDirection sortDirection
	{
		[CompilerGenerated]
		get
		{
			return entitySortDirection_0;
		}
		[CompilerGenerated]
		set
		{
			entitySortDirection_0 = value;
		}
	}

	public entityTypeDefination typeDefination
	{
		[CompilerGenerated]
		get
		{
			return entityTypeDefination_0;
		}
		[CompilerGenerated]
		set
		{
			entityTypeDefination_0 = value;
		}
	}

	public string infoString
	{
		[CompilerGenerated]
		get
		{
			return string_4;
		}
		[CompilerGenerated]
		set
		{
			string_4 = value;
		}
	}

	public string infoData
	{
		[CompilerGenerated]
		get
		{
			return string_5;
		}
		[CompilerGenerated]
		set
		{
			string_5 = value;
		}
	}

	public double infoLength
	{
		[CompilerGenerated]
		get
		{
			return double_4;
		}
		[CompilerGenerated]
		set
		{
			double_4 = value;
		}
	}

	public double infoAngle
	{
		[CompilerGenerated]
		get
		{
			return double_5;
		}
		[CompilerGenerated]
		set
		{
			double_5 = value;
		}
	}

	public double infoDirection
	{
		[CompilerGenerated]
		get
		{
			return double_6;
		}
		[CompilerGenerated]
		set
		{
			double_6 = value;
		}
	}

	public double infoHeight
	{
		[CompilerGenerated]
		get
		{
			return double_7;
		}
		[CompilerGenerated]
		set
		{
			double_7 = value;
		}
	}

	public double infoRadius
	{
		[CompilerGenerated]
		get
		{
			return double_8;
		}
		[CompilerGenerated]
		set
		{
			double_8 = value;
		}
	}

	public double infoWidth
	{
		[CompilerGenerated]
		get
		{
			return double_9;
		}
		[CompilerGenerated]
		set
		{
			double_9 = value;
		}
	}

	public double infoDepth
	{
		[CompilerGenerated]
		get
		{
			return double_10;
		}
		[CompilerGenerated]
		set
		{
			double_10 = value;
		}
	}

	public double infoHeadRadius
	{
		[CompilerGenerated]
		get
		{
			return double_11;
		}
		[CompilerGenerated]
		set
		{
			double_11 = value;
		}
	}

	public int infoSide
	{
		[CompilerGenerated]
		get
		{
			return int_5;
		}
		[CompilerGenerated]
		set
		{
			int_5 = value;
		}
	}

	public int infoDegree
	{
		[CompilerGenerated]
		get
		{
			return int_6;
		}
		[CompilerGenerated]
		set
		{
			int_6 = value;
		}
	}

	public Point3D infoBasePoint
	{
		[CompilerGenerated]
		get
		{
			return point3D_0;
		}
		[CompilerGenerated]
		set
		{
			point3D_0 = value;
		}
	}

	public entitySplineType CurveType
	{
		[CompilerGenerated]
		get
		{
			return entitySplineType_0;
		}
		[CompilerGenerated]
		set
		{
			entitySplineType_0 = value;
		}
	}

	public int Sequence
	{
		[CompilerGenerated]
		get
		{
			return int_7;
		}
		[CompilerGenerated]
		set
		{
			int_7 = value;
		}
	}

	public tuftingStitchModeType tuftingMode
	{
		[CompilerGenerated]
		get
		{
			return tuftingStitchModeType_0;
		}
		[CompilerGenerated]
		set
		{
			tuftingStitchModeType_0 = value;
		}
	}

	public double tuftingPileHeight
	{
		[CompilerGenerated]
		get
		{
			return double_12;
		}
		[CompilerGenerated]
		set
		{
			double_12 = value;
		}
	}

	public double tuftingStitchLength
	{
		[CompilerGenerated]
		get
		{
			return double_13;
		}
		[CompilerGenerated]
		set
		{
			double_13 = value;
		}
	}

	public string ID
	{
		[CompilerGenerated]
		get
		{
			return string_6;
		}
		[CompilerGenerated]
		set
		{
			string_6 = value;
		}
	}

	public string Command
	{
		[CompilerGenerated]
		get
		{
			return string_7;
		}
		[CompilerGenerated]
		set
		{
			string_7 = value;
		}
	}

	public int EntityIndex
	{
		[CompilerGenerated]
		get
		{
			return int_8;
		}
		[CompilerGenerated]
		set
		{
			int_8 = value;
		}
	}

	public int EntitySubIndex
	{
		[CompilerGenerated]
		get
		{
			return int_9;
		}
		[CompilerGenerated]
		set
		{
			int_9 = value;
		}
	}

	public int CamIndex
	{
		[CompilerGenerated]
		get
		{
			return int_10;
		}
		[CompilerGenerated]
		set
		{
			int_10 = value;
		}
	}

	public int EdgeID
	{
		[CompilerGenerated]
		get
		{
			return int_11;
		}
		[CompilerGenerated]
		set
		{
			int_11 = value;
		}
	}

	public int InsideIndex
	{
		[CompilerGenerated]
		get
		{
			return int_12;
		}
		[CompilerGenerated]
		set
		{
			int_12 = value;
		}
	}

	public CustomData()
	{
	}

	public CustomData(entityTypeDefination type)
	{
		typeDefination = type;
	}

	public CustomData(string tags, string entityname, string scenename, string actionname, int camid, bool camselected, int groupindex, entitySortDirection sortdir, double infoangle, Point3D infobasepnt, int infodegree, double infoheadrad, double infoheight, double infolength, double inforadius, int infoside, string infostring, double infowidth, double orientationc, entitySplineType curvetype, double camfeedrate, int originalentityindex, bool camselectable, int sequence, entityTypeDefination typedefination, string infodata, double infodirection, int refindex, double infodepth, tuftingStitchModeType tuftingmode, double tuftingpileheight, double tuftingstitchlen, bool dontuseforcalculation, double orientationa, double orientationb, string id, string command, int entityindex, int entitysubindex, int itemid, int edgeid, int insideindex)
	{
		Tags = tags;
		EntityName = entityname;
		SceneName = scenename;
		ActionName = actionname;
		CamID = camid;
		CamSelected = camselected;
		CamSelectable = camselectable;
		GroupIdIndex = groupindex;
		sortDirection = sortDirection;
		infoAngle = infoangle;
		if (infoBasePoint != null)
		{
			infoBasePoint = new Point3D(infoBasePoint.X, infoBasePoint.Y, infoBasePoint.Z);
		}
		infoDegree = infodegree;
		infoHeadRadius = infoheadrad;
		infoHeight = infoheight;
		infoLength = infolength;
		infoRadius = inforadius;
		infoSide = infoside;
		infoString = infostring;
		infoWidth = infowidth;
		infoDepth = infodepth;
		infoData = infodata;
		infoDirection = infodirection;
		RefIndex = refindex;
		OrientationA = orientationa;
		OrientationB = orientationb;
		OrientationC = orientationc;
		CurveType = curvetype;
		CamFeedrate = camfeedrate;
		OriginalEntityIndex = originalentityindex;
		Sequence = sequence;
		typeDefination = typedefination;
		tuftingMode = tuftingmode;
		tuftingPileHeight = tuftingpileheight;
		tuftingStitchLength = tuftingstitchlen;
		DontUseForCalculation = dontuseforcalculation;
		ID = id;
		Command = command;
		EntityIndex = entityindex;
		EntitySubIndex = entitysubindex;
		ItemID = itemid;
		EdgeID = edgeid;
		InsideIndex = insideindex;
	}

	public CustomData(CustomData Data)
	{
		if (Data == null)
		{
			Data = new CustomData();
		}
		Tags = Data.Tags;
		EntityName = Data.EntityName;
		SceneName = Data.SceneName;
		ActionName = Data.ActionName;
		CamID = Data.CamID;
		CamSelected = Data.CamSelected;
		CamSelectable = Data.CamSelectable;
		GroupIdIndex = Data.GroupIdIndex;
		sortDirection = Data.sortDirection;
		infoAngle = Data.infoAngle;
		if (Data.infoBasePoint != null)
		{
			infoBasePoint = new Point3D(Data.infoBasePoint.X, Data.infoBasePoint.Y, Data.infoBasePoint.Z);
		}
		OrientationA = Data.OrientationA;
		OrientationB = Data.OrientationB;
		OrientationC = Data.OrientationC;
		infoDegree = Data.infoDegree;
		infoHeadRadius = Data.infoHeadRadius;
		infoHeight = Data.infoHeight;
		infoLength = Data.infoLength;
		infoRadius = Data.infoRadius;
		infoSide = Data.infoSide;
		infoString = Data.infoString;
		infoData = Data.infoData;
		infoWidth = Data.infoWidth;
		infoDirection = Data.infoDirection;
		infoWidth = Data.infoWidth;
		RefIndex = Data.RefIndex;
		CurveType = Data.CurveType;
		CamFeedrate = Data.CamFeedrate;
		typeDefination = Data.typeDefination;
		OriginalEntityIndex = Data.OriginalEntityIndex;
		Sequence = Data.Sequence;
		tuftingStitchLength = Data.tuftingStitchLength;
		tuftingPileHeight = Data.tuftingPileHeight;
		tuftingMode = Data.tuftingMode;
		DontUseForCalculation = Data.DontUseForCalculation;
		ID = Data.ID;
		Command = Data.Command;
		EntityIndex = Data.EntityIndex;
		EntitySubIndex = Data.EntitySubIndex;
		ItemID = Data.ItemID;
		EdgeID = Data.EdgeID;
		InsideIndex = Data.InsideIndex;
	}

	public virtual string Dump()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("Tags = " + Tags);
		stringBuilder.AppendLine("SceneName = " + SceneName);
		stringBuilder.AppendLine("EntityName = " + EntityName);
		stringBuilder.AppendLine("ActionName = " + ActionName);
		stringBuilder.AppendLine("CamID = " + CamID);
		stringBuilder.AppendLine("GroupIdIndex = " + GroupIdIndex);
		stringBuilder.AppendLine("CamSelected = " + CamSelected);
		stringBuilder.AppendLine("sortDirection = " + sortDirection);
		stringBuilder.AppendLine("infoString = " + infoString);
		stringBuilder.AppendLine("infoLength = " + infoLength);
		stringBuilder.AppendLine("infoAngle = " + infoAngle);
		stringBuilder.AppendLine("infoHeight = " + infoHeight);
		stringBuilder.AppendLine("infoRadius = " + infoRadius);
		stringBuilder.AppendLine("infoWidth = " + infoWidth);
		stringBuilder.AppendLine("infoHeadRadius = " + infoHeadRadius);
		stringBuilder.AppendLine("infoSide = " + infoSide);
		stringBuilder.AppendLine("infoDegree = " + infoDegree);
		stringBuilder.AppendLine("infoBasePoint = " + infoBasePoint);
		stringBuilder.AppendLine("OrientationC = " + OrientationC);
		stringBuilder.AppendLine("CurveType = " + CurveType);
		stringBuilder.AppendLine("CamFeedrate = " + CamFeedrate);
		stringBuilder.AppendLine("OriginalEntityIndex = " + OriginalEntityIndex);
		stringBuilder.AppendLine("CamSelectable = " + CamSelectable);
		stringBuilder.AppendLine("Sequence = " + Sequence);
		stringBuilder.AppendLine("typeDefination = " + typeDefination);
		stringBuilder.AppendLine("infoData = " + infoData);
		stringBuilder.AppendLine("infoDirection = " + infoDirection);
		stringBuilder.AppendLine("RefIndex = " + RefIndex);
		stringBuilder.AppendLine("infoDepth = " + infoDepth);
		stringBuilder.AppendLine("tuftingMode = " + tuftingMode);
		stringBuilder.AppendLine("tuftingPileHeight = " + tuftingPileHeight);
		stringBuilder.AppendLine("tuftingStitchLength = " + tuftingStitchLength);
		stringBuilder.AppendLine("DontUseForCalculation = " + DontUseForCalculation);
		stringBuilder.AppendLine("OrientationA = " + OrientationA);
		stringBuilder.AppendLine("OrientationB = " + OrientationB);
		stringBuilder.AppendLine("ID = " + ID);
		stringBuilder.AppendLine("Command = " + Command);
		stringBuilder.AppendLine("EntityIndex = " + EntityIndex);
		stringBuilder.AppendLine("EntitySubIndex = " + EntitySubIndex);
		stringBuilder.AppendLine("CamIndex = " + CamIndex);
		stringBuilder.AppendLine("ItemID = " + ItemID);
		stringBuilder.AppendLine("EdgeID = " + EdgeID);
		stringBuilder.AppendLine("InsideIndex = " + InsideIndex);
		return stringBuilder.ToString();
	}

	public virtual CustomDataSurrogate ConvertToSurrogate()
	{
		return new CustomDataSurrogate(this);
	}
}
