using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.StructuralLoadResource;

[ExpressType("IfcStructuralLoadPlanarForce", 174)]
public class IfcStructuralLoadPlanarForce : IfcStructuralLoadStatic, IInstantiableEntity, IPersistEntity, IPersist, IIfcStructuralLoadPlanarForce, IIfcStructuralLoadStatic, IIfcStructuralLoadOrResult, IIfcStructuralLoad, IEquatable<IfcStructuralLoadPlanarForce>
{
	private IfcPlanarForceMeasure? _planarForceX;

	private IfcPlanarForceMeasure? _planarForceY;

	private IfcPlanarForceMeasure? _planarForceZ;

	IfcPlanarForceMeasure? IIfcStructuralLoadPlanarForce.PlanarForceX
	{
		get
		{
			return PlanarForceX;
		}
		set
		{
			PlanarForceX = value;
		}
	}

	IfcPlanarForceMeasure? IIfcStructuralLoadPlanarForce.PlanarForceY
	{
		get
		{
			return PlanarForceY;
		}
		set
		{
			PlanarForceY = value;
		}
	}

	IfcPlanarForceMeasure? IIfcStructuralLoadPlanarForce.PlanarForceZ
	{
		get
		{
			return PlanarForceZ;
		}
		set
		{
			PlanarForceZ = value;
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public IfcPlanarForceMeasure? PlanarForceX
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
			SetValue(delegate(IfcPlanarForceMeasure? v)
			{
				_planarForceX = v;
			}, _planarForceX, value, "PlanarForceX", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public IfcPlanarForceMeasure? PlanarForceY
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
			SetValue(delegate(IfcPlanarForceMeasure? v)
			{
				_planarForceY = v;
			}, _planarForceY, value, "PlanarForceY", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public IfcPlanarForceMeasure? PlanarForceZ
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
			SetValue(delegate(IfcPlanarForceMeasure? v)
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
