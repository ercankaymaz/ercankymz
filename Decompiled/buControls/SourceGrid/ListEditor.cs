using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using DevAge.Windows.Forms;
using SourceGrid.Cells;
using SourceGrid.Cells.Editors;
using ns27;

namespace SourceGrid;

[ToolboxItem(false)]
public class ListEditor : UserControl
{
	internal Grid grid_0;

	internal System.Windows.Forms.Button button_0;

	internal System.Windows.Forms.Button button_1;

	internal System.Windows.Forms.Button button_2;

	internal System.Windows.Forms.Button button_3;

	internal System.Windows.Forms.Button button_4;

	private Container container_0 = null;

	private ArrayList arrayList_0;

	internal Type type_0;

	internal EditorBase[] editorBase_0;

	internal PropertyInfo[] propertyInfo_0;

	[CompilerGenerated]
	private EventHandler eventHandler_0;

	public ArrayList List
	{
		get
		{
			return arrayList_0;
		}
		set
		{
			arrayList_0 = value;
		}
	}

	public Type ItemType
	{
		get
		{
			return type_0;
		}
		set
		{
			type_0 = value;
			Class76.smethod_285(this);
		}
	}

	[Browsable(false)]
	public EditorBase[] Editors
	{
		get
		{
			return editorBase_0;
		}
		set
		{
			editorBase_0 = value;
		}
	}

	[Browsable(false)]
	public PropertyInfo[] Properties
	{
		get
		{
			return propertyInfo_0;
		}
		set
		{
			propertyInfo_0 = value;
		}
	}

	public bool EnableAdd
	{
		get
		{
			return button_3.Visible;
		}
		set
		{
			button_3.Visible = value;
		}
	}

	public bool EnableRemove
	{
		get
		{
			return button_2.Visible;
		}
		set
		{
			button_2.Visible = value;
		}
	}

	public bool EnableRefresh
	{
		get
		{
			return button_4.Visible;
		}
		set
		{
			button_4.Visible = value;
		}
	}

	public bool EnableMove
	{
		get
		{
			return button_1.Visible;
		}
		set
		{
			button_1.Visible = value;
			button_0.Visible = value;
		}
	}

	public event EventHandler ListChanged
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public ListEditor()
	{
		Class76.smethod_41(this);
		grid_0.Selection.FocusRowLeaving += method_6;
		grid_0.Selection.FocusRowEntered += method_7;
		grid_0.Selection.FocusStyle = FocusStyle.None;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && container_0 != null)
		{
			container_0.Dispose();
		}
		base.Dispose(disposing);
	}

	public void LoadList()
	{
		if (!(type_0 == null))
		{
			if (arrayList_0 == null)
			{
				arrayList_0 = new ArrayList();
			}
			if (propertyInfo_0.Length == editorBase_0.Length)
			{
				grid_0.FixedRows = 1;
				grid_0.FixedColumns = 0;
				grid_0.Redim(arrayList_0.Count + grid_0.FixedRows, propertyInfo_0.Length + grid_0.FixedColumns);
				for (int i = 0; i < propertyInfo_0.Length; i++)
				{
					SourceGrid.Cells.ColumnHeader columnHeader = new SourceGrid.Cells.ColumnHeader(propertyInfo_0[i].Name);
					grid_0[0, i + grid_0.FixedColumns] = columnHeader;
					columnHeader.AutomaticSortEnabled = false;
				}
				for (int j = 0; j < arrayList_0.Count; j++)
				{
					int int_ = j + grid_0.FixedRows;
					object object_ = arrayList_0[j];
					Class76.smethod_213(int_, object_, this);
				}
				grid_0.AutoStretchColumnsToFitWidth = true;
				grid_0.AutoSizeCells();
				return;
			}
			throw new ApplicationException("Properteis.Length != Editors.Length");
		}
		throw new ApplicationException("ItemType is null");
	}

	internal void method_0(object sender, EventArgs e)
	{
		try
		{
			int rowsCount = grid_0.RowsCount;
			grid_0.Rows.Insert(rowsCount);
			object obj = Activator.CreateInstance(type_0);
			arrayList_0.Add(obj);
			Class76.smethod_213(rowsCount, obj, this);
			OnListChanged(EventArgs.Empty);
		}
		catch (Exception p_Exception)
		{
			ErrorDialog.Show(this, p_Exception, "Error");
		}
	}

	protected virtual void OnListChanged(EventArgs e)
	{
		if (eventHandler_0 != null)
		{
			eventHandler_0(this, e);
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		OnListChanged(e);
	}

	internal void method_2(object sender, EventArgs e)
	{
		try
		{
			if (!grid_0.Selection.ActivePosition.IsEmpty() && grid_0.Selection.ActivePosition.Row >= grid_0.FixedRows)
			{
				arrayList_0.Remove(grid_0.Rows[grid_0.Selection.ActivePosition.Row].Tag);
				grid_0.Rows.Remove(grid_0.Selection.ActivePosition.Row);
				OnListChanged(EventArgs.Empty);
			}
		}
		catch (Exception p_Exception)
		{
			ErrorDialog.Show(this, p_Exception, "Error");
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		try
		{
			LoadList();
		}
		catch (Exception p_Exception)
		{
			ErrorDialog.Show(this, p_Exception, "Error");
		}
	}

	internal void method_4(object sender, EventArgs e)
	{
		try
		{
			if (!grid_0.Selection.ActivePosition.IsEmpty() && grid_0.Selection.ActivePosition.Row >= grid_0.FixedRows)
			{
				object tag = grid_0.Rows[grid_0.Selection.ActivePosition.Row].Tag;
				int row = grid_0.Selection.ActivePosition.Row;
				int num = arrayList_0.IndexOf(tag);
				arrayList_0.Remove(tag);
				arrayList_0.Insert(num - 1, tag);
				grid_0.Rows.Move(row, row - 1);
				grid_0.Selection.FocusRow(row - 1);
				OnListChanged(EventArgs.Empty);
			}
		}
		catch (Exception p_Exception)
		{
			ErrorDialog.Show(this, p_Exception, "Error");
		}
	}

	internal void method_5(object sender, EventArgs e)
	{
		try
		{
			if (!grid_0.Selection.ActivePosition.IsEmpty() && grid_0.Selection.ActivePosition.Row >= grid_0.FixedRows && grid_0.Selection.ActivePosition.Row < grid_0.Rows.Count - 1)
			{
				object tag = grid_0.Rows[grid_0.Selection.ActivePosition.Row].Tag;
				int row = grid_0.Selection.ActivePosition.Row;
				int num = arrayList_0.IndexOf(tag);
				arrayList_0.Remove(tag);
				arrayList_0.Insert(num + 1, tag);
				grid_0.Rows.Move(row, row + 1);
				grid_0.Selection.FocusRow(row + 1);
				OnListChanged(EventArgs.Empty);
			}
		}
		catch (Exception p_Exception)
		{
			ErrorDialog.Show(this, p_Exception, "Error");
		}
	}

	private void method_6(object sender, RowCancelEventArgs e)
	{
		button_0.Enabled = false;
		button_1.Enabled = false;
		button_2.Enabled = false;
	}

	private void method_7(object sender, RowEventArgs e)
	{
		button_0.Enabled = true;
		button_1.Enabled = true;
		button_2.Enabled = true;
	}
}
