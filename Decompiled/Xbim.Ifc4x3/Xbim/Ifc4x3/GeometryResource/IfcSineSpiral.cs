using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.GeometryResource;

[ExpressType("IfcSineSpiral", 1492)]
public class IfcSineSpiral : IfcSpiral, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcSineSpiral>
{
	private IfcLengthMeasure _sineTerm;

	private IfcLengthMeasure? _linearTerm;

	private IfcLengthMeasure? _constantTerm;

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public IfcLengthMeasure SineTerm
	{
		get
		{
			if (_activated)
			{
				return _sineTerm;
			}
			Activate();
			return _sineTerm;
		}
		set
		{
			SetValue(delegate(IfcLengthMeasure v)
			{
				_sineTerm = v;
			}, _sineTerm, value, "SineTerm", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
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
			}, _linearTerm, value, "LinearTerm", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
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
			}, _constantTerm, value, "ConstantTerm", 4);
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

	internal IfcSineSpiral(IModel model, int label, bool activated)
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
			_sineTerm = value.RealVal;
			break;
		case 2:
			_linearTerm = value.RealVal;
			break;
		case 3:
			_constantTerm = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSineSpiral other)
	{
		return this == other;
	}
}
