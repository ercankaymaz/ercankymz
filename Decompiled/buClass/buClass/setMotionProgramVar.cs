using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class setMotionProgramVar : buSerilization
{
	public bool TouchPad = false;

	public bool ThreatRead = true;

	public bool ThreatWrite = true;

	public bool CameraEnable = false;

	public int TimerReadTick = 500;

	public int TimerGeneralTick = 100;

	public bool WindowsMaximize = false;

	public double Resolution = 0.01;

	public bool DeleteFinishedJobFile = false;

	public bool DeleteFinishedJobFileWithProgramClosed = false;

	public bool ShowPasswordPageIfNoAccessLevel = true;

	public bool ShowGCode = true;

	public double FeedOverrideMax = 100.0;

	public double FeedOverrideMin = 0.0;

	public double FeedCOverrideMax = 100.0;

	public double FeedCOverrideMin = 0.0;

	public bool ClearOperationTimeWhenStop = false;

	public LoadFileFormType LoadFileFromWindowsDialogbox = LoadFileFormType.ProgramWindowWithPreview;

	public CoordinateShowMode MachineCoordinateShowMode = CoordinateShowMode.Machine;

	public CoordinateShowMode PartCoordinateShowMode = CoordinateShowMode.Part;

	public setMotionProgramVar()
	{
	}

	public setMotionProgramVar(setMotionProgramVar data)
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
				string name = fields[i].Name;
				object value = fields[i].GetValue(CopiedClass);
				fields[i].SetValue(this, value);
			}
		}
	}
}
