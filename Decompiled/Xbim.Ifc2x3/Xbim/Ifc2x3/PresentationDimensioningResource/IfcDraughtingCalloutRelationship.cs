using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;

namespace Xbim.Ifc2x3.PresentationDimensioningResource;

[ExpressType("IfcDraughtingCalloutRelationship", 740)]
public class IfcDraughtingCalloutRelationship : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcDraughtingCalloutRelationship>
{
	private IfcLabel? _name;

	private IfcText? _description;

	private IfcDraughtingCallout _relatingDraughtingCallout;

	private IfcDraughtingCallout _relatedDraughtingCallout;

	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
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
			}, _name, value, "Name", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
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
			}, _description, value, "Description", 2);
		}
	}

	[IndexedProperty]
	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcDraughtingCallout RelatingDraughtingCallout
	{
		get
		{
			if (_activated)
			{
				return _relatingDraughtingCallout;
			}
			Activate();
			return _relatingDraughtingCallout;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcDraughtingCallout v)
			{
				_relatingDraughtingCallout = v;
			}, _relatingDraughtingCallout, value, "RelatingDraughtingCallout", 3);
		}
	}

	[IndexedProperty]
	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
	public IfcDraughtingCallout RelatedDraughtingCallout
	{
		get
		{
			if (_activated)
			{
				return _relatedDraughtingCallout;
			}
			Activate();
			return _relatedDraughtingCallout;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcDraughtingCallout v)
			{
				_relatedDraughtingCallout = v;
			}, _relatedDraughtingCallout, value, "RelatedDraughtingCallout", 4);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (RelatingDraughtingCallout != null)
			{
				yield return RelatingDraughtingCallout;
			}
			if (RelatedDraughtingCallout != null)
			{
				yield return RelatedDraughtingCallout;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (RelatingDraughtingCallout != null)
			{
				yield return RelatingDraughtingCallout;
			}
			if (RelatedDraughtingCallout != null)
			{
				yield return RelatedDraughtingCallout;
			}
		}
	}

	internal IfcDraughtingCalloutRelationship(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_name = value.StringVal;
			break;
		case 1:
			_description = value.StringVal;
			break;
		case 2:
			_relatingDraughtingCallout = (IfcDraughtingCallout)value.EntityVal;
			break;
		case 3:
			_relatedDraughtingCallout = (IfcDraughtingCallout)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcDraughtingCalloutRelationship other)
	{
		return this == other;
	}
}
