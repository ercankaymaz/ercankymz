namespace DSTV.Net.Data;

public record DstvSlot : DstvHole
{
	public double SlotAngle { get; }

	public double SlotLength { get; }

	public double SlotWidth { get; }

	public DstvSlot(string flCode, double xCoord, double yCoord, double diam, double depth, double slotLen, double slotWidth, double slotAng)
		: base(flCode, xCoord, yCoord, diam, depth)
	{
		SlotLength = slotLen;
		SlotWidth = slotWidth;
		SlotAngle = slotAng;
	}

	public override string ToString()
	{
		return $"{base.ToString()}, SlotLength : {SlotLength}, SlothWidth : {SlotWidth}, SlotAngle : {SlotAngle}";
	}

	public override string ToSvg()
	{
		return $"<rect x=\"{base.XCoord}\" y=\"{base.YCoord}\" width=\"{SlotLength + base.Diameter}\" height=\"{base.Diameter}\" fill=\"white\" rx=\"{base.Diameter / 2.0}\" />";
	}
}
