#define DEBUG
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteRibbonGeneral : Storage, IPaletteRibbonGeneral
{
	private PaletteRelativeAlign _contextTextAlign;

	private Color _contextTextColor;

	private Font _contextTextFont;

	private IPaletteRibbonGeneral _inherit;

	private PaletteRibbonShape _ribbonShape;

	private Color _dialogDarkColor;

	private Color _dialogLightColor;

	private Color _disabledDarkColor;

	private Color _disabledLightColor;

	private Color _dropArrowDarkColor;

	private Color _dropArrowLightColor;

	private Color _groupSeparatorDark;

	private Color _groupSeparatorLight;

	private Color _minimizeBarDarkColor;

	private Color _minimizeBarLightColor;

	private Color _qatButtonDarkColor;

	private Color _qatButtonLightColor;

	private Color _tabSeparatorColor;

	private Color _tabSeparatorContextColor;

	private Font _textFont;

	private PaletteTextHint _textHint;

	[Browsable(false)]
	public override bool IsDefault => ContextTextAlign == PaletteRelativeAlign.Inherit && ContextTextColor == Color.Empty && ContextTextFont == null && DisabledDark == Color.Empty && DisabledLight == Color.Empty && DropArrowLight == Color.Empty && DropArrowDark == Color.Empty && GroupDialogDark == Color.Empty && GroupDialogLight == Color.Empty && GroupSeparatorDark == Color.Empty && GroupSeparatorLight == Color.Empty && MinimizeBarDarkColor == Color.Empty && MinimizeBarLightColor == Color.Empty && RibbonShape == PaletteRibbonShape.Inherit && TextFont == null && TextHint == PaletteTextHint.Inherit && TabSeparatorColor == Color.Empty && TabSeparatorContextColor == Color.Empty && QATButtonDarkColor == Color.Empty && QATButtonLightColor == Color.Empty;

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Text alignment for the ribbon context text.")]
	[DefaultValue(typeof(PaletteRelativeAlign), "Inherit")]
	[RefreshProperties(RefreshProperties.All)]
	public PaletteRelativeAlign ContextTextAlign
	{
		get
		{
			return _contextTextAlign;
		}
		set
		{
			if (_contextTextAlign != value)
			{
				_contextTextAlign = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Font for the ribbon context text.")]
	[DefaultValue(null)]
	[RefreshProperties(RefreshProperties.All)]
	public Font ContextTextFont
	{
		get
		{
			return _contextTextFont;
		}
		set
		{
			if (_contextTextFont != value)
			{
				_contextTextFont = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Color used for ribbon context text.")]
	[DefaultValue(typeof(Color), "")]
	[RefreshProperties(RefreshProperties.All)]
	public Color ContextTextColor
	{
		get
		{
			return _contextTextColor;
		}
		set
		{
			if (_contextTextColor != value)
			{
				_contextTextColor = value;
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Dark disabled color for ribbon glyphs.")]
	[DefaultValue(typeof(Color), "")]
	[RefreshProperties(RefreshProperties.All)]
	public Color DisabledDark
	{
		get
		{
			return _disabledDarkColor;
		}
		set
		{
			if (_disabledDarkColor != value)
			{
				_disabledDarkColor = value;
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Light disabled color for ribbon glyphs.")]
	[DefaultValue(typeof(Color), "")]
	[RefreshProperties(RefreshProperties.All)]
	public Color DisabledLight
	{
		get
		{
			return _disabledLightColor;
		}
		set
		{
			if (_disabledLightColor != value)
			{
				_disabledLightColor = value;
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Ribbon group dialog launcher button dark color.")]
	[DefaultValue(typeof(Color), "")]
	[RefreshProperties(RefreshProperties.All)]
	public Color GroupDialogDark
	{
		get
		{
			return _dialogDarkColor;
		}
		set
		{
			if (_dialogDarkColor != value)
			{
				_dialogDarkColor = value;
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Ribbon group dialog launcher button light color.")]
	[DefaultValue(typeof(Color), "")]
	[RefreshProperties(RefreshProperties.All)]
	public Color GroupDialogLight
	{
		get
		{
			return _dialogLightColor;
		}
		set
		{
			if (_dialogLightColor != value)
			{
				_dialogLightColor = value;
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Ribbon drop arrow dark color.")]
	[DefaultValue(typeof(Color), "")]
	[RefreshProperties(RefreshProperties.All)]
	public Color DropArrowDark
	{
		get
		{
			return _dropArrowDarkColor;
		}
		set
		{
			if (_dropArrowDarkColor != value)
			{
				_dropArrowDarkColor = value;
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Ribbon drop arrow light color.")]
	[DefaultValue(typeof(Color), "")]
	[RefreshProperties(RefreshProperties.All)]
	public Color DropArrowLight
	{
		get
		{
			return _dropArrowLightColor;
		}
		set
		{
			if (_dropArrowLightColor != value)
			{
				_dropArrowLightColor = value;
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Ribbon group separator dark color.")]
	[DefaultValue(typeof(Color), "")]
	[RefreshProperties(RefreshProperties.All)]
	public Color GroupSeparatorDark
	{
		get
		{
			return _groupSeparatorDark;
		}
		set
		{
			if (_groupSeparatorDark != value)
			{
				_groupSeparatorDark = value;
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Ribbon group separator light color.")]
	[DefaultValue(typeof(Color), "")]
	[RefreshProperties(RefreshProperties.All)]
	public Color GroupSeparatorLight
	{
		get
		{
			return _groupSeparatorLight;
		}
		set
		{
			if (_groupSeparatorLight != value)
			{
				_groupSeparatorLight = value;
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Ribbon minimize bar dark color.")]
	[DefaultValue(typeof(Color), "")]
	[RefreshProperties(RefreshProperties.All)]
	public Color MinimizeBarDarkColor
	{
		get
		{
			return _minimizeBarDarkColor;
		}
		set
		{
			if (_minimizeBarDarkColor != value)
			{
				_minimizeBarDarkColor = value;
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Ribbon minimize bar light color.")]
	[DefaultValue(typeof(Color), "")]
	[RefreshProperties(RefreshProperties.All)]
	public Color MinimizeBarLightColor
	{
		get
		{
			return _minimizeBarLightColor;
		}
		set
		{
			if (_minimizeBarLightColor != value)
			{
				_minimizeBarLightColor = value;
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Ribbon shape.")]
	[DefaultValue(typeof(PaletteRibbonShape), "Inherit")]
	public PaletteRibbonShape RibbonShape
	{
		get
		{
			return _ribbonShape;
		}
		set
		{
			if (_ribbonShape != value)
			{
				_ribbonShape = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Ribbon tab separator color.")]
	[DefaultValue(typeof(Color), "")]
	[RefreshProperties(RefreshProperties.All)]
	public Color TabSeparatorColor
	{
		get
		{
			return _tabSeparatorColor;
		}
		set
		{
			if (_tabSeparatorColor != value)
			{
				_tabSeparatorColor = value;
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Ribbon tab context separator color.")]
	[DefaultValue(typeof(Color), "")]
	[RefreshProperties(RefreshProperties.All)]
	public Color TabSeparatorContextColor
	{
		get
		{
			return _tabSeparatorContextColor;
		}
		set
		{
			if (_tabSeparatorContextColor != value)
			{
				_tabSeparatorContextColor = value;
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Font for the ribbon text.")]
	[DefaultValue(null)]
	[RefreshProperties(RefreshProperties.All)]
	public Font TextFont
	{
		get
		{
			return _textFont;
		}
		set
		{
			if (_textFont != value)
			{
				_textFont = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Rendering hint for the text font.")]
	[DefaultValue(typeof(PaletteTextHint), "Inherit")]
	[RefreshProperties(RefreshProperties.All)]
	public PaletteTextHint TextHint
	{
		get
		{
			return _textHint;
		}
		set
		{
			if (_textHint != value)
			{
				_textHint = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Quick access toolbar extra button dark color.")]
	[DefaultValue(typeof(Color), "")]
	[RefreshProperties(RefreshProperties.All)]
	public Color QATButtonDarkColor
	{
		get
		{
			return _qatButtonDarkColor;
		}
		set
		{
			if (_qatButtonDarkColor != value)
			{
				_qatButtonDarkColor = value;
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Quick access toolbar extra button light color.")]
	[DefaultValue(typeof(Color), "")]
	[RefreshProperties(RefreshProperties.All)]
	public Color QATButtonLightColor
	{
		get
		{
			return _qatButtonLightColor;
		}
		set
		{
			if (_qatButtonLightColor != value)
			{
				_qatButtonLightColor = value;
				PerformNeedPaint();
			}
		}
	}

	public PaletteRibbonGeneral(IPaletteRibbonGeneral inherit, NeedPaintHandler needPaint)
	{
		Debug.Assert(inherit != null);
		_inherit = inherit;
		NeedPaint = needPaint;
		_contextTextAlign = PaletteRelativeAlign.Inherit;
		_contextTextColor = Color.Empty;
		_contextTextFont = null;
		_disabledDarkColor = Color.Empty;
		_disabledLightColor = Color.Empty;
		_dialogDarkColor = Color.Empty;
		_dialogLightColor = Color.Empty;
		_dropArrowLightColor = Color.Empty;
		_dropArrowDarkColor = Color.Empty;
		_groupSeparatorDark = Color.Empty;
		_groupSeparatorLight = Color.Empty;
		_minimizeBarDarkColor = Color.Empty;
		_minimizeBarLightColor = Color.Empty;
		_ribbonShape = PaletteRibbonShape.Inherit;
		_tabSeparatorColor = Color.Empty;
		_tabSeparatorContextColor = Color.Empty;
		_textFont = null;
		_textHint = PaletteTextHint.Inherit;
		_qatButtonDarkColor = Color.Empty;
		_qatButtonLightColor = Color.Empty;
	}

	public void SetInherit(IPaletteRibbonGeneral inherit)
	{
		_inherit = inherit;
	}

	public void PopulateFromBase()
	{
		ContextTextAlign = GetRibbonContextTextAlign(PaletteState.Normal);
		ContextTextFont = GetRibbonContextTextFont(PaletteState.Normal);
		ContextTextColor = GetRibbonContextTextColor(PaletteState.Normal);
		DisabledDark = GetRibbonDisabledDark(PaletteState.Normal);
		DisabledLight = GetRibbonDisabledLight(PaletteState.Normal);
		DropArrowDark = GetRibbonDropArrowDark(PaletteState.Normal);
		DropArrowLight = GetRibbonDropArrowLight(PaletteState.Normal);
		GroupDialogDark = GetRibbonGroupDialogDark(PaletteState.Normal);
		GroupDialogLight = GetRibbonGroupDialogLight(PaletteState.Normal);
		GroupSeparatorDark = GetRibbonGroupSeparatorDark(PaletteState.Normal);
		GroupSeparatorLight = GetRibbonGroupSeparatorLight(PaletteState.Normal);
		MinimizeBarDarkColor = GetRibbonMinimizeBarDark(PaletteState.Normal);
		MinimizeBarLightColor = GetRibbonMinimizeBarLight(PaletteState.Normal);
		RibbonShape = GetRibbonShape();
		TabSeparatorColor = GetRibbonTabSeparatorColor(PaletteState.Normal);
		TabSeparatorContextColor = GetRibbonTabSeparatorContextColor(PaletteState.Normal);
		TextFont = GetRibbonTextFont(PaletteState.Normal);
		TextHint = GetRibbonTextHint(PaletteState.Normal);
		QATButtonDarkColor = GetRibbonGroupDialogDark(PaletteState.Normal);
		QATButtonLightColor = GetRibbonGroupDialogLight(PaletteState.Normal);
	}

	public void ResetContextTextAlign()
	{
		ContextTextAlign = PaletteRelativeAlign.Inherit;
	}

	public PaletteRelativeAlign GetRibbonContextTextAlign(PaletteState state)
	{
		if (ContextTextAlign != PaletteRelativeAlign.Inherit)
		{
			return ContextTextAlign;
		}
		return _inherit.GetRibbonContextTextAlign(state);
	}

	public void ResetContextTextFont()
	{
		ContextTextFont = null;
	}

	public Font GetRibbonContextTextFont(PaletteState state)
	{
		if (ContextTextFont != null)
		{
			return ContextTextFont;
		}
		return _inherit.GetRibbonContextTextFont(state);
	}

	public void ResetContextTextColor()
	{
		ContextTextColor = Color.Empty;
	}

	public Color GetRibbonContextTextColor(PaletteState state)
	{
		if (DisabledDark != Color.Empty)
		{
			return ContextTextColor;
		}
		return _inherit.GetRibbonContextTextColor(state);
	}

	public void ResetDisabledDark()
	{
		DisabledDark = Color.Empty;
	}

	public Color GetRibbonDisabledDark(PaletteState state)
	{
		if (DisabledDark != Color.Empty)
		{
			return DisabledDark;
		}
		return _inherit.GetRibbonDisabledDark(state);
	}

	public void ResetDisabledLight()
	{
		DisabledLight = Color.Empty;
	}

	public Color GetRibbonDisabledLight(PaletteState state)
	{
		if (DisabledLight != Color.Empty)
		{
			return DisabledLight;
		}
		return _inherit.GetRibbonDisabledLight(state);
	}

	public void ResetGroupDialogDark()
	{
		GroupDialogDark = Color.Empty;
	}

	public Color GetRibbonGroupDialogDark(PaletteState state)
	{
		if (GroupDialogDark != Color.Empty)
		{
			return GroupDialogDark;
		}
		return _inherit.GetRibbonGroupDialogDark(state);
	}

	public void ResetGroupDialogLight()
	{
		GroupDialogLight = Color.Empty;
	}

	public Color GetRibbonGroupDialogLight(PaletteState state)
	{
		if (GroupDialogLight != Color.Empty)
		{
			return GroupDialogLight;
		}
		return _inherit.GetRibbonGroupDialogLight(state);
	}

	public void ResetDropArrowDark()
	{
		DropArrowDark = Color.Empty;
	}

	public Color GetRibbonDropArrowDark(PaletteState state)
	{
		if (DropArrowDark != Color.Empty)
		{
			return DropArrowDark;
		}
		return _inherit.GetRibbonDropArrowDark(state);
	}

	public void ResetDropArrowLight()
	{
		DropArrowLight = Color.Empty;
	}

	public Color GetRibbonDropArrowLight(PaletteState state)
	{
		if (DropArrowLight != Color.Empty)
		{
			return DropArrowLight;
		}
		return _inherit.GetRibbonDropArrowLight(state);
	}

	public void ResetGroupSeparatorDark()
	{
		GroupSeparatorDark = Color.Empty;
	}

	public Color GetRibbonGroupSeparatorDark(PaletteState state)
	{
		if (GroupSeparatorDark != Color.Empty)
		{
			return GroupSeparatorDark;
		}
		return _inherit.GetRibbonGroupSeparatorDark(state);
	}

	public void ResetGroupSeparatorLight()
	{
		GroupDialogLight = Color.Empty;
	}

	public Color GetRibbonGroupSeparatorLight(PaletteState state)
	{
		if (GroupSeparatorLight != Color.Empty)
		{
			return GroupSeparatorLight;
		}
		return _inherit.GetRibbonGroupSeparatorLight(state);
	}

	public void ResetMinimizeBarDarkColor()
	{
		MinimizeBarDarkColor = Color.Empty;
	}

	public Color GetRibbonMinimizeBarDark(PaletteState state)
	{
		if (MinimizeBarDarkColor != Color.Empty)
		{
			return MinimizeBarDarkColor;
		}
		return _inherit.GetRibbonMinimizeBarDark(state);
	}

	public void ResetMinimizeBarLightColor()
	{
		MinimizeBarLightColor = Color.Empty;
	}

	public Color GetRibbonMinimizeBarLight(PaletteState state)
	{
		if (MinimizeBarLightColor != Color.Empty)
		{
			return MinimizeBarLightColor;
		}
		return _inherit.GetRibbonMinimizeBarLight(state);
	}

	public void ResetRibbonShape()
	{
		RibbonShape = PaletteRibbonShape.Inherit;
	}

	public PaletteRibbonShape GetRibbonShape()
	{
		if (RibbonShape != PaletteRibbonShape.Inherit)
		{
			return RibbonShape;
		}
		return _inherit.GetRibbonShape();
	}

	public void ResetTabSeparatorColor()
	{
		TabSeparatorColor = Color.Empty;
	}

	public Color GetRibbonTabSeparatorColor(PaletteState state)
	{
		if (TabSeparatorColor != Color.Empty)
		{
			return TabSeparatorColor;
		}
		return _inherit.GetRibbonTabSeparatorColor(state);
	}

	public void ResetTabSeparatorContextColor()
	{
		TabSeparatorContextColor = Color.Empty;
	}

	public Color GetRibbonTabSeparatorContextColor(PaletteState state)
	{
		if (TabSeparatorColor != Color.Empty)
		{
			return TabSeparatorContextColor;
		}
		return _inherit.GetRibbonTabSeparatorContextColor(state);
	}

	public void ResetTextFont()
	{
		TextFont = null;
	}

	public Font GetRibbonTextFont(PaletteState state)
	{
		if (TextFont != null)
		{
			return TextFont;
		}
		return _inherit.GetRibbonTextFont(state);
	}

	public void ResetTextHint()
	{
		TextHint = PaletteTextHint.Inherit;
	}

	public PaletteTextHint GetRibbonTextHint(PaletteState state)
	{
		if (TextHint != PaletteTextHint.Inherit)
		{
			return TextHint;
		}
		return _inherit.GetRibbonTextHint(state);
	}

	public void ResetQATButtonDarkColor()
	{
		QATButtonDarkColor = Color.Empty;
	}

	public Color GetRibbonQATButtonDark(PaletteState state)
	{
		if (QATButtonDarkColor != Color.Empty)
		{
			return QATButtonDarkColor;
		}
		return _inherit.GetRibbonQATButtonDark(state);
	}

	public void ResetQATButtonLightColor()
	{
		QATButtonLightColor = Color.Empty;
	}

	public Color GetRibbonQATButtonLight(PaletteState state)
	{
		if (QATButtonLightColor != Color.Empty)
		{
			return QATButtonLightColor;
		}
		return _inherit.GetRibbonQATButtonLight(state);
	}
}
