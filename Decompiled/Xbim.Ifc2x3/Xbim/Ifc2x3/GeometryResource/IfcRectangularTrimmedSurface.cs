using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc2x3.GeometryResource;

[ExpressType("IfcRectangularTrimmedSurface", 653)]
public class IfcRectangularTrimmedSurface : IfcBoundedSurface, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcRectangularTrimmedSurface>, IIfcRectangularTrimmedSurface, IIfcBoundedSurface, IIfcSurface, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect, IfcSurfaceOrFaceSurface, IIfcSurfaceOrFaceSurface, IExpressValidatable
{
	public enum IfcRectangularTrimmedSurfaceClause
	{
		WR1,
		WR2,
		WR3,
		WR4
	}

	private IfcSurface _basisSurface;

	private Xbim.Ifc2x3.MeasureResource.IfcParameterValue _u1;

	private Xbim.Ifc2x3.MeasureResource.IfcParameterValue _v1;

	private Xbim.Ifc2x3.MeasureResource.IfcParameterValue _u2;

	private Xbim.Ifc2x3.MeasureResource.IfcParameterValue _v2;

	private bool _usense;

	private bool _vsense;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcSurface BasisSurface
	{
		get
		{
			if (_activated)
			{
				return _basisSurface;
			}
			Activate();
			return _basisSurface;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcSurface v)
			{
				_basisSurface = v;
			}, _basisSurface, value, "BasisSurface", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public Xbim.Ifc2x3.MeasureResource.IfcParameterValue U1
	{
		get
		{
			if (_activated)
			{
				return _u1;
			}
			Activate();
			return _u1;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcParameterValue v)
			{
				_u1 = v;
			}, _u1, value, "U1", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public Xbim.Ifc2x3.MeasureResource.IfcParameterValue V1
	{
		get
		{
			if (_activated)
			{
				return _v1;
			}
			Activate();
			return _v1;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcParameterValue v)
			{
				_v1 = v;
			}, _v1, value, "V1", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public Xbim.Ifc2x3.MeasureResource.IfcParameterValue U2
	{
		get
		{
			if (_activated)
			{
				return _u2;
			}
			Activate();
			return _u2;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcParameterValue v)
			{
				_u2 = v;
			}, _u2, value, "U2", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public Xbim.Ifc2x3.MeasureResource.IfcParameterValue V2
	{
		get
		{
			if (_activated)
			{
				return _v2;
			}
			Activate();
			return _v2;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcParameterValue v)
			{
				_v2 = v;
			}, _v2, value, "V2", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public bool Usense
	{
		get
		{
			if (_activated)
			{
				return _usense;
			}
			Activate();
			return _usense;
		}
		set
		{
			SetValue(delegate(bool v)
			{
				_usense = v;
			}, _usense, value, "Usense", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 9)]
	public bool Vsense
	{
		get
		{
			if (_activated)
			{
				return _vsense;
			}
			Activate();
			return _vsense;
		}
		set
		{
			SetValue(delegate(bool v)
			{
				_vsense = v;
			}, _vsense, value, "Vsense", 7);
		}
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public override IfcDimensionCount Dim => BasisSurface.Dim;

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (BasisSurface != null)
			{
				yield return BasisSurface;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcRectangularTrimmedSurface), 1)]
	IIfcSurface IIfcRectangularTrimmedSurface.BasisSurface
	{
		get
		{
			return BasisSurface;
		}
		set
		{
			BasisSurface = value as IfcSurface;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcRectangularTrimmedSurface), 2)]
	Xbim.Ifc4.MeasureResource.IfcParameterValue IIfcRectangularTrimmedSurface.U1
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcParameterValue(U1);
		}
		set
		{
			U1 = new Xbim.Ifc2x3.MeasureResource.IfcParameterValue(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcRectangularTrimmedSurface), 3)]
	Xbim.Ifc4.MeasureResource.IfcParameterValue IIfcRectangularTrimmedSurface.V1
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcParameterValue(V1);
		}
		set
		{
			V1 = new Xbim.Ifc2x3.MeasureResource.IfcParameterValue(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcRectangularTrimmedSurface), 4)]
	Xbim.Ifc4.MeasureResource.IfcParameterValue IIfcRectangularTrimmedSurface.U2
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcParameterValue(U2);
		}
		set
		{
			U2 = new Xbim.Ifc2x3.MeasureResource.IfcParameterValue(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcRectangularTrimmedSurface), 5)]
	Xbim.Ifc4.MeasureResource.IfcParameterValue IIfcRectangularTrimmedSurface.V2
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcParameterValue(V2);
		}
		set
		{
			V2 = new Xbim.Ifc2x3.MeasureResource.IfcParameterValue(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcRectangularTrimmedSurface), 6)]
	Xbim.Ifc4.MeasureResource.IfcBoolean IIfcRectangularTrimmedSurface.Usense
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcBoolean(Usense);
		}
		set
		{
			Usense = value;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcRectangularTrimmedSurface), 7)]
	Xbim.Ifc4.MeasureResource.IfcBoolean IIfcRectangularTrimmedSurface.Vsense
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcBoolean(Vsense);
		}
		set
		{
			Vsense = value;
		}
	}

	internal IfcRectangularTrimmedSurface(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_basisSurface = (IfcSurface)value.EntityVal;
			break;
		case 1:
			_u1 = value.RealVal;
			break;
		case 2:
			_v1 = value.RealVal;
			break;
		case 3:
			_u2 = value.RealVal;
			break;
		case 4:
			_v2 = value.RealVal;
			break;
		case 5:
			_usense = value.BooleanVal;
			break;
		case 6:
			_vsense = value.BooleanVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRectangularTrimmedSurface other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcRectangularTrimmedSurfaceClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcRectangularTrimmedSurfaceClause.WR1:
				result = U1 != U2;
				break;
			case IfcRectangularTrimmedSurfaceClause.WR2:
				result = V1 != V2;
				break;
			case IfcRectangularTrimmedSurfaceClause.WR3:
				result = (Functions.TYPEOF(BasisSurface).Contains("IFC2X3.IFCELEMENTARYSURFACE") && !Functions.TYPEOF(BasisSurface).Contains("IFC2X3.IFCPLANE")) || Functions.TYPEOF(BasisSurface).Contains("IFC2X3.IFCSURFACEOFREVOLUTION") || Usense == (double)U2 > (double)U1;
				break;
			case IfcRectangularTrimmedSurfaceClause.WR4:
				result = Vsense == (double)V2 > (double)V1;
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcRectangularTrimmedSurface>()?.LogError($"Exception thrown evaluating where-clause 'IfcRectangularTrimmedSurface.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcRectangularTrimmedSurfaceClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRectangularTrimmedSurface.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcRectangularTrimmedSurfaceClause.WR2))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRectangularTrimmedSurface.WR2",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcRectangularTrimmedSurfaceClause.WR3))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRectangularTrimmedSurface.WR3",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcRectangularTrimmedSurfaceClause.WR4))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRectangularTrimmedSurface.WR4",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
