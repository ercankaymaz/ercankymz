using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.Kernel;

[ExpressType("IfcRelAssignsToProcess", 249)]
public class IfcRelAssignsToProcess : IfcRelAssigns, IIfcRelAssignsToProcess, IIfcRelAssigns, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelAssignsToProcess>
{
	private IfcProcessSelect _relatingProcess;

	private IfcMeasureWithUnit _quantityInProcess;

	[CrossSchemaAttribute(typeof(IIfcRelAssignsToProcess), 7)]
	IIfcProcessSelect IIfcRelAssignsToProcess.RelatingProcess
	{
		get
		{
			if (RelatingProcess == null)
			{
				return null;
			}
			IfcProcess ifcProcess = RelatingProcess as IfcProcess;
			if (ifcProcess != null)
			{
				return ifcProcess;
			}
			IfcTypeProcess ifcTypeProcess = RelatingProcess as IfcTypeProcess;
			if (ifcTypeProcess != null)
			{
				return ifcTypeProcess;
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				RelatingProcess = null;
				return;
			}
			IfcProcess ifcProcess = value as IfcProcess;
			if (ifcProcess != null)
			{
				RelatingProcess = ifcProcess;
				return;
			}
			IfcTypeProcess ifcTypeProcess = value as IfcTypeProcess;
			if (ifcTypeProcess != null)
			{
				RelatingProcess = ifcTypeProcess;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcRelAssignsToProcess), 8)]
	IIfcMeasureWithUnit IIfcRelAssignsToProcess.QuantityInProcess
	{
		get
		{
			return QuantityInProcess;
		}
		set
		{
			QuantityInProcess = value as IfcMeasureWithUnit;
		}
	}

	[IndexedProperty]
	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 7)]
	public IfcProcessSelect RelatingProcess
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
			SetValue(delegate(IfcProcessSelect v)
			{
				_relatingProcess = v;
			}, _relatingProcess, value, "RelatingProcess", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 8)]
	public IfcMeasureWithUnit QuantityInProcess
	{
		get
		{
			if (_activated)
			{
				return _quantityInProcess;
			}
			Activate();
			return _quantityInProcess;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcMeasureWithUnit v)
			{
				_quantityInProcess = v;
			}, _quantityInProcess, value, "QuantityInProcess", 8);
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
			foreach (IfcObjectDefinition relatedObject in base.RelatedObjects)
			{
				yield return relatedObject;
			}
			if (RelatingProcess != null)
			{
				yield return RelatingProcess;
			}
			if (QuantityInProcess != null)
			{
				yield return QuantityInProcess;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcObjectDefinition relatedObject in base.RelatedObjects)
			{
				yield return relatedObject;
			}
			if (RelatingProcess != null)
			{
				yield return RelatingProcess;
			}
		}
	}

	internal IfcRelAssignsToProcess(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 6:
			_relatingProcess = (IfcProcessSelect)value.EntityVal;
			break;
		case 7:
			_quantityInProcess = (IfcMeasureWithUnit)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelAssignsToProcess other)
	{
		return this == other;
	}
}
