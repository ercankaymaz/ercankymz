// Decompiled with JetBrains decompiler
// Type: ns0.Class9
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;

#nullable disable
namespace ns0;

internal class Class9
{
  internal const string string_0 = "{71461f04-2faa-4bb9-a0dd-28a79101b599}";
  private const int int_0 = 4;
  internal static Dictionary<string, Assembly> dictionary_0 = new Dictionary<string, Assembly>();

  internal static bool IsWebApplication
  {
    get
    {
      try
      {
        switch (Process.GetCurrentProcess().MainModule.ModuleName.ToLower())
        {
          case "w3wp.exe":
            return true;
          case "aspnet_wp.exe":
            return true;
        }
      }
      catch
      {
      }
      return false;
    }
  }

  internal struct Struct17
  {
    public string string_0;
    public Version version_0;
    public string string_1;
    public string string_2;

    public string method_0(bool bool_0)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(this.string_0);
      if (bool_0 && this.version_0 != (Version) null)
      {
        stringBuilder.Append(", Version=");
        stringBuilder.Append((object) this.version_0);
      }
      stringBuilder.Append(", Culture=");
      stringBuilder.Append(this.string_1.Length == 0 ? "neutral" : this.string_1);
      stringBuilder.Append(", PublicKeyToken=");
      stringBuilder.Append(this.string_2.Length == 0 ? "null" : this.string_2);
      return stringBuilder.ToString();
    }

    public Struct17(string string_3)
    {
      this.version_0 = (Version) null;
      this.string_1 = string.Empty;
      this.string_2 = string.Empty;
      this.string_0 = string.Empty;
      string str1 = string_3;
      char[] chArray = new char[1]{ ',' };
      foreach (string str2 in str1.Split(chArray))
      {
        string str3 = str2.Trim();
        if (str3.StartsWith("Version="))
          this.version_0 = new Version(str3.Substring(8));
        else if (str3.StartsWith("Culture="))
        {
          this.string_1 = str3.Substring(8);
          if (this.string_1 == "neutral")
            this.string_1 = string.Empty;
        }
        else if (str3.StartsWith("PublicKeyToken="))
        {
          this.string_2 = str3.Substring(15);
          if (this.string_2 == "null")
            this.string_2 = string.Empty;
        }
        else
          this.string_0 = str3;
      }
    }
  }
}
