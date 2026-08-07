// Decompiled with JetBrains decompiler
// Type: buControls.Controls.buGrid
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

#nullable disable
namespace buControls.Controls;

public class buGrid : DataGridView
{
  public DataTable Dt = new DataTable();
  public DataColumn Col = (DataColumn) null;
  public List<ColumbProperties> customColumbs = new List<ColumbProperties>();

  public void Creat()
  {
    this.Dt = new DataTable();
    for (int index1 = 0; index1 <= this.customColumbs.Count - 1; ++index1)
    {
      for (int index2 = 0; index2 <= this.Dt.Columns.Count - 1; ++index2)
      {
        if (this.Dt.Columns[index2].ColumnName == this.customColumbs[index1].Name)
          this.customColumbs[index1].Name += index2.ToString();
      }
      this.Col = !(this.customColumbs[index1].Variable == (System.Type) null) ? new DataColumn(this.customColumbs[index1].Name, this.customColumbs[index1].Variable) : new DataColumn(this.customColumbs[index1].Name, System.Type.GetType("System.String"));
      this.Dt.Columns.Add(this.Col);
    }
    this.DataSource = (object) this.Dt;
    for (int index = 0; index <= this.customColumbs.Count - 1; ++index)
    {
      if (index <= this.customColumbs.Count - 1)
      {
        this.Columns[index].Width = this.customColumbs[index].Width;
        this.Columns[index].ReadOnly = this.customColumbs[index].ReadOnly;
        this.Columns[index].SortMode = this.customColumbs[index].SortType;
        this.Columns[index].Visible = this.customColumbs[index].Visible;
      }
    }
  }

  public void UnSelectColums(int ColumbIndex)
  {
    if (this.Rows.Count <= 0 || !(ColumbIndex >= 0 & ColumbIndex <= this.ColumnCount - 1))
      return;
    for (int index = 0; index <= this.Rows.Count - 1; ++index)
      this.Rows[index].Cells[ColumbIndex].Selected = false;
  }

  public void SelectCell(int RowIndex, int ColumbIndex)
  {
    if (!(RowIndex >= 0 & RowIndex <= this.Rows.Count - 1) || !(ColumbIndex >= 0 & ColumbIndex <= this.ColumnCount - 1))
      return;
    this.Rows[RowIndex].Cells[ColumbIndex].Selected = true;
  }

  public DataRow AddNewRow(object Val1)
  {
    DataRow row = this.Dt.NewRow();
    if (this.ColumnCount >= 1)
      row[0] = Val1;
    this.Dt.Rows.Add(row);
    return row;
  }

  public DataRow AddNewRow(object Val1, object Val2)
  {
    DataRow row = this.Dt.NewRow();
    if (this.ColumnCount >= 2)
    {
      row[0] = Val1;
      row[1] = Val2;
    }
    this.Dt.Rows.Add(row);
    return row;
  }

  public DataRow AddNewRow(object Val1, object Val2, object Val3)
  {
    DataRow row = this.Dt.NewRow();
    if (this.ColumnCount >= 3)
    {
      row[0] = Val1;
      row[1] = Val2;
      row[2] = Val3;
    }
    this.Dt.Rows.Add(row);
    return row;
  }

  public DataRow AddNewRow(object Val1, object Val2, object Val3, object Val4)
  {
    DataRow row = this.Dt.NewRow();
    if (this.ColumnCount >= 4)
    {
      row[0] = Val1;
      row[1] = Val2;
      row[2] = Val3;
      row[3] = Val4;
    }
    this.Dt.Rows.Add(row);
    return row;
  }

  public DataRow AddNewRow(object Val1, object Val2, object Val3, object Val4, object Val5)
  {
    DataRow row = this.Dt.NewRow();
    if (this.ColumnCount >= 5)
    {
      row[0] = Val1;
      row[1] = Val2;
      row[2] = Val3;
      row[3] = Val4;
      row[4] = Val5;
    }
    this.Dt.Rows.Add(row);
    return row;
  }

  public DataRow AddNewRow(
    object Val1,
    object Val2,
    object Val3,
    object Val4,
    object Val5,
    object Val6)
  {
    DataRow row = this.Dt.NewRow();
    if (this.ColumnCount >= 6)
    {
      row[0] = Val1;
      row[1] = Val2;
      row[2] = Val3;
      row[3] = Val4;
      row[4] = Val5;
      row[5] = Val6;
    }
    this.Dt.Rows.Add(row);
    return row;
  }

  public DataRow AddNewRow(
    object Val1,
    object Val2,
    object Val3,
    object Val4,
    object Val5,
    object Val6,
    object Val7)
  {
    DataRow row = this.Dt.NewRow();
    if (this.ColumnCount >= 7)
    {
      row[0] = Val1;
      row[1] = Val2;
      row[2] = Val3;
      row[3] = Val4;
      row[4] = Val5;
      row[5] = Val6;
      row[6] = Val7;
    }
    this.Dt.Rows.Add(row);
    return row;
  }

  public DataRow AddNewRow(
    object Val1,
    object Val2,
    object Val3,
    object Val4,
    object Val5,
    object Val6,
    object Val7,
    object Val8)
  {
    DataRow row = this.Dt.NewRow();
    if (this.ColumnCount >= 8)
    {
      row[0] = Val1;
      row[1] = Val2;
      row[2] = Val3;
      row[3] = Val4;
      row[4] = Val5;
      row[5] = Val6;
      row[6] = Val7;
      row[7] = Val8;
    }
    this.Dt.Rows.Add(row);
    return row;
  }

  public DataRow AddNewRow(
    object Val1,
    object Val2,
    object Val3,
    object Val4,
    object Val5,
    object Val6,
    object Val7,
    object Val8,
    object Val9)
  {
    DataRow row = this.Dt.NewRow();
    if (this.ColumnCount >= 9)
    {
      row[0] = Val1;
      row[1] = Val2;
      row[2] = Val3;
      row[3] = Val4;
      row[4] = Val5;
      row[5] = Val6;
      row[6] = Val7;
      row[7] = Val8;
      row[8] = Val9;
    }
    this.Dt.Rows.Add(row);
    return row;
  }

  public DataRow AddNewRow(
    object Val1,
    object Val2,
    object Val3,
    object Val4,
    object Val5,
    object Val6,
    object Val7,
    object Val8,
    object Val9,
    object Val10)
  {
    DataRow row = this.Dt.NewRow();
    if (this.ColumnCount >= 10)
    {
      row[0] = Val1;
      row[1] = Val2;
      row[2] = Val3;
      row[3] = Val4;
      row[4] = Val5;
      row[5] = Val6;
      row[6] = Val7;
      row[7] = Val8;
      row[8] = Val9;
      row[9] = Val10;
    }
    this.Dt.Rows.Add(row);
    return row;
  }

  public DataRow AddNewRow(
    object Val1,
    object Val2,
    object Val3,
    object Val4,
    object Val5,
    object Val6,
    object Val7,
    object Val8,
    object Val9,
    object Val10,
    object Val11)
  {
    DataRow row = this.Dt.NewRow();
    if (this.ColumnCount >= 11)
    {
      row[0] = Val1;
      row[1] = Val2;
      row[2] = Val3;
      row[3] = Val4;
      row[4] = Val5;
      row[5] = Val6;
      row[6] = Val7;
      row[7] = Val8;
      row[8] = Val9;
      row[9] = Val10;
      row[10] = Val11;
    }
    this.Dt.Rows.Add(row);
    return row;
  }

  public DataRow AddNewRow(
    object Val1,
    object Val2,
    object Val3,
    object Val4,
    object Val5,
    object Val6,
    object Val7,
    object Val8,
    object Val9,
    object Val10,
    object Val11,
    object Val12)
  {
    DataRow row = this.Dt.NewRow();
    if (this.ColumnCount >= 12)
    {
      row[0] = Val1;
      row[1] = Val2;
      row[2] = Val3;
      row[3] = Val4;
      row[4] = Val5;
      row[5] = Val6;
      row[6] = Val7;
      row[7] = Val8;
      row[8] = Val9;
      row[9] = Val10;
      row[10] = Val11;
      row[11] = Val12;
    }
    this.Dt.Rows.Add(row);
    return row;
  }

  public DataRow AddNewRow(
    object Val1,
    object Val2,
    object Val3,
    object Val4,
    object Val5,
    object Val6,
    object Val7,
    object Val8,
    object Val9,
    object Val10,
    object Val11,
    object Val12,
    object Val13)
  {
    DataRow row = this.Dt.NewRow();
    if (this.ColumnCount >= 13)
    {
      row[0] = Val1;
      row[1] = Val2;
      row[2] = Val3;
      row[3] = Val4;
      row[4] = Val5;
      row[5] = Val6;
      row[6] = Val7;
      row[7] = Val8;
      row[8] = Val9;
      row[9] = Val10;
      row[10] = Val11;
      row[11] = Val12;
      row[12] = Val13;
    }
    this.Dt.Rows.Add(row);
    return row;
  }

  public DataRow AddNewRow(
    object Val1,
    object Val2,
    object Val3,
    object Val4,
    object Val5,
    object Val6,
    object Val7,
    object Val8,
    object Val9,
    object Val10,
    object Val11,
    object Val12,
    object Val13,
    object Val14)
  {
    DataRow row = this.Dt.NewRow();
    if (this.ColumnCount >= 14)
    {
      row[0] = Val1;
      row[1] = Val2;
      row[2] = Val3;
      row[3] = Val4;
      row[4] = Val5;
      row[5] = Val6;
      row[6] = Val7;
      row[7] = Val8;
      row[8] = Val9;
      row[9] = Val10;
      row[10] = Val11;
      row[11] = Val12;
      row[12] = Val13;
      row[13] = Val14;
      row[16 /*0x10*/] = Val14;
    }
    this.Dt.Rows.Add(row);
    return row;
  }

  public DataRow AddNewRow(
    object Val1,
    object Val2,
    object Val3,
    object Val4,
    object Val5,
    object Val6,
    object Val7,
    object Val8,
    object Val9,
    object Val10,
    object Val11,
    object Val12,
    object Val13,
    object Val14,
    object Val15)
  {
    DataRow row = this.Dt.NewRow();
    if (this.ColumnCount >= 15)
    {
      row[0] = Val1;
      row[1] = Val2;
      row[2] = Val3;
      row[3] = Val4;
      row[4] = Val5;
      row[5] = Val6;
      row[6] = Val7;
      row[7] = Val8;
      row[8] = Val9;
      row[9] = Val10;
      row[10] = Val11;
      row[11] = Val12;
      row[12] = Val13;
      row[13] = Val14;
      row[14] = Val15;
    }
    this.Dt.Rows.Add(row);
    return row;
  }

  public DataRow AddNewRow(
    object Val1,
    object Val2,
    object Val3,
    object Val4,
    object Val5,
    object Val6,
    object Val7,
    object Val8,
    object Val9,
    object Val10,
    object Val11,
    object Val12,
    object Val13,
    object Val14,
    object Val15,
    object Val16)
  {
    DataRow row = this.Dt.NewRow();
    if (this.ColumnCount >= 16 /*0x10*/)
    {
      row[0] = Val1;
      row[1] = Val2;
      row[2] = Val3;
      row[3] = Val4;
      row[4] = Val5;
      row[5] = Val6;
      row[6] = Val7;
      row[7] = Val8;
      row[8] = Val9;
      row[9] = Val10;
      row[10] = Val11;
      row[11] = Val12;
      row[12] = Val13;
      row[13] = Val14;
      row[14] = Val15;
      row[15] = Val16;
    }
    this.Dt.Rows.Add(row);
    return row;
  }
}
