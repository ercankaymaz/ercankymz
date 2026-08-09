using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Common.Geometry;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.RepresentationResource;

[ExpressType("IfcGeometricRepresentationSubContext", 556)]
public class IfcGeometricRepresentationSubContext : IfcGeometricRepresentationContext, IInstantiableEntity, IPersistEntity, IPersist, IIfcGeometricRepresentationSubContext, IIfcGeometricRepresentationContext, IIfcRepresentationContext, IfcCoordinateReferenceSystemSelect, IIfcCoordinateReferenceSystemSelect, IExpressSelectType, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcGeometricRepresentationSubContext>, IExpressValidatable
{
	public enum IfcGeometricRepresentationSubContextClause
	{
		ParentNoSub,
		UserTargetProvided,
		NoCoordOperation
	}

	private IfcGeometricRepresentationContext _parentContext;

	private IfcPositiveRatioMeasure? _targetScale;

	private IfcGeometricProjectionEnum _targetView;

	private IfcLabel? _userDefinedTargetView;

	IIfcGeometricRepresentationContext IIfcGeometricRepresentationSubContext.ParentContext
	{
		get
		{
			return ParentContext;
		}
		set
		{
			ParentContext = value as IfcGeometricRepresentationContext;
		}
	}

	IfcPositiveRatioMeasure? IIfcGeometricRepresentationSubContext.TargetScale
	{
		get
		{
			return TargetScale;
		}
		set
		{
			TargetScale = value;
		}
	}

	IfcGeometricProjectionEnum IIfcGeometricRepresentationSubContext.TargetView
	{
		get
		{
			return TargetView;
		}
		set
		{
			TargetView = value;
		}
	}

	IfcLabel? IIfcGeometricRepresentationSubContext.UserDefinedTargetView
	{
		get
		{
			return UserDefinedTargetView;
		}
		set
		{
			UserDefinedTargetView = value;
		}
	}

	[IndexedProperty]
	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 10)]
	public IfcGeometricRepresentationContext ParentContext
	{
		get
		{
			if (_activated)
			{
				return _parentContext;
			}
			Activate();
			return _parentContext;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcGeometricRepresentationContext v)
			{
				_parentContext = v;
			}, _parentContext, value, "ParentContext", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 11)]
	public IfcPositiveRatioMeasure? TargetScale
	{
		get
		{
			if (_activated)
			{
				return _targetScale;
			}
			Activate();
			return _targetScale;
		}
		set
		{
			SetValue(delegate(IfcPositiveRatioMeasure? v)
			{
				_targetScale = v;
			}, _targetScale, value, "TargetScale", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 12)]
	public IfcGeometricProjectionEnum TargetView
	{
		get
		{
			if (_activated)
			{
				return _targetView;
			}
			Activate();
			return _targetView;
		}
		set
		{
			SetValue(delegate(IfcGeometricProjectionEnum v)
			{
				_targetView = v;
			}, _targetView, value, "TargetView", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 13)]
	public IfcLabel? UserDefinedTargetView
	{
		get
		{
			if (_activated)
			{
				return _userDefinedTargetView;
			}
			Activate();
			return _userDefinedTargetView;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_userDefinedTargetView = v;
			}, _userDefinedTargetView, value, "UserDefinedTargetView", 10);
		}
	}

	[EntityAttribute(5, EntityAttributeState.DerivedOverride, EntityAttributeType.Class, EntityAttributeType.None, null, null, 0)]
	public override IfcAxis2Placement WorldCoordinateSystem
	{
		get
		{
			return ParentContext.WorldCoordinateSystem;
		}
		set
		{
			throw new Exception("It is not possible to set a value of derived property WorldCoordinateSystem in IfcGeometricRepresentationSubContext");
		}
	}

	[EntityAttribute(3, EntityAttributeState.DerivedOverride, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public override IfcDimensionCount CoordinateSpaceDimension
	{
		get
		{
			return ParentContext.CoordinateSpaceDimension;
		}
		set
		{
			throw new Exception("It is not possible to set a value of derived property CoordinateSpaceDimension in IfcGeometricRepresentationSubContext");
		}
	}

	[EntityAttribute(6, EntityAttributeState.DerivedOverride, EntityAttributeType.Class, EntityAttributeType.None, null, null, 0)]
	public override IfcDirection TrueNorth
	{
		get
		{
			if (ParentContext.TrueNorth != null)
			{
				return ParentContext.TrueNorth;
			}
			return ((long?)WorldCoordinateSystem?.Dim > 1) ? new XbimVector3D(WorldCoordinateSystem.P[1].X, WorldCoordinateSystem.P[1].Y, double.NaN) : new XbimVector3D(0.0, 1.0, double.NaN);
		}
		set
		{
			throw new Exception("It is not possible to set a value of derived property TrueNorth in IfcGeometricRepresentationSubContext");
		}
	}

	[EntityAttribute(4, EntityAttributeState.DerivedOverride, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public override IfcReal? Precision
	{
		get
		{
			return ParentContext.Precision ?? ((IfcReal)1E-05);
		}
		set
		{
			throw new Exception("It is not possible to set a value of derived property Precision in IfcGeometricRepresentationSubContext");
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (WorldCoordinateSystem != null)
			{
				yield return WorldCoordinateSystem;
			}
			if (TrueNorth != null)
			{
				yield return TrueNorth;
			}
			if (ParentContext != null)
			{
				yield return ParentContext;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (ParentContext != null)
			{
				yield return ParentContext;
			}
		}
	}

	internal IfcGeometricRepresentationSubContext(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 6:
			_parentContext = (IfcGeometricRepresentationContext)value.EntityVal;
			break;
		case 7:
			_targetScale = value.RealVal;
			break;
		case 8:
			_targetView = (IfcGeometricProjectionEnum)Enum.Parse(typeof(IfcGeometricProjectionEnum), value.EnumVal, ignoreCase: true);
			break;
		case 9:
			_userDefinedTargetView = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcGeometricRepresentationSubContext other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcGeometricRepresentationSubContextClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcGeometricRepresentationSubContextClause.ParentNoSub:
				result = !Functions.TYPEOF(ParentContext).Contains("IFC4.IFCGEOMETRICREPRESENTATIONSUBCONTEXT");
				break;
			case IfcGeometricRepresentationSubContextClause.UserTargetProvided:
				result = TargetView != IfcGeometricProjectionEnum.USERDEFINED || (TargetView == IfcGeometricProjectionEnum.USERDEFINED && Functions.EXISTS(UserDefinedTargetView));
				break;
			case IfcGeometricRepresentationSubContextClause.NoCoordOperation:
				result = Functions.SIZEOF(base.HasCoordinateOperation) == 0;
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcGeometricRepresentationSubContext>()?.LogError($"Exception thrown evaluating where-clause 'IfcGeometricRepresentationSubContext.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcGeometricRepresentationSubContextClause.ParentNoSub))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcGeometricRepresentationSubContext.ParentNoSub",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcGeometricRepresentationSubContextClause.UserTargetProvided))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcGeometricRepresentationSubContext.UserTargetProvided",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcGeometricRepresentationSubContextClause.NoCoordOperation))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcGeometricRepresentationSubContext.NoCoordOperation",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
