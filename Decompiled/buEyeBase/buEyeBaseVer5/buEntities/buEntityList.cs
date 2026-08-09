using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using buClass;
using buEyeBaseVer5.Apps.Marble;
using devDept.Geometry;

namespace buEyeBaseVer5.buEntities;

[Serializable]
public class buEntityList : buSerilization5
{
	public List<buEntity> Entities = new List<buEntity>();

	public List<Point3D> Points = null;

	public Point3D pntMassCenter = null;

	public string GroupInfo = "";

	public double Depth = 0.0;

	public entityGroupType GroupType = entityGroupType.None;

	public entityToolType ToolType = entityToolType.None;

	public ClockDirectionType Direction = ClockDirectionType.CCW;

	public entityInOutDirectionType InOutType = entityInOutDirectionType.None;

	public ToolBase5 Tool = null;

	public LayerBase5 Layer = null;

	public string Aux = "";

	public marbleEntityData Marble = null;

	public buEntityList()
	{
	}

	public buEntityList(List<buEntity> entities)
	{
		buEntity.Copy(entities, ref Entities);
	}

	public buEntityList(buEntityList Data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(Data, ref CopiedClass);
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
		Entities = new List<buEntity>();
		for (int j = 0; j <= Data.Entities.Count - 1; j++)
		{
			buEntity copiedEntity = null;
			buEntity.Copy(Data.Entities[j], ref copiedEntity);
			Entities.Add(copiedEntity);
		}
		if (Data.Points != null)
		{
			Points = new List<Point3D>();
			buVector5.Copy(Data.Points, ref Points);
		}
		if (Data.pntMassCenter != null)
		{
			pntMassCenter = buVector5.ToPoint3D(Data.pntMassCenter);
		}
		if (Data.Layer != null)
		{
			Layer = new LayerBase5(Data.Layer);
		}
		if (Data.Tool != null)
		{
			Tool = new ToolBase5(Data.Tool);
		}
		if (Data.Marble != null)
		{
			Marble = new marbleEntityData(Data.Marble);
		}
	}

	public void Translate(double dX, double dY, double dZ = 0.0)
	{
		for (int i = 0; i <= Entities.Count - 1; i++)
		{
			buEntity buEntity2 = Entities[i];
			buEntity2.Translate(dX, dY, dZ);
		}
		if (Points != null)
		{
			for (int j = 0; j <= Points.Count - 1; j++)
			{
				Points[j].X = Points[j].X + dX;
				Points[j].Y = Points[j].Y + dY;
				Points[j].Z = Points[j].Y + dZ;
			}
		}
	}

	public void Rotate(double Angle, Vector3D axis, Point3D center)
	{
		for (int i = 0; i <= Entities.Count - 1; i++)
		{
			buEntity buEntity2 = Entities[i];
			buEntity2.Rotate(Angle, axis, center);
		}
		if (Points != null)
		{
			buCall.buVector5_0.Rotate(center, Angle, axis, ref Points);
		}
	}

	public static ArrayList ToDefEntity(buEntityList refEntity, int Space)
	{
		ArrayList AL = new ArrayList();
		ToDefEntity(refEntity, Space, ref AL);
		return AL;
	}

	public static void ToDefEntity(buEntityList refEntity, int Space, ref ArrayList AL)
	{
		AL.Clear();
		AL = new ArrayList();
		AL.Add(buString5.SpaceChar(Space) + "<buEntityListData>");
		AL.AddRange(buEntity.ToDefEntity(refEntity.Entities, Space + 2));
		AL.Add(buString5.SpaceChar(Space + 2) + "<buEntityListAdder>");
		AL.Add(buString5.SpaceChar(Space + 4) + "ListGroupInfo= " + refEntity.GroupInfo.ToString());
		AL.Add(buString5.SpaceChar(Space + 4) + "ListGroupType= " + refEntity.GroupType);
		AL.Add(buString5.SpaceChar(Space + 4) + "ListToolType= " + refEntity.ToolType);
		AL.Add(buString5.SpaceChar(Space + 4) + "ListAux= " + refEntity.Aux.ToString());
		AL.Add(buString5.SpaceChar(Space + 4) + "ListDirection= " + refEntity.Direction);
		if (refEntity.pntMassCenter != null)
		{
			AL.Add(buString5.SpaceChar(Space + 4) + "ListpntMassCenter= " + buSerilization5.ToDef(refEntity.pntMassCenter));
		}
		if (refEntity.Marble != null)
		{
			AL.Add(buString5.SpaceChar(Space + 4) + "ListMarble= " + buSerilization5.ClassToString(refEntity.Marble));
		}
		if (refEntity.Layer != null)
		{
			ArrayList arrayList = new ArrayList();
			arrayList.AddRange(LayerBase5.ToDef(refEntity.Layer));
			if (arrayList.Count > 0)
			{
				AL.Add(buString5.SpaceChar(Space + 4) + "ListLayer1= " + arrayList[0].ToString());
			}
		}
		if (refEntity.Tool != null)
		{
			ArrayList arrayList2 = new ArrayList();
			arrayList2.AddRange(ToolBase5.ToDef(refEntity.Tool));
			if (arrayList2.Count >= 4)
			{
				AL.Add(buString5.SpaceChar(Space + 4) + "ListTool1= " + arrayList2[0].ToString());
				AL.Add(buString5.SpaceChar(Space + 4) + "ListTool2= " + arrayList2[1].ToString());
				AL.Add(buString5.SpaceChar(Space + 4) + "ListTool3= " + arrayList2[2].ToString());
				AL.Add(buString5.SpaceChar(Space + 4) + "ListTool4= " + arrayList2[3].ToString());
			}
		}
		AL.Add(buString5.SpaceChar(Space + 2) + "</buEntityListAdder>");
		AL.Add(buString5.SpaceChar(Space) + "</buEntityListData>");
	}

	public static void ToDefEntity(List<buEntityList> refEntities, int Space, ref ArrayList AL)
	{
		AL.Clear();
		AL = new ArrayList();
		for (int i = 0; i <= refEntities.Count - 1; i++)
		{
			AL.AddRange(ToDefEntity(refEntities[i], Space));
		}
	}

	public static ArrayList ToDefEntity(List<buEntityList> refEntities, int Space)
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i <= refEntities.Count - 1; i++)
		{
			arrayList.AddRange(ToDefEntity(refEntities[i], Space));
		}
		return arrayList;
	}

	public static void Decode(List<string> SL, ref buEntityList refEntity)
	{
		try
		{
			if (SL.Count < 2)
			{
				return;
			}
			refEntity = new buEntityList();
			List<string> CalcList = new List<string>();
			List<List<string>> CalcList2 = new List<List<string>>();
			buStatics.ListToSpecificList("<buEntity>", "</buEntity>", AddStartEndKey: false, SL, ref CalcList2);
			buString5.ListToSpecificList("<buEntityListAdder>", "</buEntityListAdder>", AddStartEndKey: false, SL, ref CalcList);
			for (int i = 0; i <= CalcList2.Count - 1; i++)
			{
				buEntity buEntity2 = buEntity.Decode(CalcList2[i]);
				if (buEntity2 != null)
				{
					refEntity.Entities.Add(buEntity2);
				}
			}
			string[] array = null;
			if (CalcList.Count >= 1)
			{
				array = CalcList[0].Split('=');
				if (array.Length >= 2)
				{
					refEntity.GroupInfo = array[1];
				}
			}
			if (CalcList.Count >= 2)
			{
				array = CalcList[1].Split('=');
				if (array.Length >= 2)
				{
					refEntity.GroupType = (entityGroupType)Enum.Parse(typeof(entityGroupType), array[1], ignoreCase: true);
				}
			}
			if (CalcList.Count >= 3)
			{
				array = CalcList[2].Split('=');
				if (array.Length >= 2)
				{
					refEntity.ToolType = (entityToolType)Enum.Parse(typeof(entityToolType), array[1], ignoreCase: true);
				}
			}
			if (CalcList.Count >= 4)
			{
				array = CalcList[3].Split('=');
				if (array.Length >= 2)
				{
					refEntity.Aux = array[1];
				}
			}
			if (CalcList.Count >= 5)
			{
				array = CalcList[4].Split('=');
				if (array.Length >= 2)
				{
					refEntity.Direction = (ClockDirectionType)Enum.Parse(typeof(ClockDirectionType), array[1], ignoreCase: true);
				}
			}
			for (int j = 5; j <= CalcList.Count - 1; j++)
			{
				if (CalcList[j].IndexOf("ListpntMassCenter") >= 0)
				{
					array = CalcList[j].Split('=');
					if (array.Length >= 2)
					{
						refEntity.pntMassCenter = buSerilization5.DecoderFromPoint3D(array[1]);
					}
				}
				if (CalcList[j].IndexOf("ListMarble") >= 0)
				{
					array = CalcList[j].Split('=');
					if (array.Length >= 2)
					{
						object ObjPar = refEntity.Marble;
						buSerilization5.StringToClass(ref ObjPar, array[1]);
					}
				}
				if (CalcList[j].IndexOf("ListLayer1") >= 0)
				{
					array = CalcList[j].Split('=');
					if (array.Length >= 2)
					{
						object ObjPar2 = refEntity.Layer;
						buSerilization5.StringToClass(ref ObjPar2, array[1]);
					}
				}
				if (CalcList[j].IndexOf("ListTool1") >= 0)
				{
					refEntity.Tool = new ToolBase5();
					array = CalcList[j].Split('=');
					if (array.Length >= 2)
					{
						EnumConverter enumConverter = new EnumConverter(typeof(ToolPurpose));
						refEntity.Tool.Purpose = (ToolPurpose)enumConverter.ConvertFromString(array[1]);
					}
				}
				if (CalcList[j].IndexOf("ListTool2") >= 0)
				{
					array = CalcList[j].Split('=');
					if (array.Length >= 2)
					{
						object ObjPar3 = refEntity.Tool.Data;
						buSerilization5.StringToClass(ref ObjPar3, array[1]);
					}
				}
				if (CalcList[j].IndexOf("ListTool3") >= 0)
				{
					array = CalcList[j].Split('=');
					if (array.Length >= 2)
					{
						object ObjPar4 = refEntity.Tool.Geometry;
						buSerilization5.StringToClass(ref ObjPar4, array[1]);
					}
				}
				if (CalcList[j].IndexOf("ListTool4") >= 0)
				{
					array = CalcList[j].Split('=');
					if (array.Length >= 2)
					{
						object ObjPar5 = refEntity.Tool.CamData;
						buSerilization5.StringToClass(ref ObjPar5, array[1]);
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public static buEntityList Decode(List<string> SL)
	{
		try
		{
			buEntityList refEntity = new buEntityList();
			Decode(SL, ref refEntity);
			return refEntity;
		}
		catch (Exception)
		{
			return null;
		}
	}

	public static void Copy(List<buEntityList> refEntities, ref List<buEntityList> copyEntities)
	{
		if (refEntities != null)
		{
			copyEntities = new List<buEntityList>();
			for (int i = 0; i <= refEntities.Count - 1; i++)
			{
				copyEntities.Add(new buEntityList(refEntities[i]));
			}
		}
	}

	public static void Copy(List<List<buEntityList>> refEntities, ref List<List<buEntityList>> copyEntities)
	{
		if (refEntities == null)
		{
			return;
		}
		copyEntities = new List<List<buEntityList>>();
		for (int i = 0; i <= refEntities.Count - 1; i++)
		{
			List<buEntityList> list = new List<buEntityList>();
			for (int j = 0; j <= refEntities[i].Count - 1; j++)
			{
				list.Add(new buEntityList(refEntities[i][j]));
			}
			if (list.Count > 0)
			{
				copyEntities.Add(list);
			}
		}
	}

	public override string ToString()
	{
		string text = "Entities: " + Entities.Count;
		if (GroupType != entityGroupType.None)
		{
			text = text + " - " + GroupType;
		}
		if (GroupInfo.Length > 0)
		{
			text = text + " - Info: " + GroupInfo;
		}
		if (ToolType != entityToolType.None)
		{
			text = text + " - " + ToolType;
		}
		if (Layer != null)
		{
			text = text + " - Layer: " + Layer.Name;
		}
		if (Tool != null)
		{
			text = text + " - Tool: " + Tool.Data.Name;
		}
		return text;
	}
}
