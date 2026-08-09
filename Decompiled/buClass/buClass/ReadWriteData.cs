using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class ReadWriteData : buSerilization
{
	public bool bWriteSettingsParameter = false;

	public bool bWriteCNCSettingsParameter = false;

	public bool bWriteG54Parameter = false;

	public bool bWriteToolParameter = false;

	public bool bWriteAppParameter = false;

	public bool bWriteCounterParameters = false;

	public bool bWriteCncAutoListParameter = false;

	public bool bVariablesImported = false;

	public bool bParameterWriting = false;

	public bool bReadInputs = false;

	public bool bReadOutputs = false;

	public bool bReadSystemVars = false;

	public bool bReadAppVars = false;

	public bool bReadUserVars = false;

	public ReadWriteData()
	{
	}

	public ReadWriteData(ReadWriteData data)
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
		return "bReadSystemVars: " + bReadSystemVars;
	}
}
