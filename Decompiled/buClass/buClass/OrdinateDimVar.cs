using System;
using System.Collections.Generic;

namespace buClass;

[Serializable]
public class OrdinateDimVar : buSerilization
{
	public bool XCoordinate = true;

	public bool YCoordinate = true;

	public bool ZCoordinate = true;

	public static List<string> Captions = new List<string>();
}
