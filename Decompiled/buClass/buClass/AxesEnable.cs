namespace buClass;

public class AxesEnable
{
	public bool X = true;

	public bool Y = true;

	public bool Z = true;

	public bool A = false;

	public bool B = false;

	public bool C = false;

	public AxesEnable()
	{
	}

	public AxesEnable(bool x, bool y, bool z)
	{
		X = x;
		Y = y;
		Z = z;
		A = false;
		B = false;
		C = false;
	}

	public AxesEnable(bool x, bool y, bool z, bool a, bool b, bool c)
	{
		X = x;
		Y = y;
		Z = z;
		A = a;
		B = b;
		C = c;
	}

	public AxesEnable(AxesEnable axis)
	{
		X = axis.X;
		Y = axis.Y;
		Z = axis.Z;
		A = axis.A;
		B = axis.B;
		C = axis.C;
	}

	public override string ToString()
	{
		return "X: " + X + " , Y: " + Y + " , Z: " + Z + " , A: " + A + " , B: " + B + " , C: " + C;
	}
}
