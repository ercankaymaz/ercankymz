using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationAppearanceResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.TopologyResource;

[ExpressType("IfcFace", 83)]
public class IfcFace : IfcTopologicalRepresentationItem, IInstantiableEntity, IPersistEntity, IPersist, IIfcFace, IIfcTopologicalRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcFace>, IExpressValidatable
{
	public enum IfcFaceClause
	{
		HasOuterBound
	}

	private readonly ItemSet<IfcFaceBound> _bounds;

	IItemSet<IIfcFaceBound> IIfcFace.Bounds => new ProxyItemSet<IfcFaceBound, IIfcFaceBound>(Bounds);

	IEnumerable<IIfcTextureMap> IIfcFace.HasTextureMaps => HasTextureMaps;

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

	[InverseProperty("MappedTo")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 4)]
	public IEnumerable<IfcTextureMap> HasTextureMaps => base.Model.Instances.Where((IfcTextureMap e) => Equals(e.MappedTo), "MappedTo", this);

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
			if (clause == IfcFaceClause.HasOuterBound)
			{
				result = Functions.SIZEOF(Enumerable.Where(Bounds, (IfcFaceBound temp) => Functions.TYPEOF(temp).Contains("IFC4.IFCFACEOUTERBOUND"))) <= 1;
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
		if (!ValidateClause(IfcFaceClause.HasOuterBound))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcFace.HasOuterBound",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
