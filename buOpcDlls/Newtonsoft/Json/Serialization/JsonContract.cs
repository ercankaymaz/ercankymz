// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Serialization.JsonContract
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Newtonsoft.Json.Utilities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices.Newtonsoft.Json;
using System.Runtime.Serialization;

#nullable disable
namespace Newtonsoft.Json.Serialization;

[NullableContext(1)]
[Nullable(0)]
public abstract class JsonContract
{
  internal bool IsNullable;
  internal bool IsConvertable;
  internal bool IsEnum;
  internal Type NonNullableUnderlyingType;
  internal ReadType InternalReadType;
  internal JsonContractType ContractType;
  internal bool IsReadOnlyOrFixedSize;
  internal bool IsSealed;
  internal bool IsInstantiable;
  [Nullable(new byte[] {2, 1})]
  private List<SerializationCallback> _onDeserializedCallbacks;
  [Nullable(new byte[] {2, 1})]
  private List<SerializationCallback> _onDeserializingCallbacks;
  [Nullable(new byte[] {2, 1})]
  private List<SerializationCallback> _onSerializedCallbacks;
  [Nullable(new byte[] {2, 1})]
  private List<SerializationCallback> _onSerializingCallbacks;
  [Nullable(new byte[] {2, 1})]
  private List<SerializationErrorCallback> _onErrorCallbacks;
  private Type _createdType;

  public Type UnderlyingType { get; }

  public Type CreatedType
  {
    get => this._createdType;
    set
    {
      ValidationUtils.ArgumentNotNull((object) value, nameof (value));
      this._createdType = value;
      this.IsSealed = this._createdType.IsSealed();
      this.IsInstantiable = !this._createdType.IsInterface() && !this._createdType.IsAbstract();
    }
  }

  public bool? IsReference { get; set; }

  [field: Nullable(2)]
  [Nullable(2)]
  public JsonConverter Converter { [NullableContext(2)] get; [NullableContext(2)] set; }

  [field: Nullable(2)]
  [Nullable(2)]
  public JsonConverter InternalConverter { [NullableContext(2)] get; [NullableContext(2)] internal set; }

  public IList<SerializationCallback> OnDeserializedCallbacks
  {
    get
    {
      if (this._onDeserializedCallbacks == null)
        this._onDeserializedCallbacks = new List<SerializationCallback>();
      return (IList<SerializationCallback>) this._onDeserializedCallbacks;
    }
  }

  public IList<SerializationCallback> OnDeserializingCallbacks
  {
    get
    {
      if (this._onDeserializingCallbacks == null)
        this._onDeserializingCallbacks = new List<SerializationCallback>();
      return (IList<SerializationCallback>) this._onDeserializingCallbacks;
    }
  }

  public IList<SerializationCallback> OnSerializedCallbacks
  {
    get
    {
      if (this._onSerializedCallbacks == null)
        this._onSerializedCallbacks = new List<SerializationCallback>();
      return (IList<SerializationCallback>) this._onSerializedCallbacks;
    }
  }

  public IList<SerializationCallback> OnSerializingCallbacks
  {
    get
    {
      if (this._onSerializingCallbacks == null)
        this._onSerializingCallbacks = new List<SerializationCallback>();
      return (IList<SerializationCallback>) this._onSerializingCallbacks;
    }
  }

  public IList<SerializationErrorCallback> OnErrorCallbacks
  {
    get
    {
      if (this._onErrorCallbacks == null)
        this._onErrorCallbacks = new List<SerializationErrorCallback>();
      return (IList<SerializationErrorCallback>) this._onErrorCallbacks;
    }
  }

  [field: Nullable(new byte[] {2, 1})]
  [Nullable(new byte[] {2, 1})]
  public Func<object> DefaultCreator { [return: Nullable(new byte[] {2, 1})] get; [param: Nullable(new byte[] {2, 1})] set; }

  public bool DefaultCreatorNonPublic { get; set; }

  internal JsonContract(Type underlyingType)
  {
    ValidationUtils.ArgumentNotNull((object) underlyingType, nameof (underlyingType));
    this.UnderlyingType = underlyingType;
    underlyingType = ReflectionUtils.EnsureNotByRefType(underlyingType);
    this.IsNullable = ReflectionUtils.IsNullable(underlyingType);
    this.NonNullableUnderlyingType = !this.IsNullable || !ReflectionUtils.IsNullableType(underlyingType) ? underlyingType : Nullable.GetUnderlyingType(underlyingType);
    this._createdType = this.CreatedType = this.NonNullableUnderlyingType;
    this.IsConvertable = ConvertUtils.IsConvertible(this.NonNullableUnderlyingType);
    this.IsEnum = this.NonNullableUnderlyingType.IsEnum();
    this.InternalReadType = ReadType.Read;
  }

  internal void InvokeOnSerializing(object o, StreamingContext context)
  {
    if (this._onSerializingCallbacks == null)
      return;
    foreach (SerializationCallback serializingCallback in this._onSerializingCallbacks)
      serializingCallback(o, context);
  }

  internal void InvokeOnSerialized(object o, StreamingContext context)
  {
    if (this._onSerializedCallbacks == null)
      return;
    foreach (SerializationCallback serializedCallback in this._onSerializedCallbacks)
      serializedCallback(o, context);
  }

  internal void InvokeOnDeserializing(object o, StreamingContext context)
  {
    if (this._onDeserializingCallbacks == null)
      return;
    foreach (SerializationCallback deserializingCallback in this._onDeserializingCallbacks)
      deserializingCallback(o, context);
  }

  internal void InvokeOnDeserialized(object o, StreamingContext context)
  {
    if (this._onDeserializedCallbacks == null)
      return;
    foreach (SerializationCallback deserializedCallback in this._onDeserializedCallbacks)
      deserializedCallback(o, context);
  }

  internal void InvokeOnError(object o, StreamingContext context, ErrorContext errorContext)
  {
    if (this._onErrorCallbacks == null)
      return;
    foreach (SerializationErrorCallback onErrorCallback in this._onErrorCallbacks)
      onErrorCallback(o, context, errorContext);
  }

  internal static SerializationCallback CreateSerializationCallback(MethodInfo callbackMethodInfo)
  {
    return (SerializationCallback) ((o, context) => callbackMethodInfo.Invoke(o, new object[1]
    {
      (object) context
    }));
  }

  internal static SerializationErrorCallback CreateSerializationErrorCallback(
    MethodInfo callbackMethodInfo)
  {
    return (SerializationErrorCallback) ((o, context, econtext) => callbackMethodInfo.Invoke(o, new object[2]
    {
      (object) context,
      (object) econtext
    }));
  }
}
