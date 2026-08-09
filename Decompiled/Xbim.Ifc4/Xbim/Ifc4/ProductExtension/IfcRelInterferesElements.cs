using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.ProductExtension;

[ExpressType("IfcRelInterferesElements", 1252)]
public class IfcRelInterferesElements : IfcRelConnects, IInstantiableEntity, IPersistEntity, IPersist, IIfcRelInterferesElements, IIfcRelConnects, IIfcRelationship, IIfcRoot, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelInterferesElements>, IExpressValidatable
{
	public enum IfcRelInterferesElementsClause
	{
		NotSelfReference
	}

	private IfcElement _relatingElement;

	private IfcElement _relatedElement;

	private IfcConnectionGeometry _interferenceGeometry;

	private IfcIdentifier? _interferenceType;

	private bool? _impliedOrder;

	IIfcElement IIfcRelInterferesElements.RelatingElement
	{
		get
		{
			return RelatingElement;
		}
		set
		{
			RelatingElement = value as IfcElement;
		}
	}

	IIfcElement IIfcRelInterferesElements.RelatedElement
	{
		get
		{
			return RelatedElement;
		}
		set
		{
			RelatedElement = value as IfcElement;
		}
	}

	IIfcConnectionGeometry IIfcRelInterferesElements.InterferenceGeometry
	{
		get
		{
			return InterferenceGeometry;
		}
		set
		{
			InterferenceGeometry = value as IfcConnectionGeometry;
		}
	}

	IfcIdentifier? IIfcRelInterferesElements.InterferenceType
	{
		get
		{
			return InterferenceType;
		}
		set
		{
			InterferenceType = value;
		}
	}

	bool? IIfcRelInterferesElements.ImpliedOrder
	{
		get
		{
			return ImpliedOrder;
		}
		set
		{
			ImpliedOrder = value;
		}
	}

	[IndexedProperty]
	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcElement RelatingElement
	{
		get
		{
			if (_activated)
			{
				return _relatingElement;
			}
			Activate();
			return _relatingElement;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcElement v)
			{
				_relatingElement = v;
			}, _relatingElement, value, "RelatingElement", 5);
		}
	}

	[IndexedProperty]
	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
	public IfcElement RelatedElement
	{
		get
		{
			if (_activated)
			{
				return _relatedElement;
			}
			Activate();
			return _relatedElement;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcElement v)
			{
				_relatedElement = v;
			}, _relatedElement, value, "RelatedElement", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 7)]
	public IfcConnectionGeometry InterferenceGeometry
	{
		get
		{
			if (_activated)
			{
				return _interferenceGeometry;
			}
			Activate();
			return _interferenceGeometry;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcConnectionGeometry v)
			{
				_interferenceGeometry = v;
			}, _interferenceGeometry, value, "InterferenceGeometry", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public IfcIdentifier? InterferenceType
	{
		get
		{
			if (_activated)
			{
				return _interferenceType;
			}
			Activate();
			return _interferenceType;
		}
		set
		{
			SetValue(delegate(IfcIdentifier? v)
			{
				_interferenceType = v;
			}, _interferenceType, value, "InterferenceType", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 9)]
	public bool? ImpliedOrder
	{
		get
		{
			if (_activated)
			{
				return _impliedOrder;
			}
			Activate();
			return _impliedOrder;
		}
		set
		{
			SetValue(delegate(bool? v)
			{
				_impliedOrder = v;
			}, _impliedOrder, value, "ImpliedOrder", 9);
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
			if (RelatingElement != null)
			{
				yield return RelatingElement;
			}
			if (RelatedElement != null)
			{
				yield return RelatedElement;
			}
			if (InterferenceGeometry != null)
			{
				yield return InterferenceGeometry;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (RelatingElement != null)
			{
				yield return RelatingElement;
			}
			if (RelatedElement != null)
			{
				yield return RelatedElement;
			}
		}
	}

	internal IfcRelInterferesElements(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 4:
			_relatingElement = (IfcElement)value.EntityVal;
			break;
		case 5:
			_relatedElement = (IfcElement)value.EntityVal;
			break;
		case 6:
			_interferenceGeometry = (IfcConnectionGeometry)value.EntityVal;
			break;
		case 7:
			_interferenceType = value.StringVal;
			break;
		case 8:
			_impliedOrder = value.BooleanVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelInterferesElements other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcRelInterferesElementsClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcRelInterferesElementsClause.NotSelfReference)
			{
				result = (object)RelatingElement != RelatedElement;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcRelInterferesElements>()?.LogError($"Exception thrown evaluating where-clause 'IfcRelInterferesElements.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcRelInterferesElementsClause.NotSelfReference))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRelInterferesElements.NotSelfReference",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
