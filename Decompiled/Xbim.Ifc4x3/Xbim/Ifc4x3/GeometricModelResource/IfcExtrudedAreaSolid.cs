using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4x3.GeometryResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.GeometricModelResource;

[ExpressType("IfcExtrudedAreaSolid", 238)]
public class IfcExtrudedAreaSolid : IfcSweptAreaSolid, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcExtrudedAreaSolid>, IIfcExtrudedAreaSolid, IIfcSweptAreaSolid, IIfcSolidModel, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, Xbim.Ifc4.GeometricModelResource.IfcBooleanOperand, IIfcBooleanOperand, IfcSolidOrShell, IIfcSolidOrShell
{
	private IfcDirection _extrudedDirection;

	private Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure _depth;

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcDirection ExtrudedDirection
	{
		get
		{
			if (_activated)
			{
				return _extrudedDirection;
			}
			Activate();
			return _extrudedDirection;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcDirection v)
			{
				_extrudedDirection = v;
			}, _extrudedDirection, value, "ExtrudedDirection", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure Depth
	{
		get
		{
			if (_activated)
			{
				return _depth;
			}
			Activate();
			return _depth;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure v)
			{
				_depth = v;
			}, _depth, value, "Depth", 4);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.SweptArea != null)
			{
				yield return base.SweptArea;
			}
			if (base.Position != null)
			{
				yield return base.Position;
			}
			if (ExtrudedDirection != null)
			{
				yield return ExtrudedDirection;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcExtrudedAreaSolid), 3)]
	IIfcDirection IIfcExtrudedAreaSolid.ExtrudedDirection
	{
		get
		{
			return ExtrudedDirection;
		}
		set
		{
			ExtrudedDirection = value as IfcDirection;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcExtrudedAreaSolid), 4)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure IIfcExtrudedAreaSolid.Depth
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(Depth);
		}
		set
		{
			Depth = new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure(value);
		}
	}

	internal IfcExtrudedAreaSolid(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 2:
			_extrudedDirection = (IfcDirection)value.EntityVal;
			break;
		case 3:
			_depth = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcExtrudedAreaSolid other)
	{
		return this == other;
	}
}
