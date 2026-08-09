using System.Reflection;
using buClass;

namespace buEyeBaseVer5;

public class SewingCode
{
	public string Explanation = "";

	public SewingCodes Codes = SewingCodes.None;

	public double Data1 = 0.0;

	public double Data2 = 0.0;

	public double Data3 = 0.0;

	public double Data4 = 0.0;

	public double Data5 = 0.0;

	public SewingCode()
	{
	}

	public SewingCode(SewingCodes codes, string explanation)
	{
		Codes = codes;
		Explanation = explanation;
	}

	public SewingCode(SewingCode data)
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

	public override string ToString()
	{
		return Codes.ToString() + " ; Data1: " + Data1.ToString("f3") + " ; Data2: " + Data2.ToString("f3") + " ; Data3: " + Data3.ToString("f3") + " ; Data4: " + Data4.ToString("f3") + " ; Data5: " + Data5.ToString("f3");
	}
}
