using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc2x3.ProductExtension;

[ExpressType("IfcRelVoidsElement", 496)]
public class IfcRelVoidsElement : IfcRelConnects, IIfcRelVoidsElement, IIfcRelDecomposes, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelVoidsElement>
{
	private IfcElement _relatingBuildingElement;

	private IfcFeatureElementSubtraction _relatedOpeningElement;

	[CrossSchemaAttribute(typeof(IIfcRelVoidsElement), 5)]
	IIfcElement IIfcRelVoidsElement.RelatingBuildingElement
	{
		get
		{
			return RelatingBuildingElement;
		}
		set
		{
			RelatingBuildingElement = value as IfcElement;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcRelVoidsElement), 6)]
	IIfcFeatureElementSubtraction IIfcRelVoidsElement.RelatedOpeningElement
	{
		get
		{
			return RelatedOpeningElement;
		}
		set
		{
			RelatedOpeningElement = value as IfcFeatureElementSubtraction;
		}
	}

	[IndexedProperty]
	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcElement RelatingBuildingElement
	{
		get
		{
			if (_activated)
			{
				return _relatingBuildingElement;
			}
			Activate();
			return _relatingBuildingElement;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcElement v)
			{
				_relatingBuildingElement = v;
			}, _relatingBuildingElement, value, "RelatingBuildingElement", 5);
		}
	}

	[IndexedProperty]
	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
	public IfcFeatureElementSubtraction RelatedOpeningElement
	{
		get
		{
			if (_activated)
			{
				return _relatedOpeningElement;
			}
			Activate();
			return _relatedOpeningElement;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcFeatureElementSubtraction v)
			{
				_relatedOpeningElement = v;
			}, _relatedOpeningElement, value, "RelatedOpeningElement", 6);
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
			if (RelatingBuildingElement != null)
			{
				yield return RelatingBuildingElement;
			}
			if (RelatedOpeningElement != null)
			{
				yield return RelatedOpeningElement;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (RelatingBuildingElement != null)
			{
				yield return RelatingBuildingElement;
			}
			if (RelatedOpeningElement != null)
			{
				yield return RelatedOpeningElement;
			}
		}
	}

	internal IfcRelVoidsElement(IModel model, int label, bool activated)
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
			_relatingBuildingElement = (IfcElement)value.EntityVal;
			break;
		case 5:
			_relatedOpeningElement = (IfcFeatureElementSubtraction)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelVoidsElement other)
	{
		return this == other;
	}
}
