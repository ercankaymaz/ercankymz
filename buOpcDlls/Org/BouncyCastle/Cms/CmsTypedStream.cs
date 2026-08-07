// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cms.CmsTypedStream
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Utilities.IO;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Cms;

public class CmsTypedStream
{
  private readonly string m_oid;
  private readonly Stream m_in;

  public CmsTypedStream(Stream inStream)
    : this(PkcsObjectIdentifiers.Data.Id, inStream)
  {
  }

  public CmsTypedStream(string oid, Stream inStream)
    : this(oid, inStream, Streams.DefaultBufferSize)
  {
  }

  public CmsTypedStream(string oid, Stream inStream, int bufSize)
  {
    this.m_oid = oid;
    this.m_in = (Stream) new BufferedFilterStream(inStream, bufSize);
  }

  public string ContentType => this.m_oid;

  public Stream ContentStream => this.m_in;

  public void Drain()
  {
    using (this.m_in)
      Streams.Drain(this.m_in);
  }
}
