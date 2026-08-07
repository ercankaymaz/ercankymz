// Decompiled with JetBrains decompiler
// Type: PdfSharp.Internal.Diagnostics
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

#nullable disable
namespace PdfSharp.Internal;

internal static class Diagnostics
{
  private static NotImplementedBehaviour _notImplementedBehaviour;

  public static NotImplementedBehaviour NotImplementedBehaviour
  {
    get => Diagnostics._notImplementedBehaviour;
    set => Diagnostics._notImplementedBehaviour = value;
  }
}
