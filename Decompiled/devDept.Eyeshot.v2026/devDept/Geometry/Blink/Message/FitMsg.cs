using System.Collections.Generic;
using devDept.Eyeshot.Entities;
using devDept.Geometry.Blink.Serialization;

namespace devDept.Geometry.Blink.Message;

internal class FitMsg : BlinkMsg
{
	public IList<Entity> EntityList;

	public FitMsg(IList<Entity> entList = null)
	{
		EntityList = entList;
	}

	internal override BlinkMsgSurrogate ConvertToSurrogate()
	{
		return new FitMsgSurrogate(this);
	}
}
