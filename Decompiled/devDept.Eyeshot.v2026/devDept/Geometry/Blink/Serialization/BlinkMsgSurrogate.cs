using devDept.Geometry.Blink.Message;
using devDept.Serialization;

namespace devDept.Geometry.Blink.Serialization;

internal class BlinkMsgSurrogate : Surrogate<BlinkMsg>
{
	public BlinkMsgSurrogate(BlinkMsg obj)
		: base(obj)
	{
	}

	protected override BlinkMsg ConvertToObject()
	{
		return null;
	}

	protected override void CopyDataToObject(BlinkMsg obj)
	{
	}

	protected override void CopyDataFromObject(BlinkMsg obj)
	{
	}

	public static implicit operator BlinkMsg(BlinkMsgSurrogate surrogate)
	{
		return surrogate?.ConvertToObject();
	}

	public static implicit operator BlinkMsgSurrogate(BlinkMsg source)
	{
		return source?.ConvertToSurrogate();
	}
}
