using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.RepresentationResource;

[ExpressType("IfcGeometricRepresentationContext", 555)]
public class IfcGeometricRepresentationContext : IfcRepresentationContext, IInstantiableEntity, IPersistEntity, IPersist, IIfcGeometricRepresentationContext, IIfcRepresentationContext, IfcCoordinateReferenceSystemSelect, IIfcCoordinateReferenceSystemSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcGeometricRepresentationContext>, IExpressValidatable
{
	public enum IfcGeometricRepresentationContextClause
	{
		North2D
	}

	private IfcDimensionCount _coordinateSpaceDimension;

	private IfcReal? _precision;

	private IfcAxis2Placement _worldCoordinateSystem;

	private IfcDirection _trueNorth;

	IfcDimensionCount IIfcGeometricRepresentationContext.CoordinateSpaceDimension
	{
		get
		{
			return CoordinateSpaceDimension;
		}
		set
		{
			CoordinateSpaceDimension = value;
		}
	}

	IfcReal? IIfcGeometricRepresentationContext.Precision
	{
		get
		{
			return Precision;
		}
		set
		{
			Precision = value;
		}
	}

	IIfcAxis2Placement IIfcGeometricRepresentationContext.WorldCoordinateSystem
	{
		get
		{
			return WorldCoordinateSystem;
		}
		set
		{
			WorldCoordinateSystem = value as IfcAxis2Placement;
		}
	}

	IIfcDirection IIfcGeometricRepresentationContext.TrueNorth
	{
		get
		{
			return TrueNorth;
		}
		set
		{
			TrueNorth = value as IfcDirection;
		}
	}

	IEnumerable<IIfcGeometricRepresentationSubContext> IIfcGeometricRepresentationContext.HasSubContexts => HasSubContexts;

	IEnumerable<IIfcCoordinateOperation> IIfcGeometricRepresentationContext.HasCoordinateOperation => HasCoordinateOperation;

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public virtual IfcDimensionCount CoordinateSpaceDimension
	{
		get
		{
			if (_activated)
			{
				return _coordinateSpaceDimension;
			}
			Activate();
			return _coordinateSpaceDimension;
		}
		set
		{
			SetValue(delegate(IfcDimensionCount v)
			{
				_coordinateSpaceDimension = v;
			}, _coordinateSpaceDimension, value, "CoordinateSpaceDimension", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public virtual IfcReal? Precision
	{
		get
		{
			if (_activated)
			{
				return _precision;
			}
			Activate();
			return _precision;
		}
		set
		{
			SetValue(delegate(IfcReal? v)
			{
				_precision = v;
			}, _precision, value, "Precision", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
	public virtual IfcAxis2Placement WorldCoordinateSystem
	{
		get
		{
			if (_activated)
			{
				return _worldCoordinateSystem;
			}
			Activate();
			return _worldCoordinateSystem;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcAxis2Placement v)
			{
				_worldCoordinateSystem = v;
			}, _worldCoordinateSystem, value, "WorldCoordinateSystem", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 7)]
	public virtual IfcDirection TrueNorth
	{
		get
		{
			if (_activated)
			{
				return _trueNorth;
			}
			Activate();
			return _trueNorth;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcDirection v)
			{
				_trueNorth = v;
			}, _trueNorth, value, "TrueNorth", 6);
		}
	}

	[InverseProperty("ParentContext")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 8)]
	public IEnumerable<IfcGeometricRepresentationSubContext> HasSubContexts => base.Model.Instances.Where((IfcGeometricRepresentationSubContext e) => Equals(e.ParentContext), "ParentContext", this);

	[InverseProperty("SourceCRS")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 9)]
	public IEnumerable<IfcCoordinateOperation> HasCoordinateOperation => base.Model.Instances.Where((IfcCoordinateOperation e) => Equals(e.SourceCRS), "SourceCRS", this);

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
		}
	}

	internal IfcGeometricRepresentationContext(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 2:
			_coordinateSpaceDimension = value.IntegerVal;
			break;
		case 3:
			_precision = value.RealVal;
			break;
		case 4:
			_worldCoordinateSystem = (IfcAxis2Placement)value.EntityVal;
			break;
		case 5:
			_trueNorth = (IfcDirection)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcGeometricRepresentationContext other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcGeometricRepresentationContextClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcGeometricRepresentationContextClause.North2D)
			{
				result = !Functions.EXISTS(TrueNorth) || Functions.HIINDEX(TrueNorth.DirectionRatios) == 2;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcGeometricRepresentationContext>()?.LogError($"Exception thrown evaluating where-clause 'IfcGeometricRepresentationContext.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcGeometricRepresentationContextClause.North2D))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcGeometricRepresentationContext.North2D",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
