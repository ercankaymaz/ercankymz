// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.F_LayerList
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms;

public class F_LayerList : Form
{
  internal Label \u0013;
  internal Label \u0014;
  internal Label \u0015;
  internal ImageList \u0001;
  public Button btn_cancel;
  public Button btn_ok;
  internal Label \u0016;
  internal Label \u0017;
  internal Label \u0018;

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_Copy) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_Copy) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_Copy) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_Copy) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void LoadLanguage()
  {
    string callMethod = "NestSheetPart LoadLanguage";
    try
    {
      if (F_Copy.Captions.Count < 33)
        return;
      this.Text = F_Copy.Captions[0];
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
    if (obj0.GetType() == typeof (ToolStripMenuItem))
    {
      string name1 = ((ToolStripItem) obj0).Name;
    }
    if (!(control.Name == ((F_Copy) this).\u0001.Name))
      return;
    ((F_Copy) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_Copy) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_Copy) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    if (((F_Copy) this).\u0001.SelectedItems.Count <= 0)
      return;
    ((F_Copy) this).\u0001 = ((F_Copy) this).\u0001.SelectedIndex;
    if (((F_Copy) this).\u0001 < 0)
      return;
    List<string> Properties = new List<string>();
    buCall.\u0001.EntityToProperties(((F_Copy) this).Entities[((F_Copy) this).\u0001], ref Properties);
    ((F_Copy) this).DGV_entitiesprops.Rows.Clear();
    ((F_Copy) this).DGV_entitiesprops.Columns.Clear();
    DataGridViewColumn dataGridViewColumn1 = new DataGridViewColumn();
    dataGridViewColumn1.Width = Convert.ToInt32((double) ((F_Copy) this).DGV_entitiesprops.Width * 0.35);
    dataGridViewColumn1.HeaderText = "Name";
    dataGridViewColumn1.Name = "Name";
    dataGridViewColumn1.ReadOnly = true;
    dataGridViewColumn1.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
    dataGridViewColumn1.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
    ((F_Copy) this).DGV_entitiesprops.Columns.Add(dataGridViewColumn1);
    DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
    dataGridViewColumn2.Width = Convert.ToInt32((double) ((F_Copy) this).DGV_entitiesprops.Width - (double) dataGridViewColumn1.Width) - 25;
    dataGridViewColumn2.HeaderText = "Enable";
    dataGridViewColumn2.Name = "Enable";
    dataGridViewColumn2.ReadOnly = true;
    dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
    dataGridViewColumn2.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
    ((F_Copy) this).DGV_entitiesprops.Columns.Add(dataGridViewColumn2);
    for (int index = 0; index <= Properties.Count - 1; ++index)
    {
      string[] strArray = Properties[index].Split('=');
      if (strArray != null && strArray.Length == 2)
        ((F_Copy) this).DGV_entitiesprops.Rows.Add((object) strArray[0], (object) strArray[1]);
    }
    for (int index = 0; index <= ((F_Copy) this).viewportPort.Entities.Count - 1; ++index)
      ((F_Copy) this).viewportPort.Entities[index].Selected = false;
    ((F_Copy) this).viewportPort.Entities[((F_Copy) this).\u0001].Selected = true;
    ((F_Copy) this).viewportPort.ZoomFitSelectedLeaves();
    ((F_Copy) this).viewportPort.Invalidate();
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_Copy) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_Copy) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_LayerList() => F_Copy.Captions = new List<string>();
}
