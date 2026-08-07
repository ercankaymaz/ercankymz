// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Serialization.JsonDictionaryContract
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Newtonsoft.Json.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json.Serialization;

[NullableContext(2)]
[Nullable(0)]
public class JsonDictionaryContract : JsonContainerContract
{
  private readonly Type _genericCollectionDefinitionType;
  private Type _genericWrapperType;
  [Nullable(new byte[] {2, 1})]
  private ObjectConstructor<object> _genericWrapperCreator;
  [Nullable(new byte[] {2, 1})]
  private Func<object> _genericTemporaryDictionaryCreator;
  private readonly ConstructorInfo _parameterizedConstructor;
  [Nullable(new byte[] {2, 1})]
  private ObjectConstructor<object> _overrideCreator;
  [Nullable(new byte[] {2, 1})]
  private ObjectConstructor<object> _parameterizedCreator;

  [field: Nullable(new byte[] {2, 1, 1})]
  [Nullable(new byte[] {2, 1, 1})]
  public Func<string, string> DictionaryKeyResolver { [return: Nullable(new byte[] {2, 1, 1})] get; [param: Nullable(new byte[] {2, 1, 1})] set; }

  public Type DictionaryKeyType { get; }

  public Type DictionaryValueType { get; }

  internal JsonContract KeyContract { get; set; }

  internal bool ShouldCreateWrapper { get; }

  [Nullable(new byte[] {2, 1})]
  internal ObjectConstructor<object> ParameterizedCreator
  {
    [return: Nullable(new byte[] {2, 1})] get
    {
      if (this._parameterizedCreator == null && this._parameterizedConstructor != (ConstructorInfo) null)
        this._parameterizedCreator = JsonTypeReflector.ReflectionDelegateFactory.CreateParameterizedConstructor((MethodBase) this._parameterizedConstructor);
      return this._parameterizedCreator;
    }
  }

  [Nullable(new byte[] {2, 1})]
  public ObjectConstructor<object> OverrideCreator
  {
    [return: Nullable(new byte[] {2, 1})] get => this._overrideCreator;
    [param: Nullable(new byte[] {2, 1})] set => this._overrideCreator = value;
  }

  public bool HasParameterizedCreator { get; set; }

  internal bool HasParameterizedCreatorInternal
  {
    get
    {
      return this.HasParameterizedCreator || this._parameterizedCreator != null || this._parameterizedConstructor != (ConstructorInfo) null;
    }
  }

  [NullableContext(1)]
  public JsonDictionaryContract(Type underlyingType)
    : base(underlyingType)
  {
    this.ContractType = JsonContractType.Dictionary;
    Type keyType;
    Type valueType;
    if (ReflectionUtils.ImplementsGenericDefinition(this.NonNullableUnderlyingType, typeof (IDictionary<,>), out this._genericCollectionDefinitionType))
    {
      keyType = this._genericCollectionDefinitionType.GetGenericArguments()[0];
      valueType = this._genericCollectionDefinitionType.GetGenericArguments()[1];
      if (ReflectionUtils.IsGenericDefinition(this.NonNullableUnderlyingType, typeof (IDictionary<,>)))
        this.CreatedType = typeof (Dictionary<,>).MakeGenericType(keyType, valueType);
      else if (this.NonNullableUnderlyingType.IsGenericType() && this.NonNullableUnderlyingType.GetGenericTypeDefinition().FullName == "System.Collections.Concurrent.ConcurrentDictionary`2")
        this.ShouldCreateWrapper = true;
      this.IsReadOnlyOrFixedSize = ReflectionUtils.InheritsGenericDefinition(this.NonNullableUnderlyingType, typeof (ReadOnlyDictionary<,>));
    }
    else if (ReflectionUtils.ImplementsGenericDefinition(this.NonNullableUnderlyingType, typeof (IReadOnlyDictionary<,>), out this._genericCollectionDefinitionType))
    {
      keyType = this._genericCollectionDefinitionType.GetGenericArguments()[0];
      valueType = this._genericCollectionDefinitionType.GetGenericArguments()[1];
      if (ReflectionUtils.IsGenericDefinition(this.NonNullableUnderlyingType, typeof (IReadOnlyDictionary<,>)))
        this.CreatedType = typeof (ReadOnlyDictionary<,>).MakeGenericType(keyType, valueType);
      this.IsReadOnlyOrFixedSize = true;
    }
    else
    {
      ReflectionUtils.GetDictionaryKeyValueTypes(this.NonNullableUnderlyingType, out keyType, out valueType);
      if (this.NonNullableUnderlyingType == typeof (IDictionary))
        this.CreatedType = typeof (Dictionary<object, object>);
    }
    if (keyType != (Type) null && valueType != (Type) null)
    {
      this._parameterizedConstructor = CollectionUtils.ResolveEnumerableCollectionConstructor(this.CreatedType, typeof (KeyValuePair<,>).MakeGenericType(keyType, valueType), typeof (IDictionary<,>).MakeGenericType(keyType, valueType));
      if (!this.HasParameterizedCreatorInternal && this.NonNullableUnderlyingType.Name == "FSharpMap`2")
      {
        FSharpUtils.EnsureInitialized(this.NonNullableUnderlyingType.Assembly());
        this._parameterizedCreator = FSharpUtils.Instance.CreateMap(keyType, valueType);
      }
    }
    if (!typeof (IDictionary).IsAssignableFrom(this.CreatedType))
      this.ShouldCreateWrapper = true;
    this.DictionaryKeyType = keyType;
    this.DictionaryValueType = valueType;
    Type createdType;
    ObjectConstructor<object> parameterizedCreator;
    if (!(this.DictionaryKeyType != (Type) null) || !(this.DictionaryValueType != (Type) null) || !ImmutableCollectionsUtils.TryBuildImmutableForDictionaryContract(this.NonNullableUnderlyingType, this.DictionaryKeyType, this.DictionaryValueType, out createdType, out parameterizedCreator))
      return;
    this.CreatedType = createdType;
    this._parameterizedCreator = parameterizedCreator;
    this.IsReadOnlyOrFixedSize = true;
  }

  [NullableContext(1)]
  internal IWrappedDictionary CreateWrapper(object dictionary)
  {
    if (this._genericWrapperCreator == null)
    {
      this._genericWrapperType = typeof (DictionaryWrapper<,>).MakeGenericType(this.DictionaryKeyType, this.DictionaryValueType);
      this._genericWrapperCreator = JsonTypeReflector.ReflectionDelegateFactory.CreateParameterizedConstructor((MethodBase) this._genericWrapperType.GetConstructor(new Type[1]
      {
        this._genericCollectionDefinitionType
      }));
    }
    return (IWrappedDictionary) this._genericWrapperCreator(dictionary);
  }

  [NullableContext(1)]
  internal IDictionary CreateTemporaryDictionary()
  {
    if (this._genericTemporaryDictionaryCreator == null)
    {
      Type type1 = typeof (Dictionary<,>);
      Type[] typeArray = new Type[2];
      Type type2 = this.DictionaryKeyType;
      if ((object) type2 == null)
        type2 = typeof (object);
      typeArray[0] = type2;
      Type type3 = this.DictionaryValueType;
      if ((object) type3 == null)
        type3 = typeof (object);
      typeArray[1] = type3;
      this._genericTemporaryDictionaryCreator = JsonTypeReflector.ReflectionDelegateFactory.CreateDefaultConstructor<object>(type1.MakeGenericType(typeArray));
    }
    return (IDictionary) this._genericTemporaryDictionaryCreator();
  }
}
