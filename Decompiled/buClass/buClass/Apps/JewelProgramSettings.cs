using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class JewelProgramSettings : buSerilization
{
	public static List<string> Captions = new List<string>();

	public JewelProgramSettings()
	{
	}

	public JewelProgramSettings(JewelProgramSettings data)
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

	public static void Copy(JewelProgramSettings Source, ref JewelProgramSettings Target)
	{
		Target = new JewelProgramSettings(Source);
	}

	public override string ToString()
	{
		return "";
	}
}
[Serializable]
public class jewelProgramSettings : buSerilization
{
	public jewelWizardType CalculationMode = jewelWizardType.MultiMode;

	public jewelProgramMode ProgramMode = jewelProgramMode.CadCamOnly;

	public bool MotionColorFromLayer = true;

	public Color MotionDrawColor = Color.Black;

	public Color MotionDrawBackColorActive = Color.Green;

	public Color MotionDrawBackColorPassive = Color.WhiteSmoke;

	public Color RealTimeSimulationColor = Color.Red;

	public double RealTimeSimulationThickness = 3.0;

	public bool RealTimeSimulation = true;

	public bool DrawFromReverseKinematic = false;

	public bool SiemensMode = false;

	public jewelProgramSettings()
	{
	}

	public jewelProgramSettings(jewelProgramSettings data)
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
		return "Mode: " + CalculationMode;
	}
}
