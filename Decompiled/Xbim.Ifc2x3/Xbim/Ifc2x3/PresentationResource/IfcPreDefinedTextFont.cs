using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationAppearanceResource;

namespace Xbim.Ifc2x3.PresentationResource;

[ExpressType("IfcPreDefinedTextFont", 504)]
public abstract class IfcPreDefinedTextFont : IfcPreDefinedItem, IIfcPreDefinedTextFont, IIfcPreDefinedItem, IIfcPresentationItem, IPersistEntity, IPersist, Xbim.Ifc4.PresentationAppearanceResource.IfcTextFontSelect, IIfcTextFontSelect, IExpressSelectType, IfcTextFontSelect, IEquatable<IfcPreDefinedTextFont>
{
	internal IfcPreDefinedTextFont(IModel model, int label, bool activated)
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

	public bool Equals(IfcPreDefinedTextFont other)
	{
		return this == other;
	}
}
