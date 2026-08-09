using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.Kernel;

namespace Xbim.Ifc2x3.SharedMgmtElements;

[ExpressType("IfcProjectOrderRecord", 697)]
public class IfcProjectOrderRecord : IfcControl, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcProjectOrderRecord>
{
	private readonly ItemSet<IfcRelAssignsToProjectOrder> _records;

	private IfcProjectOrderRecordTypeEnum _predefinedType;

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.ListUnique, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 12)]
	public IItemSet<IfcRelAssignsToProjectOrder> Records
	{
		get
		{
			if (_activated)
			{
				return _records;
			}
			Activate();
			return _records;
		}
	}

	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 13)]
	public IfcProjectOrderRecordTypeEnum PredefinedType
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
			SetValue(delegate(IfcProjectOrderRecordTypeEnum v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 7);
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
			foreach (IfcRelAssignsToProjectOrder record in Records)
			{
				yield return record;
			}
		}
	}

	internal IfcProjectOrderRecord(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_records = new ItemSet<IfcRelAssignsToProjectOrder>(this, 0, 6);
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
			_records.InternalAdd((IfcRelAssignsToProjectOrder)value.EntityVal);
			break;
		case 6:
			_predefinedType = (IfcProjectOrderRecordTypeEnum)Enum.Parse(typeof(IfcProjectOrderRecordTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcProjectOrderRecord other)
	{
		return this == other;
	}
}
