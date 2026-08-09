using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.Kernel;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.SharedMgmtElements;

[ExpressType("IfcProjectOrder", 696)]
public class IfcProjectOrder : Xbim.Ifc4x3.Kernel.IfcControl, IIfcProjectOrder, IIfcControl, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcProjectOrder>
{
	private IfcProjectOrderTypeEnum? _predefinedType;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _status;

	private Xbim.Ifc4x3.MeasureResource.IfcText? _longDescription;

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
				null => null, 
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
				PredefinedType = null;
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
			Status = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcProjectOrder), 9)]
	Xbim.Ifc4.MeasureResource.IfcText? IIfcProjectOrder.LongDescription
	{
		get
		{
			if (!LongDescription.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcText(LongDescription.Value);
		}
		set
		{
			LongDescription = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcText?(new Xbim.Ifc4x3.MeasureResource.IfcText(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcText?)null));
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcProjectOrderTypeEnum? PredefinedType
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
			SetValue(delegate(IfcProjectOrderTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 20)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? Status
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
			{
				_status = v;
			}, _status, value, "Status", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 21)]
	public Xbim.Ifc4x3.MeasureResource.IfcText? LongDescription
	{
		get
		{
			if (_activated)
			{
				return _longDescription;
			}
			Activate();
			return _longDescription;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcText? v)
			{
				_longDescription = v;
			}, _longDescription, value, "LongDescription", 9);
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
		case 5:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 6:
			_predefinedType = (IfcProjectOrderTypeEnum)Enum.Parse(typeof(IfcProjectOrderTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 7:
			_status = value.StringVal;
			break;
		case 8:
			_longDescription = value.StringVal;
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
