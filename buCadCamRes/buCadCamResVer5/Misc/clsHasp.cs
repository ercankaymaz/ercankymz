// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Misc.clsHasp
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buClass;
using System;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5.Misc;

public class clsHasp
{
  public static bool InitHsKey(ref string Code)
  {
    try
    {
      string scope = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?> <haspscope/> ";
      HaspDemo haspDemo = new HaspDemo(new TextBox());
      bool LoginStatus = false;
      string KeyCode = "";
      haspDemo.RunDemo(scope, ref LoginStatus, ref KeyCode);
      if (LoginStatus)
      {
        if (HaspDemo.KeyCode.Length < 27)
          return false;
        Code = HaspDemo.KeyCode;
      }
      return LoginStatus;
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
      return false;
    }
  }
}
