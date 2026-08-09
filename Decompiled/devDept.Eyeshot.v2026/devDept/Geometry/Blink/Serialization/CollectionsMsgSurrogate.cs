using devDept.Eyeshot;
using devDept.Geometry.Blink.Message;

namespace devDept.Geometry.Blink.Serialization;

internal class CollectionsMsgSurrogate : BlinkMsgSurrogate
{
	public MaterialKeyedCollection Materials;

	public TextStyleKeyedCollection TextStyles;

	public CollectionsMsgSurrogate(CollectionsMsg obj)
		: base(obj)
	{
	}

	protected override BlinkMsg ConvertToObject()
	{
		CollectionsMsg collectionsMsg = new CollectionsMsg();
		CopyDataToObject(collectionsMsg);
		return collectionsMsg;
	}

	protected override void CopyDataToObject(BlinkMsg obj)
	{
		CollectionsMsg obj2 = (CollectionsMsg)obj;
		obj2.Materials = Materials;
		obj2.TextStyles = TextStyles;
	}

	protected override void CopyDataFromObject(BlinkMsg obj)
	{
		CollectionsMsg collectionsMsg = (CollectionsMsg)obj;
		Materials = collectionsMsg.Materials;
		TextStyles = collectionsMsg.TextStyles;
	}
}
