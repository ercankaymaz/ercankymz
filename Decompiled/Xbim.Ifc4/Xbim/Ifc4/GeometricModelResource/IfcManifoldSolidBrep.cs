using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.TopologyResource;

namespace Xbim.Ifc4.GeometricModelResource;

[ExpressType("IfcManifoldSolidBrep", 149)]
public abstract class IfcManifoldSolidBrep : IfcSolidModel, IIfcManifoldSolidBrep, IIfcSolidModel, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcBooleanOperand, IIfcBooleanOperand, IfcSolidOrShell, IIfcSolidOrShell, IEquatable<IfcManifoldSolidBrep>
{
	private IfcClosedShell _outer;

	IIfcClosedShell IIfcManifoldSolidBrep.Outer
	{
		get
		{
			return Outer;
		}
		set
		{
			Outer = value as IfcClosedShell;
		}
	}

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcClosedShell Outer
	{
		get
		{
			if (_activated)
			{
				return _outer;
			}
			Activate();
			return _outer;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcClosedShell v)
			{
				_outer = v;
			}, _outer, value, "Outer", 1);
		}
	}

	internal IfcManifoldSolidBrep(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex == 0)
		{
			_outer = (IfcClosedShell)value.EntityVal;
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcManifoldSolidBrep other)
	{
		return this == other;
	}
}
