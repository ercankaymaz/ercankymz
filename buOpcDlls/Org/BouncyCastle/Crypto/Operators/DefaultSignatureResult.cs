// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Operators.DefaultSignatureResult
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Operators;

public sealed class DefaultSignatureResult : IBlockResult
{
  private readonly ISigner mSigner;

  public DefaultSignatureResult(ISigner signer) => this.mSigner = signer;

  public byte[] Collect() => this.mSigner.GenerateSignature();

  public int Collect(byte[] buf, int off)
  {
    byte[] numArray = this.Collect();
    numArray.CopyTo((Array) buf, off);
    return numArray.Length;
  }

  public int GetMaxResultLength() => this.mSigner.GetMaxSignatureSize();
}
