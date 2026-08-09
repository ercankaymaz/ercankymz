using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.ProductExtension;

[ExpressType("IfcRelConnectsPorts", 215)]
public class IfcRelConnectsPorts : IfcRelConnects, IInstantiableEntity, IPersistEntity, IPersist, IIfcRelConnectsPorts, IIfcRelConnects, IIfcRelationship, IIfcRoot, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelConnectsPorts>, IExpressValidatable
{
	public enum IfcRelConnectsPortsClause
	{
		NoSelfReference
	}

	private IfcPort _relatingPort;

	private IfcPort _relatedPort;

	private IfcElement _realizingElement;

	IIfcPort IIfcRelConnectsPorts.RelatingPort
	{
		get
		{
			return RelatingPort;
		}
		set
		{
			RelatingPort = value as IfcPort;
		}
	}

	IIfcPort IIfcRelConnectsPorts.RelatedPort
	{
		get
		{
			return RelatedPort;
		}
		set
		{
			RelatedPort = value as IfcPort;
		}
	}

	IIfcElement IIfcRelConnectsPorts.RealizingElement
	{
		get
		{
			return RealizingElement;
		}
		set
		{
			RealizingElement = value as IfcElement;
		}
	}

	[IndexedProperty]
	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcPort RelatingPort
	{
		get
		{
			if (_activated)
			{
				return _relatingPort;
			}
			Activate();
			return _relatingPort;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcPort v)
			{
				_relatingPort = v;
			}, _relatingPort, value, "RelatingPort", 5);
		}
	}

	[IndexedProperty]
	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
	public IfcPort RelatedPort
	{
		get
		{
			if (_activated)
			{
				return _relatedPort;
			}
			Activate();
			return _relatedPort;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcPort v)
			{
				_relatedPort = v;
			}, _relatedPort, value, "RelatedPort", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 7)]
	public IfcElement RealizingElement
	{
		get
		{
			if (_activated)
			{
				return _realizingElement;
			}
			Activate();
			return _realizingElement;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcElement v)
			{
				_realizingElement = v;
			}, _realizingElement, value, "RealizingElement", 7);
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
			if (RelatingPort != null)
			{
				yield return RelatingPort;
			}
			if (RelatedPort != null)
			{
				yield return RelatedPort;
			}
			if (RealizingElement != null)
			{
				yield return RealizingElement;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (RelatingPort != null)
			{
				yield return RelatingPort;
			}
			if (RelatedPort != null)
			{
				yield return RelatedPort;
			}
		}
	}

	internal IfcRelConnectsPorts(IModel model, int label, bool activated)
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
			_relatingPort = (IfcPort)value.EntityVal;
			break;
		case 5:
			_relatedPort = (IfcPort)value.EntityVal;
			break;
		case 6:
			_realizingElement = (IfcElement)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelConnectsPorts other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcRelConnectsPortsClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcRelConnectsPortsClause.NoSelfReference)
			{
				result = (object)RelatingPort != RelatedPort;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcRelConnectsPorts>()?.LogError($"Exception thrown evaluating where-clause 'IfcRelConnectsPorts.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcRelConnectsPortsClause.NoSelfReference))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRelConnectsPorts.NoSelfReference",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
