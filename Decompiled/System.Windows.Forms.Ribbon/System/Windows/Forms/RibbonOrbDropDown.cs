using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace System.Windows.Forms;

public class RibbonOrbDropDown : RibbonPopup
{
	private const bool DefaultAutoSizeContentButtons = true;

	private const int DefaultContentButtonsMinWidth = 150;

	private const int DefaultContentRecentItemsMinWidth = 150;

	internal RibbonOrbMenuItem LastPoppedMenuItem;

	private Rectangle designerSelectedBounds;

	private readonly int glyphGap = 3;

	private Padding _contentMargin;

	private DateTime OpenedTime;

	private string _recentItemsCaption;

	private int _contentButtonsWidth = 150;

	internal List<RibbonItem> AllItems
	{
		get
		{
			List<RibbonItem> list = new List<RibbonItem>();
			list.AddRange(MenuItems);
			list.AddRange(RecentItems);
			list.AddRange(OptionItems);
			return list;
		}
	}

	[Browsable(false)]
	public Padding ContentMargin
	{
		get
		{
			if (_contentMargin.Size.IsEmpty)
			{
				_contentMargin = new Padding(6, 17, 6, 29);
			}
			return _contentMargin;
		}
	}

	[Browsable(false)]
	public Rectangle ContentBounds => Rectangle.FromLTRB(ContentMargin.Left, ContentMargin.Top, base.ClientRectangle.Right - ContentMargin.Right, base.ClientRectangle.Bottom - ContentMargin.Bottom);

	[Browsable(false)]
	public Rectangle ContentButtonsBounds
	{
		get
		{
			Rectangle contentBounds = ContentBounds;
			contentBounds.Width = _contentButtonsWidth;
			if (Ribbon.RightToLeft == RightToLeft.Yes)
			{
				contentBounds.X = ContentBounds.Right - _contentButtonsWidth;
			}
			return contentBounds;
		}
	}

	[DefaultValue(150)]
	public int ContentButtonsMinWidth { get; set; } = 150;

	[Browsable(false)]
	public Rectangle ContentRecentItemsBounds
	{
		get
		{
			Rectangle contentBounds = ContentBounds;
			contentBounds.Width -= _contentButtonsWidth;
			contentBounds.Height -= ContentRecentItemsCaptionBounds.Height;
			contentBounds.Y += ContentRecentItemsCaptionBounds.Height;
			if (Ribbon.RightToLeft == RightToLeft.No)
			{
				contentBounds.X += _contentButtonsWidth;
			}
			return contentBounds;
		}
	}

	[Browsable(false)]
	public Rectangle ContentRecentItemsCaptionBounds
	{
		get
		{
			if (RecentItemsCaption != null)
			{
				SizeF sizeF;
				using (Graphics graphics = CreateGraphics())
				{
					sizeF = graphics.MeasureString(RecentItemsCaption, Ribbon.RibbonTabFont);
				}
				Rectangle contentBounds = ContentBounds;
				contentBounds.Width -= _contentButtonsWidth;
				contentBounds.Height = Convert.ToInt32(sizeF.Height) + Ribbon.ItemMargin.Top + Ribbon.ItemMargin.Bottom;
				contentBounds.Height += RecentItemsCaptionLineSpacing;
				if (Ribbon.RightToLeft == RightToLeft.No)
				{
					contentBounds.X += _contentButtonsWidth;
				}
				return contentBounds;
			}
			return Rectangle.Empty;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int RecentItemsCaptionLineSpacing { get; } = 8;

	[DefaultValue(150)]
	public int ContentRecentItemsMinWidth { get; set; } = 150;

	private bool RibbonInDesignMode => RibbonDesigner.Current != null;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public RibbonOrbMenuItemCollection MenuItems { get; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public RibbonOrbOptionButtonCollection OptionItems { get; }

	[DefaultValue(6)]
	[Description("Spacing between option buttons (those on the bottom)")]
	public int OptionItemsPadding { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public RibbonOrbRecentItemCollection RecentItems { get; }

	[DefaultValue(null)]
	public string RecentItemsCaption
	{
		get
		{
			return _recentItemsCaption;
		}
		set
		{
			_recentItemsCaption = value;
			Invalidate();
		}
	}

	[Browsable(false)]
	public Ribbon Ribbon { get; }

	[Browsable(false)]
	public RibbonMouseSensor Sensor { get; private set; }

	internal Rectangle ButtonsGlyphBounds
	{
		get
		{
			Size size = new Size(50, 18);
			Rectangle contentButtonsBounds = ContentButtonsBounds;
			Rectangle result = new Rectangle(contentButtonsBounds.Left + (contentButtonsBounds.Width - size.Width * 2) / 2, contentButtonsBounds.Top + glyphGap, size.Width, size.Height);
			if (MenuItems.Count > 0)
			{
				result.Y = MenuItems[MenuItems.Count - 1].Bounds.Bottom + glyphGap;
			}
			return result;
		}
	}

	internal Rectangle ButtonsSeparatorGlyphBounds
	{
		get
		{
			new Size(18, 18);
			Rectangle buttonsGlyphBounds = ButtonsGlyphBounds;
			buttonsGlyphBounds.X = buttonsGlyphBounds.Right + glyphGap;
			return buttonsGlyphBounds;
		}
	}

	internal Rectangle RecentGlyphBounds
	{
		get
		{
			Size size = new Size(50, 18);
			Rectangle contentRecentItemsBounds = ContentRecentItemsBounds;
			Rectangle result = new Rectangle(contentRecentItemsBounds.Left + glyphGap, contentRecentItemsBounds.Top + glyphGap, size.Width, size.Height);
			if (RecentItems.Count > 0)
			{
				result.Y = RecentItems[RecentItems.Count - 1].Bounds.Bottom + glyphGap;
			}
			return result;
		}
	}

	internal Rectangle OptionGlyphBounds
	{
		get
		{
			Size size = new Size(50, 18);
			Rectangle contentBounds = ContentBounds;
			Rectangle result = new Rectangle(contentBounds.Right - size.Width, contentBounds.Bottom + glyphGap, size.Width, size.Height);
			if (OptionItems.Count > 0)
			{
				result.X = OptionItems[OptionItems.Count - 1].Bounds.Left - size.Width - glyphGap;
			}
			return result;
		}
	}

	[DefaultValue(true)]
	public bool AutoSizeContentButtons { get; set; } = true;

	internal RibbonOrbDropDown(Ribbon ribbon)
	{
		DoubleBuffered = true;
		Ribbon = ribbon;
		MenuItems = new RibbonOrbMenuItemCollection();
		RecentItems = new RibbonOrbRecentItemCollection();
		OptionItems = new RibbonOrbOptionButtonCollection();
		MenuItems.SetOwner(Ribbon);
		RecentItems.SetOwner(Ribbon);
		OptionItems.SetOwner(Ribbon);
		OptionItemsPadding = 6;
		base.Size = new Size(527, 447);
		base.BorderRoundness = 8;
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
		if (Sensor != null && !Sensor.Disposed)
		{
			Sensor.Dispose();
		}
	}

	internal void HandleDesignerItemRemoved(RibbonItem item)
	{
		if (MenuItems.Contains(item))
		{
			MenuItems.Remove(item);
		}
		else if (RecentItems.Contains(item))
		{
			RecentItems.Remove(item);
		}
		else if (OptionItems.Contains(item))
		{
			OptionItems.Remove(item);
		}
		OnRegionsChanged();
	}

	private int SeparatorHeight(RibbonSeparator s)
	{
		if (!string.IsNullOrEmpty(s.Text))
		{
			return 20;
		}
		return 3;
	}

	private void UpdateRegions()
	{
		int num = 0;
		int num2 = 0;
		int num3 = 44;
		int num4 = 22;
		int num5 = 1;
		int num6 = 1;
		int num7 = 0;
		int num8 = 0;
		if (AutoSizeContentButtons)
		{
			int num9 = 0;
			using (Graphics graphics = CreateGraphics())
			{
				foreach (RibbonItem menuItem in MenuItems)
				{
					int num10 = menuItem.MeasureSize(this, new RibbonElementMeasureSizeEventArgs(graphics, RibbonElementSizeMode.DropDown)).Width;
					if (num10 > num9)
					{
						num9 = num10;
					}
				}
			}
			num9 = Math.Min(num9, ContentBounds.Width - ContentRecentItemsMinWidth);
			num9 = Math.Max(num9, ContentButtonsMinWidth);
			_contentButtonsWidth = num9;
		}
		Rectangle contentBounds = ContentBounds;
		Rectangle contentButtonsBounds = ContentButtonsBounds;
		Rectangle contentRecentItemsBounds = ContentRecentItemsBounds;
		foreach (RibbonItem allItem in AllItems)
		{
			allItem.SetSizeMode(RibbonElementSizeMode.DropDown);
			allItem.SetCanvas(this);
		}
		num = contentBounds.Top + 1;
		foreach (RibbonItem menuItem2 in MenuItems)
		{
			Rectangle bounds = new Rectangle(contentButtonsBounds.Left + num5, num, contentButtonsBounds.Width - num5 * 2, num3);
			if (menuItem2 is RibbonSeparator)
			{
				bounds.Height = SeparatorHeight(menuItem2 as RibbonSeparator);
			}
			menuItem2.SetBounds(bounds);
			num += bounds.Height;
		}
		num7 = num - contentBounds.Top + 1;
		num = contentRecentItemsBounds.Top;
		foreach (RibbonItem recentItem in RecentItems)
		{
			Rectangle bounds2 = new Rectangle(contentRecentItemsBounds.Left + num6, num, contentRecentItemsBounds.Width - num6 * 2, num4);
			if (recentItem is RibbonSeparator)
			{
				bounds2.Height = SeparatorHeight(recentItem as RibbonSeparator);
			}
			recentItem.SetBounds(bounds2);
			num += bounds2.Height;
		}
		num8 = num - contentButtonsBounds.Top;
		int num11 = Math.Max(num7, num8);
		if (RibbonDesigner.Current != null)
		{
			num11 += ButtonsGlyphBounds.Height + glyphGap * 2;
		}
		base.Height = num11 + ContentMargin.Vertical;
		contentBounds = ContentBounds;
		num2 = base.ClientSize.Width - ContentMargin.Right;
		using Graphics graphics2 = CreateGraphics();
		foreach (RibbonItem optionItem in OptionItems)
		{
			Size size = optionItem.MeasureSize(this, new RibbonElementMeasureSizeEventArgs(graphics2, RibbonElementSizeMode.DropDown));
			optionItem.SetBounds(new Rectangle(new Point(y: contentBounds.Bottom + (ContentMargin.Bottom - size.Height) / 2, x: num2 - size.Width), size));
			num2 = optionItem.Bounds.Left - OptionItemsPadding;
		}
	}

	private void UpdateSensor()
	{
		if (Sensor != null && !Sensor.Disposed)
		{
			Sensor.Dispose();
		}
		Sensor = new RibbonMouseSensor(this, Ribbon, AllItems);
	}

	internal void OnRegionsChanged()
	{
		UpdateRegions();
		UpdateSensor();
		UpdateDesignerSelectedBounds();
		Invalidate();
	}

	internal void SelectOnDesigner(RibbonItem item)
	{
		if (RibbonDesigner.Current != null)
		{
			RibbonDesigner.Current.SelectedElement = item;
			UpdateDesignerSelectedBounds();
			Invalidate();
		}
	}

	internal void UpdateDesignerSelectedBounds()
	{
		designerSelectedBounds = Rectangle.Empty;
		if (RibbonInDesignMode && RibbonDesigner.Current.SelectedElement is RibbonItem ribbonItem && AllItems.Contains(ribbonItem))
		{
			designerSelectedBounds = ribbonItem.Bounds;
		}
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		base.OnMouseDown(e);
		if (!RibbonInDesignMode)
		{
			return;
		}
		if (ContentBounds.Contains(e.Location))
		{
			if (ContentButtonsBounds.Contains(e.Location))
			{
				foreach (RibbonItem menuItem in MenuItems)
				{
					if (menuItem.Bounds.Contains(e.Location))
					{
						SelectOnDesigner(menuItem);
						break;
					}
				}
			}
			else if (ContentRecentItemsBounds.Contains(e.Location))
			{
				foreach (RibbonItem recentItem in RecentItems)
				{
					if (recentItem.Bounds.Contains(e.Location))
					{
						SelectOnDesigner(recentItem);
						break;
					}
				}
			}
		}
		if (ButtonsGlyphBounds.Contains(e.Location))
		{
			RibbonDesigner.Current.CreateOrbMenuItem(typeof(RibbonOrbMenuItem));
			return;
		}
		if (ButtonsSeparatorGlyphBounds.Contains(e.Location))
		{
			RibbonDesigner.Current.CreateOrbMenuItem(typeof(RibbonSeparator));
			return;
		}
		if (RecentGlyphBounds.Contains(e.Location))
		{
			RibbonDesigner.Current.CreateOrbRecentItem(typeof(RibbonOrbRecentItem));
			return;
		}
		if (OptionGlyphBounds.Contains(e.Location))
		{
			RibbonDesigner.Current.CreateOrbOptionItem(typeof(RibbonOrbOptionButton));
			return;
		}
		foreach (RibbonItem optionItem in OptionItems)
		{
			if (optionItem.Bounds.Contains(e.Location))
			{
				SelectOnDesigner(optionItem);
				break;
			}
		}
	}

	protected override void OnOpening(CancelEventArgs e)
	{
		base.OnOpening(e);
		UpdateRegions();
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		base.OnPaint(e);
		Ribbon.Renderer.OnRenderOrbDropDownBackground(new RibbonOrbDropDownEventArgs(Ribbon, this, e.Graphics, e.ClipRectangle));
		foreach (RibbonItem allItem in AllItems)
		{
			allItem.OnPaint(this, new RibbonElementPaintEventArgs(e.ClipRectangle, e.Graphics, RibbonElementSizeMode.DropDown));
		}
		if (RibbonInDesignMode)
		{
			using (SolidBrush brush = new SolidBrush(Color.FromArgb(50, Color.Blue)))
			{
				e.Graphics.FillRectangle(brush, ButtonsGlyphBounds);
				e.Graphics.FillRectangle(brush, RecentGlyphBounds);
				e.Graphics.FillRectangle(brush, OptionGlyphBounds);
				e.Graphics.FillRectangle(brush, ButtonsSeparatorGlyphBounds);
			}
			using (StringFormat format = StringFormatFactory.Center(StringTrimming.None))
			{
				e.Graphics.DrawString("+", Font, Brushes.White, ButtonsGlyphBounds, format);
				e.Graphics.DrawString("+", Font, Brushes.White, RecentGlyphBounds, format);
				e.Graphics.DrawString("+", Font, Brushes.White, OptionGlyphBounds, format);
				e.Graphics.DrawString("---", Font, Brushes.White, ButtonsSeparatorGlyphBounds, format);
			}
			using Pen pen = new Pen(Color.Black);
			pen.DashStyle = DashStyle.Dot;
			e.Graphics.DrawRectangle(pen, designerSelectedBounds);
		}
	}

	protected override void OnClosed(EventArgs e)
	{
		Ribbon.OrbPressed = false;
		Ribbon.OrbSelected = false;
		LastPoppedMenuItem = null;
		foreach (RibbonItem allItem in AllItems)
		{
			allItem.SetSelected(selected: false);
			allItem.SetPressed(pressed: false);
		}
		base.OnClosed(e);
	}

	protected override void OnShowed(EventArgs e)
	{
		base.OnShowed(e);
		OpenedTime = DateTime.Now;
		UpdateSensor();
	}

	protected override void OnMouseClick(MouseEventArgs e)
	{
		if (Ribbon.RectangleToScreen(Ribbon.OrbBounds).Contains(PointToScreen(e.Location)))
		{
			Ribbon.OnOrbClicked(EventArgs.Empty);
			if (DateTime.Compare(DateTime.Now, OpenedTime.AddMilliseconds(SystemInformation.DoubleClickTime)) < 0)
			{
				Ribbon.OnOrbDoubleClicked(EventArgs.Empty);
			}
		}
		base.OnMouseClick(e);
	}

	protected override void OnMouseDoubleClick(MouseEventArgs e)
	{
		base.OnMouseDoubleClick(e);
		if (Ribbon.RectangleToScreen(Ribbon.OrbBounds).Contains(PointToScreen(e.Location)))
		{
			Ribbon.OnOrbDoubleClicked(EventArgs.Empty);
		}
	}

	private void _keyboardHook_KeyUp(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Down)
		{
			RibbonItem ribbonItem = null;
			RibbonItem ribbonItem2 = null;
			foreach (RibbonItem menuItem in MenuItems)
			{
				if (menuItem.Selected)
				{
					ribbonItem2 = menuItem;
					break;
				}
			}
			if (ribbonItem2 != null)
			{
				int num = MenuItems.IndexOf(ribbonItem2);
				ribbonItem = GetNextSelectableMenuItem(num + 1);
			}
			else
			{
				foreach (RibbonItem recentItem in RecentItems)
				{
					if (recentItem.Selected)
					{
						ribbonItem2 = recentItem;
						recentItem.SetSelected(selected: false);
						recentItem.RedrawItem();
						break;
					}
				}
				if (ribbonItem2 != null)
				{
					int num2 = RecentItems.IndexOf(ribbonItem2);
					ribbonItem = GetNextSelectableRecentItem(num2 + 1);
				}
				else
				{
					foreach (RibbonItem optionItem in OptionItems)
					{
						if (optionItem.Selected)
						{
							ribbonItem2 = optionItem;
							optionItem.SetSelected(selected: false);
							optionItem.RedrawItem();
							break;
						}
					}
					if (ribbonItem2 != null)
					{
						int num3 = OptionItems.IndexOf(ribbonItem2);
						ribbonItem = GetNextSelectableOptionItem(num3 + 1);
					}
				}
			}
			if (ribbonItem2 == null)
			{
				ribbonItem = GetNextSelectableMenuItem(0);
				if (ribbonItem != null)
				{
					ribbonItem.SetSelected(selected: true);
					ribbonItem.RedrawItem();
				}
			}
			else
			{
				ribbonItem2.SetSelected(selected: false);
				ribbonItem2.RedrawItem();
				ribbonItem.SetSelected(selected: true);
				ribbonItem.RedrawItem();
			}
		}
		else
		{
			_ = e.KeyCode;
			_ = 38;
		}
	}

	private RibbonItem GetNextSelectableMenuItem(int StartIndex)
	{
		for (int i = StartIndex; i < MenuItems.Count; i++)
		{
			if (MenuItems[i] is RibbonButton result)
			{
				return result;
			}
		}
		RibbonItem ribbonItem = GetNextSelectableRecentItem(0);
		if (ribbonItem == null)
		{
			ribbonItem = GetNextSelectableOptionItem(0);
			if (ribbonItem == null)
			{
				ribbonItem = GetNextSelectableMenuItem(0);
			}
		}
		return ribbonItem;
	}

	private RibbonItem GetNextSelectableRecentItem(int StartIndex)
	{
		for (int i = StartIndex; i < RecentItems.Count; i++)
		{
			if (RecentItems[i] is RibbonButton result)
			{
				return result;
			}
		}
		RibbonItem ribbonItem = GetNextSelectableOptionItem(0);
		if (ribbonItem == null)
		{
			ribbonItem = GetNextSelectableMenuItem(0);
			if (ribbonItem == null)
			{
				ribbonItem = GetNextSelectableRecentItem(0);
			}
		}
		return ribbonItem;
	}

	private RibbonItem GetNextSelectableOptionItem(int StartIndex)
	{
		for (int i = StartIndex; i < OptionItems.Count; i++)
		{
			if (OptionItems[i] is RibbonButton result)
			{
				return result;
			}
		}
		RibbonItem ribbonItem = GetNextSelectableMenuItem(0);
		if (ribbonItem == null)
		{
			ribbonItem = GetNextSelectableRecentItem(0);
			if (ribbonItem == null)
			{
				ribbonItem = GetNextSelectableOptionItem(0);
			}
		}
		return ribbonItem;
	}
}
