using System.Reflection;

namespace buEyeBaseVer5;

public class ShapeProfileData : buSerilization5
{
	public bool EachLayer = true;

	public bool ManuelZ = false;

	public double ExtraDepth = 1.0;

	public ShapeProfileData()
	{
	}

	public ShapeProfileData(ShapeProfileData data)
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
		return "ExtraDepth: " + ExtraDepth + " , EachLayer : " + EachLayer + " , ManuelZ: " + ManuelZ;
	}
}
