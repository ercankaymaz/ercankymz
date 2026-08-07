// Decompiled with JetBrains decompiler
// Type: .
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Forms.Marble;
using System;
using System.Runtime.InteropServices;

#nullable disable
namespace \u001E;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method)]
internal class \u0001 : Attribute
{
  static void \u0001([In] F_MarbleEasyDraw obj0)
  {
    string callMethod = "Profile Cut LoadLanguage";
    try
    {
      ((F_MarbleTap) obj0).buGround1.Text = buLangTranslate.preDef.Drawing;
      ((F_MarbleTap) obj0).\u0001.Text = buLangTranslate.preDef.ByMouse;
      ((F_MarbleTap) obj0).lbl_commands.Text = buLangTranslate.preDef.Command;
      ((F_MarbleDrillPocketCam) obj0).lbl_items.Text = buLangTranslate.preDef.Item;
      ((F_MarbleTap) obj0).btn_settings.Text = buLangTranslate.preDef.Settings;
      ((F_MarbleTap) obj0).btn_open.Text = buLangTranslate.preDef.Open;
      ((F_MarbleTap) obj0).btn_save.Text = buLangTranslate.preDef.Save;
      ((F_MarbleTap) obj0).lbl_countertop.Text = buLangTranslate.preDef.Countertop;
      ((F_MarbleTap) obj0).btn_ok.Text = buLangTranslate.preDef.Ok;
      ((F_MarbleTap) obj0).btn_cancel.Text = buLangTranslate.preDef.Cancel;
      ((F_MarbleTap) obj0).btn_addtolist.Text = buLangTranslate.preDef.AddToList;
      ((F_MarbleDrillPocketCam) obj0).btn_polyline.Text = buLangTranslate.preDef.Line;
      ((F_MarbleDrillPocketCam) obj0).btn_arc.Text = buLangTranslate.preDef.Arc;
      ((F_MarbleDrillPocketCam) obj0).btn_circle.Text = buLangTranslate.preDef.Cirlce;
      ((F_MarbleDrillPocketCam) obj0).btn_rectangle.Text = buLangTranslate.preDef.Rectangle;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }
}
