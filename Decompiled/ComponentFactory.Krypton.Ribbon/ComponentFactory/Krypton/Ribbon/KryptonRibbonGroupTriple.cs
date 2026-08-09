using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

[ToolboxItem(false)]
[ToolboxBitmap(typeof(KryptonRibbonGroupTriple), "ToolboxBitmaps.KryptonRibbonGroupTriple.bmp")]
[Designer("ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTripleDesigner, ComponentFactory.Krypton.Ribbon, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[DesignerCategory("code")]
[DesignTimeVisible(false)]
[DefaultProperty("Visible")]
public class KryptonRibbonGroupTriple : KryptonRibbonGroupContainer
{
	private KryptonRibbonGroupTripleCollection _ribbonTripleItems;

	private GroupItemSize _itemSizeMax;

	private GroupItemSize _itemSizeMin;

	private GroupItemSize _itemSizeCurrent;

	private RibbonItemAlignment _itemAlignment;

	private ViewBase _tripleView;

	private bool _visible;

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
			foreach (KryptonRibbonGroupItem ribbonTripleItem in _ribbonTripleItems)
			{
				ribbonTripleItem.Ribbon = value;
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
			foreach (KryptonRibbonGroupItem ribbonTripleItem in _ribbonTripleItems)
			{
				ribbonTripleItem.RibbonTab = value;
			}
		}
	}

	[Category("Visuals")]
	[Description("How to align items in medium and small item sizes.")]
	[DefaultValue(typeof(RibbonItemAlignment), "Near")]
	public RibbonItemAlignment ItemAlignment
	{
		get
		{
			return _itemAlignment;
		}
		set
		{
			if (_itemAlignment != value)
			{
				_itemAlignment = value;
				OnPropertyChanged("ItemAlignment");
			}
		}
	}

	[Bindable(true)]
	[Category("Behavior")]
	[Description("Determines whether the triple group container is visible or hidden.")]
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
	[Description("Maximum size of items placed in the triple container.")]
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
	[Description("Minimum size of items placed in the triple container.")]
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
			foreach (KryptonRibbonGroupItem item in Items)
			{
				((IRibbonGroupItem)item).ItemSizeMaximum = value;
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
			if (_itemSizeCurrent == value)
			{
				return;
			}
			_itemSizeCurrent = value;
			foreach (KryptonRibbonGroupItem item in Items)
			{
				((IRibbonGroupItem)item).ItemSizeCurrent = value;
			}
			OnPropertyChanged("ItemSizeCurrent");
		}
	}

	[Category("Visuals")]
	[Description("Collection of ribbon group triple items.")]
	[MergableProperty(false)]
	[Editor("ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTripleCollectionEditor, ComponentFactory.Krypton.Ribbon, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e", typeof(UITypeEditor))]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonRibbonGroupTripleCollection Items => _ribbonTripleItems;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public ViewBase TripleView
	{
		get
		{
			return _tripleView;
		}
		set
		{
			_tripleView = value;
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

	public KryptonRibbonGroupTriple()
	{
		_visible = true;
		_itemSizeMax = GroupItemSize.Large;
		_itemSizeMin = GroupItemSize.Small;
		_itemSizeCurrent = GroupItemSize.Large;
		_itemAlignment = RibbonItemAlignment.Near;
		_ribbonTripleItems = new KryptonRibbonGroupTripleCollection();
		_ribbonTripleItems.Clearing += OnRibbonGroupTripleClearing;
		_ribbonTripleItems.Cleared += OnRibbonGroupTripleCleared;
		_ribbonTripleItems.Inserted += OnRibbonGroupTripleInserted;
		_ribbonTripleItems.Removed += OnRibbonGroupTripleRemoved;
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
		return new ViewLayoutRibbonGroupTriple(ribbon, this, needPaint);
	}

	public override Component[] GetChildComponents()
	{
		Component[] array = new Component[Items.Count];
		_ribbonTripleItems.CopyTo(array, 0);
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

	private void OnRibbonGroupTripleClearing(object sender, EventArgs e)
	{
		foreach (KryptonRibbonGroupItem ribbonTripleItem in _ribbonTripleItems)
		{
			((IRibbonGroupItem)ribbonTripleItem).Ribbon = null;
			((IRibbonGroupItem)ribbonTripleItem).RibbonTab = null;
			((IRibbonGroupItem)ribbonTripleItem).RibbonContainer = null;
		}
	}

	private void OnRibbonGroupTripleCleared(object sender, EventArgs e)
	{
		if (Ribbon != null && RibbonTab != null && Ribbon.SelectedTab == RibbonTab)
		{
			Ribbon.PerformNeedPaint(needLayout: true);
		}
	}

	private void OnRibbonGroupTripleInserted(object sender, TypedCollectionEventArgs<KryptonRibbonGroupItem> e)
	{
		e.Item.Ribbon = Ribbon;
		e.Item.RibbonTab = RibbonTab;
		e.Item.RibbonContainer = this;
		e.Item.ItemSizeMaximum = ItemSizeMaximum;
		e.Item.ItemSizeMinimum = ItemSizeMinimum;
		e.Item.ItemSizeCurrent = ItemSizeCurrent;
		if (Ribbon != null && RibbonTab != null && Ribbon.SelectedTab == RibbonTab)
		{
			Ribbon.PerformNeedPaint(needLayout: true);
		}
	}

	private void OnRibbonGroupTripleRemoved(object sender, TypedCollectionEventArgs<KryptonRibbonGroupItem> e)
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
