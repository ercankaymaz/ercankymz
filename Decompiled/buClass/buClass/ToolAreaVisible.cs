using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class ToolAreaVisible : buSerilization
{
	public bool Name = true;

	public bool No = true;

	public bool Sector = true;

	public bool HeightOffsetIndex = true;

	public bool Tag = true;

	public bool Purpose = true;

	public bool Clone = true;

	public bool Broken = true;

	public bool Diameter = true;

	public bool Length = true;

	public bool Thickness = true;

	public bool MinLength = true;

	public bool VectorDirection = true;

	public bool Geometry = true;

	public bool Stepover = true;

	public bool Cutover = true;

	public bool OperationHeight = true;

	public bool FeedSpeed = true;

	public bool PlungeSpeed = true;

	public bool FinishSpeed = true;

	public bool AreaClearanceSpeed = true;

	public bool SpindleSpeed = true;

	public bool OperationHeigthForSecond = true;

	public bool SafeDistance = true;

	public bool SpindleDirection = true;

	public bool SolidColor = true;

	public bool CutColor = true;

	public bool HolderColor = true;

	public bool BodyColor = true;

	public bool CamColor = true;

	public bool UpperCamColor = true;

	public bool PlungeColor = true;

	public bool LeaveColor = true;

	public bool SetPositionXYZ = true;

	public bool SetPositionABC = true;

	public bool OffsetXYZ = true;

	public bool OffsetABC = true;

	public bool AngularPosition = true;

	public bool LimitAxisA = true;

	public bool LimitAxisB = true;

	public bool LimitAxisC = true;

	public bool PlaneLimits = true;

	public bool Outputs = true;

	public bool Water = true;

	public bool Air = true;

	public bool Oil = true;

	public bool InnerCooling = true;

	public bool ToolType = true;

	public bool Priority = true;

	public bool DistanceForOrientation = true;

	public bool Size = true;

	public bool PositionAngle = true;

	public bool DataTabVisible = true;

	public bool GeometryTabVisible = true;

	public bool CamTabVisible = true;

	public bool PositionTabVisible = false;

	public bool AuxTabVisible = true;

	public bool ColorTabVisible = true;

	public bool LimitTabVisible = true;

	public ToolAreaVisible()
	{
	}

	public ToolAreaVisible(ToolAreaVisible geo)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(geo, ref CopiedClass);
		if (!(this != null && CopiedClass != null) || !(GetType() == CopiedClass.GetType()))
		{
			return;
		}
		FieldInfo[] fields = GetType().GetFields();
		if (fields != null)
		{
			for (int i = 0; i <= fields.Length - 1; i++)
			{
				string name = fields[i].Name;
				object value = fields[i].GetValue(CopiedClass);
				fields[i].SetValue(this, value);
			}
		}
	}

	public ToolAreaVisible(ToolPageVisible data)
	{
		Air = data.ShowAir;
		AngularPosition = data.ShowAngularPosition;
		AreaClearanceSpeed = data.ShowAreaClearanceVelocity;
		BodyColor = data.ShowColorBody;
		CamColor = data.ShowColorCam;
		Clone = data.ShowClone;
		CutColor = data.ShowColorToolCuttings;
		Cutover = data.ShowCutOverride;
		FeedSpeed = data.ShowFeedVelocity;
		FinishSpeed = data.ShowFinishVelocity;
		HeightOffsetIndex = data.ShowHeightOffsetIndex;
		HolderColor = data.ShowColorHolder;
		InnerCooling = data.ShowInnerCooler;
		LimitAxisA = data.ShowAxisALimits;
		LimitAxisB = data.ShowAxisBLimits;
		LimitAxisC = data.ShowAxisCLimits;
		MinLength = data.ShowMinLength;
		Name = data.ShowName;
		No = data.ShowNo;
		OffsetABC = data.ShowOffsetABC;
		OffsetXYZ = data.ShowOfsetXYZ;
		Oil = data.ShowOil;
		OperationHeight = data.ShowOperationHeight;
		OperationHeigthForSecond = data.ShowSecondHeadHeight;
		Outputs = data.ShowOutputs;
		PlaneLimits = data.ShowPlaneLimits;
		PlungeSpeed = data.ShowPlungeVelocity;
		Purpose = data.ShowPurpose;
		SafeDistance = data.ShowSafeDistance;
		Sector = data.ShowSector;
		SetPositionABC = data.ShowSetPositionABC;
		SetPositionXYZ = data.ShowSetPositionXYZ;
		SolidColor = data.ShowColorToolBody;
		SpindleDirection = data.ShowSpindleDirection;
		SpindleSpeed = data.ShowSpindleSpeed;
		Stepover = data.ShowStepOverride;
		Tag = data.ShowTag;
		ToolType = data.ShowGeometryType;
		UpperCamColor = data.ShowColorUpper;
		VectorDirection = data.ShowVector;
		Water = data.ShowWater;
		PlungeColor = data.ShowColorPlunge;
		LeaveColor = data.ShowColorLeave;
		DataTabVisible = data.ShowTabData;
		GeometryTabVisible = data.ShowTabGeometry;
		CamTabVisible = data.ShowTabCam;
		AuxTabVisible = data.ShowTabAux;
		LimitTabVisible = data.ShowTabLimit;
		PositionTabVisible = data.ShowTabPosition;
		ColorTabVisible = data.ShowTabColor;
	}
}
