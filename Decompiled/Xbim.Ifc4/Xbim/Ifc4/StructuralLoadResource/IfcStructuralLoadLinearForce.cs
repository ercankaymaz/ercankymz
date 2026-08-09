using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.StructuralLoadResource;

[ExpressType("IfcStructuralLoadLinearForce", 419)]
public class IfcStructuralLoadLinearForce : IfcStructuralLoadStatic, IInstantiableEntity, IPersistEntity, IPersist, IIfcStructuralLoadLinearForce, IIfcStructuralLoadStatic, IIfcStructuralLoadOrResult, IIfcStructuralLoad, IEquatable<IfcStructuralLoadLinearForce>
{
	private IfcLinearForceMeasure? _linearForceX;

	private IfcLinearForceMeasure? _linearForceY;

	private IfcLinearForceMeasure? _linearForceZ;

	private IfcLinearMomentMeasure? _linearMomentX;

	private IfcLinearMomentMeasure? _linearMomentY;

	private IfcLinearMomentMeasure? _linearMomentZ;

	IfcLinearForceMeasure? IIfcStructuralLoadLinearForce.LinearForceX
	{
		get
		{
			return LinearForceX;
		}
		set
		{
			LinearForceX = value;
		}
	}

	IfcLinearForceMeasure? IIfcStructuralLoadLinearForce.LinearForceY
	{
		get
		{
			return LinearForceY;
		}
		set
		{
			LinearForceY = value;
		}
	}

	IfcLinearForceMeasure? IIfcStructuralLoadLinearForce.LinearForceZ
	{
		get
		{
			return LinearForceZ;
		}
		set
		{
			LinearForceZ = value;
		}
	}

	IfcLinearMomentMeasure? IIfcStructuralLoadLinearForce.LinearMomentX
	{
		get
		{
			return LinearMomentX;
		}
		set
		{
			LinearMomentX = value;
		}
	}

	IfcLinearMomentMeasure? IIfcStructuralLoadLinearForce.LinearMomentY
	{
		get
		{
			return LinearMomentY;
		}
		set
		{
			LinearMomentY = value;
		}
	}

	IfcLinearMomentMeasure? IIfcStructuralLoadLinearForce.LinearMomentZ
	{
		get
		{
			return LinearMomentZ;
		}
		set
		{
			LinearMomentZ = value;
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public IfcLinearForceMeasure? LinearForceX
	{
		get
		{
			if (_activated)
			{
				return _linearForceX;
			}
			Activate();
			return _linearForceX;
		}
		set
		{
			SetValue(delegate(IfcLinearForceMeasure? v)
			{
				_linearForceX = v;
			}, _linearForceX, value, "LinearForceX", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public IfcLinearForceMeasure? LinearForceY
	{
		get
		{
			if (_activated)
			{
				return _linearForceY;
			}
			Activate();
			return _linearForceY;
		}
		set
		{
			SetValue(delegate(IfcLinearForceMeasure? v)
			{
				_linearForceY = v;
			}, _linearForceY, value, "LinearForceY", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public IfcLinearForceMeasure? LinearForceZ
	{
		get
		{
			if (_activated)
			{
				return _linearForceZ;
			}
			Activate();
			return _linearForceZ;
		}
		set
		{
			SetValue(delegate(IfcLinearForceMeasure? v)
			{
				_linearForceZ = v;
			}, _linearForceZ, value, "LinearForceZ", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public IfcLinearMomentMeasure? LinearMomentX
	{
		get
		{
			if (_activated)
			{
				return _linearMomentX;
			}
			Activate();
			return _linearMomentX;
		}
		set
		{
			SetValue(delegate(IfcLinearMomentMeasure? v)
			{
				_linearMomentX = v;
			}, _linearMomentX, value, "LinearMomentX", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcLinearMomentMeasure? LinearMomentY
	{
		get
		{
			if (_activated)
			{
				return _linearMomentY;
			}
			Activate();
			return _linearMomentY;
		}
		set
		{
			SetValue(delegate(IfcLinearMomentMeasure? v)
			{
				_linearMomentY = v;
			}, _linearMomentY, value, "LinearMomentY", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public IfcLinearMomentMeasure? LinearMomentZ
	{
		get
		{
			if (_activated)
			{
				return _linearMomentZ;
			}
			Activate();
			return _linearMomentZ;
		}
		set
		{
			SetValue(delegate(IfcLinearMomentMeasure? v)
			{
				_linearMomentZ = v;
			}, _linearMomentZ, value, "LinearMomentZ", 7);
		}
	}

	internal IfcStructuralLoadLinearForce(IModel model, int label, bool activated)
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
			_linearForceX = value.RealVal;
			break;
		case 2:
			_linearForceY = value.RealVal;
			break;
		case 3:
			_linearForceZ = value.RealVal;
			break;
		case 4:
			_linearMomentX = value.RealVal;
			break;
		case 5:
			_linearMomentY = value.RealVal;
			break;
		case 6:
			_linearMomentZ = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcStructuralLoadLinearForce other)
	{
		return this == other;
	}
}
