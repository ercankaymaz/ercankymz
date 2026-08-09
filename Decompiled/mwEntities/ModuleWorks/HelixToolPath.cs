using System;

namespace ModuleWorks;

[Serializable]
public class HelixToolPath
{
	public Vectord StartPoint { get; set; }

	public Vectord StartOrientation { get; set; }

	public Vectord CenterPoint { get; set; }

	public Vectord CenterOrientation { get; set; }

	public Vectord EndPoint { get; set; }

	public Vectord EndOrientation { get; set; }

	public bool IsClockwise { get; set; }
}
