using System;
using System.Collections;
using System.Collections.Generic;

namespace buClass;

[Serializable]
public class MacroBase : buSerilization
{
	public ArrayList Args = new ArrayList();

	public string Command = "";

	public static List<string> Captions = new List<string>();

	public MacroBase()
	{
	}

	public MacroBase(MacroBase macro)
	{
		Command = macro.Command;
		Args.Clear();
		for (int i = 0; i <= macro.Args.Count - 1; i++)
		{
			Args.Add(macro.Args[i]);
		}
	}

	public override string ToString()
	{
		string text = "";
		if (Args.Count > 0)
		{
			text = Args[0].ToString();
			for (int i = 1; i <= Args.Count - 1; i++)
			{
				text = text + " - " + Args[i].ToString();
			}
		}
		return Command + " , " + text;
	}
}
