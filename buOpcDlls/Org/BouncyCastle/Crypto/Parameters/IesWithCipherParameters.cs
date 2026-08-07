// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.IesWithCipherParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public class IesWithCipherParameters : IesParameters
{
  private int cipherKeySize;

  public IesWithCipherParameters(
    byte[] derivation,
    byte[] encoding,
    int macKeySize,
    int cipherKeySize)
    : base(derivation, encoding, macKeySize)
  {
    this.cipherKeySize = cipherKeySize;
  }

  public int CipherKeySize => this.cipherKeySize;
}
