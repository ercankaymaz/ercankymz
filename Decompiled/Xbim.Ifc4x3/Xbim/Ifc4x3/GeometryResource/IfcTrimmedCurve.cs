using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.GeometryResource;

[ExpressType("IfcTrimmedCurve", 143)]
public class IfcTrimmedCurve : IfcBoundedCurve, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcTrimmedCurve>, IIfcTrimmedCurve, IIfcBoundedCurve, IIfcCurve, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect, IfcCurveOrEdgeCurve, IIfcCurveOrEdgeCurve
{
	private IfcCurve _basisCurve;

	private readonly ItemSet<IfcTrimmingSelect> _trim1;

	private readonly ItemSet<IfcTrimmingSelect> _trim2;

	private Xbim.Ifc4x3.MeasureResource.IfcBoolean _senseAgreement;

	private IfcTrimmingPreference _masterRepresentation;

	private IItemSet<IIfcTrimmingSelect> _trim1Ifc4;

	private IItemSet<IIfcTrimmingSelect> _trim2Ifc4;

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
	public Xbim.Ifc4x3.MeasureResource.IfcBoolean SenseAgreement
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcBoolean v)
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

	[CrossSchemaAttribute(typeof(IIfcTrimmedCurve), 1)]
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

	[CrossSchemaAttribute(typeof(IIfcTrimmedCurve), 2)]
	IItemSet<IIfcTrimmingSelect> IIfcTrimmedCurve.Trim1 => _trim1Ifc4 ?? (_trim1Ifc4 = new ExtendedItemSet<IfcTrimmingSelect, IIfcTrimmingSelect>(Trim1, new ItemSet<IIfcTrimmingSelect>(this, 0, -2), Trim1ToIfc4, Trim1ToIfc2X3));

	[CrossSchemaAttribute(typeof(IIfcTrimmedCurve), 3)]
	IItemSet<IIfcTrimmingSelect> IIfcTrimmedCurve.Trim2 => _trim2Ifc4 ?? (_trim2Ifc4 = new ExtendedItemSet<IfcTrimmingSelect, IIfcTrimmingSelect>(Trim2, new ItemSet<IIfcTrimmingSelect>(this, 0, -3), Trim2ToIfc4, Trim2ToIfc2X3));

	[CrossSchemaAttribute(typeof(IIfcTrimmedCurve), 4)]
	Xbim.Ifc4.MeasureResource.IfcBoolean IIfcTrimmedCurve.SenseAgreement
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcBoolean(SenseAgreement);
		}
		set
		{
			SenseAgreement = new Xbim.Ifc4x3.MeasureResource.IfcBoolean(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcTrimmedCurve), 5)]
	Xbim.Ifc4.Interfaces.IfcTrimmingPreference IIfcTrimmedCurve.MasterRepresentation
	{
		get
		{
			return MasterRepresentation switch
			{
				IfcTrimmingPreference.CARTESIAN => Xbim.Ifc4.Interfaces.IfcTrimmingPreference.CARTESIAN, 
				IfcTrimmingPreference.PARAMETER => Xbim.Ifc4.Interfaces.IfcTrimmingPreference.PARAMETER, 
				IfcTrimmingPreference.UNSPECIFIED => Xbim.Ifc4.Interfaces.IfcTrimmingPreference.UNSPECIFIED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcTrimmingPreference.CARTESIAN:
				MasterRepresentation = IfcTrimmingPreference.CARTESIAN;
				break;
			case Xbim.Ifc4.Interfaces.IfcTrimmingPreference.PARAMETER:
				MasterRepresentation = IfcTrimmingPreference.PARAMETER;
				break;
			case Xbim.Ifc4.Interfaces.IfcTrimmingPreference.UNSPECIFIED:
				MasterRepresentation = IfcTrimmingPreference.UNSPECIFIED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
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

	private static IIfcTrimmingSelect Trim1ToIfc4(IfcTrimmingSelect member)
	{
		if (member == null)
		{
			return null;
		}
		string name = member.GetType().Name;
		if (!(name == "IfcCartesianPoint"))
		{
			if (name == "IfcParameterValue")
			{
				return new Xbim.Ifc4.MeasureResource.IfcParameterValue((Xbim.Ifc4x3.MeasureResource.IfcParameterValue)(object)member);
			}
			throw new NotSupportedException();
		}
		return member as IfcCartesianPoint;
	}

	private static IfcTrimmingSelect Trim1ToIfc2X3(IIfcTrimmingSelect member)
	{
		if (member == null)
		{
			return null;
		}
		string name = member.GetType().Name;
		if (!(name == "IfcCartesianPoint"))
		{
			if (name == "IfcParameterValue")
			{
				return new Xbim.Ifc4x3.MeasureResource.IfcParameterValue((Xbim.Ifc4.MeasureResource.IfcParameterValue)(object)member);
			}
			throw new NotSupportedException();
		}
		return member as IfcCartesianPoint;
	}

	private static IIfcTrimmingSelect Trim2ToIfc4(IfcTrimmingSelect member)
	{
		if (member == null)
		{
			return null;
		}
		string name = member.GetType().Name;
		if (!(name == "IfcCartesianPoint"))
		{
			if (name == "IfcParameterValue")
			{
				return new Xbim.Ifc4.MeasureResource.IfcParameterValue((Xbim.Ifc4x3.MeasureResource.IfcParameterValue)(object)member);
			}
			throw new NotSupportedException();
		}
		return member as IfcCartesianPoint;
	}

	private static IfcTrimmingSelect Trim2ToIfc2X3(IIfcTrimmingSelect member)
	{
		if (member == null)
		{
			return null;
		}
		string name = member.GetType().Name;
		if (!(name == "IfcCartesianPoint"))
		{
			if (name == "IfcParameterValue")
			{
				return new Xbim.Ifc4x3.MeasureResource.IfcParameterValue((Xbim.Ifc4.MeasureResource.IfcParameterValue)(object)member);
			}
			throw new NotSupportedException();
		}
		return member as IfcCartesianPoint;
	}
}
