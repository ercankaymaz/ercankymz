using System.Drawing;
using devDept.Eyeshot.Entities;
using devDept.Geometry.Blink.Serialization;

namespace devDept.Geometry.Blink.Message;

internal class EntityMsg : BlinkMsg
{
	public Entity Entity;

	public Color? Color;

	public float? LineWeight;

	public string LayerName;

	public EntityMsg(Entity ent, Color? color, float? lineWeight, string layerName)
	{
		Entity = ent;
		Color = color;
		LineWeight = lineWeight;
		LayerName = layerName;
	}

	internal EntityMsg()
	{
	}

	internal override BlinkMsgSurrogate ConvertToSurrogate()
	{
		return new EntityMsgSurrogate(this);
	}
}
