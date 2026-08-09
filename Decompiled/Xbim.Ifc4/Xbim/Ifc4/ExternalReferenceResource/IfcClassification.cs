using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.ExternalReferenceResource;

[ExpressType("IfcClassification", 412)]
public class IfcClassification : IfcExternalInformation, IInstantiableEntity, IPersistEntity, IPersist, IIfcClassification, IIfcExternalInformation, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IfcClassificationReferenceSelect, IIfcClassificationReferenceSelect, IfcClassificationSelect, IIfcClassificationSelect, IEquatable<IfcClassification>
{
	private IfcLabel? _source;

	private IfcLabel? _edition;

	private IfcDate? _editionDate;

	private IfcLabel _name;

	private IfcText? _description;

	private IfcURIReference? _location;

	private readonly OptionalItemSet<IfcIdentifier> _referenceTokens;

	IfcLabel? IIfcClassification.Source
	{
		get
		{
			return Source;
		}
		set
		{
			Source = value;
		}
	}

	IfcLabel? IIfcClassification.Edition
	{
		get
		{
			return Edition;
		}
		set
		{
			Edition = value;
		}
	}

	IfcDate? IIfcClassification.EditionDate
	{
		get
		{
			return EditionDate;
		}
		set
		{
			EditionDate = value;
		}
	}

	IfcLabel IIfcClassification.Name
	{
		get
		{
			return Name;
		}
		set
		{
			Name = value;
		}
	}

	IfcText? IIfcClassification.Description
	{
		get
		{
			return Description;
		}
		set
		{
			Description = value;
		}
	}

	IfcURIReference? IIfcClassification.Location
	{
		get
		{
			return Location;
		}
		set
		{
			Location = value;
		}
	}

	IItemSet<IfcIdentifier> IIfcClassification.ReferenceTokens => ReferenceTokens;

	IEnumerable<IIfcRelAssociatesClassification> IIfcClassification.ClassificationForObjects => ClassificationForObjects;

	IEnumerable<IIfcClassificationReference> IIfcClassification.HasReferences => HasReferences;

	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public IfcLabel? Source
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
			SetValue(delegate(IfcLabel? v)
			{
				_source = v;
			}, _source, value, "Source", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public IfcLabel? Edition
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
			SetValue(delegate(IfcLabel? v)
			{
				_edition = v;
			}, _edition, value, "Edition", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public IfcDate? EditionDate
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
			SetValue(delegate(IfcDate? v)
			{
				_editionDate = v;
			}, _editionDate, value, "EditionDate", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public IfcLabel Name
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
			SetValue(delegate(IfcLabel v)
			{
				_name = v;
			}, _name, value, "Name", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
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
			}, _description, value, "Description", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcURIReference? Location
	{
		get
		{
			if (_activated)
			{
				return _location;
			}
			Activate();
			return _location;
		}
		set
		{
			SetValue(delegate(IfcURIReference? v)
			{
				_location = v;
			}, _location, value, "Location", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.None, new int[] { 1 }, new int[] { -1 }, 7)]
	public IOptionalItemSet<IfcIdentifier> ReferenceTokens
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

	internal IfcClassification(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_referenceTokens = new OptionalItemSet<IfcIdentifier>(this, 0, 7);
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
			_location = value.StringVal;
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
