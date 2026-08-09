using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.GeometryResource;

[ExpressType("IfcLine", 272)]
public class IfcLine : IfcCurve, IInstantiableEntity, IPersistEntity, IPersist, IIfcLine, IIfcCurve, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect, IContainsEntityReferences, IEquatable<IfcLine>, IExpressValidatable
{
	public enum IfcLineClause
	{
		SameDim
	}

	private IfcCartesianPoint _pnt;

	private IfcVector _dir;

	IIfcCartesianPoint IIfcLine.Pnt
	{
		get
		{
			return Pnt;
		}
		set
		{
			Pnt = value as IfcCartesianPoint;
		}
	}

	IIfcVector IIfcLine.Dir
	{
		get
		{
			return Dir;
		}
		set
		{
			Dir = value as IfcVector;
		}
	}

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcCartesianPoint Pnt
	{
		get
		{
			if (_activated)
			{
				return _pnt;
			}
			Activate();
			return _pnt;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcCartesianPoint v)
			{
				_pnt = v;
			}, _pnt, value, "Pnt", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
	public IfcVector Dir
	{
		get
		{
			if (_activated)
			{
				return _dir;
			}
			Activate();
			return _dir;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcVector v)
			{
				_dir = v;
			}, _dir, value, "Dir", 2);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (Pnt != null)
			{
				yield return Pnt;
			}
			if (Dir != null)
			{
				yield return Dir;
			}
		}
	}

	internal IfcLine(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_pnt = (IfcCartesianPoint)value.EntityVal;
			break;
		case 1:
			_dir = (IfcVector)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcLine other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcLineClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcLineClause.SameDim)
			{
				result = Dir.Dim == Pnt.Dim;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcLine>()?.LogError($"Exception thrown evaluating where-clause 'IfcLine.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcLineClause.SameDim))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcLine.SameDim",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
