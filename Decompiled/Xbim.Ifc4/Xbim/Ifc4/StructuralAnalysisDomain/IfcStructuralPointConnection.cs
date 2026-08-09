using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc4.StructuralAnalysisDomain;

[ExpressType("IfcStructuralPointConnection", 533)]
public class IfcStructuralPointConnection : IfcStructuralConnection, IInstantiableEntity, IPersistEntity, IPersist, IIfcStructuralPointConnection, IIfcStructuralConnection, IIfcStructuralItem, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcStructuralPointConnection>
{
	private IfcAxis2Placement3D _conditionCoordinateSystem;

	IIfcAxis2Placement3D IIfcStructuralPointConnection.ConditionCoordinateSystem
	{
		get
		{
			return ConditionCoordinateSystem;
		}
		set
		{
			ConditionCoordinateSystem = value as IfcAxis2Placement3D;
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 23)]
	public IfcAxis2Placement3D ConditionCoordinateSystem
	{
		get
		{
			if (_activated)
			{
				return _conditionCoordinateSystem;
			}
			Activate();
			return _conditionCoordinateSystem;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcAxis2Placement3D v)
			{
				_conditionCoordinateSystem = v;
			}, _conditionCoordinateSystem, value, "ConditionCoordinateSystem", 9);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.OwnerHistory != null)
			{
				yield return base.OwnerHistory;
			}
			if (base.ObjectPlacement != null)
			{
				yield return base.ObjectPlacement;
			}
			if (base.Representation != null)
			{
				yield return base.Representation;
			}
			if (base.AppliedCondition != null)
			{
				yield return base.AppliedCondition;
			}
			if (ConditionCoordinateSystem != null)
			{
				yield return ConditionCoordinateSystem;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (base.ObjectPlacement != null)
			{
				yield return base.ObjectPlacement;
			}
			if (base.Representation != null)
			{
				yield return base.Representation;
			}
		}
	}

	internal IfcStructuralPointConnection(IModel model, int label, bool activated)
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
			_conditionCoordinateSystem = (IfcAxis2Placement3D)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcStructuralPointConnection other)
	{
		return this == other;
	}
}
