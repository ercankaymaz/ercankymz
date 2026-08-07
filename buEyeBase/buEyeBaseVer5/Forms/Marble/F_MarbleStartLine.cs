// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleStartLine
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buClass.Apps;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.Forms.MortiseTenon;
using buEyeBaseVer5.Forms.PanelCut;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleStartLine : Form
{
  internal Label \u0005;
  internal NumericUpDown \u0004;
  internal Label \u0006;
  internal NumericUpDown \u0005;
  public Panel pnl_model;
  public static byte f0019F4;
  public Color SpinBaseColor;
  public Color SpinFocusColor;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public MarbleCamType CommandType;

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleBottomPanelV1) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleBottomPanelV1) this).PropertiesForm.Result = DialogResult.Cancel;
    this.Visible = false;
  }

  public void LoadLanguage()
  {
    string callMethod = "NestSheetPart LoadLanguage";
    try
    {
      if (F_MarbleBottomPanelV1.Captions.Count < 33)
        return;
      this.Text = F_MarbleBottomPanelV1.Captions[0];
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control = new Control();
    string str = "";
    if (obj0.GetType() == typeof (Control) | obj0.GetType() == typeof (Button))
      str = ((Control) obj0).Name;
    if (obj0.GetType() == typeof (ToolStripMenuItem))
      str = ((ToolStripItem) obj0).Name;
    if (str == ((F_MarbleBottomPanelV1) this).\u0002.Name)
    {
      buNestingMaterials nestingMaterials = (buNestingMaterials) new ProfileOperationNotchOld();
      ((ProfileOperationPolygon) nestingMaterials).Cost = (double) ((F_MarbleBottomPanelV1) this).\u0002.Value;
      ((ProfileOperationPolygon) nestingMaterials).Thickness = (double) ((F_MarbleBottomPanelV1) this).\u0001.Value;
      ((buEyeBaseVer5.Apps.ProfileOperationData) nestingMaterials).Material = ((F_MarbleBottomPanelV1) this).\u0001.Text;
      ((buEyeBaseVer5.Apps.ProfileOperationData) nestingMaterials).Explanation = ((F_MarbleBottomPanelV1) this).\u0002.Text;
      ((buEyeBaseVer5.Apps.ProfileOperationData) nestingMaterials).Enable = true;
      ((F_MarbleBottomPanelV1) this).Materails.Add(nestingMaterials);
      DataGridViewRowCollection rows = ((F_MarbleBottomPanelV1) this).\u0001.Rows;
      int count = ((F_MarbleBottomPanelV1) this).Materails.Count;
      bool enable = ((buEyeBaseVer5.Apps.ProfileOperationData) nestingMaterials).Enable;
      string material = ((buEyeBaseVer5.Apps.ProfileOperationData) nestingMaterials).Material;
      double thickness = ((ProfileOperationPolygon) nestingMaterials).Thickness;
      string explanation = ((buEyeBaseVer5.Apps.ProfileOperationData) nestingMaterials).Explanation;
      double cost = ((ProfileOperationPolygon) nestingMaterials).Cost;
      object[] objArray = \u0007.\u0001.\u0001(thickness, enable, explanation, cost, count, material, (F_PanelCutMaterials) this);
      rows.Add(objArray);
    }
    if (str == ((F_MarbleBottomPanelV1) this).\u0001.Name)
    {
      if (buNumeric5.MessageBoxQuestion(buNesting.LangNestingMessage[7] + AppLanguage.CadCamDynamic[33]) != DialogResult.Yes)
        return;
      ((F_MarbleBottomPanelV1) this).\u0001.Rows.RemoveAt(((F_MarbleBottomPanelV1) this).\u0001);
      ((F_MarbleBottomPanelV1) this).Materails.RemoveAt(((F_MarbleBottomPanelV1) this).\u0001);
    }
    else
    {
      if (str == ((F_MarbleBottomPanelV1) this).\u0001.Name)
      {
        for (int index = ((F_MarbleBottomPanelV1) this).\u0001.Rows.Count - 1; index >= 0; --index)
        {
          ((F_MarbleBottomPanelV1) this).\u0001.Rows[index].Cells[1].Value = (object) true;
          ((buEyeBaseVer5.Apps.ProfileOperationData) ((F_MarbleBottomPanelV1) this).Materails[index]).Enable = true;
        }
      }
      if (str == ((F_MarbleBottomPanelV1) this).\u0002.Name)
      {
        for (int index = ((F_MarbleBottomPanelV1) this).\u0001.Rows.Count - 1; index >= 0; --index)
        {
          ((F_MarbleBottomPanelV1) this).\u0001.Rows[index].Cells[1].Value = (object) false;
          ((buEyeBaseVer5.Apps.ProfileOperationData) ((F_MarbleBottomPanelV1) this).Materails[index]).Enable = false;
        }
      }
      if (str == ((F_MarbleBottomPanelV1) this).\u0004.Name && buNumeric5.MessageBoxQuestion(buNesting.LangNestingMessage[7] + AppLanguage.CadCamDynamic[33]) == DialogResult.Yes)
      {
        ((F_MarbleBottomPanelV1) this).Materails.Clear();
        ((F_MarbleBottomPanelV1) this).\u0001.Rows.Clear();
      }
      if (str == ((F_MarbleBottomPanelV1) this).\u0005.Name && buNumeric5.MessageBoxQuestion(buNesting.LangNestingMessage[7] + AppLanguage.CadCamDynamic[33]) == DialogResult.Yes)
      {
        for (int index = ((F_MarbleBottomPanelV1) this).\u0001.Rows.Count - 1; index >= 0; --index)
        {
          if (Convert.ToBoolean(((F_MarbleBottomPanelV1) this).\u0001.Rows[index].Cells[1].Value))
          {
            ((F_MarbleBottomPanelV1) this).\u0001.Rows.RemoveAt(index);
            ((F_MarbleBottomPanelV1) this).Materails.RemoveAt(index);
          }
        }
      }
      if (str == ((F_MarbleBottomPanelV1) this).\u0003.Name)
      {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.InitialDirectory = ((F_MarbleBottomPanelV1) this).SaveFileFolder;
        saveFileDialog.Filter = "Nesting Material Files (*.bunestmat)|*.bunestmat";
        saveFileDialog.FilterIndex = 1;
        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
          ((F_MarbleBottomPanelV1) this).SaveFileFolder = buFile5.bunesting.GetPath(saveFileDialog.FileName);
          new buVector5().SaveNestingMaterials(saveFileDialog.FileName, ((F_MarbleBottomPanelV1) this).Materails);
        }
      }
      if (str == ((F_MarbleBottomPanelV1) this).\u0006.Name)
      {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.InitialDirectory = ((F_MarbleBottomPanelV1) this).SaveFileFolder;
        openFileDialog.Filter = "Nesting Material Files (*.bunestmat)|*.bunestmat";
        openFileDialog.FilterIndex = 1;
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
          ((F_MarbleBottomPanelV1) this).SaveFileFolder = buFile5.bunesting.GetPath(openFileDialog.FileName);
          new buVector5().OpenNestingMaterials(openFileDialog.FileName, ref ((F_MarbleBottomPanelV1) this).Materails);
          ((F_MarbleJobOPListV2) this).Init();
        }
      }
      if (str == ((F_MarbleBottomPanelV1) this).\u0004.Name)
      {
        this.Visible = false;
        ((F_MarbleBottomPanelV1) this).PropertiesForm.Result = DialogResult.Cancel;
      }
      if (!(str == ((F_MarbleBottomPanelV1) this).\u0003.Name))
        return;
      this.Visible = false;
      ((F_MarbleBottomPanelV1) this).PropertiesForm.Result = DialogResult.OK;
    }
  }

  internal void \u0001([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    if (!(obj1.RowIndex >= 0 & obj1.RowIndex <= ((F_MarbleBottomPanelV1) this).Materails.Count - 1))
      return;
    ((F_MarbleBottomPanelV1) this).\u0001.Text = ((F_MarbleBottomPanelV1) this).\u0001.Rows[obj1.RowIndex].Cells[2].Value.ToString();
    ((F_MarbleBottomPanelV1) this).\u0001.Value = (Decimal) Convert.ToDouble(((F_MarbleBottomPanelV1) this).\u0001.Rows[obj1.RowIndex].Cells[3].Value.ToString());
    ((F_MarbleBottomPanelV1) this).\u0002.Text = ((F_MarbleBottomPanelV1) this).\u0001.Rows[obj1.RowIndex].Cells[4].Value.ToString();
    ((F_MarbleBottomPanelV1) this).\u0002.Value = (Decimal) Convert.ToDouble(((F_MarbleBottomPanelV1) this).\u0001.Rows[obj1.RowIndex].Cells[5].Value.ToString());
  }

  internal void \u0002([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    if (!(obj1.ColumnIndex >= 0 & obj1.RowIndex >= 0))
      return;
    if (obj1.ColumnIndex == 1 & obj1.RowIndex <= ((F_MarbleBottomPanelV1) this).Materails.Count - 1)
      ((buEyeBaseVer5.Apps.ProfileOperationData) ((F_MarbleBottomPanelV1) this).Materails[obj1.RowIndex]).Enable = Convert.ToBoolean(((F_MarbleBottomPanelV1) this).\u0001.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value);
    if (obj1.ColumnIndex == 2 & obj1.RowIndex <= ((F_MarbleBottomPanelV1) this).Materails.Count - 1)
      ((buEyeBaseVer5.Apps.ProfileOperationData) ((F_MarbleBottomPanelV1) this).Materails[obj1.RowIndex]).Material = Convert.ToString(((F_MarbleBottomPanelV1) this).\u0001.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value);
    if (obj1.ColumnIndex == 3 & obj1.RowIndex <= ((F_MarbleBottomPanelV1) this).Materails.Count - 1)
      ((ProfileOperationPolygon) ((F_MarbleBottomPanelV1) this).Materails[obj1.RowIndex]).Thickness = Convert.ToDouble(((F_MarbleBottomPanelV1) this).\u0001.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value);
    if (obj1.ColumnIndex == 4 & obj1.RowIndex <= ((F_MarbleBottomPanelV1) this).Materails.Count - 1)
      ((buEyeBaseVer5.Apps.ProfileOperationData) ((F_MarbleBottomPanelV1) this).Materails[obj1.RowIndex]).Explanation = Convert.ToString(((F_MarbleBottomPanelV1) this).\u0001.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value);
    if (!(obj1.ColumnIndex == 5 & obj1.RowIndex <= ((F_MarbleBottomPanelV1) this).Materails.Count - 1))
      return;
    ((ProfileOperationPolygon) ((F_MarbleBottomPanelV1) this).Materails[obj1.RowIndex]).Cost = Convert.ToDouble(((F_MarbleBottomPanelV1) this).\u0001.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleBottomPanelV1) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleBottomPanelV1) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleStartLine()
  {
    F_MarbleBottomPanelV1.Captions = new List<string>();
    F_MarbleBottomPanelV1.CaptionGrid = new List<string>();
  }

  public F_MarbleStartLine()
  {
    ((F_MarbleBottomPanelV1) this).Properties = new FormProperties();
    ((F_MarbleBottomPanelV1) this).Width = 0.0;
    ((F_MarbleBottomPanelV1) this).Diameter = 0.0;
    ((F_MarbleBottomPanelV1) this).XPos = 0.0;
    ((F_MarbleBottomPanelV1) this).YPos = 0.0;
    ((F_MarbleBottomPanelV1) this).SafeDis = 0.0;
    ((F_MarbleBottomPanelV1) this).RapidDis = 0.0;
    ((F_MarbleCoordinatesV2) this).PlungeFeed = 0.0;
    ((F_MarbleCoordinatesV2) this).CuttingFeed = 0.0;
    ((F_MarbleCoordinatesV2) this).CamType = CamClosedContourType.Outter;
    ((F_MarbleCoordinatesV2) this).ToolNo = 1;
    ((F_MarbleCoordinatesV2) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_SlotNoDepth) this);
  }

  public void Init()
  {
    ((F_MarbleBottomPanelV1) this).Properties.Inited = false;
    if (((F_MarbleBottomPanelV1) this).Properties.Height > 10)
      this.Height = ((F_MarbleBottomPanelV1) this).Properties.Height;
    if (((F_MarbleBottomPanelV1) this).Properties.Width > 10)
      ((F_MarbleBottomPanelV1) this).Width = (double) ((F_MarbleBottomPanelV1) this).Properties.Width;
    this.TopMost = ((F_MarbleBottomPanelV1) this).Properties.TopMost;
    this.StartPosition = ((F_MarbleBottomPanelV1) this).Properties.FormPosition;
    ((F_MarbleBottomPanelV1) this).Properties.Result = DialogResult.None;
    ((F_MarbleBottomPanelV1) this).Properties.Inited = true;
    ((F_MarbleCoordinatesV2) this).spn_safedis.Value = ((F_MarbleBottomPanelV1) this).SafeDis;
    ((F_MarbleCoordinatesV2) this).spn_rapiddis.Value = ((F_MarbleBottomPanelV1) this).RapidDis;
    ((F_MarbleCoordinatesV2) this).spn_plungefeed.Value = ((F_MarbleCoordinatesV2) this).PlungeFeed;
    ((F_MarbleCoordinatesV2) this).spn_cuttingfeed.Value = ((F_MarbleCoordinatesV2) this).CuttingFeed;
    ((F_MarbleCoordinatesV2) this).spn_slotheight.Value = ((F_MarbleBottomPanelV1) this).Diameter;
    ((F_MarbleCoordinatesV2) this).spn_slotwidth.Value = ((F_MarbleBottomPanelV1) this).Width;
    ((F_MarbleCoordinatesV2) this).spn_XPos.Value = ((F_MarbleBottomPanelV1) this).XPos;
    ((F_MarbleCoordinatesV2) this).spn_ZPos.Value = ((F_MarbleBottomPanelV1) this).YPos;
    \u0007.\u0001.\u0001((F_SlotNoDepth) this);
  }
}
