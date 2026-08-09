using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4x3.GeometryResource;

[ExpressType("IfcCompositeCurveOnSurface", 1130)]
public class IfcCompositeCurveOnSurface : IfcCompositeCurve, IInstantiableEntity, IPersistEntity, IPersist, IfcCurveOnSurface, IExpressSelectType, IIfcCurveOnSurface, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcCompositeCurveOnSurface>, IIfcCompositeCurveOnSurface, IIfcCompositeCurve, IIfcBoundedCurve, IIfcCurve, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IfcGeometricSetSelect, IIfcGeometricSetSelect, IfcCurveOrEdgeCurve, IIfcCurveOrEdgeCurve, Xbim.Ifc4.GeometryResource.IfcCurveOnSurface
{
	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 0)]
	public List<IfcSurface> BasisSurface => IfcGetBasisSurface(this).ToList();

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcSegment segment in base.Segments)
			{
				yield return segment;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcSegment segment in base.Segments)
			{
				yield return segment;
			}
		}
	}

	List<IIfcSurface> IIfcCompositeCurveOnSurface.BasisSurface => IfcGetBasisSurface(this).Cast<IIfcSurface>().ToList();

	internal IfcCompositeCurveOnSurface(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if ((uint)propIndex <= 1u)
		{
			base.Parse(propIndex, value, nestedIndex);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcCompositeCurveOnSurface other)
	{
		return this == other;
	}

	private static IEnumerable<IfcSurface> IfcGetBasisSurface(IfcCurveOnSurface curveOnSurface)
	{
		IfcPcurve ifcPcurve = curveOnSurface as IfcPcurve;
		if (ifcPcurve != null)
		{
			yield return ifcPcurve.BasisSurface;
			yield break;
		}
		IfcCompositeCurveOnSurface ifcCompositeCurveOnSurface = curveOnSurface as IfcCompositeCurveOnSurface;
		if (ifcCompositeCurveOnSurface == null)
		{
			yield break;
		}
		foreach (IfcSegment segment in ifcCompositeCurveOnSurface.Segments)
		{
			IfcCurve parentCurve;
			if (segment is IfcCompositeCurveSegment ifcCompositeCurveSegment)
			{
				parentCurve = ifcCompositeCurveSegment.ParentCurve;
			}
			else
			{
				if (!(segment is IfcCurveSegment ifcCurveSegment))
				{
					throw new XbimException("Unexpected segment type");
				}
				parentCurve = ifcCurveSegment.ParentCurve;
			}
			if (!(parentCurve is IfcCurveOnSurface curveOnSurface2))
			{
				continue;
			}
			foreach (IfcSurface item in IfcGetBasisSurface(curveOnSurface2))
			{
				yield return item;
			}
		}
	}
}
