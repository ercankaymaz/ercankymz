// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buEntities.buMaterial
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buClipperLib;
using devDept.Eyeshot.Entities;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.buEntities;

public class buMaterial : Brep
{
  public buMaterial(
    double width,
    double height,
    double depth,
    string textString,
    Font font,
    double angle)
  {
    ((CutterRuntimeSettings) this).Width = 10.0;
    ((CutterProgramSettings) this).Height = 10.0;
    ((CutterProgramSettings) this).Angle = 0.0;
    ((CutterProgramSettings) this).TextString = "";
    ((CutterProgramSettings) this).isWire = false;
    ((CutterProgramSettings) this).TextFont = new Font("Arial", 10f);
    // ISSUE: explicit constructor call
    ((buLineCam) this).\u002Ector();
    ((CutterRuntimeSettings) this).Width = width;
    ((CutterProgramSettings) this).Height = height;
    ((\u0012.\u0002) this).Depth = depth;
    ((CutterProgramSettings) this).TextString = textString;
    ((CutterProgramSettings) this).Angle = angle;
    ((CutterProgramSettings) this).TextFont = new Font(font.Name, font.Size, font.Style);
    ((buClipperBase) this).ShapeType = ShapeTypes.Text;
    ((buClipperBase) this).ShapeGroup = ShapeGroup.Text;
  }

  public buMaterial(buShape data)
  {
    ((CutterRuntimeSettings) this).Width = 10.0;
    ((CutterProgramSettings) this).Height = 10.0;
    ((CutterProgramSettings) this).Angle = 0.0;
    ((CutterProgramSettings) this).TextString = "";
    ((CutterProgramSettings) this).isWire = false;
    ((CutterProgramSettings) this).TextFont = new Font("Arial", 10f);
    // ISSUE: explicit constructor call
    ((buLineCam) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null))
      return;
    if (this.GetType() == CopiedClass.GetType())
    {
      FieldInfo[] fields = this.GetType().GetFields();
      if (fields != null)
      {
        for (int index = 0; index <= fields.Length - 1; ++index)
        {
          string name = fields[index].Name;
          object obj = fields[index].GetValue(CopiedClass);
          fields[index].SetValue((object) this, obj);
        }
      }
    }
    ((CutterProgramSettings) this).TextFont = new Font(((CutterProgramSettings) data).TextFont.Name, ((CutterProgramSettings) data).TextFont.Size, ((CutterProgramSettings) data).TextFont.Style);
    buRadialDim.Copy(((buClipper) data).entitiesShape, ref ((buClipper) this).entitiesShape);
  }
}
