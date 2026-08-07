// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.ToolGrinding.clsToolGrinding
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buClass;
using buControls.Forms.WinControlForms.Notepad;
using buEyeBaseVer5;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using ns8;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5.ToolGrinding;

public class clsToolGrinding
{
  public static Design viewportAuto;
  private Entity entity_0 = (Entity) null;

  public void Init()
  {
    clsFiles.OpenMachineConfig(AppPath.MachineSimConfig + "\\Machine.bumachdef", ref ccVars.SimMachine);
  }

  public void InitSimulation()
  {
  }

  public void cmdFlatMilling() => this.tt5();

  public void rr()
  {
    double num1 = 10.0;
    double num2 = 50.0;
    double num3 = 30.0;
    int num4 = 1;
    int length = 4;
    List<Point3D> point3DList1 = new List<Point3D>();
    int num5 = 36;
    int num6 = 10;
    for (int index1 = 0; index1 <= num5; ++index1)
    {
      double num7 = 2.0 * Math.PI * (double) index1 / (double) num5;
      for (int index2 = 0; index2 <= num6; ++index2)
      {
        double num8 = num2 * (double) index2 / (double) num6;
        double x = num1 * Math.Cos(num7);
        double y = num1 * Math.Sin(num7);
        double z = num8;
        point3DList1.Add(new Point3D(x, y, z));
      }
    }
    List<Point3D>[] point3DListArray = new List<Point3D>[length];
    int num9 = 100;
    for (int index3 = 0; index3 < length; ++index3)
    {
      point3DListArray[index3] = new List<Point3D>();
      double num10 = 2.0 * Math.PI * (double) index3 / (double) length;
      for (int index4 = 0; index4 <= num9; ++index4)
      {
        double num11 = (double) (num4 * 2) * Math.PI * (double) index4 / (double) num9;
        double x = num1 * Math.Cos(num11 + num10);
        double y = num1 * Math.Sin(num11 + num10);
        double z = num3 * num11 / (2.0 * Math.PI);
        point3DListArray[index3].Add(new Point3D(x, y, z));
      }
    }
    List<Point3D> point3DList2 = new List<Point3D>();
    int num12 = 36;
    for (int index = 0; index <= num12; ++index)
    {
      double num13 = 2.0 * Math.PI * (double) index / (double) num12;
      double x = num1 * Math.Cos(num13);
      double y = num1 * Math.Sin(num13);
      double z = num2;
      point3DList2.Add(new Point3D(x, y, z));
    }
  }

  public void tt1()
  {
    try
    {
      double num1 = 10.0;
      double num2 = 30.0;
      int num3 = 4;
      int uDegree = 2;
      int vDegree = 3;
      int num4 = 10;
      Point4D[,] ctrlPoints = new Point4D[4, 11];
      for (int index1 = 0; index1 < num3; ++index1)
      {
        double num5 = 2.0 * Math.PI * (double) index1 / (double) num3;
        for (int index2 = 0; index2 <= num4; ++index2)
        {
          double num6 = (double) index2 / (double) num4 * 2.0 * Math.PI;
          double x = num1 * Math.Cos(num6 + num5);
          double y = num1 * Math.Sin(num6 + num5);
          double z = num2 * num6 / (2.0 * Math.PI);
          ctrlPoints[index1, index2] = new Point4D(x, y, z, 1.0);
        }
      }
      double[] uKnotVector = new double[7]
      {
        0.0,
        0.0,
        0.0,
        1.0,
        1.0,
        1.0,
        1.0
      };
      double[] vKnotVector = new double[15]
      {
        0.0,
        0.0,
        0.0,
        0.0,
        0.0,
        0.25,
        0.5,
        0.75,
        1.0,
        1.0,
        1.0,
        1.0,
        1.0,
        1.0,
        1.0
      };
      Surface surface = new Surface(uDegree, uKnotVector, vDegree, vKnotVector, ctrlPoints);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) surface);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
    }
    catch (Exception ex)
    {
    }
  }

  public void tt()
  {
    try
    {
      double num1 = 10.0;
      double num2 = 30.0;
      int num3 = 4;
      int num4 = 2;
      int num5 = 3;
      int num6 = 10;
      Point4D[,] ctrlPoints = new Point4D[4, 11];
      for (int index1 = 0; index1 < num3; ++index1)
      {
        double num7 = 2.0 * Math.PI * (double) index1 / (double) num3;
        for (int index2 = 0; index2 <= num6; ++index2)
        {
          double num8 = (double) index2 / (double) num6 * 2.0 * Math.PI;
          double x = num1 * Math.Cos(num8 + num7);
          double y = num1 * Math.Sin(num8 + num7);
          double z = num2 * num8 / (2.0 * Math.PI);
          ctrlPoints[index1, index2] = new Point4D(x, y, z, 1.0);
        }
      }
      double[] uKnotVector = new double[num3 + num4 + 1];
      double[] vKnotVector = new double[num6 + num5 + 1 + 1];
      for (int index = 0; index < uKnotVector.Length; ++index)
        uKnotVector[index] = (double) index / (double) (uKnotVector.Length - 1);
      for (int index = 0; index < vKnotVector.Length; ++index)
        vKnotVector[index] = (double) index / (double) (vKnotVector.Length - 1);
      Surface surface = new Surface(2, uKnotVector, 3, vKnotVector, ctrlPoints);
      surface.LayerName = "Surface";
      surface.ColorMethod = colorMethodType.byLayer;
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) surface);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
    }
    catch (Exception ex)
    {
    }
  }

  public void tt2()
  {
    try
    {
      double num1 = 10.0;
      double num2 = 30.0;
      int length = 4;
      int uDegree = 2;
      int vDegree = 3;
      int num3 = 10;
      List<Surface> surfaceList = new List<Surface>();
      for (int index1 = 0; index1 < length; ++index1)
      {
        Point4D[,] ctrlPoints = new Point4D[length, num3 + 1];
        double num4 = 2.0 * Math.PI * (double) index1 / (double) length;
        for (int index2 = 0; index2 <= num3; ++index2)
        {
          double num5 = (double) index2 / (double) num3 * 2.0 * Math.PI;
          double x = num1 * Math.Cos(num5 + num4);
          double y = num1 * Math.Sin(num5 + num4);
          double z = num2 * num5 / (2.0 * Math.PI);
          ctrlPoints[index1, index2] = new Point4D(x, y, z, 1.0);
        }
        double[] uKnotVector = new double[7]
        {
          0.0,
          0.0,
          0.0,
          0.0,
          1.0,
          1.0,
          1.0
        };
        double[] vKnotVector = new double[num3 + vDegree + 1 + 1];
        for (int index3 = 0; index3 < vKnotVector.Length; ++index3)
          vKnotVector[index3] = (double) index3 / (double) (vKnotVector.Length - 1);
        Surface surface = new Surface(uDegree, uKnotVector, vDegree, vKnotVector, ctrlPoints);
        surfaceList.Add(surface);
      }
      for (int index = 0; index <= surfaceList.Count - 1; ++index)
      {
        surfaceList[index].LayerName = "Surface";
        surfaceList[index].ColorMethod = colorMethodType.byLayer;
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) surfaceList[index]);
      }
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  public void tt3()
  {
    double radius = 10.0;
    double height = 50.0;
    double num1 = 30.0;
    int num2 = 4;
    int uDegree = 2;
    int vDegree = 3;
    int num3 = 10;
    Mesh.CreateCylinder(radius, height, 30);
    Console.WriteLine("Tool body created.");
    List<Surface> surfaceList = new List<Surface>();
    for (int index1 = 0; index1 < num2; ++index1)
    {
      double num4 = 2.0 * Math.PI * (double) index1 / (double) num2;
      Point4D[,] ctrlPoints = new Point4D[4, num3 + 1];
      for (int index2 = 0; index2 < 4; ++index2)
      {
        for (int index3 = 0; index3 <= num3; ++index3)
        {
          double num5 = (double) index3 / (double) num3 * 2.0 * Math.PI;
          double x = radius * Math.Cos(num5 + num4);
          double y = radius * Math.Sin(num5 + num4);
          double z = num1 * num5 / (2.0 * Math.PI) + (double) index2;
          ctrlPoints[index2, index3] = new Point4D(x, y, z, 1.0);
        }
      }
      double[] uKnotVector = new double[7]
      {
        0.0,
        0.0,
        0.4,
        0.8,
        1.0,
        1.0,
        1.0
      };
      double[] vKnotVector = new double[num3 + vDegree + 2];
      for (int index4 = 0; index4 < vKnotVector.Length; ++index4)
        vKnotVector[index4] = (double) index4 / (double) (vKnotVector.Length - 1);
      Surface surface = new Surface(uDegree, uKnotVector, vDegree, vKnotVector, ctrlPoints);
      surface.LayerName = "Surface";
      surface.ColorMethod = colorMethodType.byLayer;
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) surface);
    }
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
  }

  public void tt4()
  {
    double num1 = 10.0;
    double num2 = 50.0;
    double num3 = 30.0;
    double num4 = 2.0;
    int num5 = 4;
    int int_0 = 2;
    int int_1 = 3;
    int num6 = 10;
    List<Entity> entityList = new List<Entity>();
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
    Mesh cylinder = Mesh.CreateCylinder(num1, num2, 30);
    entityList.Add((Entity) cylinder);
    for (int index = 0; index < num5; ++index)
    {
      double num7 = 2.0 * Math.PI * (double) index / (double) num5;
      Point4D[,] point4D_0_1 = Class5.smethod_151(num3, num2, num1, num7, num6);
      Surface surface1 = Class5.smethod_150(int_0, int_1, num6, point4D_0_1);
      surface1.Color = Color.Green;
      surface1.ColorMethod = colorMethodType.byEntity;
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) surface1);
      entityList.Add((Entity) surface1);
      Point4D[,] point4D_0_2 = Class5.smethod_58(num6, num2, num7, num3, num1 - num4);
      Surface surface2 = Class5.smethod_150(int_0, int_1, num6, point4D_0_2);
      surface2.Color = Color.Orange;
      surface2.ColorMethod = colorMethodType.byEntity;
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) surface2);
      entityList.Add((Entity) surface2);
    }
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
  }

  public void tt5()
  {
    double num1 = 10.0;
    double height = 30.0;
    double num2 = 30.0;
    double num3 = 2.0;
    int num4 = 4;
    int int_0 = 3;
    int int_1 = 3;
    int num5 = 10;
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
    List<Surface> surfaceList1 = new List<Surface>();
    List<Surface> surfaceList2 = new List<Surface>();
    List<Surface> listG = new List<Surface>();
    List<Surface> surfaceList3 = new List<Surface>();
    List<Surface> surfaceList4 = new List<Surface>();
    Mesh.CreateCylinder(num1, height, 30);
    num4 = 4;
    int num6 = 4;
    for (int index1 = 0; index1 < num6; ++index1)
    {
      double num7 = 2.0 * Math.PI * (double) index1 / (double) num6 + buConversion5.DegreeToRadian(0.0);
      Point4D[,] point4D_0_1 = Class5.smethod_34(4.0, num5, num2, 0.0, num1, num7);
      Point4D[,] point4D_0_2 = Class5.smethod_211(num5, 4.0, num2, num7, num1, 2.0, num3);
      Point4D[,] point4D_0_3 = Class5.smethod_208(num5, num3, num7, num2, num1, 7.0, 0.5);
      Point4D[,] point4D_0_4 = Class5.smethod_112(0.0, num7, num5, num2, num3, 7.5, num1);
      for (int index2 = 0; index2 <= num5; ++index2)
        point4D_0_2[0, index2] = point4D_0_1[3, index2];
      for (int index3 = 0; index3 <= num5; ++index3)
        point4D_0_3[0, index3] = point4D_0_2[3, index3];
      for (int index4 = 0; index4 <= num5; ++index4)
        point4D_0_4[0, index4] = point4D_0_3[3, index4];
      Surface surface1 = Class5.smethod_150(int_0, int_1, num5, point4D_0_1);
      Surface surface2 = Class5.smethod_150(int_0, int_1, num5, point4D_0_2);
      Surface surface3 = Class5.smethod_150(int_0, int_1, num5, point4D_0_3);
      Surface surface4 = Class5.smethod_150(int_0, int_1, num5, point4D_0_4);
      surface1.Color = Color.Green;
      surface1.ColorMethod = colorMethodType.byEntity;
      surface2.Color = Color.Orange;
      surface2.ColorMethod = colorMethodType.byEntity;
      surface3.Color = Color.LightBlue;
      surface3.ColorMethod = colorMethodType.byEntity;
      surface4.Color = Color.LightCoral;
      surface4.ColorMethod = colorMethodType.byEntity;
      if (index1 >= 0)
        ;
      listG.Add(surface1);
      surfaceList2.Add(surface2);
      surfaceList3.Add(surface3);
      surfaceList4.Add(surface4);
    }
    LinearPath outerContour1 = new LinearPath((ICollection<Point3D>) new List<Point3D>()
    {
      new Point3D(0.0, 0.0, 26.5),
      new Point3D(-0.5, 0.0, 26.5),
      new Point3D(-0.5, -5.0, 26.5),
      new Point3D(-3.0, -5.0, 26.5),
      new Point3D(-3.0, -10.0, 26.5),
      new Point3D(0.0, -10.0, 26.5),
      new Point3D(0.0, 0.0, 26.5)
    });
    Circle outerContour2 = new Circle(new Point3D(0.0, 0.0, 27.0), 10.0);
    Surface planar1 = (Surface) Surface.CreatePlanar((ICurve) outerContour1);
    Surface planar2 = (Surface) Surface.CreatePlanar((ICurve) outerContour2);
    double num8 = 26.99;
    List<buEntity> BaseRefEntities = new List<buEntity>();
    Brep cylinder = Brep.CreateCylinder(num1 - 0.4, height - 10.0, 0.1);
    cylinder.Translate(0.0, 0.0, -10.0);
    cylinder.Color = Color.Gray;
    cylinder.ColorMethod = colorMethodType.byEntity;
    Surface[] surfaces = cylinder.ConvertToSurfaces();
    int num9 = (int) surfaces[1].TrimBy((IList<Surface>) listG, 0.01, false);
    for (int index5 = 0; index5 <= surfaceList2.Count - 1; ++index5)
    {
      Surface surface = surfaceList2[index5];
      int num10 = (int) surface.TrimBy(planar2, 0.01, false);
      int num11 = (int) surface.TrimBy(surfaces[2], 0.01, true);
      surface.Regen(0.01);
      List<Point3D> points = new List<Point3D>();
      for (int index6 = 0; index6 <= surface.Vertices.Length - 1; ++index6)
      {
        if (surface.Vertices[index6].Z >= num8)
          points.Add(surface.Vertices[index6]);
      }
      if (points.Count > 0)
      {
        buLinearPath buLinearPath = new buLinearPath(points);
        BaseRefEntities.Add((buEntity) buLinearPath);
      }
      if (surface.Trimming != null)
      {
        surface.Trimming.Regen(0.01);
        for (int index7 = 0; index7 <= surface.Trimming.ContourList.Count - 1; ++index7)
        {
          if (surface.Trimming.ContourList[index7] is CompositeCurve)
          {
            CompositeCurve contour = surface.Trimming.ContourList[index7] as CompositeCurve;
          }
        }
        if (surface.Trimming.Vertices != null)
          new LinearPath(surface.Trimming.Vertices).LayerName = "Draw";
      }
      surfaceList1.Add(surface);
    }
    for (int index8 = 0; index8 <= listG.Count - 1; ++index8)
    {
      Surface surface = listG[index8];
      int num12 = (int) surface.TrimBy(planar2, 0.01, false);
      int num13 = (int) surface.TrimBy(surfaces[2], 0.01, true);
      surface.Regen(0.01);
      List<Point3D> points = new List<Point3D>();
      for (int index9 = 0; index9 <= surface.Vertices.Length - 1; ++index9)
      {
        if (surface.Vertices[index9].Z >= num8)
          points.Add(surface.Vertices[index9]);
      }
      if (points.Count > 0)
      {
        buLinearPath buLinearPath = new buLinearPath(points);
        BaseRefEntities.Add((buEntity) buLinearPath);
      }
      surfaceList1.Add(surface);
    }
    for (int index10 = 0; index10 <= surfaceList3.Count - 1; ++index10)
    {
      Surface surface = surfaceList3[index10];
      int num14 = (int) surface.TrimBy(planar2, 0.01, false);
      int num15 = (int) surface.TrimBy(surfaces[2], 0.01, true);
      surface.Regen(0.01);
      surface.Regen(0.01);
      List<Point3D> points = new List<Point3D>();
      for (int index11 = 0; index11 <= surface.Vertices.Length - 1; ++index11)
      {
        if (surface.Vertices[index11].Z >= num8)
          points.Add(surface.Vertices[index11]);
      }
      if (points.Count > 0)
      {
        points.RemoveAt(points.Count - 1);
        buLinearPath buLinearPath = new buLinearPath(points);
        BaseRefEntities.Add((buEntity) buLinearPath);
      }
      surfaceList1.Add(surface);
    }
    for (int index12 = 0; index12 <= surfaceList4.Count - 1; ++index12)
    {
      Surface surface = surfaceList4[index12];
      int num16 = (int) surface.TrimBy(planar2, 0.01, false);
      int num17 = (int) surface.TrimBy(surfaces[2], 0.01, true);
      surface.Regen(0.01);
      List<Point3D> points = new List<Point3D>();
      for (int index13 = 0; index13 <= surface.Vertices.Length - 1; ++index13)
      {
        if (surface.Vertices[index13].Z >= num8)
          points.Add(surface.Vertices[index13]);
      }
      if (points.Count > 0)
      {
        buLinearPath buLinearPath = new buLinearPath(points);
        BaseRefEntities.Add((buEntity) buLinearPath);
      }
      surfaceList1.Add(surface);
    }
    int num18 = 0;
    while (num18 <= listG.Count - 1)
      ++num18;
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) surfaces[1]);
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) surfaces[2]);
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) surfaces[0]);
    List<buEntity> copiedEntities = new List<buEntity>();
    buEntity.Copy(BaseRefEntities, ref copiedEntities);
    List<Point3D> point3DList1 = new List<Point3D>();
    Point3D point3D1 = new Point3D();
    List<Point3D> point3DList2 = new List<Point3D>();
    point3DList2.AddRange((IEnumerable<Point3D>) copiedEntities[0].Vertices);
    copiedEntities.RemoveAt(0);
    for (int index14 = 0; index14 <= BaseRefEntities.Count - 1; ++index14)
    {
      bool flag = false;
      for (int index15 = copiedEntities.Count - 1; index15 >= 0; --index15)
      {
        List<Point3D> PL = new List<Point3D>();
        PL.AddRange((IEnumerable<Point3D>) copiedEntities[index15].Vertices);
        if (this.FindPoint(point3DList2[point3DList2.Count - 1], 0.1, ref PL))
        {
          copiedEntities.RemoveAt(index15);
          point3DList2.AddRange((IEnumerable<Point3D>) PL);
          flag = true;
          index15 = 0;
        }
      }
      if (!flag)
      {
        if (clsInit.cVector5.IsClosed(point3DList2))
        {
          index14 = BaseRefEntities.Count;
        }
        else
        {
          point3DList2.RemoveAt(point3DList2.Count - 1);
          for (int index16 = copiedEntities.Count - 1; index16 >= 0; --index16)
          {
            List<Point3D> PL = new List<Point3D>();
            PL.AddRange((IEnumerable<Point3D>) copiedEntities[index16].Vertices);
            if (this.FindPoint(point3DList2[point3DList2.Count - 1], 0.1, ref PL))
            {
              copiedEntities.RemoveAt(index16);
              point3DList2.AddRange((IEnumerable<Point3D>) PL);
              flag = true;
              index16 = 0;
            }
          }
          if (!flag)
          {
            Point3D point3D2 = point3DList2[point3DList2.Count - 1];
            point3DList2.RemoveAt(point3DList2.Count - 1);
            for (int index17 = copiedEntities.Count - 1; index17 >= 0; --index17)
            {
              List<Point3D> PL = new List<Point3D>();
              PL.AddRange((IEnumerable<Point3D>) copiedEntities[index17].Vertices);
              if (this.FindPoint(point3DList2[point3DList2.Count - 1], 0.1, ref PL))
              {
                copiedEntities.RemoveAt(index17);
                point3DList2.AddRange((IEnumerable<Point3D>) PL);
                flag = true;
                index17 = 0;
              }
            }
            if (!flag)
              ;
          }
        }
      }
    }
    if (clsInit.cVector5.IsClosed(point3DList2))
    {
      planar1 = (Surface) Surface.CreatePlanar((ICurve) new LinearPath((ICollection<Point3D>) point3DList2));
      planar1.Color = Color.LightGreen;
      planar1.ColorMethod = colorMethodType.byEntity;
    }
    int num19 = 0;
    while (num19 <= num6 - 1)
      ++num19;
    if (BaseRefEntities.Count > 0)
    {
      SortbuSettings Settings = new SortbuSettings();
      Settings.Option.Resolution = 0.1;
      List<buEntity> SortedEntities = new List<buEntity>();
      clsInit.cVector5.SortEntitiesByRefPoint(BaseRefEntities[0].Vertices[0], ref BaseRefEntities, Settings, ref SortedEntities);
      if (SortedEntities.Count > 0)
        ;
    }
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) planar1);
    for (int index = 0; index <= listG.Count - 1; ++index)
    {
      Surface surface = listG[index];
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) surface);
    }
    for (int index = 0; index <= surfaceList2.Count - 1; ++index)
    {
      Surface surface = surfaceList2[index];
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) surface);
    }
    for (int index = 0; index <= surfaceList3.Count - 1; ++index)
    {
      Surface surface = surfaceList3[index];
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) surface);
    }
    for (int index = 0; index <= surfaceList4.Count - 1; ++index)
    {
      Surface surface = surfaceList4[index];
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) surface);
    }
    for (int index = 0; index <= BaseRefEntities.Count - 1; ++index)
    {
      Entity copiedEntity = (Entity) null;
      buEntity.Copy(BaseRefEntities[index], ref copiedEntity);
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
    bool point;
    if (PL.Count >= 2)
    {
      if (buCompare5.EQ(pntRef, PL[0], Resolution))
      {
        point = true;
        goto label_10;
      }
      if (buCompare5.EQ(pntRef, PL[1], Resolution))
      {
        PL.RemoveAt(0);
        point = true;
        goto label_10;
      }
      if (buCompare5.EQ(pntRef, PL[PL.Count - 1], Resolution))
      {
        PL.Reverse();
        point = true;
        goto label_10;
      }
      if (buCompare5.EQ(pntRef, PL[PL.Count - 2], Resolution))
      {
        PL.RemoveAt(PL.Count - 1);
        PL.Reverse();
        point = true;
        goto label_10;
      }
    }
    point = false;
label_10:
    return point;
  }

  public void tt6()
  {
    double num1 = 5.0;
    double num2 = 10.0;
    int num3 = 10;
    double num4 = 1.0;
    List<Point3D[]> point3DArrayList = new List<Point3D[]>();
    for (int index = 0; index <= num3; ++index)
    {
      double num5 = (double) (index * 2) * Math.PI / (double) num3;
      double x = num1 * Math.Cos(num5);
      double y = num1 * Math.Sin(num5);
      double num6 = num2 * num5 / (2.0 * Math.PI);
      double z = 0.0;
      Point3D point3D1 = new Point3D(x, y, z);
      Point3D point3D2 = new Point3D(x + num4 / 2.0, y + num4 / 2.0, z);
      point3DArrayList.Add(new Point3D[1]{ point3D1 });
    }
    Point4D[,] ctrlPoints = new Point4D[point3DArrayList.Count, 2];
    for (int index = 0; index < point3DArrayList.Count; ++index)
    {
      ctrlPoints[index, 0] = new Point4D(point3DArrayList[index][0].X, point3DArrayList[index][0].Y, point3DArrayList[index][0].Z, 1.0);
      ctrlPoints[index, 1] = new Point4D(point3DArrayList[index][0].X, point3DArrayList[index][0].Y, point3DArrayList[index][0].Z + 1.0, 1.0);
    }
    int uDegree = 2;
    int vDegree = 1;
    Brep.CreateCylinder(10.0, 20.0).ConvertToSurfaces();
    double[] vKnotVector = new double[4]
    {
      0.0,
      0.0,
      1.0,
      1.0
    };
    double[] uKnotVector = new double[num3 + 2 + 2];
    uKnotVector[0] = 0.0;
    uKnotVector[1] = 0.0;
    uKnotVector[2] = 0.0;
    for (int index = 3; index < uKnotVector.Length - 1; ++index)
    {
      if (index == 3 | index == 4)
        uKnotVector[index] = Math.PI / 2.0;
      if (index == 5 | index == 6)
        uKnotVector[index] = Math.PI;
      if (index == 7 | index == 8)
        uKnotVector[index] = 3.0 * Math.PI / 2.0;
      if (index == 9 | index == 10 | index == 11 | index == 12)
        uKnotVector[index] = 2.0 * Math.PI;
    }
    uKnotVector[uKnotVector.Length - 1] = 2.0 * Math.PI;
    Surface surface = new Surface(uDegree, uKnotVector, vDegree, vKnotVector, ctrlPoints);
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) surface);
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
  }

  public void basicnurb()
  {
    Surface surface = new Surface(3, new double[8]
    {
      0.0,
      0.0,
      0.0,
      0.0,
      1.0,
      1.0,
      1.0,
      1.0
    }, 3, new double[8]
    {
      0.0,
      0.0,
      0.0,
      0.0,
      1.0,
      1.0,
      1.0,
      1.0
    }, new Point4D[4, 4]
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
    });
    surface.Color = Color.Green;
    surface.ColorMethod = colorMethodType.byEntity;
  }

  public void dd()
  {
    Surface surface = new Surface(3, new double[8]
    {
      0.0,
      0.0,
      0.0,
      0.33,
      0.66,
      1.0,
      1.0,
      1.0
    }, 3, new double[8]
    {
      0.0,
      0.0,
      0.0,
      0.33,
      0.66,
      1.0,
      1.0,
      1.0
    }, new Point4D[4, 4]
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
    });
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) surface);
    Mesh cylinder = Mesh.CreateCylinder(10.0, 30.0, 20);
    cylinder.Translate(0.0, 0.0, 15.0);
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) cylinder);
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
  }

  public void cmdAnalyseSelected()
  {
    for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
    {
      if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].Selected)
        this.entity_0 = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index];
    }
  }

  public void cmdFaceToSurface()
  {
    Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[0];
    if (!(entity is Brep))
      return;
    entity.LayerName = "Brep";
    entity.ColorMethod = colorMethodType.byLayer;
    Surface[] surfaces = ((Brep) entity).ConvertToSurfaces();
    if (surfaces == null)
      return;
    for (int index = 0; index <= surfaces.Length - 1; ++index)
    {
      if (surfaces[index] is PlanarSurface)
      {
        surfaces[index].LayerName = "Planar Surface";
        surfaces[index].ColorMethod = colorMethodType.byLayer;
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) surfaces[index]);
      }
      else if (surfaces[index] is ConicalSurface)
      {
        surfaces[index].LayerName = "Conical Surface";
        surfaces[index].ColorMethod = colorMethodType.byLayer;
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) surfaces[index]);
      }
      else if (surfaces[index] is CylindricalSurface)
      {
        surfaces[index].LayerName = "Cylinder Surface";
        surfaces[index].ColorMethod = colorMethodType.byLayer;
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) surfaces[index]);
      }
      else if (surfaces[index] != null)
      {
        surfaces[index].LayerName = "Surface";
        surfaces[index].ColorMethod = colorMethodType.byLayer;
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) surfaces[index]);
      }
    }
  }

  public void cmdFaceToCurve()
  {
  }

  public void cmdDrawSelected()
  {
    for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
    {
      if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].Selected)
        this.entity_0 = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index];
    }
    if (this.entity_0 == null || !(this.entity_0 is Surface))
      return;
    Surface entity0 = this.entity_0 as Surface;
    if (entity0.Trimming != null)
    {
      for (int index = 0; index <= entity0.Trimming.ContourList.Count - 1; ++index)
      {
        Entity entity = (Entity) entity0.Trimming.ContourList[index].Clone();
        entity.Color = Color.Black;
        entity.LayerName = "Draw";
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(entity);
      }
    }
    for (int index = 0; index <= entity0.ControlPoints.Length - 1; ++index)
    {
      Line line = new Line((Point3D) entity0.ControlPoints[index, 0], (Point3D) entity0.ControlPoints[index, 1]);
      line.Color = Color.Black;
      line.LayerName = "Draw";
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) line);
    }
  }

  public void cmdDrawControlPoints()
  {
    string text = "";
    for (int index1 = 0; index1 <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index1)
    {
      if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index1].Selected)
      {
        this.entity_0 = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index1];
        if (this.entity_0 is Surface)
        {
          Surface entity0 = this.entity_0 as Surface;
          string str1 = $"{text}Degree U : {entity0.DegreeU.ToString()} , Degree V : {entity0.DegreeV.ToString()}{Environment.NewLine}";
          for (int index2 = 0; index2 < entity0.ControlPoints.GetLength(0); ++index2)
          {
            for (int index3 = 0; index3 < entity0.ControlPoints.GetLength(1); ++index3)
            {
              Point4D controlPoint = entity0.ControlPoints[index2, index3];
              str1 = $"{str1}[{index2.ToString()} , {index3.ToString()}] {controlPoint?.ToString()}{Environment.NewLine}";
            }
          }
          string str2 = $"{str1}Knot U : {entity0.KnotVectorU.Length.ToString()}{Environment.NewLine}";
          for (int index4 = 0; index4 <= entity0.KnotVectorU.Length - 1; ++index4)
            str2 = $"{str2}{entity0.KnotVectorU[index4].ToString()} , ";
          string str3 = $"{str2 + Environment.NewLine}Knot V : {entity0.KnotVectorV.Length.ToString()}{Environment.NewLine}";
          for (int index5 = 0; index5 <= entity0.KnotVectorV.Length - 1; ++index5)
            str3 = $"{str3}{entity0.KnotVectorV[index5].ToString()} , ";
          text = str3 + Environment.NewLine;
          for (int index6 = 0; index6 <= 3; ++index6)
          {
            int num = entity0.KnotVectorV.Length - entity0.DegreeV - 1;
            List<Point3D> points = new List<Point3D>();
            for (int index7 = 0; index7 <= num - 1; ++index7)
              points.Add(new Point3D(entity0.ControlPoints[index6, index7].X, entity0.ControlPoints[index6, index7].Y, entity0.ControlPoints[index6, index7].Z));
            LinearPath linearPath = new LinearPath((ICollection<Point3D>) points);
            linearPath.ColorMethod = colorMethodType.byLayer;
            linearPath.LayerName = "Draw";
            linearPath.LineWeight = 3f;
            linearPath.LineWeightMethod = colorMethodType.byLayer;
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) linearPath);
          }
          ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
        }
      }
    }
    F_Notepad fNotepad = new F_Notepad();
    fNotepad.Init(text);
    fNotepad.Show();
  }

  public void Job_AfterSelect(object sender, TreeViewEventArgs e)
  {
  }
}
