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

[ExpressType("IfcTubeBundleType", 138)]
public class IfcTubeBundleType : IfcEnergyConversionDeviceType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcTubeBundleType>, IIfcTubeBundleType, IIfcEnergyConversionDeviceType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IExpressValidatable
{
	public enum IfcTubeBundleTypeClause
	{
		WR1
	}

	private IfcTubeBundleTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 15)]
	public IfcTubeBundleTypeEnum PredefinedType
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
			SetValue(delegate(IfcTubeBundleTypeEnum v)
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

	[CrossSchemaAttribute(typeof(IIfcTubeBundleType), 10)]
	Xbim.Ifc4.Interfaces.IfcTubeBundleTypeEnum IIfcTubeBundleType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcTubeBundleTypeEnum.FINNED => Xbim.Ifc4.Interfaces.IfcTubeBundleTypeEnum.FINNED, 
				IfcTubeBundleTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcTubeBundleTypeEnum.USERDEFINED, 
				IfcTubeBundleTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcTubeBundleTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcTubeBundleTypeEnum.FINNED:
				PredefinedType = IfcTubeBundleTypeEnum.FINNED;
				break;
			case Xbim.Ifc4.Interfaces.IfcTubeBundleTypeEnum.USERDEFINED:
				PredefinedType = IfcTubeBundleTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcTubeBundleTypeEnum.NOTDEFINED:
				PredefinedType = IfcTubeBundleTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcTubeBundleType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcTubeBundleTypeEnum)Enum.Parse(typeof(IfcTubeBundleTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcTubeBundleType other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcTubeBundleTypeClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcTubeBundleTypeClause.WR1)
			{
				result = PredefinedType != IfcTubeBundleTypeEnum.USERDEFINED || (PredefinedType == IfcTubeBundleTypeEnum.USERDEFINED && Functions.EXISTS(base.ElementType));
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcTubeBundleType>()?.LogError($"Exception thrown evaluating where-clause 'IfcTubeBundleType.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcTubeBundleTypeClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcTubeBundleType.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
