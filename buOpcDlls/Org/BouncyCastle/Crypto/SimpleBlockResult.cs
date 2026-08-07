// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.SimpleBlockResult
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Crypto;

public sealed class SimpleBlockResult : IBlockResult
{
  private readonly byte[] result;

  public SimpleBlockResult(byte[] result) => this.result = result;

  public byte[] Collect() => this.result;

  public int Collect(byte[] buf, int off)
  {
    Array.Copy((Array) this.result, 0, (Array) buf, off, this.result.Length);
    return this.result.Length;
  }

  public int GetMaxResultLength() => this.result.Length;
}
