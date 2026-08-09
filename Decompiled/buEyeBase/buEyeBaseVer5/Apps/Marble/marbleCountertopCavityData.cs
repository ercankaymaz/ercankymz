using System;
using System.Reflection;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleCountertopCavityData : buSerilization5
{
	public bool Enable = true;

	public double Rotation = 0.0;

	public double CavityDepth = 1.0;

	public double CavityLength = 150.0;

	public double CavityHeight = 5.0;

	public double CavityOffsetX = 0.0;

	public double CavityOffsetY = 20.0;

	public double CavityAngle = 0.0;

	public int CavityCount = 3;

	public double PositionX = 0.0;

	public double PositionY = 0.0;

	public string CavityName = "";

	public MarbleToolType ToolType = MarbleToolType.Milling;

	public marbleCountertopCavityData()
	{
	}

	public marbleCountertopCavityData(marbleCountertopCavityData data)
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
		return "Cavity : " + Enable + " , Len : " + CavityLength + " , Height : " + CavityHeight + " , Depth : " + CavityDepth + " , X: " + PositionX + " , Y: " + PositionY;
	}
}
