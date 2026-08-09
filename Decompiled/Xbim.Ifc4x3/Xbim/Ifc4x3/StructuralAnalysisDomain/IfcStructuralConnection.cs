using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.StructuralLoadResource;

namespace Xbim.Ifc4x3.StructuralAnalysisDomain;

[ExpressType("IfcStructuralConnection", 265)]
public abstract class IfcStructuralConnection : IfcStructuralItem, IIfcStructuralConnection, IIfcStructuralItem, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, Xbim.Ifc4.StructuralAnalysisDomain.IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IEquatable<IfcStructuralConnection>
{
	private IfcBoundaryCondition _appliedCondition;

	[CrossSchemaAttribute(typeof(IIfcStructuralConnection), 8)]
	IIfcBoundaryCondition IIfcStructuralConnection.AppliedCondition
	{
		get
		{
			return AppliedCondition;
		}
		set
		{
			AppliedCondition = value as IfcBoundaryCondition;
		}
	}

	IEnumerable<IIfcRelConnectsStructuralMember> IIfcStructuralConnection.ConnectsStructuralMembers => base.Model.Instances.Where((IIfcRelConnectsStructuralMember e) => e.RelatedStructuralConnection as IfcStructuralConnection == this, "RelatedStructuralConnection", this);

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 23)]
	public IfcBoundaryCondition AppliedCondition
	{
		get
		{
			if (_activated)
			{
				return _appliedCondition;
			}
			Activate();
			return _appliedCondition;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcBoundaryCondition v)
			{
				_appliedCondition = v;
			}, _appliedCondition, value, "AppliedCondition", 8);
		}
	}

	[InverseProperty("RelatedStructuralConnection")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 24)]
	public IEnumerable<IfcRelConnectsStructuralMember> ConnectsStructuralMembers => base.Model.Instances.Where((IfcRelConnectsStructuralMember e) => Equals(e.RelatedStructuralConnection), "RelatedStructuralConnection", this);

	internal IfcStructuralConnection(IModel model, int label, bool activated)
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
			_appliedCondition = (IfcBoundaryCondition)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcStructuralConnection other)
	{
		return this == other;
	}
}
