using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class ProfileOperationData : buSerilization
{
	public ProfileOperationDataCircle CircleData = new ProfileOperationDataCircle();

	public ProfileOperationDataRectangle RectangleData = new ProfileOperationDataRectangle();

	public ProfileOperationDataRectangleRound RectangleRoundData = new ProfileOperationDataRectangleRound();

	public ProfileOperationDataCut CutData = new ProfileOperationDataCut();

	public ProfileOperationDataSlot SlotData = new ProfileOperationDataSlot();

	public ProfileOperationDataEllipse EllipseData = new ProfileOperationDataEllipse();

	public ProfileOperationDataNotch NotchData = new ProfileOperationDataNotch();

	public ProfileOperationDataHole HoleData = new ProfileOperationDataHole();

	public ProfileOperationDataBarel BarelData = new ProfileOperationDataBarel();

	public ProfileOperationDataFreeDraw FreeDrawData = new ProfileOperationDataFreeDraw();

	public ProfileOperationDataText TextData = new ProfileOperationDataText();

	public ProfileArray Array = new ProfileArray();

	public double DepthTopPlaneValue = 0.0;

	public double DepthLeftPlaneValue = 0.0;

	public double DepthRightPlaneValue = 0.0;

	public double DepthFreePlaneValue = 0.0;

	public double ExtraDepth = 0.0;

	public bool ExtraDepthEnable = false;

	public bool EachLayer = false;

	public bool IncrementalMode = false;

	public double SupportBlockZThickness = 0.0;

	public double SupportBlockYThickness = 0.0;

	public double ProfileLength = 0.0;

	public double PlaneSlopeLength = 10.0;

	public Pnt3D PositionLast = new Pnt3D();

	public Pnt3D Position = new Pnt3D();

	public Pnt3D PositionCircle = new Pnt3D();

	public Pnt3D PositionRectangle = new Pnt3D();

	public Pnt3D PositionRoundRect = new Pnt3D();

	public Pnt3D PositionSlot = new Pnt3D();

	public Pnt3D PositionHole = new Pnt3D();

	public Pnt3D PositionEllipse = new Pnt3D();

	public Pnt3D PositionKeyHole = new Pnt3D();

	public Pnt3D PositionText = new Pnt3D();

	public Pnt3D PositionFreeDraw = new Pnt3D();

	public Pnt3D PositionCut = new Pnt3D();

	public planeNames PlaneSelectedName = planeNames.Top;

	public WorkPlane PlaneSelected = new WorkPlane();

	public ProfileOperationTypes OperationType = ProfileOperationTypes.Circle;

	public ProfileDepth DepthData = new ProfileDepth();

	public ProfilePlaneData Plane = new ProfilePlaneData();

	public List<DepthPosition> DepthValues = new List<DepthPosition>();

	public List<DepthPosition> DepthSelectedValues = new List<DepthPosition>();

	public List<double> DepthAllPositions = new List<double>();

	public ProfileYAxisDirection YDirection = ProfileYAxisDirection.NegativeDirection;

	public static List<string> Captions = new List<string>();

	public ProfileOperationData()
	{
	}

	public ProfileOperationData(ProfileOperationData data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
		if (this != null && CopiedClass != null && GetType() == CopiedClass.GetType())
		{
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
		Array = new ProfileArray(data.Array);
		PlaneSelected = new WorkPlane(data.PlaneSelected);
		DepthData = new ProfileDepth(data.DepthData);
		Plane = new ProfilePlaneData(data.Plane);
		DepthValues.Clear();
		for (int j = 0; j <= data.DepthValues.Count - 1; j++)
		{
			DepthValues.Add(new DepthPosition(data.DepthValues[j]));
		}
		DepthSelectedValues.Clear();
		for (int k = 0; k <= data.DepthSelectedValues.Count - 1; k++)
		{
			DepthSelectedValues.Add(new DepthPosition(data.DepthSelectedValues[k]));
		}
		DepthAllPositions.Clear();
		for (int l = 0; l <= data.DepthAllPositions.Count - 1; l++)
		{
			DepthAllPositions.Add(data.DepthAllPositions[l]);
		}
		CircleData = new ProfileOperationDataCircle(data.CircleData);
		RectangleData = new ProfileOperationDataRectangle(data.RectangleData);
		RectangleRoundData = new ProfileOperationDataRectangleRound(data.RectangleRoundData);
		SlotData = new ProfileOperationDataSlot(data.SlotData);
		EllipseData = new ProfileOperationDataEllipse(data.EllipseData);
		NotchData = new ProfileOperationDataNotch(data.NotchData);
		HoleData = new ProfileOperationDataHole(data.HoleData);
		BarelData = new ProfileOperationDataBarel(data.BarelData);
		FreeDrawData = new ProfileOperationDataFreeDraw(data.FreeDrawData);
		TextData = new ProfileOperationDataText(data.TextData);
		CutData = new ProfileOperationDataCut(data.CutData);
	}

	public override string ToString()
	{
		return "OP : " + OperationType;
	}
}
