using System;
using System.Collections.Generic;

namespace buClass;

[Serializable]
public class PolygonDraw : buSerilization
{
	public PolygonType Type = PolygonType.Center;

	public int Side = 6;

	public bool Reverse = false;

	public static List<string> Captions = new List<string>();
}
