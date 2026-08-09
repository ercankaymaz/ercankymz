using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.UtilityResource;

namespace Xbim.Ifc4.Kernel;

[ExpressType("IfcRoot", 12)]
public abstract class IfcRoot : PersistEntity, IIfcRoot, IPersistEntity, IPersist, IEquatable<IfcRoot>
{
	private IfcGloballyUniqueId _globalId;

	private IfcOwnerHistory _ownerHistory;

	private IfcLabel? _name;

	private IfcText? _description;

	IfcGloballyUniqueId IIfcRoot.GlobalId
	{
		get
		{
			return GlobalId;
		}
		set
		{
			GlobalId = value;
		}
	}

	IIfcOwnerHistory IIfcRoot.OwnerHistory
	{
		get
		{
			return OwnerHistory;
		}
		set
		{
			OwnerHistory = value as IfcOwnerHistory;
		}
	}

	IfcLabel? IIfcRoot.Name
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

	IfcText? IIfcRoot.Description
	{
		get
		{
			return Description;
		}
		set
		{
			Description = value;
		}
	}

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public IfcGloballyUniqueId GlobalId
	{
		get
		{
			if (_activated)
			{
				return _globalId;
			}
			Activate();
			return _globalId;
		}
		set
		{
			SetValue(delegate(IfcGloballyUniqueId v)
			{
				_globalId = v;
			}, _globalId, value, "GlobalId", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 2)]
	public IfcOwnerHistory OwnerHistory
	{
		get
		{
			if (_activated)
			{
				return _ownerHistory;
			}
			Activate();
			return _ownerHistory;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcOwnerHistory v)
			{
				_ownerHistory = v;
			}, _ownerHistory, value, "OwnerHistory", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
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
			}, _name, value, "Name", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public IfcText? Description
	{
		get
		{
			if (_activated)
			{
				return _description;
			}
			Activate();
			return _description;
		}
		set
		{
			SetValue(delegate(IfcText? v)
			{
				_description = v;
			}, _description, value, "Description", 4);
		}
	}

	internal IfcRoot(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_globalId = value.StringVal;
			break;
		case 1:
			_ownerHistory = (IfcOwnerHistory)value.EntityVal;
			break;
		case 2:
			_name = value.StringVal;
			break;
		case 3:
			_description = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRoot other)
	{
		return this == other;
	}
}
