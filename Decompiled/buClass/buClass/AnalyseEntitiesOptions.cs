using System;
using System.Collections.Generic;
using System.Drawing;

namespace buClass;

[Serializable]
public class AnalyseEntitiesOptions : buSerilization
{
	public Color FilterColor = Color.Transparent;

	public bool UseToolPurpose = false;

	public string AuxString = null;

	public bool DontAddCamSelected = false;

	public List<int> DontAddEntityIndexList = new List<int>();

	public EntityDevideSettings Devide = new EntityDevideSettings();

	public AnalyseEntitiesOptions()
	{
	}

	public AnalyseEntitiesOptions(Color filterColor, EntityDevideSettings devide, bool dontAddCamSelected, List<int> dontAddEntityIndexList, string auxString, bool useToolPurpose)
	{
		AuxString = auxString;
		FilterColor = filterColor;
		Devide = new EntityDevideSettings(devide);
		DontAddCamSelected = dontAddCamSelected;
		UseToolPurpose = useToolPurpose;
		DontAddEntityIndexList.Clear();
		for (int i = 0; i <= dontAddEntityIndexList.Count - 1; i++)
		{
			DontAddEntityIndexList.Add(dontAddEntityIndexList[i]);
		}
	}
}
