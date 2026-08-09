using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4x3.Kernel;
using Xbim.Ifc4x3.StructuralElementsDomain;

namespace Xbim.Ifc4x3.ProductExtension;

[ExpressType("IfcRelAdheresToElement", 1477)]
public class IfcRelAdheresToElement : IfcRelDecomposes, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelAdheresToElement>
{
	private IfcElement _relatingElement;

	private readonly ItemSet<IfcSurfaceFeature> _relatedSurfaceFeatures;

	[IndexedProperty]
	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcElement RelatingElement
	{
		get
		{
			if (_activated)
			{
				return _relatingElement;
			}
			Activate();
			return _relatingElement;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcElement v)
			{
				_relatingElement = v;
			}, _relatingElement, value, "RelatingElement", 5);
		}
	}

	[IndexedProperty]
	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 6)]
	public IItemSet<IfcSurfaceFeature> RelatedSurfaceFeatures
	{
		get
		{
			if (_activated)
			{
				return _relatedSurfaceFeatures;
			}
			Activate();
			return _relatedSurfaceFeatures;
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
			if (RelatingElement != null)
			{
				yield return RelatingElement;
			}
			foreach (IfcSurfaceFeature relatedSurfaceFeature in RelatedSurfaceFeatures)
			{
				yield return relatedSurfaceFeature;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (RelatingElement != null)
			{
				yield return RelatingElement;
			}
			foreach (IfcSurfaceFeature relatedSurfaceFeature in RelatedSurfaceFeatures)
			{
				yield return relatedSurfaceFeature;
			}
		}
	}

	internal IfcRelAdheresToElement(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_relatedSurfaceFeatures = new ItemSet<IfcSurfaceFeature>(this, 0, 6);
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
			_relatingElement = (IfcElement)value.EntityVal;
			break;
		case 5:
			_relatedSurfaceFeatures.InternalAdd((IfcSurfaceFeature)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelAdheresToElement other)
	{
		return this == other;
	}
}
