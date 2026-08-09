using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4x3.ExternalReferenceResource;

namespace Xbim.Ifc4x3.Kernel;

[ExpressType("IfcRelAssociatesClassification", 343)]
public class IfcRelAssociatesClassification : IfcRelAssociates, IIfcRelAssociatesClassification, IIfcRelAssociates, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelAssociatesClassification>
{
	private IfcClassificationSelect _relatingClassification;

	[CrossSchemaAttribute(typeof(IIfcRelAssociatesClassification), 6)]
	IIfcClassificationSelect IIfcRelAssociatesClassification.RelatingClassification
	{
		get
		{
			if (RelatingClassification == null)
			{
				return null;
			}
			IfcClassification ifcClassification = RelatingClassification as IfcClassification;
			if (ifcClassification != null)
			{
				return ifcClassification;
			}
			IfcClassificationReference ifcClassificationReference = RelatingClassification as IfcClassificationReference;
			if (ifcClassificationReference != null)
			{
				return ifcClassificationReference;
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				RelatingClassification = null;
				return;
			}
			IfcClassification ifcClassification = value as IfcClassification;
			if (ifcClassification != null)
			{
				RelatingClassification = ifcClassification;
				return;
			}
			IfcClassificationReference ifcClassificationReference = value as IfcClassificationReference;
			if (ifcClassificationReference != null)
			{
				RelatingClassification = ifcClassificationReference;
			}
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
