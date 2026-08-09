using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.DateTimeResource;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.ExternalReferenceResource;

[ExpressType("IfcClassification", 412)]
public class IfcClassification : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcClassification>, IIfcClassification, IIfcExternalInformation, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IfcClassificationReferenceSelect, IIfcClassificationReferenceSelect, IfcClassificationSelect, IIfcClassificationSelect
{
	private Xbim.Ifc2x3.MeasureResource.IfcLabel _source;

	private Xbim.Ifc2x3.MeasureResource.IfcLabel _edition;

	private IfcCalendarDate _editionDate;

	private Xbim.Ifc2x3.MeasureResource.IfcLabel _name;

	private Xbim.Ifc4.MeasureResource.IfcText? _description;

	private IfcURIReference? _location;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public Xbim.Ifc2x3.MeasureResource.IfcLabel Source
	{
		get
		{
			if (_activated)
			{
				return _source;
			}
			Activate();
			return _source;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel v)
			{
				_source = v;
			}, _source, value, "Source", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public Xbim.Ifc2x3.MeasureResource.IfcLabel Edition
	{
		get
		{
			if (_activated)
			{
				return _edition;
			}
			Activate();
			return _edition;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel v)
			{
				_edition = v;
			}, _edition, value, "Edition", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcCalendarDate EditionDate
	{
		get
		{
			if (_activated)
			{
				return _editionDate;
			}
			Activate();
			return _editionDate;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcCalendarDate v)
			{
				_editionDate = v;
			}, _editionDate, value, "EditionDate", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public Xbim.Ifc2x3.MeasureResource.IfcLabel Name
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel v)
			{
				_name = v;
			}, _name, value, "Name", 4);
		}
	}

	[InverseProperty("ItemOf")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 5)]
	public IEnumerable<IfcClassificationItem> Contains => base.Model.Instances.Where((IfcClassificationItem e) => Equals(e.ItemOf), "ItemOf", this);

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (EditionDate != null)
			{
				yield return EditionDate;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcClassification), 1)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcClassification.Source
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Source);
		}
		set
		{
			Source = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLabel(value.Value) : default(Xbim.Ifc2x3.MeasureResource.IfcLabel));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcClassification), 2)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcClassification.Edition
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Edition);
		}
		set
		{
			Edition = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLabel(value.Value) : default(Xbim.Ifc2x3.MeasureResource.IfcLabel));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcClassification), 3)]
	IfcDate? IIfcClassification.EditionDate
	{
		get
		{
			return (EditionDate == null) ? ((IfcDate)null) : new IfcDate(EditionDate.ToISODateTimeString());
		}
		set
		{
			if (!value.HasValue)
			{
				EditionDate = null;
				return;
			}
			DateTime date = value.Value;
			EditionDate = base.Model.Instances.New(delegate(IfcCalendarDate d)
			{
				d.YearComponent = date.Year;
				d.MonthComponent = date.Month;
				d.DayComponent = date.Day;
			});
		}
	}

	[CrossSchemaAttribute(typeof(IIfcClassification), 4)]
	Xbim.Ifc4.MeasureResource.IfcLabel IIfcClassification.Name
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Name);
		}
		set
		{
			Name = new Xbim.Ifc2x3.MeasureResource.IfcLabel(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcClassification), 5)]
	Xbim.Ifc4.MeasureResource.IfcText? IIfcClassification.Description
	{
		get
		{
			return _description;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4.MeasureResource.IfcText? v)
			{
				_description = v;
			}, _description, value, "Description", -5);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcClassification), 6)]
	IfcURIReference? IIfcClassification.Location
	{
		get
		{
			return _location;
		}
		set
		{
			SetValue(delegate(IfcURIReference? v)
			{
				_location = v;
			}, _location, value, "Location", -6);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcClassification), 7)]
	IItemSet<Xbim.Ifc4.MeasureResource.IfcIdentifier> IIfcClassification.ReferenceTokens => null;

	IEnumerable<IIfcRelAssociatesClassification> IIfcClassification.ClassificationForObjects => base.Model.Instances.Where((IIfcRelAssociatesClassification e) => e.RelatingClassification as IfcClassification == this, "RelatingClassification", this);

	IEnumerable<IIfcClassificationReference> IIfcClassification.HasReferences => base.Model.Instances.Where((IIfcClassificationReference e) => e.ReferencedSource as IfcClassification == this, "ReferencedSource", this);

	internal IfcClassification(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_source = value.StringVal;
			break;
		case 1:
			_edition = value.StringVal;
			break;
		case 2:
			_editionDate = (IfcCalendarDate)value.EntityVal;
			break;
		case 3:
			_name = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcClassification other)
	{
		return this == other;
	}
}
