// Decompiled with JetBrains decompiler
// Type: PdfSharp.Internal.DiagnosticsHelper
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;

#nullable disable
namespace PdfSharp.Internal;

internal static class DiagnosticsHelper
{
  public static void HandleNotImplemented(string message)
  {
    string str = "Not implemented: " + message;
    switch (Diagnostics.NotImplementedBehaviour)
    {
      case NotImplementedBehaviour.DoNothing:
        break;
      case NotImplementedBehaviour.Log:
        Logger.Log(str);
        break;
      case NotImplementedBehaviour.Throw:
        DiagnosticsHelper.ThrowNotImplementedException(str);
        break;
      default:
        throw new ArgumentOutOfRangeException();
    }
  }

  public static void ThrowNotImplementedException(string message)
  {
    throw new NotImplementedException(message);
  }
}
