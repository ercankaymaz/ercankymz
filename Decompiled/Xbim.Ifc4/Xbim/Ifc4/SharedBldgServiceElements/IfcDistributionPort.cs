using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.ProductExtension;

namespace Xbim.Ifc4.SharedBldgServiceElements;

[ExpressType("IfcDistributionPort", 178)]
public class IfcDistributionPort : IfcPort, IInstantiableEntity, IPersistEntity, IPersist, IIfcDistributionPort, IIfcPort, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcDistributionPort>
{
	private IfcFlowDirectionEnum? _flowDirection;

	private IfcDistributionPortTypeEnum? _predefinedType;

	private IfcDistributionSystemEnum? _systemType;

	IfcFlowDirectionEnum? IIfcDistributionPort.FlowDirection
	{
		get
		{
			return FlowDirection;
		}
		set
		{
			FlowDirection = value;
		}
	}

	IfcDistributionPortTypeEnum? IIfcDistributionPort.PredefinedType
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

	IfcDistributionSystemEnum? IIfcDistributionPort.SystemType
	{
		get
		{
			return SystemType;
		}
		set
		{
			SystemType = value;
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 23)]
	public IfcFlowDirectionEnum? FlowDirection
	{
		get
		{
			if (_activated)
			{
				return _flowDirection;
			}
			Activate();
			return _flowDirection;
		}
		set
		{
			SetValue(delegate(IfcFlowDirectionEnum? v)
			{
				_flowDirection = v;
			}, _flowDirection, value, "FlowDirection", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 24)]
	public IfcDistributionPortTypeEnum? PredefinedType
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
			SetValue(delegate(IfcDistributionPortTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 25)]
	public IfcDistributionSystemEnum? SystemType
	{
		get
		{
			if (_activated)
			{
				return _systemType;
			}
			Activate();
			return _systemType;
		}
		set
		{
			SetValue(delegate(IfcDistributionSystemEnum? v)
			{
				_systemType = v;
			}, _systemType, value, "SystemType", 10);
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
			if (base.ObjectPlacement != null)
			{
				yield return base.ObjectPlacement;
			}
			if (base.Representation != null)
			{
				yield return base.Representation;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (base.ObjectPlacement != null)
			{
				yield return base.ObjectPlacement;
			}
			if (base.Representation != null)
			{
				yield return base.Representation;
			}
		}
	}

	internal IfcDistributionPort(IModel model, int label, bool activated)
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
		case 6:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 7:
			_flowDirection = (IfcFlowDirectionEnum)Enum.Parse(typeof(IfcFlowDirectionEnum), value.EnumVal, ignoreCase: true);
			break;
		case 8:
			_predefinedType = (IfcDistributionPortTypeEnum)Enum.Parse(typeof(IfcDistributionPortTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 9:
			_systemType = (IfcDistributionSystemEnum)Enum.Parse(typeof(IfcDistributionSystemEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcDistributionPort other)
	{
		return this == other;
	}
}
