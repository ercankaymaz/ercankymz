using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc4.ProductExtension;

[ExpressType("IfcRelServicesBuildings", 600)]
public class IfcRelServicesBuildings : IfcRelConnects, IInstantiableEntity, IPersistEntity, IPersist, IIfcRelServicesBuildings, IIfcRelConnects, IIfcRelationship, IIfcRoot, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelServicesBuildings>
{
	private IfcSystem _relatingSystem;

	private readonly ItemSet<IfcSpatialElement> _relatedBuildings;

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

	IItemSet<IIfcSpatialElement> IIfcRelServicesBuildings.RelatedBuildings => new ProxyItemSet<IfcSpatialElement, IIfcSpatialElement>(RelatedBuildings);

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
	public IItemSet<IfcSpatialElement> RelatedBuildings
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
			foreach (IfcSpatialElement relatedBuilding in RelatedBuildings)
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
			foreach (IfcSpatialElement relatedBuilding in RelatedBuildings)
			{
				yield return relatedBuilding;
			}
		}
	}

	internal IfcRelServicesBuildings(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_relatedBuildings = new ItemSet<IfcSpatialElement>(this, 0, 6);
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
			_relatedBuildings.InternalAdd((IfcSpatialElement)value.EntityVal);
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
