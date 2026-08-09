using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.RepresentationResource;

[ExpressType("IfcRigidOperation", 1480)]
public class IfcRigidOperation : IfcCoordinateOperation, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRigidOperation>
{
	private IfcMeasureValue _firstCoordinate;

	private IfcMeasureValue _secondCoordinate;

	private IfcLengthMeasure? _height;

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcMeasureValue FirstCoordinate
	{
		get
		{
			if (_activated)
			{
				return _firstCoordinate;
			}
			Activate();
			return _firstCoordinate;
		}
		set
		{
			SetValue(delegate(IfcMeasureValue v)
			{
				_firstCoordinate = v;
			}, _firstCoordinate, value, "FirstCoordinate", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
	public IfcMeasureValue SecondCoordinate
	{
		get
		{
			if (_activated)
			{
				return _secondCoordinate;
			}
			Activate();
			return _secondCoordinate;
		}
		set
		{
			SetValue(delegate(IfcMeasureValue v)
			{
				_secondCoordinate = v;
			}, _secondCoordinate, value, "SecondCoordinate", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public IfcLengthMeasure? Height
	{
		get
		{
			if (_activated)
			{
				return _height;
			}
			Activate();
			return _height;
		}
		set
		{
			SetValue(delegate(IfcLengthMeasure? v)
			{
				_height = v;
			}, _height, value, "Height", 5);
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

	internal IfcRigidOperation(IModel model, int label, bool activated)
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
			_firstCoordinate = (IfcMeasureValue)value.EntityVal;
			break;
		case 3:
			_secondCoordinate = (IfcMeasureValue)value.EntityVal;
			break;
		case 4:
			_height = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRigidOperation other)
	{
		return this == other;
	}
}
