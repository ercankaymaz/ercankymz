using devDept.Eyeshot.Entities;

namespace devDept.Serialization;

public class AttributeReferenceDataSurrogate : AttributeBaseSurrogate
{
	internal AttributeReferenceDataSurrogate(AttributeReferenceData _0023_003DzqINbf9CkbJbT)
		: base(_0023_003DzqINbf9CkbJbT)
	{
	}

	protected override Entity ConvertToObject()
	{
		AttributeReferenceData attributeReferenceData = new AttributeReferenceData(this);
		CopyDataToObject(attributeReferenceData);
		return attributeReferenceData;
	}
}
