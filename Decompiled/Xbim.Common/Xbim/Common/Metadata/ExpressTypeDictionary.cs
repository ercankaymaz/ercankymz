using System;
using System.Collections.Generic;

namespace Xbim.Common.Metadata;

public class ExpressTypeDictionary : Dictionary<Type, ExpressType>
{
	public ExpressType this[IPersist ent] => base[ent.GetType()];
}
