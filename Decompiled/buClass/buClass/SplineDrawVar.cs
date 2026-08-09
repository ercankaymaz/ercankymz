using System;
using System.Collections.Generic;

namespace buClass;

[Serializable]
public class SplineDrawVar : buSerilization
{
	public entitySplineType Type = entitySplineType.SplineCubic;

	public bool Closed = false;

	public static List<string> Captions = new List<string>();
}
