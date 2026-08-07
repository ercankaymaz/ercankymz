// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Digests.NullDigest
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Crypto.Digests;

public class NullDigest : IDigest
{
  private readonly MemoryStream bOut = new MemoryStream();

  public string AlgorithmName => "NULL";

  public int GetByteLength() => 0;

  public int GetDigestSize() => Convert.ToInt32(this.bOut.Length);

  public void Update(byte b) => this.bOut.WriteByte(b);

  public void BlockUpdate(byte[] inBytes, int inOff, int len)
  {
    this.bOut.Write(inBytes, inOff, len);
  }

  public int DoFinal(byte[] outBytes, int outOff)
  {
    try
    {
      byte[] buffer = this.bOut.GetBuffer();
      int int32 = Convert.ToInt32(this.bOut.Length);
      byte[] destinationArray = outBytes;
      int destinationIndex = outOff;
      int length = int32;
      Array.Copy((Array) buffer, 0, (Array) destinationArray, destinationIndex, length);
      return int32;
    }
    finally
    {
      this.Reset();
    }
  }

  public void Reset() => this.bOut.SetLength(0L);
}
