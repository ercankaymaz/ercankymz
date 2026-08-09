using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc2x3.TopologyResource;

[ExpressType("IfcFaceBound", 86)]
public class IfcFaceBound : IfcTopologicalRepresentationItem, IIfcFaceBound, IIfcTopologicalRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcFaceBound>
{
	private IfcLoop _bound;

	private bool _orientation;

	[CrossSchemaAttribute(typeof(IIfcFaceBound), 1)]
	IIfcLoop IIfcFaceBound.Bound
	{
		get
		{
			return Bound;
		}
		set
		{
			Bound = value as IfcLoop;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcFaceBound), 2)]
	IfcBoolean IIfcFaceBound.Orientation
	{
		get
		{
			return new IfcBoolean(Orientation);
		}
		set
		{
			Orientation = value;
		}
	}

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcLoop Bound
	{
		get
		{
			if (_activated)
			{
				return _bound;
			}
			Activate();
			return _bound;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcLoop v)
			{
				_bound = v;
			}, _bound, value, "Bound", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public bool Orientation
	{
		get
		{
			if (_activated)
			{
				return _orientation;
			}
			Activate();
			return _orientation;
		}
		set
		{
			SetValue(delegate(bool v)
			{
				_orientation = v;
			}, _orientation, value, "Orientation", 2);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (Bound != null)
			{
				yield return Bound;
			}
		}
	}

	internal IfcFaceBound(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_bound = (IfcLoop)value.EntityVal;
			break;
		case 1:
			_orientation = value.BooleanVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcFaceBound other)
	{
		return this == other;
	}
}
