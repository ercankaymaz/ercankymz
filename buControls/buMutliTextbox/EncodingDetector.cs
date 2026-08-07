// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.EncodingDetector
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

#nullable disable
namespace buMutliTextbox;

public static class EncodingDetector
{
  public static Encoding DetectTextFileEncoding(string InputFilename)
  {
    using (FileStream InputFileStream = File.OpenRead(InputFilename))
      return EncodingDetector.DetectTextFileEncoding(InputFileStream, 65536L /*0x010000*/);
  }

  public static Encoding DetectTextFileEncoding(
    FileStream InputFileStream,
    long HeuristicSampleSize)
  {
    bool HasBOM = false;
    return EncodingDetector.DetectTextFileEncoding(InputFileStream, 65536L /*0x010000*/, out HasBOM);
  }

  public static Encoding DetectTextFileEncoding(
    FileStream InputFileStream,
    long HeuristicSampleSize,
    out bool HasBOM)
  {
    long position = InputFileStream.Position;
    InputFileStream.Position = 0L;
    byte[] numArray1 = new byte[InputFileStream.Length > 4L ? new IntPtr(4) : checked ((IntPtr) InputFileStream.Length)];
    InputFileStream.Read(numArray1, 0, numArray1.Length);
    Encoding encoding1 = EncodingDetector.DetectBOMBytes(numArray1);
    Encoding encoding2;
    if (encoding1 != null)
    {
      InputFileStream.Position = position;
      HasBOM = true;
      encoding2 = encoding1;
    }
    else
    {
      byte[] numArray2 = new byte[HeuristicSampleSize > InputFileStream.Length ? checked ((IntPtr) InputFileStream.Length) : checked ((IntPtr) HeuristicSampleSize)];
      Array.Copy((Array) numArray1, (Array) numArray2, numArray1.Length);
      if (InputFileStream.Length > (long) numArray1.Length)
        InputFileStream.Read(numArray2, numArray1.Length, numArray2.Length - numArray1.Length);
      InputFileStream.Position = position;
      Encoding encoding3 = EncodingDetector.DetectUnicodeInByteSampleByHeuristics(numArray2);
      HasBOM = false;
      encoding2 = encoding3;
    }
    return encoding2;
  }

  public static Encoding DetectBOMBytes(byte[] BOMBytes)
  {
    return BOMBytes.Length >= 2 ? ((BOMBytes[0] != byte.MaxValue || BOMBytes[1] != (byte) 254 ? 0 : (BOMBytes.Length < 4 || BOMBytes[2] != (byte) 0 ? 1 : (BOMBytes[3] > (byte) 0 ? 1 : 0))) == 0 ? ((BOMBytes[0] != (byte) 254 ? 0 : (BOMBytes[1] == byte.MaxValue ? 1 : 0)) == 0 ? (BOMBytes.Length >= 3 ? ((BOMBytes[0] != (byte) 239 || BOMBytes[1] != (byte) 187 ? 0 : (BOMBytes[2] == (byte) 191 ? 1 : 0)) == 0 ? ((BOMBytes[0] != (byte) 43 || BOMBytes[1] != (byte) 47 ? 0 : (BOMBytes[2] == (byte) 118 ? 1 : 0)) == 0 ? (BOMBytes.Length >= 4 ? ((BOMBytes[0] != byte.MaxValue || BOMBytes[1] != (byte) 254 || BOMBytes[2] != (byte) 0 ? 0 : (BOMBytes[3] == (byte) 0 ? 1 : 0)) == 0 ? ((BOMBytes[0] != (byte) 0 || BOMBytes[1] != (byte) 0 || BOMBytes[2] != (byte) 254 ? 0 : (BOMBytes[3] == byte.MaxValue ? 1 : 0)) == 0 ? (Encoding) null : Encoding.GetEncoding(12001)) : Encoding.UTF32) : (Encoding) null) : Encoding.UTF7) : Encoding.UTF8) : (Encoding) null) : Encoding.BigEndianUnicode) : Encoding.Unicode) : (Encoding) null;
  }

  public static Encoding DetectUnicodeInByteSampleByHeuristics(byte[] SampleBytes)
  {
    long num1 = 0;
    long num2 = 0;
    long num3 = 0;
    long num4 = 0;
    long num5 = 0;
    long long_0 = 0;
    int num6 = 0;
    for (; long_0 < (long) SampleBytes.Length; ++long_0)
    {
      if (SampleBytes[long_0] == (byte) 0)
      {
        if (long_0 % 2L == 0L)
          ++num2;
        else
          ++num1;
      }
      if (Class39.smethod_49(SampleBytes[long_0]))
        ++num5;
      if (num6 == 0)
      {
        int num7 = Class39.smethod_598(long_0, SampleBytes);
        if (num7 > 0)
        {
          ++num3;
          num4 += (long) num7;
          num6 = num7 - 1;
        }
      }
      else
        --num6;
    }
    return ((double) num2 * 2.0 / (double) SampleBytes.Length >= 0.2 ? 0 : ((double) num1 * 2.0 / (double) SampleBytes.Length > 0.6 ? 1 : 0)) == 0 ? (((double) num1 * 2.0 / (double) SampleBytes.Length >= 0.2 ? 0 : ((double) num2 * 2.0 / (double) SampleBytes.Length > 0.6 ? 1 : 0)) == 0 ? (!new Regex("\\A([\\x09\\x0A\\x0D\\x20-\\x7E]|[\\xC2-\\xDF][\\x80-\\xBF]|\\xE0[\\xA0-\\xBF][\\x80-\\xBF]|[\\xE1-\\xEC\\xEE\\xEF][\\x80-\\xBF]{2}|\\xED[\\x80-\\x9F][\\x80-\\xBF]|\\xF0[\\x90-\\xBF][\\x80-\\xBF]{2}|[\\xF1-\\xF3][\\x80-\\xBF]{3}|\\xF4[\\x80-\\x8F][\\x80-\\xBF]{2})*\\z").IsMatch(Encoding.ASCII.GetString(SampleBytes)) || ((double) num3 * 500000.0 / (double) SampleBytes.Length < 1.0 ? 0 : ((long) SampleBytes.Length - num4 == 0L ? 1 : ((double) num5 * 1.0 / (double) ((long) SampleBytes.Length - num4) >= 0.8 ? 1 : 0))) == 0 ? (Encoding) null : Encoding.UTF8) : Encoding.BigEndianUnicode) : Encoding.Unicode;
  }
}
