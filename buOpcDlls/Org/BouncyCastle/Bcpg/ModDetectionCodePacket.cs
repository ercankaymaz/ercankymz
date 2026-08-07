// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.ModDetectionCodePacket
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Bcpg;

public class ModDetectionCodePacket : ContainedPacket
{
  private readonly byte[] digest;

  internal ModDetectionCodePacket(BcpgInputStream bcpgIn)
  {
    if (bcpgIn == null)
      throw new ArgumentNullException(nameof (bcpgIn));
    this.digest = new byte[20];
    bcpgIn.ReadFully(this.digest);
  }

  public ModDetectionCodePacket(byte[] digest)
  {
    this.digest = digest != null ? (byte[]) digest.Clone() : throw new ArgumentNullException(nameof (digest));
  }

  public byte[] GetDigest() => (byte[]) this.digest.Clone();

  public override void Encode(BcpgOutputStream bcpgOut)
  {
    bcpgOut.WritePacket(PacketTag.ModificationDetectionCode, this.digest);
  }
}
