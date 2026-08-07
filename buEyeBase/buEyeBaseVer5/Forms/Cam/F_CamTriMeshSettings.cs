// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Cam.F_CamTriMeshSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Components;
using buControls.Controls;
using buControls.DialogBox;
using buCore;
using buEyeBaseVer5.Forms.Controls;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Cam;

public class F_CamTriMeshSettings : Form
{
  public buSpin spn_geometryrad;
  internal buLabel \u0001;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public hmiUISettings Settings;
  internal IContainer \u0001;
  public buButton btn_close;
  public buGround buGround1;
  public ImageList IC32;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal buComboBox \u0001;
  internal buComboBox \u0002;
  public buSpin spn_geometryrad;
  internal buControlDisplaySet \u0001;
  public buPanel pnl_ref;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public buListBox refList;
  internal IContainer \u0001;
  public buButton btn_close;
  public buGround buGround1;
  public ImageList IC32;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal buControlDisplaySet \u0001;
  internal buComboBox \u0001;
  public buSpin spn_geometryrad;
  internal buListBox \u0001;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  internal IContainer \u0001;
  public buButton btn_close;
  public buGround buGround1;
  public ImageList IC32;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal buLabel \u0001;
  internal buLabel \u0002;
  internal buLabel \u0003;
  public buButton btn_font;
  internal buLabel \u0004;
  internal buLabel \u0005;
  internal buLabel \u0006;
  internal buLabel \u0007;
  public DataGridView dgv_ref;
  internal buLabel \u0008;
  internal buLabel \u000E;
  internal buLabel \u000F;
  public buButton btn_fontheader;
  internal buLabel \u0010;
  internal buLabel \u0011;
  public static byte f003448;
  public static List<string> Captions = new List<string>();
  public FormProperties PropertiesForm;
  public hmiUISettings Settings;
  internal IContainer \u0001;
  public buButton btn_close;
  public buGround buGround1;
  public ImageList IC32;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal buControlDisplaySet \u0001;
  internal buComboBox \u0001;
  internal buComboBox \u0002;
  public buSpin spn_geometryrad;
  internal buControlDisplaySet \u0002;
  public buSpin spn_headerheight;
  public buGroup grp_ref;
  public static List<string> Captions = new List<string>();
  public FormProperties PropertiesForm = new FormProperties();
  public RadioButton refRadio = (RadioButton) null;
  internal IContainer \u0001 = (IContainer) null;
  public buButton btn_close;
  public buGround buGround1;
  public ImageList IC32;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal RadioButton \u0001;
  internal buLabel \u0001;
  internal buLabel \u0002;
  internal buLabel \u0003;
  public buButton btn_font;
  internal buComboBox \u0001;
  public static byte f003468;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public hmiUISettings Settings;
  internal IContainer \u0001;
  public buButton btn_close;
  public buGround buGround1;
  public ImageList IC32;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal buControlDisplaySet \u0001;
  internal buComboBox \u0001;
  internal buComboBox \u0002;
  public buSpin spn_geometryrad;
  internal buControlDisplaySet \u0002;
  internal buCheckBox \u0001;
  public buProgressBar Progress_Ref;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public hmiUISettings Settings;
  internal IContainer \u0001;
  public buButton btn_close;
  public buGround buGround1;
  public ImageList IC32;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal buControlDisplaySet \u0001;
  internal buComboBox \u0001;
  internal buComboBox \u0002;
  public buSpin spn_geometryrad;
  internal buControlDisplaySet \u0002;
  public buSpin spn_arrowwidth;
  internal buLabel \u0001;
  internal buLabel \u0002;
  internal buLabel \u0003;
  internal buLabel \u0004;
  internal buLabel \u0005;
  internal buLabel \u0006;
  public buComboBox Cmb_Ref;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public hmiUISettings Settings;
  internal IContainer \u0001;
  public buButton btn_close;
  public buGround buGround1;
  public ImageList IC32;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal buControlDisplaySet \u0001;
  internal buControlDisplaySet \u0002;
  internal buComboBox \u0001;
  internal buComboBox \u0002;
  public buSpin spn_geometryrad;
  internal buControlDisplaySet \u0003;
  internal buControlDisplaySet \u0004;
  public buSpin spn_drawerwidth;
  public buTrack track_ref;
  internal buCheckBox \u0001;
  internal buCheckBox \u0002;
  internal buLabel \u0001;
  internal buLabel \u0002;
  internal buControlDisplaySet \u0005;
  internal buControlDisplaySet \u0006;
  public buButton btn_minus;
  public buButton btn_plus;
  public buSpin spn_speed;
  public buLabel lbl_speed;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public hmiUISettings Settings;
  internal IContainer \u0001;
  public buButton btn_close;
  public buGround buGround1;
  public ImageList IC32;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal buControlDisplaySet \u0001;
  internal buControlDisplaySet \u0002;
  internal buComboBox \u0001;
  internal buComboBox \u0002;
  public buSpin spn_geometryrad;
  internal buControlDisplaySet \u0003;
  internal buControlDisplaySet \u0004;
  public buSpin spn_drawerwidth;
  public buTrack track_ref;
  internal buCheckBox \u0001;
  internal buCheckBox \u0002;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public buTextBox refText;
  internal IContainer \u0001;
  public buButton btn_close;
  public buGround buGround1;
  public ImageList IC32;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal buControlDisplaySet \u0001;
  internal buComboBox \u0001;
  internal buComboBox \u0002;
  public buSpin spn_geometryrad;
  internal buControlDisplaySet \u0002;
  internal buTextBox \u0001;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public buSpin refSpin;
  internal IContainer \u0001;
  public buButton btn_close;
  public buGround buGround1;
  public ImageList IC32;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal buControlDisplaySet \u0001;
  internal buControlDisplaySet \u0002;
  internal buComboBox \u0001;
  internal buComboBox \u0002;
  public buSpin spn_geometryrad;
  public buSpin spn_ref;
  internal buControlDisplaySet \u0003;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public buLabel refLabel;
  internal IContainer \u0001;
  public buButton btn_close;
  public buGround buGround1;
  public ImageList IC32;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal buControlDisplaySet \u0001;
  internal buComboBox \u0001;
  internal buComboBox \u0002;
  public buSpin spn_geometryrad;
  internal buLabel \u0001;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public buButton refButton;
  internal IContainer \u0001;
  public buButton btn_close;
  public buGround buGround1;
  public ImageList IC32;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal buControlDisplaySet \u0001;
  public buButton btn_ref;
  internal buControlDisplaySet \u0002;
  internal buControlDisplaySet \u0003;
  internal buComboBox \u0001;
  internal buComboBox \u0002;
  public buSpin spn_geometryrad;
  public buSpin spn_displaytoovertone;
  public buButton btn_displaytoover;
  public buSpin spn_displaytodowntone;
  public buButton btn_displaytodown;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  private Timer \u0001;
  internal IContainer \u0001;
  public buButton btn_close;
  public buGround buGround1;
  public buButton btn_menubutton1;
  public ImageList IC32;
  public buButton btn_menubutton4;
  public buButton btn_menubutton3;
  public buButton btn_menubutton2;
  public buButton btn_ok;
  public buButton btn_cancel;
  public buButton btn_systembutton4;
  public buButton btn_systembutton3;
  public buButton btn_systembutton2;
  public buButton btn_systembutton1;
  public buButton btn_commandbutton4;
  public buButton btn_commandbutton3;
  public buButton btn_commandbutton2;
  public buButton btn_commandbutton1;
  internal buLabel \u0001;
  internal buLabel \u0002;
  internal buLabel \u0003;
  internal buLabel \u0004;
  internal RadioButton \u0001;
  internal RadioButton \u0002;

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.\u0001 != null ? 1 : 0)) != 0)
      this.\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_CamTriMeshSettings()
  {
  }

  public F_CamTriMeshSettings()
  {
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_ControlUIRadio) this);
  }

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    if (this.refRadio != null)
    {
      this.\u0001.ForeColor = this.refRadio.ForeColor;
      this.\u0001.BackColor = this.refRadio.BackColor;
      this.\u0001.TextAlign = this.refRadio.TextAlign;
      this.\u0002.Display.BackColor = this.refRadio.BackColor;
      this.\u0002.Text = buImage.GetColorKnownName(this.refRadio.BackColor);
      if (this.refRadio.BackColor == Color.Black)
        this.\u0002.Display.Fonts.ForeColor = Color.WhiteSmoke;
      else
        this.\u0002.Display.Fonts.ForeColor = Color.Black;
      this.\u0003.Display.BackColor = this.refRadio.ForeColor;
      this.\u0003.Text = buImage.GetColorKnownName(this.refRadio.ForeColor);
      if (this.refRadio.BackColor == Color.Black)
        this.\u0003.Display.Fonts.ForeColor = Color.WhiteSmoke;
      else
        this.\u0003.Display.Fonts.ForeColor = Color.Black;
      this.btn_font.Text = $"{this.\u0001.Font.Name} - {this.\u0001.Font.Size.ToString()}";
      this.btn_font.Display.BackColor = this.\u0001.ForeColor;
      this.btn_font.ButtonDownDisplay.BackColor = this.\u0001.ForeColor;
      this.btn_font.ButtonOverDisplay.BackColor = this.\u0001.ForeColor;
      if (this.\u0001.ForeColor == Color.Black)
      {
        this.btn_font.Display.Fonts.ForeColor = Color.WhiteSmoke;
        this.btn_font.ButtonDownDisplay.Fonts.ForeColor = Color.WhiteSmoke;
        this.btn_font.ButtonOverDisplay.Fonts.ForeColor = Color.WhiteSmoke;
      }
      else
      {
        this.btn_font.Display.Fonts.ForeColor = Color.Black;
        this.btn_font.ButtonDownDisplay.Fonts.ForeColor = Color.Black;
        this.btn_font.ButtonOverDisplay.Fonts.ForeColor = Color.Black;
      }
      this.\u0003.Display.BackColor = this.\u0001.ForeColor;
      this.\u0003.Text = buImage.GetColorKnownName(this.\u0003.Display.BackColor);
      if (this.\u0001.ForeColor == Color.Black)
        this.\u0003.Display.Fonts.ForeColor = Color.WhiteSmoke;
      else
        this.\u0003.Display.Fonts.ForeColor = Color.Black;
      this.\u0001.Items.Clear();
      this.\u0001.Items.AddRange(Enum.GetValues(typeof (ContentAlignment)).Cast<object>().ToArray<object>());
      this.\u0001.SelectedItem = (object) this.\u0001.TextAlign;
    }
    this.PropertiesForm.Result = DialogResult.None;
    this.PropertiesForm.Inited = true;
    \u0007.\u0001.\u0001((F_ControlUIRadio) this);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (this.PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    this.PropertiesForm.Result = DialogResult.Cancel;
    if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control = obj0 as Control;
      if (control.Name == this.btn_ok.Name)
      {
        this.Apply();
        this.PropertiesForm.Result = DialogResult.OK;
        if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
          return;
        this.Visible = false;
      }
      else if (control.Name == this.btn_close.Name | control.Name == this.btn_cancel.Name)
      {
        this.PropertiesForm.Result = DialogResult.Cancel;
        if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
          return;
        this.Visible = false;
      }
      else
      {
        if (!(control.Name == this.btn_font.Name))
          return;
        FontDialog fontDialog = new FontDialog();
        fontDialog.Font = this.\u0001.Font;
        int num = (int) fontDialog.ShowDialog();
        this.\u0001.Font = fontDialog.Font;
        this.refRadio.Font = new Font(fontDialog.Font.Name, fontDialog.Font.Size, fontDialog.Font.Style);
        this.btn_font.Text = $"{this.\u0001.Font.Name} - {this.\u0001.Font.Size.ToString()}";
        this.btn_font.Display.BackColor = this.\u0001.ForeColor;
        this.btn_font.ButtonDownDisplay.BackColor = this.\u0001.ForeColor;
        this.btn_font.ButtonOverDisplay.BackColor = this.\u0001.ForeColor;
        if (this.\u0001.ForeColor == Color.Black)
        {
          this.btn_font.Display.Fonts.ForeColor = Color.WhiteSmoke;
          this.btn_font.ButtonDownDisplay.Fonts.ForeColor = Color.WhiteSmoke;
          this.btn_font.ButtonOverDisplay.Fonts.ForeColor = Color.WhiteSmoke;
        }
        else
        {
          this.btn_font.Display.Fonts.ForeColor = Color.Black;
          this.btn_font.ButtonDownDisplay.Fonts.ForeColor = Color.Black;
          this.btn_font.ButtonOverDisplay.Fonts.ForeColor = Color.Black;
        }
        this.\u0003.Display.BackColor = this.\u0001.ForeColor;
        this.\u0003.Text = buImage.GetColorKnownName(this.\u0003.Display.BackColor);
        if (this.\u0001.ForeColor == Color.Black)
          this.\u0003.Display.Fonts.ForeColor = Color.WhiteSmoke;
        else
          this.\u0003.Display.Fonts.ForeColor = Color.Black;
      }
    }
    catch (Exception ex)
    {
    }
  }

  public void spn_Leave(object sender, EventArgs e)
  {
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    buLabel buLabel = obj0 as buLabel;
    if (buLabel.Name == this.\u0002.Name)
    {
      Color backColor = buLabel.Display.BackColor;
      if (ColorDialogBox.ShowDialog(ref backColor) == DialogResult.OK)
      {
        buLabel.Display.BackColor = backColor;
        buLabel.Text = buImage.GetColorKnownName(backColor);
        this.refRadio.BackColor = backColor;
        this.\u0001.BackColor = backColor;
      }
    }
    if (!(buLabel.Name == this.\u0003.Name))
      return;
    Color backColor1 = buLabel.Display.BackColor;
    if (ColorDialogBox.ShowDialog(ref backColor1) != DialogResult.OK)
      return;
    buLabel.Display.BackColor = backColor1;
    buLabel.Text = buImage.GetColorKnownName(backColor1);
    this.refRadio.ForeColor = backColor1;
    this.\u0001.ForeColor = backColor1;
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    if (!((obj0 as Control).Name == this.\u0001.Name))
      return;
    ContentAlignment result;
    Enum.TryParse<ContentAlignment>(this.\u0001.SelectedItem.ToString(), out result);
    this.refRadio.TextAlign = result;
    this.\u0001.TextAlign = result;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.\u0001 != null ? 1 : 0)) != 0)
      this.\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_CamTriMeshSettings()
  {
  }
}
