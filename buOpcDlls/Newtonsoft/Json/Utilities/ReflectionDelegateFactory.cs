// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Utilities.ReflectionDelegateFactory
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Newtonsoft.Json.Serialization;
using System;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json.Utilities;

[NullableContext(1)]
[Nullable(0)]
internal abstract class ReflectionDelegateFactory
{
  [return: Nullable(new byte[] {1, 1, 2})]
  public Func<T, object> CreateGet<[Nullable(2)] T>(MemberInfo memberInfo)
  {
    PropertyInfo propertyInfo = memberInfo as PropertyInfo;
    if ((object) propertyInfo != null)
    {
      if (propertyInfo.PropertyType.IsByRef)
        throw new InvalidOperationException("Could not create getter for {0}. ByRef return values are not supported.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) propertyInfo));
      return this.CreateGet<T>(propertyInfo);
    }
    return this.CreateGet<T>(memberInfo as FieldInfo ?? throw new Exception("Could not create getter for {0}.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) memberInfo)));
  }

  [return: Nullable(new byte[] {1, 1, 2})]
  public Action<T, object> CreateSet<[Nullable(2)] T>(MemberInfo memberInfo)
  {
    PropertyInfo propertyInfo = memberInfo as PropertyInfo;
    if ((object) propertyInfo != null)
      return this.CreateSet<T>(propertyInfo);
    return this.CreateSet<T>(memberInfo as FieldInfo ?? throw new Exception("Could not create setter for {0}.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) memberInfo)));
  }

  [return: Nullable(new byte[] {1, 1, 2})]
  public abstract MethodCall<T, object> CreateMethodCall<[Nullable(2)] T>(MethodBase method);

  public abstract ObjectConstructor<object> CreateParameterizedConstructor(MethodBase method);

  public abstract Func<T> CreateDefaultConstructor<[Nullable(2)] T>(Type type);

  [return: Nullable(new byte[] {1, 1, 2})]
  public abstract Func<T, object> CreateGet<[Nullable(2)] T>(PropertyInfo propertyInfo);

  [return: Nullable(new byte[] {1, 1, 2})]
  public abstract Func<T, object> CreateGet<[Nullable(2)] T>(FieldInfo fieldInfo);

  [return: Nullable(new byte[] {1, 1, 2})]
  public abstract Action<T, object> CreateSet<[Nullable(2)] T>(FieldInfo fieldInfo);

  [return: Nullable(new byte[] {1, 1, 2})]
  public abstract Action<T, object> CreateSet<[Nullable(2)] T>(PropertyInfo propertyInfo);
}
