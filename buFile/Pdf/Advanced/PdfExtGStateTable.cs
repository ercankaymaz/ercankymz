// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Advanced.PdfExtGStateTable
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System.Collections.Generic;

#nullable disable
namespace PdfSharp.Pdf.Advanced;

public sealed class PdfExtGStateTable(PdfDocument document) : PdfResourceTable(document)
{
  private readonly Dictionary<string, PdfExtGState> _strokeAlphaValues = new Dictionary<string, PdfExtGState>();
  private readonly Dictionary<string, PdfExtGState> _nonStrokeStates = new Dictionary<string, PdfExtGState>();

  public PdfExtGState GetExtGStateStroke(double alpha, bool overprint)
  {
    string key = PdfExtGState.MakeKey(alpha, overprint);
    PdfExtGState extGstateStroke;
    if (!this._strokeAlphaValues.TryGetValue(key, out extGstateStroke))
    {
      extGstateStroke = new PdfExtGState(this.Owner);
      extGstateStroke.StrokeAlpha = alpha;
      if (overprint)
      {
        extGstateStroke.StrokeOverprint = true;
        extGstateStroke.Elements.SetInteger("/OPM", 1);
      }
      this._strokeAlphaValues[key] = extGstateStroke;
    }
    return extGstateStroke;
  }

  public PdfExtGState GetExtGStateNonStroke(double alpha, bool overprint)
  {
    string key = PdfExtGState.MakeKey(alpha, overprint);
    PdfExtGState extGstateNonStroke;
    if (!this._nonStrokeStates.TryGetValue(key, out extGstateNonStroke))
    {
      extGstateNonStroke = new PdfExtGState(this.Owner);
      extGstateNonStroke.NonStrokeAlpha = alpha;
      if (overprint)
      {
        extGstateNonStroke.NonStrokeOverprint = true;
        extGstateNonStroke.Elements.SetInteger("/OPM", 1);
      }
      this._nonStrokeStates[key] = extGstateNonStroke;
    }
    return extGstateNonStroke;
  }
}
