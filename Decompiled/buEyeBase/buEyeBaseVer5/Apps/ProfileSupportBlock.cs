using System.Reflection;

namespace buEyeBaseVer5.Apps;

public class ProfileSupportBlock : buSerilization5
{
	public bool SupportBlockEnable = false;

	public double SupportBlockZWidth = 0.0;

	public double SupportBlockZHeight = 0.0;

	public double SupportBlockZLength = 0.0;

	public double SupportBlockY1FrontWidth = 0.0;

	public double SupportBlockY1FrontHeight = 0.0;

	public double SupportBlockY1FrontLength = 0.0;

	public double SupportBlockY2BackWidth = 0.0;

	public double SupportBlockY2BackHeight = 0.0;

	public double SupportBlockY2BackLength = 0.0;

	public ProfileSupportBlock()
	{
	}

	public ProfileSupportBlock(ProfileSupportBlock data)
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
