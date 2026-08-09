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

[ExpressType("IfcStructuralResultGroup", 532)]
public class IfcStructuralResultGroup : IfcGroup, IInstantiableEntity, IPersistEntity, IPersist, IIfcStructuralResultGroup, IIfcGroup, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcStructuralResultGroup>, IExpressValidatable
{
	public enum IfcStructuralResultGroupClause
	{
		HasObjectType
	}

	private IfcAnalysisTheoryTypeEnum _theoryType;

	private IfcStructuralLoadGroup _resultForLoadGroup;

	private IfcBoolean _isLinear;

	IfcAnalysisTheoryTypeEnum IIfcStructuralResultGroup.TheoryType
	{
		get
		{
			return TheoryType;
		}
		set
		{
			TheoryType = value;
		}
	}

	IIfcStructuralLoadGroup IIfcStructuralResultGroup.ResultForLoadGroup
	{
		get
		{
			return ResultForLoadGroup;
		}
		set
		{
			ResultForLoadGroup = value as IfcStructuralLoadGroup;
		}
	}

	IfcBoolean IIfcStructuralResultGroup.IsLinear
	{
		get
		{
			return IsLinear;
		}
		set
		{
			IsLinear = value;
		}
	}

	IEnumerable<IIfcStructuralAnalysisModel> IIfcStructuralResultGroup.ResultGroupFor => ResultGroupFor;

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 18)]
	public IfcAnalysisTheoryTypeEnum TheoryType
	{
		get
		{
			if (_activated)
			{
				return _theoryType;
			}
			Activate();
			return _theoryType;
		}
		set
		{
			SetValue(delegate(IfcAnalysisTheoryTypeEnum v)
			{
				_theoryType = v;
			}, _theoryType, value, "TheoryType", 6);
		}
	}

	[IndexedProperty]
	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 19)]
	public IfcStructuralLoadGroup ResultForLoadGroup
	{
		get
		{
			if (_activated)
			{
				return _resultForLoadGroup;
			}
			Activate();
			return _resultForLoadGroup;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcStructuralLoadGroup v)
			{
				_resultForLoadGroup = v;
			}, _resultForLoadGroup, value, "ResultForLoadGroup", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 20)]
	public IfcBoolean IsLinear
	{
		get
		{
			if (_activated)
			{
				return _isLinear;
			}
			Activate();
			return _isLinear;
		}
		set
		{
			SetValue(delegate(IfcBoolean v)
			{
				_isLinear = v;
			}, _isLinear, value, "IsLinear", 8);
		}
	}

	[InverseProperty("HasResults")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 21)]
	public IEnumerable<IfcStructuralAnalysisModel> ResultGroupFor => base.Model.Instances.Where((IfcStructuralAnalysisModel e) => e.HasResults != null && e.HasResults.Contains(this), "HasResults", this);

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.OwnerHistory != null)
			{
				yield return base.OwnerHistory;
			}
			if (ResultForLoadGroup != null)
			{
				yield return ResultForLoadGroup;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (ResultForLoadGroup != null)
			{
				yield return ResultForLoadGroup;
			}
		}
	}

	internal IfcStructuralResultGroup(IModel model, int label, bool activated)
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
			_theoryType = (IfcAnalysisTheoryTypeEnum)Enum.Parse(typeof(IfcAnalysisTheoryTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 6:
			_resultForLoadGroup = (IfcStructuralLoadGroup)value.EntityVal;
			break;
		case 7:
			_isLinear = value.BooleanVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcStructuralResultGroup other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcStructuralResultGroupClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcStructuralResultGroupClause.HasObjectType)
			{
				result = TheoryType != IfcAnalysisTheoryTypeEnum.USERDEFINED || Functions.EXISTS(base.ObjectType);
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcStructuralResultGroup>()?.LogError($"Exception thrown evaluating where-clause 'IfcStructuralResultGroup.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcStructuralResultGroupClause.HasObjectType))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcStructuralResultGroup.HasObjectType",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
