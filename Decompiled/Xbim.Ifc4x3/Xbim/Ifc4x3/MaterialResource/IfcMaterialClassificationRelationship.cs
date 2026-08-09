using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4x3.ExternalReferenceResource;

namespace Xbim.Ifc4x3.MaterialResource;

[ExpressType("IfcMaterialClassificationRelationship", 8)]
public class IfcMaterialClassificationRelationship : PersistEntity, IIfcMaterialClassificationRelationship, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcMaterialClassificationRelationship>
{
	private readonly ItemSet<IfcClassificationSelect> _materialClassifications;

	private IfcMaterial _classifiedMaterial;

	[CrossSchemaAttribute(typeof(IIfcMaterialClassificationRelationship), 1)]
	IEnumerable<IIfcClassificationSelect> IIfcMaterialClassificationRelationship.MaterialClassifications => new ProxyItemSet<IfcClassificationSelect, IIfcClassificationSelect>(MaterialClassifications);

	[CrossSchemaAttribute(typeof(IIfcMaterialClassificationRelationship), 2)]
	IIfcMaterial IIfcMaterialClassificationRelationship.ClassifiedMaterial
	{
		get
		{
			return ClassifiedMaterial;
		}
		set
		{
			ClassifiedMaterial = value as IfcMaterial;
		}
	}

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 1)]
	public IItemSet<IfcClassificationSelect> MaterialClassifications
	{
		get
		{
			if (_activated)
			{
				return _materialClassifications;
			}
			Activate();
			return _materialClassifications;
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 2)]
	public IfcMaterial ClassifiedMaterial
	{
		get
		{
			if (_activated)
			{
				return _classifiedMaterial;
			}
			Activate();
			return _classifiedMaterial;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcMaterial v)
			{
				_classifiedMaterial = v;
			}, _classifiedMaterial, value, "ClassifiedMaterial", 2);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcClassificationSelect materialClassification in MaterialClassifications)
			{
				yield return materialClassification;
			}
			if (ClassifiedMaterial != null)
			{
				yield return ClassifiedMaterial;
			}
		}
	}

	internal IfcMaterialClassificationRelationship(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_materialClassifications = new ItemSet<IfcClassificationSelect>(this, 0, 1);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_materialClassifications.InternalAdd((IfcClassificationSelect)value.EntityVal);
			break;
		case 1:
			_classifiedMaterial = (IfcMaterial)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcMaterialClassificationRelationship other)
	{
		return this == other;
	}
}
