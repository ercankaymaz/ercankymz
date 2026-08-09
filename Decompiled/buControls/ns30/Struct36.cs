using System;
using System.Runtime.CompilerServices;

namespace ns30;

internal struct Struct36
{
	public int int_0;

	public int int_1;

	public int int_2;

	public int int_3;

	[SpecialName]
	internal uint method_0()
	{
		return (uint)Math.Abs(int_2 - int_0);
	}

	[SpecialName]
	internal uint method_1()
	{
		return (uint)Math.Abs(int_3 - int_1);
	}

	string ValueType.ToString()
	{
		return int_0 + ":" + int_1 + ":" + int_2 + ":" + int_3;
	}
}
