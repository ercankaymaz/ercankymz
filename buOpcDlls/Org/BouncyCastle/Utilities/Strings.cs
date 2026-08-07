// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.Strings
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Text;

#nullable disable
namespace Org.BouncyCastle.Utilities;

public static class Strings
{
  internal static bool IsOneOf(string s, params string[] candidates)
  {
    foreach (string candidate in candidates)
    {
      if (s == candidate)
        return true;
    }
    return false;
  }

  public static string FromByteArray(byte[] bs)
  {
    char[] chArray = new char[bs.Length];
    for (int index = 0; index < chArray.Length; ++index)
      chArray[index] = Convert.ToChar(bs[index]);
    return new string(chArray);
  }

  public static byte[] ToByteArray(char[] cs)
  {
    byte[] byteArray = new byte[cs.Length];
    for (int index = 0; index < byteArray.Length; ++index)
      byteArray[index] = Convert.ToByte(cs[index]);
    return byteArray;
  }

  public static byte[] ToByteArray(string s)
  {
    byte[] byteArray = new byte[s.Length];
    for (int index = 0; index < byteArray.Length; ++index)
      byteArray[index] = Convert.ToByte(s[index]);
    return byteArray;
  }

  public static string FromAsciiByteArray(byte[] bytes) => Encoding.ASCII.GetString(bytes);

  public static byte[] ToAsciiByteArray(char[] cs) => Encoding.ASCII.GetBytes(cs);

  public static byte[] ToAsciiByteArray(string s) => Encoding.ASCII.GetBytes(s);

  public static string FromUtf8ByteArray(byte[] bytes) => Encoding.UTF8.GetString(bytes);

  public static string FromUtf8ByteArray(byte[] bytes, int index, int count)
  {
    return Encoding.UTF8.GetString(bytes, index, count);
  }

  public static byte[] ToUtf8ByteArray(char[] cs) => Encoding.UTF8.GetBytes(cs);

  public static byte[] ToUtf8ByteArray(string s) => Encoding.UTF8.GetBytes(s);
}
