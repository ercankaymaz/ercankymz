using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc2x3.TopologyResource;

[ExpressType("IfcFace", 83)]
public class IfcFace : IfcTopologicalRepresentationItem, IIfcFace, IIfcTopologicalRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcFace>, IExpressValidatable
{
	public enum IfcFaceClause
	{
		WR1
	}

	private readonly ItemSet<IfcFaceBound> _bounds;

	[CrossSchemaAttribute(typeof(IIfcFace), 1)]
	IItemSet<IIfcFaceBound> IIfcFace.Bounds => new ProxyItemSet<IfcFaceBound, IIfcFaceBound>(Bounds);

	IEnumerable<IIfcTextureMap> IIfcFace.HasTextureMaps => base.Model.Instances.Where((IIfcTextureMap e) => e.MappedTo as IfcFace == this, "MappedTo", this);

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 3)]
	public IItemSet<IfcFaceBound> Bounds
	{
		get
		{
			if (_activated)
			{
				return _bounds;
			}
			Activate();
			return _bounds;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcFaceBound bound in Bounds)
			{
				yield return bound;
			}
		}
	}

	internal IfcFace(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_bounds = new ItemSet<IfcFaceBound>(this, 0, 1);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex == 0)
		{
			_bounds.InternalAdd((IfcFaceBound)value.EntityVal);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcFace other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcFaceClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcFaceClause.WR1)
			{
				result = Functions.SIZEOF(Enumerable.Where(Bounds, (IfcFaceBound temp) => Functions.TYPEOF(temp).Contains("IFC2X3.IFCFACEOUTERBOUND"))) <= 1;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcFace>()?.LogError($"Exception thrown evaluating where-clause 'IfcFace.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcFaceClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcFace.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
