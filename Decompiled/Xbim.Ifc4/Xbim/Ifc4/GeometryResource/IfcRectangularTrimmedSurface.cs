using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.GeometryResource;

[ExpressType("IfcRectangularTrimmedSurface", 653)]
public class IfcRectangularTrimmedSurface : IfcBoundedSurface, IInstantiableEntity, IPersistEntity, IPersist, IIfcRectangularTrimmedSurface, IIfcBoundedSurface, IIfcSurface, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect, IfcSurfaceOrFaceSurface, IIfcSurfaceOrFaceSurface, IContainsEntityReferences, IEquatable<IfcRectangularTrimmedSurface>, IExpressValidatable
{
	public enum IfcRectangularTrimmedSurfaceClause
	{
		U1AndU2Different,
		V1AndV2Different,
		UsenseCompatible,
		VsenseCompatible
	}

	private IfcSurface _basisSurface;

	private IfcParameterValue _u1;

	private IfcParameterValue _v1;

	private IfcParameterValue _u2;

	private IfcParameterValue _v2;

	private IfcBoolean _usense;

	private IfcBoolean _vsense;

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

	IfcParameterValue IIfcRectangularTrimmedSurface.U1
	{
		get
		{
			return U1;
		}
		set
		{
			U1 = value;
		}
	}

	IfcParameterValue IIfcRectangularTrimmedSurface.V1
	{
		get
		{
			return V1;
		}
		set
		{
			V1 = value;
		}
	}

	IfcParameterValue IIfcRectangularTrimmedSurface.U2
	{
		get
		{
			return U2;
		}
		set
		{
			U2 = value;
		}
	}

	IfcParameterValue IIfcRectangularTrimmedSurface.V2
	{
		get
		{
			return V2;
		}
		set
		{
			V2 = value;
		}
	}

	IfcBoolean IIfcRectangularTrimmedSurface.Usense
	{
		get
		{
			return Usense;
		}
		set
		{
			Usense = value;
		}
	}

	IfcBoolean IIfcRectangularTrimmedSurface.Vsense
	{
		get
		{
			return Vsense;
		}
		set
		{
			Vsense = value;
		}
	}

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
	public IfcParameterValue U1
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
			SetValue(delegate(IfcParameterValue v)
			{
				_u1 = v;
			}, _u1, value, "U1", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public IfcParameterValue V1
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
			SetValue(delegate(IfcParameterValue v)
			{
				_v1 = v;
			}, _v1, value, "V1", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcParameterValue U2
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
			SetValue(delegate(IfcParameterValue v)
			{
				_u2 = v;
			}, _u2, value, "U2", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public IfcParameterValue V2
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
			SetValue(delegate(IfcParameterValue v)
			{
				_v2 = v;
			}, _v2, value, "V2", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public IfcBoolean Usense
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
			SetValue(delegate(IfcBoolean v)
			{
				_usense = v;
			}, _usense, value, "Usense", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 9)]
	public IfcBoolean Vsense
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
			SetValue(delegate(IfcBoolean v)
			{
				_vsense = v;
			}, _vsense, value, "Vsense", 7);
		}
	}

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
			case IfcRectangularTrimmedSurfaceClause.U1AndU2Different:
				result = U1 != U2;
				break;
			case IfcRectangularTrimmedSurfaceClause.V1AndV2Different:
				result = V1 != V2;
				break;
			case IfcRectangularTrimmedSurfaceClause.UsenseCompatible:
				result = (Functions.TYPEOF(BasisSurface).Contains("IFC4.IFCELEMENTARYSURFACE") && !Functions.TYPEOF(BasisSurface).Contains("IFC4.IFCPLANE")) || Functions.TYPEOF(BasisSurface).Contains("IFC4.IFCSURFACEOFREVOLUTION") || Usense == (double)U2 > (double)U1;
				break;
			case IfcRectangularTrimmedSurfaceClause.VsenseCompatible:
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
		if (!ValidateClause(IfcRectangularTrimmedSurfaceClause.U1AndU2Different))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRectangularTrimmedSurface.U1AndU2Different",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcRectangularTrimmedSurfaceClause.V1AndV2Different))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRectangularTrimmedSurface.V1AndV2Different",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcRectangularTrimmedSurfaceClause.UsenseCompatible))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRectangularTrimmedSurface.UsenseCompatible",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcRectangularTrimmedSurfaceClause.VsenseCompatible))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRectangularTrimmedSurface.VsenseCompatible",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
