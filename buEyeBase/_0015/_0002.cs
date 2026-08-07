// Decompiled with JetBrains decompiler
// Type: .
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Forms.Cam;
using buEyeBaseVer5.Forms.Controls;
using System;
using System.Runtime.InteropServices;

#nullable disable
namespace \u0015;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
internal class \u0002 : Attribute
{
  static void \u0001([In] F_ControlUICombo obj0)
  {
    string callMethod = "Profile Cut LoadLanguage";
    try
    {
      ((F_CamTriMeshSettings) obj0).buGround1.Text = buLangTranslate.preDef.Information;
      ((F_CamTriMeshSettings) obj0).btn_cancel.Text = buLangTranslate.preDef.Cancel;
      ((F_CamTriMeshSettings) obj0).btn_ok.Text = buLangTranslate.preDef.Ok;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }
}
