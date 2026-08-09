using System;

namespace ModuleWorks;

[Serializable]
public struct TurningSolidParameters<T>
{
	public TurningSolidInsert Insert { get; set; }

	public TurningSolidType Type { get; set; }

	public TurningSolidShank Shank { get; set; }

	public TurningSolidHand Hand { get; set; }

	public T Height { get; set; }

	public T A { get; set; }

	public T B { get; set; }

	public T C { get; set; }

	public T D { get; set; }

	public T E { get; set; }

	public T F { get; set; }

	public T G { get; set; }

	public T H { get; set; }

	public T I { get; set; }

	public TurningSolidParameters(TurningSolidInsert insert)
	{
		this = default(TurningSolidParameters<T>);
		Insert = insert;
	}

	public TurningSolidParameters(TurningSolidInsert insert, TurningSolidType type)
	{
		this = default(TurningSolidParameters<T>);
		Insert = insert;
		Type = type;
	}
}
[Serializable]
[Obsolete("Deprecated since Release 2017.04. Please use ModuleWorks.TurningSolidParameters<T> instead!")]
public struct TurningSolidParameters
{
	public TurningSolidInsert Insert { get; set; }

	public TurningSolidType Type { get; set; }

	public TurningSolidShank Shank { get; set; }

	public TurningSolidHand Hand { get; set; }

	public double Height { get; set; }

	public double A { get; set; }

	public double B { get; set; }

	public double C { get; set; }

	public double D { get; set; }

	public double E { get; set; }

	public double F { get; set; }

	public double G { get; set; }

	public double H { get; set; }

	public double I { get; set; }

	public TurningSolidParameters(TurningSolidInsert insert)
	{
		this = default(TurningSolidParameters);
		Insert = insert;
	}

	public TurningSolidParameters(TurningSolidInsert insert, TurningSolidType type)
	{
		this = default(TurningSolidParameters);
		Insert = insert;
		Type = type;
	}

	public TurningSolidParameters<double> Convert()
	{
		return new TurningSolidParameters<double>
		{
			Insert = Insert,
			Type = Type,
			Shank = Shank,
			Hand = Hand,
			A = A,
			B = B,
			C = C,
			D = D,
			E = E,
			F = F,
			G = G,
			H = H,
			I = I
		};
	}
}
