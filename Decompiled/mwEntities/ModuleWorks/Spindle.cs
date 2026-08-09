using System;

namespace ModuleWorks;

[Serializable]
public struct Spindle
{
	public Vectord Orientation { get; set; }

	public Vectord Direction { get; set; }

	public Spindle(Vectord orientation, Vectord direction)
	{
		this = default(Spindle);
		Orientation = new Vectord(orientation);
		Direction = ((direction == null) ? null : new Vectord(direction));
	}
}
