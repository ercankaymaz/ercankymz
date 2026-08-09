using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

[ToolboxItem(false)]
[ToolboxBitmap(typeof(KryptonRibbonGroupCluster), "ToolboxBitmaps.KryptonRibbonGroupCluster.bmp")]
[Designer("ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupClusterDesigner, ComponentFactory.Krypton.Ribbon, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[DesignerCategory("code")]
[DesignTimeVisible(false)]
[DefaultProperty("Visible")]
public class KryptonRibbonGroupCluster : KryptonRibbonGroupContainer
{
	private KryptonRibbonGroupClusterCollection _ribbonClusterItems;

	private GroupItemSize _itemSizeMax;

	private GroupItemSize _itemSizeMin;

	private GroupItemSize _itemSizeCurrent;

	private ViewBase _clusterView;

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
			foreach (KryptonRibbonGroupItem ribbonClusterItem in _ribbonClusterItems)
			{
				ribbonClusterItem.Ribbon = value;
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
			foreach (KryptonRibbonGroupItem ribbonClusterItem in _ribbonClusterItems)
			{
				ribbonClusterItem.RibbonTab = value;
			}
		}
	}

	[Bindable(true)]
	[Category("Behavior")]
	[Description("Determines whether the button cluster is visible or hidden.")]
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
			if (value == GroupItemSize.Large)
			{
				value = GroupItemSize.Medium;
			}
			if (_itemSizeMax == value)
			{
				return;
			}
			_itemSizeMax = value;
			if (_itemSizeMax == GroupItemSize.Small)
			{
				_itemSizeMin = GroupItemSize.Small;
			}
			foreach (KryptonRibbonGroupItem item in Items)
			{
				((IRibbonGroupItem)item).ItemSizeMaximum = _itemSizeMax;
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
			if (value == GroupItemSize.Large)
			{
				value = GroupItemSize.Medium;
			}
			if (_itemSizeMin == value)
			{
				return;
			}
			_itemSizeMin = value;
			if (_itemSizeMin == GroupItemSize.Medium)
			{
				_itemSizeMax = GroupItemSize.Medium;
			}
			foreach (KryptonRibbonGroupItem item in Items)
			{
				((IRibbonGroupItem)item).ItemSizeMinimum = _itemSizeMin;
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
	[Description("Collection of ribbon group button cluster items.")]
	[MergableProperty(false)]
	[Editor("ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupClusterCollectionEditor, ComponentFactory.Krypton.Ribbon, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e", typeof(UITypeEditor))]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonRibbonGroupClusterCollection Items => _ribbonClusterItems;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public ViewBase ClusterView
	{
		get
		{
			return _clusterView;
		}
		set
		{
			_clusterView = value;
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
	public event MouseEventHandler DesignTimeContextMenu;

	public KryptonRibbonGroupCluster()
	{
		_itemSizeMax = GroupItemSize.Medium;
		_itemSizeMin = GroupItemSize.Small;
		_itemSizeCurrent = GroupItemSize.Medium;
		_visible = true;
		_ribbonClusterItems = new KryptonRibbonGroupClusterCollection();
		_ribbonClusterItems.Clearing += OnRibbonGroupClusterClearing;
		_ribbonClusterItems.Cleared += OnRibbonGroupClusterCleared;
		_ribbonClusterItems.Inserted += OnRibbonGroupClusterInserted;
		_ribbonClusterItems.Removed += OnRibbonGroupClusterRemoved;
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
	public override int ItemGap(IRibbonGroupItem previousItem)
	{
		return 3;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override ViewBase CreateView(KryptonRibbon ribbon, NeedPaintHandler needPaint)
	{
		return new ViewLayoutRibbonGroupCluster(ribbon, this, needPaint);
	}

	public override Component[] GetChildComponents()
	{
		Component[] array = new Component[Items.Count];
		_ribbonClusterItems.CopyTo(array, 0);
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
			if (item.Visible && item.ProcessCmdKey(ref msg, keyData))
			{
				return true;
			}
		}
		return false;
	}

	private void OnRibbonGroupClusterClearing(object sender, EventArgs e)
	{
		foreach (KryptonRibbonGroupItem ribbonClusterItem in _ribbonClusterItems)
		{
			((IRibbonGroupItem)ribbonClusterItem).Ribbon = null;
			((IRibbonGroupItem)ribbonClusterItem).RibbonTab = null;
			((IRibbonGroupItem)ribbonClusterItem).RibbonContainer = null;
		}
	}

	private void OnRibbonGroupClusterCleared(object sender, EventArgs e)
	{
		if (Ribbon != null && RibbonTab != null && Ribbon.SelectedTab == RibbonTab)
		{
			Ribbon.PerformNeedPaint(needLayout: true);
		}
	}

	private void OnRibbonGroupClusterInserted(object sender, TypedCollectionEventArgs<KryptonRibbonGroupItem> e)
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

	private void OnRibbonGroupClusterRemoved(object sender, TypedCollectionEventArgs<KryptonRibbonGroupItem> e)
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
