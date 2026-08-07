// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.F_RouterOperations
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms;

public class F_RouterOperations : Form
{
  private IContainer \u0001;
  public Button btn_cancel;
  internal ImageList \u0001;
  public Button btn_ok;
  internal Label \u0001;
  internal NumericUpDown \u0001;
  internal Label \u0002;
  internal NumericUpDown \u0002;
  internal Panel \u0001;
  public Button btn_aligment;
  internal CheckBox \u0001;
  internal CheckBox \u0002;
  internal Panel \u0002;
  internal Label \u0003;
  public Button btn_rightbottom;
  public Button btn_bottom;
  public Button btn_leftbottom;
  public Button btn_right;
  public Button btn_center;
  public Button btn_left;
  public Button btn_righttop;
  public Button btn_top;
  public Button btn_lefttop;
  public FormProperties Properties;
  public static List<string> Captions;
  public CopyEventFormVars Settings;
  internal IContainer \u0001;
  public Button btn_cancel;
  internal ImageList \u0001;
  public Button btn_ok;
  internal Label \u0001;
  internal NumericUpDown \u0001;
  internal Label \u0002;
  internal NumericUpDown \u0002;
  internal Label \u0003;
  internal NumericUpDown \u0003;
  internal Panel \u0001;
  internal Panel \u0002;
  internal Label \u0004;
  public Button btn_rightbottom;
  public Button btn_bottom;
  public Button btn_leftbottom;
  public Button btn_right;
  public Button btn_center;
  public Button btn_left;
  public Button btn_righttop;
  public Button btn_top;

  public void Init()
  {
    ((F_Move) this).PropertiesForm.Inited = false;
    string str1 = "No";
    string str2 = "Sel";
    string str3 = "Name";
    string str4 = "Index";
    string str5 = "Action";
    if (((F_Scale) this).\u0001.Columns.Count == 0)
    {
      DataGridViewColumn dataGridViewColumn1 = new DataGridViewColumn();
      dataGridViewColumn1.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn1.Width = 40;
      dataGridViewColumn1.HeaderText = str1;
      dataGridViewColumn1.Name = "No";
      dataGridViewColumn1.ReadOnly = true;
      dataGridViewColumn1.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn1.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_Scale) this).\u0001.Columns.Add(dataGridViewColumn1);
      DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
      dataGridViewColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn2.Width = 40;
      dataGridViewColumn2.HeaderText = str2;
      dataGridViewColumn2.Name = "Sel";
      dataGridViewColumn2.ReadOnly = false;
      dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn2.CellTemplate = (DataGridViewCell) new DataGridViewCheckBoxCell();
      ((F_Scale) this).\u0001.Columns.Add(dataGridViewColumn2);
      DataGridViewColumn dataGridViewColumn3 = new DataGridViewColumn();
      dataGridViewColumn3.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn3.Width = 240 /*0xF0*/;
      dataGridViewColumn3.HeaderText = str3;
      dataGridViewColumn3.Name = "Name";
      dataGridViewColumn3.ReadOnly = false;
      dataGridViewColumn3.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn3.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_Scale) this).\u0001.Columns.Add(dataGridViewColumn3);
      DataGridViewColumn dataGridViewColumn4 = new DataGridViewColumn();
      dataGridViewColumn4.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn4.Width = 45;
      dataGridViewColumn4.HeaderText = str4;
      dataGridViewColumn4.Name = "Index";
      dataGridViewColumn4.ReadOnly = false;
      dataGridViewColumn4.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn4.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_Scale) this).\u0001.Columns.Add(dataGridViewColumn4);
      DataGridViewColumn dataGridViewColumn5 = new DataGridViewColumn();
      dataGridViewColumn5.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn5.Width = 110;
      dataGridViewColumn5.HeaderText = str5;
      dataGridViewColumn5.Name = "Action";
      dataGridViewColumn5.ReadOnly = false;
      dataGridViewColumn5.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      DataGridViewComboBoxCell viewComboBoxCell = new DataGridViewComboBoxCell();
      ArrayList EnumItems = new ArrayList();
      buGeneral.GetEnumTypeValues((object) AnalyseEntitiesActionType.None, ref EnumItems);
      for (int index = 0; index <= EnumItems.Count - 1; ++index)
        viewComboBoxCell.Items.AddRange((object) EnumItems[index].ToString());
      dataGridViewColumn5.CellTemplate = (DataGridViewCell) viewComboBoxCell;
      ((F_Scale) this).\u0001.Columns.Add(dataGridViewColumn5);
    }
    ((F_Scale) this).\u0001.RowHeadersVisible = false;
    ((F_Scale) this).\u0001.AllowUserToAddRows = false;
    ((F_Scale) this).\u0001.AllowUserToResizeColumns = false;
    \u0007.\u0001.\u0001((F_AnalyseResult) this);
    this.LoadLanguage();
    ((F_Move) this).PropertiesForm.Result = DialogResult.None;
    ((F_Move) this).PropertiesForm.Inited = false;
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_Move) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_Move) this).PropertiesForm.Result = DialogResult.Cancel;
    this.Visible = false;
  }

  public void LoadLanguage()
  {
    string callMethod = "NestSheetPart LoadLanguage";
    try
    {
      if (F_Devide.Captions.Count < 33)
        return;
      this.Text = F_Devide.Captions[0];
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
    if (str == ((F_Devide) this).\u0001.Name)
    {
      this.Visible = false;
      ((F_Move) this).PropertiesForm.Result = DialogResult.Cancel;
    }
    if (str == ((F_Devide) this).\u0002.Name)
    {
      this.Visible = false;
      ((F_Move) this).PropertiesForm.Result = DialogResult.OK;
      // ISSUE: reference to a compiler-generated field
      if (((F_Move) this).\u0002 != null)
      {
        // ISSUE: reference to a compiler-generated field
        ((F_Move) this).\u0002((object) null, (object) null);
      }
    }
    // ISSUE: reference to a compiler-generated field
    if (!(str == ((F_Scale) this).btn_find.Name) || !(((F_Move) this).\u0001 >= 0 & ((F_Move) this).\u0001 <= ((MachineDef) ((F_Move) this).Result).ErrorList.Count - 1) || ((F_Move) this).\u0004 == null || !(((F_Move) this).\u0001 >= 0 & ((F_Move) this).\u0001 <= ((MachineDef) ((F_Move) this).Result).ErrorList.Count - 1))
      return;
    // ISSUE: reference to a compiler-generated field
    ((F_Move) this).\u0004((object) ((F_Move) this).\u0001, (object) ((MachineDef) ((F_Move) this).Result).ErrorList[((F_Move) this).\u0001]);
  }

  internal void \u0001([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    // ISSUE: reference to a compiler-generated field
    if (!(obj1.RowIndex >= 0 & obj1.RowIndex <= ((MachineDef) ((F_Move) this).Result).ErrorList.Count - 1) || ((F_Move) this).\u0001 == null || !(obj1.RowIndex >= 0 & obj1.RowIndex <= ((MachineDef) ((F_Move) this).Result).ErrorList.Count - 1))
      return;
    ((F_Move) this).\u0001 = obj1.RowIndex;
    ((F_Move) this).\u0002 = obj1.ColumnIndex;
    // ISSUE: reference to a compiler-generated field
    ((F_Move) this).\u0001((object) obj1.RowIndex, (object) ((MachineDef) ((F_Move) this).Result).ErrorList[obj1.RowIndex]);
  }

  internal void \u0002([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    if (!(obj1.ColumnIndex >= 0 & obj1.RowIndex >= 0))
      return;
    if (obj1.ColumnIndex == 1 & obj1.RowIndex <= ((MachineDef) ((F_Move) this).Result).ErrorList.Count - 1)
      ((MachineDefPart) ((MachineDef) ((F_Move) this).Result).ErrorList[obj1.RowIndex]).Enable = Convert.ToBoolean(((F_Scale) this).\u0001.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value);
    if (!(obj1.ColumnIndex == 4 & obj1.RowIndex <= ((MachineDef) ((F_Move) this).Result).ErrorList.Count - 1))
      return;
    ((MachineDefPart) ((MachineDef) ((F_Move) this).Result).ErrorList[obj1.RowIndex]).Action = (AnalyseEntitiesActionType) buGeneral.EnumValueFromString((object) ((MachineDefPart) ((MachineDef) ((F_Move) this).Result).ErrorList[obj1.RowIndex]).Action, ((F_Scale) this).\u0001.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value.ToString().Trim());
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_Devide) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_Devide) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_RouterOperations()
  {
    F_Devide.Captions = new List<string>();
    F_Devide.CaptionGrid = new List<string>();
  }
}
