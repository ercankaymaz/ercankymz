using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Reflection;

namespace System.Text.Json.Serialization.Converters;

internal sealed class EnumConverterFactory : JsonConverterFactory
{
	[RequiresDynamicCode("JSON serialization and deserialization might require types that cannot be statically analyzed and might need runtime code generation. Use System.Text.Json source generation for native AOT applications.")]
	public EnumConverterFactory()
	{
	}

	public override bool CanConvert(Type type)
	{
		return type.IsEnum;
	}

	public static bool IsSupportedTypeCode(TypeCode typeCode)
	{
		if ((uint)(typeCode - 5) <= 7u)
		{
			return true;
		}
		return false;
	}

	[UnconditionalSuppressMessage("AOT", "IL3050:Calling members annotated with 'RequiresDynamicCodeAttribute' may break functionality when AOT compiling.", Justification = "The constructor has been annotated with RequiredDynamicCodeAttribute.")]
	public override JsonConverter CreateConverter(Type type, JsonSerializerOptions options)
	{
		return Create(type, EnumConverterOptions.AllowNumbers, null, options);
	}

	public static JsonConverter<T> Create<T>(EnumConverterOptions converterOptions, JsonSerializerOptions options, JsonNamingPolicy namingPolicy = null) where T : struct, Enum
	{
		if (!IsSupportedTypeCode(System.Type.GetTypeCode(typeof(T))))
		{
			return new UnsupportedTypeConverter<T>();
		}
		return new EnumConverter<T>(converterOptions, namingPolicy, options);
	}

	[RequiresDynamicCode("JSON serialization and deserialization might require types that cannot be statically analyzed and might need runtime code generation. Use System.Text.Json source generation for native AOT applications.")]
	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2071:UnrecognizedReflectionPattern", Justification = "'EnumConverter<T> where T : struct' implies 'T : new()', so the trimmer is warning calling MakeGenericType here because enumType's constructors are not annotated. But EnumConverter doesn't call new T(), so this is safe.")]
	public static JsonConverter Create(Type enumType, EnumConverterOptions converterOptions, JsonNamingPolicy namingPolicy, JsonSerializerOptions options)
	{
		if (!IsSupportedTypeCode(System.Type.GetTypeCode(enumType)))
		{
			return UnsupportedTypeConverterFactory.CreateUnsupportedConverterForType(enumType);
		}
		return (JsonConverter)typeof(EnumConverter<>).MakeGenericType(enumType).CreateInstanceNoWrapExceptions(new Type[3]
		{
			typeof(EnumConverterOptions),
			typeof(JsonNamingPolicy),
			typeof(JsonSerializerOptions)
		}, new object[3] { converterOptions, namingPolicy, options });
	}
}
