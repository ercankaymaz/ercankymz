using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using buClass;
using buControls.Forms.WinControlForms.Notepad;
using buEyeBaseVer5;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using ns8;

namespace buCadCamResVer5.ToolGrinding;

public class clsToolGrinding
{
	public static Design viewportAuto;

	private Entity entity_0 = null;

	public void Init()
	{
		clsFiles.OpenMachineConfig(AppPath.MachineSimConfig + "\\Machine.bumachdef", ref ccVars.SimMachine);
	}

	public void InitSimulation()
	{
	}

	public void cmdFlatMilling()
	{
		tt5();
	}

	public void rr()
	{
		double num = 10.0;
		double num2 = 50.0;
		double num3 = 30.0;
		int num4 = 1;
		int num5 = 4;
		List<Point3D> list = new List<Point3D>();
		int num6 = 36;
		int num7 = 10;
		for (int i = 0; i <= num6; i++)
		{
			double num8 = Math.PI * 2.0 * (double)i / (double)num6;
			for (int j = 0; j <= num7; j++)
			{
				double num9 = num2 * (double)j / (double)num7;
				double x = num * Math.Cos(num8);
				double y = num * Math.Sin(num8);
				double z = num9;
				list.Add(new Point3D(x, y, z));
			}
		}
		List<Point3D>[] array = new List<Point3D>[num5];
		int num10 = 100;
		for (int k = 0; k < num5; k++)
		{
			array[k] = new List<Point3D>();
			double num11 = Math.PI * 2.0 * (double)k / (double)num5;
			for (int l = 0; l <= num10; l++)
			{
				double num12 = (double)(num4 * 2) * Math.PI * (double)l / (double)num10;
				double x2 = num * Math.Cos(num12 + num11);
				double y2 = num * Math.Sin(num12 + num11);
				double z2 = num3 * num12 / (Math.PI * 2.0);
				array[k].Add(new Point3D(x2, y2, z2));
			}
		}
		List<Point3D> list2 = new List<Point3D>();
		int num13 = 36;
		for (int m = 0; m <= num13; m++)
		{
			double num14 = Math.PI * 2.0 * (double)m / (double)num13;
			double x3 = num * Math.Cos(num14);
			double y3 = num * Math.Sin(num14);
			double z3 = num2;
			list2.Add(new Point3D(x3, y3, z3));
		}
	}

	public void tt1()
	{
		try
		{
			double num = 10.0;
			double num2 = 30.0;
			int num3 = 4;
			int uDegree = 2;
			int vDegree = 3;
			int num4 = 10;
			Point4D[,] array = new Point4D[4, 11];
			for (int i = 0; i < num3; i++)
			{
				double num5 = Math.PI * 2.0 * (double)i / (double)num3;
				for (int j = 0; j <= num4; j++)
				{
					double num6 = (double)j / (double)num4 * 2.0 * Math.PI;
					double x = num * Math.Cos(num6 + num5);
					double y = num * Math.Sin(num6 + num5);
					double z = num2 * num6 / (Math.PI * 2.0);
					array[i, j] = new Point4D(x, y, z, 1.0);
				}
			}
			double[] uKnotVector = new double[7] { 0.0, 0.0, 0.0, 1.0, 1.0, 1.0, 1.0 };
			double[] vKnotVector = new double[15]
			{
				0.0, 0.0, 0.0, 0.0, 0.0, 0.25, 0.5, 0.75, 1.0, 1.0,
				1.0, 1.0, 1.0, 1.0, 1.0
			};
			Surface item = new Surface(uDegree, uKnotVector, vDegree, vKnotVector, array);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(item);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
		}
		catch (Exception)
		{
		}
	}

	public void tt()
	{
		try
		{
			double num = 10.0;
			double num2 = 30.0;
			int num3 = 4;
			int num4 = 2;
			int num5 = 3;
			int num6 = 10;
			Point4D[,] array = new Point4D[4, 11];
			for (int i = 0; i < num3; i++)
			{
				double num7 = Math.PI * 2.0 * (double)i / (double)num3;
				for (int j = 0; j <= num6; j++)
				{
					double num8 = (double)j / (double)num6 * 2.0 * Math.PI;
					double x = num * Math.Cos(num8 + num7);
					double y = num * Math.Sin(num8 + num7);
					double z = num2 * num8 / (Math.PI * 2.0);
					array[i, j] = new Point4D(x, y, z, 1.0);
				}
			}
			double[] array2 = new double[num3 + num4 + 1];
			double[] array3 = new double[num6 + num5 + 1 + 1];
			for (int k = 0; k < array2.Length; k++)
			{
				array2[k] = (double)k / (double)(array2.Length - 1);
			}
			for (int l = 0; l < array3.Length; l++)
			{
				array3[l] = (double)l / (double)(array3.Length - 1);
			}
			Surface surface = new Surface(2, array2, 3, array3, array);
			surface.LayerName = "Surface";
			surface.ColorMethod = colorMethodType.byLayer;
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(surface);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
		}
		catch (Exception)
		{
		}
	}

	public void tt2()
	{
		try
		{
			double num = 10.0;
			double num2 = 30.0;
			int num3 = 4;
			int uDegree = 2;
			int num4 = 3;
			int num5 = 10;
			List<Surface> list = new List<Surface>();
			for (int i = 0; i < num3; i++)
			{
				Point4D[,] array = new Point4D[num3, num5 + 1];
				double num6 = Math.PI * 2.0 * (double)i / (double)num3;
				for (int j = 0; j <= num5; j++)
				{
					double num7 = (double)j / (double)num5 * 2.0 * Math.PI;
					double x = num * Math.Cos(num7 + num6);
					double y = num * Math.Sin(num7 + num6);
					double z = num2 * num7 / (Math.PI * 2.0);
					array[i, j] = new Point4D(x, y, z, 1.0);
				}
				double[] uKnotVector = new double[7] { 0.0, 0.0, 0.0, 0.0, 1.0, 1.0, 1.0 };
				double[] array2 = new double[num5 + num4 + 1 + 1];
				for (int k = 0; k < array2.Length; k++)
				{
					array2[k] = (double)k / (double)(array2.Length - 1);
				}
				Surface item = new Surface(uDegree, uKnotVector, num4, array2, array);
				list.Add(item);
			}
			for (int l = 0; l <= list.Count - 1; l++)
			{
				list[l].LayerName = "Surface";
				list[l].ColorMethod = colorMethodType.byLayer;
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(list[l]);
			}
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
		}
		catch (Exception)
		{
			throw;
		}
	}

	public void tt3()
	{
		double num = 10.0;
		double height = 50.0;
		double num2 = 30.0;
		int num3 = 4;
		int uDegree = 2;
		int num4 = 3;
		int num5 = 10;
		Mesh.CreateCylinder(num, height, 30);
		Console.WriteLine("Tool body created.");
		new List<Surface>();
		for (int i = 0; i < num3; i++)
		{
			double num6 = Math.PI * 2.0 * (double)i / (double)num3;
			Point4D[,] array = new Point4D[4, num5 + 1];
			for (int j = 0; j < 4; j++)
			{
				for (int k = 0; k <= num5; k++)
				{
					double num7 = (double)k / (double)num5 * 2.0 * Math.PI;
					double x = num * Math.Cos(num7 + num6);
					double y = num * Math.Sin(num7 + num6);
					double z = num2 * num7 / (Math.PI * 2.0) + (double)j;
					array[j, k] = new Point4D(x, y, z, 1.0);
				}
			}
			double[] uKnotVector = new double[7] { 0.0, 0.0, 0.4, 0.8, 1.0, 1.0, 1.0 };
			double[] array2 = new double[num5 + num4 + 2];
			for (int l = 0; l < array2.Length; l++)
			{
				array2[l] = (double)l / (double)(array2.Length - 1);
			}
			Surface surface = new Surface(uDegree, uKnotVector, num4, array2, array);
			surface.LayerName = "Surface";
			surface.ColorMethod = colorMethodType.byLayer;
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(surface);
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
	}

	public void tt4()
	{
		double num = 10.0;
		double num2 = 50.0;
		double num3 = 30.0;
		double num4 = 2.0;
		int num5 = 4;
		int int_ = 2;
		int int_2 = 3;
		int num6 = 10;
		List<Entity> list = new List<Entity>();
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
		Mesh item = Mesh.CreateCylinder(num, num2, 30);
		list.Add(item);
		for (int i = 0; i < num5; i++)
		{
			double num7 = Math.PI * 2.0 * (double)i / (double)num5;
			Point4D[,] point4D_ = Class5.smethod_151(num3, num2, num, num7, num6);
			Surface surface = Class5.smethod_150(int_, int_2, num6, point4D_);
			surface.Color = Color.Green;
			surface.ColorMethod = colorMethodType.byEntity;
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(surface);
			list.Add(surface);
			Point4D[,] point4D_2 = Class5.smethod_58(num6, num2, num7, num3, num - num4);
			Surface surface2 = Class5.smethod_150(int_, int_2, num6, point4D_2);
			surface2.Color = Color.Orange;
			surface2.ColorMethod = colorMethodType.byEntity;
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(surface2);
			list.Add(surface2);
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
	}

	public void tt5()
	{
		double num = 10.0;
		double num2 = 30.0;
		double num3 = 30.0;
		double num4 = 2.0;
		int num5 = 4;
		int int_ = 3;
		int int_2 = 3;
		int num6 = 10;
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
		List<Surface> list = new List<Surface>();
		List<Surface> list2 = new List<Surface>();
		List<Surface> list3 = new List<Surface>();
		List<Surface> list4 = new List<Surface>();
		List<Surface> list5 = new List<Surface>();
		Mesh.CreateCylinder(num, num2, 30);
		num5 = 4;
		num5 = 4;
		for (int i = 0; i < num5; i++)
		{
			double num7 = Math.PI * 2.0 * (double)i / (double)num5 + buConversion5.DegreeToRadian(0.0);
			Point4D[,] array = Class5.smethod_34(4.0, num6, num3, 0.0, num, num7);
			Point4D[,] array2 = Class5.smethod_211(num6, 4.0, num3, num7, num, 2.0, num4);
			Point4D[,] array3 = Class5.smethod_208(num6, num4, num7, num3, num, 7.0, 0.5);
			Point4D[,] array4 = Class5.smethod_112(0.0, num7, num6, num3, num4, 7.5, num);
			for (int j = 0; j <= num6; j++)
			{
				array2[0, j] = array[3, j];
			}
			for (int k = 0; k <= num6; k++)
			{
				array3[0, k] = array2[3, k];
			}
			for (int l = 0; l <= num6; l++)
			{
				array4[0, l] = array3[3, l];
			}
			Surface surface = Class5.smethod_150(int_, int_2, num6, array);
			Surface surface2 = Class5.smethod_150(int_, int_2, num6, array2);
			Surface surface3 = Class5.smethod_150(int_, int_2, num6, array3);
			Surface surface4 = Class5.smethod_150(int_, int_2, num6, array4);
			surface.Color = Color.Green;
			surface.ColorMethod = colorMethodType.byEntity;
			surface2.Color = Color.Orange;
			surface2.ColorMethod = colorMethodType.byEntity;
			surface3.Color = Color.LightBlue;
			surface3.ColorMethod = colorMethodType.byEntity;
			surface4.Color = Color.LightCoral;
			surface4.ColorMethod = colorMethodType.byEntity;
			if (i < 0)
			{
			}
			list3.Add(surface);
			list2.Add(surface2);
			list4.Add(surface3);
			list5.Add(surface4);
		}
		List<Point3D> list6 = new List<Point3D>();
		list6.Add(new Point3D(0.0, 0.0, 26.5));
		list6.Add(new Point3D(-0.5, 0.0, 26.5));
		list6.Add(new Point3D(-0.5, -5.0, 26.5));
		list6.Add(new Point3D(-3.0, -5.0, 26.5));
		list6.Add(new Point3D(-3.0, -10.0, 26.5));
		list6.Add(new Point3D(0.0, -10.0, 26.5));
		list6.Add(new Point3D(0.0, 0.0, 26.5));
		LinearPath outerContour = new LinearPath(list6);
		Circle outerContour2 = new Circle(new Point3D(0.0, 0.0, 27.0), 10.0);
		Surface surface5 = Surface.CreatePlanar(outerContour);
		Surface g = Surface.CreatePlanar(outerContour2);
		double num8 = 26.99;
		List<buEntity> BaseRefEntities = new List<buEntity>();
		Brep brep = Brep.CreateCylinder(num - 0.4, num2 - 10.0, 0.1);
		brep.Translate(0.0, 0.0, -10.0);
		brep.Color = Color.Gray;
		brep.ColorMethod = colorMethodType.byEntity;
		Surface[] array5 = brep.ConvertToSurfaces();
		array5[1].TrimBy(list3, 0.01, flipSide: false);
		for (int m = 0; m <= list2.Count - 1; m++)
		{
			Surface surface6 = list2[m];
			surface6.TrimBy(g, 0.01, flipSide: false);
			surface6.TrimBy(array5[2], 0.01, flipSide: true);
			surface6.Regen(0.01);
			List<Point3D> list7 = new List<Point3D>();
			for (int n = 0; n <= surface6.Vertices.Length - 1; n++)
			{
				if (surface6.Vertices[n].Z >= num8)
				{
					list7.Add(surface6.Vertices[n]);
				}
			}
			if (list7.Count > 0)
			{
				buLinearPath item = new buLinearPath(list7);
				BaseRefEntities.Add(item);
			}
			if (surface6.Trimming != null)
			{
				surface6.Trimming.Regen(0.01);
				for (int num9 = 0; num9 <= surface6.Trimming.ContourList.Count - 1; num9++)
				{
					if (surface6.Trimming.ContourList[num9] is CompositeCurve)
					{
						_ = surface6.Trimming.ContourList[num9] is CompositeCurve;
					}
				}
				if (surface6.Trimming.Vertices != null)
				{
					LinearPath linearPath = new LinearPath(surface6.Trimming.Vertices);
					linearPath.LayerName = "Draw";
				}
			}
			list.Add(surface6);
		}
		for (int num10 = 0; num10 <= list3.Count - 1; num10++)
		{
			Surface surface7 = list3[num10];
			surface7.TrimBy(g, 0.01, flipSide: false);
			surface7.TrimBy(array5[2], 0.01, flipSide: true);
			surface7.Regen(0.01);
			List<Point3D> list8 = new List<Point3D>();
			for (int num11 = 0; num11 <= surface7.Vertices.Length - 1; num11++)
			{
				if (surface7.Vertices[num11].Z >= num8)
				{
					list8.Add(surface7.Vertices[num11]);
				}
			}
			if (list8.Count > 0)
			{
				buLinearPath item2 = new buLinearPath(list8);
				BaseRefEntities.Add(item2);
			}
			list.Add(surface7);
		}
		for (int num12 = 0; num12 <= list4.Count - 1; num12++)
		{
			Surface surface8 = list4[num12];
			surface8.TrimBy(g, 0.01, flipSide: false);
			surface8.TrimBy(array5[2], 0.01, flipSide: true);
			surface8.Regen(0.01);
			surface8.Regen(0.01);
			List<Point3D> list9 = new List<Point3D>();
			for (int num13 = 0; num13 <= surface8.Vertices.Length - 1; num13++)
			{
				if (surface8.Vertices[num13].Z >= num8)
				{
					list9.Add(surface8.Vertices[num13]);
				}
			}
			if (list9.Count > 0)
			{
				list9.RemoveAt(list9.Count - 1);
				buLinearPath item3 = new buLinearPath(list9);
				BaseRefEntities.Add(item3);
			}
			list.Add(surface8);
		}
		for (int num14 = 0; num14 <= list5.Count - 1; num14++)
		{
			Surface surface9 = list5[num14];
			surface9.TrimBy(g, 0.01, flipSide: false);
			surface9.TrimBy(array5[2], 0.01, flipSide: true);
			surface9.Regen(0.01);
			List<Point3D> list10 = new List<Point3D>();
			for (int num15 = 0; num15 <= surface9.Vertices.Length - 1; num15++)
			{
				if (surface9.Vertices[num15].Z >= num8)
				{
					list10.Add(surface9.Vertices[num15]);
				}
			}
			if (list10.Count > 0)
			{
				buLinearPath item4 = new buLinearPath(list10);
				BaseRefEntities.Add(item4);
			}
			list.Add(surface9);
		}
		for (int num16 = 0; num16 <= list3.Count - 1; num16++)
		{
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(array5[1]);
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(array5[2]);
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(array5[0]);
		List<buEntity> copiedEntities = new List<buEntity>();
		buEntity.Copy(BaseRefEntities, ref copiedEntities);
		new List<Point3D>();
		new Point3D();
		List<Point3D> list11 = new List<Point3D>();
		list11.AddRange(copiedEntities[0].Vertices);
		copiedEntities.RemoveAt(0);
		for (int num17 = 0; num17 <= BaseRefEntities.Count - 1; num17++)
		{
			bool flag = false;
			for (int num18 = copiedEntities.Count - 1; num18 >= 0; num18--)
			{
				List<Point3D> PL = new List<Point3D>();
				PL.AddRange(copiedEntities[num18].Vertices);
				if (FindPoint(list11[list11.Count - 1], 0.1, ref PL))
				{
					copiedEntities.RemoveAt(num18);
					list11.AddRange(PL);
					flag = true;
					num18 = 0;
				}
			}
			if (flag)
			{
				continue;
			}
			if (!clsInit.cVector5.IsClosed(list11))
			{
				list11.RemoveAt(list11.Count - 1);
				for (int num19 = copiedEntities.Count - 1; num19 >= 0; num19--)
				{
					List<Point3D> PL2 = new List<Point3D>();
					PL2.AddRange(copiedEntities[num19].Vertices);
					if (FindPoint(list11[list11.Count - 1], 0.1, ref PL2))
					{
						copiedEntities.RemoveAt(num19);
						list11.AddRange(PL2);
						flag = true;
						num19 = 0;
					}
				}
				if (flag)
				{
					continue;
				}
				_ = list11[list11.Count - 1];
				list11.RemoveAt(list11.Count - 1);
				for (int num20 = copiedEntities.Count - 1; num20 >= 0; num20--)
				{
					List<Point3D> PL3 = new List<Point3D>();
					PL3.AddRange(copiedEntities[num20].Vertices);
					if (FindPoint(list11[list11.Count - 1], 0.1, ref PL3))
					{
						copiedEntities.RemoveAt(num20);
						list11.AddRange(PL3);
						flag = true;
						num20 = 0;
					}
				}
				if (flag)
				{
				}
			}
			else
			{
				num17 = BaseRefEntities.Count;
			}
		}
		if (clsInit.cVector5.IsClosed(list11))
		{
			LinearPath outerContour3 = new LinearPath(list11);
			surface5 = Surface.CreatePlanar(outerContour3);
			surface5.Color = Color.LightGreen;
			surface5.ColorMethod = colorMethodType.byEntity;
		}
		for (int num21 = 0; num21 <= num5 - 1; num21++)
		{
		}
		if (BaseRefEntities.Count > 0)
		{
			SortbuSettings sortbuSettings = new SortbuSettings();
			sortbuSettings.Option.Resolution = 0.1;
			List<buEntity> SortedEntities = new List<buEntity>();
			clsInit.cVector5.SortEntitiesByRefPoint(BaseRefEntities[0].Vertices[0], ref BaseRefEntities, sortbuSettings, ref SortedEntities);
			if (SortedEntities.Count <= 0)
			{
			}
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(surface5);
		for (int num22 = 0; num22 <= list3.Count - 1; num22++)
		{
			Surface item5 = list3[num22];
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(item5);
		}
		for (int num23 = 0; num23 <= list2.Count - 1; num23++)
		{
			Surface item6 = list2[num23];
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(item6);
		}
		for (int num24 = 0; num24 <= list4.Count - 1; num24++)
		{
			Surface item7 = list4[num24];
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(item7);
		}
		for (int num25 = 0; num25 <= list5.Count - 1; num25++)
		{
			Surface item8 = list5[num25];
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(item8);
		}
		for (int num26 = 0; num26 <= BaseRefEntities.Count - 1; num26++)
		{
			Entity copiedEntity = null;
			buEntity.Copy(BaseRefEntities[num26], ref copiedEntity);
			copiedEntity.LayerName = "Draw";
			copiedEntity.LineWeightMethod = colorMethodType.byEntity;
			copiedEntity.LineWeight = 3f;
			copiedEntity.Translate(0.0, 0.0, 1.0);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(copiedEntity);
		}
		Brep.CreateCylinder(10.0, 20.0).ConvertToSurfaces();
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
	}

	public bool FindPoint(Point3D pntRef, double Resolution, ref List<Point3D> PL)
	{
		if (PL.Count >= 2)
		{
			if (buCompare5.EQ(pntRef, PL[0], Resolution))
			{
				return true;
			}
			if (buCompare5.EQ(pntRef, PL[1], Resolution))
			{
				PL.RemoveAt(0);
				return true;
			}
			if (buCompare5.EQ(pntRef, PL[PL.Count - 1], Resolution))
			{
				PL.Reverse();
				return true;
			}
			if (buCompare5.EQ(pntRef, PL[PL.Count - 2], Resolution))
			{
				PL.RemoveAt(PL.Count - 1);
				PL.Reverse();
				return true;
			}
		}
		return false;
	}

	public void tt6()
	{
		double num = 5.0;
		double num2 = 10.0;
		int num3 = 10;
		double num4 = 1.0;
		List<Point3D[]> list = new List<Point3D[]>();
		for (int i = 0; i <= num3; i++)
		{
			double num5 = (double)(i * 2) * Math.PI / (double)num3;
			double num6 = num * Math.Cos(num5);
			double num7 = num * Math.Sin(num5);
			double num8 = num2 * num5 / (Math.PI * 2.0);
			num8 = 0.0;
			Point3D point3D = new Point3D(num6, num7, num8);
			new Point3D(num6 + num4 / 2.0, num7 + num4 / 2.0, num8);
			list.Add(new Point3D[1] { point3D });
		}
		Point4D[,] array = new Point4D[list.Count, 2];
		for (int j = 0; j < list.Count; j++)
		{
			array[j, 0] = new Point4D(list[j][0].X, list[j][0].Y, list[j][0].Z, 1.0);
			array[j, 1] = new Point4D(list[j][0].X, list[j][0].Y, list[j][0].Z + 1.0, 1.0);
		}
		int uDegree = 2;
		int vDegree = 1;
		Brep.CreateCylinder(10.0, 20.0).ConvertToSurfaces();
		double[] vKnotVector = new double[4] { 0.0, 0.0, 1.0, 1.0 };
		double[] array2 = new double[num3 + 2 + 2];
		array2[0] = 0.0;
		array2[1] = 0.0;
		array2[2] = 0.0;
		for (int k = 3; k < array2.Length - 1; k++)
		{
			if (k == 3 || k == 4)
			{
				array2[k] = Math.PI / 2.0;
			}
			if (k == 5 || k == 6)
			{
				array2[k] = Math.PI;
			}
			if (k == 7 || k == 8)
			{
				array2[k] = 4.71238898038469;
			}
			if (k == 9 || k == 10 || k == 11 || k == 12)
			{
				array2[k] = Math.PI * 2.0;
			}
		}
		array2[array2.Length - 1] = Math.PI * 2.0;
		Surface item = new Surface(uDegree, array2, vDegree, vKnotVector, array);
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(item);
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
	}

	public void basicnurb()
	{
		Point4D[,] ctrlPoints = new Point4D[4, 4]
		{
			{
				new Point4D(0.0, 0.0, 0.0, 1.0),
				new Point4D(10.0, 0.0, 5.0, 1.0),
				new Point4D(20.0, 0.0, -5.0, 1.0),
				new Point4D(30.0, 0.0, 0.0, 1.0)
			},
			{
				new Point4D(0.0, 10.0, 5.0, 1.0),
				new Point4D(10.0, 10.0, 10.0, 1.0),
				new Point4D(20.0, 10.0, 0.0, 1.0),
				new Point4D(30.0, 10.0, 5.0, 1.0)
			},
			{
				new Point4D(0.0, 20.0, -5.0, 1.0),
				new Point4D(10.0, 20.0, 0.0, 1.0),
				new Point4D(20.0, 20.0, 10.0, 1.0),
				new Point4D(30.0, 20.0, -5.0, 1.0)
			},
			{
				new Point4D(0.0, 30.0, 0.0, 1.0),
				new Point4D(10.0, 30.0, 5.0, 1.0),
				new Point4D(20.0, 30.0, -5.0, 1.0),
				new Point4D(30.0, 30.0, 0.0, 1.0)
			}
		};
		double[] uKnotVector = new double[8] { 0.0, 0.0, 0.0, 0.0, 1.0, 1.0, 1.0, 1.0 };
		double[] vKnotVector = new double[8] { 0.0, 0.0, 0.0, 0.0, 1.0, 1.0, 1.0, 1.0 };
		Surface surface = new Surface(3, uKnotVector, 3, vKnotVector, ctrlPoints);
		surface.Color = Color.Green;
		surface.ColorMethod = colorMethodType.byEntity;
	}

	public void dd()
	{
		Point4D[,] ctrlPoints = new Point4D[4, 4]
		{
			{
				new Point4D(-50.0, -50.0, 0.0, 1.0),
				new Point4D(-25.0, -50.0, 25.0, 1.0),
				new Point4D(25.0, -50.0, 25.0, 1.0),
				new Point4D(50.0, -50.0, 0.0, 1.0)
			},
			{
				new Point4D(-50.0, -25.0, 25.0, 1.0),
				new Point4D(-25.0, -25.0, 50.0, 1.0),
				new Point4D(25.0, -25.0, 50.0, 1.0),
				new Point4D(50.0, -25.0, 25.0, 1.0)
			},
			{
				new Point4D(-50.0, 25.0, 25.0, 1.0),
				new Point4D(-25.0, 25.0, 50.0, 1.0),
				new Point4D(25.0, 25.0, 50.0, 1.0),
				new Point4D(50.0, 25.0, 25.0, 1.0)
			},
			{
				new Point4D(-50.0, 50.0, 0.0, 1.0),
				new Point4D(-25.0, 50.0, 25.0, 1.0),
				new Point4D(25.0, 50.0, 25.0, 1.0),
				new Point4D(50.0, 50.0, 0.0, 1.0)
			}
		};
		double[] uKnotVector = new double[8] { 0.0, 0.0, 0.0, 0.33, 0.66, 1.0, 1.0, 1.0 };
		double[] vKnotVector = new double[8] { 0.0, 0.0, 0.0, 0.33, 0.66, 1.0, 1.0, 1.0 };
		Surface item = new Surface(3, uKnotVector, 3, vKnotVector, ctrlPoints);
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(item);
		double radius = 10.0;
		double height = 30.0;
		Mesh mesh = Mesh.CreateCylinder(radius, height, 20);
		mesh.Translate(0.0, 0.0, 15.0);
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(mesh);
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
	}

	public void cmdAnalyseSelected()
	{
		for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
		{
			if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].Selected)
			{
				entity_0 = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i];
			}
		}
	}

	public void cmdFaceToSurface()
	{
		Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[0];
		if (!(entity is Brep))
		{
			return;
		}
		entity.LayerName = "Brep";
		entity.ColorMethod = colorMethodType.byLayer;
		Surface[] array = ((Brep)entity).ConvertToSurfaces();
		if (array == null)
		{
			return;
		}
		for (int i = 0; i <= array.Length - 1; i++)
		{
			if (!(array[i] is PlanarSurface))
			{
				if (!(array[i] is ConicalSurface))
				{
					if (!(array[i] is CylindricalSurface))
					{
						if (array[i] != null)
						{
							array[i].LayerName = "Surface";
							array[i].ColorMethod = colorMethodType.byLayer;
							ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(array[i]);
						}
					}
					else
					{
						array[i].LayerName = "Cylinder Surface";
						array[i].ColorMethod = colorMethodType.byLayer;
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(array[i]);
					}
				}
				else
				{
					array[i].LayerName = "Conical Surface";
					array[i].ColorMethod = colorMethodType.byLayer;
					ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(array[i]);
				}
			}
			else
			{
				array[i].LayerName = "Planar Surface";
				array[i].ColorMethod = colorMethodType.byLayer;
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(array[i]);
			}
		}
	}

	public void cmdFaceToCurve()
	{
	}

	public void cmdDrawSelected()
	{
		for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
		{
			if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].Selected)
			{
				entity_0 = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i];
			}
		}
		if (entity_0 == null || !(entity_0 is Surface))
		{
			return;
		}
		Surface surface = entity_0 as Surface;
		if (surface.Trimming != null)
		{
			for (int j = 0; j <= surface.Trimming.ContourList.Count - 1; j++)
			{
				Entity entity = (Entity)surface.Trimming.ContourList[j].Clone();
				entity.Color = Color.Black;
				entity.LayerName = "Draw";
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(entity);
			}
		}
		for (int k = 0; k <= surface.ControlPoints.Length - 1; k++)
		{
			Line line = new Line(surface.ControlPoints[k, 0], surface.ControlPoints[k, 1]);
			line.Color = Color.Black;
			line.LayerName = "Draw";
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(line);
		}
	}

	public void cmdDrawControlPoints()
	{
		string text = "";
		for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
		{
			if (!ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].Selected)
			{
				continue;
			}
			entity_0 = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i];
			if (!(entity_0 is Surface))
			{
				continue;
			}
			Surface surface = entity_0 as Surface;
			text = text + "Degree U : " + surface.DegreeU + " , Degree V : " + surface.DegreeV + Environment.NewLine;
			for (int j = 0; j < surface.ControlPoints.GetLength(0); j++)
			{
				for (int k = 0; k < surface.ControlPoints.GetLength(1); k++)
				{
					Point4D point4D = surface.ControlPoints[j, k];
					text = text + "[" + j + " , " + k + "] " + point4D?.ToString() + Environment.NewLine;
				}
			}
			text = text + "Knot U : " + surface.KnotVectorU.Length + Environment.NewLine;
			for (int l = 0; l <= surface.KnotVectorU.Length - 1; l++)
			{
				text = text + surface.KnotVectorU[l] + " , ";
			}
			text += Environment.NewLine;
			text = text + "Knot V : " + surface.KnotVectorV.Length + Environment.NewLine;
			for (int m = 0; m <= surface.KnotVectorV.Length - 1; m++)
			{
				text = text + surface.KnotVectorV[m] + " , ";
			}
			text += Environment.NewLine;
			for (int n = 0; n <= 3; n++)
			{
				int num = surface.KnotVectorV.Length - surface.DegreeV - 1;
				List<Point3D> list = new List<Point3D>();
				for (int num2 = 0; num2 <= num - 1; num2++)
				{
					list.Add(new Point3D(surface.ControlPoints[n, num2].X, surface.ControlPoints[n, num2].Y, surface.ControlPoints[n, num2].Z));
				}
				LinearPath linearPath = new LinearPath(list);
				linearPath.ColorMethod = colorMethodType.byLayer;
				linearPath.LayerName = "Draw";
				linearPath.LineWeight = 3f;
				linearPath.LineWeightMethod = colorMethodType.byLayer;
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(linearPath);
			}
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
		}
		F_Notepad f_Notepad = new F_Notepad();
		f_Notepad.Init(text);
		f_Notepad.Show();
	}

	public void Job_AfterSelect(object sender, TreeViewEventArgs e)
	{
	}
}
