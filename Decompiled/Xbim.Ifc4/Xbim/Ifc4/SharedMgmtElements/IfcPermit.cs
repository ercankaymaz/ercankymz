using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.SharedMgmtElements;

[ExpressType("IfcPermit", 189)]
public class IfcPermit : IfcControl, IInstantiableEntity, IPersistEntity, IPersist, IIfcPermit, IIfcControl, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcPermit>
{
	private IfcPermitTypeEnum? _predefinedType;

	private IfcLabel? _status;

	private IfcText? _longDescription;

	IfcPermitTypeEnum? IIfcPermit.PredefinedType
	{
		get
		{
			return PredefinedType;
		}
		set
		{
			PredefinedType = value;
		}
	}

	IfcLabel? IIfcPermit.Status
	{
		get
		{
			return Status;
		}
		set
		{
			Status = value;
		}
	}

	IfcText? IIfcPermit.LongDescription
	{
		get
		{
			return LongDescription;
		}
		set
		{
			LongDescription = value;
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcPermitTypeEnum? PredefinedType
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
			SetValue(delegate(IfcPermitTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 20)]
	public IfcLabel? Status
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
			SetValue(delegate(IfcLabel? v)
			{
				_status = v;
			}, _status, value, "Status", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 21)]
	public IfcText? LongDescription
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
			SetValue(delegate(IfcText? v)
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

	internal IfcPermit(IModel model, int label, bool activated)
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
			_predefinedType = (IfcPermitTypeEnum)Enum.Parse(typeof(IfcPermitTypeEnum), value.EnumVal, ignoreCase: true);
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

	public bool Equals(IfcPermit other)
	{
		return this == other;
	}
}
