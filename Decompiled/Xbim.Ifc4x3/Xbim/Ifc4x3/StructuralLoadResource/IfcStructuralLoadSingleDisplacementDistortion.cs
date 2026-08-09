using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.StructuralLoadResource;

[ExpressType("IfcStructuralLoadSingleDisplacementDistortion", 290)]
public class IfcStructuralLoadSingleDisplacementDistortion : IfcStructuralLoadSingleDisplacement, IIfcStructuralLoadSingleDisplacementDistortion, IIfcStructuralLoadSingleDisplacement, IIfcStructuralLoadStatic, IIfcStructuralLoadOrResult, IIfcStructuralLoad, IPersistEntity, IPersist, IInstantiableEntity, IEquatable<IfcStructuralLoadSingleDisplacementDistortion>
{
	private Xbim.Ifc4x3.MeasureResource.IfcCurvatureMeasure? _distortion;

	[CrossSchemaAttribute(typeof(IIfcStructuralLoadSingleDisplacementDistortion), 8)]
	Xbim.Ifc4.MeasureResource.IfcCurvatureMeasure? IIfcStructuralLoadSingleDisplacementDistortion.Distortion
	{
		get
		{
			if (!Distortion.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcCurvatureMeasure(Distortion.Value);
		}
		set
		{
			Distortion = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcCurvatureMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcCurvatureMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcCurvatureMeasure?)null));
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public Xbim.Ifc4x3.MeasureResource.IfcCurvatureMeasure? Distortion
	{
		get
		{
			if (_activated)
			{
				return _distortion;
			}
			Activate();
			return _distortion;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcCurvatureMeasure? v)
			{
				_distortion = v;
			}, _distortion, value, "Distortion", 8);
		}
	}

	internal IfcStructuralLoadSingleDisplacementDistortion(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 7:
			_distortion = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcStructuralLoadSingleDisplacementDistortion other)
	{
		return this == other;
	}
}
