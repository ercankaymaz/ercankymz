using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.StructuralLoadResource;

[ExpressType("IfcStructuralLoadLinearForce", 419)]
public class IfcStructuralLoadLinearForce : IfcStructuralLoadStatic, IIfcStructuralLoadLinearForce, IIfcStructuralLoadStatic, IIfcStructuralLoadOrResult, IIfcStructuralLoad, IPersistEntity, IPersist, IInstantiableEntity, IEquatable<IfcStructuralLoadLinearForce>
{
	private Xbim.Ifc2x3.MeasureResource.IfcLinearForceMeasure? _linearForceX;

	private Xbim.Ifc2x3.MeasureResource.IfcLinearForceMeasure? _linearForceY;

	private Xbim.Ifc2x3.MeasureResource.IfcLinearForceMeasure? _linearForceZ;

	private Xbim.Ifc2x3.MeasureResource.IfcLinearMomentMeasure? _linearMomentX;

	private Xbim.Ifc2x3.MeasureResource.IfcLinearMomentMeasure? _linearMomentY;

	private Xbim.Ifc2x3.MeasureResource.IfcLinearMomentMeasure? _linearMomentZ;

	[CrossSchemaAttribute(typeof(IIfcStructuralLoadLinearForce), 2)]
	Xbim.Ifc4.MeasureResource.IfcLinearForceMeasure? IIfcStructuralLoadLinearForce.LinearForceX
	{
		get
		{
			if (!LinearForceX.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLinearForceMeasure(LinearForceX.Value);
		}
		set
		{
			LinearForceX = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLinearForceMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcLinearForceMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLinearForceMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcStructuralLoadLinearForce), 3)]
	Xbim.Ifc4.MeasureResource.IfcLinearForceMeasure? IIfcStructuralLoadLinearForce.LinearForceY
	{
		get
		{
			if (!LinearForceY.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLinearForceMeasure(LinearForceY.Value);
		}
		set
		{
			LinearForceY = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLinearForceMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcLinearForceMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLinearForceMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcStructuralLoadLinearForce), 4)]
	Xbim.Ifc4.MeasureResource.IfcLinearForceMeasure? IIfcStructuralLoadLinearForce.LinearForceZ
	{
		get
		{
			if (!LinearForceZ.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLinearForceMeasure(LinearForceZ.Value);
		}
		set
		{
			LinearForceZ = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLinearForceMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcLinearForceMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLinearForceMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcStructuralLoadLinearForce), 5)]
	Xbim.Ifc4.MeasureResource.IfcLinearMomentMeasure? IIfcStructuralLoadLinearForce.LinearMomentX
	{
		get
		{
			if (!LinearMomentX.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLinearMomentMeasure(LinearMomentX.Value);
		}
		set
		{
			LinearMomentX = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLinearMomentMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcLinearMomentMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLinearMomentMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcStructuralLoadLinearForce), 6)]
	Xbim.Ifc4.MeasureResource.IfcLinearMomentMeasure? IIfcStructuralLoadLinearForce.LinearMomentY
	{
		get
		{
			if (!LinearMomentY.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLinearMomentMeasure(LinearMomentY.Value);
		}
		set
		{
			LinearMomentY = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLinearMomentMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcLinearMomentMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLinearMomentMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcStructuralLoadLinearForce), 7)]
	Xbim.Ifc4.MeasureResource.IfcLinearMomentMeasure? IIfcStructuralLoadLinearForce.LinearMomentZ
	{
		get
		{
			if (!LinearMomentZ.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLinearMomentMeasure(LinearMomentZ.Value);
		}
		set
		{
			LinearMomentZ = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLinearMomentMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcLinearMomentMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLinearMomentMeasure?)null));
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public Xbim.Ifc2x3.MeasureResource.IfcLinearForceMeasure? LinearForceX
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLinearForceMeasure? v)
			{
				_linearForceX = v;
			}, _linearForceX, value, "LinearForceX", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public Xbim.Ifc2x3.MeasureResource.IfcLinearForceMeasure? LinearForceY
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLinearForceMeasure? v)
			{
				_linearForceY = v;
			}, _linearForceY, value, "LinearForceY", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public Xbim.Ifc2x3.MeasureResource.IfcLinearForceMeasure? LinearForceZ
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLinearForceMeasure? v)
			{
				_linearForceZ = v;
			}, _linearForceZ, value, "LinearForceZ", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public Xbim.Ifc2x3.MeasureResource.IfcLinearMomentMeasure? LinearMomentX
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLinearMomentMeasure? v)
			{
				_linearMomentX = v;
			}, _linearMomentX, value, "LinearMomentX", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public Xbim.Ifc2x3.MeasureResource.IfcLinearMomentMeasure? LinearMomentY
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLinearMomentMeasure? v)
			{
				_linearMomentY = v;
			}, _linearMomentY, value, "LinearMomentY", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public Xbim.Ifc2x3.MeasureResource.IfcLinearMomentMeasure? LinearMomentZ
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLinearMomentMeasure? v)
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
