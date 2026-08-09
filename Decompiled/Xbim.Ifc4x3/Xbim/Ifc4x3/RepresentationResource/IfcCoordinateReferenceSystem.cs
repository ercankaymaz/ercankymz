using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.RepresentationResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.RepresentationResource;

[ExpressType("IfcCoordinateReferenceSystem", 1144)]
public abstract class IfcCoordinateReferenceSystem : PersistEntity, IIfcCoordinateReferenceSystem, IPersistEntity, IPersist, Xbim.Ifc4.RepresentationResource.IfcCoordinateReferenceSystemSelect, IIfcCoordinateReferenceSystemSelect, IExpressSelectType, IfcCoordinateReferenceSystemSelect, IEquatable<IfcCoordinateReferenceSystem>
{
	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _name;

	private Xbim.Ifc4x3.MeasureResource.IfcText? _description;

	private Xbim.Ifc4x3.MeasureResource.IfcIdentifier? _geodeticDatum;

	[CrossSchemaAttribute(typeof(IIfcCoordinateReferenceSystem), 1)]
	Xbim.Ifc4.MeasureResource.IfcLabel IIfcCoordinateReferenceSystem.Name
	{
		get
		{
			if (!Name.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Name.Value);
		}
		set
		{
			Name = new Xbim.Ifc4x3.MeasureResource.IfcLabel(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcCoordinateReferenceSystem), 2)]
	Xbim.Ifc4.MeasureResource.IfcText? IIfcCoordinateReferenceSystem.Description
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

	[CrossSchemaAttribute(typeof(IIfcCoordinateReferenceSystem), 3)]
	Xbim.Ifc4.MeasureResource.IfcIdentifier? IIfcCoordinateReferenceSystem.GeodeticDatum
	{
		get
		{
			if (!GeodeticDatum.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcIdentifier(GeodeticDatum.Value);
		}
		set
		{
			GeodeticDatum = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcIdentifier?(new Xbim.Ifc4x3.MeasureResource.IfcIdentifier(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcIdentifier?)null));
		}
	}

	IEnumerable<IIfcCoordinateOperation> IIfcCoordinateReferenceSystem.HasCoordinateOperation => base.Model.Instances.Where((IIfcCoordinateOperation e) => e.SourceCRS as IfcCoordinateReferenceSystem == this, "SourceCRS", this);

	[CrossSchemaAttribute(typeof(IIfcCoordinateReferenceSystem), 4)]
	Xbim.Ifc4.MeasureResource.IfcIdentifier? IIfcCoordinateReferenceSystem.VerticalDatum
	{
		get
		{
			if (this is IfcProjectedCRS { VerticalDatum: not null, VerticalDatum: var verticalDatum })
			{
				return new Xbim.Ifc4.MeasureResource.IfcIdentifier(verticalDatum.ToString());
			}
			return null;
		}
		set
		{
			if (this is IfcProjectedCRS ifcProjectedCRS && value.HasValue)
			{
				ifcProjectedCRS.VerticalDatum = value.ToString();
				NotifyPropertyChanged("VerticalDatum");
			}
		}
	}

	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? Name
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
			{
				_name = v;
			}, _name, value, "Name", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
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
			}, _description, value, "Description", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public Xbim.Ifc4x3.MeasureResource.IfcIdentifier? GeodeticDatum
	{
		get
		{
			if (_activated)
			{
				return _geodeticDatum;
			}
			Activate();
			return _geodeticDatum;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcIdentifier? v)
			{
				_geodeticDatum = v;
			}, _geodeticDatum, value, "GeodeticDatum", 3);
		}
	}

	[InverseProperty("SourceCRS")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 4)]
	public IEnumerable<IfcCoordinateOperation> HasCoordinateOperation => base.Model.Instances.Where((IfcCoordinateOperation e) => Equals(e.SourceCRS), "SourceCRS", this);

	[InverseProperty("CoordinateReferenceSystem")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 5)]
	public IEnumerable<IfcWellKnownText> WellKnownText => base.Model.Instances.Where((IfcWellKnownText e) => Equals(e.CoordinateReferenceSystem), "CoordinateReferenceSystem", this);

	internal IfcCoordinateReferenceSystem(IModel model, int label, bool activated)
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
			_geodeticDatum = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcCoordinateReferenceSystem other)
	{
		return this == other;
	}
}
