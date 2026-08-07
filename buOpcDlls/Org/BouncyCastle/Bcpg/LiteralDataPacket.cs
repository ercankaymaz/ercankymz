// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.LiteralDataPacket
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Bcpg;

public class LiteralDataPacket : InputStreamPacket
{
  private int format;
  private byte[] fileName;
  private long modDate;

  internal LiteralDataPacket(BcpgInputStream bcpgIn)
    : base(bcpgIn)
  {
    this.format = bcpgIn.ReadByte();
    int length = bcpgIn.ReadByte();
    this.fileName = new byte[length];
    for (int index = 0; index != length; ++index)
    {
      int num = bcpgIn.ReadByte();
      this.fileName[index] = num >= 0 ? (byte) num : throw new IOException("literal data truncated in header");
    }
    this.modDate = (long) (uint) (bcpgIn.ReadByte() << 24 | bcpgIn.ReadByte() << 16 /*0x10*/ | bcpgIn.ReadByte() << 8 | bcpgIn.ReadByte()) * 1000L;
  }

  public int Format => this.format;

  public long ModificationTime => this.modDate;

  public string FileName => Strings.FromUtf8ByteArray(this.fileName);

  public byte[] GetRawFileName() => Arrays.Clone(this.fileName);
}
