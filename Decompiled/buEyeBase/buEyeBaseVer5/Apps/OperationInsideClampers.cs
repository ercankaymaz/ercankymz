using System.Reflection;

namespace buEyeBaseVer5.Apps;

public class OperationInsideClampers : buSerilization5
{
	public double LeftDistance = 0.0;

	public double RightDistance = 0.0;

	public int IndexOpertion = 0;

	public bool UseTopPlane = false;

	public double ClamperWidth = 0.0;

	public OperationInsideClampers()
	{
	}

	public OperationInsideClampers(OperationInsideClampers data)
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

	public OperationInsideClampers(double leftDis, double rightDis)
	{
		RightDistance = rightDis;
		LeftDistance = leftDis;
	}

	public OperationInsideClampers(double leftDis, double rightDis, double clamperwidth)
	{
		RightDistance = rightDis;
		LeftDistance = leftDis;
		ClamperWidth = clamperwidth;
	}

	public override string ToString()
	{
		return "RightDistance: " + RightDistance + " - LeftDistance: " + LeftDistance;
	}
}
