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

[ExpressType("IfcStructuralSurfaceMember", 420)]
public class IfcStructuralSurfaceMember : IfcStructuralMember, IInstantiableEntity, IPersistEntity, IPersist, IIfcStructuralSurfaceMember, IIfcStructuralMember, IIfcStructuralItem, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcStructuralSurfaceMember>, IExpressValidatable
{
	public enum IfcStructuralSurfaceMemberClause
	{
		HasObjectType
	}

	private IfcStructuralSurfaceMemberTypeEnum _predefinedType;

	private IfcPositiveLengthMeasure? _thickness;

	IfcStructuralSurfaceMemberTypeEnum IIfcStructuralSurfaceMember.PredefinedType
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

	IfcPositiveLengthMeasure? IIfcStructuralSurfaceMember.Thickness
	{
		get
		{
			return Thickness;
		}
		set
		{
			Thickness = value;
		}
	}

	[EntityAttribute(8, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 22)]
	public IfcStructuralSurfaceMemberTypeEnum PredefinedType
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
			SetValue(delegate(IfcStructuralSurfaceMemberTypeEnum v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 23)]
	public IfcPositiveLengthMeasure? Thickness
	{
		get
		{
			if (_activated)
			{
				return _thickness;
			}
			Activate();
			return _thickness;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure? v)
			{
				_thickness = v;
			}, _thickness, value, "Thickness", 9);
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

	internal IfcStructuralSurfaceMember(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 7:
			_predefinedType = (IfcStructuralSurfaceMemberTypeEnum)Enum.Parse(typeof(IfcStructuralSurfaceMemberTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 8:
			_thickness = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcStructuralSurfaceMember other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcStructuralSurfaceMemberClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcStructuralSurfaceMemberClause.HasObjectType)
			{
				result = PredefinedType != IfcStructuralSurfaceMemberTypeEnum.USERDEFINED || Functions.EXISTS(base.ObjectType);
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcStructuralSurfaceMember>()?.LogError($"Exception thrown evaluating where-clause 'IfcStructuralSurfaceMember.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcStructuralSurfaceMemberClause.HasObjectType))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcStructuralSurfaceMember.HasObjectType",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
