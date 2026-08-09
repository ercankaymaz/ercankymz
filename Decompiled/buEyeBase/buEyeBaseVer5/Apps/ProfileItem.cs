using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class ProfileItem : buSerilization5
{
	public string ItemName = "";

	public string FileName = "";

	public string FileNameFull = "";

	public bool IsClamperDone = false;

	public bool isSimulationDone = false;

	public bool isCollisionControlDone = false;

	public bool isError = false;

	public bool isSupportBlockOffsetAdd = false;

	public bool isStandartProfile = false;

	public bool isCollisionOnlineAvailable = false;

	public bool isCollisionOfflineAvailable = false;

	public bool isGCodeCreated = false;

	public bool isGCodeSimMoveCreated = false;

	public bool CreatedFromDrawing = false;

	public bool Enable = true;

	public bool Selected = false;

	public bool ClamperChanged = false;

	public int YDirection = 1;

	public int StandartProfileIndex = -1;

	public double Length = 1000.0;

	public double Width = 0.0;

	public double Height = 0.0;

	public double TotalWidth = 0.0;

	public double Thickness = 1.0;

	public double LeftAngle = 0.0;

	public double RightAngle = 0.0;

	public double MaxOperationXPosition = 0.0;

	public int MaxClamperNumber = 4;

	public string TextureName = "";

	public Color colorProfile = Color.DarkGray;

	public Color colorSupportBlock = Color.Lime;

	public Point3D TotalOffset = new Point3D();

	public Point3D ProfileMinPoint = new Point3D();

	public Point3D ProfileMaxPoint = new Point3D();

	public Point3D ProfileCenterPoint = new Point3D();

	public Point3D ProfileOffset = new Point3D();

	public LeftRightType XReferanceLocation = LeftRightType.Left;

	public ProfileNewType ProfileType = ProfileNewType.Drawing;

	public Color Color = Color.DarkGray;

	public int Transparency = 120;

	public Vector3D Direction = new Vector3D(1.0, 0.0, 0.0);

	public ProfileSupportBlock SupportBlock = new ProfileSupportBlock();

	public ProfileMultiply MultiplyProfile = new ProfileMultiply();

	public MaterialSkin Skin = new MaterialSkin();

	public List<SelectedPlaneInfo> selectedFreePlanes = new List<SelectedPlaneInfo>();

	public List<ProfileOperation> Operations = new List<ProfileOperation>();

	public List<ProfileItemCalc> CalculationData = new List<ProfileItemCalc>();

	public List<buShape> Items = new List<buShape>();

	public List<ProfileDrawings> Drawings = new List<ProfileDrawings>();

	public ProfileClamperSettings ClamperSettings = new ProfileClamperSettings();

	public Entity LeftAngleEntity = null;

	public Entity RightAngleEntity = null;

	public Entity ProfileReferanceEntity = null;

	public Entity ProfileReferanceBottomEntity = null;

	public Entity ProfileReferanceBackEntity = null;

	public List<Entity> SupportBlockEntities = null;

	public List<Entity> auxEntities = null;

	public List<string> ProfileTraformations = new List<string>();

	public List<string> GCodeList = new List<string>();

	public List<string> warningAllList = new List<string>();

	public List<string> errorAllList = new List<string>();

	public List<string> infoAllList = new List<string>();

	public ProfileItem()
	{
	}

	public ProfileItem(ProfileItem data, bool Less = false)
	{
		if (data == null)
		{
			return;
		}
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
		if (this != null && CopiedClass != null && GetType() == CopiedClass.GetType())
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
		ProfileCenterPoint = new Point3D(data.ProfileCenterPoint.X, data.ProfileCenterPoint.Y, data.ProfileCenterPoint.Z);
		ProfileMinPoint = new Point3D(data.ProfileMinPoint.X, data.ProfileMinPoint.Y, data.ProfileMinPoint.Z);
		ProfileMaxPoint = new Point3D(data.ProfileMaxPoint.X, data.ProfileMaxPoint.Y, data.ProfileMaxPoint.Z);
		ClamperSettings = new ProfileClamperSettings(data.ClamperSettings);
		SupportBlock = new ProfileSupportBlock(data.SupportBlock);
		MultiplyProfile = new ProfileMultiply(data.MultiplyProfile);
		buShape.Copy(data.Items, ref Items);
		if (data.CalculationData != null)
		{
			for (int j = 0; j <= data.CalculationData.Count - 1; j++)
			{
				CalculationData.Add(new ProfileItemCalc(data.CalculationData[j]));
			}
		}
		if (!Less)
		{
			for (int k = 0; k <= data.selectedFreePlanes.Count - 1; k++)
			{
				selectedFreePlanes.Add(new SelectedPlaneInfo(data.selectedFreePlanes[k]));
			}
			if (data.ProfileReferanceEntity != null)
			{
				ProfileReferanceEntity = buVector5.CopyEntities(data.ProfileReferanceEntity);
			}
			if (data.ProfileReferanceBottomEntity != null)
			{
				ProfileReferanceBottomEntity = buVector5.CopyEntities(data.ProfileReferanceBottomEntity);
			}
			if (data.ProfileReferanceBackEntity != null)
			{
				ProfileReferanceBackEntity = buVector5.CopyEntities(data.ProfileReferanceBackEntity);
			}
			if (data.LeftAngleEntity != null)
			{
				LeftAngleEntity = buVector5.CopyEntities(data.LeftAngleEntity);
			}
			if (data.RightAngleEntity != null)
			{
				RightAngleEntity = buVector5.CopyEntities(data.RightAngleEntity);
			}
			if (SupportBlockEntities != null)
			{
				for (int l = 0; l <= data.SupportBlockEntities.Count - 1; l++)
				{
					SupportBlockEntities.Add(buVector5.CopyEntities(data.SupportBlockEntities[l]));
				}
			}
			if (auxEntities != null)
			{
				for (int m = 0; m <= data.auxEntities.Count - 1; m++)
				{
					auxEntities.Add(buVector5.CopyEntities(data.auxEntities[m]));
				}
			}
			if (data.Drawings != null)
			{
				for (int n = 0; n <= data.Drawings.Count - 1; n++)
				{
					ProfileDrawings item = new ProfileDrawings(data.Drawings[n]);
					Drawings.Add(item);
				}
			}
		}
		Operations = new List<ProfileOperation>();
		ProfileOperation.Copy(data.Operations, ref Operations);
	}

	public static ArrayList ToDef(List<ProfileItem> Items, int Space)
	{
		new string(' ', Space);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i <= Items.Count - 1; i++)
		{
			ArrayList arrayList2 = new ArrayList();
			arrayList2.AddRange(ToDef(Items[i], Space).ToArray());
			arrayList.AddRange(arrayList2.ToArray());
		}
		return arrayList;
	}

	public static ArrayList ToDef(ProfileItem refItem, int Space)
	{
		string text = "";
		buSerilization5.ExceptionalVariables.Add("GCodeList");
		buSerilization5.ExceptionalVariables.Add("ClamperSettings");
		ArrayList arrayList = new ArrayList();
		arrayList.AddRange(refItem.ToDefAll("", Space, SerilizationMode5.MultiLine));
		if (arrayList.Count > 0)
		{
			text = arrayList[arrayList.Count - 1].ToString();
			arrayList.RemoveAt(arrayList.Count - 1);
			for (int i = 0; i <= refItem.Drawings.Count - 1; i++)
			{
				arrayList.Add(buString5.SpaceChar(Space + 2) + "<Drawings>");
				arrayList.Add(buString5.SpaceChar(Space + 4) + "<OutterEntitites>");
				arrayList.AddRange(buEntity.ToDefEntity(refItem.Drawings[i].OutterEntitites, Space + 6));
				arrayList.Add(buString5.SpaceChar(Space + 4) + "</OutterEntitites>");
				arrayList.Add(buString5.SpaceChar(Space + 4) + "<InnerEntitites>");
				for (int j = 0; j <= refItem.Drawings[i].InnerEntities.Count - 1; j++)
				{
					arrayList.Add(buString5.SpaceChar(Space + 6) + "<InnerEntititesSub>");
					arrayList.AddRange(buEntity.ToDefEntity(refItem.Drawings[i].InnerEntities[j], Space + 8));
					arrayList.Add(buString5.SpaceChar(Space + 6) + "</InnerEntititesSub>");
				}
				arrayList.Add(buString5.SpaceChar(Space + 4) + "</InnerEntitites>");
				arrayList.Add(buString5.SpaceChar(Space + 4) + "<SolidProfileEntities>");
				if (refItem.Drawings[i].SolidEntity != null && refItem.Drawings[i].SolidEntity is Mesh)
				{
					buMesh refEntity = new buMesh((Mesh)refItem.Drawings[i].SolidEntity);
					arrayList.AddRange(buEntity.ToDefEntity(refEntity, Space + 6));
				}
				if (refItem.Drawings[i].SolidEntity != null && refItem.Drawings[i].SolidEntity is Brep)
				{
					if (((Brep)refItem.Drawings[i].SolidEntity).BoxMin == null)
					{
						((Brep)refItem.Drawings[i].SolidEntity).Regen(0.2);
					}
					Mesh mesh = ((Brep)refItem.Drawings[i].SolidEntity).ConvertToMesh();
					if (mesh != null)
					{
						buMesh refEntity2 = new buMesh(mesh);
						arrayList.AddRange(buEntity.ToDefEntity(refEntity2, Space + 6));
					}
				}
				arrayList.Add(buString5.SpaceChar(Space + 4) + "</SolidProfileEntities>");
				arrayList.Add(buString5.SpaceChar(Space + 2) + "</Drawings>");
			}
			arrayList.Add(buString5.SpaceChar(Space + 2) + "<ProfileOperation>");
			for (int k = 0; k <= refItem.Operations.Count - 1; k++)
			{
				arrayList.Add(buString5.SpaceChar(Space + 4) + "<PrfOperation>");
				arrayList.AddRange(ProfileOperation.ToDef(refItem.Operations[k], "", Space + 6));
				if (refItem.Operations[k].OperationData.OperationType == ProfileOperationTypes.FreeDraw)
				{
					if (refItem.Operations[k].EntityMultiXYPlane == null || refItem.Operations[k].EntityMultiXYPlane.Count <= 0)
					{
						if (refItem.Operations[k].EntityMultiContour != null && refItem.Operations[k].EntityMultiContour.Count > 0)
						{
							arrayList.Add(buString5.SpaceChar(Space + 6) + "<ContourEntitites>");
							arrayList.AddRange(buEntity.ToDefEntity(refItem.Operations[k].EntityMultiContour, Space + 8));
							arrayList.Add(buString5.SpaceChar(Space + 6) + "</ContourEntitites>");
						}
					}
					else
					{
						arrayList.Add(buString5.SpaceChar(Space + 6) + "<ContourEntititesXY>");
						arrayList.AddRange(buEntity.ToDefEntity(refItem.Operations[k].EntityMultiXYPlane, Space + 8));
						arrayList.Add(buString5.SpaceChar(Space + 6) + "</ContourEntititesXY>");
					}
				}
				if (refItem.Operations[k].EntityMultiSolidDepth != null)
				{
					for (int l = 0; l <= refItem.Operations[k].EntityMultiSolidDepth.Count - 1; l++)
					{
						if (refItem.Operations[k].EntityMultiSolidDepth[l] != null && refItem.Operations[k].EntityMultiSolidDepth[l] is Mesh)
						{
							arrayList.Add(buString5.SpaceChar(Space + 6) + "<SolidOperationEntities>");
							buMesh refEntity3 = new buMesh((Mesh)refItem.Operations[k].EntityMultiSolidDepth[l]);
							arrayList.AddRange(buEntity.ToDefEntity(refEntity3, Space + 6));
							arrayList.Add(buString5.SpaceChar(Space + 6) + "</SolidOperationEntities>");
						}
					}
				}
				arrayList.Add(buString5.SpaceChar(Space + 4) + "</PrfOperation>");
			}
			arrayList.Add(buString5.SpaceChar(Space + 2) + "</ProfileOperations>");
			arrayList.Add(text);
		}
		buSerilization5.ExceptionalVariables.Clear();
		return arrayList;
	}

	public static void Decode(ArrayList AL, ref List<ProfileItem> Items)
	{
		Items.Clear();
		Items = new List<ProfileItem>();
		new List<List<string>>();
		List<List<string>> CalcList = new List<List<string>>();
		buStatics.ListToSpecificList("<ProfileItem>", "</ProfileItem>", AddStartEndKey: true, AL, ref CalcList);
		for (int i = 0; i <= CalcList.Count - 1; i++)
		{
			ArrayList arrayList = new ArrayList();
			arrayList.AddRange(CalcList[i].ToArray());
			ProfileItem Item = new ProfileItem();
			Decode(arrayList, ref Item);
			Items.Add(Item);
		}
	}

	public static void Decode(ArrayList AL, ref ProfileItem Item)
	{
		Item = new ProfileItem();
		buSerilization5.Decode(AL, "", SerilizationMode5.MultiLine, Item);
		List<List<string>> CalcList = new List<List<string>>();
		List<List<string>> CalcList2 = new List<List<string>>();
		buStatics.ListToSpecificList("<Drawings>", "</Drawings>", AddStartEndKey: true, AL, ref CalcList2);
		if (CalcList2.Count <= 0)
		{
			ProfileDrawings profileDrawings = new ProfileDrawings();
			List<string> CalcList3 = new List<string>();
			buStatics.ListToSpecificList("<OutterEntitites>", "</OutterEntitites>", AddStartEndKey: false, AL, ref CalcList3);
			buStatics.ListToSpecificList("<buEntity>", "</buEntity>", AddStartEndKey: false, CalcList3, ref CalcList);
			for (int i = 0; i <= CalcList.Count - 1; i++)
			{
				buEntity buEntity2 = buEntity.Decode(CalcList[i]);
				if (buEntity2 != null)
				{
					profileDrawings.OutterEntitites.Add(buEntity2);
				}
			}
			CalcList3 = new List<string>();
			List<List<string>> CalcList4 = new List<List<string>>();
			buStatics.ListToSpecificList("<InnerEntitites>", "</InnerEntitites>", AddStartEndKey: false, AL, ref CalcList3);
			buStatics.ListToSpecificList("<InnerEntititesSub>", "</InnerEntititesSub>", AddStartEndKey: false, CalcList3, ref CalcList4);
			for (int j = 0; j <= CalcList4.Count - 1; j++)
			{
				buStatics.ListToSpecificList("<buEntity>", "</buEntity>", AddStartEndKey: false, CalcList4[j], ref CalcList);
				List<buEntity> list = new List<buEntity>();
				for (int k = 0; k <= CalcList.Count - 1; k++)
				{
					buEntity buEntity3 = buEntity.Decode(CalcList[k]);
					if (buEntity3 != null)
					{
						list.Add(buEntity3);
					}
				}
				if (list.Count > 0)
				{
					profileDrawings.InnerEntities.Add(list);
				}
			}
			Item.Drawings.Add(profileDrawings);
		}
		else
		{
			for (int l = 0; l <= CalcList2.Count - 1; l++)
			{
				List<string> CalcList5 = new List<string>();
				buStatics.ListToSpecificList("<Drawings>", "</Drawings>", AddStartEndKey: true, CalcList2[l], ref CalcList5);
				ProfileDrawings profileDrawings2 = new ProfileDrawings();
				List<string> CalcList6 = new List<string>();
				buStatics.ListToSpecificList("<OutterEntitites>", "</OutterEntitites>", AddStartEndKey: false, CalcList5, ref CalcList6);
				buStatics.ListToSpecificList("<buEntity>", "</buEntity>", AddStartEndKey: false, CalcList6, ref CalcList);
				for (int m = 0; m <= CalcList.Count - 1; m++)
				{
					buEntity buEntity4 = buEntity.Decode(CalcList[m]);
					if (buEntity4 != null)
					{
						profileDrawings2.OutterEntitites.Add(buEntity4);
					}
				}
				CalcList6 = new List<string>();
				List<List<string>> CalcList7 = new List<List<string>>();
				buStatics.ListToSpecificList("<InnerEntitites>", "</InnerEntitites>", AddStartEndKey: false, CalcList5, ref CalcList6);
				buStatics.ListToSpecificList("<InnerEntititesSub>", "</InnerEntititesSub>", AddStartEndKey: false, CalcList6, ref CalcList7);
				for (int n = 0; n <= CalcList7.Count - 1; n++)
				{
					buStatics.ListToSpecificList("<buEntity>", "</buEntity>", AddStartEndKey: false, CalcList7[n], ref CalcList);
					List<buEntity> list2 = new List<buEntity>();
					for (int num = 0; num <= CalcList.Count - 1; num++)
					{
						buEntity buEntity5 = buEntity.Decode(CalcList[num]);
						if (buEntity5 != null)
						{
							list2.Add(buEntity5);
						}
					}
					if (list2.Count > 0)
					{
						profileDrawings2.InnerEntities.Add(list2);
					}
				}
				Item.Drawings.Add(profileDrawings2);
				CalcList5.Clear();
			}
		}
		CalcList = new List<List<string>>();
		buStatics.ListToSpecificList("<PrfOperation>", "</PrfOperation>", AddStartEndKey: false, AL, ref CalcList);
		if (CalcList.Count == 0)
		{
			buStatics.ListToSpecificList("<Operations>", "</Operations>", AddStartEndKey: false, AL, ref CalcList);
		}
		for (int num2 = 0; num2 <= CalcList.Count - 1; num2++)
		{
			ArrayList arrayList = new ArrayList();
			arrayList.AddRange(CalcList[num2].ToArray());
			ProfileOperation OP = new ProfileOperation();
			ProfileOperation.Decode(CalcList[num2], ref OP);
			if (OP.MinPoint.X == OP.MaxPoint.X)
			{
				continue;
			}
			OP.OperationData.CamParNotch.Notch.NotchCutType = OP.CamOPData.NotchCutType;
			if (OP.OperationData.OperationType == ProfileOperationTypes.FreeDraw)
			{
				OP.EntityMultiContour = new List<buEntity>();
				OP.EntityMultiXYPlane = new List<buEntity>();
				List<string> CalcList8 = new List<string>();
				buStatics.ListToSpecificList("<ContourEntitites>", "</ContourEntitites>", AddStartEndKey: false, CalcList[num2], ref CalcList8);
				if (CalcList8.Count > 0)
				{
					List<List<string>> CalcList9 = new List<List<string>>();
					buStatics.ListToSpecificList("<buEntity>", "</buEntity>", AddStartEndKey: false, CalcList8, ref CalcList9);
					for (int num3 = 0; num3 <= CalcList9.Count - 1; num3++)
					{
						buEntity buEntity6 = buEntity.Decode(CalcList9[num3]);
						if (buEntity6 != null)
						{
							OP.EntityMultiContour.Add(buEntity6);
						}
					}
					CalcList9.Clear();
				}
				CalcList8.Clear();
				CalcList8 = new List<string>();
				buStatics.ListToSpecificList("<ContourEntititesXY>", "</ContourEntititesXY>", AddStartEndKey: false, CalcList[num2], ref CalcList8);
				if (CalcList8.Count > 0)
				{
					List<List<string>> CalcList10 = new List<List<string>>();
					buStatics.ListToSpecificList("<buEntity>", "</buEntity>", AddStartEndKey: false, CalcList8, ref CalcList10);
					for (int num4 = 0; num4 <= CalcList10.Count - 1; num4++)
					{
						buEntity buEntity7 = buEntity.Decode(CalcList10[num4]);
						if (buEntity7 != null)
						{
							OP.EntityMultiXYPlane.Add(buEntity7);
						}
					}
					CalcList10.Clear();
				}
				CalcList8.Clear();
			}
			Item.Operations.Add(OP);
		}
		CalcList.Clear();
		CalcList2.Clear();
	}

	public override string ToString()
	{
		return ItemName.ToString() + "- Len: " + Length.ToString("f3") + " - OP: " + Operations.Count;
	}
}
