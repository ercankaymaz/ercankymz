using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace System.Windows.Forms;

public class RibbonQuickAccessToolbar : RibbonItem, IContainsSelectableRibbonItems, IContainsRibbonComponents
{
	private readonly RibbonQuickAccessToolbarItemCollection _items;

	private bool _dropDownButtonVisible;

	private RibbonMouseSensor _sensor;

	private RibbonButton _dropDownButton;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override string Name
	{
		get
		{
			return base.Name;
		}
		set
		{
			base.Name = value;
		}
	}

	[Description("Shows or hides the dropdown button of the toolbar")]
	[Category("Drop Down")]
	[DefaultValue(true)]
	public bool DropDownButtonVisible
	{
		get
		{
			return _dropDownButtonVisible;
		}
		set
		{
			_dropDownButtonVisible = value;
			base.Owner.OnRegionsChanged();
		}
	}

	[Browsable(false)]
	internal Rectangle SuperBounds => Rectangle.FromLTRB(base.Bounds.Left - Padding.Horizontal, base.Bounds.Top, DropDownButton.Bounds.Right, base.Bounds.Bottom);

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public RibbonButton DropDownButton => _dropDownButton;

	[Description("The drop down items of the dropdown button of the toolbar")]
	[Category("Drop Down")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public RibbonItemCollection DropDownButtonItems => DropDownButton.DropDownItems;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Padding Padding { get; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Padding Margin { get; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool MenuButtonVisible { get; set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public RibbonMouseSensor Sensor => _sensor;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public RibbonQuickAccessToolbarItemCollection Items
	{
		get
		{
			if (DropDownButtonVisible)
			{
				if (!_items.Contains(DropDownButton))
				{
					_items.Add(DropDownButton);
				}
			}
			else if (_items.Contains(DropDownButton))
			{
				_items.Remove(DropDownButton);
			}
			return _items;
		}
	}

	internal RibbonQuickAccessToolbar(Ribbon ownerRibbon)
	{
		if (ownerRibbon == null)
		{
			throw new ArgumentNullException("ownerRibbon");
		}
		SetOwner(ownerRibbon);
		_dropDownButton = new RibbonButton();
		_dropDownButton.SetOwner(ownerRibbon);
		_dropDownButton.SmallImage = CreateDropDownButtonImage();
		_dropDownButton.Style = RibbonButtonStyle.DropDown;
		Margin = new Padding(9);
		Padding = new Padding(3, 0, 0, 0);
		_items = new RibbonQuickAccessToolbarItemCollection(this);
		_sensor = new RibbonMouseSensor(ownerRibbon, ownerRibbon, Items);
		_dropDownButtonVisible = true;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && RibbonDesigner.Current == null)
		{
			try
			{
				foreach (RibbonItem item in _items)
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
			_dropDownButton.Dispose();
			_sensor.Dispose();
		}
		base.Dispose(disposing);
	}

	private Image CreateDropDownButtonImage()
	{
		Bitmap bitmap = new Bitmap(7, 7);
		RibbonProfessionalRenderer ribbonProfessionalRenderer = base.Owner.Renderer as RibbonProfessionalRenderer;
		Color c = Color.Navy;
		Color c2 = Color.White;
		if (ribbonProfessionalRenderer != null)
		{
			c = ribbonProfessionalRenderer.ColorTable.Arrow;
			c2 = ribbonProfessionalRenderer.ColorTable.ArrowLight;
		}
		using Graphics g = Graphics.FromImage(bitmap);
		DrawDropDownButtonArrow(g, c2, 0, 1);
		DrawDropDownButtonArrow(g, c, 0, 0);
		return bitmap;
	}

	private void DrawDropDownButtonArrow(Graphics g, Color c, int x, int y)
	{
		using Pen pen = new Pen(c);
		using SolidBrush brush = new SolidBrush(c);
		g.DrawLine(pen, x, y, x + 4, y);
		g.FillPolygon(brush, new Point[3]
		{
			new Point(x, y + 3),
			new Point(x + 5, y + 3),
			new Point(x + 2, y + 6)
		});
	}

	public override void OnPaint(object sender, RibbonElementPaintEventArgs e)
	{
		if (!Visible || !base.Owner.CaptionBarVisible)
		{
			return;
		}
		if (base.Owner.OrbStyle == RibbonOrbStyle.Office_2007)
		{
			base.Owner.Renderer.OnRenderRibbonQuickAccessToolbarBackground(new RibbonRenderEventArgs(base.Owner, e.Graphics, e.Clip));
		}
		foreach (RibbonItem item in Items)
		{
			if (item.Visible)
			{
				item.OnPaint(this, new RibbonElementPaintEventArgs(item.Bounds, e.Graphics, RibbonElementSizeMode.Compact));
			}
		}
	}

	public override Size MeasureSize(object sender, RibbonElementMeasureSizeEventArgs e)
	{
		if (!Visible || !base.Owner.CaptionBarVisible)
		{
			SetLastMeasuredSize(new Size(0, 0));
			return base.LastMeasuredSize;
		}
		int num = Padding.Horizontal;
		int num2 = 16;
		foreach (RibbonItem item in Items)
		{
			if (!item.Equals(DropDownButton))
			{
				item.SetSizeMode(RibbonElementSizeMode.Compact);
				Size size = item.MeasureSize(this, new RibbonElementMeasureSizeEventArgs(e.Graphics, RibbonElementSizeMode.Compact));
				num += size.Width + 1;
				num2 = Math.Max(num2, size.Height);
			}
		}
		num--;
		if (Site != null && Site.DesignMode)
		{
			num += 16;
		}
		Size size2 = new Size(num, num2);
		SetLastMeasuredSize(size2);
		return size2;
	}

	public override void SetBounds(Rectangle bounds)
	{
		base.SetBounds(bounds);
		if (base.Owner.RightToLeft == RightToLeft.No)
		{
			int x = bounds.Left + Padding.Left;
			foreach (RibbonItem item in Items)
			{
				item.SetBounds(new Rectangle(new Point(x, bounds.Top), item.LastMeasuredSize));
				x = item.Bounds.Right + 1;
			}
			if (DropDownButtonVisible)
			{
				DropDownButton.SetBounds(new Rectangle(bounds.Right + bounds.Height / 2 + 2, bounds.Top, 12, bounds.Height));
			}
		}
		else
		{
			int x2 = bounds.Left + Padding.Left;
			for (int num = Items.Count - 1; num >= 0; num--)
			{
				Items[num].SetBounds(new Rectangle(new Point(x2, bounds.Top), Items[num].LastMeasuredSize));
				x2 = Items[num].Bounds.Right + 1;
			}
			if (DropDownButtonVisible)
			{
				DropDownButton.SetBounds(new Rectangle(bounds.Left - bounds.Height / 2 - 14, bounds.Top, 12, bounds.Height));
			}
		}
	}

	public IEnumerable<Component> GetAllChildComponents()
	{
		return Items.ToArray();
	}

	public IEnumerable<RibbonItem> GetItems()
	{
		return Items;
	}

	public Rectangle GetContentBounds()
	{
		return base.Bounds;
	}
}
