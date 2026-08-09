using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace System.Windows.Forms;

[Designer(typeof(RibbonItemGroupDesigner))]
public class RibbonItemGroup : RibbonItem, IContainsSelectableRibbonItems, IContainsRibbonComponents
{
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override bool Checked
	{
		get
		{
			return base.Checked;
		}
		set
		{
			base.Checked = value;
		}
	}

	[DefaultValue(true)]
	[Category("Appearance")]
	[Description("Background drawing should be avoided when group contains only TextBoxes and ComboBoxes")]
	public bool DrawBackground { get; set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public RibbonItem FirstItem
	{
		get
		{
			if (Items.Count > 0)
			{
				return Items[0];
			}
			return null;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public RibbonItem LastItem
	{
		get
		{
			if (Items.Count > 0)
			{
				return Items[Items.Count - 1];
			}
			return null;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public RibbonItemGroupItemCollection Items { get; }

	public RibbonItemGroup()
	{
		Items = new RibbonItemGroupItemCollection(this);
		Items.SetOwnerItem(this);
		DrawBackground = true;
	}

	public RibbonItemGroup(IEnumerable<RibbonItem> items)
		: this()
	{
		Items.AddRange(items);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && RibbonDesigner.Current == null)
		{
			try
			{
				foreach (RibbonItem item in Items)
				{
					item.Dispose();
				}
			}
			catch (InvalidOperationException)
			{
				if (!IsOpenInVisualStudioDesigner())
				{
					throw;
				}
			}
		}
		base.Dispose(disposing);
	}

	protected override bool ClosesDropDownAt(Point p)
	{
		return false;
	}

	public override void SetBounds(Rectangle bounds)
	{
		base.SetBounds(bounds);
		int x = bounds.Left;
		foreach (RibbonItem item in Items)
		{
			item.SetBounds(new Rectangle(new Point(x, bounds.Top), item.LastMeasuredSize));
			x = item.Bounds.Right + 1;
		}
	}

	public override void OnPaint(object sender, RibbonElementPaintEventArgs e)
	{
		if (DrawBackground)
		{
			base.Owner.Renderer.OnRenderRibbonItem(new RibbonItemRenderEventArgs(base.Owner, e.Graphics, e.Clip, this));
		}
		foreach (RibbonItem item in Items)
		{
			if (item.Visible || base.Owner.IsDesignMode())
			{
				item.OnPaint(this, new RibbonElementPaintEventArgs(item.Bounds, e.Graphics, RibbonElementSizeMode.Compact));
			}
		}
		if (DrawBackground)
		{
			base.Owner.Renderer.OnRenderRibbonItemBorder(new RibbonItemRenderEventArgs(base.Owner, e.Graphics, e.Clip, this));
		}
	}

	public override Size MeasureSize(object sender, RibbonElementMeasureSizeEventArgs e)
	{
		if (!Visible && !base.Owner.IsDesignMode())
		{
			SetLastMeasuredSize(new Size(0, 0));
			return base.LastMeasuredSize;
		}
		int val = 16;
		int num = 0;
		int num2 = 16;
		foreach (RibbonItem item in Items)
		{
			Size size = item.MeasureSize(this, new RibbonElementMeasureSizeEventArgs(e.Graphics, RibbonElementSizeMode.Compact));
			num += size.Width + 1;
			num2 = Math.Max(num2, size.Height);
		}
		num--;
		num = Math.Max(num, val);
		if (Site != null && Site.DesignMode)
		{
			num += 10;
		}
		Size size2 = new Size(num, num2);
		SetLastMeasuredSize(size2);
		return size2;
	}

	internal override void SetOwnerPanel(RibbonPanel ownerPanel)
	{
		base.SetOwnerPanel(ownerPanel);
		Items.SetOwnerPanel(ownerPanel);
	}

	internal override void SetOwner(Ribbon owner)
	{
		base.SetOwner(owner);
		Items.SetOwner(owner);
	}

	internal override void SetOwnerTab(RibbonTab ownerTab)
	{
		base.SetOwnerTab(ownerTab);
		Items.SetOwnerTab(ownerTab);
	}

	internal override void SetOwnerItem(RibbonItem ownerItem)
	{
		base.SetOwnerItem(ownerItem);
	}

	internal override void ClearOwner()
	{
		List<RibbonItem> list = new List<RibbonItem>(Items);
		base.ClearOwner();
		foreach (RibbonItem item in list)
		{
			item.ClearOwner();
		}
	}

	internal override void SetSizeMode(RibbonElementSizeMode sizeMode)
	{
		base.SetSizeMode(sizeMode);
		foreach (RibbonItem item in Items)
		{
			item.SetSizeMode(RibbonElementSizeMode.Compact);
		}
	}

	public override string ToString()
	{
		return "Group: " + Items.Count + " item(s)";
	}

	public IEnumerable<RibbonItem> GetItems()
	{
		return Items;
	}

	public Rectangle GetContentBounds()
	{
		return Rectangle.FromLTRB(base.Bounds.Left + 1, base.Bounds.Top + 1, base.Bounds.Right - 1, base.Bounds.Bottom);
	}

	public IEnumerable<Component> GetAllChildComponents()
	{
		return Items.ToArray();
	}
}
