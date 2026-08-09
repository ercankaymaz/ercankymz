using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationAppearanceResource;

namespace Xbim.Ifc4x3.PresentationAppearanceResource;

[ExpressType("IfcDraughtingPreDefinedCurveFont", 286)]
public class IfcDraughtingPreDefinedCurveFont : IfcPreDefinedCurveFont, IIfcDraughtingPreDefinedCurveFont, IIfcPreDefinedCurveFont, IIfcPreDefinedItem, IIfcPresentationItem, IPersistEntity, IPersist, Xbim.Ifc4.PresentationAppearanceResource.IfcCurveStyleFontSelect, Xbim.Ifc4.PresentationAppearanceResource.IfcCurveFontOrScaledCurveFontSelect, IIfcCurveFontOrScaledCurveFontSelect, IExpressSelectType, IIfcCurveStyleFontSelect, IInstantiableEntity, IEquatable<IfcDraughtingPreDefinedCurveFont>
{
	internal IfcDraughtingPreDefinedCurveFont(IModel model, int label, bool activated)
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

	public bool Equals(IfcDraughtingPreDefinedCurveFont other)
	{
		return this == other;
	}
}
