// Decompiled with JetBrains decompiler
// Type: buMarble.Forms.F_MarbleMDIV1
// Assembly: buMarble, Version=5.1.1.2, Culture=neutral, PublicKeyToken=null
// MVID: D6F2AAC2-9013-4D8E-A4D2-15511BAB107F
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMarble.dll

using buClass;
using buControls.Controls;
using buControls.DialogBox;
using buEyeBaseVer5;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buMarble.Forms;

public class F_MarbleMDIV1 : Form
{
  public Panel pnl_preview;
  public buSpin spn_toolspeed;
  public static List<string> Captions = new List<string>();
  public FormProperties PropertiesForm;
  public List<UserLoginInfo> UserList;
  public int SelectedRow;
  internal IContainer \u0001;
  public buButton btn_close;
  public buGround buGround1;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal DataGridView \u0001;
  public ImageList IC32;
  public buButton btn_remove;
  public buButton btn_add;
  public static byte f000471;
  public static List<string> Captions;
  public FormProperties PropertiesForm = new FormProperties();
  private string \u0001 = nameof (F_MarbleMDIV1);
  internal IContainer \u0001 = (IContainer) null;
  public buButton btn_close;
  public buGround buGround1;
  public ImageList IC32;
  public buButton btn_stop;
  public buButton btn_tcp;
  public buButton btn_gozero;
  public buButton btn_park;
  public buButton btn_crousecontrol;
  public buButton btn_light;
  public buButton btn_materialmeasure;
  public buButton btn_vagonpark;
  public buLabel buLabel1;
  public buButton btn_spindlewarm;
  public buButton btn_sawwarm;
  public buLabel buLabel2;
  public buButton btn_spindlepistondown;
  public buButton btn_spindlepistonup;
  public buButton btn_spindleheadpark;
  public buButton btn_sawpark;

  public void FillInfo()
  {
    this.\u0001.Rows.Clear();
    if (this.UserList == null)
      return;
    for (int index = 0; index <= this.UserList.Count - 1; ++index)
    {
      DataGridViewRowCollection rows = this.\u0001.Rows;
      string userName = this.UserList[index].UserName;
      int userId = this.UserList[index].UserID;
      int userPassword = this.UserList[index].UserPassword;
      object[] objArray = \u0005.\u0003.\u0001(this.UserList[index].UserLevel, userName, userPassword, index + 1, (F_MarbleUserList) this, userId);
      rows.Add(objArray);
      this.\u0001.Rows[this.\u0001.Rows.Count - 1].Height = 40;
    }
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control = obj0 as Control;
      if (control.Name == this.btn_add.Name)
      {
        this.\u0001.Rows.Add(\u0005.\u0003.\u0001(0, "", 0, this.\u0001.Rows.Count, (F_MarbleUserList) this, 0));
        this.\u0001.Rows[this.\u0001.Rows.Count - 1].Height = 40;
      }
      if (control.Name == this.btn_remove.Name && this.\u0001.Rows.Count > 0 & this.SelectedRow >= 0 & this.SelectedRow <= this.\u0001.Rows.Count - 1)
      {
        buDialogMessageBoxYesNo dialogMessageBoxYesNo = new buDialogMessageBoxYesNo();
        dialogMessageBoxYesNo.StartPosition = FormStartPosition.CenterScreen;
        dialogMessageBoxYesNo.Init(buLangTranslate.preDef.Delete, buLangTranslate.preSentences.DoYouWantToDelete);
        int num = (int) dialogMessageBoxYesNo.ShowDialog();
        if (dialogMessageBoxYesNo.Result != DialogResult.Yes)
          return;
        this.\u0001.Rows.RemoveAt(this.SelectedRow);
      }
      if (control.Name == this.btn_ok.Name)
      {
        ((F_MarbleUserList) this).Apply();
        this.PropertiesForm.Result = DialogResult.OK;
        if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (!(control.Name == this.btn_close.Name | control.Name == this.btn_cancel.Name))
        return;
      this.PropertiesForm.Result = DialogResult.Cancel;
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    catch (Exception ex)
    {
    }
  }

  public void spn_Leave(object sender, EventArgs e)
  {
  }

  internal void \u0001([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    this.SelectedRow = obj1.RowIndex;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.\u0001 != null ? 1 : 0)) != 0)
      this.\u0001.Dispose();
    base.Dispose(disposing);
  }

  public F_MarbleMDIV1() => \u0005.\u0003.\u0001(this);

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    this.PropertiesForm.Result = DialogResult.None;
    this.PropertiesForm.Inited = true;
    \u0005.\u0003.\u0001(this);
    this.UpdateVisuals();
  }

  public void UpdateVisuals()
  {
    string str = nameof (UpdateVisuals);
    try
    {
      if (buEyeVars.parVisual == null)
        return;
      if (!this.PropertiesForm.VisualUpdated | AppBool.VisualUpdateForce && new FileInfo(AppPath.MachineSettings + "\\ApplicationVisual.prm").Exists)
      {
        Control.ControlCollection controlCollection = (Control.ControlCollection) null;
        controlCollection = hmiUICommands.SetVisualItem(this.buGround1.Controls);
        this.PropertiesForm.VisualUpdated = true;
      }
      \u0005.\u0003.\u0001(this);
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(this.\u0001, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
    }
  }
}
