using System;
using System.Collections;
using System.Reflection;

namespace buClass;

[Serializable]
public class postRegionMode : buSerilization
{
	public bool Enable = false;

	public string Code = "";

	public string Auxiliry1 = "";

	public string Auxiliry2 = "";

	public string Explanation = "";

	public ArrayList StartLines = new ArrayList();

	public ArrayList EndLines = new ArrayList();

	public ToolPost RegionToolDef = new ToolPost();

	public SpindlePost RegionSpindleDef = new SpindlePost(usespindle: true, spindleattoolline: false, "M3", "M4", "M5");

	public CharDefinitions RegionTDef = new CharDefinitions("T", 0, 1.0, 0, 1);

	public CharDefinitions RegionSDef = new CharDefinitions("S", 0, 1.0, 0, 1);

	public CharDefinitions RegionXDef = new CharDefinitions("X", 3, 1.0, 0, 1);

	public CharDefinitions RegionYDef = new CharDefinitions("Y", 3, 1.0, 0, 1);

	public CharDefinitions RegionZDef = new CharDefinitions("Z", 3, 1.0, 0, 1);

	public CharDefinitions RegionADef = new CharDefinitions("A", 3, 1.0, 0, 1);

	public CharDefinitions RegionBDef = new CharDefinitions("B", 3, 1.0, 0, 1);

	public CharDefinitions RegionCDef = new CharDefinitions("C", 3, 1.0, 0, 1);

	public postRegionMode()
	{
	}

	public postRegionMode(postRegionMode data)
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
		RegionADef = new CharDefinitions(data.RegionADef);
		RegionBDef = new CharDefinitions(data.RegionBDef);
		RegionCDef = new CharDefinitions(data.RegionCDef);
		RegionSDef = new CharDefinitions(data.RegionSDef);
		RegionSpindleDef = new SpindlePost(data.RegionSpindleDef);
		RegionTDef = new CharDefinitions(data.RegionTDef);
		RegionToolDef = new ToolPost(data.RegionToolDef);
		RegionXDef = new CharDefinitions(data.RegionXDef);
		RegionYDef = new CharDefinitions(data.RegionYDef);
		RegionZDef = new CharDefinitions(data.RegionZDef);
		StartLines = new ArrayList();
		for (int j = 0; j <= data.StartLines.Count - 1; j++)
		{
			StartLines.Add(data.StartLines[j]);
		}
		EndLines = new ArrayList();
		for (int k = 0; k <= data.EndLines.Count - 1; k++)
		{
			EndLines.Add(data.EndLines[k]);
		}
	}
}
