using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace System.Text.Json.Schema;

public static class JsonSchemaExporter
{
	private readonly ref struct GenerationState(JsonSerializerOptions options, JsonSchemaExporterOptions exporterOptions)
	{
		private readonly List<string> _currentPath = new List<string>();

		private readonly Dictionary<(JsonTypeInfo, JsonPropertyInfo), string[]> _generated = new Dictionary<(JsonTypeInfo, JsonPropertyInfo), string[]>();

		public int CurrentDepth => _currentPath.Count;

		public JsonSerializerOptions Options { get; } = options;

		public JsonSchemaExporterOptions ExporterOptions { get; } = exporterOptions;

		public void PushSchemaNode(string nodeId)
		{
			if (CurrentDepth == Options.EffectiveMaxDepth)
			{
				ThrowHelper.ThrowInvalidOperationException_JsonSchemaExporterDepthTooLarge();
			}
			_currentPath.Add(nodeId);
		}

		public void PopSchemaNode()
		{
			_currentPath.RemoveAt(_currentPath.Count - 1);
		}

		public bool TryGetExistingJsonPointer(in JsonSchemaExporterContext context, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out string existingJsonPointer)
		{
			(JsonTypeInfo, JsonPropertyInfo) key = (context.TypeInfo, context.PropertyInfo);
			if (_generated.TryGetValue(key, out var value))
			{
				existingJsonPointer = FormatJsonPointer(value);
				return true;
			}
			_generated[key] = context._path;
			existingJsonPointer = null;
			return false;
		}

		public JsonSchemaExporterContext CreateContext(JsonTypeInfo typeInfo, JsonPropertyInfo propertyInfo, JsonTypeInfo baseTypeInfo)
		{
			return new JsonSchemaExporterContext(typeInfo, propertyInfo, baseTypeInfo, _currentPath.ToArray());
		}

		private static string FormatJsonPointer(ReadOnlySpan<string> path)
		{
			if (path.IsEmpty)
			{
				return "#";
			}
			using System.Text.ValueStringBuilder valueStringBuilder = new System.Text.ValueStringBuilder(path.Length * 10);
			valueStringBuilder.Append('#');
			ReadOnlySpan<string> readOnlySpan = path;
			for (int i = 0; i < readOnlySpan.Length; i++)
			{
				ReadOnlySpan<char> readOnlySpan2 = readOnlySpan[i].AsSpan();
				valueStringBuilder.Append('/');
				do
				{
					int num = readOnlySpan2.IndexOfAny('~', '/');
					if (num < 0)
					{
						valueStringBuilder.Append(readOnlySpan2);
						break;
					}
					valueStringBuilder.Append(readOnlySpan2.Slice(0, num));
					if (readOnlySpan2[num] == '~')
					{
						valueStringBuilder.Append("~0");
					}
					else
					{
						valueStringBuilder.Append("~1");
					}
					readOnlySpan2 = readOnlySpan2.Slice(num + 1);
				}
				while (!readOnlySpan2.IsEmpty);
			}
			return valueStringBuilder.ToString();
		}
	}

	public static JsonNode GetJsonSchemaAsNode(this JsonSerializerOptions options, Type type, JsonSchemaExporterOptions? exporterOptions = null)
	{
		if (options == null)
		{
			ThrowHelper.ThrowArgumentNullException("options");
		}
		if ((object)type == null)
		{
			ThrowHelper.ThrowArgumentNullException("type");
		}
		ValidateOptions(options);
		return options.GetTypeInfoInternal(type, ensureConfigured: true, true).GetJsonSchemaAsNode(exporterOptions);
	}

	public static JsonNode GetJsonSchemaAsNode(this JsonTypeInfo typeInfo, JsonSchemaExporterOptions? exporterOptions = null)
	{
		if (typeInfo == null)
		{
			ThrowHelper.ThrowArgumentNullException("typeInfo");
		}
		ValidateOptions(typeInfo.Options);
		if (exporterOptions == null)
		{
			exporterOptions = JsonSchemaExporterOptions.Default;
		}
		typeInfo.EnsureConfigured();
		GenerationState state = new GenerationState(typeInfo.Options, exporterOptions);
		return MapJsonSchemaCore(ref state, typeInfo).ToJsonNode(exporterOptions);
	}

	private static JsonSchema MapJsonSchemaCore(ref GenerationState state, JsonTypeInfo typeInfo, JsonPropertyInfo propertyInfo = null, JsonConverter customConverter = null, JsonNumberHandling? customNumberHandling = null, JsonTypeInfo parentPolymorphicTypeInfo = null, bool parentPolymorphicTypeContainsTypesWithoutDiscriminator = false, bool parentPolymorphicTypeIsNonNullable = false, KeyValuePair<string, JsonSchema>? typeDiscriminator = null, bool cacheResult = true)
	{
		JsonSchemaExporterContext exporterContext = state.CreateContext(typeInfo, propertyInfo, parentPolymorphicTypeInfo);
		if (cacheResult && typeInfo.Kind != JsonTypeInfoKind.None && state.TryGetExistingJsonPointer(in exporterContext, out var existingJsonPointer))
		{
			return CompleteSchema(ref state, new JsonSchema
			{
				Ref = existingJsonPointer
			});
		}
		JsonConverter jsonConverter = customConverter ?? typeInfo.Converter;
		JsonNumberHandling jsonNumberHandling = customNumberHandling ?? typeInfo.NumberHandling ?? typeInfo.Options.NumberHandling;
		JsonSchema schema = jsonConverter.GetSchema(jsonNumberHandling);
		if (schema != null)
		{
			return CompleteSchema(ref state, schema);
		}
		if (parentPolymorphicTypeInfo == null)
		{
			JsonPolymorphismOptions polymorphismOptions = typeInfo.PolymorphismOptions;
			if (polymorphismOptions != null)
			{
				IList<JsonDerivedType> derivedTypes = polymorphismOptions.DerivedTypes;
				if (derivedTypes != null && derivedTypes.Count > 0)
				{
					string typeDiscriminatorPropertyName = polymorphismOptions.TypeDiscriminatorPropertyName;
					List<JsonDerivedType> list = new List<JsonDerivedType>(polymorphismOptions.DerivedTypes);
					if (!typeInfo.Type.IsAbstract && !IsPolymorphicTypeThatSpecifiesItselfAsDerivedType(typeInfo))
					{
						list.Add(new JsonDerivedType(typeInfo.Type));
					}
					bool flag = list.Exists((JsonDerivedType jsonDerivedType) => jsonDerivedType.TypeDiscriminator == null);
					JsonSchemaType jsonSchemaType = JsonSchemaType.Any;
					List<JsonSchema> list2 = new List<JsonSchema>(list.Count);
					state.PushSchemaNode("anyOf");
					foreach (JsonDerivedType item in list)
					{
						KeyValuePair<string, JsonSchema>? keyValuePair = null;
						object typeDiscriminator2 = item.TypeDiscriminator;
						if (typeDiscriminator2 != null)
						{
							JsonNode jsonNode = ((!(typeDiscriminator2 is string text)) ? ((JsonNode)(int)typeDiscriminator2) : ((JsonNode?)text));
							JsonNode constant = jsonNode;
							JsonSchema value = new JsonSchema
							{
								Constant = constant
							};
							keyValuePair = new KeyValuePair<string, JsonSchema>(typeDiscriminatorPropertyName, value);
						}
						JsonTypeInfo typeInfoInternal = typeInfo.Options.GetTypeInfoInternal(item.DerivedType, ensureConfigured: true, true);
						state.PushSchemaNode(list2.Count.ToString(CultureInfo.InvariantCulture));
						JsonTypeInfo parentPolymorphicTypeInfo2 = typeInfo;
						KeyValuePair<string, JsonSchema>? typeDiscriminator3 = keyValuePair;
						bool parentPolymorphicTypeContainsTypesWithoutDiscriminator2 = flag;
						bool parentPolymorphicTypeIsNonNullable2 = propertyInfo != null && !propertyInfo.IsGetNullable && !propertyInfo.IsSetNullable;
						JsonSchema jsonSchema = MapJsonSchemaCore(ref state, typeInfoInternal, null, null, null, parentPolymorphicTypeInfo2, parentPolymorphicTypeContainsTypesWithoutDiscriminator2, parentPolymorphicTypeIsNonNullable2, typeDiscriminator3, cacheResult: false);
						state.PopSchemaNode();
						if (list2.Count == 0)
						{
							jsonSchemaType = jsonSchema.Type;
						}
						else if (jsonSchemaType != jsonSchema.Type)
						{
							jsonSchemaType = JsonSchemaType.Any;
						}
						list2.Add(jsonSchema);
					}
					state.PopSchemaNode();
					if (jsonSchemaType != JsonSchemaType.Any)
					{
						foreach (JsonSchema item2 in list2)
						{
							item2.Type = JsonSchemaType.Any;
							if (item2.KeywordCount == 0)
							{
								list2 = null;
								break;
							}
						}
					}
					return CompleteSchema(ref state, new JsonSchema
					{
						Type = jsonSchemaType,
						AnyOf = list2,
						Required = (flag ? null : new List<string>(1) { typeDiscriminatorPropertyName })
					});
				}
			}
		}
		JsonConverter nullableElementConverter = jsonConverter.NullableElementConverter;
		if (nullableElementConverter != null)
		{
			JsonTypeInfo typeInfo2 = typeInfo.Options.GetTypeInfo(nullableElementConverter.Type);
			schema = MapJsonSchemaCore(ref state, typeInfo2, null, nullableElementConverter, null, null, parentPolymorphicTypeContainsTypesWithoutDiscriminator: false, parentPolymorphicTypeIsNonNullable: false, null, cacheResult: false);
			if (schema.Enum != null)
			{
				schema.Enum.Add(null);
			}
			return CompleteSchema(ref state, schema);
		}
		switch (typeInfo.Kind)
		{
		case JsonTypeInfoKind.Object:
		{
			List<KeyValuePair<string, JsonSchema>> list3 = null;
			List<string> list4 = null;
			JsonSchema additionalProperties = null;
			if ((typeInfo.UnmappedMemberHandling ?? typeInfo.Options.UnmappedMemberHandling) == JsonUnmappedMemberHandling.Disallow)
			{
				additionalProperties = JsonSchema.CreateFalseSchema();
			}
			if (typeDiscriminator.HasValue)
			{
				KeyValuePair<string, JsonSchema> valueOrDefault2 = typeDiscriminator.GetValueOrDefault();
				(list3 ?? (list3 = new List<KeyValuePair<string, JsonSchema>>())).Add(valueOrDefault2);
				if (parentPolymorphicTypeContainsTypesWithoutDiscriminator)
				{
					(list4 ?? (list4 = new List<string>())).Add(valueOrDefault2.Key);
				}
			}
			state.PushSchemaNode("properties");
			foreach (JsonPropertyInfo property in typeInfo.Properties)
			{
				if ((property != null && ((property.Get == null && property.Set == null) || property.IsExtensionData)) ? true : false)
				{
					continue;
				}
				state.PushSchemaNode(property.Name);
				JsonSchema schema2 = MapJsonSchemaCore(ref state, property.JsonTypeInfo, property, property.EffectiveConverter, property.EffectiveNumberHandling);
				state.PopSchemaNode();
				JsonParameterInfo associatedParameter = property.AssociatedParameter;
				if (associatedParameter != null && associatedParameter.HasDefaultValue)
				{
					JsonSchema.EnsureMutable(ref schema2);
					schema2.DefaultValue = JsonSerializer.SerializeToNode(associatedParameter.DefaultValue, property.JsonTypeInfo);
					schema2.HasDefaultValue = true;
				}
				(list3 ?? (list3 = new List<KeyValuePair<string, JsonSchema>>())).Add(new KeyValuePair<string, JsonSchema>(property.Name, schema2));
				if (property == null)
				{
					goto IL_05b4;
				}
				if (!property.IsRequired)
				{
					JsonParameterInfo associatedParameter2 = property.AssociatedParameter;
					if (associatedParameter2 == null || !associatedParameter2.IsRequiredParameter)
					{
						goto IL_05b4;
					}
				}
				bool parentPolymorphicTypeIsNonNullable2 = true;
				goto IL_05b7;
				IL_05b4:
				parentPolymorphicTypeIsNonNullable2 = false;
				goto IL_05b7;
				IL_05b7:
				if (parentPolymorphicTypeIsNonNullable2)
				{
					(list4 ?? (list4 = new List<string>())).Add(property.Name);
				}
			}
			state.PopSchemaNode();
			return CompleteSchema(ref state, new JsonSchema
			{
				Type = JsonSchemaType.Object,
				Properties = list3,
				Required = list4,
				AdditionalProperties = additionalProperties
			});
		}
		case JsonTypeInfoKind.Enumerable:
		{
			if (!typeDiscriminator.HasValue)
			{
				state.PushSchemaNode("items");
				JsonSchema jsonSchema3 = MapJsonSchemaCore(ref state, typeInfo.ElementTypeInfo, null, null, jsonNumberHandling);
				state.PopSchemaNode();
				return CompleteSchema(ref state, new JsonSchema
				{
					Type = JsonSchemaType.Array,
					Items = (jsonSchema3.IsTrue ? null : jsonSchema3)
				});
			}
			state.PushSchemaNode("properties");
			state.PushSchemaNode("$values");
			state.PushSchemaNode("items");
			JsonSchema jsonSchema4 = MapJsonSchemaCore(ref state, typeInfo.ElementTypeInfo, null, null, jsonNumberHandling);
			state.PopSchemaNode();
			state.PopSchemaNode();
			state.PopSchemaNode();
			return CompleteSchema(ref state, new JsonSchema
			{
				Type = JsonSchemaType.Object,
				Properties = new List<KeyValuePair<string, JsonSchema>>(2)
				{
					typeDiscriminator.Value,
					new KeyValuePair<string, JsonSchema>("$values", new JsonSchema
					{
						Type = JsonSchemaType.Array,
						Items = (jsonSchema4.IsTrue ? null : jsonSchema4)
					})
				},
				Required = (parentPolymorphicTypeContainsTypesWithoutDiscriminator ? new List<string>(1) { typeDiscriminator.Value.Key } : null)
			});
		}
		case JsonTypeInfoKind.Dictionary:
		{
			List<KeyValuePair<string, JsonSchema>> properties = null;
			List<string> required = null;
			if (typeDiscriminator.HasValue)
			{
				KeyValuePair<string, JsonSchema> valueOrDefault = typeDiscriminator.GetValueOrDefault();
				properties = new List<KeyValuePair<string, JsonSchema>>(1) { valueOrDefault };
				if (parentPolymorphicTypeContainsTypesWithoutDiscriminator)
				{
					required = new List<string>(1) { valueOrDefault.Key };
				}
			}
			state.PushSchemaNode("additionalProperties");
			JsonSchema jsonSchema2 = MapJsonSchemaCore(ref state, typeInfo.ElementTypeInfo, null, null, jsonNumberHandling);
			state.PopSchemaNode();
			return CompleteSchema(ref state, new JsonSchema
			{
				Type = JsonSchemaType.Object,
				Properties = properties,
				Required = required,
				AdditionalProperties = (jsonSchema2.IsTrue ? null : jsonSchema2)
			});
		}
		default:
			return CompleteSchema(ref state, JsonSchema.CreateTrueSchema());
		}
		JsonSchema CompleteSchema(ref GenerationState reference, JsonSchema jsonSchema5)
		{
			if (jsonSchema5.Ref == null)
			{
				bool num;
				if (propertyInfo == null)
				{
					if (!typeInfo.CanBeNull || parentPolymorphicTypeIsNonNullable)
					{
						goto IL_005b;
					}
					num = !reference.ExporterOptions.TreatNullObliviousAsNonNullable;
				}
				else
				{
					if (propertyInfo.IsGetNullable)
					{
						goto IL_0055;
					}
					num = propertyInfo.IsSetNullable;
				}
				if (num)
				{
					goto IL_0055;
				}
			}
			goto IL_005b;
			IL_005b:
			if (reference.ExporterOptions.TransformSchemaNode != null)
			{
				jsonSchema5.ExporterContext = exporterContext;
			}
			return jsonSchema5;
			IL_0055:
			jsonSchema5.MakeNullable();
			goto IL_005b;
		}
	}

	private static void ValidateOptions(JsonSerializerOptions options)
	{
		if (options.ReferenceHandler == ReferenceHandler.Preserve)
		{
			ThrowHelper.ThrowNotSupportedException_JsonSchemaExporterDoesNotSupportReferenceHandlerPreserve();
		}
		options.MakeReadOnly();
	}

	private static bool IsPolymorphicTypeThatSpecifiesItselfAsDerivedType(JsonTypeInfo typeInfo)
	{
		foreach (JsonDerivedType derivedType in typeInfo.PolymorphismOptions.DerivedTypes)
		{
			if (derivedType.DerivedType == typeInfo.Type)
			{
				return true;
			}
		}
		return false;
	}
}
