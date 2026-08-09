using System;
using System.Collections.Generic;
using System.Drawing;

namespace buClass;

[Serializable]
public class SortingFilter : buSerilization
{
	public List<eEntities> NotSelectEntities = new List<eEntities>();

	public List<eEntities> SelectableEntities = new List<eEntities>();

	public List<int> NotSelectIndex = new List<int>();

	public List<int> SelectableIndex = new List<int>();

	public List<Color> NotSelectColor = new List<Color>();

	public List<Color> SelectableColor = new List<Color>();

	public MostClosestPointType MostClosestType = MostClosestPointType.OnlyNotCamSelectedEntities;

	public bool UsePointEntities = false;
}
