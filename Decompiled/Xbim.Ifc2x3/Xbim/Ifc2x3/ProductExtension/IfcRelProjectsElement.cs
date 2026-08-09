using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc2x3.ProductExtension;

[ExpressType("IfcRelProjectsElement", 311)]
public class IfcRelProjectsElement : IfcRelConnects, IIfcRelProjectsElement, IIfcRelDecomposes, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelProjectsElement>
{
	private IfcElement _relatingElement;

	private IfcFeatureElementAddition _relatedFeatureElement;

	[CrossSchemaAttribute(typeof(IIfcRelProjectsElement), 5)]
	IIfcElement IIfcRelProjectsElement.RelatingElement
	{
		get
		{
			return RelatingElement;
		}
		set
		{
			RelatingElement = value as IfcElement;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcRelProjectsElement), 6)]
	IIfcFeatureElementAddition IIfcRelProjectsElement.RelatedFeatureElement
	{
		get
		{
			return RelatedFeatureElement;
		}
		set
		{
			RelatedFeatureElement = value as IfcFeatureElementAddition;
		}
	}

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
	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
	public IfcFeatureElementAddition RelatedFeatureElement
	{
		get
		{
			if (_activated)
			{
				return _relatedFeatureElement;
			}
			Activate();
			return _relatedFeatureElement;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcFeatureElementAddition v)
			{
				_relatedFeatureElement = v;
			}, _relatedFeatureElement, value, "RelatedFeatureElement", 6);
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
			if (RelatedFeatureElement != null)
			{
				yield return RelatedFeatureElement;
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
			if (RelatedFeatureElement != null)
			{
				yield return RelatedFeatureElement;
			}
		}
	}

	internal IfcRelProjectsElement(IModel model, int label, bool activated)
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
			_relatingElement = (IfcElement)value.EntityVal;
			break;
		case 5:
			_relatedFeatureElement = (IfcFeatureElementAddition)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelProjectsElement other)
	{
		return this == other;
	}
}
