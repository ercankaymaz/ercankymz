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

namespace Xbim.Ifc2x3.ElectricalDomain;

[ExpressType("IfcCableCarrierFittingType", 689)]
public class IfcCableCarrierFittingType : IfcFlowFittingType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcCableCarrierFittingType>, IIfcCableCarrierFittingType, IIfcFlowFittingType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IExpressValidatable
{
	public enum IfcCableCarrierFittingTypeClause
	{
		WR1
	}

	private IfcCableCarrierFittingTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 15)]
	public IfcCableCarrierFittingTypeEnum PredefinedType
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
			SetValue(delegate(IfcCableCarrierFittingTypeEnum v)
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

	[CrossSchemaAttribute(typeof(IIfcCableCarrierFittingType), 10)]
	Xbim.Ifc4.Interfaces.IfcCableCarrierFittingTypeEnum IIfcCableCarrierFittingType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcCableCarrierFittingTypeEnum.BEND => Xbim.Ifc4.Interfaces.IfcCableCarrierFittingTypeEnum.BEND, 
				IfcCableCarrierFittingTypeEnum.CROSS => Xbim.Ifc4.Interfaces.IfcCableCarrierFittingTypeEnum.CROSS, 
				IfcCableCarrierFittingTypeEnum.REDUCER => Xbim.Ifc4.Interfaces.IfcCableCarrierFittingTypeEnum.REDUCER, 
				IfcCableCarrierFittingTypeEnum.TEE => Xbim.Ifc4.Interfaces.IfcCableCarrierFittingTypeEnum.TEE, 
				IfcCableCarrierFittingTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcCableCarrierFittingTypeEnum.USERDEFINED, 
				IfcCableCarrierFittingTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcCableCarrierFittingTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcCableCarrierFittingTypeEnum.BEND:
				PredefinedType = IfcCableCarrierFittingTypeEnum.BEND;
				break;
			case Xbim.Ifc4.Interfaces.IfcCableCarrierFittingTypeEnum.CROSS:
				PredefinedType = IfcCableCarrierFittingTypeEnum.CROSS;
				break;
			case Xbim.Ifc4.Interfaces.IfcCableCarrierFittingTypeEnum.REDUCER:
				PredefinedType = IfcCableCarrierFittingTypeEnum.REDUCER;
				break;
			case Xbim.Ifc4.Interfaces.IfcCableCarrierFittingTypeEnum.TEE:
				PredefinedType = IfcCableCarrierFittingTypeEnum.TEE;
				break;
			case Xbim.Ifc4.Interfaces.IfcCableCarrierFittingTypeEnum.USERDEFINED:
				PredefinedType = IfcCableCarrierFittingTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcCableCarrierFittingTypeEnum.NOTDEFINED:
				PredefinedType = IfcCableCarrierFittingTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcCableCarrierFittingType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcCableCarrierFittingTypeEnum)Enum.Parse(typeof(IfcCableCarrierFittingTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcCableCarrierFittingType other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcCableCarrierFittingTypeClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcCableCarrierFittingTypeClause.WR1)
			{
				result = PredefinedType != IfcCableCarrierFittingTypeEnum.USERDEFINED || (PredefinedType == IfcCableCarrierFittingTypeEnum.USERDEFINED && Functions.EXISTS(base.ElementType));
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcCableCarrierFittingType>()?.LogError($"Exception thrown evaluating where-clause 'IfcCableCarrierFittingType.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcCableCarrierFittingTypeClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcCableCarrierFittingType.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
