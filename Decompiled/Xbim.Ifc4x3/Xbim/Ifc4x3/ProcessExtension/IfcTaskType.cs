using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.Kernel;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.ProcessExtension;

[ExpressType("IfcTaskType", 1296)]
public class IfcTaskType : Xbim.Ifc4x3.Kernel.IfcTypeProcess, IIfcTaskType, IIfcTypeProcess, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProcessSelect, IIfcProcessSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcTaskType>
{
	private IfcTaskTypeEnum _predefinedType;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _workMethod;

	[CrossSchemaAttribute(typeof(IIfcTaskType), 10)]
	Xbim.Ifc4.Interfaces.IfcTaskTypeEnum IIfcTaskType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcTaskTypeEnum.ADJUSTMENT => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcTaskTypeEnum>(), 
				IfcTaskTypeEnum.ATTENDANCE => Xbim.Ifc4.Interfaces.IfcTaskTypeEnum.ATTENDANCE, 
				IfcTaskTypeEnum.CALIBRATION => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcTaskTypeEnum>(), 
				IfcTaskTypeEnum.CONSTRUCTION => Xbim.Ifc4.Interfaces.IfcTaskTypeEnum.CONSTRUCTION, 
				IfcTaskTypeEnum.DEMOLITION => Xbim.Ifc4.Interfaces.IfcTaskTypeEnum.DEMOLITION, 
				IfcTaskTypeEnum.DISMANTLE => Xbim.Ifc4.Interfaces.IfcTaskTypeEnum.DISMANTLE, 
				IfcTaskTypeEnum.DISPOSAL => Xbim.Ifc4.Interfaces.IfcTaskTypeEnum.DISPOSAL, 
				IfcTaskTypeEnum.EMERGENCY => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcTaskTypeEnum>(), 
				IfcTaskTypeEnum.INSPECTION => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcTaskTypeEnum>(), 
				IfcTaskTypeEnum.INSTALLATION => Xbim.Ifc4.Interfaces.IfcTaskTypeEnum.INSTALLATION, 
				IfcTaskTypeEnum.LOGISTIC => Xbim.Ifc4.Interfaces.IfcTaskTypeEnum.LOGISTIC, 
				IfcTaskTypeEnum.MAINTENANCE => Xbim.Ifc4.Interfaces.IfcTaskTypeEnum.MAINTENANCE, 
				IfcTaskTypeEnum.MOVE => Xbim.Ifc4.Interfaces.IfcTaskTypeEnum.MOVE, 
				IfcTaskTypeEnum.OPERATION => Xbim.Ifc4.Interfaces.IfcTaskTypeEnum.OPERATION, 
				IfcTaskTypeEnum.REMOVAL => Xbim.Ifc4.Interfaces.IfcTaskTypeEnum.REMOVAL, 
				IfcTaskTypeEnum.RENOVATION => Xbim.Ifc4.Interfaces.IfcTaskTypeEnum.RENOVATION, 
				IfcTaskTypeEnum.SAFETY => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcTaskTypeEnum>(), 
				IfcTaskTypeEnum.SHUTDOWN => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcTaskTypeEnum>(), 
				IfcTaskTypeEnum.STARTUP => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcTaskTypeEnum>(), 
				IfcTaskTypeEnum.TESTING => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcTaskTypeEnum>(), 
				IfcTaskTypeEnum.TROUBLESHOOTING => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcTaskTypeEnum>(), 
				IfcTaskTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcTaskTypeEnum.USERDEFINED, 
				IfcTaskTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcTaskTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcTaskTypeEnum.ATTENDANCE:
				PredefinedType = IfcTaskTypeEnum.ATTENDANCE;
				break;
			case Xbim.Ifc4.Interfaces.IfcTaskTypeEnum.CONSTRUCTION:
				PredefinedType = IfcTaskTypeEnum.CONSTRUCTION;
				break;
			case Xbim.Ifc4.Interfaces.IfcTaskTypeEnum.DEMOLITION:
				PredefinedType = IfcTaskTypeEnum.DEMOLITION;
				break;
			case Xbim.Ifc4.Interfaces.IfcTaskTypeEnum.DISMANTLE:
				PredefinedType = IfcTaskTypeEnum.DISMANTLE;
				break;
			case Xbim.Ifc4.Interfaces.IfcTaskTypeEnum.DISPOSAL:
				PredefinedType = IfcTaskTypeEnum.DISPOSAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcTaskTypeEnum.INSTALLATION:
				PredefinedType = IfcTaskTypeEnum.INSTALLATION;
				break;
			case Xbim.Ifc4.Interfaces.IfcTaskTypeEnum.LOGISTIC:
				PredefinedType = IfcTaskTypeEnum.LOGISTIC;
				break;
			case Xbim.Ifc4.Interfaces.IfcTaskTypeEnum.MAINTENANCE:
				PredefinedType = IfcTaskTypeEnum.MAINTENANCE;
				break;
			case Xbim.Ifc4.Interfaces.IfcTaskTypeEnum.MOVE:
				PredefinedType = IfcTaskTypeEnum.MOVE;
				break;
			case Xbim.Ifc4.Interfaces.IfcTaskTypeEnum.OPERATION:
				PredefinedType = IfcTaskTypeEnum.OPERATION;
				break;
			case Xbim.Ifc4.Interfaces.IfcTaskTypeEnum.REMOVAL:
				PredefinedType = IfcTaskTypeEnum.REMOVAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcTaskTypeEnum.RENOVATION:
				PredefinedType = IfcTaskTypeEnum.RENOVATION;
				break;
			case Xbim.Ifc4.Interfaces.IfcTaskTypeEnum.USERDEFINED:
				PredefinedType = IfcTaskTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcTaskTypeEnum.NOTDEFINED:
				PredefinedType = IfcTaskTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcTaskType), 11)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcTaskType.WorkMethod
	{
		get
		{
			if (!WorkMethod.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(WorkMethod.Value);
		}
		set
		{
			WorkMethod = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcTaskTypeEnum PredefinedType
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
			SetValue(delegate(IfcTaskTypeEnum v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 20)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? WorkMethod
	{
		get
		{
			if (_activated)
			{
				return _workMethod;
			}
			Activate();
			return _workMethod;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
			{
				_workMethod = v;
			}, _workMethod, value, "WorkMethod", 11);
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
			foreach (Xbim.Ifc4x3.Kernel.IfcPropertySetDefinition hasPropertySet in base.HasPropertySets)
			{
				yield return hasPropertySet;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (Xbim.Ifc4x3.Kernel.IfcPropertySetDefinition hasPropertySet in base.HasPropertySets)
			{
				yield return hasPropertySet;
			}
		}
	}

	internal IfcTaskType(IModel model, int label, bool activated)
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
		case 8:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 9:
			_predefinedType = (IfcTaskTypeEnum)Enum.Parse(typeof(IfcTaskTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 10:
			_workMethod = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcTaskType other)
	{
		return this == other;
	}
}
