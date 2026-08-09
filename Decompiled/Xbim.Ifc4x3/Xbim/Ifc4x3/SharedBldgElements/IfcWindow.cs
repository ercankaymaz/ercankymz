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

[ExpressType("IfcWindow", 667)]
public class IfcWindow : IfcBuiltElement, IIfcWindow, IIfcBuildingElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcWindow>
{
	private Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? _overallHeight;

	private Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? _overallWidth;

	private IfcWindowTypeEnum? _predefinedType;

	private IfcWindowTypePartitioningEnum? _partitioningType;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _userDefinedPartitioningType;

	[CrossSchemaAttribute(typeof(IIfcWindow), 9)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure? IIfcWindow.OverallHeight
	{
		get
		{
			if (!OverallHeight.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(OverallHeight.Value);
		}
		set
		{
			OverallHeight = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcWindow), 10)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure? IIfcWindow.OverallWidth
	{
		get
		{
			if (!OverallWidth.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(OverallWidth.Value);
		}
		set
		{
			OverallWidth = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcWindow), 11)]
	Xbim.Ifc4.Interfaces.IfcWindowTypeEnum? IIfcWindow.PredefinedType
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
				null => null, 
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
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcWindow), 12)]
	Xbim.Ifc4.Interfaces.IfcWindowTypePartitioningEnum? IIfcWindow.PartitioningType
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
				null => null, 
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
			case null:
				PartitioningType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcWindow), 13)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcWindow.UserDefinedPartitioningType
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

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 35)]
	public Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? OverallHeight
	{
		get
		{
			if (_activated)
			{
				return _overallHeight;
			}
			Activate();
			return _overallHeight;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? v)
			{
				_overallHeight = v;
			}, _overallHeight, value, "OverallHeight", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 36)]
	public Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? OverallWidth
	{
		get
		{
			if (_activated)
			{
				return _overallWidth;
			}
			Activate();
			return _overallWidth;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? v)
			{
				_overallWidth = v;
			}, _overallWidth, value, "OverallWidth", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 37)]
	public IfcWindowTypeEnum? PredefinedType
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
			SetValue(delegate(IfcWindowTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 11);
		}
	}

	[EntityAttribute(12, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 38)]
	public IfcWindowTypePartitioningEnum? PartitioningType
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
			SetValue(delegate(IfcWindowTypePartitioningEnum? v)
			{
				_partitioningType = v;
			}, _partitioningType, value, "PartitioningType", 12);
		}
	}

	[EntityAttribute(13, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 39)]
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

	internal IfcWindow(IModel model, int label, bool activated)
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
			_overallHeight = value.RealVal;
			break;
		case 9:
			_overallWidth = value.RealVal;
			break;
		case 10:
			_predefinedType = (IfcWindowTypeEnum)Enum.Parse(typeof(IfcWindowTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 11:
			_partitioningType = (IfcWindowTypePartitioningEnum)Enum.Parse(typeof(IfcWindowTypePartitioningEnum), value.EnumVal, ignoreCase: true);
			break;
		case 12:
			_userDefinedPartitioningType = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcWindow other)
	{
		return this == other;
	}
}
