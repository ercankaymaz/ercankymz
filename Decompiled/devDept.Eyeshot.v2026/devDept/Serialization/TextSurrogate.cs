using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

public class TextSurrogate : EntitySurrogate
{
	public Plane Plane;

	public string TextString;

	public double Height;

	public byte Alignment;

	public string StyleName;

	public bool Simplify;

	public double WidthFactor;

	public bool Backward;

	public bool UpsideDown;

	public bool Billboard;

	public TextSurrogate(Text text)
		: base(text)
	{
	}

	protected override Entity ConvertToObject()
	{
		Text text = new Text(this);
		CopyDataToObject(text);
		return text;
	}

	protected override void CopyDataToObject(Entity entity)
	{
		Text text = entity as Text;
		if (!(text is MultilineText))
		{
			text.WidthFactor = WidthFactor;
		}
		text.Plane = Plane;
		if (!(text is Dimension))
		{
			text.TextString = TextString;
		}
		text.Height = Height;
		text.alignment = (Text.alignmentType)Alignment;
		text.StyleName = StyleName;
		text.Simplify = Simplify;
		text.Backward = Backward;
		text.UpsideDown = UpsideDown;
		text.Billboard = Billboard;
		base.CopyDataToObject(entity);
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		Text text = entity as Text;
		if (!(text is MultilineText))
		{
			WidthFactor = text.WidthFactor;
		}
		Plane = text.Plane;
		TextString = text.TextString;
		Height = text.Height;
		Alignment = (byte)text.Alignment;
		StyleName = text.StyleName;
		Simplify = text.Simplify;
		Backward = text.Backward;
		UpsideDown = text.UpsideDown;
		Billboard = text.Billboard;
		base.CopyDataFromObject(entity);
	}
}
