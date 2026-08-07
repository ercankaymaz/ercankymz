// Decompiled with JetBrains decompiler
// Type: buMarble.Forms.F_MarbleIOConfig
// Assembly: buMarble, Version=5.1.1.2, Culture=neutral, PublicKeyToken=null
// MVID: D6F2AAC2-9013-4D8E-A4D2-15511BAB107F
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMarble.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps.Marble;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buMarble.Forms;

public class F_MarbleIOConfig : Form
{
  public buButton btn_toolmag10;
  public buButton btn_toolmag9;
  public buButton btn_toolmag8;
  public buButton btn_toolmag7;
  public buButton btn_toolmag6;
  public buButton btn_toolmag5;
  public buButton btn_toolmag4;
  public buButton btn_toolmag3;
  public buButton btn_toolmag2;
  public buSpin spn_sawsocket;
  public buButton btn_saw_gozeroposition;
  public buButton btn_milling_gozeroposition;
  public buButton btn_millinghead_gozeroposition;
  public static byte f00043F;
  public static List<string> Captions;
  public FormProperties PropertiesForm = new FormProperties();
  internal IContainer \u0001 = (IContainer) null;
  public buButton btn_close;

  public void Apply()
  {
    buMarbleCalc.activeToolMilling.Geometry.Diameter = ((F_MarbleToolCurrentAllV2) this).spn_milling_diameter.Value;
    buMarbleCalc.activeToolMilling.Geometry.Length = ((F_MarbleToolCurrentAllV2) this).spn_milling_length.Value;
    buMarbleCalc.activeToolMilling.CamData.SpindleSpeed = ((F_MarbleToolCurrentAllV2) this).spn_milling_speed.Value;
    buMarbleCalc.activeToolSaw.Geometry.Diameter = ((F_MarbleToolCurrentAllV2) this).spn_sawdia.Value;
    buMarbleCalc.activeToolSaw.Geometry.Thickness = ((F_MarbleToolCurrentAllV2) this).spn_sawthickness.Value;
    buMarbleCalc.activeToolSaw.CamData.SpindleSpeed = ((F_MarbleToolCurrentAllV2) this).spn_sawspeed.Value;
    buMarbleCalc.activeToolSaw.Geometry.SocketThickness = this.spn_sawsocket.Value;
    buMarbleCalc.activeToolMillingHead.Geometry.Diameter = ((F_MarbleToolCurrentAllV2) this).spn_millinghead_diameter.Value;
    buMarbleCalc.activeToolMillingHead.Geometry.Length = ((F_MarbleToolCurrentAllV2) this).spn_millinghead_length.Value;
    buMarbleCalc.activeToolMillingHead.CamData.SpindleSpeed = ((F_MarbleToolCurrentAllV2) this).spn_millinghead_speed.Value;
    if (!(clsAppMarbleVars.varApp.ToolChangeCount > 0 & buMarbleCalc.ToolInMagazine != null))
      return;
    buMarbleCalc.ToolInMagazine[1].Geometry.Diameter = ((F_MarbleToolCurrentAllV2) this).spn_toolmagdia1.Value;
    buMarbleCalc.ToolInMagazine[1].Geometry.Length = ((F_MarbleToolCurrentAllV2) this).spn_toolmaglen1.Value;
    buMarbleCalc.ToolInMagazine[1].CamData.SpindleSpeed = ((F_MarbleToolCurrentAllV2) this).spn_toolmagapeed1.Value;
    buMarbleCalc.ToolInMagazine[1].Data.No = 1;
    buMarbleCalc.ToolInMagazine[2].Geometry.Diameter = ((F_MarbleToolCurrentAllV2) this).spn_toolmagdia2.Value;
    buMarbleCalc.ToolInMagazine[2].Geometry.Length = ((F_MarbleToolCurrentAllV2) this).spn_toolmaglen2.Value;
    buMarbleCalc.ToolInMagazine[2].CamData.SpindleSpeed = ((F_MarbleToolCurrentAllV2) this).spn_toolmagapeed2.Value;
    buMarbleCalc.ToolInMagazine[2].Data.No = 2;
    buMarbleCalc.ToolInMagazine[3].Geometry.Diameter = ((F_MarbleToolCurrentAllV2) this).spn_toolmagdia3.Value;
    buMarbleCalc.ToolInMagazine[3].Geometry.Length = ((F_MarbleToolCurrentAllV2) this).spn_toolmaglen3.Value;
    buMarbleCalc.ToolInMagazine[3].CamData.SpindleSpeed = ((F_MarbleToolCurrentAllV2) this).spn_toolmagapeed3.Value;
    buMarbleCalc.ToolInMagazine[3].Data.No = 3;
    buMarbleCalc.ToolInMagazine[4].Geometry.Diameter = ((F_MarbleToolCurrentAllV2) this).spn_toolmagdia4.Value;
    buMarbleCalc.ToolInMagazine[4].Geometry.Length = ((F_MarbleToolCurrentAllV2) this).spn_toolmaglen4.Value;
    buMarbleCalc.ToolInMagazine[4].CamData.SpindleSpeed = ((F_MarbleToolCurrentAllV2) this).spn_toolmagapeed4.Value;
    buMarbleCalc.ToolInMagazine[4].Data.No = 4;
    buMarbleCalc.ToolInMagazine[5].Geometry.Diameter = ((F_MarbleToolCurrentAllV2) this).spn_toolmagdia5.Value;
    buMarbleCalc.ToolInMagazine[5].Geometry.Length = ((F_MarbleToolCurrentAllV2) this).spn_toolmaglen5.Value;
    buMarbleCalc.ToolInMagazine[5].CamData.SpindleSpeed = ((F_MarbleToolCurrentAllV2) this).spn_toolmagapeed5.Value;
    buMarbleCalc.ToolInMagazine[5].Data.No = 5;
    buMarbleCalc.ToolInMagazine[6].Geometry.Diameter = ((F_MarbleToolCurrentAllV2) this).spn_toolmagdia6.Value;
    buMarbleCalc.ToolInMagazine[6].Geometry.Length = ((F_MarbleToolCurrentAllV2) this).spn_toolmaglen6.Value;
    buMarbleCalc.ToolInMagazine[6].CamData.SpindleSpeed = ((F_MarbleToolCurrentAllV2) this).spn_toolmagapeed6.Value;
    buMarbleCalc.ToolInMagazine[6].Data.No = 6;
    buMarbleCalc.ToolInMagazine[7].Geometry.Diameter = ((F_MarbleToolCurrentAllV2) this).spn_toolmagdia7.Value;
    buMarbleCalc.ToolInMagazine[7].Geometry.Length = ((F_MarbleToolCurrentAllV2) this).spn_toolmaglen7.Value;
    buMarbleCalc.ToolInMagazine[7].CamData.SpindleSpeed = ((F_MarbleToolCurrentAllV2) this).spn_toolmagapeed7.Value;
    buMarbleCalc.ToolInMagazine[7].Data.No = 7;
    buMarbleCalc.ToolInMagazine[8].Geometry.Diameter = ((F_MarbleToolCurrentAllV2) this).spn_toolmagdia8.Value;
    buMarbleCalc.ToolInMagazine[8].Geometry.Length = ((F_MarbleToolCurrentAllV2) this).spn_toolmaglen8.Value;
    buMarbleCalc.ToolInMagazine[8].CamData.SpindleSpeed = ((F_MarbleToolCurrentAllV2) this).spn_toolmagapeed8.Value;
    buMarbleCalc.ToolInMagazine[8].Data.No = 8;
    buMarbleCalc.ToolInMagazine[9].Geometry.Diameter = ((F_MarbleToolCurrentAllV2) this).spn_toolmagdia9.Value;
    buMarbleCalc.ToolInMagazine[9].Geometry.Length = ((F_MarbleToolCurrentAllV2) this).spn_toolmaglen9.Value;
    buMarbleCalc.ToolInMagazine[9].CamData.SpindleSpeed = ((F_MarbleToolCurrentAllV2) this).spn_toolmagapeed9.Value;
    buMarbleCalc.ToolInMagazine[9].Data.No = 9;
    buMarbleCalc.ToolInMagazine[10].Geometry.Diameter = ((F_MarbleToolCurrentAllV2) this).spn_toolmagdia10.Value;
    buMarbleCalc.ToolInMagazine[10].Geometry.Length = ((F_MarbleToolCurrentAllV2) this).spn_toolmaglen10.Value;
    buMarbleCalc.ToolInMagazine[10].CamData.SpindleSpeed = ((F_MarbleToolCurrentAllV2) this).spn_toolmagapeed10.Value;
    buMarbleCalc.ToolInMagazine[10].Data.No = 10;
  }

  public void MenuButtonColors(int PageIndex)
  {
    hmiUICommands.SetVisualItem(((F_MarbleToolCurrentAllV2) this).\u0001.Controls);
    if (PageIndex == 0)
    {
      ((F_MarbleToolCurrentAllV2) this).btn_sawtool.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      ((F_MarbleToolCurrentAllV2) this).btn_sawtool.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex == 1)
    {
      ((F_MarbleToolCurrentAllV2) this).btn_millingtool.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      ((F_MarbleToolCurrentAllV2) this).btn_millingtool.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex == 2)
    {
      ((F_MarbleToolCurrentAllV2) this).btn_millingheadtool.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      ((F_MarbleToolCurrentAllV2) this).btn_millingheadtool.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex == 3)
    {
      ((F_MarbleToolCurrentAllV2) this).btn_magazine.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      ((F_MarbleToolCurrentAllV2) this).btn_magazine.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    ((F_MarbleToolCurrentAllV2) this).SelectedTab = PageIndex;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    // ISSUE: unable to decompile the method.
  }

  public int ToolTypeToImageIndex(ToolType T)
  {
    int imageIndex;
    switch (T)
    {
      case ToolType.Flat:
        imageIndex = 0;
        break;
      case ToolType.Sphere:
        imageIndex = 1;
        break;
      case ToolType.Bullnose:
        imageIndex = 2;
        break;
      case ToolType.Taper:
        imageIndex = 3;
        break;
      case ToolType.Lollipop:
        imageIndex = 8;
        break;
      case ToolType.Dove:
        imageIndex = 7;
        break;
      case ToolType.Chamfer:
        imageIndex = 5;
        break;
      case ToolType.Barrel:
        imageIndex = 4;
        break;
      case ToolType.ConvexTip:
        imageIndex = 6;
        break;
      default:
        imageIndex = 0;
        break;
    }
    return imageIndex;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleToolCurrentAllV2) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleToolCurrentAllV2) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleIOConfig() => F_MarbleToolCurrentAllV2.Captions = new List<string>();

  public F_MarbleIOConfig() => \u0005.\u0003.\u0001(this);

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    ((F_MarbleToolSawTypes) this).buTab_tools.ItemSize = new Size(1, 1);
    int num1 = 40;
    int num2 = 60;
    int num3 = 60;
    int num4 = 220;
    if (((F_MarbleToolSawTypes) this).DGV_Input.Columns.Count == 0)
    {
      DataGridViewColumn dataGridViewColumn1 = new DataGridViewColumn();
      dataGridViewColumn1.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn1.Width = num1;
      dataGridViewColumn1.HeaderText = buLangTranslate.preDef.No;
      dataGridViewColumn1.Name = "No";
      dataGridViewColumn1.ReadOnly = true;
      dataGridViewColumn1.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn1.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_MarbleToolSawTypes) this).DGV_Input.Columns.Add(dataGridViewColumn1);
      DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
      dataGridViewColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn2.Width = ((F_MarbleToolSawTypes) this).DGV_Input.Width - num4 - num2 - num3 - num1 - 10;
      dataGridViewColumn2.HeaderText = buLangTranslate.preDef.Name;
      dataGridViewColumn2.Name = "Name";
      dataGridViewColumn2.ReadOnly = true;
      dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
      dataGridViewColumn2.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_MarbleToolSawTypes) this).DGV_Input.Columns.Add(dataGridViewColumn2);
      DataGridViewColumn dataGridViewColumn3 = new DataGridViewColumn();
      dataGridViewColumn3.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn3.Width = num2;
      dataGridViewColumn3.HeaderText = buLangTranslate.preDef.Index;
      dataGridViewColumn3.Name = "Index";
      dataGridViewColumn3.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn3.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_MarbleToolSawTypes) this).DGV_Input.Columns.Add(dataGridViewColumn3);
      DataGridViewColumn dataGridViewColumn4 = new DataGridViewColumn();
      dataGridViewColumn4.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn4.Width = num3;
      dataGridViewColumn4.HeaderText = buLangTranslate.preDef.Invert;
      dataGridViewColumn4.Name = "Invert";
      dataGridViewColumn4.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn4.CellTemplate = (DataGridViewCell) new DataGridViewCheckBoxCell();
      ((F_MarbleToolSawTypes) this).DGV_Input.Columns.Add(dataGridViewColumn4);
      DataGridViewColumn dataGridViewColumn5 = new DataGridViewColumn();
      dataGridViewColumn5.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn5.Width = num4;
      dataGridViewColumn5.HeaderText = buLangTranslate.preDef.Explanation;
      dataGridViewColumn5.Name = "Caption";
      dataGridViewColumn5.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
      dataGridViewColumn5.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_MarbleToolSawTypes) this).DGV_Input.Columns.Add(dataGridViewColumn5);
      DataGridViewColumn dataGridViewColumn6 = new DataGridViewColumn();
      dataGridViewColumn6.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn6.Width = num4;
      dataGridViewColumn6.HeaderText = "I";
      dataGridViewColumn6.Name = "I";
      dataGridViewColumn6.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
      dataGridViewColumn6.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_MarbleToolSawTypes) this).DGV_Input.Columns.Add(dataGridViewColumn6);
      ((F_MarbleToolSawTypes) this).DGV_Input.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12f, FontStyle.Bold);
    }
    ((F_MarbleToolSawTypes) this).DGV_Input.RowHeadersVisible = false;
    ((F_MarbleToolSawTypes) this).DGV_Input.AllowUserToAddRows = false;
    ((F_MarbleToolSawTypes) this).DGV_Input.AllowUserToResizeColumns = false;
    ((F_MarbleToolSawTypes) this).DGV_Input.ColumnHeadersVisible = true;
    if (((F_MarbleToolSawTypes) this).DGV_Output.Columns.Count == 0)
    {
      DataGridViewColumn dataGridViewColumn7 = new DataGridViewColumn();
      dataGridViewColumn7.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn7.Width = num1;
      dataGridViewColumn7.HeaderText = buLangTranslate.preDef.No;
      dataGridViewColumn7.Name = "No";
      dataGridViewColumn7.ReadOnly = true;
      dataGridViewColumn7.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn7.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_MarbleToolSawTypes) this).DGV_Output.Columns.Add(dataGridViewColumn7);
      DataGridViewColumn dataGridViewColumn8 = new DataGridViewColumn();
      dataGridViewColumn8.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn8.Width = ((F_MarbleToolSawTypes) this).DGV_Input.Width - num4 - num2 - num3 - num1 - 10;
      dataGridViewColumn8.HeaderText = buLangTranslate.preDef.Name;
      dataGridViewColumn8.Name = "Name";
      dataGridViewColumn8.ReadOnly = true;
      dataGridViewColumn8.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn8.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
      dataGridViewColumn8.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_MarbleToolSawTypes) this).DGV_Output.Columns.Add(dataGridViewColumn8);
      DataGridViewColumn dataGridViewColumn9 = new DataGridViewColumn();
      dataGridViewColumn9.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn9.Width = num2;
      dataGridViewColumn9.HeaderText = buLangTranslate.preDef.Index;
      dataGridViewColumn9.Name = "Index";
      dataGridViewColumn9.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn9.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn9.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_MarbleToolSawTypes) this).DGV_Output.Columns.Add(dataGridViewColumn9);
      DataGridViewColumn dataGridViewColumn10 = new DataGridViewColumn();
      dataGridViewColumn10.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn10.Width = num3;
      dataGridViewColumn10.HeaderText = buLangTranslate.preDef.Invert;
      dataGridViewColumn10.Name = "Invert";
      dataGridViewColumn10.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn10.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn10.CellTemplate = (DataGridViewCell) new DataGridViewCheckBoxCell();
      ((F_MarbleToolSawTypes) this).DGV_Output.Columns.Add(dataGridViewColumn10);
      ((F_MarbleToolSawTypes) this).DGV_Output.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12f, FontStyle.Bold);
      DataGridViewColumn dataGridViewColumn11 = new DataGridViewColumn();
      dataGridViewColumn11.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn11.Width = num4;
      dataGridViewColumn11.HeaderText = buLangTranslate.preDef.Explanation;
      dataGridViewColumn11.Name = "Caption";
      dataGridViewColumn11.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn11.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
      dataGridViewColumn11.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_MarbleToolSawTypes) this).DGV_Output.Columns.Add(dataGridViewColumn11);
      DataGridViewColumn dataGridViewColumn12 = new DataGridViewColumn();
      dataGridViewColumn12.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn12.Width = num4;
      dataGridViewColumn12.HeaderText = "O";
      dataGridViewColumn12.Name = "O";
      dataGridViewColumn12.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn12.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
      dataGridViewColumn12.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_MarbleToolSawTypes) this).DGV_Output.Columns.Add(dataGridViewColumn12);
    }
    ((F_MarbleToolSawTypes) this).DGV_Output.RowHeadersVisible = false;
    ((F_MarbleToolSawTypes) this).DGV_Output.AllowUserToAddRows = false;
    ((F_MarbleToolSawTypes) this).DGV_Output.ColumnHeadersVisible = true;
    ((F_MarbleToolSawTypes) this).DGV_Output.AllowUserToResizeColumns = false;
    this.FillIO();
    ((F_MarbleToolSawTypes) this).MenuButtonColors(0);
    this.PropertiesForm.Result = DialogResult.None;
    this.PropertiesForm.Inited = true;
    \u0005.\u0003.\u0001(this);
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

  public void FillIO()
  {
    ((F_MarbleToolSawTypes) this).DGV_Input.Rows.Clear();
    for (int index = 0; index <= clsAppMarbleVars.cMachine.Inputs.Count - 1; ++index)
    {
      DataGridViewRowCollection rows = ((F_MarbleToolSawTypes) this).DGV_Input.Rows;
      string name = clsAppMarbleVars.cMachine.Inputs[index].Name;
      int sourceIndex = clsAppMarbleVars.cMachine.Inputs[index].SourceIndex;
      bool invert = clsAppMarbleVars.cMachine.Inputs[index].Invert;
      string caption = clsAppMarbleVars.cMachine.Inputs[index].Caption;
      string str = "Off";
      object[] objArray = \u0005.\u0003.\u0001(sourceIndex, invert, str, this, name, caption, index + 1);
      rows.Add(objArray);
      ((F_MarbleToolSawTypes) this).DGV_Input.Rows[((F_MarbleToolSawTypes) this).DGV_Input.Rows.Count - 1].Height = 40;
      if (clsAppMarbleVars.cMachine.Inputs[index].SourceIndex >= 0)
        ((F_MarbleToolSawTypes) this).DGV_Input.Rows[((F_MarbleToolSawTypes) this).DGV_Input.Rows.Count - 1].DefaultCellStyle.BackColor = Color.WhiteSmoke;
      else
        ((F_MarbleToolSawTypes) this).DGV_Input.Rows[((F_MarbleToolSawTypes) this).DGV_Input.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightCoral;
    }
    ((F_MarbleToolSawTypes) this).DGV_Output.Rows.Clear();
    for (int index = 0; index <= clsAppMarbleVars.cMachine.Outputs.Count - 1; ++index)
    {
      DataGridViewRowCollection rows = ((F_MarbleToolSawTypes) this).DGV_Output.Rows;
      string name = clsAppMarbleVars.cMachine.Outputs[index].Name;
      int sourceIndex = clsAppMarbleVars.cMachine.Outputs[index].SourceIndex;
      bool invert = clsAppMarbleVars.cMachine.Outputs[index].Invert;
      string caption = clsAppMarbleVars.cMachine.Outputs[index].Caption;
      string str = "Off";
      object[] objArray = \u0005.\u0003.\u0001(name, str, index + 1, invert, this, sourceIndex, caption);
      rows.Add(objArray);
      ((F_MarbleToolSawTypes) this).DGV_Output.Rows[((F_MarbleToolSawTypes) this).DGV_Output.Rows.Count - 1].Height = 40;
      if (clsAppMarbleVars.cMachine.Outputs[index].SourceIndex >= 0)
        ((F_MarbleToolSawTypes) this).DGV_Output.Rows[((F_MarbleToolSawTypes) this).DGV_Output.Rows.Count - 1].DefaultCellStyle.BackColor = Color.WhiteSmoke;
      else
        ((F_MarbleToolSawTypes) this).DGV_Output.Rows[((F_MarbleToolSawTypes) this).DGV_Output.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightCoral;
    }
  }
}
