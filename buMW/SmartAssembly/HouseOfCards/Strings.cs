// Decompiled with JetBrains decompiler
// Type: SmartAssembly.HouseOfCards.Strings
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using \u0008;
using System;

#nullable disable
namespace SmartAssembly.HouseOfCards;

public static class Strings
{
  public Strings(string _param1)
  {
    ((\u0005) this).\u0001 = (Version) null;
    ((\u0005) this).\u0002 = string.Empty;
    ((\u0005) this).\u0003 = string.Empty;
    ((\u0005) this).\u0001 = string.Empty;
    string str1 = _param1;
    char[] chArray = new char[1]{ ',' };
    foreach (string str2 in str1.Split(chArray))
    {
      string str3 = str2.Trim();
      if (str3.StartsWith("Version="))
        ((\u0005) this).\u0001 = new Version(str3.Substring(8));
      else if (str3.StartsWith("Culture="))
      {
        ((\u0005) this).\u0002 = str3.Substring(8);
        if (((\u0005) this).\u0002 == "neutral")
          ((\u0005) this).\u0002 = string.Empty;
      }
      else if (str3.StartsWith("PublicKeyToken="))
      {
        ((\u0005) this).\u0003 = str3.Substring(15);
        if (((\u0005) this).\u0003 == "null")
          ((\u0005) this).\u0003 = string.Empty;
      }
      else
        ((\u0005) this).\u0001 = str3;
    }
  }
}
