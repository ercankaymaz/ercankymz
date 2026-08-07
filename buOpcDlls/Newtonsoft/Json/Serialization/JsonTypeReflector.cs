// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Serialization.JsonTypeReflector
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Newtonsoft.Json.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices.Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Security;
using System.Security.Permissions;

#nullable disable
namespace Newtonsoft.Json.Serialization;

[NullableContext(1)]
[Nullable(0)]
internal static class JsonTypeReflector
{
  private static bool? _dynamicCodeGeneration;
  private static bool? _fullyTrusted;
  public const string IdPropertyName = "$id";
  public const string RefPropertyName = "$ref";
  public const string TypePropertyName = "$type";
  public const string ValuePropertyName = "$value";
  public const string ArrayValuesPropertyName = "$values";
  public const string ShouldSerializePrefix = "ShouldSerialize";
  public const string SpecifiedPostfix = "Specified";
  public const string ConcurrentDictionaryTypeName = "System.Collections.Concurrent.ConcurrentDictionary`2";
  [Nullable(new byte[] {1, 1, 1, 2, 1, 1})]
  private static readonly ThreadSafeStore<Type, Func<object[], object>> CreatorCache = new ThreadSafeStore<Type, Func<object[], object>>(new Func<Type, Func<object[], object>>(JsonTypeReflector.GetCreator));
  [Nullable(new byte[] {1, 1, 2})]
  private static readonly ThreadSafeStore<Type, Type> AssociatedMetadataTypesCache = new ThreadSafeStore<Type, Type>(new Func<Type, Type>(JsonTypeReflector.GetAssociateMetadataTypeFromAttribute));
  [Nullable(2)]
  private static ReflectionObject _metadataTypeAttributeReflectionObject;

  [return: Nullable(2)]
  public static T GetCachedAttribute<[Nullable(0)] T>(object attributeProvider) where T : Attribute
  {
    return CachedAttributeGetter<T>.GetAttribute(attributeProvider);
  }

  public static bool CanTypeDescriptorConvertString(Type type, out TypeConverter typeConverter)
  {
    typeConverter = TypeDescriptor.GetConverter(type);
    if (typeConverter != null)
    {
      Type type1 = typeConverter.GetType();
      if (!string.Equals(type1.FullName, "System.ComponentModel.ComponentConverter", StringComparison.Ordinal) && !string.Equals(type1.FullName, "System.ComponentModel.ReferenceConverter", StringComparison.Ordinal) && !string.Equals(type1.FullName, "System.Windows.Forms.Design.DataSourceConverter", StringComparison.Ordinal) && type1 != typeof (TypeConverter))
        return typeConverter.CanConvertTo(typeof (string));
    }
    return false;
  }

  [return: Nullable(2)]
  public static DataContractAttribute GetDataContractAttribute(Type type)
  {
    for (Type type1 = type; type1 != (Type) null; type1 = type1.BaseType())
    {
      DataContractAttribute attribute = CachedAttributeGetter<DataContractAttribute>.GetAttribute((object) type1);
      if (attribute != null)
        return attribute;
    }
    return (DataContractAttribute) null;
  }

  [return: Nullable(2)]
  public static DataMemberAttribute GetDataMemberAttribute(MemberInfo memberInfo)
  {
    if (memberInfo.MemberType() == MemberTypes.Field)
      return CachedAttributeGetter<DataMemberAttribute>.GetAttribute((object) memberInfo);
    PropertyInfo propertyInfo = (PropertyInfo) memberInfo;
    DataMemberAttribute attribute = CachedAttributeGetter<DataMemberAttribute>.GetAttribute((object) propertyInfo);
    if (attribute == null && propertyInfo.IsVirtual())
    {
      for (Type type = propertyInfo.DeclaringType; attribute == null && type != (Type) null; type = type.BaseType())
      {
        PropertyInfo memberInfoFromType = (PropertyInfo) ReflectionUtils.GetMemberInfoFromType(type, (MemberInfo) propertyInfo);
        if (memberInfoFromType != (PropertyInfo) null && memberInfoFromType.IsVirtual())
          attribute = CachedAttributeGetter<DataMemberAttribute>.GetAttribute((object) memberInfoFromType);
      }
    }
    return attribute;
  }

  public static MemberSerialization GetObjectMemberSerialization(
    Type objectType,
    bool ignoreSerializableAttribute)
  {
    JsonObjectAttribute cachedAttribute = JsonTypeReflector.GetCachedAttribute<JsonObjectAttribute>((object) objectType);
    if (cachedAttribute != null)
      return cachedAttribute.MemberSerialization;
    if (JsonTypeReflector.GetDataContractAttribute(objectType) != null)
      return MemberSerialization.OptIn;
    return !ignoreSerializableAttribute && JsonTypeReflector.IsSerializable((object) objectType) ? MemberSerialization.Fields : MemberSerialization.OptOut;
  }

  [return: Nullable(2)]
  public static JsonConverter GetJsonConverter(object attributeProvider)
  {
    JsonConverterAttribute cachedAttribute = JsonTypeReflector.GetCachedAttribute<JsonConverterAttribute>(attributeProvider);
    if (cachedAttribute != null)
    {
      Func<object[], object> func = JsonTypeReflector.CreatorCache.Get(cachedAttribute.ConverterType);
      if (func != null)
        return (JsonConverter) func(cachedAttribute.ConverterParameters);
    }
    return (JsonConverter) null;
  }

  public static JsonConverter CreateJsonConverterInstance(Type converterType, [Nullable(new byte[] {2, 1})] object[] args)
  {
    return (JsonConverter) JsonTypeReflector.CreatorCache.Get(converterType)(args);
  }

  public static NamingStrategy CreateNamingStrategyInstance(Type namingStrategyType, [Nullable(new byte[] {2, 1})] object[] args)
  {
    return (NamingStrategy) JsonTypeReflector.CreatorCache.Get(namingStrategyType)(args);
  }

  [return: Nullable(2)]
  public static NamingStrategy GetContainerNamingStrategy(JsonContainerAttribute containerAttribute)
  {
    if (containerAttribute.NamingStrategyInstance == null)
    {
      if (containerAttribute.NamingStrategyType == (Type) null)
        return (NamingStrategy) null;
      containerAttribute.NamingStrategyInstance = JsonTypeReflector.CreateNamingStrategyInstance(containerAttribute.NamingStrategyType, containerAttribute.NamingStrategyParameters);
    }
    return containerAttribute.NamingStrategyInstance;
  }

  [return: Nullable(new byte[] {1, 2, 1, 1})]
  private static Func<object[], object> GetCreator(Type type)
  {
    Func<object> defaultConstructor = ReflectionUtils.HasDefaultConstructor(type, false) ? JsonTypeReflector.ReflectionDelegateFactory.CreateDefaultConstructor<object>(type) : (Func<object>) null;
    return (Func<object[], object>) (([Nullable(new byte[] {2, 1})] parameters) =>
    {
      try
      {
        if (parameters != null)
        {
          ConstructorInfo constructor = type.GetConstructor(((IEnumerable<object>) parameters).Select<object, Type>((Func<object, Type>) ([NullableContext(0)] (param) =>
          {
            return param != null ? param.GetType() : throw new InvalidOperationException("Cannot pass a null parameter to the constructor.");
          })).ToArray<Type>());
          if (constructor != (ConstructorInfo) null)
            return JsonTypeReflector.ReflectionDelegateFactory.CreateParameterizedConstructor((MethodBase) constructor)(parameters);
          throw new JsonException("No matching parameterized constructor found for '{0}'.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) type));
        }
        if (defaultConstructor == null)
          throw new JsonException("No parameterless constructor defined for '{0}'.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) type));
        return defaultConstructor();
      }
      catch (Exception ex)
      {
        throw new JsonException("Error creating '{0}'.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) type), ex);
      }
    });
  }

  [return: Nullable(2)]
  private static Type GetAssociatedMetadataType(Type type)
  {
    return JsonTypeReflector.AssociatedMetadataTypesCache.Get(type);
  }

  [return: Nullable(2)]
  private static Type GetAssociateMetadataTypeFromAttribute(Type type)
  {
    foreach (Attribute attribute in ReflectionUtils.GetAttributes((object) type, (Type) null, true))
    {
      Type type1 = attribute.GetType();
      if (string.Equals(type1.FullName, "System.ComponentModel.DataAnnotations.MetadataTypeAttribute", StringComparison.Ordinal))
      {
        if (JsonTypeReflector._metadataTypeAttributeReflectionObject == null)
          JsonTypeReflector._metadataTypeAttributeReflectionObject = ReflectionObject.Create(type1, "MetadataClassType");
        return (Type) JsonTypeReflector._metadataTypeAttributeReflectionObject.GetValue((object) attribute, "MetadataClassType");
      }
    }
    return (Type) null;
  }

  [return: Nullable(2)]
  private static T GetAttribute<[Nullable(0)] T>(Type type) where T : Attribute
  {
    Type associatedMetadataType = JsonTypeReflector.GetAssociatedMetadataType(type);
    if (associatedMetadataType != (Type) null)
    {
      T attribute = ReflectionUtils.GetAttribute<T>((object) associatedMetadataType, true);
      if ((object) attribute != null)
        return attribute;
    }
    T attribute1 = ReflectionUtils.GetAttribute<T>((object) type, true);
    if ((object) attribute1 != null)
      return attribute1;
    foreach (object attributeProvider in type.GetInterfaces())
    {
      T attribute2 = ReflectionUtils.GetAttribute<T>(attributeProvider, true);
      if ((object) attribute2 != null)
        return attribute2;
    }
    return default (T);
  }

  [return: Nullable(2)]
  private static T GetAttribute<[Nullable(0)] T>(MemberInfo memberInfo) where T : Attribute
  {
    Type associatedMetadataType = JsonTypeReflector.GetAssociatedMetadataType(memberInfo.DeclaringType);
    if (associatedMetadataType != (Type) null)
    {
      MemberInfo memberInfoFromType = ReflectionUtils.GetMemberInfoFromType(associatedMetadataType, memberInfo);
      if (memberInfoFromType != (MemberInfo) null)
      {
        T attribute = ReflectionUtils.GetAttribute<T>((object) memberInfoFromType, true);
        if ((object) attribute != null)
          return attribute;
      }
    }
    T attribute1 = ReflectionUtils.GetAttribute<T>((object) memberInfo, true);
    if ((object) attribute1 != null)
      return attribute1;
    if (memberInfo.DeclaringType != (Type) null)
    {
      foreach (Type targetType in memberInfo.DeclaringType.GetInterfaces())
      {
        MemberInfo memberInfoFromType = ReflectionUtils.GetMemberInfoFromType(targetType, memberInfo);
        if (memberInfoFromType != (MemberInfo) null)
        {
          T attribute2 = ReflectionUtils.GetAttribute<T>((object) memberInfoFromType, true);
          if ((object) attribute2 != null)
            return attribute2;
        }
      }
    }
    return default (T);
  }

  public static bool IsNonSerializable(object provider)
  {
    return ReflectionUtils.GetAttribute<NonSerializedAttribute>(provider, false) != null;
  }

  public static bool IsSerializable(object provider)
  {
    return ReflectionUtils.GetAttribute<SerializableAttribute>(provider, false) != null;
  }

  [return: Nullable(2)]
  public static T GetAttribute<[Nullable(0)] T>(object provider) where T : Attribute
  {
    Type type = provider as Type;
    if ((object) type != null)
      return JsonTypeReflector.GetAttribute<T>(type);
    MemberInfo memberInfo = provider as MemberInfo;
    return (object) memberInfo != null ? JsonTypeReflector.GetAttribute<T>(memberInfo) : ReflectionUtils.GetAttribute<T>(provider, true);
  }

  public static bool DynamicCodeGeneration
  {
    [SecuritySafeCritical] get
    {
      if (!JsonTypeReflector._dynamicCodeGeneration.HasValue)
      {
        try
        {
          new ReflectionPermission(ReflectionPermissionFlag.MemberAccess).Demand();
          new ReflectionPermission(ReflectionPermissionFlag.RestrictedMemberAccess).Demand();
          new SecurityPermission(SecurityPermissionFlag.SkipVerification).Demand();
          new SecurityPermission(SecurityPermissionFlag.UnmanagedCode).Demand();
          new SecurityPermission(PermissionState.Unrestricted).Demand();
          JsonTypeReflector._dynamicCodeGeneration = new bool?(true);
        }
        catch (Exception ex)
        {
          JsonTypeReflector._dynamicCodeGeneration = new bool?(false);
        }
      }
      return JsonTypeReflector._dynamicCodeGeneration.GetValueOrDefault();
    }
  }

  public static bool FullyTrusted
  {
    get
    {
      if (!JsonTypeReflector._fullyTrusted.HasValue)
      {
        AppDomain currentDomain = AppDomain.CurrentDomain;
        JsonTypeReflector._fullyTrusted = new bool?(currentDomain.IsHomogenous && currentDomain.IsFullyTrusted);
      }
      return JsonTypeReflector._fullyTrusted.GetValueOrDefault();
    }
  }

  public static ReflectionDelegateFactory ReflectionDelegateFactory
  {
    get
    {
      return JsonTypeReflector.DynamicCodeGeneration ? (ReflectionDelegateFactory) DynamicReflectionDelegateFactory.Instance : LateBoundReflectionDelegateFactory.Instance;
    }
  }
}
