// Decompiled with JetBrains decompiler
// Type: PdfSharp.SharpZipLib.Zip.ZipException
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;

#nullable disable
namespace PdfSharp.SharpZipLib.Zip;

internal class ZipException : SharpZipBaseException
{
  public ZipException()
  {
  }

  public ZipException(string message)
    : base(message)
  {
  }

  public ZipException(string message, Exception exception)
    : base(message, exception)
  {
  }
}
