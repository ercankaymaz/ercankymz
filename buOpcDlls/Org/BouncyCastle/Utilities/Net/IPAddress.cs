// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.Net.IPAddress
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Utilities.Net;

public class IPAddress
{
  public static bool IsValid(string address)
  {
    return IPAddress.IsValidIPv4(address) || IPAddress.IsValidIPv6(address);
  }

  public static bool IsValidWithNetMask(string address)
  {
    return IPAddress.IsValidIPv4WithNetmask(address) || IPAddress.IsValidIPv6WithNetmask(address);
  }

  public static bool IsValidIPv4(string address)
  {
    int length = address.Length;
    switch (length)
    {
      case 7:
      case 8:
      case 9:
      case 10:
      case 11:
      case 12:
      case 13:
      case 14:
      case 15:
        int num = 0;
        for (int index = 0; index < 3; ++index)
        {
          int end = Platform.IndexOf(address, '.', num);
          if (!IPAddress.IsParseableIPv4Octet(address, num, end))
            return false;
          num = end + 1;
        }
        return IPAddress.IsParseableIPv4Octet(address, num, length);
      default:
        return false;
    }
  }

  public static bool IsValidIPv4WithNetmask(string address)
  {
    int length = Platform.IndexOf(address, '/');
    if (length < 1)
      return false;
    string address1 = address.Substring(0, length);
    string str = address.Substring(length + 1);
    if (!IPAddress.IsValidIPv4(address1))
      return false;
    return IPAddress.IsValidIPv4(str) || IPAddress.IsParseableIPv4Mask(str);
  }

  public static bool IsValidIPv6(string address)
  {
    if (address.Length == 0 || address[0] != ':' && IPAddress.GetDigitHexadecimal(address, 0) < 0)
      return false;
    int num1 = 0;
    string str1 = address + ":";
    bool flag = false;
    int num2 = 0;
    int end;
    while (num2 < str1.Length && (end = Platform.IndexOf(str1, ':', num2)) >= num2)
    {
      if (num1 == 8)
        return false;
      if (num2 != end)
      {
        string str2 = str1.Substring(num2, end - num2);
        if (end == str1.Length - 1 && Platform.IndexOf(str2, '.') > 0)
        {
          if (++num1 == 8 || !IPAddress.IsValidIPv4(str2))
            return false;
        }
        else if (!IPAddress.IsParseableIPv6Segment(str1, num2, end))
          return false;
      }
      else
      {
        if (((end == 1 ? 0 : (end != str1.Length - 1 ? 1 : 0)) & (flag ? 1 : 0)) != 0)
          return false;
        flag = true;
      }
      num2 = end + 1;
      ++num1;
    }
    return num1 == 8 | flag;
  }

  public static bool IsValidIPv6WithNetmask(string address)
  {
    int length = Platform.IndexOf(address, '/');
    if (length < 1)
      return false;
    string address1 = address.Substring(0, length);
    string str = address.Substring(length + 1);
    if (!IPAddress.IsValidIPv6(address1))
      return false;
    return IPAddress.IsValidIPv6(str) || IPAddress.IsParseableIPv6Mask(str);
  }

  private static bool IsParseableIPv4Mask(string s)
  {
    return IPAddress.IsParseableDecimal(s, 0, s.Length, 2, false, 0, 32 /*0x20*/);
  }

  private static bool IsParseableIPv4Octet(string s, int pos, int end)
  {
    return IPAddress.IsParseableDecimal(s, pos, end, 3, true, 0, (int) byte.MaxValue);
  }

  private static bool IsParseableIPv6Mask(string s)
  {
    return IPAddress.IsParseableDecimal(s, 0, s.Length, 3, false, 1, 128 /*0x80*/);
  }

  private static bool IsParseableIPv6Segment(string s, int pos, int end)
  {
    return IPAddress.IsParseableHexadecimal(s, pos, end, 4, true, 0, (int) ushort.MaxValue);
  }

  private static bool IsParseableDecimal(
    string s,
    int pos,
    int end,
    int maxLength,
    bool allowLeadingZero,
    int minValue,
    int maxValue)
  {
    int num1 = end - pos;
    if (num1 < 1 | num1 > maxLength || num1 > 1 & !allowLeadingZero && s[pos] == '0')
      return false;
    int num2 = 0;
    while (pos < end)
    {
      int digitDecimal = IPAddress.GetDigitDecimal(s, pos++);
      if (digitDecimal < 0)
        return false;
      num2 = num2 * 10 + digitDecimal;
    }
    return num2 >= minValue & num2 <= maxValue;
  }

  private static bool IsParseableHexadecimal(
    string s,
    int pos,
    int end,
    int maxLength,
    bool allowLeadingZero,
    int minValue,
    int maxValue)
  {
    int num1 = end - pos;
    if (num1 < 1 | num1 > maxLength || num1 > 1 & !allowLeadingZero && s[pos] == '0')
      return false;
    int num2 = 0;
    while (pos < end)
    {
      int digitHexadecimal = IPAddress.GetDigitHexadecimal(s, pos++);
      if (digitHexadecimal < 0)
        return false;
      num2 = num2 * 16 /*0x10*/ + digitHexadecimal;
    }
    return num2 >= minValue & num2 <= maxValue;
  }

  private static int GetDigitDecimal(string s, int pos)
  {
    uint num = (uint) s[pos] - 48U /*0x30*/;
    return num > 9U ? -1 : (int) num;
  }

  private static int GetDigitHexadecimal(string s, int pos)
  {
    uint num1 = (uint) s[pos] | 32U /*0x20*/;
    uint num2 = num1 - (num1 >= 97U ? 87U : 48U /*0x30*/);
    return num2 > 16U /*0x10*/ ? -1 : (int) num2;
  }
}
