using System;

namespace DevAge.Drawing.VisualElements;

[Serializable]
public abstract class ButtonBase : BackgroundBase, ICloneable, IVisualElement, IBackground, IButton
{
	private ButtonStyle mControlDrawStyle = ButtonStyle.Normal;

	public virtual ButtonStyle Style
	{
		get
		{
			return mControlDrawStyle;
		}
		set
		{
			mControlDrawStyle = value;
		}
	}

	public ButtonBase()
	{
	}

	public ButtonBase(ButtonBase other)
		: base(other)
	{
		Style = other.Style;
	}

	protected virtual bool ShouldSerializeStyle()
	{
		return Style != ButtonStyle.Normal;
	}
}
