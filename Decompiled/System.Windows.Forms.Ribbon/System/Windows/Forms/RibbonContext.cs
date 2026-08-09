using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace System.Windows.Forms;

[ToolboxItem(false)]
[DesignTimeVisible(false)]
public class RibbonContext : Component, IRibbonElement
{
	private string _text;

	private Color _glowColor;

	private bool _visible;

	[Category("Appearance")]
	public string Text
	{
		get
		{
			return _text;
		}
		set
		{
			_text = value;
			if (Owner != null)
			{
				Owner.OnRegionsChanged();
			}
		}
	}

	[Category("Appearance")]
	public Color GlowColor
	{
		get
		{
			return _glowColor;
		}
		set
		{
			_glowColor = value;
			if (Owner != null)
			{
				Owner.OnRegionsChanged();
			}
		}
	}

	[Category("Behavior")]
	[DefaultValue(false)]
	public bool Visible
	{
		get
		{
			if (Owner != null && !Owner.IsDesignMode() && !Owner.Visible)
			{
				return false;
			}
			return _visible;
		}
		set
		{
			_visible = value;
			if (Owner != null)
			{
				if (_visible)
				{
					if (ContextualTabsCount > 0)
					{
						Owner.ActiveTab = ContextualTabs[0];
					}
				}
				else
				{
					Owner.ActiveTab = Owner.Tabs[0];
				}
			}
			if (Owner != null)
			{
				Owner.OnRegionsChanged();
			}
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Rectangle Bounds { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Rectangle HeaderBounds { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public List<RibbonTab> ContextualTabs
	{
		get
		{
			List<RibbonTab> list = new List<RibbonTab>();
			foreach (RibbonTab tab in Owner.Tabs)
			{
				if (tab.Context == this)
				{
					list.Add(tab);
				}
			}
			return list;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int ContextualTabsCount
	{
		get
		{
			int num = 0;
			foreach (RibbonTab tab in Owner.Tabs)
			{
				if (tab.Context == this)
				{
					num++;
				}
			}
			return num;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Ribbon Owner { get; private set; }

	public event EventHandler OwnerChanged;

	public void SetBounds(Rectangle bounds)
	{
		Bounds = bounds;
	}

	public void SetHeaderBounds(Rectangle bounds)
	{
		HeaderBounds = bounds;
	}

	internal void SetOwner(Ribbon owner)
	{
		Owner = owner;
	}

	internal virtual void ClearOwner()
	{
		Owner = null;
		OnOwnerChanged(EventArgs.Empty);
	}

	public Size MeasureSize(object sender, RibbonElementMeasureSizeEventArgs e)
	{
		if (!Visible && !Owner.IsDesignMode())
		{
			return new Size(0, 0);
		}
		return Size.Ceiling(e.Graphics.MeasureString(string.IsNullOrEmpty(Text) ? "   " : Text, Owner.Font));
	}

	public void OnPaint(object sender, RibbonElementPaintEventArgs e)
	{
		if (Owner != null && (ContextualTabsCount > 0 || Owner.IsDesignMode()))
		{
			Owner.Renderer.OnRenderRibbonContext(new RibbonContextRenderEventArgs(Owner, e.Graphics, e.Clip, this));
			Owner.Renderer.OnRenderRibbonContextText(new RibbonContextRenderEventArgs(Owner, e.Graphics, e.Clip, this));
		}
	}

	public void OnOwnerChanged(EventArgs e)
	{
		if (this.OwnerChanged != null)
		{
			this.OwnerChanged(this, e);
		}
	}
}
