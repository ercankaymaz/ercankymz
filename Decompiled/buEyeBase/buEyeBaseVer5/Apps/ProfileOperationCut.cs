using System.Reflection;

namespace buEyeBaseVer5.Apps;

public class ProfileOperationCut : ProfileOperation
{
	public double CutWidth = 10.0;

	public double CutHeight = 40.0;

	public double CutDepth = 50.0;

	public double Angle = 0.0;

	public ProfileOperationCut()
	{
	}

	public ProfileOperationCut(ProfileOperationCut data)
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
		return ProfileTempVars.strCut + " X: " + OperationData.Position.X.ToString("f2") + " W: " + CutWidth.ToString("f3") + " - H: " + CutHeight.ToString("f3");
	}
}
