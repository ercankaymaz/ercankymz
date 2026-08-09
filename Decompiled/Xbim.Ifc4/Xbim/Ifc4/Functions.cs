using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Geometry;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.IfcFunctions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationAppearanceResource;
using Xbim.Ifc4.ProductExtension;
using Xbim.Ifc4.ProfileResource;
using Xbim.Ifc4.PropertyResource;
using Xbim.Ifc4.QuantityResource;
using Xbim.Ifc4.TopologyResource;

namespace Xbim.Ifc4;

public static class Functions
{
	internal static TypesArray NewTypesArray(params string[] args)
	{
		return new TypesArray(args);
	}

	internal static IfcEdgeLoop AsIfcEdgeLoop(this IfcLoop toCast)
	{
		return toCast as IfcEdgeLoop;
	}

	internal static bool AsBool(this IfcBoolean toCast)
	{
		bool? flag = (bool?)toCast.Value;
		if (!flag.HasValue)
		{
			throw new Exception("IfcLogical value not defined attempting bool conversion.");
		}
		return flag.Value;
	}

	internal static Direction IfcDirection(double x, double y, double z)
	{
		return new Direction(x, y, z);
	}

	internal static double IfcDotProduct(Direction dir1, IfcDirection dir2)
	{
		return dir1.X * dir2.X + dir1.Y * dir2.Y + dir1.Z * dir2.Z;
	}

	internal static bool AsBool(this IfcLogical toCast)
	{
		bool? flag = (bool?)toCast.Value;
		if (!flag.HasValue)
		{
			throw new Exception("IfcLogical value not defined attempting bool conversion.");
		}
		return flag.Value;
	}

	internal static IfcRelAssociatesMaterial AsIfcRelAssociatesMaterial(this IPersistEntity toCast)
	{
		return toCast as IfcRelAssociatesMaterial;
	}

	internal static IfcDescriptiveMeasure AsIfcDescriptiveMeasure(this IfcSizeSelect toCast)
	{
		return (IfcDescriptiveMeasure)(object)toCast;
	}

	internal static IfcLengthMeasure AsIfcLengthMeasure(this IfcSizeSelect toCast)
	{
		return (IfcLengthMeasure)(object)toCast;
	}

	internal static IfcEdgeCurve AsIfcEdgeCurve(this IfcEdge toCast)
	{
		return toCast as IfcEdgeCurve;
	}

	internal static IEnumerable<double> DirectionRatios(this XbimVector3D vector3D)
	{
		yield return vector3D.X;
		yield return vector3D.Y;
		yield return vector3D.Z;
	}

	internal static T ItemAt<T>(this IEnumerable<T> enumerable, long index)
	{
		if (enumerable == null)
		{
			return default(T);
		}
		T[] array = enumerable.ToArray();
		if (index < array.Length)
		{
			return array[index];
		}
		return default(T);
	}

	internal static T NVL<T>(T obj1, T obj2) where T : class
	{
		return obj1 ?? obj2;
	}

	internal static IEnumerable<IPersistEntity> USEDIN(IPersistEntity ifcObject, string v)
	{
		if (v == "IFC4.IFCRELASSOCIATES.RELATEDOBJECTS")
		{
			return from x in ifcObject.Model.Instances.OfType<IfcRelAssociates>()
				where x.RelatedObjects.Contains(ifcObject)
				select x;
		}
		throw new Exception($"NotImplemented: USEDIN does not support role {v}.");
	}

	internal static bool EXISTS(object o)
	{
		return o != null;
	}

	internal static int SIZEOF<T>(IEnumerable<T> source)
	{
		return source.Count();
	}

	internal static int SIZEOF(TypesArray array)
	{
		return array.Count();
	}

	internal static bool INTYPEOF(IPersist obj, string typeString)
	{
		return TYPEOF(obj).Contains(typeString);
	}

	internal static bool INTYPEOF(IVectorOrDirection obj, string typeString)
	{
		if (obj is Vector && typeString.ToLowerInvariant().Contains("vector"))
		{
			return true;
		}
		if (obj is Direction && typeString.ToLowerInvariant().Contains("direction"))
		{
			return true;
		}
		return false;
	}

	internal static double SQRT(double mag)
	{
		return Math.Sqrt(mag);
	}

	internal static double ABS(double mag)
	{
		return Math.Abs(mag);
	}

	internal static int BLENGTH(IfcBinary value)
	{
		throw new NotImplementedException();
	}

	internal static TypesArray TYPEOF(IPersist instance)
	{
		return new TypesArray(instance);
	}

	internal static int HIINDEX<T>(IEnumerable<T> source)
	{
		return source.Count();
	}

	internal static T IfcBooleanChoose<T>(bool B, T Choice1, T Choice2)
	{
		if (!B)
		{
			return Choice2;
		}
		return Choice1;
	}

	internal static bool IfcCorrectUnitAssignment(IItemSet<IfcUnit> Units)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		List<IfcUnitEnum> list = new List<IfcUnitEnum>();
		List<IfcDerivedUnitEnum> list2 = new List<IfcDerivedUnitEnum>();
		num = SIZEOF(Enumerable.Where(Units, (IfcUnit temp) => INTYPEOF(temp, "IFC4.IFCNAMEDUNIT") && (temp as IfcNamedUnit).UnitType != IfcUnitEnum.USERDEFINED));
		num2 = SIZEOF(Enumerable.Where(Units, (IfcUnit temp) => INTYPEOF(temp, "IFC4.IFCDERIVEDUNIT") && (temp as IfcDerivedUnit).UnitType != IfcDerivedUnitEnum.USERDEFINED));
		num3 = SIZEOF(Enumerable.Where(Units, (IfcUnit temp) => INTYPEOF(temp, "IFC4.IFCMONETARYUNIT")));
		for (int num4 = 0; num4 < SIZEOF(Units); num4++)
		{
			if (INTYPEOF(Units[num4], "IFC4.IFCNAMEDUNIT") && (Units[num4] as IfcNamedUnit).UnitType != IfcUnitEnum.USERDEFINED)
			{
				list.Add((Units[num4] as IfcNamedUnit).UnitType);
			}
			if (INTYPEOF(Units[num4], "IFC4.IFCDERIVEDUNIT") && (Units[num4] as IfcDerivedUnit).UnitType != IfcDerivedUnitEnum.USERDEFINED)
			{
				list2.Add((Units[num4] as IfcDerivedUnit).UnitType);
			}
		}
		if (SIZEOF(list) == num && SIZEOF(list2) == num2)
		{
			return num3 <= 1;
		}
		return false;
	}

	internal static Vector IfcCrossProduct(IfcDirection Arg1, IfcDirection Arg2)
	{
		if (!EXISTS(Arg1) || Arg1.Dim == 2L || !EXISTS(Arg2) || Arg2.Dim == 2L)
		{
			return null;
		}
		Direction direction = new Direction(Arg1);
		Direction arg = new Direction(Arg2);
		double[] directionRatios = IfcNormalise(direction).DirectionRatios;
		double[] directionRatios2 = IfcNormalise(arg).DirectionRatios;
		Direction direction2 = new Direction(directionRatios[1] * directionRatios2[2] - directionRatios[2] * directionRatios2[1], directionRatios[2] * directionRatios2[0] - directionRatios[0] * directionRatios2[2], directionRatios[0] * directionRatios2[1] - directionRatios[1] * directionRatios2[0]);
		double num = 0.0;
		for (int i = 0; i < 3; i++)
		{
			num += direction2.DirectionRatios[i] * direction2.DirectionRatios[i];
		}
		if (!(num > 0.0))
		{
			return new Vector(direction, 0.0);
		}
		return new Vector(direction2, SQRT(num));
	}

	internal static bool IfcTopologyRepresentationTypes(IfcLabel? RepType, IItemSet<IfcRepresentationItem> Items)
	{
		int num = 0;
		if (!RepType.HasValue)
		{
			return true;
		}
		switch (RepType.Value)
		{
		case "Vertex":
			num = Items.Count((IfcRepresentationItem x) => x is IIfcVertex);
			break;
		case "Edge":
			num = Items.Count((IfcRepresentationItem x) => x is IIfcEdge);
			break;
		case "Path":
			num = Items.Count((IfcRepresentationItem x) => x is IIfcPath);
			break;
		case "Face":
			num = Items.Count((IfcRepresentationItem x) => x is IIfcFace);
			break;
		case "Shell":
			num = Items.Count((IfcRepresentationItem x) => x is IIfcOpenShell || x is IIfcClosedShell);
			break;
		case "Undefined":
			return true;
		}
		return num == Items.Count;
	}

	internal static bool IfcTaperedSweptAreaProfiles(IfcProfileDef StartArea, IfcProfileDef EndArea)
	{
		bool flag = false;
		if (INTYPEOF(StartArea, "IFC4.IFCPARAMETERIZEDPROFILEDEF"))
		{
			if (INTYPEOF(EndArea, "IFC4.IFCDERIVEDPROFILEDEF"))
			{
				IIfcDerivedProfileDef ifcDerivedProfileDef = EndArea as IIfcDerivedProfileDef;
				return StartArea == ifcDerivedProfileDef.ParentProfile;
			}
			return StartArea.GetType() == EndArea.GetType();
		}
		if (INTYPEOF(EndArea, "IFC4.IFCDERIVEDPROFILEDEF"))
		{
			IIfcDerivedProfileDef ifcDerivedProfileDef2 = EndArea as IIfcDerivedProfileDef;
			return StartArea == ifcDerivedProfileDef2.ParentProfile;
		}
		return false;
	}

	internal static bool IfcShapeRepresentationTypes(IfcLabel? RepType, IItemSet<IfcRepresentationItem> Items)
	{
		int num = 0;
		if (!RepType.HasValue)
		{
			return num == Items.Count;
		}
		switch (RepType.Value)
		{
		case "Point":
			num = Items.Count((IfcRepresentationItem x) => x is IIfcPoint);
			break;
		case "PointCloud":
			num = Items.Count((IfcRepresentationItem x) => x is IIfcCartesianPointList3D);
			break;
		case "Curve":
			num = Items.Count((IfcRepresentationItem x) => x is IIfcCurve);
			break;
		case "Curve2D":
			num = Items.Count((IfcRepresentationItem x) => x is IIfcCurve && ((IIfcCurve)x).Dim == 2L);
			break;
		case "Curve3D":
			num = Items.Count((IfcRepresentationItem x) => x is IIfcCurve && ((IIfcCurve)x).Dim == 3L);
			break;
		case "Surface":
			num = Items.Count((IfcRepresentationItem x) => x is IIfcSurface);
			break;
		case "Surface2D":
			num = Items.Count((IfcRepresentationItem x) => x is IIfcSurface && ((IIfcSurface)x).Dim == 2L);
			break;
		case "Surface3D":
			num = Items.Count((IfcRepresentationItem x) => x is IIfcSurface && ((IIfcSurface)x).Dim == 3L);
			break;
		case "FillArea":
			num = Items.Count((IfcRepresentationItem x) => x is IIfcAnnotationFillArea);
			break;
		case "Text":
			num = Items.Count((IfcRepresentationItem x) => x is IIfcTextLiteral);
			break;
		case "AdvancedSurface":
			num = Items.Count((IfcRepresentationItem x) => x is IIfcBSplineSurface);
			break;
		case "Annotation2D":
			num = Items.Count((IfcRepresentationItem x) => x is IIfcPoint || x is IIfcCurve || x is IIfcGeometricCurveSet || x is IIfcAnnotationFillArea || x is IIfcTextLiteral);
			break;
		case "GeometricSet":
			num = Items.Count((IfcRepresentationItem x) => x is IIfcGeometricSet || x is IIfcPoint || x is IIfcCurve || x is IIfcSurface);
			break;
		case "GeometricCurveSet":
			num = Items.Count((IfcRepresentationItem x) => x is IIfcGeometricCurveSet || x is IIfcGeometricSet || x is IIfcPoint || x is IIfcCurve);
			foreach (IfcRepresentationItem Item in Items)
			{
				if (Item is IIfcGeometricSet && (Item as IIfcGeometricSet).Elements.Count((IIfcGeometricSetSelect temp) => temp is IfcSurface) > 0)
				{
					num--;
				}
			}
			break;
		case "Tessellation":
			num = Items.Count((IfcRepresentationItem x) => x is IIfcTessellatedItem);
			break;
		case "SurfaceOrSolidModel":
			num = Items.Count((IfcRepresentationItem x) => x is IIfcTessellatedItem || x is IIfcShellBasedSurfaceModel || x is IIfcFaceBasedSurfaceModel || x is IIfcSolidModel);
			break;
		case "SurfaceModel":
			num = Items.Count((IfcRepresentationItem x) => x is IIfcTessellatedItem || x is IIfcShellBasedSurfaceModel || x is IIfcFaceBasedSurfaceModel);
			break;
		case "SolidModel":
			num = Items.Count((IfcRepresentationItem x) => x is IIfcSolidModel);
			break;
		case "SweptSolid":
			num = Items.Count((IfcRepresentationItem x) => (x is IIfcExtrudedAreaSolid || x is IIfcRevolvedAreaSolid) && !(x is IIfcExtrudedAreaSolidTapered) && !(x is IIfcRevolvedAreaSolidTapered));
			break;
		case "AdvancedSweptSolid":
			num = Items.Count((IfcRepresentationItem x) => x is IIfcSweptAreaSolid || x is IIfcSweptDiskSolid);
			break;
		case "CSG":
			num = Items.Count((IfcRepresentationItem x) => x is IIfcBooleanResult || x is IIfcCsgPrimitive3D || x is IIfcCsgSolid);
			break;
		case "Clipping":
			num = Items.Count((IfcRepresentationItem x) => x is IIfcBooleanClippingResult);
			break;
		case "Brep":
			num = Items.Count((IfcRepresentationItem x) => x is IIfcFacetedBrep);
			break;
		case "AdvancedBrep":
			num = Items.Count((IfcRepresentationItem x) => x is IIfcManifoldSolidBrep);
			break;
		case "BoundingBox":
			num = Items.Count((IfcRepresentationItem x) => x is IIfcBoundingBox);
			if (Items.Count > 1)
			{
				num = 0;
			}
			break;
		case "SectionedSpine":
			num = Items.Count((IfcRepresentationItem x) => x is IIfcSectionedSpine);
			break;
		case "LightSource":
			num = Items.Count((IfcRepresentationItem x) => x is IIfcLightSource);
			break;
		case "MappedRepresentation":
			num = Items.Count((IfcRepresentationItem x) => x is IIfcMappedItem);
			break;
		}
		return num == Items.Count;
	}

	internal static bool IfcConsecutiveSegments(IOptionalItemSet<IfcSegmentIndexSelect> Segments)
	{
		return true;
	}

	internal static bool IfcUniquePropertySetNames(IOptionalItemSet<IfcPropertySetDefinition> hasPropertySets)
	{
		List<IfcPropertySetDefinition> source = hasPropertySets.ToList();
		return source.Select((IfcPropertySetDefinition x) => x.Name).ToList().Distinct()
			.Count() == source.Count();
	}

	internal static bool IfcUniqueDefinitionNames(IEnumerable<IfcRelDefinesByProperties> RelDefinesByProperties)
	{
		List<IfcLabel?> source = RelDefinesByProperties.SelectMany((IfcRelDefinesByProperties r) => r.RelatingPropertyDefinition.PropertySetDefinitions.Select((IIfcPropertySetDefinition x) => x.Name)).ToList();
		return source.Distinct().Count() == source.Count();
	}

	internal static bool IfcUniquePropertyName(IItemSet<IfcProperty> Properties)
	{
		return Properties.Select((IfcProperty x) => x.Name).ToList().Distinct()
			.Count() == Properties.Count();
	}

	internal static bool IfcUniquePropertyTemplateNames(IItemSet<IfcPropertyTemplate> PropertyTemplates)
	{
		return PropertyTemplates.Select((IfcPropertyTemplate x) => x.Name).ToList().Distinct()
			.Count() == PropertyTemplates.Count();
	}

	internal static bool IfcUniqueQuantityNames(IItemSet<IfcPhysicalQuantity> Quantities)
	{
		return Quantities.Select((IfcPhysicalQuantity x) => x.Name).ToList().Distinct()
			.Count() == Quantities.Count();
	}

	internal static bool IfcCurveWeightsPositive(IfcRationalBSplineCurveWithKnots B)
	{
		bool result = true;
		for (int i = 0; i <= (long)B.UpperIndexOnControlPoints; i++)
		{
			if ((double)B.Weights[i] <= 0.0)
			{
				return false;
			}
		}
		return result;
	}

	internal static bool IfcCorrectObjectAssignment(IfcObjectTypeEnum? Constraint, IItemSet<IfcObjectDefinition> Objects)
	{
		if (!Constraint.HasValue)
		{
			return true;
		}
		bool? flag = IfcCorrectObjectAssignment(Constraint.Value, Objects.ToArray());
		if (!flag.HasValue)
		{
			throw new ArgumentException("Undetermined value in where clause.");
		}
		return flag.Value;
	}

	internal static bool? IfcCorrectObjectAssignment(IfcObjectTypeEnum Constraint, IEnumerable<IfcObjectDefinition> Objects)
	{
		if (!EXISTS(Constraint))
		{
			return true;
		}
		return Constraint switch
		{
			IfcObjectTypeEnum.NOTDEFINED => true, 
			IfcObjectTypeEnum.PRODUCT => SIZEOF(Objects.Where((IfcObjectDefinition temp) => !INTYPEOF(temp, "IFC4.IFCPRODUCT"))) == 0, 
			IfcObjectTypeEnum.PROCESS => SIZEOF(Objects.Where((IfcObjectDefinition temp) => !INTYPEOF(temp, "IFC4.IFCPROCESS"))) == 0, 
			IfcObjectTypeEnum.CONTROL => SIZEOF(Objects.Where((IfcObjectDefinition temp) => !INTYPEOF(temp, "IFC4.IFCCONTROL"))) == 0, 
			IfcObjectTypeEnum.RESOURCE => SIZEOF(Objects.Where((IfcObjectDefinition temp) => !INTYPEOF(temp, "IFC4.IFCRESOURCE"))) == 0, 
			IfcObjectTypeEnum.ACTOR => SIZEOF(Objects.Where((IfcObjectDefinition temp) => !INTYPEOF(temp, "IFC4.IFCACTOR"))) == 0, 
			IfcObjectTypeEnum.GROUP => SIZEOF(Objects.Where((IfcObjectDefinition temp) => !INTYPEOF(temp, "IFC4.IFCGROUP"))) == 0, 
			IfcObjectTypeEnum.PROJECT => SIZEOF(Objects.Where((IfcObjectDefinition temp) => !INTYPEOF(temp, "IFC4.IFCPROJECT"))) == 0, 
			_ => null, 
		};
	}

	internal static bool IfcConstraintsParamBSpline(IfcInteger Degree, IfcInteger UpKnots, IfcInteger UpCp, IItemSet<IfcInteger> KnotMult, IItemSet<IfcParameterValue> Knots)
	{
		bool result = true;
		int num = (int)(long)KnotMult[0];
		for (int i = 2; i <= (long)UpKnots; i++)
		{
			num = (int)(num + (long)KnotMult[i - 1]);
		}
		if ((long)Degree < 1 || (long)UpKnots < 2 || (long)UpCp < (long)Degree || num != (long)Degree + (long)UpCp + 2)
		{
			return false;
		}
		int num2 = (int)(long)KnotMult[1];
		if (num2 < 1 || num2 > (long)Degree + 1)
		{
			return false;
		}
		for (int j = 2; j <= (long)UpKnots; j++)
		{
			if ((long)KnotMult[j - 1] < 1 || (double)Knots[j - 1] <= (double)Knots[j - 2])
			{
				return false;
			}
			num2 = (int)(long)KnotMult[j - 1];
			if (j < (long)UpKnots && num2 > (long)Degree)
			{
				return false;
			}
			if (j == UpKnots && num2 > (long)Degree + 1)
			{
				return false;
			}
		}
		return result;
	}

	private static bool HasIfcDimensionalExponents(IIfcDimensionalExponents dim, int len, int mass, int time, int elec, int temp, int substance, int lum)
	{
		if (dim.LengthExponent == len && dim.MassExponent == mass && dim.TimeExponent == time && dim.ElectricCurrentExponent == elec && dim.ThermodynamicTemperatureExponent == temp && dim.AmountOfSubstanceExponent == substance)
		{
			return dim.LuminousIntensityExponent == lum;
		}
		return false;
	}

	internal static bool IfcCorrectDimensions(IfcUnitEnum unitType, IfcDimensionalExponents dimensions)
	{
		bool? flag = NullableIfcCorrectDimensions(unitType, dimensions);
		if (!flag.HasValue && unitType != IfcUnitEnum.USERDEFINED)
		{
			throw new ArgumentException("Undetermined value in where clause.");
		}
		return flag ?? true;
	}

	private static bool? NullableIfcCorrectDimensions(IfcUnitEnum m, IfcDimensionalExponents Dim)
	{
		switch (m)
		{
		case IfcUnitEnum.LENGTHUNIT:
			if (HasIfcDimensionalExponents(Dim, 1, 0, 0, 0, 0, 0, 0))
			{
				return true;
			}
			return false;
		case IfcUnitEnum.MASSUNIT:
			if (HasIfcDimensionalExponents(Dim, 0, 1, 0, 0, 0, 0, 0))
			{
				return true;
			}
			return false;
		case IfcUnitEnum.TIMEUNIT:
			if (HasIfcDimensionalExponents(Dim, 0, 0, 1, 0, 0, 0, 0))
			{
				return true;
			}
			return false;
		case IfcUnitEnum.ELECTRICCURRENTUNIT:
			if (HasIfcDimensionalExponents(Dim, 0, 0, 0, 1, 0, 0, 0))
			{
				return true;
			}
			return false;
		case IfcUnitEnum.THERMODYNAMICTEMPERATUREUNIT:
			if (HasIfcDimensionalExponents(Dim, 0, 0, 0, 0, 1, 0, 0))
			{
				return true;
			}
			return false;
		case IfcUnitEnum.AMOUNTOFSUBSTANCEUNIT:
			if (HasIfcDimensionalExponents(Dim, 0, 0, 0, 0, 0, 1, 0))
			{
				return true;
			}
			return false;
		case IfcUnitEnum.LUMINOUSINTENSITYUNIT:
			if (HasIfcDimensionalExponents(Dim, 0, 0, 0, 0, 0, 0, 1))
			{
				return true;
			}
			return false;
		case IfcUnitEnum.PLANEANGLEUNIT:
			if (HasIfcDimensionalExponents(Dim, 0, 0, 0, 0, 0, 0, 0))
			{
				return true;
			}
			return false;
		case IfcUnitEnum.SOLIDANGLEUNIT:
			if (HasIfcDimensionalExponents(Dim, 0, 0, 0, 0, 0, 0, 0))
			{
				return true;
			}
			return false;
		case IfcUnitEnum.AREAUNIT:
			if (HasIfcDimensionalExponents(Dim, 2, 0, 0, 0, 0, 0, 0))
			{
				return true;
			}
			return false;
		case IfcUnitEnum.VOLUMEUNIT:
			if (HasIfcDimensionalExponents(Dim, 3, 0, 0, 0, 0, 0, 0))
			{
				return true;
			}
			return false;
		case IfcUnitEnum.ABSORBEDDOSEUNIT:
			if (HasIfcDimensionalExponents(Dim, 2, 0, -2, 0, 0, 0, 0))
			{
				return true;
			}
			return false;
		case IfcUnitEnum.RADIOACTIVITYUNIT:
			if (HasIfcDimensionalExponents(Dim, 0, 0, -1, 0, 0, 0, 0))
			{
				return true;
			}
			return false;
		case IfcUnitEnum.ELECTRICCAPACITANCEUNIT:
			if (HasIfcDimensionalExponents(Dim, -2, -1, 4, 2, 0, 0, 0))
			{
				return true;
			}
			return false;
		case IfcUnitEnum.DOSEEQUIVALENTUNIT:
			if (HasIfcDimensionalExponents(Dim, 2, 0, -2, 0, 0, 0, 0))
			{
				return true;
			}
			return false;
		case IfcUnitEnum.ELECTRICCHARGEUNIT:
			if (HasIfcDimensionalExponents(Dim, 0, 0, 1, 1, 0, 0, 0))
			{
				return true;
			}
			return false;
		case IfcUnitEnum.ELECTRICCONDUCTANCEUNIT:
			if (HasIfcDimensionalExponents(Dim, -2, -1, 3, 2, 0, 0, 0))
			{
				return true;
			}
			return false;
		case IfcUnitEnum.ELECTRICVOLTAGEUNIT:
			if (HasIfcDimensionalExponents(Dim, 2, 1, -3, -1, 0, 0, 0))
			{
				return true;
			}
			return false;
		case IfcUnitEnum.ELECTRICRESISTANCEUNIT:
			if (HasIfcDimensionalExponents(Dim, 2, 1, -3, -2, 0, 0, 0))
			{
				return true;
			}
			return false;
		case IfcUnitEnum.ENERGYUNIT:
			if (HasIfcDimensionalExponents(Dim, 2, 1, -2, 0, 0, 0, 0))
			{
				return true;
			}
			return false;
		case IfcUnitEnum.FORCEUNIT:
			if (HasIfcDimensionalExponents(Dim, 1, 1, -2, 0, 0, 0, 0))
			{
				return true;
			}
			return false;
		case IfcUnitEnum.FREQUENCYUNIT:
			if (HasIfcDimensionalExponents(Dim, 0, 0, -1, 0, 0, 0, 0))
			{
				return true;
			}
			return false;
		case IfcUnitEnum.INDUCTANCEUNIT:
			if (HasIfcDimensionalExponents(Dim, 2, 1, -2, -2, 0, 0, 0))
			{
				return true;
			}
			return false;
		case IfcUnitEnum.ILLUMINANCEUNIT:
			if (HasIfcDimensionalExponents(Dim, -2, 0, 0, 0, 0, 0, 1))
			{
				return true;
			}
			return false;
		case IfcUnitEnum.LUMINOUSFLUXUNIT:
			if (HasIfcDimensionalExponents(Dim, 0, 0, 0, 0, 0, 0, 1))
			{
				return true;
			}
			return false;
		case IfcUnitEnum.MAGNETICFLUXUNIT:
			if (HasIfcDimensionalExponents(Dim, 2, 1, -2, -1, 0, 0, 0))
			{
				return true;
			}
			return false;
		case IfcUnitEnum.MAGNETICFLUXDENSITYUNIT:
			if (HasIfcDimensionalExponents(Dim, 0, 1, -2, -1, 0, 0, 0))
			{
				return true;
			}
			return false;
		case IfcUnitEnum.POWERUNIT:
			if (HasIfcDimensionalExponents(Dim, 2, 1, -3, 0, 0, 0, 0))
			{
				return true;
			}
			return false;
		case IfcUnitEnum.PRESSUREUNIT:
			if (HasIfcDimensionalExponents(Dim, -1, 1, -2, 0, 0, 0, 0))
			{
				return true;
			}
			return false;
		default:
			return null;
		}
	}

	internal static bool IfcCorrectLocalPlacement(IfcAxis2Placement relativePlacement, IfcObjectPlacement placementRelTo)
	{
		bool? flag = NullableIfcCorrectLocalPlacement(relativePlacement, placementRelTo);
		if (!flag.HasValue)
		{
			throw new ArgumentException("Undetermined value in where clause.");
		}
		return flag.Value;
	}

	private static bool? NullableIfcCorrectLocalPlacement(IfcAxis2Placement AxisPlacement, IfcObjectPlacement RelPlacement)
	{
		if (EXISTS(RelPlacement))
		{
			if (INTYPEOF(RelPlacement, "IFC4.IFCGRIDPLACEMENT"))
			{
				return null;
			}
			if (INTYPEOF(RelPlacement, "IFC4.IFCLOCALPLACEMENT"))
			{
				if (INTYPEOF(AxisPlacement, "IFC4.IFCAXIS2PLACEMENT2D"))
				{
					return true;
				}
				if (INTYPEOF(AxisPlacement, "IFC4.IFCAXIS2PLACEMENT3D"))
				{
					if ((RelPlacement as IfcLocalPlacement).RelativePlacement.Dim == 3L)
					{
						return true;
					}
					return false;
				}
			}
			return null;
		}
		return true;
	}

	internal static bool IfcPathHeadToTail(IfcPath ifcPath)
	{
		bool? flag = NullableIfcPathHeadToTail(ifcPath);
		if (!flag.HasValue)
		{
			throw new ArgumentException("Undetermined value in where clause.");
		}
		return flag.Value;
	}

	private static bool? NullableIfcPathHeadToTail(IfcPath APath)
	{
		int num = 0;
		bool? result = null;
		num = SIZEOF(APath.EdgeList);
		for (int i = 2; i <= num; i++)
		{
			if (!result.HasValue)
			{
				result = true;
			}
			result = result.Value && APath.EdgeList[i - 2].EdgeEnd == APath.EdgeList[i - 1].EdgeStart;
		}
		return result;
	}

	internal static bool IfcLoopHeadToTail(IfcEdgeLoop ALoop)
	{
		bool flag = true;
		int num = SIZEOF(ALoop.EdgeList);
		for (int i = 2; i <= num; i++)
		{
			flag = flag && ALoop.EdgeList[i - 2].EdgeEnd == ALoop.EdgeList[i - 1].EdgeStart;
		}
		return flag;
	}

	internal static bool IfcCorrectFillAreaStyle(IItemSet<IfcFillStyleSelect> Styles)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		num4 = SIZEOF(Enumerable.Where(Styles, (IfcFillStyleSelect Style) => INTYPEOF(Style, "IFC4.IFCEXTERNALLYDEFINEDHATCHSTYLE")));
		num = SIZEOF(Enumerable.Where(Styles, (IfcFillStyleSelect Style) => INTYPEOF(Style, "IFC4.IFCFILLAREASTYLEHATCHING")));
		num2 = SIZEOF(Enumerable.Where(Styles, (IfcFillStyleSelect Style) => INTYPEOF(Style, "IFC4.IFCFILLAREASTYLETILES")));
		num3 = SIZEOF(Enumerable.Where(Styles, (IfcFillStyleSelect Style) => INTYPEOF(Style, "IFC4.IFCCOLOUR")));
		if (num4 > 1)
		{
			return false;
		}
		if (num4 == 1 && (num > 0 || num2 > 0 || num3 > 0))
		{
			return false;
		}
		if (num3 > 1)
		{
			return false;
		}
		if (num > 0 && num2 > 0)
		{
			return false;
		}
		return true;
	}

	internal static bool IfcSurfaceWeightsPositive(IfcRationalBSplineSurfaceWithKnots B)
	{
		bool result = true;
		for (int i = 1; i <= (long)((IIfcBSplineSurface)B).UUpper; i++)
		{
			for (int j = 1; j <= (long)((IIfcBSplineSurface)B).VUpper; j++)
			{
				if ((double)B.Weights[i - 1][j - 1] <= 0.0)
				{
					return false;
				}
			}
		}
		return result;
	}

	private static IVectorOrDirection IfcNormalise(IVectorOrDirection Arg)
	{
		Direction direction = new Direction(1.0, 0.0);
		Vector vector = new Vector(new Direction(1.0, 0.0), 1.0);
		IVectorOrDirection vectorOrDirection = direction;
		if (!EXISTS(Arg))
		{
			return null;
		}
		int dim;
		if (Arg is Vector)
		{
			dim = Arg.Dim;
			Vector vector2 = Arg as Vector;
			direction.DirectionRatios = vector2.Orientation.DirectionRatios;
			vector.Magnitude = vector2.Magnitude;
			vector.Orientation = direction;
			if (vector2.Magnitude == 0.0)
			{
				return null;
			}
			vector.Magnitude = 1.0;
		}
		else
		{
			Direction direction2 = Arg as Direction;
			dim = direction2.Dim;
			direction.DirectionRatios = direction2.DirectionRatios;
		}
		double num = 0.0;
		for (int i = 0; i < dim; i++)
		{
			num += direction.DirectionRatios[i] * direction.DirectionRatios[i];
		}
		if (num > 0.0)
		{
			num = SQRT(num);
			for (int j = 0; j < dim; j++)
			{
				direction.DirectionRatios[j] = direction.DirectionRatios[j] / num;
			}
			if (Arg is Vector)
			{
				vector.Orientation = direction;
				return vector;
			}
			return direction;
		}
		return null;
	}
}
