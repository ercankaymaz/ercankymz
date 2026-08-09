using devDept.Eyeshot;

namespace devDept.Serialization;

internal class LineTypeExSurrogate : LineTypeSurrogate
{
	public string XRefName_V12;

	public LineTypeExSurrogate(LineTypeEx lpEx)
		: base(lpEx)
	{
	}

	protected override LineType ConvertToObject()
	{
		LineType lineType = new LineType(Name, Pattern);
		XRefName = XRefName_V12;
		CopyDataToObject(lineType);
		return lineType;
	}
}
