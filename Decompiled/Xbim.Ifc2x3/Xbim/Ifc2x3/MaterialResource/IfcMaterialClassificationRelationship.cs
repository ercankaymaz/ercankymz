using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc2x3.MaterialResource;

[ExpressType("IfcMaterialClassificationRelationship", 8)]
public class IfcMaterialClassificationRelationship : PersistEntity, IIfcMaterialClassificationRelationship, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcMaterialClassificationRelationship>
{
	private readonly ItemSet<IfcClassificationNotationSelect> _materialClassifications;

	private IfcMaterial _classifiedMaterial;

	[CrossSchemaAttribute(typeof(IIfcMaterialClassificationRelationship), 1)]
	IEnumerable<IIfcClassificationSelect> IIfcMaterialClassificationRelationship.MaterialClassifications
	{
		get
		{
			foreach (IfcClassificationNotationSelect materialClassification in MaterialClassifications)
			{
				IfcClassificationNotation notation = materialClassification as IfcClassificationNotation;
				if (notation != null)
				{
					List<IfcClassificationItem> list = base.Model.Instances.Where((IfcClassificationItem i) => notation.NotationFacets.Any((IfcClassificationNotationFacet f) => i.Notation == f)).ToList();
					if (list.Any())
					{
						foreach (IfcClassificationItem item in list)
						{
							yield return item;
						}
					}
					else
					{
						yield return notation;
					}
				}
				else
				{
					IfcClassificationReference ifcClassificationReference = materialClassification as IfcClassificationReference;
					if (ifcClassificationReference != null)
					{
						yield return ifcClassificationReference;
					}
				}
			}
		}
	}

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
	public IItemSet<IfcClassificationNotationSelect> MaterialClassifications
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

	[IndexedProperty]
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
			foreach (IfcClassificationNotationSelect materialClassification in MaterialClassifications)
			{
				yield return materialClassification;
			}
			if (ClassifiedMaterial != null)
			{
				yield return ClassifiedMaterial;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (ClassifiedMaterial != null)
			{
				yield return ClassifiedMaterial;
			}
		}
	}

	internal IfcMaterialClassificationRelationship(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_materialClassifications = new ItemSet<IfcClassificationNotationSelect>(this, 0, 1);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_materialClassifications.InternalAdd((IfcClassificationNotationSelect)value.EntityVal);
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
