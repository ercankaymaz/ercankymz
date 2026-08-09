using devDept.Geometry.Blink.Serialization;

namespace devDept.Geometry.Blink.Message;

internal class ClearMsg : BlinkMsg
{
	public string Layer;

	public ClearMsg(string layer = null)
	{
		Layer = layer;
	}

	internal override BlinkMsgSurrogate ConvertToSurrogate()
	{
		return new ClearMsgSurrogate(this);
	}
}
