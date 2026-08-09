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

[ExpressType("IfcVoidingFeature", 1313)]
public class IfcVoidingFeature : IfcFeatureElementSubtraction, IInstantiableEntity, IPersistEntity, IPersist, IIfcVoidingFeature, IIfcFeatureElementSubtraction, IIfcFeatureElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcVoidingFeature>, IExpressValidatable
{
	public enum IfcVoidingFeatureClause
	{
		HasObjectType
	}

	private IfcVoidingFeatureTypeEnum? _predefinedType;

	IfcVoidingFeatureTypeEnum? IIfcVoidingFeature.PredefinedType
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

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 34)]
	public IfcVoidingFeatureTypeEnum? PredefinedType
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
			SetValue(delegate(IfcVoidingFeatureTypeEnum? v)
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

	internal IfcVoidingFeature(IModel model, int label, bool activated)
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
			_predefinedType = (IfcVoidingFeatureTypeEnum)Enum.Parse(typeof(IfcVoidingFeatureTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcVoidingFeature other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcVoidingFeatureClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcVoidingFeatureClause.HasObjectType)
			{
				result = !Functions.EXISTS(PredefinedType) || PredefinedType != IfcVoidingFeatureTypeEnum.USERDEFINED || Functions.EXISTS(base.ObjectType);
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcVoidingFeature>()?.LogError($"Exception thrown evaluating where-clause 'IfcVoidingFeature.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcVoidingFeatureClause.HasObjectType))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcVoidingFeature.HasObjectType",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
