using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxBitmap(typeof(KryptonDataGridViewLinkColumn), "ToolboxBitmaps.KryptonLinkLabel.bmp")]
public class KryptonDataGridViewLinkColumn : DataGridViewColumn
{
	private MethodInfo _miColumnCommonChange;

	private PropertyInfo _piUseColumnTextForLinkValueInternal;

	private PropertyInfo _piTrackVisitedStateInternal;

	private string _text;

	private LabelStyle _labelStyle;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override DataGridViewCell CellTemplate
	{
		get
		{
			return base.CellTemplate;
		}
		set
		{
			if (value != null && !(value is KryptonDataGridViewLinkCell))
			{
				throw new InvalidCastException("Can only assign a object of type KryptonDataGridViewLinkCell");
			}
			base.CellTemplate = value;
		}
	}

	[Category("Appearance")]
	[DefaultValue(null)]
	public string Text
	{
		get
		{
			return _text;
		}
		set
		{
			if (string.Equals(value, _text, StringComparison.Ordinal))
			{
				return;
			}
			_text = value;
			if (base.DataGridView == null)
			{
				return;
			}
			if (UseColumnTextForLinkValue)
			{
				ColumnCommonChange(base.Index);
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				if (rows.SharedRow(i).Cells[base.Index] is KryptonDataGridViewLinkCell { UseColumnTextForLinkValue: not false })
				{
					ColumnCommonChange(base.Index);
					return;
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	[Category("Appearance")]
	[DefaultValue(typeof(LabelStyle), "NormalControl")]
	public LabelStyle LabelStyle
	{
		get
		{
			return _labelStyle;
		}
		set
		{
			if (_labelStyle == value)
			{
				return;
			}
			_labelStyle = value;
			((KryptonDataGridViewLinkCell)CellTemplate).LabelStyleInternal = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				if (rows.SharedRow(i).Cells[base.Index] is KryptonDataGridViewLinkCell kryptonDataGridViewLinkCell)
				{
					kryptonDataGridViewLinkCell.LabelStyleInternal = value;
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	[Category("Behavior")]
	[DefaultValue(typeof(LinkBehavior), "AlwaysUnderline")]
	public LinkBehavior LinkBehavior
	{
		get
		{
			if (CellTemplate == null)
			{
				throw new InvalidOperationException("KryptonDataGridViewLinkCell cell template required");
			}
			return ((KryptonDataGridViewLinkCell)CellTemplate).LinkBehavior;
		}
		set
		{
			if (LinkBehavior.Equals(value))
			{
				return;
			}
			((KryptonDataGridViewLinkCell)CellTemplate).LinkBehaviorInternal = value;
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				if (rows.SharedRow(i).Cells[base.Index] is KryptonDataGridViewLinkCell kryptonDataGridViewLinkCell)
				{
					kryptonDataGridViewLinkCell.LinkBehaviorInternal = value;
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	[Category("Behavior")]
	[DefaultValue(true)]
	public bool TrackVisitedState
	{
		get
		{
			if (CellTemplate == null)
			{
				throw new InvalidOperationException("KryptonDataGridViewLinkCell cell template required");
			}
			return ((KryptonDataGridViewLinkCell)CellTemplate).TrackVisitedState;
		}
		set
		{
			if (TrackVisitedState == value)
			{
				return;
			}
			TrackVisitedStateInternal(CellTemplate, value);
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				if (rows.SharedRow(i).Cells[base.Index] is DataGridViewLinkCell instance)
				{
					TrackVisitedStateInternal(instance, value);
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	[Category("Appearance")]
	[DefaultValue(false)]
	public bool UseColumnTextForLinkValue
	{
		get
		{
			if (CellTemplate == null)
			{
				throw new InvalidOperationException("KryptonDataGridViewLinkCell cell template required");
			}
			return ((KryptonDataGridViewLinkCell)CellTemplate).UseColumnTextForLinkValue;
		}
		set
		{
			if (UseColumnTextForLinkValue == value)
			{
				return;
			}
			SetUseColumnTextForLinkValueInternal(CellTemplate, value);
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				if (rows.SharedRow(i).Cells[base.Index] is DataGridViewLinkCell instance)
				{
					SetUseColumnTextForLinkValueInternal(instance, value);
				}
			}
			ColumnCommonChange(base.Index);
		}
	}

	public KryptonDataGridViewLinkColumn()
		: base(new KryptonDataGridViewLinkCell())
	{
		_labelStyle = LabelStyle.NormalControl;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder(64);
		stringBuilder.Append("KryptonDataGridViewLinkColumn { Name=");
		stringBuilder.Append(base.Name);
		stringBuilder.Append(", Index=");
		stringBuilder.Append(base.Index.ToString(CultureInfo.CurrentCulture));
		stringBuilder.Append(" }");
		return stringBuilder.ToString();
	}

	public override object Clone()
	{
		KryptonDataGridViewLinkColumn kryptonDataGridViewLinkColumn = base.Clone() as KryptonDataGridViewLinkColumn;
		kryptonDataGridViewLinkColumn.Text = Text;
		kryptonDataGridViewLinkColumn.LabelStyle = LabelStyle;
		return kryptonDataGridViewLinkColumn;
	}

	private void ColumnCommonChange(int columnIndex)
	{
		if (_miColumnCommonChange == null)
		{
			_miColumnCommonChange = typeof(DataGridView).GetMethod("OnColumnCommonChange", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField);
		}
		_miColumnCommonChange.Invoke(base.DataGridView, new object[1] { columnIndex });
	}

	private void SetUseColumnTextForLinkValueInternal(object instance, bool value)
	{
		if (_piUseColumnTextForLinkValueInternal == null)
		{
			_piUseColumnTextForLinkValueInternal = typeof(DataGridViewLinkCell).GetProperty("UseColumnTextForLinkValueInternal", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.SetProperty);
		}
		_piUseColumnTextForLinkValueInternal.SetValue(instance, value, null);
	}

	private void TrackVisitedStateInternal(object instance, bool value)
	{
		if (_piTrackVisitedStateInternal == null)
		{
			_piTrackVisitedStateInternal = typeof(DataGridViewLinkCell).GetProperty("TrackVisitedStateInternal", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.SetProperty);
		}
		_piTrackVisitedStateInternal.SetValue(instance, value, null);
	}
}
