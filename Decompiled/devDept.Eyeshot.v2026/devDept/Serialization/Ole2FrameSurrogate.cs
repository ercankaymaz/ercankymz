using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Translators;

namespace devDept.Serialization;

public class Ole2FrameSurrogate : PictureSurrogate
{
	public Ole2FrameSurrogate(Ole2Frame ole2Frame)
		: base(ole2Frame)
	{
	}

	protected override Entity ConvertToObject()
	{
		Ole2Frame ole2Frame = new Ole2Frame(this);
		CopyDataToObject(ole2Frame);
		return ole2Frame;
	}
}
