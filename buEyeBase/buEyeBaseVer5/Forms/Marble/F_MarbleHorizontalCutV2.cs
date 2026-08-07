// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleHorizontalCutV2
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.Apps.Marble;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleHorizontalCutV2 : Form
{
  public Color clrButtonDown;
  internal IContainer \u0001;
  public buButton btn_contourmenueditor;
  public buButton btn_contourmenufilelist;
  public buButton btn_close;
  internal buSeparator \u0001;
  internal buSeparator \u0002;
  internal ImageList \u0001;
  internal ImageList \u0002;
  public buButton btn_camsettings;
  public buButton btn_toolsettings;
  public buButton btn_strategy;
  public buButton btn_tool;
  public buGround buGround1;
  public buLabel lbl_strategytype;
  public buLabel lbl_tooltype;
  public buLabel lbl_contourtype;
  public buCheckBox chk_addtonesting;
  public buCheckBox chk_insidemilling;
  internal buSeparator \u0003;
  public buLabel lbl_events;
  public buCheckBox chk_rotate90plus;
  public buCheckBox chk_rotate180plus;
  public buCheckBox chk_rotate90minus;
  public buCheckBox chk_rotate180minus;
  public buCheckBox chk_mirroY;
  public buCheckBox chk_mirrorX;
  public buButton btn_objectlocation;
  internal ImageList \u0003;
  public static byte f002899;
  public Color SpinBaseColor;
  public Color SpinFocusColor;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public MarbleTextMenuType TextType;
  public MarbleItemType ItemType;
  public marbleMenuType MenuType;
  public Color clrLabel;
  public Color clrFormCaption;
  public Color clrFormBackUpper;
  public Color clrFormBackDown;
  public Color clrButtonDisplay;
  public Color clrButtonOver;
  public Color clrButtonDown;
  internal IContainer \u0001;
  public buButton btn_textfont;
  public buButton btn_textfromfile;
  public buButton btn_textwireframe;
  public buButton btn_close;
  public buCheckBox chk_3D;
  internal ImageList \u0001;
  internal ImageList \u0002;
  public buButton btn_camsettings;
  public buButton btn_toolsettings;
  public buButton btn_strategy;
  public buButton btn_tool;
  internal buSeparator \u0001;
  internal buSeparator \u0002;
  public buGround buGround1;
  public buLabel lbl_strategytype;

  public void Apply()
  {
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    // ISSUE: unable to decompile the method.
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleCutting) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleCutting) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleCutting) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }
}
