using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.MeasureResource;
using Xbim.Ifc4x3.ProductExtension;

namespace Xbim.Ifc4x3.SharedBldgElements;

[ExpressType("IfcBuildingSystem", 1108)]
public class IfcBuildingSystem : IfcSystem, IIfcBuildingSystem, IIfcSystem, IIfcGroup, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcBuildingSystem>
{
	private IfcBuildingSystemTypeEnum? _predefinedType;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _longName;

	[CrossSchemaAttribute(typeof(IIfcBuildingSystem), 6)]
	Xbim.Ifc4.Interfaces.IfcBuildingSystemTypeEnum? IIfcBuildingSystem.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcBuildingSystemTypeEnum.FENESTRATION => Xbim.Ifc4.Interfaces.IfcBuildingSystemTypeEnum.FENESTRATION, 
				IfcBuildingSystemTypeEnum.FOUNDATION => Xbim.Ifc4.Interfaces.IfcBuildingSystemTypeEnum.FOUNDATION, 
				IfcBuildingSystemTypeEnum.LOADBEARING => Xbim.Ifc4.Interfaces.IfcBuildingSystemTypeEnum.LOADBEARING, 
				IfcBuildingSystemTypeEnum.OUTERSHELL => Xbim.Ifc4.Interfaces.IfcBuildingSystemTypeEnum.OUTERSHELL, 
				IfcBuildingSystemTypeEnum.SHADING => Xbim.Ifc4.Interfaces.IfcBuildingSystemTypeEnum.SHADING, 
				IfcBuildingSystemTypeEnum.TRANSPORT => Xbim.Ifc4.Interfaces.IfcBuildingSystemTypeEnum.TRANSPORT, 
				IfcBuildingSystemTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcBuildingSystemTypeEnum.USERDEFINED, 
				IfcBuildingSystemTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcBuildingSystemTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcBuildingSystemTypeEnum.FENESTRATION:
				PredefinedType = IfcBuildingSystemTypeEnum.FENESTRATION;
				break;
			case Xbim.Ifc4.Interfaces.IfcBuildingSystemTypeEnum.FOUNDATION:
				PredefinedType = IfcBuildingSystemTypeEnum.FOUNDATION;
				break;
			case Xbim.Ifc4.Interfaces.IfcBuildingSystemTypeEnum.LOADBEARING:
				PredefinedType = IfcBuildingSystemTypeEnum.LOADBEARING;
				break;
			case Xbim.Ifc4.Interfaces.IfcBuildingSystemTypeEnum.OUTERSHELL:
				PredefinedType = IfcBuildingSystemTypeEnum.OUTERSHELL;
				break;
			case Xbim.Ifc4.Interfaces.IfcBuildingSystemTypeEnum.SHADING:
				PredefinedType = IfcBuildingSystemTypeEnum.SHADING;
				break;
			case Xbim.Ifc4.Interfaces.IfcBuildingSystemTypeEnum.TRANSPORT:
				PredefinedType = IfcBuildingSystemTypeEnum.TRANSPORT;
				break;
			case Xbim.Ifc4.Interfaces.IfcBuildingSystemTypeEnum.USERDEFINED:
				PredefinedType = IfcBuildingSystemTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcBuildingSystemTypeEnum.NOTDEFINED:
				PredefinedType = IfcBuildingSystemTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcBuildingSystem), 7)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcBuildingSystem.LongName
	{
		get
		{
			if (!LongName.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(LongName.Value);
		}
		set
		{
			LongName = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 21)]
	public IfcBuildingSystemTypeEnum? PredefinedType
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
			SetValue(delegate(IfcBuildingSystemTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 22)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? LongName
	{
		get
		{
			if (_activated)
			{
				return _longName;
			}
			Activate();
			return _longName;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
			{
				_longName = v;
			}, _longName, value, "LongName", 7);
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
		}
	}

	internal IfcBuildingSystem(IModel model, int label, bool activated)
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
			_predefinedType = (IfcBuildingSystemTypeEnum)Enum.Parse(typeof(IfcBuildingSystemTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 6:
			_longName = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcBuildingSystem other)
	{
		return this == other;
	}
}
