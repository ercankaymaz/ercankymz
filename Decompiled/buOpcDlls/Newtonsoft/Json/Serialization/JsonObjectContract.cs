using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Security;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Utilities;

namespace Newtonsoft.Json.Serialization;

[Newtonsoft_002EJson_002ENullableContext(2)]
[Newtonsoft_002EJson_002ENullable(0)]
public class JsonObjectContract : JsonContainerContract
{
	internal bool ExtensionDataIsJToken;

	private bool? _hasRequiredOrDefaultValueProperties;

	[Newtonsoft_002EJson_002ENullable(new byte[] { 2, 1 })]
	private ObjectConstructor<object> _overrideCreator;

	[Newtonsoft_002EJson_002ENullable(new byte[] { 2, 1 })]
	private ObjectConstructor<object> _parameterizedCreator;

	private JsonPropertyCollection _creatorParameters;

	private Type _extensionDataValueType;

	public MemberSerialization MemberSerialization { get; set; }

	public MissingMemberHandling? MissingMemberHandling { get; set; }

	public Required? ItemRequired { get; set; }

	public NullValueHandling? ItemNullValueHandling { get; set; }

	[Newtonsoft_002EJson_002ENullable(1)]
	[field: Newtonsoft_002EJson_002ENullable(1)]
	public JsonPropertyCollection Properties
	{
		[Newtonsoft_002EJson_002ENullableContext(1)]
		get;
	}

	[Newtonsoft_002EJson_002ENullable(1)]
	public JsonPropertyCollection CreatorParameters
	{
		[Newtonsoft_002EJson_002ENullableContext(1)]
		get
		{
			if (_creatorParameters == null)
			{
				_creatorParameters = new JsonPropertyCollection(base.UnderlyingType);
			}
			return _creatorParameters;
		}
	}

	[Newtonsoft_002EJson_002ENullable(new byte[] { 2, 1 })]
	public ObjectConstructor<object> OverrideCreator
	{
		[return: Newtonsoft_002EJson_002ENullable(new byte[] { 2, 1 })]
		get
		{
			return _overrideCreator;
		}
		[param: Newtonsoft_002EJson_002ENullable(new byte[] { 2, 1 })]
		set
		{
			_overrideCreator = value;
		}
	}

	[Newtonsoft_002EJson_002ENullable(new byte[] { 2, 1 })]
	internal ObjectConstructor<object> ParameterizedCreator
	{
		[return: Newtonsoft_002EJson_002ENullable(new byte[] { 2, 1 })]
		get
		{
			return _parameterizedCreator;
		}
		[param: Newtonsoft_002EJson_002ENullable(new byte[] { 2, 1 })]
		set
		{
			_parameterizedCreator = value;
		}
	}

	public ExtensionDataSetter ExtensionDataSetter { get; set; }

	public ExtensionDataGetter ExtensionDataGetter { get; set; }

	public Type ExtensionDataValueType
	{
		get
		{
			return _extensionDataValueType;
		}
		set
		{
			_extensionDataValueType = value;
			ExtensionDataIsJToken = value != null && typeof(JToken).IsAssignableFrom(value);
		}
	}

	[Newtonsoft_002EJson_002ENullable(new byte[] { 2, 1, 1 })]
	[field: Newtonsoft_002EJson_002ENullable(new byte[] { 2, 1, 1 })]
	public Func<string, string> ExtensionDataNameResolver
	{
		[return: Newtonsoft_002EJson_002ENullable(new byte[] { 2, 1, 1 })]
		get;
		[param: Newtonsoft_002EJson_002ENullable(new byte[] { 2, 1, 1 })]
		set;
	}

	internal bool HasRequiredOrDefaultValueProperties
	{
		get
		{
			if (!_hasRequiredOrDefaultValueProperties.HasValue)
			{
				_hasRequiredOrDefaultValueProperties = false;
				if ((ItemRequired ?? Required.Default) != Required.Default)
				{
					_hasRequiredOrDefaultValueProperties = true;
				}
				else
				{
					foreach (JsonProperty property in Properties)
					{
						if (property.Required != Required.Default || ((uint?)property.DefaultValueHandling & 2u) == 2)
						{
							_hasRequiredOrDefaultValueProperties = true;
							break;
						}
					}
				}
			}
			return _hasRequiredOrDefaultValueProperties == true;
		}
	}

	[Newtonsoft_002EJson_002ENullableContext(1)]
	public JsonObjectContract(Type underlyingType)
		: base(underlyingType)
	{
		ContractType = JsonContractType.Object;
		Properties = new JsonPropertyCollection(base.UnderlyingType);
	}

	[Newtonsoft_002EJson_002ENullableContext(1)]
	[SecuritySafeCritical]
	internal object GetUninitializedObject()
	{
		if (!JsonTypeReflector.FullyTrusted)
		{
			throw new JsonException("Insufficient permissions. Creating an uninitialized '{0}' type requires full trust.".FormatWith(CultureInfo.InvariantCulture, NonNullableUnderlyingType));
		}
		return FormatterServices.GetUninitializedObject(NonNullableUnderlyingType);
	}
}
