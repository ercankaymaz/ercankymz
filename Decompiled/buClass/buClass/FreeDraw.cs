using System;
using System.Collections.Generic;

namespace buClass;

[Serializable]
public class FreeDraw : buSerilization
{
	public FreeDrawMouseModeType MouseMode = FreeDrawMouseModeType.DownDown;

	public bool ConverToSpline = true;

	public double Length = 1.0;

	public entitySplineType SplineType = entitySplineType.SplineCubic;

	public static List<string> Captions = new List<string>();
}
