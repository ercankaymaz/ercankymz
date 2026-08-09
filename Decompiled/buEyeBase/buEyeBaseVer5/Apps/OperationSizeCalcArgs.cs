using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps;

public class OperationSizeCalcArgs : buSerilization5
{
	public double PatternWidth = 0.0;

	public double PatternHeight = 0.0;

	public double ZOffset = 0.0;

	public OperationSizeCalcArgs()
	{
	}

	public OperationSizeCalcArgs(double patternWidth, double patternHeight, double zOffset)
	{
		PatternWidth = patternWidth;
		PatternHeight = patternHeight;
		ZOffset = zOffset;
	}

	public OperationSizeCalcArgs(OperationSizeCalcArgs data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
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
