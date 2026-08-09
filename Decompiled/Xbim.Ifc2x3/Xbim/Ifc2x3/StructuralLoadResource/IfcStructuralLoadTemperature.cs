using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.StructuralLoadResource;

[ExpressType("IfcStructuralLoadTemperature", 36)]
public class IfcStructuralLoadTemperature : IfcStructuralLoadStatic, IIfcStructuralLoadTemperature, IIfcStructuralLoadStatic, IIfcStructuralLoadOrResult, IIfcStructuralLoad, IPersistEntity, IPersist, IInstantiableEntity, IEquatable<IfcStructuralLoadTemperature>
{
	private Xbim.Ifc2x3.MeasureResource.IfcThermodynamicTemperatureMeasure? _deltaT_Constant;

	private Xbim.Ifc2x3.MeasureResource.IfcThermodynamicTemperatureMeasure? _deltaT_Y;

	private Xbim.Ifc2x3.MeasureResource.IfcThermodynamicTemperatureMeasure? _deltaT_Z;

	[CrossSchemaAttribute(typeof(IIfcStructuralLoadTemperature), 2)]
	Xbim.Ifc4.MeasureResource.IfcThermodynamicTemperatureMeasure? IIfcStructuralLoadTemperature.DeltaTConstant
	{
		get
		{
			if (!DeltaT_Constant.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcThermodynamicTemperatureMeasure(DeltaT_Constant.Value);
		}
		set
		{
			DeltaT_Constant = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcThermodynamicTemperatureMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcThermodynamicTemperatureMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcThermodynamicTemperatureMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcStructuralLoadTemperature), 3)]
	Xbim.Ifc4.MeasureResource.IfcThermodynamicTemperatureMeasure? IIfcStructuralLoadTemperature.DeltaTY
	{
		get
		{
			if (!DeltaT_Y.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcThermodynamicTemperatureMeasure(DeltaT_Y.Value);
		}
		set
		{
			DeltaT_Y = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcThermodynamicTemperatureMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcThermodynamicTemperatureMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcThermodynamicTemperatureMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcStructuralLoadTemperature), 4)]
	Xbim.Ifc4.MeasureResource.IfcThermodynamicTemperatureMeasure? IIfcStructuralLoadTemperature.DeltaTZ
	{
		get
		{
			if (!DeltaT_Z.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcThermodynamicTemperatureMeasure(DeltaT_Z.Value);
		}
		set
		{
			DeltaT_Z = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcThermodynamicTemperatureMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcThermodynamicTemperatureMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcThermodynamicTemperatureMeasure?)null));
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public Xbim.Ifc2x3.MeasureResource.IfcThermodynamicTemperatureMeasure? DeltaT_Constant
	{
		get
		{
			if (_activated)
			{
				return _deltaT_Constant;
			}
			Activate();
			return _deltaT_Constant;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcThermodynamicTemperatureMeasure? v)
			{
				_deltaT_Constant = v;
			}, _deltaT_Constant, value, "DeltaT_Constant", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public Xbim.Ifc2x3.MeasureResource.IfcThermodynamicTemperatureMeasure? DeltaT_Y
	{
		get
		{
			if (_activated)
			{
				return _deltaT_Y;
			}
			Activate();
			return _deltaT_Y;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcThermodynamicTemperatureMeasure? v)
			{
				_deltaT_Y = v;
			}, _deltaT_Y, value, "DeltaT_Y", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public Xbim.Ifc2x3.MeasureResource.IfcThermodynamicTemperatureMeasure? DeltaT_Z
	{
		get
		{
			if (_activated)
			{
				return _deltaT_Z;
			}
			Activate();
			return _deltaT_Z;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcThermodynamicTemperatureMeasure? v)
			{
				_deltaT_Z = v;
			}, _deltaT_Z, value, "DeltaT_Z", 4);
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
			_deltaT_Constant = value.RealVal;
			break;
		case 2:
			_deltaT_Y = value.RealVal;
			break;
		case 3:
			_deltaT_Z = value.RealVal;
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
