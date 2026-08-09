using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;
using buEyeBaseVer5.buEntities;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class GProfileOperation : buSerilization5
{
	public double Depth = 0.0;

	public string ProfileName = "";

	public double ProfileWidth = 0.0;

	public double ProfileHeight = 0.0;

	public double ProfileLength = 0.0;

	public string Name = "";

	public string ID = "";

	public bool Used = false;

	public bool Enable = true;

	public bool isClamperOver = false;

	public bool MoveSafeBeforeOperation = false;

	public bool MoveSafeAfterOperation = false;

	public bool Error = false;

	public bool isCollision = false;

	public bool Calculated = false;

	public bool Selected = false;

	public int Priority = 0;

	public int ClamperIndex = -1;

	public int CollisionClamperIndex = -1;

	public actionTypeBU Action = actionTypeBU.None;

	public LeftRightType XReferanceLocation = LeftRightType.Left;

	public ProfileOperationData OperationData = new ProfileOperationData();

	public ProfileOperationCamData CamOPData = new ProfileOperationCamData();

	public List<camTp> CamCalculation = new List<camTp>();

	public ToolBase5 Tool = new ToolBase5();

	public BoxSize5 SizePoint = new BoxSize5();

	public List<ProfileClamper> Clampers = new List<ProfileClamper>();

	public List<buEntity> EntityMultiCam = null;

	public GProfileOperation()
	{
	}

	public GProfileOperation(GProfileOperation data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
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
		Clampers.Clear();
		Clampers = new List<ProfileClamper>();
		for (int j = 0; j <= data.Clampers.Count - 1; j++)
		{
			ProfileClamper item = new ProfileClamper(data.Clampers[j]);
			Clampers.Add(item);
		}
		OperationData = new ProfileOperationData(data.OperationData);
		CamOPData = new ProfileOperationCamData(data.CamOPData);
		Tool = new ToolBase5(data.Tool);
		SizePoint = new BoxSize5(data.SizePoint);
		CamCalculation = new List<camTp>();
		for (int k = 0; k <= data.CamCalculation.Count - 1; k++)
		{
			camTp item2 = new camTp(data.CamCalculation[k]);
			CamCalculation.Add(item2);
		}
		if (data.EntityMultiCam != null)
		{
			EntityMultiCam = buEntity.Copy(data.EntityMultiCam);
		}
	}

	public GProfileOperation(ProfileOperation Operation)
	{
		Error = Operation.Error;
		Depth = Operation.Depth;
		Action = Operation.Action;
		Enable = Operation.Enable;
		ID = Operation.ID;
		isClamperOver = Operation.isClamperOver;
		MoveSafeAfterOperation = Operation.MoveSafeAfterOperation;
		MoveSafeBeforeOperation = Operation.MoveSafeBeforeOperation;
		Name = Operation.Name;
		ProfileHeight = Operation.ProfileHeight;
		ProfileLength = Operation.ProfileLength;
		ProfileWidth = Operation.ProfileWidth;
		ProfileName = Operation.ProfileName;
		Used = Operation.Used;
		Priority = Operation.Priority;
		XReferanceLocation = Operation.ParentXReferance;
		OperationData = new ProfileOperationData(Operation.OperationData);
		CamOPData = new ProfileOperationCamData(Operation.CamOPData);
		Tool = new ToolBase5(Operation.Tool);
		SizePoint = new BoxSize5(Operation.MinPoint, Operation.MaxPoint);
		Clampers.Clear();
		for (int i = 0; i <= Operation.Clampers.Count - 1; i++)
		{
			Clampers.Add(new ProfileClamper(Operation.Clampers[i]));
		}
		if (Operation.EntityMultiCam != null)
		{
			EntityMultiCam = buEntity.Copy(Operation.EntityMultiCam);
		}
		CamCalculation = new List<camTp>();
		for (int j = 0; j <= Operation.CamCalculation.Count - 1; j++)
		{
			camTp item = new camTp(Operation.CamCalculation[j]);
			CamCalculation.Add(item);
		}
	}

	public static void Copy(List<List<GProfileOperation>> RefOperation, ref List<List<GProfileOperation>> CopiedOperation)
	{
		CopiedOperation.Clear();
		CopiedOperation = new List<List<GProfileOperation>>();
		for (int i = 0; i <= RefOperation.Count - 1; i++)
		{
			List<GProfileOperation> CopiedOperation2 = new List<GProfileOperation>();
			Copy(RefOperation[i], ref CopiedOperation2);
			CopiedOperation.Add(CopiedOperation2);
		}
	}

	public static void Copy(List<GProfileOperation> RefOperation, ref List<GProfileOperation> CopiedOperation)
	{
		CopiedOperation.Clear();
		CopiedOperation = new List<GProfileOperation>();
		for (int i = 0; i <= RefOperation.Count - 1; i++)
		{
			GProfileOperation CopiedOperation2 = new GProfileOperation();
			Copy(RefOperation[i], ref CopiedOperation2);
			CopiedOperation.Add(CopiedOperation2);
		}
	}

	public static void Copy(GProfileOperation RefOperation, ref GProfileOperation CopiedOperation)
	{
		CopiedOperation = new GProfileOperation(RefOperation);
	}

	public override string ToString()
	{
		string text = OperationData.OperationType.ToString() + " =  " + OperationData.selectedPlaneName.ToString() + " - P( " + OperationData.Position.X.ToString("f2") + " , ";
		if (!((OperationData.selectedPlaneName == planeNames.Top) | (OperationData.selectedPlaneName == planeNames.Bottom) | (OperationData.selectedPlaneName == planeNames.Free)))
		{
			if ((OperationData.selectedPlaneName == planeNames.Front) | (OperationData.selectedPlaneName == planeNames.Back))
			{
				text = text + OperationData.Position.Z.ToString("f2") + " )";
			}
		}
		else
		{
			text = text + OperationData.Position.Y.ToString("f2") + " )";
		}
		text = text + " , MinX: " + SizePoint.MinPoint.X.ToString("f2") + " , MaxX: " + SizePoint.MaxPoint.X.ToString("f2");
		return text + " - T" + Tool.Data.No + " Dia: " + Tool.Geometry.Diameter + " ID: " + ID;
	}
}
