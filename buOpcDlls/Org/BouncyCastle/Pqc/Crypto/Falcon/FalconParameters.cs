// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Falcon.FalconParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Falcon;

public sealed class FalconParameters : ICipherParameters
{
  public static readonly FalconParameters falcon_512 = new FalconParameters("falcon512", 9U, 40U);
  public static readonly FalconParameters falcon_1024 = new FalconParameters("falcon1024", 10U, 40U);
  private readonly string name;
  private readonly uint logn;
  private readonly uint nonce_length;

  private FalconParameters(string name, uint logn, uint nonce_length)
  {
    this.name = name;
    this.logn = logn;
    this.nonce_length = nonce_length;
  }

  public int LogN => Convert.ToInt32(this.logn);

  public int NonceLength => Convert.ToInt32(this.nonce_length);

  public string Name => this.name;
}
