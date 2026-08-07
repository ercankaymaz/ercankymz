// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.DerSetGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.IO;

#nullable disable
namespace Org.BouncyCastle.Asn1;

public class DerSetGenerator : DerGenerator
{
  private readonly MemoryStream _bOut = new MemoryStream();

  public DerSetGenerator(Stream outStream)
    : base(outStream)
  {
  }

  public DerSetGenerator(Stream outStream, int tagNo, bool isExplicit)
    : base(outStream, tagNo, isExplicit)
  {
  }

  protected override void Finish() => this.WriteDerEncoded(49, this._bOut.ToArray());

  public override void AddObject(Asn1Encodable obj) => obj.EncodeTo((Stream) this._bOut, "DER");

  public override void AddObject(Asn1Object obj) => obj.EncodeTo((Stream) this._bOut, "DER");

  public override Stream GetRawOutputStream() => (Stream) this._bOut;
}
