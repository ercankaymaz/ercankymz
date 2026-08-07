// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.ClassForm.F_ColorType
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Components;
using buControls.Controls;
using buCore;
using buEyeBaseVer5.Forms.Cam;
using buEyeBaseVer5.Forms.Controls;
using dummy_ptr;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.ClassForm;

public class F_ColorType : Form
{
  public buButton btn_ok;
  public buButton btn_cancel;
  internal buControlDisplaySet \u0001;
  internal buComboBox \u0001;
  internal buComboBox \u0002;
  public buSpin spn_geometryrad;
  internal buControlDisplaySet \u0002;
  public buSpin spn_headerheight;

  public F_ColorType()
  {
    ((F_CamTriMeshSettings) this).PropertiesForm = new FormProperties();
    ((F_CamTriMeshSettings) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_ControlUIDataGridView) this);
  }

  public void Init()
  {
    ((F_CamTriMeshSettings) this).PropertiesForm.Inited = false;
    if (((F_CamTriMeshSettings) this).PropertiesForm.Height > 10)
      this.Height = ((F_CamTriMeshSettings) this).PropertiesForm.Height;
    if (((F_CamTriMeshSettings) this).PropertiesForm.Width > 10)
      this.Width = ((F_CamTriMeshSettings) this).PropertiesForm.Width;
    this.TopMost = ((F_CamTriMeshSettings) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_CamTriMeshSettings) this).PropertiesForm.FormPosition;
    if (((F_CamTriMeshSettings) this).dgv_ref.Columns.Count == 0)
    {
      DataGridViewColumn dataGridViewColumn1 = new DataGridViewColumn();
      dataGridViewColumn1.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn1.Width = 35;
      dataGridViewColumn1.HeaderText = buLangTranslate.preDef.Number;
      dataGridViewColumn1.Name = "No";
      dataGridViewColumn1.ReadOnly = true;
      dataGridViewColumn1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn1.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn1.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((F_CamTriMeshSettings) this).dgv_ref.Columns.Add(dataGridViewColumn1);
      DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
      dataGridViewColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn2.Width = ((F_CamTriMeshSettings) this).dgv_ref.Width - 40;
      dataGridViewColumn2.HeaderText = buLangTranslate.preDef.Text;
      dataGridViewColumn2.Name = "Text";
      dataGridViewColumn2.ReadOnly = true;
      dataGridViewColumn2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn2.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((F_CamTriMeshSettings) this).dgv_ref.Columns.Add(dataGridViewColumn2);
      ((F_CamTriMeshSettings) this).dgv_ref.Rows.Add(\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001("DataGridView2", 1, (F_ControlUIDataGridView) this));
      ((F_CamTriMeshSettings) this).dgv_ref.Rows.Add(\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001("DataGridView2", 2, (F_ControlUIDataGridView) this));
    }
    ((F_CamTriMeshSettings) this).dgv_ref.RowHeadersVisible = false;
    ((F_CamTriMeshSettings) this).dgv_ref.AllowUserToAddRows = false;
    ((F_CamTriMeshSettings) this).dgv_ref.AllowUserToResizeColumns = false;
    ((F_CamTriMeshSettings) this).dgv_ref.ColumnHeadersVisible = true;
    ((F_CamTriMeshSettings) this).\u0002.Display.BackColor = ((F_CamTriMeshSettings) this).dgv_ref.BackgroundColor;
    ((F_CamTriMeshSettings) this).\u0002.Text = buImage.GetColorKnownName(((F_CamTriMeshSettings) this).dgv_ref.BackgroundColor);
    if (((F_CamTriMeshSettings) this).dgv_ref.BackgroundColor == Color.Black)
      ((F_CamTriMeshSettings) this).\u0002.Display.Fonts.ForeColor = Color.WhiteSmoke;
    else
      ((F_CamTriMeshSettings) this).\u0002.Display.Fonts.ForeColor = Color.Black;
    ((F_CamTriMeshSettings) this).\u0007.Display.BackColor = ((F_CamTriMeshSettings) this).dgv_ref.DefaultCellStyle.BackColor;
    ((F_CamTriMeshSettings) this).\u0007.Text = buImage.GetColorKnownName(((F_CamTriMeshSettings) this).dgv_ref.DefaultCellStyle.BackColor);
    if (((F_CamTriMeshSettings) this).dgv_ref.DefaultCellStyle.BackColor == Color.Black)
      ((F_CamTriMeshSettings) this).\u0007.Display.Fonts.ForeColor = Color.WhiteSmoke;
    else
      ((F_CamTriMeshSettings) this).\u0007.Display.Fonts.ForeColor = Color.Black;
    ((F_CamTriMeshSettings) this).\u000E.Display.BackColor = ((F_CamTriMeshSettings) this).dgv_ref.DefaultCellStyle.SelectionBackColor;
    ((F_CamTriMeshSettings) this).\u000E.Text = buImage.GetColorKnownName(((F_CamTriMeshSettings) this).dgv_ref.DefaultCellStyle.SelectionBackColor);
    if (((F_CamTriMeshSettings) this).dgv_ref.DefaultCellStyle.SelectionBackColor == Color.Black)
      ((F_CamTriMeshSettings) this).\u000E.Display.Fonts.ForeColor = Color.WhiteSmoke;
    else
      ((F_CamTriMeshSettings) this).\u000E.Display.Fonts.ForeColor = Color.Black;
    ((F_CamTriMeshSettings) this).\u0005.Display.BackColor = ((F_CamTriMeshSettings) this).dgv_ref.GridColor;
    ((F_CamTriMeshSettings) this).\u0005.Text = buImage.GetColorKnownName(((F_CamTriMeshSettings) this).dgv_ref.GridColor);
    if (((F_CamTriMeshSettings) this).dgv_ref.GridColor == Color.Black)
      ((F_CamTriMeshSettings) this).\u0005.Display.Fonts.ForeColor = Color.WhiteSmoke;
    else
      ((F_CamTriMeshSettings) this).\u0005.Display.Fonts.ForeColor = Color.Black;
    ((F_CamTriMeshSettings) this).\u0011.Display.BackColor = ((F_CamTriMeshSettings) this).dgv_ref.ColumnHeadersDefaultCellStyle.BackColor;
    ((F_CamTriMeshSettings) this).\u0011.Text = buImage.GetColorKnownName(((F_CamTriMeshSettings) this).dgv_ref.ColumnHeadersDefaultCellStyle.BackColor);
    if (((F_CamTriMeshSettings) this).dgv_ref.ColumnHeadersDefaultCellStyle.BackColor == Color.Black)
      ((F_CamTriMeshSettings) this).\u0011.Display.Fonts.ForeColor = Color.WhiteSmoke;
    else
      ((F_CamTriMeshSettings) this).\u0011.Display.Fonts.ForeColor = Color.Black;
    ((F_CamTriMeshSettings) this).btn_font.Text = $"{buLangTranslate.preDef.Cell} : {((F_CamTriMeshSettings) this).dgv_ref.DefaultCellStyle.Font.Name} - {((F_CamTriMeshSettings) this).dgv_ref.DefaultCellStyle.Font.Size.ToString()}";
    ((F_CamTriMeshSettings) this).btn_font.Display.BackColor = ((F_CamTriMeshSettings) this).dgv_ref.DefaultCellStyle.ForeColor;
    ((F_CamTriMeshSettings) this).btn_font.ButtonDownDisplay.BackColor = ((F_CamTriMeshSettings) this).dgv_ref.DefaultCellStyle.ForeColor;
    ((F_CamTriMeshSettings) this).btn_font.ButtonOverDisplay.BackColor = ((F_CamTriMeshSettings) this).dgv_ref.DefaultCellStyle.ForeColor;
    if (((F_CamTriMeshSettings) this).dgv_ref.DefaultCellStyle.ForeColor == Color.Black)
    {
      ((F_CamTriMeshSettings) this).btn_font.Display.Fonts.ForeColor = Color.WhiteSmoke;
      ((F_CamTriMeshSettings) this).btn_font.ButtonDownDisplay.Fonts.ForeColor = Color.WhiteSmoke;
      ((F_CamTriMeshSettings) this).btn_font.ButtonOverDisplay.Fonts.ForeColor = Color.WhiteSmoke;
    }
    else
    {
      ((F_CamTriMeshSettings) this).btn_font.Display.Fonts.ForeColor = Color.Black;
      ((F_CamTriMeshSettings) this).btn_font.ButtonDownDisplay.Fonts.ForeColor = Color.Black;
      ((F_CamTriMeshSettings) this).btn_font.ButtonOverDisplay.Fonts.ForeColor = Color.Black;
    }
    ((F_CamTriMeshSettings) this).\u0003.Display.BackColor = ((F_CamTriMeshSettings) this).dgv_ref.DefaultCellStyle.ForeColor;
    ((F_CamTriMeshSettings) this).\u0003.Text = buImage.GetColorKnownName(((F_CamTriMeshSettings) this).\u0003.Display.BackColor);
    if (((F_CamTriMeshSettings) this).dgv_ref.DefaultCellStyle.ForeColor == Color.Black)
      ((F_CamTriMeshSettings) this).\u0003.Display.Fonts.ForeColor = Color.WhiteSmoke;
    else
      ((F_CamTriMeshSettings) this).\u0003.Display.Fonts.ForeColor = Color.Black;
    ((F_CamTriMeshSettings) this).btn_fontheader.Text = $"{buLangTranslate.preDef.Header} : {((F_CamTriMeshSettings) this).dgv_ref.ColumnHeadersDefaultCellStyle.Font.Name} - {((F_CamTriMeshSettings) this).dgv_ref.ColumnHeadersDefaultCellStyle.Font.Size.ToString()}";
    ((F_CamTriMeshSettings) this).btn_fontheader.Display.BackColor = ((F_CamTriMeshSettings) this).dgv_ref.ColumnHeadersDefaultCellStyle.ForeColor;
    ((F_CamTriMeshSettings) this).btn_fontheader.ButtonDownDisplay.BackColor = ((F_CamTriMeshSettings) this).dgv_ref.ColumnHeadersDefaultCellStyle.ForeColor;
    ((F_CamTriMeshSettings) this).btn_fontheader.ButtonOverDisplay.BackColor = ((F_CamTriMeshSettings) this).dgv_ref.ColumnHeadersDefaultCellStyle.ForeColor;
    if (((F_CamTriMeshSettings) this).dgv_ref.ColumnHeadersDefaultCellStyle.ForeColor == Color.Black)
    {
      ((F_CamTriMeshSettings) this).btn_fontheader.Display.Fonts.ForeColor = Color.WhiteSmoke;
      ((F_CamTriMeshSettings) this).btn_fontheader.ButtonDownDisplay.Fonts.ForeColor = Color.WhiteSmoke;
      ((F_CamTriMeshSettings) this).btn_fontheader.ButtonOverDisplay.Fonts.ForeColor = Color.WhiteSmoke;
    }
    else
    {
      ((F_CamTriMeshSettings) this).btn_fontheader.Display.Fonts.ForeColor = Color.Black;
      ((F_CamTriMeshSettings) this).btn_fontheader.ButtonDownDisplay.Fonts.ForeColor = Color.Black;
      ((F_CamTriMeshSettings) this).btn_fontheader.ButtonOverDisplay.Fonts.ForeColor = Color.Black;
    }
    ((F_CamTriMeshSettings) this).\u000F.Display.BackColor = ((F_CamTriMeshSettings) this).dgv_ref.ColumnHeadersDefaultCellStyle.ForeColor;
    ((F_CamTriMeshSettings) this).\u000F.Text = buImage.GetColorKnownName(((F_CamTriMeshSettings) this).\u0003.Display.BackColor);
    if (((F_CamTriMeshSettings) this).dgv_ref.ColumnHeadersDefaultCellStyle.ForeColor == Color.Black)
      ((F_CamTriMeshSettings) this).\u000F.Display.Fonts.ForeColor = Color.WhiteSmoke;
    else
      ((F_CamTriMeshSettings) this).\u000F.Display.Fonts.ForeColor = Color.Black;
    ((F_CamTriMeshSettings) this).PropertiesForm.Result = DialogResult.None;
    ((F_CamTriMeshSettings) this).PropertiesForm.Inited = true;
    \u0007.\u0001.\u0001((F_ControlUIDataGridView) this);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_CamTriMeshSettings) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_CamTriMeshSettings) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_CamTriMeshSettings) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_CamTriMeshSettings) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
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
      if (control.Name == ((F_CamTriMeshSettings) this).btn_ok.Name)
      {
        this.Apply();
        ((F_CamTriMeshSettings) this).PropertiesForm.Result = DialogResult.OK;
        if (((F_CamTriMeshSettings) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_CamTriMeshSettings) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
          return;
        this.Visible = false;
      }
      else if (control.Name == ((F_CamTriMeshSettings) this).btn_close.Name | control.Name == ((F_CamTriMeshSettings) this).btn_cancel.Name)
      {
        ((F_CamTriMeshSettings) this).PropertiesForm.Result = DialogResult.Cancel;
        if (((F_CamTriMeshSettings) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_CamTriMeshSettings) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
          return;
        this.Visible = false;
      }
      else
      {
        if (control.Name == ((F_CamTriMeshSettings) this).btn_fontheader.Name)
        {
          FontDialog fontDialog = new FontDialog();
          fontDialog.Font = ((F_CamTriMeshSettings) this).dgv_ref.ColumnHeadersDefaultCellStyle.Font;
          int num = (int) fontDialog.ShowDialog();
          ((F_CamTriMeshSettings) this).dgv_ref.ColumnHeadersDefaultCellStyle.Font = fontDialog.Font;
          ((F_CamTriMeshSettings) this).btn_fontheader.Text = $"{buLangTranslate.preDef.Header} : {((F_CamTriMeshSettings) this).dgv_ref.ColumnHeadersDefaultCellStyle.Font.Name} - {((F_CamTriMeshSettings) this).dgv_ref.ColumnHeadersDefaultCellStyle.Font.Size.ToString()}";
          ((F_CamTriMeshSettings) this).btn_fontheader.Display.BackColor = ((F_CamTriMeshSettings) this).dgv_ref.ColumnHeadersDefaultCellStyle.ForeColor;
          ((F_CamTriMeshSettings) this).btn_fontheader.ButtonDownDisplay.BackColor = ((F_CamTriMeshSettings) this).dgv_ref.ColumnHeadersDefaultCellStyle.ForeColor;
          ((F_CamTriMeshSettings) this).btn_fontheader.ButtonOverDisplay.BackColor = ((F_CamTriMeshSettings) this).dgv_ref.ColumnHeadersDefaultCellStyle.ForeColor;
          if (((F_CamTriMeshSettings) this).dgv_ref.ColumnHeadersDefaultCellStyle.ForeColor == Color.Black)
          {
            ((F_CamTriMeshSettings) this).btn_fontheader.Display.Fonts.ForeColor = Color.WhiteSmoke;
            ((F_CamTriMeshSettings) this).btn_fontheader.ButtonDownDisplay.Fonts.ForeColor = Color.WhiteSmoke;
            ((F_CamTriMeshSettings) this).btn_fontheader.ButtonOverDisplay.Fonts.ForeColor = Color.WhiteSmoke;
          }
          else
          {
            ((F_CamTriMeshSettings) this).btn_fontheader.Display.Fonts.ForeColor = Color.Black;
            ((F_CamTriMeshSettings) this).btn_fontheader.ButtonDownDisplay.Fonts.ForeColor = Color.Black;
            ((F_CamTriMeshSettings) this).btn_fontheader.ButtonOverDisplay.Fonts.ForeColor = Color.Black;
          }
          ((F_CamTriMeshSettings) this).\u000F.Display.BackColor = ((F_CamTriMeshSettings) this).dgv_ref.ColumnHeadersDefaultCellStyle.ForeColor;
          ((F_CamTriMeshSettings) this).\u000F.Text = buImage.GetColorKnownName(((F_CamTriMeshSettings) this).\u0003.Display.BackColor);
          if (((F_CamTriMeshSettings) this).dgv_ref.ColumnHeadersDefaultCellStyle.ForeColor == Color.Black)
            ((F_CamTriMeshSettings) this).\u000F.Display.Fonts.ForeColor = Color.WhiteSmoke;
          else
            ((F_CamTriMeshSettings) this).\u000F.Display.Fonts.ForeColor = Color.Black;
        }
        if (!(control.Name == ((F_CamTriMeshSettings) this).btn_font.Name))
          return;
        FontDialog fontDialog1 = new FontDialog();
        fontDialog1.Font = ((F_CamTriMeshSettings) this).dgv_ref.DefaultCellStyle.Font;
        int num1 = (int) fontDialog1.ShowDialog();
        ((F_CamTriMeshSettings) this).dgv_ref.DefaultCellStyle.Font = fontDialog1.Font;
        ((F_CamTriMeshSettings) this).btn_font.Text = $"{buLangTranslate.preDef.Cell} : {((F_CamTriMeshSettings) this).dgv_ref.DefaultCellStyle.Font.Name} - {((F_CamTriMeshSettings) this).dgv_ref.DefaultCellStyle.Font.Size.ToString()}";
        ((F_CamTriMeshSettings) this).btn_font.Display.BackColor = ((F_CamTriMeshSettings) this).dgv_ref.DefaultCellStyle.ForeColor;
        ((F_CamTriMeshSettings) this).btn_font.ButtonDownDisplay.BackColor = ((F_CamTriMeshSettings) this).dgv_ref.DefaultCellStyle.ForeColor;
        ((F_CamTriMeshSettings) this).btn_font.ButtonOverDisplay.BackColor = ((F_CamTriMeshSettings) this).dgv_ref.DefaultCellStyle.ForeColor;
        if (((F_CamTriMeshSettings) this).dgv_ref.DefaultCellStyle.ForeColor == Color.Black)
        {
          ((F_CamTriMeshSettings) this).btn_font.Display.Fonts.ForeColor = Color.WhiteSmoke;
          ((F_CamTriMeshSettings) this).btn_font.ButtonDownDisplay.Fonts.ForeColor = Color.WhiteSmoke;
          ((F_CamTriMeshSettings) this).btn_font.ButtonOverDisplay.Fonts.ForeColor = Color.WhiteSmoke;
        }
        else
        {
          ((F_CamTriMeshSettings) this).btn_font.Display.Fonts.ForeColor = Color.Black;
          ((F_CamTriMeshSettings) this).btn_font.ButtonDownDisplay.Fonts.ForeColor = Color.Black;
          ((F_CamTriMeshSettings) this).btn_font.ButtonOverDisplay.Fonts.ForeColor = Color.Black;
        }
        ((F_CamTriMeshSettings) this).\u0003.Display.BackColor = ((F_CamTriMeshSettings) this).dgv_ref.DefaultCellStyle.ForeColor;
        ((F_CamTriMeshSettings) this).\u0003.Text = buImage.GetColorKnownName(((F_CamTriMeshSettings) this).\u0003.Display.BackColor);
        if (((F_CamTriMeshSettings) this).dgv_ref.DefaultCellStyle.ForeColor == Color.Black)
          ((F_CamTriMeshSettings) this).\u0003.Display.Fonts.ForeColor = Color.WhiteSmoke;
        else
          ((F_CamTriMeshSettings) this).\u0003.Display.Fonts.ForeColor = Color.Black;
      }
    }
    catch (Exception ex)
    {
    }
  }

  public void spn_Leave(object sender, EventArgs e)
  {
  }
}
