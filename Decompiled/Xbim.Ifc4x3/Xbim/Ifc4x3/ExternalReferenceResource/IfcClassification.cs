using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.DateTimeResource;
using Xbim.Ifc4x3.Kernel;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.ExternalReferenceResource;

[ExpressType("IfcClassification", 412)]
public class IfcClassification : IfcExternalInformation, IInstantiableEntity, IPersistEntity, IPersist, IfcClassificationReferenceSelect, IExpressSelectType, IIfcClassificationReferenceSelect, IfcClassificationSelect, IIfcClassificationSelect, IEquatable<IfcClassification>, IIfcClassification, IIfcExternalInformation, Xbim.Ifc4.ExternalReferenceResource.IfcResourceObjectSelect, IIfcResourceObjectSelect, Xbim.Ifc4.ExternalReferenceResource.IfcClassificationReferenceSelect, Xbim.Ifc4.ExternalReferenceResource.IfcClassificationSelect
{
	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _source;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _edition;

	private Xbim.Ifc4x3.DateTimeResource.IfcDate? _editionDate;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel _name;

	private Xbim.Ifc4x3.MeasureResource.IfcText? _description;

	private Xbim.Ifc4x3.MeasureResource.IfcURIReference? _specification;

	private readonly OptionalItemSet<Xbim.Ifc4x3.MeasureResource.IfcIdentifier> _referenceTokens;

	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? Source
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
			{
				_source = v;
			}, _source, value, "Source", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? Edition
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
			{
				_edition = v;
			}, _edition, value, "Edition", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public Xbim.Ifc4x3.DateTimeResource.IfcDate? EditionDate
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
			SetValue(delegate(Xbim.Ifc4x3.DateTimeResource.IfcDate? v)
			{
				_editionDate = v;
			}, _editionDate, value, "EditionDate", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel Name
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel v)
			{
				_name = v;
			}, _name, value, "Name", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public Xbim.Ifc4x3.MeasureResource.IfcText? Description
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcText? v)
			{
				_description = v;
			}, _description, value, "Description", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public Xbim.Ifc4x3.MeasureResource.IfcURIReference? Specification
	{
		get
		{
			if (_activated)
			{
				return _specification;
			}
			Activate();
			return _specification;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcURIReference? v)
			{
				_specification = v;
			}, _specification, value, "Specification", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.None, new int[] { 1 }, new int[] { -1 }, 7)]
	public IOptionalItemSet<Xbim.Ifc4x3.MeasureResource.IfcIdentifier> ReferenceTokens
	{
		get
		{
			if (_activated)
			{
				return _referenceTokens;
			}
			Activate();
			return _referenceTokens;
		}
	}

	[InverseProperty("RelatingClassification")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 8)]
	public IEnumerable<IfcRelAssociatesClassification> ClassificationForObjects => base.Model.Instances.Where((IfcRelAssociatesClassification e) => Equals(e.RelatingClassification), "RelatingClassification", this);

	[InverseProperty("ReferencedSource")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 9)]
	public IEnumerable<IfcClassificationReference> HasReferences => base.Model.Instances.Where((IfcClassificationReference e) => Equals(e.ReferencedSource), "ReferencedSource", this);

	[CrossSchemaAttribute(typeof(IIfcClassification), 1)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcClassification.Source
	{
		get
		{
			if (!Source.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Source.Value);
		}
		set
		{
			Source = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcClassification), 2)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcClassification.Edition
	{
		get
		{
			if (!Edition.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Edition.Value);
		}
		set
		{
			Edition = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcClassification), 3)]
	Xbim.Ifc4.DateTimeResource.IfcDate? IIfcClassification.EditionDate
	{
		get
		{
			if (!EditionDate.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.DateTimeResource.IfcDate(EditionDate.Value);
		}
		set
		{
			EditionDate = (value.HasValue ? new Xbim.Ifc4x3.DateTimeResource.IfcDate?(new Xbim.Ifc4x3.DateTimeResource.IfcDate(value.Value)) : ((Xbim.Ifc4x3.DateTimeResource.IfcDate?)null));
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
			Name = new Xbim.Ifc4x3.MeasureResource.IfcLabel(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcClassification), 5)]
	Xbim.Ifc4.MeasureResource.IfcText? IIfcClassification.Description
	{
		get
		{
			if (!Description.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcText(Description.Value);
		}
		set
		{
			Description = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcText?(new Xbim.Ifc4x3.MeasureResource.IfcText(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcText?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcClassification), 6)]
	Xbim.Ifc4.ExternalReferenceResource.IfcURIReference? IIfcClassification.Location
	{
		get
		{
			if (!Specification.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.ExternalReferenceResource.IfcURIReference(Specification.Value);
		}
		set
		{
			Specification = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcURIReference?(new Xbim.Ifc4x3.MeasureResource.IfcURIReference(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcURIReference?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcClassification), 7)]
	IItemSet<Xbim.Ifc4.MeasureResource.IfcIdentifier> IIfcClassification.ReferenceTokens => new ProxyValueSet<Xbim.Ifc4x3.MeasureResource.IfcIdentifier, Xbim.Ifc4.MeasureResource.IfcIdentifier>(ReferenceTokens, (Xbim.Ifc4x3.MeasureResource.IfcIdentifier s) => new Xbim.Ifc4.MeasureResource.IfcIdentifier(s), (Xbim.Ifc4.MeasureResource.IfcIdentifier t) => new Xbim.Ifc4x3.MeasureResource.IfcIdentifier(t));

	IEnumerable<IIfcRelAssociatesClassification> IIfcClassification.ClassificationForObjects => base.Model.Instances.Where((IIfcRelAssociatesClassification e) => e.RelatingClassification as IfcClassification == this, "RelatingClassification", this);

	IEnumerable<IIfcClassificationReference> IIfcClassification.HasReferences => base.Model.Instances.Where((IIfcClassificationReference e) => e.ReferencedSource as IfcClassification == this, "ReferencedSource", this);

	internal IfcClassification(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_referenceTokens = new OptionalItemSet<Xbim.Ifc4x3.MeasureResource.IfcIdentifier>(this, 0, 7);
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
			_editionDate = value.StringVal;
			break;
		case 3:
			_name = value.StringVal;
			break;
		case 4:
			_description = value.StringVal;
			break;
		case 5:
			_specification = value.StringVal;
			break;
		case 6:
			_referenceTokens.InternalAdd(value.StringVal);
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
