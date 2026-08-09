using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Collections;
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

[ExpressType("IfcTrimmedCurve", 143)]
public class IfcTrimmedCurve : IfcBoundedCurve, IInstantiableEntity, IPersistEntity, IPersist, IIfcTrimmedCurve, IIfcBoundedCurve, IIfcCurve, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect, IfcCurveOrEdgeCurve, IIfcCurveOrEdgeCurve, IContainsEntityReferences, IEquatable<IfcTrimmedCurve>, IExpressValidatable
{
	public enum IfcTrimmedCurveClause
	{
		Trim1ValuesConsistent,
		Trim2ValuesConsistent,
		NoTrimOfBoundedCurves
	}

	private IfcCurve _basisCurve;

	private readonly ItemSet<IfcTrimmingSelect> _trim1;

	private readonly ItemSet<IfcTrimmingSelect> _trim2;

	private IfcBoolean _senseAgreement;

	private IfcTrimmingPreference _masterRepresentation;

	IIfcCurve IIfcTrimmedCurve.BasisCurve
	{
		get
		{
			return BasisCurve;
		}
		set
		{
			BasisCurve = value as IfcCurve;
		}
	}

	IItemSet<IIfcTrimmingSelect> IIfcTrimmedCurve.Trim1 => new ProxyItemSet<IfcTrimmingSelect, IIfcTrimmingSelect>(Trim1);

	IItemSet<IIfcTrimmingSelect> IIfcTrimmedCurve.Trim2 => new ProxyItemSet<IfcTrimmingSelect, IIfcTrimmingSelect>(Trim2);

	IfcBoolean IIfcTrimmedCurve.SenseAgreement
	{
		get
		{
			return SenseAgreement;
		}
		set
		{
			SenseAgreement = value;
		}
	}

	IfcTrimmingPreference IIfcTrimmedCurve.MasterRepresentation
	{
		get
		{
			return MasterRepresentation;
		}
		set
		{
			MasterRepresentation = value;
		}
	}

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcCurve BasisCurve
	{
		get
		{
			if (_activated)
			{
				return _basisCurve;
			}
			Activate();
			return _basisCurve;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcCurve v)
			{
				_basisCurve = v;
			}, _basisCurve, value, "BasisCurve", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { 2 }, 4)]
	public IItemSet<IfcTrimmingSelect> Trim1
	{
		get
		{
			if (_activated)
			{
				return _trim1;
			}
			Activate();
			return _trim1;
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { 2 }, 5)]
	public IItemSet<IfcTrimmingSelect> Trim2
	{
		get
		{
			if (_activated)
			{
				return _trim2;
			}
			Activate();
			return _trim2;
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcBoolean SenseAgreement
	{
		get
		{
			if (_activated)
			{
				return _senseAgreement;
			}
			Activate();
			return _senseAgreement;
		}
		set
		{
			SetValue(delegate(IfcBoolean v)
			{
				_senseAgreement = v;
			}, _senseAgreement, value, "SenseAgreement", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 7)]
	public IfcTrimmingPreference MasterRepresentation
	{
		get
		{
			if (_activated)
			{
				return _masterRepresentation;
			}
			Activate();
			return _masterRepresentation;
		}
		set
		{
			SetValue(delegate(IfcTrimmingPreference v)
			{
				_masterRepresentation = v;
			}, _masterRepresentation, value, "MasterRepresentation", 5);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (BasisCurve != null)
			{
				yield return BasisCurve;
			}
		}
	}

	internal IfcTrimmedCurve(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_trim1 = new ItemSet<IfcTrimmingSelect>(this, 2, 2);
		_trim2 = new ItemSet<IfcTrimmingSelect>(this, 2, 3);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_basisCurve = (IfcCurve)value.EntityVal;
			break;
		case 1:
			_trim1.InternalAdd((IfcTrimmingSelect)value.EntityVal);
			break;
		case 2:
			_trim2.InternalAdd((IfcTrimmingSelect)value.EntityVal);
			break;
		case 3:
			_senseAgreement = value.BooleanVal;
			break;
		case 4:
			_masterRepresentation = (IfcTrimmingPreference)Enum.Parse(typeof(IfcTrimmingPreference), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcTrimmedCurve other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcTrimmedCurveClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcTrimmedCurveClause.Trim1ValuesConsistent:
				result = Functions.HIINDEX(Trim1) == 1 || Functions.TYPEOF(Trim1.ItemAt(0L)) != Functions.TYPEOF(Trim1.ItemAt(1L));
				break;
			case IfcTrimmedCurveClause.Trim2ValuesConsistent:
				result = Functions.HIINDEX(Trim2) == 1 || Functions.TYPEOF(Trim2.ItemAt(0L)) != Functions.TYPEOF(Trim2.ItemAt(1L));
				break;
			case IfcTrimmedCurveClause.NoTrimOfBoundedCurves:
				result = !Functions.TYPEOF(BasisCurve).Contains("IFC4.IFCBOUNDEDCURVE");
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcTrimmedCurve>()?.LogError($"Exception thrown evaluating where-clause 'IfcTrimmedCurve.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcTrimmedCurveClause.Trim1ValuesConsistent))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcTrimmedCurve.Trim1ValuesConsistent",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcTrimmedCurveClause.Trim2ValuesConsistent))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcTrimmedCurve.Trim2ValuesConsistent",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcTrimmedCurveClause.NoTrimOfBoundedCurves))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcTrimmedCurve.NoTrimOfBoundedCurves",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
