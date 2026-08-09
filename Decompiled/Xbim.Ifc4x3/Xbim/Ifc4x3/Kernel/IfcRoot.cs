using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.UtilityResource;
using Xbim.Ifc4x3.MeasureResource;
using Xbim.Ifc4x3.UtilityResource;

namespace Xbim.Ifc4x3.Kernel;

[ExpressType("IfcRoot", 12)]
public abstract class IfcRoot : PersistEntity, IIfcRoot, IPersistEntity, IPersist, IEquatable<IfcRoot>
{
	private Xbim.Ifc4x3.UtilityResource.IfcGloballyUniqueId _globalId;

	private Xbim.Ifc4x3.UtilityResource.IfcOwnerHistory _ownerHistory;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _name;

	private Xbim.Ifc4x3.MeasureResource.IfcText? _description;

	[CrossSchemaAttribute(typeof(IIfcRoot), 1)]
	Xbim.Ifc4.UtilityResource.IfcGloballyUniqueId IIfcRoot.GlobalId
	{
		get
		{
			return new Xbim.Ifc4.UtilityResource.IfcGloballyUniqueId(GlobalId);
		}
		set
		{
			GlobalId = new Xbim.Ifc4x3.UtilityResource.IfcGloballyUniqueId(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcRoot), 2)]
	IIfcOwnerHistory IIfcRoot.OwnerHistory
	{
		get
		{
			return OwnerHistory;
		}
		set
		{
			OwnerHistory = value as Xbim.Ifc4x3.UtilityResource.IfcOwnerHistory;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcRoot), 3)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcRoot.Name
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

	[CrossSchemaAttribute(typeof(IIfcRoot), 4)]
	Xbim.Ifc4.MeasureResource.IfcText? IIfcRoot.Description
	{
		get
		{
			if (!Description.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcText(Description.Value);
		}
		set
		{
			Description = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcText?(new Xbim.Ifc4x3.MeasureResource.IfcText(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcText?)null));
		}
	}

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public Xbim.Ifc4x3.UtilityResource.IfcGloballyUniqueId GlobalId
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
			SetValue(delegate(Xbim.Ifc4x3.UtilityResource.IfcGloballyUniqueId v)
			{
				_globalId = v;
			}, _globalId, value, "GlobalId", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 2)]
	public Xbim.Ifc4x3.UtilityResource.IfcOwnerHistory OwnerHistory
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
			SetValue(delegate(Xbim.Ifc4x3.UtilityResource.IfcOwnerHistory v)
			{
				_ownerHistory = v;
			}, _ownerHistory, value, "OwnerHistory", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
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
			}, _name, value, "Name", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public Xbim.Ifc4x3.MeasureResource.IfcText? Description
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcText? v)
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
			_ownerHistory = (Xbim.Ifc4x3.UtilityResource.IfcOwnerHistory)value.EntityVal;
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
