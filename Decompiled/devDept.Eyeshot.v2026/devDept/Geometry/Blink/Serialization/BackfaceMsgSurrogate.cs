using devDept.Geometry.Blink.Message;
using devDept.Graphics;

namespace devDept.Geometry.Blink.Serialization;

internal class BackfaceMsgSurrogate : BlinkMsgSurrogate
{
	public backfaceColorMethodType ColorMethod;

	public BackfaceMsgSurrogate(BackfaceMsg obj)
		: base(obj)
	{
	}

	protected override BlinkMsg ConvertToObject()
	{
		BackfaceMsg backfaceMsg = new BackfaceMsg();
		CopyDataToObject(backfaceMsg);
		return backfaceMsg;
	}

	protected override void CopyDataToObject(BlinkMsg obj)
	{
		((BackfaceMsg)obj).ColorMethod = ColorMethod;
	}

	protected override void CopyDataFromObject(BlinkMsg obj)
	{
		BackfaceMsg backfaceMsg = (BackfaceMsg)obj;
		ColorMethod = backfaceMsg.ColorMethod;
	}
}
