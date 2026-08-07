// Decompiled with JetBrains decompiler
// Type: .
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buCore;
using buEyeBaseVer5;
using buEyeBaseVer5.Forms.PanelCut;
using buEyeBaseVer5.Forms.Profile;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.IO;
using System.Runtime.InteropServices;

#nullable disable
namespace \u000F;

internal class \u0001
{
  static void \u0001([In] string obj0, [In] F_ProfileAdd obj1)
  {
    try
    {
      FileInfo fileInfo = new FileInfo(obj0);
      if (((F_PanelCutPartList) obj1).\u0001 == null || !((F_PanelCutPartList) obj1).\u0001.IsHandleCreated)
        return;
      if (fileInfo.Extension.ToLower() == ".dxf")
      {
        cParameter5.OpenDxfDwg(ref ((F_PanelCutPartList) obj1).\u0001, obj0);
        for (int index = 0; index <= ((F_PanelCutPartList) obj1).\u0001.Entities.Count - 1; ++index)
        {
          if (((F_PanelCutPartList) obj1).\u0001.Entities[index] is ICurve)
            ;
        }
        Point3D MinPoint = new Point3D();
        Point3D MidPoint = new Point3D();
        Point3D MaxPoint = new Point3D();
        buCall.\u0001.BoxSizeCalculate(((F_PanelCutPartList) obj1).\u0001.Entities, ref MinPoint, ref MidPoint, ref MaxPoint);
        ((F_PanelCutPartList) obj1).\u0001.Entities.Translate(-MaxPoint.X, -MinPoint.Y, -MinPoint.Z);
        ((F_PanelCutPartList) obj1).\u0001.Entities.RegenAllCurved();
        ((F_PanelCutPartList) obj1).\u0001.Entities.Regen();
        ((F_PanelCutPartList) obj1).\u0001.SetView(viewType.Top);
        ((F_PanelCutPartList) obj1).\u0001.RotateLeft(180.0);
        ((F_PanelCutPartList) obj1).\u0001.ZoomFit();
        ((F_PanelCutPartList) obj1).\u0001.Invalidate();
      }
      if (fileInfo.Extension == ".bucad")
        ;
      buCall.\u0001.BoxSizeCalculate(((F_PanelCutPartList) obj1).\u0001.Entities, ref ((F_PanelCutPartList) obj1).\u0001, ref ((F_PanelCutPartList) obj1).\u0002, ref ((F_PanelCutPartList) obj1).\u0003);
      ((F_PanelCutPartList) obj1).\u0003.Text = buFile.getFileName(obj0);
      ((F_PanelCutPartList) obj1).PropertiesForm.Inited = false;
      ((F_PanelCutSheetList) obj1).\u0006.Value = (Decimal) (((F_PanelCutPartList) obj1).\u0003.X - ((F_PanelCutPartList) obj1).\u0001.X);
      ((F_PanelCutSheetList) obj1).\u0007.Value = (Decimal) (((F_PanelCutPartList) obj1).\u0003.Y - ((F_PanelCutPartList) obj1).\u0001.Y);
      ((F_PanelCutPartList) obj1).PropertiesForm.Inited = true;
    }
    catch (Exception ex)
    {
    }
  }
}
