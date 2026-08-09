using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.ProductExtension;

[ExpressType("IfcZone", 669)]
public class IfcZone : Xbim.Ifc2x3.Kernel.IfcGroup, IIfcZone, IIfcSystem, IIfcGroup, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcZone>, IExpressValidatable
{
	public enum IfcZoneClause
	{
		WR1
	}

	private IfcLabel? _longName;

	[CrossSchemaAttribute(typeof(IIfcZone), 6)]
	IfcLabel? IIfcZone.LongName
	{
		get
		{
			return _longName;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_longName = v;
			}, _longName, value, "LongName", -6);
		}
	}

	IEnumerable<IIfcRelServicesBuildings> IIfcSystem.ServicesBuildings => base.Model.Instances.Where((IIfcRelServicesBuildings e) => e.RelatingSystem as IfcZone == this, "RelatingSystem", this);

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

	internal IfcZone(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if ((uint)propIndex <= 4u)
		{
			base.Parse(propIndex, value, nestedIndex);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcZone other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcZoneClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcZoneClause.WR1)
			{
				result = Functions.SIZEOF(Enumerable.Where(base.IsGroupedBy.RelatedObjects, (Xbim.Ifc2x3.Kernel.IfcObjectDefinition temp) => !Functions.TYPEOF(temp).Contains("IFC2X3.IFCZONE") && !Functions.TYPEOF(temp).Contains("IFC2X3.IFCSPACE"))) == 0;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcZone>()?.LogError($"Exception thrown evaluating where-clause 'IfcZone.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcZoneClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcZone.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
