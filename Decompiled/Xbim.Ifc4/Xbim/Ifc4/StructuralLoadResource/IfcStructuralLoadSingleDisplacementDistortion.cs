using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.StructuralLoadResource;

[ExpressType("IfcStructuralLoadSingleDisplacementDistortion", 290)]
public class IfcStructuralLoadSingleDisplacementDistortion : IfcStructuralLoadSingleDisplacement, IInstantiableEntity, IPersistEntity, IPersist, IIfcStructuralLoadSingleDisplacementDistortion, IIfcStructuralLoadSingleDisplacement, IIfcStructuralLoadStatic, IIfcStructuralLoadOrResult, IIfcStructuralLoad, IEquatable<IfcStructuralLoadSingleDisplacementDistortion>
{
	private IfcCurvatureMeasure? _distortion;

	IfcCurvatureMeasure? IIfcStructuralLoadSingleDisplacementDistortion.Distortion
	{
		get
		{
			return Distortion;
		}
		set
		{
			Distortion = value;
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public IfcCurvatureMeasure? Distortion
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
			SetValue(delegate(IfcCurvatureMeasure? v)
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
