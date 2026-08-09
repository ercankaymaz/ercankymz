using System;
using Win32Types;

namespace ns5;

internal struct Struct2
{
	public IntPtr intptr_0;

	public IntPtr intptr_1;

	public int int_0;

	public int int_1;

	public int int_2;

	public int int_3;

	public uint uint_0;

	string ValueType.ToString()
	{
		string[] obj = new string[9]
		{
			int_0.ToString(),
			":",
			int_1.ToString(),
			":",
			int_2.ToString(),
			":",
			int_3.ToString(),
			":",
			null
		};
		Win32Types.SWP_Flags sWP_Flags = (Win32Types.SWP_Flags)uint_0;
		obj[8] = sWP_Flags.ToString();
		return string.Concat(obj);
	}
}
