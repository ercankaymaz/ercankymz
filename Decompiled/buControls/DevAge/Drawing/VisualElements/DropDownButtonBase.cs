using System;

namespace DevAge.Drawing.VisualElements;

[Serializable]
public abstract class DropDownButtonBase : VisualElementBase, ICloneable, IVisualElement, IDropDownButton
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

	public DropDownButtonBase()
	{
	}

	public DropDownButtonBase(DropDownButtonBase other)
		: base(other)
	{
		Style = other.Style;
	}

	protected virtual bool ShouldSerializeStyle()
	{
		return Style != ButtonStyle.Normal;
	}
}
