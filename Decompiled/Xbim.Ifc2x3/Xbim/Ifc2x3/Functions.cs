using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Geometry;
using Xbim.Ifc2x3.DateTimeResource;
using Xbim.Ifc2x3.GeometricConstraintResource;
using Xbim.Ifc2x3.GeometricModelResource;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc2x3.IfcFunctions;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.PresentationAppearanceResource;
using Xbim.Ifc2x3.PresentationDefinitionResource;
using Xbim.Ifc2x3.PresentationDimensioningResource;
using Xbim.Ifc2x3.PresentationOrganizationResource;
using Xbim.Ifc2x3.ProductExtension;
using Xbim.Ifc2x3.ProfileResource;
using Xbim.Ifc2x3.PropertyResource;
using Xbim.Ifc2x3.QuantityResource;
using Xbim.Ifc2x3.TopologyResource;

namespace Xbim.Ifc2x3;

public static class Functions
{
	internal static ValuesArray<T> NewArray<T>(params T[] args) where T : class
	{
		return new ValuesArray<T>(args);
	}

	internal static IfcEdgeLoop AsIfcEdgeLoop(this IfcLoop toCast)
	{
		return toCast as IfcEdgeLoop;
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

	internal static Direction IfcDirection(double x, double y, double z)
	{
		return new Direction(x, y, z);
	}

	internal static double IfcDotProduct(Direction dir1, IfcDirection dir2)
	{
		return dir1.X * dir2.X + dir1.Y * dir2.Y + dir1.Z * dir2.Z;
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

	internal static IfcAnnotationTextOccurrence AsIfcAnnotationTextOccurrence(this IfcDraughtingCalloutElement toCast)
	{
		return toCast as IfcAnnotationTextOccurrence;
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

	internal static IfcDimensionCurveTerminator AsIfcDimensionCurveTerminator(this IPersistEntity toCast)
	{
		return (IfcDimensionCurveTerminator)toCast;
	}

	internal static T NVL<T>(T obj1, T obj2) where T : class
	{
		return obj1 ?? obj2;
	}

	internal static IEnumerable<IPersistEntity> USEDIN(IPersistEntity ifcObject, string v)
	{
		return v switch
		{
			"IFC2X3.IFCRELASSOCIATES.RELATEDOBJECTS" => from x in ifcObject.Model.Instances.OfType<IfcRelAssociates>()
				where x.RelatedObjects.Contains(ifcObject)
				select x, 
			"IFC2X3.IFCTERMINATORSYMBOL.ANNOTATEDCURVE" => from x in ifcObject.Model.Instances.OfType<IfcTerminatorSymbol>()
				where x.AnnotatedCurve == ifcObject
				select x, 
			"IFC2X3.IFCDRAUGHTINGCALLOUT.CONTENTS" => from x in ifcObject.Model.Instances.OfType<IfcDraughtingCallout>()
				where x.Contents.Contains(ifcObject)
				select x, 
			_ => throw new Exception($"NotImplemented: USEDIN does not support role {v}."), 
		};
	}

	internal static bool EXISTS(object o)
	{
		return o != null;
	}

	internal static int SIZEOF<T>(IEnumerable<T> source)
	{
		return source.Count();
	}

	internal static int SIZEOF<T>(ValuesArray<T> array) where T : class
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

	internal static ValuesArray<string> TYPEOF(IPersist instance)
	{
		return new ValuesArray<string>(instance);
	}

	internal static int LOINDEX<T>(IEnumerable<T> source)
	{
		return 0;
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
		num = SIZEOF(from temp in Units.OfType<IfcNamedUnit>()
			where temp.UnitType != IfcUnitEnum.USERDEFINED
			select temp);
		num2 = SIZEOF(from temp in Units.OfType<IfcDerivedUnit>()
			where temp.UnitType != IfcDerivedUnitEnum.USERDEFINED
			select temp);
		num3 = SIZEOF(Units.OfType<IfcMonetaryUnit>());
		for (int num4 = 0; num4 < SIZEOF(Units); num4++)
		{
			if (Units[num4] is IfcNamedUnit && (Units[num4] as IfcNamedUnit).UnitType != IfcUnitEnum.USERDEFINED)
			{
				list.Add((Units[num4] as IfcNamedUnit).UnitType);
			}
			if (Units[num4] is IfcDerivedUnit && (Units[num4] as IfcDerivedUnit).UnitType != IfcDerivedUnitEnum.USERDEFINED)
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
			num = Items.Count((IfcRepresentationItem x) => x is IfcVertex);
			break;
		case "Edge":
			num = Items.Count((IfcRepresentationItem x) => x is IfcEdge);
			break;
		case "Path":
			num = Items.Count((IfcRepresentationItem x) => x is IfcPath);
			break;
		case "Face":
			num = Items.Count((IfcRepresentationItem x) => x is IfcFace);
			break;
		case "Shell":
			num = Items.Count((IfcRepresentationItem x) => x is IfcOpenShell || x is IfcClosedShell);
			break;
		case "Undefined":
			return true;
		}
		return num == Items.Count;
	}

	internal static bool IfcTaperedSweptAreaProfiles(IfcProfileDef StartArea, IfcProfileDef EndArea)
	{
		bool flag = false;
		if (StartArea is IfcParameterizedProfileDef)
		{
			if (EndArea is IfcDerivedProfileDef)
			{
				IfcDerivedProfileDef ifcDerivedProfileDef = EndArea as IfcDerivedProfileDef;
				return ifcDerivedProfileDef != null && StartArea == ifcDerivedProfileDef.ParentProfile;
			}
			return StartArea.GetType() == EndArea.GetType();
		}
		if (EndArea is IfcDerivedProfileDef)
		{
			IfcDerivedProfileDef ifcDerivedProfileDef2 = EndArea as IfcDerivedProfileDef;
			return ifcDerivedProfileDef2 != null && StartArea == ifcDerivedProfileDef2.ParentProfile;
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
			num = Items.Count((IfcRepresentationItem x) => x is IfcPoint);
			break;
		case "Curve":
			num = Items.Count((IfcRepresentationItem x) => x is IfcCurve);
			break;
		case "Curve2D":
			num = Items.Count((IfcRepresentationItem x) => x is IfcCurve && ((IfcCurve)x).Dim == 2L);
			break;
		case "Curve3D":
			num = Items.Count((IfcRepresentationItem x) => x is IfcCurve && ((IfcCurve)x).Dim == 3L);
			break;
		case "Surface":
			num = Items.Count((IfcRepresentationItem x) => x is IfcSurface);
			break;
		case "Surface2D":
			num = Items.Count((IfcRepresentationItem x) => x is IfcSurface && ((IfcSurface)x).Dim == 2L);
			break;
		case "Surface3D":
			num = Items.Count((IfcRepresentationItem x) => x is IfcSurface && ((IfcSurface)x).Dim == 3L);
			break;
		case "FillArea":
			num = Items.Count((IfcRepresentationItem x) => x is IfcAnnotationFillArea);
			break;
		case "Text":
			num = Items.Count((IfcRepresentationItem x) => x is IfcTextLiteral);
			break;
		case "Annotation2D":
			num = Items.Count((IfcRepresentationItem x) => x is IfcPoint || x is IfcCurve || x is IfcGeometricCurveSet || x is IfcAnnotationFillArea || x is IfcTextLiteral);
			break;
		case "GeometricSet":
			num = Items.Count((IfcRepresentationItem x) => x is IfcGeometricSet || x is IfcPoint || x is IfcCurve || x is IfcSurface);
			break;
		case "GeometricCurveSet":
			num = Items.Count((IfcRepresentationItem x) => x is IfcGeometricCurveSet || x is IfcGeometricSet || x is IfcPoint || x is IfcCurve);
			foreach (IfcRepresentationItem Item in Items)
			{
				if (Item is IfcGeometricSet && (Item as IfcGeometricSet).Elements.Count((IfcGeometricSetSelect temp) => temp is IfcSurface) > 0)
				{
					num--;
				}
			}
			break;
		case "SurfaceOrSolidModel":
			num = Items.Count((IfcRepresentationItem x) => x is IfcShellBasedSurfaceModel || x is IfcFaceBasedSurfaceModel || x is IfcSolidModel);
			break;
		case "SurfaceModel":
			num = Items.Count((IfcRepresentationItem x) => x is IfcShellBasedSurfaceModel || x is IfcFaceBasedSurfaceModel);
			break;
		case "SolidModel":
			num = Items.Count((IfcRepresentationItem x) => x is IfcSolidModel);
			break;
		case "SweptSolid":
			num = Items.Count((IfcRepresentationItem x) => x is IfcExtrudedAreaSolid || x is IfcRevolvedAreaSolid);
			break;
		case "AdvancedSweptSolid":
			num = Items.Count((IfcRepresentationItem x) => x is IfcSweptAreaSolid || x is IfcSweptDiskSolid);
			break;
		case "CSG":
			num = Items.Count((IfcRepresentationItem x) => x is IfcBooleanResult || x is IfcCsgPrimitive3D || x is IfcCsgSolid);
			break;
		case "Clipping":
			num = Items.Count((IfcRepresentationItem x) => x is IfcBooleanClippingResult);
			break;
		case "Brep":
			num = Items.Count((IfcRepresentationItem x) => x is IfcFacetedBrep);
			break;
		case "AdvancedBrep":
			num = Items.Count((IfcRepresentationItem x) => x is IfcManifoldSolidBrep);
			break;
		case "BoundingBox":
			num = Items.Count((IfcRepresentationItem x) => x is IfcBoundingBox);
			if (Items.Count > 1)
			{
				num = 0;
			}
			break;
		case "SectionedSpine":
			num = Items.Count((IfcRepresentationItem x) => x is IfcSectionedSpine);
			break;
		case "LightSource":
			num = Items.Count((IfcRepresentationItem x) => x is IfcLightSource);
			break;
		case "MappedRepresentation":
			num = Items.Count((IfcRepresentationItem x) => x is IfcMappedItem);
			break;
		}
		return num == Items.Count;
	}

	internal static bool IfcUniquePropertyName(IItemSet<IfcProperty> Properties)
	{
		return Properties.Select((IfcProperty x) => x.Name).ToList().Distinct()
			.Count() == Properties.Count();
	}

	internal static bool IfcUniqueQuantityNames(IItemSet<IfcPhysicalQuantity> Quantities)
	{
		return Quantities.Select((IfcPhysicalQuantity x) => x.Name).ToList().Distinct()
			.Count() == Quantities.Count();
	}

	internal static bool IfcCorrectObjectAssignment(IfcObjectTypeEnum? Constraint, IItemSet<IfcObjectDefinition> Objects)
	{
		if (!Constraint.HasValue)
		{
			return true;
		}
		bool? flag = IfcCorrectObjectAssignment(Constraint.Value, Objects.ToList());
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
			IfcObjectTypeEnum.PRODUCT => SIZEOF(Objects.Where((IfcObjectDefinition temp) => !INTYPEOF(temp, "IFC2X3.IFCPRODUCT"))) == 0, 
			IfcObjectTypeEnum.PROCESS => SIZEOF(Objects.Where((IfcObjectDefinition temp) => !INTYPEOF(temp, "IFC2X3.IFCPROCESS"))) == 0, 
			IfcObjectTypeEnum.CONTROL => SIZEOF(Objects.Where((IfcObjectDefinition temp) => !INTYPEOF(temp, "IFC2X3.IFCCONTROL"))) == 0, 
			IfcObjectTypeEnum.RESOURCE => SIZEOF(Objects.Where((IfcObjectDefinition temp) => !INTYPEOF(temp, "IFC2X3.IFCRESOURCE"))) == 0, 
			IfcObjectTypeEnum.ACTOR => SIZEOF(Objects.Where((IfcObjectDefinition temp) => !INTYPEOF(temp, "IFC2X3.IFCACTOR"))) == 0, 
			IfcObjectTypeEnum.GROUP => SIZEOF(Objects.Where((IfcObjectDefinition temp) => !INTYPEOF(temp, "IFC2X3.IFCGROUP"))) == 0, 
			IfcObjectTypeEnum.PROJECT => SIZEOF(Objects.Where((IfcObjectDefinition temp) => !INTYPEOF(temp, "IFC2X3.IFCPROJECT"))) == 0, 
			_ => null, 
		};
	}

	internal static bool IfcValidTime(IfcLocalTime Time)
	{
		if (Time.SecondComponent.HasValue)
		{
			return Time.MinuteComponent.HasValue;
		}
		return true;
	}

	internal static bool IfcCurveWeightsPositive(IfcRationalBezierCurve B)
	{
		for (int i = 0; i < B.UpperIndexOnControlPoints; i++)
		{
			if (B.Weights[i] < 0.0)
			{
				return false;
			}
		}
		return true;
	}

	internal static bool IfcValidCalendarDate(IfcCalendarDate date)
	{
		IfcDayInMonthNumber dayComponent = date.DayComponent;
		if ((long)dayComponent < 1)
		{
			return false;
		}
		int num = (int)(long)date.MonthComponent;
		if (num < 1 || num > 12)
		{
			return false;
		}
		int year = (int)(long)date.YearComponent;
		return (long)dayComponent <= DateTime.DaysInMonth(year, num);
	}

	internal static bool IfcConstraintsParamBSpline(IfcInteger Degree, IfcInteger UpKnots, IfcInteger UpCp, IItemSet<IfcInteger> KnotMult, IItemSet<IfcParameterValue> Knots)
	{
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
		return true;
	}

	private static bool HasIfcDimensionalExponents(IfcDimensionalExponents dim, int len, int mass, int time, int elec, int temp, int substance, int lum)
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
		if (!flag.HasValue)
		{
			throw new ArgumentException("Undetermined value in where clause.");
		}
		return flag.Value;
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
			if (RelPlacement is IfcGridPlacement)
			{
				return null;
			}
			if (RelPlacement is IfcLocalPlacement)
			{
				if (AxisPlacement is IfcAxis2Placement2D)
				{
					return true;
				}
				if (AxisPlacement is IfcAxis2Placement3D)
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
		num4 = SIZEOF(Enumerable.Where(Styles, (IfcFillStyleSelect Style) => INTYPEOF(Style, "IFC2X3.IFCEXTERNALLYDEFINEDHATCHSTYLE")));
		num = SIZEOF(Enumerable.Where(Styles, (IfcFillStyleSelect Style) => INTYPEOF(Style, "IFC2X3.IFCFILLAREASTYLEHATCHING")));
		num2 = SIZEOF(Enumerable.Where(Styles, (IfcFillStyleSelect Style) => INTYPEOF(Style, "IFC2X3.IFCFILLAREASTYLETILES")));
		num3 = SIZEOF(Enumerable.Where(Styles, (IfcFillStyleSelect Style) => INTYPEOF(Style, "IFC2X3.IFCCOLOUR")));
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
