using devDept.Eyeshot.Entities;

namespace devDept.Serialization;

public abstract class AttributeBaseSurrogate : TextSurrogate
{
	public bool Invisible;

	public bool Constant;

	public bool Verify;

	public bool Preset;

	public AttributeBaseSurrogate(AttributeBase attBase)
		: base(attBase)
	{
	}

	protected abstract override Entity ConvertToObject();

	protected override void CopyDataToObject(Entity entity)
	{
		AttributeBase obj = entity as AttributeBase;
		obj.Invisible = Invisible;
		obj.Constant = Constant;
		obj.Verify = Verify;
		obj.Preset = Preset;
		base.CopyDataToObject(entity);
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		AttributeBase attributeBase = entity as AttributeBase;
		Invisible = attributeBase.Invisible;
		Constant = attributeBase.Constant;
		Verify = attributeBase.Verify;
		Preset = attributeBase.Preset;
		base.CopyDataFromObject(entity);
	}
}
