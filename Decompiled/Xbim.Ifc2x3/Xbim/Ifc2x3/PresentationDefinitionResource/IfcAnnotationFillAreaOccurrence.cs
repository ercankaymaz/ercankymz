using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc2x3.PresentationAppearanceResource;
using Xbim.Ifc2x3.RepresentationResource;
using Xbim.Ifc2x3.Validation;

namespace Xbim.Ifc2x3.PresentationDefinitionResource;

[ExpressType("IfcAnnotationFillAreaOccurrence", 544)]
public class IfcAnnotationFillAreaOccurrence : IfcAnnotationOccurrence, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcAnnotationFillAreaOccurrence>, IExpressValidatable
{
	public enum IfcAnnotationFillAreaOccurrenceClause
	{
		WR31
	}

	private IfcPoint _fillStyleTarget;

	private IfcGlobalOrLocalEnum? _globalOrLocal;

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
	public IfcPoint FillStyleTarget
	{
		get
		{
			if (_activated)
			{
				return _fillStyleTarget;
			}
			Activate();
			return _fillStyleTarget;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcPoint v)
			{
				_fillStyleTarget = v;
			}, _fillStyleTarget, value, "FillStyleTarget", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 7)]
	public IfcGlobalOrLocalEnum? GlobalOrLocal
	{
		get
		{
			if (_activated)
			{
				return _globalOrLocal;
			}
			Activate();
			return _globalOrLocal;
		}
		set
		{
			SetValue(delegate(IfcGlobalOrLocalEnum? v)
			{
				_globalOrLocal = v;
			}, _globalOrLocal, value, "GlobalOrLocal", 5);
		}
	}

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
			if (FillStyleTarget != null)
			{
				yield return FillStyleTarget;
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

	internal IfcAnnotationFillAreaOccurrence(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 3:
			_fillStyleTarget = (IfcPoint)value.EntityVal;
			break;
		case 4:
			_globalOrLocal = (IfcGlobalOrLocalEnum)Enum.Parse(typeof(IfcGlobalOrLocalEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcAnnotationFillAreaOccurrence other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcAnnotationFillAreaOccurrenceClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcAnnotationFillAreaOccurrenceClause.WR31)
			{
				result = !Functions.EXISTS(base.Item) || Functions.TYPEOF(base.Item).Contains("IFC2X3.IFCANNOTATIONFILLAREA");
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcAnnotationFillAreaOccurrence>()?.LogError($"Exception thrown evaluating where-clause 'IfcAnnotationFillAreaOccurrence.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcAnnotationFillAreaOccurrenceClause.WR31))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcAnnotationFillAreaOccurrence.WR31",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
