// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Serialization.JsonObjectContract
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Utilities;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Runtime.CompilerServices.Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Security;

#nullable disable
namespace Newtonsoft.Json.Serialization;

[NullableContext(2)]
[Nullable(0)]
public class JsonObjectContract : JsonContainerContract
{
  internal bool ExtensionDataIsJToken;
  private bool? _hasRequiredOrDefaultValueProperties;
  [Nullable(new byte[] {2, 1})]
  private ObjectConstructor<object> _overrideCreator;
  [Nullable(new byte[] {2, 1})]
  private ObjectConstructor<object> _parameterizedCreator;
  private JsonPropertyCollection _creatorParameters;
  private Type _extensionDataValueType;

  public MemberSerialization MemberSerialization { get; set; }

  public Newtonsoft.Json.MissingMemberHandling? MissingMemberHandling { get; set; }

  public Required? ItemRequired { get; set; }

  public NullValueHandling? ItemNullValueHandling { get; set; }

  [field: Nullable(1)]
  [Nullable(1)]
  public JsonPropertyCollection Properties { [NullableContext(1)] get; }

  [Nullable(1)]
  public JsonPropertyCollection CreatorParameters
  {
    [NullableContext(1)] get
    {
      if (this._creatorParameters == null)
        this._creatorParameters = new JsonPropertyCollection(this.UnderlyingType);
      return this._creatorParameters;
    }
  }

  [Nullable(new byte[] {2, 1})]
  public ObjectConstructor<object> OverrideCreator
  {
    [return: Nullable(new byte[] {2, 1})] get => this._overrideCreator;
    [param: Nullable(new byte[] {2, 1})] set => this._overrideCreator = value;
  }

  [Nullable(new byte[] {2, 1})]
  internal ObjectConstructor<object> ParameterizedCreator
  {
    [return: Nullable(new byte[] {2, 1})] get => this._parameterizedCreator;
    [param: Nullable(new byte[] {2, 1})] set => this._parameterizedCreator = value;
  }

  public ExtensionDataSetter ExtensionDataSetter { get; set; }

  public ExtensionDataGetter ExtensionDataGetter { get; set; }

  public Type ExtensionDataValueType
  {
    get => this._extensionDataValueType;
    set
    {
      this._extensionDataValueType = value;
      this.ExtensionDataIsJToken = value != (Type) null && typeof (JToken).IsAssignableFrom(value);
    }
  }

  [field: Nullable(new byte[] {2, 1, 1})]
  [Nullable(new byte[] {2, 1, 1})]
  public Func<string, string> ExtensionDataNameResolver { [return: Nullable(new byte[] {2, 1, 1})] get; [param: Nullable(new byte[] {2, 1, 1})] set; }

  internal bool HasRequiredOrDefaultValueProperties
  {
    get
    {
      if (!this._hasRequiredOrDefaultValueProperties.HasValue)
      {
        this._hasRequiredOrDefaultValueProperties = new bool?(false);
        if ((this.ItemRequired ?? Required.Default) != Required.Default)
        {
          this._hasRequiredOrDefaultValueProperties = new bool?(true);
        }
        else
        {
          foreach (JsonProperty property in (Collection<JsonProperty>) this.Properties)
          {
            if (property.Required == Required.Default)
            {
              DefaultValueHandling? defaultValueHandling = property.DefaultValueHandling;
              DefaultValueHandling? nullable = defaultValueHandling.HasValue ? new DefaultValueHandling?(defaultValueHandling.GetValueOrDefault() & DefaultValueHandling.Populate) : new DefaultValueHandling?();
              if (!(nullable.GetValueOrDefault() == DefaultValueHandling.Populate & nullable.HasValue))
                continue;
            }
            this._hasRequiredOrDefaultValueProperties = new bool?(true);
            break;
          }
        }
      }
      return this._hasRequiredOrDefaultValueProperties.GetValueOrDefault();
    }
  }

  [NullableContext(1)]
  public JsonObjectContract(Type underlyingType)
    : base(underlyingType)
  {
    this.ContractType = JsonContractType.Object;
    this.Properties = new JsonPropertyCollection(this.UnderlyingType);
  }

  [NullableContext(1)]
  [SecuritySafeCritical]
  internal object GetUninitializedObject()
  {
    if (!JsonTypeReflector.FullyTrusted)
      throw new JsonException("Insufficient permissions. Creating an uninitialized '{0}' type requires full trust.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) this.NonNullableUnderlyingType));
    return FormatterServices.GetUninitializedObject(this.NonNullableUnderlyingType);
  }
}
