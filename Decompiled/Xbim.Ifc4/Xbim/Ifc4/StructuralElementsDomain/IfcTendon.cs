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

namespace Xbim.Ifc4.StructuralElementsDomain;

[ExpressType("IfcTendon", 261)]
public class IfcTendon : IfcReinforcingElement, IInstantiableEntity, IPersistEntity, IPersist, IIfcTendon, IIfcReinforcingElement, IIfcElementComponent, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcTendon>, IExpressValidatable
{
	public enum IfcTendonClause
	{
		CorrectPredefinedType,
		CorrectTypeAssigned
	}

	private IfcTendonTypeEnum? _predefinedType;

	private IfcPositiveLengthMeasure? _nominalDiameter;

	private IfcAreaMeasure? _crossSectionArea;

	private IfcForceMeasure? _tensionForce;

	private IfcPressureMeasure? _preStress;

	private IfcNormalisedRatioMeasure? _frictionCoefficient;

	private IfcPositiveLengthMeasure? _anchorageSlip;

	private IfcPositiveLengthMeasure? _minCurvatureRadius;

	IfcTendonTypeEnum? IIfcTendon.PredefinedType
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

	IfcPositiveLengthMeasure? IIfcTendon.NominalDiameter
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

	IfcAreaMeasure? IIfcTendon.CrossSectionArea
	{
		get
		{
			return CrossSectionArea;
		}
		set
		{
			CrossSectionArea = value;
		}
	}

	IfcForceMeasure? IIfcTendon.TensionForce
	{
		get
		{
			return TensionForce;
		}
		set
		{
			TensionForce = value;
		}
	}

	IfcPressureMeasure? IIfcTendon.PreStress
	{
		get
		{
			return PreStress;
		}
		set
		{
			PreStress = value;
		}
	}

	IfcNormalisedRatioMeasure? IIfcTendon.FrictionCoefficient
	{
		get
		{
			return FrictionCoefficient;
		}
		set
		{
			FrictionCoefficient = value;
		}
	}

	IfcPositiveLengthMeasure? IIfcTendon.AnchorageSlip
	{
		get
		{
			return AnchorageSlip;
		}
		set
		{
			AnchorageSlip = value;
		}
	}

	IfcPositiveLengthMeasure? IIfcTendon.MinCurvatureRadius
	{
		get
		{
			return MinCurvatureRadius;
		}
		set
		{
			MinCurvatureRadius = value;
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 34)]
	public IfcTendonTypeEnum? PredefinedType
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
			SetValue(delegate(IfcTendonTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 35)]
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

	[EntityAttribute(12, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 36)]
	public IfcAreaMeasure? CrossSectionArea
	{
		get
		{
			if (_activated)
			{
				return _crossSectionArea;
			}
			Activate();
			return _crossSectionArea;
		}
		set
		{
			SetValue(delegate(IfcAreaMeasure? v)
			{
				_crossSectionArea = v;
			}, _crossSectionArea, value, "CrossSectionArea", 12);
		}
	}

	[EntityAttribute(13, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 37)]
	public IfcForceMeasure? TensionForce
	{
		get
		{
			if (_activated)
			{
				return _tensionForce;
			}
			Activate();
			return _tensionForce;
		}
		set
		{
			SetValue(delegate(IfcForceMeasure? v)
			{
				_tensionForce = v;
			}, _tensionForce, value, "TensionForce", 13);
		}
	}

	[EntityAttribute(14, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 38)]
	public IfcPressureMeasure? PreStress
	{
		get
		{
			if (_activated)
			{
				return _preStress;
			}
			Activate();
			return _preStress;
		}
		set
		{
			SetValue(delegate(IfcPressureMeasure? v)
			{
				_preStress = v;
			}, _preStress, value, "PreStress", 14);
		}
	}

	[EntityAttribute(15, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 39)]
	public IfcNormalisedRatioMeasure? FrictionCoefficient
	{
		get
		{
			if (_activated)
			{
				return _frictionCoefficient;
			}
			Activate();
			return _frictionCoefficient;
		}
		set
		{
			SetValue(delegate(IfcNormalisedRatioMeasure? v)
			{
				_frictionCoefficient = v;
			}, _frictionCoefficient, value, "FrictionCoefficient", 15);
		}
	}

	[EntityAttribute(16, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 40)]
	public IfcPositiveLengthMeasure? AnchorageSlip
	{
		get
		{
			if (_activated)
			{
				return _anchorageSlip;
			}
			Activate();
			return _anchorageSlip;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure? v)
			{
				_anchorageSlip = v;
			}, _anchorageSlip, value, "AnchorageSlip", 16);
		}
	}

	[EntityAttribute(17, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 41)]
	public IfcPositiveLengthMeasure? MinCurvatureRadius
	{
		get
		{
			if (_activated)
			{
				return _minCurvatureRadius;
			}
			Activate();
			return _minCurvatureRadius;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure? v)
			{
				_minCurvatureRadius = v;
			}, _minCurvatureRadius, value, "MinCurvatureRadius", 17);
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

	internal IfcTendon(IModel model, int label, bool activated)
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
			_predefinedType = (IfcTendonTypeEnum)Enum.Parse(typeof(IfcTendonTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 10:
			_nominalDiameter = value.RealVal;
			break;
		case 11:
			_crossSectionArea = value.RealVal;
			break;
		case 12:
			_tensionForce = value.RealVal;
			break;
		case 13:
			_preStress = value.RealVal;
			break;
		case 14:
			_frictionCoefficient = value.RealVal;
			break;
		case 15:
			_anchorageSlip = value.RealVal;
			break;
		case 16:
			_minCurvatureRadius = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcTendon other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcTendonClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcTendonClause.CorrectPredefinedType:
				result = !Functions.EXISTS(PredefinedType) || PredefinedType != IfcTendonTypeEnum.USERDEFINED || (PredefinedType == IfcTendonTypeEnum.USERDEFINED && Functions.EXISTS(base.ObjectType));
				break;
			case IfcTendonClause.CorrectTypeAssigned:
				result = Functions.SIZEOF(base.IsTypedBy) == 0 || Functions.TYPEOF(base.IsTypedBy.ItemAt(0L).RelatingType).Contains("IFC4.IFCTENDONTYPE");
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcTendon>()?.LogError($"Exception thrown evaluating where-clause 'IfcTendon.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcTendonClause.CorrectPredefinedType))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcTendon.CorrectPredefinedType",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcTendonClause.CorrectTypeAssigned))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcTendon.CorrectTypeAssigned",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
