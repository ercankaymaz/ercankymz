using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.TopologyResource;

[ExpressType("IfcFaceOuterBound", 201)]
public class IfcFaceOuterBound : IfcFaceBound, IInstantiableEntity, IPersistEntity, IPersist, IIfcFaceOuterBound, IIfcFaceBound, IIfcTopologicalRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcFaceOuterBound>
{
	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.Bound != null)
			{
				yield return base.Bound;
			}
		}
	}

	internal IfcFaceOuterBound(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if ((uint)propIndex <= 1u)
		{
			base.Parse(propIndex, value, nestedIndex);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcFaceOuterBound other)
	{
		return this == other;
	}
}
