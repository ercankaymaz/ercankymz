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

[ExpressType("IfcReinforcingMeshType", 1247)]
public class IfcReinforcingMeshType : IfcReinforcingElementType, IInstantiableEntity, IPersistEntity, IPersist, IIfcReinforcingMeshType, IIfcReinforcingElementType, IIfcElementComponentType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcReinforcingMeshType>, IExpressValidatable
{
	public enum IfcReinforcingMeshTypeClause
	{
		CorrectPredefinedType,
		BendingShapeCodeProvided
	}

	private IfcReinforcingMeshTypeEnum _predefinedType;

	private IfcPositiveLengthMeasure? _meshLength;

	private IfcPositiveLengthMeasure? _meshWidth;

	private IfcPositiveLengthMeasure? _longitudinalBarNominalDiameter;

	private IfcPositiveLengthMeasure? _transverseBarNominalDiameter;

	private IfcAreaMeasure? _longitudinalBarCrossSectionArea;

	private IfcAreaMeasure? _transverseBarCrossSectionArea;

	private IfcPositiveLengthMeasure? _longitudinalBarSpacing;

	private IfcPositiveLengthMeasure? _transverseBarSpacing;

	private IfcLabel? _bendingShapeCode;

	private readonly OptionalItemSet<IfcBendingParameterSelect> _bendingParameters;

	IfcReinforcingMeshTypeEnum IIfcReinforcingMeshType.PredefinedType
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

	IfcPositiveLengthMeasure? IIfcReinforcingMeshType.MeshLength
	{
		get
		{
			return MeshLength;
		}
		set
		{
			MeshLength = value;
		}
	}

	IfcPositiveLengthMeasure? IIfcReinforcingMeshType.MeshWidth
	{
		get
		{
			return MeshWidth;
		}
		set
		{
			MeshWidth = value;
		}
	}

	IfcPositiveLengthMeasure? IIfcReinforcingMeshType.LongitudinalBarNominalDiameter
	{
		get
		{
			return LongitudinalBarNominalDiameter;
		}
		set
		{
			LongitudinalBarNominalDiameter = value;
		}
	}

	IfcPositiveLengthMeasure? IIfcReinforcingMeshType.TransverseBarNominalDiameter
	{
		get
		{
			return TransverseBarNominalDiameter;
		}
		set
		{
			TransverseBarNominalDiameter = value;
		}
	}

	IfcAreaMeasure? IIfcReinforcingMeshType.LongitudinalBarCrossSectionArea
	{
		get
		{
			return LongitudinalBarCrossSectionArea;
		}
		set
		{
			LongitudinalBarCrossSectionArea = value;
		}
	}

	IfcAreaMeasure? IIfcReinforcingMeshType.TransverseBarCrossSectionArea
	{
		get
		{
			return TransverseBarCrossSectionArea;
		}
		set
		{
			TransverseBarCrossSectionArea = value;
		}
	}

	IfcPositiveLengthMeasure? IIfcReinforcingMeshType.LongitudinalBarSpacing
	{
		get
		{
			return LongitudinalBarSpacing;
		}
		set
		{
			LongitudinalBarSpacing = value;
		}
	}

	IfcPositiveLengthMeasure? IIfcReinforcingMeshType.TransverseBarSpacing
	{
		get
		{
			return TransverseBarSpacing;
		}
		set
		{
			TransverseBarSpacing = value;
		}
	}

	IfcLabel? IIfcReinforcingMeshType.BendingShapeCode
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

	IItemSet<IIfcBendingParameterSelect> IIfcReinforcingMeshType.BendingParameters => new ProxyItemSet<IfcBendingParameterSelect, IIfcBendingParameterSelect>(BendingParameters);

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcReinforcingMeshTypeEnum PredefinedType
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
			SetValue(delegate(IfcReinforcingMeshTypeEnum v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 20)]
	public IfcPositiveLengthMeasure? MeshLength
	{
		get
		{
			if (_activated)
			{
				return _meshLength;
			}
			Activate();
			return _meshLength;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure? v)
			{
				_meshLength = v;
			}, _meshLength, value, "MeshLength", 11);
		}
	}

	[EntityAttribute(12, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 21)]
	public IfcPositiveLengthMeasure? MeshWidth
	{
		get
		{
			if (_activated)
			{
				return _meshWidth;
			}
			Activate();
			return _meshWidth;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure? v)
			{
				_meshWidth = v;
			}, _meshWidth, value, "MeshWidth", 12);
		}
	}

	[EntityAttribute(13, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 22)]
	public IfcPositiveLengthMeasure? LongitudinalBarNominalDiameter
	{
		get
		{
			if (_activated)
			{
				return _longitudinalBarNominalDiameter;
			}
			Activate();
			return _longitudinalBarNominalDiameter;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure? v)
			{
				_longitudinalBarNominalDiameter = v;
			}, _longitudinalBarNominalDiameter, value, "LongitudinalBarNominalDiameter", 13);
		}
	}

	[EntityAttribute(14, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 23)]
	public IfcPositiveLengthMeasure? TransverseBarNominalDiameter
	{
		get
		{
			if (_activated)
			{
				return _transverseBarNominalDiameter;
			}
			Activate();
			return _transverseBarNominalDiameter;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure? v)
			{
				_transverseBarNominalDiameter = v;
			}, _transverseBarNominalDiameter, value, "TransverseBarNominalDiameter", 14);
		}
	}

	[EntityAttribute(15, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 24)]
	public IfcAreaMeasure? LongitudinalBarCrossSectionArea
	{
		get
		{
			if (_activated)
			{
				return _longitudinalBarCrossSectionArea;
			}
			Activate();
			return _longitudinalBarCrossSectionArea;
		}
		set
		{
			SetValue(delegate(IfcAreaMeasure? v)
			{
				_longitudinalBarCrossSectionArea = v;
			}, _longitudinalBarCrossSectionArea, value, "LongitudinalBarCrossSectionArea", 15);
		}
	}

	[EntityAttribute(16, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 25)]
	public IfcAreaMeasure? TransverseBarCrossSectionArea
	{
		get
		{
			if (_activated)
			{
				return _transverseBarCrossSectionArea;
			}
			Activate();
			return _transverseBarCrossSectionArea;
		}
		set
		{
			SetValue(delegate(IfcAreaMeasure? v)
			{
				_transverseBarCrossSectionArea = v;
			}, _transverseBarCrossSectionArea, value, "TransverseBarCrossSectionArea", 16);
		}
	}

	[EntityAttribute(17, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 26)]
	public IfcPositiveLengthMeasure? LongitudinalBarSpacing
	{
		get
		{
			if (_activated)
			{
				return _longitudinalBarSpacing;
			}
			Activate();
			return _longitudinalBarSpacing;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure? v)
			{
				_longitudinalBarSpacing = v;
			}, _longitudinalBarSpacing, value, "LongitudinalBarSpacing", 17);
		}
	}

	[EntityAttribute(18, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 27)]
	public IfcPositiveLengthMeasure? TransverseBarSpacing
	{
		get
		{
			if (_activated)
			{
				return _transverseBarSpacing;
			}
			Activate();
			return _transverseBarSpacing;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure? v)
			{
				_transverseBarSpacing = v;
			}, _transverseBarSpacing, value, "TransverseBarSpacing", 18);
		}
	}

	[EntityAttribute(19, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 28)]
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
			}, _bendingShapeCode, value, "BendingShapeCode", 19);
		}
	}

	[EntityAttribute(20, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 29)]
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

	internal IfcReinforcingMeshType(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_bendingParameters = new OptionalItemSet<IfcBendingParameterSelect>(this, 0, 20);
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
			_predefinedType = (IfcReinforcingMeshTypeEnum)Enum.Parse(typeof(IfcReinforcingMeshTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 10:
			_meshLength = value.RealVal;
			break;
		case 11:
			_meshWidth = value.RealVal;
			break;
		case 12:
			_longitudinalBarNominalDiameter = value.RealVal;
			break;
		case 13:
			_transverseBarNominalDiameter = value.RealVal;
			break;
		case 14:
			_longitudinalBarCrossSectionArea = value.RealVal;
			break;
		case 15:
			_transverseBarCrossSectionArea = value.RealVal;
			break;
		case 16:
			_longitudinalBarSpacing = value.RealVal;
			break;
		case 17:
			_transverseBarSpacing = value.RealVal;
			break;
		case 18:
			_bendingShapeCode = value.StringVal;
			break;
		case 19:
			_bendingParameters.InternalAdd((IfcBendingParameterSelect)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcReinforcingMeshType other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcReinforcingMeshTypeClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcReinforcingMeshTypeClause.CorrectPredefinedType:
				result = PredefinedType != IfcReinforcingMeshTypeEnum.USERDEFINED || (PredefinedType == IfcReinforcingMeshTypeEnum.USERDEFINED && Functions.EXISTS(base.ElementType));
				break;
			case IfcReinforcingMeshTypeClause.BendingShapeCodeProvided:
				result = !Functions.EXISTS(BendingParameters) || Functions.EXISTS(BendingShapeCode);
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcReinforcingMeshType>()?.LogError($"Exception thrown evaluating where-clause 'IfcReinforcingMeshType.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcReinforcingMeshTypeClause.CorrectPredefinedType))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcReinforcingMeshType.CorrectPredefinedType",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcReinforcingMeshTypeClause.BendingShapeCodeProvided))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcReinforcingMeshType.BendingShapeCodeProvided",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
