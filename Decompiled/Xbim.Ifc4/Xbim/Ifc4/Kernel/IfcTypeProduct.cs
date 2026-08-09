using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.Kernel;

[ExpressType("IfcTypeProduct", 43)]
public class IfcTypeProduct : IfcTypeObject, IInstantiableEntity, IPersistEntity, IPersist, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcTypeProduct>, IExpressValidatable
{
	public enum IfcTypeProductClause
	{
		ApplicableOccurrence
	}

	private readonly OptionalItemSet<IfcRepresentationMap> _representationMaps;

	private IfcLabel? _tag;

	IItemSet<IIfcRepresentationMap> IIfcTypeProduct.RepresentationMaps => new ProxyItemSet<IfcRepresentationMap, IIfcRepresentationMap>(RepresentationMaps);

	IfcLabel? IIfcTypeProduct.Tag
	{
		get
		{
			return Tag;
		}
		set
		{
			Tag = value;
		}
	}

	IEnumerable<IIfcRelAssignsToProduct> IIfcTypeProduct.ReferencedBy => ReferencedBy;

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.ListUnique, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 15)]
	public IOptionalItemSet<IfcRepresentationMap> RepresentationMaps
	{
		get
		{
			if (_activated)
			{
				return _representationMaps;
			}
			Activate();
			return _representationMaps;
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 16)]
	public IfcLabel? Tag
	{
		get
		{
			if (_activated)
			{
				return _tag;
			}
			Activate();
			return _tag;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_tag = v;
			}, _tag, value, "Tag", 8);
		}
	}

	[InverseProperty("RelatingProduct")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 17)]
	public IEnumerable<IfcRelAssignsToProduct> ReferencedBy => base.Model.Instances.Where((IfcRelAssignsToProduct e) => Equals(e.RelatingProduct), "RelatingProduct", this);

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.OwnerHistory != null)
			{
				yield return base.OwnerHistory;
			}
			foreach (IfcPropertySetDefinition hasPropertySet in base.HasPropertySets)
			{
				yield return hasPropertySet;
			}
			foreach (IfcRepresentationMap representationMap in RepresentationMaps)
			{
				yield return representationMap;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcPropertySetDefinition hasPropertySet in base.HasPropertySets)
			{
				yield return hasPropertySet;
			}
		}
	}

	internal IfcTypeProduct(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_representationMaps = new OptionalItemSet<IfcRepresentationMap>(this, 0, 7);
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 6:
			_representationMaps.InternalAdd((IfcRepresentationMap)value.EntityVal);
			break;
		case 7:
			_tag = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcTypeProduct other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcTypeProductClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcTypeProductClause.ApplicableOccurrence)
			{
				result = !Functions.EXISTS(base.Types.ItemAt(0L)) || Functions.SIZEOF(Enumerable.Where(base.Types.ItemAt(0L).RelatedObjects, (IfcObject temp) => !Functions.TYPEOF(temp).Contains("IFC4.IFCPRODUCT"))) == 0;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcTypeProduct>()?.LogError($"Exception thrown evaluating where-clause 'IfcTypeProduct.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcTypeProductClause.ApplicableOccurrence))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcTypeProduct.ApplicableOccurrence",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
