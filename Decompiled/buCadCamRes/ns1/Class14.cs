using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using ns8;

namespace ns1;

internal class Class14
{
	public static class Class15
	{
		public static string smethod_0(int int_0)
		{
			int_0 ^= 0x666BEEF;
			int_0 -= Class14.int_0;
			if (!bool_0)
			{
				return Class5.smethod_168(int_0);
			}
			return Class5.smethod_179(int_0);
		}
	}

	private static readonly string string_0;

	private static readonly string string_1;

	internal static readonly byte[] byte_0;

	internal static readonly Dictionary<int, string> dictionary_0;

	internal static readonly object object_0;

	internal static readonly bool bool_0;

	private static readonly int int_0;

	public static string smethod_0(int int_1)
	{
		return Class15.smethod_0(int_1);
	}

	static Class14()
	{
		string_0 = "1";
		string_1 = "38";
		byte_0 = null;
		object_0 = new object();
		bool_0 = false;
		int_0 = 0;
		if (string_0 == "1")
		{
			bool_0 = true;
			dictionary_0 = new Dictionary<int, string>();
		}
		int_0 = Convert.ToInt32(string_1);
		using Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("{e1d240fa-e10d-4c46-a4bd-19e42daa2ad2}");
		int num = Convert.ToInt32(stream.Length);
		byte[] buffer = new byte[num];
		stream.Read(buffer, 0, num);
		byte_0 = Class5.smethod_134(buffer);
		buffer = null;
	}
}
