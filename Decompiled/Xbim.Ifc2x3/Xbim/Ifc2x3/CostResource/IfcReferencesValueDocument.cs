using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.ExternalReferenceResource;
using Xbim.Ifc2x3.MeasureResource;

namespace Xbim.Ifc2x3.CostResource;

[ExpressType("IfcReferencesValueDocument", 551)]
public class IfcReferencesValueDocument : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcReferencesValueDocument>
{
	private IfcDocumentSelect _referencedDocument;

	private readonly ItemSet<IfcAppliedValue> _referencingValues;

	private IfcLabel? _name;

	private IfcText? _description;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 1)]
	public IfcDocumentSelect ReferencedDocument
	{
		get
		{
			if (_activated)
			{
				return _referencedDocument;
			}
			Activate();
			return _referencedDocument;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcDocumentSelect v)
			{
				_referencedDocument = v;
			}, _referencedDocument, value, "ReferencedDocument", 1);
		}
	}

	[IndexedProperty]
	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 2)]
	public IItemSet<IfcAppliedValue> ReferencingValues
	{
		get
		{
			if (_activated)
			{
				return _referencingValues;
			}
			Activate();
			return _referencingValues;
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public IfcLabel? Name
	{
		get
		{
			if (_activated)
			{
				return _name;
			}
			Activate();
			return _name;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_name = v;
			}, _name, value, "Name", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public IfcText? Description
	{
		get
		{
			if (_activated)
			{
				return _description;
			}
			Activate();
			return _description;
		}
		set
		{
			SetValue(delegate(IfcText? v)
			{
				_description = v;
			}, _description, value, "Description", 4);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (ReferencedDocument != null)
			{
				yield return ReferencedDocument;
			}
			foreach (IfcAppliedValue referencingValue in ReferencingValues)
			{
				yield return referencingValue;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcAppliedValue referencingValue in ReferencingValues)
			{
				yield return referencingValue;
			}
		}
	}

	internal IfcReferencesValueDocument(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_referencingValues = new ItemSet<IfcAppliedValue>(this, 0, 2);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_referencedDocument = (IfcDocumentSelect)value.EntityVal;
			break;
		case 1:
			_referencingValues.InternalAdd((IfcAppliedValue)value.EntityVal);
			break;
		case 2:
			_name = value.StringVal;
			break;
		case 3:
			_description = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcReferencesValueDocument other)
	{
		return this == other;
	}
}
