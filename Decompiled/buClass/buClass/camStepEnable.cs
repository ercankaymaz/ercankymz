using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class camStepEnable : buSerilization
{
	public bool StartValue = true;

	public bool EndValue = true;

	public bool Distance = false;

	public bool Count = true;

	public bool Step = false;

	public bool Type = true;

	public bool MoveUp = false;

	public bool MoveUpType = false;

	public bool Sequence = false;

	public static List<string> Captions = new List<string>();

	public camStepEnable()
	{
	}

	public camStepEnable(bool startval, bool endvalue, bool distance, bool count, bool step, bool type)
	{
		StartValue = startval;
		EndValue = endvalue;
		Distance = distance;
		Count = count;
		Step = step;
		Type = type;
	}

	public camStepEnable(bool startval, bool endvalue, bool distance, bool count, bool step, bool type, bool moveup, bool moveuptype, bool sequence)
	{
		StartValue = startval;
		EndValue = endvalue;
		Distance = distance;
		Count = count;
		Step = step;
		Type = type;
		MoveUp = moveup;
		MoveUpType = moveuptype;
		Sequence = sequence;
	}

	public camStepEnable(camStepEnable Data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(Data, ref CopiedClass);
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
		return "StartValue: " + StartValue + " , EndValue: " + EndValue + " , Distance: " + Distance + " , Count: " + Count + " , Step: " + Step + " , Type: " + Type;
	}
}
