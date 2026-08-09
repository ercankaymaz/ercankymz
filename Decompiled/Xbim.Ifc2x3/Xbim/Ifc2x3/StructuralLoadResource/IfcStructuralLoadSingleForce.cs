using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.StructuralLoadResource;

[ExpressType("IfcStructuralLoadSingleForce", 119)]
public class IfcStructuralLoadSingleForce : IfcStructuralLoadStatic, IIfcStructuralLoadSingleForce, IIfcStructuralLoadStatic, IIfcStructuralLoadOrResult, IIfcStructuralLoad, IPersistEntity, IPersist, IInstantiableEntity, IEquatable<IfcStructuralLoadSingleForce>
{
	private Xbim.Ifc2x3.MeasureResource.IfcForceMeasure? _forceX;

	private Xbim.Ifc2x3.MeasureResource.IfcForceMeasure? _forceY;

	private Xbim.Ifc2x3.MeasureResource.IfcForceMeasure? _forceZ;

	private Xbim.Ifc2x3.MeasureResource.IfcTorqueMeasure? _momentX;

	private Xbim.Ifc2x3.MeasureResource.IfcTorqueMeasure? _momentY;

	private Xbim.Ifc2x3.MeasureResource.IfcTorqueMeasure? _momentZ;

	[CrossSchemaAttribute(typeof(IIfcStructuralLoadSingleForce), 2)]
	Xbim.Ifc4.MeasureResource.IfcForceMeasure? IIfcStructuralLoadSingleForce.ForceX
	{
		get
		{
			if (!ForceX.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcForceMeasure(ForceX.Value);
		}
		set
		{
			ForceX = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcForceMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcForceMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcForceMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcStructuralLoadSingleForce), 3)]
	Xbim.Ifc4.MeasureResource.IfcForceMeasure? IIfcStructuralLoadSingleForce.ForceY
	{
		get
		{
			if (!ForceY.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcForceMeasure(ForceY.Value);
		}
		set
		{
			ForceY = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcForceMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcForceMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcForceMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcStructuralLoadSingleForce), 4)]
	Xbim.Ifc4.MeasureResource.IfcForceMeasure? IIfcStructuralLoadSingleForce.ForceZ
	{
		get
		{
			if (!ForceZ.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcForceMeasure(ForceZ.Value);
		}
		set
		{
			ForceZ = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcForceMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcForceMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcForceMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcStructuralLoadSingleForce), 5)]
	Xbim.Ifc4.MeasureResource.IfcTorqueMeasure? IIfcStructuralLoadSingleForce.MomentX
	{
		get
		{
			if (!MomentX.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcTorqueMeasure(MomentX.Value);
		}
		set
		{
			MomentX = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcTorqueMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcTorqueMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcTorqueMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcStructuralLoadSingleForce), 6)]
	Xbim.Ifc4.MeasureResource.IfcTorqueMeasure? IIfcStructuralLoadSingleForce.MomentY
	{
		get
		{
			if (!MomentY.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcTorqueMeasure(MomentY.Value);
		}
		set
		{
			MomentY = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcTorqueMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcTorqueMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcTorqueMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcStructuralLoadSingleForce), 7)]
	Xbim.Ifc4.MeasureResource.IfcTorqueMeasure? IIfcStructuralLoadSingleForce.MomentZ
	{
		get
		{
			if (!MomentZ.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcTorqueMeasure(MomentZ.Value);
		}
		set
		{
			MomentZ = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcTorqueMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcTorqueMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcTorqueMeasure?)null));
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public Xbim.Ifc2x3.MeasureResource.IfcForceMeasure? ForceX
	{
		get
		{
			if (_activated)
			{
				return _forceX;
			}
			Activate();
			return _forceX;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcForceMeasure? v)
			{
				_forceX = v;
			}, _forceX, value, "ForceX", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public Xbim.Ifc2x3.MeasureResource.IfcForceMeasure? ForceY
	{
		get
		{
			if (_activated)
			{
				return _forceY;
			}
			Activate();
			return _forceY;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcForceMeasure? v)
			{
				_forceY = v;
			}, _forceY, value, "ForceY", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public Xbim.Ifc2x3.MeasureResource.IfcForceMeasure? ForceZ
	{
		get
		{
			if (_activated)
			{
				return _forceZ;
			}
			Activate();
			return _forceZ;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcForceMeasure? v)
			{
				_forceZ = v;
			}, _forceZ, value, "ForceZ", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public Xbim.Ifc2x3.MeasureResource.IfcTorqueMeasure? MomentX
	{
		get
		{
			if (_activated)
			{
				return _momentX;
			}
			Activate();
			return _momentX;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcTorqueMeasure? v)
			{
				_momentX = v;
			}, _momentX, value, "MomentX", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public Xbim.Ifc2x3.MeasureResource.IfcTorqueMeasure? MomentY
	{
		get
		{
			if (_activated)
			{
				return _momentY;
			}
			Activate();
			return _momentY;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcTorqueMeasure? v)
			{
				_momentY = v;
			}, _momentY, value, "MomentY", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public Xbim.Ifc2x3.MeasureResource.IfcTorqueMeasure? MomentZ
	{
		get
		{
			if (_activated)
			{
				return _momentZ;
			}
			Activate();
			return _momentZ;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcTorqueMeasure? v)
			{
				_momentZ = v;
			}, _momentZ, value, "MomentZ", 7);
		}
	}

	internal IfcStructuralLoadSingleForce(IModel model, int label, bool activated)
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
			_forceX = value.RealVal;
			break;
		case 2:
			_forceY = value.RealVal;
			break;
		case 3:
			_forceZ = value.RealVal;
			break;
		case 4:
			_momentX = value.RealVal;
			break;
		case 5:
			_momentY = value.RealVal;
			break;
		case 6:
			_momentZ = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcStructuralLoadSingleForce other)
	{
		return this == other;
	}
}
