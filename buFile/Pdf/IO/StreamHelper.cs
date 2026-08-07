// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.IO.StreamHelper
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System.Diagnostics;

#nullable disable
namespace PdfSharp.Pdf.IO;

internal static class StreamHelper
{
  public static int WSize(int[] w)
  {
    Debug.Assert(w.Length == 3);
    return w[0] + w[1] + w[2];
  }

  public static uint ReadBytes(byte[] bytes, int index, int byteCount)
  {
    uint num = 0;
    for (int index1 = 0; index1 < byteCount; ++index1)
      num = num * 256U /*0x0100*/ + (uint) bytes[index + index1];
    return num;
  }
}
