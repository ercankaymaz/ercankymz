using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.RepresentationResource;

[ExpressType("IfcMapConversionScaled", 1457)]
public class IfcMapConversionScaled : IfcMapConversion, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcMapConversionScaled>
{
	private IfcReal _factorX;

	private IfcReal _factorY;

	private IfcReal _factorZ;

	[EntityAttribute(9, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 9)]
	public IfcReal FactorX
	{
		get
		{
			if (_activated)
			{
				return _factorX;
			}
			Activate();
			return _factorX;
		}
		set
		{
			SetValue(delegate(IfcReal v)
			{
				_factorX = v;
			}, _factorX, value, "FactorX", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 10)]
	public IfcReal FactorY
	{
		get
		{
			if (_activated)
			{
				return _factorY;
			}
			Activate();
			return _factorY;
		}
		set
		{
			SetValue(delegate(IfcReal v)
			{
				_factorY = v;
			}, _factorY, value, "FactorY", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 11)]
	public IfcReal FactorZ
	{
		get
		{
			if (_activated)
			{
				return _factorZ;
			}
			Activate();
			return _factorZ;
		}
		set
		{
			SetValue(delegate(IfcReal v)
			{
				_factorZ = v;
			}, _factorZ, value, "FactorZ", 11);
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

	internal IfcMapConversionScaled(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
		case 2:
		case 3:
		case 4:
		case 5:
		case 6:
		case 7:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 8:
			_factorX = value.RealVal;
			break;
		case 9:
			_factorY = value.RealVal;
			break;
		case 10:
			_factorZ = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcMapConversionScaled other)
	{
		return this == other;
	}
}
