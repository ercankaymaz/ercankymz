using System.Collections.Generic;
using Org.BouncyCastle.Asn1.Cms;

namespace Org.BouncyCastle.Cms;

public class SimpleAttributeTableGenerator : CmsAttributeTableGenerator
{
	private readonly AttributeTable attributes;

	public SimpleAttributeTableGenerator(AttributeTable attributes)
	{
		this.attributes = attributes;
	}

	public virtual AttributeTable GetAttributes(IDictionary<CmsAttributeTableParameter, object> parameters)
	{
		return attributes;
	}
}
