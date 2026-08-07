// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.Sig.IssuerFingerprint
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;

#nullable disable
namespace Org.BouncyCastle.Bcpg.Sig;

public class IssuerFingerprint : SignatureSubpacket
{
  public IssuerFingerprint(bool critical, bool isLongLength, byte[] data)
    : base(SignatureSubpacketTag.IssuerFingerprint, critical, isLongLength, data)
  {
  }

  public IssuerFingerprint(bool critical, int keyVersion, byte[] fingerprint)
    : base(SignatureSubpacketTag.IssuerFingerprint, critical, false, Arrays.Prepend(fingerprint, (byte) keyVersion))
  {
  }

  public int KeyVersion => (int) this.data[0];

  public byte[] GetFingerprint() => Arrays.CopyOfRange(this.data, 1, this.data.Length);
}
