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
using Xbim.Ifc4.ProductExtension;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.SharedBldgElements;

[ExpressType("IfcWindow", 667)]
public class IfcWindow : IfcBuildingElement, IInstantiableEntity, IPersistEntity, IPersist, IIfcWindow, IIfcBuildingElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcWindow>, IExpressValidatable
{
	public enum IfcWindowClause
	{
		CorrectStyleAssigned
	}

	private IfcPositiveLengthMeasure? _overallHeight;

	private IfcPositiveLengthMeasure? _overallWidth;

	private IfcWindowTypeEnum? _predefinedType;

	private IfcWindowTypePartitioningEnum? _partitioningType;

	private IfcLabel? _userDefinedPartitioningType;

	IfcPositiveLengthMeasure? IIfcWindow.OverallHeight
	{
		get
		{
			return OverallHeight;
		}
		set
		{
			OverallHeight = value;
		}
	}

	IfcPositiveLengthMeasure? IIfcWindow.OverallWidth
	{
		get
		{
			return OverallWidth;
		}
		set
		{
			OverallWidth = value;
		}
	}

	IfcWindowTypeEnum? IIfcWindow.PredefinedType
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

	IfcWindowTypePartitioningEnum? IIfcWindow.PartitioningType
	{
		get
		{
			return PartitioningType;
		}
		set
		{
			PartitioningType = value;
		}
	}

	IfcLabel? IIfcWindow.UserDefinedPartitioningType
	{
		get
		{
			return UserDefinedPartitioningType;
		}
		set
		{
			UserDefinedPartitioningType = value;
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 33)]
	public IfcPositiveLengthMeasure? OverallHeight
	{
		get
		{
			if (_activated)
			{
				return _overallHeight;
			}
			Activate();
			return _overallHeight;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure? v)
			{
				_overallHeight = v;
			}, _overallHeight, value, "OverallHeight", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 34)]
	public IfcPositiveLengthMeasure? OverallWidth
	{
		get
		{
			if (_activated)
			{
				return _overallWidth;
			}
			Activate();
			return _overallWidth;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure? v)
			{
				_overallWidth = v;
			}, _overallWidth, value, "OverallWidth", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 35)]
	public IfcWindowTypeEnum? PredefinedType
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
			SetValue(delegate(IfcWindowTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 11);
		}
	}

	[EntityAttribute(12, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 36)]
	public IfcWindowTypePartitioningEnum? PartitioningType
	{
		get
		{
			if (_activated)
			{
				return _partitioningType;
			}
			Activate();
			return _partitioningType;
		}
		set
		{
			SetValue(delegate(IfcWindowTypePartitioningEnum? v)
			{
				_partitioningType = v;
			}, _partitioningType, value, "PartitioningType", 12);
		}
	}

	[EntityAttribute(13, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 37)]
	public IfcLabel? UserDefinedPartitioningType
	{
		get
		{
			if (_activated)
			{
				return _userDefinedPartitioningType;
			}
			Activate();
			return _userDefinedPartitioningType;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_userDefinedPartitioningType = v;
			}, _userDefinedPartitioningType, value, "UserDefinedPartitioningType", 13);
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

	internal IfcWindow(IModel model, int label, bool activated)
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
			_overallHeight = value.RealVal;
			break;
		case 9:
			_overallWidth = value.RealVal;
			break;
		case 10:
			_predefinedType = (IfcWindowTypeEnum)Enum.Parse(typeof(IfcWindowTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 11:
			_partitioningType = (IfcWindowTypePartitioningEnum)Enum.Parse(typeof(IfcWindowTypePartitioningEnum), value.EnumVal, ignoreCase: true);
			break;
		case 12:
			_userDefinedPartitioningType = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcWindow other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcWindowClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcWindowClause.CorrectStyleAssigned)
			{
				result = Functions.SIZEOF(base.IsTypedBy) == 0 || Functions.TYPEOF(base.IsTypedBy.ItemAt(0L).RelatingType).Contains("IFC4.IFCWINDOWTYPE");
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcWindow>()?.LogError($"Exception thrown evaluating where-clause 'IfcWindow.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcWindowClause.CorrectStyleAssigned))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcWindow.CorrectStyleAssigned",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
