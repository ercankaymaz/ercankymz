// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.PdfObjectID
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;
using System.Diagnostics;
using System.Globalization;

#nullable disable
namespace PdfSharp.Pdf;

[System.Diagnostics.DebuggerDisplay("{DebuggerDisplay}")]
public struct PdfObjectID : IComparable
{
  private readonly int _objectNumber;
  private readonly ushort _generationNumber;

  public PdfObjectID(int objectNumber)
  {
    Debug.Assert(objectNumber >= 1, "Object number out of range.");
    this._objectNumber = objectNumber;
    this._generationNumber = (ushort) 0;
  }

  public PdfObjectID(int objectNumber, int generationNumber)
  {
    Debug.Assert(objectNumber >= 1, "Object number out of range.");
    this._objectNumber = objectNumber;
    this._generationNumber = (ushort) generationNumber;
  }

  public int ObjectNumber => this._objectNumber;

  public int GenerationNumber => (int) this._generationNumber;

  public bool IsEmpty => this._objectNumber == 0;

  public override bool Equals(object obj)
  {
    return obj is PdfObjectID pdfObjectId && this._objectNumber == pdfObjectId._objectNumber && (int) this._generationNumber == (int) pdfObjectId._generationNumber;
  }

  public override int GetHashCode() => this._objectNumber ^ (int) this._generationNumber;

  public static bool operator ==(PdfObjectID left, PdfObjectID right)
  {
    return left.Equals((object) right);
  }

  public static bool operator !=(PdfObjectID left, PdfObjectID right)
  {
    return !left.Equals((object) right);
  }

  public override string ToString()
  {
    return $"{this._objectNumber.ToString((IFormatProvider) CultureInfo.InvariantCulture)} {this._generationNumber.ToString((IFormatProvider) CultureInfo.InvariantCulture)}";
  }

  public static PdfObjectID Empty => new PdfObjectID();

  public int CompareTo(object obj)
  {
    return !(obj is PdfObjectID pdfObjectId) ? 1 : (this._objectNumber != pdfObjectId._objectNumber ? this._objectNumber - pdfObjectId._objectNumber : (int) this._generationNumber - (int) pdfObjectId._generationNumber);
  }

  internal string DebuggerDisplay => $"id=({this.ToString()})";
}
