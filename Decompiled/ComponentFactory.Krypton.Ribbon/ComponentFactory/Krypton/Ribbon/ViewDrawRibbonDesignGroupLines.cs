#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Ribbon.Properties;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonDesignGroupLines : ViewDrawRibbonDesignBase
{
	private static readonly Padding _padding;

	private static readonly ImageList _imageList;

	private KryptonRibbonGroupLines _ribbonLines;

	private ContextMenuStrip _cms;

	private GroupItemSize _currentSize;

	public GroupItemSize CurrentSize
	{
		get
		{
			return _currentSize;
		}
		set
		{
			_currentSize = value;
		}
	}

	protected override Padding PreferredPadding => _padding;

	protected override Padding LayoutPadding => Padding.Empty;

	protected override Padding OuterPadding => _padding;

	static ViewDrawRibbonDesignGroupLines()
	{
		_padding = new Padding(0, 2, 2, 4);
		_imageList = new ImageList();
		_imageList.TransparentColor = Color.Magenta;
		_imageList.Images.AddRange(new Image[15]
		{
			Resources.KryptonRibbonGroupButton,
			Resources.KryptonRibbonGroupColorButton,
			Resources.KryptonRibbonGroupCheckBox,
			Resources.KryptonRibbonGroupRadioButton,
			Resources.KryptonRibbonGroupLabel,
			Resources.KryptonRibbonGroupCustomControl,
			Resources.KryptonRibbonGroupCluster,
			Resources.KryptonRibbonGroupTextBox,
			Resources.KryptonRibbonGroupRichTextBox,
			Resources.KryptonRibbonGroupComboBox,
			Resources.KryptonRibbonGroupMaskedTextBox,
			Resources.KryptonRibbonGroupNumericUpDown,
			Resources.KryptonRibbonGroupDomainUpDown,
			Resources.KryptonRibbonGroupDateTimePicker,
			Resources.KryptonRibbonGroupTrackBar
		});
	}

	public ViewDrawRibbonDesignGroupLines(KryptonRibbon ribbon, KryptonRibbonGroupLines ribbonLines, GroupItemSize currentSize, NeedPaintHandler needPaint)
		: base(ribbon, needPaint)
	{
		Debug.Assert(ribbonLines != null);
		_ribbonLines = ribbonLines;
		_currentSize = currentSize;
	}

	public override string ToString()
	{
		return "ViewDrawRibbonDesignGroupLines:" + base.Id;
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
			ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem("Add Button", null, OnAddButton);
			ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem("Add Color Button", null, OnAddColorButton);
			ToolStripMenuItem toolStripMenuItem3 = new ToolStripMenuItem("Add CheckBox", null, OnAddCheckBox);
			ToolStripMenuItem toolStripMenuItem4 = new ToolStripMenuItem("Add RadioButton", null, OnAddRadioButton);
			ToolStripMenuItem toolStripMenuItem5 = new ToolStripMenuItem("Add Label", null, OnAddLabel);
			ToolStripMenuItem toolStripMenuItem6 = new ToolStripMenuItem("Add Custom Control", null, OnAddCustomControl);
			ToolStripMenuItem toolStripMenuItem7 = new ToolStripMenuItem("Add Cluster", null, OnAddCluster);
			ToolStripMenuItem toolStripMenuItem8 = new ToolStripMenuItem("Add TextBox", null, OnAddTextBox);
			ToolStripMenuItem toolStripMenuItem9 = new ToolStripMenuItem("Add MaskedTextBox", null, OnAddMaskedTextBox);
			ToolStripMenuItem toolStripMenuItem10 = new ToolStripMenuItem("Add RichTextBox", null, OnAddRichTextBox);
			ToolStripMenuItem toolStripMenuItem11 = new ToolStripMenuItem("Add ComboBox", null, OnAddComboBox);
			ToolStripMenuItem toolStripMenuItem12 = new ToolStripMenuItem("Add NumericUpDown", null, OnAddNumericUpDown);
			ToolStripMenuItem toolStripMenuItem13 = new ToolStripMenuItem("Add DomainUpDown", null, OnAddDomainUpDown);
			ToolStripMenuItem toolStripMenuItem14 = new ToolStripMenuItem("Add DateTimePicker", null, OnAddDateTimePicker);
			ToolStripMenuItem toolStripMenuItem15 = new ToolStripMenuItem("Add TrackBar", null, OnAddTrackBar);
			toolStripMenuItem.ImageIndex = 0;
			toolStripMenuItem2.ImageIndex = 1;
			toolStripMenuItem3.ImageIndex = 2;
			toolStripMenuItem4.ImageIndex = 3;
			toolStripMenuItem5.ImageIndex = 4;
			toolStripMenuItem6.ImageIndex = 5;
			toolStripMenuItem7.ImageIndex = 6;
			toolStripMenuItem8.ImageIndex = 7;
			toolStripMenuItem10.ImageIndex = 8;
			toolStripMenuItem11.ImageIndex = 9;
			toolStripMenuItem9.ImageIndex = 10;
			toolStripMenuItem12.ImageIndex = 11;
			toolStripMenuItem13.ImageIndex = 12;
			toolStripMenuItem14.ImageIndex = 13;
			toolStripMenuItem15.ImageIndex = 13;
			_cms.Items.AddRange(new ToolStripItem[15]
			{
				toolStripMenuItem, toolStripMenuItem2, toolStripMenuItem3, toolStripMenuItem7, toolStripMenuItem11, toolStripMenuItem6, toolStripMenuItem14, toolStripMenuItem13, toolStripMenuItem5, toolStripMenuItem12,
				toolStripMenuItem4, toolStripMenuItem10, toolStripMenuItem8, toolStripMenuItem15, toolStripMenuItem9
			});
		}
		if (CommonHelper.ValidContextMenuStrip(_cms))
		{
			Rectangle rectangle = base.Ribbon.ViewRectangleToScreen(this);
			VisualPopupManager.Singleton.ShowContextMenuStrip(_cms, new Point(rectangle.X, rectangle.Bottom));
		}
	}

	private void OnAddButton(object sender, EventArgs e)
	{
		_ribbonLines.OnDesignTimeAddButton();
	}

	private void OnAddColorButton(object sender, EventArgs e)
	{
		_ribbonLines.OnDesignTimeAddColorButton();
	}

	private void OnAddCheckBox(object sender, EventArgs e)
	{
		_ribbonLines.OnDesignTimeAddCheckBox();
	}

	private void OnAddRadioButton(object sender, EventArgs e)
	{
		_ribbonLines.OnDesignTimeAddRadioButton();
	}

	private void OnAddCluster(object sender, EventArgs e)
	{
		_ribbonLines.OnDesignTimeAddCluster();
	}

	private void OnAddLabel(object sender, EventArgs e)
	{
		_ribbonLines.OnDesignTimeAddLabel();
	}

	private void OnAddCustomControl(object sender, EventArgs e)
	{
		_ribbonLines.OnDesignTimeAddCustomControl();
	}

	private void OnAddTextBox(object sender, EventArgs e)
	{
		_ribbonLines.OnDesignTimeAddTextBox();
	}

	private void OnAddMaskedTextBox(object sender, EventArgs e)
	{
		_ribbonLines.OnDesignTimeAddMaskedTextBox();
	}

	private void OnAddRichTextBox(object sender, EventArgs e)
	{
		_ribbonLines.OnDesignTimeAddRichTextBox();
	}

	private void OnAddComboBox(object sender, EventArgs e)
	{
		_ribbonLines.OnDesignTimeAddComboBox();
	}

	private void OnAddNumericUpDown(object sender, EventArgs e)
	{
		_ribbonLines.OnDesignTimeAddNumericUpDown();
	}

	private void OnAddDomainUpDown(object sender, EventArgs e)
	{
		_ribbonLines.OnDesignTimeAddDomainUpDown();
	}

	private void OnAddDateTimePicker(object sender, EventArgs e)
	{
		_ribbonLines.OnDesignTimeAddDateTimePicker();
	}

	private void OnAddTrackBar(object sender, EventArgs e)
	{
		_ribbonLines.OnDesignTimeAddTrackBar();
	}
}
