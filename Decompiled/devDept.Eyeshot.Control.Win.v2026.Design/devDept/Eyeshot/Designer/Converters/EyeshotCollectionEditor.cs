using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Windows.Forms;
using devDept.Eyeshot.Control;

namespace devDept.Eyeshot.Designer.Converters;

public class EyeshotCollectionEditor<T> : CollectionEditor where T : DisposableBase
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private CollectionForm _0023_003DzzvS0zcdAqttoJip7Xg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private PropertyGrid _0023_003Dznt2KA98_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ToolStripItem _0023_003DzxI5jKx22zKNzkOLSjA_003D_003D;

	protected Viewport viewport;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal static Design _0023_003Dzf_0024fnpVEiO9xqE1nPDQ_003D_003D;

	protected ListBox listBox;

	protected bool cancelled;

	public EyeshotCollectionEditor(Type type)
		: base(type)
	{
	}

	protected override CollectionForm CreateCollectionForm()
	{
		cancelled = false;
		_0023_003DzzvS0zcdAqttoJip7Xg_003D_003D = base.CreateCollectionForm();
		if (_0023_003DzzvS0zcdAqttoJip7Xg_003D_003D.Controls[0] is TableLayoutPanel tableLayoutPanel)
		{
			if (tableLayoutPanel.Controls[5] is PropertyGrid)
			{
				_0023_003Dznt2KA98_003D = tableLayoutPanel.Controls[5] as PropertyGrid;
				_0023_003Dznt2KA98_003D.PropertyValueChanged += propertyGrid_PropertyValueChanged;
				_0023_003Dznt2KA98_003D.ContextMenuStrip = new ContextMenuStrip();
				_0023_003DzxI5jKx22zKNzkOLSjA_003D_003D = new ToolStripButton(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313345));
				_0023_003Dznt2KA98_003D.ContextMenuStrip.Items.Add(_0023_003DzxI5jKx22zKNzkOLSjA_003D_003D);
				_0023_003Dznt2KA98_003D.ContextMenuStrip.Opening += _0023_003DzPxYLw0MXKNQlqMRuSw_003D_003D;
				_0023_003DzxI5jKx22zKNzkOLSjA_003D_003D.Click += delegate
				{
					GridItem selectedGridItem = _0023_003Dznt2KA98_003D.SelectedGridItem;
					selectedGridItem.PropertyDescriptor.ResetValue(selectedGridItem.Parent.Value ?? _0023_003Dznt2KA98_003D.SelectedObject);
					_0023_003Dznt2KA98_003D.Refresh();
					UpdateGraphics();
				};
				_0023_003DzxI5jKx22zKNzkOLSjA_003D_003D.AutoToolTip = false;
				_0023_003DzxI5jKx22zKNzkOLSjA_003D_003D.DisplayStyle = ToolStripItemDisplayStyle.Text;
			}
			if (tableLayoutPanel.Controls[4] is ListBox)
			{
				listBox = (ListBox)tableLayoutPanel.Controls[4];
				listBox.SelectedIndexChanged += SelectionIndexChanged;
				listBox.SelectionMode = SelectionMode.One;
			}
		}
		_0023_003DzzvS0zcdAqttoJip7Xg_003D_003D.Closed += FormClosed;
		return _0023_003DzzvS0zcdAqttoJip7Xg_003D_003D;
	}

	protected virtual void SelectionIndexChanged(object sender, EventArgs e)
	{
	}

	private void _0023_003DzPxYLw0MXKNQlqMRuSw_003D_003D(object _0023_003DzUNNLWvM_003D, CancelEventArgs _0023_003Dz9I8ZVlc_003D)
	{
		GridItem selectedGridItem = _0023_003Dznt2KA98_003D.SelectedGridItem;
		if (selectedGridItem.Value == null)
		{
			_0023_003DzxI5jKx22zKNzkOLSjA_003D_003D.Enabled = false;
		}
		else
		{
			_0023_003DzxI5jKx22zKNzkOLSjA_003D_003D.Enabled = selectedGridItem.PropertyDescriptor.CanResetValue(selectedGridItem.Parent.Value ?? _0023_003Dznt2KA98_003D.SelectedObject);
		}
	}

	private void _0023_003DzEe_0024WeFH_0024PTw4lqQecolJxtc_003D(object _0023_003DzUNNLWvM_003D, EventArgs _0023_003Dz9I8ZVlc_003D)
	{
		GridItem selectedGridItem = _0023_003Dznt2KA98_003D.SelectedGridItem;
		selectedGridItem.PropertyDescriptor.ResetValue(selectedGridItem.Parent.Value ?? _0023_003Dznt2KA98_003D.SelectedObject);
		_0023_003Dznt2KA98_003D.Refresh();
		UpdateGraphics();
	}

	protected override Type CreateCollectionItemType()
	{
		return typeof(T);
	}

	protected override object CreateInstance(Type itemType)
	{
		return (T)base.CreateInstance(itemType);
	}

	protected virtual void propertyGrid_PropertyValueChanged(object sender, PropertyValueChangedEventArgs e)
	{
		UpdateGraphics();
	}

	protected void UpdateGraphics()
	{
		if (_0023_003Dzf_0024fnpVEiO9xqE1nPDQ_003D_003D != null)
		{
			((IWorkspaceInternal)_0023_003Dzf_0024fnpVEiO9xqE1nPDQ_003D_003D).UpdateWorkspace();
		}
		else if (viewport != null)
		{
			((IViewportInternal)viewport).UpdateWorkspace();
		}
	}

	protected virtual void FormClosed(object sender, EventArgs e)
	{
		if (_0023_003DzzvS0zcdAqttoJip7Xg_003D_003D.DialogResult != DialogResult.OK)
		{
			cancelled = true;
		}
	}

	protected List<T> GetItemsList()
	{
		List<T> list = new List<T>();
		foreach (object item in listBox.Items)
		{
			object value = item.GetType().GetProperty(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313461)).GetValue(item, null);
			if (value is T && !((T)value).Disposed)
			{
				list.Add((T)value);
			}
		}
		return list;
	}
}
