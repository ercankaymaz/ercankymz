using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4.Kernel;

[ExpressType("IfcRelAssociatesClassification", 343)]
public class IfcRelAssociatesClassification : IfcRelAssociates, IInstantiableEntity, IPersistEntity, IPersist, IIfcRelAssociatesClassification, IIfcRelAssociates, IIfcRelationship, IIfcRoot, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelAssociatesClassification>
{
	private IfcClassificationSelect _relatingClassification;

	IIfcClassificationSelect IIfcRelAssociatesClassification.RelatingClassification
	{
		get
		{
			return RelatingClassification;
		}
		set
		{
			RelatingClassification = value as IfcClassificationSelect;
		}
	}

	[IndexedProperty]
	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
	public IfcClassificationSelect RelatingClassification
	{
		get
		{
			if (_activated)
			{
				return _relatingClassification;
			}
			Activate();
			return _relatingClassification;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcClassificationSelect v)
			{
				_relatingClassification = v;
			}, _relatingClassification, value, "RelatingClassification", 6);
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
			foreach (IfcDefinitionSelect relatedObject in base.RelatedObjects)
			{
				yield return relatedObject;
			}
			if (RelatingClassification != null)
			{
				yield return RelatingClassification;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcDefinitionSelect relatedObject in base.RelatedObjects)
			{
				yield return relatedObject;
			}
			if (RelatingClassification != null)
			{
				yield return RelatingClassification;
			}
		}
	}

	internal IfcRelAssociatesClassification(IModel model, int label, bool activated)
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
		case 4:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 5:
			_relatingClassification = (IfcClassificationSelect)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelAssociatesClassification other)
	{
		return this == other;
	}
}
