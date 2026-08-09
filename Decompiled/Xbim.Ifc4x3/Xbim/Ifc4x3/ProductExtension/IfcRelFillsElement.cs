using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4x3.Kernel;

namespace Xbim.Ifc4x3.ProductExtension;

[ExpressType("IfcRelFillsElement", 563)]
public class IfcRelFillsElement : IfcRelConnects, IIfcRelFillsElement, IIfcRelConnects, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelFillsElement>
{
	private IfcOpeningElement _relatingOpeningElement;

	private IfcElement _relatedBuildingElement;

	[CrossSchemaAttribute(typeof(IIfcRelFillsElement), 5)]
	IIfcOpeningElement IIfcRelFillsElement.RelatingOpeningElement
	{
		get
		{
			return RelatingOpeningElement;
		}
		set
		{
			RelatingOpeningElement = value as IfcOpeningElement;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcRelFillsElement), 6)]
	IIfcElement IIfcRelFillsElement.RelatedBuildingElement
	{
		get
		{
			return RelatedBuildingElement;
		}
		set
		{
			RelatedBuildingElement = value as IfcElement;
		}
	}

	[IndexedProperty]
	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcOpeningElement RelatingOpeningElement
	{
		get
		{
			if (_activated)
			{
				return _relatingOpeningElement;
			}
			Activate();
			return _relatingOpeningElement;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcOpeningElement v)
			{
				_relatingOpeningElement = v;
			}, _relatingOpeningElement, value, "RelatingOpeningElement", 5);
		}
	}

	[IndexedProperty]
	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
	public IfcElement RelatedBuildingElement
	{
		get
		{
			if (_activated)
			{
				return _relatedBuildingElement;
			}
			Activate();
			return _relatedBuildingElement;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcElement v)
			{
				_relatedBuildingElement = v;
			}, _relatedBuildingElement, value, "RelatedBuildingElement", 6);
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
			if (RelatingOpeningElement != null)
			{
				yield return RelatingOpeningElement;
			}
			if (RelatedBuildingElement != null)
			{
				yield return RelatedBuildingElement;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (RelatingOpeningElement != null)
			{
				yield return RelatingOpeningElement;
			}
			if (RelatedBuildingElement != null)
			{
				yield return RelatedBuildingElement;
			}
		}
	}

	internal IfcRelFillsElement(IModel model, int label, bool activated)
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
			_relatingOpeningElement = (IfcOpeningElement)value.EntityVal;
			break;
		case 5:
			_relatedBuildingElement = (IfcElement)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelFillsElement other)
	{
		return this == other;
	}
}
