using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.StructuralLoadResource;

[ExpressType("IfcStructuralLoadTemperature", 36)]
public class IfcStructuralLoadTemperature : IfcStructuralLoadStatic, IIfcStructuralLoadTemperature, IIfcStructuralLoadStatic, IIfcStructuralLoadOrResult, IIfcStructuralLoad, IPersistEntity, IPersist, IInstantiableEntity, IEquatable<IfcStructuralLoadTemperature>
{
	private Xbim.Ifc4x3.MeasureResource.IfcThermodynamicTemperatureMeasure? _deltaTConstant;

	private Xbim.Ifc4x3.MeasureResource.IfcThermodynamicTemperatureMeasure? _deltaTY;

	private Xbim.Ifc4x3.MeasureResource.IfcThermodynamicTemperatureMeasure? _deltaTZ;

	[CrossSchemaAttribute(typeof(IIfcStructuralLoadTemperature), 2)]
	Xbim.Ifc4.MeasureResource.IfcThermodynamicTemperatureMeasure? IIfcStructuralLoadTemperature.DeltaTConstant
	{
		get
		{
			if (!DeltaTConstant.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcThermodynamicTemperatureMeasure(DeltaTConstant.Value);
		}
		set
		{
			DeltaTConstant = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcThermodynamicTemperatureMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcThermodynamicTemperatureMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcThermodynamicTemperatureMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcStructuralLoadTemperature), 3)]
	Xbim.Ifc4.MeasureResource.IfcThermodynamicTemperatureMeasure? IIfcStructuralLoadTemperature.DeltaTY
	{
		get
		{
			if (!DeltaTY.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcThermodynamicTemperatureMeasure(DeltaTY.Value);
		}
		set
		{
			DeltaTY = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcThermodynamicTemperatureMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcThermodynamicTemperatureMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcThermodynamicTemperatureMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcStructuralLoadTemperature), 4)]
	Xbim.Ifc4.MeasureResource.IfcThermodynamicTemperatureMeasure? IIfcStructuralLoadTemperature.DeltaTZ
	{
		get
		{
			if (!DeltaTZ.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcThermodynamicTemperatureMeasure(DeltaTZ.Value);
		}
		set
		{
			DeltaTZ = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcThermodynamicTemperatureMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcThermodynamicTemperatureMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcThermodynamicTemperatureMeasure?)null));
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public Xbim.Ifc4x3.MeasureResource.IfcThermodynamicTemperatureMeasure? DeltaTConstant
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcThermodynamicTemperatureMeasure? v)
			{
				_deltaTConstant = v;
			}, _deltaTConstant, value, "DeltaTConstant", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public Xbim.Ifc4x3.MeasureResource.IfcThermodynamicTemperatureMeasure? DeltaTY
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcThermodynamicTemperatureMeasure? v)
			{
				_deltaTY = v;
			}, _deltaTY, value, "DeltaTY", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public Xbim.Ifc4x3.MeasureResource.IfcThermodynamicTemperatureMeasure? DeltaTZ
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcThermodynamicTemperatureMeasure? v)
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
