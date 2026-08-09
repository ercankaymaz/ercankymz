using System;
using System.Collections.Generic;
using System.Reflection;
using devDept.Eyeshot.Entities;

namespace buEyeBaseVer5;

[Serializable]
public class CamEntitiesToEntities : buSerilization5
{
	public List<Entity> G0Entities = new List<Entity>();

	public List<Entity> G1Entities = new List<Entity>();

	public List<Entity> LeaveEntities = new List<Entity>();

	public List<Entity> PlungeEntities = new List<Entity>();

	public List<Entity> LeadInEntities = new List<Entity>();

	public List<Entity> LeadOutEntities = new List<Entity>();

	public List<Entity> MarkEntities = new List<Entity>();

	public List<Entity> OtherEntities = new List<Entity>();

	public List<Entity> AllEntities = new List<Entity>();

	public CamEntitiesToEntities()
	{
	}

	public CamEntitiesToEntities(CamEntitiesToEntities data)
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
		buVector5.CopyEntities(data.G0Entities, ref G0Entities);
		buVector5.CopyEntities(data.G1Entities, ref G1Entities);
		buVector5.CopyEntities(data.LeaveEntities, ref LeaveEntities);
		buVector5.CopyEntities(data.PlungeEntities, ref PlungeEntities);
		buVector5.CopyEntities(data.LeadInEntities, ref LeadInEntities);
		buVector5.CopyEntities(data.LeadOutEntities, ref LeadOutEntities);
		buVector5.CopyEntities(data.MarkEntities, ref MarkEntities);
		buVector5.CopyEntities(data.OtherEntities, ref OtherEntities);
	}
}
