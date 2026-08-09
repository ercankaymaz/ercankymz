using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.ProductExtension;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.StructuralAnalysisDomain;

namespace Xbim.Ifc2x3.SharedBldgElements;

[ExpressType("IfcStairFlight", 25)]
public class IfcStairFlight : IfcBuildingElement, IIfcStairFlight, IIfcBuildingElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcStairFlight>
{
	private Xbim.Ifc4.Interfaces.IfcStairFlightTypeEnum? _predefinedType;

	private long? _numberOfRiser;

	private long? _numberOfTreads;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? _riserHeight;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? _treadLength;

	[CrossSchemaAttribute(typeof(IIfcStairFlight), 9)]
	Xbim.Ifc4.MeasureResource.IfcInteger? IIfcStairFlight.NumberOfRisers
	{
		get
		{
			if (!NumberOfRiser.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcInteger(NumberOfRiser.Value);
		}
		set
		{
			NumberOfRiser = value;
			NotifyPropertyChanged("NumberOfRisers");
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
			NumberOfTreads = value;
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
			RiserHeight = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure?)null));
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
			TreadLength = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcStairFlight), 13)]
	Xbim.Ifc4.Interfaces.IfcStairFlightTypeEnum? IIfcStairFlight.PredefinedType
	{
		get
		{
			return _predefinedType;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4.Interfaces.IfcStairFlightTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", -13);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 27)]
	public long? NumberOfRiser
	{
		get
		{
			if (_activated)
			{
				return _numberOfRiser;
			}
			Activate();
			return _numberOfRiser;
		}
		set
		{
			SetValue(delegate(long? v)
			{
				_numberOfRiser = v;
			}, _numberOfRiser, value, "NumberOfRiser", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 28)]
	public long? NumberOfTreads
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
			SetValue(delegate(long? v)
			{
				_numberOfTreads = v;
			}, _numberOfTreads, value, "NumberOfTreads", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 29)]
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? RiserHeight
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? v)
			{
				_riserHeight = v;
			}, _riserHeight, value, "RiserHeight", 11);
		}
	}

	[EntityAttribute(12, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 30)]
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? TreadLength
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? v)
			{
				_treadLength = v;
			}, _treadLength, value, "TreadLength", 12);
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
			_numberOfRiser = value.IntegerVal;
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
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcStairFlight other)
	{
		return this == other;
	}
}
