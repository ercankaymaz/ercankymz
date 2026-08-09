using System;
using System.Drawing;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class ProfileOperationDataNotch : buSerilization
{
	public ProfileNotchType NotchType = ProfileNotchType.LType;

	public double NotchLDepth = 20.0;

	public double NotchLWidth = 10.0;

	public double NotchLHeight = 20.0;

	public UpDownLocationType NotchLUpDown = UpDownLocationType.Up;

	public double NotchUDepth = 20.0;

	public double NotchUWidth = 10.0;

	public double NotchUHeight = 20.0;

	public double NotchUStart = 10.0;

	public double NotchCutPersentage = 90.0;

	public LeftRightLocationType NotchLeftRight = LeftRightLocationType.Left;

	public Color NotchColor = Color.Blue;

	public double NotchThickness = 1.0;

	public ProfileNotchCutType NotchCutType = ProfileNotchCutType.BySawAndMilling;

	public CamCuttingWayDirectionType NotchCutDirection = CamCuttingWayDirectionType.TwoWayDirection;

	public ProfileOperationDataNotch()
	{
	}

	public ProfileOperationDataNotch(ProfileOperationDataNotch data)
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

	public override string ToString()
	{
		return "NotchType : " + NotchType;
	}
}
