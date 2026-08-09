using System;
using System.Collections.Generic;
using System.Reflection;
using buEyeBaseVer5.buEntities;

namespace buEyeBaseVer5;

[Serializable]
public class CamEntitiesTobuEntities : buSerilization5
{
	public List<buEntity> G0Entities = new List<buEntity>();

	public List<buEntity> G1Entities = new List<buEntity>();

	public List<buEntity> LeaveEntities = new List<buEntity>();

	public List<buEntity> PlungeEntities = new List<buEntity>();

	public List<buEntity> LeadInEntities = new List<buEntity>();

	public List<buEntity> LeadOutEntities = new List<buEntity>();

	public List<buEntity> MarkEntities = new List<buEntity>();

	public List<buEntity> OtherEntities = new List<buEntity>();

	public List<buEntity> AllEntities = new List<buEntity>();

	public CamEntitiesTobuEntities()
	{
	}

	public CamEntitiesTobuEntities(CamEntitiesTobuEntities data)
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
		buEntity.Copy(data.G0Entities, ref G0Entities);
		buEntity.Copy(data.G1Entities, ref G1Entities);
		buEntity.Copy(data.LeaveEntities, ref LeaveEntities);
		buEntity.Copy(data.PlungeEntities, ref PlungeEntities);
		buEntity.Copy(data.LeadInEntities, ref LeadInEntities);
		buEntity.Copy(data.LeadOutEntities, ref LeadOutEntities);
		buEntity.Copy(data.MarkEntities, ref MarkEntities);
		buEntity.Copy(data.OtherEntities, ref OtherEntities);
	}
}
