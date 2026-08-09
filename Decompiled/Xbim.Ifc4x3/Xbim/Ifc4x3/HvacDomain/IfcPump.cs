using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.HvacDomain;

[ExpressType("IfcPump", 1238)]
public class IfcPump : IfcFlowMovingDevice, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcPump>, IIfcPump, IIfcFlowMovingDevice, IIfcDistributionFlowElement, IIfcDistributionElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect
{
	private IfcPumpTypeEnum? _predefinedType;

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 37)]
	public IfcPumpTypeEnum? PredefinedType
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
			SetValue(delegate(IfcPumpTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 9);
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

	[CrossSchemaAttribute(typeof(IIfcPump), 9)]
	Xbim.Ifc4.Interfaces.IfcPumpTypeEnum? IIfcPump.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcPumpTypeEnum.CIRCULATOR => Xbim.Ifc4.Interfaces.IfcPumpTypeEnum.CIRCULATOR, 
				IfcPumpTypeEnum.ENDSUCTION => Xbim.Ifc4.Interfaces.IfcPumpTypeEnum.ENDSUCTION, 
				IfcPumpTypeEnum.SPLITCASE => Xbim.Ifc4.Interfaces.IfcPumpTypeEnum.SPLITCASE, 
				IfcPumpTypeEnum.SUBMERSIBLEPUMP => Xbim.Ifc4.Interfaces.IfcPumpTypeEnum.SUBMERSIBLEPUMP, 
				IfcPumpTypeEnum.SUMPPUMP => Xbim.Ifc4.Interfaces.IfcPumpTypeEnum.SUMPPUMP, 
				IfcPumpTypeEnum.VERTICALINLINE => Xbim.Ifc4.Interfaces.IfcPumpTypeEnum.VERTICALINLINE, 
				IfcPumpTypeEnum.VERTICALTURBINE => Xbim.Ifc4.Interfaces.IfcPumpTypeEnum.VERTICALTURBINE, 
				IfcPumpTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcPumpTypeEnum.USERDEFINED, 
				IfcPumpTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcPumpTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcPumpTypeEnum.CIRCULATOR:
				PredefinedType = IfcPumpTypeEnum.CIRCULATOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcPumpTypeEnum.ENDSUCTION:
				PredefinedType = IfcPumpTypeEnum.ENDSUCTION;
				break;
			case Xbim.Ifc4.Interfaces.IfcPumpTypeEnum.SPLITCASE:
				PredefinedType = IfcPumpTypeEnum.SPLITCASE;
				break;
			case Xbim.Ifc4.Interfaces.IfcPumpTypeEnum.SUBMERSIBLEPUMP:
				PredefinedType = IfcPumpTypeEnum.SUBMERSIBLEPUMP;
				break;
			case Xbim.Ifc4.Interfaces.IfcPumpTypeEnum.SUMPPUMP:
				PredefinedType = IfcPumpTypeEnum.SUMPPUMP;
				break;
			case Xbim.Ifc4.Interfaces.IfcPumpTypeEnum.VERTICALINLINE:
				PredefinedType = IfcPumpTypeEnum.VERTICALINLINE;
				break;
			case Xbim.Ifc4.Interfaces.IfcPumpTypeEnum.VERTICALTURBINE:
				PredefinedType = IfcPumpTypeEnum.VERTICALTURBINE;
				break;
			case Xbim.Ifc4.Interfaces.IfcPumpTypeEnum.USERDEFINED:
				PredefinedType = IfcPumpTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcPumpTypeEnum.NOTDEFINED:
				PredefinedType = IfcPumpTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcPump(IModel model, int label, bool activated)
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
		case 7:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 8:
			_predefinedType = (IfcPumpTypeEnum)Enum.Parse(typeof(IfcPumpTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcPump other)
	{
		return this == other;
	}
}
