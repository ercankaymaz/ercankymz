// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.IesParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public class IesParameters : ICipherParameters
{
  private byte[] derivation;
  private byte[] encoding;
  private int macKeySize;

  public IesParameters(byte[] derivation, byte[] encoding, int macKeySize)
  {
    this.derivation = derivation;
    this.encoding = encoding;
    this.macKeySize = macKeySize;
  }

  public byte[] GetDerivationV() => this.derivation;

  public byte[] GetEncodingV() => this.encoding;

  public int MacKeySize => this.macKeySize;
}
