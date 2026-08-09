using devDept.Eyeshot.Control.Labels;

namespace devDept.Serialization;

public class OutlinedTextSurrogate : TextOnlySurrogate
{
	public OutlinedTextSurrogate(OutlinedText outlinedText)
		: base(outlinedText)
	{
	}

	protected override Label ConvertToObject()
	{
		OutlinedText outlinedText = new OutlinedText(AnchorPoint, Text, Font, Color);
		CopyDataToObject(outlinedText);
		return outlinedText;
	}
}
