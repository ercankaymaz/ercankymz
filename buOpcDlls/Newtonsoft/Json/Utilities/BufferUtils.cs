// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Utilities.BufferUtils
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json.Utilities;

[NullableContext(2)]
[Nullable(0)]
internal static class BufferUtils
{
  [NullableContext(1)]
  public static char[] RentBuffer([Nullable(2)] IArrayPool<char> bufferPool, int minSize)
  {
    return bufferPool == null ? new char[minSize] : bufferPool.Rent(minSize);
  }

  public static void ReturnBuffer(IArrayPool<char> bufferPool, char[] buffer)
  {
    bufferPool?.Return(buffer);
  }

  [return: Nullable(1)]
  public static char[] EnsureBufferSize(IArrayPool<char> bufferPool, int size, char[] buffer)
  {
    if (bufferPool == null)
      return new char[size];
    if (buffer != null)
      bufferPool.Return(buffer);
    return bufferPool.Rent(size);
  }
}
