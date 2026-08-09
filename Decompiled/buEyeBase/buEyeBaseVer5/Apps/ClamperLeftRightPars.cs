using System.Reflection;

namespace buEyeBaseVer5.Apps;

public class ClamperLeftRightPars : buSerilization5
{
	public double LeftMinDis = 0.0;

	public double LeftMaxDis = 0.0;

	public double LeftMinClamperPos = 0.0;

	public double LeftMaxClamperPos = 0.0;

	public double RightMinDis = 0.0;

	public double RightMaxDis = 0.0;

	public double RightMinClamperPos = 0.0;

	public double RightMaxClamperPos = 0.0;

	public bool OperationAboveClamper = false;

	public ClamperLeftRightPars()
	{
	}

	public ClamperLeftRightPars(ClamperLeftRightPars data)
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
		return "LeftClpPos(Min - Max): " + LeftMinClamperPos + " , " + LeftMaxClamperPos + " - RightClpPos(Min - Max): " + RightMinClamperPos + " , " + RightMaxClamperPos + " - LeftMinDis: " + LeftMinDis + " - RightMinDis: " + RightMinDis + " - LeftMaxDis: " + LeftMaxDis + " - RightMaxDis: " + RightMaxDis;
	}
}
