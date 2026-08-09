using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.GeometricConstraintResource;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc2x3.StructuralAnalysisDomain;

[ExpressType("IfcRelConnectsWithEccentricity", 322)]
public class IfcRelConnectsWithEccentricity : IfcRelConnectsStructuralMember, IIfcRelConnectsWithEccentricity, IIfcRelConnectsStructuralMember, IIfcRelConnects, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelConnectsWithEccentricity>
{
	private IfcConnectionGeometry _connectionConstraint;

	[CrossSchemaAttribute(typeof(IIfcRelConnectsWithEccentricity), 11)]
	IIfcConnectionGeometry IIfcRelConnectsWithEccentricity.ConnectionConstraint
	{
		get
		{
			return ConnectionConstraint;
		}
		set
		{
			ConnectionConstraint = value as IfcConnectionGeometry;
		}
	}

	[EntityAttribute(11, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 11)]
	public IfcConnectionGeometry ConnectionConstraint
	{
		get
		{
			if (_activated)
			{
				return _connectionConstraint;
			}
			Activate();
			return _connectionConstraint;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcConnectionGeometry v)
			{
				_connectionConstraint = v;
			}, _connectionConstraint, value, "ConnectionConstraint", 11);
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
			if (base.RelatingStructuralMember != null)
			{
				yield return base.RelatingStructuralMember;
			}
			if (base.RelatedStructuralConnection != null)
			{
				yield return base.RelatedStructuralConnection;
			}
			if (base.AppliedCondition != null)
			{
				yield return base.AppliedCondition;
			}
			if (base.AdditionalConditions != null)
			{
				yield return base.AdditionalConditions;
			}
			if (base.ConditionCoordinateSystem != null)
			{
				yield return base.ConditionCoordinateSystem;
			}
			if (ConnectionConstraint != null)
			{
				yield return ConnectionConstraint;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (base.RelatingStructuralMember != null)
			{
				yield return base.RelatingStructuralMember;
			}
			if (base.RelatedStructuralConnection != null)
			{
				yield return base.RelatedStructuralConnection;
			}
		}
	}

	internal IfcRelConnectsWithEccentricity(IModel model, int label, bool activated)
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
		case 8:
		case 9:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 10:
			_connectionConstraint = (IfcConnectionGeometry)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelConnectsWithEccentricity other)
	{
		return this == other;
	}
}
