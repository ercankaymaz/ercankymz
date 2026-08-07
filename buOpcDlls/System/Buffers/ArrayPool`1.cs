// Decompiled with JetBrains decompiler
// Type: System.Buffers.ArrayPool`1
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

#nullable disable
namespace System.Buffers;

[ComVisible(true)]
public abstract class ArrayPool<T>
{
  private static ArrayPool<T> s_sharedInstance;

  public static ArrayPool<T> Shared
  {
    [MethodImpl(MethodImplOptions.AggressiveInlining)] get
    {
      return Volatile.Read<ArrayPool<T>>(ref ArrayPool<T>.s_sharedInstance) ?? ArrayPool<T>.EnsureSharedCreated();
    }
  }

  private static ArrayPool<T> EnsureSharedCreated()
  {
    Interlocked.CompareExchange<ArrayPool<T>>(ref ArrayPool<T>.s_sharedInstance, ArrayPool<T>.Create(), (ArrayPool<T>) null);
    return ArrayPool<T>.s_sharedInstance;
  }

  public static ArrayPool<T> Create() => (ArrayPool<T>) new DefaultArrayPool<T>();

  public static ArrayPool<T> Create(int maxArrayLength, int maxArraysPerBucket)
  {
    return (ArrayPool<T>) new DefaultArrayPool<T>(maxArrayLength, maxArraysPerBucket);
  }

  public abstract T[] Rent(int minimumLength);

  public abstract void Return(T[] array, bool clearArray = false);
}
