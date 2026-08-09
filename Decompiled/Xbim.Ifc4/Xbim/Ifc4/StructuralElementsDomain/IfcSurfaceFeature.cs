using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.ProductExtension;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.StructuralElementsDomain;

[ExpressType("IfcSurfaceFeature", 1287)]
public class IfcSurfaceFeature : IfcFeatureElement, IInstantiableEntity, IPersistEntity, IPersist, IIfcSurfaceFeature, IIfcFeatureElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcSurfaceFeature>, IExpressValidatable
{
	public enum IfcSurfaceFeatureClause
	{
		HasObjectType
	}

	private IfcSurfaceFeatureTypeEnum? _predefinedType;

	IfcSurfaceFeatureTypeEnum? IIfcSurfaceFeature.PredefinedType
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
	public IfcSurfaceFeatureTypeEnum? PredefinedType
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
			SetValue(delegate(IfcSurfaceFeatureTypeEnum? v)
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

	internal IfcSurfaceFeature(IModel model, int label, bool activated)
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
			_predefinedType = (IfcSurfaceFeatureTypeEnum)Enum.Parse(typeof(IfcSurfaceFeatureTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSurfaceFeature other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcSurfaceFeatureClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcSurfaceFeatureClause.HasObjectType)
			{
				result = !Functions.EXISTS(PredefinedType) || PredefinedType != IfcSurfaceFeatureTypeEnum.USERDEFINED || Functions.EXISTS(base.ObjectType);
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcSurfaceFeature>()?.LogError($"Exception thrown evaluating where-clause 'IfcSurfaceFeature.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcSurfaceFeatureClause.HasObjectType))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcSurfaceFeature.HasObjectType",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
