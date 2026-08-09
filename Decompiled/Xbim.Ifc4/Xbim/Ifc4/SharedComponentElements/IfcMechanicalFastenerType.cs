using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.SharedComponentElements;

[ExpressType("IfcMechanicalFastenerType", 643)]
public class IfcMechanicalFastenerType : IfcElementComponentType, IInstantiableEntity, IPersistEntity, IPersist, IIfcMechanicalFastenerType, IIfcElementComponentType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcMechanicalFastenerType>, IExpressValidatable
{
	public enum IfcMechanicalFastenerTypeClause
	{
		CorrectPredefinedType
	}

	private IfcMechanicalFastenerTypeEnum _predefinedType;

	private IfcPositiveLengthMeasure? _nominalDiameter;

	private IfcPositiveLengthMeasure? _nominalLength;

	IfcMechanicalFastenerTypeEnum IIfcMechanicalFastenerType.PredefinedType
	{
		get
		{
			return PredefinedType;
		}
		set
		{
			PredefinedType = value;
		}
	}

	IfcPositiveLengthMeasure? IIfcMechanicalFastenerType.NominalDiameter
	{
		get
		{
			return NominalDiameter;
		}
		set
		{
			NominalDiameter = value;
		}
	}

	IfcPositiveLengthMeasure? IIfcMechanicalFastenerType.NominalLength
	{
		get
		{
			return NominalLength;
		}
		set
		{
			NominalLength = value;
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcMechanicalFastenerTypeEnum PredefinedType
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
			SetValue(delegate(IfcMechanicalFastenerTypeEnum v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 20)]
	public IfcPositiveLengthMeasure? NominalDiameter
	{
		get
		{
			if (_activated)
			{
				return _nominalDiameter;
			}
			Activate();
			return _nominalDiameter;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure? v)
			{
				_nominalDiameter = v;
			}, _nominalDiameter, value, "NominalDiameter", 11);
		}
	}

	[EntityAttribute(12, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 21)]
	public IfcPositiveLengthMeasure? NominalLength
	{
		get
		{
			if (_activated)
			{
				return _nominalLength;
			}
			Activate();
			return _nominalLength;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure? v)
			{
				_nominalLength = v;
			}, _nominalLength, value, "NominalLength", 12);
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
			foreach (IfcPropertySetDefinition hasPropertySet in base.HasPropertySets)
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
			foreach (IfcPropertySetDefinition hasPropertySet in base.HasPropertySets)
			{
				yield return hasPropertySet;
			}
		}
	}

	internal IfcMechanicalFastenerType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcMechanicalFastenerTypeEnum)Enum.Parse(typeof(IfcMechanicalFastenerTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 10:
			_nominalDiameter = value.RealVal;
			break;
		case 11:
			_nominalLength = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcMechanicalFastenerType other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcMechanicalFastenerTypeClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcMechanicalFastenerTypeClause.CorrectPredefinedType)
			{
				result = PredefinedType != IfcMechanicalFastenerTypeEnum.USERDEFINED || (PredefinedType == IfcMechanicalFastenerTypeEnum.USERDEFINED && Functions.EXISTS(base.ElementType));
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcMechanicalFastenerType>()?.LogError($"Exception thrown evaluating where-clause 'IfcMechanicalFastenerType.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcMechanicalFastenerTypeClause.CorrectPredefinedType))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcMechanicalFastenerType.CorrectPredefinedType",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
