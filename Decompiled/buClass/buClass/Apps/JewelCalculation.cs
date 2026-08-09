using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class JewelCalculation : buSerilization
{
	public bool Enable = true;

	public double DepthOverride = 0.0;

	public JewelVar JewelPar = new JewelVar();

	public List<eEntities> CadEntities = new List<eEntities>();

	public List<eEntities> ScreenEntities = new List<eEntities>();

	public camBase CamCalculation = new camBase();

	public ToolBase Tool = new ToolBase();

	public int TotalLineCount = 1;

	public string GCodes = "";

	public JewelCalculation()
	{
	}

	public JewelCalculation(JewelCalculation data)
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
		GCodes = data.GCodes;
		CadEntities.Clear();
		ScreenEntities.Clear();
		eEntities.CopyEntities(data.CadEntities, ref CadEntities);
		eEntities.CopyEntities(data.ScreenEntities, ref ScreenEntities);
		CamCalculation = new camBase(data.CamCalculation);
		JewelPar = new JewelVar(data.JewelPar);
	}
}
