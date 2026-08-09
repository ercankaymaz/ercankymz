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

[ExpressType("IfcReinforcingBar", 571)]
public class IfcReinforcingBar : IfcReinforcingElement, IInstantiableEntity, IPersistEntity, IPersist, IIfcReinforcingBar, IIfcReinforcingElement, IIfcElementComponent, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcReinforcingBar>, IExpressValidatable
{
	public enum IfcReinforcingBarClause
	{
		CorrectPredefinedType,
		CorrectTypeAssigned
	}

	private IfcPositiveLengthMeasure? _nominalDiameter;

	private IfcAreaMeasure? _crossSectionArea;

	private IfcPositiveLengthMeasure? _barLength;

	private IfcReinforcingBarTypeEnum? _predefinedType;

	private IfcReinforcingBarSurfaceEnum? _barSurface;

	IfcPositiveLengthMeasure? IIfcReinforcingBar.NominalDiameter
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

	IfcAreaMeasure? IIfcReinforcingBar.CrossSectionArea
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

	IfcPositiveLengthMeasure? IIfcReinforcingBar.BarLength
	{
		get
		{
			return BarLength;
		}
		set
		{
			BarLength = value;
		}
	}

	IfcReinforcingBarTypeEnum? IIfcReinforcingBar.PredefinedType
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

	IfcReinforcingBarSurfaceEnum? IIfcReinforcingBar.BarSurface
	{
		get
		{
			return BarSurface;
		}
		set
		{
			BarSurface = value;
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 34)]
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
			}, _nominalDiameter, value, "NominalDiameter", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 35)]
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
			}, _crossSectionArea, value, "CrossSectionArea", 11);
		}
	}

	[EntityAttribute(12, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 36)]
	public IfcPositiveLengthMeasure? BarLength
	{
		get
		{
			if (_activated)
			{
				return _barLength;
			}
			Activate();
			return _barLength;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure? v)
			{
				_barLength = v;
			}, _barLength, value, "BarLength", 12);
		}
	}

	[EntityAttribute(13, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 37)]
	public IfcReinforcingBarTypeEnum? PredefinedType
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
			SetValue(delegate(IfcReinforcingBarTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 13);
		}
	}

	[EntityAttribute(14, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 38)]
	public IfcReinforcingBarSurfaceEnum? BarSurface
	{
		get
		{
			if (_activated)
			{
				return _barSurface;
			}
			Activate();
			return _barSurface;
		}
		set
		{
			SetValue(delegate(IfcReinforcingBarSurfaceEnum? v)
			{
				_barSurface = v;
			}, _barSurface, value, "BarSurface", 14);
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

	internal IfcReinforcingBar(IModel model, int label, bool activated)
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
			_nominalDiameter = value.RealVal;
			break;
		case 10:
			_crossSectionArea = value.RealVal;
			break;
		case 11:
			_barLength = value.RealVal;
			break;
		case 12:
			_predefinedType = (IfcReinforcingBarTypeEnum)Enum.Parse(typeof(IfcReinforcingBarTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 13:
			_barSurface = (IfcReinforcingBarSurfaceEnum)Enum.Parse(typeof(IfcReinforcingBarSurfaceEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcReinforcingBar other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcReinforcingBarClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcReinforcingBarClause.CorrectPredefinedType:
				result = !Functions.EXISTS(PredefinedType) || PredefinedType != IfcReinforcingBarTypeEnum.USERDEFINED || (PredefinedType == IfcReinforcingBarTypeEnum.USERDEFINED && Functions.EXISTS(base.ObjectType));
				break;
			case IfcReinforcingBarClause.CorrectTypeAssigned:
				result = Functions.SIZEOF(base.IsTypedBy) == 0 || Functions.TYPEOF(base.IsTypedBy.ItemAt(0L).RelatingType).Contains("IFC4.IFCREINFORCINGBARTYPE");
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcReinforcingBar>()?.LogError($"Exception thrown evaluating where-clause 'IfcReinforcingBar.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcReinforcingBarClause.CorrectPredefinedType))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcReinforcingBar.CorrectPredefinedType",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcReinforcingBarClause.CorrectTypeAssigned))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcReinforcingBar.CorrectTypeAssigned",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
