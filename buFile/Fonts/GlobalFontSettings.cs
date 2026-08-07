// Decompiled with JetBrains decompiler
// Type: PdfSharp.Fonts.GlobalFontSettings
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Internal;
using PdfSharp.Pdf;
using System;

#nullable disable
namespace PdfSharp.Fonts;

public static class GlobalFontSettings
{
  public const string DefaultFontName = "PlatformDefault";
  private static IFontResolver _fontResolver;
  private static PdfFontEncoding _fontEncoding;
  private static bool _fontEncodingInitialized;

  public static IFontResolver FontResolver
  {
    get => GlobalFontSettings._fontResolver;
    set
    {
      if (value == null)
        throw new ArgumentNullException();
      try
      {
        Lock.EnterFontFactory();
        if (GlobalFontSettings._fontResolver == value)
          return;
        if (FontFactory.HasFontSources)
          throw new InvalidOperationException("Must not change font resolver after is was once used.");
        GlobalFontSettings._fontResolver = value;
      }
      finally
      {
        Lock.ExitFontFactory();
      }
    }
  }

  public static PdfFontEncoding DefaultFontEncoding
  {
    get
    {
      if (!GlobalFontSettings._fontEncodingInitialized)
        GlobalFontSettings.DefaultFontEncoding = PdfFontEncoding.Unicode;
      return GlobalFontSettings._fontEncoding;
    }
    set
    {
      try
      {
        Lock.EnterFontFactory();
        if (GlobalFontSettings._fontEncodingInitialized)
        {
          if (GlobalFontSettings._fontEncoding != value)
            throw new InvalidOperationException("Must not change DefaultFontEncoding after is was set once.");
        }
        else
        {
          GlobalFontSettings._fontEncoding = value;
          GlobalFontSettings._fontEncodingInitialized = true;
        }
      }
      finally
      {
        Lock.ExitFontFactory();
      }
    }
  }
}
