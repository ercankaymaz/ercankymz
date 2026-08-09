using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4x3.MaterialResource;

namespace Xbim.Ifc4x3.RepresentationResource;

[ExpressType("IfcMaterialDefinitionRepresentation", 2)]
public class IfcMaterialDefinitionRepresentation : IfcProductRepresentation, IIfcMaterialDefinitionRepresentation, IIfcProductRepresentation, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcMaterialDefinitionRepresentation>
{
	private IfcMaterial _representedMaterial;

	[CrossSchemaAttribute(typeof(IIfcMaterialDefinitionRepresentation), 4)]
	IIfcMaterial IIfcMaterialDefinitionRepresentation.RepresentedMaterial
	{
		get
		{
			return RepresentedMaterial;
		}
		set
		{
			RepresentedMaterial = value as IfcMaterial;
		}
	}

	[IndexedProperty]
	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
	public IfcMaterial RepresentedMaterial
	{
		get
		{
			if (_activated)
			{
				return _representedMaterial;
			}
			Activate();
			return _representedMaterial;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcMaterial v)
			{
				_representedMaterial = v;
			}, _representedMaterial, value, "RepresentedMaterial", 4);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcRepresentation representation in base.Representations)
			{
				yield return representation;
			}
			if (RepresentedMaterial != null)
			{
				yield return RepresentedMaterial;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcRepresentation representation in base.Representations)
			{
				yield return representation;
			}
			if (RepresentedMaterial != null)
			{
				yield return RepresentedMaterial;
			}
		}
	}

	internal IfcMaterialDefinitionRepresentation(IModel model, int label, bool activated)
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
			_representedMaterial = (IfcMaterial)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcMaterialDefinitionRepresentation other)
	{
		return this == other;
	}
}
