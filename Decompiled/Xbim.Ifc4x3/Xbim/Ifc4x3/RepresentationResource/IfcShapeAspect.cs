using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.ExternalReferenceResource;
using Xbim.Ifc4x3.GeometryResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.RepresentationResource;

[ExpressType("IfcShapeAspect", 665)]
public class IfcShapeAspect : PersistEntity, IIfcShapeAspect, IPersistEntity, IPersist, Xbim.Ifc4.ExternalReferenceResource.IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IInstantiableEntity, Xbim.Ifc4x3.ExternalReferenceResource.IfcResourceObjectSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcShapeAspect>
{
	private readonly ItemSet<IfcShapeModel> _shapeRepresentations;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _name;

	private Xbim.Ifc4x3.MeasureResource.IfcText? _description;

	private Xbim.Ifc4x3.MeasureResource.IfcLogical _productDefinitional;

	private IfcProductRepresentationSelect _partOfProductDefinitionShape;

	[CrossSchemaAttribute(typeof(IIfcShapeAspect), 1)]
	IItemSet<IIfcShapeModel> IIfcShapeAspect.ShapeRepresentations => new ProxyItemSet<IfcShapeModel, IIfcShapeModel>(ShapeRepresentations);

	[CrossSchemaAttribute(typeof(IIfcShapeAspect), 2)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcShapeAspect.Name
	{
		get
		{
			if (!Name.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Name.Value);
		}
		set
		{
			Name = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcShapeAspect), 3)]
	Xbim.Ifc4.MeasureResource.IfcText? IIfcShapeAspect.Description
	{
		get
		{
			if (!Description.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcText(Description.Value);
		}
		set
		{
			Description = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcText?(new Xbim.Ifc4x3.MeasureResource.IfcText(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcText?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcShapeAspect), 4)]
	Xbim.Ifc4.MeasureResource.IfcLogical IIfcShapeAspect.ProductDefinitional
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcLogical(ProductDefinitional);
		}
		set
		{
			ProductDefinitional = new Xbim.Ifc4x3.MeasureResource.IfcLogical(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcShapeAspect), 5)]
	IIfcProductRepresentationSelect IIfcShapeAspect.PartOfProductDefinitionShape
	{
		get
		{
			if (PartOfProductDefinitionShape == null)
			{
				return null;
			}
			IfcProductDefinitionShape ifcProductDefinitionShape = PartOfProductDefinitionShape as IfcProductDefinitionShape;
			if (ifcProductDefinitionShape != null)
			{
				return ifcProductDefinitionShape;
			}
			IfcRepresentationMap ifcRepresentationMap = PartOfProductDefinitionShape as IfcRepresentationMap;
			if (ifcRepresentationMap != null)
			{
				return ifcRepresentationMap;
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				PartOfProductDefinitionShape = null;
				return;
			}
			IfcProductDefinitionShape ifcProductDefinitionShape = value as IfcProductDefinitionShape;
			if (ifcProductDefinitionShape != null)
			{
				PartOfProductDefinitionShape = ifcProductDefinitionShape;
				return;
			}
			IfcRepresentationMap ifcRepresentationMap = value as IfcRepresentationMap;
			if (ifcRepresentationMap != null)
			{
				PartOfProductDefinitionShape = ifcRepresentationMap;
			}
		}
	}

	[IndexedProperty]
	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 1)]
	public IItemSet<IfcShapeModel> ShapeRepresentations
	{
		get
		{
			if (_activated)
			{
				return _shapeRepresentations;
			}
			Activate();
			return _shapeRepresentations;
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? Name
	{
		get
		{
			if (_activated)
			{
				return _name;
			}
			Activate();
			return _name;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
			{
				_name = v;
			}, _name, value, "Name", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public Xbim.Ifc4x3.MeasureResource.IfcText? Description
	{
		get
		{
			if (_activated)
			{
				return _description;
			}
			Activate();
			return _description;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcText? v)
			{
				_description = v;
			}, _description, value, "Description", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public Xbim.Ifc4x3.MeasureResource.IfcLogical ProductDefinitional
	{
		get
		{
			if (_activated)
			{
				return _productDefinitional;
			}
			Activate();
			return _productDefinitional;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLogical v)
			{
				_productDefinitional = v;
			}, _productDefinitional, value, "ProductDefinitional", 4);
		}
	}

	[IndexedProperty]
	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcProductRepresentationSelect PartOfProductDefinitionShape
	{
		get
		{
			if (_activated)
			{
				return _partOfProductDefinitionShape;
			}
			Activate();
			return _partOfProductDefinitionShape;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcProductRepresentationSelect v)
			{
				_partOfProductDefinitionShape = v;
			}, _partOfProductDefinitionShape, value, "PartOfProductDefinitionShape", 5);
		}
	}

	[InverseProperty("RelatedResourceObjects")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 6)]
	public IEnumerable<Xbim.Ifc4x3.ExternalReferenceResource.IfcExternalReferenceRelationship> HasExternalReferences => base.Model.Instances.Where((Xbim.Ifc4x3.ExternalReferenceResource.IfcExternalReferenceRelationship e) => e.RelatedResourceObjects != null && e.RelatedResourceObjects.Contains(this), "RelatedResourceObjects", this);

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcShapeModel shapeRepresentation in ShapeRepresentations)
			{
				yield return shapeRepresentation;
			}
			if (PartOfProductDefinitionShape != null)
			{
				yield return PartOfProductDefinitionShape;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcShapeModel shapeRepresentation in ShapeRepresentations)
			{
				yield return shapeRepresentation;
			}
			if (PartOfProductDefinitionShape != null)
			{
				yield return PartOfProductDefinitionShape;
			}
		}
	}

	internal IfcShapeAspect(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_shapeRepresentations = new ItemSet<IfcShapeModel>(this, 0, 1);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_shapeRepresentations.InternalAdd((IfcShapeModel)value.EntityVal);
			break;
		case 1:
			_name = value.StringVal;
			break;
		case 2:
			_description = value.StringVal;
			break;
		case 3:
			_productDefinitional = value.BooleanVal;
			break;
		case 4:
			_partOfProductDefinitionShape = (IfcProductRepresentationSelect)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcShapeAspect other)
	{
		return this == other;
	}
}
