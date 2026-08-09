using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buCore;
using ns27;

namespace buControls.UserControls;

public class buLayerGrid : UserControl
{
	public List<LayerBase> Layers = new List<LayerBase>();

	public int SelectedLayer = 0;

	public bool ShowNoteColumb = false;

	private DataColumn dataColumn_0;

	private DataTable dataTable_0 = new DataTable();

	private bool bool_0 = false;

	[CompilerGenerated]
	private ValueIntChangedEventHandler valueIntChangedEventHandler_0;

	[CompilerGenerated]
	private ValueBoolChangedEventHandler valueBoolChangedEventHandler_0;

	private IContainer icontainer_0 = null;

	internal DataGridView dataGridView_0;

	public event ValueIntChangedEventHandler LayerChanged
	{
		[CompilerGenerated]
		add
		{
			ValueIntChangedEventHandler valueIntChangedEventHandler = valueIntChangedEventHandler_0;
			ValueIntChangedEventHandler valueIntChangedEventHandler2;
			do
			{
				valueIntChangedEventHandler2 = valueIntChangedEventHandler;
				ValueIntChangedEventHandler value2 = (ValueIntChangedEventHandler)Delegate.Combine(valueIntChangedEventHandler2, value);
				valueIntChangedEventHandler = Interlocked.CompareExchange(ref valueIntChangedEventHandler_0, value2, valueIntChangedEventHandler2);
			}
			while ((object)valueIntChangedEventHandler != valueIntChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ValueIntChangedEventHandler valueIntChangedEventHandler = valueIntChangedEventHandler_0;
			ValueIntChangedEventHandler valueIntChangedEventHandler2;
			do
			{
				valueIntChangedEventHandler2 = valueIntChangedEventHandler;
				ValueIntChangedEventHandler value2 = (ValueIntChangedEventHandler)Delegate.Remove(valueIntChangedEventHandler2, value);
				valueIntChangedEventHandler = Interlocked.CompareExchange(ref valueIntChangedEventHandler_0, value2, valueIntChangedEventHandler2);
			}
			while ((object)valueIntChangedEventHandler != valueIntChangedEventHandler2);
		}
	}

	public event ValueBoolChangedEventHandler EnableChanged
	{
		[CompilerGenerated]
		add
		{
			ValueBoolChangedEventHandler valueBoolChangedEventHandler = valueBoolChangedEventHandler_0;
			ValueBoolChangedEventHandler valueBoolChangedEventHandler2;
			do
			{
				valueBoolChangedEventHandler2 = valueBoolChangedEventHandler;
				ValueBoolChangedEventHandler value2 = (ValueBoolChangedEventHandler)Delegate.Combine(valueBoolChangedEventHandler2, value);
				valueBoolChangedEventHandler = Interlocked.CompareExchange(ref valueBoolChangedEventHandler_0, value2, valueBoolChangedEventHandler2);
			}
			while ((object)valueBoolChangedEventHandler != valueBoolChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ValueBoolChangedEventHandler valueBoolChangedEventHandler = valueBoolChangedEventHandler_0;
			ValueBoolChangedEventHandler valueBoolChangedEventHandler2;
			do
			{
				valueBoolChangedEventHandler2 = valueBoolChangedEventHandler;
				ValueBoolChangedEventHandler value2 = (ValueBoolChangedEventHandler)Delegate.Remove(valueBoolChangedEventHandler2, value);
				valueBoolChangedEventHandler = Interlocked.CompareExchange(ref valueBoolChangedEventHandler_0, value2, valueBoolChangedEventHandler2);
			}
			while ((object)valueBoolChangedEventHandler != valueBoolChangedEventHandler2);
		}
	}

	public buLayerGrid()
	{
		Class76.smethod_819(this);
	}

	public void Init()
	{
		dataTable_0 = new DataTable();
		dataColumn_0 = new DataColumn("Name", Type.GetType("System.String"));
		dataTable_0.Columns.Add(dataColumn_0);
		dataColumn_0 = new DataColumn("Enable", Type.GetType("System.Boolean"));
		dataTable_0.Columns.Add(dataColumn_0);
		dataColumn_0 = new DataColumn("Color", Type.GetType("System.String"));
		dataTable_0.Columns.Add(dataColumn_0);
		dataColumn_0 = new DataColumn("Info", Type.GetType("System.String"));
		dataTable_0.Columns.Add(dataColumn_0);
		dataGridView_0.DataSource = dataTable_0;
		dataGridView_0.RowHeadersVisible = false;
		dataGridView_0.ColumnHeadersVisible = false;
		dataGridView_0.AllowUserToAddRows = false;
		dataGridView_0.AllowUserToResizeColumns = false;
		int num = 145;
		if (!ShowNoteColumb)
		{
			num -= 40;
			dataGridView_0.Columns[3].Visible = false;
		}
		dataGridView_0.Columns[0].Width = dataGridView_0.Width - num - 1;
		dataGridView_0.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridView_0.Columns[1].Width = 35;
		dataGridView_0.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridView_0.Columns[2].Width = 70;
		dataGridView_0.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridView_0.Columns[3].Width = 40;
		dataGridView_0.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
	}

	public void LayerUpdate(bool Fill, List<LayerBase> layers)
	{
		bool_0 = true;
		if (!Fill)
		{
			for (int i = 0; i <= layers.Count - 1; i++)
			{
				dataGridView_0.Rows[i].Cells[0].Value = layers[i].ShownName;
				dataGridView_0.Rows[i].Cells[1].Value = layers[i].Enable;
				if (!layers[i].LayerColor.IsKnownColor)
				{
					dataGridView_0.Rows[i].Cells[2].Value = layers[i].LayerColor.ToString();
				}
				else
				{
					dataGridView_0.Rows[i].Cells[2].Value = layers[i].LayerColor.ToKnownColor();
				}
				dataGridView_0.Rows[i].Cells[2].Style.BackColor = layers[i].LayerColor;
				dataGridView_0.Rows[i].Cells[2].Style.ForeColor = buImage.InvertColorNoGray(layers[i].LayerColor);
				dataGridView_0.Rows[i].Cells[3].Value = layers[i].Note;
			}
		}
		else
		{
			dataTable_0.Rows.Clear();
			for (int j = 0; j <= layers.Count - 1; j++)
			{
				DataRowCollection rows = dataTable_0.Rows;
				ref DataTable reference = ref dataTable_0;
				LayerBase layerBase_ = layers[j];
				rows.Add(Class76.smethod_728(layerBase_, this, ref reference));
				dataGridView_0.Rows[dataGridView_0.Rows.Count - 1].Cells[2].Style.BackColor = layers[j].LayerColor;
				dataGridView_0.Rows[dataGridView_0.Rows.Count - 1].Cells[2].Style.ForeColor = buImage.InvertColorNoGray(layers[j].LayerColor);
			}
		}
		bool_0 = false;
	}

	public void SetEnableValue(bool Enable, int LayerIndex)
	{
		bool_0 = true;
		if ((LayerIndex >= 0) & (LayerIndex <= dataGridView_0.Rows.Count - 1))
		{
			dataGridView_0.Rows[LayerIndex].Cells[1].Value = Enable;
		}
		bool_0 = false;
	}

	public void SetSelectedValue(int LayerIndex)
	{
		bool_0 = true;
		if ((LayerIndex >= 0) & (LayerIndex <= dataGridView_0.Rows.Count - 1))
		{
			dataGridView_0.Rows[LayerIndex].Cells[0].Selected = true;
		}
		bool_0 = false;
	}

	internal void method_0(object sender, DataGridViewCellEventArgs e)
	{
		if (((e.ColumnIndex == 1) & !bool_0) && valueBoolChangedEventHandler_0 != null)
		{
			bool value = Convert.ToBoolean(dataGridView_0.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
			valueBoolChangedEventHandler_0(value);
		}
	}

	internal void method_1(object sender, DataGridViewCellEventArgs e)
	{
		SelectedLayer = e.RowIndex;
		if (valueIntChangedEventHandler_0 != null)
		{
			valueIntChangedEventHandler_0(SelectedLayer);
		}
		for (int i = 0; i <= dataGridView_0.Rows.Count - 1; i++)
		{
			dataGridView_0.Rows[i].Cells[0].Selected = false;
		}
		dataGridView_0.Rows[e.RowIndex].Cells[0].Selected = true;
	}

	internal void method_2(object sender, DataGridViewCellMouseEventArgs e)
	{
		if (((e.ColumnIndex == 1) & !bool_0) && valueBoolChangedEventHandler_0 != null)
		{
			dataGridView_0.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = !Convert.ToBoolean(dataGridView_0.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
		}
	}

	internal void method_3(object sender, DataGridViewCellValidatingEventArgs e)
	{
	}

	internal void method_4(object sender, DataGridViewCellEventArgs e)
	{
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
