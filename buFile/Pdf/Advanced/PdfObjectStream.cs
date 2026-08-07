// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Advanced.PdfObjectStream
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Pdf.Internal;
using PdfSharp.Pdf.IO;
using System.Diagnostics;
using System.IO;

#nullable disable
namespace PdfSharp.Pdf.Advanced;

public class PdfObjectStream : PdfDictionary
{
  private readonly int[][] _header;

  public PdfObjectStream(PdfDocument document)
    : base(document)
  {
    if (!PdfDiagnostics.TraceObjectStreams)
      return;
    Debug.WriteLine("PdfObjectStream(document) created.");
  }

  internal PdfObjectStream(PdfDictionary dict)
    : base(dict)
  {
    int integer1 = this.Elements.GetInteger("/N");
    int integer2 = this.Elements.GetInteger("/First");
    this.Stream.TryUnfilter();
    this._header = new Parser((PdfDocument) null, (System.IO.Stream) new MemoryStream(this.Stream.Value)).ReadObjectStreamHeader(integer1, integer2);
    if (!PdfDiagnostics.TraceObjectStreams)
      return;
    Debug.WriteLine($"PdfObjectStream(document) created. Header item count: {this._header.GetLength(0)}");
  }

  internal void ReadReferences(PdfCrossReferenceTable xrefTable)
  {
    for (int index = 0; index < this._header.Length; ++index)
    {
      PdfReference iref = new PdfReference(new PdfObjectID(this._header[index][0]), -1);
      if (!xrefTable.Contains(iref.ObjectID))
        xrefTable.Add(iref);
      else
        this.GetType();
    }
  }

  internal PdfReference ReadCompressedObject(int index)
  {
    return new Parser(this._document, (System.IO.Stream) new MemoryStream(this.Stream.Value)).ReadCompressedObject(this._header[index][0], this._header[index][1]);
  }

  public class Keys : PdfDictionary.PdfStream.Keys
  {
    [KeyInfo(KeyType.Name | KeyType.Required, FixedValue = "ObjStm")]
    public const string Type = "/Type";
    [KeyInfo(KeyType.Integer | KeyType.Required)]
    public const string N = "/N";
    [KeyInfo(KeyType.Integer | KeyType.Required)]
    public const string First = "/First";
    [KeyInfo(KeyType.Stream | KeyType.Optional)]
    public const string Extends = "/Extends";
  }
}
