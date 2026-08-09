using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.DateTimeResource;
using Xbim.Ifc4x3.Kernel;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.ProcessExtension;

[ExpressType("IfcRelSequence", 490)]
public class IfcRelSequence : IfcRelConnects, IIfcRelSequence, IIfcRelConnects, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelSequence>
{
	private IfcProcess _relatingProcess;

	private IfcProcess _relatedProcess;

	private IfcLagTime _timeLag;

	private IfcSequenceEnum? _sequenceType;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _userDefinedSequenceType;

	[CrossSchemaAttribute(typeof(IIfcRelSequence), 5)]
	IIfcProcess IIfcRelSequence.RelatingProcess
	{
		get
		{
			return RelatingProcess;
		}
		set
		{
			RelatingProcess = value as IfcProcess;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcRelSequence), 6)]
	IIfcProcess IIfcRelSequence.RelatedProcess
	{
		get
		{
			return RelatedProcess;
		}
		set
		{
			RelatedProcess = value as IfcProcess;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcRelSequence), 7)]
	IIfcLagTime IIfcRelSequence.TimeLag
	{
		get
		{
			return TimeLag;
		}
		set
		{
			TimeLag = value as IfcLagTime;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcRelSequence), 8)]
	Xbim.Ifc4.Interfaces.IfcSequenceEnum? IIfcRelSequence.SequenceType
	{
		get
		{
			return SequenceType switch
			{
				IfcSequenceEnum.FINISH_FINISH => Xbim.Ifc4.Interfaces.IfcSequenceEnum.FINISH_FINISH, 
				IfcSequenceEnum.FINISH_START => Xbim.Ifc4.Interfaces.IfcSequenceEnum.FINISH_START, 
				IfcSequenceEnum.START_FINISH => Xbim.Ifc4.Interfaces.IfcSequenceEnum.START_FINISH, 
				IfcSequenceEnum.START_START => Xbim.Ifc4.Interfaces.IfcSequenceEnum.START_START, 
				IfcSequenceEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcSequenceEnum.USERDEFINED, 
				IfcSequenceEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcSequenceEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcSequenceEnum.START_START:
				SequenceType = IfcSequenceEnum.START_START;
				break;
			case Xbim.Ifc4.Interfaces.IfcSequenceEnum.START_FINISH:
				SequenceType = IfcSequenceEnum.START_FINISH;
				break;
			case Xbim.Ifc4.Interfaces.IfcSequenceEnum.FINISH_START:
				SequenceType = IfcSequenceEnum.FINISH_START;
				break;
			case Xbim.Ifc4.Interfaces.IfcSequenceEnum.FINISH_FINISH:
				SequenceType = IfcSequenceEnum.FINISH_FINISH;
				break;
			case Xbim.Ifc4.Interfaces.IfcSequenceEnum.USERDEFINED:
				SequenceType = IfcSequenceEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcSequenceEnum.NOTDEFINED:
				SequenceType = IfcSequenceEnum.NOTDEFINED;
				break;
			case null:
				SequenceType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcRelSequence), 9)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcRelSequence.UserDefinedSequenceType
	{
		get
		{
			if (!UserDefinedSequenceType.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(UserDefinedSequenceType.Value);
		}
		set
		{
			UserDefinedSequenceType = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	[IndexedProperty]
	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcProcess RelatingProcess
	{
		get
		{
			if (_activated)
			{
				return _relatingProcess;
			}
			Activate();
			return _relatingProcess;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcProcess v)
			{
				_relatingProcess = v;
			}, _relatingProcess, value, "RelatingProcess", 5);
		}
	}

	[IndexedProperty]
	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
	public IfcProcess RelatedProcess
	{
		get
		{
			if (_activated)
			{
				return _relatedProcess;
			}
			Activate();
			return _relatedProcess;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcProcess v)
			{
				_relatedProcess = v;
			}, _relatedProcess, value, "RelatedProcess", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 7)]
	public IfcLagTime TimeLag
	{
		get
		{
			if (_activated)
			{
				return _timeLag;
			}
			Activate();
			return _timeLag;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcLagTime v)
			{
				_timeLag = v;
			}, _timeLag, value, "TimeLag", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 8)]
	public IfcSequenceEnum? SequenceType
	{
		get
		{
			if (_activated)
			{
				return _sequenceType;
			}
			Activate();
			return _sequenceType;
		}
		set
		{
			SetValue(delegate(IfcSequenceEnum? v)
			{
				_sequenceType = v;
			}, _sequenceType, value, "SequenceType", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 9)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? UserDefinedSequenceType
	{
		get
		{
			if (_activated)
			{
				return _userDefinedSequenceType;
			}
			Activate();
			return _userDefinedSequenceType;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
			{
				_userDefinedSequenceType = v;
			}, _userDefinedSequenceType, value, "UserDefinedSequenceType", 9);
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
			if (RelatingProcess != null)
			{
				yield return RelatingProcess;
			}
			if (RelatedProcess != null)
			{
				yield return RelatedProcess;
			}
			if (TimeLag != null)
			{
				yield return TimeLag;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (RelatingProcess != null)
			{
				yield return RelatingProcess;
			}
			if (RelatedProcess != null)
			{
				yield return RelatedProcess;
			}
		}
	}

	internal IfcRelSequence(IModel model, int label, bool activated)
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
			_relatingProcess = (IfcProcess)value.EntityVal;
			break;
		case 5:
			_relatedProcess = (IfcProcess)value.EntityVal;
			break;
		case 6:
			_timeLag = (IfcLagTime)value.EntityVal;
			break;
		case 7:
			_sequenceType = (IfcSequenceEnum)Enum.Parse(typeof(IfcSequenceEnum), value.EnumVal, ignoreCase: true);
			break;
		case 8:
			_userDefinedSequenceType = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelSequence other)
	{
		return this == other;
	}
}
