using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4x3.GeometricConstraintResource;

namespace Xbim.Ifc4x3.ProductExtension;

[ExpressType("IfcGrid", 564)]
public class IfcGrid : IfcPositioningElement, IIfcGrid, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcGrid>
{
	private readonly ItemSet<IfcGridAxis> _uAxes;

	private readonly ItemSet<IfcGridAxis> _vAxes;

	private readonly OptionalItemSet<IfcGridAxis> _wAxes;

	private IfcGridTypeEnum? _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcGrid), 8)]
	IItemSet<IIfcGridAxis> IIfcGrid.UAxes => new ProxyItemSet<IfcGridAxis, IIfcGridAxis>(UAxes);

	[CrossSchemaAttribute(typeof(IIfcGrid), 9)]
	IItemSet<IIfcGridAxis> IIfcGrid.VAxes => new ProxyItemSet<IfcGridAxis, IIfcGridAxis>(VAxes);

	[CrossSchemaAttribute(typeof(IIfcGrid), 10)]
	IItemSet<IIfcGridAxis> IIfcGrid.WAxes => new ProxyItemSet<IfcGridAxis, IIfcGridAxis>(WAxes);

	[CrossSchemaAttribute(typeof(IIfcGrid), 11)]
	Xbim.Ifc4.Interfaces.IfcGridTypeEnum? IIfcGrid.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcGridTypeEnum.IRREGULAR => Xbim.Ifc4.Interfaces.IfcGridTypeEnum.IRREGULAR, 
				IfcGridTypeEnum.RADIAL => Xbim.Ifc4.Interfaces.IfcGridTypeEnum.RADIAL, 
				IfcGridTypeEnum.RECTANGULAR => Xbim.Ifc4.Interfaces.IfcGridTypeEnum.RECTANGULAR, 
				IfcGridTypeEnum.TRIANGULAR => Xbim.Ifc4.Interfaces.IfcGridTypeEnum.TRIANGULAR, 
				IfcGridTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcGridTypeEnum.USERDEFINED, 
				IfcGridTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcGridTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcGridTypeEnum.RECTANGULAR:
				PredefinedType = IfcGridTypeEnum.RECTANGULAR;
				break;
			case Xbim.Ifc4.Interfaces.IfcGridTypeEnum.RADIAL:
				PredefinedType = IfcGridTypeEnum.RADIAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcGridTypeEnum.TRIANGULAR:
				PredefinedType = IfcGridTypeEnum.TRIANGULAR;
				break;
			case Xbim.Ifc4.Interfaces.IfcGridTypeEnum.IRREGULAR:
				PredefinedType = IfcGridTypeEnum.IRREGULAR;
				break;
			case Xbim.Ifc4.Interfaces.IfcGridTypeEnum.USERDEFINED:
				PredefinedType = IfcGridTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcGridTypeEnum.NOTDEFINED:
				PredefinedType = IfcGridTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	IEnumerable<IIfcRelContainedInSpatialStructure> IIfcGrid.ContainedInStructure => base.Model.Instances.Where((IIfcRelContainedInSpatialStructure e) => e.RelatedElements != null && e.RelatedElements.Contains(this), "RelatedElements", this);

	[IndexedProperty]
	[EntityAttribute(8, EntityAttributeState.Mandatory, EntityAttributeType.ListUnique, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 24)]
	public IItemSet<IfcGridAxis> UAxes
	{
		get
		{
			if (_activated)
			{
				return _uAxes;
			}
			Activate();
			return _uAxes;
		}
	}

	[IndexedProperty]
	[EntityAttribute(9, EntityAttributeState.Mandatory, EntityAttributeType.ListUnique, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 25)]
	public IItemSet<IfcGridAxis> VAxes
	{
		get
		{
			if (_activated)
			{
				return _vAxes;
			}
			Activate();
			return _vAxes;
		}
	}

	[IndexedProperty]
	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.ListUnique, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 26)]
	public IOptionalItemSet<IfcGridAxis> WAxes
	{
		get
		{
			if (_activated)
			{
				return _wAxes;
			}
			Activate();
			return _wAxes;
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 27)]
	public IfcGridTypeEnum? PredefinedType
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
			SetValue(delegate(IfcGridTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 11);
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
			foreach (IfcGridAxis uAxis in UAxes)
			{
				yield return uAxis;
			}
			foreach (IfcGridAxis vAxis in VAxes)
			{
				yield return vAxis;
			}
			foreach (IfcGridAxis wAxis in WAxes)
			{
				yield return wAxis;
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
			foreach (IfcGridAxis uAxis in UAxes)
			{
				yield return uAxis;
			}
			foreach (IfcGridAxis vAxis in VAxes)
			{
				yield return vAxis;
			}
			foreach (IfcGridAxis wAxis in WAxes)
			{
				yield return wAxis;
			}
		}
	}

	internal IfcGrid(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_uAxes = new ItemSet<IfcGridAxis>(this, 0, 8);
		_vAxes = new ItemSet<IfcGridAxis>(this, 0, 9);
		_wAxes = new OptionalItemSet<IfcGridAxis>(this, 0, 10);
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 7:
			_uAxes.InternalAdd((IfcGridAxis)value.EntityVal);
			break;
		case 8:
			_vAxes.InternalAdd((IfcGridAxis)value.EntityVal);
			break;
		case 9:
			_wAxes.InternalAdd((IfcGridAxis)value.EntityVal);
			break;
		case 10:
			_predefinedType = (IfcGridTypeEnum)Enum.Parse(typeof(IfcGridTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcGrid other)
	{
		return this == other;
	}
}
