// Decompiled with JetBrains decompiler
// Type: System.Security.Cryptography.CryptoPool
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Buffers;

#nullable disable
namespace System.Security.Cryptography;

internal static class CryptoPool
{
  internal const int ClearAll = -1;

  internal static byte[] Rent(int minimumLength) => ArrayPool<byte>.Shared.Rent(minimumLength);

  internal static void Return(ArraySegment<byte> arraySegment)
  {
    CryptoPool.Return(arraySegment.Array, arraySegment.Count);
  }

  internal static void Return(byte[] array, int clearSize = -1)
  {
    bool clearArray;
    if (!(clearArray = clearSize < 0) && clearSize != 0)
      Array.Clear((Array) array, 0, clearSize);
    ArrayPool<byte>.Shared.Return(array, clearArray);
  }
}
