using devDept.Eyeshot;
using devDept.Geometry.Blink.Serialization;

namespace devDept.Geometry.Blink.Message;

internal class CollectionsMsg : BlinkMsg
{
	public MaterialKeyedCollection Materials;

	public TextStyleKeyedCollection TextStyles;

	internal override BlinkMsgSurrogate ConvertToSurrogate()
	{
		return new CollectionsMsgSurrogate(this);
	}
}
