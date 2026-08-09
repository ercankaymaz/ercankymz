using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5;

[Serializable]
public class ShapeUpdateArg : buSerilization5
{
	public bool UpdateRuntime = false;

	public bool Finished = false;

	public bool isError = false;

	public bool ToolChangeForced = false;

	public bool ToolFound = false;

	public bool OnlyDrawing = false;

	public bool OpenFile = false;

	public bool NotOriginalTool = false;

	public bool DontUpdateTree = false;

	public string ToolName = "";

	public string ToolAuxName = "";

	public int ToolIndex = -1;

	public string Command = "";

	public ShapeRuntimeData Parameters = new ShapeRuntimeData();

	public ToolBase5 Tool = null;

	public ShapeDataValueType ValueType = ShapeDataValueType.None;

	public List<string> CommandList = new List<string>();

	public ShapeUpdateArg()
	{
	}

	public ShapeUpdateArg(ShapeRuntimeData Pars)
	{
		Parameters = new ShapeRuntimeData(Pars);
	}

	public ShapeUpdateArg(ShapeUpdateArg data)
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

	public override string ToString()
	{
		return "Finished :" + Finished;
	}
}
