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

namespace Xbim.Ifc4.ProcessExtension;

[ExpressType("IfcTaskType", 1296)]
public class IfcTaskType : IfcTypeProcess, IInstantiableEntity, IPersistEntity, IPersist, IIfcTaskType, IIfcTypeProcess, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProcessSelect, IIfcProcessSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcTaskType>, IExpressValidatable
{
	public enum IfcTaskTypeClause
	{
		CorrectPredefinedType
	}

	private IfcTaskTypeEnum _predefinedType;

	private IfcLabel? _workMethod;

	IfcTaskTypeEnum IIfcTaskType.PredefinedType
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

	IfcLabel? IIfcTaskType.WorkMethod
	{
		get
		{
			return WorkMethod;
		}
		set
		{
			WorkMethod = value;
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcTaskTypeEnum PredefinedType
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
			SetValue(delegate(IfcTaskTypeEnum v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 20)]
	public IfcLabel? WorkMethod
	{
		get
		{
			if (_activated)
			{
				return _workMethod;
			}
			Activate();
			return _workMethod;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_workMethod = v;
			}, _workMethod, value, "WorkMethod", 11);
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

	internal IfcTaskType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcTaskTypeEnum)Enum.Parse(typeof(IfcTaskTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 10:
			_workMethod = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcTaskType other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcTaskTypeClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcTaskTypeClause.CorrectPredefinedType)
			{
				result = PredefinedType != IfcTaskTypeEnum.USERDEFINED || (PredefinedType == IfcTaskTypeEnum.USERDEFINED && Functions.EXISTS(base.ProcessType));
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcTaskType>()?.LogError($"Exception thrown evaluating where-clause 'IfcTaskType.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcTaskTypeClause.CorrectPredefinedType))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcTaskType.CorrectPredefinedType",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
