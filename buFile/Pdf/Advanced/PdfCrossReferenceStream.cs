// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Advanced.PdfCrossReferenceStream
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Pdf.Internal;
using System.Collections.Generic;
using System.Diagnostics;

#nullable disable
namespace PdfSharp.Pdf.Advanced;

internal sealed class PdfCrossReferenceStream : PdfTrailer
{
  public readonly List<PdfCrossReferenceStream.CrossReferenceStreamEntry> Entries = new List<PdfCrossReferenceStream.CrossReferenceStreamEntry>();

  public PdfCrossReferenceStream(PdfDocument document)
    : base(document)
  {
    if (!PdfDiagnostics.TraceXrefStreams)
      return;
    Debug.WriteLine("PdfCrossReferenceStream created.");
  }

  internal override DictionaryMeta Meta => PdfCrossReferenceStream.Keys.Meta;

  public struct CrossReferenceStreamEntry
  {
    public uint Type;
    public uint Field2;
    public uint Field3;
  }

  public new class Keys : PdfTrailer.Keys
  {
    [KeyInfo(KeyType.Name | KeyType.Required, FixedValue = "XRef")]
    public const string Type = "/Type";
    [KeyInfo(KeyType.Integer | KeyType.Required)]
    public new const string Size = "/Size";
    [KeyInfo(KeyType.Array | KeyType.Optional)]
    public const string Index = "/Index";
    [KeyInfo(KeyType.Integer | KeyType.Optional)]
    public new const string Prev = "/Prev";
    [KeyInfo(KeyType.Array | KeyType.Required)]
    public const string W = "/W";
    private static DictionaryMeta _meta;

    public new static DictionaryMeta Meta
    {
      get
      {
        return PdfCrossReferenceStream.Keys._meta ?? (PdfCrossReferenceStream.Keys._meta = KeysBase.CreateMeta(typeof (PdfCrossReferenceStream.Keys)));
      }
    }
  }
}
