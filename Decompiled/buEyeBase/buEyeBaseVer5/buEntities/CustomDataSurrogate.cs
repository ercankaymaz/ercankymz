using buClass;
using devDept.Geometry;
using devDept.Serialization;

namespace buEyeBaseVer5.buEntities;

public class CustomDataSurrogate(CustomData obj) : Surrogate<CustomData>(obj)
{
	public string Tags;

	public string SceneName;

	public string EntityName;

	public string ActionName;

	public int CamID = -1;

	public int GroupIdIndex = -1;

	public int OriginalEntityIndex = -1;

	public int RefIndex = -1;

	public bool CamSelected;

	public bool CamSelectable = true;

	public double OrientationA;

	public double OrientationB;

	public double OrientationC;

	public entitySortDirection sortDirection;

	public entityTypeDefination typeDefination;

	public string infoString;

	public string infoData;

	public double infoLength;

	public double infoAngle;

	public double infoHeight;

	public double infoRadius;

	public double infoWidth;

	public double infoDepth;

	public double infoHeadRadius;

	public int infoSide;

	public int infoDegree;

	public double infoDirection;

	public Point3D infoBasePoint;

	public entitySplineType CurveType;

	public double camFeedrate;

	public int Sequence;

	public tuftingStitchModeType tuftingMode = tuftingStitchModeType.None;

	public double tuftingPileHeight = 0.0;

	public double tuftingStitchLength = 0.0;

	public bool DontUseForCalculation = false;

	public string ID = "";

	public string Command;

	public int EntityIndex;

	public int EntitySubIndex;

	public int ItemID;

	public int EdgeID;

	public int InsideIndex;

	protected override CustomData ConvertToObject()
	{
		CustomData customData = null;
		customData = new CustomData(Tags, EntityName, SceneName, ActionName, CamID, CamSelected, GroupIdIndex, sortDirection, infoAngle, infoBasePoint, infoDegree, infoHeadRadius, infoHeight, infoLength, infoRadius, infoSide, infoString, infoWidth, OrientationC, CurveType, camFeedrate, OriginalEntityIndex, CamSelectable, Sequence, typeDefination, infoData, infoDirection, RefIndex, infoDepth, tuftingMode, tuftingPileHeight, tuftingStitchLength, DontUseForCalculation, OrientationA, OrientationB, ID, Command, EntityIndex, EntitySubIndex, ItemID, EdgeID, InsideIndex);
		CopyDataToObject(customData);
		return customData;
	}

	protected override void CopyDataToObject(CustomData cd)
	{
		cd.Tags = Tags;
		cd.SceneName = SceneName;
		cd.EntityName = EntityName;
		cd.ActionName = ActionName;
		cd.CamID = CamID;
		cd.CamSelected = CamSelected;
		cd.CamSelectable = CamSelectable;
		cd.GroupIdIndex = GroupIdIndex;
		cd.sortDirection = sortDirection;
		cd.infoAngle = infoAngle;
		cd.infoDegree = infoDegree;
		cd.infoHeadRadius = infoHeadRadius;
		cd.infoHeight = infoHeight;
		cd.infoLength = infoLength;
		cd.infoRadius = infoRadius;
		cd.infoSide = infoSide;
		cd.infoString = infoString;
		cd.infoData = infoData;
		cd.infoWidth = infoWidth;
		cd.infoDepth = infoDepth;
		cd.infoDirection = infoDirection;
		cd.RefIndex = RefIndex;
		cd.OrientationA = OrientationA;
		cd.OrientationB = OrientationB;
		cd.OrientationC = OrientationC;
		cd.CurveType = CurveType;
		cd.CamFeedrate = camFeedrate;
		cd.OriginalEntityIndex = OriginalEntityIndex;
		cd.Sequence = Sequence;
		cd.typeDefination = typeDefination;
		cd.tuftingMode = tuftingMode;
		cd.tuftingPileHeight = tuftingPileHeight;
		cd.tuftingStitchLength = tuftingStitchLength;
		cd.DontUseForCalculation = DontUseForCalculation;
		cd.ID = ID;
		cd.Command = Command;
		cd.EntityIndex = EntityIndex;
		cd.EntitySubIndex = EntitySubIndex;
		cd.ItemID = ItemID;
		cd.EdgeID = EdgeID;
		cd.InsideIndex = InsideIndex;
		if (infoBasePoint != null)
		{
			cd.infoBasePoint = (Point3D)infoBasePoint.Clone();
		}
	}

	protected override void CopyDataFromObject(CustomData cd)
	{
		Tags = cd.Tags;
		SceneName = cd.SceneName;
		EntityName = cd.EntityName;
		ActionName = cd.ActionName;
		CamID = cd.CamID;
		CamSelected = cd.CamSelected;
		CamSelectable = cd.CamSelectable;
		GroupIdIndex = cd.GroupIdIndex;
		sortDirection = cd.sortDirection;
		infoAngle = cd.infoAngle;
		infoDegree = cd.infoDegree;
		infoHeadRadius = cd.infoHeadRadius;
		infoHeight = cd.infoHeight;
		infoLength = cd.infoLength;
		infoRadius = cd.infoRadius;
		infoSide = cd.infoSide;
		infoString = cd.infoString;
		infoData = cd.infoData;
		infoWidth = cd.infoWidth;
		infoDepth = cd.infoDepth;
		infoDirection = cd.infoDirection;
		RefIndex = cd.RefIndex;
		OrientationA = cd.OrientationA;
		OrientationB = cd.OrientationB;
		OrientationC = cd.OrientationC;
		CurveType = cd.CurveType;
		camFeedrate = cd.CamFeedrate;
		OriginalEntityIndex = cd.OriginalEntityIndex;
		Sequence = cd.Sequence;
		typeDefination = cd.typeDefination;
		tuftingMode = cd.tuftingMode;
		tuftingPileHeight = cd.tuftingPileHeight;
		tuftingStitchLength = cd.tuftingStitchLength;
		DontUseForCalculation = cd.DontUseForCalculation;
		ID = cd.ID;
		Command = cd.Command;
		EntityIndex = cd.EntityIndex;
		EntitySubIndex = cd.EntitySubIndex;
		ItemID = cd.ItemID;
		EdgeID = cd.EdgeID;
		InsideIndex = cd.InsideIndex;
		if (cd.infoBasePoint != null)
		{
			infoBasePoint = (Point3D)cd.infoBasePoint.Clone();
		}
	}

	public static implicit operator CustomData(CustomDataSurrogate surrogate)
	{
		return surrogate?.ConvertToObject();
	}

	public static implicit operator CustomDataSurrogate(CustomData source)
	{
		return source?.ConvertToSurrogate();
	}
}
