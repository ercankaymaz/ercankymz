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

[ExpressType("IfcActionRequest", 516)]
public class IfcActionRequest : Xbim.Ifc4x3.Kernel.IfcControl, IIfcActionRequest, IIfcControl, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcActionRequest>
{
	private IfcActionRequestTypeEnum? _predefinedType;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _status;

	private Xbim.Ifc4x3.MeasureResource.IfcText? _longDescription;

	[CrossSchemaAttribute(typeof(IIfcActionRequest), 7)]
	Xbim.Ifc4.Interfaces.IfcActionRequestTypeEnum? IIfcActionRequest.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcActionRequestTypeEnum.EMAIL => Xbim.Ifc4.Interfaces.IfcActionRequestTypeEnum.EMAIL, 
				IfcActionRequestTypeEnum.FAX => Xbim.Ifc4.Interfaces.IfcActionRequestTypeEnum.FAX, 
				IfcActionRequestTypeEnum.PHONE => Xbim.Ifc4.Interfaces.IfcActionRequestTypeEnum.PHONE, 
				IfcActionRequestTypeEnum.POST => Xbim.Ifc4.Interfaces.IfcActionRequestTypeEnum.POST, 
				IfcActionRequestTypeEnum.VERBAL => Xbim.Ifc4.Interfaces.IfcActionRequestTypeEnum.VERBAL, 
				IfcActionRequestTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcActionRequestTypeEnum.USERDEFINED, 
				IfcActionRequestTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcActionRequestTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcActionRequestTypeEnum.EMAIL:
				PredefinedType = IfcActionRequestTypeEnum.EMAIL;
				break;
			case Xbim.Ifc4.Interfaces.IfcActionRequestTypeEnum.FAX:
				PredefinedType = IfcActionRequestTypeEnum.FAX;
				break;
			case Xbim.Ifc4.Interfaces.IfcActionRequestTypeEnum.PHONE:
				PredefinedType = IfcActionRequestTypeEnum.PHONE;
				break;
			case Xbim.Ifc4.Interfaces.IfcActionRequestTypeEnum.POST:
				PredefinedType = IfcActionRequestTypeEnum.POST;
				break;
			case Xbim.Ifc4.Interfaces.IfcActionRequestTypeEnum.VERBAL:
				PredefinedType = IfcActionRequestTypeEnum.VERBAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcActionRequestTypeEnum.USERDEFINED:
				PredefinedType = IfcActionRequestTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcActionRequestTypeEnum.NOTDEFINED:
				PredefinedType = IfcActionRequestTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcActionRequest), 8)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcActionRequest.Status
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

	[CrossSchemaAttribute(typeof(IIfcActionRequest), 9)]
	Xbim.Ifc4.MeasureResource.IfcText? IIfcActionRequest.LongDescription
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
	public IfcActionRequestTypeEnum? PredefinedType
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
			SetValue(delegate(IfcActionRequestTypeEnum? v)
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

	internal IfcActionRequest(IModel model, int label, bool activated)
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
			_predefinedType = (IfcActionRequestTypeEnum)Enum.Parse(typeof(IfcActionRequestTypeEnum), value.EnumVal, ignoreCase: true);
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

	public bool Equals(IfcActionRequest other)
	{
		return this == other;
	}
}
