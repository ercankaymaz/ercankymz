// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Cmce.CmcePrivateKeyParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Cmce;

public sealed class CmcePrivateKeyParameters : CmceKeyParameters
{
  internal readonly byte[] privateKey;

  public byte[] GetPrivateKey() => Arrays.Clone(this.privateKey);

  public CmcePrivateKeyParameters(CmceParameters parameters, byte[] privateKey)
    : base(true, parameters)
  {
    this.privateKey = Arrays.Clone(privateKey);
  }

  public CmcePrivateKeyParameters(
    CmceParameters parameters,
    byte[] delta,
    byte[] C,
    byte[] g,
    byte[] alpha,
    byte[] s)
    : base(true, parameters)
  {
    this.privateKey = new byte[delta.Length + C.Length + g.Length + alpha.Length + s.Length];
    Array.Copy((Array) delta, 0, (Array) this.privateKey, 0, delta.Length);
    int destinationIndex1 = 0 + delta.Length;
    Array.Copy((Array) C, 0, (Array) this.privateKey, destinationIndex1, C.Length);
    int destinationIndex2 = destinationIndex1 + C.Length;
    Array.Copy((Array) g, 0, (Array) this.privateKey, destinationIndex2, g.Length);
    int destinationIndex3 = destinationIndex2 + g.Length;
    Array.Copy((Array) alpha, 0, (Array) this.privateKey, destinationIndex3, alpha.Length);
    int destinationIndex4 = destinationIndex3 + alpha.Length;
    Array.Copy((Array) s, 0, (Array) this.privateKey, destinationIndex4, s.Length);
  }

  public byte[] ReconstructPublicKey()
  {
    ICmceEngine engine = this.Parameters.Engine;
    byte[] numArray = new byte[engine.PublicKeySize];
    engine.GeneratePublicKeyFromPrivateKey(this.privateKey);
    return numArray;
  }

  public byte[] GetEncoded() => Arrays.Clone(this.privateKey);

  internal byte[] Delta => Arrays.CopyOfRange(this.privateKey, 0, 32 /*0x20*/);

  internal byte[] C => Arrays.CopyOfRange(this.privateKey, 32 /*0x20*/, 40);

  internal byte[] G => Arrays.CopyOfRange(this.privateKey, 40, 40 + this.Parameters.T * 2);

  internal byte[] Alpha
  {
    get
    {
      return Arrays.CopyOfRange(this.privateKey, 40 + this.Parameters.T * 2, this.privateKey.Length - 32 /*0x20*/);
    }
  }

  internal byte[] S
  {
    get
    {
      return Arrays.CopyOfRange(this.privateKey, this.privateKey.Length - 32 /*0x20*/, this.privateKey.Length);
    }
  }
}
