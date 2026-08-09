using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.ProductExtension;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc2x3.SharedBldgServiceElements;

[ExpressType("IfcDistributionPort", 178)]
public class IfcDistributionPort : IfcPort, IIfcDistributionPort, IIfcPort, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcDistributionPort>
{
	private IfcDistributionPortTypeEnum? _predefinedType;

	private IfcDistributionSystemEnum? _systemType;

	private IfcFlowDirectionEnum? _flowDirection;

	[CrossSchemaAttribute(typeof(IIfcDistributionPort), 8)]
	Xbim.Ifc4.Interfaces.IfcFlowDirectionEnum? IIfcDistributionPort.FlowDirection
	{
		get
		{
			return FlowDirection switch
			{
				IfcFlowDirectionEnum.SOURCE => Xbim.Ifc4.Interfaces.IfcFlowDirectionEnum.SOURCE, 
				IfcFlowDirectionEnum.SINK => Xbim.Ifc4.Interfaces.IfcFlowDirectionEnum.SINK, 
				IfcFlowDirectionEnum.SOURCEANDSINK => Xbim.Ifc4.Interfaces.IfcFlowDirectionEnum.SOURCEANDSINK, 
				IfcFlowDirectionEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcFlowDirectionEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcFlowDirectionEnum.SOURCE:
				FlowDirection = IfcFlowDirectionEnum.SOURCE;
				break;
			case Xbim.Ifc4.Interfaces.IfcFlowDirectionEnum.SINK:
				FlowDirection = IfcFlowDirectionEnum.SINK;
				break;
			case Xbim.Ifc4.Interfaces.IfcFlowDirectionEnum.SOURCEANDSINK:
				FlowDirection = IfcFlowDirectionEnum.SOURCEANDSINK;
				break;
			case Xbim.Ifc4.Interfaces.IfcFlowDirectionEnum.NOTDEFINED:
				FlowDirection = IfcFlowDirectionEnum.NOTDEFINED;
				break;
			case null:
				FlowDirection = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcDistributionPort), 9)]
	IfcDistributionPortTypeEnum? IIfcDistributionPort.PredefinedType
	{
		get
		{
			return _predefinedType;
		}
		set
		{
			SetValue(delegate(IfcDistributionPortTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", -9);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcDistributionPort), 10)]
	IfcDistributionSystemEnum? IIfcDistributionPort.SystemType
	{
		get
		{
			return _systemType;
		}
		set
		{
			SetValue(delegate(IfcDistributionSystemEnum? v)
			{
				_systemType = v;
			}, _systemType, value, "SystemType", -10);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 17)]
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
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcDistributionPort other)
	{
		return this == other;
	}
}
