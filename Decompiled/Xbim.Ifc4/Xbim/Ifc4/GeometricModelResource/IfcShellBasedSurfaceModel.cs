using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.TopologyResource;

namespace Xbim.Ifc4.GeometricModelResource;

[ExpressType("IfcShellBasedSurfaceModel", 235)]
public class IfcShellBasedSurfaceModel : IfcGeometricRepresentationItem, IInstantiableEntity, IPersistEntity, IPersist, IIfcShellBasedSurfaceModel, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcShellBasedSurfaceModel>
{
	private readonly ItemSet<IfcShell> _sbsmBoundary;

	IItemSet<IIfcShell> IIfcShellBasedSurfaceModel.SbsmBoundary => new ProxyItemSet<IfcShell, IIfcShell>(SbsmBoundary);

	IfcDimensionCount IIfcShellBasedSurfaceModel.Dim => Dim;

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
	public IfcDimensionCount Dim => 3L;

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
