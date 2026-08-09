using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace buControls.Controls;

public class buGrid : DataGridView
{
	public DataTable Dt = new DataTable();

	public DataColumn Col = null;

	public List<ColumbProperties> customColumbs = new List<ColumbProperties>();

	public void Creat()
	{
		Dt = new DataTable();
		for (int i = 0; i <= customColumbs.Count - 1; i++)
		{
			for (int j = 0; j <= Dt.Columns.Count - 1; j++)
			{
				if (Dt.Columns[j].ColumnName == customColumbs[i].Name)
				{
					customColumbs[i].Name = customColumbs[i].Name + j;
				}
			}
			if (!(customColumbs[i].Variable == null))
			{
				Col = new DataColumn(customColumbs[i].Name, customColumbs[i].Variable);
			}
			else
			{
				Col = new DataColumn(customColumbs[i].Name, Type.GetType("System.String"));
			}
			Dt.Columns.Add(Col);
		}
		base.DataSource = Dt;
		for (int k = 0; k <= customColumbs.Count - 1; k++)
		{
			if (k <= customColumbs.Count - 1)
			{
				base.Columns[k].Width = customColumbs[k].Width;
				base.Columns[k].ReadOnly = customColumbs[k].ReadOnly;
				base.Columns[k].SortMode = customColumbs[k].SortType;
				base.Columns[k].Visible = customColumbs[k].Visible;
			}
		}
	}

	public void UnSelectColums(int ColumbIndex)
	{
		if (base.Rows.Count > 0 && ((ColumbIndex >= 0) & (ColumbIndex <= base.ColumnCount - 1)))
		{
			for (int i = 0; i <= base.Rows.Count - 1; i++)
			{
				base.Rows[i].Cells[ColumbIndex].Selected = false;
			}
		}
	}

	public void SelectCell(int RowIndex, int ColumbIndex)
	{
		if (((RowIndex >= 0) & (RowIndex <= base.Rows.Count - 1)) && ((ColumbIndex >= 0) & (ColumbIndex <= base.ColumnCount - 1)))
		{
			base.Rows[RowIndex].Cells[ColumbIndex].Selected = true;
		}
	}

	public DataRow AddNewRow(object Val1)
	{
		DataRow dataRow = Dt.NewRow();
		if (base.ColumnCount >= 1)
		{
			dataRow[0] = Val1;
		}
		Dt.Rows.Add(dataRow);
		return dataRow;
	}

	public DataRow AddNewRow(object Val1, object Val2)
	{
		DataRow dataRow = Dt.NewRow();
		if (base.ColumnCount >= 2)
		{
			dataRow[0] = Val1;
			dataRow[1] = Val2;
		}
		Dt.Rows.Add(dataRow);
		return dataRow;
	}

	public DataRow AddNewRow(object Val1, object Val2, object Val3)
	{
		DataRow dataRow = Dt.NewRow();
		if (base.ColumnCount >= 3)
		{
			dataRow[0] = Val1;
			dataRow[1] = Val2;
			dataRow[2] = Val3;
		}
		Dt.Rows.Add(dataRow);
		return dataRow;
	}

	public DataRow AddNewRow(object Val1, object Val2, object Val3, object Val4)
	{
		DataRow dataRow = Dt.NewRow();
		if (base.ColumnCount >= 4)
		{
			dataRow[0] = Val1;
			dataRow[1] = Val2;
			dataRow[2] = Val3;
			dataRow[3] = Val4;
		}
		Dt.Rows.Add(dataRow);
		return dataRow;
	}

	public DataRow AddNewRow(object Val1, object Val2, object Val3, object Val4, object Val5)
	{
		DataRow dataRow = Dt.NewRow();
		if (base.ColumnCount >= 5)
		{
			dataRow[0] = Val1;
			dataRow[1] = Val2;
			dataRow[2] = Val3;
			dataRow[3] = Val4;
			dataRow[4] = Val5;
		}
		Dt.Rows.Add(dataRow);
		return dataRow;
	}

	public DataRow AddNewRow(object Val1, object Val2, object Val3, object Val4, object Val5, object Val6)
	{
		DataRow dataRow = Dt.NewRow();
		if (base.ColumnCount >= 6)
		{
			dataRow[0] = Val1;
			dataRow[1] = Val2;
			dataRow[2] = Val3;
			dataRow[3] = Val4;
			dataRow[4] = Val5;
			dataRow[5] = Val6;
		}
		Dt.Rows.Add(dataRow);
		return dataRow;
	}

	public DataRow AddNewRow(object Val1, object Val2, object Val3, object Val4, object Val5, object Val6, object Val7)
	{
		DataRow dataRow = Dt.NewRow();
		if (base.ColumnCount >= 7)
		{
			dataRow[0] = Val1;
			dataRow[1] = Val2;
			dataRow[2] = Val3;
			dataRow[3] = Val4;
			dataRow[4] = Val5;
			dataRow[5] = Val6;
			dataRow[6] = Val7;
		}
		Dt.Rows.Add(dataRow);
		return dataRow;
	}

	public DataRow AddNewRow(object Val1, object Val2, object Val3, object Val4, object Val5, object Val6, object Val7, object Val8)
	{
		DataRow dataRow = Dt.NewRow();
		if (base.ColumnCount >= 8)
		{
			dataRow[0] = Val1;
			dataRow[1] = Val2;
			dataRow[2] = Val3;
			dataRow[3] = Val4;
			dataRow[4] = Val5;
			dataRow[5] = Val6;
			dataRow[6] = Val7;
			dataRow[7] = Val8;
		}
		Dt.Rows.Add(dataRow);
		return dataRow;
	}

	public DataRow AddNewRow(object Val1, object Val2, object Val3, object Val4, object Val5, object Val6, object Val7, object Val8, object Val9)
	{
		DataRow dataRow = Dt.NewRow();
		if (base.ColumnCount >= 9)
		{
			dataRow[0] = Val1;
			dataRow[1] = Val2;
			dataRow[2] = Val3;
			dataRow[3] = Val4;
			dataRow[4] = Val5;
			dataRow[5] = Val6;
			dataRow[6] = Val7;
			dataRow[7] = Val8;
			dataRow[8] = Val9;
		}
		Dt.Rows.Add(dataRow);
		return dataRow;
	}

	public DataRow AddNewRow(object Val1, object Val2, object Val3, object Val4, object Val5, object Val6, object Val7, object Val8, object Val9, object Val10)
	{
		DataRow dataRow = Dt.NewRow();
		if (base.ColumnCount >= 10)
		{
			dataRow[0] = Val1;
			dataRow[1] = Val2;
			dataRow[2] = Val3;
			dataRow[3] = Val4;
			dataRow[4] = Val5;
			dataRow[5] = Val6;
			dataRow[6] = Val7;
			dataRow[7] = Val8;
			dataRow[8] = Val9;
			dataRow[9] = Val10;
		}
		Dt.Rows.Add(dataRow);
		return dataRow;
	}

	public DataRow AddNewRow(object Val1, object Val2, object Val3, object Val4, object Val5, object Val6, object Val7, object Val8, object Val9, object Val10, object Val11)
	{
		DataRow dataRow = Dt.NewRow();
		if (base.ColumnCount >= 11)
		{
			dataRow[0] = Val1;
			dataRow[1] = Val2;
			dataRow[2] = Val3;
			dataRow[3] = Val4;
			dataRow[4] = Val5;
			dataRow[5] = Val6;
			dataRow[6] = Val7;
			dataRow[7] = Val8;
			dataRow[8] = Val9;
			dataRow[9] = Val10;
			dataRow[10] = Val11;
		}
		Dt.Rows.Add(dataRow);
		return dataRow;
	}

	public DataRow AddNewRow(object Val1, object Val2, object Val3, object Val4, object Val5, object Val6, object Val7, object Val8, object Val9, object Val10, object Val11, object Val12)
	{
		DataRow dataRow = Dt.NewRow();
		if (base.ColumnCount >= 12)
		{
			dataRow[0] = Val1;
			dataRow[1] = Val2;
			dataRow[2] = Val3;
			dataRow[3] = Val4;
			dataRow[4] = Val5;
			dataRow[5] = Val6;
			dataRow[6] = Val7;
			dataRow[7] = Val8;
			dataRow[8] = Val9;
			dataRow[9] = Val10;
			dataRow[10] = Val11;
			dataRow[11] = Val12;
		}
		Dt.Rows.Add(dataRow);
		return dataRow;
	}

	public DataRow AddNewRow(object Val1, object Val2, object Val3, object Val4, object Val5, object Val6, object Val7, object Val8, object Val9, object Val10, object Val11, object Val12, object Val13)
	{
		DataRow dataRow = Dt.NewRow();
		if (base.ColumnCount >= 13)
		{
			dataRow[0] = Val1;
			dataRow[1] = Val2;
			dataRow[2] = Val3;
			dataRow[3] = Val4;
			dataRow[4] = Val5;
			dataRow[5] = Val6;
			dataRow[6] = Val7;
			dataRow[7] = Val8;
			dataRow[8] = Val9;
			dataRow[9] = Val10;
			dataRow[10] = Val11;
			dataRow[11] = Val12;
			dataRow[12] = Val13;
		}
		Dt.Rows.Add(dataRow);
		return dataRow;
	}

	public DataRow AddNewRow(object Val1, object Val2, object Val3, object Val4, object Val5, object Val6, object Val7, object Val8, object Val9, object Val10, object Val11, object Val12, object Val13, object Val14)
	{
		DataRow dataRow = Dt.NewRow();
		if (base.ColumnCount >= 14)
		{
			dataRow[0] = Val1;
			dataRow[1] = Val2;
			dataRow[2] = Val3;
			dataRow[3] = Val4;
			dataRow[4] = Val5;
			dataRow[5] = Val6;
			dataRow[6] = Val7;
			dataRow[7] = Val8;
			dataRow[8] = Val9;
			dataRow[9] = Val10;
			dataRow[10] = Val11;
			dataRow[11] = Val12;
			dataRow[12] = Val13;
			dataRow[13] = Val14;
			dataRow[16] = Val14;
		}
		Dt.Rows.Add(dataRow);
		return dataRow;
	}

	public DataRow AddNewRow(object Val1, object Val2, object Val3, object Val4, object Val5, object Val6, object Val7, object Val8, object Val9, object Val10, object Val11, object Val12, object Val13, object Val14, object Val15)
	{
		DataRow dataRow = Dt.NewRow();
		if (base.ColumnCount >= 15)
		{
			dataRow[0] = Val1;
			dataRow[1] = Val2;
			dataRow[2] = Val3;
			dataRow[3] = Val4;
			dataRow[4] = Val5;
			dataRow[5] = Val6;
			dataRow[6] = Val7;
			dataRow[7] = Val8;
			dataRow[8] = Val9;
			dataRow[9] = Val10;
			dataRow[10] = Val11;
			dataRow[11] = Val12;
			dataRow[12] = Val13;
			dataRow[13] = Val14;
			dataRow[14] = Val15;
		}
		Dt.Rows.Add(dataRow);
		return dataRow;
	}

	public DataRow AddNewRow(object Val1, object Val2, object Val3, object Val4, object Val5, object Val6, object Val7, object Val8, object Val9, object Val10, object Val11, object Val12, object Val13, object Val14, object Val15, object Val16)
	{
		DataRow dataRow = Dt.NewRow();
		if (base.ColumnCount >= 16)
		{
			dataRow[0] = Val1;
			dataRow[1] = Val2;
			dataRow[2] = Val3;
			dataRow[3] = Val4;
			dataRow[4] = Val5;
			dataRow[5] = Val6;
			dataRow[6] = Val7;
			dataRow[7] = Val8;
			dataRow[8] = Val9;
			dataRow[9] = Val10;
			dataRow[10] = Val11;
			dataRow[11] = Val12;
			dataRow[12] = Val13;
			dataRow[13] = Val14;
			dataRow[14] = Val15;
			dataRow[15] = Val16;
		}
		Dt.Rows.Add(dataRow);
		return dataRow;
	}
}
