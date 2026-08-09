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

[ExpressType("IfcDuctSilencerType", 141)]
public class IfcDuctSilencerType : IfcFlowTreatmentDeviceType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcDuctSilencerType>, IIfcDuctSilencerType, IIfcFlowTreatmentDeviceType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IExpressValidatable
{
	public enum IfcDuctSilencerTypeClause
	{
		WR1
	}

	private IfcDuctSilencerTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 15)]
	public IfcDuctSilencerTypeEnum PredefinedType
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
			SetValue(delegate(IfcDuctSilencerTypeEnum v)
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

	[CrossSchemaAttribute(typeof(IIfcDuctSilencerType), 10)]
	Xbim.Ifc4.Interfaces.IfcDuctSilencerTypeEnum IIfcDuctSilencerType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcDuctSilencerTypeEnum.FLATOVAL => Xbim.Ifc4.Interfaces.IfcDuctSilencerTypeEnum.FLATOVAL, 
				IfcDuctSilencerTypeEnum.RECTANGULAR => Xbim.Ifc4.Interfaces.IfcDuctSilencerTypeEnum.RECTANGULAR, 
				IfcDuctSilencerTypeEnum.ROUND => Xbim.Ifc4.Interfaces.IfcDuctSilencerTypeEnum.ROUND, 
				IfcDuctSilencerTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcDuctSilencerTypeEnum.USERDEFINED, 
				IfcDuctSilencerTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcDuctSilencerTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcDuctSilencerTypeEnum.FLATOVAL:
				PredefinedType = IfcDuctSilencerTypeEnum.FLATOVAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcDuctSilencerTypeEnum.RECTANGULAR:
				PredefinedType = IfcDuctSilencerTypeEnum.RECTANGULAR;
				break;
			case Xbim.Ifc4.Interfaces.IfcDuctSilencerTypeEnum.ROUND:
				PredefinedType = IfcDuctSilencerTypeEnum.ROUND;
				break;
			case Xbim.Ifc4.Interfaces.IfcDuctSilencerTypeEnum.USERDEFINED:
				PredefinedType = IfcDuctSilencerTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcDuctSilencerTypeEnum.NOTDEFINED:
				PredefinedType = IfcDuctSilencerTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcDuctSilencerType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcDuctSilencerTypeEnum)Enum.Parse(typeof(IfcDuctSilencerTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcDuctSilencerType other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcDuctSilencerTypeClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcDuctSilencerTypeClause.WR1)
			{
				result = PredefinedType != IfcDuctSilencerTypeEnum.USERDEFINED || (PredefinedType == IfcDuctSilencerTypeEnum.USERDEFINED && Functions.EXISTS(base.ElementType));
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcDuctSilencerType>()?.LogError($"Exception thrown evaluating where-clause 'IfcDuctSilencerType.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcDuctSilencerTypeClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcDuctSilencerType.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
