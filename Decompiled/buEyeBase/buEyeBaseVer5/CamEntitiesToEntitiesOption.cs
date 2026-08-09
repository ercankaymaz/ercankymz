using System;
using System.Reflection;

namespace buEyeBaseVer5;

[Serializable]
public class CamEntitiesToEntitiesOption : buSerilization5
{
	public bool G0EntitiesEnable = false;

	public bool G1EntitiesEnable = false;

	public bool LeaveEntitiesEnable = false;

	public bool PlungeEntitiesEnable = false;

	public bool LeadInEntitiesEnable = false;

	public bool LeadOutEntitiesEnable = false;

	public bool MarkEntitiesEnable = false;

	public bool OtherEntitiesEnable = false;

	public bool AllAsSingle = false;

	public bool G1EntitiesFromOriginal = false;

	public CamEntitiesToEntitiesOption()
	{
	}

	public CamEntitiesToEntitiesOption(bool G0, bool G1, bool Leave, bool Plunge)
	{
		G0EntitiesEnable = G0;
		G1EntitiesEnable = G1;
		LeaveEntitiesEnable = Leave;
		PlungeEntitiesEnable = Plunge;
	}

	public CamEntitiesToEntitiesOption(bool G0, bool G1, bool Leave, bool Plunge, bool G1Original)
	{
		G0EntitiesEnable = G0;
		G1EntitiesEnable = G1;
		LeaveEntitiesEnable = Leave;
		PlungeEntitiesEnable = Plunge;
		G1EntitiesFromOriginal = G1Original;
	}

	public CamEntitiesToEntitiesOption(bool G0, bool G1, bool Leave, bool Plunge, bool G1Original, bool leadin, bool leadout)
	{
		G0EntitiesEnable = G0;
		G1EntitiesEnable = G1;
		LeaveEntitiesEnable = Leave;
		PlungeEntitiesEnable = Plunge;
		G1EntitiesFromOriginal = G1Original;
		LeadInEntitiesEnable = leadin;
		LeadOutEntitiesEnable = leadout;
	}

	public CamEntitiesToEntitiesOption(CamEntitiesToEntitiesOption data)
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
	}
}
