// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Holes.F_SlotSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.DialogBox;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Holes;

public class F_SlotSettings : Form
{
  internal TextBox \u0081;
  internal TextBox \u0082;
  internal TextBox \u0083;
  internal TextBox \u0084;
  internal TextBox \u0086;
  internal TextBox \u0087;
  internal TextBox \u0088;
  internal TextBox \u0089;
  internal TextBox \u008A;
  internal TextBox \u008B;
  internal TextBox \u008C;
  internal TextBox \u008D;
  internal TextBox \u008E;
  internal TextBox \u008F;
  internal TextBox \u0090;
  internal TextBox \u0091;
  internal TextBox \u0092;

  public void Init()
  {
    ((F_MirrorOP) this).PropertiesForm.Inited = false;
    this.LoadLanguage();
    ((F_MirrorOP) this).PropertiesForm.Result = DialogResult.None;
    this.StartPosition = ((F_MirrorOP) this).PropertiesForm.FormPosition;
    for (int index1 = 0; index1 <= ((F_MirrorOP) this).LayerOptions.Count - 1; ++index1)
    {
      for (int index2 = 0; index2 <= this.Controls.Count - 1; ++index2)
      {
        if ((this.Controls[index2].Name.IndexOf("txt_orjname") < 0 ? 0 : (this.Controls[index2].Tag != null ? 1 : 0)) != 0)
        {
          int result = -1;
          int.TryParse(this.Controls[index2].Tag.ToString(), out result);
          if (result == index1)
            this.Controls[index2].Text = ((DeleteTypeEventFormVars) ((F_MirrorOP) this).LayerOptions[index1]).LayerOriginalName;
        }
        if ((this.Controls[index2].Name.IndexOf("txt_newname") < 0 ? 0 : (this.Controls[index2].Tag != null ? 1 : 0)) != 0)
        {
          int result = -1;
          int.TryParse(this.Controls[index2].Tag.ToString(), out result);
          if (result == index1)
            this.Controls[index2].Text = ((DeleteTypeEventFormVars) ((F_MirrorOP) this).LayerOptions[index1]).LayerNewName;
        }
        if ((this.Controls[index2].Name.IndexOf("txt_extra") < 0 ? 0 : (this.Controls[index2].Tag != null ? 1 : 0)) != 0)
        {
          int result = -1;
          int.TryParse(this.Controls[index2].Tag.ToString(), out result);
          if (result == index1)
            this.Controls[index2].Text = ((DeleteTypeEventFormVars) ((F_MirrorOP) this).LayerOptions[index1]).LayerExtraName;
        }
        if ((this.Controls[index2].Name.IndexOf("lbl_Color") < 0 ? 0 : (this.Controls[index2].Tag != null ? 1 : 0)) != 0)
        {
          int result = -1;
          int.TryParse(this.Controls[index2].Tag.ToString(), out result);
          if (result == index1)
          {
            // ISSUE: reference to a compiler-generated field
            this.Controls[index2].BackColor = buVector5.\u0002.ColorList[result];
            // ISSUE: reference to a compiler-generated field
            this.Controls[index2].ForeColor = buFile5.InvertColorNoGray(buVector5.\u0002.ColorList[result]);
            // ISSUE: reference to a compiler-generated field
            this.Controls[index2].Text = buFile5.GetColorKnownName(buVector5.\u0002.ColorList[result]);
          }
        }
      }
    }
    ((F_MirrorOP) this).PropertiesForm.Inited = false;
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MirrorOP) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MirrorOP) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MirrorOP) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MirrorOP) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void LoadLanguage()
  {
    string callMethod = nameof (LoadLanguage);
    try
    {
      this.Text = $"{buLangTranslate.preDef.Layer} {buLangTranslate.preDef.Option} {buLangTranslate.preDef.List}";
      ((F_DrawingMenu) this).\u0086.Text = $"{buLangTranslate.preDef.Originale} {buLangTranslate.preDef.Layer} {buLangTranslate.preDef.Name}";
      ((F_DrawingMenu) this).\u0087.Text = $"{buLangTranslate.preDef.New} {buLangTranslate.preDef.Layer} {buLangTranslate.preDef.Name}";
      ((F_DrawingMenu) this).\u0088.Text = $"{buLangTranslate.preDef.Extra} {buLangTranslate.preDef.Layer} {buLangTranslate.preDef.Name}";
      ((F_Contour) this).btn_cancel.Text = buLangTranslate.preDef.Cancel;
      ((F_Contour) this).btn_ok.Text = buLangTranslate.preDef.Ok;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  public void Apply()
  {
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control = new Control();
    if (obj0.GetType() == typeof (Control) | obj0.GetType() == typeof (Button))
    {
      control = (Control) obj0;
      string name = control.Name;
    }
    if (control.Name == ((F_Contour) this).btn_ok.Name)
    {
      ((F_MirrorOP) this).LayerOptions.Clear();
      if (((F_DrawingMenu) this).\u0001.Text.Trim().Length > 0 & ((F_DrawingMenu) this).\u0002.Text.Trim().Length > 0)
      {
        SketchAnalyseSetData sketchAnalyseSetData = new SketchAnalyseSetData();
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerOriginalName = ((F_DrawingMenu) this).\u0001.Text;
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerNewName = ((F_DrawingMenu) this).\u0002.Text;
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerExtraName = ((F_DrawingMenu) this).\u0003.Text;
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerNewColor = ((F_Contour) this).\u0007.BackColor;
        ((F_MirrorOP) this).LayerOptions.Add((LayerOverride) sketchAnalyseSetData);
      }
      if (((F_CutMenu) this).\u0006.Text.Trim().Length > 0 & ((F_CutMenu) this).\u0005.Text.Trim().Length > 0)
      {
        SketchAnalyseSetData sketchAnalyseSetData = new SketchAnalyseSetData();
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerOriginalName = ((F_CutMenu) this).\u0006.Text;
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerNewName = ((F_CutMenu) this).\u0005.Text;
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerExtraName = ((F_DrawingMenu) this).\u0004.Text;
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerNewColor = ((F_Contour) this).\u0006.BackColor;
        ((F_MirrorOP) this).LayerOptions.Add((LayerOverride) sketchAnalyseSetData);
      }
      if (((F_CutMenu) this).\u0011.Text.Trim().Length > 0 & ((F_CutMenu) this).\u0010.Text.Trim().Length > 0)
      {
        SketchAnalyseSetData sketchAnalyseSetData = new SketchAnalyseSetData();
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerOriginalName = ((F_CutMenu) this).\u0011.Text;
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerNewName = ((F_CutMenu) this).\u0010.Text;
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerExtraName = ((F_CutMenu) this).\u000F.Text;
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerNewColor = ((F_Contour) this).\u0005.BackColor;
        ((F_MirrorOP) this).LayerOptions.Add((LayerOverride) sketchAnalyseSetData);
      }
      if (((F_CutMenu) this).\u000E.Text.Trim().Length > 0 & ((F_CutMenu) this).\u0008.Text.Trim().Length > 0)
      {
        SketchAnalyseSetData sketchAnalyseSetData = new SketchAnalyseSetData();
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerOriginalName = ((F_CutMenu) this).\u000E.Text;
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerNewName = ((F_CutMenu) this).\u0008.Text;
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerExtraName = ((F_CutMenu) this).\u0007.Text;
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerNewColor = ((F_Contour) this).\u0004.BackColor;
        ((F_MirrorOP) this).LayerOptions.Add((LayerOverride) sketchAnalyseSetData);
      }
      if (((F_CutMenu) this).\u000E.Text.Trim().Length > 0 & ((F_HoleMenu) this).\u001C.Text.Trim().Length > 0)
      {
        SketchAnalyseSetData sketchAnalyseSetData = new SketchAnalyseSetData();
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerOriginalName = ((F_HoleMenu) this).\u001D.Text;
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerNewName = ((F_HoleMenu) this).\u001C.Text;
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerExtraName = ((F_HoleMenu) this).\u001B.Text;
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerNewColor = ((F_Contour) this).\u0003.BackColor;
        ((F_MirrorOP) this).LayerOptions.Add((LayerOverride) sketchAnalyseSetData);
      }
      if (((F_HoleMenu) this).\u001A.Text.Trim().Length > 0 & ((F_HoleMenu) this).\u0019.Text.Trim().Length > 0)
      {
        SketchAnalyseSetData sketchAnalyseSetData = new SketchAnalyseSetData();
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerOriginalName = ((F_HoleMenu) this).\u001A.Text;
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerNewName = ((F_HoleMenu) this).\u0019.Text;
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerExtraName = ((F_HoleMenu) this).\u0018.Text;
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerNewColor = ((F_Contour) this).\u0002.BackColor;
        ((F_MirrorOP) this).LayerOptions.Add((LayerOverride) sketchAnalyseSetData);
      }
      if (((F_HoleMenu) this).\u0017.Text.Trim().Length > 0 & ((F_HoleMenu) this).\u0016.Text.Trim().Length > 0)
      {
        SketchAnalyseSetData sketchAnalyseSetData = new SketchAnalyseSetData();
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerOriginalName = ((F_HoleMenu) this).\u0017.Text;
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerNewName = ((F_HoleMenu) this).\u0016.Text;
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerExtraName = ((F_HoleMenu) this).\u0015.Text;
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerNewColor = ((F_MirrorOP) this).\u0001.BackColor;
        ((F_MirrorOP) this).LayerOptions.Add((LayerOverride) sketchAnalyseSetData);
      }
      if (((F_CutMenu) this).\u0014.Text.Trim().Length > 0 & ((F_CutMenu) this).\u0013.Text.Trim().Length > 0)
      {
        SketchAnalyseSetData sketchAnalyseSetData = new SketchAnalyseSetData();
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerOriginalName = ((F_CutMenu) this).\u0014.Text;
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerNewName = ((F_CutMenu) this).\u0013.Text;
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerExtraName = ((F_CutMenu) this).\u0012.Text;
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerNewColor = ((F_Contour) this).\u0008.BackColor;
        ((F_MirrorOP) this).LayerOptions.Add((LayerOverride) sketchAnalyseSetData);
      }
      if (this.\u0089.Text.Trim().Length > 0 & this.\u0088.Text.Trim().Length > 0)
      {
        SketchAnalyseSetData sketchAnalyseSetData = new SketchAnalyseSetData();
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerOriginalName = this.\u0089.Text;
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerNewName = this.\u0088.Text;
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerExtraName = this.\u0087.Text;
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerNewColor = ((F_Contour) this).\u0015.BackColor;
        ((F_MirrorOP) this).LayerOptions.Add((LayerOverride) sketchAnalyseSetData);
      }
      if (this.\u0086.Text.Trim().Length > 0 & this.\u0084.Text.Trim().Length > 0)
      {
        SketchAnalyseSetData sketchAnalyseSetData = new SketchAnalyseSetData();
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerOriginalName = this.\u0086.Text;
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerNewName = this.\u0084.Text;
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerExtraName = this.\u0083.Text;
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerNewColor = ((F_Contour) this).\u0014.BackColor;
        ((F_MirrorOP) this).LayerOptions.Add((LayerOverride) sketchAnalyseSetData);
      }
      if (this.\u0082.Text.Trim().Length > 0 & this.\u0081.Text.Trim().Length > 0)
      {
        SketchAnalyseSetData sketchAnalyseSetData = new SketchAnalyseSetData();
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerOriginalName = this.\u0082.Text;
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerNewName = this.\u0081.Text;
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerExtraName = ((F_HoleMenu) this).\u0080.Text;
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerNewColor = ((F_Contour) this).\u0013.BackColor;
        ((F_MirrorOP) this).LayerOptions.Add((LayerOverride) sketchAnalyseSetData);
      }
      if (((F_HoleMenu) this).\u007F.Text.Trim().Length > 0 & ((F_HoleMenu) this).\u001F.Text.Trim().Length > 0)
      {
        SketchAnalyseSetData sketchAnalyseSetData = new SketchAnalyseSetData();
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerOriginalName = ((F_HoleMenu) this).\u007F.Text;
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerNewName = ((F_HoleMenu) this).\u001F.Text;
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerExtraName = ((F_HoleMenu) this).\u001E.Text;
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerNewColor = ((F_Contour) this).\u0012.BackColor;
        ((F_MirrorOP) this).LayerOptions.Add((LayerOverride) sketchAnalyseSetData);
      }
      if (((F_HolesTemp) this).\u0095.Text.Trim().Length > 0 & ((F_HolesTemp) this).\u0094.Text.Trim().Length > 0)
      {
        SketchAnalyseSetData sketchAnalyseSetData = new SketchAnalyseSetData();
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerOriginalName = ((F_HolesTemp) this).\u0095.Text;
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerNewName = ((F_HolesTemp) this).\u0094.Text;
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerExtraName = ((F_HolesTemp) this).\u0093.Text;
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerNewColor = ((F_Contour) this).\u0011.BackColor;
        ((F_MirrorOP) this).LayerOptions.Add((LayerOverride) sketchAnalyseSetData);
      }
      if (this.\u0092.Text.Trim().Length > 0 & this.\u0091.Text.Trim().Length > 0)
      {
        SketchAnalyseSetData sketchAnalyseSetData = new SketchAnalyseSetData();
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerOriginalName = this.\u0092.Text;
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerNewName = this.\u0091.Text;
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerExtraName = this.\u0090.Text;
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerNewColor = ((F_Contour) this).\u0010.BackColor;
        ((F_MirrorOP) this).LayerOptions.Add((LayerOverride) sketchAnalyseSetData);
      }
      if (this.\u008F.Text.Trim().Length > 0 & this.\u008E.Text.Trim().Length > 0)
      {
        SketchAnalyseSetData sketchAnalyseSetData = new SketchAnalyseSetData();
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerOriginalName = this.\u008F.Text;
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerNewName = this.\u008E.Text;
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerExtraName = this.\u008D.Text;
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerNewColor = ((F_Contour) this).\u000F.BackColor;
        ((F_MirrorOP) this).LayerOptions.Add((LayerOverride) sketchAnalyseSetData);
      }
      if (this.\u008C.Text.Trim().Length > 0 & this.\u008B.Text.Trim().Length > 0)
      {
        SketchAnalyseSetData sketchAnalyseSetData = new SketchAnalyseSetData();
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerOriginalName = this.\u008C.Text;
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerNewName = this.\u008B.Text;
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerExtraName = this.\u008A.Text;
        ((DeleteTypeEventFormVars) sketchAnalyseSetData).LayerNewColor = ((F_Contour) this).\u000E.BackColor;
        ((F_MirrorOP) this).LayerOptions.Add((LayerOverride) sketchAnalyseSetData);
      }
      ((F_MirrorOP) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_MirrorOP) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_MirrorOP) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control.Name == ((F_Contour) this).btn_cancel.Name))
      return;
    ((F_MirrorOP) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MirrorOP) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MirrorOP) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if ((control2.Tag == null ? 0 : (buFile5.IsNumeric(control2.Tag.ToString()) ? 1 : 0)) == 0)
      return;
    int index = int.Parse(control2.Tag.ToString());
    // ISSUE: reference to a compiler-generated field
    ColorDialogBox.ShowDialog(buVector5.\u0002.ColorList[index]);
    if (ColorDialogBox.Result != DialogResult.OK)
      return;
    if (index >= 0 & index <= ((F_MirrorOP) this).LayerOptions.Count - 1)
      ((DeleteTypeEventFormVars) ((F_MirrorOP) this).LayerOptions[index]).LayerNewColor = ColorDialogBox.Color;
    control2.BackColor = ColorDialogBox.Color;
    control2.ForeColor = buFile5.InvertColorNoGray(control2.BackColor);
    control2.Text = buFile5.GetColorKnownName(control2.BackColor);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MirrorOP) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MirrorOP) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_SlotSettings() => F_MirrorOP.Captions = new List<string>();
}
