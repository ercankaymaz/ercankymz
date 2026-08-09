using System;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class DoorRuntimeSettings : buSerilization5
{
	public bool SelectMode = false;

	public bool FromFileKeepRatio = true;

	public string pathFromFile = "C:\\";

	public string pathJob = "C:\\";

	public double MaterialHeight = 800.0;

	public double MaterialWidth = 2000.0;

	public double MaterialDepth = 20.0;

	public double Case1Width = 2000.0;

	public double Case1Height = 400.0;

	public double Case1Depth = 20.0;

	public double Case2Width = 2000.0;

	public double Case2Height = 400.0;

	public double Case2Depth = 20.0;

	public double CaseSpace = 50.0;

	public double MaterialFrontAngle = 0.0;

	public double MaterialBackAngle = 0.0;

	public int SecondToolNo = 1;

	public bool SecondToolEnable = false;

	public MaterialPurpose MaterailPurpuse = MaterialPurpose.Door;

	public ShapeRuntimeData ShapeDataParameters = new ShapeRuntimeData();

	public DoorRuntimeSettings()
	{
	}

	public DoorRuntimeSettings(DoorRuntimeSettings data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null))
		{
			return;
		}
		if (GetType() == CopiedClass.GetType())
		{
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
		ShapeDataParameters = new ShapeRuntimeData(data.ShapeDataParameters);
	}
}
