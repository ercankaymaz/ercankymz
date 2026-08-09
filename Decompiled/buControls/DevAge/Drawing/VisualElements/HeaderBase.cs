using System;

namespace DevAge.Drawing.VisualElements;

[Serializable]
public abstract class HeaderBase : BackgroundBase, ICloneable, IVisualElement, IBackground, IHeader
{
	private ControlDrawStyle mControlDrawStyle = ControlDrawStyle.Normal;

	public virtual ControlDrawStyle Style
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

	public HeaderBase()
	{
	}

	public HeaderBase(HeaderBase other)
		: base(other)
	{
		Style = other.Style;
	}

	protected virtual bool ShouldSerializeStyle()
	{
		return Style != ControlDrawStyle.Normal;
	}
}
