using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.GeometryResource;

[ExpressType("IfcCosineSpiral", 1424)]
public class IfcCosineSpiral : IfcSpiral, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcCosineSpiral>
{
	private IfcLengthMeasure _cosineTerm;

	private IfcLengthMeasure? _constantTerm;

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public IfcLengthMeasure CosineTerm
	{
		get
		{
			if (_activated)
			{
				return _cosineTerm;
			}
			Activate();
			return _cosineTerm;
		}
		set
		{
			SetValue(delegate(IfcLengthMeasure v)
			{
				_cosineTerm = v;
			}, _cosineTerm, value, "CosineTerm", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
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
			}, _constantTerm, value, "ConstantTerm", 3);
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

	internal IfcCosineSpiral(IModel model, int label, bool activated)
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
			_cosineTerm = value.RealVal;
			break;
		case 2:
			_constantTerm = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcCosineSpiral other)
	{
		return this == other;
	}
}
