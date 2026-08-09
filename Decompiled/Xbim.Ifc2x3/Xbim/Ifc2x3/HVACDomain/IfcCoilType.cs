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

[ExpressType("IfcCoilType", 622)]
public class IfcCoilType : IfcEnergyConversionDeviceType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcCoilType>, IIfcCoilType, IIfcEnergyConversionDeviceType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IExpressValidatable
{
	public enum IfcCoilTypeClause
	{
		WR1
	}

	private IfcCoilTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 15)]
	public IfcCoilTypeEnum PredefinedType
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
			SetValue(delegate(IfcCoilTypeEnum v)
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

	[CrossSchemaAttribute(typeof(IIfcCoilType), 10)]
	Xbim.Ifc4.Interfaces.IfcCoilTypeEnum IIfcCoilType.PredefinedType
	{
		get
		{
			switch (PredefinedType)
			{
			case IfcCoilTypeEnum.DXCOOLINGCOIL:
				return Xbim.Ifc4.Interfaces.IfcCoilTypeEnum.DXCOOLINGCOIL;
			case IfcCoilTypeEnum.WATERCOOLINGCOIL:
				return Xbim.Ifc4.Interfaces.IfcCoilTypeEnum.WATERCOOLINGCOIL;
			case IfcCoilTypeEnum.STEAMHEATINGCOIL:
				return Xbim.Ifc4.Interfaces.IfcCoilTypeEnum.STEAMHEATINGCOIL;
			case IfcCoilTypeEnum.WATERHEATINGCOIL:
				return Xbim.Ifc4.Interfaces.IfcCoilTypeEnum.WATERHEATINGCOIL;
			case IfcCoilTypeEnum.ELECTRICHEATINGCOIL:
				return Xbim.Ifc4.Interfaces.IfcCoilTypeEnum.ELECTRICHEATINGCOIL;
			case IfcCoilTypeEnum.GASHEATINGCOIL:
				return Xbim.Ifc4.Interfaces.IfcCoilTypeEnum.GASHEATINGCOIL;
			case IfcCoilTypeEnum.USERDEFINED:
			{
				if (base.ElementType.HasValue && Enum.TryParse<Xbim.Ifc4.Interfaces.IfcCoilTypeEnum>(base.ElementType.Value, ignoreCase: false, out var result))
				{
					return result;
				}
				return Xbim.Ifc4.Interfaces.IfcCoilTypeEnum.USERDEFINED;
			}
			case IfcCoilTypeEnum.NOTDEFINED:
				return Xbim.Ifc4.Interfaces.IfcCoilTypeEnum.NOTDEFINED;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcCoilTypeEnum.DXCOOLINGCOIL:
				PredefinedType = IfcCoilTypeEnum.DXCOOLINGCOIL;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoilTypeEnum.ELECTRICHEATINGCOIL:
				PredefinedType = IfcCoilTypeEnum.ELECTRICHEATINGCOIL;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoilTypeEnum.GASHEATINGCOIL:
				PredefinedType = IfcCoilTypeEnum.GASHEATINGCOIL;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoilTypeEnum.HYDRONICCOIL:
				base.ElementType = value.ToString();
				PredefinedType = IfcCoilTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoilTypeEnum.STEAMHEATINGCOIL:
				PredefinedType = IfcCoilTypeEnum.STEAMHEATINGCOIL;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoilTypeEnum.WATERCOOLINGCOIL:
				PredefinedType = IfcCoilTypeEnum.WATERCOOLINGCOIL;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoilTypeEnum.WATERHEATINGCOIL:
				PredefinedType = IfcCoilTypeEnum.WATERHEATINGCOIL;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoilTypeEnum.USERDEFINED:
				PredefinedType = IfcCoilTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoilTypeEnum.NOTDEFINED:
				PredefinedType = IfcCoilTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcCoilType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcCoilTypeEnum)Enum.Parse(typeof(IfcCoilTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcCoilType other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcCoilTypeClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcCoilTypeClause.WR1)
			{
				result = PredefinedType != IfcCoilTypeEnum.USERDEFINED || (PredefinedType == IfcCoilTypeEnum.USERDEFINED && Functions.EXISTS(base.ElementType));
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcCoilType>()?.LogError($"Exception thrown evaluating where-clause 'IfcCoilType.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcCoilTypeClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcCoilType.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
