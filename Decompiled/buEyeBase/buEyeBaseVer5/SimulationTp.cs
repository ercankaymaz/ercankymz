using System;
using System.Collections.Generic;
using buClass;

namespace buEyeBaseVer5;

[Serializable]
public class SimulationTp : buSerilization5
{
	public List<Pnt6DSimMove> SimMove = new List<Pnt6DSimMove>();

	public string Aux1 = "";

	public string Aux2 = "";

	public SimulationMoveCommand MoveCommand = SimulationMoveCommand.None;

	public object Obj1 = null;

	public SimulationTp()
	{
	}

	public SimulationTp(SimulationTp sim)
	{
		SimMove.Clear();
		for (int i = 0; i <= sim.SimMove.Count - 1; i++)
		{
			SimMove.Add(new Pnt6DSimMove(sim.SimMove[i]));
		}
	}

	public override string ToString()
	{
		return "Count: " + SimMove.Count;
	}
}
