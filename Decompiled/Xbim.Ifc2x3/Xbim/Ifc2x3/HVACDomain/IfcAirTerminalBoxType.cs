using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.SharedBldgServiceElements;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc2x3.HVACDomain;

[ExpressType("IfcAirTerminalBoxType", 332)]
public class IfcAirTerminalBoxType : IfcFlowControllerType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcAirTerminalBoxType>, IIfcAirTerminalBoxType, IIfcFlowControllerType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IExpressValidatable
{
	public enum IfcAirTerminalBoxTypeClause
	{
		WR1
	}

	private IfcAirTerminalBoxTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 15)]
	public IfcAirTerminalBoxTypeEnum PredefinedType
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
			SetValue(delegate(IfcAirTerminalBoxTypeEnum v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 10);
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
			foreach (Xbim.Ifc2x3.Kernel.IfcPropertySetDefinition hasPropertySet in base.HasPropertySets)
			{
				yield return hasPropertySet;
			}
			foreach (IfcRepresentationMap representationMap in base.RepresentationMaps)
			{
				yield return representationMap;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (Xbim.Ifc2x3.Kernel.IfcPropertySetDefinition hasPropertySet in base.HasPropertySets)
			{
				yield return hasPropertySet;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcAirTerminalBoxType), 10)]
	Xbim.Ifc4.Interfaces.IfcAirTerminalBoxTypeEnum IIfcAirTerminalBoxType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcAirTerminalBoxTypeEnum.CONSTANTFLOW => Xbim.Ifc4.Interfaces.IfcAirTerminalBoxTypeEnum.CONSTANTFLOW, 
				IfcAirTerminalBoxTypeEnum.VARIABLEFLOWPRESSUREDEPENDANT => Xbim.Ifc4.Interfaces.IfcAirTerminalBoxTypeEnum.VARIABLEFLOWPRESSUREDEPENDANT, 
				IfcAirTerminalBoxTypeEnum.VARIABLEFLOWPRESSUREINDEPENDANT => Xbim.Ifc4.Interfaces.IfcAirTerminalBoxTypeEnum.VARIABLEFLOWPRESSUREINDEPENDANT, 
				IfcAirTerminalBoxTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcAirTerminalBoxTypeEnum.USERDEFINED, 
				IfcAirTerminalBoxTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcAirTerminalBoxTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcAirTerminalBoxTypeEnum.CONSTANTFLOW:
				PredefinedType = IfcAirTerminalBoxTypeEnum.CONSTANTFLOW;
				break;
			case Xbim.Ifc4.Interfaces.IfcAirTerminalBoxTypeEnum.VARIABLEFLOWPRESSUREDEPENDANT:
				PredefinedType = IfcAirTerminalBoxTypeEnum.VARIABLEFLOWPRESSUREDEPENDANT;
				break;
			case Xbim.Ifc4.Interfaces.IfcAirTerminalBoxTypeEnum.VARIABLEFLOWPRESSUREINDEPENDANT:
				PredefinedType = IfcAirTerminalBoxTypeEnum.VARIABLEFLOWPRESSUREINDEPENDANT;
				break;
			case Xbim.Ifc4.Interfaces.IfcAirTerminalBoxTypeEnum.USERDEFINED:
				PredefinedType = IfcAirTerminalBoxTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcAirTerminalBoxTypeEnum.NOTDEFINED:
				PredefinedType = IfcAirTerminalBoxTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcAirTerminalBoxType(IModel model, int label, bool activated)
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
		case 8:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 9:
			_predefinedType = (IfcAirTerminalBoxTypeEnum)Enum.Parse(typeof(IfcAirTerminalBoxTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcAirTerminalBoxType other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcAirTerminalBoxTypeClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcAirTerminalBoxTypeClause.WR1)
			{
				result = PredefinedType != IfcAirTerminalBoxTypeEnum.USERDEFINED || (PredefinedType == IfcAirTerminalBoxTypeEnum.USERDEFINED && Functions.EXISTS(base.ElementType));
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcAirTerminalBoxType>()?.LogError($"Exception thrown evaluating where-clause 'IfcAirTerminalBoxType.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcAirTerminalBoxTypeClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcAirTerminalBoxType.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
