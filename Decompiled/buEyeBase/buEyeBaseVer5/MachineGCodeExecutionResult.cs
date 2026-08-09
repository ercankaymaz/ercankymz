using System;
using System.Collections.Generic;
using System.Reflection;

namespace buEyeBaseVer5;

[Serializable]
public class MachineGCodeExecutionResult : buSerilization5
{
	public double TotalTimeAsSec = 0.0;

	public double OperationTimeAsSec = 0.0;

	public double QuickMoveTimeAsSec = 0.0;

	public double TotalMCodeTimeAsSec = 0.0;

	public double TotalLengthAsMeter = 0.0;

	public double OperationLengthAsMeter = 0.0;

	public double QuickMoveLengthAsMeter = 0.0;

	public int NumberOfToolChange = 0;

	public List<string> NoDefinedMCodes = new List<string>();

	public MachineGCodeExecutionResult()
	{
	}

	public MachineGCodeExecutionResult(MachineGCodeExecutionResult data)
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
		return "TotalTimeAsSec : " + TotalTimeAsSec.ToString("f2") + " - TotalLengthAsMeter: " + TotalLengthAsMeter.ToString("f2");
	}
}
