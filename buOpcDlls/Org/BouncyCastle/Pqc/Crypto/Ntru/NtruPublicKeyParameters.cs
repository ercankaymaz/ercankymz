// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Ntru.NtruPublicKeyParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Ntru;

public sealed class NtruPublicKeyParameters : NtruKeyParameters
{
  private byte[] _publicKey;

  public byte[] PublicKey
  {
    get => (byte[]) this._publicKey.Clone();
    set => this._publicKey = (byte[]) value.Clone();
  }

  public NtruPublicKeyParameters(NtruParameters parameters, byte[] key)
    : base(false, parameters)
  {
    this.PublicKey = key;
  }

  public override byte[] GetEncoded() => this.PublicKey;
}
