// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.PublicSubkeyPacket
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Bcpg;

public class PublicSubkeyPacket : PublicKeyPacket
{
  internal PublicSubkeyPacket(BcpgInputStream bcpgIn)
    : base(bcpgIn)
  {
  }

  public PublicSubkeyPacket(PublicKeyAlgorithmTag algorithm, DateTime time, IBcpgKey key)
    : base(algorithm, time, key)
  {
  }

  public override void Encode(BcpgOutputStream bcpgOut)
  {
    bcpgOut.WritePacket(PacketTag.PublicSubkey, this.GetEncodedContents());
  }
}
