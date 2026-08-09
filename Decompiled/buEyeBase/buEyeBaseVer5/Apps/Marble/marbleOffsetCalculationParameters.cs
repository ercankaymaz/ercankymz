using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps.Marble;

public class marbleOffsetCalculationParameters
{
	public bool isClosed = false;

	public bool isReverseAngleA = false;

	public bool isToolSaw = true;

	public bool isInside = false;

	public double ToolSocket = 3.2;

	public double ToolThickness = 3.2;

	public double ToolDiameter = 5.0;

	public double Offset = 0.0;

	public double OrientationA = 0.0;

	public double MaterialThickness = 10.0;

	public double TargetZ = 0.0;

	public CamClosedContourType ClosedOffsetType = CamClosedContourType.Outter;

	public CamOpenContourType OpenOffsetType = CamOpenContourType.Center;

	public marbleOffsetCalculationParameters()
	{
	}

	public marbleOffsetCalculationParameters(marbleOffsetCalculationParameters data)
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
}
