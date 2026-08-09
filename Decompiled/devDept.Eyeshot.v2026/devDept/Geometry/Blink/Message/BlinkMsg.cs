using devDept.Geometry.Blink.Serialization;

namespace devDept.Geometry.Blink.Message;

internal abstract class BlinkMsg
{
	internal BlinkMsg()
	{
	}

	internal abstract BlinkMsgSurrogate ConvertToSurrogate();
}
