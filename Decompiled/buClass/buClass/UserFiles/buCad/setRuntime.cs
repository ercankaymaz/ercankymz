using System;

namespace buClass.UserFiles.buCad;

[Serializable]
public class setRuntime : buSerilization
{
	public string FormSkin = "Office 2007 Black";

	public int Language = 0;

	public int MetricUnit = 0;

	public int MachineID = 0;

	public string ReleaseVer = "0";

	public string CustomerName = "";

	public override string ToString()
	{
		return "Lang:" + Language + " - MAchineID: " + MachineID;
	}
}
