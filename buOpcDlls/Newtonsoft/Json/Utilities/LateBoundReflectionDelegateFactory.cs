// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Utilities.LateBoundReflectionDelegateFactory
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Newtonsoft.Json.Serialization;
using System;
using System.Reflection;
using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json.Utilities;

[NullableContext(1)]
[Nullable(0)]
internal class LateBoundReflectionDelegateFactory : ReflectionDelegateFactory
{
  private static readonly LateBoundReflectionDelegateFactory _instance = new LateBoundReflectionDelegateFactory();

  internal static ReflectionDelegateFactory Instance
  {
    get => (ReflectionDelegateFactory) LateBoundReflectionDelegateFactory._instance;
  }

  public override ObjectConstructor<object> CreateParameterizedConstructor(MethodBase method)
  {
    ValidationUtils.ArgumentNotNull((object) method, nameof (method));
    ConstructorInfo c = method as ConstructorInfo;
    return (object) c != null ? (ObjectConstructor<object>) (([Nullable(new byte[] {1, 2})] a) => c.Invoke(a)) : (ObjectConstructor<object>) (([Nullable(new byte[] {1, 2})] a) => method.Invoke((object) null, a));
  }

  [return: Nullable(new byte[] {1, 1, 2})]
  public override MethodCall<T, object> CreateMethodCall<[Nullable(2)] T>(MethodBase method)
  {
    ValidationUtils.ArgumentNotNull((object) method, nameof (method));
    ConstructorInfo c = method as ConstructorInfo;
    return (object) c != null ? (MethodCall<T, object>) ([NullableContext(0)] [return: Nullable(2)] (o, [Nullable(new byte[] {1, 2})] a) => c.Invoke(a)) : (MethodCall<T, object>) ([NullableContext(0)] [return: Nullable(2)] (o, [Nullable(new byte[] {1, 2})] a) => method.Invoke((object) o, a));
  }

  public override Func<T> CreateDefaultConstructor<[Nullable(2)] T>(Type type)
  {
    ValidationUtils.ArgumentNotNull((object) type, nameof (type));
    if (type.IsValueType())
      return (Func<T>) ([NullableContext(0)] () => (T) Activator.CreateInstance(type));
    ConstructorInfo constructorInfo = ReflectionUtils.GetDefaultConstructor(type, true);
    return !(constructorInfo == (ConstructorInfo) null) ? (Func<T>) ([NullableContext(0)] () => (T) constructorInfo.Invoke((object[]) null)) : throw new InvalidOperationException("Unable to find default constructor for " + type.FullName);
  }

  [return: Nullable(new byte[] {1, 1, 2})]
  public override Func<T, object> CreateGet<[Nullable(2)] T>(PropertyInfo propertyInfo)
  {
    ValidationUtils.ArgumentNotNull((object) propertyInfo, nameof (propertyInfo));
    return (Func<T, object>) ([NullableContext(0)] [return: Nullable(2)] (o) => propertyInfo.GetValue((object) o, (object[]) null));
  }

  [return: Nullable(new byte[] {1, 1, 2})]
  public override Func<T, object> CreateGet<[Nullable(2)] T>(FieldInfo fieldInfo)
  {
    ValidationUtils.ArgumentNotNull((object) fieldInfo, nameof (fieldInfo));
    return (Func<T, object>) ([NullableContext(0)] [return: Nullable(2)] (o) => fieldInfo.GetValue((object) o));
  }

  [return: Nullable(new byte[] {1, 1, 2})]
  public override Action<T, object> CreateSet<[Nullable(2)] T>(FieldInfo fieldInfo)
  {
    ValidationUtils.ArgumentNotNull((object) fieldInfo, nameof (fieldInfo));
    return (Action<T, object>) ([NullableContext(0)] (o, [Nullable(2)] v) => fieldInfo.SetValue((object) o, v));
  }

  [return: Nullable(new byte[] {1, 1, 2})]
  public override Action<T, object> CreateSet<[Nullable(2)] T>(PropertyInfo propertyInfo)
  {
    ValidationUtils.ArgumentNotNull((object) propertyInfo, nameof (propertyInfo));
    return (Action<T, object>) ([NullableContext(0)] (o, [Nullable(2)] v) => propertyInfo.SetValue((object) o, v, (object[]) null));
  }
}
