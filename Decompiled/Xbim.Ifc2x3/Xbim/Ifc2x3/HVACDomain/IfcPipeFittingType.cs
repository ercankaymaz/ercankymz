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

[ExpressType("IfcPipeFittingType", 511)]
public class IfcPipeFittingType : IfcFlowFittingType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcPipeFittingType>, IIfcPipeFittingType, IIfcFlowFittingType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IExpressValidatable
{
	public enum IfcPipeFittingTypeClause
	{
		WR1
	}

	private IfcPipeFittingTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 15)]
	public IfcPipeFittingTypeEnum PredefinedType
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
			SetValue(delegate(IfcPipeFittingTypeEnum v)
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

	[CrossSchemaAttribute(typeof(IIfcPipeFittingType), 10)]
	Xbim.Ifc4.Interfaces.IfcPipeFittingTypeEnum IIfcPipeFittingType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcPipeFittingTypeEnum.BEND => Xbim.Ifc4.Interfaces.IfcPipeFittingTypeEnum.BEND, 
				IfcPipeFittingTypeEnum.CONNECTOR => Xbim.Ifc4.Interfaces.IfcPipeFittingTypeEnum.CONNECTOR, 
				IfcPipeFittingTypeEnum.ENTRY => Xbim.Ifc4.Interfaces.IfcPipeFittingTypeEnum.ENTRY, 
				IfcPipeFittingTypeEnum.EXIT => Xbim.Ifc4.Interfaces.IfcPipeFittingTypeEnum.EXIT, 
				IfcPipeFittingTypeEnum.JUNCTION => Xbim.Ifc4.Interfaces.IfcPipeFittingTypeEnum.JUNCTION, 
				IfcPipeFittingTypeEnum.OBSTRUCTION => Xbim.Ifc4.Interfaces.IfcPipeFittingTypeEnum.OBSTRUCTION, 
				IfcPipeFittingTypeEnum.TRANSITION => Xbim.Ifc4.Interfaces.IfcPipeFittingTypeEnum.TRANSITION, 
				IfcPipeFittingTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcPipeFittingTypeEnum.USERDEFINED, 
				IfcPipeFittingTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcPipeFittingTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcPipeFittingTypeEnum.BEND:
				PredefinedType = IfcPipeFittingTypeEnum.BEND;
				break;
			case Xbim.Ifc4.Interfaces.IfcPipeFittingTypeEnum.CONNECTOR:
				PredefinedType = IfcPipeFittingTypeEnum.CONNECTOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcPipeFittingTypeEnum.ENTRY:
				PredefinedType = IfcPipeFittingTypeEnum.ENTRY;
				break;
			case Xbim.Ifc4.Interfaces.IfcPipeFittingTypeEnum.EXIT:
				PredefinedType = IfcPipeFittingTypeEnum.EXIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcPipeFittingTypeEnum.JUNCTION:
				PredefinedType = IfcPipeFittingTypeEnum.JUNCTION;
				break;
			case Xbim.Ifc4.Interfaces.IfcPipeFittingTypeEnum.OBSTRUCTION:
				PredefinedType = IfcPipeFittingTypeEnum.OBSTRUCTION;
				break;
			case Xbim.Ifc4.Interfaces.IfcPipeFittingTypeEnum.TRANSITION:
				PredefinedType = IfcPipeFittingTypeEnum.TRANSITION;
				break;
			case Xbim.Ifc4.Interfaces.IfcPipeFittingTypeEnum.USERDEFINED:
				PredefinedType = IfcPipeFittingTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcPipeFittingTypeEnum.NOTDEFINED:
				PredefinedType = IfcPipeFittingTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcPipeFittingType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcPipeFittingTypeEnum)Enum.Parse(typeof(IfcPipeFittingTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcPipeFittingType other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcPipeFittingTypeClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcPipeFittingTypeClause.WR1)
			{
				result = PredefinedType != IfcPipeFittingTypeEnum.USERDEFINED || (PredefinedType == IfcPipeFittingTypeEnum.USERDEFINED && Functions.EXISTS(base.ElementType));
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcPipeFittingType>()?.LogError($"Exception thrown evaluating where-clause 'IfcPipeFittingType.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcPipeFittingTypeClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcPipeFittingType.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
