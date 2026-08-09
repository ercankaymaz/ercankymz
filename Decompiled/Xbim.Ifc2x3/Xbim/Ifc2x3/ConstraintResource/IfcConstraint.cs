using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.ActorResource;
using Xbim.Ifc2x3.DateTimeResource;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.ConstraintResource;

[ExpressType("IfcConstraint", 81)]
public abstract class IfcConstraint : PersistEntity, IEquatable<IfcConstraint>, IIfcConstraint, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IExpressValidatable
{
	public enum IfcConstraintClause
	{
		WR11
	}

	private Xbim.Ifc2x3.MeasureResource.IfcLabel _name;

	private Xbim.Ifc2x3.MeasureResource.IfcText? _description;

	private IfcConstraintEnum _constraintGrade;

	private Xbim.Ifc2x3.MeasureResource.IfcLabel? _constraintSource;

	private IfcActorSelect _creatingActor;

	private IfcDateTimeSelect _creationTime;

	private Xbim.Ifc2x3.MeasureResource.IfcLabel? _userDefinedGrade;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public Xbim.Ifc2x3.MeasureResource.IfcLabel Name
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel v)
			{
				_name = v;
			}, _name, value, "Name", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public Xbim.Ifc2x3.MeasureResource.IfcText? Description
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcText? v)
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
	public Xbim.Ifc2x3.MeasureResource.IfcLabel? ConstraintSource
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel? v)
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

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
	public IfcDateTimeSelect CreationTime
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
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcDateTimeSelect v)
			{
				_creationTime = v;
			}, _creationTime, value, "CreationTime", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public Xbim.Ifc2x3.MeasureResource.IfcLabel? UserDefinedGrade
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel? v)
			{
				_userDefinedGrade = v;
			}, _userDefinedGrade, value, "UserDefinedGrade", 7);
		}
	}

	[InverseProperty("ClassifiedConstraint")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 8)]
	public IEnumerable<IfcConstraintClassificationRelationship> ClassifiedAs => base.Model.Instances.Where((IfcConstraintClassificationRelationship e) => Equals(e.ClassifiedConstraint), "ClassifiedConstraint", this);

	[InverseProperty("RelatingConstraint")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 9)]
	public IEnumerable<IfcConstraintRelationship> RelatesConstraints => base.Model.Instances.Where((IfcConstraintRelationship e) => Equals(e.RelatingConstraint), "RelatingConstraint", this);

	[InverseProperty("RelatedConstraints")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 10)]
	public IEnumerable<IfcConstraintRelationship> IsRelatedWith => base.Model.Instances.Where((IfcConstraintRelationship e) => e.RelatedConstraints != null && e.RelatedConstraints.Contains(this), "RelatedConstraints", this);

	[InverseProperty("RelatingConstraint")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 11)]
	public IEnumerable<IfcPropertyConstraintRelationship> PropertiesForConstraint => base.Model.Instances.Where((IfcPropertyConstraintRelationship e) => Equals(e.RelatingConstraint), "RelatingConstraint", this);

	[InverseProperty("RelatingConstraint")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 12)]
	public IEnumerable<IfcConstraintAggregationRelationship> Aggregates => base.Model.Instances.Where((IfcConstraintAggregationRelationship e) => Equals(e.RelatingConstraint), "RelatingConstraint", this);

	[InverseProperty("RelatedConstraints")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 13)]
	public IEnumerable<IfcConstraintAggregationRelationship> IsAggregatedIn => base.Model.Instances.Where((IfcConstraintAggregationRelationship e) => e.RelatedConstraints != null && e.RelatedConstraints.Contains(this), "RelatedConstraints", this);

	[CrossSchemaAttribute(typeof(IIfcConstraint), 1)]
	Xbim.Ifc4.MeasureResource.IfcLabel IIfcConstraint.Name
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Name);
		}
		set
		{
			Name = new Xbim.Ifc2x3.MeasureResource.IfcLabel(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcConstraint), 2)]
	Xbim.Ifc4.MeasureResource.IfcText? IIfcConstraint.Description
	{
		get
		{
			if (!Description.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcText(Description.Value);
		}
		set
		{
			Description = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcText?(new Xbim.Ifc2x3.MeasureResource.IfcText(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcText?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcConstraint), 3)]
	Xbim.Ifc4.Interfaces.IfcConstraintEnum IIfcConstraint.ConstraintGrade
	{
		get
		{
			return ConstraintGrade switch
			{
				IfcConstraintEnum.HARD => Xbim.Ifc4.Interfaces.IfcConstraintEnum.HARD, 
				IfcConstraintEnum.SOFT => Xbim.Ifc4.Interfaces.IfcConstraintEnum.SOFT, 
				IfcConstraintEnum.ADVISORY => Xbim.Ifc4.Interfaces.IfcConstraintEnum.ADVISORY, 
				IfcConstraintEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcConstraintEnum.USERDEFINED, 
				IfcConstraintEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcConstraintEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcConstraintEnum.HARD:
				ConstraintGrade = IfcConstraintEnum.HARD;
				break;
			case Xbim.Ifc4.Interfaces.IfcConstraintEnum.SOFT:
				ConstraintGrade = IfcConstraintEnum.SOFT;
				break;
			case Xbim.Ifc4.Interfaces.IfcConstraintEnum.ADVISORY:
				ConstraintGrade = IfcConstraintEnum.ADVISORY;
				break;
			case Xbim.Ifc4.Interfaces.IfcConstraintEnum.USERDEFINED:
				ConstraintGrade = IfcConstraintEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcConstraintEnum.NOTDEFINED:
				ConstraintGrade = IfcConstraintEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcConstraint), 4)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcConstraint.ConstraintSource
	{
		get
		{
			if (!ConstraintSource.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(ConstraintSource.Value);
		}
		set
		{
			ConstraintSource = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLabel?(new Xbim.Ifc2x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcConstraint), 5)]
	IIfcActorSelect IIfcConstraint.CreatingActor
	{
		get
		{
			if (CreatingActor == null)
			{
				return null;
			}
			IfcOrganization ifcOrganization = CreatingActor as IfcOrganization;
			if (ifcOrganization != null)
			{
				return ifcOrganization;
			}
			IfcPerson ifcPerson = CreatingActor as IfcPerson;
			if (ifcPerson != null)
			{
				return ifcPerson;
			}
			IfcPersonAndOrganization ifcPersonAndOrganization = CreatingActor as IfcPersonAndOrganization;
			if (ifcPersonAndOrganization != null)
			{
				return ifcPersonAndOrganization;
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				CreatingActor = null;
				return;
			}
			IfcOrganization ifcOrganization = value as IfcOrganization;
			if (ifcOrganization != null)
			{
				CreatingActor = ifcOrganization;
				return;
			}
			IfcPerson ifcPerson = value as IfcPerson;
			if (ifcPerson != null)
			{
				CreatingActor = ifcPerson;
				return;
			}
			IfcPersonAndOrganization ifcPersonAndOrganization = value as IfcPersonAndOrganization;
			if (ifcPersonAndOrganization != null)
			{
				CreatingActor = ifcPersonAndOrganization;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcConstraint), 6)]
	IfcDateTime? IIfcConstraint.CreationTime
	{
		get
		{
			return (CreationTime == null) ? ((IfcDateTime)null) : new IfcDateTime(CreationTime.ToISODateTimeString());
		}
		set
		{
			if (!value.HasValue)
			{
				CreationTime = null;
				return;
			}
			DateTime d = value.Value;
			CreationTime = base.Model.Instances.New(delegate(IfcDateAndTime dt)
			{
				dt.DateComponent = base.Model.Instances.New(delegate(IfcCalendarDate date)
				{
					date.YearComponent = d.Year;
					date.MonthComponent = d.Month;
					date.DayComponent = d.Day;
				});
				dt.TimeComponent = base.Model.Instances.New(delegate(IfcLocalTime t)
				{
					t.HourComponent = d.Hour;
					t.MinuteComponent = d.Minute;
					t.SecondComponent = d.Second;
				});
			});
		}
	}

	[CrossSchemaAttribute(typeof(IIfcConstraint), 7)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcConstraint.UserDefinedGrade
	{
		get
		{
			if (!UserDefinedGrade.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(UserDefinedGrade.Value);
		}
		set
		{
			UserDefinedGrade = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLabel?(new Xbim.Ifc2x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLabel?)null));
		}
	}

	IEnumerable<IIfcExternalReferenceRelationship> IIfcConstraint.HasExternalReferences => base.Model.Instances.Where((IIfcExternalReferenceRelationship e) => e.RelatedResourceObjects != null && e.RelatedResourceObjects.Contains(this), "RelatedResourceObjects", this);

	IEnumerable<IIfcResourceConstraintRelationship> IIfcConstraint.PropertiesForConstraint => base.Model.Instances.Where((IIfcResourceConstraintRelationship e) => e.RelatingConstraint as IfcConstraint == this, "RelatingConstraint", this);

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
			_creationTime = (IfcDateTimeSelect)value.EntityVal;
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
