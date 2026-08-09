using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc2x3.ProfileResource;

[ExpressType("IfcArbitraryProfileDefWithVoids", 116)]
public class IfcArbitraryProfileDefWithVoids : IfcArbitraryClosedProfileDef, IIfcArbitraryProfileDefWithVoids, IIfcArbitraryClosedProfileDef, IIfcProfileDef, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcArbitraryProfileDefWithVoids>, IExpressValidatable
{
	public enum IfcArbitraryProfileDefWithVoidsClause
	{
		WR1,
		WR2,
		WR3
	}

	private readonly ItemSet<IfcCurve> _innerCurves;

	[CrossSchemaAttribute(typeof(IIfcArbitraryProfileDefWithVoids), 4)]
	IItemSet<IIfcCurve> IIfcArbitraryProfileDefWithVoids.InnerCurves => new ProxyItemSet<IfcCurve, IIfcCurve>(InnerCurves);

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 4)]
	public IItemSet<IfcCurve> InnerCurves
	{
		get
		{
			if (_activated)
			{
				return _innerCurves;
			}
			Activate();
			return _innerCurves;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.OuterCurve != null)
			{
				yield return base.OuterCurve;
			}
			foreach (IfcCurve innerCurf in InnerCurves)
			{
				yield return innerCurf;
			}
		}
	}

	internal IfcArbitraryProfileDefWithVoids(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_innerCurves = new ItemSet<IfcCurve>(this, 0, 4);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
		case 2:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 3:
			_innerCurves.InternalAdd((IfcCurve)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcArbitraryProfileDefWithVoids other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcArbitraryProfileDefWithVoidsClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcArbitraryProfileDefWithVoidsClause.WR1:
				result = base.ProfileType == IfcProfileTypeEnum.AREA;
				break;
			case IfcArbitraryProfileDefWithVoidsClause.WR2:
				result = Functions.SIZEOF(Enumerable.Where(InnerCurves, (IfcCurve temp) => temp.Dim != 2L)) == 0;
				break;
			case IfcArbitraryProfileDefWithVoidsClause.WR3:
				result = Functions.SIZEOF(Enumerable.Where(InnerCurves, (IfcCurve temp) => Functions.TYPEOF(temp).Contains("IFC2X3.IFCLINE"))) == 0;
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcArbitraryProfileDefWithVoids>()?.LogError($"Exception thrown evaluating where-clause 'IfcArbitraryProfileDefWithVoids.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcArbitraryProfileDefWithVoidsClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcArbitraryProfileDefWithVoids.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcArbitraryProfileDefWithVoidsClause.WR2))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcArbitraryProfileDefWithVoids.WR2",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcArbitraryProfileDefWithVoidsClause.WR3))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcArbitraryProfileDefWithVoids.WR3",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
