// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.DocumentState
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;

#nullable disable
namespace PdfSharp.Pdf;

[Flags]
internal enum DocumentState
{
  Created = 1,
  Imported = 2,
  Disposed = 32768, // 0x00008000
}
