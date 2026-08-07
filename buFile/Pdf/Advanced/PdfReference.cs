// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Advanced.PdfReference
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.Diagnostics;

#nullable disable
namespace PdfSharp.Pdf.Advanced;

[DebuggerDisplay("iref({ObjectNumber}, {GenerationNumber})")]
public sealed class PdfReference : PdfItem
{
  private PdfObjectID _objectID;
  private int _position;
  private PdfObject _value;
  private PdfDocument _document;

  public PdfReference(PdfObject pdfObject)
  {
    this._value = pdfObject.Reference == null ? pdfObject : throw new InvalidOperationException("Must not create iref for an object that already has one.");
    pdfObject.Reference = this;
  }

  public PdfReference(PdfObjectID objectID, int position)
  {
    this._objectID = objectID;
    this._position = position;
  }

  internal void WriteXRefEnty(PdfWriter writer)
  {
    string rawString = $"{this._position:0000000000} {this._objectID.GenerationNumber:00000} n\n";
    writer.WriteRaw(rawString);
  }

  internal override void WriteObject(PdfWriter writer) => writer.Write(this);

  public PdfObjectID ObjectID
  {
    get => this._objectID;
    set
    {
      if (this._objectID == value)
        return;
      this._objectID = value;
      if (this.Document != null)
        ;
    }
  }

  public int ObjectNumber => this._objectID.ObjectNumber;

  public int GenerationNumber => this._objectID.GenerationNumber;

  public int Position
  {
    get => this._position;
    set => this._position = value;
  }

  public PdfObject Value
  {
    get => this._value;
    set
    {
      Debug.Assert(value != null, "The value of a PdfReference must never be null.");
      Debug.Assert(value.Reference == null || value.Reference == this, "The reference of the value must be null or this.");
      this._value = value;
      value.Reference = this;
    }
  }

  internal void SetObject(PdfObject value) => this._value = value;

  public PdfDocument Document
  {
    get => this._document;
    set => this._document = value;
  }

  public override string ToString() => this._objectID.ToString() + " R";

  internal static PdfReference.PdfReferenceComparer Comparer
  {
    get => new PdfReference.PdfReferenceComparer();
  }

  internal class PdfReferenceComparer : IComparer<PdfReference>
  {
    public int Compare(PdfReference x, PdfReference y)
    {
      PdfReference pdfReference1 = x;
      PdfReference pdfReference2 = y;
      return pdfReference1 == null ? (pdfReference2 == null ? 0 : 1) : (pdfReference2 == null ? -1 : pdfReference1._objectID.CompareTo((object) pdfReference2._objectID));
    }
  }
}
