using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;
using devDept.Geometry;

namespace buEyeBaseVer5;

[Serializable]
public class EntityInfo : buSerilization5
{
	public int Sequence = -1;

	public int OriginalEntityIndex = -1;

	public int InsideIndex = -1;

	public int EntityIndex = -1;

	public int EntitySubIndex = -1;

	public int RefIndex = -1;

	public int CamIndex = -1;

	public bool CamSelected = false;

	public int CamSelectedCount = 0;

	public bool CamSelectable = true;

	public string CamPlungeAxis = null;

	public string CamLeaveAxis = null;

	public double CamSpeed = 0.0;

	public double PlungeSpeed = 0.0;

	public double SpindleSpeed = 0.0;

	public bool Enable = true;

	public bool Calculated = false;

	public bool Selectable = true;

	public bool DontUseForCalculation = false;

	public bool isUpperEntity = false;

	public int CamID = -1;

	public int ItemID = -1;

	public int EdgeID = -1;

	public int CamToolNo = 1;

	public string EntityName = null;

	public string CamCode = null;

	public string ID = null;

	public string Tags = null;

	public string Data = null;

	public double AuxVal = 0.0;

	public double Length = 0.0;

	public double Radius = 0.0;

	public Point3D Offset = null;

	public PointABC OffsetABC = null;

	public OrientationAngle OffsetAngle = null;

	public List<string> Commands = null;

	public List<string> Options = null;

	public entityOriginalType OrjType = entityOriginalType.None;

	public EntityInfo()
	{
	}

	public EntityInfo(EntityInfo data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
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
		if (data.Offset != null)
		{
			Offset = new Point3D(data.Offset.X, data.Offset.Y, data.Offset.Z);
		}
		if (data.OffsetABC != null)
		{
			OffsetABC = new PointABC(data.OffsetABC.A, data.OffsetABC.B, data.OffsetABC.C);
		}
		if (data.Commands != null)
		{
			Commands = new List<string>();
			Commands.AddRange(data.Commands);
		}
		if (data.Options != null)
		{
			Options = new List<string>();
			Options.AddRange(data.Options);
		}
	}

	public override string ToString()
	{
		string text = "";
		if (Sequence >= 0)
		{
			text = text + "Seq: " + Sequence;
		}
		if (OriginalEntityIndex >= 0)
		{
			text = ((text.Length > 0) ? (text + " , OrjEntIndex: " + OriginalEntityIndex) : (text + "OrjEntIndex: " + OriginalEntityIndex));
		}
		if (RefIndex >= 0)
		{
			text = ((text.Length > 0) ? (text + " , RefIndex: " + RefIndex) : (text + "RefIndex: " + RefIndex));
		}
		if (EntityIndex >= 0)
		{
			text = ((text.Length > 0) ? (text + " , EntIndex: " + EntityIndex) : (text + "EntIndex: " + EntityIndex));
		}
		if (EntitySubIndex >= 0)
		{
			text = ((text.Length > 0) ? (text + " , EntSubIndex: " + EntitySubIndex) : (text + "EntSubIndex: " + EntitySubIndex));
		}
		if (CamIndex >= 0)
		{
			text = ((text.Length > 0) ? (text + " , CamIndex: " + CamIndex) : (text + "CamIndex: " + CamIndex));
		}
		if (CamID >= 0)
		{
			text = ((text.Length > 0) ? (text + " , CamID: " + CamID) : (text + "CamID: " + CamID));
		}
		text = ((text.Length > 0) ? (text + " , Cam Selected: " + CamSelected) : (text + "Cam Selected: " + CamSelected));
		if (!Enable)
		{
			text = ((text.Length > 0) ? (text + " , Enable: " + Enable) : (text + "Enable: " + Enable));
		}
		if (AuxVal != 0.0)
		{
			text = ((text.Length > 0) ? (text + " , Val: " + AuxVal) : (text + "Val: " + AuxVal));
		}
		if (Offset != null)
		{
			text = ((text.Length > 0) ? (text + " , Offset: (" + Offset.X + " , " + Offset.Y + " , " + Offset.Z + ")") : (text + "Offset: (" + Offset.X + " , " + Offset.Y + " , " + Offset.Z + ")"));
		}
		if (OffsetABC != null)
		{
			text = ((text.Length > 0) ? (text + " , OffsetABC: (" + OffsetABC.A + " , " + OffsetABC.B + " , " + OffsetABC.C + ")") : (text + "OffsetABC: (" + OffsetABC.A + " , " + OffsetABC.B + " , " + OffsetABC.C + ")"));
		}
		if (OrjType != entityOriginalType.None)
		{
			text = text + " Orj: " + OrjType;
		}
		return text;
	}
}
