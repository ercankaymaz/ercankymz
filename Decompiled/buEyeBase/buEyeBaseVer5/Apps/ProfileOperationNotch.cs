using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps;

public class ProfileOperationNotch : ProfileOperation
{
	public double Width = 10.0;

	public double Height = 10.0;

	public double Start = 10.0;

	public double Angle = 0.0;

	public UpDownLocationType UpDown = UpDownLocationType.Up;

	public ProfileNotchLocationType NotchLocation = ProfileNotchLocationType.Left;

	public ProfileNotchOperationType OPType = ProfileNotchOperationType.Side;

	public ProfileOperationNotch()
	{
	}

	public ProfileOperationNotch(ProfileOperationNotch data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
		if (this != null && CopiedClass != null && GetType() == CopiedClass.GetType())
		{
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
		OperationData = new ProfileOperationData(data.OperationData);
		Depth = data.Depth;
		Tool = new ToolBase5(data.Tool);
		ToolNotch = new ToolBase5(data.ToolNotch);
		camTp.CopyCam(data.CamCalculation, ref CamCalculation);
	}

	public override string ToString()
	{
		return ProfileTempVars.strNotch + " " + OPType.ToString() + " W: " + Width.ToString("f3") + " - H: " + Height.ToString("f3");
	}
}
