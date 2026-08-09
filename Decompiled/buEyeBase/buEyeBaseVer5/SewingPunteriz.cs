using System.Reflection;
using buClass;

namespace buEyeBaseVer5;

public class SewingPunteriz
{
	public SewingPunterizType PunterizType = SewingPunterizType.MinLeft;

	public SewingPunterizMethod PunterizMethod = SewingPunterizMethod.StitchThenPunteriz;

	public double Length = 10.0;

	public double Width = 2.0;

	public double Height = 4.0;

	public double Angle = 0.0;

	public int Count = 5;

	public SewingPunteriz()
	{
	}

	public SewingPunteriz(SewingPunteriz data)
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
		return PunterizType.ToString() + " ; Length: " + Length.ToString("f3") + " ; Width: " + Width.ToString("f3") + " ; Count: " + Count.ToString("f3");
	}
}
