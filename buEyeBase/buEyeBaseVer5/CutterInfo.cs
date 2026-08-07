// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.CutterInfo
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class CutterInfo : buSerilization5
{
  public string TextOverride;

  public ArrayList ToDef(int Space)
  {
    ArrayList def = new ArrayList();
    def.Add((object) (buImage5.SpaceChar(Space) + buSerilization5.ClassToString((object) this)));
    def.Add((object) (buImage5.SpaceChar(Space) + "<SewingVertex>"));
    for (int index1 = 0; index1 <= ((MarbleInfo) this).Vertex.Count - 1; ++index1)
    {
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "<Vertex>"));
      string str1 = $"{buImage5.SpaceChar(Space + 4) + buSerilization5.ToDef(((DimensionInfo) ((MarbleInfo) this).Vertex[index1]).Point) + " % "}{((DimensionInfo) ((MarbleInfo) this).Vertex[index1]).DeltaX.ToString()} ; {((DimensionInfo) ((MarbleInfo) this).Vertex[index1]).DeltaY.ToString()} ; {((DimensionInfo) ((MarbleInfo) this).Vertex[index1]).FootHeight.ToString()} ; {((DimensionInfo) ((MarbleInfo) this).Vertex[index1]).Speed.ToString()}" + " % ";
      if (((DimensionInfo) ((MarbleInfo) this).Vertex[index1]).Codes.Count > 0)
      {
        for (int index2 = 0; index2 <= ((DimensionInfo) ((MarbleInfo) this).Vertex[index1]).Codes.Count - 1; ++index2)
        {
          str1 += buSerilization5.ClassToString((object) ((DimensionInfo) ((MarbleInfo) this).Vertex[index1]).Codes[index2]);
          if (index2 < ((DimensionInfo) ((MarbleInfo) this).Vertex[index1]).Codes.Count - 1)
            str1 += " ; ";
        }
      }
      string str2 = str1 + " % ";
      if (((DimensionInfo) ((MarbleInfo) this).Vertex[index1]).Punterez != null)
        str2 = $"{str2}{((EntityInfo) ((DimensionInfo) ((MarbleInfo) this).Vertex[index1]).Punterez).Angle.ToString()};{((EntityInfo) ((DimensionInfo) ((MarbleInfo) this).Vertex[index1]).Punterez).Count.ToString()};{((EntityInfo) ((DimensionInfo) ((MarbleInfo) this).Vertex[index1]).Punterez).Height.ToString()};{((EntityInfo) ((DimensionInfo) ((MarbleInfo) this).Vertex[index1]).Punterez).Length.ToString()};{((EntityInfo) ((DimensionInfo) ((MarbleInfo) this).Vertex[index1]).Punterez).PunterizType.ToString()};{((EntityInfo) ((DimensionInfo) ((MarbleInfo) this).Vertex[index1]).Punterez).Width.ToString()}";
      def.Add((object) str2);
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "</Vertex>"));
    }
    def.Add((object) (buImage5.SpaceChar(Space) + "</SewingVertex>"));
    return def;
  }

  public static void Decode(List<string> SL, ref SewingInfo Sewing)
  {
    try
    {
      if (SL.Count < 3)
        return;
      Sewing = (SewingInfo) new EntityInfo();
      object ObjPar1 = (object) Sewing;
      buSerilization5.StringToClass(ref ObjPar1, SL[0]);
      List<List<string>> CalcList = new List<List<string>>();
      buImage5.ListToSpecificList("<Vertex>", "</Vertex>", false, SL, ref CalcList);
      if (CalcList.Count <= 0)
        return;
      for (int index1 = 0; index1 <= CalcList.Count - 1; ++index1)
      {
        SewingVertex sewingVertex = (SewingVertex) new Rectangle2D();
        string[] strArray1 = CalcList[index1][0].Split('%');
        if (strArray1 != null & strArray1.Length >= 1)
          ((DimensionInfo) sewingVertex).Point = buSerilization5.DecoderFromPoint3D(strArray1[0]);
        if (strArray1 != null & strArray1.Length >= 2)
        {
          string[] strArray2 = strArray1[1].Split(';');
          if (strArray2 != null & strArray2.Length >= 2)
          {
            ((DimensionInfo) sewingVertex).DeltaX = Convert.ToDouble(strArray2[0]);
            ((DimensionInfo) sewingVertex).DeltaY = Convert.ToDouble(strArray2[1]);
          }
          if (strArray2 != null & strArray2.Length >= 3)
            ((DimensionInfo) sewingVertex).FootHeight = Convert.ToDouble(strArray2[2]);
          if (strArray2 != null & strArray2.Length >= 4)
            ((DimensionInfo) sewingVertex).Speed = Convert.ToDouble(strArray2[3]);
        }
        if (strArray1 != null & strArray1.Length >= 3)
        {
          string[] strArray3 = strArray1[2].Split(';');
          if (strArray3 != null)
          {
            for (int index2 = 0; index2 <= strArray3.Length - 1; ++index2)
            {
              if (strArray3[index2].Trim().Length > 0)
              {
                object ObjPar2 = (object) new Rectangle2D();
                buSerilization5.StringToClass(ref ObjPar2, strArray3[index2]);
                ((DimensionInfo) sewingVertex).Codes.Add((SewingCode) ObjPar2);
              }
            }
          }
        }
        if (strArray1 != null & strArray1.Length >= 4)
        {
          string[] strArray4 = strArray1[3].Split(';');
          if ((strArray4 == null ? 0 : (strArray4.Length >= 6 ? 1 : 0)) != 0)
          {
            ((DimensionInfo) sewingVertex).Punterez = (SewingPunteriz) new Line2D();
            ((EntityInfo) ((DimensionInfo) sewingVertex).Punterez).Angle = Convert.ToDouble(strArray4[0]);
            ((EntityInfo) ((DimensionInfo) sewingVertex).Punterez).Count = Convert.ToInt32(strArray4[1]);
            ((EntityInfo) ((DimensionInfo) sewingVertex).Punterez).Height = Convert.ToDouble(strArray4[2]);
            ((EntityInfo) ((DimensionInfo) sewingVertex).Punterez).Length = Convert.ToDouble(strArray4[3]);
            Enum.TryParse<SewingPunterizType>(strArray4[4], true, out ((EntityInfo) ((DimensionInfo) sewingVertex).Punterez).PunterizType);
            ((EntityInfo) ((DimensionInfo) sewingVertex).Punterez).Width = Convert.ToDouble(strArray4[5]);
          }
        }
        ((MarbleInfo) Sewing).Vertex.Add(sewingVertex);
      }
    }
    catch (Exception ex)
    {
    }
  }

  public override string ToString()
  {
    string str = $"Len: {((MarbleInfo) this).StitchLengt.ToString("f2")} , Stitch Mode: {((DimensionInfo) this).isStitchDrawing.ToString()}";
    if (((MarbleInfo) this).Vertex.Count > 0)
      str = $"{str} Vertex: {((MarbleInfo) this).Vertex.Count.ToString()}";
    return str;
  }
}
