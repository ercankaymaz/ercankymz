using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc2x3.Kernel;

[ExpressType("IfcRelAssociatesClassification", 343)]
public class IfcRelAssociatesClassification : IfcRelAssociates, IIfcRelAssociatesClassification, IIfcRelAssociates, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelAssociatesClassification>
{
	private IfcClassificationNotationSelect _relatingClassification;

	[CrossSchemaAttribute(typeof(IIfcRelAssociatesClassification), 6)]
	IIfcClassificationSelect IIfcRelAssociatesClassification.RelatingClassification
	{
		get
		{
			return RelatingClassification as IIfcClassificationSelect;
		}
		set
		{
			RelatingClassification = value as IfcClassificationNotationSelect;
		}
	}

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
	public IfcClassificationNotationSelect RelatingClassification
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
			SetValue(delegate(IfcClassificationNotationSelect v)
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
			foreach (IfcRoot relatedObject in base.RelatedObjects)
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
			foreach (IfcRoot relatedObject in base.RelatedObjects)
			{
				yield return relatedObject;
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
			_relatingClassification = (IfcClassificationNotationSelect)value.EntityVal;
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
