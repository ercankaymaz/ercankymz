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

[ExpressType("IfcWindow", 667)]
public class IfcWindow : IfcBuildingElement, IIfcWindow, IIfcBuildingElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcWindow>
{
	private IfcWindowTypeEnum? _predefinedType;

	private IfcWindowTypePartitioningEnum? _partitioningType;

	private Xbim.Ifc4.MeasureResource.IfcLabel? _userDefinedPartitioningType;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? _overallHeight;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? _overallWidth;

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
			OverallHeight = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure?)null));
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
			OverallWidth = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcWindow), 11)]
	IfcWindowTypeEnum? IIfcWindow.PredefinedType
	{
		get
		{
			return _predefinedType;
		}
		set
		{
			SetValue(delegate(IfcWindowTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", -11);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcWindow), 12)]
	IfcWindowTypePartitioningEnum? IIfcWindow.PartitioningType
	{
		get
		{
			return _partitioningType;
		}
		set
		{
			SetValue(delegate(IfcWindowTypePartitioningEnum? v)
			{
				_partitioningType = v;
			}, _partitioningType, value, "PartitioningType", -12);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcWindow), 13)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcWindow.UserDefinedPartitioningType
	{
		get
		{
			return _userDefinedPartitioningType;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4.MeasureResource.IfcLabel? v)
			{
				_userDefinedPartitioningType = v;
			}, _userDefinedPartitioningType, value, "UserDefinedPartitioningType", -13);
		}
	}

	public Xbim.Ifc4.MeasureResource.IfcBoolean? IsExternal
	{
		get
		{
			Xbim.Ifc2x3.MeasureResource.IfcValue propertySingleNominalValue = GetPropertySingleNominalValue("Pset_WindowCommon", "IsExternal");
			if (propertySingleNominalValue is Xbim.Ifc2x3.MeasureResource.IfcBoolean)
			{
				return new Xbim.Ifc4.MeasureResource.IfcBoolean((Xbim.Ifc2x3.MeasureResource.IfcBoolean)(object)propertySingleNominalValue);
			}
			return new Xbim.Ifc4.MeasureResource.IfcBoolean(val: false);
		}
	}

	public Xbim.Ifc4.MeasureResource.IfcIdentifier? Reference
	{
		get
		{
			Xbim.Ifc2x3.MeasureResource.IfcValue propertySingleNominalValue = GetPropertySingleNominalValue("Pset_WindowCommon", "Reference ");
			if (propertySingleNominalValue is Xbim.Ifc2x3.MeasureResource.IfcIdentifier)
			{
				return new Xbim.Ifc4.MeasureResource.IfcIdentifier((Xbim.Ifc2x3.MeasureResource.IfcIdentifier)(object)propertySingleNominalValue);
			}
			return null;
		}
	}

	public Xbim.Ifc4.MeasureResource.IfcLabel? FireRating
	{
		get
		{
			Xbim.Ifc2x3.MeasureResource.IfcValue propertySingleNominalValue = GetPropertySingleNominalValue("Pset_WindowCommon", "FireRating ");
			if (propertySingleNominalValue is Xbim.Ifc2x3.MeasureResource.IfcLabel)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLabel((Xbim.Ifc2x3.MeasureResource.IfcLabel)(object)propertySingleNominalValue);
			}
			return null;
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 27)]
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? OverallHeight
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? v)
			{
				_overallHeight = v;
			}, _overallHeight, value, "OverallHeight", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 28)]
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? OverallWidth
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? v)
			{
				_overallWidth = v;
			}, _overallWidth, value, "OverallWidth", 10);
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
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcWindow other)
	{
		return this == other;
	}
}
