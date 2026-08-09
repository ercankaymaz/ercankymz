using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.ExternalReferenceResource;

namespace Xbim.Ifc2x3.PresentationDefinitionResource;

[ExpressType("IfcExternallyDefinedSymbol", 391)]
public class IfcExternallyDefinedSymbol : IfcExternalReference, IInstantiableEntity, IPersistEntity, IPersist, IfcDefinedSymbolSelect, IExpressSelectType, IEquatable<IfcExternallyDefinedSymbol>
{
	internal IfcExternallyDefinedSymbol(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if ((uint)propIndex <= 2u)
		{
			base.Parse(propIndex, value, nestedIndex);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcExternallyDefinedSymbol other)
	{
		return this == other;
	}
}
