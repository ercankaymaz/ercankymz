namespace buClass;

public class ForceCamAxisStrings
{
	public string X = "";

	public string Y = "";

	public string Z = "";

	public string A = "";

	public string B = "";

	public string C = "";

	public string U = "";

	public string V = "";

	public string W = "";

	public ForceCamAxisStrings()
	{
	}

	public ForceCamAxisStrings(string x, string y, string z)
	{
		X = x;
		Y = y;
		Z = z;
		A = "";
		B = "";
		C = "";
		U = "";
		V = "";
		W = "";
	}

	public ForceCamAxisStrings(string x, string y, string z, string a, string b, string c)
	{
		X = x;
		Y = y;
		Z = z;
		A = a;
		B = b;
		C = c;
		U = "";
		V = "";
		W = "";
	}

	public ForceCamAxisStrings(string x, string y, string z, string a, string b, string c, string u, string v, string w)
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

	public ForceCamAxisStrings(ForceCamAxisStrings axis)
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
		return "X: " + X.ToString() + " , Y: " + Y.ToString() + " , Z: " + Z.ToString() + " , A: " + A.ToString() + " , B: " + B.ToString() + " , C: " + C.ToString() + " , U: " + U.ToString() + " , V: " + V.ToString() + " , W: " + W.ToString();
	}
}
