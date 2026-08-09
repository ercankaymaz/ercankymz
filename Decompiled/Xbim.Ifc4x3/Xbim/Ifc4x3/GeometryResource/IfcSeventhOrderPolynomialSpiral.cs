using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.GeometryResource;

[ExpressType("IfcSeventhOrderPolynomialSpiral", 1487)]
public class IfcSeventhOrderPolynomialSpiral : IfcSpiral, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcSeventhOrderPolynomialSpiral>
{
	private IfcLengthMeasure _septicTerm;

	private IfcLengthMeasure? _sexticTerm;

	private IfcLengthMeasure? _quinticTerm;

	private IfcLengthMeasure? _quarticTerm;

	private IfcLengthMeasure? _cubicTerm;

	private IfcLengthMeasure? _quadraticTerm;

	private IfcLengthMeasure? _linearTerm;

	private IfcLengthMeasure? _constantTerm;

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public IfcLengthMeasure SepticTerm
	{
		get
		{
			if (_activated)
			{
				return _septicTerm;
			}
			Activate();
			return _septicTerm;
		}
		set
		{
			SetValue(delegate(IfcLengthMeasure v)
			{
				_septicTerm = v;
			}, _septicTerm, value, "SepticTerm", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public IfcLengthMeasure? SexticTerm
	{
		get
		{
			if (_activated)
			{
				return _sexticTerm;
			}
			Activate();
			return _sexticTerm;
		}
		set
		{
			SetValue(delegate(IfcLengthMeasure? v)
			{
				_sexticTerm = v;
			}, _sexticTerm, value, "SexticTerm", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcLengthMeasure? QuinticTerm
	{
		get
		{
			if (_activated)
			{
				return _quinticTerm;
			}
			Activate();
			return _quinticTerm;
		}
		set
		{
			SetValue(delegate(IfcLengthMeasure? v)
			{
				_quinticTerm = v;
			}, _quinticTerm, value, "QuinticTerm", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public IfcLengthMeasure? QuarticTerm
	{
		get
		{
			if (_activated)
			{
				return _quarticTerm;
			}
			Activate();
			return _quarticTerm;
		}
		set
		{
			SetValue(delegate(IfcLengthMeasure? v)
			{
				_quarticTerm = v;
			}, _quarticTerm, value, "QuarticTerm", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public IfcLengthMeasure? CubicTerm
	{
		get
		{
			if (_activated)
			{
				return _cubicTerm;
			}
			Activate();
			return _cubicTerm;
		}
		set
		{
			SetValue(delegate(IfcLengthMeasure? v)
			{
				_cubicTerm = v;
			}, _cubicTerm, value, "CubicTerm", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 9)]
	public IfcLengthMeasure? QuadraticTerm
	{
		get
		{
			if (_activated)
			{
				return _quadraticTerm;
			}
			Activate();
			return _quadraticTerm;
		}
		set
		{
			SetValue(delegate(IfcLengthMeasure? v)
			{
				_quadraticTerm = v;
			}, _quadraticTerm, value, "QuadraticTerm", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 10)]
	public IfcLengthMeasure? LinearTerm
	{
		get
		{
			if (_activated)
			{
				return _linearTerm;
			}
			Activate();
			return _linearTerm;
		}
		set
		{
			SetValue(delegate(IfcLengthMeasure? v)
			{
				_linearTerm = v;
			}, _linearTerm, value, "LinearTerm", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 11)]
	public IfcLengthMeasure? ConstantTerm
	{
		get
		{
			if (_activated)
			{
				return _constantTerm;
			}
			Activate();
			return _constantTerm;
		}
		set
		{
			SetValue(delegate(IfcLengthMeasure? v)
			{
				_constantTerm = v;
			}, _constantTerm, value, "ConstantTerm", 9);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.Position != null)
			{
				yield return base.Position;
			}
		}
	}

	internal IfcSeventhOrderPolynomialSpiral(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 1:
			_septicTerm = value.RealVal;
			break;
		case 2:
			_sexticTerm = value.RealVal;
			break;
		case 3:
			_quinticTerm = value.RealVal;
			break;
		case 4:
			_quarticTerm = value.RealVal;
			break;
		case 5:
			_cubicTerm = value.RealVal;
			break;
		case 6:
			_quadraticTerm = value.RealVal;
			break;
		case 7:
			_linearTerm = value.RealVal;
			break;
		case 8:
			_constantTerm = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSeventhOrderPolynomialSpiral other)
	{
		return this == other;
	}
}
