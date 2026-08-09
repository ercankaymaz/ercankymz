using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.RepresentationResource;

[ExpressType("IfcShapeAspect", 665)]
public class IfcShapeAspect : PersistEntity, IIfcShapeAspect, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcShapeAspect>
{
	private IIfcProductRepresentationSelect _partOfProductDefinitionShape4;

	private readonly ItemSet<IfcShapeModel> _shapeRepresentations;

	private Xbim.Ifc2x3.MeasureResource.IfcLabel? _name;

	private Xbim.Ifc2x3.MeasureResource.IfcText? _description;

	private bool? _productDefinitional;

	private IfcProductDefinitionShape _partOfProductDefinitionShape;

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
			Name = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLabel?(new Xbim.Ifc2x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLabel?)null));
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
			Description = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcText?(new Xbim.Ifc2x3.MeasureResource.IfcText(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcText?)null));
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
			ProductDefinitional = value;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcShapeAspect), 5)]
	IIfcProductRepresentationSelect IIfcShapeAspect.PartOfProductDefinitionShape
	{
		get
		{
			return _partOfProductDefinitionShape4 ?? PartOfProductDefinitionShape;
		}
		set
		{
			if (value == null)
			{
				PartOfProductDefinitionShape = null;
				if (_partOfProductDefinitionShape4 != null)
				{
					SetValue(delegate(IIfcProductRepresentationSelect v)
					{
						_partOfProductDefinitionShape4 = v;
					}, _partOfProductDefinitionShape4, null, "PartOfProductDefinitionShape", -5);
				}
				return;
			}
			IfcProductDefinitionShape ifcProductDefinitionShape = value as IfcProductDefinitionShape;
			if (ifcProductDefinitionShape != null)
			{
				PartOfProductDefinitionShape = ifcProductDefinitionShape;
				if (_partOfProductDefinitionShape4 != null)
				{
					SetValue(delegate(IIfcProductRepresentationSelect v)
					{
						_partOfProductDefinitionShape4 = v;
					}, _partOfProductDefinitionShape4, null, "PartOfProductDefinitionShape", -5);
				}
			}
			else
			{
				if (PartOfProductDefinitionShape != null)
				{
					PartOfProductDefinitionShape = null;
				}
				SetValue(delegate(IIfcProductRepresentationSelect v)
				{
					_partOfProductDefinitionShape4 = v;
				}, _partOfProductDefinitionShape4, value, "PartOfProductDefinitionShape", -5);
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
	public Xbim.Ifc2x3.MeasureResource.IfcLabel? Name
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel? v)
			{
				_name = v;
			}, _name, value, "Name", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public Xbim.Ifc2x3.MeasureResource.IfcText? Description
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcText? v)
			{
				_description = v;
			}, _description, value, "Description", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public bool? ProductDefinitional
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
			SetValue(delegate(bool? v)
			{
				_productDefinitional = v;
			}, _productDefinitional, value, "ProductDefinitional", 4);
		}
	}

	[IndexedProperty]
	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcProductDefinitionShape PartOfProductDefinitionShape
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
			SetValue(delegate(IfcProductDefinitionShape v)
			{
				_partOfProductDefinitionShape = v;
			}, _partOfProductDefinitionShape, value, "PartOfProductDefinitionShape", 5);
		}
	}

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
			_partOfProductDefinitionShape = (IfcProductDefinitionShape)value.EntityVal;
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
