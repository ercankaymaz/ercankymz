// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.Sig.SignatureTarget
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;

#nullable disable
namespace Org.BouncyCastle.Bcpg.Sig;

public class SignatureTarget : SignatureSubpacket
{
  public SignatureTarget(bool critical, bool isLongLength, byte[] data)
    : base(SignatureSubpacketTag.SignatureTarget, critical, isLongLength, data)
  {
  }

  public SignatureTarget(
    bool critical,
    int publicKeyAlgorithm,
    int hashAlgorithm,
    byte[] hashData)
    : base(SignatureSubpacketTag.SignatureTarget, (critical ? 1 : 0) != 0, false, Arrays.Concatenate(new byte[2]
    {
      (byte) publicKeyAlgorithm,
      (byte) hashAlgorithm
    }, hashData))
  {
  }

  public int PublicKeyAlgorithm => (int) this.data[0];

  public int HashAlgorithm => (int) this.data[1];

  public byte[] GetHashData() => Arrays.CopyOfRange(this.data, 2, this.data.Length);
}
