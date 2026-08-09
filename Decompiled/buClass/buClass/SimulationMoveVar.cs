using System;
using System.Collections.Generic;

namespace buClass;

[Serializable]
public class SimulationMoveVar : buSerilization
{
	public AxesEnable Axes = new AxesEnable();

	public Pnt3D RotationPoint = new Pnt3D();

	public static List<string> Captions = new List<string>();

	public SimulationMoveVar()
	{
	}

	public SimulationMoveVar(SimulationMoveVar data)
	{
		Axes = new AxesEnable(data.Axes);
		RotationPoint = new Pnt3D(data.RotationPoint);
	}
}
