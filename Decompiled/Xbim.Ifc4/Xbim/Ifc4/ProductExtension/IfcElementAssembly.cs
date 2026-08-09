using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.ProductExtension;

[ExpressType("IfcElementAssembly", 18)]
public class IfcElementAssembly : IfcElement, IInstantiableEntity, IPersistEntity, IPersist, IIfcElementAssembly, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcElementAssembly>, IExpressValidatable
{
	public enum IfcElementAssemblyClause
	{
		CorrectPredefinedType,
		CorrectTypeAssigned
	}

	private IfcAssemblyPlaceEnum? _assemblyPlace;

	private IfcElementAssemblyTypeEnum? _predefinedType;

	IfcAssemblyPlaceEnum? IIfcElementAssembly.AssemblyPlace
	{
		get
		{
			return AssemblyPlace;
		}
		set
		{
			AssemblyPlace = value;
		}
	}

	IfcElementAssemblyTypeEnum? IIfcElementAssembly.PredefinedType
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

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 33)]
	public IfcAssemblyPlaceEnum? AssemblyPlace
	{
		get
		{
			if (_activated)
			{
				return _assemblyPlace;
			}
			Activate();
			return _assemblyPlace;
		}
		set
		{
			SetValue(delegate(IfcAssemblyPlaceEnum? v)
			{
				_assemblyPlace = v;
			}, _assemblyPlace, value, "AssemblyPlace", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 34)]
	public IfcElementAssemblyTypeEnum? PredefinedType
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
			SetValue(delegate(IfcElementAssemblyTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 10);
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

	internal IfcElementAssembly(IModel model, int label, bool activated)
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
			_assemblyPlace = (IfcAssemblyPlaceEnum)Enum.Parse(typeof(IfcAssemblyPlaceEnum), value.EnumVal, ignoreCase: true);
			break;
		case 9:
			_predefinedType = (IfcElementAssemblyTypeEnum)Enum.Parse(typeof(IfcElementAssemblyTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcElementAssembly other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcElementAssemblyClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcElementAssemblyClause.CorrectPredefinedType:
				result = !Functions.EXISTS(PredefinedType) || PredefinedType != IfcElementAssemblyTypeEnum.USERDEFINED || (PredefinedType == IfcElementAssemblyTypeEnum.USERDEFINED && Functions.EXISTS(base.ObjectType));
				break;
			case IfcElementAssemblyClause.CorrectTypeAssigned:
				result = Functions.SIZEOF(base.IsTypedBy) == 0 || Functions.TYPEOF(base.IsTypedBy.ItemAt(0L).RelatingType).Contains("IFC4.IFCELEMENTASSEMBLYTYPE");
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcElementAssembly>()?.LogError($"Exception thrown evaluating where-clause 'IfcElementAssembly.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcElementAssemblyClause.CorrectPredefinedType))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcElementAssembly.CorrectPredefinedType",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcElementAssemblyClause.CorrectTypeAssigned))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcElementAssembly.CorrectTypeAssigned",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
