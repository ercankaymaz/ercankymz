using devDept.Geometry.Blink.Message;

namespace devDept.Geometry.Blink.Serialization;

internal class ClearMsgSurrogate : BlinkMsgSurrogate
{
	public string Layer;

	public ClearMsgSurrogate(ClearMsg obj)
		: base(obj)
	{
	}

	protected override BlinkMsg ConvertToObject()
	{
		ClearMsg clearMsg = new ClearMsg();
		CopyDataToObject(clearMsg);
		return clearMsg;
	}

	protected override void CopyDataToObject(BlinkMsg obj)
	{
		((ClearMsg)obj).Layer = Layer;
	}

	protected override void CopyDataFromObject(BlinkMsg obj)
	{
		ClearMsg clearMsg = (ClearMsg)obj;
		Layer = clearMsg.Layer;
	}
}
