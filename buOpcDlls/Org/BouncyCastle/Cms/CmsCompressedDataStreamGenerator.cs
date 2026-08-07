// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cms.CmsCompressedDataStreamGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities.IO;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Cms;

public class CmsCompressedDataStreamGenerator
{
  public static readonly string ZLib = CmsObjectIdentifiers.ZlibCompress.Id;
  private int _bufferSize;

  public void SetBufferSize(int bufferSize) => this._bufferSize = bufferSize;

  public Stream Open(Stream outStream)
  {
    return this.Open(outStream, CmsObjectIdentifiers.Data.Id, CmsCompressedDataStreamGenerator.ZLib);
  }

  public Stream Open(Stream outStream, string compressionOid)
  {
    return this.Open(outStream, CmsObjectIdentifiers.Data.Id, compressionOid);
  }

  public Stream Open(Stream outStream, string contentOid, string compressionOid)
  {
    if (CmsCompressedDataStreamGenerator.ZLib != compressionOid)
      throw new ArgumentException("Unsupported compression algorithm: " + compressionOid, nameof (compressionOid));
    BerSequenceGenerator sGen = new BerSequenceGenerator(outStream);
    sGen.AddObject((Asn1Object) CmsObjectIdentifiers.CompressedData);
    BerSequenceGenerator cGen = new BerSequenceGenerator(sGen.GetRawOutputStream(), 0, true);
    cGen.AddObject((Asn1Object) new DerInteger(0));
    cGen.AddObject((Asn1Encodable) new AlgorithmIdentifier(CmsObjectIdentifiers.ZlibCompress));
    BerSequenceGenerator eiGen = new BerSequenceGenerator(cGen.GetRawOutputStream());
    eiGen.AddObject((Asn1Object) new DerObjectIdentifier(contentOid));
    BerOctetStringGenerator octGen = new BerOctetStringGenerator(eiGen.GetRawOutputStream(), 0, true);
    return (Stream) new CmsCompressedDataStreamGenerator.CmsCompressedOutputStream(Org.BouncyCastle.Utilities.IO.Compression.ZLib.CompressOutput(octGen.GetOctetOutputStream(this._bufferSize), -1), sGen, cGen, eiGen, octGen);
  }

  private class CmsCompressedOutputStream : BaseOutputStream
  {
    private Stream _out;
    private BerSequenceGenerator _sGen;
    private BerSequenceGenerator _cGen;
    private BerSequenceGenerator _eiGen;
    private BerOctetStringGenerator _octGen;

    internal CmsCompressedOutputStream(
      Stream outStream,
      BerSequenceGenerator sGen,
      BerSequenceGenerator cGen,
      BerSequenceGenerator eiGen,
      BerOctetStringGenerator octGen)
    {
      this._out = outStream;
      this._sGen = sGen;
      this._cGen = cGen;
      this._eiGen = eiGen;
      this._octGen = octGen;
    }

    public override void Write(byte[] buffer, int offset, int count)
    {
      this._out.Write(buffer, offset, count);
    }

    public override void WriteByte(byte value) => this._out.WriteByte(value);

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        this._out.Dispose();
        this._octGen.Dispose();
        this._eiGen.Dispose();
        this._cGen.Dispose();
        this._sGen.Dispose();
      }
      base.Dispose(disposing);
    }
  }
}
