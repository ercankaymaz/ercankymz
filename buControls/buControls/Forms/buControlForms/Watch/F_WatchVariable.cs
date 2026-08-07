// Decompiled with JetBrains decompiler
// Type: buControls.Forms.buControlForms.Watch.F_WatchVariable
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buControls.Controls;
using buControls.DialogBox;
using buCore;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.buControlForms.Watch;

public class F_WatchVariable : Form
{
  public string AddString = "";
  public static List<string> Captions = new List<string>();
  public List<WatchItem> Items = new List<WatchItem>();
  public bool HideNewValueColumb = false;
  public bool HideExplanationColumb = false;
  public bool HideStatusColumb = false;
  public List<string> ConstantStringList = new List<string>();
  private int int_0 = -1;
  private IContainer icontainer_0 = (IContainer) null;
  internal buGround buGround_0;
  internal buButton buButton_0;
  internal buButton buButton_1;
  public DataGridView DGV;
  internal buButton buButton_2;
  public buButton btn_add;
  public buButton btn_cancel;
  public buButton btn_write;
  public buButton btn_save;
  public buButton btn_load;
  public buButton buButton4;
  public buButton btn_reset;
  public buButton btn_removeall;
  public buButton btn_remove;
  internal buTextBox buTextBox_0;

  public F_WatchVariable() => Class39.smethod_543(this);

  public event WatchItemResetClickEventHandler ResetClick;

  public event WatchItemRemoveAllClickEventHandler RemoveAllClick;

  public event WatchItemRemoveClickEventHandler RemoveClick;

  public event WatchItemListChangedEventHandler ListChanged;

  public event WatchItemWriteSingleEventHandler WriteItem;

  public void Init()
  {
    try
    {
      this.DGV.RowHeadersVisible = false;
      this.DGV.ColumnHeadersVisible = false;
      this.DGV.AllowUserToAddRows = false;
      this.DGV.AllowUserToResizeColumns = false;
      this.DGV.AllowUserToResizeRows = false;
      this.DGV.Rows.Clear();
      this.DGV.Columns.Clear();
      DataGridViewColumn dataGridViewColumn1 = new DataGridViewColumn();
      dataGridViewColumn1.Width = 50;
      dataGridViewColumn1.HeaderText = "No";
      dataGridViewColumn1.Name = "No";
      dataGridViewColumn1.ReadOnly = true;
      dataGridViewColumn1.DefaultCellStyle.Font = new Font("Arial", 12f, FontStyle.Bold);
      dataGridViewColumn1.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      this.DGV.Columns.Add(dataGridViewColumn1);
      DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
      dataGridViewColumn2.Width = 400;
      dataGridViewColumn2.HeaderText = "Name";
      dataGridViewColumn2.Name = "Name";
      dataGridViewColumn2.ReadOnly = false;
      dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 12f, FontStyle.Bold);
      dataGridViewColumn2.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
      this.DGV.Columns.Add(dataGridViewColumn2);
      DataGridViewColumn dataGridViewColumn3 = new DataGridViewColumn();
      dataGridViewColumn3.Width = 200;
      dataGridViewColumn3.HeaderText = "Value";
      dataGridViewColumn3.Name = "Value";
      dataGridViewColumn3.ReadOnly = true;
      dataGridViewColumn3.DefaultCellStyle.Font = new Font("Arial", 12f, FontStyle.Bold);
      dataGridViewColumn3.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      this.DGV.Columns.Add(dataGridViewColumn3);
      DataGridViewComboBoxColumn viewComboBoxColumn = new DataGridViewComboBoxColumn();
      viewComboBoxColumn.Width = 140;
      viewComboBoxColumn.HeaderText = "Type";
      viewComboBoxColumn.Name = "Type";
      viewComboBoxColumn.ReadOnly = true;
      viewComboBoxColumn.DataSource = (object) Enum.GetValues(typeof (VariableType));
      viewComboBoxColumn.ValueType = typeof (VariableType);
      viewComboBoxColumn.DefaultCellStyle.Font = new Font("Arial", 12f, FontStyle.Bold);
      viewComboBoxColumn.ReadOnly = false;
      this.DGV.Columns.Add((DataGridViewColumn) viewComboBoxColumn);
      for (int index = 0; index <= this.Items.Count - 1; ++index)
        this.DGV.Rows.Add((object) (index + 1).ToString(), (object) this.Items[index].Name, (object) this.Items[index].Value.ToString(), (object) this.Items[index].VarType);
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public void LoadLanguage()
  {
    try
    {
      if (F_WatchVariable.Captions.Count <= 0)
        return;
      this.Text = F_WatchVariable.Captions[0];
      this.btn_reset.Text = F_WatchVariable.Captions[0];
      this.btn_write.Text = F_WatchVariable.Captions[0];
      this.btn_add.Text = F_WatchVariable.Captions[0];
      this.btn_remove.Text = F_WatchVariable.Captions[0];
      this.btn_removeall.Text = F_WatchVariable.Captions[0];
      this.btn_save.Text = F_WatchVariable.Captions[0];
      this.btn_cancel.Text = F_WatchVariable.Captions[0];
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public void UpdateWatchList(List<WatchItem> Items)
  {
    try
    {
      for (int index = 0; index <= Items.Count - 1; ++index)
      {
        if (index <= this.DGV.Rows.Count - 1)
          ;
      }
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  internal void method_0(object sender, DataGridViewCellEventArgs e)
  {
    try
    {
      this.int_0 = e.RowIndex;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  internal void method_1(object sender, DataGridViewCellEventArgs e)
  {
    try
    {
      if (!(e.RowIndex >= 0 & e.RowIndex <= this.Items.Count - 1))
        return;
      if (e.ColumnIndex == 1)
      {
        this.Items[e.RowIndex].Name = this.DGV.Rows[e.RowIndex].Cells[1].Value.ToString();
        this.Items[e.RowIndex].VarType = (VariableType) this.DGV.Rows[e.RowIndex].Cells[3].Value;
        // ISSUE: reference to a compiler-generated field
        if (this.watchItemListChangedEventHandler_0 != null)
        {
          // ISSUE: reference to a compiler-generated field
          this.watchItemListChangedEventHandler_0(this.Items);
        }
      }
      if (e.ColumnIndex == 3)
      {
        this.Items[e.RowIndex].Name = this.DGV.Rows[e.RowIndex].Cells[1].Value.ToString();
        this.Items[e.RowIndex].VarType = (VariableType) this.DGV.Rows[e.RowIndex].Cells[3].Value;
        // ISSUE: reference to a compiler-generated field
        if (this.watchItemListChangedEventHandler_0 != null)
        {
          // ISSUE: reference to a compiler-generated field
          this.watchItemListChangedEventHandler_0(this.Items);
        }
      }
      this.btn_write.Focus();
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  internal void method_2(object sender, EventArgs e)
  {
    try
    {
      // ISSUE: reference to a compiler-generated field
      if (this.watchItemResetClickEventHandler_0 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.watchItemResetClickEventHandler_0();
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  internal void method_3(object sender, EventArgs e)
  {
    try
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.InitialDirectory = Application.StartupPath;
      saveFileDialog.Filter = "Watch Item Files (*.watch)|*.watch";
      saveFileDialog.FilterIndex = 1;
      saveFileDialog.FileName = "";
      if (saveFileDialog.ShowDialog() != DialogResult.OK)
        return;
      List<string> StringList = new List<string>();
      StringList.Add("Name ; Value ; MinValue ; MaxValue ; AvarageValue ; Explanation");
      for (int index = 0; index <= this.Items.Count - 1; ++index)
      {
        string str = $"{this.Items[index].Name} ; {this.Items[index].Value.ToString()} ; {this.Items[index].MinValue.ToString()} ; {this.Items[index].MaxValue.ToString()} ; {this.Items[index].AvarageValue.ToString()} ; {this.Items[index].Explanation}";
        StringList.Add(str);
      }
      buFile.SaveToFile(StringList, saveFileDialog.FileName);
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  internal void method_4(object sender, EventArgs e)
  {
    try
    {
      this.Items.Add(new WatchItem());
      this.DGV.Rows.Add((object) this.Items.Count, (object) "", (object) "", (object) this.Items[this.Items.Count - 1].VarType);
      if (this.DGV.Rows.Count > 0)
        this.DGV.Rows[this.DGV.Rows.Count - 1].Cells[2].Style.BackColor = Color.White;
      // ISSUE: reference to a compiler-generated field
      if (this.watchItemListChangedEventHandler_0 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.watchItemListChangedEventHandler_0(this.Items);
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  internal void method_5(object sender, EventArgs e)
  {
    try
    {
      string text = "Do You Want to Remove";
      if (AppLanguage.SystemMessages.Count >= 8)
        text = AppLanguage.SystemMessages[7];
      if (MessageBox.Show(text, Application.ProductName, MessageBoxButtons.YesNo) == DialogResult.No || !(this.int_0 >= 0 & this.int_0 <= this.Items.Count - 1))
        return;
      this.DGV.Rows.RemoveAt(this.int_0);
      this.Items.RemoveAt(this.int_0);
      // ISSUE: reference to a compiler-generated field
      if (this.watchItemListChangedEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.watchItemListChangedEventHandler_0(this.Items);
      }
      // ISSUE: reference to a compiler-generated field
      if (this.watchItemRemoveClickEventHandler_0 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.watchItemRemoveClickEventHandler_0(this.int_0);
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  internal void method_6(object sender, EventArgs e)
  {
    try
    {
      string text = "Do You Want to Remove All";
      if (AppLanguage.SystemMessages.Count >= 9)
        text = AppLanguage.SystemMessages[8];
      if (MessageBox.Show(text, Application.ProductName, MessageBoxButtons.YesNo) == DialogResult.No)
        return;
      this.DGV.Rows.Clear();
      this.Items.Clear();
      // ISSUE: reference to a compiler-generated field
      if (this.watchItemListChangedEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.watchItemListChangedEventHandler_0(this.Items);
      }
      // ISSUE: reference to a compiler-generated field
      if (this.watchItemRemoveAllClickEventHandler_0 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.watchItemRemoveAllClickEventHandler_0();
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  internal void method_7(object sender, EventArgs e)
  {
    try
    {
      // ISSUE: reference to a compiler-generated field
      if (this.watchItemWriteSingleEventHandler_0 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.watchItemWriteSingleEventHandler_0(new WatchItem(this.Items[this.int_0])
      {
        NewValue = this.buTextBox_0.Text
      });
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  internal void method_8(object sender, EventArgs e)
  {
    try
    {
      if (this.ConstantStringList.Count <= 0)
        return;
      DialogBoxList dialogBoxList = new DialogBoxList();
      for (int index = 0; index <= this.ConstantStringList.Count - 1; ++index)
        dialogBoxList.Items.Add(this.ConstantStringList[index]);
      dialogBoxList.Init();
      int num = (int) dialogBoxList.ShowDialog();
      if (dialogBoxList.Result != DialogResult.OK || !(this.int_0 >= 0 & this.int_0 <= this.DGV.Rows.Count - 1))
        return;
      this.DGV.Rows[this.int_0].Cells[1].Value = (object) dialogBoxList.SelectedItemText;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  internal void method_9(object sender, EventArgs e)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) sender;
      if (control2.Name == this.buButton_1.Name | control2.Name == this.btn_cancel.Name)
        this.Visible = false;
      if (control2.Name == this.buButton_0.Name)
        this.WindowState = FormWindowState.Minimized;
      if (!(control2.Name == this.buButton_2.Name))
        return;
      if (this.WindowState == FormWindowState.Maximized)
        this.WindowState = FormWindowState.Normal;
      else
        this.WindowState = FormWindowState.Maximized;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
