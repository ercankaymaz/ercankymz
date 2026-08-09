using System.Collections.Generic;

namespace buEyeBaseVer5.Apps.Robotic;

public class RobotItem : buSerilization5
{
	public List<RobotToolPath> ToolPaths = new List<RobotToolPath>();

	public List<string> Codes = new List<string>();

	public string Code = "";

	public ToolBase5 SelectedTool = new ToolBase5();
}
