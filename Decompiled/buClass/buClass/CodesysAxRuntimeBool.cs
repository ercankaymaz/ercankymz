using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class CodesysAxRuntimeBool : buSerilization
{
	public bool bStandstill;

	public bool bEnabled;

	public bool bHomingDone;

	public bool bAxisError;

	public bool bComOK;

	public bool bAllowToMove = true;

	public bool bJogPlus = false;

	public bool bJogMinus = false;

	public bool bMaintananceAvailable = false;

	public CodesysAxRuntimeBool()
	{
	}

	public CodesysAxRuntimeBool(CodesysAxRuntimeBool data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null) || !(GetType() == CopiedClass.GetType()))
		{
			return;
		}
		FieldInfo[] fields = GetType().GetFields();
		if (fields != null)
		{
			for (int i = 0; i <= fields.Length - 1; i++)
			{
				string name = fields[i].Name;
				object value = fields[i].GetValue(CopiedClass);
				fields[i].SetValue(this, value);
			}
		}
	}

	public override string ToString()
	{
		return "Enabeled: " + bEnabled + " , Home: " + bHomingDone;
	}
}
