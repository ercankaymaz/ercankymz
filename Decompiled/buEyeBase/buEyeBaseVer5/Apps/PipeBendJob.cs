using System;
using System.Collections.Generic;
using System.Reflection;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class PipeBendJob : buSerilization5
{
	public string Name = "PipeBend";

	public double PipeDiameter = 40.0;

	public List<BendingLRAMaterialData> BendingList = new List<BendingLRAMaterialData>();

	public List<PipeBendMove> Moves = new List<PipeBendMove>();

	public List<PipeBendSimulationMove> SimMoves = new List<PipeBendSimulationMove>();

	public MaterialBase5 Material = new MaterialBase5();

	public List<Block> BlockList = new List<Block>();

	public List<Entity> EntityList = new List<Entity>();

	public List<buEntity> calcEntities = new List<buEntity>();

	public List<Entity> AuxEntityList = new List<Entity>();

	public PipeBendJob()
	{
	}

	public PipeBendJob(PipeBendJob data)
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
		Material = new MaterialBase5(data.Material);
	}

	public override string ToString()
	{
		return "BendingList: " + BendingList.Count;
	}
}
