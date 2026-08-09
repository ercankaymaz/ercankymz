using System;
using System.Collections.Generic;

namespace buClass;

[Serializable]
public class QuickDimensionVar : buSerilization
{
	public bool ConnectEntities = true;

	public static List<string> Captions = new List<string>();
}
