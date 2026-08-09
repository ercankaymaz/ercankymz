using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.RepresentationResource;

[ExpressType("IfcCoordinateReferenceSystem", 1144)]
public abstract class IfcCoordinateReferenceSystem : PersistEntity, IIfcCoordinateReferenceSystem, IPersistEntity, IPersist, IfcCoordinateReferenceSystemSelect, IIfcCoordinateReferenceSystemSelect, IExpressSelectType, IEquatable<IfcCoordinateReferenceSystem>
{
	private IfcLabel _name;

	private IfcText? _description;

	private IfcIdentifier? _geodeticDatum;

	private IfcIdentifier? _verticalDatum;

	IfcLabel IIfcCoordinateReferenceSystem.Name
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

	IfcText? IIfcCoordinateReferenceSystem.Description
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

	IfcIdentifier? IIfcCoordinateReferenceSystem.GeodeticDatum
	{
		get
		{
			return GeodeticDatum;
		}
		set
		{
			GeodeticDatum = value;
		}
	}

	IfcIdentifier? IIfcCoordinateReferenceSystem.VerticalDatum
	{
		get
		{
			return VerticalDatum;
		}
		set
		{
			VerticalDatum = value;
		}
	}

	IEnumerable<IIfcCoordinateOperation> IIfcCoordinateReferenceSystem.HasCoordinateOperation => HasCoordinateOperation;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
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

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public IfcIdentifier? GeodeticDatum
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
			SetValue(delegate(IfcIdentifier? v)
			{
				_geodeticDatum = v;
			}, _geodeticDatum, value, "GeodeticDatum", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public IfcIdentifier? VerticalDatum
	{
		get
		{
			if (_activated)
			{
				return _verticalDatum;
			}
			Activate();
			return _verticalDatum;
		}
		set
		{
			SetValue(delegate(IfcIdentifier? v)
			{
				_verticalDatum = v;
			}, _verticalDatum, value, "VerticalDatum", 4);
		}
	}

	[InverseProperty("SourceCRS")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 5)]
	public IEnumerable<IfcCoordinateOperation> HasCoordinateOperation => base.Model.Instances.Where((IfcCoordinateOperation e) => Equals(e.SourceCRS), "SourceCRS", this);

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
		case 3:
			_verticalDatum = value.StringVal;
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
