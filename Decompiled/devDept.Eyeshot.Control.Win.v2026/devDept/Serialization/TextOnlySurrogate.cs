using System.Drawing;
using devDept.Eyeshot.Control.Labels;

namespace devDept.Serialization;

public class TextOnlySurrogate : LabelSurrogate
{
	public string Text;

	public Font Font;

	public bool Vertical;

	public Color FillColor;

	public Color ColorForSelection;

	public Color FillColorForSelection;

	public int CornerRadius;

	public TextOnlySurrogate(TextOnly textOnly)
		: base(textOnly)
	{
	}

	protected override Label ConvertToObject()
	{
		TextOnly textOnly = new TextOnly(AnchorPoint, Text, Font, FillColor);
		CopyDataToObject(textOnly);
		return textOnly;
	}

	protected override void CopyDataToObject(Label label)
	{
		TextOnly obj = (TextOnly)label;
		obj.FillColor = FillColor;
		obj.Vertical = Vertical;
		obj.ColorForSelection = ColorForSelection;
		obj.FillColorForSelection = FillColorForSelection;
		obj.CornerRadius = CornerRadius;
		base.CopyDataToObject(label);
	}

	protected override void CopyDataFromObject(Label label)
	{
		TextOnly textOnly = (TextOnly)label;
		Text = textOnly.Text;
		Font = textOnly.Font;
		Vertical = textOnly.Vertical;
		FillColor = textOnly.FillColor;
		ColorForSelection = textOnly.ColorForSelection;
		FillColorForSelection = textOnly.FillColorForSelection;
		CornerRadius = textOnly.CornerRadius;
		base.CopyDataFromObject(label);
	}
}
