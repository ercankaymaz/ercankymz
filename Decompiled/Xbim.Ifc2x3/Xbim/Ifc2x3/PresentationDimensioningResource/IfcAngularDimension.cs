using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;

namespace Xbim.Ifc2x3.PresentationDimensioningResource;

[ExpressType("IfcAngularDimension", 738)]
public class IfcAngularDimension : IfcDimensionCurveDirectedCallout, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcAngularDimension>
{
	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcDraughtingCalloutElement content in base.Contents)
			{
				yield return content;
			}
		}
	}

	internal IfcAngularDimension(IModel model, int label, bool activated)
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

	public bool Equals(IfcAngularDimension other)
	{
		return this == other;
	}
}
