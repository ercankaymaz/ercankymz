using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps;

public class ProfileOperationNotchOld : ProfileOperation
{
	public double Width = 10.0;

	public double Height = 10.0;

	public double Start = 10.0;

	public double ToolCutPersentage = 90.0;

	public ProfileNotchType Type = ProfileNotchType.LType;

	public UpDownLocationType UpDown = UpDownLocationType.Up;

	public LeftRightLocationType LeftRight = LeftRightLocationType.Left;

	public ProfileOperationNotchOld()
	{
	}

	public ProfileOperationNotchOld(ProfileOperationNotchOld data)
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
		camTp.CopyCam(data.CamCalculation, ref CamCalculation);
	}

	public override string ToString()
	{
		return ProfileTempVars.strNotch + " W: " + Width.ToString("f3") + " - H: " + Height.ToString("f3");
	}
}
