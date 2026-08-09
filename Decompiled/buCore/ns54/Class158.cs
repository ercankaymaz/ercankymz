using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace ns54;

internal class Class158
{
	public static class Class159
	{
		public static string smethod_0(int int_0)
		{
			int_0 ^= 0x666BEEF;
			int_0 -= Class158.int_0;
			if (!bool_0)
			{
				return Class156.smethod_174(int_0);
			}
			return Class156.smethod_71(int_0);
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
		return Class159.smethod_0(int_1);
	}

	static Class158()
	{
		string_0 = "1";
		string_1 = "17";
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
		using Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("{21efdfc3-0630-48bd-8756-22f26806796f}");
		int num = Convert.ToInt32(stream.Length);
		byte[] buffer = new byte[num];
		stream.Read(buffer, 0, num);
		byte_0 = Class156.smethod_277(buffer);
		buffer = null;
	}
}
