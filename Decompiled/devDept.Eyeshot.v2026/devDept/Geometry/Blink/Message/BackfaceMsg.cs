using devDept.Geometry.Blink.Serialization;
using devDept.Graphics;

namespace devDept.Geometry.Blink.Message;

internal class BackfaceMsg : BlinkMsg
{
	public backfaceColorMethodType ColorMethod;

	public BackfaceMsg(backfaceColorMethodType colorMethod = backfaceColorMethodType.SingleColor)
	{
		ColorMethod = colorMethod;
	}

	internal override BlinkMsgSurrogate ConvertToSurrogate()
	{
		return new BackfaceMsgSurrogate(this);
	}
}
