// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Pages
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buCadCamResVer5.Forms;
using buClass;
using buEyeBaseVer5;
using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buCadCamResVer5;

public class Pages : IDisposable
{
  private bool bool_0 = false;
  public List<PageScene> Scene = new List<PageScene>();
  public List<camTp> Cams = new List<camTp>();
  public F_Drawing Form = (F_Drawing) null;
  public List<LayerBase5> Layers = new List<LayerBase5>();
  public List<UndoV5> UndoBuffer = new List<UndoV5>();
  public List<UndoV5> RedoBuffer = new List<UndoV5>();
  public List<OsnapPoint> OsnapPoints = new List<OsnapPoint>();
  public List<OsnapPoint> OsnapTempPoints = new List<OsnapPoint>();
  public List<OsnapPoint> OsnapOtherPoints = new List<OsnapPoint>();
  public pageInfo Info = new pageInfo();
  public Vec3D MovedDistanceWhenImport = new Vec3D();
  public string PageName = "";
  public int SceneIndex = 0;
  public string SceneName = "";
  public int LayerIndex = 0;
  public int GroupIndex = 0;
  public int CamIndex = 0;
  public int BlockIndex = 0;
  public int EntityIndex = 0;
  public int EntityCounter = 1;
  public string FileName = "";
  public string LayerName = "";
  public bool Changed = false;

  public Pages()
  {
  }

  public Pages(Pages data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
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
    this.Info = new pageInfo(data.Info);
    this.Form = data.Form;
    this.Form.viewportcad = data.Form.viewportcad.DeepClone<ViewportCC>();
    this.Layers.Clear();
    this.Cams.Clear();
    camTp.CopyCam(data.Cams, ref this.Cams);
    for (int index = 0; index <= data.Layers.Count - 1; ++index)
      this.Layers.Add(new LayerBase5(data.Layers[index]));
    for (int index = 0; index <= data.Scene.Count - 1; ++index)
      this.Scene.Add(new PageScene(data.Scene[index]));
  }

  ~Pages() => this.Dispose(false);

  public void Dispose()
  {
    this.Dispose(true);
    GC.SuppressFinalize((object) this);
  }

  protected virtual void Dispose(bool disposing)
  {
    if (!this.bool_0 && disposing)
    {
      this.Form.viewportcad.Dispose();
      this.Form.viewportcad = (ViewportCC) null;
      this.Layers.Clear();
      this.UndoBuffer.Clear();
      this.RedoBuffer.Clear();
      this.OsnapPoints.Clear();
      this.OsnapTempPoints.Clear();
      this.Scene.Clear();
      this.Cams.Clear();
      this.Scene = (List<PageScene>) null;
      this.Form = (F_Drawing) null;
      this.Layers = (List<LayerBase5>) null;
      this.UndoBuffer = (List<UndoV5>) null;
      this.RedoBuffer = (List<UndoV5>) null;
      this.Cams = (List<camTp>) null;
    }
    this.bool_0 = true;
  }
}
