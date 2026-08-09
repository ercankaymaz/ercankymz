using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ConstraintResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PropertyResource;
using Xbim.Ifc4x3.ConstraintResource;
using Xbim.Ifc4x3.MeasureResource;
using Xbim.Ifc4x3.PropertyResource;

namespace Xbim.Ifc4x3.UtilityResource;

[ExpressType("IfcTable", 377)]
public class IfcTable : PersistEntity, IIfcTable, IPersistEntity, IPersist, Xbim.Ifc4.ConstraintResource.IfcMetricValueSelect, IIfcMetricValueSelect, IExpressSelectType, Xbim.Ifc4.PropertyResource.IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IInstantiableEntity, Xbim.Ifc4x3.ConstraintResource.IfcMetricValueSelect, Xbim.Ifc4x3.PropertyResource.IfcObjectReferenceSelect, IContainsEntityReferences, IEquatable<IfcTable>
{
	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _name;

	private readonly OptionalItemSet<IfcTableRow> _rows;

	private readonly OptionalItemSet<IfcTableColumn> _columns;

	[CrossSchemaAttribute(typeof(IIfcTable), 1)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcTable.Name
	{
		get
		{
			if (!Name.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Name.Value);
		}
		set
		{
			Name = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcTable), 2)]
	IItemSet<IIfcTableRow> IIfcTable.Rows => new ProxyItemSet<IfcTableRow, IIfcTableRow>(Rows);

	[CrossSchemaAttribute(typeof(IIfcTable), 3)]
	IItemSet<IIfcTableColumn> IIfcTable.Columns => new ProxyItemSet<IfcTableColumn, IIfcTableColumn>(Columns);

	Xbim.Ifc4.MeasureResource.IfcInteger IIfcTable.NumberOfCellsInRow => new Xbim.Ifc4.MeasureResource.IfcInteger(NumberOfCellsInRow);

	Xbim.Ifc4.MeasureResource.IfcInteger IIfcTable.NumberOfHeadings => new Xbim.Ifc4.MeasureResource.IfcInteger(NumberOfHeadings);

	Xbim.Ifc4.MeasureResource.IfcInteger IIfcTable.NumberOfDataRows => new Xbim.Ifc4.MeasureResource.IfcInteger(NumberOfDataRows);

	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? Name
	{
		get
		{
			if (_activated)
			{
				return _name;
			}
			Activate();
			return _name;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
			{
				_name = v;
			}, _name, value, "Name", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 2)]
	public IOptionalItemSet<IfcTableRow> Rows
	{
		get
		{
			if (_activated)
			{
				return _rows;
			}
			Activate();
			return _rows;
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 3)]
	public IOptionalItemSet<IfcTableColumn> Columns
	{
		get
		{
			if (_activated)
			{
				return _columns;
			}
			Activate();
			return _columns;
		}
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public Xbim.Ifc4x3.MeasureResource.IfcInteger NumberOfCellsInRow => Rows.FirstOrDefault()?.RowCells.Count ?? 0;

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public Xbim.Ifc4x3.MeasureResource.IfcInteger NumberOfHeadings => Rows.Count((IfcTableRow r) => r.IsHeading ?? ((Xbim.Ifc4x3.MeasureResource.IfcBoolean)false));

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public Xbim.Ifc4x3.MeasureResource.IfcInteger NumberOfDataRows => Rows.Count((IfcTableRow r) => !(r.IsHeading ?? ((Xbim.Ifc4x3.MeasureResource.IfcBoolean)false)));

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcTableRow row in Rows)
			{
				yield return row;
			}
			foreach (IfcTableColumn column in Columns)
			{
				yield return column;
			}
		}
	}

	internal IfcTable(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_rows = new OptionalItemSet<IfcTableRow>(this, 0, 2);
		_columns = new OptionalItemSet<IfcTableColumn>(this, 0, 3);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_name = value.StringVal;
			break;
		case 1:
			_rows.InternalAdd((IfcTableRow)value.EntityVal);
			break;
		case 2:
			_columns.InternalAdd((IfcTableColumn)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcTable other)
	{
		return this == other;
	}
}
