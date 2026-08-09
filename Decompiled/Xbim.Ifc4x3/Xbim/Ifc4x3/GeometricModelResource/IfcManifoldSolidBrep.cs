using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4x3.TopologyResource;

namespace Xbim.Ifc4x3.GeometricModelResource;

[ExpressType("IfcManifoldSolidBrep", 149)]
public abstract class IfcManifoldSolidBrep : IfcSolidModel, IEquatable<IfcManifoldSolidBrep>, IIfcManifoldSolidBrep, IIfcSolidModel, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, Xbim.Ifc4.GeometricModelResource.IfcBooleanOperand, IIfcBooleanOperand, IfcSolidOrShell, IIfcSolidOrShell
{
	private IfcClosedShell _outer;

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

	[CrossSchemaAttribute(typeof(IIfcManifoldSolidBrep), 1)]
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
