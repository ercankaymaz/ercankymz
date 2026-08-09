using System.Reflection;

namespace buEyeBaseVer5.Apps;

public class ProfileMultiply : buSerilization5
{
	public bool ProfileMultiplyEnable = false;

	public bool ProfileMultiplyMirror = false;

	public double ProfileMultiplySpace = 0.0;

	public int ProfileMultiplyCount = 1;

	public ProfileMultiply()
	{
	}

	public ProfileMultiply(ProfileMultiply data)
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
		return "Enable: " + ProfileMultiplyEnable + " , Cnt: " + ProfileMultiplyCount + " , Mirror: " + ProfileMultiplyMirror + " , Space: " + ProfileMultiplySpace;
	}
}
