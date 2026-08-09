using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.PresentationResource;

namespace Xbim.Ifc2x3.PresentationDefinitionResource;

[ExpressType("IfcPreDefinedSymbol", 568)]
public abstract class IfcPreDefinedSymbol : IfcPreDefinedItem, IfcDefinedSymbolSelect, IExpressSelectType, IPersist, IPersistEntity, IEquatable<IfcPreDefinedSymbol>
{
	internal IfcPreDefinedSymbol(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex == 0)
		{
			base.Parse(propIndex, value, nestedIndex);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcPreDefinedSymbol other)
	{
		return this == other;
	}
}
