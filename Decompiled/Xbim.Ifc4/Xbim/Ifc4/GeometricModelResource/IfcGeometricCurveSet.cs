using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.GeometricModelResource;

[ExpressType("IfcGeometricCurveSet", 237)]
public class IfcGeometricCurveSet : IfcGeometricSet, IInstantiableEntity, IPersistEntity, IPersist, IIfcGeometricCurveSet, IIfcGeometricSet, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcGeometricCurveSet>, IExpressValidatable
{
	public enum IfcGeometricCurveSetClause
	{
		NoSurfaces
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcGeometricSetSelect element in base.Elements)
			{
				yield return element;
			}
		}
	}

	internal IfcGeometricCurveSet(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex == 0)
		{
			base.Parse(propIndex, value, nestedIndex);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcGeometricCurveSet other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcGeometricCurveSetClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcGeometricCurveSetClause.NoSurfaces)
			{
				result = Functions.SIZEOF(Enumerable.Where(base.Elements, (IfcGeometricSetSelect Temp) => Functions.TYPEOF(Temp).Contains("IFC4.IFCSURFACE"))) == 0;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcGeometricCurveSet>()?.LogError($"Exception thrown evaluating where-clause 'IfcGeometricCurveSet.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcGeometricCurveSetClause.NoSurfaces))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcGeometricCurveSet.NoSurfaces",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
