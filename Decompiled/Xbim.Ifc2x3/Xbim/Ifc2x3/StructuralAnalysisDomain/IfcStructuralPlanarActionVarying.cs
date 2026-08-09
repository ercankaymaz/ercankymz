using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.RepresentationResource;
using Xbim.Ifc2x3.StructuralLoadResource;

namespace Xbim.Ifc2x3.StructuralAnalysisDomain;

[ExpressType("IfcStructuralPlanarActionVarying", 357)]
public class IfcStructuralPlanarActionVarying : IfcStructuralPlanarAction, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcStructuralPlanarActionVarying>
{
	private IfcShapeAspect _varyingAppliedLoadLocation;

	private readonly ItemSet<IfcStructuralLoad> _subsequentAppliedLoads;

	[EntityAttribute(13, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 20)]
	public IfcShapeAspect VaryingAppliedLoadLocation
	{
		get
		{
			if (_activated)
			{
				return _varyingAppliedLoadLocation;
			}
			Activate();
			return _varyingAppliedLoadLocation;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcShapeAspect v)
			{
				_varyingAppliedLoadLocation = v;
			}, _varyingAppliedLoadLocation, value, "VaryingAppliedLoadLocation", 13);
		}
	}

	[EntityAttribute(14, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 2 }, new int[] { -1 }, 21)]
	public IItemSet<IfcStructuralLoad> SubsequentAppliedLoads
	{
		get
		{
			if (_activated)
			{
				return _subsequentAppliedLoads;
			}
			Activate();
			return _subsequentAppliedLoads;
		}
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 3 }, new int[] { -1 }, 0)]
	public List<IfcStructuralLoad> VaryingAppliedLoads
	{
		get
		{
			List<IfcStructuralLoad> list = new List<IfcStructuralLoad>();
			list.Add(base.AppliedLoad);
			list.AddRange(SubsequentAppliedLoads);
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
			if (base.AppliedLoad != null)
			{
				yield return base.AppliedLoad;
			}
			if (base.CausedBy != null)
			{
				yield return base.CausedBy;
			}
			if (VaryingAppliedLoadLocation != null)
			{
				yield return VaryingAppliedLoadLocation;
			}
			foreach (IfcStructuralLoad subsequentAppliedLoad in SubsequentAppliedLoads)
			{
				yield return subsequentAppliedLoad;
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
			if (base.CausedBy != null)
			{
				yield return base.CausedBy;
			}
		}
	}

	internal IfcStructuralPlanarActionVarying(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_subsequentAppliedLoads = new ItemSet<IfcStructuralLoad>(this, 0, 14);
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
		case 9:
		case 10:
		case 11:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 12:
			_varyingAppliedLoadLocation = (IfcShapeAspect)value.EntityVal;
			break;
		case 13:
			_subsequentAppliedLoads.InternalAdd((IfcStructuralLoad)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcStructuralPlanarActionVarying other)
	{
		return this == other;
	}
}
