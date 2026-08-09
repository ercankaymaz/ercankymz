using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.StructuralLoadResource;

[ExpressType("IfcStructuralLoadTemperature", 36)]
public class IfcStructuralLoadTemperature : IfcStructuralLoadStatic, IInstantiableEntity, IPersistEntity, IPersist, IIfcStructuralLoadTemperature, IIfcStructuralLoadStatic, IIfcStructuralLoadOrResult, IIfcStructuralLoad, IEquatable<IfcStructuralLoadTemperature>
{
	private IfcThermodynamicTemperatureMeasure? _deltaTConstant;

	private IfcThermodynamicTemperatureMeasure? _deltaTY;

	private IfcThermodynamicTemperatureMeasure? _deltaTZ;

	IfcThermodynamicTemperatureMeasure? IIfcStructuralLoadTemperature.DeltaTConstant
	{
		get
		{
			return DeltaTConstant;
		}
		set
		{
			DeltaTConstant = value;
		}
	}

	IfcThermodynamicTemperatureMeasure? IIfcStructuralLoadTemperature.DeltaTY
	{
		get
		{
			return DeltaTY;
		}
		set
		{
			DeltaTY = value;
		}
	}

	IfcThermodynamicTemperatureMeasure? IIfcStructuralLoadTemperature.DeltaTZ
	{
		get
		{
			return DeltaTZ;
		}
		set
		{
			DeltaTZ = value;
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public IfcThermodynamicTemperatureMeasure? DeltaTConstant
	{
		get
		{
			if (_activated)
			{
				return _deltaTConstant;
			}
			Activate();
			return _deltaTConstant;
		}
		set
		{
			SetValue(delegate(IfcThermodynamicTemperatureMeasure? v)
			{
				_deltaTConstant = v;
			}, _deltaTConstant, value, "DeltaTConstant", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public IfcThermodynamicTemperatureMeasure? DeltaTY
	{
		get
		{
			if (_activated)
			{
				return _deltaTY;
			}
			Activate();
			return _deltaTY;
		}
		set
		{
			SetValue(delegate(IfcThermodynamicTemperatureMeasure? v)
			{
				_deltaTY = v;
			}, _deltaTY, value, "DeltaTY", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public IfcThermodynamicTemperatureMeasure? DeltaTZ
	{
		get
		{
			if (_activated)
			{
				return _deltaTZ;
			}
			Activate();
			return _deltaTZ;
		}
		set
		{
			SetValue(delegate(IfcThermodynamicTemperatureMeasure? v)
			{
				_deltaTZ = v;
			}, _deltaTZ, value, "DeltaTZ", 4);
		}
	}

	internal IfcStructuralLoadTemperature(IModel model, int label, bool activated)
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
			_deltaTConstant = value.RealVal;
			break;
		case 2:
			_deltaTY = value.RealVal;
			break;
		case 3:
			_deltaTZ = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcStructuralLoadTemperature other)
	{
		return this == other;
	}
}
