#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Ribbon.Properties;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonDesignGroupTriple : ViewDrawRibbonDesignBase
{
	private static readonly Padding _preferredPaddingL;

	private static readonly Padding _layoutPaddingL;

	private static readonly Padding _outerPaddingL;

	private static readonly Padding _paddingMS;

	private static readonly ImageList _imageList;

	private KryptonRibbonGroupTriple _ribbonTriple;

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

	protected override Padding PreferredPadding => (CurrentSize == GroupItemSize.Large) ? _preferredPaddingL : _paddingMS;

	protected override Padding LayoutPadding => (CurrentSize == GroupItemSize.Large) ? _layoutPaddingL : Padding.Empty;

	protected override Padding OuterPadding => (CurrentSize == GroupItemSize.Large) ? _outerPaddingL : _paddingMS;

	static ViewDrawRibbonDesignGroupTriple()
	{
		_preferredPaddingL = new Padding(1, 3, 1, 3);
		_layoutPaddingL = new Padding(1);
		_outerPaddingL = new Padding(0, 2, 0, 2);
		_paddingMS = new Padding(0, 2, 0, 2);
		_imageList = new ImageList();
		_imageList.TransparentColor = Color.Magenta;
		_imageList.Images.AddRange(new Image[14]
		{
			Resources.KryptonRibbonGroupButton,
			Resources.KryptonRibbonGroupColorButton,
			Resources.KryptonRibbonGroupCheckBox,
			Resources.KryptonRibbonGroupRadioButton,
			Resources.KryptonRibbonGroupLabel,
			Resources.KryptonRibbonGroupCustomControl,
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

	public ViewDrawRibbonDesignGroupTriple(KryptonRibbon ribbon, KryptonRibbonGroupTriple ribbonTriple, GroupItemSize currentSize, NeedPaintHandler needPaint)
		: base(ribbon, needPaint)
	{
		Debug.Assert(ribbonTriple != null);
		_ribbonTriple = ribbonTriple;
		_currentSize = currentSize;
	}

	public override string ToString()
	{
		return "ViewDrawRibbonDesignGroupTriple:" + base.Id;
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
			ToolStripMenuItem toolStripMenuItem4 = new ToolStripMenuItem("Add Custom Control", null, OnAddCustomControl);
			ToolStripMenuItem toolStripMenuItem5 = new ToolStripMenuItem("Add Label", null, OnAddLabel);
			ToolStripMenuItem toolStripMenuItem6 = new ToolStripMenuItem("Add RadioButton", null, OnAddRadioButton);
			ToolStripMenuItem toolStripMenuItem7 = new ToolStripMenuItem("Add TextBox", null, OnAddTextBox);
			ToolStripMenuItem toolStripMenuItem8 = new ToolStripMenuItem("Add MaskedTextBox", null, OnAddMaskedTextBox);
			ToolStripMenuItem toolStripMenuItem9 = new ToolStripMenuItem("Add RichTextBox", null, OnAddRichTextBox);
			ToolStripMenuItem toolStripMenuItem10 = new ToolStripMenuItem("Add ComboBox", null, OnAddComboBox);
			ToolStripMenuItem toolStripMenuItem11 = new ToolStripMenuItem("Add NumericUpDown", null, OnAddNumericUpDown);
			ToolStripMenuItem toolStripMenuItem12 = new ToolStripMenuItem("Add DomainUpDown", null, OnAddDomainUpDown);
			ToolStripMenuItem toolStripMenuItem13 = new ToolStripMenuItem("Add DateTimePicker", null, OnAddDateTimePicker);
			ToolStripMenuItem toolStripMenuItem14 = new ToolStripMenuItem("Add TrackBar", null, OnAddTrackBar);
			toolStripMenuItem.ImageIndex = 0;
			toolStripMenuItem2.ImageIndex = 1;
			toolStripMenuItem3.ImageIndex = 2;
			toolStripMenuItem6.ImageIndex = 3;
			toolStripMenuItem5.ImageIndex = 4;
			toolStripMenuItem4.ImageIndex = 5;
			toolStripMenuItem7.ImageIndex = 6;
			toolStripMenuItem9.ImageIndex = 7;
			toolStripMenuItem10.ImageIndex = 8;
			toolStripMenuItem8.ImageIndex = 9;
			toolStripMenuItem11.ImageIndex = 10;
			toolStripMenuItem12.ImageIndex = 11;
			toolStripMenuItem13.ImageIndex = 12;
			toolStripMenuItem14.ImageIndex = 13;
			_cms.Items.AddRange(new ToolStripItem[14]
			{
				toolStripMenuItem, toolStripMenuItem2, toolStripMenuItem3, toolStripMenuItem10, toolStripMenuItem4, toolStripMenuItem13, toolStripMenuItem12, toolStripMenuItem5, toolStripMenuItem11, toolStripMenuItem6,
				toolStripMenuItem9, toolStripMenuItem7, toolStripMenuItem14, toolStripMenuItem8
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
		_ribbonTriple.OnDesignTimeAddButton();
	}

	private void OnAddColorButton(object sender, EventArgs e)
	{
		_ribbonTriple.OnDesignTimeAddColorButton();
	}

	private void OnAddCheckBox(object sender, EventArgs e)
	{
		_ribbonTriple.OnDesignTimeAddCheckBox();
	}

	private void OnAddRadioButton(object sender, EventArgs e)
	{
		_ribbonTriple.OnDesignTimeAddRadioButton();
	}

	private void OnAddLabel(object sender, EventArgs e)
	{
		_ribbonTriple.OnDesignTimeAddLabel();
	}

	private void OnAddCustomControl(object sender, EventArgs e)
	{
		_ribbonTriple.OnDesignTimeAddCustomControl();
	}

	private void OnAddTextBox(object sender, EventArgs e)
	{
		_ribbonTriple.OnDesignTimeAddTextBox();
	}

	private void OnAddMaskedTextBox(object sender, EventArgs e)
	{
		_ribbonTriple.OnDesignTimeAddMaskedTextBox();
	}

	private void OnAddRichTextBox(object sender, EventArgs e)
	{
		_ribbonTriple.OnDesignTimeAddRichTextBox();
	}

	private void OnAddComboBox(object sender, EventArgs e)
	{
		_ribbonTriple.OnDesignTimeAddComboBox();
	}

	private void OnAddNumericUpDown(object sender, EventArgs e)
	{
		_ribbonTriple.OnDesignTimeAddNumericUpDown();
	}

	private void OnAddDomainUpDown(object sender, EventArgs e)
	{
		_ribbonTriple.OnDesignTimeAddDomainUpDown();
	}

	private void OnAddDateTimePicker(object sender, EventArgs e)
	{
		_ribbonTriple.OnDesignTimeAddDateTimePicker();
	}

	private void OnAddTrackBar(object sender, EventArgs e)
	{
		_ribbonTriple.OnDesignTimeAddTrackBar();
	}
}
