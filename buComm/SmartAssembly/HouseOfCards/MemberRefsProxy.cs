// Decompiled with JetBrains decompiler
// Type: SmartAssembly.HouseOfCards.MemberRefsProxy
// Assembly: buComm, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: F368091B-602E-4A5D-88CB-765F3FC3A1DE
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buComm.dll

using \u0003;
using buClass;
using System;
using System.IO;
using System.Net.Sockets;
using System.Reflection;

#nullable disable
namespace SmartAssembly.HouseOfCards;

public static class MemberRefsProxy
{
  internal Socket \u0001;
  internal StreamWriter \u0001;

  public MemberRefsProxy(string msg, string replyCode)
  {
    ((\u0002) this).\u0001 = -1;
    // ISSUE: explicit constructor call
    ((Exception) this).\u002Ector(msg);
    try
    {
      ((\u0002) this).\u0001 = int.Parse(replyCode);
    }
    catch (FormatException ex)
    {
      ((\u0002) this).\u0001 = -1;
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException((Exception) ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public abstract void m0000D3();
}
