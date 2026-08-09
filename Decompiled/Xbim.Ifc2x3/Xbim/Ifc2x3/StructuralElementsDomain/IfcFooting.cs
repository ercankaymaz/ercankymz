using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.ProductExtension;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;

namespace Xbim.Ifc2x3.StructuralElementsDomain;

[ExpressType("IfcFooting", 120)]
public class IfcFooting : IfcBuildingElement, IIfcFooting, IIfcBuildingElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcFooting>, IExpressValidatable
{
	public enum IfcFootingClause
	{
		WR1
	}

	private IfcFootingTypeEnum _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcFooting), 9)]
	Xbim.Ifc4.Interfaces.IfcFootingTypeEnum? IIfcFooting.PredefinedType
	{
		get
		{
			switch (PredefinedType)
			{
			case IfcFootingTypeEnum.FOOTING_BEAM:
				return Xbim.Ifc4.Interfaces.IfcFootingTypeEnum.FOOTING_BEAM;
			case IfcFootingTypeEnum.PAD_FOOTING:
				return Xbim.Ifc4.Interfaces.IfcFootingTypeEnum.PAD_FOOTING;
			case IfcFootingTypeEnum.PILE_CAP:
				return Xbim.Ifc4.Interfaces.IfcFootingTypeEnum.PILE_CAP;
			case IfcFootingTypeEnum.STRIP_FOOTING:
				return Xbim.Ifc4.Interfaces.IfcFootingTypeEnum.STRIP_FOOTING;
			case IfcFootingTypeEnum.USERDEFINED:
				if (base.ObjectType == (IfcLabel?)(IfcLabel)"CAISSON_FOUNDATION")
				{
					return Xbim.Ifc4.Interfaces.IfcFootingTypeEnum.CAISSON_FOUNDATION;
				}
				return Xbim.Ifc4.Interfaces.IfcFootingTypeEnum.USERDEFINED;
			case IfcFootingTypeEnum.NOTDEFINED:
				return Xbim.Ifc4.Interfaces.IfcFootingTypeEnum.NOTDEFINED;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcFootingTypeEnum.CAISSON_FOUNDATION:
				base.ObjectType = value.ToString();
				PredefinedType = IfcFootingTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcFootingTypeEnum.FOOTING_BEAM:
				PredefinedType = IfcFootingTypeEnum.FOOTING_BEAM;
				break;
			case Xbim.Ifc4.Interfaces.IfcFootingTypeEnum.PAD_FOOTING:
				PredefinedType = IfcFootingTypeEnum.PAD_FOOTING;
				break;
			case Xbim.Ifc4.Interfaces.IfcFootingTypeEnum.PILE_CAP:
				PredefinedType = IfcFootingTypeEnum.PILE_CAP;
				break;
			case Xbim.Ifc4.Interfaces.IfcFootingTypeEnum.STRIP_FOOTING:
				PredefinedType = IfcFootingTypeEnum.STRIP_FOOTING;
				break;
			case Xbim.Ifc4.Interfaces.IfcFootingTypeEnum.USERDEFINED:
				PredefinedType = IfcFootingTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcFootingTypeEnum.NOTDEFINED:
				PredefinedType = IfcFootingTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = IfcFootingTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(9, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 27)]
	public IfcFootingTypeEnum PredefinedType
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
			SetValue(delegate(IfcFootingTypeEnum v)
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

	internal IfcFooting(IModel model, int label, bool activated)
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
			_predefinedType = (IfcFootingTypeEnum)Enum.Parse(typeof(IfcFootingTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcFooting other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcFootingClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcFootingClause.WR1)
			{
				result = PredefinedType != IfcFootingTypeEnum.USERDEFINED || (PredefinedType == IfcFootingTypeEnum.USERDEFINED && Functions.EXISTS(base.ObjectType));
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcFooting>()?.LogError($"Exception thrown evaluating where-clause 'IfcFooting.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcFootingClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcFooting.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
