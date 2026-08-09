using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.ProductExtension;

namespace Xbim.Ifc4.SharedBldgServiceElements;

[ExpressType("IfcDistributionSystem", 1150)]
public class IfcDistributionSystem : IfcSystem, IInstantiableEntity, IPersistEntity, IPersist, IIfcDistributionSystem, IIfcSystem, IIfcGroup, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcDistributionSystem>
{
	private IfcLabel? _longName;

	private IfcDistributionSystemEnum? _predefinedType;

	IfcLabel? IIfcDistributionSystem.LongName
	{
		get
		{
			return LongName;
		}
		set
		{
			LongName = value;
		}
	}

	IfcDistributionSystemEnum? IIfcDistributionSystem.PredefinedType
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

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 19)]
	public IfcLabel? LongName
	{
		get
		{
			if (_activated)
			{
				return _longName;
			}
			Activate();
			return _longName;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_longName = v;
			}, _longName, value, "LongName", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 20)]
	public IfcDistributionSystemEnum? PredefinedType
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
			SetValue(delegate(IfcDistributionSystemEnum? v)
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
		}
	}

	internal IfcDistributionSystem(IModel model, int label, bool activated)
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
			_longName = value.StringVal;
			break;
		case 6:
			_predefinedType = (IfcDistributionSystemEnum)Enum.Parse(typeof(IfcDistributionSystemEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcDistributionSystem other)
	{
		return this == other;
	}
}
