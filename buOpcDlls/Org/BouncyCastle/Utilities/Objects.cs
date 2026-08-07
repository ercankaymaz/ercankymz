// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.Objects
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Threading;

#nullable disable
namespace Org.BouncyCastle.Utilities;

public static class Objects
{
  public static int GetHashCode(object obj) => obj != null ? obj.GetHashCode() : 0;

  internal static TValue EnsureSingletonInitialized<TValue, TArg>(
    ref TValue value,
    TArg arg,
    Func<TArg, TValue> initialize)
    where TValue : class
  {
    TValue obj1 = Volatile.Read<TValue>(ref value);
    if ((object) obj1 != null)
      return obj1;
    TValue obj2 = initialize(arg);
    return Interlocked.CompareExchange<TValue>(ref value, obj2, default (TValue)) ?? obj2;
  }
}
