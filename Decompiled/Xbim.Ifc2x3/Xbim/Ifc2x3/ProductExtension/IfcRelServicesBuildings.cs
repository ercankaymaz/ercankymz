using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc2x3.ProductExtension;

[ExpressType("IfcRelServicesBuildings", 600)]
public class IfcRelServicesBuildings : IfcRelConnects, IIfcRelServicesBuildings, IIfcRelConnects, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelServicesBuildings>
{
	private IItemSet<IIfcSpatialElement> _relatedBuildingsIfc4;

	private IfcSystem _relatingSystem;

	private readonly ItemSet<IfcSpatialStructureElement> _relatedBuildings;

	[CrossSchemaAttribute(typeof(IIfcRelServicesBuildings), 5)]
	IIfcSystem IIfcRelServicesBuildings.RelatingSystem
	{
		get
		{
			return RelatingSystem;
		}
		set
		{
			RelatingSystem = value as IfcSystem;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcRelServicesBuildings), 6)]
	IItemSet<IIfcSpatialElement> IIfcRelServicesBuildings.RelatedBuildings => _relatedBuildingsIfc4 ?? (_relatedBuildingsIfc4 = new ExtendedItemSet<IfcSpatialStructureElement, IIfcSpatialElement>(RelatedBuildings, new ItemSet<IIfcSpatialElement>(this, 0, -6), RelatedBuildingsToIfc4, RelatedBuildingsToIfc2X3));

	[IndexedProperty]
	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcSystem RelatingSystem
	{
		get
		{
			if (_activated)
			{
				return _relatingSystem;
			}
			Activate();
			return _relatingSystem;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcSystem v)
			{
				_relatingSystem = v;
			}, _relatingSystem, value, "RelatingSystem", 5);
		}
	}

	[IndexedProperty]
	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 6)]
	public IItemSet<IfcSpatialStructureElement> RelatedBuildings
	{
		get
		{
			if (_activated)
			{
				return _relatedBuildings;
			}
			Activate();
			return _relatedBuildings;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.OwnerHistory != null)
			{
				yield return base.OwnerHistory;
			}
			if (RelatingSystem != null)
			{
				yield return RelatingSystem;
			}
			foreach (IfcSpatialStructureElement relatedBuilding in RelatedBuildings)
			{
				yield return relatedBuilding;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (RelatingSystem != null)
			{
				yield return RelatingSystem;
			}
			foreach (IfcSpatialStructureElement relatedBuilding in RelatedBuildings)
			{
				yield return relatedBuilding;
			}
		}
	}

	private static IIfcSpatialElement RelatedBuildingsToIfc4(IfcSpatialStructureElement member)
	{
		return member;
	}

	private static IfcSpatialStructureElement RelatedBuildingsToIfc2X3(IIfcSpatialElement member)
	{
		return member as IfcSpatialStructureElement;
	}

	internal IfcRelServicesBuildings(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_relatedBuildings = new ItemSet<IfcSpatialStructureElement>(this, 0, 6);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
		case 2:
		case 3:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 4:
			_relatingSystem = (IfcSystem)value.EntityVal;
			break;
		case 5:
			_relatedBuildings.InternalAdd((IfcSpatialStructureElement)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelServicesBuildings other)
	{
		return this == other;
	}
}
