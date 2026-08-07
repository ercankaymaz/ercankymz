// Decompiled with JetBrains decompiler
// Type: buControls.Forms.buControlForms.Counters.F_Counters
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buControls.Controls;
using buCore;
using ns7;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.buControlForms.Counters;

public class F_Counters : Form
{
  public bool ShowCommunicationAddress = true;
  public DialogResult Result = DialogResult.None;
  private int int_0 = -1;
  private int int_1 = -1;
  private double double_0 = 0.0;
  public List<CounterItem> Counters = new List<CounterItem>();
  private IContainer icontainer_0 = (IContainer) null;
  internal buGround buGround_0;
  internal buButton buButton_0;
  internal buButton buButton_1;
  internal buButton buButton_2;
  public buButton btn_save;
  public buButton btn_load;
  public buButton btn_reset;
  public buButton btn_cancel;
  public buGrid grid_counter;
  public buButton btn_removeall;
  public buButton btn_remove;
  public buButton btn_add;
  public buButton btn_ok;
  internal buGroup buGroup_0;
  public buButton btn_itemclose;
  public buButton btn_itemadd;
  internal buTextBox buTextBox_0;
  public buSpin spn_limit;
  internal buTextBox buTextBox_1;
  public buButton btn_report;
  public buButton btn_resettotalall;
  public buButton btn_resettotal;

  public F_Counters() => Class39.smethod_137(this);

  public event CounterFileEventHandler LoadCounter;

  public event CounterFileEventHandler SaveCounter;

  public event CounterResetEventHandler ResetCounter;

  public event CounterResetAllEventHandler ResetTotalAllCounter;

  public event CounterResetEventHandler ResetTotalCounter;

  public void Init(List<CounterItem> counters)
  {
    this.grid_counter.customColumbs.Clear();
    ColumbProperties columbProperties = new ColumbProperties();
    this.grid_counter.customColumbs.Add(new ColumbProperties("Name", 320, false, System.Type.GetType("System.String")));
    this.grid_counter.customColumbs.Add(new ColumbProperties("Count", 150, true, System.Type.GetType("System.Double")));
    this.grid_counter.customColumbs.Add(new ColumbProperties("Limit", 150, false, System.Type.GetType("System.Double")));
    this.grid_counter.customColumbs.Add(new ColumbProperties("Previous Count", 150, true, System.Type.GetType("System.Double")));
    this.grid_counter.customColumbs.Add(new ColumbProperties("Total Count", 150, true, System.Type.GetType("System.Double")));
    int width = this.grid_counter.Width - this.grid_counter.customColumbs[0].Width - this.grid_counter.customColumbs[1].Width - this.grid_counter.customColumbs[2].Width - this.grid_counter.customColumbs[3].Width - this.grid_counter.customColumbs[4].Width - 20;
    if (width < 40)
      width = 40;
    this.grid_counter.customColumbs.Add(new ColumbProperties("Reset Date", width, true, System.Type.GetType("System.String")));
    this.grid_counter.Creat();
    this.grid_counter.Dt.Rows.Clear();
    for (int index = 0; index <= counters.Count - 1; ++index)
      this.grid_counter.AddNewRow((object) counters[index].Name, (object) counters[index].ActualCount, (object) counters[index].Limit, (object) counters[index].PreviousCount, (object) counters[index].TotalCount, (object) buConversion.DateToString(counters[index].ResetDate));
    this.Counters.Clear();
    for (int index = 0; index <= counters.Count - 1; ++index)
      this.Counters.Add(new CounterItem(counters[index]));
    this.Result = DialogResult.Cancel;
    this.buTextBox_1.Visible = this.ShowCommunicationAddress;
  }

  public void FieldsToParameter()
  {
    for (int index = 0; index <= this.grid_counter.Rows.Count - 1; ++index)
    {
      if (index <= this.Counters.Count - 1)
      {
        double result = 0.0;
        this.Counters[index].Name = this.grid_counter.Rows[index].Cells[0].Value.ToString();
        if (double.TryParse(this.grid_counter.Rows[index].Cells[2].Value.ToString(), out result))
          this.Counters[index].Limit = result;
      }
    }
  }

  internal void method_0(object sender, EventArgs e)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) sender;
      if (control2.Name == this.buButton_2.Name | control2.Name == this.btn_cancel.Name)
      {
        this.Visible = false;
        this.Result = DialogResult.Cancel;
      }
      if (control2.Name == this.buButton_1.Name)
        this.WindowState = FormWindowState.Minimized;
      if (!(control2.Name == this.buButton_0.Name))
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

  internal void method_1(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (control2.Name == this.btn_itemadd.Name)
    {
      this.Counters.Add(new CounterItem(this.buTextBox_0.Text)
      {
        Limit = this.spn_limit.Value,
        Address = this.buTextBox_1.Text,
        ResetDate = DateTime.Now
      });
      this.grid_counter.AddNewRow((object) this.buTextBox_0.Text, (object) 0, (object) this.spn_limit.Value, (object) 0, (object) 0, (object) buConversion.DateToString(DateTime.Now));
    }
    if (control2.Name == this.btn_itemclose.Name)
      this.buGroup_0.Visible = false;
    if (control2.Name == this.btn_add.Name && AppSecurity.PasswordLevel >= 1)
      this.buGroup_0.Visible = true;
    if (control2.Name == this.btn_remove.Name && AppSecurity.PasswordLevel >= 1 && this.int_1 >= 0 & this.int_1 <= this.Counters.Count - 1 && buString.MessageBoxQuestion(AppLanguage.SystemMessages[7]) == DialogResult.Yes)
    {
      this.Counters.RemoveAt(this.int_1);
      this.grid_counter.Dt.Rows.RemoveAt(this.int_1);
    }
    if (control2.Name == this.btn_removeall.Name && AppSecurity.PasswordLevel >= 1 && this.Counters.Count > 0 && buString.MessageBoxQuestion(AppLanguage.SystemMessages[8]) == DialogResult.Yes)
    {
      this.Counters.Clear();
      this.grid_counter.Dt.Rows.Clear();
    }
    if (control2.Name == this.btn_ok.Name)
    {
      this.Result = DialogResult.OK;
      this.FieldsToParameter();
      this.Visible = false;
    }
    if (control2.Name == this.btn_save.Name)
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.InitialDirectory = AppPath.Counter;
      saveFileDialog.Filter = "Counter Files (*.bucnt)|*.bucnt";
      saveFileDialog.FilterIndex = 1;
      saveFileDialog.FileName = "";
      if (this.Counters.Count > 0 && saveFileDialog.ShowDialog() == DialogResult.OK)
      {
        AppPath.Counter = buFile.GetPath(saveFileDialog.FileName);
        ArrayList StringList = new ArrayList();
        for (int index = 0; index <= this.Counters.Count - 1; ++index)
          StringList.AddRange((ICollection) this.Counters[index].ToDefAll("", 0, SerilizationMode.MultiLine));
        buFile.SaveToFile(StringList, saveFileDialog.FileName);
        // ISSUE: reference to a compiler-generated field
        if (this.counterFileEventHandler_1 != null)
        {
          // ISSUE: reference to a compiler-generated field
          this.counterFileEventHandler_1(new FileEventArg(saveFileDialog.FileName), this.Counters);
        }
      }
    }
    if (control2.Name == this.btn_load.Name)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.InitialDirectory = AppPath.Counter;
      openFileDialog.Filter = "Counter Files (*.bucnt)|*.bucnt";
      openFileDialog.FilterIndex = 1;
      openFileDialog.Multiselect = false;
      openFileDialog.FileName = "";
      if (openFileDialog.ShowDialog() == DialogResult.OK)
      {
        AppPath.Counter = buFile.GetPath(openFileDialog.FileName);
        List<string> StringList = new List<string>();
        buFile.OpenFromFile(openFileDialog.FileName, ref StringList);
        List<List<string>> CalcList = new List<List<string>>();
        buString.ListToSpecificList("<CounterItem>", "</CounterItem>", true, StringList, ref CalcList);
        if (CalcList.Count > 0)
          this.Counters.Clear();
        for (int index = 0; index <= CalcList.Count - 1; ++index)
        {
          ArrayList AL = new ArrayList();
          AL.AddRange((ICollection) CalcList[index].ToArray());
          CounterItem counterItem = new CounterItem();
          buSerilization.Decode(AL, "", SerilizationMode.MultiLine, (object) counterItem);
          this.Counters.Add(counterItem);
        }
        this.grid_counter.Dt.Rows.Clear();
        for (int index = 0; index <= this.Counters.Count - 1; ++index)
          this.grid_counter.AddNewRow((object) this.Counters[index].Name, (object) this.Counters[index].ActualCount, (object) this.Counters[index].Limit, (object) this.Counters[index].PreviousCount, (object) this.Counters[index].TotalCount, (object) buConversion.DateToString(this.Counters[index].ResetDate));
        // ISSUE: reference to a compiler-generated field
        if (this.counterFileEventHandler_0 != null)
        {
          // ISSUE: reference to a compiler-generated field
          this.counterFileEventHandler_0(new FileEventArg(openFileDialog.FileName), this.Counters);
        }
      }
    }
    if (control2.Name == this.btn_reset.Name)
    {
      if (this.int_1 >= 0 & this.int_1 <= this.grid_counter.Rows.Count - 1)
      {
        this.Counters[this.int_1].ActualCount = double.Parse(this.grid_counter.Rows[this.int_1].Cells[1].Value.ToString());
        this.Counters[this.int_1].PreviousCount = this.Counters[this.int_1].ActualCount;
        this.Counters[this.int_1].TotalCount += this.Counters[this.int_1].ActualCount;
        this.Counters[this.int_1].ActualCount = 0.0;
        this.Counters[this.int_1].ResetDate = DateTime.Now;
        this.grid_counter.Rows[this.int_1].Cells[3].Value = (object) this.Counters[this.int_1].PreviousCount;
        this.grid_counter.Rows[this.int_1].Cells[4].Value = (object) this.Counters[this.int_1].TotalCount;
        this.grid_counter.Rows[this.int_1].Cells[1].Value = (object) this.Counters[this.int_1].ActualCount;
        this.grid_counter.Rows[this.int_1].Cells[5].Value = (object) buConversion.DateToString(this.Counters[this.int_1].ResetDate);
      }
      // ISSUE: reference to a compiler-generated field
      if (this.counterResetEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.counterResetEventHandler_0(this.int_1, DateTime.Now, this.Counters[this.int_1]);
      }
    }
    if (control2.Name == this.btn_resettotal.Name)
    {
      if (this.int_1 >= 0 & this.int_1 <= this.grid_counter.Rows.Count - 1)
      {
        this.Counters[this.int_1].PreviousCount = 0.0;
        this.Counters[this.int_1].TotalCount = 0.0;
        this.Counters[this.int_1].ActualCount = 0.0;
        this.Counters[this.int_1].ResetDate = DateTime.Now;
        this.grid_counter.Rows[this.int_1].Cells[3].Value = (object) this.Counters[this.int_1].PreviousCount;
        this.grid_counter.Rows[this.int_1].Cells[4].Value = (object) this.Counters[this.int_1].TotalCount;
        this.grid_counter.Rows[this.int_1].Cells[1].Value = (object) this.Counters[this.int_1].ActualCount;
        this.grid_counter.Rows[this.int_1].Cells[5].Value = (object) buConversion.DateToString(this.Counters[this.int_1].ResetDate);
      }
      // ISSUE: reference to a compiler-generated field
      if (this.counterResetEventHandler_1 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.counterResetEventHandler_1(this.int_1, DateTime.Now, this.Counters[this.int_1]);
      }
    }
    if (!(control2.Name == this.btn_resettotalall.Name))
      return;
    for (int index = 0; index <= this.Counters.Count - 1; ++index)
    {
      this.Counters[index].PreviousCount = 0.0;
      this.Counters[index].TotalCount = 0.0;
      this.Counters[index].ActualCount = 0.0;
      this.Counters[index].ResetDate = DateTime.Now;
      this.grid_counter.Rows[index].Cells[3].Value = (object) this.Counters[index].PreviousCount;
      this.grid_counter.Rows[index].Cells[4].Value = (object) this.Counters[index].TotalCount;
      this.grid_counter.Rows[index].Cells[1].Value = (object) this.Counters[index].ActualCount;
      this.grid_counter.Rows[index].Cells[5].Value = (object) buConversion.DateToString(this.Counters[index].ResetDate);
    }
    // ISSUE: reference to a compiler-generated field
    if (this.counterResetEventHandler_1 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.counterResetAllEventHandler_0(DateTime.Now, this.Counters);
  }

  internal void method_2(object sender, DataGridViewCellValidatingEventArgs e)
  {
    try
    {
      buGrid buGrid = new buGrid();
      if (!(((Control) sender).Name == this.grid_counter.Name) || e.ColumnIndex != 2)
        return;
      if (buNumeric.IsNumeric(e.FormattedValue.ToString()))
      {
        if (e.FormattedValue.ToString().IndexOf(",") >= 0)
          this.double_0 = double.Parse(e.FormattedValue.ToString().Replace(",", "."));
        else
          this.double_0 = double.Parse(e.FormattedValue.ToString());
      }
      else
      {
        string[] strArray = new string[6]
        {
          AppLanguage.SystemMessages[11],
          " - [ ",
          null,
          null,
          null,
          null
        };
        int num = e.RowIndex;
        strArray[2] = num.ToString();
        strArray[3] = " , ";
        num = e.ColumnIndex;
        strArray[4] = num.ToString();
        strArray[5] = " ]";
        buString.MessageBoxError(string.Concat(strArray));
        e.Cancel = true;
      }
    }
    catch (Exception ex)
    {
      buString.MessageBoxError(AppLanguage.Messages[11]);
    }
  }

  internal void method_3(object sender, DataGridViewCellEventArgs e)
  {
    try
    {
      buGrid buGrid = new buGrid();
      if (!(((Control) sender).Name == this.grid_counter.Name) || e.ColumnIndex != 2)
        return;
      this.grid_counter.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = (object) this.double_0;
    }
    catch (Exception ex)
    {
      buString.MessageBoxError(AppLanguage.Messages[3]);
    }
  }

  internal void method_4(object sender, DataGridViewCellEventArgs e)
  {
    buGrid buGrid = new buGrid();
    if (!(((Control) sender).Name == this.grid_counter.Name))
      return;
    this.int_1 = e.RowIndex;
    this.int_0 = e.ColumnIndex;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
