using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.ProductExtension;

[ExpressType("IfcRelConnectsWithRealizingElements", 313)]
public class IfcRelConnectsWithRealizingElements : IfcRelConnectsElements, IIfcRelConnectsWithRealizingElements, IIfcRelConnectsElements, IIfcRelConnects, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelConnectsWithRealizingElements>
{
	private readonly ItemSet<IfcElement> _realizingElements;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _connectionType;

	[CrossSchemaAttribute(typeof(IIfcRelConnectsWithRealizingElements), 8)]
	IItemSet<IIfcElement> IIfcRelConnectsWithRealizingElements.RealizingElements => new ProxyItemSet<IfcElement, IIfcElement>(RealizingElements);

	[CrossSchemaAttribute(typeof(IIfcRelConnectsWithRealizingElements), 9)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcRelConnectsWithRealizingElements.ConnectionType
	{
		get
		{
			if (!ConnectionType.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(ConnectionType.Value);
		}
		set
		{
			ConnectionType = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	[IndexedProperty]
	[EntityAttribute(8, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 8)]
	public IItemSet<IfcElement> RealizingElements
	{
		get
		{
			if (_activated)
			{
				return _realizingElements;
			}
			Activate();
			return _realizingElements;
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 9)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? ConnectionType
	{
		get
		{
			if (_activated)
			{
				return _connectionType;
			}
			Activate();
			return _connectionType;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
			{
				_connectionType = v;
			}, _connectionType, value, "ConnectionType", 9);
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
			if (base.ConnectionGeometry != null)
			{
				yield return base.ConnectionGeometry;
			}
			if (base.RelatingElement != null)
			{
				yield return base.RelatingElement;
			}
			if (base.RelatedElement != null)
			{
				yield return base.RelatedElement;
			}
			foreach (IfcElement realizingElement in RealizingElements)
			{
				yield return realizingElement;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (base.RelatingElement != null)
			{
				yield return base.RelatingElement;
			}
			if (base.RelatedElement != null)
			{
				yield return base.RelatedElement;
			}
			foreach (IfcElement realizingElement in RealizingElements)
			{
				yield return realizingElement;
			}
		}
	}

	internal IfcRelConnectsWithRealizingElements(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_realizingElements = new ItemSet<IfcElement>(this, 0, 8);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
		case 2:
		case 3:
		case 4:
		case 5:
		case 6:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 7:
			_realizingElements.InternalAdd((IfcElement)value.EntityVal);
			break;
		case 8:
			_connectionType = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelConnectsWithRealizingElements other)
	{
		return this == other;
	}
}
