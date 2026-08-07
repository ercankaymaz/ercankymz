// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.BerGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities.IO;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Asn1;

public abstract class BerGenerator : Asn1Generator
{
  private bool _tagged;
  private bool _isExplicit;
  private int _tagNo;

  protected BerGenerator(Stream outStream)
    : base(outStream)
  {
  }

  protected BerGenerator(Stream outStream, int tagNo, bool isExplicit)
    : base(outStream)
  {
    this._tagged = true;
    this._isExplicit = isExplicit;
    this._tagNo = tagNo;
  }

  protected override void Finish() => this.WriteBerEnd();

  public override void AddObject(Asn1Encodable obj) => obj.EncodeTo(this.OutStream);

  public override void AddObject(Asn1Object obj) => obj.EncodeTo(this.OutStream);

  public override Stream GetRawOutputStream() => this.OutStream;

  private void WriteHdr(int tag)
  {
    this.OutStream.WriteByte((byte) tag);
    this.OutStream.WriteByte((byte) 128 /*0x80*/);
  }

  protected void WriteBerHeader(int tag)
  {
    if (this._tagged)
    {
      int tag1 = this._tagNo | 128 /*0x80*/;
      if (this._isExplicit)
      {
        this.WriteHdr(tag1 | 32 /*0x20*/);
        this.WriteHdr(tag);
      }
      else if ((tag & 32 /*0x20*/) != 0)
        this.WriteHdr(tag1 | 32 /*0x20*/);
      else
        this.WriteHdr(tag1);
    }
    else
      this.WriteHdr(tag);
  }

  protected void WriteBerBody(Stream contentStream)
  {
    Streams.PipeAll(contentStream, this.OutStream);
  }

  protected void WriteBerEnd()
  {
    this.OutStream.WriteByte((byte) 0);
    this.OutStream.WriteByte((byte) 0);
    if (!this._tagged || !this._isExplicit)
      return;
    this.OutStream.WriteByte((byte) 0);
    this.OutStream.WriteByte((byte) 0);
  }
}
