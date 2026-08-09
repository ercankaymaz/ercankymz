using devDept.Eyeshot;

namespace devDept.Serialization;

internal class TextStyleExSurrogate : TextStyleSurrogate
{
	public string XRefName_V12;

	public TextStyleExSurrogate(TextStyleEx textStyleEx)
		: base(textStyleEx)
	{
	}

	protected override TextStyle ConvertToObject()
	{
		TextStyle textStyle = new TextStyle(Name, FontFamilyName, Style);
		XRefName = XRefName_V12;
		CopyDataToObject(textStyle);
		return textStyle;
	}
}
