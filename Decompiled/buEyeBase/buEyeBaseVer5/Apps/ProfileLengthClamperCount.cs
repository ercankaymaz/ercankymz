using System.Collections.Generic;
using System.Reflection;

namespace buEyeBaseVer5.Apps;

public class ProfileLengthClamperCount : buSerilization5
{
	public double ProfileLength = 500.0;

	public int ClamperCount = 2;

	public ProfileLengthClamperCount()
	{
	}

	public ProfileLengthClamperCount(double profilelen, int clampcount)
	{
		ProfileLength = profilelen;
		ClamperCount = clampcount;
	}

	public ProfileLengthClamperCount(ProfileLengthClamperCount data)
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
		return "ProfileLength: " + ProfileLength.ToString("f2") + " , ClamperCount: " + ClamperCount;
	}

	public static void Copy(List<ProfileLengthClamperCount> RefClamper, ref List<ProfileLengthClamperCount> CopiedClamper)
	{
		CopiedClamper.Clear();
		CopiedClamper = new List<ProfileLengthClamperCount>();
		for (int i = 0; i <= RefClamper.Count - 1; i++)
		{
			ProfileLengthClamperCount CopiedClamper2 = new ProfileLengthClamperCount();
			Copy(RefClamper[i], ref CopiedClamper2);
			CopiedClamper.Add(CopiedClamper2);
		}
	}

	public static void Copy(ProfileLengthClamperCount RefClamper, ref ProfileLengthClamperCount CopiedClamper)
	{
		CopiedClamper = new ProfileLengthClamperCount(RefClamper);
	}
}
