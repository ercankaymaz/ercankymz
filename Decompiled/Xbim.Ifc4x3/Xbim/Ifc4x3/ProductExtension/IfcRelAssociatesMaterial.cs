using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4x3.Kernel;
using Xbim.Ifc4x3.MaterialResource;

namespace Xbim.Ifc4x3.ProductExtension;

[ExpressType("IfcRelAssociatesMaterial", 497)]
public class IfcRelAssociatesMaterial : IfcRelAssociates, IIfcRelAssociatesMaterial, IIfcRelAssociates, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelAssociatesMaterial>
{
	private IfcMaterialSelect _relatingMaterial;

	[CrossSchemaAttribute(typeof(IIfcRelAssociatesMaterial), 6)]
	IIfcMaterialSelect IIfcRelAssociatesMaterial.RelatingMaterial
	{
		get
		{
			if (RelatingMaterial == null)
			{
				return null;
			}
			IfcMaterialDefinition ifcMaterialDefinition = RelatingMaterial as IfcMaterialDefinition;
			if (ifcMaterialDefinition != null)
			{
				return ifcMaterialDefinition;
			}
			IfcMaterialList ifcMaterialList = RelatingMaterial as IfcMaterialList;
			if (ifcMaterialList != null)
			{
				return ifcMaterialList;
			}
			IfcMaterialUsageDefinition ifcMaterialUsageDefinition = RelatingMaterial as IfcMaterialUsageDefinition;
			if (ifcMaterialUsageDefinition != null)
			{
				return ifcMaterialUsageDefinition;
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				RelatingMaterial = null;
				return;
			}
			IfcMaterialDefinition ifcMaterialDefinition = value as IfcMaterialDefinition;
			if (ifcMaterialDefinition != null)
			{
				RelatingMaterial = ifcMaterialDefinition;
				return;
			}
			IfcMaterialList ifcMaterialList = value as IfcMaterialList;
			if (ifcMaterialList != null)
			{
				RelatingMaterial = ifcMaterialList;
				return;
			}
			IfcMaterialUsageDefinition ifcMaterialUsageDefinition = value as IfcMaterialUsageDefinition;
			if (ifcMaterialUsageDefinition != null)
			{
				RelatingMaterial = ifcMaterialUsageDefinition;
			}
		}
	}

	[IndexedProperty]
	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
	public IfcMaterialSelect RelatingMaterial
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
			SetValue(delegate(IfcMaterialSelect v)
			{
				_relatingMaterial = v;
			}, _relatingMaterial, value, "RelatingMaterial", 6);
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
			foreach (IfcDefinitionSelect relatedObject in base.RelatedObjects)
			{
				yield return relatedObject;
			}
			if (RelatingMaterial != null)
			{
				yield return RelatingMaterial;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcDefinitionSelect relatedObject in base.RelatedObjects)
			{
				yield return relatedObject;
			}
			if (RelatingMaterial != null)
			{
				yield return RelatingMaterial;
			}
		}
	}

	internal IfcRelAssociatesMaterial(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 5:
			_relatingMaterial = (IfcMaterialSelect)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelAssociatesMaterial other)
	{
		return this == other;
	}
}
