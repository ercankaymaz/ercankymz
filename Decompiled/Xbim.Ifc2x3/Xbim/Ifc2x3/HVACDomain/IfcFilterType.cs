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

[ExpressType("IfcFilterType", 139)]
public class IfcFilterType : IfcFlowTreatmentDeviceType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcFilterType>, IIfcFilterType, IIfcFlowTreatmentDeviceType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IExpressValidatable
{
	public enum IfcFilterTypeClause
	{
		WR1
	}

	private IfcFilterTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 15)]
	public IfcFilterTypeEnum PredefinedType
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
			SetValue(delegate(IfcFilterTypeEnum v)
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

	[CrossSchemaAttribute(typeof(IIfcFilterType), 10)]
	Xbim.Ifc4.Interfaces.IfcFilterTypeEnum IIfcFilterType.PredefinedType
	{
		get
		{
			switch (PredefinedType)
			{
			case IfcFilterTypeEnum.AIRPARTICLEFILTER:
				return Xbim.Ifc4.Interfaces.IfcFilterTypeEnum.AIRPARTICLEFILTER;
			case IfcFilterTypeEnum.ODORFILTER:
				return Xbim.Ifc4.Interfaces.IfcFilterTypeEnum.ODORFILTER;
			case IfcFilterTypeEnum.OILFILTER:
				return Xbim.Ifc4.Interfaces.IfcFilterTypeEnum.OILFILTER;
			case IfcFilterTypeEnum.STRAINER:
				return Xbim.Ifc4.Interfaces.IfcFilterTypeEnum.STRAINER;
			case IfcFilterTypeEnum.WATERFILTER:
				return Xbim.Ifc4.Interfaces.IfcFilterTypeEnum.WATERFILTER;
			case IfcFilterTypeEnum.USERDEFINED:
			{
				if (base.ElementType.HasValue && Enum.TryParse<Xbim.Ifc4.Interfaces.IfcFilterTypeEnum>(base.ElementType.Value, ignoreCase: false, out var result))
				{
					return result;
				}
				return Xbim.Ifc4.Interfaces.IfcFilterTypeEnum.USERDEFINED;
			}
			case IfcFilterTypeEnum.NOTDEFINED:
				return Xbim.Ifc4.Interfaces.IfcFilterTypeEnum.NOTDEFINED;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcFilterTypeEnum.AIRPARTICLEFILTER:
				PredefinedType = IfcFilterTypeEnum.AIRPARTICLEFILTER;
				break;
			case Xbim.Ifc4.Interfaces.IfcFilterTypeEnum.COMPRESSEDAIRFILTER:
				base.ElementType = value.ToString();
				PredefinedType = IfcFilterTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcFilterTypeEnum.ODORFILTER:
				PredefinedType = IfcFilterTypeEnum.ODORFILTER;
				break;
			case Xbim.Ifc4.Interfaces.IfcFilterTypeEnum.OILFILTER:
				PredefinedType = IfcFilterTypeEnum.OILFILTER;
				break;
			case Xbim.Ifc4.Interfaces.IfcFilterTypeEnum.STRAINER:
				PredefinedType = IfcFilterTypeEnum.STRAINER;
				break;
			case Xbim.Ifc4.Interfaces.IfcFilterTypeEnum.WATERFILTER:
				PredefinedType = IfcFilterTypeEnum.WATERFILTER;
				break;
			case Xbim.Ifc4.Interfaces.IfcFilterTypeEnum.USERDEFINED:
				PredefinedType = IfcFilterTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcFilterTypeEnum.NOTDEFINED:
				PredefinedType = IfcFilterTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcFilterType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcFilterTypeEnum)Enum.Parse(typeof(IfcFilterTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcFilterType other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcFilterTypeClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcFilterTypeClause.WR1)
			{
				result = PredefinedType != IfcFilterTypeEnum.USERDEFINED || (PredefinedType == IfcFilterTypeEnum.USERDEFINED && Functions.EXISTS(base.ElementType));
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcFilterType>()?.LogError($"Exception thrown evaluating where-clause 'IfcFilterType.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcFilterTypeClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcFilterType.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
