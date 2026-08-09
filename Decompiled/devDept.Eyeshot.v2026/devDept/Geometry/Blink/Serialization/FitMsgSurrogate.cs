using System.Collections.Generic;
using devDept.Eyeshot.Entities;
using devDept.Geometry.Blink.Message;

namespace devDept.Geometry.Blink.Serialization;

internal class FitMsgSurrogate : BlinkMsgSurrogate
{
	public IList<Entity> EntityList;

	public FitMsgSurrogate(FitMsg obj)
		: base(obj)
	{
	}

	protected override BlinkMsg ConvertToObject()
	{
		FitMsg fitMsg = new FitMsg();
		CopyDataToObject(fitMsg);
		return fitMsg;
	}

	protected override void CopyDataToObject(BlinkMsg obj)
	{
		((FitMsg)obj).EntityList = EntityList;
	}

	protected override void CopyDataFromObject(BlinkMsg obj)
	{
		FitMsg fitMsg = (FitMsg)obj;
		EntityList = fitMsg.EntityList;
	}
}
