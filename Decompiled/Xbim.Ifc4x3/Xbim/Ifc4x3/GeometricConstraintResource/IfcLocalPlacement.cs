using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4x3.GeometryResource;

namespace Xbim.Ifc4x3.GeometricConstraintResource;

[ExpressType("IfcLocalPlacement", 481)]
public class IfcLocalPlacement : IfcObjectPlacement, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcLocalPlacement>, IIfcLocalPlacement, IIfcObjectPlacement
{
	private IfcAxis2Placement _relativePlacement;

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
	public IfcAxis2Placement RelativePlacement
	{
		get
		{
			if (_activated)
			{
				return _relativePlacement;
			}
			Activate();
			return _relativePlacement;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcAxis2Placement v)
			{
				_relativePlacement = v;
			}, _relativePlacement, value, "RelativePlacement", 2);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.PlacementRelTo != null)
			{
				yield return base.PlacementRelTo;
			}
			if (RelativePlacement != null)
			{
				yield return RelativePlacement;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (base.PlacementRelTo != null)
			{
				yield return base.PlacementRelTo;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcLocalPlacement), 1)]
	IIfcObjectPlacement IIfcLocalPlacement.PlacementRelTo
	{
		get
		{
			return base.PlacementRelTo;
		}
		set
		{
			base.PlacementRelTo = value as IfcObjectPlacement;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcLocalPlacement), 2)]
	IIfcAxis2Placement IIfcLocalPlacement.RelativePlacement
	{
		get
		{
			if (RelativePlacement == null)
			{
				return null;
			}
			IfcAxis2Placement2D ifcAxis2Placement2D = RelativePlacement as IfcAxis2Placement2D;
			if (ifcAxis2Placement2D != null)
			{
				return ifcAxis2Placement2D;
			}
			IfcAxis2Placement3D ifcAxis2Placement3D = RelativePlacement as IfcAxis2Placement3D;
			if (ifcAxis2Placement3D != null)
			{
				return ifcAxis2Placement3D;
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				RelativePlacement = null;
				return;
			}
			IfcAxis2Placement2D ifcAxis2Placement2D = value as IfcAxis2Placement2D;
			if (ifcAxis2Placement2D != null)
			{
				RelativePlacement = ifcAxis2Placement2D;
				return;
			}
			IfcAxis2Placement3D ifcAxis2Placement3D = value as IfcAxis2Placement3D;
			if (ifcAxis2Placement3D != null)
			{
				RelativePlacement = ifcAxis2Placement3D;
			}
		}
	}

	internal IfcLocalPlacement(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 1:
			_relativePlacement = (IfcAxis2Placement)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcLocalPlacement other)
	{
		return this == other;
	}
}
