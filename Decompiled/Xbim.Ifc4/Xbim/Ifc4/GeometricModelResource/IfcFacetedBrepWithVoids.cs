using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.TopologyResource;

namespace Xbim.Ifc4.GeometricModelResource;

[ExpressType("IfcFacetedBrepWithVoids", 369)]
public class IfcFacetedBrepWithVoids : IfcFacetedBrep, IInstantiableEntity, IPersistEntity, IPersist, IIfcFacetedBrepWithVoids, IIfcFacetedBrep, IIfcManifoldSolidBrep, IIfcSolidModel, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcBooleanOperand, IIfcBooleanOperand, IfcSolidOrShell, IIfcSolidOrShell, IContainsEntityReferences, IEquatable<IfcFacetedBrepWithVoids>
{
	private readonly ItemSet<IfcClosedShell> _voids;

	IItemSet<IIfcClosedShell> IIfcFacetedBrepWithVoids.Voids => new ProxyItemSet<IfcClosedShell, IIfcClosedShell>(Voids);

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 4)]
	public IItemSet<IfcClosedShell> Voids
	{
		get
		{
			if (_activated)
			{
				return _voids;
			}
			Activate();
			return _voids;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.Outer != null)
			{
				yield return base.Outer;
			}
			foreach (IfcClosedShell @void in Voids)
			{
				yield return @void;
			}
		}
	}

	internal IfcFacetedBrepWithVoids(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_voids = new ItemSet<IfcClosedShell>(this, 0, 2);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 1:
			_voids.InternalAdd((IfcClosedShell)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcFacetedBrepWithVoids other)
	{
		return this == other;
	}
}
