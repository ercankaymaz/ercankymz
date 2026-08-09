using System;
using System.Collections.Generic;

namespace buClass;

[Serializable]
public class RectangleDraw : buSerilization
{
	public RectangleDrawType DrawType = RectangleDrawType.Corner;

	public static List<string> Captions = new List<string>();
}
