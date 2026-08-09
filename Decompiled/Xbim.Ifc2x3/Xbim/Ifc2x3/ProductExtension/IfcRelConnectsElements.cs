using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.GeometricConstraintResource;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc2x3.ProductExtension;

[ExpressType("IfcRelConnectsElements", 312)]
public class IfcRelConnectsElements : IfcRelConnects, IIfcRelConnectsElements, IIfcRelConnects, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelConnectsElements>, IExpressValidatable
{
	public enum IfcRelConnectsElementsClause
	{
		WR31
	}

	private IfcConnectionGeometry _connectionGeometry;

	private IfcElement _relatingElement;

	private IfcElement _relatedElement;

	[CrossSchemaAttribute(typeof(IIfcRelConnectsElements), 5)]
	IIfcConnectionGeometry IIfcRelConnectsElements.ConnectionGeometry
	{
		get
		{
			return ConnectionGeometry;
		}
		set
		{
			ConnectionGeometry = value as IfcConnectionGeometry;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcRelConnectsElements), 6)]
	IIfcElement IIfcRelConnectsElements.RelatingElement
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

	[CrossSchemaAttribute(typeof(IIfcRelConnectsElements), 7)]
	IIfcElement IIfcRelConnectsElements.RelatedElement
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

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcConnectionGeometry ConnectionGeometry
	{
		get
		{
			if (_activated)
			{
				return _connectionGeometry;
			}
			Activate();
			return _connectionGeometry;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcConnectionGeometry v)
			{
				_connectionGeometry = v;
			}, _connectionGeometry, value, "ConnectionGeometry", 5);
		}
	}

	[IndexedProperty]
	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
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
			}, _relatingElement, value, "RelatingElement", 6);
		}
	}

	[IndexedProperty]
	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 7)]
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
			}, _relatedElement, value, "RelatedElement", 7);
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
			if (ConnectionGeometry != null)
			{
				yield return ConnectionGeometry;
			}
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

	internal IfcRelConnectsElements(IModel model, int label, bool activated)
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
			_connectionGeometry = (IfcConnectionGeometry)value.EntityVal;
			break;
		case 5:
			_relatingElement = (IfcElement)value.EntityVal;
			break;
		case 6:
			_relatedElement = (IfcElement)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelConnectsElements other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcRelConnectsElementsClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcRelConnectsElementsClause.WR31)
			{
				result = (object)RelatingElement != RelatedElement;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcRelConnectsElements>()?.LogError($"Exception thrown evaluating where-clause 'IfcRelConnectsElements.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcRelConnectsElementsClause.WR31))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRelConnectsElements.WR31",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
