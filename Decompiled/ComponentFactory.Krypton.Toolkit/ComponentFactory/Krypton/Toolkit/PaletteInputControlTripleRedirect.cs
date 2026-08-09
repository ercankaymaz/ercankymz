#define DEBUG
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteInputControlTripleRedirect : Storage, IPaletteTriple, IPaletteMetric
{
	private PaletteInputControlBackStates _back;

	private PaletteBorder _border;

	private PaletteInputControlContentStates _content;

	private PaletteBackInheritRedirect _backInherit;

	private PaletteBorderInheritRedirect _borderInherit;

	private PaletteContentInheritRedirect _contentInherit;

	private PaletteMetricRedirect _metricRedirect;

	[Browsable(false)]
	public override bool IsDefault => Back.IsDefault && Border.IsDefault && Content.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining background appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteInputControlBackStates Back => _back;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public IPaletteBack PaletteBack => Back;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public PaletteBackStyle BackStyle
	{
		get
		{
			return _backInherit.Style;
		}
		set
		{
			_backInherit.Style = value;
		}
	}

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining border appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteBorder Border => _border;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public IPaletteBorder PaletteBorder => Border;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public PaletteBorderStyle BorderStyle
	{
		get
		{
			return _borderInherit.Style;
		}
		set
		{
			_borderInherit.Style = value;
		}
	}

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining content appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteInputControlContentStates Content => _content;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public IPaletteContent PaletteContent => Content;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public PaletteContentStyle ContentStyle
	{
		get
		{
			return _contentInherit.Style;
		}
		set
		{
			_contentInherit.Style = value;
		}
	}

	public PaletteInputControlTripleRedirect(PaletteRedirect redirect, PaletteBackStyle backStyle, PaletteBorderStyle borderStyle, PaletteContentStyle contentStyle, NeedPaintHandler needPaint)
	{
		Debug.Assert(redirect != null);
		NeedPaint = needPaint;
		_backInherit = new PaletteBackInheritRedirect(redirect, backStyle);
		_borderInherit = new PaletteBorderInheritRedirect(redirect, borderStyle);
		_contentInherit = new PaletteContentInheritRedirect(redirect, contentStyle);
		_metricRedirect = new PaletteMetricRedirect(redirect);
		_back = new PaletteInputControlBackStates(_backInherit, needPaint);
		_border = new PaletteBorder(_borderInherit, needPaint);
		_content = new PaletteInputControlContentStates(_contentInherit, needPaint);
	}

	public virtual void SetRedirector(PaletteRedirect redirect)
	{
		_backInherit.SetRedirector(redirect);
		_borderInherit.SetRedirector(redirect);
		_contentInherit.SetRedirector(redirect);
		_metricRedirect.SetRedirector(redirect);
	}

	public void SetStyles(InputControlStyle style)
	{
		switch (style)
		{
		case InputControlStyle.Standalone:
			SetStyles(PaletteBackStyle.InputControlStandalone, PaletteBorderStyle.InputControlStandalone, PaletteContentStyle.InputControlStandalone);
			break;
		case InputControlStyle.Ribbon:
			SetStyles(PaletteBackStyle.InputControlRibbon, PaletteBorderStyle.InputControlRibbon, PaletteContentStyle.InputControlRibbon);
			break;
		case InputControlStyle.Custom1:
			SetStyles(PaletteBackStyle.InputControlCustom1, PaletteBorderStyle.InputControlCustom1, PaletteContentStyle.InputControlCustom1);
			break;
		}
	}

	public void SetStyles(PaletteBackStyle backStyle, PaletteBorderStyle borderStyle, PaletteContentStyle contentStyle)
	{
		BackStyle = backStyle;
		BorderStyle = borderStyle;
		ContentStyle = contentStyle;
	}

	public void PopulateFromBase(PaletteState state)
	{
		_back.PopulateFromBase(state);
		_border.PopulateFromBase(state);
		_content.PopulateFromBase(state);
	}

	private bool ShouldSerializeBack()
	{
		return !_back.IsDefault;
	}

	private bool ShouldSerializeBorder()
	{
		return !_border.IsDefault;
	}

	private bool ShouldSerializeContent()
	{
		return !_content.IsDefault;
	}

	public int GetMetricInt(PaletteState state, PaletteMetricInt metric)
	{
		return _metricRedirect.GetMetricInt(state, metric);
	}

	public InheritBool GetMetricBool(PaletteState state, PaletteMetricBool metric)
	{
		return _metricRedirect.GetMetricBool(state, metric);
	}

	public Padding GetMetricPadding(PaletteState state, PaletteMetricPadding metric)
	{
		return _metricRedirect.GetMetricPadding(state, metric);
	}

	protected void OnNeedPaint(object sender, bool needLayout)
	{
		PerformNeedPaint(needLayout);
	}
}
