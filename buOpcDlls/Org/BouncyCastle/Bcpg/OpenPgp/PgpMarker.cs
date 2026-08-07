// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.OpenPgp.PgpMarker
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.IO;

#nullable disable
namespace Org.BouncyCastle.Bcpg.OpenPgp;

public class PgpMarker : PgpObject
{
  private readonly MarkerPacket data;

  public PgpMarker(BcpgInputStream bcpgInput)
  {
    Packet packet = bcpgInput.ReadPacket();
    this.data = packet is MarkerPacket markerPacket ? markerPacket : throw new IOException("unexpected packet in stream: " + packet?.ToString());
  }
}
