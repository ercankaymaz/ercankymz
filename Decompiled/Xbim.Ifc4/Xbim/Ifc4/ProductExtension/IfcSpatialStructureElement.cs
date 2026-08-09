using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.ProductExtension;

[ExpressType("IfcSpatialStructureElement", 170)]
public abstract class IfcSpatialStructureElement : IfcSpatialElement, IIfcSpatialStructureElement, IIfcSpatialElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IEquatable<IfcSpatialStructureElement>, IExpressValidatable
{
	public enum IfcSpatialStructureElementClause
	{
		WR41
	}

	private IfcElementCompositionEnum? _compositionType;

	IfcElementCompositionEnum? IIfcSpatialStructureElement.CompositionType
	{
		get
		{
			return CompositionType;
		}
		set
		{
			CompositionType = value;
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 24)]
	public IfcElementCompositionEnum? CompositionType
	{
		get
		{
			if (_activated)
			{
				return _compositionType;
			}
			Activate();
			return _compositionType;
		}
		set
		{
			SetValue(delegate(IfcElementCompositionEnum? v)
			{
				_compositionType = v;
			}, _compositionType, value, "CompositionType", 9);
		}
	}

	internal IfcSpatialStructureElement(IModel model, int label, bool activated)
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
			_compositionType = (IfcElementCompositionEnum)Enum.Parse(typeof(IfcElementCompositionEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSpatialStructureElement other)
	{
		return this == other;
	}

	public void AddElement(IfcProduct product)
	{
		IfcRelContainedInSpatialStructure ifcRelContainedInSpatialStructure = base.ContainsElements.FirstOrDefault();
		if (ifcRelContainedInSpatialStructure == null)
		{
			IfcRelContainedInSpatialStructure ifcRelContainedInSpatialStructure2 = base.Model.Instances.New<IfcRelContainedInSpatialStructure>();
			ifcRelContainedInSpatialStructure2.RelatingStructure = this;
			ifcRelContainedInSpatialStructure2.RelatedElements.Add(product);
		}
		else
		{
			ifcRelContainedInSpatialStructure.RelatedElements.Add(product);
		}
	}

	public void AddToSpatialDecomposition(IfcSpatialStructureElement child)
	{
		IfcRelAggregates ifcRelAggregates = base.IsDecomposedBy.FirstOrDefault();
		if (ifcRelAggregates == null)
		{
			IfcRelAggregates ifcRelAggregates2 = base.Model.Instances.New<IfcRelAggregates>();
			ifcRelAggregates2.RelatingObject = this;
			ifcRelAggregates2.RelatedObjects.Add(child);
		}
		else
		{
			ifcRelAggregates.RelatedObjects.Add(child);
		}
	}

	public bool ValidateClause(IfcSpatialStructureElementClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcSpatialStructureElementClause.WR41)
			{
				result = Functions.HIINDEX(base.Decomposes) == 1 && Functions.TYPEOF(base.Decomposes.ItemAt(0L)).Contains("IFC4.IFCRELAGGREGATES") && (Functions.TYPEOF(base.Decomposes.ItemAt(0L).RelatingObject).Contains("IFC4.IFCPROJECT") || Functions.TYPEOF(base.Decomposes.ItemAt(0L).RelatingObject).Contains("IFC4.IFCSPATIALSTRUCTUREELEMENT"));
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcSpatialStructureElement>()?.LogError($"Exception thrown evaluating where-clause 'IfcSpatialStructureElement.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcSpatialStructureElementClause.WR41))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcSpatialStructureElement.WR41",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
