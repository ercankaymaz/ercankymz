using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.SharedComponentElements;

[ExpressType("IfcMechanicalFastener", 536)]
public class IfcMechanicalFastener : IfcElementComponent, IInstantiableEntity, IPersistEntity, IPersist, IIfcMechanicalFastener, IIfcElementComponent, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcMechanicalFastener>, IExpressValidatable
{
	public enum IfcMechanicalFastenerClause
	{
		CorrectPredefinedType,
		CorrectTypeAssigned
	}

	private IfcPositiveLengthMeasure? _nominalDiameter;

	private IfcPositiveLengthMeasure? _nominalLength;

	private IfcMechanicalFastenerTypeEnum? _predefinedType;

	IfcPositiveLengthMeasure? IIfcMechanicalFastener.NominalDiameter
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

	IfcPositiveLengthMeasure? IIfcMechanicalFastener.NominalLength
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

	IfcMechanicalFastenerTypeEnum? IIfcMechanicalFastener.PredefinedType
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

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 33)]
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
			}, _nominalDiameter, value, "NominalDiameter", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 34)]
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
			}, _nominalLength, value, "NominalLength", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 35)]
	public IfcMechanicalFastenerTypeEnum? PredefinedType
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
			SetValue(delegate(IfcMechanicalFastenerTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 11);
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

	internal IfcMechanicalFastener(IModel model, int label, bool activated)
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
			_nominalDiameter = value.RealVal;
			break;
		case 9:
			_nominalLength = value.RealVal;
			break;
		case 10:
			_predefinedType = (IfcMechanicalFastenerTypeEnum)Enum.Parse(typeof(IfcMechanicalFastenerTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcMechanicalFastener other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcMechanicalFastenerClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcMechanicalFastenerClause.CorrectPredefinedType:
				result = !Functions.EXISTS(PredefinedType) || PredefinedType != IfcMechanicalFastenerTypeEnum.USERDEFINED || (PredefinedType == IfcMechanicalFastenerTypeEnum.USERDEFINED && Functions.EXISTS(base.ObjectType));
				break;
			case IfcMechanicalFastenerClause.CorrectTypeAssigned:
				result = Functions.SIZEOF(base.IsTypedBy) == 0 || Functions.TYPEOF(base.IsTypedBy.ItemAt(0L).RelatingType).Contains("IFC4.IFCMECHANICALFASTENERTYPE");
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcMechanicalFastener>()?.LogError($"Exception thrown evaluating where-clause 'IfcMechanicalFastener.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcMechanicalFastenerClause.CorrectPredefinedType))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcMechanicalFastener.CorrectPredefinedType",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcMechanicalFastenerClause.CorrectTypeAssigned))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcMechanicalFastener.CorrectTypeAssigned",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
