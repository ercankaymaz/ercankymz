using System.Collections.Generic;

namespace buEyeBaseVer5.Apps;

public class DrillSplitedItems
{
	public List<List<DrillCalcItem>> lstTop = new List<List<DrillCalcItem>>();

	public List<List<DrillCalcItem>> lstBottom = new List<List<DrillCalcItem>>();

	public List<List<DrillCalcItem>> lstLeftRight = new List<List<DrillCalcItem>>();

	public List<List<DrillCalcItem>> lstLeft = new List<List<DrillCalcItem>>();

	public List<List<DrillCalcItem>> lstRight = new List<List<DrillCalcItem>>();

	public List<List<DrillCalcItem>> lstFront = new List<List<DrillCalcItem>>();

	public List<List<DrillCalcItem>> lstBack = new List<List<DrillCalcItem>>();

	public override string ToString()
	{
		return "Top: " + lstTop.Count + " , Bottom: " + lstBottom.Count + " , Left-Right: " + lstLeftRight.Count + " , Front: " + lstFront.Count + " , Back: " + lstBack.Count;
	}
}
