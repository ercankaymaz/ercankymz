using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class CharDefinitions : buSerilization
{
	public string Char = "";

	public int Decimal;

	public double Multiply;

	public int SpaceWithCharAndValue;

	public int SpaceWithNextCommandAndValue;

	public int RoundCount = 3;

	public string AdditionalData = "";

	public int SpaceWithAdditionalData = 0;

	public CharDefinitions()
	{
	}

	public CharDefinitions(CharDefinitions data)
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

	public CharDefinitions(string chars, int decimalpoint, double multiply, int spacewithchatandvalue, int spacewithnextcommand)
	{
		Char = chars;
		Decimal = decimalpoint;
		Multiply = multiply;
		SpaceWithCharAndValue = spacewithchatandvalue;
		SpaceWithNextCommandAndValue = spacewithnextcommand;
	}
}
