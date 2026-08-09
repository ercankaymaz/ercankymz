using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.StructuralElementsDomain;

[ExpressType("IfcReinforcingBarType", 1245)]
public class IfcReinforcingBarType : IfcReinforcingElementType, IInstantiableEntity, IPersistEntity, IPersist, IIfcReinforcingBarType, IIfcReinforcingElementType, IIfcElementComponentType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcReinforcingBarType>, IExpressValidatable
{
	public enum IfcReinforcingBarTypeClause
	{
		CorrectPredefinedType,
		BendingShapeCodeProvided
	}

	private IfcReinforcingBarTypeEnum _predefinedType;

	private IfcPositiveLengthMeasure? _nominalDiameter;

	private IfcAreaMeasure? _crossSectionArea;

	private IfcPositiveLengthMeasure? _barLength;

	private IfcReinforcingBarSurfaceEnum? _barSurface;

	private IfcLabel? _bendingShapeCode;

	private readonly OptionalItemSet<IfcBendingParameterSelect> _bendingParameters;

	IfcReinforcingBarTypeEnum IIfcReinforcingBarType.PredefinedType
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

	IfcPositiveLengthMeasure? IIfcReinforcingBarType.NominalDiameter
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

	IfcAreaMeasure? IIfcReinforcingBarType.CrossSectionArea
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

	IfcPositiveLengthMeasure? IIfcReinforcingBarType.BarLength
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

	IfcReinforcingBarSurfaceEnum? IIfcReinforcingBarType.BarSurface
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

	IfcLabel? IIfcReinforcingBarType.BendingShapeCode
	{
		get
		{
			return BendingShapeCode;
		}
		set
		{
			BendingShapeCode = value;
		}
	}

	IItemSet<IIfcBendingParameterSelect> IIfcReinforcingBarType.BendingParameters => new ProxyItemSet<IfcBendingParameterSelect, IIfcBendingParameterSelect>(BendingParameters);

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcReinforcingBarTypeEnum PredefinedType
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
			SetValue(delegate(IfcReinforcingBarTypeEnum v)
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

	[EntityAttribute(13, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 22)]
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
			}, _barLength, value, "BarLength", 13);
		}
	}

	[EntityAttribute(14, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 23)]
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

	[EntityAttribute(15, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 24)]
	public IfcLabel? BendingShapeCode
	{
		get
		{
			if (_activated)
			{
				return _bendingShapeCode;
			}
			Activate();
			return _bendingShapeCode;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_bendingShapeCode = v;
			}, _bendingShapeCode, value, "BendingShapeCode", 15);
		}
	}

	[EntityAttribute(16, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 25)]
	public IOptionalItemSet<IfcBendingParameterSelect> BendingParameters
	{
		get
		{
			if (_activated)
			{
				return _bendingParameters;
			}
			Activate();
			return _bendingParameters;
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

	internal IfcReinforcingBarType(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_bendingParameters = new OptionalItemSet<IfcBendingParameterSelect>(this, 0, 16);
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
			_predefinedType = (IfcReinforcingBarTypeEnum)Enum.Parse(typeof(IfcReinforcingBarTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 10:
			_nominalDiameter = value.RealVal;
			break;
		case 11:
			_crossSectionArea = value.RealVal;
			break;
		case 12:
			_barLength = value.RealVal;
			break;
		case 13:
			_barSurface = (IfcReinforcingBarSurfaceEnum)Enum.Parse(typeof(IfcReinforcingBarSurfaceEnum), value.EnumVal, ignoreCase: true);
			break;
		case 14:
			_bendingShapeCode = value.StringVal;
			break;
		case 15:
			_bendingParameters.InternalAdd((IfcBendingParameterSelect)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcReinforcingBarType other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcReinforcingBarTypeClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcReinforcingBarTypeClause.CorrectPredefinedType:
				result = PredefinedType != IfcReinforcingBarTypeEnum.USERDEFINED || (PredefinedType == IfcReinforcingBarTypeEnum.USERDEFINED && Functions.EXISTS(base.ElementType));
				break;
			case IfcReinforcingBarTypeClause.BendingShapeCodeProvided:
				result = !Functions.EXISTS(BendingParameters) || Functions.EXISTS(BendingShapeCode);
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcReinforcingBarType>()?.LogError($"Exception thrown evaluating where-clause 'IfcReinforcingBarType.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcReinforcingBarTypeClause.CorrectPredefinedType))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcReinforcingBarType.CorrectPredefinedType",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcReinforcingBarTypeClause.BendingShapeCodeProvided))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcReinforcingBarType.BendingShapeCodeProvided",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
