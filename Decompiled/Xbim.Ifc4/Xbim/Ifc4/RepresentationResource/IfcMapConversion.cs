using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.RepresentationResource;

[ExpressType("IfcMapConversion", 1200)]
public class IfcMapConversion : IfcCoordinateOperation, IInstantiableEntity, IPersistEntity, IPersist, IIfcMapConversion, IIfcCoordinateOperation, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcMapConversion>
{
	private IfcLengthMeasure _eastings;

	private IfcLengthMeasure _northings;

	private IfcLengthMeasure _orthogonalHeight;

	private IfcReal? _xAxisAbscissa;

	private IfcReal? _xAxisOrdinate;

	private IfcReal? _scale;

	IfcLengthMeasure IIfcMapConversion.Eastings
	{
		get
		{
			return Eastings;
		}
		set
		{
			Eastings = value;
		}
	}

	IfcLengthMeasure IIfcMapConversion.Northings
	{
		get
		{
			return Northings;
		}
		set
		{
			Northings = value;
		}
	}

	IfcLengthMeasure IIfcMapConversion.OrthogonalHeight
	{
		get
		{
			return OrthogonalHeight;
		}
		set
		{
			OrthogonalHeight = value;
		}
	}

	IfcReal? IIfcMapConversion.XAxisAbscissa
	{
		get
		{
			return XAxisAbscissa;
		}
		set
		{
			XAxisAbscissa = value;
		}
	}

	IfcReal? IIfcMapConversion.XAxisOrdinate
	{
		get
		{
			return XAxisOrdinate;
		}
		set
		{
			XAxisOrdinate = value;
		}
	}

	IfcReal? IIfcMapConversion.Scale
	{
		get
		{
			return Scale;
		}
		set
		{
			Scale = value;
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public IfcLengthMeasure Eastings
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
			SetValue(delegate(IfcLengthMeasure v)
			{
				_eastings = v;
			}, _eastings, value, "Eastings", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public IfcLengthMeasure Northings
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
			SetValue(delegate(IfcLengthMeasure v)
			{
				_northings = v;
			}, _northings, value, "Northings", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public IfcLengthMeasure OrthogonalHeight
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
			SetValue(delegate(IfcLengthMeasure v)
			{
				_orthogonalHeight = v;
			}, _orthogonalHeight, value, "OrthogonalHeight", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcReal? XAxisAbscissa
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
			SetValue(delegate(IfcReal? v)
			{
				_xAxisAbscissa = v;
			}, _xAxisAbscissa, value, "XAxisAbscissa", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public IfcReal? XAxisOrdinate
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
			SetValue(delegate(IfcReal? v)
			{
				_xAxisOrdinate = v;
			}, _xAxisOrdinate, value, "XAxisOrdinate", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public IfcReal? Scale
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
			SetValue(delegate(IfcReal? v)
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
