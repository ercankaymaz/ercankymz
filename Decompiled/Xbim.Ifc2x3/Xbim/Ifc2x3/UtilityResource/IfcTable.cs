using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.ConstraintResource;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.ConstraintResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PropertyResource;

namespace Xbim.Ifc2x3.UtilityResource;

[ExpressType("IfcTable", 377)]
public class IfcTable : PersistEntity, IIfcTable, IPersistEntity, IPersist, Xbim.Ifc4.ConstraintResource.IfcMetricValueSelect, IIfcMetricValueSelect, IExpressSelectType, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IInstantiableEntity, Xbim.Ifc2x3.ConstraintResource.IfcMetricValueSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcTable>, IExpressValidatable
{
	public enum IfcTableClause
	{
		WR1,
		WR2,
		WR3
	}

	private string _name;

	private readonly ItemSet<IfcTableRow> _rows;

	[CrossSchemaAttribute(typeof(IIfcTable), 1)]
	IfcLabel? IIfcTable.Name
	{
		get
		{
			if (string.IsNullOrWhiteSpace(Name))
			{
				return null;
			}
			return new IfcLabel(Name);
		}
		set
		{
			IfcLabel? ifcLabel = value;
			Name = (ifcLabel.HasValue ? ((string)ifcLabel.GetValueOrDefault()) : null);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcTable), 2)]
	IItemSet<IIfcTableRow> IIfcTable.Rows => new ProxyItemSet<IfcTableRow, IIfcTableRow>(Rows);

	[CrossSchemaAttribute(typeof(IIfcTable), 3)]
	IItemSet<IIfcTableColumn> IIfcTable.Columns => null;

	IfcInteger IIfcTable.NumberOfCellsInRow => new IfcInteger(NumberOfCellsInRow);

	IfcInteger IIfcTable.NumberOfHeadings => new IfcInteger(NumberOfHeadings);

	IfcInteger IIfcTable.NumberOfDataRows => new IfcInteger(NumberOfDataRows);

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public string Name
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
			SetValue(delegate(string v)
			{
				_name = v;
			}, _name, value, "Name", 1);
		}
	}

	[IndexedProperty]
	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 2)]
	public IItemSet<IfcTableRow> Rows
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

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public long NumberOfCellsInRow => (Rows != null) ? Rows[0].RowCells.Count : 0;

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public long NumberOfHeadings => Rows.Count((IfcTableRow r) => r.IsHeading);

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public long NumberOfDataRows => Rows.Count((IfcTableRow r) => !r.IsHeading);

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcTableRow row in Rows)
			{
				yield return row;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcTableRow row in Rows)
			{
				yield return row;
			}
		}
	}

	internal IfcTable(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_rows = new ItemSet<IfcTableRow>(this, 0, 2);
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
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcTable other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcTableClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcTableClause.WR1:
				result = Functions.SIZEOF(Enumerable.Where(Rows, (IfcTableRow Temp) => Functions.HIINDEX(Temp.RowCells) != Functions.HIINDEX(Rows.ItemAt(0L).RowCells))) == 0;
				break;
			case IfcTableClause.WR2:
				result = Functions.SIZEOF(Enumerable.Where(Rows, (IfcTableRow Temp) => Functions.HIINDEX(Temp.RowCells) != Functions.HIINDEX(Rows.ItemAt(0L).RowCells))) == 0;
				break;
			case IfcTableClause.WR3:
				result = 0 <= NumberOfHeadings && NumberOfHeadings <= 1;
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcTable>()?.LogError($"Exception thrown evaluating where-clause 'IfcTable.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcTableClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcTable.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcTableClause.WR2))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcTable.WR2",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcTableClause.WR3))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcTable.WR3",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
