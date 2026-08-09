using System.ComponentModel;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteRibbonText : Storage, IPaletteRibbonText
{
	private IPaletteRibbonText _inheritText;

	private Color _textColor;

	[Browsable(false)]
	public override bool IsDefault => TextColor == Color.Empty;

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Color for the text.")]
	[DefaultValue(typeof(Color), "")]
	[RefreshProperties(RefreshProperties.All)]
	public Color TextColor
	{
		get
		{
			return _textColor;
		}
		set
		{
			if (_textColor != value)
			{
				_textColor = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	public PaletteRibbonText(NeedPaintHandler needPaint)
		: this(null, needPaint)
	{
	}

	public PaletteRibbonText(IPaletteRibbonText inheritText, NeedPaintHandler needPaint)
	{
		_inheritText = inheritText;
		NeedPaint = needPaint;
		_textColor = Color.Empty;
	}

	public void SetInherit(IPaletteRibbonText inheritText)
	{
		if (_inheritText != null)
		{
			_inheritText = inheritText;
		}
	}

	public void PopulateFromBase(PaletteState state)
	{
		TextColor = GetRibbonTextColor(state);
	}

	public void ResetTextColor()
	{
		TextColor = Color.Empty;
	}

	public Color GetRibbonTextColor(PaletteState state)
	{
		if (TextColor != Color.Empty)
		{
			return TextColor;
		}
		if (_inheritText != null)
		{
			return _inheritText.GetRibbonTextColor(state);
		}
		return Color.Empty;
	}
}
