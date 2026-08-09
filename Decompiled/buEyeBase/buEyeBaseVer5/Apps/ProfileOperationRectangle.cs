using System.Reflection;

namespace buEyeBaseVer5.Apps;

public class ProfileOperationRectangle : ProfileOperation
{
	public double Width = 10.0;

	public double Height = 10.0;

	public double Radius = 0.0;

	public double Chamfer = 0.0;

	public double Angle = 0.0;

	public ProfileOperationRectangle()
	{
	}

	public ProfileOperationRectangle(ProfileOperationRectangle data)
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
		Depth = data.Depth;
		OperationData = new ProfileOperationData(data.OperationData);
		Tool = new ToolBase5(data.Tool);
		camTp.CopyCam(data.CamCalculation, ref CamCalculation);
	}
}
