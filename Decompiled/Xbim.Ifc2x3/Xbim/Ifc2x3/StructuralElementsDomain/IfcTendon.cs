using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.StructuralAnalysisDomain;

namespace Xbim.Ifc2x3.StructuralElementsDomain;

[ExpressType("IfcTendon", 261)]
public class IfcTendon : IfcReinforcingElement, IIfcTendon, IIfcReinforcingElement, IIfcElementComponent, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcTendon>, IExpressValidatable
{
	public enum IfcTendonClause
	{
		WR1
	}

	private IfcTendonTypeEnum _predefinedType;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure _nominalDiameter;

	private Xbim.Ifc2x3.MeasureResource.IfcAreaMeasure _crossSectionArea;

	private Xbim.Ifc2x3.MeasureResource.IfcForceMeasure? _tensionForce;

	private Xbim.Ifc2x3.MeasureResource.IfcPressureMeasure? _preStress;

	private Xbim.Ifc2x3.MeasureResource.IfcNormalisedRatioMeasure? _frictionCoefficient;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? _anchorageSlip;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? _minCurvatureRadius;

	[CrossSchemaAttribute(typeof(IIfcTendon), 10)]
	Xbim.Ifc4.Interfaces.IfcTendonTypeEnum? IIfcTendon.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcTendonTypeEnum.STRAND => Xbim.Ifc4.Interfaces.IfcTendonTypeEnum.STRAND, 
				IfcTendonTypeEnum.WIRE => Xbim.Ifc4.Interfaces.IfcTendonTypeEnum.WIRE, 
				IfcTendonTypeEnum.BAR => Xbim.Ifc4.Interfaces.IfcTendonTypeEnum.BAR, 
				IfcTendonTypeEnum.COATED => Xbim.Ifc4.Interfaces.IfcTendonTypeEnum.COATED, 
				IfcTendonTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcTendonTypeEnum.USERDEFINED, 
				IfcTendonTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcTendonTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcTendonTypeEnum.BAR:
				PredefinedType = IfcTendonTypeEnum.BAR;
				break;
			case Xbim.Ifc4.Interfaces.IfcTendonTypeEnum.COATED:
				PredefinedType = IfcTendonTypeEnum.COATED;
				break;
			case Xbim.Ifc4.Interfaces.IfcTendonTypeEnum.STRAND:
				PredefinedType = IfcTendonTypeEnum.STRAND;
				break;
			case Xbim.Ifc4.Interfaces.IfcTendonTypeEnum.WIRE:
				PredefinedType = IfcTendonTypeEnum.WIRE;
				break;
			case Xbim.Ifc4.Interfaces.IfcTendonTypeEnum.USERDEFINED:
				PredefinedType = IfcTendonTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcTendonTypeEnum.NOTDEFINED:
				PredefinedType = IfcTendonTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = IfcTendonTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcTendon), 11)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure? IIfcTendon.NominalDiameter
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(NominalDiameter);
		}
		set
		{
			NominalDiameter = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure(value.Value) : default(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcTendon), 12)]
	Xbim.Ifc4.MeasureResource.IfcAreaMeasure? IIfcTendon.CrossSectionArea
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcAreaMeasure(CrossSectionArea);
		}
		set
		{
			CrossSectionArea = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcAreaMeasure(value.Value) : default(Xbim.Ifc2x3.MeasureResource.IfcAreaMeasure));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcTendon), 13)]
	Xbim.Ifc4.MeasureResource.IfcForceMeasure? IIfcTendon.TensionForce
	{
		get
		{
			if (!TensionForce.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcForceMeasure(TensionForce.Value);
		}
		set
		{
			TensionForce = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcForceMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcForceMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcForceMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcTendon), 14)]
	Xbim.Ifc4.MeasureResource.IfcPressureMeasure? IIfcTendon.PreStress
	{
		get
		{
			if (!PreStress.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcPressureMeasure(PreStress.Value);
		}
		set
		{
			PreStress = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcPressureMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcPressureMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcPressureMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcTendon), 15)]
	Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure? IIfcTendon.FrictionCoefficient
	{
		get
		{
			if (!FrictionCoefficient.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure(FrictionCoefficient.Value);
		}
		set
		{
			FrictionCoefficient = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcNormalisedRatioMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcNormalisedRatioMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcNormalisedRatioMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcTendon), 16)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure? IIfcTendon.AnchorageSlip
	{
		get
		{
			if (!AnchorageSlip.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(AnchorageSlip.Value);
		}
		set
		{
			AnchorageSlip = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcTendon), 17)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure? IIfcTendon.MinCurvatureRadius
	{
		get
		{
			if (!MinCurvatureRadius.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(MinCurvatureRadius.Value);
		}
		set
		{
			MinCurvatureRadius = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure?)null));
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 28)]
	public IfcTendonTypeEnum PredefinedType
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
			SetValue(delegate(IfcTendonTypeEnum v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 29)]
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure NominalDiameter
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure v)
			{
				_nominalDiameter = v;
			}, _nominalDiameter, value, "NominalDiameter", 11);
		}
	}

	[EntityAttribute(12, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 30)]
	public Xbim.Ifc2x3.MeasureResource.IfcAreaMeasure CrossSectionArea
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcAreaMeasure v)
			{
				_crossSectionArea = v;
			}, _crossSectionArea, value, "CrossSectionArea", 12);
		}
	}

	[EntityAttribute(13, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 31)]
	public Xbim.Ifc2x3.MeasureResource.IfcForceMeasure? TensionForce
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcForceMeasure? v)
			{
				_tensionForce = v;
			}, _tensionForce, value, "TensionForce", 13);
		}
	}

	[EntityAttribute(14, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 32)]
	public Xbim.Ifc2x3.MeasureResource.IfcPressureMeasure? PreStress
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPressureMeasure? v)
			{
				_preStress = v;
			}, _preStress, value, "PreStress", 14);
		}
	}

	[EntityAttribute(15, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 33)]
	public Xbim.Ifc2x3.MeasureResource.IfcNormalisedRatioMeasure? FrictionCoefficient
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcNormalisedRatioMeasure? v)
			{
				_frictionCoefficient = v;
			}, _frictionCoefficient, value, "FrictionCoefficient", 15);
		}
	}

	[EntityAttribute(16, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 34)]
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? AnchorageSlip
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? v)
			{
				_anchorageSlip = v;
			}, _anchorageSlip, value, "AnchorageSlip", 16);
		}
	}

	[EntityAttribute(17, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 35)]
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? MinCurvatureRadius
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? v)
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
			if (clause == IfcTendonClause.WR1)
			{
				result = PredefinedType != IfcTendonTypeEnum.USERDEFINED || (PredefinedType == IfcTendonTypeEnum.USERDEFINED && Functions.EXISTS(base.ObjectType));
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
		if (!ValidateClause(IfcTendonClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcTendon.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
