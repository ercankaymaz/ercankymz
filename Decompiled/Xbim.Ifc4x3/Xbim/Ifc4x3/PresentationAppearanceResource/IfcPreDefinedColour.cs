using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationAppearanceResource;

namespace Xbim.Ifc4x3.PresentationAppearanceResource;

[ExpressType("IfcPreDefinedColour", 608)]
public abstract class IfcPreDefinedColour : IfcPreDefinedItem, IIfcPreDefinedColour, IIfcPreDefinedItem, IIfcPresentationItem, IPersistEntity, IPersist, Xbim.Ifc4.PresentationAppearanceResource.IfcColour, Xbim.Ifc4.PresentationAppearanceResource.IfcFillStyleSelect, IIfcFillStyleSelect, IExpressSelectType, IIfcColour, IfcColour, IfcFillStyleSelect, IEquatable<IfcPreDefinedColour>
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
