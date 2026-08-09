using ACadSharp.Attributes;

namespace ACadSharp.Entities;

[DxfName("ATTRIB")]
[DxfSubClass("AcDbAttribute")]
public class AttributeEntity : AttributeBase
{
	public override ObjectType ObjectType => ObjectType.ATTRIB;

	public override string ObjectName => "ATTRIB";

	public override string SubclassMarker => "AcDbAttribute";

	public AttributeEntity()
	{
	}

	public AttributeEntity(AttributeDefinition definition)
		: this()
	{
		matchAttributeProperties(definition);
	}
}
