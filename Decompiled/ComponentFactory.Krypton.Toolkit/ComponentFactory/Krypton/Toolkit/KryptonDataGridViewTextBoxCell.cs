using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonDataGridViewTextBoxCell : DataGridViewTextBoxCell
{
	[ThreadStatic]
	private static KryptonTextBox _paintingTextBox;

	private static readonly Type _defaultEditType = typeof(KryptonDataGridViewTextBoxEditingControl);

	private static readonly Type _defaultValueType = typeof(string);

	private static readonly Size _sizeLarge = new Size(10000, 10000);

	public override Type EditType => _defaultEditType;

	public override Type ValueType
	{
		get
		{
			Type valueType = base.ValueType;
			if (valueType != null)
			{
				return valueType;
			}
			return _defaultValueType;
		}
	}

	private KryptonDataGridViewTextBoxEditingControl EditingTextBox => base.DataGridView.EditingControl as KryptonDataGridViewTextBoxEditingControl;

	public KryptonDataGridViewTextBoxCell()
	{
		if (_paintingTextBox == null)
		{
			_paintingTextBox = new KryptonTextBox();
			_paintingTextBox.StateCommon.Border.Width = 0;
			_paintingTextBox.StateCommon.Border.Draw = InheritBool.False;
			_paintingTextBox.StateCommon.Back.Color1 = Color.Empty;
		}
	}

	public override string ToString()
	{
		return "KryptonDataGridViewTextBoxCell { ColumnIndex=" + base.ColumnIndex.ToString(CultureInfo.CurrentCulture) + ", RowIndex=" + base.RowIndex.ToString(CultureInfo.CurrentCulture) + " }";
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
		}
		base.Dispose(disposing);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public override void DetachEditingControl()
	{
		DataGridView dataGridView = base.DataGridView;
		if (dataGridView == null || dataGridView.EditingControl == null)
		{
			throw new InvalidOperationException("Cell is detached or its grid has no editing control.");
		}
		if (dataGridView.EditingControl is KryptonTextBox kryptonTextBox && base.OwningColumn is KryptonDataGridViewTextBoxColumn)
		{
			foreach (ButtonSpecAny buttonSpec in kryptonTextBox.ButtonSpecs)
			{
				buttonSpec.Click -= OnButtonClick;
			}
			kryptonTextBox.ButtonSpecs.Clear();
			if (kryptonTextBox.Controls[0] is TextBox textBox)
			{
				textBox.ClearUndo();
			}
		}
		base.DetachEditingControl();
	}

	public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
	{
		base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
		if (!(base.DataGridView.EditingControl is KryptonTextBox kryptonTextBox))
		{
			return;
		}
		if (base.OwningColumn is KryptonDataGridViewTextBoxColumn kryptonDataGridViewTextBoxColumn)
		{
			kryptonTextBox.ButtonSpecs.Clear();
			kryptonTextBox.ButtonSpecs.Owner = base.DataGridView.Rows[rowIndex].Cells[base.ColumnIndex];
			foreach (ButtonSpecAny buttonSpec in kryptonDataGridViewTextBoxColumn.ButtonSpecs)
			{
				buttonSpec.Click += OnButtonClick;
				kryptonTextBox.ButtonSpecs.Add((object)buttonSpec);
			}
		}
		if (!(initialFormattedValue is string text))
		{
			kryptonTextBox.Text = string.Empty;
		}
		else
		{
			kryptonTextBox.Text = text;
		}
		DataGridViewTriState wrapMode = base.Style.WrapMode;
		if (wrapMode == DataGridViewTriState.NotSet)
		{
			wrapMode = base.OwningColumn.DefaultCellStyle.WrapMode;
		}
		bool wordWrap = (kryptonTextBox.Multiline = wrapMode == DataGridViewTriState.True);
		kryptonTextBox.WordWrap = wordWrap;
	}

	public override void PositionEditingControl(bool setLocation, bool setSize, Rectangle cellBounds, Rectangle cellClip, DataGridViewCellStyle cellStyle, bool singleVerticalBorderAdded, bool singleHorizontalBorderAdded, bool isFirstDisplayedColumn, bool isFirstDisplayedRow)
	{
		Rectangle editingControlBounds = PositionEditingPanel(cellBounds, cellClip, cellStyle, singleVerticalBorderAdded, singleHorizontalBorderAdded, isFirstDisplayedColumn, isFirstDisplayedRow);
		editingControlBounds = GetAdjustedEditingControlBounds(editingControlBounds, cellStyle);
		base.DataGridView.EditingControl.Location = new Point(editingControlBounds.X, editingControlBounds.Y);
		base.DataGridView.EditingControl.Size = new Size(editingControlBounds.Width, editingControlBounds.Height);
	}

	protected override Rectangle GetErrorIconBounds(Graphics graphics, DataGridViewCellStyle cellStyle, int rowIndex)
	{
		Rectangle errorIconBounds = base.GetErrorIconBounds(graphics, cellStyle, rowIndex);
		if (base.DataGridView.RightToLeft == RightToLeft.Yes)
		{
			errorIconBounds.X = errorIconBounds.Left + 16;
		}
		else
		{
			errorIconBounds.X = errorIconBounds.Left - 16;
		}
		return errorIconBounds;
	}

	protected override Size GetPreferredSize(Graphics graphics, DataGridViewCellStyle cellStyle, int rowIndex, Size constraintSize)
	{
		if (base.DataGridView == null)
		{
			return new Size(-1, -1);
		}
		Size preferredSize = base.GetPreferredSize(graphics, cellStyle, rowIndex, constraintSize);
		if (constraintSize.Width == 0)
		{
			preferredSize.Width += 24;
		}
		return preferredSize;
	}

	private void OnButtonClick(object sender, EventArgs e)
	{
		KryptonDataGridViewTextBoxColumn kryptonDataGridViewTextBoxColumn = base.OwningColumn as KryptonDataGridViewTextBoxColumn;
		DataGridViewButtonSpecClickEventArgs args = new DataGridViewButtonSpecClickEventArgs(kryptonDataGridViewTextBoxColumn, this, (ButtonSpecAny)sender);
		kryptonDataGridViewTextBoxColumn.PerfomButtonSpecClick(args);
	}

	private Rectangle GetAdjustedEditingControlBounds(Rectangle editingControlBounds, DataGridViewCellStyle cellStyle)
	{
		int height = base.DataGridView.EditingControl.GetPreferredSize(new Size(editingControlBounds.Width, 10000)).Height;
		if (height < editingControlBounds.Height)
		{
			switch (cellStyle.Alignment)
			{
			case DataGridViewContentAlignment.MiddleLeft:
			case DataGridViewContentAlignment.MiddleCenter:
			case DataGridViewContentAlignment.MiddleRight:
				editingControlBounds.Y += (editingControlBounds.Height - height) / 2;
				break;
			case DataGridViewContentAlignment.BottomLeft:
			case DataGridViewContentAlignment.BottomCenter:
			case DataGridViewContentAlignment.BottomRight:
				editingControlBounds.Y += editingControlBounds.Height - height;
				break;
			}
		}
		return editingControlBounds;
	}

	private void OnCommonChange()
	{
		if (base.DataGridView != null && !base.DataGridView.IsDisposed && !base.DataGridView.Disposing)
		{
			if (base.RowIndex == -1)
			{
				base.DataGridView.InvalidateColumn(base.ColumnIndex);
			}
			else
			{
				base.DataGridView.UpdateCellValue(base.ColumnIndex, base.RowIndex);
			}
		}
	}

	private bool OwnsEditingTextBox(int rowIndex)
	{
		if (rowIndex == -1 || base.DataGridView == null)
		{
			return false;
		}
		return base.DataGridView.EditingControl is KryptonDataGridViewTextBoxEditingControl kryptonDataGridViewTextBoxEditingControl && rowIndex == ((IDataGridViewEditingControl)kryptonDataGridViewTextBoxEditingControl).EditingControlRowIndex;
	}

	private static bool PartPainted(DataGridViewPaintParts paintParts, DataGridViewPaintParts paintPart)
	{
		return (paintParts & paintPart) != 0;
	}
}
