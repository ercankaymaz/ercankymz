using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4x3.RepresentationResource;

[ExpressType("IfcShapeModel", 89)]
public abstract class IfcShapeModel : IfcRepresentation, IIfcShapeModel, IIfcRepresentation, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IEquatable<IfcShapeModel>
{
	IEnumerable<IIfcShapeAspect> IIfcShapeModel.OfShapeAspect => base.Model.Instances.Where((IIfcShapeAspect e) => e.ShapeRepresentations != null && e.ShapeRepresentations.Contains(this), "ShapeRepresentations", this);

	[InverseProperty("ShapeRepresentations")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 8)]
	public IEnumerable<IfcShapeAspect> OfShapeAspect => base.Model.Instances.Where((IfcShapeAspect e) => e.ShapeRepresentations != null && e.ShapeRepresentations.Contains(this), "ShapeRepresentations", this);

	internal IfcShapeModel(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if ((uint)propIndex <= 3u)
		{
			base.Parse(propIndex, value, nestedIndex);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcShapeModel other)
	{
		return this == other;
	}
}
