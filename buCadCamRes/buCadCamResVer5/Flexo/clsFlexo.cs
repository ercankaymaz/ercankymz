// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Flexo.clsFlexo
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buClass;
using buEyeBaseVer5;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5.Flexo;

public class clsFlexo
{
  public List<string> cmdExceptionID = new List<string>();
  public Design viewportSimilasyon;

  public event OkCommandWithTwoDataEventHandler ObjectSelected;

  public void Init()
  {
    this.cmdExceptionID.Add("clsProfile - ID = 101-00100");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00101");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00102");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00103");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00104");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00105");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00106");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00107");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00108");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00109");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00110");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00111");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00112");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00113");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00114");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00115");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00116");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00117");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00118");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00119");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00120");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00121");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00122");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00123");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00124");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00125");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00126");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00127");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00128");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00129");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00130");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00131");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00132");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00133");
  }

  public void InitSimulation()
  {
    AppPath.MachineSimConfig = AppPath.Machine + "\\MachineData";
    clsFiles.OpenMachineConfig(AppPath.MachineSimConfig + "\\Machine.bumachdef", ref ccVars.SimMachine);
    if (this.viewportSimilasyon == null)
    {
      buEyeShotFunctions.CreateControlsTool(true, new EyeCreateProps()
      {
        ShowToolBar = false,
        ShowViewCube = false,
        ShowCoordinateArrow = false,
        PanMouseButton = {
          Button = mouseButtonsZPR.Middle,
          ModifierKey = devDept.Eyeshot.Control.modifierKeys.None
        },
        RotateMouseButton = {
          Button = mouseButtonsZPR.Middle,
          ModifierKey = devDept.Eyeshot.Control.modifierKeys.Ctrl
        },
        ZoomMouseButton = {
          Button = mouseButtonsZPR.Middle,
          ModifierKey = devDept.Eyeshot.Control.modifierKeys.Shift
        }
      }, ref this.viewportSimilasyon);
      this.viewportSimilasyon.Dock = DockStyle.Fill;
    }
    for (int index = 0; index <= this.viewportSimilasyon.Layers.Count - 1; ++index)
      this.viewportSimilasyon.Layers[index].Visible = true;
    this.viewportSimilasyon.Layers.Add(new Layer("Operation", Color.Cyan));
    this.viewportSimilasyon.Layers.Add(new Layer("Cam", Color.Red));
    this.viewportSimilasyon.Layers.Add(new Layer("Drawing", Color.Black));
    this.viewportSimilasyon.Layers.Add(new Layer("Machine", Color.DarkOrange));
    this.viewportSimilasyon.TempEntities.Clear();
    this.viewportSimilasyon.ActiveViewport.DisplayMode = displayType.Flat;
    this.viewportSimilasyon.StartAnimation();
    if (this.viewportSimilasyon.Blocks.Count > 1)
    {
      for (int index = this.viewportSimilasyon.Blocks.Count - 1; index >= 1; --index)
        this.viewportSimilasyon.Blocks.RemoveAt(index);
    }
    List<Entity> entityList1 = new List<Entity>();
    List<Entity> entityList2 = new List<Entity>();
    if (ccVars.SimMachine == null)
      ccVars.SimMachine = new MachineDef();
    if (ccVars.SimMachine != null)
    {
      if (ccVars.SimMachine.MachineParts.Count > 0)
      {
        for (int index1 = 0; index1 <= ccVars.SimMachine.MachineParts.Count - 1; ++index1)
        {
          for (int index2 = 0; index2 <= ccVars.SimMachine.MachineParts[index1].Entities.Count - 1; ++index2)
          {
            Entity entity = buVector5.CopyEntities(ccVars.SimMachine.MachineParts[index1].Entities[index2]);
            entity.EntityData = (object) new CustomData()
            {
              typeDefination = entityTypeDefination.MachineParts,
              EntityName = ccVars.SimMachine.MachineParts[index1].PartName
            };
            entity.Regen(new RegenParams(buSystem.RegenDeviation, (IWorkspace) this.viewportSimilasyon));
            if (!ccVars.SimMachine.MachineParts[index1].AddAsMesh)
              entityList2.Add(entity);
          }
        }
      }
      if (entityList2.Count > 0)
      {
        for (int index = 0; index <= entityList2.Count - 1; ++index)
        {
          string name = ((CustomData) entityList2[index].EntityData).EntityName;
          if (name.Length == 0)
            name = "Block" + index.ToString();
          Block block = new Block(name);
          Entity entity = buVector5.CopyEntities(entityList2[index]);
          entity.Color = Color.Linen;
          int alpha = (int) byte.MaxValue;
          if (ccVars.SimMachine.MachineParts[index].Transparency >= 0 & ccVars.SimMachine.MachineParts[index].Transparency <= (int) byte.MaxValue)
            alpha = ccVars.SimMachine.MachineParts[index].Transparency;
          if (index <= ccVars.SimMachine.MachineParts.Count - 1)
            entity.Color = Color.FromArgb(alpha, ccVars.SimMachine.MachineParts[index].Color);
          entity.ColorMethod = colorMethodType.byEntity;
          block.Entities.Add(entity);
          this.viewportSimilasyon.Blocks.Add(block);
        }
      }
    }
    this.viewportSimilasyon.MouseDown += new MouseEventHandler(this.MouseDown_Event);
    this.viewportSimilasyon.MouseMove += new MouseEventHandler(this.MouseMove_Event);
    this.viewportSimilasyon.MouseUp += new MouseEventHandler(this.MouseUp_Event);
  }

  public void MouseMove_Event(object sender, MouseEventArgs e)
  {
  }

  public void MouseUp_Event(object sender, MouseEventArgs e)
  {
  }

  public void MouseDown_Event(object sender, MouseEventArgs e)
  {
    int underMouseCursor = this.viewportSimilasyon.GetEntityUnderMouseCursor(e.Location);
    if (underMouseCursor < 0)
      return;
    if (this.viewportSimilasyon.Entities[underMouseCursor] is buMachinePart)
    {
      buMachinePart entity = this.viewportSimilasyon.Entities[underMouseCursor] as buMachinePart;
      // ISSUE: reference to a compiler-generated field
      if (this.okCommandWithTwoDataEventHandler_0 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.okCommandWithTwoDataEventHandler_0((object) entity.BlockName, (object) "");
    }
    else
    {
      if (!(this.viewportSimilasyon.Entities[underMouseCursor] is Mesh))
        return;
      Mesh entity = this.viewportSimilasyon.Entities[underMouseCursor] as Mesh;
      if (!(entity.EntityData != null & entity.EntityData is CustomData))
        return;
      CustomData entityData = entity.EntityData as CustomData;
      // ISSUE: reference to a compiler-generated field
      if (this.okCommandWithTwoDataEventHandler_0 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.okCommandWithTwoDataEventHandler_0((object) entityData.EntityName, (object) "");
    }
  }

  public void DrawSimulationEntities(bool machine)
  {
    this.viewportSimilasyon.Entities.Clear();
    if (machine)
    {
      for (int index1 = 0; index1 <= ccVars.SimMachine.MachineParts.Count - 1; ++index1)
      {
        for (int index2 = 0; index2 <= ccVars.SimMachine.MachineParts[index1].Entities.Count - 1; ++index2)
        {
          if (!ccVars.SimMachine.MachineParts[index1].AddAsMesh)
          {
            buMachinePart buMachinePart = new buMachinePart(ccVars.SimMachine.MachineParts[index1].PartName);
            buMachinePart.ARotation = ccVars.SimMachine.MachineParts[index1].MoveAxisPermision.A;
            buMachinePart.BRotation = ccVars.SimMachine.MachineParts[index1].MoveAxisPermision.B;
            buMachinePart.CRotation = ccVars.SimMachine.MachineParts[index1].MoveAxisPermision.C;
            buMachinePart.XMove = ccVars.SimMachine.MachineParts[index1].MoveAxisPermision.X;
            buMachinePart.YMove = ccVars.SimMachine.MachineParts[index1].MoveAxisPermision.Y;
            buMachinePart.ZMove = ccVars.SimMachine.MachineParts[index1].MoveAxisPermision.Z;
            buMachinePart.xRot = ccVars.SimMachine.MachineParts[index1].RotationCenter.X;
            buMachinePart.yRot = ccVars.SimMachine.MachineParts[index1].RotationCenter.Y;
            buMachinePart.zRot = ccVars.SimMachine.MachineParts[index1].RotationCenter.Z;
            int alpha = (int) byte.MaxValue;
            if (ccVars.SimMachine.MachineParts[index1].Transparency >= 0 & ccVars.SimMachine.MachineParts[index1].Transparency <= (int) byte.MaxValue)
              alpha = ccVars.SimMachine.MachineParts[index1].Transparency;
            buMachinePart.Color = Color.FromArgb(alpha, ccVars.SimMachine.MachineParts[index1].Color);
            buMachinePart.ColorMethod = colorMethodType.byEntity;
            double dx = ccVars.SimMachine.MachineParts[index1].PositionBaseOffset.X + ccVars.SimMachine.MachineParts[index1].PositionAuxOffset.X;
            double dy = ccVars.SimMachine.MachineParts[index1].PositionBaseOffset.Y + ccVars.SimMachine.MachineParts[index1].PositionAuxOffset.Y;
            double dz = ccVars.SimMachine.MachineParts[index1].PositionBaseOffset.Z + ccVars.SimMachine.MachineParts[index1].PositionAuxOffset.Z;
            buMachinePart.Translate(dx, dy, dz);
            buMachinePart.EntityData = (object) new CustomData()
            {
              typeDefination = entityTypeDefination.MachineBody,
              OriginalEntityIndex = this.viewportSimilasyon.Entities.Count
            };
            buMachinePart.Regen(new RegenParams(buSystem.RegenDeviation, (IWorkspace) this.viewportSimilasyon));
            buMachinePart.LayerName = "Machine";
            this.viewportSimilasyon.Entities.Add((Entity) buMachinePart);
          }
          else
          {
            Mesh mesh = (Mesh) ccVars.SimMachine.MachineParts[index1].Entities[0].Clone();
            CustomData customData = new CustomData();
            customData.typeDefination = entityTypeDefination.MachineBody;
            customData.OriginalEntityIndex = this.viewportSimilasyon.Entities.Count;
            customData.EntityName = ccVars.SimMachine.MachineParts[index1].PartName;
            int alpha = (int) byte.MaxValue;
            if (ccVars.SimMachine.MachineParts[index1].Transparency >= 0 & ccVars.SimMachine.MachineParts[index1].Transparency <= (int) byte.MaxValue)
              alpha = ccVars.SimMachine.MachineParts[index1].Transparency;
            mesh.Color = Color.FromArgb(alpha, ccVars.SimMachine.MachineParts[index1].Color);
            mesh.ColorMethod = colorMethodType.byEntity;
            mesh.EntityData = (object) customData;
            mesh.LayerName = "Machine";
            double dx = ccVars.SimMachine.MachineParts[index1].PositionBaseOffset.X + ccVars.SimMachine.MachineParts[index1].PositionAuxOffset.X;
            double dy = ccVars.SimMachine.MachineParts[index1].PositionBaseOffset.Y + ccVars.SimMachine.MachineParts[index1].PositionAuxOffset.Y;
            double dz = ccVars.SimMachine.MachineParts[index1].PositionBaseOffset.Z + ccVars.SimMachine.MachineParts[index1].PositionAuxOffset.Z;
            mesh.Translate(dx, dy, dz);
            this.viewportSimilasyon.Entities.Add((Entity) mesh);
          }
        }
      }
    }
    this.viewportSimilasyon.Entities.Regen(new RegenOptions());
    this.viewportSimilasyon.Invalidate();
  }

  public void AddWinder(Point3D Position, double Diameter, double Length, Color clr)
  {
    for (int index = 0; index <= this.viewportSimilasyon.Entities.Count - 1; ++index)
    {
      if (this.viewportSimilasyon.Entities[index].EntityData != null && this.viewportSimilasyon.Entities[index].EntityData is CustomData && ((CustomData) this.viewportSimilasyon.Entities[index].EntityData).EntityName == "Winder")
        this.viewportSimilasyon.Entities[index].Selected = true;
    }
    this.viewportSimilasyon.Entities.DeleteSelected();
    Circle outer = new Circle(Plane.XZ, Position, Diameter / 2.0);
    devDept.Eyeshot.Entities.Region region = new devDept.Eyeshot.Entities.Region((ICurve) outer);
    CustomData customData = new CustomData();
    customData.EntityName = "Winder";
    outer.EntityData = (object) new CustomData();
    Mesh mesh = region.ExtrudeAsMesh(new Vector3D(0.0, Length, 0.0), 0.1, Mesh.natureType.RichPlain);
    mesh.Color = clr;
    mesh.ColorMethod = colorMethodType.byEntity;
    mesh.EntityData = (object) customData;
    this.viewportSimilasyon.Entities.Add((Entity) mesh);
    this.viewportSimilasyon.Invalidate();
  }

  public void AddUnWinder(Point3D Position, double Diameter, double Length, Color clr)
  {
    for (int index = 0; index <= this.viewportSimilasyon.Entities.Count - 1; ++index)
    {
      if (this.viewportSimilasyon.Entities[index].EntityData != null && this.viewportSimilasyon.Entities[index].EntityData is CustomData && ((CustomData) this.viewportSimilasyon.Entities[index].EntityData).EntityName == "UnWinder")
        this.viewportSimilasyon.Entities[index].Selected = true;
    }
    this.viewportSimilasyon.Entities.DeleteSelected();
    Circle outer = new Circle(Plane.XZ, Position, Diameter / 2.0);
    devDept.Eyeshot.Entities.Region region = new devDept.Eyeshot.Entities.Region((ICurve) outer);
    CustomData customData = new CustomData();
    customData.EntityName = "UnWinder";
    outer.EntityData = (object) new CustomData();
    Mesh mesh = region.ExtrudeAsMesh(new Vector3D(0.0, Length, 0.0), 0.1, Mesh.natureType.RichPlain);
    mesh.Color = clr;
    mesh.ColorMethod = colorMethodType.byEntity;
    mesh.EntityData = (object) customData;
    this.viewportSimilasyon.Entities.Add((Entity) mesh);
    this.viewportSimilasyon.Invalidate();
  }

  public void MoveUnWinderFront(double Distance)
  {
    for (int index = 0; index <= this.viewportSimilasyon.Entities.Count - 1; ++index)
    {
      if (this.viewportSimilasyon.Entities[index] is buMachinePart)
      {
        buMachinePart entity = this.viewportSimilasyon.Entities[index] as buMachinePart;
        if (this.viewportSimilasyon.Entities[index].EntityData != null & this.viewportSimilasyon.Entities[index].EntityData is CustomData)
        {
          CustomData entityData = this.viewportSimilasyon.Entities[index].EntityData as CustomData;
          if (entity.BlockName == "UnwinderFront")
            entity.yPos = Distance;
        }
      }
    }
    this.viewportSimilasyon.Invalidate();
  }

  public void MoveUnWinderBack(double Distance)
  {
    for (int index = 0; index <= this.viewportSimilasyon.Entities.Count - 1; ++index)
    {
      if (this.viewportSimilasyon.Entities[index] is buMachinePart)
      {
        buMachinePart entity = this.viewportSimilasyon.Entities[index] as buMachinePart;
        if (this.viewportSimilasyon.Entities[index].EntityData != null & this.viewportSimilasyon.Entities[index].EntityData is CustomData)
        {
          CustomData entityData = this.viewportSimilasyon.Entities[index].EntityData as CustomData;
          if (entity.BlockName == "UnwinderBack")
            entity.yPos = Distance;
        }
      }
    }
    this.viewportSimilasyon.Invalidate();
  }

  public void MoveUnWinderFrontBack(double Distance)
  {
    this.MoveUnWinderFront(Distance);
    this.MoveUnWinderBack(-Distance);
  }

  public void MoveWinderFront(double Distance)
  {
    for (int index = 0; index <= this.viewportSimilasyon.Entities.Count - 1; ++index)
    {
      if (this.viewportSimilasyon.Entities[index] is buMachinePart)
      {
        buMachinePart entity = this.viewportSimilasyon.Entities[index] as buMachinePart;
        if (this.viewportSimilasyon.Entities[index].EntityData != null & this.viewportSimilasyon.Entities[index].EntityData is CustomData)
        {
          CustomData entityData = this.viewportSimilasyon.Entities[index].EntityData as CustomData;
          if (entity.BlockName == "WinderFront")
            entity.yPos = Distance;
        }
      }
    }
    this.viewportSimilasyon.Invalidate();
  }

  public void MoveWinderBack(double Distance)
  {
    for (int index = 0; index <= this.viewportSimilasyon.Entities.Count - 1; ++index)
    {
      if (this.viewportSimilasyon.Entities[index] is buMachinePart)
      {
        buMachinePart entity = this.viewportSimilasyon.Entities[index] as buMachinePart;
        if (this.viewportSimilasyon.Entities[index].EntityData != null & this.viewportSimilasyon.Entities[index].EntityData is CustomData)
        {
          CustomData entityData = this.viewportSimilasyon.Entities[index].EntityData as CustomData;
          if (entity.BlockName == "WinderBack")
            entity.yPos = Distance;
        }
      }
    }
    this.viewportSimilasyon.Invalidate();
  }

  public void MoveWinderFrontBack(double Distance)
  {
    this.MoveWinderFront(Distance);
    this.MoveWinderBack(-Distance);
  }

  public void SetObjectColor(string ObjectName, Color clr)
  {
    for (int index = 0; index <= this.viewportSimilasyon.Blocks.Count - 1; ++index)
    {
      if (this.viewportSimilasyon.Blocks[index].Name == ObjectName)
        this.viewportSimilasyon.Blocks[index].Entities[0].Color = clr;
    }
    for (int index = 0; index <= this.viewportSimilasyon.Entities.Count - 1; ++index)
    {
      if (this.viewportSimilasyon.Entities[index] is buMachinePart)
      {
        buMachinePart entity1 = this.viewportSimilasyon.Entities[index] as buMachinePart;
      }
      else if (this.viewportSimilasyon.Entities[index] is Mesh)
      {
        Mesh entity2 = this.viewportSimilasyon.Entities[index] as Mesh;
        if (entity2.EntityData != null & entity2.EntityData is CustomData && (entity2.EntityData as CustomData).EntityName.ToLower() == ObjectName.ToLower())
          entity2.Color = clr;
      }
    }
    this.viewportSimilasyon.Invalidate();
  }

  public void ScaleLine(double NewLength)
  {
    for (int index = 0; index <= this.viewportSimilasyon.Entities.Count - 1; ++index)
    {
      if (this.viewportSimilasyon.Entities[index] is Mesh)
      {
        Mesh entity = this.viewportSimilasyon.Entities[index] as Mesh;
        if (((CustomData) entity.EntityData).EntityName == "Line")
        {
          entity.Regen(new RegenParams(0.01, (IWorkspace) this.viewportSimilasyon));
          double num = entity.BoxMax.Y - entity.BoxMin.Y;
          if (num > 0.0)
          {
            Point3D fixedPoint = clsInit.cVector5.MiddlePointOfLine(entity.BoxMin, entity.BoxMax);
            double sy = NewLength / num;
            entity.Scale(fixedPoint, 1.0, sy);
            entity.Regen(new RegenParams(0.01, (IWorkspace) this.viewportSimilasyon));
          }
        }
      }
    }
    this.viewportSimilasyon.Entities.Regen();
    this.viewportSimilasyon.Invalidate();
  }
}
