// Decompiled with JetBrains decompiler
// Type: buMW.buMwCutSim
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using \u0005;
using buClass;
using buMW.Variables;
using ModuleWorks;
using ModuleWorks.Graphics;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buMW;

public class buMwCutSim
{
  public static List<Pnt3D> MeshVertices;
  public static List<Triangle3D> MeshTri;
  public AsyncRenderer ARender;
  public IndexedAbstractRenderer AbsRender;
  public static List<List<Triangle3D>> CutSimTri;
  public static List<Triangle3D> ListTRi;
  public AsyncRenderer RenderD;
  public Verification Verify;
  public int MoveID;

  public buMwCutSim()
    : this()
  {
  }

  static buMwCutSim()
  {
    AbsRenderr.Triangles = new Dictionary<int, List<RenderedTriangle>>();
    AbsRenderr.Lines = new Dictionary<int, List<RenderedLine>>();
    AbsRenderr.Visiblity = new Dictionary<int, bool>();
    AbsRenderr.MeshTriangles = new List<TriangleIndex>();
    buMwCutSim.MeshVertices = new List<Pnt3D>();
    buMwCutSim.MeshTri = new List<Triangle3D>();
  }

  public event MWCalculationResultHandler GetCalculations;

  public void DefineCutSim()
  {
    this.AbsRender = (IndexedAbstractRenderer) new buMwCutSim();
    this.Verify = new Verification();
    this.Verify.DataModel = WorkpieceRepresentation.DexelBlock;
    this.Verify.DrawMode = WorkpieceDrawMode.Tool;
    this.Verify.MeshColor = Color.Blue;
    this.Verify.GetColorScheme(WorkpieceDrawMode.Tool);
    this.Verify.Precision = 10f;
    this.Verify.SetStockCube(new Vectorf(0.0f, 0.0f, 0.0f), new Vectorf(500f, 500f, 50f));
    this.Verify.SetTool((ModuleWorks.Tool) new EndMill(10.0, ToolHolder.CreateHolderAsCylinder(5.0, 5.0, Unit.Metric), 80.0, 50.0, ToolArbor.CreateArborAsCylinder(5.0, 5.0, Unit.Metric), Unit.Metric), 0);
    this.Verify.SetToolBehavior(\u0002.\u0001(), false);
    this.MoveID = 1;
    ((buMWDiamalerVars) this).CutSimCount = 0;
  }

  public void MoveCutSim(Pnt3D MoveFrom, Pnt3D MoveTo, bool GetTriangles, ref eEntities StockMesh)
  {
    ModuleWorks.Quaternion quaternion = TQuaternion\u003Cfloat\u003E.OrientationToQuaternion(new Vectorf(0.0f, 0.0f, 1f), 0.0f);
    Frame from = new Frame(new Vectorf((float) MoveFrom.X, (float) MoveFrom.Y, (float) MoveFrom.Z), quaternion);
    Frame to = new Frame(new Vectorf((float) MoveTo.X, (float) MoveTo.Y, (float) MoveTo.Z), quaternion);
    this.Verify.MoveID = (float) this.MoveID;
    this.Verify.Cut(from, to, false);
    ++this.MoveID;
    if (GetTriangles)
    {
      buMwCutSim.MeshTri.Clear();
      AbsRenderr.MeshTriangles = new List<TriangleIndex>();
      buMwCutSim.MeshVertices = new List<Pnt3D>();
      this.Verify.Render((InteropAbstractRendererBase) this.AbsRender);
      AbsRenderr.Draw();
      List<Triangle3D> triangle3DList = new List<Triangle3D>();
      if (buMwCutSim.MeshTri.Count > 0)
        StockMesh = (eEntities) new eSurface(buMwCutSim.MeshTri, Color.Gray);
    }
    ((buMWDiamalerVars) this).CutSimCount = ((buMWDiamalerVars) this).CutSimCount + 1;
  }

  public void MoveSim()
  {
    this.AbsRender = (IndexedAbstractRenderer) new buMwCutSim();
    this.Verify = new Verification();
    this.StartRecord();
    this.Verify.DataModel = WorkpieceRepresentation.DexelBlock;
    this.Verify.DrawMode = WorkpieceDrawMode.Tool;
    this.Verify.MeshColor = Color.Blue;
    this.Verify.GetColorScheme(WorkpieceDrawMode.Tool);
    this.Verify.Precision = 0.1f;
    this.Verify.SetStockCube(new Vectorf(-10f, -10f, 0.0f), new Vectorf(10f, 10f, 10f));
    this.Verify.SetTool((ModuleWorks.Tool) new EndMill(2.0, ToolHolder.CreateHolderAsCylinder(5.0, 5.0, Unit.Metric), 20.0, 5.0, ToolArbor.CreateArborAsCylinder(5.0, 5.0, Unit.Metric), Unit.Metric), 0);
    this.Verify.GetMesh();
    this.Verify.SetToolBehavior(\u0002.\u0001(), false);
    ModuleWorks.Quaternion quaternion = TQuaternion\u003Cfloat\u003E.OrientationToQuaternion(new Vectorf(0.0f, 0.0f, 1f), 0.0f);
    Frame from = new Frame(new Vectorf(-10f, -10f, 9f), quaternion);
    Frame frame = new Frame(new Vectorf(0.0f, 0.0f, 5f), quaternion);
    Frame to = new Frame(new Vectorf(10f, 10f, 0.0f), quaternion);
    this.Verify.MoveID = 1f;
    this.Verify.Cut(from, frame, false);
    this.Verify.MoveID = 2f;
    this.Verify.Cut(frame, to, false);
    this.StopRecord();
    this.Verify.GetMesh();
  }

  public void Sim() => this.Verify.Render((InteropAbstractRendererBase) this.AbsRender);

  public void DrawRender() => this.RenderD.RenderGraphics();

  public void StartRecord() => this.Verify.StartRecord(Application.StartupPath + "\\Record.csb");

  public void StopRecord() => this.Verify.StopRecord();
}
