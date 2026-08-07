// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.ContainedPacket
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.IO;

#nullable disable
namespace Org.BouncyCastle.Bcpg;

public abstract class ContainedPacket : Packet
{
  public byte[] GetEncoded()
  {
    MemoryStream outStr = new MemoryStream();
    new BcpgOutputStream((Stream) outStr).WritePacket(this);
    return outStr.ToArray();
  }

  public abstract void Encode(BcpgOutputStream bcpgOut);
}
