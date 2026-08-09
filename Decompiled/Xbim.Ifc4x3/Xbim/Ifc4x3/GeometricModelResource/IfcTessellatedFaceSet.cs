using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4x3.GeometryResource;
using Xbim.Ifc4x3.PresentationAppearanceResource;

namespace Xbim.Ifc4x3.GeometricModelResource;

[ExpressType("IfcTessellatedFaceSet", 1299)]
public abstract class IfcTessellatedFaceSet : IfcTessellatedItem, IfcBooleanOperand, IExpressSelectType, IPersist, IPersistEntity, IIfcBooleanOperand, IEquatable<IfcTessellatedFaceSet>, IIfcTessellatedFaceSet, IIfcTessellatedItem, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, Xbim.Ifc4.GeometricModelResource.IfcBooleanOperand
{
	private IfcCartesianPointList3D _coordinates;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcCartesianPointList3D Coordinates
	{
		get
		{
			if (_activated)
			{
				return _coordinates;
			}
			Activate();
			return _coordinates;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcCartesianPointList3D v)
			{
				_coordinates = v;
			}, _coordinates, value, "Coordinates", 1);
		}
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public Xbim.Ifc4x3.GeometryResource.IfcDimensionCount Dim => 3L;

	[InverseProperty("MappedTo")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 4)]
	public IEnumerable<IfcIndexedColourMap> HasColours => base.Model.Instances.Where((IfcIndexedColourMap e) => Equals(e.MappedTo), "MappedTo", this);

	[InverseProperty("MappedTo")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 5)]
	public IEnumerable<IfcIndexedTextureMap> HasTextures => base.Model.Instances.Where((IfcIndexedTextureMap e) => Equals(e.MappedTo), "MappedTo", this);

	[CrossSchemaAttribute(typeof(IIfcTessellatedFaceSet), 1)]
	IIfcCartesianPointList3D IIfcTessellatedFaceSet.Coordinates
	{
		get
		{
			return Coordinates;
		}
		set
		{
			Coordinates = value as IfcCartesianPointList3D;
		}
	}

	IEnumerable<IIfcIndexedColourMap> IIfcTessellatedFaceSet.HasColours => base.Model.Instances.Where((IIfcIndexedColourMap e) => e.MappedTo as IfcTessellatedFaceSet == this, "MappedTo", this);

	IEnumerable<IIfcIndexedTextureMap> IIfcTessellatedFaceSet.HasTextures => base.Model.Instances.Where((IIfcIndexedTextureMap e) => e.MappedTo as IfcTessellatedFaceSet == this, "MappedTo", this);

	Xbim.Ifc4.GeometryResource.IfcDimensionCount Xbim.Ifc4.GeometricModelResource.IfcBooleanOperand.Dim => new Xbim.Ifc4.GeometryResource.IfcDimensionCount(Dim);

	internal IfcTessellatedFaceSet(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex == 0)
		{
			_coordinates = (IfcCartesianPointList3D)value.EntityVal;
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcTessellatedFaceSet other)
	{
		return this == other;
	}
}
