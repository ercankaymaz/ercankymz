using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.RepresentationResource;

[ExpressType("IfcShapeAspect", 665)]
public class IfcShapeAspect : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IIfcShapeAspect, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcShapeAspect>
{
	private readonly ItemSet<IfcShapeModel> _shapeRepresentations;

	private IfcLabel? _name;

	private IfcText? _description;

	private IfcLogical _productDefinitional;

	private IfcProductRepresentationSelect _partOfProductDefinitionShape;

	IItemSet<IIfcShapeModel> IIfcShapeAspect.ShapeRepresentations => new ProxyItemSet<IfcShapeModel, IIfcShapeModel>(ShapeRepresentations);

	IfcLabel? IIfcShapeAspect.Name
	{
		get
		{
			return Name;
		}
		set
		{
			Name = value;
		}
	}

	IfcText? IIfcShapeAspect.Description
	{
		get
		{
			return Description;
		}
		set
		{
			Description = value;
		}
	}

	IfcLogical IIfcShapeAspect.ProductDefinitional
	{
		get
		{
			return ProductDefinitional;
		}
		set
		{
			ProductDefinitional = value;
		}
	}

	IIfcProductRepresentationSelect IIfcShapeAspect.PartOfProductDefinitionShape
	{
		get
		{
			return PartOfProductDefinitionShape;
		}
		set
		{
			PartOfProductDefinitionShape = value as IfcProductRepresentationSelect;
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
	public IfcLabel? Name
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
			SetValue(delegate(IfcLabel? v)
			{
				_name = v;
			}, _name, value, "Name", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public IfcText? Description
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
			SetValue(delegate(IfcText? v)
			{
				_description = v;
			}, _description, value, "Description", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public IfcLogical ProductDefinitional
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
			SetValue(delegate(IfcLogical v)
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
