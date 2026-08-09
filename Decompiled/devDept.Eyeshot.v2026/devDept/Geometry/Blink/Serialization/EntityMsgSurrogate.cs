using System.Drawing;
using devDept.Eyeshot.Entities;
using devDept.Geometry.Blink.Message;

namespace devDept.Geometry.Blink.Serialization;

internal class EntityMsgSurrogate : BlinkMsgSurrogate
{
	public Entity Entity;

	public Color? Color;

	public float? LineWeight;

	public string LayerName;

	public EntityMsgSurrogate(EntityMsg obj)
		: base(obj)
	{
	}

	protected override BlinkMsg ConvertToObject()
	{
		EntityMsg entityMsg = new EntityMsg();
		CopyDataToObject(entityMsg);
		return entityMsg;
	}

	protected override void CopyDataToObject(BlinkMsg obj)
	{
		EntityMsg obj2 = (EntityMsg)obj;
		obj2.Entity = Entity;
		obj2.Color = Color;
		obj2.LineWeight = LineWeight;
		obj2.LayerName = LayerName;
	}

	protected override void CopyDataFromObject(BlinkMsg obj)
	{
		EntityMsg entityMsg = (EntityMsg)obj;
		Entity = entityMsg.Entity;
		Color = entityMsg.Color;
		LineWeight = entityMsg.LineWeight;
		LayerName = entityMsg.LayerName;
	}
}
