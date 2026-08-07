// Decompiled with JetBrains decompiler
// Type: dummy_ptr.{c4786be5-4d12-491c-8bef-494b08e93552}
// Assembly: buOpcUA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF9DFBD0-0B81-4B3D-BD5F-1E30872BDC2B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcUA.dll

using System;
using System.Runtime.InteropServices;
using System.Text;

#nullable disable
namespace dummy_ptr;

internal abstract class \u007Bc4786be5\u002D4d12\u002D491c\u002D8bef\u002D494b08e93552\u007D
{
  internal static readonly \u0004.\u0001.\u0005 \u0001;
  internal static readonly \u0004.\u0001.\u0003 \u0001;
  internal static readonly \u0004.\u0001.\u0002 \u0003;
  internal static readonly \u0004.\u0001.\u0001 \u0002;
  internal static readonly \u0004.\u0001.\u0004 \u0002;
  internal static readonly \u0004.\u0001.\u0005 \u0002;

  static byte[] \u0001([In] byte[] obj0)
  {
    // ISSUE: unable to decompile the method.
  }

  static string \u0001([In] int obj0)
  {
    int num1 = obj0;
    byte[] numArray1 = \u0005.\u0003.\u0001;
    int index1 = num1;
    int index2 = index1 + 1;
    int num2 = (int) numArray1[index1];
    int count;
    if ((num2 & 128 /*0x80*/) == 0)
    {
      count = num2;
      if (count == 0)
        return string.Empty;
    }
    else if ((num2 & 64 /*0x40*/) == 0)
    {
      count = ((num2 & 63 /*0x3F*/) << 8) + (int) \u0005.\u0003.\u0001[index2++];
    }
    else
    {
      int num3 = (num2 & 31 /*0x1F*/) << 24;
      byte[] numArray2 = \u0005.\u0003.\u0001;
      int index3 = index2;
      int num4 = index3 + 1;
      int num5 = (int) numArray2[index3] << 16 /*0x10*/;
      int num6 = num3 + num5;
      byte[] numArray3 = \u0005.\u0003.\u0001;
      int index4 = num4;
      int num7 = index4 + 1;
      int num8 = (int) numArray3[index4] << 8;
      int num9 = num6 + num8;
      byte[] numArray4 = \u0005.\u0003.\u0001;
      int index5 = num7;
      index2 = index5 + 1;
      int num10 = (int) numArray4[index5];
      count = num9 + num10;
    }
    try
    {
      byte[] bytes = Convert.FromBase64String(Encoding.UTF8.GetString(\u0005.\u0003.\u0001, index2, count));
      string str = string.Intern(Encoding.UTF8.GetString(bytes, 0, bytes.Length));
      if (\u0005.\u0003.\u0001)
        \u0002.\u0003.\u0001(obj0, str);
      return str;
    }
    catch
    {
      return (string) null;
    }
  }

  static \u0006.\u0001.\u0004 \u0001([In] \u0006.\u0001.\u0005 obj0)
  {
    byte[] destinationArray = new byte[obj0.\u0003];
    Array.Copy((Array) obj0.\u0002, obj0.\u0002, (Array) destinationArray, 0, obj0.\u0003);
    return (\u0006.\u0001.\u0004) new \u0006.\u0001.\u0006(destinationArray);
  }
}
