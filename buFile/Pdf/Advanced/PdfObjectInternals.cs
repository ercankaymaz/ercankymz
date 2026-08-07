// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Advanced.PdfObjectInternals
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

#nullable disable
namespace PdfSharp.Pdf.Advanced;

public class PdfObjectInternals
{
  private readonly PdfObject _obj;

  internal PdfObjectInternals(PdfObject obj) => this._obj = obj;

  public PdfObjectID ObjectID => this._obj.ObjectID;

  public int ObjectNumber => this._obj.ObjectID.ObjectNumber;

  public int GenerationNumber => this._obj.ObjectID.GenerationNumber;

  public string TypeID
  {
    get
    {
      return !(this._obj is PdfArray) ? (!(this._obj is PdfDictionary) ? this._obj.GetType().Name : "dictionary") : "array";
    }
  }
}
