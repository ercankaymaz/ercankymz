using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace DevAge.Drawing.VisualElements;

[Serializable]
public class CheckBoxThemed : CheckBoxBase
{
	private CheckBox mStandardCheckBox = new CheckBox();

	public override ControlDrawStyle Style
	{
		get
		{
			return base.Style;
		}
		set
		{
			base.Style = value;
			mStandardCheckBox.Style = value;
		}
	}

	public override CheckBoxState CheckBoxState
	{
		get
		{
			return base.CheckBoxState;
		}
		set
		{
			base.CheckBoxState = value;
			mStandardCheckBox.CheckBoxState = value;
		}
	}

	public CheckBoxThemed()
	{
	}

	public CheckBoxThemed(CheckBoxThemed other)
		: base(other)
	{
	}

	public override object Clone()
	{
		return new CheckBoxThemed(this);
	}

	protected VisualStyleElement GetBackgroundElement()
	{
		if (Style != ControlDrawStyle.Hot)
		{
			if (Style != ControlDrawStyle.Pressed)
			{
				if (Style != ControlDrawStyle.Disabled)
				{
					if (CheckBoxState != CheckBoxState.Checked)
					{
						if (CheckBoxState != CheckBoxState.Unchecked)
						{
							return VisualStyleElement.Button.CheckBox.MixedNormal;
						}
						return VisualStyleElement.Button.CheckBox.UncheckedNormal;
					}
					return VisualStyleElement.Button.CheckBox.CheckedNormal;
				}
				if (CheckBoxState != CheckBoxState.Checked)
				{
					if (CheckBoxState != CheckBoxState.Unchecked)
					{
						return VisualStyleElement.Button.CheckBox.MixedDisabled;
					}
					return VisualStyleElement.Button.CheckBox.UncheckedDisabled;
				}
				return VisualStyleElement.Button.CheckBox.CheckedDisabled;
			}
			if (CheckBoxState != CheckBoxState.Checked)
			{
				if (CheckBoxState != CheckBoxState.Unchecked)
				{
					return VisualStyleElement.Button.CheckBox.MixedPressed;
				}
				return VisualStyleElement.Button.CheckBox.UncheckedPressed;
			}
			return VisualStyleElement.Button.CheckBox.CheckedPressed;
		}
		if (CheckBoxState != CheckBoxState.Checked)
		{
			if (CheckBoxState != CheckBoxState.Unchecked)
			{
				return VisualStyleElement.Button.CheckBox.MixedHot;
			}
			return VisualStyleElement.Button.CheckBox.UncheckedHot;
		}
		return VisualStyleElement.Button.CheckBox.CheckedHot;
	}

	protected VisualStyleRenderer GetRenderer(VisualStyleElement element)
	{
		return new VisualStyleRenderer(element);
	}

	protected override void OnDraw(GraphicsCache graphics, RectangleF area)
	{
		if (!Application.RenderWithVisualStyles || !VisualStyleRenderer.IsElementDefined(GetBackgroundElement()))
		{
			mStandardCheckBox.Draw(graphics, area);
		}
		else
		{
			GetRenderer(GetBackgroundElement()).DrawBackground(graphics.Graphics, Rectangle.Round(area));
		}
	}

	protected override SizeF OnMeasureContent(MeasureHelper measure, SizeF maxSize)
	{
		if (!Application.RenderWithVisualStyles || !VisualStyleRenderer.IsElementDefined(GetBackgroundElement()))
		{
			return mStandardCheckBox.Measure(measure, Size.Empty, maxSize);
		}
		return GetRenderer(GetBackgroundElement()).GetPartSize(measure.Graphics, ThemeSizeType.True);
	}
}
