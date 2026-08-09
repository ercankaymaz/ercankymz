namespace buClass;

public class AxesEnableWithUVW
{
	public bool X = true;

	public bool Y = true;

	public bool Z = true;

	public bool A = false;

	public bool B = false;

	public bool C = false;

	public bool U = false;

	public bool V = false;

	public bool W = false;

	public AxesEnableWithUVW()
	{
	}

	public AxesEnableWithUVW(bool x, bool y, bool z)
	{
		X = x;
		Y = y;
		Z = z;
		A = false;
		B = false;
		C = false;
		U = false;
		V = false;
		W = false;
	}

	public AxesEnableWithUVW(bool x, bool y, bool z, bool a, bool b, bool c)
	{
		X = x;
		Y = y;
		Z = z;
		A = a;
		B = b;
		C = c;
		U = false;
		V = false;
		W = false;
	}

	public AxesEnableWithUVW(bool x, bool y, bool z, bool a, bool b, bool c, bool u, bool v, bool w)
	{
		X = x;
		Y = y;
		Z = z;
		A = a;
		B = b;
		C = c;
		U = u;
		V = v;
		W = w;
	}

	public AxesEnableWithUVW(AxesEnableWithUVW axis)
	{
		X = axis.X;
		Y = axis.Y;
		Z = axis.Z;
		A = axis.A;
		B = axis.B;
		C = axis.C;
		U = axis.U;
		V = axis.V;
		W = axis.W;
	}

	public override string ToString()
	{
		return "X: " + X + " , Y: " + Y + " , Z: " + Z + " , A: " + A + " , B: " + B + " , C: " + C + " , U: " + U + " , V: " + V + " , W: " + W;
	}
}
