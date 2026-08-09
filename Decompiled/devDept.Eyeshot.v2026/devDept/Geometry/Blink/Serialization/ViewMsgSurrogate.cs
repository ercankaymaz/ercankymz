using devDept.Eyeshot;
using devDept.Geometry.Blink.Message;

namespace devDept.Geometry.Blink.Serialization;

internal class ViewMsgSurrogate : BlinkMsgSurrogate
{
	public viewType View;

	public ViewMsgSurrogate(ViewMsg obj)
		: base(obj)
	{
	}

	protected override BlinkMsg ConvertToObject()
	{
		ViewMsg viewMsg = new ViewMsg();
		CopyDataToObject(viewMsg);
		return viewMsg;
	}

	protected override void CopyDataToObject(BlinkMsg obj)
	{
		((ViewMsg)obj).View = View;
	}

	protected override void CopyDataFromObject(BlinkMsg obj)
	{
		ViewMsg viewMsg = (ViewMsg)obj;
		View = viewMsg.View;
	}
}
