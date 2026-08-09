using System.Reflection;

namespace buEyeBaseVer5.Apps;

public class ProfileOperationHole : ProfileOperation
{
	public double Diameter = 10.0;

	public double DiameterTapping = 11.0;

	public double DepthTapping = 5.0;

	public double TappingPitch = 5.0;

	public double TappingAdditional = 1.0;

	public bool Tapping = false;

	public ProfileOperationHole()
	{
	}

	public ProfileOperationHole(ProfileOperationHole data)
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
		string text = "";
		if (Tapping)
		{
			text = " Tapping Pitch:" + TappingPitch.ToString("f2") + " - Dia: " + DiameterTapping.ToString("f2") + " Depth: " + DepthTapping.ToString("f2");
		}
		return ProfileTempVars.strHole + " X: " + OperationData.Position.X.ToString("f2") + " D: " + Diameter.ToString("f3") + text;
	}
}
