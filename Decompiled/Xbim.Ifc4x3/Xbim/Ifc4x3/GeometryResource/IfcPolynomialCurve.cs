using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.GeometryResource;

[ExpressType("IfcPolynomialCurve", 1470)]
public class IfcPolynomialCurve : IfcCurve, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcPolynomialCurve>
{
	private IfcPlacement _position;

	private readonly OptionalItemSet<IfcReal> _coefficientsX;

	private readonly OptionalItemSet<IfcReal> _coefficientsY;

	private readonly OptionalItemSet<IfcReal> _coefficientsZ;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcPlacement Position
	{
		get
		{
			if (_activated)
			{
				return _position;
			}
			Activate();
			return _position;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcPlacement v)
			{
				_position = v;
			}, _position, value, "Position", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.None, new int[] { 2 }, new int[] { -1 }, 4)]
	public IOptionalItemSet<IfcReal> CoefficientsX
	{
		get
		{
			if (_activated)
			{
				return _coefficientsX;
			}
			Activate();
			return _coefficientsX;
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.None, new int[] { 2 }, new int[] { -1 }, 5)]
	public IOptionalItemSet<IfcReal> CoefficientsY
	{
		get
		{
			if (_activated)
			{
				return _coefficientsY;
			}
			Activate();
			return _coefficientsY;
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.None, new int[] { 2 }, new int[] { -1 }, 6)]
	public IOptionalItemSet<IfcReal> CoefficientsZ
	{
		get
		{
			if (_activated)
			{
				return _coefficientsZ;
			}
			Activate();
			return _coefficientsZ;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (Position != null)
			{
				yield return Position;
			}
		}
	}

	internal IfcPolynomialCurve(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_coefficientsX = new OptionalItemSet<IfcReal>(this, 0, 2);
		_coefficientsY = new OptionalItemSet<IfcReal>(this, 0, 3);
		_coefficientsZ = new OptionalItemSet<IfcReal>(this, 0, 4);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_position = (IfcPlacement)value.EntityVal;
			break;
		case 1:
			_coefficientsX.InternalAdd(value.RealVal);
			break;
		case 2:
			_coefficientsY.InternalAdd(value.RealVal);
			break;
		case 3:
			_coefficientsZ.InternalAdd(value.RealVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcPolynomialCurve other)
	{
		return this == other;
	}
}
