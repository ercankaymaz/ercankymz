// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Bindings.BufferCollection
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua.Bindings;

[ComVisible(true)]
public class BufferCollection : List<ArraySegment<byte>>
{
  public BufferCollection()
  {
  }

  public BufferCollection(int capacity)
    : base(capacity)
  {
  }

  public BufferCollection(ArraySegment<byte> segment) => this.Add(segment);

  public BufferCollection(byte[] array, int offset, int count)
  {
    this.Add(new ArraySegment<byte>(array, offset, count));
  }

  public int Release(BufferManager bufferManager, string owner)
  {
    int num = 0;
    foreach (ArraySegment<byte> arraySegment in (List<ArraySegment<byte>>) this)
    {
      num += arraySegment.Count;
      bufferManager.ReturnBuffer(arraySegment.Array, owner);
    }
    this.Clear();
    return num;
  }

  public int TotalSize
  {
    get
    {
      int totalSize = 0;
      for (int index = 0; index < this.Count; ++index)
        totalSize += this[index].Count;
      return totalSize;
    }
  }
}
