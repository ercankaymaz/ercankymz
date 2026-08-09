using System.Reflection;

namespace buEyeBaseVer5.Apps;

public class ProfileOperationCircle : ProfileOperation
{
	public double Diameter = 10.0;

	public ProfileOperationCircle()
	{
	}

	public ProfileOperationCircle(ProfileOperationCircle data)
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
		return ProfileTempVars.strCircle + " X: " + OperationData.Position.X.ToString("f2") + " D: " + Diameter.ToString("f3");
	}
}
