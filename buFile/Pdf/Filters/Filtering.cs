// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Filters.Filtering
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;
using System.Diagnostics;

#nullable disable
namespace PdfSharp.Pdf.Filters;

public static class Filtering
{
  private static AsciiHexDecode _asciiHexDecode;
  private static Ascii85Decode _ascii85Decode;
  private static LzwDecode _lzwDecode;
  private static FlateDecode _flateDecode;

  public static Filter GetFilter(string filterName)
  {
    if (filterName.StartsWith("/"))
      filterName = filterName.Substring(1);
    Filter filter;
    switch (filterName)
    {
      case "A85":
      case "ASCII85Decode":
        filter = (Filter) (Filtering._ascii85Decode ?? (Filtering._ascii85Decode = new Ascii85Decode()));
        break;
      case "AHx":
      case "ASCIIHexDecode":
        filter = (Filter) (Filtering._asciiHexDecode ?? (Filtering._asciiHexDecode = new AsciiHexDecode()));
        break;
      case "CCITTFaxDecode":
      case "Crypt":
      case "DCTDecode":
      case "JBIG2Decode":
      case "JPXDecode":
      case "RunLengthDecode":
        Debug.WriteLine("Filter not implemented: " + filterName);
        filter = (Filter) null;
        break;
      case "Fl":
      case "FlateDecode":
        filter = (Filter) (Filtering._flateDecode ?? (Filtering._flateDecode = new FlateDecode()));
        break;
      case "LZW":
      case "LZWDecode":
        filter = (Filter) (Filtering._lzwDecode ?? (Filtering._lzwDecode = new LzwDecode()));
        break;
      default:
        throw new NotImplementedException("Unknown filter: " + filterName);
    }
    return filter;
  }

  public static AsciiHexDecode ASCIIHexDecode
  {
    get => Filtering._asciiHexDecode ?? (Filtering._asciiHexDecode = new AsciiHexDecode());
  }

  public static Ascii85Decode ASCII85Decode
  {
    get => Filtering._ascii85Decode ?? (Filtering._ascii85Decode = new Ascii85Decode());
  }

  public static LzwDecode LzwDecode
  {
    get => Filtering._lzwDecode ?? (Filtering._lzwDecode = new LzwDecode());
  }

  public static FlateDecode FlateDecode
  {
    get => Filtering._flateDecode ?? (Filtering._flateDecode = new FlateDecode());
  }

  public static byte[] Encode(byte[] data, string filterName)
  {
    Filter filter = Filtering.GetFilter(filterName);
    return filter == null ? (byte[]) null : filter.Encode(data);
  }

  public static byte[] Encode(string rawString, string filterName)
  {
    Filter filter = Filtering.GetFilter(filterName);
    return filter == null ? (byte[]) null : filter.Encode(rawString);
  }

  public static byte[] Decode(byte[] data, string filterName, FilterParms parms)
  {
    Filter filter = Filtering.GetFilter(filterName);
    return filter == null ? (byte[]) null : filter.Decode(data, parms);
  }

  public static byte[] Decode(byte[] data, string filterName)
  {
    Filter filter = Filtering.GetFilter(filterName);
    return filter == null ? (byte[]) null : filter.Decode(data, (FilterParms) null);
  }

  public static byte[] Decode(byte[] data, PdfItem filterItem)
  {
    byte[] numArray = (byte[]) null;
    switch (filterItem)
    {
      case PdfName _:
        Filter filter = Filtering.GetFilter(filterItem.ToString());
        if (filter != null)
        {
          numArray = filter.Decode(data);
          break;
        }
        break;
      case PdfArray _:
        foreach (PdfItem filterItem1 in (PdfArray) filterItem)
          data = Filtering.Decode(data, filterItem1);
        numArray = data;
        break;
    }
    return numArray;
  }

  public static string DecodeToString(byte[] data, string filterName, FilterParms parms)
  {
    Filter filter = Filtering.GetFilter(filterName);
    return filter == null ? (string) null : filter.DecodeToString(data, parms);
  }

  public static string DecodeToString(byte[] data, string filterName)
  {
    Filter filter = Filtering.GetFilter(filterName);
    return filter == null ? (string) null : filter.DecodeToString(data, (FilterParms) null);
  }
}
