using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4x3.PropertyResource;

namespace Xbim.Ifc4x3.MaterialResource;

[ExpressType("IfcMaterialProperties", 437)]
public class IfcMaterialProperties : IfcExtendedProperties, IIfcMaterialProperties, IIfcExtendedProperties, IIfcPropertyAbstraction, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcMaterialProperties>
{
	private IfcMaterialDefinition _material;

	[CrossSchemaAttribute(typeof(IIfcMaterialProperties), 4)]
	IIfcMaterialDefinition IIfcMaterialProperties.Material
	{
		get
		{
			return Material;
		}
		set
		{
			Material = value as IfcMaterialDefinition;
		}
	}

	[IndexedProperty]
	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcMaterialDefinition Material
	{
		get
		{
			if (_activated)
			{
				return _material;
			}
			Activate();
			return _material;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcMaterialDefinition v)
			{
				_material = v;
			}, _material, value, "Material", 4);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcProperty property in base.Properties)
			{
				yield return property;
			}
			if (Material != null)
			{
				yield return Material;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (Material != null)
			{
				yield return Material;
			}
		}
	}

	internal IfcMaterialProperties(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 3:
			_material = (IfcMaterialDefinition)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcMaterialProperties other)
	{
		return this == other;
	}
}
