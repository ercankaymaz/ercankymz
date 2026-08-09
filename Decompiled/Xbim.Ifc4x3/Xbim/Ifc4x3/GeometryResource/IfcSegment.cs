using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;

namespace Xbim.Ifc4x3.GeometryResource;

[ExpressType("IfcSegment", 1485)]
public abstract class IfcSegment : IfcGeometricRepresentationItem, IEquatable<IfcSegment>
{
	private IfcTransitionCode _transition;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 3)]
	public IfcTransitionCode Transition
	{
		get
		{
			if (_activated)
			{
				return _transition;
			}
			Activate();
			return _transition;
		}
		set
		{
			SetValue(delegate(IfcTransitionCode v)
			{
				_transition = v;
			}, _transition, value, "Transition", 1);
		}
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public IfcDimensionCount Dim
	{
		get
		{
			if (this is IfcCurveSegment ifcCurveSegment)
			{
				return ifcCurveSegment.ParentCurve.Dim;
			}
			if (this is IfcCompositeCurveSegment ifcCompositeCurveSegment)
			{
				return ifcCompositeCurveSegment.ParentCurve.Dim;
			}
			throw new NotSupportedException("Unexpected segment type " + GetType().Name);
		}
	}

	[InverseProperty("Segments")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 4)]
	public IEnumerable<IfcCompositeCurve> UsingCurves => base.Model.Instances.Where((IfcCompositeCurve e) => e.Segments != null && e.Segments.Contains(this), "Segments", this);

	internal IfcSegment(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex == 0)
		{
			_transition = (IfcTransitionCode)Enum.Parse(typeof(IfcTransitionCode), value.EnumVal, ignoreCase: true);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcSegment other)
	{
		return this == other;
	}
}
