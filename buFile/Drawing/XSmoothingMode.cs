// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.XSmoothingMode
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;

#nullable disable
namespace PdfSharp.Drawing;

[Flags]
public enum XSmoothingMode
{
  Invalid = -1, // 0xFFFFFFFF
  Default = 0,
  HighSpeed = 1,
  HighQuality = 2,
  None = HighQuality | HighSpeed, // 0x00000003
  AntiAlias = 4,
}
