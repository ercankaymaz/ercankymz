// Decompiled with JetBrains decompiler
// Type: ns7.Class32
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

#nullable disable
namespace ns7;

internal class Class32
{
  private static readonly string string_0 = "1";
  private static readonly string string_1 = "17";
  internal static readonly byte[] byte_0 = (byte[]) null;
  internal static readonly Dictionary<int, string> dictionary_0;
  internal static readonly object object_0 = new object();
  internal static readonly bool bool_0 = false;
  private static readonly int int_0 = 0;

  public static string smethod_0(int int_1) => Class32.Class33.smethod_0(int_1);

  static Class32()
  {
    if (Class32.string_0 == "1")
    {
      Class32.bool_0 = true;
      Class32.dictionary_0 = new Dictionary<int, string>();
    }
    Class32.int_0 = Convert.ToInt32(Class32.string_1);
    using (Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("{21efdfc3-0630-48bd-8756-22f26806796f}"))
    {
      int int32 = Convert.ToInt32(manifestResourceStream.Length);
      byte[] numArray = new byte[int32];
      manifestResourceStream.Read(numArray, 0, int32);
      Class32.byte_0 = Class30.smethod_277(numArray);
    }
  }

  public static class Class33
  {
    public static string smethod_0(int int_0)
    {
      int_0 ^= 107396847;
      int_0 -= Class32.int_0;
      return !Class32.bool_0 ? Class30.smethod_174(int_0) : Class30.smethod_71(int_0);
    }
  }
}
