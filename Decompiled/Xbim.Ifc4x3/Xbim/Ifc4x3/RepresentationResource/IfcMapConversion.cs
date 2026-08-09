using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.RepresentationResource;

[ExpressType("IfcMapConversion", 1200)]
public class IfcMapConversion : IfcCoordinateOperation, IIfcMapConversion, IIfcCoordinateOperation, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcMapConversion>
{
	private Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure _eastings;

	private Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure _northings;

	private Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure _orthogonalHeight;

	private Xbim.Ifc4x3.MeasureResource.IfcReal? _xAxisAbscissa;

	private Xbim.Ifc4x3.MeasureResource.IfcReal? _xAxisOrdinate;

	private Xbim.Ifc4x3.MeasureResource.IfcReal? _scale;

	[CrossSchemaAttribute(typeof(IIfcMapConversion), 3)]
	Xbim.Ifc4.MeasureResource.IfcLengthMeasure IIfcMapConversion.Eastings
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcLengthMeasure(Eastings);
		}
		set
		{
			Eastings = new Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcMapConversion), 4)]
	Xbim.Ifc4.MeasureResource.IfcLengthMeasure IIfcMapConversion.Northings
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcLengthMeasure(Northings);
		}
		set
		{
			Northings = new Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcMapConversion), 5)]
	Xbim.Ifc4.MeasureResource.IfcLengthMeasure IIfcMapConversion.OrthogonalHeight
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcLengthMeasure(OrthogonalHeight);
		}
		set
		{
			OrthogonalHeight = new Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcMapConversion), 6)]
	Xbim.Ifc4.MeasureResource.IfcReal? IIfcMapConversion.XAxisAbscissa
	{
		get
		{
			if (!XAxisAbscissa.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcReal(XAxisAbscissa.Value);
		}
		set
		{
			XAxisAbscissa = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcReal?(new Xbim.Ifc4x3.MeasureResource.IfcReal(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcReal?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcMapConversion), 7)]
	Xbim.Ifc4.MeasureResource.IfcReal? IIfcMapConversion.XAxisOrdinate
	{
		get
		{
			if (!XAxisOrdinate.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcReal(XAxisOrdinate.Value);
		}
		set
		{
			XAxisOrdinate = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcReal?(new Xbim.Ifc4x3.MeasureResource.IfcReal(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcReal?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcMapConversion), 8)]
	Xbim.Ifc4.MeasureResource.IfcReal? IIfcMapConversion.Scale
	{
		get
		{
			if (!Scale.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcReal(Scale.Value);
		}
		set
		{
			Scale = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcReal?(new Xbim.Ifc4x3.MeasureResource.IfcReal(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcReal?)null));
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure Eastings
	{
		get
		{
			if (_activated)
			{
				return _eastings;
			}
			Activate();
			return _eastings;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure v)
			{
				_eastings = v;
			}, _eastings, value, "Eastings", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure Northings
	{
		get
		{
			if (_activated)
			{
				return _northings;
			}
			Activate();
			return _northings;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure v)
			{
				_northings = v;
			}, _northings, value, "Northings", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure OrthogonalHeight
	{
		get
		{
			if (_activated)
			{
				return _orthogonalHeight;
			}
			Activate();
			return _orthogonalHeight;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure v)
			{
				_orthogonalHeight = v;
			}, _orthogonalHeight, value, "OrthogonalHeight", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public Xbim.Ifc4x3.MeasureResource.IfcReal? XAxisAbscissa
	{
		get
		{
			if (_activated)
			{
				return _xAxisAbscissa;
			}
			Activate();
			return _xAxisAbscissa;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcReal? v)
			{
				_xAxisAbscissa = v;
			}, _xAxisAbscissa, value, "XAxisAbscissa", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public Xbim.Ifc4x3.MeasureResource.IfcReal? XAxisOrdinate
	{
		get
		{
			if (_activated)
			{
				return _xAxisOrdinate;
			}
			Activate();
			return _xAxisOrdinate;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcReal? v)
			{
				_xAxisOrdinate = v;
			}, _xAxisOrdinate, value, "XAxisOrdinate", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public Xbim.Ifc4x3.MeasureResource.IfcReal? Scale
	{
		get
		{
			if (_activated)
			{
				return _scale;
			}
			Activate();
			return _scale;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcReal? v)
			{
				_scale = v;
			}, _scale, value, "Scale", 8);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.SourceCRS != null)
			{
				yield return base.SourceCRS;
			}
			if (base.TargetCRS != null)
			{
				yield return base.TargetCRS;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (base.SourceCRS != null)
			{
				yield return base.SourceCRS;
			}
		}
	}

	internal IfcMapConversion(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 2:
			_eastings = value.RealVal;
			break;
		case 3:
			_northings = value.RealVal;
			break;
		case 4:
			_orthogonalHeight = value.RealVal;
			break;
		case 5:
			_xAxisAbscissa = value.RealVal;
			break;
		case 6:
			_xAxisOrdinate = value.RealVal;
			break;
		case 7:
			_scale = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcMapConversion other)
	{
		return this == other;
	}
}
