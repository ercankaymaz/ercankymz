// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Utilities.TypeExtensions
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis.Newtonsoft.Json1494283;
using System.Reflection;
using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json.Utilities;

[NullableContext(1)]
[Nullable(0)]
internal static class TypeExtensions
{
  public static MethodInfo Method(this Delegate d) => d.Method;

  public static MemberTypes MemberType(this MemberInfo memberInfo) => memberInfo.MemberType;

  public static bool ContainsGenericParameters(this Type type) => type.ContainsGenericParameters;

  public static bool IsInterface(this Type type) => type.IsInterface;

  public static bool IsGenericType(this Type type) => type.IsGenericType;

  public static bool IsGenericTypeDefinition(this Type type) => type.IsGenericTypeDefinition;

  [return: Nullable(2)]
  public static Type BaseType(this Type type) => type.BaseType;

  public static System.Reflection.Assembly Assembly(this Type type) => type.Assembly;

  public static bool IsEnum(this Type type) => type.IsEnum;

  public static bool IsClass(this Type type) => type.IsClass;

  public static bool IsSealed(this Type type) => type.IsSealed;

  public static bool IsAbstract(this Type type) => type.IsAbstract;

  public static bool IsVisible(this Type type) => type.IsVisible;

  public static bool IsValueType(this Type type) => type.IsValueType;

  public static bool IsPrimitive(this Type type) => type.IsPrimitive;

  public static bool AssignableToTypeName(
    this Type type,
    string fullTypeName,
    bool searchInterfaces,
    [Nullable(2), NotNullWhen(true)] out Type match)
  {
    for (Type type1 = type; type1 != (Type) null; type1 = type1.BaseType())
    {
      if (string.Equals(type1.FullName, fullTypeName, StringComparison.Ordinal))
      {
        match = type1;
        return true;
      }
    }
    if (searchInterfaces)
    {
      foreach (MemberInfo memberInfo in type.GetInterfaces())
      {
        if (string.Equals(memberInfo.Name, fullTypeName, StringComparison.Ordinal))
        {
          match = type;
          return true;
        }
      }
    }
    match = (Type) null;
    return false;
  }

  public static bool AssignableToTypeName(
    this Type type,
    string fullTypeName,
    bool searchInterfaces)
  {
    return type.AssignableToTypeName(fullTypeName, searchInterfaces, out Type _);
  }

  public static bool ImplementInterface(this Type type, Type interfaceType)
  {
    for (Type type1 = type; type1 != (Type) null; type1 = type1.BaseType())
    {
      foreach (Type type2 in (IEnumerable<Type>) type1.GetInterfaces())
      {
        if (type2 == interfaceType || type2 != (Type) null && type2.ImplementInterface(interfaceType))
          return true;
      }
    }
    return false;
  }
}
