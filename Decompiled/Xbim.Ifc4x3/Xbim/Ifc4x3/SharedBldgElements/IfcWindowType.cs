using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.GeometryResource;
using Xbim.Ifc4x3.Kernel;
using Xbim.Ifc4x3.MeasureResource;
using Xbim.Ifc4x3.ProductExtension;

namespace Xbim.Ifc4x3.SharedBldgElements;

[ExpressType("IfcWindowType", 1317)]
public class IfcWindowType : IfcBuiltElementType, IIfcWindowType, IIfcBuildingElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcWindowType>
{
	private IfcWindowTypeEnum _predefinedType;

	private IfcWindowTypePartitioningEnum _partitioningType;

	private Xbim.Ifc4x3.MeasureResource.IfcBoolean? _parameterTakesPrecedence;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _userDefinedPartitioningType;

	[CrossSchemaAttribute(typeof(IIfcWindowType), 10)]
	Xbim.Ifc4.Interfaces.IfcWindowTypeEnum IIfcWindowType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcWindowTypeEnum.LIGHTDOME => Xbim.Ifc4.Interfaces.IfcWindowTypeEnum.LIGHTDOME, 
				IfcWindowTypeEnum.SKYLIGHT => Xbim.Ifc4.Interfaces.IfcWindowTypeEnum.SKYLIGHT, 
				IfcWindowTypeEnum.WINDOW => Xbim.Ifc4.Interfaces.IfcWindowTypeEnum.WINDOW, 
				IfcWindowTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcWindowTypeEnum.USERDEFINED, 
				IfcWindowTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcWindowTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcWindowTypeEnum.WINDOW:
				PredefinedType = IfcWindowTypeEnum.WINDOW;
				break;
			case Xbim.Ifc4.Interfaces.IfcWindowTypeEnum.SKYLIGHT:
				PredefinedType = IfcWindowTypeEnum.SKYLIGHT;
				break;
			case Xbim.Ifc4.Interfaces.IfcWindowTypeEnum.LIGHTDOME:
				PredefinedType = IfcWindowTypeEnum.LIGHTDOME;
				break;
			case Xbim.Ifc4.Interfaces.IfcWindowTypeEnum.USERDEFINED:
				PredefinedType = IfcWindowTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcWindowTypeEnum.NOTDEFINED:
				PredefinedType = IfcWindowTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcWindowType), 11)]
	Xbim.Ifc4.Interfaces.IfcWindowTypePartitioningEnum IIfcWindowType.PartitioningType
	{
		get
		{
			return PartitioningType switch
			{
				IfcWindowTypePartitioningEnum.DOUBLE_PANEL_HORIZONTAL => Xbim.Ifc4.Interfaces.IfcWindowTypePartitioningEnum.DOUBLE_PANEL_HORIZONTAL, 
				IfcWindowTypePartitioningEnum.DOUBLE_PANEL_VERTICAL => Xbim.Ifc4.Interfaces.IfcWindowTypePartitioningEnum.DOUBLE_PANEL_VERTICAL, 
				IfcWindowTypePartitioningEnum.SINGLE_PANEL => Xbim.Ifc4.Interfaces.IfcWindowTypePartitioningEnum.SINGLE_PANEL, 
				IfcWindowTypePartitioningEnum.TRIPLE_PANEL_BOTTOM => Xbim.Ifc4.Interfaces.IfcWindowTypePartitioningEnum.TRIPLE_PANEL_BOTTOM, 
				IfcWindowTypePartitioningEnum.TRIPLE_PANEL_HORIZONTAL => Xbim.Ifc4.Interfaces.IfcWindowTypePartitioningEnum.TRIPLE_PANEL_HORIZONTAL, 
				IfcWindowTypePartitioningEnum.TRIPLE_PANEL_LEFT => Xbim.Ifc4.Interfaces.IfcWindowTypePartitioningEnum.TRIPLE_PANEL_LEFT, 
				IfcWindowTypePartitioningEnum.TRIPLE_PANEL_RIGHT => Xbim.Ifc4.Interfaces.IfcWindowTypePartitioningEnum.TRIPLE_PANEL_RIGHT, 
				IfcWindowTypePartitioningEnum.TRIPLE_PANEL_TOP => Xbim.Ifc4.Interfaces.IfcWindowTypePartitioningEnum.TRIPLE_PANEL_TOP, 
				IfcWindowTypePartitioningEnum.TRIPLE_PANEL_VERTICAL => Xbim.Ifc4.Interfaces.IfcWindowTypePartitioningEnum.TRIPLE_PANEL_VERTICAL, 
				IfcWindowTypePartitioningEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcWindowTypePartitioningEnum.USERDEFINED, 
				IfcWindowTypePartitioningEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcWindowTypePartitioningEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcWindowTypePartitioningEnum.SINGLE_PANEL:
				PartitioningType = IfcWindowTypePartitioningEnum.SINGLE_PANEL;
				break;
			case Xbim.Ifc4.Interfaces.IfcWindowTypePartitioningEnum.DOUBLE_PANEL_VERTICAL:
				PartitioningType = IfcWindowTypePartitioningEnum.DOUBLE_PANEL_VERTICAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcWindowTypePartitioningEnum.DOUBLE_PANEL_HORIZONTAL:
				PartitioningType = IfcWindowTypePartitioningEnum.DOUBLE_PANEL_HORIZONTAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcWindowTypePartitioningEnum.TRIPLE_PANEL_VERTICAL:
				PartitioningType = IfcWindowTypePartitioningEnum.TRIPLE_PANEL_VERTICAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcWindowTypePartitioningEnum.TRIPLE_PANEL_BOTTOM:
				PartitioningType = IfcWindowTypePartitioningEnum.TRIPLE_PANEL_BOTTOM;
				break;
			case Xbim.Ifc4.Interfaces.IfcWindowTypePartitioningEnum.TRIPLE_PANEL_TOP:
				PartitioningType = IfcWindowTypePartitioningEnum.TRIPLE_PANEL_TOP;
				break;
			case Xbim.Ifc4.Interfaces.IfcWindowTypePartitioningEnum.TRIPLE_PANEL_LEFT:
				PartitioningType = IfcWindowTypePartitioningEnum.TRIPLE_PANEL_LEFT;
				break;
			case Xbim.Ifc4.Interfaces.IfcWindowTypePartitioningEnum.TRIPLE_PANEL_RIGHT:
				PartitioningType = IfcWindowTypePartitioningEnum.TRIPLE_PANEL_RIGHT;
				break;
			case Xbim.Ifc4.Interfaces.IfcWindowTypePartitioningEnum.TRIPLE_PANEL_HORIZONTAL:
				PartitioningType = IfcWindowTypePartitioningEnum.TRIPLE_PANEL_HORIZONTAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcWindowTypePartitioningEnum.USERDEFINED:
				PartitioningType = IfcWindowTypePartitioningEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcWindowTypePartitioningEnum.NOTDEFINED:
				PartitioningType = IfcWindowTypePartitioningEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcWindowType), 12)]
	Xbim.Ifc4.MeasureResource.IfcBoolean? IIfcWindowType.ParameterTakesPrecedence
	{
		get
		{
			if (!ParameterTakesPrecedence.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcBoolean(ParameterTakesPrecedence.Value);
		}
		set
		{
			ParameterTakesPrecedence = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcBoolean?(new Xbim.Ifc4x3.MeasureResource.IfcBoolean(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcBoolean?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcWindowType), 13)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcWindowType.UserDefinedPartitioningType
	{
		get
		{
			if (!UserDefinedPartitioningType.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(UserDefinedPartitioningType.Value);
		}
		set
		{
			UserDefinedPartitioningType = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcWindowTypeEnum PredefinedType
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
			SetValue(delegate(IfcWindowTypeEnum v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 20)]
	public IfcWindowTypePartitioningEnum PartitioningType
	{
		get
		{
			if (_activated)
			{
				return _partitioningType;
			}
			Activate();
			return _partitioningType;
		}
		set
		{
			SetValue(delegate(IfcWindowTypePartitioningEnum v)
			{
				_partitioningType = v;
			}, _partitioningType, value, "PartitioningType", 11);
		}
	}

	[EntityAttribute(12, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 21)]
	public Xbim.Ifc4x3.MeasureResource.IfcBoolean? ParameterTakesPrecedence
	{
		get
		{
			if (_activated)
			{
				return _parameterTakesPrecedence;
			}
			Activate();
			return _parameterTakesPrecedence;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcBoolean? v)
			{
				_parameterTakesPrecedence = v;
			}, _parameterTakesPrecedence, value, "ParameterTakesPrecedence", 12);
		}
	}

	[EntityAttribute(13, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 22)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? UserDefinedPartitioningType
	{
		get
		{
			if (_activated)
			{
				return _userDefinedPartitioningType;
			}
			Activate();
			return _userDefinedPartitioningType;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
			{
				_userDefinedPartitioningType = v;
			}, _userDefinedPartitioningType, value, "UserDefinedPartitioningType", 13);
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
			foreach (IfcRepresentationMap representationMap in base.RepresentationMaps)
			{
				yield return representationMap;
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

	internal IfcWindowType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcWindowTypeEnum)Enum.Parse(typeof(IfcWindowTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 10:
			_partitioningType = (IfcWindowTypePartitioningEnum)Enum.Parse(typeof(IfcWindowTypePartitioningEnum), value.EnumVal, ignoreCase: true);
			break;
		case 11:
			_parameterTakesPrecedence = value.BooleanVal;
			break;
		case 12:
			_userDefinedPartitioningType = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcWindowType other)
	{
		return this == other;
	}
}
