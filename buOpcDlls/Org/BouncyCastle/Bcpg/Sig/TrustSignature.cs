// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.Sig.TrustSignature
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Bcpg.Sig;

public class TrustSignature : SignatureSubpacket
{
  private static byte[] IntToByteArray(int v1, int v2)
  {
    return new byte[2]{ (byte) v1, (byte) v2 };
  }

  public TrustSignature(bool critical, bool isLongLength, byte[] data)
    : base(SignatureSubpacketTag.TrustSig, critical, isLongLength, data)
  {
  }

  public TrustSignature(bool critical, int depth, int trustAmount)
    : base(SignatureSubpacketTag.TrustSig, critical, false, TrustSignature.IntToByteArray(depth, trustAmount))
  {
  }

  public int Depth => (int) this.data[0] & (int) byte.MaxValue;

  public int TrustAmount => (int) this.data[1] & (int) byte.MaxValue;
}
