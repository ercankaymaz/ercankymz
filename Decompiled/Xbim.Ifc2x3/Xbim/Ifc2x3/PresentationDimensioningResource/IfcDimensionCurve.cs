using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.PresentationAppearanceResource;
using Xbim.Ifc2x3.PresentationDefinitionResource;
using Xbim.Ifc2x3.Validation;

namespace Xbim.Ifc2x3.PresentationDimensioningResource;

[ExpressType("IfcDimensionCurve", 742)]
public class IfcDimensionCurve : IfcAnnotationCurveOccurrence, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcDimensionCurve>, IExpressValidatable
{
	public enum IfcDimensionCurveClause
	{
		WR51,
		WR52,
		WR53
	}

	[InverseProperty("AnnotatedCurve")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 2 }, 6)]
	public IEnumerable<IfcTerminatorSymbol> AnnotatedBySymbols => base.Model.Instances.Where((IfcTerminatorSymbol e) => Equals(e.AnnotatedCurve), "AnnotatedCurve", this);

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.Item != null)
			{
				yield return base.Item;
			}
			foreach (IfcPresentationStyleAssignment style in base.Styles)
			{
				yield return style;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (base.Item != null)
			{
				yield return base.Item;
			}
		}
	}

	internal IfcDimensionCurve(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if ((uint)propIndex <= 2u)
		{
			base.Parse(propIndex, value, nestedIndex);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcDimensionCurve other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcDimensionCurveClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcDimensionCurveClause.WR51:
				result = Functions.SIZEOF(Functions.USEDIN(this, "IFC2X3.IFCDRAUGHTINGCALLOUT.CONTENTS")) >= 1;
				break;
			case IfcDimensionCurveClause.WR52:
				result = Functions.SIZEOF(from Dct1 in Functions.USEDIN(this, "IFC2X3.IFCTERMINATORSYMBOL.ANNOTATEDCURVE")
					where Dct1.AsIfcDimensionCurveTerminator().Role == IfcDimensionExtentUsage.ORIGIN
					select Dct1) <= 1 && Functions.SIZEOF(from Dct2 in Functions.USEDIN(this, "IFC2X3.IFCTERMINATORSYMBOL.ANNOTATEDCURVE")
					where Dct2.AsIfcDimensionCurveTerminator().Role == IfcDimensionExtentUsage.TARGET
					select Dct2) <= 1;
				break;
			case IfcDimensionCurveClause.WR53:
				result = Functions.SIZEOF(AnnotatedBySymbols.Where((IfcTerminatorSymbol Dct) => !Functions.TYPEOF(Dct).Contains("IFC2X3.IFCDIMENSIONCURVETERMINATOR"))) == 0;
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcDimensionCurve>()?.LogError($"Exception thrown evaluating where-clause 'IfcDimensionCurve.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcDimensionCurveClause.WR51))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcDimensionCurve.WR51",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcDimensionCurveClause.WR52))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcDimensionCurve.WR52",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcDimensionCurveClause.WR53))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcDimensionCurve.WR53",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
