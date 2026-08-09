using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.ActorResource;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.ConstraintResource;

[ExpressType("IfcConstraint", 81)]
public abstract class IfcConstraint : PersistEntity, IIfcConstraint, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IEquatable<IfcConstraint>, IExpressValidatable
{
	public enum IfcConstraintClause
	{
		WR11
	}

	private IfcLabel _name;

	private IfcText? _description;

	private IfcConstraintEnum _constraintGrade;

	private IfcLabel? _constraintSource;

	private IfcActorSelect _creatingActor;

	private IfcDateTime? _creationTime;

	private IfcLabel? _userDefinedGrade;

	IfcLabel IIfcConstraint.Name
	{
		get
		{
			return Name;
		}
		set
		{
			Name = value;
		}
	}

	IfcText? IIfcConstraint.Description
	{
		get
		{
			return Description;
		}
		set
		{
			Description = value;
		}
	}

	IfcConstraintEnum IIfcConstraint.ConstraintGrade
	{
		get
		{
			return ConstraintGrade;
		}
		set
		{
			ConstraintGrade = value;
		}
	}

	IfcLabel? IIfcConstraint.ConstraintSource
	{
		get
		{
			return ConstraintSource;
		}
		set
		{
			ConstraintSource = value;
		}
	}

	IIfcActorSelect IIfcConstraint.CreatingActor
	{
		get
		{
			return CreatingActor;
		}
		set
		{
			CreatingActor = value as IfcActorSelect;
		}
	}

	IfcDateTime? IIfcConstraint.CreationTime
	{
		get
		{
			return CreationTime;
		}
		set
		{
			CreationTime = value;
		}
	}

	IfcLabel? IIfcConstraint.UserDefinedGrade
	{
		get
		{
			return UserDefinedGrade;
		}
		set
		{
			UserDefinedGrade = value;
		}
	}

	IEnumerable<IIfcExternalReferenceRelationship> IIfcConstraint.HasExternalReferences => HasExternalReferences;

	IEnumerable<IIfcResourceConstraintRelationship> IIfcConstraint.PropertiesForConstraint => PropertiesForConstraint;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public IfcLabel Name
	{
		get
		{
			if (_activated)
			{
				return _name;
			}
			Activate();
			return _name;
		}
		set
		{
			SetValue(delegate(IfcLabel v)
			{
				_name = v;
			}, _name, value, "Name", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public IfcText? Description
	{
		get
		{
			if (_activated)
			{
				return _description;
			}
			Activate();
			return _description;
		}
		set
		{
			SetValue(delegate(IfcText? v)
			{
				_description = v;
			}, _description, value, "Description", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 3)]
	public IfcConstraintEnum ConstraintGrade
	{
		get
		{
			if (_activated)
			{
				return _constraintGrade;
			}
			Activate();
			return _constraintGrade;
		}
		set
		{
			SetValue(delegate(IfcConstraintEnum v)
			{
				_constraintGrade = v;
			}, _constraintGrade, value, "ConstraintGrade", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public IfcLabel? ConstraintSource
	{
		get
		{
			if (_activated)
			{
				return _constraintSource;
			}
			Activate();
			return _constraintSource;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_constraintSource = v;
			}, _constraintSource, value, "ConstraintSource", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcActorSelect CreatingActor
	{
		get
		{
			if (_activated)
			{
				return _creatingActor;
			}
			Activate();
			return _creatingActor;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcActorSelect v)
			{
				_creatingActor = v;
			}, _creatingActor, value, "CreatingActor", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcDateTime? CreationTime
	{
		get
		{
			if (_activated)
			{
				return _creationTime;
			}
			Activate();
			return _creationTime;
		}
		set
		{
			SetValue(delegate(IfcDateTime? v)
			{
				_creationTime = v;
			}, _creationTime, value, "CreationTime", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public IfcLabel? UserDefinedGrade
	{
		get
		{
			if (_activated)
			{
				return _userDefinedGrade;
			}
			Activate();
			return _userDefinedGrade;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_userDefinedGrade = v;
			}, _userDefinedGrade, value, "UserDefinedGrade", 7);
		}
	}

	[InverseProperty("RelatedResourceObjects")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 8)]
	public IEnumerable<IfcExternalReferenceRelationship> HasExternalReferences => base.Model.Instances.Where((IfcExternalReferenceRelationship e) => e.RelatedResourceObjects != null && e.RelatedResourceObjects.Contains(this), "RelatedResourceObjects", this);

	[InverseProperty("RelatingConstraint")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 9)]
	public IEnumerable<IfcResourceConstraintRelationship> PropertiesForConstraint => base.Model.Instances.Where((IfcResourceConstraintRelationship e) => Equals(e.RelatingConstraint), "RelatingConstraint", this);

	internal IfcConstraint(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_name = value.StringVal;
			break;
		case 1:
			_description = value.StringVal;
			break;
		case 2:
			_constraintGrade = (IfcConstraintEnum)Enum.Parse(typeof(IfcConstraintEnum), value.EnumVal, ignoreCase: true);
			break;
		case 3:
			_constraintSource = value.StringVal;
			break;
		case 4:
			_creatingActor = (IfcActorSelect)value.EntityVal;
			break;
		case 5:
			_creationTime = value.StringVal;
			break;
		case 6:
			_userDefinedGrade = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcConstraint other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcConstraintClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcConstraintClause.WR11)
			{
				result = ConstraintGrade != IfcConstraintEnum.USERDEFINED || (ConstraintGrade == IfcConstraintEnum.USERDEFINED && Functions.EXISTS(UserDefinedGrade));
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcConstraint>()?.LogError($"Exception thrown evaluating where-clause 'IfcConstraint.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcConstraintClause.WR11))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcConstraint.WR11",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
