// Decompiled with JetBrains decompiler
// Type: SmartAssembly.HouseOfCards.MemberRefsProxy
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

#nullable disable
namespace SmartAssembly.HouseOfCards;

public static class MemberRefsProxy
{
  internal Label \u000E;
  internal NumericUpDown \u0005;

  static MemberRefsProxy() => \u0008.\u0005.\u0001 = new Dictionary<string, Assembly>();

  public string \u0001(bool _param1)
  {
    StringBuilder stringBuilder = new StringBuilder();
    stringBuilder.Append(((\u0008.\u0005) this).\u0001);
    if (_param1 && ((\u0008.\u0005) this).\u0001 != (Version) null)
    {
      stringBuilder.Append(", Version=");
      stringBuilder.Append((object) ((\u0008.\u0005) this).\u0001);
    }
    stringBuilder.Append(", Culture=");
    stringBuilder.Append(((\u0008.\u0005) this).\u0002.Length == 0 ? "neutral" : ((\u0008.\u0005) this).\u0002);
    stringBuilder.Append(", PublicKeyToken=");
    stringBuilder.Append(((\u0008.\u0005) this).\u0003.Length == 0 ? "null" : ((\u0008.\u0005) this).\u0003);
    return stringBuilder.ToString();
  }
}
