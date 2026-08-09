using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using ns27;

namespace ns46;

internal sealed class Class116
{
	public static class Class117
	{
		public static string smethod_0(int int_0)
		{
			int_0 ^= 0x666BEEF;
			int_0 -= Class116.int_0;
			if (!bool_0)
			{
				return Class76.smethod_425(int_0);
			}
			return Class76.smethod_701(int_0);
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
		return Class117.smethod_0(int_1);
	}

	static Class116()
	{
		string_0 = "1";
		string_1 = "192";
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
		using Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("{12887206-8450-4c5f-88b1-f2bdae7aafb0}");
		int num = Convert.ToInt32(stream.Length);
		byte[] buffer = new byte[num];
		stream.Read(buffer, 0, num);
		byte_0 = Class76.smethod_388(buffer);
		buffer = null;
	}
}
