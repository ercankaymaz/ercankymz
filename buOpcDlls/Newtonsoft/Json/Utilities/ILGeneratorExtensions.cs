// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Utilities.ILGeneratorExtensions
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json.Utilities;

[NullableContext(1)]
[Nullable(0)]
internal static class ILGeneratorExtensions
{
  public static void PushInstance(this ILGenerator generator, Type type)
  {
    generator.Emit(OpCodes.Ldarg_0);
    if (type.IsValueType())
      generator.Emit(OpCodes.Unbox, type);
    else
      generator.Emit(OpCodes.Castclass, type);
  }

  public static void PushArrayInstance(this ILGenerator generator, int argsIndex, int arrayIndex)
  {
    generator.Emit(OpCodes.Ldarg, argsIndex);
    generator.Emit(OpCodes.Ldc_I4, arrayIndex);
    generator.Emit(OpCodes.Ldelem_Ref);
  }

  public static void BoxIfNeeded(this ILGenerator generator, Type type)
  {
    if (type.IsValueType())
      generator.Emit(OpCodes.Box, type);
    else
      generator.Emit(OpCodes.Castclass, type);
  }

  public static void UnboxIfNeeded(this ILGenerator generator, Type type)
  {
    if (type.IsValueType())
      generator.Emit(OpCodes.Unbox_Any, type);
    else
      generator.Emit(OpCodes.Castclass, type);
  }

  public static void CallMethod(this ILGenerator generator, MethodInfo methodInfo)
  {
    if (!methodInfo.IsFinal && methodInfo.IsVirtual)
      generator.Emit(OpCodes.Callvirt, methodInfo);
    else
      generator.Emit(OpCodes.Call, methodInfo);
  }

  public static void Return(this ILGenerator generator) => generator.Emit(OpCodes.Ret);
}
