using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.TopologyResource;

namespace Xbim.Ifc4.GeometricModelResource;

[ExpressType("IfcFaceBasedSurfaceModel", 438)]
public class IfcFaceBasedSurfaceModel : IfcGeometricRepresentationItem, IInstantiableEntity, IPersistEntity, IPersist, IIfcFaceBasedSurfaceModel, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcSurfaceOrFaceSurface, IIfcSurfaceOrFaceSurface, IContainsEntityReferences, IEquatable<IfcFaceBasedSurfaceModel>
{
	private readonly ItemSet<IfcConnectedFaceSet> _fbsmFaces;

	IItemSet<IIfcConnectedFaceSet> IIfcFaceBasedSurfaceModel.FbsmFaces => new ProxyItemSet<IfcConnectedFaceSet, IIfcConnectedFaceSet>(FbsmFaces);

	IfcDimensionCount IIfcFaceBasedSurfaceModel.Dim => Dim;

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
	public IfcDimensionCount Dim => 3L;

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
