#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

[ToolboxItem(false)]
[ToolboxBitmap(typeof(KryptonRibbonGroupLines), "ToolboxBitmaps.KryptonRibbonGroupLines.bmp")]
[Designer("ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupLinesDesigner, ComponentFactory.Krypton.Ribbon, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[DesignerCategory("code")]
[DesignTimeVisible(false)]
[DefaultProperty("Visible")]
public class KryptonRibbonGroupLines : KryptonRibbonGroupContainer
{
	private KryptonRibbonGroupLinesCollection _ribbonLineItems;

	private GroupItemSize _itemSizeMax;

	private GroupItemSize _itemSizeMin;

	private GroupItemSize _itemSizeCurrent;

	private bool _visible;

	private ViewBase _linesView;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override KryptonRibbon Ribbon
	{
		get
		{
			return base.Ribbon;
		}
		set
		{
			base.Ribbon = value;
			foreach (KryptonRibbonGroupItem ribbonLineItem in _ribbonLineItems)
			{
				ribbonLineItem.Ribbon = value;
			}
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override KryptonRibbonTab RibbonTab
	{
		get
		{
			return base.RibbonTab;
		}
		set
		{
			base.RibbonTab = value;
			foreach (KryptonRibbonGroupItem ribbonLineItem in _ribbonLineItems)
			{
				ribbonLineItem.RibbonTab = value;
			}
		}
	}

	[Bindable(true)]
	[Category("Behavior")]
	[Description("Determines whether the lines group container is visible or hidden.")]
	[DefaultValue(true)]
	[Browsable(true)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public override bool Visible
	{
		get
		{
			return _visible;
		}
		set
		{
			if (value != _visible)
			{
				_visible = value;
				OnPropertyChanged("Visible");
			}
		}
	}

	[Category("Visuals")]
	[Description("Maximum size of items placed in the lines container.")]
	[Browsable(true)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	[DefaultValue(typeof(GroupItemSize), "Large")]
	[RefreshProperties(RefreshProperties.All)]
	public GroupItemSize MaximumSize
	{
		get
		{
			return ItemSizeMaximum;
		}
		set
		{
			ItemSizeMaximum = value;
		}
	}

	[Category("Visuals")]
	[Description("Minimum size of items placed in the lines container.")]
	[Browsable(true)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	[DefaultValue(typeof(GroupItemSize), "Small")]
	[RefreshProperties(RefreshProperties.All)]
	public GroupItemSize MinimumSize
	{
		get
		{
			return ItemSizeMinimum;
		}
		set
		{
			ItemSizeMinimum = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override GroupItemSize ItemSizeMaximum
	{
		get
		{
			return _itemSizeMax;
		}
		set
		{
			if (_itemSizeMax == value)
			{
				return;
			}
			_itemSizeMax = value;
			switch (_itemSizeMax)
			{
			case GroupItemSize.Medium:
				if (_itemSizeMin == GroupItemSize.Large)
				{
					_itemSizeMin = GroupItemSize.Medium;
				}
				break;
			case GroupItemSize.Small:
				if (_itemSizeMin != GroupItemSize.Small)
				{
					_itemSizeMin = GroupItemSize.Small;
				}
				break;
			}
			GroupItemSize itemSizeMaximum = LinesToItemSize(_itemSizeMax);
			foreach (KryptonRibbonGroupItem item in Items)
			{
				((IRibbonGroupItem)item).ItemSizeMaximum = itemSizeMaximum;
			}
			OnPropertyChanged("ItemSizeMaximum");
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override GroupItemSize ItemSizeMinimum
	{
		get
		{
			return _itemSizeMin;
		}
		set
		{
			if (_itemSizeMin == value)
			{
				return;
			}
			_itemSizeMin = value;
			switch (_itemSizeMin)
			{
			case GroupItemSize.Large:
				if (_itemSizeMax != GroupItemSize.Large)
				{
					_itemSizeMax = GroupItemSize.Large;
				}
				break;
			case GroupItemSize.Medium:
				if (_itemSizeMax == GroupItemSize.Small)
				{
					_itemSizeMax = GroupItemSize.Medium;
				}
				break;
			}
			GroupItemSize groupItemSize = LinesToItemSize(_itemSizeMin);
			foreach (KryptonRibbonGroupItem item in Items)
			{
				((IRibbonGroupItem)item).ItemSizeMinimum = value;
			}
			OnPropertyChanged("ItemSizeMinimum");
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override GroupItemSize ItemSizeCurrent
	{
		get
		{
			return _itemSizeCurrent;
		}
		set
		{
			if (_itemSizeCurrent != value)
			{
				_itemSizeCurrent = value;
				OnPropertyChanged("ItemSizeCurrent");
			}
		}
	}

	[Category("Visuals")]
	[Description("Collection of ribbon group line items.")]
	[MergableProperty(false)]
	[Editor("ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupLinesCollectionEditor, ComponentFactory.Krypton.Ribbon, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e", typeof(UITypeEditor))]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonRibbonGroupLinesCollection Items => _ribbonLineItems;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public ViewBase LinesView
	{
		get
		{
			return _linesView;
		}
		set
		{
			_linesView = value;
		}
	}

	[Category("Ribbon")]
	[Description("Occurs after the value of a property has changed.")]
	public event PropertyChangedEventHandler PropertyChanged;

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public event EventHandler DesignTimeAddButton;

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public event EventHandler DesignTimeAddColorButton;

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public event EventHandler DesignTimeAddCheckBox;

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public event EventHandler DesignTimeAddRadioButton;

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public event EventHandler DesignTimeAddLabel;

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public event EventHandler DesignTimeAddCustomControl;

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public event EventHandler DesignTimeAddCluster;

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public event EventHandler DesignTimeAddTextBox;

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public event EventHandler DesignTimeAddMaskedTextBox;

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public event EventHandler DesignTimeAddRichTextBox;

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public event EventHandler DesignTimeAddComboBox;

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public event EventHandler DesignTimeAddNumericUpDown;

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public event EventHandler DesignTimeAddDomainUpDown;

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public event EventHandler DesignTimeAddDateTimePicker;

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public event EventHandler DesignTimeAddTrackBar;

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public event MouseEventHandler DesignTimeContextMenu;

	public KryptonRibbonGroupLines()
	{
		_visible = true;
		_itemSizeMax = GroupItemSize.Large;
		_itemSizeMin = GroupItemSize.Small;
		_itemSizeCurrent = GroupItemSize.Large;
		_ribbonLineItems = new KryptonRibbonGroupLinesCollection();
		_ribbonLineItems.Clearing += OnRibbonGroupLineClearing;
		_ribbonLineItems.Cleared += OnRibbonGroupLineCleared;
		_ribbonLineItems.Inserted += OnRibbonGroupLineInserted;
		_ribbonLineItems.Removed += OnRibbonGroupLineRemoved;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			foreach (KryptonRibbonGroupItem item in Items)
			{
				item.Dispose();
			}
		}
		base.Dispose(disposing);
	}

	public void Show()
	{
		Visible = true;
	}

	public void Hide()
	{
		Visible = false;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override ViewBase CreateView(KryptonRibbon ribbon, NeedPaintHandler needPaint)
	{
		return new ViewLayoutRibbonGroupLines(ribbon, this, needPaint);
	}

	public override Component[] GetChildComponents()
	{
		Component[] array = new Component[Items.Count];
		_ribbonLineItems.CopyTo(array, 0);
		return array;
	}

	protected virtual void OnPropertyChanged(string propertyName)
	{
		if (this.PropertyChanged != null)
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}

	internal void OnDesignTimeAddButton()
	{
		if (this.DesignTimeAddButton != null)
		{
			this.DesignTimeAddButton(this, EventArgs.Empty);
		}
	}

	internal void OnDesignTimeAddColorButton()
	{
		if (this.DesignTimeAddColorButton != null)
		{
			this.DesignTimeAddColorButton(this, EventArgs.Empty);
		}
	}

	internal void OnDesignTimeAddCheckBox()
	{
		if (this.DesignTimeAddCheckBox != null)
		{
			this.DesignTimeAddCheckBox(this, EventArgs.Empty);
		}
	}

	internal void OnDesignTimeAddRadioButton()
	{
		if (this.DesignTimeAddRadioButton != null)
		{
			this.DesignTimeAddRadioButton(this, EventArgs.Empty);
		}
	}

	internal void OnDesignTimeAddLabel()
	{
		if (this.DesignTimeAddLabel != null)
		{
			this.DesignTimeAddLabel(this, EventArgs.Empty);
		}
	}

	internal void OnDesignTimeAddCustomControl()
	{
		if (this.DesignTimeAddCustomControl != null)
		{
			this.DesignTimeAddCustomControl(this, EventArgs.Empty);
		}
	}

	internal void OnDesignTimeAddCluster()
	{
		if (this.DesignTimeAddCluster != null)
		{
			this.DesignTimeAddCluster(this, EventArgs.Empty);
		}
	}

	internal void OnDesignTimeAddTextBox()
	{
		if (this.DesignTimeAddTextBox != null)
		{
			this.DesignTimeAddTextBox(this, EventArgs.Empty);
		}
	}

	internal void OnDesignTimeAddMaskedTextBox()
	{
		if (this.DesignTimeAddMaskedTextBox != null)
		{
			this.DesignTimeAddMaskedTextBox(this, EventArgs.Empty);
		}
	}

	internal void OnDesignTimeAddRichTextBox()
	{
		if (this.DesignTimeAddRichTextBox != null)
		{
			this.DesignTimeAddRichTextBox(this, EventArgs.Empty);
		}
	}

	internal void OnDesignTimeAddComboBox()
	{
		if (this.DesignTimeAddComboBox != null)
		{
			this.DesignTimeAddComboBox(this, EventArgs.Empty);
		}
	}

	internal void OnDesignTimeAddNumericUpDown()
	{
		if (this.DesignTimeAddNumericUpDown != null)
		{
			this.DesignTimeAddNumericUpDown(this, EventArgs.Empty);
		}
	}

	internal void OnDesignTimeAddDomainUpDown()
	{
		if (this.DesignTimeAddDomainUpDown != null)
		{
			this.DesignTimeAddDomainUpDown(this, EventArgs.Empty);
		}
	}

	internal void OnDesignTimeAddDateTimePicker()
	{
		if (this.DesignTimeAddDateTimePicker != null)
		{
			this.DesignTimeAddDateTimePicker(this, EventArgs.Empty);
		}
	}

	internal void OnDesignTimeAddTrackBar()
	{
		if (this.DesignTimeAddTrackBar != null)
		{
			this.DesignTimeAddTrackBar(this, EventArgs.Empty);
		}
	}

	internal void OnDesignTimeContextMenu(MouseEventArgs e)
	{
		if (this.DesignTimeContextMenu != null)
		{
			this.DesignTimeContextMenu(this, e);
		}
	}

	internal override bool ProcessCmdKey(ref Message msg, Keys keyData)
	{
		foreach (KryptonRibbonGroupItem item in Items)
		{
			if (item.ProcessCmdKey(ref msg, keyData))
			{
				return true;
			}
		}
		return false;
	}

	private GroupItemSize LinesToItemSize(GroupItemSize containerSize)
	{
		switch (containerSize)
		{
		case GroupItemSize.Large:
			return GroupItemSize.Medium;
		case GroupItemSize.Small:
		case GroupItemSize.Medium:
			return GroupItemSize.Small;
		default:
			Debug.Assert(condition: false);
			return GroupItemSize.Medium;
		}
	}

	private void OnRibbonGroupLineClearing(object sender, EventArgs e)
	{
		foreach (KryptonRibbonGroupItem ribbonLineItem in _ribbonLineItems)
		{
			((IRibbonGroupItem)ribbonLineItem).Ribbon = null;
			((IRibbonGroupItem)ribbonLineItem).RibbonTab = null;
			((IRibbonGroupItem)ribbonLineItem).RibbonContainer = null;
		}
	}

	private void OnRibbonGroupLineCleared(object sender, EventArgs e)
	{
		if (Ribbon != null && RibbonTab != null && Ribbon.SelectedTab == RibbonTab)
		{
			Ribbon.PerformNeedPaint(needLayout: true);
		}
	}

	private void OnRibbonGroupLineInserted(object sender, TypedCollectionEventArgs<KryptonRibbonGroupItem> e)
	{
		e.Item.Ribbon = Ribbon;
		e.Item.RibbonTab = RibbonTab;
		e.Item.RibbonContainer = this;
		e.Item.ItemSizeMaximum = LinesToItemSize(ItemSizeMaximum);
		e.Item.ItemSizeMinimum = LinesToItemSize(ItemSizeMinimum);
		e.Item.ItemSizeCurrent = LinesToItemSize(ItemSizeCurrent);
		if (Ribbon != null && RibbonTab != null && Ribbon.SelectedTab == RibbonTab)
		{
			Ribbon.PerformNeedPaint(needLayout: true);
		}
	}

	private void OnRibbonGroupLineRemoved(object sender, TypedCollectionEventArgs<KryptonRibbonGroupItem> e)
	{
		e.Item.Ribbon = null;
		e.Item.RibbonTab = null;
		e.Item.RibbonContainer = null;
		if (Ribbon != null && RibbonTab != null && Ribbon.SelectedTab == RibbonTab)
		{
			Ribbon.PerformNeedPaint(needLayout: true);
		}
	}
}
