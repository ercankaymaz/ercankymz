using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4x3.GeometricConstraintResource;
using Xbim.Ifc4x3.ProductExtension;
using Xbim.Ifc4x3.RepresentationResource;

namespace Xbim.Ifc4x3.Kernel;

[ExpressType("IfcProduct", 20)]
public abstract class IfcProduct : IfcObject, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect, IfcProductSelect, IfcSpatialReferenceSelect, IEquatable<IfcProduct>
{
	private IfcObjectPlacement _objectPlacement;

	private IfcProductRepresentation _representation;

	[CrossSchemaAttribute(typeof(IIfcProduct), 6)]
	IIfcObjectPlacement IIfcProduct.ObjectPlacement
	{
		get
		{
			return ObjectPlacement;
		}
		set
		{
			ObjectPlacement = value as IfcObjectPlacement;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcProduct), 7)]
	IIfcProductRepresentation IIfcProduct.Representation
	{
		get
		{
			return Representation;
		}
		set
		{
			Representation = value as IfcProductRepresentation;
		}
	}

	IEnumerable<IIfcRelAssignsToProduct> IIfcProduct.ReferencedBy => base.Model.Instances.Where((IIfcRelAssignsToProduct e) => e.RelatingProduct as IfcProduct == this, "RelatingProduct", this);

	public IIfcSpatialElement IsContainedIn => (from s in base.Model.Instances
		where s.RelatedElements.Contains(this)
		select s.RelatingStructure).FirstOrDefault();

	[IndexedProperty]
	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 17)]
	public IfcObjectPlacement ObjectPlacement
	{
		get
		{
			if (_activated)
			{
				return _objectPlacement;
			}
			Activate();
			return _objectPlacement;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcObjectPlacement v)
			{
				_objectPlacement = v;
			}, _objectPlacement, value, "ObjectPlacement", 6);
		}
	}

	[IndexedProperty]
	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 18)]
	public IfcProductRepresentation Representation
	{
		get
		{
			if (_activated)
			{
				return _representation;
			}
			Activate();
			return _representation;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcProductRepresentation v)
			{
				_representation = v;
			}, _representation, value, "Representation", 7);
		}
	}

	[InverseProperty("RelatingProduct")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 19)]
	public IEnumerable<IfcRelAssignsToProduct> ReferencedBy => base.Model.Instances.Where((IfcRelAssignsToProduct e) => Equals(e.RelatingProduct), "RelatingProduct", this);

	[InverseProperty("RelatedProducts")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 20)]
	public IEnumerable<IfcRelPositions> PositionedRelativeTo => base.Model.Instances.Where((IfcRelPositions e) => e.RelatedProducts != null && e.RelatedProducts.Contains(this), "RelatedProducts", this);

	[InverseProperty("RelatedElements")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 21)]
	public IEnumerable<IfcRelReferencedInSpatialStructure> ReferencedInStructures => base.Model.Instances.Where((IfcRelReferencedInSpatialStructure e) => e.RelatedElements != null && e.RelatedElements.Contains(this), "RelatedElements", this);

	internal IfcProduct(IModel model, int label, bool activated)
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
			_objectPlacement = (IfcObjectPlacement)value.EntityVal;
			break;
		case 6:
			_representation = (IfcProductRepresentation)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcProduct other)
	{
		return this == other;
	}
}
