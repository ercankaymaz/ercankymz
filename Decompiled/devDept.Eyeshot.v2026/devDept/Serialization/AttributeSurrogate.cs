using devDept.Eyeshot.Entities;

namespace devDept.Serialization;

public class AttributeSurrogate : AttributeBaseSurrogate
{
	public string Value;

	public string Prompt;

	public AttributeSurrogate(Attribute att)
		: base(att)
	{
	}

	protected override Entity ConvertToObject()
	{
		Attribute attribute = new Attribute(this);
		CopyDataToObject(attribute);
		return attribute;
	}

	protected override void CopyDataToObject(Entity entity)
	{
		Attribute obj = entity as Attribute;
		obj.Value = Value;
		obj.Prompt = Prompt;
		base.CopyDataToObject(entity);
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		Attribute attribute = entity as Attribute;
		Value = attribute.Value;
		Prompt = attribute.Prompt;
		base.CopyDataFromObject(entity);
	}
}
