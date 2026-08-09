using System;

namespace DevAge.Drawing.VisualElements;

[Serializable]
public abstract class CheckBoxBase : VisualElementBase, ICloneable, IVisualElement, ICheckBox
{
	private ControlDrawStyle mControlDrawStyle = ControlDrawStyle.Normal;

	private CheckBoxState mCheckBoxState = CheckBoxState.Undefined;

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

	public virtual CheckBoxState CheckBoxState
	{
		get
		{
			return mCheckBoxState;
		}
		set
		{
			mCheckBoxState = value;
		}
	}

	public CheckBoxBase()
	{
		AnchorArea = new AnchorArea(float.NaN, float.NaN, float.NaN, float.NaN, center: true, middle: true);
	}

	public CheckBoxBase(CheckBoxBase other)
		: base(other)
	{
		Style = other.Style;
		CheckBoxState = other.CheckBoxState;
	}

	protected virtual bool ShouldSerializeStyle()
	{
		return Style != ControlDrawStyle.Normal;
	}

	protected virtual bool ShouldSerializeCheckBoxState()
	{
		return CheckBoxState != CheckBoxState.Undefined;
	}
}
