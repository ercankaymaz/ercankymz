using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.Kernel;

[ExpressType("IfcProxy", 447)]
public class IfcProxy : IfcProduct, IInstantiableEntity, IPersistEntity, IPersist, IIfcProxy, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcProxy>, IExpressValidatable
{
	public enum IfcProxyClause
	{
		WR1
	}

	private IfcObjectTypeEnum _proxyType;

	private IfcLabel? _tag;

	IfcObjectTypeEnum IIfcProxy.ProxyType
	{
		get
		{
			return ProxyType;
		}
		set
		{
			ProxyType = value;
		}
	}

	IfcLabel? IIfcProxy.Tag
	{
		get
		{
			return Tag;
		}
		set
		{
			Tag = value;
		}
	}

	[EntityAttribute(8, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 20)]
	public IfcObjectTypeEnum ProxyType
	{
		get
		{
			if (_activated)
			{
				return _proxyType;
			}
			Activate();
			return _proxyType;
		}
		set
		{
			SetValue(delegate(IfcObjectTypeEnum v)
			{
				_proxyType = v;
			}, _proxyType, value, "ProxyType", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 21)]
	public IfcLabel? Tag
	{
		get
		{
			if (_activated)
			{
				return _tag;
			}
			Activate();
			return _tag;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_tag = v;
			}, _tag, value, "Tag", 9);
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
			if (base.ObjectPlacement != null)
			{
				yield return base.ObjectPlacement;
			}
			if (base.Representation != null)
			{
				yield return base.Representation;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (base.ObjectPlacement != null)
			{
				yield return base.ObjectPlacement;
			}
			if (base.Representation != null)
			{
				yield return base.Representation;
			}
		}
	}

	internal IfcProxy(IModel model, int label, bool activated)
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
		case 4:
		case 5:
		case 6:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 7:
			_proxyType = (IfcObjectTypeEnum)Enum.Parse(typeof(IfcObjectTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 8:
			_tag = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcProxy other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcProxyClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcProxyClause.WR1)
			{
				result = Functions.EXISTS(base.Name);
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcProxy>()?.LogError($"Exception thrown evaluating where-clause 'IfcProxy.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcProxyClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcProxy.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
