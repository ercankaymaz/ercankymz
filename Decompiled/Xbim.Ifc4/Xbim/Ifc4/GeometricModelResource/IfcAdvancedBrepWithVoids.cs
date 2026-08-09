using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.TopologyResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.GeometricModelResource;

[ExpressType("IfcAdvancedBrepWithVoids", 1093)]
public class IfcAdvancedBrepWithVoids : IfcAdvancedBrep, IInstantiableEntity, IPersistEntity, IPersist, IIfcAdvancedBrepWithVoids, IIfcAdvancedBrep, IIfcManifoldSolidBrep, IIfcSolidModel, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcBooleanOperand, IIfcBooleanOperand, IfcSolidOrShell, IIfcSolidOrShell, IContainsEntityReferences, IEquatable<IfcAdvancedBrepWithVoids>, IExpressValidatable
{
	public enum IfcAdvancedBrepWithVoidsClause
	{
		VoidsHaveAdvancedFaces
	}

	private readonly ItemSet<IfcClosedShell> _voids;

	IItemSet<IIfcClosedShell> IIfcAdvancedBrepWithVoids.Voids => new ProxyItemSet<IfcClosedShell, IIfcClosedShell>(Voids);

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 4)]
	public IItemSet<IfcClosedShell> Voids
	{
		get
		{
			if (_activated)
			{
				return _voids;
			}
			Activate();
			return _voids;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.Outer != null)
			{
				yield return base.Outer;
			}
			foreach (IfcClosedShell @void in Voids)
			{
				yield return @void;
			}
		}
	}

	internal IfcAdvancedBrepWithVoids(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_voids = new ItemSet<IfcClosedShell>(this, 0, 2);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 1:
			_voids.InternalAdd((IfcClosedShell)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcAdvancedBrepWithVoids other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcAdvancedBrepWithVoidsClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcAdvancedBrepWithVoidsClause.VoidsHaveAdvancedFaces)
			{
				result = Functions.SIZEOF(Enumerable.Where(Voids, (IfcClosedShell Vsh) => Functions.SIZEOF(Enumerable.Where(Vsh.CfsFaces, (IfcFace Afs) => !Functions.TYPEOF(Afs).Contains("IFC4.IFCADVANCEDFACE"))) == 0)) == 0;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcAdvancedBrepWithVoids>()?.LogError($"Exception thrown evaluating where-clause 'IfcAdvancedBrepWithVoids.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcAdvancedBrepWithVoidsClause.VoidsHaveAdvancedFaces))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcAdvancedBrepWithVoids.VoidsHaveAdvancedFaces",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
