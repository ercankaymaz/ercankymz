using System;
using System.Collections.Generic;

namespace ModuleWorks;

[Serializable]
public class UVKnotVector
{
	public List<double> UKnots { get; private set; }

	public List<double> VKnots { get; private set; }

	public UVKnotVector()
	{
		UKnots = new List<double>();
		VKnots = new List<double>();
	}

	public UVKnotVector(IEnumerable<double> uKnots, IEnumerable<double> vKnots)
	{
		UKnots = new List<double>(uKnots);
		VKnots = new List<double>(vKnots);
	}

	public UVKnotVector(int uKnotSize, int vKnotSize)
	{
		UKnots = new List<double>(uKnotSize);
		VKnots = new List<double>(vKnotSize);
	}
}
