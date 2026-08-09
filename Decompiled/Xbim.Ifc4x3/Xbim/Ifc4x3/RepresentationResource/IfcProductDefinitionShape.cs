using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.RepresentationResource;
using Xbim.Ifc4x3.Kernel;

namespace Xbim.Ifc4x3.RepresentationResource;

[ExpressType("IfcProductDefinitionShape", 90)]
public class IfcProductDefinitionShape : IfcProductRepresentation, IIfcProductDefinitionShape, IIfcProductRepresentation, IPersistEntity, IPersist, Xbim.Ifc4.RepresentationResource.IfcProductRepresentationSelect, IIfcProductRepresentationSelect, IExpressSelectType, IInstantiableEntity, IfcProductRepresentationSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcProductDefinitionShape>
{
	IEnumerable<IIfcProduct> IIfcProductDefinitionShape.ShapeOfProduct => base.Model.Instances.Where((IIfcProduct e) => e.Representation as IfcProductDefinitionShape == this, "Representation", this);

	IEnumerable<IIfcShapeAspect> IIfcProductDefinitionShape.HasShapeAspects => base.Model.Instances.Where((IIfcShapeAspect e) => e.PartOfProductDefinitionShape as IfcProductDefinitionShape == this, "PartOfProductDefinitionShape", this);

	[InverseProperty("Representation")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 4)]
	public IEnumerable<IfcProduct> ShapeOfProduct => base.Model.Instances.Where((IfcProduct e) => Equals(e.Representation), "Representation", this);

	[InverseProperty("PartOfProductDefinitionShape")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 5)]
	public IEnumerable<IfcShapeAspect> HasShapeAspects => base.Model.Instances.Where((IfcShapeAspect e) => Equals(e.PartOfProductDefinitionShape), "PartOfProductDefinitionShape", this);

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcRepresentation representation in base.Representations)
			{
				yield return representation;
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
		}
	}

	internal IfcProductDefinitionShape(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if ((uint)propIndex <= 2u)
		{
			base.Parse(propIndex, value, nestedIndex);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcProductDefinitionShape other)
	{
		return this == other;
	}
}
