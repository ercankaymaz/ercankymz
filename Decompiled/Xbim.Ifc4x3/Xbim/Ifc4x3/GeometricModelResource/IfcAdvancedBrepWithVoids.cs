using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4x3.TopologyResource;

namespace Xbim.Ifc4x3.GeometricModelResource;

[ExpressType("IfcAdvancedBrepWithVoids", 1093)]
public class IfcAdvancedBrepWithVoids : IfcAdvancedBrep, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcAdvancedBrepWithVoids>, IIfcAdvancedBrepWithVoids, IIfcAdvancedBrep, IIfcManifoldSolidBrep, IIfcSolidModel, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, Xbim.Ifc4.GeometricModelResource.IfcBooleanOperand, IIfcBooleanOperand, IfcSolidOrShell, IIfcSolidOrShell
{
	private readonly ItemSet<IfcClosedShell> _voids;

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

	[CrossSchemaAttribute(typeof(IIfcAdvancedBrepWithVoids), 2)]
	IItemSet<IIfcClosedShell> IIfcAdvancedBrepWithVoids.Voids => new ProxyItemSet<IfcClosedShell, IIfcClosedShell>(Voids);

	internal IfcAdvancedBrepWithVoids(IModel model, int label, bool activated)
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

	public bool Equals(IfcAdvancedBrepWithVoids other)
	{
		return this == other;
	}
}
