// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.AsymmetricKeyParameter
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Crypto;

public abstract class AsymmetricKeyParameter : ICipherParameters
{
  private readonly bool privateKey;

  protected AsymmetricKeyParameter(bool privateKey) => this.privateKey = privateKey;

  public bool IsPrivate => this.privateKey;

  public override bool Equals(object obj)
  {
    return obj is AsymmetricKeyParameter other && this.Equals(other);
  }

  protected bool Equals(AsymmetricKeyParameter other) => this.privateKey == other.privateKey;

  public override int GetHashCode() => this.privateKey.GetHashCode();
}
