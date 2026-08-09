using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.HvacDomain;

[ExpressType("IfcEngine", 1164)]
public class IfcEngine : IfcEnergyConversionDevice, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcEngine>, IIfcEngine, IIfcEnergyConversionDevice, IIfcDistributionFlowElement, IIfcDistributionElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect
{
	private IfcEngineTypeEnum? _predefinedType;

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 37)]
	public IfcEngineTypeEnum? PredefinedType
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
			SetValue(delegate(IfcEngineTypeEnum? v)
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

	[CrossSchemaAttribute(typeof(IIfcEngine), 9)]
	Xbim.Ifc4.Interfaces.IfcEngineTypeEnum? IIfcEngine.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcEngineTypeEnum.EXTERNALCOMBUSTION => Xbim.Ifc4.Interfaces.IfcEngineTypeEnum.EXTERNALCOMBUSTION, 
				IfcEngineTypeEnum.INTERNALCOMBUSTION => Xbim.Ifc4.Interfaces.IfcEngineTypeEnum.INTERNALCOMBUSTION, 
				IfcEngineTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcEngineTypeEnum.USERDEFINED, 
				IfcEngineTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcEngineTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcEngineTypeEnum.EXTERNALCOMBUSTION:
				PredefinedType = IfcEngineTypeEnum.EXTERNALCOMBUSTION;
				break;
			case Xbim.Ifc4.Interfaces.IfcEngineTypeEnum.INTERNALCOMBUSTION:
				PredefinedType = IfcEngineTypeEnum.INTERNALCOMBUSTION;
				break;
			case Xbim.Ifc4.Interfaces.IfcEngineTypeEnum.USERDEFINED:
				PredefinedType = IfcEngineTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcEngineTypeEnum.NOTDEFINED:
				PredefinedType = IfcEngineTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcEngine(IModel model, int label, bool activated)
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
			_predefinedType = (IfcEngineTypeEnum)Enum.Parse(typeof(IfcEngineTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcEngine other)
	{
		return this == other;
	}
}
