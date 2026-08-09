using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.PresentationAppearanceResource;

namespace Xbim.Ifc2x3.PresentationDefinitionResource;

[ExpressType("IfcAnnotationOccurrence", 58)]
public abstract class IfcAnnotationOccurrence : IfcStyledItem, IEquatable<IfcAnnotationOccurrence>
{
	internal IfcAnnotationOccurrence(IModel model, int label, bool activated)
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

	public bool Equals(IfcAnnotationOccurrence other)
	{
		return this == other;
	}
}
