// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.OpenPgp.PgpLiteralData
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities.Date;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Bcpg.OpenPgp;

public class PgpLiteralData : PgpObject
{
  public const char Binary = 'b';
  public const char Text = 't';
  public const char Utf8 = 'u';
  public const string Console = "_CONSOLE";
  private readonly LiteralDataPacket data;

  public PgpLiteralData(BcpgInputStream bcpgInput)
  {
    Packet packet = bcpgInput.ReadPacket();
    this.data = packet is LiteralDataPacket literalDataPacket ? literalDataPacket : throw new IOException("unexpected packet in stream: " + packet?.ToString());
  }

  public int Format => this.data.Format;

  public string FileName => this.data.FileName;

  public byte[] GetRawFileName() => this.data.GetRawFileName();

  public DateTime ModificationTime
  {
    get => DateTimeUtilities.UnixMsToDateTime(this.data.ModificationTime);
  }

  public Stream GetInputStream() => (Stream) this.data.GetInputStream();

  public Stream GetDataStream() => this.GetInputStream();
}
