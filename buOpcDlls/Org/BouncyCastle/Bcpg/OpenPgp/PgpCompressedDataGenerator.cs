// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.OpenPgp.PgpCompressedDataGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities.IO.Compression;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Bcpg.OpenPgp;

public class PgpCompressedDataGenerator : IStreamGenerator
{
  private readonly CompressionAlgorithmTag algorithm;
  private readonly int compression;
  private Stream dOut;
  private BcpgOutputStream pkOut;

  public PgpCompressedDataGenerator(CompressionAlgorithmTag algorithm)
    : this(algorithm, -1)
  {
  }

  public PgpCompressedDataGenerator(CompressionAlgorithmTag algorithm, int compression)
  {
    switch (algorithm)
    {
      case CompressionAlgorithmTag.Uncompressed:
      case CompressionAlgorithmTag.Zip:
      case CompressionAlgorithmTag.ZLib:
      case CompressionAlgorithmTag.BZip2:
        if (compression != -1 && (compression < 0 || compression > 9))
          throw new ArgumentException("unknown compression level: " + compression.ToString());
        this.algorithm = algorithm;
        this.compression = compression;
        break;
      default:
        throw new ArgumentException("unknown compression algorithm", nameof (algorithm));
    }
  }

  public Stream Open(Stream outStr)
  {
    if (this.dOut != null)
      throw new InvalidOperationException("generator already in open state");
    this.pkOut = outStr != null ? new BcpgOutputStream(outStr, PacketTag.CompressedData) : throw new ArgumentNullException(nameof (outStr));
    this.DoOpen();
    return (Stream) new WrappedGeneratorStream((IStreamGenerator) this, this.dOut);
  }

  public Stream Open(Stream outStr, byte[] buffer)
  {
    if (this.dOut != null)
      throw new InvalidOperationException("generator already in open state");
    if (outStr == null)
      throw new ArgumentNullException(nameof (outStr));
    this.pkOut = buffer != null ? new BcpgOutputStream(outStr, PacketTag.CompressedData, buffer) : throw new ArgumentNullException(nameof (buffer));
    this.DoOpen();
    return (Stream) new WrappedGeneratorStream((IStreamGenerator) this, this.dOut);
  }

  private void DoOpen()
  {
    this.pkOut.WriteByte((byte) this.algorithm);
    switch (this.algorithm)
    {
      case CompressionAlgorithmTag.Uncompressed:
        this.dOut = (Stream) this.pkOut;
        break;
      case CompressionAlgorithmTag.Zip:
        this.dOut = Zip.CompressOutput((Stream) this.pkOut, this.compression, true);
        break;
      case CompressionAlgorithmTag.ZLib:
        this.dOut = ZLib.CompressOutput((Stream) this.pkOut, this.compression, true);
        break;
      case CompressionAlgorithmTag.BZip2:
        this.dOut = Bzip2.CompressOutput((Stream) this.pkOut, true);
        break;
      default:
        throw new InvalidOperationException();
    }
  }

  [Obsolete("Dispose any opened Stream directly")]
  public void Close()
  {
    if (this.dOut == null)
      return;
    if (this.dOut != this.pkOut)
      this.dOut.Dispose();
    this.dOut = (Stream) null;
    this.pkOut.Finish();
    this.pkOut.Flush();
    this.pkOut = (BcpgOutputStream) null;
  }
}
