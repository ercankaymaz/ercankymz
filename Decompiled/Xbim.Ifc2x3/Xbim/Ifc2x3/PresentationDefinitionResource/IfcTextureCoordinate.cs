using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc2x3.PresentationDefinitionResource;

[ExpressType("IfcTextureCoordinate", 732)]
public abstract class IfcTextureCoordinate : PersistEntity, IIfcTextureCoordinate, IIfcPresentationItem, IPersistEntity, IPersist, IEquatable<IfcTextureCoordinate>
{
	private IItemSet<IIfcSurfaceTexture> _ifcTextureCoordinate;

	[CrossSchemaAttribute(typeof(IIfcTextureCoordinate), 1)]
	IItemSet<IIfcSurfaceTexture> IIfcTextureCoordinate.Maps => _ifcTextureCoordinate ?? (_ifcTextureCoordinate = new ItemSet<IIfcSurfaceTexture>(this, 0, -1));

	[InverseProperty("TextureCoordinates")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { 1 }, 1)]
	public IEnumerable<IfcAnnotationSurface> AnnotatedSurface => base.Model.Instances.Where((IfcAnnotationSurface e) => Equals(e.TextureCoordinates), "TextureCoordinates", this);

	internal IfcTextureCoordinate(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		throw new IndexOutOfRangeException("There are no attributes defined for this entity");
	}

	public bool Equals(IfcTextureCoordinate other)
	{
		return this == other;
	}
}
