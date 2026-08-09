using devDept.Eyeshot.Entities;

namespace devDept.Serialization;

public class MultilineTextSurrogate : TextSurrogate
{
	public double RectWidth;

	public double RectHeight;

	public double LineSpaceDistance;

	public double[] WidthFactors;

	public bool Wrap;

	public string Contents;

	public MultilineTextSurrogate(MultilineText multilineText)
		: base(multilineText)
	{
	}

	protected override Entity ConvertToObject()
	{
		MultilineText multilineText = new MultilineText(this);
		CopyDataToObject(multilineText);
		return multilineText;
	}

	protected override void CopyDataToObject(Entity entity)
	{
		MultilineText obj = entity as MultilineText;
		obj.RectWidth = RectWidth;
		obj.RectHeight = RectHeight;
		obj.LineSpaceDistance = LineSpaceDistance;
		obj.WidthFactors = WidthFactors;
		obj.Wrap = Wrap;
		obj.Contents = Contents;
		base.CopyDataToObject(entity);
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		MultilineText multilineText = entity as MultilineText;
		RectWidth = multilineText.RectWidth;
		RectHeight = multilineText.RectHeight;
		LineSpaceDistance = multilineText.LineSpaceDistance;
		WidthFactors = multilineText.WidthFactors;
		Wrap = multilineText.Wrap;
		Contents = multilineText.Contents;
		base.CopyDataFromObject(entity);
	}
}
