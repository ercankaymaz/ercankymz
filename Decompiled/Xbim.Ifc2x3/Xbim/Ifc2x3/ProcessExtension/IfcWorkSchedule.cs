using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.ActorResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc2x3.ProcessExtension;

[ExpressType("IfcWorkSchedule", 186)]
public class IfcWorkSchedule : IfcWorkControl, IIfcWorkSchedule, IIfcWorkControl, IIfcControl, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcWorkSchedule>
{
	private IfcWorkScheduleTypeEnum? _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcWorkSchedule), 14)]
	IfcWorkScheduleTypeEnum? IIfcWorkSchedule.PredefinedType
	{
		get
		{
			return _predefinedType;
		}
		set
		{
			SetValue(delegate(IfcWorkScheduleTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", -14);
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
			if (base.CreationDate != null)
			{
				yield return base.CreationDate;
			}
			foreach (IfcPerson creator in base.Creators)
			{
				yield return creator;
			}
			if (base.StartTime != null)
			{
				yield return base.StartTime;
			}
			if (base.FinishTime != null)
			{
				yield return base.FinishTime;
			}
		}
	}

	internal IfcWorkSchedule(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if ((uint)propIndex <= 14u)
		{
			base.Parse(propIndex, value, nestedIndex);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcWorkSchedule other)
	{
		return this == other;
	}
}
