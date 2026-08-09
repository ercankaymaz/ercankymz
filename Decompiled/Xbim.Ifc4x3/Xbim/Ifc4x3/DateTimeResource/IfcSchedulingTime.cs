using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.DateTimeResource;

[ExpressType("IfcSchedulingTime", 1263)]
public abstract class IfcSchedulingTime : PersistEntity, IEquatable<IfcSchedulingTime>, IIfcSchedulingTime, IPersistEntity, IPersist
{
	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _name;

	private IfcDataOriginEnum? _dataOrigin;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _userDefinedDataOrigin;

	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? Name
	{
		get
		{
			if (_activated)
			{
				return _name;
			}
			Activate();
			return _name;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
			{
				_name = v;
			}, _name, value, "Name", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 2)]
	public IfcDataOriginEnum? DataOrigin
	{
		get
		{
			if (_activated)
			{
				return _dataOrigin;
			}
			Activate();
			return _dataOrigin;
		}
		set
		{
			SetValue(delegate(IfcDataOriginEnum? v)
			{
				_dataOrigin = v;
			}, _dataOrigin, value, "DataOrigin", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? UserDefinedDataOrigin
	{
		get
		{
			if (_activated)
			{
				return _userDefinedDataOrigin;
			}
			Activate();
			return _userDefinedDataOrigin;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
			{
				_userDefinedDataOrigin = v;
			}, _userDefinedDataOrigin, value, "UserDefinedDataOrigin", 3);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSchedulingTime), 1)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcSchedulingTime.Name
	{
		get
		{
			if (!Name.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Name.Value);
		}
		set
		{
			Name = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSchedulingTime), 2)]
	Xbim.Ifc4.Interfaces.IfcDataOriginEnum? IIfcSchedulingTime.DataOrigin
	{
		get
		{
			return DataOrigin switch
			{
				IfcDataOriginEnum.MEASURED => Xbim.Ifc4.Interfaces.IfcDataOriginEnum.MEASURED, 
				IfcDataOriginEnum.PREDICTED => Xbim.Ifc4.Interfaces.IfcDataOriginEnum.PREDICTED, 
				IfcDataOriginEnum.SIMULATED => Xbim.Ifc4.Interfaces.IfcDataOriginEnum.SIMULATED, 
				IfcDataOriginEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcDataOriginEnum.USERDEFINED, 
				IfcDataOriginEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcDataOriginEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcDataOriginEnum.MEASURED:
				DataOrigin = IfcDataOriginEnum.MEASURED;
				break;
			case Xbim.Ifc4.Interfaces.IfcDataOriginEnum.PREDICTED:
				DataOrigin = IfcDataOriginEnum.PREDICTED;
				break;
			case Xbim.Ifc4.Interfaces.IfcDataOriginEnum.SIMULATED:
				DataOrigin = IfcDataOriginEnum.SIMULATED;
				break;
			case Xbim.Ifc4.Interfaces.IfcDataOriginEnum.USERDEFINED:
				DataOrigin = IfcDataOriginEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcDataOriginEnum.NOTDEFINED:
				DataOrigin = IfcDataOriginEnum.NOTDEFINED;
				break;
			case null:
				DataOrigin = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSchedulingTime), 3)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcSchedulingTime.UserDefinedDataOrigin
	{
		get
		{
			if (!UserDefinedDataOrigin.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(UserDefinedDataOrigin.Value);
		}
		set
		{
			UserDefinedDataOrigin = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	internal IfcSchedulingTime(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_name = value.StringVal;
			break;
		case 1:
			_dataOrigin = (IfcDataOriginEnum)Enum.Parse(typeof(IfcDataOriginEnum), value.EnumVal, ignoreCase: true);
			break;
		case 2:
			_userDefinedDataOrigin = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSchedulingTime other)
	{
		return this == other;
	}
}
