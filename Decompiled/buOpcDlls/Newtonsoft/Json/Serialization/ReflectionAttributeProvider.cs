using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Utilities;

namespace Newtonsoft.Json.Serialization;

[Newtonsoft_002EJson_002ENullableContext(1)]
[Newtonsoft_002EJson_002ENullable(0)]
public class ReflectionAttributeProvider : IAttributeProvider
{
	private readonly object _attributeProvider;

	public ReflectionAttributeProvider(object attributeProvider)
	{
		ValidationUtils.ArgumentNotNull(attributeProvider, "attributeProvider");
		_attributeProvider = attributeProvider;
	}

	public IList<Attribute> GetAttributes(bool inherit)
	{
		return ReflectionUtils.GetAttributes(_attributeProvider, null, inherit);
	}

	public IList<Attribute> GetAttributes(Type attributeType, bool inherit)
	{
		return ReflectionUtils.GetAttributes(_attributeProvider, attributeType, inherit);
	}
}
