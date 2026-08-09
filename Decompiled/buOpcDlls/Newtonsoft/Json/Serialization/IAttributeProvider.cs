using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Serialization;

[Newtonsoft_002EJson_002ENullableContext(1)]
public interface IAttributeProvider
{
	IList<Attribute> GetAttributes(bool inherit);

	IList<Attribute> GetAttributes(Type attributeType, bool inherit);
}
