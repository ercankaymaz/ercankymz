using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.DateTimeResource;

[ExpressType("IfcSchedulingTime", 1263)]
public abstract class IfcSchedulingTime : PersistEntity, IIfcSchedulingTime, IPersistEntity, IPersist, IEquatable<IfcSchedulingTime>
{
	private IfcLabel? _name;

	private IfcDataOriginEnum? _dataOrigin;

	private IfcLabel? _userDefinedDataOrigin;

	IfcLabel? IIfcSchedulingTime.Name
	{
		get
		{
			return Name;
		}
		set
		{
			Name = value;
		}
	}

	IfcDataOriginEnum? IIfcSchedulingTime.DataOrigin
	{
		get
		{
			return DataOrigin;
		}
		set
		{
			DataOrigin = value;
		}
	}

	IfcLabel? IIfcSchedulingTime.UserDefinedDataOrigin
	{
		get
		{
			return UserDefinedDataOrigin;
		}
		set
		{
			UserDefinedDataOrigin = value;
		}
	}

	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public IfcLabel? Name
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
			SetValue(delegate(IfcLabel? v)
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
	public IfcLabel? UserDefinedDataOrigin
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
			SetValue(delegate(IfcLabel? v)
			{
				_userDefinedDataOrigin = v;
			}, _userDefinedDataOrigin, value, "UserDefinedDataOrigin", 3);
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
