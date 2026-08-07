// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Ntru.NtruPrivateKeyParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Ntru;

public sealed class NtruPrivateKeyParameters : NtruKeyParameters
{
  private byte[] _privateKey;

  public byte[] PrivateKey
  {
    get => (byte[]) this._privateKey.Clone();
    private set => this._privateKey = (byte[]) value.Clone();
  }

  public NtruPrivateKeyParameters(NtruParameters parameters, byte[] key)
    : base(true, parameters)
  {
    this.PrivateKey = key;
  }

  public override byte[] GetEncoded() => this.PrivateKey;
}
