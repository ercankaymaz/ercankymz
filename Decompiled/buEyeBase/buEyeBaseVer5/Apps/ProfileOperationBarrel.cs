using System.Reflection;

namespace buEyeBaseVer5.Apps;

public class ProfileOperationBarrel : ProfileOperation
{
	public double Diameter = 20.0;

	public double Length = 40.0;

	public double Width = 10.0;

	public double Angle = 0.0;

	public ProfileOperationBarrel()
	{
	}

	public ProfileOperationBarrel(ProfileOperationBarrel data)
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
		return ProfileTempVars.strKeyHole + " X: " + OperationData.Position.X.ToString("f2") + " W: " + Width.ToString("f3") + " - D: " + Diameter.ToString("f3");
	}
}
