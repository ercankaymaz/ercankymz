using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4.PresentationAppearanceResource;

[ExpressType("IfcPreDefinedColour", 608)]
public abstract class IfcPreDefinedColour : IfcPreDefinedItem, IIfcPreDefinedColour, IIfcPreDefinedItem, IIfcPresentationItem, IPersistEntity, IPersist, IfcColour, IfcFillStyleSelect, IIfcFillStyleSelect, IExpressSelectType, IIfcColour, IEquatable<IfcPreDefinedColour>
{
	internal IfcPreDefinedColour(IModel model, int label, bool activated)
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

	public bool Equals(IfcPreDefinedColour other)
	{
		return this == other;
	}
}
