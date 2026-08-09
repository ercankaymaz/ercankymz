using devDept.Eyeshot;
using devDept.Geometry.Blink.Serialization;

namespace devDept.Geometry.Blink.Message;

internal class ViewMsg : BlinkMsg
{
	public viewType View;

	internal ViewMsg()
	{
	}

	public ViewMsg(viewType view)
	{
		View = view;
	}

	internal override BlinkMsgSurrogate ConvertToSurrogate()
	{
		return new ViewMsgSurrogate(this);
	}
}
