using System;
using System.Collections.Generic;
using System.Reflection;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleEventPar : buSerilization5
{
	public bool eventRotateByMouse = false;

	public bool eventMoveByMouse = false;

	public bool UndoEnable = false;

	public int UndoLimit = 10;

	public static List<string> Captions = new List<string>();

	public static List<string> CaptionsUnits = new List<string>();

	public marbleEventPar()
	{
	}

	public marbleEventPar(marbleEventPar data)
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

	public static void Copy(marbleEventPar Source, ref marbleEventPar Target)
	{
		Target = new marbleEventPar(Source);
	}

	public static marbleEventPar Copy(marbleEventPar Source)
	{
		marbleEventPar Target = new marbleEventPar();
		Copy(Source, ref Target);
		return Target;
	}

	public static void Copy(List<marbleEventPar> Source, ref List<marbleEventPar> Target)
	{
		Source.Clear();
		for (int i = 0; i <= Source.Count - 1; i++)
		{
			marbleEventPar Target2 = new marbleEventPar();
			Copy(Source[i], ref Target2);
			Target.Add(Target2);
		}
	}

	public override string ToString()
	{
		return "eventRotateByMouse : " + eventRotateByMouse;
	}
}
