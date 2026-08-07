// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.OpenPgp.PgpCompressedData
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities.IO.Compression;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Bcpg.OpenPgp;

public class PgpCompressedData : PgpObject
{
  private readonly CompressedDataPacket data;

  public PgpCompressedData(BcpgInputStream bcpgInput)
  {
    Packet packet = bcpgInput.ReadPacket();
    this.data = packet is CompressedDataPacket compressedDataPacket ? compressedDataPacket : throw new IOException("unexpected packet in stream: " + packet?.ToString());
  }

  public CompressionAlgorithmTag Algorithm => this.data.Algorithm;

  public Stream GetInputStream() => (Stream) this.data.GetInputStream();

  public Stream GetDataStream()
  {
    switch (this.Algorithm)
    {
      case CompressionAlgorithmTag.Uncompressed:
        return this.GetInputStream();
      case CompressionAlgorithmTag.Zip:
        return Zip.DecompressInput(this.GetInputStream());
      case CompressionAlgorithmTag.ZLib:
        return ZLib.DecompressInput(this.GetInputStream());
      case CompressionAlgorithmTag.BZip2:
        return Bzip2.DecompressInput(this.GetInputStream());
      default:
        throw new PgpException("can't recognise compression algorithm: " + this.Algorithm.ToString());
    }
  }
}
