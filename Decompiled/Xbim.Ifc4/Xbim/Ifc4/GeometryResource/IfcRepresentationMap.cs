using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.RepresentationResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.GeometryResource;

[ExpressType("IfcRepresentationMap", 95)]
public class IfcRepresentationMap : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IIfcRepresentationMap, IfcProductRepresentationSelect, IIfcProductRepresentationSelect, IExpressSelectType, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRepresentationMap>, IExpressValidatable
{
	public enum IfcRepresentationMapClause
	{
		ApplicableMappedRepr
	}

	private IfcAxis2Placement _mappingOrigin;

	private IfcRepresentation _mappedRepresentation;

	IIfcAxis2Placement IIfcRepresentationMap.MappingOrigin
	{
		get
		{
			return MappingOrigin;
		}
		set
		{
			MappingOrigin = value as IfcAxis2Placement;
		}
	}

	IIfcRepresentation IIfcRepresentationMap.MappedRepresentation
	{
		get
		{
			return MappedRepresentation;
		}
		set
		{
			MappedRepresentation = value as IfcRepresentation;
		}
	}

	IEnumerable<IIfcShapeAspect> IIfcRepresentationMap.HasShapeAspects => HasShapeAspects;

	IEnumerable<IIfcMappedItem> IIfcRepresentationMap.MapUsage => MapUsage;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 1)]
	public IfcAxis2Placement MappingOrigin
	{
		get
		{
			if (_activated)
			{
				return _mappingOrigin;
			}
			Activate();
			return _mappingOrigin;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcAxis2Placement v)
			{
				_mappingOrigin = v;
			}, _mappingOrigin, value, "MappingOrigin", 1);
		}
	}

	[IndexedProperty]
	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 2)]
	public IfcRepresentation MappedRepresentation
	{
		get
		{
			if (_activated)
			{
				return _mappedRepresentation;
			}
			Activate();
			return _mappedRepresentation;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcRepresentation v)
			{
				_mappedRepresentation = v;
			}, _mappedRepresentation, value, "MappedRepresentation", 2);
		}
	}

	[InverseProperty("PartOfProductDefinitionShape")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 3)]
	public IEnumerable<IfcShapeAspect> HasShapeAspects => base.Model.Instances.Where((IfcShapeAspect e) => Equals(e.PartOfProductDefinitionShape), "PartOfProductDefinitionShape", this);

	[InverseProperty("MappingSource")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 4)]
	public IEnumerable<IfcMappedItem> MapUsage => base.Model.Instances.Where((IfcMappedItem e) => Equals(e.MappingSource), "MappingSource", this);

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (MappingOrigin != null)
			{
				yield return MappingOrigin;
			}
			if (MappedRepresentation != null)
			{
				yield return MappedRepresentation;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (MappedRepresentation != null)
			{
				yield return MappedRepresentation;
			}
		}
	}

	internal IfcRepresentationMap(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_mappingOrigin = (IfcAxis2Placement)value.EntityVal;
			break;
		case 1:
			_mappedRepresentation = (IfcRepresentation)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRepresentationMap other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcRepresentationMapClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcRepresentationMapClause.ApplicableMappedRepr)
			{
				result = Functions.TYPEOF(MappedRepresentation).Contains("IFC4.IFCSHAPEMODEL");
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcRepresentationMap>()?.LogError($"Exception thrown evaluating where-clause 'IfcRepresentationMap.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcRepresentationMapClause.ApplicableMappedRepr))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRepresentationMap.ApplicableMappedRepr",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
