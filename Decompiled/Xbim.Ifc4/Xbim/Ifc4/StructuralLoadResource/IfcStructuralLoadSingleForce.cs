using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.StructuralLoadResource;

[ExpressType("IfcStructuralLoadSingleForce", 119)]
public class IfcStructuralLoadSingleForce : IfcStructuralLoadStatic, IInstantiableEntity, IPersistEntity, IPersist, IIfcStructuralLoadSingleForce, IIfcStructuralLoadStatic, IIfcStructuralLoadOrResult, IIfcStructuralLoad, IEquatable<IfcStructuralLoadSingleForce>
{
	private IfcForceMeasure? _forceX;

	private IfcForceMeasure? _forceY;

	private IfcForceMeasure? _forceZ;

	private IfcTorqueMeasure? _momentX;

	private IfcTorqueMeasure? _momentY;

	private IfcTorqueMeasure? _momentZ;

	IfcForceMeasure? IIfcStructuralLoadSingleForce.ForceX
	{
		get
		{
			return ForceX;
		}
		set
		{
			ForceX = value;
		}
	}

	IfcForceMeasure? IIfcStructuralLoadSingleForce.ForceY
	{
		get
		{
			return ForceY;
		}
		set
		{
			ForceY = value;
		}
	}

	IfcForceMeasure? IIfcStructuralLoadSingleForce.ForceZ
	{
		get
		{
			return ForceZ;
		}
		set
		{
			ForceZ = value;
		}
	}

	IfcTorqueMeasure? IIfcStructuralLoadSingleForce.MomentX
	{
		get
		{
			return MomentX;
		}
		set
		{
			MomentX = value;
		}
	}

	IfcTorqueMeasure? IIfcStructuralLoadSingleForce.MomentY
	{
		get
		{
			return MomentY;
		}
		set
		{
			MomentY = value;
		}
	}

	IfcTorqueMeasure? IIfcStructuralLoadSingleForce.MomentZ
	{
		get
		{
			return MomentZ;
		}
		set
		{
			MomentZ = value;
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public IfcForceMeasure? ForceX
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
			SetValue(delegate(IfcForceMeasure? v)
			{
				_forceX = v;
			}, _forceX, value, "ForceX", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public IfcForceMeasure? ForceY
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
			SetValue(delegate(IfcForceMeasure? v)
			{
				_forceY = v;
			}, _forceY, value, "ForceY", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public IfcForceMeasure? ForceZ
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
			SetValue(delegate(IfcForceMeasure? v)
			{
				_forceZ = v;
			}, _forceZ, value, "ForceZ", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public IfcTorqueMeasure? MomentX
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
			SetValue(delegate(IfcTorqueMeasure? v)
			{
				_momentX = v;
			}, _momentX, value, "MomentX", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcTorqueMeasure? MomentY
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
			SetValue(delegate(IfcTorqueMeasure? v)
			{
				_momentY = v;
			}, _momentY, value, "MomentY", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public IfcTorqueMeasure? MomentZ
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
			SetValue(delegate(IfcTorqueMeasure? v)
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
