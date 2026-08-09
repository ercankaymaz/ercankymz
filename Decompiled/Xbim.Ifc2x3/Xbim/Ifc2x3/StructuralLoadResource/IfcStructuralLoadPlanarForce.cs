using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.StructuralLoadResource;

[ExpressType("IfcStructuralLoadPlanarForce", 174)]
public class IfcStructuralLoadPlanarForce : IfcStructuralLoadStatic, IIfcStructuralLoadPlanarForce, IIfcStructuralLoadStatic, IIfcStructuralLoadOrResult, IIfcStructuralLoad, IPersistEntity, IPersist, IInstantiableEntity, IEquatable<IfcStructuralLoadPlanarForce>
{
	private Xbim.Ifc2x3.MeasureResource.IfcPlanarForceMeasure? _planarForceX;

	private Xbim.Ifc2x3.MeasureResource.IfcPlanarForceMeasure? _planarForceY;

	private Xbim.Ifc2x3.MeasureResource.IfcPlanarForceMeasure? _planarForceZ;

	[CrossSchemaAttribute(typeof(IIfcStructuralLoadPlanarForce), 2)]
	Xbim.Ifc4.MeasureResource.IfcPlanarForceMeasure? IIfcStructuralLoadPlanarForce.PlanarForceX
	{
		get
		{
			if (!PlanarForceX.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcPlanarForceMeasure(PlanarForceX.Value);
		}
		set
		{
			PlanarForceX = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcPlanarForceMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcPlanarForceMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcPlanarForceMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcStructuralLoadPlanarForce), 3)]
	Xbim.Ifc4.MeasureResource.IfcPlanarForceMeasure? IIfcStructuralLoadPlanarForce.PlanarForceY
	{
		get
		{
			if (!PlanarForceY.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcPlanarForceMeasure(PlanarForceY.Value);
		}
		set
		{
			PlanarForceY = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcPlanarForceMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcPlanarForceMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcPlanarForceMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcStructuralLoadPlanarForce), 4)]
	Xbim.Ifc4.MeasureResource.IfcPlanarForceMeasure? IIfcStructuralLoadPlanarForce.PlanarForceZ
	{
		get
		{
			if (!PlanarForceZ.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcPlanarForceMeasure(PlanarForceZ.Value);
		}
		set
		{
			PlanarForceZ = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcPlanarForceMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcPlanarForceMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcPlanarForceMeasure?)null));
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public Xbim.Ifc2x3.MeasureResource.IfcPlanarForceMeasure? PlanarForceX
	{
		get
		{
			if (_activated)
			{
				return _planarForceX;
			}
			Activate();
			return _planarForceX;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPlanarForceMeasure? v)
			{
				_planarForceX = v;
			}, _planarForceX, value, "PlanarForceX", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public Xbim.Ifc2x3.MeasureResource.IfcPlanarForceMeasure? PlanarForceY
	{
		get
		{
			if (_activated)
			{
				return _planarForceY;
			}
			Activate();
			return _planarForceY;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPlanarForceMeasure? v)
			{
				_planarForceY = v;
			}, _planarForceY, value, "PlanarForceY", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public Xbim.Ifc2x3.MeasureResource.IfcPlanarForceMeasure? PlanarForceZ
	{
		get
		{
			if (_activated)
			{
				return _planarForceZ;
			}
			Activate();
			return _planarForceZ;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPlanarForceMeasure? v)
			{
				_planarForceZ = v;
			}, _planarForceZ, value, "PlanarForceZ", 4);
		}
	}

	internal IfcStructuralLoadPlanarForce(IModel model, int label, bool activated)
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
			_planarForceX = value.RealVal;
			break;
		case 2:
			_planarForceY = value.RealVal;
			break;
		case 3:
			_planarForceZ = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcStructuralLoadPlanarForce other)
	{
		return this == other;
	}
}
