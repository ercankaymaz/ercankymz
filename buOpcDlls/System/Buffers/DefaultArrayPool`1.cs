// Decompiled with JetBrains decompiler
// Type: System.Buffers.DefaultArrayPool`1
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Diagnostics;
using System.Threading;

#nullable disable
namespace System.Buffers;

internal sealed class DefaultArrayPool<T> : ArrayPool<T>
{
  private const int DefaultMaxArrayLength = 1048576 /*0x100000*/;
  private const int DefaultMaxNumberOfArraysPerBucket = 50;
  private static T[] s_emptyArray;
  private readonly DefaultArrayPool<T>.Bucket[] _buckets;

  internal DefaultArrayPool()
    : this(1048576 /*0x100000*/, 50)
  {
  }

  internal DefaultArrayPool(int maxArrayLength, int maxArraysPerBucket)
  {
    if (maxArrayLength <= 0)
      throw new ArgumentOutOfRangeException(nameof (maxArrayLength));
    if (maxArraysPerBucket <= 0)
      throw new ArgumentOutOfRangeException(nameof (maxArraysPerBucket));
    if (maxArrayLength > 1073741824 /*0x40000000*/)
      maxArrayLength = 1073741824 /*0x40000000*/;
    else if (maxArrayLength < 16 /*0x10*/)
      maxArrayLength = 16 /*0x10*/;
    int id = this.Id;
    DefaultArrayPool<T>.Bucket[] bucketArray = new DefaultArrayPool<T>.Bucket[Utilities.SelectBucketIndex(maxArrayLength) + 1];
    for (int binIndex = 0; binIndex < bucketArray.Length; ++binIndex)
      bucketArray[binIndex] = new DefaultArrayPool<T>.Bucket(Utilities.GetMaxSizeForBucket(binIndex), maxArraysPerBucket, id);
    this._buckets = bucketArray;
  }

  private int Id => this.GetHashCode();

  public override T[] Rent(int minimumLength)
  {
    if (minimumLength < 0)
      throw new ArgumentOutOfRangeException(nameof (minimumLength));
    if (minimumLength == 0)
      return DefaultArrayPool<T>.s_emptyArray ?? (DefaultArrayPool<T>.s_emptyArray = new T[0]);
    ArrayPoolEventSource log = ArrayPoolEventSource.Log;
    int index1 = Utilities.SelectBucketIndex(minimumLength);
    T[] objArray1;
    if (index1 < this._buckets.Length)
    {
      int index2 = index1;
      T[] objArray2;
      do
      {
        objArray2 = this._buckets[index2].Rent();
        if (objArray2 != null)
          goto label_8;
      }
      while (++index2 < this._buckets.Length && index2 != index1 + 2);
      goto label_11;
label_8:
      if (log.IsEnabled())
        log.BufferRented(objArray2.GetHashCode(), objArray2.Length, this.Id, this._buckets[index2].Id);
      return objArray2;
label_11:
      objArray1 = new T[this._buckets[index1]._bufferLength];
    }
    else
      objArray1 = new T[minimumLength];
    if (log.IsEnabled())
    {
      int hashCode = objArray1.GetHashCode();
      log.BufferRented(hashCode, objArray1.Length, this.Id, -1);
      log.BufferAllocated(hashCode, objArray1.Length, this.Id, -1, index1 >= this._buckets.Length ? ArrayPoolEventSource.BufferAllocatedReason.OverMaximumSize : ArrayPoolEventSource.BufferAllocatedReason.PoolExhausted);
    }
    return objArray1;
  }

  public override void Return(T[] array, bool clearArray = false)
  {
    if (array == null)
      throw new ArgumentNullException(nameof (array));
    if (array.Length == 0)
      return;
    int index = Utilities.SelectBucketIndex(array.Length);
    if (index < this._buckets.Length)
    {
      if (clearArray)
        Array.Clear((Array) array, 0, array.Length);
      this._buckets[index].Return(array);
    }
    ArrayPoolEventSource log = ArrayPoolEventSource.Log;
    if (!log.IsEnabled())
      return;
    log.BufferReturned(array.GetHashCode(), array.Length, this.Id);
  }

  private sealed class Bucket
  {
    internal readonly int _bufferLength;
    private readonly T[][] _buffers;
    private readonly int _poolId;
    private SpinLock _lock;
    private int _index;

    internal Bucket(int bufferLength, int numberOfBuffers, int poolId)
    {
      this._lock = new SpinLock(Debugger.IsAttached);
      this._buffers = new T[numberOfBuffers][];
      this._bufferLength = bufferLength;
      this._poolId = poolId;
    }

    internal int Id => this.GetHashCode();

    internal T[] Rent()
    {
      T[][] buffers = this._buffers;
      T[] objArray = (T[]) null;
      bool lockTaken = false;
      bool flag = false;
      try
      {
        this._lock.Enter(ref lockTaken);
        if (this._index < buffers.Length)
        {
          objArray = buffers[this._index];
          buffers[this._index++] = (T[]) null;
          flag = objArray == null;
        }
      }
      finally
      {
        if (lockTaken)
          this._lock.Exit(false);
      }
      if (flag)
      {
        objArray = new T[this._bufferLength];
        ArrayPoolEventSource log = ArrayPoolEventSource.Log;
        if (log.IsEnabled())
          log.BufferAllocated(objArray.GetHashCode(), this._bufferLength, this._poolId, this.Id, ArrayPoolEventSource.BufferAllocatedReason.Pooled);
      }
      return objArray;
    }

    internal void Return(T[] array)
    {
      if (array.Length != this._bufferLength)
        throw new ArgumentException(System.System.Buffers3459908.SR.ArgumentException_BufferNotFromPool, nameof (array));
      bool lockTaken = false;
      try
      {
        this._lock.Enter(ref lockTaken);
        if (this._index == 0)
          return;
        this._buffers[--this._index] = array;
      }
      finally
      {
        if (lockTaken)
          this._lock.Exit(false);
      }
    }
  }
}
