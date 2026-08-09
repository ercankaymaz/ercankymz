using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.StructuralLoadResource;

namespace Xbim.Ifc4.StructuralAnalysisDomain;

[ExpressType("IfcRelConnectsStructuralMember", 321)]
public class IfcRelConnectsStructuralMember : IfcRelConnects, IInstantiableEntity, IPersistEntity, IPersist, IIfcRelConnectsStructuralMember, IIfcRelConnects, IIfcRelationship, IIfcRoot, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelConnectsStructuralMember>
{
	private IfcStructuralMember _relatingStructuralMember;

	private IfcStructuralConnection _relatedStructuralConnection;

	private IfcBoundaryCondition _appliedCondition;

	private IfcStructuralConnectionCondition _additionalConditions;

	private IfcLengthMeasure? _supportedLength;

	private IfcAxis2Placement3D _conditionCoordinateSystem;

	IIfcStructuralMember IIfcRelConnectsStructuralMember.RelatingStructuralMember
	{
		get
		{
			return RelatingStructuralMember;
		}
		set
		{
			RelatingStructuralMember = value as IfcStructuralMember;
		}
	}

	IIfcStructuralConnection IIfcRelConnectsStructuralMember.RelatedStructuralConnection
	{
		get
		{
			return RelatedStructuralConnection;
		}
		set
		{
			RelatedStructuralConnection = value as IfcStructuralConnection;
		}
	}

	IIfcBoundaryCondition IIfcRelConnectsStructuralMember.AppliedCondition
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

	IIfcStructuralConnectionCondition IIfcRelConnectsStructuralMember.AdditionalConditions
	{
		get
		{
			return AdditionalConditions;
		}
		set
		{
			AdditionalConditions = value as IfcStructuralConnectionCondition;
		}
	}

	IfcLengthMeasure? IIfcRelConnectsStructuralMember.SupportedLength
	{
		get
		{
			return SupportedLength;
		}
		set
		{
			SupportedLength = value;
		}
	}

	IIfcAxis2Placement3D IIfcRelConnectsStructuralMember.ConditionCoordinateSystem
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

	[IndexedProperty]
	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcStructuralMember RelatingStructuralMember
	{
		get
		{
			if (_activated)
			{
				return _relatingStructuralMember;
			}
			Activate();
			return _relatingStructuralMember;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcStructuralMember v)
			{
				_relatingStructuralMember = v;
			}, _relatingStructuralMember, value, "RelatingStructuralMember", 5);
		}
	}

	[IndexedProperty]
	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
	public IfcStructuralConnection RelatedStructuralConnection
	{
		get
		{
			if (_activated)
			{
				return _relatedStructuralConnection;
			}
			Activate();
			return _relatedStructuralConnection;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcStructuralConnection v)
			{
				_relatedStructuralConnection = v;
			}, _relatedStructuralConnection, value, "RelatedStructuralConnection", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 7)]
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
			}, _appliedCondition, value, "AppliedCondition", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 8)]
	public IfcStructuralConnectionCondition AdditionalConditions
	{
		get
		{
			if (_activated)
			{
				return _additionalConditions;
			}
			Activate();
			return _additionalConditions;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcStructuralConnectionCondition v)
			{
				_additionalConditions = v;
			}, _additionalConditions, value, "AdditionalConditions", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 9)]
	public IfcLengthMeasure? SupportedLength
	{
		get
		{
			if (_activated)
			{
				return _supportedLength;
			}
			Activate();
			return _supportedLength;
		}
		set
		{
			SetValue(delegate(IfcLengthMeasure? v)
			{
				_supportedLength = v;
			}, _supportedLength, value, "SupportedLength", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 10)]
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
			}, _conditionCoordinateSystem, value, "ConditionCoordinateSystem", 10);
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
			if (RelatingStructuralMember != null)
			{
				yield return RelatingStructuralMember;
			}
			if (RelatedStructuralConnection != null)
			{
				yield return RelatedStructuralConnection;
			}
			if (AppliedCondition != null)
			{
				yield return AppliedCondition;
			}
			if (AdditionalConditions != null)
			{
				yield return AdditionalConditions;
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
			if (RelatingStructuralMember != null)
			{
				yield return RelatingStructuralMember;
			}
			if (RelatedStructuralConnection != null)
			{
				yield return RelatedStructuralConnection;
			}
		}
	}

	internal IfcRelConnectsStructuralMember(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 4:
			_relatingStructuralMember = (IfcStructuralMember)value.EntityVal;
			break;
		case 5:
			_relatedStructuralConnection = (IfcStructuralConnection)value.EntityVal;
			break;
		case 6:
			_appliedCondition = (IfcBoundaryCondition)value.EntityVal;
			break;
		case 7:
			_additionalConditions = (IfcStructuralConnectionCondition)value.EntityVal;
			break;
		case 8:
			_supportedLength = value.RealVal;
			break;
		case 9:
			_conditionCoordinateSystem = (IfcAxis2Placement3D)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelConnectsStructuralMember other)
	{
		return this == other;
	}
}
