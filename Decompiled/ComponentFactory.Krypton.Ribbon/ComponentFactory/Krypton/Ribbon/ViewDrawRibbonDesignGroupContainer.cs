#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Ribbon.Properties;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonDesignGroupContainer : ViewDrawRibbonDesignBase
{
	private static readonly Padding _padding;

	private static readonly ImageList _imageList;

	private KryptonRibbonGroup _ribbonGroup;

	private ContextMenuStrip _cms;

	protected override Padding PreferredPadding => _padding;

	protected override Padding LayoutPadding => Padding.Empty;

	protected override Padding OuterPadding => _padding;

	static ViewDrawRibbonDesignGroupContainer()
	{
		_padding = new Padding(1, 0, 0, 0);
		_imageList = new ImageList();
		_imageList.TransparentColor = Color.Magenta;
		_imageList.Images.AddRange(new Image[4]
		{
			Resources.KryptonRibbonGroupTriple,
			Resources.KryptonRibbonGroupLines,
			Resources.KryptonRibbonGroupSeparator,
			Resources.KryptonGallery
		});
	}

	public ViewDrawRibbonDesignGroupContainer(KryptonRibbon ribbon, KryptonRibbonGroup ribbonGroup, NeedPaintHandler needPaint)
		: base(ribbon, needPaint)
	{
		Debug.Assert(ribbonGroup != null);
		_ribbonGroup = ribbonGroup;
	}

	public override string ToString()
	{
		return "ViewDrawRibbonDesignGroupContainer:" + base.Id;
	}

	public override string GetShortText()
	{
		return "New";
	}

	protected override void OnClick(object sender, EventArgs e)
	{
		if (_cms == null)
		{
			_cms = new ContextMenuStrip();
			_cms.ImageList = _imageList;
			ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem("Add Triple", null, OnAddTriple);
			ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem("Add Lines", null, OnAddLines);
			ToolStripMenuItem toolStripMenuItem3 = new ToolStripMenuItem("Add Separator", null, OnAddSeparator);
			ToolStripMenuItem toolStripMenuItem4 = new ToolStripMenuItem("Add Gallery", null, OnAddGallery);
			toolStripMenuItem.ImageIndex = 0;
			toolStripMenuItem2.ImageIndex = 1;
			toolStripMenuItem3.ImageIndex = 2;
			toolStripMenuItem4.ImageIndex = 3;
			_cms.Items.AddRange(new ToolStripItem[4] { toolStripMenuItem, toolStripMenuItem2, toolStripMenuItem3, toolStripMenuItem4 });
		}
		if (CommonHelper.ValidContextMenuStrip(_cms))
		{
			Rectangle rectangle = base.Ribbon.ViewRectangleToScreen(this);
			VisualPopupManager.Singleton.ShowContextMenuStrip(_cms, new Point(rectangle.X, rectangle.Bottom));
		}
	}

	private void OnAddTriple(object sender, EventArgs e)
	{
		_ribbonGroup.OnDesignTimeAddTriple();
	}

	private void OnAddLines(object sender, EventArgs e)
	{
		_ribbonGroup.OnDesignTimeAddLines();
	}

	private void OnAddSeparator(object sender, EventArgs e)
	{
		_ribbonGroup.OnDesignTimeAddSeparator();
	}

	private void OnAddGallery(object sender, EventArgs e)
	{
		_ribbonGroup.OnDesignTimeAddGallery();
	}
}
