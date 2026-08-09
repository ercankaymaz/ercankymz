using System.CodeDom.Compiler;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public static class ReferenceTypes
{
	public const uint References = 31u;

	public const uint NonHierarchicalReferences = 32u;

	public const uint HierarchicalReferences = 33u;

	public const uint HasChild = 34u;

	public const uint Organizes = 35u;

	public const uint HasEventSource = 36u;

	public const uint HasModellingRule = 37u;

	public const uint HasEncoding = 38u;

	public const uint HasDescription = 39u;

	public const uint HasTypeDefinition = 40u;

	public const uint GeneratesEvent = 41u;

	public const uint AlwaysGeneratesEvent = 3065u;

	public const uint Aggregates = 44u;

	public const uint HasSubtype = 45u;

	public const uint HasProperty = 46u;

	public const uint HasComponent = 47u;

	public const uint HasNotifier = 48u;

	public const uint HasOrderedComponent = 49u;

	public const uint FromState = 51u;

	public const uint ToState = 52u;

	public const uint HasCause = 53u;

	public const uint HasEffect = 54u;

	public const uint HasSubStateMachine = 117u;

	public const uint HasHistoricalConfiguration = 56u;

	public const uint HasArgumentDescription = 129u;

	public const uint HasOptionalInputArgumentDescription = 131u;

	public const uint HasGuard = 15112u;

	public const uint HasDictionaryEntry = 17597u;

	public const uint HasInterface = 17603u;

	public const uint HasAddIn = 17604u;

	public const uint HasTrueSubState = 9004u;

	public const uint HasFalseSubState = 9005u;

	public const uint HasAlarmSuppressionGroup = 16361u;

	public const uint AlarmGroupMember = 16362u;

	public const uint HasCondition = 9006u;

	public const uint HasEffectDisable = 17276u;

	public const uint HasEffectEnable = 17983u;

	public const uint HasEffectSuppressed = 17984u;

	public const uint HasEffectUnsuppressed = 17985u;

	public const uint HasPubSubConnection = 14476u;

	public const uint DataSetToWriter = 14936u;

	public const uint HasDataSetWriter = 15296u;

	public const uint HasWriterGroup = 18804u;

	public const uint HasDataSetReader = 15297u;

	public const uint HasReaderGroup = 18805u;

	public const uint AliasFor = 23469u;

	public static string GetBrowseName(uint identifier)
	{
		FieldInfo[] fields = typeof(ReferenceTypes).GetFields(BindingFlags.Static | BindingFlags.Public);
		foreach (FieldInfo fieldInfo in fields)
		{
			if (identifier == (uint)fieldInfo.GetValue(typeof(ReferenceTypes)))
			{
				return fieldInfo.Name;
			}
		}
		return string.Empty;
	}

	public static string[] GetBrowseNames()
	{
		FieldInfo[] fields = typeof(ReferenceTypes).GetFields(BindingFlags.Static | BindingFlags.Public);
		int num = 0;
		string[] array = new string[fields.Length];
		FieldInfo[] array2 = fields;
		foreach (FieldInfo fieldInfo in array2)
		{
			array[num++] = fieldInfo.Name;
		}
		return array;
	}

	public static uint GetIdentifier(string browseName)
	{
		FieldInfo[] fields = typeof(ReferenceTypes).GetFields(BindingFlags.Static | BindingFlags.Public);
		foreach (FieldInfo fieldInfo in fields)
		{
			if (fieldInfo.Name == browseName)
			{
				return (uint)fieldInfo.GetValue(typeof(ReferenceTypes));
			}
		}
		return 0u;
	}
}
