using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.ProfileResource;

[ExpressType("IfcCompositeProfileDef", 172)]
public class IfcCompositeProfileDef : IfcProfileDef, IIfcCompositeProfileDef, IIfcProfileDef, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcCompositeProfileDef>, IExpressValidatable
{
	public enum IfcCompositeProfileDefClause
	{
		WR1,
		WR2
	}

	private readonly ItemSet<IfcProfileDef> _profiles;

	private Xbim.Ifc2x3.MeasureResource.IfcLabel? _label;

	[CrossSchemaAttribute(typeof(IIfcCompositeProfileDef), 3)]
	IItemSet<IIfcProfileDef> IIfcCompositeProfileDef.Profiles => new ProxyItemSet<IfcProfileDef, IIfcProfileDef>(Profiles);

	[CrossSchemaAttribute(typeof(IIfcCompositeProfileDef), 4)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcCompositeProfileDef.Label
	{
		get
		{
			if (!Label.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Label.Value);
		}
		set
		{
			Label = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLabel?(new Xbim.Ifc2x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLabel?)null));
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 2 }, new int[] { -1 }, 3)]
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

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public Xbim.Ifc2x3.MeasureResource.IfcLabel? Label
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel? v)
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
			case IfcCompositeProfileDefClause.WR1:
				result = Functions.SIZEOF(Enumerable.Where(Profiles, (IfcProfileDef temp) => temp.ProfileType != Profiles.ItemAt(0L).ProfileType)) == 0;
				break;
			case IfcCompositeProfileDefClause.WR2:
				result = Functions.SIZEOF(Enumerable.Where(Profiles, (IfcProfileDef temp) => Functions.TYPEOF(temp).Contains("IFC2X3.IFCCOMPOSITEPROFILEDEF"))) == 0;
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
		if (!ValidateClause(IfcCompositeProfileDefClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcCompositeProfileDef.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcCompositeProfileDefClause.WR2))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcCompositeProfileDef.WR2",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
