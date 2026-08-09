using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationAppearanceResource;

namespace Xbim.Ifc4x3.PresentationAppearanceResource;

[ExpressType("IfcDraughtingPreDefinedColour", 607)]
public class IfcDraughtingPreDefinedColour : IfcPreDefinedColour, IIfcDraughtingPreDefinedColour, IIfcPreDefinedColour, IIfcPreDefinedItem, IIfcPresentationItem, IPersistEntity, IPersist, Xbim.Ifc4.PresentationAppearanceResource.IfcColour, Xbim.Ifc4.PresentationAppearanceResource.IfcFillStyleSelect, IIfcFillStyleSelect, IExpressSelectType, IIfcColour, IInstantiableEntity, IEquatable<IfcDraughtingPreDefinedColour>
{
	internal IfcDraughtingPreDefinedColour(IModel model, int label, bool activated)
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

	public bool Equals(IfcDraughtingPreDefinedColour other)
	{
		return this == other;
	}
}
