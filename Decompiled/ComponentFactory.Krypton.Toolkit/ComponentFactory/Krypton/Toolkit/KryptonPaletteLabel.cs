using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonPaletteLabel : Storage
{
	private PaletteContentInheritRedirect _stateInherit;

	private PaletteContent _stateCommon;

	private PaletteContent _stateNormal;

	private PaletteContent _stateDisabled;

	private PaletteContent _stateFocus;

	private PaletteContent _stateVisited;

	private PaletteContent _stateNotVisited;

	private PaletteContent _statePressed;

	[Browsable(false)]
	public override bool IsDefault => _stateCommon.IsDefault && _stateDisabled.IsDefault && _stateNormal.IsDefault && _stateFocus.IsDefault && _stateVisited.IsDefault && _stateNotVisited.IsDefault && _statePressed.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining common label appearance that other states can override.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteContent StateCommon => _stateCommon;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining disabled label appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteContent StateDisabled => _stateDisabled;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining normal label appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteContent StateNormal => _stateNormal;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining label appearance when it has focus.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteContent OverrideFocus => _stateFocus;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for modifying normal state when label has been visited.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteContent OverrideVisited => _stateVisited;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for modifying normal state when label has not been visited.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteContent OverrideNotVisited => _stateNotVisited;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining pressed label appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteContent OverridePressed => _statePressed;

	public KryptonPaletteLabel(PaletteRedirect redirect, PaletteContentStyle contentStyle, NeedPaintHandler needPaint)
	{
		_stateInherit = new PaletteContentInheritRedirect(redirect, contentStyle);
		_stateCommon = new PaletteContent(_stateInherit, needPaint);
		_stateDisabled = new PaletteContent(_stateCommon, needPaint);
		_stateNormal = new PaletteContent(_stateCommon, needPaint);
		_stateFocus = new PaletteContent(_stateInherit, needPaint);
		_stateVisited = new PaletteContent(_stateInherit, needPaint);
		_stateNotVisited = new PaletteContent(_stateInherit, needPaint);
		_statePressed = new PaletteContent(_stateInherit, needPaint);
	}

	public void SetRedirector(PaletteRedirect redirect)
	{
		_stateInherit.SetRedirector(redirect);
	}

	public void PopulateFromBase()
	{
		_stateDisabled.PopulateFromBase(PaletteState.Disabled);
		_stateNormal.PopulateFromBase(PaletteState.Normal);
		_stateFocus.PopulateFromBase(PaletteState.FocusOverride);
		_stateVisited.PopulateFromBase(PaletteState.LinkVisitedOverride);
		_stateNotVisited.PopulateFromBase(PaletteState.LinkNotVisitedOverride);
		_statePressed.PopulateFromBase(PaletteState.LinkPressedOverride);
	}

	private bool ShouldSerializeStateCommon()
	{
		return !_stateCommon.IsDefault;
	}

	private bool ShouldSerializeStateDisabled()
	{
		return !_stateDisabled.IsDefault;
	}

	private bool ShouldSerializeStateNormal()
	{
		return !_stateNormal.IsDefault;
	}

	private bool ShouldSerializeOverrideFocus()
	{
		return !_stateFocus.IsDefault;
	}

	private bool ShouldSerializeOverrideVisited()
	{
		return !_stateVisited.IsDefault;
	}

	private bool ShouldSerializeOverrideNotVisited()
	{
		return !_stateNotVisited.IsDefault;
	}

	private bool ShouldSerializeOverridePressed()
	{
		return !_statePressed.IsDefault;
	}
}
