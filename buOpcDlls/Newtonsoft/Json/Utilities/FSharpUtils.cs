// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Utilities.FSharpUtils
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json.Utilities;

[NullableContext(1)]
[Nullable(0)]
internal class FSharpUtils
{
  private static readonly object Lock = new object();
  [Nullable(2)]
  private static FSharpUtils _instance;
  private MethodInfo _ofSeq;
  private Type _mapType;
  public const string FSharpSetTypeName = "FSharpSet`1";
  public const string FSharpListTypeName = "FSharpList`1";
  public const string FSharpMapTypeName = "FSharpMap`2";

  private FSharpUtils(Assembly fsharpCoreAssembly)
  {
    this.FSharpCoreAssembly = fsharpCoreAssembly;
    Type type1 = fsharpCoreAssembly.GetType("Microsoft.FSharp.Reflection.FSharpType");
    this.IsUnion = JsonTypeReflector.ReflectionDelegateFactory.CreateMethodCall<object>((MethodBase) FSharpUtils.GetMethodWithNonPublicFallback(type1, nameof (IsUnion), BindingFlags.Static | BindingFlags.Public));
    this.GetUnionCases = JsonTypeReflector.ReflectionDelegateFactory.CreateMethodCall<object>((MethodBase) FSharpUtils.GetMethodWithNonPublicFallback(type1, nameof (GetUnionCases), BindingFlags.Static | BindingFlags.Public));
    Type type2 = fsharpCoreAssembly.GetType("Microsoft.FSharp.Reflection.FSharpValue");
    this.PreComputeUnionTagReader = FSharpUtils.CreateFSharpFuncCall(type2, nameof (PreComputeUnionTagReader));
    this.PreComputeUnionReader = FSharpUtils.CreateFSharpFuncCall(type2, nameof (PreComputeUnionReader));
    this.PreComputeUnionConstructor = FSharpUtils.CreateFSharpFuncCall(type2, nameof (PreComputeUnionConstructor));
    Type type3 = fsharpCoreAssembly.GetType("Microsoft.FSharp.Reflection.UnionCaseInfo");
    this.GetUnionCaseInfoName = JsonTypeReflector.ReflectionDelegateFactory.CreateGet<object>(type3.GetProperty("Name"));
    this.GetUnionCaseInfoTag = JsonTypeReflector.ReflectionDelegateFactory.CreateGet<object>(type3.GetProperty("Tag"));
    this.GetUnionCaseInfoDeclaringType = JsonTypeReflector.ReflectionDelegateFactory.CreateGet<object>(type3.GetProperty("DeclaringType"));
    this.GetUnionCaseInfoFields = JsonTypeReflector.ReflectionDelegateFactory.CreateMethodCall<object>((MethodBase) type3.GetMethod("GetFields"));
    this._ofSeq = fsharpCoreAssembly.GetType("Microsoft.FSharp.Collections.ListModule").GetMethod("OfSeq");
    this._mapType = fsharpCoreAssembly.GetType("Microsoft.FSharp.Collections.FSharpMap`2");
  }

  public static FSharpUtils Instance => FSharpUtils._instance;

  public Assembly FSharpCoreAssembly { get; private set; }

  [field: Nullable(new byte[] {1, 2, 1})]
  [Nullable(new byte[] {1, 2, 1})]
  public MethodCall<object, object> IsUnion { [return: Nullable(new byte[] {1, 2, 1})] get; [param: Nullable(new byte[] {1, 2, 1})] private set; }

  [field: Nullable(new byte[] {1, 2, 1})]
  [Nullable(new byte[] {1, 2, 1})]
  public MethodCall<object, object> GetUnionCases { [return: Nullable(new byte[] {1, 2, 1})] get; [param: Nullable(new byte[] {1, 2, 1})] private set; }

  [field: Nullable(new byte[] {1, 2, 1})]
  [Nullable(new byte[] {1, 2, 1})]
  public MethodCall<object, object> PreComputeUnionTagReader { [return: Nullable(new byte[] {1, 2, 1})] get; [param: Nullable(new byte[] {1, 2, 1})] private set; }

  [field: Nullable(new byte[] {1, 2, 1})]
  [Nullable(new byte[] {1, 2, 1})]
  public MethodCall<object, object> PreComputeUnionReader { [return: Nullable(new byte[] {1, 2, 1})] get; [param: Nullable(new byte[] {1, 2, 1})] private set; }

  [field: Nullable(new byte[] {1, 2, 1})]
  [Nullable(new byte[] {1, 2, 1})]
  public MethodCall<object, object> PreComputeUnionConstructor { [return: Nullable(new byte[] {1, 2, 1})] get; [param: Nullable(new byte[] {1, 2, 1})] private set; }

  public Func<object, object> GetUnionCaseInfoDeclaringType { get; private set; }

  public Func<object, object> GetUnionCaseInfoName { get; private set; }

  public Func<object, object> GetUnionCaseInfoTag { get; private set; }

  [field: Nullable(new byte[] {1, 1, 2})]
  [Nullable(new byte[] {1, 1, 2})]
  public MethodCall<object, object> GetUnionCaseInfoFields { [return: Nullable(new byte[] {1, 1, 2})] get; [param: Nullable(new byte[] {1, 1, 2})] private set; }

  public static void EnsureInitialized(Assembly fsharpCoreAssembly)
  {
    if (FSharpUtils._instance != null)
      return;
    lock (FSharpUtils.Lock)
    {
      if (FSharpUtils._instance != null)
        return;
      FSharpUtils._instance = new FSharpUtils(fsharpCoreAssembly);
    }
  }

  private static MethodInfo GetMethodWithNonPublicFallback(
    Type type,
    string methodName,
    BindingFlags bindingFlags)
  {
    MethodInfo method = type.GetMethod(methodName, bindingFlags);
    if (method == (MethodInfo) null && (bindingFlags & BindingFlags.NonPublic) != BindingFlags.NonPublic)
      method = type.GetMethod(methodName, bindingFlags | BindingFlags.NonPublic);
    return method;
  }

  [return: Nullable(new byte[] {1, 2, 1})]
  private static MethodCall<object, object> CreateFSharpFuncCall(Type type, string methodName)
  {
    MethodInfo nonPublicFallback = FSharpUtils.GetMethodWithNonPublicFallback(type, methodName, BindingFlags.Static | BindingFlags.Public);
    MethodInfo method = nonPublicFallback.ReturnType.GetMethod("Invoke", BindingFlags.Instance | BindingFlags.Public);
    MethodCall<object, object> call = JsonTypeReflector.ReflectionDelegateFactory.CreateMethodCall<object>((MethodBase) nonPublicFallback);
    MethodCall<object, object> invoke = JsonTypeReflector.ReflectionDelegateFactory.CreateMethodCall<object>((MethodBase) method);
    return (MethodCall<object, object>) (([Nullable(2)] target, [Nullable(new byte[] {1, 2})] args) => (object) new FSharpFunction(call(target, args), invoke));
  }

  public ObjectConstructor<object> CreateSeq(Type t)
  {
    return JsonTypeReflector.ReflectionDelegateFactory.CreateParameterizedConstructor((MethodBase) this._ofSeq.MakeGenericMethod(t));
  }

  public ObjectConstructor<object> CreateMap(Type keyType, Type valueType)
  {
    return (ObjectConstructor<object>) typeof (FSharpUtils).GetMethod("BuildMapCreator").MakeGenericMethod(keyType, valueType).Invoke((object) this, (object[]) null);
  }

  [NullableContext(2)]
  [return: Nullable(1)]
  public ObjectConstructor<object> BuildMapCreator<TKey, TValue>()
  {
    ObjectConstructor<object> ctorDelegate = JsonTypeReflector.ReflectionDelegateFactory.CreateParameterizedConstructor((MethodBase) this._mapType.MakeGenericType(typeof (TKey), typeof (TValue)).GetConstructor(new Type[1]
    {
      typeof (IEnumerable<Tuple<TKey, TValue>>)
    }));
    return (ObjectConstructor<object>) (([Nullable(new byte[] {1, 2})] args) =>
    {
      IEnumerable<Tuple<TKey, TValue>> tuples = ((IEnumerable<KeyValuePair<TKey, TValue>>) args[0]).Select<KeyValuePair<TKey, TValue>, Tuple<TKey, TValue>>((Func<KeyValuePair<TKey, TValue>, Tuple<TKey, TValue>>) ([NullableContext(0)] (kv) => new Tuple<TKey, TValue>(kv.Key, kv.Value)));
      return ctorDelegate((object) tuples);
    });
  }
}
