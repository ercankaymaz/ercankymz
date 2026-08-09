using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

[ToolboxItem(false)]
[DesignerCategory("code")]
[DesignTimeVisible(false)]
public abstract class KryptonRibbonGroupItem : Component, IRibbonGroupItem
{
	private object _tag;

	private KryptonRibbon _ribbon;

	private KryptonRibbonTab _ribbonTab;

	private KryptonRibbonGroupContainer _ribbonContainer;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual KryptonRibbon Ribbon
	{
		get
		{
			return _ribbon;
		}
		set
		{
			_ribbon = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual KryptonRibbonTab RibbonTab
	{
		get
		{
			return _ribbonTab;
		}
		set
		{
			_ribbonTab = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual KryptonRibbonGroupContainer RibbonContainer
	{
		get
		{
			return _ribbonContainer;
		}
		set
		{
			_ribbonContainer = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public abstract bool Visible { get; set; }

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public abstract GroupItemSize ItemSizeMaximum { get; set; }

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public abstract GroupItemSize ItemSizeMinimum { get; set; }

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public abstract GroupItemSize ItemSizeCurrent { get; set; }

	[Category("Data")]
	[Description("User-defined data associated with the object.")]
	[TypeConverter(typeof(StringConverter))]
	[Bindable(true)]
	public object Tag
	{
		get
		{
			return _tag;
		}
		set
		{
			if (value != _tag)
			{
				_tag = value;
			}
		}
	}

	protected bool ChainVisible
	{
		get
		{
			for (KryptonRibbonGroupContainer ribbonContainer = RibbonContainer; ribbonContainer != null; ribbonContainer = ribbonContainer.RibbonContainer)
			{
				if (!ribbonContainer.Visible)
				{
					return false;
				}
			}
			return true;
		}
	}

	internal virtual Image InternalToolTipImage => null;

	internal virtual LabelStyle InternalToolTipStyle => LabelStyle.SuperTip;

	internal virtual Color InternalToolTipImageTransparentColor => Color.Empty;

	internal virtual string InternalToolTipTitle => string.Empty;

	internal virtual string InternalToolTipBody => string.Empty;

	public KryptonRibbonGroupItem()
	{
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual int ItemGap(IRibbonGroupItem previousItem)
	{
		if (previousItem is KryptonRibbonGroupCluster)
		{
			return 3;
		}
		return 1;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public abstract ViewBase CreateView(KryptonRibbon ribbon, NeedPaintHandler needPaint);

	private bool ShouldSerializeTag()
	{
		return Tag != null;
	}

	private void ResetTag()
	{
		Tag = null;
	}

	internal abstract bool ProcessCmdKey(ref Message msg, Keys keyData);
}
