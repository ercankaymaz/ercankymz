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

[ExpressType("IfcPumpType", 685)]
public class IfcPumpType : IfcFlowMovingDeviceType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcPumpType>, IIfcPumpType, IIfcFlowMovingDeviceType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IExpressValidatable
{
	public enum IfcPumpTypeClause
	{
		WR1
	}

	private IfcPumpTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 15)]
	public IfcPumpTypeEnum PredefinedType
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
			SetValue(delegate(IfcPumpTypeEnum v)
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

	[CrossSchemaAttribute(typeof(IIfcPumpType), 10)]
	Xbim.Ifc4.Interfaces.IfcPumpTypeEnum IIfcPumpType.PredefinedType
	{
		get
		{
			switch (PredefinedType)
			{
			case IfcPumpTypeEnum.CIRCULATOR:
				return Xbim.Ifc4.Interfaces.IfcPumpTypeEnum.CIRCULATOR;
			case IfcPumpTypeEnum.ENDSUCTION:
				return Xbim.Ifc4.Interfaces.IfcPumpTypeEnum.ENDSUCTION;
			case IfcPumpTypeEnum.SPLITCASE:
				return Xbim.Ifc4.Interfaces.IfcPumpTypeEnum.SPLITCASE;
			case IfcPumpTypeEnum.VERTICALINLINE:
				return Xbim.Ifc4.Interfaces.IfcPumpTypeEnum.VERTICALINLINE;
			case IfcPumpTypeEnum.VERTICALTURBINE:
				return Xbim.Ifc4.Interfaces.IfcPumpTypeEnum.VERTICALTURBINE;
			case IfcPumpTypeEnum.USERDEFINED:
			{
				if (base.ElementType.HasValue && Enum.TryParse<Xbim.Ifc4.Interfaces.IfcPumpTypeEnum>(base.ElementType.Value, ignoreCase: false, out var result))
				{
					return result;
				}
				return Xbim.Ifc4.Interfaces.IfcPumpTypeEnum.USERDEFINED;
			}
			case IfcPumpTypeEnum.NOTDEFINED:
				return Xbim.Ifc4.Interfaces.IfcPumpTypeEnum.NOTDEFINED;
			default:
				throw new ArgumentOutOfRangeException();
			}
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
				base.ElementType = value.ToString();
				PredefinedType = IfcPumpTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcPumpTypeEnum.SUMPPUMP:
				base.ElementType = value.ToString();
				PredefinedType = IfcPumpTypeEnum.USERDEFINED;
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
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcPumpType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcPumpTypeEnum)Enum.Parse(typeof(IfcPumpTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcPumpType other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcPumpTypeClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcPumpTypeClause.WR1)
			{
				result = PredefinedType != IfcPumpTypeEnum.USERDEFINED || (PredefinedType == IfcPumpTypeEnum.USERDEFINED && Functions.EXISTS(base.ElementType));
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcPumpType>()?.LogError($"Exception thrown evaluating where-clause 'IfcPumpType.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcPumpTypeClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcPumpType.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
