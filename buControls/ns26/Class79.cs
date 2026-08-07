// Decompiled with JetBrains decompiler
// Type: ns26.Class79
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

#nullable disable
namespace ns26;

internal sealed class Class79
{
  private static readonly string string_0 = "1";
  private static readonly string string_1 = "192";
  internal static readonly byte[] byte_0 = (byte[]) null;
  internal static readonly Dictionary<int, string> dictionary_0;
  internal static readonly object object_0 = new object();
  internal static readonly bool bool_0 = false;
  private static readonly int int_0 = 0;

  public static string smethod_0(int int_1) => Class79.Class80.smethod_0(int_1);

  static Class79()
  {
    if (Class79.string_0 == "1")
    {
      Class79.bool_0 = true;
      Class79.dictionary_0 = new Dictionary<int, string>();
    }
    Class79.int_0 = Convert.ToInt32(Class79.string_1);
    using (Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("{12887206-8450-4c5f-88b1-f2bdae7aafb0}"))
    {
      int int32 = Convert.ToInt32(manifestResourceStream.Length);
      byte[] numArray = new byte[int32];
      manifestResourceStream.Read(numArray, 0, int32);
      Class79.byte_0 = Class39.smethod_388(numArray);
    }
  }

  public static class Class80
  {
    public static string smethod_0(int int_0)
    {
      int_0 ^= 107396847;
      int_0 -= Class79.int_0;
      return !Class79.bool_0 ? Class39.smethod_425(int_0) : Class39.smethod_701(int_0);
    }
  }
}
