// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Filters.FlateDecode
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.SharpZipLib.Zip.Compression;
using PdfSharp.SharpZipLib.Zip.Compression.Streams;
using System.IO;

#nullable disable
namespace PdfSharp.Pdf.Filters;

public class FlateDecode : Filter
{
  public override byte[] Encode(byte[] data) => this.Encode(data, PdfFlateEncodeMode.Default);

  public byte[] Encode(byte[] data, PdfFlateEncodeMode mode)
  {
    MemoryStream baseOutputStream = new MemoryStream();
    int level = -1;
    switch (mode)
    {
      case PdfFlateEncodeMode.BestSpeed:
        level = 1;
        break;
      case PdfFlateEncodeMode.BestCompression:
        level = 9;
        break;
    }
    DeflaterOutputStream deflaterOutputStream = new DeflaterOutputStream((Stream) baseOutputStream, new Deflater(level, false));
    deflaterOutputStream.Write(data, 0, data.Length);
    deflaterOutputStream.Finish();
    baseOutputStream.Capacity = (int) baseOutputStream.Length;
    return baseOutputStream.GetBuffer();
  }

  public override byte[] Decode(byte[] data, FilterParms parms)
  {
    MemoryStream baseInputStream = new MemoryStream(data);
    MemoryStream memoryStream = new MemoryStream();
    InflaterInputStream inflaterInputStream = new InflaterInputStream((Stream) baseInputStream, new Inflater(false));
    byte[] buffer = new byte[32768 /*0x8000*/];
    int count;
    do
    {
      count = inflaterInputStream.Read(buffer, 0, buffer.Length);
      if (count > 0)
        goto label_2;
label_1:
      continue;
label_2:
      memoryStream.Write(buffer, 0, count);
      goto label_1;
    }
    while (count > 0);
    inflaterInputStream.Close();
    memoryStream.Flush();
    byte[] numArray;
    if (memoryStream.Length >= 0L)
    {
      memoryStream.Capacity = (int) memoryStream.Length;
      numArray = memoryStream.GetBuffer();
    }
    else
      numArray = (byte[]) null;
    return numArray;
  }
}
