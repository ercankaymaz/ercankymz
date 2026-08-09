using System.Reflection;

namespace buEyeBaseVer5.Apps;

public class ProfileOperationPolygon : ProfileOperation
{
	public int Side = 6;

	public double Diameter = 10.0;

	public double Angle = 0.0;

	public ProfileOperationPolygon()
	{
	}

	public ProfileOperationPolygon(ProfileOperationPolygon data)
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
		Side = data.Side;
		Diameter = data.Diameter;
		Angle = data.Angle;
		Tool = new ToolBase5(data.Tool);
		camTp.CopyCam(data.CamCalculation, ref CamCalculation);
	}

	public override string ToString()
	{
		return ProfileTempVars.strPoylgon + " X: " + OperationData.Position.X.ToString("f2") + " S: " + Side.ToString("f3") + " - D: " + Diameter.ToString("f3");
	}
}
