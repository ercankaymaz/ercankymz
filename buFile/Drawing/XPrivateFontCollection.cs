// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.XPrivateFontCollection
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace PdfSharp.Drawing;

public sealed class XPrivateFontCollection
{
  internal static XPrivateFontCollection _singleton = new XPrivateFontCollection();
  private readonly Dictionary<string, XGlyphTypeface> _typefaces = new Dictionary<string, XGlyphTypeface>();

  private XPrivateFontCollection()
  {
  }

  internal static XPrivateFontCollection Singleton => XPrivateFontCollection._singleton;

  [Obsolete("Use Add(Stream stream)")]
  public static void AddFont(string filename) => throw new NotImplementedException();

  [Obsolete("Use Add(Stream stream)")]
  public static void AddFont(Stream stream, string facename) => throw new NotImplementedException();

  private static string MakeKey(string familyName, XFontStyle style)
  {
    return XPrivateFontCollection.MakeKey(familyName, (style & XFontStyle.Bold) != 0, (style & XFontStyle.Italic) != 0);
  }

  private static string MakeKey(string familyName, bool bold, bool italic)
  {
    return $"{familyName}#{(bold ? "b" : "")}{(italic ? "i" : "")}";
  }
}
