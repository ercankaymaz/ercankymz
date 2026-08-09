using System;
using System.Collections.Generic;
using System.Reflection;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleSlatPars : buSerilization5
{
	public marbleSlatData DataSlat = new marbleSlatData();

	public marbleCountertopInsidePars Socket1 = new marbleCountertopInsidePars();

	public marbleCountertopInsidePars Socket2 = new marbleCountertopInsidePars();

	public marbleChamferBothSidePars StartChamfer = new marbleChamferBothSidePars();

	public marbleChamferBothSidePars EndChamfer = new marbleChamferBothSidePars();

	public buEntitiesGroup EntGroup = new buEntitiesGroup();

	public Entity Solid = null;

	public Entity entityAngleSolidStart = null;

	public Entity entityAnglePlaneStart = null;

	public Entity entityChamferTopPlaneStart = null;

	public Entity entityChamferBottomPlaneStart = null;

	public Entity entityChamferTopSolidStart = null;

	public Entity entityChamferBottomSolidStart = null;

	public Entity entityAngleSolidEnd = null;

	public Entity entityAnglePlaneEnd = null;

	public Entity entityChamferTopPlaneEnd = null;

	public Entity entityChamferBottomPlaneEnd = null;

	public Entity entityChamferTopSolidEnd = null;

	public Entity entityChamferBottomSolidEnd = null;

	public List<buEntity> cutEntities = new List<buEntity>();

	public List<buEntity> connectEntities = new List<buEntity>();

	public List<Entity> EntityAngleText = new List<Entity>();

	public static List<string> Captions = new List<string>();

	public marbleSlatPars()
	{
	}

	public marbleSlatPars(marbleSlatPars data)
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
		DataSlat = new marbleSlatData(data.DataSlat);
		Socket1 = new marbleCountertopInsidePars(data.Socket1);
		Socket2 = new marbleCountertopInsidePars(data.Socket2);
		StartChamfer = new marbleChamferBothSidePars(data.StartChamfer);
		EndChamfer = new marbleChamferBothSidePars(data.EndChamfer);
		EntGroup = new buEntitiesGroup(data.EntGroup);
		buEntity.Copy(data.cutEntities, ref cutEntities);
		buEntity.Copy(data.connectEntities, ref connectEntities);
	}

	public override string ToString()
	{
		return "Enable : " + DataSlat.Enable + " , Width : " + DataSlat.Width + " , StartAngle : " + DataSlat.StartAngle + " , EndAngle : " + DataSlat.EndAngle;
	}
}
