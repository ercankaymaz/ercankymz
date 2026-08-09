using System;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.StructuralLoadResource;

[ExpressType("IfcSurfaceReinforcementArea", 1288)]
public class IfcSurfaceReinforcementArea : IfcStructuralLoadOrResult, IIfcSurfaceReinforcementArea, IIfcStructuralLoadOrResult, IIfcStructuralLoad, IPersistEntity, IPersist, IInstantiableEntity, IEquatable<IfcSurfaceReinforcementArea>
{
	private readonly OptionalItemSet<Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure> _surfaceReinforcement1;

	private readonly OptionalItemSet<Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure> _surfaceReinforcement2;

	private Xbim.Ifc4x3.MeasureResource.IfcRatioMeasure? _shearReinforcement;

	[CrossSchemaAttribute(typeof(IIfcSurfaceReinforcementArea), 2)]
	IItemSet<Xbim.Ifc4.MeasureResource.IfcLengthMeasure> IIfcSurfaceReinforcementArea.SurfaceReinforcement1 => new ProxyValueSet<Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure, Xbim.Ifc4.MeasureResource.IfcLengthMeasure>(SurfaceReinforcement1, (Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure s) => new Xbim.Ifc4.MeasureResource.IfcLengthMeasure(s), (Xbim.Ifc4.MeasureResource.IfcLengthMeasure t) => new Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure(t));

	[CrossSchemaAttribute(typeof(IIfcSurfaceReinforcementArea), 3)]
	IItemSet<Xbim.Ifc4.MeasureResource.IfcLengthMeasure> IIfcSurfaceReinforcementArea.SurfaceReinforcement2 => new ProxyValueSet<Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure, Xbim.Ifc4.MeasureResource.IfcLengthMeasure>(SurfaceReinforcement2, (Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure s) => new Xbim.Ifc4.MeasureResource.IfcLengthMeasure(s), (Xbim.Ifc4.MeasureResource.IfcLengthMeasure t) => new Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure(t));

	[CrossSchemaAttribute(typeof(IIfcSurfaceReinforcementArea), 4)]
	Xbim.Ifc4.MeasureResource.IfcRatioMeasure? IIfcSurfaceReinforcementArea.ShearReinforcement
	{
		get
		{
			if (!ShearReinforcement.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcRatioMeasure(ShearReinforcement.Value);
		}
		set
		{
			ShearReinforcement = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcRatioMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcRatioMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcRatioMeasure?)null));
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.None, new int[] { 2 }, new int[] { 3 }, 2)]
	public IOptionalItemSet<Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure> SurfaceReinforcement1
	{
		get
		{
			if (_activated)
			{
				return _surfaceReinforcement1;
			}
			Activate();
			return _surfaceReinforcement1;
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.None, new int[] { 2 }, new int[] { 3 }, 3)]
	public IOptionalItemSet<Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure> SurfaceReinforcement2
	{
		get
		{
			if (_activated)
			{
				return _surfaceReinforcement2;
			}
			Activate();
			return _surfaceReinforcement2;
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public Xbim.Ifc4x3.MeasureResource.IfcRatioMeasure? ShearReinforcement
	{
		get
		{
			if (_activated)
			{
				return _shearReinforcement;
			}
			Activate();
			return _shearReinforcement;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcRatioMeasure? v)
			{
				_shearReinforcement = v;
			}, _shearReinforcement, value, "ShearReinforcement", 4);
		}
	}

	internal IfcSurfaceReinforcementArea(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_surfaceReinforcement1 = new OptionalItemSet<Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure>(this, 3, 2);
		_surfaceReinforcement2 = new OptionalItemSet<Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure>(this, 3, 3);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 1:
			_surfaceReinforcement1.InternalAdd(value.RealVal);
			break;
		case 2:
			_surfaceReinforcement2.InternalAdd(value.RealVal);
			break;
		case 3:
			_shearReinforcement = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSurfaceReinforcementArea other)
	{
		return this == other;
	}
}
