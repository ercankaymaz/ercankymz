namespace buClass;

public class AxesEnableWithUVWAndIJK
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

	public bool I = false;

	public bool J = false;

	public bool K = false;

	public AxesEnableWithUVWAndIJK()
	{
	}

	public AxesEnableWithUVWAndIJK(bool x, bool y, bool z)
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
		I = false;
		J = false;
		J = false;
	}

	public AxesEnableWithUVWAndIJK(bool x, bool y, bool z, bool a, bool b, bool c)
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
		I = false;
		J = false;
		J = false;
	}

	public AxesEnableWithUVWAndIJK(bool x, bool y, bool z, bool a, bool b, bool c, bool u, bool v, bool w)
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
		I = false;
		J = false;
		J = false;
	}

	public AxesEnableWithUVWAndIJK(bool x, bool y, bool z, bool a, bool b, bool c, bool u, bool v, bool w, bool i, bool j, bool k)
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
		I = i;
		J = j;
		J = k;
	}

	public AxesEnableWithUVWAndIJK(AxesEnableWithUVWAndIJK axis)
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
		I = axis.I;
		J = axis.J;
		J = axis.K;
	}

	public override string ToString()
	{
		return "X: " + X + " , Y: " + Y + " , Z: " + Z + " , A: " + A + " , B: " + B + " , C: " + C + " , U: " + U + " , V: " + V + " , W: " + W + " , I: " + U + " , J: " + V + " , K: " + W;
	}
}
