using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class CodesysSystemSets : buSerilization
{
	public FeedSettings Feed = new FeedSettings();

	public SpindleSettings Spindle = new SpindleSettings();

	public SpindleSettings SpindleSaw = new SpindleSettings();

	public TimeSettings Times = new TimeSettings();

	public ToolSettings Tool = new ToolSettings();

	public OffsetSettings Offset = new OffsetSettings();

	public int EthercatSyncTime = 4000;

	public bool EnableAxesAfterInit = true;

	public bool FairLoopMode = false;

	public ParameterTransferType ParameterTransfer = ParameterTransferType.FromVariable;

	public static List<string> Captions = new List<string>();

	public CodesysSystemSets()
	{
	}

	public CodesysSystemSets(CodesysSystemSets data)
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

	public override string ToString()
	{
		return "EnableAxesAfterInit: " + EnableAxesAfterInit + " , EthercatSyncTime : " + EthercatSyncTime;
	}
}
