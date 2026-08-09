using System;
using System.Collections.Generic;

namespace buClass;

[Serializable]
public class SortingAskMe : buSerilization
{
	public bool Return = false;

	public bool ReturnNextGroup = false;

	public int SelectedIndex = 0;

	public Pnt3D RefPoint = new Pnt3D();

	public List<int> EntitiesIndex = new List<int>();

	public List<eEntities> Entities = new List<eEntities>();

	public List<eEntities> SortedEntities = new List<eEntities>();

	public List<eEntities> UpperEntities = new List<eEntities>();
}
