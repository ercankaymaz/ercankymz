using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.ActorResource;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc2x3.ConstructionMgmtDomain;

[ExpressType("IfcConstructionMaterialResource", 243)]
public class IfcConstructionMaterialResource : IfcConstructionResource, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcConstructionMaterialResource>, IIfcConstructionMaterialResource, IIfcConstructionResource, IIfcResource, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcResourceSelect, IIfcResourceSelect, IExpressValidatable
{
	public enum IfcConstructionMaterialResourceClause
	{
		WR1,
		WR2
	}

	private readonly OptionalItemSet<IfcActorSelect> _suppliers;

	private IfcRatioMeasure? _usageRatio;

	private IfcConstructionMaterialResourceTypeEnum? _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 16)]
	public IOptionalItemSet<IfcActorSelect> Suppliers
	{
		get
		{
			if (_activated)
			{
				return _suppliers;
			}
			Activate();
			return _suppliers;
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 17)]
	public IfcRatioMeasure? UsageRatio
	{
		get
		{
			if (_activated)
			{
				return _usageRatio;
			}
			Activate();
			return _usageRatio;
		}
		set
		{
			SetValue(delegate(IfcRatioMeasure? v)
			{
				_usageRatio = v;
			}, _usageRatio, value, "UsageRatio", 11);
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
			if (base.BaseQuantity != null)
			{
				yield return base.BaseQuantity;
			}
			foreach (IfcActorSelect supplier in Suppliers)
			{
				yield return supplier;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcConstructionMaterialResource), 11)]
	IfcConstructionMaterialResourceTypeEnum? IIfcConstructionMaterialResource.PredefinedType
	{
		get
		{
			return _predefinedType;
		}
		set
		{
			SetValue(delegate(IfcConstructionMaterialResourceTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", -11);
		}
	}

	internal IfcConstructionMaterialResource(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_suppliers = new OptionalItemSet<IfcActorSelect>(this, 0, 10);
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
			_suppliers.InternalAdd((IfcActorSelect)value.EntityVal);
			break;
		case 10:
			_usageRatio = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcConstructionMaterialResource other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcConstructionMaterialResourceClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcConstructionMaterialResourceClause.WR1:
				result = Functions.SIZEOF(base.ResourceOf) <= 1;
				break;
			case IfcConstructionMaterialResourceClause.WR2:
				result = !Functions.EXISTS(base.ResourceOf.ItemAt(0L)) || base.ResourceOf.ItemAt(0L).RelatedObjectsType == Xbim.Ifc2x3.Kernel.IfcObjectTypeEnum.PRODUCT;
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcConstructionMaterialResource>()?.LogError($"Exception thrown evaluating where-clause 'IfcConstructionMaterialResource.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcConstructionMaterialResourceClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcConstructionMaterialResource.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcConstructionMaterialResourceClause.WR2))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcConstructionMaterialResource.WR2",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
