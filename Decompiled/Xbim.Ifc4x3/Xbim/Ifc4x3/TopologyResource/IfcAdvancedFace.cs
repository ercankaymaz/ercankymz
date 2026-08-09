using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4x3.TopologyResource;

[ExpressType("IfcAdvancedFace", 1094)]
public class IfcAdvancedFace : IfcFaceSurface, IIfcAdvancedFace, IIfcFaceSurface, IIfcFace, IIfcTopologicalRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcSurfaceOrFaceSurface, IIfcSurfaceOrFaceSurface, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcAdvancedFace>
{
	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcFaceBound bound in base.Bounds)
			{
				yield return bound;
			}
			if (base.FaceSurface != null)
			{
				yield return base.FaceSurface;
			}
		}
	}

	internal IfcAdvancedFace(IModel model, int label, bool activated)
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

	public bool Equals(IfcAdvancedFace other)
	{
		return this == other;
	}
}
