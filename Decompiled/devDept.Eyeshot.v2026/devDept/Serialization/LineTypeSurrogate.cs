using devDept.Eyeshot;

namespace devDept.Serialization;

public class LineTypeSurrogate : Surrogate<LineType>
{
	public string Name;

	public float[] Pattern;

	public string Description;

	public float Length;

	public string XRefName;

	public LineTypeSurrogate(LineType lineType)
		: base(lineType)
	{
	}

	protected override LineType ConvertToObject()
	{
		LineType lineType = new LineType(this);
		CopyDataToObject(lineType);
		return lineType;
	}

	protected override void CopyDataToObject(LineType lineType)
	{
		lineType.Name = Name;
		lineType.Description = Description;
		lineType._0023_003Dzz7VuV7VFyvdX(Length);
		lineType.XRefName = XRefName;
	}

	protected override void CopyDataFromObject(LineType lineType)
	{
		Name = lineType.Name;
		Pattern = lineType.Pattern;
		Description = lineType.Description;
		Length = lineType.Length;
		XRefName = lineType.XRefName;
	}

	public static implicit operator LineType(LineTypeSurrogate surrogate)
	{
		return surrogate?.ConvertToObject();
	}

	public static implicit operator LineTypeSurrogate(LineType source)
	{
		return source?.ConvertToSurrogate();
	}
}
