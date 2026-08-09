using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.ExternalReferenceResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.MaterialResource;

[ExpressType("IfcMaterialRelationship", 1210)]
public class IfcMaterialRelationship : IfcResourceLevelRelationship, IIfcMaterialRelationship, IIfcResourceLevelRelationship, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcMaterialRelationship>
{
	private IfcMaterial _relatingMaterial;

	private readonly ItemSet<IfcMaterial> _relatedMaterials;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _materialExpression;

	[CrossSchemaAttribute(typeof(IIfcMaterialRelationship), 3)]
	IIfcMaterial IIfcMaterialRelationship.RelatingMaterial
	{
		get
		{
			return RelatingMaterial;
		}
		set
		{
			RelatingMaterial = value as IfcMaterial;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcMaterialRelationship), 4)]
	IItemSet<IIfcMaterial> IIfcMaterialRelationship.RelatedMaterials => new ProxyItemSet<IfcMaterial, IIfcMaterial>(RelatedMaterials);

	[CrossSchemaAttribute(typeof(IIfcMaterialRelationship), 5)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcMaterialRelationship.Expression
	{
		get
		{
			if (!MaterialExpression.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(MaterialExpression.Value);
		}
		set
		{
			MaterialExpression = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	[IndexedProperty]
	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcMaterial RelatingMaterial
	{
		get
		{
			if (_activated)
			{
				return _relatingMaterial;
			}
			Activate();
			return _relatingMaterial;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcMaterial v)
			{
				_relatingMaterial = v;
			}, _relatingMaterial, value, "RelatingMaterial", 3);
		}
	}

	[IndexedProperty]
	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 4)]
	public IItemSet<IfcMaterial> RelatedMaterials
	{
		get
		{
			if (_activated)
			{
				return _relatedMaterials;
			}
			Activate();
			return _relatedMaterials;
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? MaterialExpression
	{
		get
		{
			if (_activated)
			{
				return _materialExpression;
			}
			Activate();
			return _materialExpression;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
			{
				_materialExpression = v;
			}, _materialExpression, value, "MaterialExpression", 5);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (RelatingMaterial != null)
			{
				yield return RelatingMaterial;
			}
			foreach (IfcMaterial relatedMaterial in RelatedMaterials)
			{
				yield return relatedMaterial;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (RelatingMaterial != null)
			{
				yield return RelatingMaterial;
			}
			foreach (IfcMaterial relatedMaterial in RelatedMaterials)
			{
				yield return relatedMaterial;
			}
		}
	}

	internal IfcMaterialRelationship(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_relatedMaterials = new ItemSet<IfcMaterial>(this, 0, 4);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 2:
			_relatingMaterial = (IfcMaterial)value.EntityVal;
			break;
		case 3:
			_relatedMaterials.InternalAdd((IfcMaterial)value.EntityVal);
			break;
		case 4:
			_materialExpression = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcMaterialRelationship other)
	{
		return this == other;
	}
}
