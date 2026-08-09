using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4x3.Kernel;
using Xbim.Ifc4x3.ProductExtension;

namespace Xbim.Ifc4x3.SharedBldgElements;

[ExpressType("IfcRelCoversSpaces", 17)]
public class IfcRelCoversSpaces : IfcRelConnects, IIfcRelCoversSpaces, IIfcRelConnects, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelCoversSpaces>
{
	private IfcSpace _relatingSpace;

	private readonly ItemSet<IfcCovering> _relatedCoverings;

	[CrossSchemaAttribute(typeof(IIfcRelCoversSpaces), 5)]
	IIfcSpace IIfcRelCoversSpaces.RelatingSpace
	{
		get
		{
			return RelatingSpace;
		}
		set
		{
			RelatingSpace = value as IfcSpace;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcRelCoversSpaces), 6)]
	IItemSet<IIfcCovering> IIfcRelCoversSpaces.RelatedCoverings => new ProxyItemSet<IfcCovering, IIfcCovering>(RelatedCoverings);

	[IndexedProperty]
	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcSpace RelatingSpace
	{
		get
		{
			if (_activated)
			{
				return _relatingSpace;
			}
			Activate();
			return _relatingSpace;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcSpace v)
			{
				_relatingSpace = v;
			}, _relatingSpace, value, "RelatingSpace", 5);
		}
	}

	[IndexedProperty]
	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 6)]
	public IItemSet<IfcCovering> RelatedCoverings
	{
		get
		{
			if (_activated)
			{
				return _relatedCoverings;
			}
			Activate();
			return _relatedCoverings;
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
			if (RelatingSpace != null)
			{
				yield return RelatingSpace;
			}
			foreach (IfcCovering relatedCovering in RelatedCoverings)
			{
				yield return relatedCovering;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (RelatingSpace != null)
			{
				yield return RelatingSpace;
			}
			foreach (IfcCovering relatedCovering in RelatedCoverings)
			{
				yield return relatedCovering;
			}
		}
	}

	internal IfcRelCoversSpaces(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_relatedCoverings = new ItemSet<IfcCovering>(this, 0, 6);
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
			_relatingSpace = (IfcSpace)value.EntityVal;
			break;
		case 5:
			_relatedCoverings.InternalAdd((IfcCovering)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelCoversSpaces other)
	{
		return this == other;
	}
}
