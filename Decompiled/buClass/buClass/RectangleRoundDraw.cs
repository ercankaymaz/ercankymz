using System;
using System.Collections.Generic;

namespace buClass;

[Serializable]
public class RectangleRoundDraw : buSerilization
{
	public double Radius = 10.0;

	public RectangleDrawType DrawType = RectangleDrawType.Corner;

	public static List<string> Captions = new List<string>();
}
