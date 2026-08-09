using System;
using System.Collections.Generic;
using Xbim.IO.Step21;
using devDept.Diagnostic;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Translators;

public static class IfcBuilder
{
	public static Brep Extrude(Region profile, Vector3D amount, ifcElementType type, double tolerance = 0.0)
	{
		Telemetry.Instance.AddUsage(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998225), Telemetry.moduleType.Generic);
		Brep brep = profile.ExtrudeAsBrep(amount, 0.0, tolerance);
		brep.IfcProperties = new IfcProperties
		{
			GUID = Guid.NewGuid().ToPart21(),
			ElementType = type,
			ProfileDef = profile,
			ExtrusionAmount = amount
		};
		return brep;
	}

	public static bool Difference(Brep buildingElement, Brep openingElement)
	{
		if (buildingElement.IfcProperties == null)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998212));
		}
		Brep[] array = Brep.Difference(buildingElement, openingElement);
		if (array != null && array.Length != 0)
		{
			buildingElement._0023_003Dzd55uIPSKitfg(array[0].Vertices, array[0].Edges, array[0].Faces, array[0].Inners);
			buildingElement.RegenMode = regenType.RegenAndCompile;
			IfcProperties ifcProperties = buildingElement.IfcProperties;
			if (ifcProperties.Openings == null)
			{
				ifcProperties.Openings = new List<Entity>();
			}
			buildingElement.IfcProperties.Openings.Add(openingElement);
			return true;
		}
		return false;
	}

	public static bool ExtrudeRemove(Brep buildingElement, Region openingProfile, double amount)
	{
		Brep openingElement = Extrude(openingProfile, openingProfile.Plane.AxisZ * amount, ifcElementType.IfcOpeningElement, buildingElement.RebuildTolerance);
		return Difference(buildingElement, openingElement);
	}

	public static bool ExtrudeRemoveThrough(Brep buildingElement, Region openingProfile)
	{
		buildingElement._0023_003Dzz0cR7hJgEH1Gz0obmw_003D_003D(openingProfile.Plane, out var _0023_003Dzkvk88KaXCcAi, out var _0023_003Dzj_0024c4yo8Y8jLt);
		double num = Utility._0023_003DzBdlHahH_sn5_0cVpzJ_0024pzhGGFVyq5_aiECmXAR_0024dnNChzXciog_003D_003D * (_0023_003Dzj_0024c4yo8Y8jLt - _0023_003Dzkvk88KaXCcAi);
		Interval interval = new Interval(_0023_003Dzkvk88KaXCcAi - num, _0023_003Dzj_0024c4yo8Y8jLt + num);
		if (interval.Low < 0.0)
		{
			openingProfile = (Region)openingProfile.Clone();
			openingProfile.Translate(openingProfile.Plane.AxisZ * interval.Low);
		}
		return ExtrudeRemove(buildingElement, openingProfile, interval.Length);
	}

	public static bool CutBy(Brep buildingElement, Plane plane)
	{
		Point3D _0023_003DzDPcjoBJLcqli;
		Point3D _0023_003Dz_0024N_0024yKptW9BoC;
		if (buildingElement.BoxMin == null || buildingElement.RegenMode == regenType.RegenAndCompile)
		{
			buildingElement.Rebuild(0.0, soft: true);
			buildingElement._0023_003DzQCWJbpjMGLxZWfwMCQ_003D_003D(out _0023_003DzDPcjoBJLcqli, out _0023_003Dz_0024N_0024yKptW9BoC, _0023_003Dz7cP1pZCb1hQy: true);
		}
		else
		{
			_0023_003DzDPcjoBJLcqli = buildingElement.BoxMin;
			_0023_003Dz_0024N_0024yKptW9BoC = buildingElement.BoxMax;
		}
		Surface surface = Surface._0023_003DziDGe5xzc5KLyQpPYDk5PyHY_003D(plane, _0023_003DzDPcjoBJLcqli, _0023_003Dz_0024N_0024yKptW9BoC);
		buildingElement._0023_003Dzz0cR7hJgEH1Gz0obmw_003D_003D(plane, out var _, out var _0023_003Dzj_0024c4yo8Y8jLt);
		return ExtrudeRemove(buildingElement, surface.ConvertToRegion(), _0023_003Dzj_0024c4yo8Y8jLt + Utility._0023_003DzBdlHahH_sn5_0cVpzJ_0024pzhGGFVyq5_aiECmXAR_0024dnNChzXciog_003D_003D);
	}

	public static void TransformBy(Entity buildingElement, Transformation xform)
	{
		buildingElement.TransformBy(xform);
		if (buildingElement.IfcProperties == null)
		{
			return;
		}
		buildingElement.IfcProperties.ProfileDef?.TransformBy(xform);
		buildingElement.IfcProperties.ExtrusionAmount?.TransformBy(xform);
		if (buildingElement.IfcProperties.Openings == null)
		{
			return;
		}
		foreach (Entity opening in buildingElement.IfcProperties.Openings)
		{
			TransformBy(opening, xform);
		}
	}
}
