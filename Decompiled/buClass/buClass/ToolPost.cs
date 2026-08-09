using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class ToolPost : buSerilization
{
	public CodeUsing ToolData = new CodeUsing();

	public string ToolChangeCode = "M6";

	public string ToolSectorSeperateChar = "";

	public string ToolLengthCompensationChar = "G43";

	public string ToolLengthCompensationHeightChar = "H";

	public string ToolLengthCompensationZChar = "";

	public bool UseToolSector = false;

	public bool ToolSectorDataNextLine = false;

	public bool MoveSafeBeforeToolChange = false;

	public bool UseToolWithComment = false;

	public bool UseToolLengthCompensation = false;

	public bool UseToolLengthCompensationHeight = false;

	public bool UseToolInfo = false;

	public bool UseToolAuxCodes = false;

	public bool UseToolDChar = false;

	public bool ToolChangeMCommandFirst = false;

	public int ToolWriteSequence = 0;

	public string ToolAdditionalString = "";

	public ToolPost()
	{
	}

	public ToolPost(ToolPost data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
		if (this != null && CopiedClass != null && GetType() == CopiedClass.GetType())
		{
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
		ToolData = new CodeUsing(data.ToolData);
	}

	public override string ToString()
	{
		return "Use: " + ToolData.Enable;
	}
}
