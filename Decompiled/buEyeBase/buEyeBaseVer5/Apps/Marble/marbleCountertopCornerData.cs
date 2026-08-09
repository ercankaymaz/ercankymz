using System;
using System.Reflection;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleCountertopCornerData : buSerilization5
{
	public MarbleCountertopCornerTypes CornerType = MarbleCountertopCornerTypes.Rectangle;

	public bool Enable = false;

	public double CornerWidth = 100.0;

	public double CornerHeight = 100.0;

	public marbleCountertopCornerData()
	{
	}

	public marbleCountertopCornerData(marbleCountertopCornerData data)
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
		return "Corner : " + Enable + " , Width: " + CornerWidth + " , Height: " + CornerHeight;
	}
}
