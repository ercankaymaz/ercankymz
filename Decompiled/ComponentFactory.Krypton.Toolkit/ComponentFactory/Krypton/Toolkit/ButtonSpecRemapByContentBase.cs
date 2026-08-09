#define DEBUG
using System.Diagnostics;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public abstract class ButtonSpecRemapByContentBase : PaletteRedirect
{
	private ButtonSpec _buttonSpec;

	public abstract IPaletteContent PaletteContent { get; }

	public abstract PaletteState PaletteState { get; }

	public ButtonSpecRemapByContentBase(IPalette target, ButtonSpec buttonSpec)
		: base(target)
	{
		Debug.Assert(buttonSpec != null);
		_buttonSpec = buttonSpec;
	}

	public override Color GetContentImageColorMap(PaletteContentStyle style, PaletteState state)
	{
		Color color = OverrideImageColor(state);
		if (color != Color.Empty && PaletteContent != null)
		{
			return color;
		}
		return base.GetContentImageColorMap(style, state);
	}

	public override Color GetContentImageColorTo(PaletteContentStyle style, PaletteState state)
	{
		Color color = OverrideImageColor(state);
		if (color != Color.Empty && PaletteContent != null)
		{
			PaletteState state2 = PaletteState;
			if (state == PaletteState.Disabled)
			{
				state2 = PaletteState.Disabled;
			}
			return PaletteContent.GetContentShortTextColor1(state2);
		}
		return base.GetContentImageColorTo(style, state);
	}

	public override Color GetContentShortTextColor1(PaletteContentStyle style, PaletteState state)
	{
		if (OverrideTextColor(state) && PaletteContent != null)
		{
			return PaletteContent.GetContentShortTextColor1(state);
		}
		return base.GetContentShortTextColor1(style, state);
	}

	public override Color GetContentLongTextColor1(PaletteContentStyle style, PaletteState state)
	{
		if (OverrideTextColor(state) && PaletteContent != null)
		{
			return PaletteContent.GetContentShortTextColor1(state);
		}
		return base.GetContentLongTextColor1(style, state);
	}

	private Color OverrideImageColor(PaletteState state)
	{
		if (PaletteContent != null && (state == PaletteState.Normal || state == PaletteState.Disabled))
		{
			Color colorMap = _buttonSpec.GetColorMap(base.Target);
			if (colorMap != Color.Empty)
			{
				ButtonStyle style = _buttonSpec.GetStyle(base.Target);
				if (style == ButtonStyle.ButtonSpec)
				{
					return colorMap;
				}
			}
		}
		return Color.Empty;
	}

	private bool OverrideTextColor(PaletteState state)
	{
		if (state == PaletteState.Normal)
		{
			ButtonStyle style = _buttonSpec.GetStyle(base.Target);
			if (style == ButtonStyle.ButtonSpec)
			{
				return true;
			}
		}
		return false;
	}
}
