using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.ProductExtension;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;

namespace Xbim.Ifc2x3.SharedBldgElements;

[ExpressType("IfcSlab", 99)]
public class IfcSlab : IfcBuildingElement, IIfcSlab, IIfcBuildingElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcSlab>, IExpressValidatable
{
	public enum IfcSlabClause
	{
		WR61
	}

	private IfcSlabTypeEnum? _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcSlab), 9)]
	Xbim.Ifc4.Interfaces.IfcSlabTypeEnum? IIfcSlab.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcSlabTypeEnum.FLOOR => Xbim.Ifc4.Interfaces.IfcSlabTypeEnum.FLOOR, 
				IfcSlabTypeEnum.ROOF => Xbim.Ifc4.Interfaces.IfcSlabTypeEnum.ROOF, 
				IfcSlabTypeEnum.LANDING => Xbim.Ifc4.Interfaces.IfcSlabTypeEnum.LANDING, 
				IfcSlabTypeEnum.BASESLAB => Xbim.Ifc4.Interfaces.IfcSlabTypeEnum.BASESLAB, 
				IfcSlabTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcSlabTypeEnum.USERDEFINED, 
				IfcSlabTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcSlabTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcSlabTypeEnum.FLOOR:
				PredefinedType = IfcSlabTypeEnum.FLOOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcSlabTypeEnum.ROOF:
				PredefinedType = IfcSlabTypeEnum.ROOF;
				break;
			case Xbim.Ifc4.Interfaces.IfcSlabTypeEnum.LANDING:
				PredefinedType = IfcSlabTypeEnum.LANDING;
				break;
			case Xbim.Ifc4.Interfaces.IfcSlabTypeEnum.BASESLAB:
				PredefinedType = IfcSlabTypeEnum.BASESLAB;
				break;
			case Xbim.Ifc4.Interfaces.IfcSlabTypeEnum.USERDEFINED:
				PredefinedType = IfcSlabTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcSlabTypeEnum.NOTDEFINED:
				PredefinedType = IfcSlabTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 27)]
	public IfcSlabTypeEnum? PredefinedType
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
			SetValue(delegate(IfcSlabTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 9);
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

	internal IfcSlab(IModel model, int label, bool activated)
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
			_predefinedType = (IfcSlabTypeEnum)Enum.Parse(typeof(IfcSlabTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSlab other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcSlabClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcSlabClause.WR61)
			{
				result = !Functions.EXISTS(PredefinedType) || PredefinedType != IfcSlabTypeEnum.USERDEFINED || (PredefinedType == IfcSlabTypeEnum.USERDEFINED && Functions.EXISTS(base.ObjectType));
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcSlab>()?.LogError($"Exception thrown evaluating where-clause 'IfcSlab.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcSlabClause.WR61))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcSlab.WR61",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
