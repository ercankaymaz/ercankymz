using System;
using System.Collections.Generic;

namespace buClass;

[Serializable]
public class SortingResult : buSerilization
{
	public Pnt3D FirstPoint = new Pnt3D();

	public Pnt3D LastPoint = new Pnt3D();

	public SortingResultType ResultType = SortingResultType.None;

	public List<int> SelectedEntitiesIndex = new List<int>();

	public List<eEntities> LastCalculatedEntities = new List<eEntities>();

	public List<int> LastSelectedEntitiesIndex = new List<int>();
}
