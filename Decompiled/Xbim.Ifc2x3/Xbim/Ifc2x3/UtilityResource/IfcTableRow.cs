using System;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.UtilityResource;

[ExpressType("IfcTableRow", 661)]
public class IfcTableRow : PersistEntity, IIfcTableRow, IPersistEntity, IPersist, IInstantiableEntity, IEquatable<IfcTableRow>
{
	private IItemSet<IIfcValue> _rowCellsIfc4;

	private readonly ItemSet<Xbim.Ifc2x3.MeasureResource.IfcValue> _rowCells;

	private bool _isHeading;

	[CrossSchemaAttribute(typeof(IIfcTableRow), 1)]
	IItemSet<IIfcValue> IIfcTableRow.RowCells => _rowCellsIfc4 ?? (_rowCellsIfc4 = new ExtendedItemSet<Xbim.Ifc2x3.MeasureResource.IfcValue, IIfcValue>(RowCells, new ItemSet<IIfcValue>(this, 0, -1), (Xbim.Ifc2x3.MeasureResource.IfcValue v) => v.ToIfc4(), (IIfcValue v) => v.ToIfc3()));

	[CrossSchemaAttribute(typeof(IIfcTableRow), 2)]
	Xbim.Ifc4.MeasureResource.IfcBoolean? IIfcTableRow.IsHeading
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcBoolean(IsHeading);
		}
		set
		{
			if (!value.HasValue)
			{
				IsHeading = false;
			}
			else
			{
				IsHeading = value.Value;
			}
		}
	}

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 1)]
	public IItemSet<Xbim.Ifc2x3.MeasureResource.IfcValue> RowCells
	{
		get
		{
			if (_activated)
			{
				return _rowCells;
			}
			Activate();
			return _rowCells;
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public bool IsHeading
	{
		get
		{
			if (_activated)
			{
				return _isHeading;
			}
			Activate();
			return _isHeading;
		}
		set
		{
			SetValue(delegate(bool v)
			{
				_isHeading = v;
			}, _isHeading, value, "IsHeading", 2);
		}
	}

	[InverseProperty("Rows")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, null, null, 3)]
	public IfcTable OfTable => base.Model.Instances.FirstOrDefault((IfcTable e) => e.Rows != null && e.Rows.Contains(this), "Rows", this);

	internal IfcTableRow(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_rowCells = new ItemSet<Xbim.Ifc2x3.MeasureResource.IfcValue>(this, 0, 1);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_rowCells.InternalAdd((Xbim.Ifc2x3.MeasureResource.IfcValue)value.EntityVal);
			break;
		case 1:
			_isHeading = value.BooleanVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcTableRow other)
	{
		return this == other;
	}
}
