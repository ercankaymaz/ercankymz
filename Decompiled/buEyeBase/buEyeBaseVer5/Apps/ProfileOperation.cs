using System;
using System.Collections;
using System.Collections.Generic;
using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class ProfileOperation : buSerilization5
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

	public bool Selected = false;

	public bool XRefFromEnd = false;

	public bool Locked = false;

	public bool CamAssinged = false;

	public int Priority = 0;

	public actionTypeBU Action = actionTypeBU.None;

	public LeftRightType ParentXReferance = LeftRightType.Left;

	public ProfileOperationData OperationData = new ProfileOperationData();

	public ProfileOperationCamData CamOPData = new ProfileOperationCamData();

	public List<camTp> CamCalculation = new List<camTp>();

	public Vector3D CamInsideVector = new Vector3D();

	public Vector3D CamOutsideVector = new Vector3D();

	public ToolBase5 Tool = new ToolBase5();

	public ToolBase5 ToolNotch = new ToolBase5();

	public ToolBase5 ToolAux = null;

	public Point3D MinPoint = new Point3D();

	public Point3D MaxPoint = new Point3D();

	public Point3D GeoSize = new Point3D();

	public List<ProfileClamper> Clampers = new List<ProfileClamper>();

	public List<buEntity> EntityMultiCam = null;

	public List<buEntity> EntityMultiCamAux = null;

	public List<buEntity> EntityMultiContour = null;

	public List<Entity> EntityMultiSolidDepth = null;

	public List<buEntity> EntityMultiXYPlane = null;

	public List<DimensionGroup> EntityDimension = null;

	public List<string> warningList = new List<string>();

	public List<string> errorList = new List<string>();

	public List<string> infoList = new List<string>();

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
		if (RefOperation.Count > 0)
		{
			for (int i = 0; i <= RefOperation.Count - 1; i++)
			{
				ProfileOperation CopiedOperation2 = new ProfileOperation();
				Copy(RefOperation[i], ref CopiedOperation2);
				CopiedOperation.Add(CopiedOperation2);
			}
		}
	}

	public static void Copy(ProfileOperation RefOperation, ref ProfileOperation CopiedOperation)
	{
		if ((RefOperation.GetType() == typeof(ProfileOperationCircle)) | (RefOperation.Action == actionTypeBU.profileCircle))
		{
			CopiedOperation = new ProfileOperationCircle((ProfileOperationCircle)RefOperation);
		}
		if ((RefOperation.GetType() == typeof(ProfileOperationRectangle)) | (RefOperation.Action == actionTypeBU.profileRectangle))
		{
			CopiedOperation = new ProfileOperationRectangle((ProfileOperationRectangle)RefOperation);
		}
		if ((RefOperation.GetType() == typeof(ProfileOperationRoundRectangle)) | (RefOperation.Action == actionTypeBU.profileRoundRectangle))
		{
			CopiedOperation = new ProfileOperationRoundRectangle((ProfileOperationRoundRectangle)RefOperation);
		}
		if ((RefOperation.GetType() == typeof(ProfileOperationBarrel)) | (RefOperation.Action == actionTypeBU.profileBarrel))
		{
			CopiedOperation = new ProfileOperationBarrel((ProfileOperationBarrel)RefOperation);
		}
		if ((RefOperation.GetType() == typeof(ProfileOperationEllipse)) | (RefOperation.Action == actionTypeBU.profileEllipse))
		{
			CopiedOperation = new ProfileOperationEllipse((ProfileOperationEllipse)RefOperation);
		}
		if ((RefOperation.GetType() == typeof(ProfileOperationFreeDraw)) | (RefOperation.Action == actionTypeBU.profileFreeDraw))
		{
			CopiedOperation = new ProfileOperationFreeDraw((ProfileOperationFreeDraw)RefOperation);
		}
		if ((RefOperation.GetType() == typeof(ProfileOperationText)) | (RefOperation.Action == actionTypeBU.profileText))
		{
			CopiedOperation = new ProfileOperationText((ProfileOperationText)RefOperation);
		}
		if ((RefOperation.GetType() == typeof(ProfileOperationText)) | (RefOperation.Action == actionTypeBU.profileWireText))
		{
			CopiedOperation = new ProfileOperationText((ProfileOperationText)RefOperation);
		}
		if ((RefOperation.GetType() == typeof(ProfileOperationHole)) | (RefOperation.Action == actionTypeBU.profileHole))
		{
			CopiedOperation = new ProfileOperationHole((ProfileOperationHole)RefOperation);
		}
		if ((RefOperation.GetType() == typeof(ProfileOperationSlot)) | (RefOperation.Action == actionTypeBU.profileSlot))
		{
			CopiedOperation = new ProfileOperationSlot((ProfileOperationSlot)RefOperation);
		}
		if ((RefOperation.GetType() == typeof(ProfileOperationCut)) | (RefOperation.Action == actionTypeBU.profileCut))
		{
			CopiedOperation = new ProfileOperationCut((ProfileOperationCut)RefOperation);
		}
		if ((RefOperation.GetType() == typeof(ProfileOperationNotch)) | (RefOperation.Action == actionTypeBU.profileNotch))
		{
			CopiedOperation = new ProfileOperationNotch((ProfileOperationNotch)RefOperation);
		}
		if ((RefOperation.GetType() == typeof(ProfileOperationPolygon)) | (RefOperation.Action == actionTypeBU.profilePolygon))
		{
			CopiedOperation = new ProfileOperationPolygon((ProfileOperationPolygon)RefOperation);
		}
		CopiedOperation.CamOPData = new ProfileOperationCamData(RefOperation.CamOPData);
		CopiedOperation.Clampers.Clear();
		CopiedOperation.Clampers = new List<ProfileClamper>();
		for (int i = 0; i <= RefOperation.Clampers.Count - 1; i++)
		{
			ProfileClamper item = new ProfileClamper(RefOperation.Clampers[i]);
			CopiedOperation.Clampers.Add(item);
		}
		if (RefOperation.EntityDimension != null)
		{
			CopiedOperation.EntityDimension = new List<DimensionGroup>();
			for (int j = 0; j <= RefOperation.EntityDimension.Count - 1; j++)
			{
				CopiedOperation.EntityDimension.Add(new DimensionGroup(RefOperation.EntityDimension[j]));
			}
		}
		if (RefOperation.EntityMultiContour != null)
		{
			CopiedOperation.EntityMultiContour = buEntity.Copy(RefOperation.EntityMultiContour);
		}
		if (RefOperation.EntityMultiCam != null)
		{
			CopiedOperation.EntityMultiCam = buEntity.Copy(RefOperation.EntityMultiCam);
		}
		if (RefOperation.EntityMultiCamAux != null)
		{
			CopiedOperation.EntityMultiCamAux = buEntity.Copy(RefOperation.EntityMultiCamAux);
		}
		if (RefOperation.EntityMultiSolidDepth != null)
		{
			CopiedOperation.EntityMultiSolidDepth = buVector5.CopyEntities(RefOperation.EntityMultiSolidDepth);
		}
		if (RefOperation.EntityMultiXYPlane != null)
		{
			CopiedOperation.EntityMultiXYPlane = buEntity.Copy(RefOperation.EntityMultiXYPlane);
		}
		if (CopiedOperation.CamCalculation != null)
		{
			if (RefOperation.CamCalculation.Count != CopiedOperation.CamCalculation.Count)
			{
				camTp.CopyCam(RefOperation.CamCalculation, ref CopiedOperation.CamCalculation);
			}
		}
		else
		{
			CopiedOperation.CamCalculation = new List<camTp>();
			camTp.CopyCam(RefOperation.CamCalculation, ref CopiedOperation.CamCalculation);
		}
		if (RefOperation.ToolAux != null)
		{
			CopiedOperation.ToolAux = new ToolBase5(RefOperation.ToolAux);
		}
		CopiedOperation.ToolNotch = new ToolBase5(RefOperation.ToolNotch);
		CopiedOperation.MinPoint = new Point3D(RefOperation.MinPoint.X, RefOperation.MinPoint.Y, RefOperation.MinPoint.Z);
		CopiedOperation.MaxPoint = new Point3D(RefOperation.MaxPoint.X, RefOperation.MaxPoint.Y, RefOperation.MaxPoint.Z);
		CopiedOperation.GeoSize = new Point3D(RefOperation.GeoSize.X, RefOperation.GeoSize.Y, RefOperation.GeoSize.Z);
		CopiedOperation.CamInsideVector = new Vector3D(RefOperation.CamInsideVector.X, RefOperation.CamInsideVector.Y, RefOperation.CamInsideVector.Z);
		CopiedOperation.CamOutsideVector = new Vector3D(RefOperation.CamOutsideVector.X, RefOperation.CamOutsideVector.Y, RefOperation.CamOutsideVector.Z);
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
		new string(' ', Space);
		ArrayList arrayList = new ArrayList();
		arrayList.Add(buString5.SpaceChar(Space) + Item.OperationData.OperationType);
		arrayList.AddRange(ToDefPars(Item, Space));
		arrayList.AddRange(ProfileOperationData.ToDefPars(Item.OperationData, Space));
		arrayList.AddRange(ProfileOperationCamData.ToDefPars(Item.CamOPData, Space));
		if (Item.OperationData.OperationType == ProfileOperationTypes.Circle)
		{
			arrayList.AddRange(ProfileOperationDataCircle.ToDefPars(Item.OperationData.CircleData, Space));
		}
		if (Item.OperationData.OperationType == ProfileOperationTypes.Rectangle)
		{
			arrayList.AddRange(ProfileOperationDataRectangle.ToDefPars(Item.OperationData.RectangleData, Space));
		}
		if (Item.OperationData.OperationType == ProfileOperationTypes.RoundRectangle)
		{
			arrayList.AddRange(ProfileOperationDataRectangleRound.ToDefPars(Item.OperationData.RectangleRoundData, Space));
		}
		if (Item.OperationData.OperationType == ProfileOperationTypes.Ellipse)
		{
			arrayList.AddRange(ProfileOperationDataEllipse.ToDefPars(Item.OperationData.EllipseData, Space));
		}
		if (Item.OperationData.OperationType == ProfileOperationTypes.Slot)
		{
			arrayList.AddRange(ProfileOperationDataSlot.ToDefPars(Item.OperationData.SlotData, Space));
		}
		if (Item.OperationData.OperationType == ProfileOperationTypes.Barrel)
		{
			arrayList.AddRange(ProfileOperationDataBarel.ToDefPars(Item.OperationData.BarelData, Space));
		}
		if (Item.OperationData.OperationType == ProfileOperationTypes.Polygon)
		{
			arrayList.AddRange(ProfileOperationDataPolygon.ToDefPars(Item.OperationData.PolygonData, Space));
		}
		if (Item.OperationData.OperationType == ProfileOperationTypes.Hole)
		{
			arrayList.AddRange(ProfileOperationDataHole.ToDefPars(Item.OperationData.HoleData, Space));
		}
		if (Item.OperationData.OperationType == ProfileOperationTypes.FreeDraw)
		{
			arrayList.AddRange(ProfileOperationDataFreeDraw.ToDefPars(Item.OperationData.FreeDrawData, Space));
		}
		if (Item.OperationData.OperationType == ProfileOperationTypes.Text)
		{
			arrayList.AddRange(ProfileOperationDataText.ToDefPars(Item.OperationData.TextData, Space));
		}
		if (Item.OperationData.OperationType == ProfileOperationTypes.WireText)
		{
			arrayList.AddRange(ProfileOperationDataText.ToDefPars(Item.OperationData.TextData, Space));
		}
		if (Item.OperationData.OperationType == ProfileOperationTypes.Cut)
		{
			arrayList.AddRange(ProfileOperationDataCut.ToDefPars(Item.OperationData.CutData, Space));
		}
		if (Item.OperationData.OperationType == ProfileOperationTypes.Notch)
		{
			arrayList.AddRange(ProfileOperationDataNotch.ToDefPars(Item.OperationData.NotchData, Space));
		}
		if (Item.OperationData.OperationType == ProfileOperationTypes.Polygon)
		{
			arrayList.AddRange(ProfileOperationDataPolygon.ToDefPars(Item.OperationData.PolygonData, Space));
		}
		arrayList.Add(buString5.SpaceChar(Space) + "<Clampers>");
		for (int i = 0; i <= Item.Clampers.Count - 1; i++)
		{
			arrayList.AddRange(Item.Clampers[i].ToDefAll(Char, Space + 2, SerilizationMode5.MultiLine));
		}
		arrayList.Add(buString5.SpaceChar(Space) + "</Clampers>");
		arrayList.Add(buString5.SpaceChar(Space) + "<DepthValues>");
		for (int j = 0; j <= Item.OperationData.DepthValues.Count - 1; j++)
		{
			arrayList.AddRange(Item.OperationData.DepthValues[j].ToDefAll(Char, Space + 2, SerilizationMode5.MultiLine));
		}
		arrayList.Add(buString5.SpaceChar(Space) + "</DepthValues>");
		return arrayList;
	}

	public static ArrayList ToDefPars(ProfileOperation P, int Space)
	{
		ArrayList arrayList = new ArrayList();
		arrayList.Add(buString5.SpaceChar(Space) + "<ProfileOperationPars>");
		arrayList.Add(buString5.SpaceChar(Space + 2) + ToDefPars(P));
		arrayList.Add(buString5.SpaceChar(Space) + "</ProfileOperationPars>");
		return arrayList;
	}

	public static string ToDefPars(ProfileOperation P)
	{
		return buSerilization5.ClassToString(P);
	}

	public static void Decode(List<string> Lines, ref ProfileOperation OP)
	{
		if (Lines.Count <= 0)
		{
			return;
		}
		if (Lines[0].Trim().ToLower() == "rectangle")
		{
			OP = new ProfileOperationRectangle();
		}
		if (Lines[0].Trim().ToLower() == "circle")
		{
			OP = new ProfileOperationCircle();
		}
		if (Lines[0].Trim().ToLower() == "roundrectangle")
		{
			OP = new ProfileOperationRoundRectangle();
		}
		if (Lines[0].Trim().ToLower() == "barrel")
		{
			OP = new ProfileOperationBarrel();
		}
		if (Lines[0].Trim().ToLower() == "ellipse")
		{
			OP = new ProfileOperationEllipse();
		}
		if (Lines[0].Trim().ToLower() == "hole")
		{
			OP = new ProfileOperationHole();
		}
		if (Lines[0].Trim().ToLower() == "notch")
		{
			OP = new ProfileOperationNotch();
		}
		if (Lines[0].Trim().ToLower() == "freedraw")
		{
			OP = new ProfileOperationFreeDraw();
		}
		if (Lines[0].Trim().ToLower() == "text")
		{
			OP = new ProfileOperationText();
		}
		if (Lines[0].Trim().ToLower() == "wiretext")
		{
			OP = new ProfileOperationText();
		}
		if (Lines[0].Trim().ToLower() == "slot")
		{
			OP = new ProfileOperationSlot();
		}
		if (Lines[0].Trim().ToLower() == "cut")
		{
			OP = new ProfileOperationCut();
		}
		if (Lines[0].Trim().ToLower() == "polygon")
		{
			OP = new ProfileOperationPolygon();
		}
		if (OP == null)
		{
			return;
		}
		List<string> CalcList = new List<string>();
		buStatics.ListToSpecificList("<ProfileOperationPars>", "</ProfileOperationPars>", AddStartEndKey: false, Lines, ref CalcList);
		if (CalcList.Count > 0)
		{
			object ObjPar = OP;
			buSerilization5.StringToClass(ref ObjPar, CalcList[0]);
		}
		CalcList = new List<string>();
		buStatics.ListToSpecificList("<ProfileOperationDataPars>", "</ProfileOperationDataPars>", AddStartEndKey: false, Lines, ref CalcList);
		if (CalcList.Count > 0)
		{
			object ObjPar2 = OP.OperationData;
			buSerilization5.StringToClass(ref ObjPar2, CalcList[0]);
		}
		CalcList = new List<string>();
		buStatics.ListToSpecificList("<ProfileOperationCamDataPars>", "</ProfileOperationCamDataPars>", AddStartEndKey: false, Lines, ref CalcList);
		if (CalcList.Count > 0)
		{
			object ObjPar3 = OP.CamOPData;
			buSerilization5.StringToClass(ref ObjPar3, CalcList[0]);
		}
		CalcList = new List<string>();
		if (OP.OperationData.OperationType == ProfileOperationTypes.Rectangle)
		{
			buStatics.ListToSpecificList("<ProfileOperationDataRectanglePars>", "</ProfileOperationDataRectanglePars>", AddStartEndKey: false, Lines, ref CalcList);
			if (CalcList.Count > 0)
			{
				object ObjPar4 = OP.OperationData.RectangleData;
				buSerilization5.StringToClass(ref ObjPar4, CalcList[0]);
			}
		}
		if (OP.OperationData.OperationType == ProfileOperationTypes.Circle)
		{
			buStatics.ListToSpecificList("<ProfileOperationDataCirclePars>", "</ProfileOperationDataCirclePars>", AddStartEndKey: false, Lines, ref CalcList);
			if (CalcList.Count > 0)
			{
				object ObjPar5 = OP.OperationData.CircleData;
				buSerilization5.StringToClass(ref ObjPar5, CalcList[0]);
			}
		}
		if (OP.OperationData.OperationType == ProfileOperationTypes.RoundRectangle)
		{
			buStatics.ListToSpecificList("<ProfileOperationDataRoundRectanglePars>", "</ProfileOperationDataRoundRectanglePars>", AddStartEndKey: false, Lines, ref CalcList);
			if (CalcList.Count > 0)
			{
				object ObjPar6 = OP.OperationData.RectangleRoundData;
				buSerilization5.StringToClass(ref ObjPar6, CalcList[0]);
			}
		}
		if (OP.OperationData.OperationType == ProfileOperationTypes.Barrel)
		{
			buStatics.ListToSpecificList("<ProfileOperationDataBarelPars>", "</ProfileOperationDataBarelPars>", AddStartEndKey: false, Lines, ref CalcList);
			if (CalcList.Count > 0)
			{
				object ObjPar7 = OP.OperationData.BarelData;
				buSerilization5.StringToClass(ref ObjPar7, CalcList[0]);
			}
		}
		if (OP.OperationData.OperationType == ProfileOperationTypes.Ellipse)
		{
			buStatics.ListToSpecificList("<ProfileOperationDataEllipsePars>", "</ProfileOperationDataEllipsePars>", AddStartEndKey: false, Lines, ref CalcList);
			if (CalcList.Count > 0)
			{
				object ObjPar8 = OP.OperationData.EllipseData;
				buSerilization5.StringToClass(ref ObjPar8, CalcList[0]);
			}
		}
		if (OP.OperationData.OperationType == ProfileOperationTypes.Hole)
		{
			buStatics.ListToSpecificList("<ProfileOperationDataHolePars>", "</ProfileOperationDataHolePars>", AddStartEndKey: false, Lines, ref CalcList);
			if (CalcList.Count > 0)
			{
				object ObjPar9 = OP.OperationData.HoleData;
				buSerilization5.StringToClass(ref ObjPar9, CalcList[0]);
			}
		}
		if (OP.OperationData.OperationType == ProfileOperationTypes.Slot)
		{
			buStatics.ListToSpecificList("<ProfileOperationDataSlotPars>", "</ProfileOperationDataSlotPars>", AddStartEndKey: false, Lines, ref CalcList);
			if (CalcList.Count > 0)
			{
				object ObjPar10 = OP.OperationData.SlotData;
				buSerilization5.StringToClass(ref ObjPar10, CalcList[0]);
			}
		}
		if (OP.OperationData.OperationType == ProfileOperationTypes.Cut)
		{
			buStatics.ListToSpecificList("<ProfileOperationDataCutPars>", "</ProfileOperationDataCutPars>", AddStartEndKey: false, Lines, ref CalcList);
			if (CalcList.Count > 0)
			{
				object ObjPar11 = OP.OperationData.CutData;
				buSerilization5.StringToClass(ref ObjPar11, CalcList[0]);
			}
		}
		if (OP.OperationData.OperationType == ProfileOperationTypes.FreeDraw)
		{
			buStatics.ListToSpecificList("<ProfileOperationDataFreeDrawPars>", "</ProfileOperationDataFreeDrawPars>", AddStartEndKey: false, Lines, ref CalcList);
			if (CalcList.Count > 0)
			{
				object ObjPar12 = OP.OperationData.FreeDrawData;
				buSerilization5.StringToClass(ref ObjPar12, CalcList[0]);
			}
		}
		if (OP.OperationData.OperationType == ProfileOperationTypes.Text)
		{
			buStatics.ListToSpecificList("<ProfileOperationDataTextPars>", "</ProfileOperationDataTextPars>", AddStartEndKey: false, Lines, ref CalcList);
			if (CalcList.Count > 0)
			{
				object ObjPar13 = OP.OperationData.TextData;
				buSerilization5.StringToClass(ref ObjPar13, CalcList[0]);
			}
		}
		if (OP.OperationData.OperationType == ProfileOperationTypes.WireText)
		{
			buStatics.ListToSpecificList("<ProfileOperationDataTextPars>", "</ProfileOperationDataTextPars>", AddStartEndKey: false, Lines, ref CalcList);
			if (CalcList.Count > 0)
			{
				object ObjPar14 = OP.OperationData.TextData;
				buSerilization5.StringToClass(ref ObjPar14, CalcList[0]);
			}
		}
		if (OP.OperationData.OperationType == ProfileOperationTypes.Notch)
		{
			buStatics.ListToSpecificList("<ProfileOperationDataNotchPars>", "</ProfileOperationDataNotchPars>", AddStartEndKey: false, Lines, ref CalcList);
			if (CalcList.Count > 0)
			{
				object ObjPar15 = OP.OperationData.NotchData;
				buSerilization5.StringToClass(ref ObjPar15, CalcList[0]);
			}
		}
		if (OP.OperationData.OperationType == ProfileOperationTypes.Polygon)
		{
			buStatics.ListToSpecificList("<ProfileOperationDataPolygonPars>", "</ProfileOperationDataPolygonPars>", AddStartEndKey: false, Lines, ref CalcList);
			if (CalcList.Count > 0)
			{
				object ObjPar16 = OP.OperationData.PolygonData;
				buSerilization5.StringToClass(ref ObjPar16, CalcList[0]);
			}
		}
		List<List<string>> CalcList2 = new List<List<string>>();
		buStatics.ListToSpecificList("<DepthPositions>", "</DepthPositions>", AddStartEndKey: true, Lines, ref CalcList2);
		for (int i = 0; i <= CalcList2.Count - 1; i++)
		{
			DepthPositions depthPositions = new DepthPositions();
			buSerilization5.Decode(CalcList2[i], "", SerilizationMode5.MultiLine, depthPositions);
			OP.OperationData.DepthValues.Add(depthPositions);
		}
	}

	public override string ToString()
	{
		string text = " " + OperationData.selectedPlaneName.ToString() + " - P( " + OperationData.Position.X.ToString("f2") + " , ";
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
		text = text + " - T" + Tool.Data.No + " Dia: " + Tool.Geometry.Diameter;
		if (!(GetType() == typeof(ProfileOperationCircle)))
		{
			if (!(GetType() == typeof(ProfileOperationRectangle)))
			{
				if (!(GetType() == typeof(ProfileOperationRoundRectangle)))
				{
					if (!(GetType() == typeof(ProfileOperationSlot)))
					{
						if (!(GetType() == typeof(ProfileOperationBarrel)))
						{
							if (!(GetType() == typeof(ProfileOperationEllipse)))
							{
								if (!(GetType() == typeof(ProfileOperationHole)))
								{
									if (!(GetType() == typeof(ProfileOperationNotch)))
									{
										if (!(GetType() == typeof(ProfileOperationFreeDraw)))
										{
											if (!(GetType() == typeof(ProfileOperationText)))
											{
												if (!(GetType() == typeof(ProfileOperationPolygon)))
												{
													if (!(GetType() == typeof(ProfileOperationCut)))
													{
														return Name;
													}
													return Name + " - " + ProfileTempVars.strCut + "W: " + ((ProfileOperationCut)this).OperationData.CutData.CutWidth + " - H: " + ((ProfileOperationCut)this).OperationData.CutData.CutHeigth.ToString("f3") + text;
												}
												return Name + " - " + ProfileTempVars.strPoylgon + "Side: " + ((ProfileOperationPolygon)this).OperationData.PolygonData.PolygonSide + " - Dia: " + ((ProfileOperationPolygon)this).OperationData.PolygonData.PolygonDiameter.ToString("f3") + text;
											}
											return Name + " - " + ProfileTempVars.strText + "T: " + ((ProfileOperationText)this).Text.ToString() + " - H: " + ((ProfileOperationText)this).OperationData.TextData.TextHeight.ToString("f3") + text;
										}
										return Name + ProfileTempVars.strFreeDraw + text;
									}
									text = " - TNotch" + Tool.Data.No + " Dia: " + Tool.Geometry.Diameter;
									return Name + " - " + ProfileTempVars.strNotch + ((ProfileOperationNotch)this).OperationData.NotchData.NotchWidth.ToString("f3") + " - H: " + ((ProfileOperationNotch)this).OperationData.NotchData.NotchHeight.ToString("f3") + text;
								}
								string text2 = "";
								if (((ProfileOperationHole)this).Tapping)
								{
									text2 = "Tapping";
								}
								return Name + " - " + ProfileTempVars.strHole + "D: " + ((ProfileOperationHole)this).OperationData.HoleData.HoleDiameter.ToString("f3") + text + " " + text2;
							}
							return Name + " - " + ProfileTempVars.strEllipse + "W: " + ((ProfileOperationEllipse)this).OperationData.EllipseData.EllipseWidth.ToString("f3") + " - H: " + ((ProfileOperationEllipse)this).OperationData.EllipseData.EllipseHeight.ToString("f3") + text;
						}
						return Name + " - W: " + ((ProfileOperationBarrel)this).OperationData.BarelData.BarrelWidth.ToString("f3") + " - D: " + ((ProfileOperationBarrel)this).OperationData.BarelData.BarrelDiameter.ToString("f3") + text;
					}
					return Name + " - " + ProfileTempVars.strSlot + "W: " + ((ProfileOperationSlot)this).OperationData.SlotData.SlotWidth.ToString("f3") + " - D: " + ((ProfileOperationSlot)this).OperationData.SlotData.SlotDiameter.ToString("f3") + text;
				}
				return Name + " - " + ProfileTempVars.strRoundRect + "W: " + ((ProfileOperationRoundRectangle)this).OperationData.RectangleRoundData.RoundRectangleWidth.ToString("f3") + " - H: " + ((ProfileOperationRoundRectangle)this).OperationData.RectangleRoundData.RoundRectangleHeight.ToString("f3") + " - R: " + ((ProfileOperationRoundRectangle)this).OperationData.RectangleRoundData.RoundRectangleRadius.ToString("f3") + text;
			}
			return Name + " - " + ProfileTempVars.strRectangle + "W: " + ((ProfileOperationRectangle)this).OperationData.RectangleData.RectangleWidth.ToString("f3") + " - H: " + ((ProfileOperationRectangle)this).OperationData.RectangleData.RectangleHeight.ToString("f3") + text;
		}
		return Name + " - " + ProfileTempVars.strCircle + "D: " + ((ProfileOperationCircle)this).OperationData.CircleData.CircleDiameter.ToString("f3") + text;
	}
}
