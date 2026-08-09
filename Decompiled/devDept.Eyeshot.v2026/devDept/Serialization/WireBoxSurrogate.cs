using devDept.Eyeshot.Entities;

namespace devDept.Serialization;

public class WireBoxSurrogate : LinearPathSurrogate
{
	public WireBoxSurrogate(WireBox wb)
		: base(wb)
	{
	}

	protected override Entity ConvertToObject()
	{
		WireBox wireBox = new WireBox(this);
		CopyDataToObject(wireBox);
		return wireBox;
	}
}
