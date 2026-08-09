namespace buClass;

public class AxesEnableXYZ
{
	public bool X = true;

	public bool Y = true;

	public bool Z = true;

	public AxesEnableXYZ()
	{
	}

	public AxesEnableXYZ(bool x, bool y, bool z)
	{
		X = x;
		Y = y;
		Z = z;
	}

	public AxesEnableXYZ(AxesEnable axis)
	{
		X = axis.X;
		Y = axis.Y;
		Z = axis.Z;
	}

	public override string ToString()
	{
		return "X: " + X + " , Y: " + Y + " , Z: " + Z;
	}
}
