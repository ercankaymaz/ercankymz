using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.PresentationAppearanceResource;
using Xbim.Ifc2x3.PresentationDefinitionResource;

namespace Xbim.Ifc2x3.PresentationDimensioningResource;

[ExpressType("IfcTerminatorSymbol", 743)]
public class IfcTerminatorSymbol : IfcAnnotationSymbolOccurrence, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcTerminatorSymbol>
{
	private IfcAnnotationCurveOccurrence _annotatedCurve;

	[IndexedProperty]
	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
	public IfcAnnotationCurveOccurrence AnnotatedCurve
	{
		get
		{
			if (_activated)
			{
				return _annotatedCurve;
			}
			Activate();
			return _annotatedCurve;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcAnnotationCurveOccurrence v)
			{
				_annotatedCurve = v;
			}, _annotatedCurve, value, "AnnotatedCurve", 4);
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
			if (AnnotatedCurve != null)
			{
				yield return AnnotatedCurve;
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
			if (AnnotatedCurve != null)
			{
				yield return AnnotatedCurve;
			}
		}
	}

	internal IfcTerminatorSymbol(IModel model, int label, bool activated)
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
			_annotatedCurve = (IfcAnnotationCurveOccurrence)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcTerminatorSymbol other)
	{
		return this == other;
	}
}
