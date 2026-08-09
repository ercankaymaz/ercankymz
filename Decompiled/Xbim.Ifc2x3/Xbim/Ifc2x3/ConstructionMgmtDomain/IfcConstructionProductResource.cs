using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc2x3.ConstructionMgmtDomain;

[ExpressType("IfcConstructionProductResource", 660)]
public class IfcConstructionProductResource : IfcConstructionResource, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcConstructionProductResource>, IIfcConstructionProductResource, IIfcConstructionResource, IIfcResource, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcResourceSelect, IIfcResourceSelect, IExpressValidatable
{
	public enum IfcConstructionProductResourceClause
	{
		WR1,
		WR2
	}

	private IfcConstructionProductResourceTypeEnum? _predefinedType;

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.OwnerHistory != null)
			{
				yield return base.OwnerHistory;
			}
			if (base.BaseQuantity != null)
			{
				yield return base.BaseQuantity;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcConstructionProductResource), 11)]
	IfcConstructionProductResourceTypeEnum? IIfcConstructionProductResource.PredefinedType
	{
		get
		{
			return _predefinedType;
		}
		set
		{
			SetValue(delegate(IfcConstructionProductResourceTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", -11);
		}
	}

	internal IfcConstructionProductResource(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if ((uint)propIndex <= 8u)
		{
			base.Parse(propIndex, value, nestedIndex);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcConstructionProductResource other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcConstructionProductResourceClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcConstructionProductResourceClause.WR1:
				result = Functions.SIZEOF(base.ResourceOf) <= 1;
				break;
			case IfcConstructionProductResourceClause.WR2:
				result = !Functions.EXISTS(base.ResourceOf.ItemAt(0L)) || base.ResourceOf.ItemAt(0L).RelatedObjectsType == Xbim.Ifc2x3.Kernel.IfcObjectTypeEnum.PRODUCT;
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcConstructionProductResource>()?.LogError($"Exception thrown evaluating where-clause 'IfcConstructionProductResource.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcConstructionProductResourceClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcConstructionProductResource.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcConstructionProductResourceClause.WR2))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcConstructionProductResource.WR2",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
