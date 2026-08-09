#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Ribbon.Properties;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonDesignCluster : ViewDrawRibbonDesignBase
{
	private static readonly Padding _padding;

	private static readonly ImageList _imageList;

	private KryptonRibbonGroupCluster _ribbonCluster;

	private ContextMenuStrip _cms;

	protected override Padding PreferredPadding => _padding;

	protected override Padding LayoutPadding => Padding.Empty;

	protected override Padding OuterPadding => _padding;

	static ViewDrawRibbonDesignCluster()
	{
		_padding = new Padding(1, 2, 0, 2);
		_imageList = new ImageList();
		_imageList.TransparentColor = Color.Magenta;
		_imageList.Images.AddRange(new Image[2]
		{
			Resources.KryptonRibbonGroupClusterButton,
			Resources.KryptonRibbonGroupClusterColorButton
		});
	}

	public ViewDrawRibbonDesignCluster(KryptonRibbon ribbon, KryptonRibbonGroupCluster ribbonCluster, NeedPaintHandler needPaint)
		: base(ribbon, needPaint)
	{
		Debug.Assert(ribbonCluster != null);
		_ribbonCluster = ribbonCluster;
	}

	public override string ToString()
	{
		return "ViewDrawRibbonDesignCluster:" + base.Id;
	}

	public override string GetShortText()
	{
		return "Item";
	}

	protected override void OnClick(object sender, EventArgs e)
	{
		if (_cms == null)
		{
			_cms = new ContextMenuStrip();
			_cms.ImageList = _imageList;
			ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem("Add Cluster Button", null, OnAddButton);
			ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem("Add Cluster Color Button", null, OnAddColorButton);
			toolStripMenuItem.ImageIndex = 0;
			toolStripMenuItem2.ImageIndex = 1;
			_cms.Items.AddRange(new ToolStripItem[2] { toolStripMenuItem, toolStripMenuItem2 });
		}
		if (CommonHelper.ValidContextMenuStrip(_cms))
		{
			Rectangle rectangle = base.Ribbon.ViewRectangleToScreen(this);
			VisualPopupManager.Singleton.ShowContextMenuStrip(_cms, new Point(rectangle.X, rectangle.Bottom));
		}
	}

	private void OnAddButton(object sender, EventArgs e)
	{
		_ribbonCluster.OnDesignTimeAddButton();
	}

	private void OnAddColorButton(object sender, EventArgs e)
	{
		_ribbonCluster.OnDesignTimeAddColorButton();
	}
}
