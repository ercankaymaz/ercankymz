using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.SharedMgmtElements;

[ExpressType("IfcProjectOrder", 696)]
public class IfcProjectOrder : Xbim.Ifc2x3.Kernel.IfcControl, IIfcProjectOrder, IIfcControl, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcProjectOrder>
{
	private Xbim.Ifc2x3.MeasureResource.IfcIdentifier _iD;

	private IfcProjectOrderTypeEnum _predefinedType;

	private Xbim.Ifc2x3.MeasureResource.IfcLabel? _status;

	[CrossSchemaAttribute(typeof(IIfcProjectOrder), 7)]
	Xbim.Ifc4.Interfaces.IfcProjectOrderTypeEnum? IIfcProjectOrder.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcProjectOrderTypeEnum.CHANGEORDER => Xbim.Ifc4.Interfaces.IfcProjectOrderTypeEnum.CHANGEORDER, 
				IfcProjectOrderTypeEnum.MAINTENANCEWORKORDER => Xbim.Ifc4.Interfaces.IfcProjectOrderTypeEnum.MAINTENANCEWORKORDER, 
				IfcProjectOrderTypeEnum.MOVEORDER => Xbim.Ifc4.Interfaces.IfcProjectOrderTypeEnum.MOVEORDER, 
				IfcProjectOrderTypeEnum.PURCHASEORDER => Xbim.Ifc4.Interfaces.IfcProjectOrderTypeEnum.PURCHASEORDER, 
				IfcProjectOrderTypeEnum.WORKORDER => Xbim.Ifc4.Interfaces.IfcProjectOrderTypeEnum.WORKORDER, 
				IfcProjectOrderTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcProjectOrderTypeEnum.USERDEFINED, 
				IfcProjectOrderTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcProjectOrderTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcProjectOrderTypeEnum.CHANGEORDER:
				PredefinedType = IfcProjectOrderTypeEnum.CHANGEORDER;
				break;
			case Xbim.Ifc4.Interfaces.IfcProjectOrderTypeEnum.MAINTENANCEWORKORDER:
				PredefinedType = IfcProjectOrderTypeEnum.MAINTENANCEWORKORDER;
				break;
			case Xbim.Ifc4.Interfaces.IfcProjectOrderTypeEnum.MOVEORDER:
				PredefinedType = IfcProjectOrderTypeEnum.MOVEORDER;
				break;
			case Xbim.Ifc4.Interfaces.IfcProjectOrderTypeEnum.PURCHASEORDER:
				PredefinedType = IfcProjectOrderTypeEnum.PURCHASEORDER;
				break;
			case Xbim.Ifc4.Interfaces.IfcProjectOrderTypeEnum.WORKORDER:
				PredefinedType = IfcProjectOrderTypeEnum.WORKORDER;
				break;
			case Xbim.Ifc4.Interfaces.IfcProjectOrderTypeEnum.USERDEFINED:
				PredefinedType = IfcProjectOrderTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcProjectOrderTypeEnum.NOTDEFINED:
				PredefinedType = IfcProjectOrderTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = IfcProjectOrderTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcProjectOrder), 8)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcProjectOrder.Status
	{
		get
		{
			if (!Status.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Status.Value);
		}
		set
		{
			Status = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLabel?(new Xbim.Ifc2x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcProjectOrder), 9)]
	Xbim.Ifc4.MeasureResource.IfcText? IIfcProjectOrder.LongDescription
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcText(ID);
		}
		set
		{
			ID = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcIdentifier(value.Value) : default(Xbim.Ifc2x3.MeasureResource.IfcIdentifier));
		}
	}

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 12)]
	public Xbim.Ifc2x3.MeasureResource.IfcIdentifier ID
	{
		get
		{
			if (_activated)
			{
				return _iD;
			}
			Activate();
			return _iD;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcIdentifier v)
			{
				_iD = v;
			}, _iD, value, "ID", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 13)]
	public IfcProjectOrderTypeEnum PredefinedType
	{
		get
		{
			if (_activated)
			{
				return _predefinedType;
			}
			Activate();
			return _predefinedType;
		}
		set
		{
			SetValue(delegate(IfcProjectOrderTypeEnum v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 14)]
	public Xbim.Ifc2x3.MeasureResource.IfcLabel? Status
	{
		get
		{
			if (_activated)
			{
				return _status;
			}
			Activate();
			return _status;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel? v)
			{
				_status = v;
			}, _status, value, "Status", 8);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.OwnerHistory != null)
			{
				yield return base.OwnerHistory;
			}
		}
	}

	internal IfcProjectOrder(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
		case 2:
		case 3:
		case 4:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 5:
			_iD = value.StringVal;
			break;
		case 6:
			_predefinedType = (IfcProjectOrderTypeEnum)Enum.Parse(typeof(IfcProjectOrderTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 7:
			_status = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcProjectOrder other)
	{
		return this == other;
	}
}
