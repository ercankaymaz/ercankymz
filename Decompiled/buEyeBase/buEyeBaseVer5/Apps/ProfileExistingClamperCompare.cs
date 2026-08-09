using System.Reflection;

namespace buEyeBaseVer5.Apps;

public class ProfileExistingClamperCompare : buSerilization5
{
	public double SmallChangeGap = 50.0;

	public double BigChangeGap = 300.0;

	public double LeftDistance = 0.0;

	public double RightDistance = 0.0;

	public bool UseBig = false;

	public ProfileExistingClamperCompare()
	{
	}

	public ProfileExistingClamperCompare(ProfileExistingClamperCompare data)
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

	public ProfileExistingClamperCompare(double smallChangeGap, double bigChangeGap, bool usebig, double leftdis, double rightdis)
	{
		SmallChangeGap = smallChangeGap;
		BigChangeGap = bigChangeGap;
		UseBig = usebig;
		LeftDistance = leftdis;
		RightDistance = rightdis;
	}

	public override string ToString()
	{
		return "BigChangeGap: " + BigChangeGap + " - SmallChangeGap: " + SmallChangeGap;
	}
}
