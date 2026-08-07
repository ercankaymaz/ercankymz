// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Utilities.ReflectionUtils
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Newtonsoft.Json.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis.Newtonsoft.Json1494283;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices.Newtonsoft.Json;
using System.Text;

#nullable disable
namespace Newtonsoft.Json.Utilities;

[NullableContext(1)]
[Nullable(0)]
internal static class ReflectionUtils
{
  public static readonly Type[] EmptyTypes = Type.EmptyTypes;

  public static bool IsVirtual(this PropertyInfo propertyInfo)
  {
    ValidationUtils.ArgumentNotNull((object) propertyInfo, nameof (propertyInfo));
    MethodInfo getMethod = propertyInfo.GetGetMethod(true);
    if (getMethod != (MethodInfo) null && getMethod.IsVirtual)
      return true;
    MethodInfo setMethod = propertyInfo.GetSetMethod(true);
    return setMethod != (MethodInfo) null && setMethod.IsVirtual;
  }

  [return: Nullable(2)]
  public static MethodInfo GetBaseDefinition(this PropertyInfo propertyInfo)
  {
    ValidationUtils.ArgumentNotNull((object) propertyInfo, nameof (propertyInfo));
    MethodInfo getMethod = propertyInfo.GetGetMethod(true);
    if (getMethod != (MethodInfo) null)
      return getMethod.GetBaseDefinition();
    return propertyInfo.GetSetMethod(true)?.GetBaseDefinition();
  }

  public static bool IsPublic(PropertyInfo property)
  {
    MethodInfo getMethod = property.GetGetMethod();
    if (getMethod != (MethodInfo) null && getMethod.IsPublic)
      return true;
    MethodInfo setMethod = property.GetSetMethod();
    return setMethod != (MethodInfo) null && setMethod.IsPublic;
  }

  [NullableContext(2)]
  public static Type GetObjectType(object v) => v?.GetType();

  public static string GetTypeName(
    Type t,
    TypeNameAssemblyFormatHandling assemblyFormat,
    [Nullable(2)] ISerializationBinder binder)
  {
    string qualifiedTypeName = ReflectionUtils.GetFullyQualifiedTypeName(t, binder);
    if (assemblyFormat == TypeNameAssemblyFormatHandling.Simple)
      return ReflectionUtils.RemoveAssemblyDetails(qualifiedTypeName);
    if (assemblyFormat != TypeNameAssemblyFormatHandling.Full)
      throw new ArgumentOutOfRangeException();
    return qualifiedTypeName;
  }

  private static string GetFullyQualifiedTypeName(Type t, [Nullable(2)] ISerializationBinder binder)
  {
    if (binder == null)
      return t.AssemblyQualifiedName;
    string assemblyName;
    string typeName;
    binder.BindToName(t, out assemblyName, out typeName);
    return typeName + (assemblyName == null ? "" : ", " + assemblyName);
  }

  private static string RemoveAssemblyDetails(string fullyQualifiedTypeName)
  {
    StringBuilder stringBuilder = new StringBuilder();
    bool flag1 = false;
    bool flag2 = false;
    bool flag3 = false;
    for (int index = 0; index < fullyQualifiedTypeName.Length; ++index)
    {
      char ch = fullyQualifiedTypeName[index];
      switch (ch)
      {
        case ',':
          if (flag3)
          {
            stringBuilder.Append(ch);
            break;
          }
          if (!flag1)
          {
            flag1 = true;
            stringBuilder.Append(ch);
            break;
          }
          flag2 = true;
          break;
        case '[':
          flag1 = false;
          flag2 = false;
          flag3 = true;
          stringBuilder.Append(ch);
          break;
        case ']':
          flag1 = false;
          flag2 = false;
          flag3 = false;
          stringBuilder.Append(ch);
          break;
        default:
          flag3 = false;
          if (!flag2)
          {
            stringBuilder.Append(ch);
            break;
          }
          break;
      }
    }
    return stringBuilder.ToString();
  }

  public static bool HasDefaultConstructor(Type t, bool nonPublic)
  {
    ValidationUtils.ArgumentNotNull((object) t, nameof (t));
    return t.IsValueType() || ReflectionUtils.GetDefaultConstructor(t, nonPublic) != (ConstructorInfo) null;
  }

  [return: Nullable(2)]
  public static ConstructorInfo GetDefaultConstructor(Type t)
  {
    return ReflectionUtils.GetDefaultConstructor(t, false);
  }

  [return: Nullable(2)]
  public static ConstructorInfo GetDefaultConstructor(Type t, bool nonPublic)
  {
    BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.Public;
    if (nonPublic)
      bindingAttr |= BindingFlags.NonPublic;
    return ((IEnumerable<ConstructorInfo>) t.GetConstructors(bindingAttr)).SingleOrDefault<ConstructorInfo>((Func<ConstructorInfo, bool>) ([NullableContext(0)] (c) => !((IEnumerable<ParameterInfo>) c.GetParameters()).Any<ParameterInfo>()));
  }

  public static bool IsNullable(Type t)
  {
    ValidationUtils.ArgumentNotNull((object) t, nameof (t));
    return !t.IsValueType() || ReflectionUtils.IsNullableType(t);
  }

  public static bool IsNullableType(Type t)
  {
    ValidationUtils.ArgumentNotNull((object) t, nameof (t));
    return t.IsGenericType() && t.GetGenericTypeDefinition() == typeof (Nullable<>);
  }

  public static Type EnsureNotNullableType(Type t)
  {
    return !ReflectionUtils.IsNullableType(t) ? t : Nullable.GetUnderlyingType(t);
  }

  public static Type EnsureNotByRefType(Type t)
  {
    return t.IsByRef && t.HasElementType ? t.GetElementType() : t;
  }

  public static bool IsGenericDefinition(Type type, Type genericInterfaceDefinition)
  {
    return type.IsGenericType() && type.GetGenericTypeDefinition() == genericInterfaceDefinition;
  }

  public static bool ImplementsGenericDefinition(Type type, Type genericInterfaceDefinition)
  {
    return ReflectionUtils.ImplementsGenericDefinition(type, genericInterfaceDefinition, out Type _);
  }

  public static bool ImplementsGenericDefinition(
    Type type,
    Type genericInterfaceDefinition,
    [Nullable(2), NotNullWhen(true)] out Type implementingType)
  {
    ValidationUtils.ArgumentNotNull((object) type, nameof (type));
    ValidationUtils.ArgumentNotNull((object) genericInterfaceDefinition, nameof (genericInterfaceDefinition));
    if (!genericInterfaceDefinition.IsInterface() || !genericInterfaceDefinition.IsGenericTypeDefinition())
      throw new ArgumentNullException("'{0}' is not a generic interface definition.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) genericInterfaceDefinition));
    if (type.IsInterface() && type.IsGenericType())
    {
      Type genericTypeDefinition = type.GetGenericTypeDefinition();
      if (genericInterfaceDefinition == genericTypeDefinition)
      {
        implementingType = type;
        return true;
      }
    }
    foreach (Type type1 in type.GetInterfaces())
    {
      if (type1.IsGenericType())
      {
        Type genericTypeDefinition = type1.GetGenericTypeDefinition();
        if (genericInterfaceDefinition == genericTypeDefinition)
        {
          implementingType = type1;
          return true;
        }
      }
    }
    implementingType = (Type) null;
    return false;
  }

  public static bool InheritsGenericDefinition(Type type, Type genericClassDefinition)
  {
    return ReflectionUtils.InheritsGenericDefinition(type, genericClassDefinition, out Type _);
  }

  public static bool InheritsGenericDefinition(
    Type type,
    Type genericClassDefinition,
    [Nullable(2)] out Type implementingType)
  {
    ValidationUtils.ArgumentNotNull((object) type, nameof (type));
    ValidationUtils.ArgumentNotNull((object) genericClassDefinition, nameof (genericClassDefinition));
    return genericClassDefinition.IsClass() && genericClassDefinition.IsGenericTypeDefinition() ? ReflectionUtils.InheritsGenericDefinitionInternal(type, genericClassDefinition, out implementingType) : throw new ArgumentNullException("'{0}' is not a generic class definition.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) genericClassDefinition));
  }

  private static bool InheritsGenericDefinitionInternal(
    Type type,
    Type genericClassDefinition,
    [Nullable(2)] out Type implementingType)
  {
    Type type1 = type;
    while (!type1.IsGenericType() || !(genericClassDefinition == type1.GetGenericTypeDefinition()))
    {
      type1 = type1.BaseType();
      if (!(type1 != (Type) null))
      {
        implementingType = (Type) null;
        return false;
      }
    }
    implementingType = type1;
    return true;
  }

  [return: Nullable(2)]
  public static Type GetCollectionItemType(Type type)
  {
    ValidationUtils.ArgumentNotNull((object) type, nameof (type));
    if (type.IsArray)
      return type.GetElementType();
    Type implementingType;
    if (ReflectionUtils.ImplementsGenericDefinition(type, typeof (IEnumerable<>), out implementingType))
      return !implementingType.IsGenericTypeDefinition() ? implementingType.GetGenericArguments()[0] : throw new Exception("Type {0} is not a collection.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) type));
    if (!typeof (IEnumerable).IsAssignableFrom(type))
      throw new Exception("Type {0} is not a collection.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) type));
    return (Type) null;
  }

  [NullableContext(2)]
  public static void GetDictionaryKeyValueTypes(
    [Nullable(1)] Type dictionaryType,
    out Type keyType,
    out Type valueType)
  {
    ValidationUtils.ArgumentNotNull((object) dictionaryType, nameof (dictionaryType));
    Type implementingType;
    if (ReflectionUtils.ImplementsGenericDefinition(dictionaryType, typeof (IDictionary<,>), out implementingType))
    {
      Type[] typeArray = !implementingType.IsGenericTypeDefinition() ? implementingType.GetGenericArguments() : throw new Exception("Type {0} is not a dictionary.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) dictionaryType));
      keyType = typeArray[0];
      valueType = typeArray[1];
    }
    else
    {
      if (!typeof (IDictionary).IsAssignableFrom(dictionaryType))
        throw new Exception("Type {0} is not a dictionary.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) dictionaryType));
      keyType = (Type) null;
      valueType = (Type) null;
    }
  }

  public static Type GetMemberUnderlyingType(MemberInfo member)
  {
    ValidationUtils.ArgumentNotNull((object) member, nameof (member));
    switch (member.MemberType())
    {
      case MemberTypes.Event:
        return ((EventInfo) member).EventHandlerType;
      case MemberTypes.Field:
        return ((FieldInfo) member).FieldType;
      case MemberTypes.Method:
        return ((MethodInfo) member).ReturnType;
      case MemberTypes.Property:
        return ((PropertyInfo) member).PropertyType;
      default:
        throw new ArgumentException("MemberInfo must be of type FieldInfo, PropertyInfo, EventInfo or MethodInfo", nameof (member));
    }
  }

  public static bool IsByRefLikeType(Type type)
  {
    if (!type.IsValueType())
      return false;
    foreach (object attribute in ReflectionUtils.GetAttributes((object) type, (Type) null, false))
    {
      if (string.Equals(attribute.GetType().FullName, "System.Runtime.CompilerServices.IsByRefLikeAttribute", StringComparison.Ordinal))
        return true;
    }
    return false;
  }

  public static bool IsIndexedProperty(PropertyInfo property)
  {
    ValidationUtils.ArgumentNotNull((object) property, nameof (property));
    return property.GetIndexParameters().Length != 0;
  }

  [return: Nullable(2)]
  public static object GetMemberValue(MemberInfo member, object target)
  {
    ValidationUtils.ArgumentNotNull((object) member, nameof (member));
    ValidationUtils.ArgumentNotNull(target, nameof (target));
    switch (member.MemberType())
    {
      case MemberTypes.Field:
        return ((FieldInfo) member).GetValue(target);
      case MemberTypes.Property:
        try
        {
          return ((PropertyInfo) member).GetValue(target, (object[]) null);
        }
        catch (TargetParameterCountException ex)
        {
          throw new ArgumentException("MemberInfo '{0}' has index parameters".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) member.Name), (Exception) ex);
        }
      default:
        throw new ArgumentException("MemberInfo '{0}' is not of type FieldInfo or PropertyInfo".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) member.Name), nameof (member));
    }
  }

  public static void SetMemberValue(MemberInfo member, object target, [Nullable(2)] object value)
  {
    ValidationUtils.ArgumentNotNull((object) member, nameof (member));
    ValidationUtils.ArgumentNotNull(target, nameof (target));
    switch (member.MemberType())
    {
      case MemberTypes.Field:
        ((FieldInfo) member).SetValue(target, value);
        break;
      case MemberTypes.Property:
        ((PropertyInfo) member).SetValue(target, value, (object[]) null);
        break;
      default:
        throw new ArgumentException("MemberInfo '{0}' must be of type FieldInfo or PropertyInfo".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) member.Name), nameof (member));
    }
  }

  public static bool CanReadMemberValue(MemberInfo member, bool nonPublic)
  {
    switch (member.MemberType())
    {
      case MemberTypes.Field:
        FieldInfo fieldInfo = (FieldInfo) member;
        return nonPublic || fieldInfo.IsPublic;
      case MemberTypes.Property:
        PropertyInfo propertyInfo = (PropertyInfo) member;
        if (!propertyInfo.CanRead)
          return false;
        return nonPublic || propertyInfo.GetGetMethod(nonPublic) != (MethodInfo) null;
      default:
        return false;
    }
  }

  public static bool CanSetMemberValue(MemberInfo member, bool nonPublic, bool canSetReadOnly)
  {
    switch (member.MemberType())
    {
      case MemberTypes.Field:
        FieldInfo fieldInfo = (FieldInfo) member;
        return !fieldInfo.IsLiteral && (!fieldInfo.IsInitOnly || canSetReadOnly) && (nonPublic || fieldInfo.IsPublic);
      case MemberTypes.Property:
        PropertyInfo propertyInfo = (PropertyInfo) member;
        if (!propertyInfo.CanWrite)
          return false;
        return nonPublic || propertyInfo.GetSetMethod(nonPublic) != (MethodInfo) null;
      default:
        return false;
    }
  }

  public static List<MemberInfo> GetFieldsAndProperties(Type type, BindingFlags bindingAttr)
  {
    List<MemberInfo> source1 = new List<MemberInfo>();
    source1.AddRange((IEnumerable<MemberInfo>) ReflectionUtils.GetFields(type, bindingAttr));
    source1.AddRange((IEnumerable<MemberInfo>) ReflectionUtils.GetProperties(type, bindingAttr));
    List<MemberInfo> fieldsAndProperties = new List<MemberInfo>(source1.Count);
    foreach (IGrouping<string, MemberInfo> source2 in source1.GroupBy<MemberInfo, string>((Func<MemberInfo, string>) ([NullableContext(0)] (m) => m.Name)))
    {
      if (source2.Count<MemberInfo>() == 1)
      {
        fieldsAndProperties.Add(source2.First<MemberInfo>());
      }
      else
      {
        List<MemberInfo> memberInfoList = new List<MemberInfo>();
        foreach (MemberInfo memberInfo1 in (IEnumerable<MemberInfo>) source2)
        {
          MemberInfo memberInfo = memberInfo1;
          if (memberInfoList.Count == 0)
            memberInfoList.Add(memberInfo);
          else if ((!ReflectionUtils.IsOverridenGenericMember(memberInfo, bindingAttr) || memberInfo.Name == "Item") && !memberInfoList.Any<MemberInfo>((Func<MemberInfo, bool>) ([NullableContext(0)] (m) => m.DeclaringType == memberInfo.DeclaringType)))
            memberInfoList.Add(memberInfo);
        }
        fieldsAndProperties.AddRange((IEnumerable<MemberInfo>) memberInfoList);
      }
    }
    return fieldsAndProperties;
  }

  private static bool IsOverridenGenericMember(MemberInfo memberInfo, BindingFlags bindingAttr)
  {
    if (memberInfo.MemberType() != MemberTypes.Property)
      return false;
    PropertyInfo propertyInfo = (PropertyInfo) memberInfo;
    if (!propertyInfo.IsVirtual())
      return false;
    Type declaringType = propertyInfo.DeclaringType;
    if (!declaringType.IsGenericType())
      return false;
    Type genericTypeDefinition = declaringType.GetGenericTypeDefinition();
    if (genericTypeDefinition == (Type) null)
      return false;
    MemberInfo[] member = genericTypeDefinition.GetMember(propertyInfo.Name, bindingAttr);
    return member.Length != 0 && ReflectionUtils.GetMemberUnderlyingType(member[0]).IsGenericParameter;
  }

  [return: Nullable(2)]
  public static T GetAttribute<[Nullable(0)] T>(object attributeProvider) where T : Attribute
  {
    return ReflectionUtils.GetAttribute<T>(attributeProvider, true);
  }

  [return: Nullable(2)]
  public static T GetAttribute<[Nullable(0)] T>(object attributeProvider, bool inherit) where T : Attribute
  {
    T[] attributes = ReflectionUtils.GetAttributes<T>(attributeProvider, inherit);
    return attributes == null ? default (T) : ((IEnumerable<T>) attributes).FirstOrDefault<T>();
  }

  public static T[] GetAttributes<[Nullable(0)] T>(object attributeProvider, bool inherit) where T : Attribute
  {
    Attribute[] attributes = ReflectionUtils.GetAttributes(attributeProvider, typeof (T), inherit);
    return attributes is T[] objArray ? objArray : attributes.Cast<T>().ToArray<T>();
  }

  public static Attribute[] GetAttributes(
    object attributeProvider,
    [Nullable(2)] Type attributeType,
    bool inherit)
  {
    ValidationUtils.ArgumentNotNull(attributeProvider, nameof (attributeProvider));
    object obj = attributeProvider;
    Type type = obj as Type;
    if ((object) type != null)
      return (attributeType != (Type) null ? (IEnumerable) type.GetCustomAttributes(attributeType, inherit) : (IEnumerable) type.GetCustomAttributes(inherit)).Cast<Attribute>().ToArray<Attribute>();
    Assembly element1 = obj as Assembly;
    if ((object) element1 == null)
    {
      MemberInfo element2 = obj as MemberInfo;
      if ((object) element2 == null)
      {
        Module element3 = obj as Module;
        if ((object) element3 == null)
        {
          if (!(obj is ParameterInfo element4))
          {
            ICustomAttributeProvider attributeProvider1 = (ICustomAttributeProvider) attributeProvider;
            return attributeType != (Type) null ? (Attribute[]) attributeProvider1.GetCustomAttributes(attributeType, inherit) : (Attribute[]) attributeProvider1.GetCustomAttributes(inherit);
          }
          return !(attributeType != (Type) null) ? Attribute.GetCustomAttributes(element4, inherit) : Attribute.GetCustomAttributes(element4, attributeType, inherit);
        }
        return !(attributeType != (Type) null) ? Attribute.GetCustomAttributes(element3, inherit) : Attribute.GetCustomAttributes(element3, attributeType, inherit);
      }
      return !(attributeType != (Type) null) ? Attribute.GetCustomAttributes(element2, inherit) : Attribute.GetCustomAttributes(element2, attributeType, inherit);
    }
    return !(attributeType != (Type) null) ? Attribute.GetCustomAttributes(element1) : Attribute.GetCustomAttributes(element1, attributeType);
  }

  [return: Nullable(new byte[] {0, 2, 1})]
  public static StructMultiKey<string, string> SplitFullyQualifiedTypeName(
    string fullyQualifiedTypeName)
  {
    int? assemblyDelimiterIndex = ReflectionUtils.GetAssemblyDelimiterIndex(fullyQualifiedTypeName);
    string v2;
    string v1;
    if (assemblyDelimiterIndex.HasValue)
    {
      v2 = fullyQualifiedTypeName.Trim(0, assemblyDelimiterIndex.GetValueOrDefault());
      v1 = fullyQualifiedTypeName.Trim(assemblyDelimiterIndex.GetValueOrDefault() + 1, fullyQualifiedTypeName.Length - assemblyDelimiterIndex.GetValueOrDefault() - 1);
    }
    else
    {
      v2 = fullyQualifiedTypeName;
      v1 = (string) null;
    }
    return new StructMultiKey<string, string>(v1, v2);
  }

  private static int? GetAssemblyDelimiterIndex(string fullyQualifiedTypeName)
  {
    int num = 0;
    for (int index = 0; index < fullyQualifiedTypeName.Length; ++index)
    {
      switch (fullyQualifiedTypeName[index])
      {
        case ',':
          if (num == 0)
            return new int?(index);
          break;
        case '[':
          ++num;
          break;
        case ']':
          --num;
          break;
      }
    }
    return new int?();
  }

  [return: Nullable(2)]
  public static MemberInfo GetMemberInfoFromType(Type targetType, MemberInfo memberInfo)
  {
    if (memberInfo.MemberType() != MemberTypes.Property)
      return ((IEnumerable<MemberInfo>) targetType.GetMember(memberInfo.Name, memberInfo.MemberType(), BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)).SingleOrDefault<MemberInfo>();
    PropertyInfo propertyInfo = (PropertyInfo) memberInfo;
    Type[] array = ((IEnumerable<ParameterInfo>) propertyInfo.GetIndexParameters()).Select<ParameterInfo, Type>((Func<ParameterInfo, Type>) ([NullableContext(0)] (p) => p.ParameterType)).ToArray<Type>();
    return (MemberInfo) targetType.GetProperty(propertyInfo.Name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, (Binder) null, propertyInfo.PropertyType, array, (ParameterModifier[]) null);
  }

  public static IEnumerable<FieldInfo> GetFields(Type targetType, BindingFlags bindingAttr)
  {
    ValidationUtils.ArgumentNotNull((object) targetType, nameof (targetType));
    List<MemberInfo> memberInfoList = new List<MemberInfo>((IEnumerable<MemberInfo>) targetType.GetFields(bindingAttr));
    ReflectionUtils.GetChildPrivateFields((IList<MemberInfo>) memberInfoList, targetType, bindingAttr);
    return memberInfoList.Cast<FieldInfo>();
  }

  private static void GetChildPrivateFields(
    IList<MemberInfo> initialFields,
    Type type,
    BindingFlags bindingAttr)
  {
    Type type1 = type;
    if ((bindingAttr & BindingFlags.NonPublic) == BindingFlags.Default)
      return;
    BindingFlags bindingAttr1 = bindingAttr.RemoveFlag(BindingFlags.Public);
    while ((type1 = type1.BaseType()) != (Type) null)
    {
      IEnumerable<FieldInfo> collection = ((IEnumerable<FieldInfo>) type1.GetFields(bindingAttr1)).Where<FieldInfo>((Func<FieldInfo, bool>) ([NullableContext(0)] (f) => f.IsPrivate));
      initialFields.AddRange<MemberInfo>((IEnumerable<MemberInfo>) collection);
    }
  }

  public static IEnumerable<PropertyInfo> GetProperties(Type targetType, BindingFlags bindingAttr)
  {
    ValidationUtils.ArgumentNotNull((object) targetType, nameof (targetType));
    List<PropertyInfo> initialProperties = new List<PropertyInfo>((IEnumerable<PropertyInfo>) targetType.GetProperties(bindingAttr));
    if (targetType.IsInterface())
    {
      foreach (Type type in targetType.GetInterfaces())
        initialProperties.AddRange((IEnumerable<PropertyInfo>) type.GetProperties(bindingAttr));
    }
    ReflectionUtils.GetChildPrivateProperties((IList<PropertyInfo>) initialProperties, targetType, bindingAttr);
    for (int index = 0; index < initialProperties.Count; ++index)
    {
      PropertyInfo propertyInfo = initialProperties[index];
      if (propertyInfo.DeclaringType != targetType)
      {
        PropertyInfo memberInfoFromType = (PropertyInfo) ReflectionUtils.GetMemberInfoFromType(propertyInfo.DeclaringType, (MemberInfo) propertyInfo);
        initialProperties[index] = memberInfoFromType;
      }
    }
    return (IEnumerable<PropertyInfo>) initialProperties;
  }

  public static BindingFlags RemoveFlag(this BindingFlags bindingAttr, BindingFlags flag)
  {
    return (bindingAttr & flag) != flag ? bindingAttr : bindingAttr ^ flag;
  }

  private static void GetChildPrivateProperties(
    IList<PropertyInfo> initialProperties,
    Type type,
    BindingFlags bindingAttr)
  {
    Type type1 = type;
    while ((type1 = type1.BaseType()) != (Type) null)
    {
      foreach (PropertyInfo property in type1.GetProperties(bindingAttr))
      {
        PropertyInfo subTypeProperty = property;
        if (!subTypeProperty.IsVirtual())
        {
          if (!ReflectionUtils.IsPublic(subTypeProperty))
          {
            int index = initialProperties.IndexOf<PropertyInfo>((Func<PropertyInfo, bool>) ([NullableContext(0)] (p) => p.Name == subTypeProperty.Name));
            if (index == -1)
              initialProperties.Add(subTypeProperty);
            else if (!ReflectionUtils.IsPublic(initialProperties[index]))
              initialProperties[index] = subTypeProperty;
          }
          else if (initialProperties.IndexOf<PropertyInfo>((Func<PropertyInfo, bool>) ([NullableContext(0)] (p) => p.Name == subTypeProperty.Name && p.DeclaringType == subTypeProperty.DeclaringType)) == -1)
            initialProperties.Add(subTypeProperty);
        }
        else
        {
          MethodInfo baseDefinition1 = subTypeProperty.GetBaseDefinition();
          Type type2;
          if ((object) baseDefinition1 == null)
          {
            type2 = (Type) null;
          }
          else
          {
            type2 = baseDefinition1.DeclaringType;
            if ((object) type2 != null)
              goto label_14;
          }
          type2 = subTypeProperty.DeclaringType;
label_14:
          Type subTypePropertyDeclaringType = type2;
          if (initialProperties.IndexOf<PropertyInfo>((Func<PropertyInfo, bool>) ([NullableContext(0)] (p) =>
          {
            if (!(p.Name == subTypeProperty.Name) || !p.IsVirtual())
              return false;
            MethodInfo baseDefinition2 = p.GetBaseDefinition();
            Type type3;
            if ((object) baseDefinition2 == null)
            {
              type3 = (Type) null;
            }
            else
            {
              type3 = baseDefinition2.DeclaringType;
              if ((object) type3 != null)
                goto label_5;
            }
            type3 = p.DeclaringType;
label_5:
            return type3.IsAssignableFrom(subTypePropertyDeclaringType);
          })) == -1)
            initialProperties.Add(subTypeProperty);
        }
      }
    }
  }

  public static bool IsMethodOverridden(Type currentType, Type methodDeclaringType, string method)
  {
    return ((IEnumerable<MethodInfo>) currentType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)).Any<MethodInfo>((Func<MethodInfo, bool>) ([NullableContext(0)] (info) => info.Name == method && info.DeclaringType != methodDeclaringType && info.GetBaseDefinition().DeclaringType == methodDeclaringType));
  }

  [return: Nullable(2)]
  public static object GetDefaultValue(Type type)
  {
    if (!type.IsValueType())
      return (object) null;
    switch (ConvertUtils.GetTypeCode(type))
    {
      case PrimitiveTypeCode.Char:
      case PrimitiveTypeCode.SByte:
      case PrimitiveTypeCode.Int16:
      case PrimitiveTypeCode.UInt16:
      case PrimitiveTypeCode.Int32:
      case PrimitiveTypeCode.Byte:
      case PrimitiveTypeCode.UInt32:
        return (object) 0;
      case PrimitiveTypeCode.Boolean:
        return (object) false;
      case PrimitiveTypeCode.Int64:
      case PrimitiveTypeCode.UInt64:
        return (object) 0L;
      case PrimitiveTypeCode.Single:
        return (object) 0.0f;
      case PrimitiveTypeCode.Double:
        return (object) 0.0;
      case PrimitiveTypeCode.DateTime:
        return (object) new DateTime();
      case PrimitiveTypeCode.DateTimeOffset:
        return (object) new DateTimeOffset();
      case PrimitiveTypeCode.Decimal:
        return (object) 0M;
      case PrimitiveTypeCode.Guid:
        return (object) new Guid();
      case PrimitiveTypeCode.BigInteger:
        return (object) new BigInteger();
      default:
        return ReflectionUtils.IsNullable(type) ? (object) null : Activator.CreateInstance(type);
    }
  }
}
