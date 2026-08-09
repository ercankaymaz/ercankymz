using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.RepresentationResource;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;

namespace Xbim.Ifc2x3.StructuralAnalysisDomain;

[ExpressType("IfcStructuralSurfaceMemberVarying", 421)]
public class IfcStructuralSurfaceMemberVarying : IfcStructuralSurfaceMember, IIfcStructuralSurfaceMemberVarying, IIfcStructuralSurfaceMember, IIfcStructuralMember, IIfcStructuralItem, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, Xbim.Ifc4.StructuralAnalysisDomain.IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcStructuralSurfaceMemberVarying>, IExpressValidatable
{
	public enum IfcStructuralSurfaceMemberVaryingClause
	{
		WR61,
		WR62,
		WR63
	}

	private readonly ItemSet<IfcPositiveLengthMeasure> _subsequentThickness;

	private IfcShapeAspect _varyingThicknessLocation;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.None, new int[] { 2 }, new int[] { -1 }, 19)]
	public IItemSet<IfcPositiveLengthMeasure> SubsequentThickness
	{
		get
		{
			if (_activated)
			{
				return _subsequentThickness;
			}
			Activate();
			return _subsequentThickness;
		}
	}

	[EntityAttribute(11, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 20)]
	public IfcShapeAspect VaryingThicknessLocation
	{
		get
		{
			if (_activated)
			{
				return _varyingThicknessLocation;
			}
			Activate();
			return _varyingThicknessLocation;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcShapeAspect v)
			{
				_varyingThicknessLocation = v;
			}, _varyingThicknessLocation, value, "VaryingThicknessLocation", 11);
		}
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.List, EntityAttributeType.None, new int[] { 3 }, new int[] { -1 }, 0)]
	public List<IfcPositiveLengthMeasure> VaryingThickness
	{
		get
		{
			List<IfcPositiveLengthMeasure> list = new List<IfcPositiveLengthMeasure>();
			list.Add(base.Thickness ?? ((IfcPositiveLengthMeasure)0.0));
			list.AddRange(SubsequentThickness);
			return list;
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
			if (VaryingThicknessLocation != null)
			{
				yield return VaryingThicknessLocation;
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

	internal IfcStructuralSurfaceMemberVarying(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_subsequentThickness = new ItemSet<IfcPositiveLengthMeasure>(this, 0, 10);
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
		case 7:
		case 8:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 9:
			_subsequentThickness.InternalAdd(value.RealVal);
			break;
		case 10:
			_varyingThicknessLocation = (IfcShapeAspect)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcStructuralSurfaceMemberVarying other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcStructuralSurfaceMemberVaryingClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcStructuralSurfaceMemberVaryingClause.WR61:
				result = Functions.EXISTS(base.Thickness);
				break;
			case IfcStructuralSurfaceMemberVaryingClause.WR62:
				result = Functions.SIZEOF(Enumerable.Where(VaryingThicknessLocation.ShapeRepresentations, (IfcShapeModel temp) => Functions.SIZEOF(temp.Items) != 1)) == 0;
				break;
			case IfcStructuralSurfaceMemberVaryingClause.WR63:
				result = Functions.SIZEOF(Enumerable.Where(VaryingThicknessLocation.ShapeRepresentations, (IfcShapeModel temp) => !Functions.TYPEOF(temp.Items.ItemAt(0L)).Contains("IFC2X3.IFCCARTESIANPOINT") && !Functions.TYPEOF(temp.Items.ItemAt(0L)).Contains("IFC2X3.IFCPOINTONSURFACE"))) == 0;
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcStructuralSurfaceMemberVarying>()?.LogError($"Exception thrown evaluating where-clause 'IfcStructuralSurfaceMemberVarying.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcStructuralSurfaceMemberVaryingClause.WR61))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcStructuralSurfaceMemberVarying.WR61",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcStructuralSurfaceMemberVaryingClause.WR62))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcStructuralSurfaceMemberVarying.WR62",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcStructuralSurfaceMemberVaryingClause.WR63))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcStructuralSurfaceMemberVarying.WR63",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
