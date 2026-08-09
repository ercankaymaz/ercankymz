using System.Reflection;
using buClass;

namespace buEyeBaseVer5.buEntities;

public class buShapeNotch : buShape
{
	public double NotchWidth = 10.0;

	public double NotchHeight = 10.0;

	public double NotchStartHeight = 0.0;

	public double NotchAngle = 0.0;

	public UpDownLocationType NotchUpDown = UpDownLocationType.Up;

	public FrontBackType NotchFrontBack = FrontBackType.Front;

	public ProfileNotchLocationType NotchLocation = ProfileNotchLocationType.Left;

	public ProfileNotchOperationType NotchOPType = ProfileNotchOperationType.Side;

	public buShapeNotch()
	{
		ShapeGroup = ShapeGroup.Notch;
	}

	public buShapeNotch(double width, double height, double startheight, double depth, UpDownLocationType updown, ProfileNotchLocationType location, ProfileNotchOperationType NotchOpType, FrontBackType frontback)
	{
		NotchWidth = width;
		NotchHeight = height;
		NotchStartHeight = startheight;
		NotchUpDown = updown;
		NotchLocation = location;
		Depth = depth;
		NotchOPType = NotchOpType;
		NotchFrontBack = frontback;
	}

	public buShapeNotch(buShape data)
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
		string text = NotchOPType.ToString() + " - Width: " + NotchWidth.ToString("f2") + " , Height: " + NotchHeight.ToString("f2") + " , Depth: " + Depth.ToString("f2");
		text = text + " , Location: " + NotchLocation;
		return text + " , UpDown: " + NotchUpDown;
	}
}
