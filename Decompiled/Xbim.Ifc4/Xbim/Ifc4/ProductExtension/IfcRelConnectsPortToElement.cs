using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc4.ProductExtension;

[ExpressType("IfcRelConnectsPortToElement", 633)]
public class IfcRelConnectsPortToElement : IfcRelConnects, IInstantiableEntity, IPersistEntity, IPersist, IIfcRelConnectsPortToElement, IIfcRelConnects, IIfcRelationship, IIfcRoot, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelConnectsPortToElement>
{
	private IfcPort _relatingPort;

	private IfcDistributionElement _relatedElement;

	IIfcPort IIfcRelConnectsPortToElement.RelatingPort
	{
		get
		{
			return RelatingPort;
		}
		set
		{
			RelatingPort = value as IfcPort;
		}
	}

	IIfcDistributionElement IIfcRelConnectsPortToElement.RelatedElement
	{
		get
		{
			return RelatedElement;
		}
		set
		{
			RelatedElement = value as IfcDistributionElement;
		}
	}

	[IndexedProperty]
	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcPort RelatingPort
	{
		get
		{
			if (_activated)
			{
				return _relatingPort;
			}
			Activate();
			return _relatingPort;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcPort v)
			{
				_relatingPort = v;
			}, _relatingPort, value, "RelatingPort", 5);
		}
	}

	[IndexedProperty]
	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
	public IfcDistributionElement RelatedElement
	{
		get
		{
			if (_activated)
			{
				return _relatedElement;
			}
			Activate();
			return _relatedElement;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcDistributionElement v)
			{
				_relatedElement = v;
			}, _relatedElement, value, "RelatedElement", 6);
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
			if (RelatingPort != null)
			{
				yield return RelatingPort;
			}
			if (RelatedElement != null)
			{
				yield return RelatedElement;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (RelatingPort != null)
			{
				yield return RelatingPort;
			}
			if (RelatedElement != null)
			{
				yield return RelatedElement;
			}
		}
	}

	internal IfcRelConnectsPortToElement(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
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
			_relatingPort = (IfcPort)value.EntityVal;
			break;
		case 5:
			_relatedElement = (IfcDistributionElement)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelConnectsPortToElement other)
	{
		return this == other;
	}
}
