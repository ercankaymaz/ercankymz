using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc2x3.TopologyResource;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc2x3.GeometricModelResource;

[ExpressType("IfcShellBasedSurfaceModel", 235)]
public class IfcShellBasedSurfaceModel : Xbim.Ifc2x3.GeometryResource.IfcGeometricRepresentationItem, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcShellBasedSurfaceModel>, IIfcShellBasedSurfaceModel, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType
{
	private readonly ItemSet<IfcShell> _sbsmBoundary;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 3)]
	public IItemSet<IfcShell> SbsmBoundary
	{
		get
		{
			if (_activated)
			{
				return _sbsmBoundary;
			}
			Activate();
			return _sbsmBoundary;
		}
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public Xbim.Ifc2x3.GeometryResource.IfcDimensionCount Dim => 3L;

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcShell item in SbsmBoundary)
			{
				yield return item;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcShellBasedSurfaceModel), 1)]
	IItemSet<IIfcShell> IIfcShellBasedSurfaceModel.SbsmBoundary => new ProxyItemSet<IfcShell, IIfcShell>(SbsmBoundary);

	Xbim.Ifc4.GeometryResource.IfcDimensionCount IIfcShellBasedSurfaceModel.Dim => new Xbim.Ifc4.GeometryResource.IfcDimensionCount(Dim);

	internal IfcShellBasedSurfaceModel(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_sbsmBoundary = new ItemSet<IfcShell>(this, 0, 1);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex == 0)
		{
			_sbsmBoundary.InternalAdd((IfcShell)value.EntityVal);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcShellBasedSurfaceModel other)
	{
		return this == other;
	}
}
