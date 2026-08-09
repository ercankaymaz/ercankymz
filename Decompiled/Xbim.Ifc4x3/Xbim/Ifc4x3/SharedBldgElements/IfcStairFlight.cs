using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.MeasureResource;
using Xbim.Ifc4x3.ProductExtension;

namespace Xbim.Ifc4x3.SharedBldgElements;

[ExpressType("IfcStairFlight", 25)]
public class IfcStairFlight : IfcBuiltElement, IIfcStairFlight, IIfcBuildingElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcStairFlight>
{
	private Xbim.Ifc4x3.MeasureResource.IfcInteger? _numberOfRisers;

	private Xbim.Ifc4x3.MeasureResource.IfcInteger? _numberOfTreads;

	private Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? _riserHeight;

	private Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? _treadLength;

	private IfcStairFlightTypeEnum? _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcStairFlight), 9)]
	Xbim.Ifc4.MeasureResource.IfcInteger? IIfcStairFlight.NumberOfRisers
	{
		get
		{
			if (!NumberOfRisers.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcInteger(NumberOfRisers.Value);
		}
		set
		{
			NumberOfRisers = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcInteger?(new Xbim.Ifc4x3.MeasureResource.IfcInteger(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcInteger?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcStairFlight), 10)]
	Xbim.Ifc4.MeasureResource.IfcInteger? IIfcStairFlight.NumberOfTreads
	{
		get
		{
			if (!NumberOfTreads.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcInteger(NumberOfTreads.Value);
		}
		set
		{
			NumberOfTreads = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcInteger?(new Xbim.Ifc4x3.MeasureResource.IfcInteger(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcInteger?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcStairFlight), 11)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure? IIfcStairFlight.RiserHeight
	{
		get
		{
			if (!RiserHeight.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(RiserHeight.Value);
		}
		set
		{
			RiserHeight = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcStairFlight), 12)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure? IIfcStairFlight.TreadLength
	{
		get
		{
			if (!TreadLength.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(TreadLength.Value);
		}
		set
		{
			TreadLength = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcStairFlight), 13)]
	Xbim.Ifc4.Interfaces.IfcStairFlightTypeEnum? IIfcStairFlight.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcStairFlightTypeEnum.CURVED => Xbim.Ifc4.Interfaces.IfcStairFlightTypeEnum.CURVED, 
				IfcStairFlightTypeEnum.FREEFORM => Xbim.Ifc4.Interfaces.IfcStairFlightTypeEnum.FREEFORM, 
				IfcStairFlightTypeEnum.SPIRAL => Xbim.Ifc4.Interfaces.IfcStairFlightTypeEnum.SPIRAL, 
				IfcStairFlightTypeEnum.STRAIGHT => Xbim.Ifc4.Interfaces.IfcStairFlightTypeEnum.STRAIGHT, 
				IfcStairFlightTypeEnum.WINDER => Xbim.Ifc4.Interfaces.IfcStairFlightTypeEnum.WINDER, 
				IfcStairFlightTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcStairFlightTypeEnum.USERDEFINED, 
				IfcStairFlightTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcStairFlightTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcStairFlightTypeEnum.STRAIGHT:
				PredefinedType = IfcStairFlightTypeEnum.STRAIGHT;
				break;
			case Xbim.Ifc4.Interfaces.IfcStairFlightTypeEnum.WINDER:
				PredefinedType = IfcStairFlightTypeEnum.WINDER;
				break;
			case Xbim.Ifc4.Interfaces.IfcStairFlightTypeEnum.SPIRAL:
				PredefinedType = IfcStairFlightTypeEnum.SPIRAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcStairFlightTypeEnum.CURVED:
				PredefinedType = IfcStairFlightTypeEnum.CURVED;
				break;
			case Xbim.Ifc4.Interfaces.IfcStairFlightTypeEnum.FREEFORM:
				PredefinedType = IfcStairFlightTypeEnum.FREEFORM;
				break;
			case Xbim.Ifc4.Interfaces.IfcStairFlightTypeEnum.USERDEFINED:
				PredefinedType = IfcStairFlightTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcStairFlightTypeEnum.NOTDEFINED:
				PredefinedType = IfcStairFlightTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 35)]
	public Xbim.Ifc4x3.MeasureResource.IfcInteger? NumberOfRisers
	{
		get
		{
			if (_activated)
			{
				return _numberOfRisers;
			}
			Activate();
			return _numberOfRisers;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcInteger? v)
			{
				_numberOfRisers = v;
			}, _numberOfRisers, value, "NumberOfRisers", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 36)]
	public Xbim.Ifc4x3.MeasureResource.IfcInteger? NumberOfTreads
	{
		get
		{
			if (_activated)
			{
				return _numberOfTreads;
			}
			Activate();
			return _numberOfTreads;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcInteger? v)
			{
				_numberOfTreads = v;
			}, _numberOfTreads, value, "NumberOfTreads", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 37)]
	public Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? RiserHeight
	{
		get
		{
			if (_activated)
			{
				return _riserHeight;
			}
			Activate();
			return _riserHeight;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? v)
			{
				_riserHeight = v;
			}, _riserHeight, value, "RiserHeight", 11);
		}
	}

	[EntityAttribute(12, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 38)]
	public Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? TreadLength
	{
		get
		{
			if (_activated)
			{
				return _treadLength;
			}
			Activate();
			return _treadLength;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? v)
			{
				_treadLength = v;
			}, _treadLength, value, "TreadLength", 12);
		}
	}

	[EntityAttribute(13, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 39)]
	public IfcStairFlightTypeEnum? PredefinedType
	{
		get
		{
			if (_activated)
			{
				return _predefinedType;
			}
			Activate();
			return _predefinedType;
		}
		set
		{
			SetValue(delegate(IfcStairFlightTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 13);
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

	internal IfcStairFlight(IModel model, int label, bool activated)
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
			_numberOfRisers = value.IntegerVal;
			break;
		case 9:
			_numberOfTreads = value.IntegerVal;
			break;
		case 10:
			_riserHeight = value.RealVal;
			break;
		case 11:
			_treadLength = value.RealVal;
			break;
		case 12:
			_predefinedType = (IfcStairFlightTypeEnum)Enum.Parse(typeof(IfcStairFlightTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcStairFlight other)
	{
		return this == other;
	}
}
