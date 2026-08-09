using System;
using System.Collections.Generic;
using System.Drawing;
using buClass;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5.Apps;

public class buDiamakerCalc
{
	public static DiemakerGrindingShapeSettings varGrindingShape = new DiemakerGrindingShapeSettings();

	public void doGrindingVShape(DiemakerGrindingShapeSettings Pars, ToolBase5 ToolGrinding, ToolBase5 ToolNick, bool isCircular, ref List<Entity> calcEntities, ref camTp Cam)
	{
		Cam = new camTp();
		double num = 0.0;
		double num2 = 0.0;
		new Point3D();
		new Point3D();
		Point3D point3D = new Point3D();
		Point3D point3D2 = new Point3D();
		Point3D point3D3 = new Point3D();
		Point3D point3D4 = new Point3D();
		Point3D EndPnt = new Point3D();
		Point3D EndPnt2 = new Point3D();
		Point3D point3D5 = new Point3D();
		Entity rectangleEntity = null;
		buCall.buVector5_0.DrawRectangle(new Point3D(), Pars.MaterialThickness, Pars.BaseMaterialHeight, Plane.XY, ref rectangleEntity);
		rectangleEntity.Translate((0.0 - Pars.MaterialThickness) / 2.0, 0.0);
		calcEntities.Add(rectangleEntity);
		double num3 = Pars.MaterialThickness / 2.0 / Math.Tan(buConversion5.DegreeToRadian(Pars.VShapeTargetAngle / 2.0));
		List<Point3D> Vertices = new List<Point3D>();
		Vertices.Add(new Point3D((0.0 - Pars.MaterialThickness) / 2.0, 0.0));
		Vertices.Add(new Point3D((0.0 - Pars.MaterialThickness) / 2.0, Pars.TargetMaterialHeight - num3));
		Vertices.Add(new Point3D(Pars.MaterialThickness / 2.0 - Pars.MaterialThickness / 2.0, Pars.TargetMaterialHeight));
		Vertices.Add(new Point3D(Pars.MaterialThickness - Pars.MaterialThickness / 2.0, Pars.TargetMaterialHeight - num3));
		Vertices.Add(new Point3D(Pars.MaterialThickness - Pars.MaterialThickness / 2.0, 0.0));
		Vertices.Add(new Point3D((0.0 - Pars.MaterialThickness) / 2.0, 0.0));
		buCall.buVector5_0.MiddlePointOfLine(Vertices[1], Vertices[2]);
		buCall.buVector5_0.MiddlePointOfLine(Vertices[2], Vertices[3]);
		if (isCircular)
		{
			Vertices = new List<Point3D>();
			buCall.buVector5_0.Arc3Point(new Point3D((0.0 - Pars.MaterialThickness) / 2.0, Pars.TargetMaterialHeight - Pars.MaterialThickness / 3.0), new Point3D(0.0, Pars.TargetMaterialHeight), new Point3D(Pars.MaterialThickness / 2.0, Pars.TargetMaterialHeight - Pars.MaterialThickness / 3.0), Plane.XY, new EntityResolution(0.002, 50, 20.0, EntityResolutionType.ByLength), ref Vertices);
			buVector5.ToPoint3D(Vertices[0]);
			buVector5.ToPoint3D(Vertices[Vertices.Count - 1]);
		}
		double num4 = 5.0;
		LinearPath linearPath = new LinearPath(Vertices);
		linearPath.ColorMethod = colorMethodType.byEntity;
		linearPath.Color = Color.Lime;
		calcEntities.Add(linearPath);
		Cam.Tool = new ToolBase5(ToolGrinding);
		Cam.Tool.Geometry.GeometryType = ToolType.Flat;
		Cam.Tool.Geometry.Length = ToolGrinding.Geometry.Thickness;
		Cam.Tool.Geometry.Thickness = 2.0;
		double num5 = 5.0;
		double num6 = 1.0;
		camTpPoint camTpPoint2 = new camTpPoint();
		Pnt6D pnt6D = new Pnt6D();
		TpPnt9D tpPnt9D = new TpPnt9D();
		double num7 = Pars.BaseMaterialHeight - Pars.TargetMaterialHeight - Pars.VShapeHeightFinishDepth;
		int num8 = Convert.ToInt32(buNumeric5.RoundToUpper(num7 / Pars.VShapeHeightRoughDepth));
		double num9 = Math.Round(num7 / (double)num8, 3);
		double x = 0.0;
		double num10 = ToolGrinding.Geometry.Thickness * Pars.ToolPersentage / 100.0;
		int num11 = (int)buNumeric5.RoundToUpper(Pars.GrindingLength / num10);
		double num12 = 0.0;
		if (Pars.NickEnable)
		{
			camTpPoint camTpPoint3 = new camTpPoint();
			camTpPoint3.PreCodes.Add("G75");
			string text = " K1";
			if (Pars.NickReverseDir)
			{
				text = " K-1";
			}
			if (Pars.NickToolNo == 1)
			{
				camTpPoint3.PreCodes.Add("M21" + text);
			}
			if (Pars.NickToolNo == 2)
			{
				camTpPoint3.PreCodes.Add("M22" + text);
			}
			if (Pars.NickToolNo == 3)
			{
				camTpPoint3.PreCodes.Add("M23" + text);
			}
			camTpPoint3.PreCodes.Add("M154");
			camTpPoint3.PreCodes.Add("G75");
			camTpPoint3.PreCodes.Add("G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
			camTpPoint3.PreCodes.Add("G75");
			pnt6D = new Pnt6D(0.0, Pars.BaseMaterialHeight + num4 + ToolNick.Geometry.Diameter / 2.0, 0.0);
			camTpPoint3.Points.Add(new TpPnt9D(pnt6D, Pars.NickRoughVel, 0, plungemove: false));
			camTpPoint3.Points[camTpPoint3.Points.Count - 1].EnableAxes.Y = false;
			pnt6D = new Pnt6D(0.0, Pars.BaseMaterialHeight + num4 + ToolNick.Geometry.Diameter / 2.0, 0.0);
			camTpPoint3.Points.Add(new TpPnt9D(pnt6D, Pars.NickRoughVel, 0, plungemove: false));
			pnt6D = new Pnt6D(0.0, Pars.NickDepth + Pars.NickFinishDepth + ToolNick.Geometry.Diameter / 2.0, 0.0);
			camTpPoint3.Points.Add(new TpPnt9D(pnt6D, Pars.NickRoughVel, 1, plungemove: false));
			pnt6D = new Pnt6D((0.0 - Pars.NickWidth) / 2.0, Pars.NickDepth + Pars.NickFinishDepth + 0.0 + ToolNick.Geometry.Diameter / 2.0, 0.0);
			camTpPoint3.Points.Add(new TpPnt9D(pnt6D, Pars.NickRoughVel, 0, plungemove: false));
			pnt6D = new Pnt6D((0.0 - Pars.NickWidth) / 2.0, Pars.NickDepth + ToolNick.Geometry.Diameter / 2.0, 0.0);
			camTpPoint3.Points.Add(new TpPnt9D(pnt6D, Pars.NickRoughVel, 0, plungemove: false));
			pnt6D = new Pnt6D(Pars.NickWidth / 2.0, Pars.NickDepth + ToolNick.Geometry.Diameter / 2.0, 0.0);
			camTpPoint3.Points.Add(new TpPnt9D(pnt6D, Pars.NickFinishVel, 1, plungemove: false));
			pnt6D = new Pnt6D(Pars.NickWidth / 2.0, Pars.BaseMaterialHeight + num4 + ToolNick.Geometry.Diameter / 2.0, 0.0);
			camTpPoint3.Points.Add(new TpPnt9D(pnt6D, Pars.NickRoughVel, 0, plungemove: false));
			x = pnt6D.X;
			camTpPoint3.AfterCodes.Add("M32");
			camTpPoint3.AfterCodes.Add("M40 K" + (Pars.GrindingLength + ToolNick.Geometry.Thickness / 1.0).ToString("f2"));
			num12 += ToolGrinding.Geometry.Thickness / 2.0;
			camTpPoint3.AfterCodes.Add("M31");
			Cam.CamPoints.Add(camTpPoint3);
		}
		if (Pars.NickEnable)
		{
			camTpPoint camTpPoint4 = new camTpPoint();
			camTpPoint4.PreCodes.Add("G75");
			string text2 = " K1";
			if (Pars.NickReverseDir)
			{
				text2 = " K-1";
			}
			if (Pars.NickToolNo == 1)
			{
				camTpPoint4.PreCodes.Add("M21" + text2);
			}
			if (Pars.NickToolNo == 2)
			{
				camTpPoint4.PreCodes.Add("M22" + text2);
			}
			if (Pars.NickToolNo == 3)
			{
				camTpPoint4.PreCodes.Add("M23" + text2);
			}
			camTpPoint4.PreCodes.Add("M154");
			camTpPoint4.PreCodes.Add("G75");
			camTpPoint4.PreCodes.Add("G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
			camTpPoint4.PreCodes.Add("G75");
			pnt6D = new Pnt6D(0.0, Pars.BaseMaterialHeight + num4 + ToolNick.Geometry.Diameter / 2.0, 0.0);
			camTpPoint4.Points.Add(new TpPnt9D(pnt6D, Pars.NickRoughVel, 0, plungemove: false));
			camTpPoint4.Points[camTpPoint4.Points.Count - 1].EnableAxes.Y = false;
			pnt6D = new Pnt6D(0.0, Pars.BaseMaterialHeight + num4 + ToolNick.Geometry.Diameter / 2.0, 0.0);
			camTpPoint4.Points.Add(new TpPnt9D(pnt6D, Pars.NickRoughVel, 0, plungemove: false));
			pnt6D = new Pnt6D(0.0, Pars.NickDepth + Pars.NickFinishDepth + ToolNick.Geometry.Diameter / 2.0, 0.0);
			camTpPoint4.Points.Add(new TpPnt9D(pnt6D, Pars.NickRoughVel, 1, plungemove: false));
			pnt6D = new Pnt6D((0.0 - Pars.NickWidth) / 2.0, Pars.NickDepth + Pars.NickFinishDepth + 0.0 + ToolNick.Geometry.Diameter / 2.0, 0.0);
			camTpPoint4.Points.Add(new TpPnt9D(pnt6D, Pars.NickRoughVel, 0, plungemove: false));
			pnt6D = new Pnt6D((0.0 - Pars.NickWidth) / 2.0, Pars.NickDepth + ToolNick.Geometry.Diameter / 2.0, 0.0);
			camTpPoint4.Points.Add(new TpPnt9D(pnt6D, Pars.NickRoughVel, 0, plungemove: false));
			pnt6D = new Pnt6D(Pars.NickWidth / 2.0, Pars.NickDepth + ToolNick.Geometry.Diameter / 2.0, 0.0);
			camTpPoint4.Points.Add(new TpPnt9D(pnt6D, Pars.NickFinishVel, 1, plungemove: false));
			pnt6D = new Pnt6D(Pars.NickWidth / 2.0, Pars.BaseMaterialHeight + num4 + ToolNick.Geometry.Diameter / 2.0, 0.0);
			camTpPoint4.Points.Add(new TpPnt9D(pnt6D, Pars.NickRoughVel, 0, plungemove: false));
			camTpPoint4.AfterCodes.Add("M32");
			camTpPoint4.AfterCodes.Add("M40 K" + (ToolGrinding.Geometry.Thickness / 2.0 - (Pars.GrindingLength + ToolNick.Geometry.Thickness / 1.0)).ToString("f2"));
			camTpPoint4.AfterCodes.Add("M31");
			Cam.CamPoints.Add(camTpPoint4);
		}
		camTpPoint2.PreCodes.Add("G75");
		if (Pars.VShapeHeightToolNo == 1)
		{
			camTpPoint2.PreCodes.Add("M21 K1");
		}
		if (Pars.VShapeHeightToolNo == 2)
		{
			camTpPoint2.PreCodes.Add("M22 K1");
		}
		if (Pars.VShapeHeightToolNo == 3)
		{
			camTpPoint2.PreCodes.Add("M23 K1");
		}
		camTpPoint2.PreCodes.Add("M154");
		camTpPoint2.PreCodes.Add("G75");
		camTpPoint2.PreCodes.Add("G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
		camTpPoint2.PreCodes.Add("G75");
		double num13 = 0.0;
		double num14 = 0.0;
		double num15 = 0.0;
		if (!isCircular)
		{
			for (int i = 1; i <= num11; i++)
			{
				pnt6D = new Pnt6D(x, Pars.BaseMaterialHeight + num4 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
				tpPnt9D = new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 0, plungemove: false);
				tpPnt9D.EnableAxes.X = false;
				camTpPoint2.Points.Add(tpPnt9D);
				tpPnt9D = new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 0, plungemove: false);
				camTpPoint2.Points.Add(tpPnt9D);
				if (Pars.VShapeHeightZigzag)
				{
					pnt6D = new Pnt6D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.BaseMaterialHeight + 1.0 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 0, plungemove: false));
					camTpPoint2.Points[camTpPoint2.Points.Count - 1].EnableAxes.Y = false;
					pnt6D = new Pnt6D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.BaseMaterialHeight + 1.0 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 0, plungemove: false));
				}
				for (int j = 1; j <= num8; j++)
				{
					if (Pars.VShapeHeightZigzag)
					{
						if (j % 2 != 1)
						{
							pnt6D = new Pnt6D(Pars.VShapeHeightWidth / 2.0, Pars.BaseMaterialHeight - (double)j * num9 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 1, plungemove: false));
							pnt6D = new Pnt6D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.BaseMaterialHeight - (double)j * num9 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 1, plungemove: false));
						}
						else
						{
							pnt6D = new Pnt6D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.BaseMaterialHeight - (double)j * num9 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 1, plungemove: false));
							pnt6D = new Pnt6D(Pars.VShapeHeightWidth / 2.0, Pars.BaseMaterialHeight - (double)j * num9 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 1, plungemove: false));
						}
					}
					else
					{
						pnt6D = new Pnt6D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.BaseMaterialHeight + 1.0 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 0, plungemove: false));
						pnt6D = new Pnt6D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.BaseMaterialHeight - (double)j * num9 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 1, plungemove: false));
						pnt6D = new Pnt6D(Pars.VShapeHeightWidth / 2.0, Pars.BaseMaterialHeight - (double)j * num9 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 1, plungemove: false));
						pnt6D = new Pnt6D(Pars.VShapeHeightWidth / 2.0, Pars.BaseMaterialHeight + 1.0 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 1, plungemove: false));
					}
					Line line = new Line(new Point3D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.BaseMaterialHeight - (double)j * num9), new Point3D(Pars.VShapeHeightWidth / 2.0, Pars.BaseMaterialHeight - (double)j * num9));
					line.ColorMethod = colorMethodType.byEntity;
					line.Color = Color.Cyan;
					calcEntities.Add(line);
				}
				if (Pars.VShapeHeightFinishDepth != 0.0)
				{
					if (Pars.VShapeHeightZigzag)
					{
						if (!(camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.X > 0.0))
						{
							pnt6D = new Pnt6D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.TargetMaterialHeight + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 1, plungemove: false));
							pnt6D = new Pnt6D(Pars.VShapeHeightWidth / 2.0, Pars.TargetMaterialHeight + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 1, plungemove: false));
						}
						else
						{
							pnt6D = new Pnt6D(Pars.VShapeHeightWidth / 2.0, Pars.TargetMaterialHeight + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 1, plungemove: false));
							pnt6D = new Pnt6D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.TargetMaterialHeight + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 1, plungemove: false));
						}
					}
					else
					{
						pnt6D = new Pnt6D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.BaseMaterialHeight + 1.0 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 1, plungemove: false));
						pnt6D = new Pnt6D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.TargetMaterialHeight + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 1, plungemove: false));
						pnt6D = new Pnt6D(Pars.VShapeHeightWidth / 2.0, Pars.TargetMaterialHeight + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 1, plungemove: false));
						pnt6D = new Pnt6D(Pars.VShapeHeightWidth / 2.0, Pars.BaseMaterialHeight + 1.0 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 1, plungemove: false));
					}
					Line line2 = new Line(new Point3D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.TargetMaterialHeight), new Point3D(Pars.VShapeHeightWidth / 2.0, Pars.TargetMaterialHeight));
					line2.ColorMethod = colorMethodType.byEntity;
					line2.Color = Color.Blue;
					calcEntities.Add(line2);
				}
				if (Pars.VShapeHeightZigzag)
				{
					pnt6D = new Pnt6D(camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.X, Pars.BaseMaterialHeight + 1.0 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 1, plungemove: false));
				}
				pnt6D = new Pnt6D(camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.X, Pars.BaseMaterialHeight + num5 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
				camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 0, plungemove: false));
				if (i == num11)
				{
					pnt6D = new Pnt6D(0.0 - Math.Abs(camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.X) - ToolGrinding.Geometry.Diameter / 2.0, Pars.BaseMaterialHeight + num5 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 0, plungemove: false));
				}
				if (Pars.NickEnable)
				{
					if (i < num11)
					{
						if (i != num11 - 1)
						{
							camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M32");
							camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M40 K" + num10.ToString("f2"));
							camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M31");
							num12 += num10;
							num13 += num10;
						}
						else
						{
							camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M32");
							camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M40 K" + (Pars.GrindingLength - num10 * ((double)num11 - 1.0)).ToString("f2"));
							camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M31");
							num12 += Pars.GrindingLength - num10 * ((double)num11 - 1.0);
							num13 += Pars.GrindingLength - num10 * ((double)num11 - 1.0);
						}
					}
				}
				else if (i < num11)
				{
					if (i != num11 - 1)
					{
						camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M32");
						camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M40 K" + num10.ToString("f2"));
						camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M31");
						num12 += num10;
					}
					else
					{
						camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M32");
						camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M40 K" + (Pars.GrindingLength - (ToolGrinding.Geometry.Thickness + num12)).ToString("f2"));
						camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M31");
						num12 += Pars.GrindingLength - (ToolGrinding.Geometry.Thickness + num12);
					}
				}
			}
			if (num13 != 0.0)
			{
				camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M32");
				camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M40 K" + (0.0 - num13).ToString("f2"));
				camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M31");
			}
			num13 = 0.0;
			for (int k = 1; k <= num11; k++)
			{
				if (k == 1)
				{
					pnt6D = new Pnt6D(camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.X, Pars.BaseMaterialHeight + num4 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
					tpPnt9D = new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 0, plungemove: false);
					tpPnt9D.EnableAxes.X = false;
					camTpPoint2.Points.Add(tpPnt9D);
					tpPnt9D = new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 0, plungemove: false);
					camTpPoint2.Points.Add(tpPnt9D);
					pnt6D = new Pnt6D(0.0 - Math.Abs(camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.X) - ToolGrinding.Geometry.Diameter / 2.0, Pars.BaseMaterialHeight + num5 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 0, plungemove: false));
				}
				if (!Pars.VShapeAngleEnable)
				{
					continue;
				}
				double num16 = Pars.MaterialThickness / 2.0 - Pars.VShapeAngleFinishDepth;
				int num17 = Convert.ToInt32(buNumeric5.RoundToUpper(num16 / Pars.VShapeAngleRoughDepth));
				double num18 = Math.Round(num16 / (double)num17, 3);
				num6 = 1.0;
				Point3D point3D6 = new Point3D();
				int num19 = 0;
				for (int num20 = num17; num20 >= 1; num20--)
				{
					EndPnt = new Point3D();
					EndPnt2 = new Point3D();
					if (Pars.VShapeAngleUpDownMode != UpDownDirectionType.DownToUp)
					{
						point3D = buVector5.ToPoint3D(Vertices[2]);
						point3D2 = buVector5.ToPoint3D(Vertices[1]);
						num = buCall.buVector5_0.PointAngle(Vertices[1], Vertices[2]);
						buCall.buVector5_0.LineWithLengthAndAngle(point3D, (double)num20 * num18, num - 90.0, ref EndPnt);
						buCall.buVector5_0.LineWithLengthAndAngle(point3D2, (double)num20 * num18, num - 90.0, ref EndPnt2);
						point3D5 = buCall.buVector5_0.MiddlePointOfLine(EndPnt, EndPnt2);
						buCall.buVector5_0.LineWithLengthAndAngle(point3D5, Pars.VShapeAngleWidth / 2.0, num - 180.0, ref EndPnt);
						buCall.buVector5_0.LineWithLengthAndAngle(point3D5, Pars.VShapeAngleWidth / 2.0, num, ref EndPnt2);
						point3D6 = new Point3D();
						buCall.buVector5_0.LineWithLengthAndAngle(EndPnt, Cam.Tool.Geometry.Diameter / 2.0 + num6, num - 90.0, ref point3D6);
						pnt6D = new Pnt6D(point3D6.X, point3D6.Y, 0.0);
						num14 = point3D6.X;
						num15 = point3D6.Y;
						if (num19 != 0)
						{
							tpPnt9D = new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false);
							camTpPoint2.Points.Add(tpPnt9D);
						}
						else
						{
							tpPnt9D = new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false);
							if (Pars.VShapeHeightToolNo == 1)
							{
								tpPnt9D.PreCodes.Add("M21 K1");
							}
							if (Pars.VShapeHeightToolNo == 2)
							{
								tpPnt9D.PreCodes.Add("M22 K1");
							}
							if (Pars.VShapeHeightToolNo == 3)
							{
								tpPnt9D.PreCodes.Add("M23 K1");
							}
							camTpPoint2.Points.Add(tpPnt9D);
						}
						point3D6 = new Point3D();
						buCall.buVector5_0.LineWithLengthAndAngle(EndPnt, Cam.Tool.Geometry.Diameter / 2.0, num - 90.0, ref point3D6);
						pnt6D = new Pnt6D(point3D6.X, point3D6.Y, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false));
						point3D6 = new Point3D();
						buCall.buVector5_0.LineWithLengthAndAngle(EndPnt2, Cam.Tool.Geometry.Diameter / 2.0, num - 90.0, ref point3D6);
						pnt6D = new Pnt6D(point3D6.X, point3D6.Y, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false));
						point3D6 = new Point3D();
						buCall.buVector5_0.LineWithLengthAndAngle(EndPnt2, Cam.Tool.Geometry.Diameter / 2.0 + num6, num - 90.0, ref point3D6);
						pnt6D = new Pnt6D(point3D6.X, point3D6.Y, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false));
						num19++;
					}
					else
					{
						point3D = buVector5.ToPoint3D(Vertices[1]);
						point3D2 = buVector5.ToPoint3D(Vertices[2]);
						num = buCall.buVector5_0.PointAngle(Vertices[2], Vertices[1]);
						buCall.buVector5_0.LineWithLengthAndAngle(point3D, (double)num20 * num18, num + 90.0, ref EndPnt);
						buCall.buVector5_0.LineWithLengthAndAngle(point3D2, (double)num20 * num18, num + 90.0, ref EndPnt2);
						point3D5 = buCall.buVector5_0.MiddlePointOfLine(EndPnt, EndPnt2);
						buCall.buVector5_0.LineWithLengthAndAngle(point3D5, Pars.VShapeAngleWidth / 2.0, num - 180.0, ref EndPnt);
						buCall.buVector5_0.LineWithLengthAndAngle(point3D5, Pars.VShapeAngleWidth / 2.0, num, ref EndPnt2);
						point3D6 = new Point3D();
						buCall.buVector5_0.LineWithLengthAndAngle(EndPnt, Cam.Tool.Geometry.Diameter / 2.0 + num6, num + 90.0, ref point3D6);
						pnt6D = new Pnt6D(point3D6.X, point3D6.Y, 0.0);
						num14 = point3D6.X;
						num15 = point3D6.Y;
						if (num19 != 0)
						{
							tpPnt9D = new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false);
							camTpPoint2.Points.Add(tpPnt9D);
						}
						else
						{
							tpPnt9D = new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false);
							if (Pars.VShapeHeightToolNo == 1)
							{
								tpPnt9D.PreCodes.Add("M21 K1");
							}
							if (Pars.VShapeHeightToolNo == 2)
							{
								tpPnt9D.PreCodes.Add("M22 K1");
							}
							if (Pars.VShapeHeightToolNo == 3)
							{
								tpPnt9D.PreCodes.Add("M23 K1");
							}
							camTpPoint2.Points.Add(tpPnt9D);
						}
						point3D6 = new Point3D();
						buCall.buVector5_0.LineWithLengthAndAngle(EndPnt, Cam.Tool.Geometry.Diameter / 2.0, num + 90.0, ref point3D6);
						pnt6D = new Pnt6D(point3D6.X, point3D6.Y, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false));
						point3D6 = new Point3D();
						buCall.buVector5_0.LineWithLengthAndAngle(EndPnt2, Cam.Tool.Geometry.Diameter / 2.0, num + 90.0, ref point3D6);
						pnt6D = new Pnt6D(point3D6.X, point3D6.Y, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false));
						point3D6 = new Point3D();
						buCall.buVector5_0.LineWithLengthAndAngle(EndPnt2, Cam.Tool.Geometry.Diameter / 2.0 + num6, num + 90.0, ref point3D6);
						pnt6D = new Pnt6D(point3D6.X, point3D6.Y, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false));
						num19++;
					}
					Line line3 = new Line(EndPnt, EndPnt2);
					line3.ColorMethod = colorMethodType.byEntity;
					line3.Color = Color.Red;
					calcEntities.Add(line3);
				}
				for (int l = 1; l <= Pars.VShapeAngleFinishCount; l++)
				{
					if (Pars.VShapeAngleUpDownMode != UpDownDirectionType.DownToUp)
					{
						EndPnt = new Point3D();
						EndPnt2 = new Point3D();
						point3D5 = buCall.buVector5_0.MiddlePointOfLine(point3D, point3D2);
						buCall.buVector5_0.LineWithLengthAndAngle(point3D5, Pars.VShapeAngleWidth / 2.0, num - 180.0, ref EndPnt);
						buCall.buVector5_0.LineWithLengthAndAngle(point3D5, Pars.VShapeAngleWidth / 2.0, num, ref EndPnt2);
						point3D6 = new Point3D();
						buCall.buVector5_0.LineWithLengthAndAngle(EndPnt, Cam.Tool.Geometry.Diameter / 2.0 + num6, num - 90.0, ref point3D6);
						pnt6D = new Pnt6D(point3D6.X, point3D6.Y, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleFinishVel, 1, plungemove: false));
						point3D6 = new Point3D();
						buCall.buVector5_0.LineWithLengthAndAngle(EndPnt, Cam.Tool.Geometry.Diameter / 2.0, num - 90.0, ref point3D6);
						pnt6D = new Pnt6D(point3D6.X, point3D6.Y, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleFinishVel, 1, plungemove: false));
						point3D6 = new Point3D();
						buCall.buVector5_0.LineWithLengthAndAngle(EndPnt2, Cam.Tool.Geometry.Diameter / 2.0, num - 90.0, ref point3D6);
						pnt6D = new Pnt6D(point3D6.X, point3D6.Y, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleFinishVel, 1, plungemove: false));
						point3D6 = new Point3D();
						buCall.buVector5_0.LineWithLengthAndAngle(EndPnt2, Cam.Tool.Geometry.Diameter / 2.0 + num6, num - 90.0, ref point3D6);
						pnt6D = new Pnt6D(point3D6.X, point3D6.Y, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleFinishVel, 1, plungemove: false));
					}
					else
					{
						EndPnt = new Point3D();
						EndPnt2 = new Point3D();
						point3D5 = buCall.buVector5_0.MiddlePointOfLine(point3D, point3D2);
						buCall.buVector5_0.LineWithLengthAndAngle(point3D5, Pars.VShapeAngleWidth / 2.0, num - 180.0, ref EndPnt);
						buCall.buVector5_0.LineWithLengthAndAngle(point3D5, Pars.VShapeAngleWidth / 2.0, num, ref EndPnt2);
						point3D6 = new Point3D();
						buCall.buVector5_0.LineWithLengthAndAngle(EndPnt, Cam.Tool.Geometry.Diameter / 2.0 + num6, num + 90.0, ref point3D6);
						pnt6D = new Pnt6D(point3D6.X, point3D6.Y, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleFinishVel, 1, plungemove: false));
						point3D6 = new Point3D();
						buCall.buVector5_0.LineWithLengthAndAngle(EndPnt, Cam.Tool.Geometry.Diameter / 2.0, num + 90.0, ref point3D6);
						pnt6D = new Pnt6D(point3D6.X, point3D6.Y, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleFinishVel, 1, plungemove: false));
						point3D6 = new Point3D();
						buCall.buVector5_0.LineWithLengthAndAngle(EndPnt2, Cam.Tool.Geometry.Diameter / 2.0, num + 90.0, ref point3D6);
						pnt6D = new Pnt6D(point3D6.X, point3D6.Y, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleFinishVel, 1, plungemove: false));
						point3D6 = new Point3D();
						buCall.buVector5_0.LineWithLengthAndAngle(EndPnt2, Cam.Tool.Geometry.Diameter / 2.0 + num6, num + 90.0, ref point3D6);
						pnt6D = new Pnt6D(point3D6.X, point3D6.Y, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleFinishVel, 1, plungemove: false));
					}
				}
				Line line4 = new Line(EndPnt, EndPnt2);
				line4.ColorMethod = colorMethodType.byEntity;
				line4.Color = Color.Red;
				calcEntities.Add(line4);
				if (k != num11)
				{
					pnt6D = new Pnt6D(num14 - 1.0, num15 + 1.0, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 0, plungemove: false));
				}
				else
				{
					pnt6D = new Pnt6D(camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.X, Pars.BaseMaterialHeight + num5 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 0, plungemove: false));
					pnt6D = new Pnt6D(Cam.Tool.Geometry.Diameter / 2.0 + 10.0, Pars.BaseMaterialHeight + num5 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 0, plungemove: false));
				}
				if (Pars.NickEnable)
				{
					if (k < num11)
					{
						if (k != num11 - 1)
						{
							camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M32");
							camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M40 K" + num10.ToString("f2"));
							camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M31");
							num12 += num10;
							num13 += num10;
						}
						else
						{
							camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M32");
							camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M40 K" + (Pars.GrindingLength - num10 * ((double)num11 - 1.0)).ToString("f2"));
							camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M31");
							num12 += Pars.GrindingLength - num10 * ((double)num11 - 1.0);
							num13 += Pars.GrindingLength - num10 * ((double)num11 - 1.0);
						}
					}
				}
				else if (k < num11)
				{
					if (k != num11 - 1)
					{
						camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M32");
						camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M40 K" + num10.ToString("f2"));
						camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M31");
						num12 += num10;
					}
					else
					{
						camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M32");
						camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M40 K" + (Pars.GrindingLength - (ToolGrinding.Geometry.Thickness + num12)).ToString("f2"));
						camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M31");
						num12 += Pars.GrindingLength - (ToolGrinding.Geometry.Thickness + num12);
					}
				}
			}
			if (num13 != 0.0)
			{
				camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M32");
				camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M40 K" + (0.0 - num13).ToString("f2"));
				camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M31");
			}
			num13 = 0.0;
			for (int m = 1; m <= num11; m++)
			{
				if (m == 1)
				{
					pnt6D = new Pnt6D(camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.X, Pars.BaseMaterialHeight + num4 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
					tpPnt9D = new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 0, plungemove: false);
					tpPnt9D.EnableAxes.X = false;
					camTpPoint2.Points.Add(tpPnt9D);
					tpPnt9D = new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 0, plungemove: false);
					camTpPoint2.Points.Add(tpPnt9D);
				}
				if (!Pars.VShapeAngleEnable)
				{
					continue;
				}
				if (m == 1)
				{
					pnt6D = new Pnt6D(camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.X, Pars.BaseMaterialHeight + num5 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 0, plungemove: false));
					pnt6D = new Pnt6D(Cam.Tool.Geometry.Diameter / 2.0 + 10.0, Pars.BaseMaterialHeight + num5 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 0, plungemove: false));
				}
				double num21 = Pars.MaterialThickness / 2.0 - Pars.VShapeAngleFinishDepth;
				int num22 = Convert.ToInt32(buNumeric5.RoundToUpper(num21 / Pars.VShapeAngleRoughDepth));
				double num23 = Math.Round(num21 / (double)num22, 3);
				int num24 = 0;
				for (int num25 = num22; num25 >= 1; num25--)
				{
					if (Pars.VShapeAngleUpDownMode != UpDownDirectionType.DownToUp)
					{
						point3D3 = buVector5.ToPoint3D(Vertices[2]);
						point3D4 = buVector5.ToPoint3D(Vertices[3]);
						num2 = buCall.buVector5_0.PointAngle(Vertices[3], Vertices[2]);
						EndPnt = new Point3D();
						EndPnt2 = new Point3D();
						buCall.buVector5_0.LineWithLengthAndAngle(point3D3, (double)num25 * num23, num2 + 90.0, ref EndPnt);
						buCall.buVector5_0.LineWithLengthAndAngle(point3D4, (double)num25 * num23, num2 + 90.0, ref EndPnt2);
						point3D5 = buCall.buVector5_0.MiddlePointOfLine(EndPnt, EndPnt2);
						buCall.buVector5_0.LineWithLengthAndAngle(point3D5, Pars.VShapeAngleWidth / 2.0, num2 - 180.0, ref EndPnt);
						buCall.buVector5_0.LineWithLengthAndAngle(point3D5, Pars.VShapeAngleWidth / 2.0, num2, ref EndPnt2);
						Point3D EndPnt3 = new Point3D();
						buCall.buVector5_0.LineWithLengthAndAngle(EndPnt, Cam.Tool.Geometry.Diameter / 2.0 + num6, num2 + 90.0, ref EndPnt3);
						num14 = EndPnt3.X;
						num15 = EndPnt3.Y;
						pnt6D = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
						if (num24 != 0)
						{
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false));
						}
						else
						{
							tpPnt9D = new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false);
							if (Pars.VShapeHeightToolNo == 1)
							{
								tpPnt9D.PreCodes.Add("M21 K-1");
							}
							if (Pars.VShapeHeightToolNo == 2)
							{
								tpPnt9D.PreCodes.Add("M22 K-1");
							}
							if (Pars.VShapeHeightToolNo == 3)
							{
								tpPnt9D.PreCodes.Add("M23 K-1");
							}
							camTpPoint2.Points.Add(tpPnt9D);
						}
						EndPnt3 = new Point3D();
						buCall.buVector5_0.LineWithLengthAndAngle(EndPnt, Cam.Tool.Geometry.Diameter / 2.0, num2 + 90.0, ref EndPnt3);
						pnt6D = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false));
						EndPnt3 = new Point3D();
						buCall.buVector5_0.LineWithLengthAndAngle(EndPnt2, Cam.Tool.Geometry.Diameter / 2.0, num2 + 90.0, ref EndPnt3);
						pnt6D = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false));
						EndPnt3 = new Point3D();
						buCall.buVector5_0.LineWithLengthAndAngle(EndPnt2, Cam.Tool.Geometry.Diameter / 2.0 + num6, num2 + 90.0, ref EndPnt3);
						pnt6D = new Pnt6D(EndPnt3.X, EndPnt3.Y, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false));
						Line line5 = new Line(EndPnt, EndPnt2);
						line5.ColorMethod = colorMethodType.byEntity;
						line5.Color = Color.Red;
						calcEntities.Add(line5);
						num24++;
					}
					else
					{
						num2 = buCall.buVector5_0.PointAngle(Vertices[2], Vertices[3]);
						point3D3 = buVector5.ToPoint3D(Vertices[3]);
						point3D4 = buVector5.ToPoint3D(Vertices[2]);
						EndPnt = new Point3D();
						EndPnt2 = new Point3D();
						buCall.buVector5_0.LineWithLengthAndAngle(point3D3, (double)num25 * num23, num2 - 90.0, ref EndPnt);
						buCall.buVector5_0.LineWithLengthAndAngle(point3D4, (double)num25 * num23, num2 - 90.0, ref EndPnt2);
						point3D5 = buCall.buVector5_0.MiddlePointOfLine(EndPnt, EndPnt2);
						buCall.buVector5_0.LineWithLengthAndAngle(point3D5, Pars.VShapeAngleWidth / 2.0, num2 - 180.0, ref EndPnt);
						buCall.buVector5_0.LineWithLengthAndAngle(point3D5, Pars.VShapeAngleWidth / 2.0, num2, ref EndPnt2);
						Point3D EndPnt4 = new Point3D();
						buCall.buVector5_0.LineWithLengthAndAngle(EndPnt, Cam.Tool.Geometry.Diameter / 2.0 + num6, num2 - 90.0, ref EndPnt4);
						pnt6D = new Pnt6D(EndPnt4.X, EndPnt4.Y, 0.0);
						num14 = EndPnt4.X;
						num15 = EndPnt4.Y;
						if (num24 != 0)
						{
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false));
						}
						else
						{
							tpPnt9D = new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false);
							if (Pars.VShapeHeightToolNo == 1)
							{
								tpPnt9D.PreCodes.Add("M21 K-1");
							}
							if (Pars.VShapeHeightToolNo == 2)
							{
								tpPnt9D.PreCodes.Add("M22 K-1");
							}
							if (Pars.VShapeHeightToolNo == 3)
							{
								tpPnt9D.PreCodes.Add("M23 K-1");
							}
							camTpPoint2.Points.Add(tpPnt9D);
						}
						EndPnt4 = new Point3D();
						buCall.buVector5_0.LineWithLengthAndAngle(EndPnt, Cam.Tool.Geometry.Diameter / 2.0, num2 - 90.0, ref EndPnt4);
						pnt6D = new Pnt6D(EndPnt4.X, EndPnt4.Y, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false));
						EndPnt4 = new Point3D();
						buCall.buVector5_0.LineWithLengthAndAngle(EndPnt2, Cam.Tool.Geometry.Diameter / 2.0, num2 - 90.0, ref EndPnt4);
						pnt6D = new Pnt6D(EndPnt4.X, EndPnt4.Y, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false));
						EndPnt4 = new Point3D();
						buCall.buVector5_0.LineWithLengthAndAngle(EndPnt2, Cam.Tool.Geometry.Diameter / 2.0 + num6, num2 - 90.0, ref EndPnt4);
						pnt6D = new Pnt6D(EndPnt4.X, EndPnt4.Y, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false));
						Line line6 = new Line(EndPnt, EndPnt2);
						line6.ColorMethod = colorMethodType.byEntity;
						line6.Color = Color.Red;
						calcEntities.Add(line6);
						num24++;
					}
				}
				for (int n = 1; n <= Pars.VShapeAngleFinishCount; n++)
				{
					if (Pars.VShapeAngleUpDownMode != UpDownDirectionType.DownToUp)
					{
						EndPnt = new Point3D();
						EndPnt2 = new Point3D();
						point3D5 = buCall.buVector5_0.MiddlePointOfLine(point3D3, point3D4);
						buCall.buVector5_0.LineWithLengthAndAngle(point3D5, Pars.VShapeAngleWidth / 2.0, num2 - 180.0, ref EndPnt);
						buCall.buVector5_0.LineWithLengthAndAngle(point3D5, Pars.VShapeAngleWidth / 2.0, num2, ref EndPnt2);
						Point3D EndPnt5 = new Point3D();
						buCall.buVector5_0.LineWithLengthAndAngle(EndPnt, Cam.Tool.Geometry.Diameter / 2.0 + num6, num2 + 90.0, ref EndPnt5);
						pnt6D = new Pnt6D(EndPnt5.X, EndPnt5.Y, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleFinishVel, 1, plungemove: false));
						EndPnt5 = new Point3D();
						buCall.buVector5_0.LineWithLengthAndAngle(EndPnt, Cam.Tool.Geometry.Diameter / 2.0, num2 + 90.0, ref EndPnt5);
						pnt6D = new Pnt6D(EndPnt5.X, EndPnt5.Y, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleFinishVel, 1, plungemove: false));
						EndPnt5 = new Point3D();
						buCall.buVector5_0.LineWithLengthAndAngle(EndPnt2, Cam.Tool.Geometry.Diameter / 2.0, num2 + 90.0, ref EndPnt5);
						pnt6D = new Pnt6D(EndPnt5.X, EndPnt5.Y, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleFinishVel, 1, plungemove: false));
						EndPnt5 = new Point3D();
						buCall.buVector5_0.LineWithLengthAndAngle(EndPnt2, Cam.Tool.Geometry.Diameter / 2.0 + num6, num2 + 90.0, ref EndPnt5);
						pnt6D = new Pnt6D(EndPnt5.X, EndPnt5.Y, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleFinishVel, 1, plungemove: false));
					}
					else
					{
						EndPnt = new Point3D();
						EndPnt2 = new Point3D();
						point3D5 = buCall.buVector5_0.MiddlePointOfLine(point3D3, point3D4);
						buCall.buVector5_0.LineWithLengthAndAngle(point3D5, Pars.VShapeAngleWidth / 2.0, num2 - 180.0, ref EndPnt);
						buCall.buVector5_0.LineWithLengthAndAngle(point3D5, Pars.VShapeAngleWidth / 2.0, num2, ref EndPnt2);
						Point3D EndPnt6 = new Point3D();
						buCall.buVector5_0.LineWithLengthAndAngle(EndPnt, Cam.Tool.Geometry.Diameter / 2.0 + num6, num2 - 90.0, ref EndPnt6);
						pnt6D = new Pnt6D(EndPnt6.X, EndPnt6.Y, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleFinishVel, 1, plungemove: false));
						EndPnt6 = new Point3D();
						buCall.buVector5_0.LineWithLengthAndAngle(EndPnt, Cam.Tool.Geometry.Diameter / 2.0, num2 - 90.0, ref EndPnt6);
						pnt6D = new Pnt6D(EndPnt6.X, EndPnt6.Y, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleFinishVel, 1, plungemove: false));
						EndPnt6 = new Point3D();
						buCall.buVector5_0.LineWithLengthAndAngle(EndPnt2, Cam.Tool.Geometry.Diameter / 2.0, num2 - 90.0, ref EndPnt6);
						pnt6D = new Pnt6D(EndPnt6.X, EndPnt6.Y, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleFinishVel, 1, plungemove: false));
						EndPnt6 = new Point3D();
						buCall.buVector5_0.LineWithLengthAndAngle(EndPnt2, Cam.Tool.Geometry.Diameter / 2.0 + num6, num2 - 90.0, ref EndPnt6);
						pnt6D = new Pnt6D(EndPnt6.X, EndPnt6.Y, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleFinishVel, 1, plungemove: false));
						pnt6D = new Pnt6D(camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.X, Pars.BaseMaterialHeight + num5 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 0, plungemove: false));
					}
				}
				if (m != num11)
				{
					pnt6D = new Pnt6D(num14 + 1.0, num15 + 1.0, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 0, plungemove: false));
				}
				else
				{
					pnt6D = new Pnt6D(camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.X, Pars.BaseMaterialHeight + num5 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 0, plungemove: false));
				}
				if (Pars.NickEnable)
				{
					if (m < num11)
					{
						if (m != num11 - 1)
						{
							camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M32");
							camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M40 K" + num10.ToString("f2"));
							camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M31");
							num12 += num10;
							num13 += num10;
						}
						else
						{
							camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M32");
							camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M40 K" + (Pars.GrindingLength - num10 * ((double)num11 - 1.0)).ToString("f2"));
							camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M31");
							num12 += Pars.GrindingLength - num10 * ((double)num11 - 1.0);
							num13 += Pars.GrindingLength - num10 * ((double)num11 - 1.0);
						}
					}
				}
				else if (m < num11)
				{
					if (m != num11 - 1)
					{
						camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M32");
						camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M40 K" + num10.ToString("f2"));
						camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M31");
						num12 += num10;
					}
					else
					{
						camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M32");
						camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M40 K" + (Pars.GrindingLength - (ToolGrinding.Geometry.Thickness + num12)).ToString("f2"));
						camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M31");
						num12 += Pars.GrindingLength - (ToolGrinding.Geometry.Thickness + num12);
					}
				}
				Line line7 = new Line(EndPnt, EndPnt2);
				line7.ColorMethod = colorMethodType.byEntity;
				line7.Color = Color.Red;
				calcEntities.Add(line7);
			}
		}
		camTpPoint2.AfterCodes.Add("M32");
		if (Pars.NickEnable)
		{
			camTpPoint2.AfterCodes.Add("M40 K" + (Pars.GrindingLength + ToolNick.Geometry.Thickness / 1.0 - num12).ToString("f2"));
			num12 += Pars.GrindingLength + ToolNick.Geometry.Thickness / 2.0 - num12;
		}
		else
		{
			camTpPoint2.AfterCodes.Add("M40 K" + (Pars.FeedDistance + ToolGrinding.Geometry.Thickness).ToString("f2"));
		}
		camTpPoint2.AfterCodes.Add("M31");
		Cam.CamPoints.Add(camTpPoint2);
		Cam.PreCodes.Add("//Count = " + Pars.FeedCount);
		buCall.buCam5_0.CreateSimulationPointsFromCamPoint(ref Cam, camTpPoint2, 0.9, 0.2);
	}

	public void doGrindingVShape1(DiemakerGrindingShapeSettings Pars, ToolBase5 ToolGrinding, ToolBase5 ToolNick, bool isCircular, ref List<Entity> calcEntities, ref camTp Cam)
	{
		Cam = new camTp();
		double num = 0.0;
		double num2 = 0.0;
		new Point3D();
		new Point3D();
		Point3D point3D = new Point3D();
		Point3D point3D2 = new Point3D();
		Point3D point3D3 = new Point3D();
		Point3D point3D4 = new Point3D();
		Point3D EndPnt = new Point3D();
		Point3D EndPnt2 = new Point3D();
		Point3D point3D5 = new Point3D();
		Entity rectangleEntity = null;
		buCall.buVector5_0.DrawRectangle(new Point3D(), Pars.MaterialThickness, Pars.BaseMaterialHeight, Plane.XY, ref rectangleEntity);
		rectangleEntity.Translate((0.0 - Pars.MaterialThickness) / 2.0, 0.0);
		calcEntities.Add(rectangleEntity);
		double num3 = Pars.MaterialThickness / 2.0 / Math.Tan(buConversion5.DegreeToRadian(Pars.VShapeTargetAngle / 2.0));
		List<Point3D> Vertices = new List<Point3D>();
		Vertices.Add(new Point3D((0.0 - Pars.MaterialThickness) / 2.0, 0.0));
		Vertices.Add(new Point3D((0.0 - Pars.MaterialThickness) / 2.0, Pars.TargetMaterialHeight - num3));
		Vertices.Add(new Point3D(Pars.MaterialThickness / 2.0 - Pars.MaterialThickness / 2.0, Pars.TargetMaterialHeight));
		Vertices.Add(new Point3D(Pars.MaterialThickness - Pars.MaterialThickness / 2.0, Pars.TargetMaterialHeight - num3));
		Vertices.Add(new Point3D(Pars.MaterialThickness - Pars.MaterialThickness / 2.0, 0.0));
		Vertices.Add(new Point3D((0.0 - Pars.MaterialThickness) / 2.0, 0.0));
		buCall.buVector5_0.MiddlePointOfLine(Vertices[1], Vertices[2]);
		buCall.buVector5_0.MiddlePointOfLine(Vertices[2], Vertices[3]);
		Point3D point3D6 = null;
		Point3D point3D7 = null;
		if (isCircular)
		{
			Vertices = new List<Point3D>();
			buCall.buVector5_0.Arc3Point(new Point3D((0.0 - Pars.MaterialThickness) / 2.0, Pars.TargetMaterialHeight - Pars.MaterialThickness / 3.0), new Point3D(0.0, Pars.TargetMaterialHeight), new Point3D(Pars.MaterialThickness / 2.0, Pars.TargetMaterialHeight - Pars.MaterialThickness / 3.0), Plane.XY, new EntityResolution(0.002, 50, 20.0, EntityResolutionType.ByLength), ref Vertices);
			point3D6 = buVector5.ToPoint3D(Vertices[0]);
			point3D7 = buVector5.ToPoint3D(Vertices[Vertices.Count - 1]);
		}
		double num4 = 5.0;
		LinearPath linearPath = new LinearPath(Vertices);
		linearPath.ColorMethod = colorMethodType.byEntity;
		linearPath.Color = Color.Lime;
		calcEntities.Add(linearPath);
		Cam.Tool = new ToolBase5(ToolGrinding);
		Cam.Tool.Geometry.GeometryType = ToolType.Flat;
		Cam.Tool.Geometry.Length = ToolGrinding.Geometry.Thickness;
		Cam.Tool.Geometry.Thickness = 2.0;
		double num5 = 5.0;
		camTpPoint camTpPoint2 = new camTpPoint();
		Pnt6D pnt6D = new Pnt6D();
		TpPnt9D tpPnt9D = new TpPnt9D();
		double num6 = Pars.BaseMaterialHeight - Pars.TargetMaterialHeight - Pars.VShapeHeightFinishDepth;
		int num7 = Convert.ToInt32(buNumeric5.RoundToUpper(num6 / Pars.VShapeHeightRoughDepth));
		double num8 = Math.Round(num6 / (double)num7, 3);
		double x = 0.0;
		double num9 = ToolGrinding.Geometry.Thickness - ToolNick.Geometry.Thickness;
		int num10 = (int)buNumeric5.RoundToUpper(Pars.GrindingLength / num9);
		double num11 = 0.0;
		if (Pars.NickEnable)
		{
			camTpPoint camTpPoint3 = new camTpPoint();
			camTpPoint3.PreCodes.Add("G75");
			string text = " K1";
			if (Pars.NickReverseDir)
			{
				text = " K-1";
			}
			if (Pars.NickToolNo == 1)
			{
				camTpPoint3.PreCodes.Add("M21" + text);
			}
			if (Pars.NickToolNo == 2)
			{
				camTpPoint3.PreCodes.Add("M22" + text);
			}
			if (Pars.NickToolNo == 3)
			{
				camTpPoint3.PreCodes.Add("M23" + text);
			}
			camTpPoint3.PreCodes.Add("M154");
			camTpPoint3.PreCodes.Add("G75");
			camTpPoint3.PreCodes.Add("G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
			camTpPoint3.PreCodes.Add("G75");
			pnt6D = new Pnt6D(0.0, Pars.BaseMaterialHeight + num4 + ToolNick.Geometry.Diameter / 2.0, 0.0);
			camTpPoint3.Points.Add(new TpPnt9D(pnt6D, Pars.NickRoughVel, 0, plungemove: false));
			camTpPoint3.Points[camTpPoint3.Points.Count - 1].EnableAxes.Y = false;
			pnt6D = new Pnt6D(0.0, Pars.BaseMaterialHeight + num4 + ToolNick.Geometry.Diameter / 2.0, 0.0);
			camTpPoint3.Points.Add(new TpPnt9D(pnt6D, Pars.NickRoughVel, 0, plungemove: false));
			pnt6D = new Pnt6D(0.0, Pars.NickDepth + Pars.NickFinishDepth + ToolNick.Geometry.Diameter / 2.0, 0.0);
			camTpPoint3.Points.Add(new TpPnt9D(pnt6D, Pars.NickRoughVel, 1, plungemove: false));
			pnt6D = new Pnt6D((0.0 - Pars.NickWidth) / 2.0, Pars.NickDepth + Pars.NickFinishDepth + 0.0 + ToolNick.Geometry.Diameter / 2.0, 0.0);
			camTpPoint3.Points.Add(new TpPnt9D(pnt6D, Pars.NickRoughVel, 0, plungemove: false));
			pnt6D = new Pnt6D((0.0 - Pars.NickWidth) / 2.0, Pars.NickDepth + ToolNick.Geometry.Diameter / 2.0, 0.0);
			camTpPoint3.Points.Add(new TpPnt9D(pnt6D, Pars.NickRoughVel, 0, plungemove: false));
			pnt6D = new Pnt6D(Pars.NickWidth / 2.0, Pars.NickDepth + ToolNick.Geometry.Diameter / 2.0, 0.0);
			camTpPoint3.Points.Add(new TpPnt9D(pnt6D, Pars.NickFinishVel, 1, plungemove: false));
			pnt6D = new Pnt6D(Pars.NickWidth / 2.0, Pars.BaseMaterialHeight + num4 + ToolNick.Geometry.Diameter / 2.0, 0.0);
			camTpPoint3.Points.Add(new TpPnt9D(pnt6D, Pars.NickRoughVel, 0, plungemove: false));
			x = pnt6D.X;
			camTpPoint3.AfterCodes.Add("M32");
			camTpPoint3.AfterCodes.Add("M40 K" + (ToolGrinding.Geometry.Thickness / 2.0).ToString("f2"));
			num11 += ToolGrinding.Geometry.Thickness / 2.0;
			camTpPoint3.AfterCodes.Add("M31");
			Cam.CamPoints.Add(camTpPoint3);
		}
		camTpPoint2.PreCodes.Add("G75");
		if (Pars.VShapeHeightToolNo == 1)
		{
			camTpPoint2.PreCodes.Add("M21 K1");
		}
		if (Pars.VShapeHeightToolNo == 2)
		{
			camTpPoint2.PreCodes.Add("M22 K1");
		}
		if (Pars.VShapeHeightToolNo == 3)
		{
			camTpPoint2.PreCodes.Add("M23 K1");
		}
		camTpPoint2.PreCodes.Add("M154");
		camTpPoint2.PreCodes.Add("G75");
		camTpPoint2.PreCodes.Add("G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
		camTpPoint2.PreCodes.Add("G75");
		if (isCircular)
		{
			for (int i = 1; i <= num10; i++)
			{
				num6 = Pars.BaseMaterialHeight - Pars.TargetMaterialHeight - Pars.VShapeHeightFinishDepth;
				num7 = Convert.ToInt32(buNumeric5.RoundToUpper(num6 / Pars.VShapeHeightRoughDepth));
				num8 = Math.Round(num6 / (double)num7, 3);
				if (Pars.VShapeHeightZigzag)
				{
					pnt6D = new Pnt6D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.BaseMaterialHeight + 1.0 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
					tpPnt9D = new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 0, plungemove: false);
					tpPnt9D.EnableAxes.X = false;
					camTpPoint2.Points.Add(tpPnt9D);
					tpPnt9D = new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 0, plungemove: false);
					camTpPoint2.Points.Add(tpPnt9D);
				}
				for (int j = 1; j <= num7; j++)
				{
					if (Pars.VShapeHeightZigzag)
					{
						if (j % 2 != 1)
						{
							pnt6D = new Pnt6D(Pars.VShapeHeightWidth / 2.0, Pars.BaseMaterialHeight - (double)j * num8 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 1, plungemove: false));
							pnt6D = new Pnt6D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.BaseMaterialHeight - (double)j * num8 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 1, plungemove: false));
						}
						else
						{
							pnt6D = new Pnt6D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.BaseMaterialHeight - (double)j * num8 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 1, plungemove: false));
							pnt6D = new Pnt6D(Pars.VShapeHeightWidth / 2.0, Pars.BaseMaterialHeight - (double)j * num8 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 1, plungemove: false));
						}
					}
					else
					{
						pnt6D = new Pnt6D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.BaseMaterialHeight + 1.0 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 0, plungemove: false));
						pnt6D = new Pnt6D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.BaseMaterialHeight - (double)j * num8 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 1, plungemove: false));
						pnt6D = new Pnt6D(Pars.VShapeHeightWidth / 2.0, Pars.BaseMaterialHeight - (double)j * num8 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 1, plungemove: false));
						pnt6D = new Pnt6D(Pars.VShapeHeightWidth / 2.0, Pars.BaseMaterialHeight + 1.0 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 1, plungemove: false));
					}
					Line line = new Line(new Point3D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.BaseMaterialHeight - (double)j * num8), new Point3D(Pars.VShapeHeightWidth / 2.0, Pars.BaseMaterialHeight - (double)j * num8));
					line.ColorMethod = colorMethodType.byEntity;
					line.Color = Color.Cyan;
					calcEntities.Add(line);
				}
				if (Pars.VShapeHeightFinishDepth != 0.0)
				{
					if (Pars.VShapeHeightZigzag)
					{
						if (!(camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.X > 0.0))
						{
							pnt6D = new Pnt6D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.TargetMaterialHeight + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 1, plungemove: false));
							pnt6D = new Pnt6D(Pars.VShapeHeightWidth / 2.0, Pars.TargetMaterialHeight + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 1, plungemove: false));
						}
						else
						{
							pnt6D = new Pnt6D(Pars.VShapeHeightWidth / 2.0, Pars.TargetMaterialHeight + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 1, plungemove: false));
							pnt6D = new Pnt6D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.TargetMaterialHeight + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 1, plungemove: false));
						}
					}
					else
					{
						pnt6D = new Pnt6D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.BaseMaterialHeight + 1.0 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 1, plungemove: false));
						pnt6D = new Pnt6D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.TargetMaterialHeight + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 1, plungemove: false));
						pnt6D = new Pnt6D(Pars.VShapeHeightWidth / 2.0, Pars.TargetMaterialHeight + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 1, plungemove: false));
						pnt6D = new Pnt6D(Pars.VShapeHeightWidth / 2.0, Pars.BaseMaterialHeight + 1.0 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 1, plungemove: false));
					}
					Line line2 = new Line(new Point3D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.TargetMaterialHeight), new Point3D(Pars.VShapeHeightWidth / 2.0, Pars.TargetMaterialHeight));
					line2.ColorMethod = colorMethodType.byEntity;
					line2.Color = Color.Blue;
					calcEntities.Add(line2);
				}
				if (Pars.VShapeHeightZigzag)
				{
					pnt6D = new Pnt6D(camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.X, Pars.BaseMaterialHeight + 1.0 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 1, plungemove: false));
				}
				if (Pars.VShapeAngleEnable)
				{
					pnt6D = new Pnt6D(camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.X, Pars.BaseMaterialHeight + num4 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 0, plungemove: false));
					pnt6D = new Pnt6D(0.0 - Math.Abs(camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.X) - 20.0, Pars.BaseMaterialHeight + num4 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 0, plungemove: false));
					num6 = Pars.TargetMaterialHeight - point3D6.Y - Pars.VShapeAngleFinishDepth;
					num7 = Convert.ToInt32(buNumeric5.RoundToUpper(num6 / Pars.VShapeAngleRoughDepth));
					num8 = Math.Round(num6 / (double)num7, 3);
					Point3D point3D8 = new Point3D();
					EntityResolution entityResolution = new EntityResolution(0.001, 20, 20.0, EntityResolutionType.ByLength);
					entityResolution.MinPointCount = 50;
					for (int k = 1; k <= num7; k++)
					{
						Vertices = new List<Point3D>();
						Point3D firstPoint = new Point3D(point3D6.X, Pars.TargetMaterialHeight - (double)k * num8);
						Point3D secondPoint = new Point3D((point3D6.X + point3D7.X) / 2.0, Pars.TargetMaterialHeight);
						Point3D thirdPoint = new Point3D(point3D7.X, Pars.TargetMaterialHeight - (double)k * num8);
						buCall.buVector5_0.Arc3Point(firstPoint, secondPoint, thirdPoint, Plane.XY, entityResolution, ref Vertices);
						LinearPath linearPath2 = new LinearPath(Vertices);
						linearPath2.ColorMethod = colorMethodType.byEntity;
						linearPath2.Color = Color.Red;
						calcEntities.Add(linearPath2);
						if (Pars.VShapeAngleZigzag)
						{
							double num12 = 0.0;
							if (k % 2 != 1)
							{
								for (int l = 0; l <= Vertices.Count - 2; l++)
								{
									num12 = buCall.buVector5_0.PointAngle(Vertices[l + 1], Vertices[l]);
									point3D8 = new Point3D();
									buCall.buVector5_0.LineWithLengthAndAngle(Vertices[l], Cam.Tool.Geometry.Diameter / 2.0 + 0.0, num12 - 90.0, ref point3D8);
									pnt6D = new Pnt6D(point3D8.X, point3D8.Y, 0.0);
									camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false));
								}
								num12 = buCall.buVector5_0.PointAngle(Vertices[Vertices.Count - 2], Vertices[Vertices.Count - 1]) + 180.0;
								point3D8 = new Point3D();
								buCall.buVector5_0.LineWithLengthAndAngle(Vertices[Vertices.Count - 1], Cam.Tool.Geometry.Diameter / 2.0 + 0.0, num12 - 90.0, ref point3D8);
								pnt6D = new Pnt6D(point3D8.X, point3D8.Y, 0.0);
								camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false));
								pnt6D = new Pnt6D(camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.X - 10.0, camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.Y, 0.0);
								camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false));
								continue;
							}
							Vertices.Reverse();
							for (int m = 0; m <= Vertices.Count - 2; m++)
							{
								num12 = buCall.buVector5_0.PointAngle(Vertices[m + 1], Vertices[m]);
								point3D8 = new Point3D();
								buCall.buVector5_0.LineWithLengthAndAngle(Vertices[m], Cam.Tool.Geometry.Diameter / 2.0 + 0.0, num12 + 90.0, ref point3D8);
								pnt6D = new Pnt6D(point3D8.X, point3D8.Y, 0.0);
								camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false));
							}
							num12 = buCall.buVector5_0.PointAngle(Vertices[Vertices.Count - 2], Vertices[Vertices.Count - 1]) + 180.0;
							point3D8 = new Point3D();
							buCall.buVector5_0.LineWithLengthAndAngle(Vertices[Vertices.Count - 1], Cam.Tool.Geometry.Diameter / 2.0 + 0.0, num12 + 90.0, ref point3D8);
							pnt6D = new Pnt6D(point3D8.X, point3D8.Y, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false));
							pnt6D = new Pnt6D(camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.X + 10.0, camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.Y, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false));
						}
						else
						{
							Vertices.Reverse();
							for (int n = 0; n <= Vertices.Count - 2; n++)
							{
								double num13 = buCall.buVector5_0.PointAngle(Vertices[n + 1], Vertices[n]);
								point3D8 = new Point3D();
								buCall.buVector5_0.LineWithLengthAndAngle(Vertices[n], Cam.Tool.Geometry.Diameter / 2.0 + 0.0, num13 + 90.0, ref point3D8);
								pnt6D = new Pnt6D(point3D8.X, point3D8.Y, 0.0);
								camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false));
							}
							pnt6D = new Pnt6D(camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.X, Pars.BaseMaterialHeight + num4 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 0, plungemove: false));
							pnt6D = new Pnt6D(0.0 - camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.X - 20.0, Pars.BaseMaterialHeight + num4 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 0, plungemove: false));
						}
					}
					Vertices = new List<Point3D>();
					buCall.buVector5_0.Arc3Point(new Point3D((0.0 - Pars.MaterialThickness) / 2.0, Pars.TargetMaterialHeight - Pars.MaterialThickness / 3.0), new Point3D(0.0, Pars.TargetMaterialHeight), new Point3D(Pars.MaterialThickness / 2.0, Pars.TargetMaterialHeight - Pars.MaterialThickness / 3.0), Plane.XY, entityResolution, ref Vertices);
					if (Pars.VShapeAngleZigzag)
					{
						if (!(camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.X > 0.0))
						{
							Vertices.Reverse();
							for (int num14 = 0; num14 <= Vertices.Count - 2; num14++)
							{
								double num15 = buCall.buVector5_0.PointAngle(Vertices[num14 + 1], Vertices[num14]);
								point3D8 = new Point3D();
								buCall.buVector5_0.LineWithLengthAndAngle(Vertices[num14], Cam.Tool.Geometry.Diameter / 2.0 + 0.0, num15 + 90.0, ref point3D8);
								pnt6D = new Pnt6D(point3D8.X, point3D8.Y, 0.0);
								camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleFinishVel, 1, plungemove: false));
							}
							pnt6D = new Pnt6D(camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.X, Pars.BaseMaterialHeight + num4 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 0, plungemove: false));
						}
						else
						{
							for (int num16 = 0; num16 <= Vertices.Count - 2; num16++)
							{
								double num17 = buCall.buVector5_0.PointAngle(Vertices[num16 + 1], Vertices[num16]);
								point3D8 = new Point3D();
								buCall.buVector5_0.LineWithLengthAndAngle(Vertices[num16], Cam.Tool.Geometry.Diameter / 2.0 + 0.0, num17 - 90.0, ref point3D8);
								pnt6D = new Pnt6D(point3D8.X, point3D8.Y, 0.0);
								camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleFinishVel, 1, plungemove: false));
							}
							pnt6D = new Pnt6D(camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.X, Pars.BaseMaterialHeight + num4 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 0, plungemove: false));
						}
					}
					else
					{
						Vertices.Reverse();
						for (int num18 = 0; num18 <= Vertices.Count - 2; num18++)
						{
							double num19 = buCall.buVector5_0.PointAngle(Vertices[num18 + 1], Vertices[num18]);
							point3D8 = new Point3D();
							buCall.buVector5_0.LineWithLengthAndAngle(Vertices[num18], Cam.Tool.Geometry.Diameter / 2.0 + 0.0, num19 + 90.0, ref point3D8);
							pnt6D = new Pnt6D(point3D8.X, point3D8.Y, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleFinishVel, 1, plungemove: false));
						}
						pnt6D = new Pnt6D(camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.X, Pars.BaseMaterialHeight + num4 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 0, plungemove: false));
					}
				}
				if (Pars.NickEnable)
				{
					if (i < num10)
					{
						if (i != num10 - 1)
						{
							camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M32");
							camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M40 K" + num9.ToString("f2"));
							camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M31");
							num11 += num9;
						}
						else
						{
							camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M32");
							camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M40 K" + (Pars.GrindingLength + ToolNick.Geometry.Thickness / 2.0 - num9 * ((double)num10 - 1.0)).ToString("f2"));
							camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M31");
							num11 += Pars.GrindingLength + ToolNick.Geometry.Thickness / 2.0 - num9 * ((double)num10 - 1.0);
						}
					}
				}
				else if (i < num10)
				{
					if (i != num10 - 1)
					{
						camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M32");
						camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M40 K" + num9.ToString("f2"));
						camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M31");
						num11 += num9;
					}
					else
					{
						camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M32");
						camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M40 K" + (Pars.GrindingLength - (ToolGrinding.Geometry.Thickness + num11)).ToString("f2"));
						camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M31");
						num11 += Pars.GrindingLength - (ToolGrinding.Geometry.Thickness + num11);
					}
				}
			}
		}
		else
		{
			for (int num20 = 1; num20 <= num10; num20++)
			{
				pnt6D = new Pnt6D(x, Pars.BaseMaterialHeight + num4 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
				tpPnt9D = new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 0, plungemove: false);
				tpPnt9D.EnableAxes.X = false;
				camTpPoint2.Points.Add(tpPnt9D);
				tpPnt9D = new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 0, plungemove: false);
				camTpPoint2.Points.Add(tpPnt9D);
				if (Pars.VShapeHeightZigzag)
				{
					pnt6D = new Pnt6D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.BaseMaterialHeight + 1.0 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 0, plungemove: false));
					camTpPoint2.Points[camTpPoint2.Points.Count - 1].EnableAxes.Y = false;
					pnt6D = new Pnt6D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.BaseMaterialHeight + 1.0 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 0, plungemove: false));
				}
				for (int num21 = 1; num21 <= num7; num21++)
				{
					if (Pars.VShapeHeightZigzag)
					{
						if (num21 % 2 != 1)
						{
							pnt6D = new Pnt6D(Pars.VShapeHeightWidth / 2.0, Pars.BaseMaterialHeight - (double)num21 * num8 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 1, plungemove: false));
							pnt6D = new Pnt6D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.BaseMaterialHeight - (double)num21 * num8 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 1, plungemove: false));
						}
						else
						{
							pnt6D = new Pnt6D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.BaseMaterialHeight - (double)num21 * num8 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 1, plungemove: false));
							pnt6D = new Pnt6D(Pars.VShapeHeightWidth / 2.0, Pars.BaseMaterialHeight - (double)num21 * num8 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 1, plungemove: false));
						}
					}
					else
					{
						pnt6D = new Pnt6D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.BaseMaterialHeight + 1.0 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 0, plungemove: false));
						pnt6D = new Pnt6D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.BaseMaterialHeight - (double)num21 * num8 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 1, plungemove: false));
						pnt6D = new Pnt6D(Pars.VShapeHeightWidth / 2.0, Pars.BaseMaterialHeight - (double)num21 * num8 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 1, plungemove: false));
						pnt6D = new Pnt6D(Pars.VShapeHeightWidth / 2.0, Pars.BaseMaterialHeight + 1.0 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 1, plungemove: false));
					}
					Line line3 = new Line(new Point3D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.BaseMaterialHeight - (double)num21 * num8), new Point3D(Pars.VShapeHeightWidth / 2.0, Pars.BaseMaterialHeight - (double)num21 * num8));
					line3.ColorMethod = colorMethodType.byEntity;
					line3.Color = Color.Cyan;
					calcEntities.Add(line3);
				}
				if (Pars.VShapeHeightFinishDepth != 0.0)
				{
					if (Pars.VShapeHeightZigzag)
					{
						if (!(camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.X > 0.0))
						{
							pnt6D = new Pnt6D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.TargetMaterialHeight + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 1, plungemove: false));
							pnt6D = new Pnt6D(Pars.VShapeHeightWidth / 2.0, Pars.TargetMaterialHeight + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 1, plungemove: false));
						}
						else
						{
							pnt6D = new Pnt6D(Pars.VShapeHeightWidth / 2.0, Pars.TargetMaterialHeight + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 1, plungemove: false));
							pnt6D = new Pnt6D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.TargetMaterialHeight + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 1, plungemove: false));
						}
					}
					else
					{
						pnt6D = new Pnt6D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.BaseMaterialHeight + 1.0 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 1, plungemove: false));
						pnt6D = new Pnt6D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.TargetMaterialHeight + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 1, plungemove: false));
						pnt6D = new Pnt6D(Pars.VShapeHeightWidth / 2.0, Pars.TargetMaterialHeight + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 1, plungemove: false));
						pnt6D = new Pnt6D(Pars.VShapeHeightWidth / 2.0, Pars.BaseMaterialHeight + 1.0 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 1, plungemove: false));
					}
					Line line4 = new Line(new Point3D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.TargetMaterialHeight), new Point3D(Pars.VShapeHeightWidth / 2.0, Pars.TargetMaterialHeight));
					line4.ColorMethod = colorMethodType.byEntity;
					line4.Color = Color.Blue;
					calcEntities.Add(line4);
				}
				if (Pars.VShapeHeightZigzag)
				{
					pnt6D = new Pnt6D(camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.X, Pars.BaseMaterialHeight + 1.0 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 1, plungemove: false));
				}
				pnt6D = new Pnt6D(camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.X, Pars.BaseMaterialHeight + num5 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
				camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 0, plungemove: false));
				pnt6D = new Pnt6D(0.0 - Math.Abs(camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.X) - ToolGrinding.Geometry.Diameter / 2.0, Pars.BaseMaterialHeight + num5 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
				camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 0, plungemove: false));
				if (Pars.VShapeAngleEnable)
				{
					double num22 = Pars.MaterialThickness / 2.0 - Pars.VShapeAngleFinishDepth;
					int num23 = Convert.ToInt32(buNumeric5.RoundToUpper(num22 / Pars.VShapeAngleRoughDepth));
					double num24 = Math.Round(num22 / (double)num23, 3);
					double num25 = 1.0;
					Point3D point3D9 = new Point3D();
					int num26 = 0;
					for (int num27 = num23; num27 >= 1; num27--)
					{
						EndPnt = new Point3D();
						EndPnt2 = new Point3D();
						if (Pars.VShapeAngleUpDownMode != UpDownDirectionType.DownToUp)
						{
							point3D = buVector5.ToPoint3D(Vertices[2]);
							point3D2 = buVector5.ToPoint3D(Vertices[1]);
							num = buCall.buVector5_0.PointAngle(Vertices[1], Vertices[2]);
							buCall.buVector5_0.LineWithLengthAndAngle(point3D, (double)num27 * num24, num - 90.0, ref EndPnt);
							buCall.buVector5_0.LineWithLengthAndAngle(point3D2, (double)num27 * num24, num - 90.0, ref EndPnt2);
							point3D5 = buCall.buVector5_0.MiddlePointOfLine(EndPnt, EndPnt2);
							buCall.buVector5_0.LineWithLengthAndAngle(point3D5, Pars.VShapeAngleWidth / 2.0, num - 180.0, ref EndPnt);
							buCall.buVector5_0.LineWithLengthAndAngle(point3D5, Pars.VShapeAngleWidth / 2.0, num, ref EndPnt2);
							point3D9 = new Point3D();
							buCall.buVector5_0.LineWithLengthAndAngle(EndPnt, Cam.Tool.Geometry.Diameter / 2.0 + num25, num - 90.0, ref point3D9);
							pnt6D = new Pnt6D(point3D9.X, point3D9.Y, 0.0);
							if (num26 != 0)
							{
								tpPnt9D = new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false);
								camTpPoint2.Points.Add(tpPnt9D);
							}
							else
							{
								tpPnt9D = new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false);
								if (Pars.VShapeHeightToolNo == 1)
								{
									tpPnt9D.PreCodes.Add("M21 K1");
								}
								if (Pars.VShapeHeightToolNo == 2)
								{
									tpPnt9D.PreCodes.Add("M22 K1");
								}
								if (Pars.VShapeHeightToolNo == 3)
								{
									tpPnt9D.PreCodes.Add("M23 K1");
								}
								camTpPoint2.Points.Add(tpPnt9D);
							}
							point3D9 = new Point3D();
							buCall.buVector5_0.LineWithLengthAndAngle(EndPnt, Cam.Tool.Geometry.Diameter / 2.0, num - 90.0, ref point3D9);
							pnt6D = new Pnt6D(point3D9.X, point3D9.Y, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false));
							point3D9 = new Point3D();
							buCall.buVector5_0.LineWithLengthAndAngle(EndPnt2, Cam.Tool.Geometry.Diameter / 2.0, num - 90.0, ref point3D9);
							pnt6D = new Pnt6D(point3D9.X, point3D9.Y, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false));
							point3D9 = new Point3D();
							buCall.buVector5_0.LineWithLengthAndAngle(EndPnt2, Cam.Tool.Geometry.Diameter / 2.0 + num25, num - 90.0, ref point3D9);
							pnt6D = new Pnt6D(point3D9.X, point3D9.Y, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false));
							num26++;
						}
						else
						{
							point3D = buVector5.ToPoint3D(Vertices[1]);
							point3D2 = buVector5.ToPoint3D(Vertices[2]);
							num = buCall.buVector5_0.PointAngle(Vertices[2], Vertices[1]);
							buCall.buVector5_0.LineWithLengthAndAngle(point3D, (double)num27 * num24, num + 90.0, ref EndPnt);
							buCall.buVector5_0.LineWithLengthAndAngle(point3D2, (double)num27 * num24, num + 90.0, ref EndPnt2);
							point3D5 = buCall.buVector5_0.MiddlePointOfLine(EndPnt, EndPnt2);
							buCall.buVector5_0.LineWithLengthAndAngle(point3D5, Pars.VShapeAngleWidth / 2.0, num - 180.0, ref EndPnt);
							buCall.buVector5_0.LineWithLengthAndAngle(point3D5, Pars.VShapeAngleWidth / 2.0, num, ref EndPnt2);
							point3D9 = new Point3D();
							buCall.buVector5_0.LineWithLengthAndAngle(EndPnt, Cam.Tool.Geometry.Diameter / 2.0 + num25, num + 90.0, ref point3D9);
							pnt6D = new Pnt6D(point3D9.X, point3D9.Y, 0.0);
							if (num26 != 0)
							{
								tpPnt9D = new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false);
								camTpPoint2.Points.Add(tpPnt9D);
							}
							else
							{
								tpPnt9D = new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false);
								if (Pars.VShapeHeightToolNo == 1)
								{
									tpPnt9D.PreCodes.Add("M21 K1");
								}
								if (Pars.VShapeHeightToolNo == 2)
								{
									tpPnt9D.PreCodes.Add("M22 K1");
								}
								if (Pars.VShapeHeightToolNo == 3)
								{
									tpPnt9D.PreCodes.Add("M23 K1");
								}
								camTpPoint2.Points.Add(tpPnt9D);
							}
							point3D9 = new Point3D();
							buCall.buVector5_0.LineWithLengthAndAngle(EndPnt, Cam.Tool.Geometry.Diameter / 2.0, num + 90.0, ref point3D9);
							pnt6D = new Pnt6D(point3D9.X, point3D9.Y, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false));
							point3D9 = new Point3D();
							buCall.buVector5_0.LineWithLengthAndAngle(EndPnt2, Cam.Tool.Geometry.Diameter / 2.0, num + 90.0, ref point3D9);
							pnt6D = new Pnt6D(point3D9.X, point3D9.Y, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false));
							point3D9 = new Point3D();
							buCall.buVector5_0.LineWithLengthAndAngle(EndPnt2, Cam.Tool.Geometry.Diameter / 2.0 + num25, num + 90.0, ref point3D9);
							pnt6D = new Pnt6D(point3D9.X, point3D9.Y, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false));
							num26++;
						}
						Line line5 = new Line(EndPnt, EndPnt2);
						line5.ColorMethod = colorMethodType.byEntity;
						line5.Color = Color.Red;
						calcEntities.Add(line5);
					}
					for (int num28 = 1; num28 <= Pars.VShapeAngleFinishCount; num28++)
					{
						if (Pars.VShapeAngleUpDownMode != UpDownDirectionType.DownToUp)
						{
							EndPnt = new Point3D();
							EndPnt2 = new Point3D();
							point3D5 = buCall.buVector5_0.MiddlePointOfLine(point3D, point3D2);
							buCall.buVector5_0.LineWithLengthAndAngle(point3D5, Pars.VShapeAngleWidth / 2.0, num - 180.0, ref EndPnt);
							buCall.buVector5_0.LineWithLengthAndAngle(point3D5, Pars.VShapeAngleWidth / 2.0, num, ref EndPnt2);
							point3D9 = new Point3D();
							buCall.buVector5_0.LineWithLengthAndAngle(EndPnt, Cam.Tool.Geometry.Diameter / 2.0 + num25, num - 90.0, ref point3D9);
							pnt6D = new Pnt6D(point3D9.X, point3D9.Y, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleFinishVel, 1, plungemove: false));
							point3D9 = new Point3D();
							buCall.buVector5_0.LineWithLengthAndAngle(EndPnt, Cam.Tool.Geometry.Diameter / 2.0, num - 90.0, ref point3D9);
							pnt6D = new Pnt6D(point3D9.X, point3D9.Y, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleFinishVel, 1, plungemove: false));
							point3D9 = new Point3D();
							buCall.buVector5_0.LineWithLengthAndAngle(EndPnt2, Cam.Tool.Geometry.Diameter / 2.0, num - 90.0, ref point3D9);
							pnt6D = new Pnt6D(point3D9.X, point3D9.Y, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleFinishVel, 1, plungemove: false));
							point3D9 = new Point3D();
							buCall.buVector5_0.LineWithLengthAndAngle(EndPnt2, Cam.Tool.Geometry.Diameter / 2.0 + num25, num - 90.0, ref point3D9);
							pnt6D = new Pnt6D(point3D9.X, point3D9.Y, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleFinishVel, 1, plungemove: false));
						}
						else
						{
							EndPnt = new Point3D();
							EndPnt2 = new Point3D();
							point3D5 = buCall.buVector5_0.MiddlePointOfLine(point3D, point3D2);
							buCall.buVector5_0.LineWithLengthAndAngle(point3D5, Pars.VShapeAngleWidth / 2.0, num - 180.0, ref EndPnt);
							buCall.buVector5_0.LineWithLengthAndAngle(point3D5, Pars.VShapeAngleWidth / 2.0, num, ref EndPnt2);
							point3D9 = new Point3D();
							buCall.buVector5_0.LineWithLengthAndAngle(EndPnt, Cam.Tool.Geometry.Diameter / 2.0 + num25, num + 90.0, ref point3D9);
							pnt6D = new Pnt6D(point3D9.X, point3D9.Y, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleFinishVel, 1, plungemove: false));
							point3D9 = new Point3D();
							buCall.buVector5_0.LineWithLengthAndAngle(EndPnt, Cam.Tool.Geometry.Diameter / 2.0, num + 90.0, ref point3D9);
							pnt6D = new Pnt6D(point3D9.X, point3D9.Y, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleFinishVel, 1, plungemove: false));
							point3D9 = new Point3D();
							buCall.buVector5_0.LineWithLengthAndAngle(EndPnt2, Cam.Tool.Geometry.Diameter / 2.0, num + 90.0, ref point3D9);
							pnt6D = new Pnt6D(point3D9.X, point3D9.Y, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleFinishVel, 1, plungemove: false));
							point3D9 = new Point3D();
							buCall.buVector5_0.LineWithLengthAndAngle(EndPnt2, Cam.Tool.Geometry.Diameter / 2.0 + num25, num + 90.0, ref point3D9);
							pnt6D = new Pnt6D(point3D9.X, point3D9.Y, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleFinishVel, 1, plungemove: false));
						}
					}
					Line line6 = new Line(EndPnt, EndPnt2);
					line6.ColorMethod = colorMethodType.byEntity;
					line6.Color = Color.Red;
					calcEntities.Add(line6);
					pnt6D = new Pnt6D(camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.X, Pars.BaseMaterialHeight + num5 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 0, plungemove: false));
					pnt6D = new Pnt6D(Cam.Tool.Geometry.Diameter / 2.0 + 10.0, Pars.BaseMaterialHeight + num5 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 0, plungemove: false));
					num22 = Pars.MaterialThickness / 2.0 - Pars.VShapeAngleFinishDepth;
					num23 = Convert.ToInt32(buNumeric5.RoundToUpper(num22 / Pars.VShapeAngleRoughDepth));
					num24 = Math.Round(num22 / (double)num23, 3);
					num26 = 0;
					for (int num29 = num23; num29 >= 1; num29--)
					{
						if (Pars.VShapeAngleUpDownMode != UpDownDirectionType.DownToUp)
						{
							point3D3 = buVector5.ToPoint3D(Vertices[2]);
							point3D4 = buVector5.ToPoint3D(Vertices[3]);
							num2 = buCall.buVector5_0.PointAngle(Vertices[3], Vertices[2]);
							EndPnt = new Point3D();
							EndPnt2 = new Point3D();
							buCall.buVector5_0.LineWithLengthAndAngle(point3D3, (double)num29 * num24, num2 + 90.0, ref EndPnt);
							buCall.buVector5_0.LineWithLengthAndAngle(point3D4, (double)num29 * num24, num2 + 90.0, ref EndPnt2);
							point3D5 = buCall.buVector5_0.MiddlePointOfLine(EndPnt, EndPnt2);
							buCall.buVector5_0.LineWithLengthAndAngle(point3D5, Pars.VShapeAngleWidth / 2.0, num2 - 180.0, ref EndPnt);
							buCall.buVector5_0.LineWithLengthAndAngle(point3D5, Pars.VShapeAngleWidth / 2.0, num2, ref EndPnt2);
							point3D9 = new Point3D();
							buCall.buVector5_0.LineWithLengthAndAngle(EndPnt, Cam.Tool.Geometry.Diameter / 2.0 + num25, num2 + 90.0, ref point3D9);
							pnt6D = new Pnt6D(point3D9.X, point3D9.Y, 0.0);
							if (num26 != 0)
							{
								camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false));
							}
							else
							{
								tpPnt9D = new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false);
								if (Pars.VShapeHeightToolNo == 1)
								{
									tpPnt9D.PreCodes.Add("M21 K-1");
								}
								if (Pars.VShapeHeightToolNo == 2)
								{
									tpPnt9D.PreCodes.Add("M22 K-1");
								}
								if (Pars.VShapeHeightToolNo == 3)
								{
									tpPnt9D.PreCodes.Add("M23 K-1");
								}
								camTpPoint2.Points.Add(tpPnt9D);
							}
							point3D9 = new Point3D();
							buCall.buVector5_0.LineWithLengthAndAngle(EndPnt, Cam.Tool.Geometry.Diameter / 2.0, num2 + 90.0, ref point3D9);
							pnt6D = new Pnt6D(point3D9.X, point3D9.Y, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false));
							point3D9 = new Point3D();
							buCall.buVector5_0.LineWithLengthAndAngle(EndPnt2, Cam.Tool.Geometry.Diameter / 2.0, num2 + 90.0, ref point3D9);
							pnt6D = new Pnt6D(point3D9.X, point3D9.Y, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false));
							point3D9 = new Point3D();
							buCall.buVector5_0.LineWithLengthAndAngle(EndPnt2, Cam.Tool.Geometry.Diameter / 2.0 + num25, num2 + 90.0, ref point3D9);
							pnt6D = new Pnt6D(point3D9.X, point3D9.Y, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false));
							Line line7 = new Line(EndPnt, EndPnt2);
							line7.ColorMethod = colorMethodType.byEntity;
							line7.Color = Color.Red;
							calcEntities.Add(line7);
							num26++;
						}
						else
						{
							num2 = buCall.buVector5_0.PointAngle(Vertices[2], Vertices[3]);
							point3D3 = buVector5.ToPoint3D(Vertices[3]);
							point3D4 = buVector5.ToPoint3D(Vertices[2]);
							EndPnt = new Point3D();
							EndPnt2 = new Point3D();
							buCall.buVector5_0.LineWithLengthAndAngle(point3D3, (double)num29 * num24, num2 - 90.0, ref EndPnt);
							buCall.buVector5_0.LineWithLengthAndAngle(point3D4, (double)num29 * num24, num2 - 90.0, ref EndPnt2);
							point3D5 = buCall.buVector5_0.MiddlePointOfLine(EndPnt, EndPnt2);
							buCall.buVector5_0.LineWithLengthAndAngle(point3D5, Pars.VShapeAngleWidth / 2.0, num2 - 180.0, ref EndPnt);
							buCall.buVector5_0.LineWithLengthAndAngle(point3D5, Pars.VShapeAngleWidth / 2.0, num2, ref EndPnt2);
							point3D9 = new Point3D();
							buCall.buVector5_0.LineWithLengthAndAngle(EndPnt, Cam.Tool.Geometry.Diameter / 2.0 + num25, num2 - 90.0, ref point3D9);
							pnt6D = new Pnt6D(point3D9.X, point3D9.Y, 0.0);
							if (num26 != 0)
							{
								camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false));
							}
							else
							{
								tpPnt9D = new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false);
								if (Pars.VShapeHeightToolNo == 1)
								{
									tpPnt9D.PreCodes.Add("M21 K-1");
								}
								if (Pars.VShapeHeightToolNo == 2)
								{
									tpPnt9D.PreCodes.Add("M22 K-1");
								}
								if (Pars.VShapeHeightToolNo == 3)
								{
									tpPnt9D.PreCodes.Add("M23 K-1");
								}
								camTpPoint2.Points.Add(tpPnt9D);
							}
							point3D9 = new Point3D();
							buCall.buVector5_0.LineWithLengthAndAngle(EndPnt, Cam.Tool.Geometry.Diameter / 2.0, num2 - 90.0, ref point3D9);
							pnt6D = new Pnt6D(point3D9.X, point3D9.Y, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false));
							point3D9 = new Point3D();
							buCall.buVector5_0.LineWithLengthAndAngle(EndPnt2, Cam.Tool.Geometry.Diameter / 2.0, num2 - 90.0, ref point3D9);
							pnt6D = new Pnt6D(point3D9.X, point3D9.Y, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false));
							point3D9 = new Point3D();
							buCall.buVector5_0.LineWithLengthAndAngle(EndPnt2, Cam.Tool.Geometry.Diameter / 2.0 + num25, num2 - 90.0, ref point3D9);
							pnt6D = new Pnt6D(point3D9.X, point3D9.Y, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false));
							Line line8 = new Line(EndPnt, EndPnt2);
							line8.ColorMethod = colorMethodType.byEntity;
							line8.Color = Color.Red;
							calcEntities.Add(line8);
							num26++;
						}
					}
					for (int num30 = 1; num30 <= Pars.VShapeAngleFinishCount; num30++)
					{
						if (Pars.VShapeAngleUpDownMode != UpDownDirectionType.DownToUp)
						{
							EndPnt = new Point3D();
							EndPnt2 = new Point3D();
							point3D5 = buCall.buVector5_0.MiddlePointOfLine(point3D3, point3D4);
							buCall.buVector5_0.LineWithLengthAndAngle(point3D5, Pars.VShapeAngleWidth / 2.0, num2 - 180.0, ref EndPnt);
							buCall.buVector5_0.LineWithLengthAndAngle(point3D5, Pars.VShapeAngleWidth / 2.0, num2, ref EndPnt2);
							point3D9 = new Point3D();
							buCall.buVector5_0.LineWithLengthAndAngle(EndPnt, Cam.Tool.Geometry.Diameter / 2.0 + num25, num2 + 90.0, ref point3D9);
							pnt6D = new Pnt6D(point3D9.X, point3D9.Y, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleFinishVel, 1, plungemove: false));
							point3D9 = new Point3D();
							buCall.buVector5_0.LineWithLengthAndAngle(EndPnt, Cam.Tool.Geometry.Diameter / 2.0, num2 + 90.0, ref point3D9);
							pnt6D = new Pnt6D(point3D9.X, point3D9.Y, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleFinishVel, 1, plungemove: false));
							point3D9 = new Point3D();
							buCall.buVector5_0.LineWithLengthAndAngle(EndPnt2, Cam.Tool.Geometry.Diameter / 2.0, num2 + 90.0, ref point3D9);
							pnt6D = new Pnt6D(point3D9.X, point3D9.Y, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleFinishVel, 1, plungemove: false));
							point3D9 = new Point3D();
							buCall.buVector5_0.LineWithLengthAndAngle(EndPnt2, Cam.Tool.Geometry.Diameter / 2.0 + num25, num2 + 90.0, ref point3D9);
							pnt6D = new Pnt6D(point3D9.X, point3D9.Y, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleFinishVel, 1, plungemove: false));
						}
						else
						{
							EndPnt = new Point3D();
							EndPnt2 = new Point3D();
							point3D5 = buCall.buVector5_0.MiddlePointOfLine(point3D3, point3D4);
							buCall.buVector5_0.LineWithLengthAndAngle(point3D5, Pars.VShapeAngleWidth / 2.0, num2 - 180.0, ref EndPnt);
							buCall.buVector5_0.LineWithLengthAndAngle(point3D5, Pars.VShapeAngleWidth / 2.0, num2, ref EndPnt2);
							point3D9 = new Point3D();
							buCall.buVector5_0.LineWithLengthAndAngle(EndPnt, Cam.Tool.Geometry.Diameter / 2.0 + num25, num2 - 90.0, ref point3D9);
							pnt6D = new Pnt6D(point3D9.X, point3D9.Y, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleFinishVel, 1, plungemove: false));
							point3D9 = new Point3D();
							buCall.buVector5_0.LineWithLengthAndAngle(EndPnt, Cam.Tool.Geometry.Diameter / 2.0, num2 - 90.0, ref point3D9);
							pnt6D = new Pnt6D(point3D9.X, point3D9.Y, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleFinishVel, 1, plungemove: false));
							point3D9 = new Point3D();
							buCall.buVector5_0.LineWithLengthAndAngle(EndPnt2, Cam.Tool.Geometry.Diameter / 2.0, num2 - 90.0, ref point3D9);
							pnt6D = new Pnt6D(point3D9.X, point3D9.Y, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleFinishVel, 1, plungemove: false));
							point3D9 = new Point3D();
							buCall.buVector5_0.LineWithLengthAndAngle(EndPnt2, Cam.Tool.Geometry.Diameter / 2.0 + num25, num2 - 90.0, ref point3D9);
							pnt6D = new Pnt6D(point3D9.X, point3D9.Y, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleFinishVel, 1, plungemove: false));
							pnt6D = new Pnt6D(camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.X, Pars.BaseMaterialHeight + num5 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 0, plungemove: false));
						}
					}
					pnt6D = new Pnt6D(camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.X, Pars.BaseMaterialHeight + num5 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 0, plungemove: false));
					Line line9 = new Line(EndPnt, EndPnt2);
					line9.ColorMethod = colorMethodType.byEntity;
					line9.Color = Color.Red;
					calcEntities.Add(line9);
				}
				if (Pars.NickEnable)
				{
					if (num20 < num10)
					{
						if (num20 != num10 - 1)
						{
							camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M32");
							camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M40 K" + num9.ToString("f2"));
							camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M31");
							num11 += num9;
						}
						else
						{
							camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M32");
							camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M40 K" + (Pars.GrindingLength + ToolNick.Geometry.Thickness / 2.0 - num9 * ((double)num10 - 1.0)).ToString("f2"));
							camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M31");
							num11 += Pars.GrindingLength + ToolNick.Geometry.Thickness / 2.0 - num9 * ((double)num10 - 1.0);
						}
					}
				}
				else if (num20 < num10)
				{
					if (num20 != num10 - 1)
					{
						camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M32");
						camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M40 K" + num9.ToString("f2"));
						camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M31");
						num11 += num9;
					}
					else
					{
						camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M32");
						camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M40 K" + (Pars.GrindingLength - (ToolGrinding.Geometry.Thickness + num11)).ToString("f2"));
						camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M31");
						num11 += Pars.GrindingLength - (ToolGrinding.Geometry.Thickness + num11);
					}
				}
			}
		}
		camTpPoint2.AfterCodes.Add("M32");
		if (Pars.NickEnable)
		{
			camTpPoint2.AfterCodes.Add("M40 K" + (Pars.GrindingLength + ToolNick.Geometry.Thickness / 1.0 - num11).ToString("f2"));
			num11 += Pars.GrindingLength + ToolNick.Geometry.Thickness / 2.0 - num11;
		}
		else
		{
			camTpPoint2.AfterCodes.Add("M40 K" + (Pars.FeedDistance + ToolGrinding.Geometry.Thickness).ToString("f2"));
		}
		camTpPoint2.AfterCodes.Add("M31");
		Cam.CamPoints.Add(camTpPoint2);
		if (Pars.NickEnable)
		{
			camTpPoint camTpPoint4 = new camTpPoint();
			camTpPoint4.PreCodes.Add("G75");
			string text2 = " K1";
			if (Pars.NickReverseDir)
			{
				text2 = " K-1";
			}
			if (Pars.NickToolNo == 1)
			{
				camTpPoint4.PreCodes.Add("M21" + text2);
			}
			if (Pars.NickToolNo == 2)
			{
				camTpPoint4.PreCodes.Add("M22" + text2);
			}
			if (Pars.NickToolNo == 3)
			{
				camTpPoint4.PreCodes.Add("M23" + text2);
			}
			camTpPoint4.PreCodes.Add("M154");
			camTpPoint4.PreCodes.Add("G75");
			camTpPoint4.PreCodes.Add("G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
			camTpPoint4.PreCodes.Add("G75");
			pnt6D = new Pnt6D(0.0, Pars.BaseMaterialHeight + num4 + ToolNick.Geometry.Diameter / 2.0, 0.0);
			camTpPoint4.Points.Add(new TpPnt9D(pnt6D, Pars.NickRoughVel, 0, plungemove: false));
			camTpPoint4.Points[camTpPoint4.Points.Count - 1].EnableAxes.Y = false;
			pnt6D = new Pnt6D(0.0, Pars.BaseMaterialHeight + num4 + ToolNick.Geometry.Diameter / 2.0, 0.0);
			camTpPoint4.Points.Add(new TpPnt9D(pnt6D, Pars.NickRoughVel, 0, plungemove: false));
			pnt6D = new Pnt6D(0.0, Pars.NickDepth + Pars.NickFinishDepth + ToolNick.Geometry.Diameter / 2.0, 0.0);
			camTpPoint4.Points.Add(new TpPnt9D(pnt6D, Pars.NickRoughVel, 1, plungemove: false));
			pnt6D = new Pnt6D((0.0 - Pars.NickWidth) / 2.0, Pars.NickDepth + Pars.NickFinishDepth + 0.0 + ToolNick.Geometry.Diameter / 2.0, 0.0);
			camTpPoint4.Points.Add(new TpPnt9D(pnt6D, Pars.NickRoughVel, 0, plungemove: false));
			pnt6D = new Pnt6D((0.0 - Pars.NickWidth) / 2.0, Pars.NickDepth + ToolNick.Geometry.Diameter / 2.0, 0.0);
			camTpPoint4.Points.Add(new TpPnt9D(pnt6D, Pars.NickRoughVel, 0, plungemove: false));
			pnt6D = new Pnt6D(Pars.NickWidth / 2.0, Pars.NickDepth + ToolNick.Geometry.Diameter / 2.0, 0.0);
			camTpPoint4.Points.Add(new TpPnt9D(pnt6D, Pars.NickFinishVel, 1, plungemove: false));
			pnt6D = new Pnt6D(Pars.NickWidth / 2.0, Pars.BaseMaterialHeight + num4 + ToolNick.Geometry.Diameter / 2.0, 0.0);
			camTpPoint4.Points.Add(new TpPnt9D(pnt6D, Pars.NickRoughVel, 0, plungemove: false));
			camTpPoint4.AfterCodes.Add("M32");
			camTpPoint4.AfterCodes.Add("M40 K" + (Pars.FeedDistance + ToolNick.Geometry.Thickness).ToString("f2"));
			camTpPoint4.AfterCodes.Add("M31");
			Cam.CamPoints.Add(camTpPoint4);
		}
		Cam.PreCodes.Add("//Count = " + Pars.FeedCount);
		buCall.buCam5_0.CreateSimulationPointsFromCamPoint(ref Cam, camTpPoint2, 0.9, 0.2);
	}

	public void doGrindingCircularShape(DiemakerGrindingShapeSettings Pars, ToolBase5 ToolGrinding, ToolBase5 ToolNick, ref List<Entity> calcEntities, ref camTp Cam)
	{
		Cam = new camTp();
		new Point3D();
		new Point3D();
		new Point3D();
		new Point3D();
		new Point3D();
		new Point3D();
		new Point3D();
		new Point3D();
		new Point3D();
		Entity rectangleEntity = null;
		buCall.buVector5_0.DrawRectangle(new Point3D(), Pars.MaterialThickness, Pars.BaseMaterialHeight, Plane.XY, ref rectangleEntity);
		rectangleEntity.Translate((0.0 - Pars.MaterialThickness) / 2.0, 0.0);
		calcEntities.Add(rectangleEntity);
		_ = Pars.MaterialThickness / 2.0 / Math.Tan(buConversion5.DegreeToRadian(Pars.VShapeTargetAngle / 2.0));
		List<Point3D> Vertices = new List<Point3D>();
		buCall.buVector5_0.Arc3Point(new Point3D((0.0 - Pars.MaterialThickness) / 2.0, Pars.TargetMaterialHeight - Pars.MaterialThickness / 3.0), new Point3D(0.0, Pars.TargetMaterialHeight), new Point3D(Pars.MaterialThickness / 2.0, Pars.TargetMaterialHeight - Pars.MaterialThickness / 3.0), Plane.XY, new EntityResolution(0.002, 50, 20.0, EntityResolutionType.ByLength), ref Vertices);
		Point3D point3D = buVector5.ToPoint3D(Vertices[0]);
		Point3D point3D2 = buVector5.ToPoint3D(Vertices[Vertices.Count - 1]);
		double num = 5.0;
		LinearPath linearPath = new LinearPath(Vertices);
		linearPath.ColorMethod = colorMethodType.byEntity;
		linearPath.Color = Color.Red;
		linearPath.LineWeightMethod = colorMethodType.byEntity;
		linearPath.LineWeight = 3f;
		calcEntities.Add(linearPath);
		Cam.Tool = new ToolBase5(ToolGrinding);
		Cam.Tool.Geometry.GeometryType = ToolType.Flat;
		Cam.Tool.Geometry.Length = ToolGrinding.Geometry.Thickness;
		Cam.Tool.Geometry.Thickness = 2.0;
		camTpPoint camTpPoint2 = new camTpPoint();
		Pnt6D pnt6D = new Pnt6D();
		new TpPnt9D();
		if (Pars.NickEnable)
		{
			camTpPoint camTpPoint3 = new camTpPoint();
			camTpPoint3.PreCodes.Add("G75");
			if (Pars.NickToolNo == 1)
			{
				camTpPoint3.PreCodes.Add("M21 K1");
			}
			if (Pars.NickToolNo == 2)
			{
				camTpPoint3.PreCodes.Add("M22 K1");
			}
			if (Pars.NickToolNo == 3)
			{
				camTpPoint3.PreCodes.Add("M23 K1");
			}
			camTpPoint3.PreCodes.Add("M154");
			camTpPoint3.PreCodes.Add("G75");
			camTpPoint3.PreCodes.Add("G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
			camTpPoint3.PreCodes.Add("G75");
			pnt6D = new Pnt6D(0.0, Pars.BaseMaterialHeight + 5.0 + ToolNick.Geometry.Diameter / 2.0, 0.0);
			camTpPoint3.Points.Add(new TpPnt9D(pnt6D, Pars.NickRoughVel, 0, plungemove: false));
			camTpPoint3.Points[camTpPoint3.Points.Count - 1].EnableAxes.Y = false;
			pnt6D = new Pnt6D(0.0, Pars.BaseMaterialHeight + 5.0 + ToolNick.Geometry.Diameter / 2.0, 0.0);
			camTpPoint3.Points.Add(new TpPnt9D(pnt6D, Pars.NickRoughVel, 0, plungemove: false));
			pnt6D = new Pnt6D(0.0, Pars.NickDepth + Pars.NickFinishDepth + ToolNick.Geometry.Diameter / 2.0, 0.0);
			camTpPoint3.Points.Add(new TpPnt9D(pnt6D, Pars.NickRoughVel, 1, plungemove: false));
			pnt6D = new Pnt6D(0.0, Pars.NickDepth + Pars.NickFinishDepth + 2.0 + ToolNick.Geometry.Diameter / 2.0, 0.0);
			camTpPoint3.Points.Add(new TpPnt9D(pnt6D, Pars.NickRoughVel, 0, plungemove: false));
			pnt6D = new Pnt6D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.NickDepth + Pars.NickFinishDepth + 2.0 + ToolNick.Geometry.Diameter / 2.0, 0.0);
			camTpPoint3.Points.Add(new TpPnt9D(pnt6D, Pars.NickRoughVel, 0, plungemove: false));
			pnt6D = new Pnt6D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.NickDepth + ToolNick.Geometry.Diameter / 2.0, 0.0);
			camTpPoint3.Points.Add(new TpPnt9D(pnt6D, Pars.NickRoughVel, 0, plungemove: false));
			pnt6D = new Pnt6D(Pars.VShapeHeightWidth / 2.0, Pars.NickDepth + ToolNick.Geometry.Diameter / 2.0, 0.0);
			camTpPoint3.Points.Add(new TpPnt9D(pnt6D, Pars.NickFinishVel, 1, plungemove: false));
			pnt6D = new Pnt6D(Pars.VShapeHeightWidth / 2.0, Pars.BaseMaterialHeight + 10.0 + ToolNick.Geometry.Diameter / 2.0, 0.0);
			camTpPoint3.Points.Add(new TpPnt9D(pnt6D, Pars.NickRoughVel, 0, plungemove: false));
			camTpPoint3.AfterCodes.Add("M32");
			camTpPoint3.AfterCodes.Add("M40 K" + (Pars.FeedDistance + ToolNick.Geometry.Thickness / 2.0 - ToolGrinding.Geometry.Thickness / 2.0).ToString("f2"));
			camTpPoint3.AfterCodes.Add("M31");
			Cam.CamPoints.Add(camTpPoint3);
		}
		camTpPoint2.PreCodes.Add("G75");
		if (Pars.VShapeHeightToolNo == 1)
		{
			camTpPoint2.PreCodes.Add("M21 K1");
		}
		if (Pars.VShapeHeightToolNo == 2)
		{
			camTpPoint2.PreCodes.Add("M22 K1");
		}
		if (Pars.VShapeHeightToolNo == 3)
		{
			camTpPoint2.PreCodes.Add("M23 K1");
		}
		camTpPoint2.PreCodes.Add("M154");
		camTpPoint2.PreCodes.Add("G75");
		camTpPoint2.PreCodes.Add("G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
		camTpPoint2.PreCodes.Add("G75");
		double num2 = Pars.BaseMaterialHeight - Pars.TargetMaterialHeight - Pars.VShapeHeightFinishDepth;
		int num3 = Convert.ToInt32(buNumeric5.RoundToUpper(num2 / Pars.VShapeHeightRoughDepth));
		double num4 = Math.Round(num2 / (double)num3, 3);
		if (Pars.VShapeHeightZigzag)
		{
			pnt6D = new Pnt6D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.BaseMaterialHeight + 1.0 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
			camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 0, plungemove: false));
		}
		for (int i = 1; i <= num3; i++)
		{
			if (Pars.VShapeHeightZigzag)
			{
				if (i % 2 != 1)
				{
					pnt6D = new Pnt6D(Pars.VShapeHeightWidth / 2.0, Pars.BaseMaterialHeight - (double)i * num4 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 1, plungemove: false));
					pnt6D = new Pnt6D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.BaseMaterialHeight - (double)i * num4 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 1, plungemove: false));
				}
				else
				{
					pnt6D = new Pnt6D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.BaseMaterialHeight - (double)i * num4 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 1, plungemove: false));
					pnt6D = new Pnt6D(Pars.VShapeHeightWidth / 2.0, Pars.BaseMaterialHeight - (double)i * num4 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 1, plungemove: false));
				}
			}
			else
			{
				pnt6D = new Pnt6D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.BaseMaterialHeight + 1.0 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
				camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 0, plungemove: false));
				pnt6D = new Pnt6D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.BaseMaterialHeight - (double)i * num4 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
				camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 1, plungemove: false));
				pnt6D = new Pnt6D(Pars.VShapeHeightWidth / 2.0, Pars.BaseMaterialHeight - (double)i * num4 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
				camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 1, plungemove: false));
				pnt6D = new Pnt6D(Pars.VShapeHeightWidth / 2.0, Pars.BaseMaterialHeight + 1.0 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
				camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 1, plungemove: false));
			}
			Line line = new Line(new Point3D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.BaseMaterialHeight - (double)i * num4), new Point3D(Pars.VShapeHeightWidth / 2.0, Pars.BaseMaterialHeight - (double)i * num4));
			line.ColorMethod = colorMethodType.byEntity;
			line.Color = Color.Cyan;
			calcEntities.Add(line);
		}
		if (Pars.VShapeHeightFinishDepth != 0.0)
		{
			if (Pars.VShapeHeightZigzag)
			{
				if (!(camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.X > 0.0))
				{
					pnt6D = new Pnt6D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.TargetMaterialHeight + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 1, plungemove: false));
					pnt6D = new Pnt6D(Pars.VShapeHeightWidth / 2.0, Pars.TargetMaterialHeight + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 1, plungemove: false));
				}
				else
				{
					pnt6D = new Pnt6D(Pars.VShapeHeightWidth / 2.0, Pars.TargetMaterialHeight + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 1, plungemove: false));
					pnt6D = new Pnt6D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.TargetMaterialHeight + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 1, plungemove: false));
				}
			}
			else
			{
				pnt6D = new Pnt6D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.BaseMaterialHeight + 1.0 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
				camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 1, plungemove: false));
				pnt6D = new Pnt6D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.TargetMaterialHeight + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
				camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 1, plungemove: false));
				pnt6D = new Pnt6D(Pars.VShapeHeightWidth / 2.0, Pars.TargetMaterialHeight + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
				camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 1, plungemove: false));
				pnt6D = new Pnt6D(Pars.VShapeHeightWidth / 2.0, Pars.BaseMaterialHeight + 1.0 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
				camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 1, plungemove: false));
			}
			Line line2 = new Line(new Point3D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.TargetMaterialHeight), new Point3D(Pars.VShapeHeightWidth / 2.0, Pars.TargetMaterialHeight));
			line2.ColorMethod = colorMethodType.byEntity;
			line2.Color = Color.Blue;
			calcEntities.Add(line2);
		}
		if (Pars.VShapeHeightZigzag)
		{
			pnt6D = new Pnt6D(camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.X, Pars.BaseMaterialHeight + 1.0 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
			camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 1, plungemove: false));
		}
		pnt6D = new Pnt6D(camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.X, Pars.BaseMaterialHeight + num + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
		camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 0, plungemove: false));
		pnt6D = new Pnt6D(0.0 - Math.Abs(camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.X) - 20.0, Pars.BaseMaterialHeight + num + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
		camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 0, plungemove: false));
		num2 = Pars.TargetMaterialHeight - point3D.Y - Pars.VShapeAngleFinishDepth;
		num3 = Convert.ToInt32(buNumeric5.RoundToUpper(num2 / Pars.VShapeAngleRoughDepth));
		num4 = Math.Round(num2 / (double)num3, 3);
		Point3D point3D3 = new Point3D();
		EntityResolution entityResolution = new EntityResolution(0.001, 20, 20.0, EntityResolutionType.ByLength);
		entityResolution.MinPointCount = 50;
		for (int j = 1; j <= num3; j++)
		{
			Vertices = new List<Point3D>();
			Point3D firstPoint = new Point3D(point3D.X, Pars.TargetMaterialHeight - (double)j * num4);
			Point3D secondPoint = new Point3D((point3D.X + point3D2.X) / 2.0, Pars.TargetMaterialHeight);
			Point3D thirdPoint = new Point3D(point3D2.X, Pars.TargetMaterialHeight - (double)j * num4);
			buCall.buVector5_0.Arc3Point(firstPoint, secondPoint, thirdPoint, Plane.XY, entityResolution, ref Vertices);
			LinearPath linearPath2 = new LinearPath(Vertices);
			linearPath2.ColorMethod = colorMethodType.byEntity;
			linearPath2.Color = Color.Red;
			calcEntities.Add(linearPath2);
			if (Pars.VShapeAngleZigzag)
			{
				double num5 = 0.0;
				if (j % 2 != 1)
				{
					for (int k = 0; k <= Vertices.Count - 2; k++)
					{
						num5 = buCall.buVector5_0.PointAngle(Vertices[k + 1], Vertices[k]);
						point3D3 = new Point3D();
						buCall.buVector5_0.LineWithLengthAndAngle(Vertices[k], Cam.Tool.Geometry.Diameter / 2.0 + 0.0, num5 - 90.0, ref point3D3);
						pnt6D = new Pnt6D(point3D3.X, point3D3.Y, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false));
					}
					num5 = buCall.buVector5_0.PointAngle(Vertices[Vertices.Count - 2], Vertices[Vertices.Count - 1]) + 180.0;
					point3D3 = new Point3D();
					buCall.buVector5_0.LineWithLengthAndAngle(Vertices[Vertices.Count - 1], Cam.Tool.Geometry.Diameter / 2.0 + 0.0, num5 - 90.0, ref point3D3);
					pnt6D = new Pnt6D(point3D3.X, point3D3.Y, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false));
					pnt6D = new Pnt6D(camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.X - 10.0, camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.Y, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false));
					continue;
				}
				Vertices.Reverse();
				for (int l = 0; l <= Vertices.Count - 2; l++)
				{
					num5 = buCall.buVector5_0.PointAngle(Vertices[l + 1], Vertices[l]);
					point3D3 = new Point3D();
					buCall.buVector5_0.LineWithLengthAndAngle(Vertices[l], Cam.Tool.Geometry.Diameter / 2.0 + 0.0, num5 + 90.0, ref point3D3);
					pnt6D = new Pnt6D(point3D3.X, point3D3.Y, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false));
				}
				num5 = buCall.buVector5_0.PointAngle(Vertices[Vertices.Count - 2], Vertices[Vertices.Count - 1]) + 180.0;
				point3D3 = new Point3D();
				buCall.buVector5_0.LineWithLengthAndAngle(Vertices[Vertices.Count - 1], Cam.Tool.Geometry.Diameter / 2.0 + 0.0, num5 + 90.0, ref point3D3);
				pnt6D = new Pnt6D(point3D3.X, point3D3.Y, 0.0);
				camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false));
				pnt6D = new Pnt6D(camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.X + 10.0, camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.Y, 0.0);
				camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false));
			}
			else
			{
				Vertices.Reverse();
				for (int m = 0; m <= Vertices.Count - 2; m++)
				{
					double num6 = buCall.buVector5_0.PointAngle(Vertices[m + 1], Vertices[m]);
					point3D3 = new Point3D();
					buCall.buVector5_0.LineWithLengthAndAngle(Vertices[m], Cam.Tool.Geometry.Diameter / 2.0 + 0.0, num6 + 90.0, ref point3D3);
					pnt6D = new Pnt6D(point3D3.X, point3D3.Y, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false));
				}
				pnt6D = new Pnt6D(camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.X, Pars.BaseMaterialHeight + num + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
				camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 0, plungemove: false));
				pnt6D = new Pnt6D(0.0 - camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.X - 20.0, Pars.BaseMaterialHeight + num + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
				camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 0, plungemove: false));
			}
		}
		Vertices = new List<Point3D>();
		buCall.buVector5_0.Arc3Point(new Point3D((0.0 - Pars.MaterialThickness) / 2.0, Pars.TargetMaterialHeight - Pars.MaterialThickness / 3.0), new Point3D(0.0, Pars.TargetMaterialHeight), new Point3D(Pars.MaterialThickness / 2.0, Pars.TargetMaterialHeight - Pars.MaterialThickness / 3.0), Plane.XY, entityResolution, ref Vertices);
		if (Pars.VShapeAngleZigzag)
		{
			if (!(camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.X > 0.0))
			{
				Vertices.Reverse();
				for (int n = 0; n <= Vertices.Count - 2; n++)
				{
					double num7 = buCall.buVector5_0.PointAngle(Vertices[n + 1], Vertices[n]);
					point3D3 = new Point3D();
					buCall.buVector5_0.LineWithLengthAndAngle(Vertices[n], Cam.Tool.Geometry.Diameter / 2.0 + 0.0, num7 + 90.0, ref point3D3);
					pnt6D = new Pnt6D(point3D3.X, point3D3.Y, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleFinishVel, 1, plungemove: false));
				}
				pnt6D = new Pnt6D(camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.X, Pars.BaseMaterialHeight + num + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
				camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 0, plungemove: false));
			}
			else
			{
				for (int num8 = 0; num8 <= Vertices.Count - 2; num8++)
				{
					double num9 = buCall.buVector5_0.PointAngle(Vertices[num8 + 1], Vertices[num8]);
					point3D3 = new Point3D();
					buCall.buVector5_0.LineWithLengthAndAngle(Vertices[num8], Cam.Tool.Geometry.Diameter / 2.0 + 0.0, num9 - 90.0, ref point3D3);
					pnt6D = new Pnt6D(point3D3.X, point3D3.Y, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleFinishVel, 1, plungemove: false));
				}
				pnt6D = new Pnt6D(camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.X, Pars.BaseMaterialHeight + num + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
				camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 0, plungemove: false));
			}
		}
		else
		{
			Vertices.Reverse();
			for (int num10 = 0; num10 <= Vertices.Count - 2; num10++)
			{
				double num11 = buCall.buVector5_0.PointAngle(Vertices[num10 + 1], Vertices[num10]);
				point3D3 = new Point3D();
				buCall.buVector5_0.LineWithLengthAndAngle(Vertices[num10], Cam.Tool.Geometry.Diameter / 2.0 + 0.0, num11 + 90.0, ref point3D3);
				pnt6D = new Pnt6D(point3D3.X, point3D3.Y, 0.0);
				camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleFinishVel, 1, plungemove: false));
			}
			pnt6D = new Pnt6D(camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.X, Pars.BaseMaterialHeight + num + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
			camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 0, plungemove: false));
		}
		camTpPoint2.AfterCodes.Add("M32");
		if (Pars.NickEnable)
		{
			camTpPoint2.AfterCodes.Add("M40 K" + (Pars.FeedDistance + ToolNick.Geometry.Thickness / 2.0 - ToolGrinding.Geometry.Thickness / 2.0).ToString("f2"));
		}
		else
		{
			camTpPoint2.AfterCodes.Add("M40 K" + Pars.FeedDistance.ToString("f2"));
		}
		camTpPoint2.AfterCodes.Add("M31");
		Cam.CamPoints.Add(camTpPoint2);
		if (Pars.NickEnable)
		{
			camTpPoint camTpPoint4 = new camTpPoint();
			camTpPoint4.PreCodes.Add("G75");
			if (Pars.NickToolNo == 1)
			{
				camTpPoint4.PreCodes.Add("M21 K1");
			}
			if (Pars.NickToolNo == 2)
			{
				camTpPoint4.PreCodes.Add("M22 K1");
			}
			if (Pars.NickToolNo == 3)
			{
				camTpPoint4.PreCodes.Add("M23 K1");
			}
			camTpPoint4.PreCodes.Add("M154");
			camTpPoint4.PreCodes.Add("G75");
			camTpPoint4.PreCodes.Add("G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
			camTpPoint4.PreCodes.Add("G75");
			pnt6D = new Pnt6D(0.0, Pars.BaseMaterialHeight + 5.0 + ToolNick.Geometry.Diameter / 2.0, 0.0);
			camTpPoint4.Points.Add(new TpPnt9D(pnt6D, Pars.NickRoughVel, 0, plungemove: false));
			camTpPoint4.Points[camTpPoint4.Points.Count - 1].EnableAxes.Y = false;
			pnt6D = new Pnt6D(0.0, Pars.BaseMaterialHeight + 5.0 + ToolNick.Geometry.Diameter / 2.0, 0.0);
			camTpPoint4.Points.Add(new TpPnt9D(pnt6D, Pars.NickRoughVel, 0, plungemove: false));
			pnt6D = new Pnt6D(0.0, Pars.NickDepth + Pars.NickFinishDepth + ToolNick.Geometry.Diameter / 2.0, 0.0);
			camTpPoint4.Points.Add(new TpPnt9D(pnt6D, Pars.NickRoughVel, 1, plungemove: false));
			pnt6D = new Pnt6D(0.0, Pars.NickDepth + Pars.NickFinishDepth + 2.0 + ToolNick.Geometry.Diameter / 2.0, 0.0);
			camTpPoint4.Points.Add(new TpPnt9D(pnt6D, Pars.NickRoughVel, 0, plungemove: false));
			pnt6D = new Pnt6D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.NickDepth + Pars.NickFinishDepth + 2.0 + ToolNick.Geometry.Diameter / 2.0, 0.0);
			camTpPoint4.Points.Add(new TpPnt9D(pnt6D, Pars.NickRoughVel, 0, plungemove: false));
			pnt6D = new Pnt6D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.NickDepth + ToolNick.Geometry.Diameter / 2.0, 0.0);
			camTpPoint4.Points.Add(new TpPnt9D(pnt6D, Pars.NickRoughVel, 0, plungemove: false));
			pnt6D = new Pnt6D(Pars.VShapeHeightWidth / 2.0, Pars.NickDepth + ToolNick.Geometry.Diameter / 2.0, 0.0);
			camTpPoint4.Points.Add(new TpPnt9D(pnt6D, Pars.NickFinishVel, 1, plungemove: false));
			pnt6D = new Pnt6D(Pars.VShapeHeightWidth / 2.0, Pars.BaseMaterialHeight + 10.0 + ToolNick.Geometry.Diameter / 2.0, 0.0);
			camTpPoint4.Points.Add(new TpPnt9D(pnt6D, Pars.NickRoughVel, 0, plungemove: false));
			camTpPoint4.AfterCodes.Add("M32");
			camTpPoint4.AfterCodes.Add("M40 K" + Pars.FeedDistance.ToString("f2"));
			camTpPoint4.AfterCodes.Add("M31");
			Cam.CamPoints.Add(camTpPoint4);
		}
		buCall.buCam5_0.CreateSimulationPointsFromCamPoint(ref Cam, camTpPoint2, 0.9, 0.2);
	}

	public void doGrindingVShape1(DiemakerGrindingShapeSettings Pars, ToolBase5 ToolGrinding, ToolBase5 ToolNick, ref List<Entity> calcEntities, ref camTp Cam)
	{
		Cam = new camTp();
		double num = 0.0;
		double num2 = 0.0;
		new Point3D();
		new Point3D();
		Point3D point3D = new Point3D();
		Point3D point3D2 = new Point3D();
		Point3D point3D3 = new Point3D();
		Point3D point3D4 = new Point3D();
		Point3D EndPnt = new Point3D();
		Point3D EndPnt2 = new Point3D();
		Point3D point3D5 = new Point3D();
		Entity rectangleEntity = null;
		buCall.buVector5_0.DrawRectangle(new Point3D(), Pars.MaterialThickness, Pars.BaseMaterialHeight, Plane.XY, ref rectangleEntity);
		rectangleEntity.Translate((0.0 - Pars.MaterialThickness) / 2.0, 0.0);
		calcEntities.Add(rectangleEntity);
		double num3 = Pars.MaterialThickness / 2.0 / Math.Tan(buConversion5.DegreeToRadian(Pars.VShapeTargetAngle / 2.0));
		List<Point3D> list = new List<Point3D>();
		list.Add(new Point3D((0.0 - Pars.MaterialThickness) / 2.0, 0.0));
		list.Add(new Point3D((0.0 - Pars.MaterialThickness) / 2.0, Pars.TargetMaterialHeight - num3));
		list.Add(new Point3D(Pars.MaterialThickness / 2.0 - Pars.MaterialThickness / 2.0, Pars.TargetMaterialHeight));
		list.Add(new Point3D(Pars.MaterialThickness - Pars.MaterialThickness / 2.0, Pars.TargetMaterialHeight - num3));
		list.Add(new Point3D(Pars.MaterialThickness - Pars.MaterialThickness / 2.0, 0.0));
		list.Add(new Point3D((0.0 - Pars.MaterialThickness) / 2.0, 0.0));
		buCall.buVector5_0.MiddlePointOfLine(list[1], list[2]);
		buCall.buVector5_0.MiddlePointOfLine(list[2], list[3]);
		LinearPath linearPath = new LinearPath(list);
		linearPath.ColorMethod = colorMethodType.byEntity;
		linearPath.Color = Color.Lime;
		calcEntities.Add(linearPath);
		Cam.Tool = new ToolBase5(ToolGrinding);
		Cam.Tool.Geometry.GeometryType = ToolType.Flat;
		Cam.Tool.Geometry.Length = ToolGrinding.Geometry.Thickness;
		Cam.Tool.Geometry.Thickness = 2.0;
		double num4 = 5.0;
		camTpPoint camTpPoint2 = new camTpPoint();
		Pnt6D pnt6D = new Pnt6D();
		TpPnt9D tpPnt9D = new TpPnt9D();
		double num5 = Pars.BaseMaterialHeight - Pars.TargetMaterialHeight - Pars.VShapeHeightFinishDepth;
		int num6 = Convert.ToInt32(buNumeric5.RoundToUpper(num5 / Pars.VShapeHeightRoughDepth));
		double num7 = Math.Round(num5 / (double)num6, 3);
		double x = 0.0;
		double num8 = ToolGrinding.Geometry.Thickness - ToolNick.Geometry.Thickness;
		int num9 = (int)buNumeric5.RoundToUpper(Pars.GrindingLength / num8);
		double num10 = 0.0;
		if (Pars.NickEnable)
		{
			camTpPoint camTpPoint3 = new camTpPoint();
			camTpPoint3.PreCodes.Add("G75");
			if (Pars.NickToolNo == 1)
			{
				camTpPoint3.PreCodes.Add("M21 K1");
			}
			if (Pars.NickToolNo == 2)
			{
				camTpPoint3.PreCodes.Add("M22 K1");
			}
			if (Pars.NickToolNo == 3)
			{
				camTpPoint3.PreCodes.Add("M23 K1");
			}
			camTpPoint3.PreCodes.Add("M154");
			camTpPoint3.PreCodes.Add("G75");
			camTpPoint3.PreCodes.Add("G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
			camTpPoint3.PreCodes.Add("G75");
			pnt6D = new Pnt6D(0.0, Pars.BaseMaterialHeight + 5.0 + ToolNick.Geometry.Diameter / 2.0, 0.0);
			camTpPoint3.Points.Add(new TpPnt9D(pnt6D, Pars.NickRoughVel, 0, plungemove: false));
			camTpPoint3.Points[camTpPoint3.Points.Count - 1].EnableAxes.Y = false;
			pnt6D = new Pnt6D(0.0, Pars.BaseMaterialHeight + 5.0 + ToolNick.Geometry.Diameter / 2.0, 0.0);
			camTpPoint3.Points.Add(new TpPnt9D(pnt6D, Pars.NickRoughVel, 0, plungemove: false));
			pnt6D = new Pnt6D(0.0, Pars.NickDepth + Pars.NickFinishDepth + ToolNick.Geometry.Diameter / 2.0, 0.0);
			camTpPoint3.Points.Add(new TpPnt9D(pnt6D, Pars.NickRoughVel, 1, plungemove: false));
			pnt6D = new Pnt6D((0.0 - Pars.NickWidth) / 2.0, Pars.NickDepth + Pars.NickFinishDepth + 0.0 + ToolNick.Geometry.Diameter / 2.0, 0.0);
			camTpPoint3.Points.Add(new TpPnt9D(pnt6D, Pars.NickRoughVel, 0, plungemove: false));
			pnt6D = new Pnt6D((0.0 - Pars.NickWidth) / 2.0, Pars.NickDepth + ToolNick.Geometry.Diameter / 2.0, 0.0);
			camTpPoint3.Points.Add(new TpPnt9D(pnt6D, Pars.NickRoughVel, 0, plungemove: false));
			pnt6D = new Pnt6D(Pars.NickWidth / 2.0, Pars.NickDepth + ToolNick.Geometry.Diameter / 2.0, 0.0);
			camTpPoint3.Points.Add(new TpPnt9D(pnt6D, Pars.NickFinishVel, 1, plungemove: false));
			pnt6D = new Pnt6D(Pars.NickWidth / 2.0, Pars.BaseMaterialHeight + 10.0 + ToolNick.Geometry.Diameter / 2.0, 0.0);
			camTpPoint3.Points.Add(new TpPnt9D(pnt6D, Pars.NickRoughVel, 0, plungemove: false));
			x = pnt6D.X;
			camTpPoint3.AfterCodes.Add("M32");
			camTpPoint3.AfterCodes.Add("M40 K" + (ToolGrinding.Geometry.Thickness / 2.0).ToString("f2"));
			num10 += ToolGrinding.Geometry.Thickness / 2.0;
			camTpPoint3.AfterCodes.Add("M31");
			Cam.CamPoints.Add(camTpPoint3);
		}
		camTpPoint2.PreCodes.Add("G75");
		if (Pars.VShapeHeightToolNo == 1)
		{
			camTpPoint2.PreCodes.Add("M21 K1");
		}
		if (Pars.VShapeHeightToolNo == 2)
		{
			camTpPoint2.PreCodes.Add("M22 K1");
		}
		if (Pars.VShapeHeightToolNo == 3)
		{
			camTpPoint2.PreCodes.Add("M23 K1");
		}
		camTpPoint2.PreCodes.Add("M154");
		camTpPoint2.PreCodes.Add("G75");
		camTpPoint2.PreCodes.Add("G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
		camTpPoint2.PreCodes.Add("G75");
		for (int i = 1; i <= num9; i++)
		{
			pnt6D = new Pnt6D(x, Pars.BaseMaterialHeight + 10.0 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
			tpPnt9D = new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 0, plungemove: false);
			tpPnt9D.EnableAxes.X = false;
			camTpPoint2.Points.Add(tpPnt9D);
			tpPnt9D = new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 0, plungemove: false);
			camTpPoint2.Points.Add(tpPnt9D);
			if (Pars.VShapeHeightZigzag)
			{
				pnt6D = new Pnt6D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.BaseMaterialHeight + 1.0 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
				camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 0, plungemove: false));
				camTpPoint2.Points[camTpPoint2.Points.Count - 1].EnableAxes.Y = false;
				pnt6D = new Pnt6D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.BaseMaterialHeight + 1.0 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
				camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 0, plungemove: false));
			}
			for (int j = 1; j <= num6; j++)
			{
				if (Pars.VShapeHeightZigzag)
				{
					if (j % 2 != 1)
					{
						pnt6D = new Pnt6D(Pars.VShapeHeightWidth / 2.0, Pars.BaseMaterialHeight - (double)j * num7 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 1, plungemove: false));
						pnt6D = new Pnt6D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.BaseMaterialHeight - (double)j * num7 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 1, plungemove: false));
					}
					else
					{
						pnt6D = new Pnt6D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.BaseMaterialHeight - (double)j * num7 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 1, plungemove: false));
						pnt6D = new Pnt6D(Pars.VShapeHeightWidth / 2.0, Pars.BaseMaterialHeight - (double)j * num7 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 1, plungemove: false));
					}
				}
				else
				{
					pnt6D = new Pnt6D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.BaseMaterialHeight + 1.0 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 0, plungemove: false));
					pnt6D = new Pnt6D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.BaseMaterialHeight - (double)j * num7 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 1, plungemove: false));
					pnt6D = new Pnt6D(Pars.VShapeHeightWidth / 2.0, Pars.BaseMaterialHeight - (double)j * num7 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 1, plungemove: false));
					pnt6D = new Pnt6D(Pars.VShapeHeightWidth / 2.0, Pars.BaseMaterialHeight + 1.0 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 1, plungemove: false));
				}
				Line line = new Line(new Point3D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.BaseMaterialHeight - (double)j * num7), new Point3D(Pars.VShapeHeightWidth / 2.0, Pars.BaseMaterialHeight - (double)j * num7));
				line.ColorMethod = colorMethodType.byEntity;
				line.Color = Color.Cyan;
				calcEntities.Add(line);
			}
			if (Pars.VShapeHeightFinishDepth != 0.0)
			{
				if (Pars.VShapeHeightZigzag)
				{
					if (!(camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.X > 0.0))
					{
						pnt6D = new Pnt6D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.TargetMaterialHeight + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 1, plungemove: false));
						pnt6D = new Pnt6D(Pars.VShapeHeightWidth / 2.0, Pars.TargetMaterialHeight + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 1, plungemove: false));
					}
					else
					{
						pnt6D = new Pnt6D(Pars.VShapeHeightWidth / 2.0, Pars.TargetMaterialHeight + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 1, plungemove: false));
						pnt6D = new Pnt6D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.TargetMaterialHeight + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 1, plungemove: false));
					}
				}
				else
				{
					pnt6D = new Pnt6D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.BaseMaterialHeight + 1.0 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 1, plungemove: false));
					pnt6D = new Pnt6D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.TargetMaterialHeight + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 1, plungemove: false));
					pnt6D = new Pnt6D(Pars.VShapeHeightWidth / 2.0, Pars.TargetMaterialHeight + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 1, plungemove: false));
					pnt6D = new Pnt6D(Pars.VShapeHeightWidth / 2.0, Pars.BaseMaterialHeight + 1.0 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 1, plungemove: false));
				}
				Line line2 = new Line(new Point3D((0.0 - Pars.VShapeHeightWidth) / 2.0, Pars.TargetMaterialHeight), new Point3D(Pars.VShapeHeightWidth / 2.0, Pars.TargetMaterialHeight));
				line2.ColorMethod = colorMethodType.byEntity;
				line2.Color = Color.Blue;
				calcEntities.Add(line2);
			}
			if (Pars.VShapeHeightZigzag)
			{
				pnt6D = new Pnt6D(camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.X, Pars.BaseMaterialHeight + 1.0 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
				camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightRoughVel, 1, plungemove: false));
			}
			pnt6D = new Pnt6D(camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.X, Pars.BaseMaterialHeight + num4 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
			camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 0, plungemove: false));
			pnt6D = new Pnt6D(0.0 - Math.Abs(camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.X) - ToolGrinding.Geometry.Diameter / 2.0, Pars.BaseMaterialHeight + num4 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
			camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 0, plungemove: false));
			double num11 = Pars.MaterialThickness / 2.0 - Pars.VShapeAngleFinishDepth;
			int num12 = Convert.ToInt32(buNumeric5.RoundToUpper(num11 / Pars.VShapeAngleRoughDepth));
			double num13 = Math.Round(num11 / (double)num12, 3);
			double num14 = 1.0;
			Point3D point3D6 = new Point3D();
			for (int num15 = num12; num15 >= 1; num15--)
			{
				EndPnt = new Point3D();
				EndPnt2 = new Point3D();
				if (Pars.VShapeAngleUpDownMode != UpDownDirectionType.DownToUp)
				{
					point3D = buVector5.ToPoint3D(list[2]);
					point3D2 = buVector5.ToPoint3D(list[1]);
					num = buCall.buVector5_0.PointAngle(list[1], list[2]);
					buCall.buVector5_0.LineWithLengthAndAngle(point3D, (double)num15 * num13, num - 90.0, ref EndPnt);
					buCall.buVector5_0.LineWithLengthAndAngle(point3D2, (double)num15 * num13, num - 90.0, ref EndPnt2);
					point3D5 = buCall.buVector5_0.MiddlePointOfLine(EndPnt, EndPnt2);
					buCall.buVector5_0.LineWithLengthAndAngle(point3D5, Pars.VShapeAngleWidth / 2.0, num - 180.0, ref EndPnt);
					buCall.buVector5_0.LineWithLengthAndAngle(point3D5, Pars.VShapeAngleWidth / 2.0, num, ref EndPnt2);
					point3D6 = new Point3D();
					buCall.buVector5_0.LineWithLengthAndAngle(EndPnt, Cam.Tool.Geometry.Diameter / 2.0 + num14, num - 90.0, ref point3D6);
					pnt6D = new Pnt6D(point3D6.X, point3D6.Y, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false));
					point3D6 = new Point3D();
					buCall.buVector5_0.LineWithLengthAndAngle(EndPnt, Cam.Tool.Geometry.Diameter / 2.0, num - 90.0, ref point3D6);
					pnt6D = new Pnt6D(point3D6.X, point3D6.Y, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false));
					point3D6 = new Point3D();
					buCall.buVector5_0.LineWithLengthAndAngle(EndPnt2, Cam.Tool.Geometry.Diameter / 2.0, num - 90.0, ref point3D6);
					pnt6D = new Pnt6D(point3D6.X, point3D6.Y, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false));
					point3D6 = new Point3D();
					buCall.buVector5_0.LineWithLengthAndAngle(EndPnt2, Cam.Tool.Geometry.Diameter / 2.0 + num14, num - 90.0, ref point3D6);
					pnt6D = new Pnt6D(point3D6.X, point3D6.Y, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false));
				}
				else
				{
					point3D = buVector5.ToPoint3D(list[1]);
					point3D2 = buVector5.ToPoint3D(list[2]);
					num = buCall.buVector5_0.PointAngle(list[2], list[1]);
					buCall.buVector5_0.LineWithLengthAndAngle(point3D, (double)num15 * num13, num + 90.0, ref EndPnt);
					buCall.buVector5_0.LineWithLengthAndAngle(point3D2, (double)num15 * num13, num + 90.0, ref EndPnt2);
					point3D5 = buCall.buVector5_0.MiddlePointOfLine(EndPnt, EndPnt2);
					buCall.buVector5_0.LineWithLengthAndAngle(point3D5, Pars.VShapeAngleWidth / 2.0, num - 180.0, ref EndPnt);
					buCall.buVector5_0.LineWithLengthAndAngle(point3D5, Pars.VShapeAngleWidth / 2.0, num, ref EndPnt2);
					point3D6 = new Point3D();
					buCall.buVector5_0.LineWithLengthAndAngle(EndPnt, Cam.Tool.Geometry.Diameter / 2.0 + num14, num + 90.0, ref point3D6);
					pnt6D = new Pnt6D(point3D6.X, point3D6.Y, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false));
					point3D6 = new Point3D();
					buCall.buVector5_0.LineWithLengthAndAngle(EndPnt, Cam.Tool.Geometry.Diameter / 2.0, num + 90.0, ref point3D6);
					pnt6D = new Pnt6D(point3D6.X, point3D6.Y, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false));
					point3D6 = new Point3D();
					buCall.buVector5_0.LineWithLengthAndAngle(EndPnt2, Cam.Tool.Geometry.Diameter / 2.0, num + 90.0, ref point3D6);
					pnt6D = new Pnt6D(point3D6.X, point3D6.Y, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false));
					point3D6 = new Point3D();
					buCall.buVector5_0.LineWithLengthAndAngle(EndPnt2, Cam.Tool.Geometry.Diameter / 2.0 + num14, num + 90.0, ref point3D6);
					pnt6D = new Pnt6D(point3D6.X, point3D6.Y, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false));
				}
				Line line3 = new Line(EndPnt, EndPnt2);
				line3.ColorMethod = colorMethodType.byEntity;
				line3.Color = Color.Red;
				calcEntities.Add(line3);
			}
			for (int k = 1; k <= Pars.VShapeAngleFinishCount; k++)
			{
				if (Pars.VShapeAngleUpDownMode != UpDownDirectionType.DownToUp)
				{
					EndPnt = new Point3D();
					EndPnt2 = new Point3D();
					point3D5 = buCall.buVector5_0.MiddlePointOfLine(point3D, point3D2);
					buCall.buVector5_0.LineWithLengthAndAngle(point3D5, Pars.VShapeAngleWidth / 2.0, num - 180.0, ref EndPnt);
					buCall.buVector5_0.LineWithLengthAndAngle(point3D5, Pars.VShapeAngleWidth / 2.0, num, ref EndPnt2);
					point3D6 = new Point3D();
					buCall.buVector5_0.LineWithLengthAndAngle(EndPnt, Cam.Tool.Geometry.Diameter / 2.0 + num14, num - 90.0, ref point3D6);
					pnt6D = new Pnt6D(point3D6.X, point3D6.Y, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleFinishVel, 1, plungemove: false));
					point3D6 = new Point3D();
					buCall.buVector5_0.LineWithLengthAndAngle(EndPnt, Cam.Tool.Geometry.Diameter / 2.0, num - 90.0, ref point3D6);
					pnt6D = new Pnt6D(point3D6.X, point3D6.Y, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleFinishVel, 1, plungemove: false));
					point3D6 = new Point3D();
					buCall.buVector5_0.LineWithLengthAndAngle(EndPnt2, Cam.Tool.Geometry.Diameter / 2.0, num - 90.0, ref point3D6);
					pnt6D = new Pnt6D(point3D6.X, point3D6.Y, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleFinishVel, 1, plungemove: false));
					point3D6 = new Point3D();
					buCall.buVector5_0.LineWithLengthAndAngle(EndPnt2, Cam.Tool.Geometry.Diameter / 2.0 + num14, num - 90.0, ref point3D6);
					pnt6D = new Pnt6D(point3D6.X, point3D6.Y, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleFinishVel, 1, plungemove: false));
				}
				else
				{
					EndPnt = new Point3D();
					EndPnt2 = new Point3D();
					point3D5 = buCall.buVector5_0.MiddlePointOfLine(point3D, point3D2);
					buCall.buVector5_0.LineWithLengthAndAngle(point3D5, Pars.VShapeAngleWidth / 2.0, num - 180.0, ref EndPnt);
					buCall.buVector5_0.LineWithLengthAndAngle(point3D5, Pars.VShapeAngleWidth / 2.0, num, ref EndPnt2);
					point3D6 = new Point3D();
					buCall.buVector5_0.LineWithLengthAndAngle(EndPnt, Cam.Tool.Geometry.Diameter / 2.0 + num14, num + 90.0, ref point3D6);
					pnt6D = new Pnt6D(point3D6.X, point3D6.Y, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleFinishVel, 1, plungemove: false));
					point3D6 = new Point3D();
					buCall.buVector5_0.LineWithLengthAndAngle(EndPnt, Cam.Tool.Geometry.Diameter / 2.0, num + 90.0, ref point3D6);
					pnt6D = new Pnt6D(point3D6.X, point3D6.Y, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleFinishVel, 1, plungemove: false));
					point3D6 = new Point3D();
					buCall.buVector5_0.LineWithLengthAndAngle(EndPnt2, Cam.Tool.Geometry.Diameter / 2.0, num + 90.0, ref point3D6);
					pnt6D = new Pnt6D(point3D6.X, point3D6.Y, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleFinishVel, 1, plungemove: false));
					point3D6 = new Point3D();
					buCall.buVector5_0.LineWithLengthAndAngle(EndPnt2, Cam.Tool.Geometry.Diameter / 2.0 + num14, num + 90.0, ref point3D6);
					pnt6D = new Pnt6D(point3D6.X, point3D6.Y, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleFinishVel, 1, plungemove: false));
				}
			}
			Line line4 = new Line(EndPnt, EndPnt2);
			line4.ColorMethod = colorMethodType.byEntity;
			line4.Color = Color.Red;
			calcEntities.Add(line4);
			pnt6D = new Pnt6D(camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.X, Pars.BaseMaterialHeight + num4 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
			camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 0, plungemove: false));
			pnt6D = new Pnt6D(Cam.Tool.Geometry.Diameter / 2.0 + 10.0, Pars.BaseMaterialHeight + num4 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
			camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 0, plungemove: false));
			num11 = Pars.MaterialThickness / 2.0 - Pars.VShapeAngleFinishDepth;
			num12 = Convert.ToInt32(buNumeric5.RoundToUpper(num11 / Pars.VShapeAngleRoughDepth));
			num13 = Math.Round(num11 / (double)num12, 3);
			int num16 = 0;
			for (int num17 = num12; num17 >= 1; num17--)
			{
				if (Pars.VShapeAngleUpDownMode != UpDownDirectionType.DownToUp)
				{
					point3D3 = buVector5.ToPoint3D(list[2]);
					point3D4 = buVector5.ToPoint3D(list[3]);
					num2 = buCall.buVector5_0.PointAngle(list[3], list[2]);
					EndPnt = new Point3D();
					EndPnt2 = new Point3D();
					buCall.buVector5_0.LineWithLengthAndAngle(point3D3, (double)num17 * num13, num2 + 90.0, ref EndPnt);
					buCall.buVector5_0.LineWithLengthAndAngle(point3D4, (double)num17 * num13, num2 + 90.0, ref EndPnt2);
					point3D5 = buCall.buVector5_0.MiddlePointOfLine(EndPnt, EndPnt2);
					buCall.buVector5_0.LineWithLengthAndAngle(point3D5, Pars.VShapeAngleWidth / 2.0, num2 - 180.0, ref EndPnt);
					buCall.buVector5_0.LineWithLengthAndAngle(point3D5, Pars.VShapeAngleWidth / 2.0, num2, ref EndPnt2);
					point3D6 = new Point3D();
					buCall.buVector5_0.LineWithLengthAndAngle(EndPnt, Cam.Tool.Geometry.Diameter / 2.0 + num14, num2 + 90.0, ref point3D6);
					pnt6D = new Pnt6D(point3D6.X, point3D6.Y, 0.0);
					if (num16 != 0)
					{
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false));
					}
					else
					{
						tpPnt9D = new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false);
						if (Pars.VShapeHeightToolNo == 1)
						{
							tpPnt9D.PreCodes.Add("M21 K-1");
						}
						if (Pars.VShapeHeightToolNo == 2)
						{
							tpPnt9D.PreCodes.Add("M22 K-1");
						}
						if (Pars.VShapeHeightToolNo == 3)
						{
							tpPnt9D.PreCodes.Add("M23 K-1");
						}
						camTpPoint2.Points.Add(tpPnt9D);
					}
					point3D6 = new Point3D();
					buCall.buVector5_0.LineWithLengthAndAngle(EndPnt, Cam.Tool.Geometry.Diameter / 2.0, num2 + 90.0, ref point3D6);
					pnt6D = new Pnt6D(point3D6.X, point3D6.Y, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false));
					point3D6 = new Point3D();
					buCall.buVector5_0.LineWithLengthAndAngle(EndPnt2, Cam.Tool.Geometry.Diameter / 2.0, num2 + 90.0, ref point3D6);
					pnt6D = new Pnt6D(point3D6.X, point3D6.Y, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false));
					point3D6 = new Point3D();
					buCall.buVector5_0.LineWithLengthAndAngle(EndPnt2, Cam.Tool.Geometry.Diameter / 2.0 + num14, num2 + 90.0, ref point3D6);
					pnt6D = new Pnt6D(point3D6.X, point3D6.Y, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false));
					Line line5 = new Line(EndPnt, EndPnt2);
					line5.ColorMethod = colorMethodType.byEntity;
					line5.Color = Color.Red;
					calcEntities.Add(line5);
					num16++;
				}
				else
				{
					num2 = buCall.buVector5_0.PointAngle(list[2], list[3]);
					point3D3 = buVector5.ToPoint3D(list[3]);
					point3D4 = buVector5.ToPoint3D(list[2]);
					EndPnt = new Point3D();
					EndPnt2 = new Point3D();
					buCall.buVector5_0.LineWithLengthAndAngle(point3D3, (double)num17 * num13, num2 - 90.0, ref EndPnt);
					buCall.buVector5_0.LineWithLengthAndAngle(point3D4, (double)num17 * num13, num2 - 90.0, ref EndPnt2);
					point3D5 = buCall.buVector5_0.MiddlePointOfLine(EndPnt, EndPnt2);
					buCall.buVector5_0.LineWithLengthAndAngle(point3D5, Pars.VShapeAngleWidth / 2.0, num2 - 180.0, ref EndPnt);
					buCall.buVector5_0.LineWithLengthAndAngle(point3D5, Pars.VShapeAngleWidth / 2.0, num2, ref EndPnt2);
					point3D6 = new Point3D();
					buCall.buVector5_0.LineWithLengthAndAngle(EndPnt, Cam.Tool.Geometry.Diameter / 2.0 + num14, num2 - 90.0, ref point3D6);
					pnt6D = new Pnt6D(point3D6.X, point3D6.Y, 0.0);
					if (num16 != 0)
					{
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false));
					}
					else
					{
						tpPnt9D = new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false);
						if (Pars.VShapeHeightToolNo == 1)
						{
							tpPnt9D.PreCodes.Add("M21 K-1");
						}
						if (Pars.VShapeHeightToolNo == 2)
						{
							tpPnt9D.PreCodes.Add("M22 K-1");
						}
						if (Pars.VShapeHeightToolNo == 3)
						{
							tpPnt9D.PreCodes.Add("M23 K-1");
						}
						camTpPoint2.Points.Add(tpPnt9D);
					}
					point3D6 = new Point3D();
					buCall.buVector5_0.LineWithLengthAndAngle(EndPnt, Cam.Tool.Geometry.Diameter / 2.0, num2 - 90.0, ref point3D6);
					pnt6D = new Pnt6D(point3D6.X, point3D6.Y, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false));
					point3D6 = new Point3D();
					buCall.buVector5_0.LineWithLengthAndAngle(EndPnt2, Cam.Tool.Geometry.Diameter / 2.0, num2 - 90.0, ref point3D6);
					pnt6D = new Pnt6D(point3D6.X, point3D6.Y, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false));
					point3D6 = new Point3D();
					buCall.buVector5_0.LineWithLengthAndAngle(EndPnt2, Cam.Tool.Geometry.Diameter / 2.0 + num14, num2 - 90.0, ref point3D6);
					pnt6D = new Pnt6D(point3D6.X, point3D6.Y, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleRoughVel, 1, plungemove: false));
					Line line6 = new Line(EndPnt, EndPnt2);
					line6.ColorMethod = colorMethodType.byEntity;
					line6.Color = Color.Red;
					calcEntities.Add(line6);
					num16++;
				}
			}
			for (int l = 1; l <= Pars.VShapeAngleFinishCount; l++)
			{
				if (Pars.VShapeAngleUpDownMode != UpDownDirectionType.DownToUp)
				{
					EndPnt = new Point3D();
					EndPnt2 = new Point3D();
					point3D5 = buCall.buVector5_0.MiddlePointOfLine(point3D3, point3D4);
					buCall.buVector5_0.LineWithLengthAndAngle(point3D5, Pars.VShapeAngleWidth / 2.0, num2 - 180.0, ref EndPnt);
					buCall.buVector5_0.LineWithLengthAndAngle(point3D5, Pars.VShapeAngleWidth / 2.0, num2, ref EndPnt2);
					point3D6 = new Point3D();
					buCall.buVector5_0.LineWithLengthAndAngle(EndPnt, Cam.Tool.Geometry.Diameter / 2.0 + num14, num2 + 90.0, ref point3D6);
					pnt6D = new Pnt6D(point3D6.X, point3D6.Y, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleFinishVel, 1, plungemove: false));
					point3D6 = new Point3D();
					buCall.buVector5_0.LineWithLengthAndAngle(EndPnt, Cam.Tool.Geometry.Diameter / 2.0, num2 + 90.0, ref point3D6);
					pnt6D = new Pnt6D(point3D6.X, point3D6.Y, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleFinishVel, 1, plungemove: false));
					point3D6 = new Point3D();
					buCall.buVector5_0.LineWithLengthAndAngle(EndPnt2, Cam.Tool.Geometry.Diameter / 2.0, num2 + 90.0, ref point3D6);
					pnt6D = new Pnt6D(point3D6.X, point3D6.Y, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleFinishVel, 1, plungemove: false));
					point3D6 = new Point3D();
					buCall.buVector5_0.LineWithLengthAndAngle(EndPnt2, Cam.Tool.Geometry.Diameter / 2.0 + num14, num2 + 90.0, ref point3D6);
					pnt6D = new Pnt6D(point3D6.X, point3D6.Y, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleFinishVel, 1, plungemove: false));
				}
				else
				{
					EndPnt = new Point3D();
					EndPnt2 = new Point3D();
					point3D5 = buCall.buVector5_0.MiddlePointOfLine(point3D3, point3D4);
					buCall.buVector5_0.LineWithLengthAndAngle(point3D5, Pars.VShapeAngleWidth / 2.0, num2 - 180.0, ref EndPnt);
					buCall.buVector5_0.LineWithLengthAndAngle(point3D5, Pars.VShapeAngleWidth / 2.0, num2, ref EndPnt2);
					point3D6 = new Point3D();
					buCall.buVector5_0.LineWithLengthAndAngle(EndPnt, Cam.Tool.Geometry.Diameter / 2.0 + num14, num2 - 90.0, ref point3D6);
					pnt6D = new Pnt6D(point3D6.X, point3D6.Y, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleFinishVel, 1, plungemove: false));
					point3D6 = new Point3D();
					buCall.buVector5_0.LineWithLengthAndAngle(EndPnt, Cam.Tool.Geometry.Diameter / 2.0, num2 - 90.0, ref point3D6);
					pnt6D = new Pnt6D(point3D6.X, point3D6.Y, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleFinishVel, 1, plungemove: false));
					point3D6 = new Point3D();
					buCall.buVector5_0.LineWithLengthAndAngle(EndPnt2, Cam.Tool.Geometry.Diameter / 2.0, num2 - 90.0, ref point3D6);
					pnt6D = new Pnt6D(point3D6.X, point3D6.Y, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleFinishVel, 1, plungemove: false));
					point3D6 = new Point3D();
					buCall.buVector5_0.LineWithLengthAndAngle(EndPnt2, Cam.Tool.Geometry.Diameter / 2.0 + num14, num2 - 90.0, ref point3D6);
					pnt6D = new Pnt6D(point3D6.X, point3D6.Y, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeAngleFinishVel, 1, plungemove: false));
					pnt6D = new Pnt6D(camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.X, Pars.BaseMaterialHeight + num4 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 0, plungemove: false));
				}
			}
			pnt6D = new Pnt6D(camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.X, Pars.BaseMaterialHeight + num4 + Cam.Tool.Geometry.Diameter / 2.0, 0.0);
			camTpPoint2.Points.Add(new TpPnt9D(pnt6D, Pars.VShapeHeightFinishVel, 0, plungemove: false));
			Line line7 = new Line(EndPnt, EndPnt2);
			line7.ColorMethod = colorMethodType.byEntity;
			line7.Color = Color.Red;
			calcEntities.Add(line7);
			if (Pars.NickEnable)
			{
				if (i < num9)
				{
					if (i != num9 - 1)
					{
						camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M32");
						camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M40 K" + num8.ToString("f2"));
						camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M31");
						num10 += num8;
					}
					else
					{
						camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M32");
						camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M40 K" + (Pars.GrindingLength + ToolNick.Geometry.Thickness / 2.0 - num8 * ((double)num9 - 1.0)).ToString("f2"));
						camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M31");
						num10 += Pars.GrindingLength + ToolNick.Geometry.Thickness / 2.0 - num8 * ((double)num9 - 1.0);
					}
				}
			}
			else if (i < num9)
			{
				if (i != num9 - 1)
				{
					camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M32");
					camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M40 K" + num8.ToString("f2"));
					camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M31");
					num10 += num8;
				}
				else
				{
					camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M32");
					camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M40 K" + (Pars.GrindingLength - (ToolGrinding.Geometry.Thickness + num10)).ToString("f2"));
					camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M31");
					num10 += Pars.GrindingLength - (ToolGrinding.Geometry.Thickness + num10);
				}
			}
		}
		camTpPoint2.AfterCodes.Add("M32");
		if (Pars.NickEnable)
		{
			camTpPoint2.AfterCodes.Add("M40 K" + (Pars.GrindingLength + ToolNick.Geometry.Thickness / 1.0 - num10).ToString("f2"));
			num10 += Pars.GrindingLength + ToolNick.Geometry.Thickness / 2.0 - num10;
		}
		else
		{
			camTpPoint2.AfterCodes.Add("M40 K" + (Pars.FeedDistance + ToolGrinding.Geometry.Thickness).ToString("f2"));
		}
		camTpPoint2.AfterCodes.Add("M31");
		Cam.CamPoints.Add(camTpPoint2);
		if (Pars.NickEnable)
		{
			camTpPoint camTpPoint4 = new camTpPoint();
			camTpPoint4.PreCodes.Add("G75");
			if (Pars.NickToolNo == 1)
			{
				camTpPoint4.PreCodes.Add("M21 K1");
			}
			if (Pars.NickToolNo == 2)
			{
				camTpPoint4.PreCodes.Add("M22 K1");
			}
			if (Pars.NickToolNo == 3)
			{
				camTpPoint4.PreCodes.Add("M23 K1");
			}
			camTpPoint4.PreCodes.Add("M154");
			camTpPoint4.PreCodes.Add("G75");
			camTpPoint4.PreCodes.Add("G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
			camTpPoint4.PreCodes.Add("G75");
			pnt6D = new Pnt6D(0.0, Pars.BaseMaterialHeight + 5.0 + ToolNick.Geometry.Diameter / 2.0, 0.0);
			camTpPoint4.Points.Add(new TpPnt9D(pnt6D, Pars.NickRoughVel, 0, plungemove: false));
			camTpPoint4.Points[camTpPoint4.Points.Count - 1].EnableAxes.Y = false;
			pnt6D = new Pnt6D(0.0, Pars.BaseMaterialHeight + 5.0 + ToolNick.Geometry.Diameter / 2.0, 0.0);
			camTpPoint4.Points.Add(new TpPnt9D(pnt6D, Pars.NickRoughVel, 0, plungemove: false));
			pnt6D = new Pnt6D(0.0, Pars.NickDepth + Pars.NickFinishDepth + ToolNick.Geometry.Diameter / 2.0, 0.0);
			camTpPoint4.Points.Add(new TpPnt9D(pnt6D, Pars.NickRoughVel, 1, plungemove: false));
			pnt6D = new Pnt6D((0.0 - Pars.NickWidth) / 2.0, Pars.NickDepth + Pars.NickFinishDepth + 0.0 + ToolNick.Geometry.Diameter / 2.0, 0.0);
			camTpPoint4.Points.Add(new TpPnt9D(pnt6D, Pars.NickRoughVel, 0, plungemove: false));
			pnt6D = new Pnt6D((0.0 - Pars.NickWidth) / 2.0, Pars.NickDepth + ToolNick.Geometry.Diameter / 2.0, 0.0);
			camTpPoint4.Points.Add(new TpPnt9D(pnt6D, Pars.NickRoughVel, 0, plungemove: false));
			pnt6D = new Pnt6D(Pars.NickWidth / 2.0, Pars.NickDepth + ToolNick.Geometry.Diameter / 2.0, 0.0);
			camTpPoint4.Points.Add(new TpPnt9D(pnt6D, Pars.NickFinishVel, 1, plungemove: false));
			pnt6D = new Pnt6D(Pars.NickWidth / 2.0, Pars.BaseMaterialHeight + 10.0 + ToolNick.Geometry.Diameter / 2.0, 0.0);
			camTpPoint4.Points.Add(new TpPnt9D(pnt6D, Pars.NickRoughVel, 0, plungemove: false));
			camTpPoint4.AfterCodes.Add("M32");
			camTpPoint4.AfterCodes.Add("M40 K" + (Pars.FeedDistance + ToolNick.Geometry.Thickness).ToString("f2"));
			camTpPoint4.AfterCodes.Add("M31");
			Cam.CamPoints.Add(camTpPoint4);
		}
		Cam.PreCodes.Add("//Count = " + Pars.FeedCount);
		buCall.buCam5_0.CreateSimulationPointsFromCamPoint(ref Cam, camTpPoint2, 0.9, 0.2);
	}
}
