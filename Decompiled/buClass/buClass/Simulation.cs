using System;
using System.Collections.Generic;

namespace buClass;

[Serializable]
public class Simulation : buSerilization
{
	public List<Pnt6DSim> SimDetailedPoints = new List<Pnt6DSim>();

	public List<Pnt6D> SimPoints = new List<Pnt6D>();

	public Simulation()
	{
	}

	public Simulation(Simulation sim)
	{
		SimDetailedPoints.Clear();
		SimPoints.Clear();
		for (int i = 0; i <= sim.SimDetailedPoints.Count - 1; i++)
		{
			SimDetailedPoints.Add(new Pnt6DSim(sim.SimDetailedPoints[i]));
		}
		for (int j = 0; j <= sim.SimPoints.Count - 1; j++)
		{
			SimPoints.Add(new Pnt6D(sim.SimPoints[j]));
		}
	}

	public override string ToString()
	{
		return "Count: " + SimDetailedPoints.Count;
	}
}
