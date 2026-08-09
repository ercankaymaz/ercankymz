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
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.StructuralAnalysisDomain;

[ExpressType("IfcStructuralLoadGroup", 573)]
public class IfcStructuralLoadGroup : IfcGroup, IInstantiableEntity, IPersistEntity, IPersist, IIfcStructuralLoadGroup, IIfcGroup, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcStructuralLoadGroup>, IExpressValidatable
{
	public enum IfcStructuralLoadGroupClause
	{
		HasObjectType
	}

	private IfcLoadGroupTypeEnum _predefinedType;

	private IfcActionTypeEnum _actionType;

	private IfcActionSourceTypeEnum _actionSource;

	private IfcRatioMeasure? _coefficient;

	private IfcLabel? _purpose;

	IfcLoadGroupTypeEnum IIfcStructuralLoadGroup.PredefinedType
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

	IfcActionTypeEnum IIfcStructuralLoadGroup.ActionType
	{
		get
		{
			return ActionType;
		}
		set
		{
			ActionType = value;
		}
	}

	IfcActionSourceTypeEnum IIfcStructuralLoadGroup.ActionSource
	{
		get
		{
			return ActionSource;
		}
		set
		{
			ActionSource = value;
		}
	}

	IfcRatioMeasure? IIfcStructuralLoadGroup.Coefficient
	{
		get
		{
			return Coefficient;
		}
		set
		{
			Coefficient = value;
		}
	}

	IfcLabel? IIfcStructuralLoadGroup.Purpose
	{
		get
		{
			return Purpose;
		}
		set
		{
			Purpose = value;
		}
	}

	IEnumerable<IIfcStructuralResultGroup> IIfcStructuralLoadGroup.SourceOfResultGroup => SourceOfResultGroup;

	IEnumerable<IIfcStructuralAnalysisModel> IIfcStructuralLoadGroup.LoadGroupFor => LoadGroupFor;

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 18)]
	public IfcLoadGroupTypeEnum PredefinedType
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
			SetValue(delegate(IfcLoadGroupTypeEnum v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcActionTypeEnum ActionType
	{
		get
		{
			if (_activated)
			{
				return _actionType;
			}
			Activate();
			return _actionType;
		}
		set
		{
			SetValue(delegate(IfcActionTypeEnum v)
			{
				_actionType = v;
			}, _actionType, value, "ActionType", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 20)]
	public IfcActionSourceTypeEnum ActionSource
	{
		get
		{
			if (_activated)
			{
				return _actionSource;
			}
			Activate();
			return _actionSource;
		}
		set
		{
			SetValue(delegate(IfcActionSourceTypeEnum v)
			{
				_actionSource = v;
			}, _actionSource, value, "ActionSource", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 21)]
	public IfcRatioMeasure? Coefficient
	{
		get
		{
			if (_activated)
			{
				return _coefficient;
			}
			Activate();
			return _coefficient;
		}
		set
		{
			SetValue(delegate(IfcRatioMeasure? v)
			{
				_coefficient = v;
			}, _coefficient, value, "Coefficient", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 22)]
	public IfcLabel? Purpose
	{
		get
		{
			if (_activated)
			{
				return _purpose;
			}
			Activate();
			return _purpose;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_purpose = v;
			}, _purpose, value, "Purpose", 10);
		}
	}

	[InverseProperty("ResultForLoadGroup")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 23)]
	public IEnumerable<IfcStructuralResultGroup> SourceOfResultGroup => base.Model.Instances.Where((IfcStructuralResultGroup e) => Equals(e.ResultForLoadGroup), "ResultForLoadGroup", this);

	[InverseProperty("LoadedBy")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 24)]
	public IEnumerable<IfcStructuralAnalysisModel> LoadGroupFor => base.Model.Instances.Where((IfcStructuralAnalysisModel e) => e.LoadedBy != null && e.LoadedBy.Contains(this), "LoadedBy", this);

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.OwnerHistory != null)
			{
				yield return base.OwnerHistory;
			}
		}
	}

	internal IfcStructuralLoadGroup(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 5:
			_predefinedType = (IfcLoadGroupTypeEnum)Enum.Parse(typeof(IfcLoadGroupTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 6:
			_actionType = (IfcActionTypeEnum)Enum.Parse(typeof(IfcActionTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 7:
			_actionSource = (IfcActionSourceTypeEnum)Enum.Parse(typeof(IfcActionSourceTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 8:
			_coefficient = value.RealVal;
			break;
		case 9:
			_purpose = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcStructuralLoadGroup other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcStructuralLoadGroupClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcStructuralLoadGroupClause.HasObjectType)
			{
				result = (PredefinedType != IfcLoadGroupTypeEnum.USERDEFINED && ActionType != IfcActionTypeEnum.USERDEFINED && ActionSource != IfcActionSourceTypeEnum.USERDEFINED) || Functions.EXISTS(base.ObjectType);
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcStructuralLoadGroup>()?.LogError($"Exception thrown evaluating where-clause 'IfcStructuralLoadGroup.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcStructuralLoadGroupClause.HasObjectType))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcStructuralLoadGroup.HasObjectType",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
