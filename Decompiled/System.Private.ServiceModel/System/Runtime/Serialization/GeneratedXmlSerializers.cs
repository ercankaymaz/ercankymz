using System.Collections.Generic;

namespace System.Runtime.Serialization;

public class GeneratedXmlSerializers
{
	private static Dictionary<string, Type> s_generatedSerializers = new Dictionary<string, Type>();

	public static bool IsInitialized => s_generatedSerializers.Count != 0;

	public static Dictionary<string, Type> GetGeneratedSerializers()
	{
		return s_generatedSerializers;
	}
}
