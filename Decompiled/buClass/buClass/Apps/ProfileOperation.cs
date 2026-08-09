using System;
using System.Collections;
using System.Collections.Generic;

namespace buClass.Apps;

[Serializable]
public class ProfileOperation : buSerilization
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

	public double Depth = 0.0;

	public string Name = "";

	public string ID = "";

	public bool Used = false;

	public bool Enable = true;

	public bool isClamperOver = false;

	public bool MoveSafeBeforeOperation = false;

	public bool MoveSafeAfterOperation = false;

	public ProfileOperationData OperationData = new ProfileOperationData();

	public WorkPlane Plane = new WorkPlane();

	public Quad3D SlopePlane = new Quad3D();

	public planeNames SelectedPlane = planeNames.Top;

	public List<List<eEntities>> Entities = new List<List<eEntities>>();

	public List<List<eEntities>> NoRotatedEntities = new List<List<eEntities>>();

	public List<eEntities> SolidEntities = new List<eEntities>();

	public List<eEntities> AuxEntities = new List<eEntities>();

	public List<List<Pnt3D>> DrawPoints = new List<List<Pnt3D>>();

	public List<List<Pnt3D>> NoRotatedDrawPoints = new List<List<Pnt3D>>();

	public List<List<Pnt3D>> CamPoints = new List<List<Pnt3D>>();

	public List<camBase> CamCalculation = new List<camBase>();

	public camParameters CamParMilling = new camParameters();

	public camParameters CamParNotch = new camParameters();

	public ToolBase Tool = new ToolBase();

	public Pnt3D MinPoint = new Pnt3D();

	public Pnt3D MaxPoint = new Pnt3D();

	public Length3D GeoSize = new Length3D();

	public actionTypeBU Action = actionTypeBU.None;

	public List<ProfileClamper> ClampersOperations = new List<ProfileClamper>();

	public bool Error = false;

	public static void Copy(List<List<ProfileOperation>> RefOperation, ref List<List<ProfileOperation>> CopiedOperation)
	{
		CopiedOperation.Clear();
		CopiedOperation = new List<List<ProfileOperation>>();
		for (int i = 0; i <= RefOperation.Count - 1; i++)
		{
			List<ProfileOperation> CopiedOperation2 = new List<ProfileOperation>();
			Copy(RefOperation[i], ref CopiedOperation2);
			CopiedOperation.Add(CopiedOperation2);
		}
	}

	public static void Copy(List<ProfileOperation> RefOperation, ref List<ProfileOperation> CopiedOperation)
	{
		CopiedOperation.Clear();
		CopiedOperation = new List<ProfileOperation>();
		for (int i = 0; i <= RefOperation.Count - 1; i++)
		{
			ProfileOperation CopiedOperation2 = new ProfileOperation();
			Copy(RefOperation[i], ref CopiedOperation2);
			CopiedOperation.Add(CopiedOperation2);
		}
	}

	public static void Copy(ProfileOperation RefOperation, ref ProfileOperation CopiedOperation)
	{
		if (RefOperation.GetType() == typeof(ProfileOperationCircle))
		{
			CopiedOperation = new ProfileOperationCircle((ProfileOperationCircle)RefOperation);
		}
		if (RefOperation.GetType() == typeof(ProfileOperationRectangle))
		{
			CopiedOperation = new ProfileOperationRectangle((ProfileOperationRectangle)RefOperation);
		}
		if (RefOperation.GetType() == typeof(ProfileOperationRoundRectangle))
		{
			CopiedOperation = new ProfileOperationRoundRectangle((ProfileOperationRoundRectangle)RefOperation);
		}
		if (RefOperation.GetType() == typeof(ProfileOperationBarrel))
		{
			CopiedOperation = new ProfileOperationBarrel((ProfileOperationBarrel)RefOperation);
		}
		if (RefOperation.GetType() == typeof(ProfileOperationEllipse))
		{
			CopiedOperation = new ProfileOperationEllipse((ProfileOperationEllipse)RefOperation);
		}
		if (RefOperation.GetType() == typeof(ProfileOperationFreeDraw))
		{
			CopiedOperation = new ProfileOperationFreeDraw((ProfileOperationFreeDraw)RefOperation);
		}
		if (RefOperation.GetType() == typeof(ProfileOperationText))
		{
			CopiedOperation = new ProfileOperationText((ProfileOperationText)RefOperation);
		}
		if (RefOperation.GetType() == typeof(ProfileOperationHole))
		{
			CopiedOperation = new ProfileOperationHole((ProfileOperationHole)RefOperation);
		}
		if (RefOperation.GetType() == typeof(ProfileOperationSlot))
		{
			CopiedOperation = new ProfileOperationSlot((ProfileOperationSlot)RefOperation);
		}
		if (RefOperation.GetType() == typeof(ProfileOperationCut))
		{
			CopiedOperation = new ProfileOperationCut((ProfileOperationCut)RefOperation);
		}
		if (RefOperation.GetType() == typeof(ProfileOperationNotch))
		{
			CopiedOperation = new ProfileOperationNotch((ProfileOperationNotch)RefOperation);
		}
		if (RefOperation.GetType() == typeof(ProfileOperationMoveClamper))
		{
			CopiedOperation = new ProfileOperationMoveClamper((ProfileOperationMoveClamper)RefOperation);
		}
		CopiedOperation.ClampersOperations.Clear();
		CopiedOperation.ClampersOperations = new List<ProfileClamper>();
		for (int i = 0; i <= RefOperation.ClampersOperations.Count - 1; i++)
		{
			ProfileClamper item = new ProfileClamper(RefOperation.ClampersOperations[i]);
			CopiedOperation.ClampersOperations.Add(item);
		}
		CopiedOperation.Entities.Clear();
		eEntities.CopyEntities(RefOperation.Entities, ref CopiedOperation.Entities);
		CopiedOperation.AuxEntities.Clear();
		eEntities.CopyEntities(RefOperation.AuxEntities, ref CopiedOperation.AuxEntities);
		CopiedOperation.SolidEntities.Clear();
		eEntities.CopyEntities(RefOperation.SolidEntities, ref CopiedOperation.SolidEntities);
		CopiedOperation.NoRotatedEntities.Clear();
		eEntities.CopyEntities(RefOperation.NoRotatedEntities, ref CopiedOperation.NoRotatedEntities);
		CopiedOperation.CamCalculation.Clear();
		CopiedOperation.CamCalculation = new List<camBase>();
		for (int j = 0; j <= RefOperation.CamCalculation.Count - 1; j++)
		{
			camBase item2 = new camBase(RefOperation.CamCalculation[j]);
			CopiedOperation.CamCalculation.Add(item2);
		}
	}

	public static ArrayList ToDef(List<List<ProfileOperation>> Items, string Char, int Space)
	{
		string text = new string(' ', Space + 2);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i <= Items.Count - 1; i++)
		{
			ArrayList arrayList2 = new ArrayList();
			arrayList2.Add(text + "<ProfileOperationMain>");
			for (int j = 0; j <= Items[i].Count - 1; j++)
			{
				arrayList2.Add(text + "<ProfileOperation>");
				arrayList2.AddRange(ToDef(Items[i], Char, Space + 2).ToArray());
				arrayList2.Add(text + "</ProfileOperation>");
			}
			arrayList2.Add(text + "</ProfileOperationMain>");
			arrayList.AddRange(arrayList2.ToArray());
		}
		return arrayList;
	}

	public static ArrayList ToDef(List<ProfileOperation> Items, string Char, int Space)
	{
		string text = new string(' ', Space + 2);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i <= Items.Count - 1; i++)
		{
			ArrayList arrayList2 = new ArrayList();
			arrayList2.Add(text + "<ProfileOperation" + Char + ">");
			arrayList2.AddRange(ToDef(Items[i], "", Space + 2).ToArray());
			arrayList2.Add(text + "</ProfileOperation" + Char + ">");
			arrayList.AddRange(arrayList2.ToArray());
		}
		return arrayList;
	}

	public static ArrayList ToDef(ProfileOperation Item, string Char, int Space)
	{
		string text = new string(' ', Space);
		ArrayList arrayList = new ArrayList();
		arrayList.AddRange(Item.ToDefAll(Char, Space + 2, SerilizationMode.MultiLine));
		arrayList.AddRange(Item.OperationData.CircleData.ToDefAll(Char, Space + 2, SerilizationMode.MultiLine));
		arrayList.AddRange(Item.OperationData.RectangleData.ToDefAll(Char, Space + 2, SerilizationMode.MultiLine));
		arrayList.AddRange(Item.OperationData.BarelData.ToDefAll(Char, Space + 2, SerilizationMode.MultiLine));
		arrayList.AddRange(Item.OperationData.EllipseData.ToDefAll(Char, Space + 2, SerilizationMode.MultiLine));
		arrayList.AddRange(Item.OperationData.FreeDrawData.ToDefAll(Char, Space + 2, SerilizationMode.MultiLine));
		arrayList.AddRange(Item.OperationData.HoleData.ToDefAll(Char, Space + 2, SerilizationMode.MultiLine));
		arrayList.AddRange(Item.OperationData.NotchData.ToDefAll(Char, Space + 2, SerilizationMode.MultiLine));
		arrayList.AddRange(Item.OperationData.RectangleRoundData.ToDefAll(Char, Space + 2, SerilizationMode.MultiLine));
		arrayList.AddRange(Item.OperationData.SlotData.ToDefAll(Char, Space + 2, SerilizationMode.MultiLine));
		arrayList.AddRange(Item.OperationData.TextData.ToDefAll(Char, Space + 2, SerilizationMode.MultiLine));
		arrayList.AddRange(Item.OperationData.CutData.ToDefAll(Char, Space + 2, SerilizationMode.MultiLine));
		arrayList.Add(new string(' ', Space + 2) + "<ClampersOperations>");
		for (int i = 0; i <= Item.ClampersOperations.Count - 1; i++)
		{
			arrayList.AddRange(Item.ClampersOperations[i].ToDefAll(Char, Space + 6, SerilizationMode.MultiLine));
		}
		arrayList.Add(new string(' ', Space + 2) + "</ClampersOperations>");
		arrayList.Add(new string(' ', Space + 2) + "<DepthSelectedValues>");
		for (int j = 0; j <= Item.OperationData.DepthSelectedValues.Count - 1; j++)
		{
			arrayList.AddRange(Item.OperationData.DepthSelectedValues[j].ToDefAll(Char, Space + 6, SerilizationMode.MultiLine));
		}
		arrayList.Add(new string(' ', Space + 2) + "</DepthSelectedValues>");
		arrayList.Add(new string(' ', Space + 2) + "<DepthValues>");
		for (int k = 0; k <= Item.OperationData.DepthValues.Count - 1; k++)
		{
			arrayList.AddRange(Item.OperationData.DepthValues[k].ToDefAll(Char, Space + 6, SerilizationMode.MultiLine));
		}
		arrayList.Add(new string(' ', Space + 2) + "</DepthValues>");
		arrayList.Add(new string(' ', Space + 2) + "<OperationsDrawPoints>");
		for (int l = 0; l <= Item.Entities.Count - 1; l++)
		{
			arrayList.Add(new string(' ', Space + 4) + "<PointVertices>");
			arrayList.Add(new string(' ', Space + 4) + "</PointVertices>");
		}
		arrayList.Add(new string(' ', Space + 2) + "</OperationsDrawPoints>");
		return arrayList;
	}

	public static void Decode(ArrayList AL, ref ProfileOperation OP)
	{
		OP = new ProfileOperation();
		if (AL.Count > 0)
		{
			string text = AL[0].ToString();
			if (text.IndexOf("ProfileOperationCircle") >= 0)
			{
				OP = new ProfileOperationCircle();
				buSerilization.Decode(AL, "", SerilizationMode.MultiLine, OP);
			}
			if (text.IndexOf("ProfileOperationRectangle") >= 0)
			{
				OP = new ProfileOperationRectangle();
				buSerilization.Decode(AL, "", SerilizationMode.MultiLine, OP);
			}
			if (text.IndexOf("ProfileOperationBarrel") >= 0)
			{
				OP = new ProfileOperationBarrel();
				buSerilization.Decode(AL, "", SerilizationMode.MultiLine, OP);
			}
			if (text.IndexOf("ProfileOperationEllipse") >= 0)
			{
				OP = new ProfileOperationEllipse();
				buSerilization.Decode(AL, "", SerilizationMode.MultiLine, OP);
			}
			if (text.IndexOf("ProfileOperationSlot") >= 0)
			{
				OP = new ProfileOperationSlot();
				buSerilization.Decode(AL, "", SerilizationMode.MultiLine, OP);
			}
			if (text.IndexOf("ProfileOperationCut") >= 0)
			{
				OP = new ProfileOperationCut();
				buSerilization.Decode(AL, "", SerilizationMode.MultiLine, OP);
			}
			if (text.IndexOf("ProfileOperationFreeDraw") >= 0)
			{
				OP = new ProfileOperationFreeDraw();
				buSerilization.Decode(AL, "", SerilizationMode.MultiLine, OP);
			}
			if (text.IndexOf("ProfileOperationHole") >= 0)
			{
				OP = new ProfileOperationHole();
				buSerilization.Decode(AL, "", SerilizationMode.MultiLine, OP);
			}
			if (text.IndexOf("ProfileOperationNotch") >= 0)
			{
				OP = new ProfileOperationNotch();
				buSerilization.Decode(AL, "", SerilizationMode.MultiLine, OP);
			}
			if (text.IndexOf("ProfileOperationRoundRectangle") >= 0)
			{
				OP = new ProfileOperationRoundRectangle();
				buSerilization.Decode(AL, "", SerilizationMode.MultiLine, OP);
			}
			if (text.IndexOf("ProfileOperationText") >= 0)
			{
				OP = new ProfileOperationText();
				buSerilization.Decode(AL, "", SerilizationMode.MultiLine, OP);
			}
			if (text.IndexOf("ProfileOperationMoveClamper") >= 0)
			{
				OP = new ProfileOperationMoveClamper();
				buSerilization.Decode(AL, "", SerilizationMode.MultiLine, OP);
			}
			buSerilization.Decode(AL, "", SerilizationMode.MultiLine, OP.OperationData);
			List<string> CalcList = new List<string>();
			buStatics.ListToSpecificList("<ProfileOperationDataCircle>", "</ProfileOperationDataCircle>", AddStartEndKey: true, AL, ref CalcList);
			buSerilization.Decode(CalcList, "", SerilizationMode.MultiLine, OP.OperationData.CircleData);
			CalcList = new List<string>();
			buStatics.ListToSpecificList("<ProfileOperationDataRectangle>", "</ProfileOperationDataRectangle>", AddStartEndKey: true, AL, ref CalcList);
			buSerilization.Decode(CalcList, "", SerilizationMode.MultiLine, OP.OperationData.RectangleData);
			CalcList = new List<string>();
			buStatics.ListToSpecificList("<ProfileOperationDataBarel>", "</ProfileOperationDataBarel>", AddStartEndKey: true, AL, ref CalcList);
			buSerilization.Decode(CalcList, "", SerilizationMode.MultiLine, OP.OperationData.BarelData);
			CalcList = new List<string>();
			buStatics.ListToSpecificList("<ProfileOperationDataEllipse>", "</ProfileOperationDataEllipse>", AddStartEndKey: true, AL, ref CalcList);
			buSerilization.Decode(CalcList, "", SerilizationMode.MultiLine, OP.OperationData.EllipseData);
			CalcList = new List<string>();
			buStatics.ListToSpecificList("<ProfileOperationDataFreeDraw>", "</ProfileOperationDataFreeDraw>", AddStartEndKey: true, AL, ref CalcList);
			buSerilization.Decode(CalcList, "", SerilizationMode.MultiLine, OP.OperationData.FreeDrawData);
			CalcList = new List<string>();
			buStatics.ListToSpecificList("<ProfileOperationDataHole>", "</ProfileOperationDataHole>", AddStartEndKey: true, AL, ref CalcList);
			buSerilization.Decode(CalcList, "", SerilizationMode.MultiLine, OP.OperationData.HoleData);
			CalcList = new List<string>();
			buStatics.ListToSpecificList("<ProfileOperationDataNotch>", "</ProfileOperationDataNotch>", AddStartEndKey: true, AL, ref CalcList);
			buSerilization.Decode(CalcList, "", SerilizationMode.MultiLine, OP.OperationData.NotchData);
			CalcList = new List<string>();
			buStatics.ListToSpecificList("<ProfileOperationDataRectangleRound>", "</ProfileOperationDataRectangleRound>", AddStartEndKey: true, AL, ref CalcList);
			buSerilization.Decode(CalcList, "", SerilizationMode.MultiLine, OP.OperationData.RectangleRoundData);
			CalcList = new List<string>();
			buStatics.ListToSpecificList("<ProfileOperationDataSlot>", "</ProfileOperationDataSlot>", AddStartEndKey: true, AL, ref CalcList);
			buSerilization.Decode(CalcList, "", SerilizationMode.MultiLine, OP.OperationData.SlotData);
			CalcList = new List<string>();
			buStatics.ListToSpecificList("<ProfileOperationDataCut>", "</ProfileOperationDataCut>", AddStartEndKey: true, AL, ref CalcList);
			buSerilization.Decode(CalcList, "", SerilizationMode.MultiLine, OP.OperationData.CutData);
			CalcList = new List<string>();
			buStatics.ListToSpecificList("<ProfileOperationDataText>", "</ProfileOperationDataText>", AddStartEndKey: true, AL, ref CalcList);
			buSerilization.Decode(CalcList, "", SerilizationMode.MultiLine, OP.OperationData.TextData);
			CalcList = new List<string>();
			List<List<string>> CalcList2 = new List<List<string>>();
			buStatics.ListToSpecificList("<DepthSelectedValues>", "</DepthSelectedValues>", AddStartEndKey: true, AL, ref CalcList);
			buStatics.ListToSpecificList("<DepthHeight>", "</DepthHeight>", AddStartEndKey: true, CalcList, ref CalcList2);
			for (int i = 0; i <= CalcList2.Count - 1; i++)
			{
				DepthPosition depthPosition = new DepthPosition();
				buSerilization.Decode(CalcList2[i], "", SerilizationMode.MultiLine, depthPosition);
				OP.OperationData.DepthSelectedValues.Add(depthPosition);
			}
			CalcList = new List<string>();
			CalcList2 = new List<List<string>>();
			buStatics.ListToSpecificList("<DepthValues>", "</DepthValues>", AddStartEndKey: true, AL, ref CalcList);
			buStatics.ListToSpecificList("<DepthHeight>", "</DepthHeight>", AddStartEndKey: true, CalcList, ref CalcList2);
			for (int j = 0; j <= CalcList2.Count - 1; j++)
			{
				DepthPosition depthPosition2 = new DepthPosition();
				buSerilization.Decode(CalcList2[j], "", SerilizationMode.MultiLine, depthPosition2);
				OP.OperationData.DepthValues.Add(depthPosition2);
			}
			CalcList = new List<string>();
			CalcList2 = new List<List<string>>();
			buStatics.ListToSpecificList("<ClampersOperations>", "</ClampersOperations>", AddStartEndKey: true, AL, ref CalcList);
			buStatics.ListToSpecificList("<ProfileClamper>", "</ProfileClamper>", AddStartEndKey: true, CalcList, ref CalcList2);
			for (int k = 0; k <= CalcList2.Count - 1; k++)
			{
				ProfileClamper profileClamper = new ProfileClamper();
				buSerilization.Decode(CalcList2[k], "", SerilizationMode.MultiLine, profileClamper);
				OP.ClampersOperations.Add(profileClamper);
			}
		}
	}

	public override string ToString()
	{
		if (GetType() == typeof(ProfileOperationCircle))
		{
			return Name + " - " + strCircle + " D: " + ((ProfileOperationCircle)this).Diameter.ToString("f3");
		}
		if (GetType() == typeof(ProfileOperationRectangle))
		{
			return Name + " - " + strRectangle + " W: " + ((ProfileOperationRectangle)this).Width.ToString("f3") + " - H: " + ((ProfileOperationRectangle)this).Height.ToString("f3");
		}
		if (GetType() == typeof(ProfileOperationRoundRectangle))
		{
			return Name + " - " + strRoundRect + " W: " + ((ProfileOperationRoundRectangle)this).Width.ToString("f3") + " - H: " + ((ProfileOperationRoundRectangle)this).Height.ToString("f3") + " - R: " + ((ProfileOperationRoundRectangle)this).Radius.ToString("f3");
		}
		if (GetType() == typeof(ProfileOperationSlot))
		{
			return Name + " - " + strSlot + "W: " + ((ProfileOperationSlot)this).Width.ToString("f3") + " - D: " + ((ProfileOperationSlot)this).Diameter.ToString("f3");
		}
		if (GetType() == typeof(ProfileOperationBarrel))
		{
			return Name + " - W: " + ((ProfileOperationBarrel)this).Width.ToString("f3") + " - D: " + ((ProfileOperationBarrel)this).Diameter.ToString("f3");
		}
		if (GetType() == typeof(ProfileOperationEllipse))
		{
			return Name + " - " + strEllipse + "W: " + ((ProfileOperationEllipse)this).Width.ToString("f3") + " - H: " + ((ProfileOperationEllipse)this).Height.ToString("f3");
		}
		if (GetType() == typeof(ProfileOperationHole))
		{
			return Name + " - " + strHole + "D: " + ((ProfileOperationHole)this).Diameter.ToString("f3");
		}
		if (GetType() == typeof(ProfileOperationNotch))
		{
			return Name + " - " + strNotch + "W: " + ((ProfileOperationNotch)this).Width.ToString("f3") + " - H: " + ((ProfileOperationNotch)this).Height.ToString("f3");
		}
		if (GetType() == typeof(ProfileOperationFreeDraw))
		{
			return Name + " -" + strFreeDraw + " W: " + ((ProfileOperationFreeDraw)this).DrawPoints.Count.ToString("f3") + " - H: " + ((ProfileOperationFreeDraw)this).Height.ToString("f3");
		}
		if (GetType() == typeof(ProfileOperationText))
		{
			return Name + " - " + strText + "T: " + ((ProfileOperationText)this).Text.ToString() + " - H: " + ((ProfileOperationText)this).Height.ToString("f3");
		}
		return Name;
	}
}
