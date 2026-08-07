// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Filters.Filter
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Pdf.Internal;

#nullable disable
namespace PdfSharp.Pdf.Filters;

public abstract class Filter
{
  public abstract byte[] Encode(byte[] data);

  public virtual byte[] Encode(string rawString)
  {
    return this.Encode(PdfEncoders.RawEncoding.GetBytes(rawString));
  }

  public abstract byte[] Decode(byte[] data, FilterParms parms);

  public byte[] Decode(byte[] data) => this.Decode(data, (FilterParms) null);

  public virtual string DecodeToString(byte[] data, FilterParms parms)
  {
    byte[] bytes = this.Decode(data, parms);
    return PdfEncoders.RawEncoding.GetString(bytes, 0, bytes.Length);
  }

  public string DecodeToString(byte[] data) => this.DecodeToString(data, (FilterParms) null);

  protected byte[] RemoveWhiteSpace(byte[] data)
  {
    int length1 = data.Length;
    int length2 = 0;
    int index1 = 0;
    while (index1 < length1)
    {
      byte num = data[index1];
      if (num <= (byte) 10)
      {
        if (num == (byte) 0 || (uint) num - 9U <= 1U)
          goto label_6;
      }
      else if ((uint) num - 12U <= 1U || num == (byte) 32 /*0x20*/)
        goto label_6;
      if (index1 != length2)
      {
        data[length2] = data[index1];
        goto label_7;
      }
      goto label_7;
label_6:
      --length2;
label_7:
      ++index1;
      ++length2;
    }
    if (length2 < length1)
    {
      byte[] numArray = data;
      data = new byte[length2];
      for (int index2 = 0; index2 < length2; ++index2)
        data[index2] = numArray[index2];
    }
    return data;
  }
}
