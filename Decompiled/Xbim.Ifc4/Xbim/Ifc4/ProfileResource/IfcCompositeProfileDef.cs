using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.ProfileResource;

[ExpressType("IfcCompositeProfileDef", 172)]
public class IfcCompositeProfileDef : IfcProfileDef, IInstantiableEntity, IPersistEntity, IPersist, IIfcCompositeProfileDef, IIfcProfileDef, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcCompositeProfileDef>, IExpressValidatable
{
	public enum IfcCompositeProfileDefClause
	{
		InvariantProfileType,
		NoRecursion
	}

	private readonly ItemSet<IfcProfileDef> _profiles;

	private IfcLabel? _label;

	IItemSet<IIfcProfileDef> IIfcCompositeProfileDef.Profiles => new ProxyItemSet<IfcProfileDef, IIfcProfileDef>(Profiles);

	IfcLabel? IIfcCompositeProfileDef.Label
	{
		get
		{
			return Label;
		}
		set
		{
			Label = value;
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 2 }, new int[] { -1 }, 5)]
	public IItemSet<IfcProfileDef> Profiles
	{
		get
		{
			if (_activated)
			{
				return _profiles;
			}
			Activate();
			return _profiles;
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcLabel? Label
	{
		get
		{
			if (_activated)
			{
				return _label;
			}
			Activate();
			return _label;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_label = v;
			}, _label, value, "Label", 4);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcProfileDef profile in Profiles)
			{
				yield return profile;
			}
		}
	}

	internal IfcCompositeProfileDef(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_profiles = new ItemSet<IfcProfileDef>(this, 0, 3);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 2:
			_profiles.InternalAdd((IfcProfileDef)value.EntityVal);
			break;
		case 3:
			_label = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcCompositeProfileDef other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcCompositeProfileDefClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcCompositeProfileDefClause.InvariantProfileType:
				result = Functions.SIZEOF(Enumerable.Where(Profiles, (IfcProfileDef temp) => temp.ProfileType != Profiles.ItemAt(0L).ProfileType)) == 0;
				break;
			case IfcCompositeProfileDefClause.NoRecursion:
				result = Functions.SIZEOF(Enumerable.Where(Profiles, (IfcProfileDef temp) => Functions.TYPEOF(temp).Contains("IFC4.IFCCOMPOSITEPROFILEDEF"))) == 0;
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcCompositeProfileDef>()?.LogError($"Exception thrown evaluating where-clause 'IfcCompositeProfileDef.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcCompositeProfileDefClause.InvariantProfileType))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcCompositeProfileDef.InvariantProfileType",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcCompositeProfileDefClause.NoRecursion))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcCompositeProfileDef.NoRecursion",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
