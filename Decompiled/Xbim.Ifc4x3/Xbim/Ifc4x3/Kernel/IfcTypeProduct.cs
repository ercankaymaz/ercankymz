using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.GeometryResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.Kernel;

[ExpressType("IfcTypeProduct", 43)]
public class IfcTypeProduct : IfcTypeObject, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect, IInstantiableEntity, IfcProductSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcTypeProduct>
{
	private readonly OptionalItemSet<IfcRepresentationMap> _representationMaps;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _tag;

	[CrossSchemaAttribute(typeof(IIfcTypeProduct), 7)]
	IItemSet<IIfcRepresentationMap> IIfcTypeProduct.RepresentationMaps => new ProxyItemSet<IfcRepresentationMap, IIfcRepresentationMap>(RepresentationMaps);

	[CrossSchemaAttribute(typeof(IIfcTypeProduct), 8)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcTypeProduct.Tag
	{
		get
		{
			if (!Tag.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Tag.Value);
		}
		set
		{
			Tag = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	IEnumerable<IIfcRelAssignsToProduct> IIfcTypeProduct.ReferencedBy => base.Model.Instances.Where((IIfcRelAssignsToProduct e) => e.RelatingProduct as IfcTypeProduct == this, "RelatingProduct", this);

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
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? Tag
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
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
}
