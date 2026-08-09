using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.ExternalReferenceResource;

namespace Xbim.Ifc2x3.TimeSeriesResource;

[ExpressType("IfcTimeSeriesReferenceRelationship", 673)]
public class IfcTimeSeriesReferenceRelationship : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcTimeSeriesReferenceRelationship>
{
	private IfcTimeSeries _referencedTimeSeries;

	private readonly ItemSet<IfcDocumentSelect> _timeSeriesReferences;

	[IndexedProperty]
	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 1)]
	public IfcTimeSeries ReferencedTimeSeries
	{
		get
		{
			if (_activated)
			{
				return _referencedTimeSeries;
			}
			Activate();
			return _referencedTimeSeries;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcTimeSeries v)
			{
				_referencedTimeSeries = v;
			}, _referencedTimeSeries, value, "ReferencedTimeSeries", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 2)]
	public IItemSet<IfcDocumentSelect> TimeSeriesReferences
	{
		get
		{
			if (_activated)
			{
				return _timeSeriesReferences;
			}
			Activate();
			return _timeSeriesReferences;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (ReferencedTimeSeries != null)
			{
				yield return ReferencedTimeSeries;
			}
			foreach (IfcDocumentSelect timeSeriesReference in TimeSeriesReferences)
			{
				yield return timeSeriesReference;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (ReferencedTimeSeries != null)
			{
				yield return ReferencedTimeSeries;
			}
		}
	}

	internal IfcTimeSeriesReferenceRelationship(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_timeSeriesReferences = new ItemSet<IfcDocumentSelect>(this, 0, 2);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_referencedTimeSeries = (IfcTimeSeries)value.EntityVal;
			break;
		case 1:
			_timeSeriesReferences.InternalAdd((IfcDocumentSelect)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcTimeSeriesReferenceRelationship other)
	{
		return this == other;
	}
}
