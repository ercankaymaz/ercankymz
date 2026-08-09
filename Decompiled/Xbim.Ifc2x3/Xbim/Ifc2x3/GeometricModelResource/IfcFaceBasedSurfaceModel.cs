using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.GeometricConstraintResource;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc2x3.TopologyResource;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc2x3.GeometricModelResource;

[ExpressType("IfcFaceBasedSurfaceModel", 438)]
public class IfcFaceBasedSurfaceModel : Xbim.Ifc2x3.GeometryResource.IfcGeometricRepresentationItem, IInstantiableEntity, IPersistEntity, IPersist, Xbim.Ifc2x3.GeometricConstraintResource.IfcSurfaceOrFaceSurface, IExpressSelectType, IIfcSurfaceOrFaceSurface, IContainsEntityReferences, IEquatable<IfcFaceBasedSurfaceModel>, IIfcFaceBasedSurfaceModel, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, Xbim.Ifc4.GeometricConstraintResource.IfcSurfaceOrFaceSurface
{
	private readonly ItemSet<IfcConnectedFaceSet> _fbsmFaces;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 3)]
	public IItemSet<IfcConnectedFaceSet> FbsmFaces
	{
		get
		{
			if (_activated)
			{
				return _fbsmFaces;
			}
			Activate();
			return _fbsmFaces;
		}
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public Xbim.Ifc2x3.GeometryResource.IfcDimensionCount Dim => 3L;

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcConnectedFaceSet fbsmFace in FbsmFaces)
			{
				yield return fbsmFace;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcFaceBasedSurfaceModel), 1)]
	IItemSet<IIfcConnectedFaceSet> IIfcFaceBasedSurfaceModel.FbsmFaces => new ProxyItemSet<IfcConnectedFaceSet, IIfcConnectedFaceSet>(FbsmFaces);

	Xbim.Ifc4.GeometryResource.IfcDimensionCount IIfcFaceBasedSurfaceModel.Dim => new Xbim.Ifc4.GeometryResource.IfcDimensionCount(Dim);

	internal IfcFaceBasedSurfaceModel(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_fbsmFaces = new ItemSet<IfcConnectedFaceSet>(this, 0, 1);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex == 0)
		{
			_fbsmFaces.InternalAdd((IfcConnectedFaceSet)value.EntityVal);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcFaceBasedSurfaceModel other)
	{
		return this == other;
	}
}
