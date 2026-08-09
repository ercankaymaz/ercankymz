using System;
using System.Drawing;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class DrillSettings : buSerilization5
{
	public Color colorPanel = Color.Brown;

	public int transparencyPanel = 150;

	public int transparencyOperation = 200;

	public int simulationInterval = 10;

	public DrillMachineView MachineView = DrillMachineView.CrossLeft;

	public double ClamperSimX1ClampZDistance = -20.0;

	public double ClamperSimX2ClampZDistance = -20.0;

	public double SimTopMillingOffset = 0.0;

	public double SimBottomMillinOffset = 0.0;

	public bool AutoOpenLastPanel = true;

	public bool AutoOpenLastPanelAndDrill = false;

	public bool DeleteDrawingAfterChangeToJob = true;

	public double CornerArrowLength = 50.0;

	public double CornerArrowDiameter = 10.0;

	public double CornerArrowConeDiameter = 16.0;

	public double CornerArrowConeLength = 15.0;

	public int CodeLineDecimal = 1;

	public Color CornerArrowXColor = Color.Red;

	public Color CornerArrowYColor = Color.Green;

	public Color CornerArrowZColor = Color.Blue;

	public Color CornerArrowBallColor = Color.Gold;

	public DrillSettings()
	{
	}

	public DrillSettings(DrillSettings data)
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
}
