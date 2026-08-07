// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Internal.PdfDiagnostics
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

#nullable disable
namespace PdfSharp.Pdf.Internal;

internal class PdfDiagnostics
{
  private static bool _traceCompressedObjects = true;
  private static bool _traceXrefStreams = true;
  private static bool _traceObjectStreams = true;

  public static bool TraceCompressedObjects
  {
    get => PdfDiagnostics._traceCompressedObjects;
    set => PdfDiagnostics._traceCompressedObjects = value;
  }

  public static bool TraceXrefStreams
  {
    get => PdfDiagnostics._traceXrefStreams && PdfDiagnostics.TraceCompressedObjects;
    set => PdfDiagnostics._traceXrefStreams = value;
  }

  public static bool TraceObjectStreams
  {
    get => PdfDiagnostics._traceObjectStreams && PdfDiagnostics.TraceCompressedObjects;
    set => PdfDiagnostics._traceObjectStreams = value;
  }
}
