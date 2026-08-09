using devDept.Eyeshot;

namespace devDept.Serialization;

public class TextStyleSurrogate : Surrogate<TextStyle>
{
	public string Name;

	public string FontFamilyName;

	public fontStyle Style;

	public double WidthFactor;

	public string FileName;

	internal ShapeFile shapeFile;

	public string XRefName;

	public TextStyleSurrogate(TextStyle textStyle)
		: base(textStyle)
	{
	}

	protected override TextStyle ConvertToObject()
	{
		TextStyle textStyle = new TextStyle(this);
		CopyDataToObject(textStyle);
		return textStyle;
	}

	protected override void CopyDataToObject(TextStyle ts)
	{
		ts.Name = Name;
		ts.FontFamilyName = FontFamilyName;
		ts.Style = Style;
		ts.WidthFactor = WidthFactor;
		ts.FileName = FileName;
		ts.shapeFile = shapeFile;
		ts.XRefName = XRefName;
	}

	protected override void CopyDataFromObject(TextStyle ts)
	{
		Name = ts.Name;
		FontFamilyName = ts.FontFamilyName;
		Style = ts.Style;
		WidthFactor = ts.WidthFactor;
		FileName = ts.FileName;
		shapeFile = ts.shapeFile;
		XRefName = ts.XRefName;
	}

	public static implicit operator TextStyle(TextStyleSurrogate surrogate)
	{
		return surrogate?.ConvertToObject();
	}

	public static implicit operator TextStyleSurrogate(TextStyle source)
	{
		return source?.ConvertToSurrogate();
	}
}
