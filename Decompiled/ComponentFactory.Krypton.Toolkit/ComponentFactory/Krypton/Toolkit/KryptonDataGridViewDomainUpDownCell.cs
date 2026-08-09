using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonDataGridViewDomainUpDownCell : DataGridViewTextBoxCell
{
	[ThreadStatic]
	private static KryptonDomainUpDown _paintingDomainUpDown;

	private static readonly DataGridViewContentAlignment _anyRight = (DataGridViewContentAlignment)1092;

	private static readonly DataGridViewContentAlignment _anyCenter = (DataGridViewContentAlignment)546;

	private static readonly Type _defaultEditType = typeof(KryptonDataGridViewDomainUpDownEditingControl);

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

	private KryptonDataGridViewDomainUpDownEditingControl EditingDomainUpDown => base.DataGridView.EditingControl as KryptonDataGridViewDomainUpDownEditingControl;

	public KryptonDataGridViewDomainUpDownCell()
	{
		if (_paintingDomainUpDown == null)
		{
			_paintingDomainUpDown = new KryptonDomainUpDown();
			_paintingDomainUpDown.SetLayoutDisplayPadding(new Padding(0, 0, 0, -1));
			_paintingDomainUpDown.StateCommon.Border.Width = 0;
			_paintingDomainUpDown.StateCommon.Border.Draw = InheritBool.False;
		}
	}

	public override string ToString()
	{
		return "DataGridViewDomainUpDownCell { ColumnIndex=" + base.ColumnIndex.ToString(CultureInfo.CurrentCulture) + ", RowIndex=" + base.RowIndex.ToString(CultureInfo.CurrentCulture) + " }";
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public override void DetachEditingControl()
	{
		DataGridView dataGridView = base.DataGridView;
		if (dataGridView == null || dataGridView.EditingControl == null)
		{
			throw new InvalidOperationException("Cell is detached or its grid has no editing control.");
		}
		if (dataGridView.EditingControl is KryptonDomainUpDown kryptonDomainUpDown && base.OwningColumn is KryptonDataGridViewDomainUpDownColumn)
		{
			kryptonDomainUpDown.Items.Clear();
			foreach (ButtonSpecAny buttonSpec in kryptonDomainUpDown.ButtonSpecs)
			{
				buttonSpec.Click -= OnButtonClick;
			}
			kryptonDomainUpDown.ButtonSpecs.Clear();
			if (kryptonDomainUpDown.Controls[0].Controls[1] is TextBox textBox)
			{
				textBox.ClearUndo();
			}
		}
		base.DetachEditingControl();
	}

	public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
	{
		base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
		if (!(base.DataGridView.EditingControl is KryptonDomainUpDown kryptonDomainUpDown))
		{
			return;
		}
		kryptonDomainUpDown.Items.Clear();
		kryptonDomainUpDown.ButtonSpecs.Clear();
		if (base.OwningColumn is KryptonDataGridViewDomainUpDownColumn kryptonDataGridViewDomainUpDownColumn)
		{
			kryptonDomainUpDown.Items.InsertRange(0, kryptonDataGridViewDomainUpDownColumn.Items);
			kryptonDomainUpDown.ButtonSpecs.Owner = base.DataGridView.Rows[rowIndex].Cells[base.ColumnIndex];
			foreach (ButtonSpecAny buttonSpec in kryptonDataGridViewDomainUpDownColumn.ButtonSpecs)
			{
				buttonSpec.Click += OnButtonClick;
				kryptonDomainUpDown.ButtonSpecs.Add((object)buttonSpec);
			}
		}
		if (!(initialFormattedValue is string text))
		{
			kryptonDomainUpDown.Text = string.Empty;
		}
		else
		{
			kryptonDomainUpDown.Text = text;
		}
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
		KryptonDataGridViewDomainUpDownColumn kryptonDataGridViewDomainUpDownColumn = base.OwningColumn as KryptonDataGridViewDomainUpDownColumn;
		DataGridViewButtonSpecClickEventArgs args = new DataGridViewButtonSpecClickEventArgs(kryptonDataGridViewDomainUpDownColumn, this, (ButtonSpecAny)sender);
		kryptonDataGridViewDomainUpDownColumn.PerfomButtonSpecClick(args);
	}

	private Rectangle GetAdjustedEditingControlBounds(Rectangle editingControlBounds, DataGridViewCellStyle cellStyle)
	{
		int num = _paintingDomainUpDown.GetPreferredSize(_sizeLarge).Height + 2;
		if (num < editingControlBounds.Height)
		{
			switch (cellStyle.Alignment)
			{
			case DataGridViewContentAlignment.MiddleLeft:
			case DataGridViewContentAlignment.MiddleCenter:
			case DataGridViewContentAlignment.MiddleRight:
				editingControlBounds.Y += (editingControlBounds.Height - num) / 2;
				break;
			case DataGridViewContentAlignment.BottomLeft:
			case DataGridViewContentAlignment.BottomCenter:
			case DataGridViewContentAlignment.BottomRight:
				editingControlBounds.Y += editingControlBounds.Height - num;
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

	private bool OwnsEditingDomainUpDown(int rowIndex)
	{
		if (rowIndex == -1 || base.DataGridView == null)
		{
			return false;
		}
		return base.DataGridView.EditingControl is KryptonDataGridViewDomainUpDownEditingControl kryptonDataGridViewDomainUpDownEditingControl && rowIndex == ((IDataGridViewEditingControl)kryptonDataGridViewDomainUpDownEditingControl).EditingControlRowIndex;
	}

	private static bool PartPainted(DataGridViewPaintParts paintParts, DataGridViewPaintParts paintPart)
	{
		return (paintParts & paintPart) != 0;
	}

	internal static HorizontalAlignment TranslateAlignment(DataGridViewContentAlignment align)
	{
		if ((align & _anyRight) != DataGridViewContentAlignment.NotSet)
		{
			return HorizontalAlignment.Right;
		}
		if ((align & _anyCenter) != DataGridViewContentAlignment.NotSet)
		{
			return HorizontalAlignment.Center;
		}
		return HorizontalAlignment.Left;
	}
}
