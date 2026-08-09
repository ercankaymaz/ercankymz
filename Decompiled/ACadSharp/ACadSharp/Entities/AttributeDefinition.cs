using ACadSharp.Attributes;

namespace ACadSharp.Entities;

[DxfName("ATTDEF")]
[DxfSubClass("AcDbAttributeDefinition")]
public class AttributeDefinition : AttributeBase
{
	public override ObjectType ObjectType => ObjectType.ATTDEF;

	public override string ObjectName => "ATTDEF";

	public override string SubclassMarker => "AcDbAttributeDefinition";

	[DxfCodeValue(new int[] { 3 })]
	public string Prompt { get; set; } = string.Empty;

	public AttributeDefinition()
	{
	}

	public AttributeDefinition(AttributeEntity entity)
		: this()
	{
		matchAttributeProperties(entity);
	}
}
