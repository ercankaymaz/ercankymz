using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;

namespace Xbim.Ifc2x3.ProductExtension;

[ExpressType("IfcCovering", 382)]
public class IfcCovering : IfcBuildingElement, IIfcCovering, IIfcBuildingElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcCovering>, IExpressValidatable
{
	public enum IfcCoveringClause
	{
		WR61
	}

	private IfcCoveringTypeEnum? _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcCovering), 9)]
	Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum? IIfcCovering.PredefinedType
	{
		get
		{
			switch (PredefinedType)
			{
			case IfcCoveringTypeEnum.CEILING:
				return Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.CEILING;
			case IfcCoveringTypeEnum.FLOORING:
				return Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.FLOORING;
			case IfcCoveringTypeEnum.CLADDING:
				return Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.CLADDING;
			case IfcCoveringTypeEnum.ROOFING:
				return Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.ROOFING;
			case IfcCoveringTypeEnum.INSULATION:
				return Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.INSULATION;
			case IfcCoveringTypeEnum.MEMBRANE:
				return Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.MEMBRANE;
			case IfcCoveringTypeEnum.SLEEVING:
				return Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.SLEEVING;
			case IfcCoveringTypeEnum.WRAPPING:
				return Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.WRAPPING;
			case IfcCoveringTypeEnum.USERDEFINED:
			{
				if (base.ObjectType.HasValue && Enum.TryParse<Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum>(base.ObjectType.Value, ignoreCase: false, out var result))
				{
					return result;
				}
				return Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.USERDEFINED;
			}
			case IfcCoveringTypeEnum.NOTDEFINED:
				return Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.NOTDEFINED;
			case null:
				return null;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.CEILING:
				PredefinedType = IfcCoveringTypeEnum.CEILING;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.FLOORING:
				PredefinedType = IfcCoveringTypeEnum.FLOORING;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.CLADDING:
				PredefinedType = IfcCoveringTypeEnum.CLADDING;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.ROOFING:
				PredefinedType = IfcCoveringTypeEnum.ROOFING;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.MOLDING:
				base.ObjectType = value.ToString();
				PredefinedType = IfcCoveringTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.SKIRTINGBOARD:
				base.ObjectType = value.ToString();
				PredefinedType = IfcCoveringTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.INSULATION:
				PredefinedType = IfcCoveringTypeEnum.INSULATION;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.MEMBRANE:
				PredefinedType = IfcCoveringTypeEnum.MEMBRANE;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.SLEEVING:
				PredefinedType = IfcCoveringTypeEnum.SLEEVING;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.WRAPPING:
				PredefinedType = IfcCoveringTypeEnum.WRAPPING;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.USERDEFINED:
				PredefinedType = IfcCoveringTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.NOTDEFINED:
				PredefinedType = IfcCoveringTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	IEnumerable<IIfcRelCoversSpaces> IIfcCovering.CoversSpaces => base.Model.Instances.Where((IIfcRelCoversSpaces e) => e.RelatedCoverings != null && e.RelatedCoverings.Contains(this), "RelatedCoverings", this);

	IEnumerable<IIfcRelCoversBldgElements> IIfcCovering.CoversElements => base.Model.Instances.Where((IIfcRelCoversBldgElements e) => e.RelatedCoverings != null && e.RelatedCoverings.Contains(this), "RelatedCoverings", this);

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 27)]
	public IfcCoveringTypeEnum? PredefinedType
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
			SetValue(delegate(IfcCoveringTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 9);
		}
	}

	[InverseProperty("RelatedCoverings")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 28)]
	public IEnumerable<IfcRelCoversSpaces> CoversSpaces => base.Model.Instances.Where((IfcRelCoversSpaces e) => e.RelatedCoverings != null && e.RelatedCoverings.Contains(this), "RelatedCoverings", this);

	[InverseProperty("RelatedCoverings")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 29)]
	public IEnumerable<IfcRelCoversBldgElements> Covers => base.Model.Instances.Where((IfcRelCoversBldgElements e) => e.RelatedCoverings != null && e.RelatedCoverings.Contains(this), "RelatedCoverings", this);

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

	internal IfcCovering(IModel model, int label, bool activated)
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
			_predefinedType = (IfcCoveringTypeEnum)Enum.Parse(typeof(IfcCoveringTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcCovering other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcCoveringClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcCoveringClause.WR61)
			{
				result = !Functions.EXISTS(PredefinedType) || PredefinedType != IfcCoveringTypeEnum.USERDEFINED || (PredefinedType == IfcCoveringTypeEnum.USERDEFINED && Functions.EXISTS(base.ObjectType));
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcCovering>()?.LogError($"Exception thrown evaluating where-clause 'IfcCovering.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcCoveringClause.WR61))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcCovering.WR61",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
