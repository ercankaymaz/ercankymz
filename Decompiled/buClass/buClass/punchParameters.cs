using System;
using System.Collections;

namespace buClass;

[Serializable]
public class punchParameters : buSerilization
{
	public punchOptions Options = new punchOptions();

	public punchParameters()
	{
	}

	public punchParameters(punchParameters parameters)
	{
		Options = new punchOptions(parameters.Options);
	}

	public static void Decode(ArrayList AL, string Char, ref punchParameters Par)
	{
		buSerilization.Decode(AL, Char, SerilizationMode.MultiLine, Par.Options);
	}

	public static void ToDef(punchParameters Par, ref ArrayList AL, string Char, int Space, SerilizationMode DefMode)
	{
		AL.AddRange(Par.Options.ToDefAll(Char, Space, SerilizationMode.MultiLine));
	}
}
