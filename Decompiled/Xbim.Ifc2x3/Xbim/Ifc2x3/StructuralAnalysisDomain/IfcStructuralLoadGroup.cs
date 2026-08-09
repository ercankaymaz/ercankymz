using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.StructuralAnalysisDomain;

[ExpressType("IfcStructuralLoadGroup", 573)]
public class IfcStructuralLoadGroup : Xbim.Ifc2x3.Kernel.IfcGroup, IIfcStructuralLoadGroup, IIfcGroup, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcStructuralLoadGroup>
{
	private IfcLoadGroupTypeEnum _predefinedType;

	private IfcActionTypeEnum _actionType;

	private IfcActionSourceTypeEnum _actionSource;

	private Xbim.Ifc2x3.MeasureResource.IfcRatioMeasure? _coefficient;

	private Xbim.Ifc2x3.MeasureResource.IfcLabel? _purpose;

	[CrossSchemaAttribute(typeof(IIfcStructuralLoadGroup), 6)]
	Xbim.Ifc4.Interfaces.IfcLoadGroupTypeEnum IIfcStructuralLoadGroup.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcLoadGroupTypeEnum.LOAD_GROUP => Xbim.Ifc4.Interfaces.IfcLoadGroupTypeEnum.LOAD_GROUP, 
				IfcLoadGroupTypeEnum.LOAD_CASE => Xbim.Ifc4.Interfaces.IfcLoadGroupTypeEnum.LOAD_CASE, 
				IfcLoadGroupTypeEnum.LOAD_COMBINATION_GROUP => Xbim.Ifc4.Interfaces.IfcLoadGroupTypeEnum.USERDEFINED, 
				IfcLoadGroupTypeEnum.LOAD_COMBINATION => Xbim.Ifc4.Interfaces.IfcLoadGroupTypeEnum.LOAD_COMBINATION, 
				IfcLoadGroupTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcLoadGroupTypeEnum.USERDEFINED, 
				IfcLoadGroupTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcLoadGroupTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcLoadGroupTypeEnum.LOAD_GROUP:
				PredefinedType = IfcLoadGroupTypeEnum.LOAD_GROUP;
				break;
			case Xbim.Ifc4.Interfaces.IfcLoadGroupTypeEnum.LOAD_CASE:
				PredefinedType = IfcLoadGroupTypeEnum.LOAD_CASE;
				break;
			case Xbim.Ifc4.Interfaces.IfcLoadGroupTypeEnum.LOAD_COMBINATION:
				PredefinedType = IfcLoadGroupTypeEnum.LOAD_COMBINATION;
				break;
			case Xbim.Ifc4.Interfaces.IfcLoadGroupTypeEnum.USERDEFINED:
				PredefinedType = IfcLoadGroupTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcLoadGroupTypeEnum.NOTDEFINED:
				PredefinedType = IfcLoadGroupTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcStructuralLoadGroup), 7)]
	Xbim.Ifc4.Interfaces.IfcActionTypeEnum IIfcStructuralLoadGroup.ActionType
	{
		get
		{
			return ActionType switch
			{
				IfcActionTypeEnum.PERMANENT_G => Xbim.Ifc4.Interfaces.IfcActionTypeEnum.PERMANENT_G, 
				IfcActionTypeEnum.VARIABLE_Q => Xbim.Ifc4.Interfaces.IfcActionTypeEnum.VARIABLE_Q, 
				IfcActionTypeEnum.EXTRAORDINARY_A => Xbim.Ifc4.Interfaces.IfcActionTypeEnum.EXTRAORDINARY_A, 
				IfcActionTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcActionTypeEnum.USERDEFINED, 
				IfcActionTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcActionTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcActionTypeEnum.PERMANENT_G:
				ActionType = IfcActionTypeEnum.PERMANENT_G;
				break;
			case Xbim.Ifc4.Interfaces.IfcActionTypeEnum.VARIABLE_Q:
				ActionType = IfcActionTypeEnum.VARIABLE_Q;
				break;
			case Xbim.Ifc4.Interfaces.IfcActionTypeEnum.EXTRAORDINARY_A:
				ActionType = IfcActionTypeEnum.EXTRAORDINARY_A;
				break;
			case Xbim.Ifc4.Interfaces.IfcActionTypeEnum.USERDEFINED:
				ActionType = IfcActionTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcActionTypeEnum.NOTDEFINED:
				ActionType = IfcActionTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcStructuralLoadGroup), 8)]
	Xbim.Ifc4.Interfaces.IfcActionSourceTypeEnum IIfcStructuralLoadGroup.ActionSource
	{
		get
		{
			return ActionSource switch
			{
				IfcActionSourceTypeEnum.DEAD_LOAD_G => Xbim.Ifc4.Interfaces.IfcActionSourceTypeEnum.DEAD_LOAD_G, 
				IfcActionSourceTypeEnum.COMPLETION_G1 => Xbim.Ifc4.Interfaces.IfcActionSourceTypeEnum.COMPLETION_G1, 
				IfcActionSourceTypeEnum.LIVE_LOAD_Q => Xbim.Ifc4.Interfaces.IfcActionSourceTypeEnum.LIVE_LOAD_Q, 
				IfcActionSourceTypeEnum.SNOW_S => Xbim.Ifc4.Interfaces.IfcActionSourceTypeEnum.SNOW_S, 
				IfcActionSourceTypeEnum.WIND_W => Xbim.Ifc4.Interfaces.IfcActionSourceTypeEnum.WIND_W, 
				IfcActionSourceTypeEnum.PRESTRESSING_P => Xbim.Ifc4.Interfaces.IfcActionSourceTypeEnum.PRESTRESSING_P, 
				IfcActionSourceTypeEnum.SETTLEMENT_U => Xbim.Ifc4.Interfaces.IfcActionSourceTypeEnum.SETTLEMENT_U, 
				IfcActionSourceTypeEnum.TEMPERATURE_T => Xbim.Ifc4.Interfaces.IfcActionSourceTypeEnum.TEMPERATURE_T, 
				IfcActionSourceTypeEnum.EARTHQUAKE_E => Xbim.Ifc4.Interfaces.IfcActionSourceTypeEnum.EARTHQUAKE_E, 
				IfcActionSourceTypeEnum.FIRE => Xbim.Ifc4.Interfaces.IfcActionSourceTypeEnum.FIRE, 
				IfcActionSourceTypeEnum.IMPULSE => Xbim.Ifc4.Interfaces.IfcActionSourceTypeEnum.IMPULSE, 
				IfcActionSourceTypeEnum.IMPACT => Xbim.Ifc4.Interfaces.IfcActionSourceTypeEnum.IMPACT, 
				IfcActionSourceTypeEnum.TRANSPORT => Xbim.Ifc4.Interfaces.IfcActionSourceTypeEnum.TRANSPORT, 
				IfcActionSourceTypeEnum.ERECTION => Xbim.Ifc4.Interfaces.IfcActionSourceTypeEnum.ERECTION, 
				IfcActionSourceTypeEnum.PROPPING => Xbim.Ifc4.Interfaces.IfcActionSourceTypeEnum.PROPPING, 
				IfcActionSourceTypeEnum.SYSTEM_IMPERFECTION => Xbim.Ifc4.Interfaces.IfcActionSourceTypeEnum.SYSTEM_IMPERFECTION, 
				IfcActionSourceTypeEnum.SHRINKAGE => Xbim.Ifc4.Interfaces.IfcActionSourceTypeEnum.SHRINKAGE, 
				IfcActionSourceTypeEnum.CREEP => Xbim.Ifc4.Interfaces.IfcActionSourceTypeEnum.CREEP, 
				IfcActionSourceTypeEnum.LACK_OF_FIT => Xbim.Ifc4.Interfaces.IfcActionSourceTypeEnum.LACK_OF_FIT, 
				IfcActionSourceTypeEnum.BUOYANCY => Xbim.Ifc4.Interfaces.IfcActionSourceTypeEnum.BUOYANCY, 
				IfcActionSourceTypeEnum.ICE => Xbim.Ifc4.Interfaces.IfcActionSourceTypeEnum.ICE, 
				IfcActionSourceTypeEnum.CURRENT => Xbim.Ifc4.Interfaces.IfcActionSourceTypeEnum.CURRENT, 
				IfcActionSourceTypeEnum.WAVE => Xbim.Ifc4.Interfaces.IfcActionSourceTypeEnum.WAVE, 
				IfcActionSourceTypeEnum.RAIN => Xbim.Ifc4.Interfaces.IfcActionSourceTypeEnum.RAIN, 
				IfcActionSourceTypeEnum.BRAKES => Xbim.Ifc4.Interfaces.IfcActionSourceTypeEnum.BRAKES, 
				IfcActionSourceTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcActionSourceTypeEnum.USERDEFINED, 
				IfcActionSourceTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcActionSourceTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcActionSourceTypeEnum.DEAD_LOAD_G:
				ActionSource = IfcActionSourceTypeEnum.DEAD_LOAD_G;
				break;
			case Xbim.Ifc4.Interfaces.IfcActionSourceTypeEnum.COMPLETION_G1:
				ActionSource = IfcActionSourceTypeEnum.COMPLETION_G1;
				break;
			case Xbim.Ifc4.Interfaces.IfcActionSourceTypeEnum.LIVE_LOAD_Q:
				ActionSource = IfcActionSourceTypeEnum.LIVE_LOAD_Q;
				break;
			case Xbim.Ifc4.Interfaces.IfcActionSourceTypeEnum.SNOW_S:
				ActionSource = IfcActionSourceTypeEnum.SNOW_S;
				break;
			case Xbim.Ifc4.Interfaces.IfcActionSourceTypeEnum.WIND_W:
				ActionSource = IfcActionSourceTypeEnum.WIND_W;
				break;
			case Xbim.Ifc4.Interfaces.IfcActionSourceTypeEnum.PRESTRESSING_P:
				ActionSource = IfcActionSourceTypeEnum.PRESTRESSING_P;
				break;
			case Xbim.Ifc4.Interfaces.IfcActionSourceTypeEnum.SETTLEMENT_U:
				ActionSource = IfcActionSourceTypeEnum.SETTLEMENT_U;
				break;
			case Xbim.Ifc4.Interfaces.IfcActionSourceTypeEnum.TEMPERATURE_T:
				ActionSource = IfcActionSourceTypeEnum.TEMPERATURE_T;
				break;
			case Xbim.Ifc4.Interfaces.IfcActionSourceTypeEnum.EARTHQUAKE_E:
				ActionSource = IfcActionSourceTypeEnum.EARTHQUAKE_E;
				break;
			case Xbim.Ifc4.Interfaces.IfcActionSourceTypeEnum.FIRE:
				ActionSource = IfcActionSourceTypeEnum.FIRE;
				break;
			case Xbim.Ifc4.Interfaces.IfcActionSourceTypeEnum.IMPULSE:
				ActionSource = IfcActionSourceTypeEnum.IMPULSE;
				break;
			case Xbim.Ifc4.Interfaces.IfcActionSourceTypeEnum.IMPACT:
				ActionSource = IfcActionSourceTypeEnum.IMPACT;
				break;
			case Xbim.Ifc4.Interfaces.IfcActionSourceTypeEnum.TRANSPORT:
				ActionSource = IfcActionSourceTypeEnum.TRANSPORT;
				break;
			case Xbim.Ifc4.Interfaces.IfcActionSourceTypeEnum.ERECTION:
				ActionSource = IfcActionSourceTypeEnum.ERECTION;
				break;
			case Xbim.Ifc4.Interfaces.IfcActionSourceTypeEnum.PROPPING:
				ActionSource = IfcActionSourceTypeEnum.PROPPING;
				break;
			case Xbim.Ifc4.Interfaces.IfcActionSourceTypeEnum.SYSTEM_IMPERFECTION:
				ActionSource = IfcActionSourceTypeEnum.SYSTEM_IMPERFECTION;
				break;
			case Xbim.Ifc4.Interfaces.IfcActionSourceTypeEnum.SHRINKAGE:
				ActionSource = IfcActionSourceTypeEnum.SHRINKAGE;
				break;
			case Xbim.Ifc4.Interfaces.IfcActionSourceTypeEnum.CREEP:
				ActionSource = IfcActionSourceTypeEnum.CREEP;
				break;
			case Xbim.Ifc4.Interfaces.IfcActionSourceTypeEnum.LACK_OF_FIT:
				ActionSource = IfcActionSourceTypeEnum.LACK_OF_FIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcActionSourceTypeEnum.BUOYANCY:
				ActionSource = IfcActionSourceTypeEnum.BUOYANCY;
				break;
			case Xbim.Ifc4.Interfaces.IfcActionSourceTypeEnum.ICE:
				ActionSource = IfcActionSourceTypeEnum.ICE;
				break;
			case Xbim.Ifc4.Interfaces.IfcActionSourceTypeEnum.CURRENT:
				ActionSource = IfcActionSourceTypeEnum.CURRENT;
				break;
			case Xbim.Ifc4.Interfaces.IfcActionSourceTypeEnum.WAVE:
				ActionSource = IfcActionSourceTypeEnum.WAVE;
				break;
			case Xbim.Ifc4.Interfaces.IfcActionSourceTypeEnum.RAIN:
				ActionSource = IfcActionSourceTypeEnum.RAIN;
				break;
			case Xbim.Ifc4.Interfaces.IfcActionSourceTypeEnum.BRAKES:
				ActionSource = IfcActionSourceTypeEnum.BRAKES;
				break;
			case Xbim.Ifc4.Interfaces.IfcActionSourceTypeEnum.USERDEFINED:
				ActionSource = IfcActionSourceTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcActionSourceTypeEnum.NOTDEFINED:
				ActionSource = IfcActionSourceTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcStructuralLoadGroup), 9)]
	Xbim.Ifc4.MeasureResource.IfcRatioMeasure? IIfcStructuralLoadGroup.Coefficient
	{
		get
		{
			if (!Coefficient.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcRatioMeasure(Coefficient.Value);
		}
		set
		{
			Coefficient = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcRatioMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcRatioMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcRatioMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcStructuralLoadGroup), 10)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcStructuralLoadGroup.Purpose
	{
		get
		{
			if (!Purpose.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Purpose.Value);
		}
		set
		{
			Purpose = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLabel?(new Xbim.Ifc2x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLabel?)null));
		}
	}

	IEnumerable<IIfcStructuralResultGroup> IIfcStructuralLoadGroup.SourceOfResultGroup => base.Model.Instances.Where((IIfcStructuralResultGroup e) => e.ResultForLoadGroup as IfcStructuralLoadGroup == this, "ResultForLoadGroup", this);

	IEnumerable<IIfcStructuralAnalysisModel> IIfcStructuralLoadGroup.LoadGroupFor => base.Model.Instances.Where((IIfcStructuralAnalysisModel e) => e.LoadedBy != null && e.LoadedBy.Contains(this), "LoadedBy", this);

	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcObject.ObjectType
	{
		get
		{
			if (PredefinedType == IfcLoadGroupTypeEnum.LOAD_COMBINATION_GROUP)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLabel("LOAD_COMBINATION_GROUP");
			}
			Xbim.Ifc4.MeasureResource.IfcLabel value;
			if (!base.ObjectType.HasValue)
			{
				value = null;
			}
			else
			{
				Xbim.Ifc2x3.MeasureResource.IfcLabel? objectType = base.ObjectType;
				value = new Xbim.Ifc4.MeasureResource.IfcLabel(objectType.HasValue ? ((string)objectType.GetValueOrDefault()) : null);
			}
			return value;
		}
		set
		{
			if (!value.HasValue)
			{
				base.ObjectType = null;
				return;
			}
			string text = value.Value.ToString();
			if (string.Equals(text, "LOAD_COMBINATION_GROUP", StringComparison.OrdinalIgnoreCase))
			{
				PredefinedType = IfcLoadGroupTypeEnum.LOAD_COMBINATION_GROUP;
				base.ObjectType = text;
			}
		}
	}

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 12)]
	public IfcLoadGroupTypeEnum PredefinedType
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
			SetValue(delegate(IfcLoadGroupTypeEnum v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 13)]
	public IfcActionTypeEnum ActionType
	{
		get
		{
			if (_activated)
			{
				return _actionType;
			}
			Activate();
			return _actionType;
		}
		set
		{
			SetValue(delegate(IfcActionTypeEnum v)
			{
				_actionType = v;
			}, _actionType, value, "ActionType", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 14)]
	public IfcActionSourceTypeEnum ActionSource
	{
		get
		{
			if (_activated)
			{
				return _actionSource;
			}
			Activate();
			return _actionSource;
		}
		set
		{
			SetValue(delegate(IfcActionSourceTypeEnum v)
			{
				_actionSource = v;
			}, _actionSource, value, "ActionSource", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 15)]
	public Xbim.Ifc2x3.MeasureResource.IfcRatioMeasure? Coefficient
	{
		get
		{
			if (_activated)
			{
				return _coefficient;
			}
			Activate();
			return _coefficient;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcRatioMeasure? v)
			{
				_coefficient = v;
			}, _coefficient, value, "Coefficient", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 16)]
	public Xbim.Ifc2x3.MeasureResource.IfcLabel? Purpose
	{
		get
		{
			if (_activated)
			{
				return _purpose;
			}
			Activate();
			return _purpose;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel? v)
			{
				_purpose = v;
			}, _purpose, value, "Purpose", 10);
		}
	}

	[InverseProperty("ResultForLoadGroup")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 17)]
	public IEnumerable<IfcStructuralResultGroup> SourceOfResultGroup => base.Model.Instances.Where((IfcStructuralResultGroup e) => Equals(e.ResultForLoadGroup), "ResultForLoadGroup", this);

	[InverseProperty("LoadedBy")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 18)]
	public IEnumerable<IfcStructuralAnalysisModel> LoadGroupFor => base.Model.Instances.Where((IfcStructuralAnalysisModel e) => e.LoadedBy != null && e.LoadedBy.Contains(this), "LoadedBy", this);

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.OwnerHistory != null)
			{
				yield return base.OwnerHistory;
			}
		}
	}

	internal IfcStructuralLoadGroup(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 5:
			_predefinedType = (IfcLoadGroupTypeEnum)Enum.Parse(typeof(IfcLoadGroupTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 6:
			_actionType = (IfcActionTypeEnum)Enum.Parse(typeof(IfcActionTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 7:
			_actionSource = (IfcActionSourceTypeEnum)Enum.Parse(typeof(IfcActionSourceTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 8:
			_coefficient = value.RealVal;
			break;
		case 9:
			_purpose = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcStructuralLoadGroup other)
	{
		return this == other;
	}
}
