// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buMatrix5
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Geometry;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;

#nullable disable
namespace buEyeBaseVer5;

public class buMatrix5
{
  public static byte f0008F7;

  public override string ToString()
  {
    return $"Visible: {((buFile5.Cf2) this).VisibleStatus.ToString()} ImageIndex: {((buFile5.Cf2) this).ImageIndex.ToString()}";
  }

  public abstract void m0003A9();

  public buMatrix5()
  {
    ((buFile5.GCodeRead) this).fontHeader = new Font("Arial", 14f, FontStyle.Bold);
    ((buFile5.GCodeRead) this).fontCell = new Font("Times New Roman", 10f, FontStyle.Bold);
    ((buFile5.GCodeRead) this).colorBackGround = Color.LightGray;
    ((buFile5.GCodeRead) this).colorHeader = Color.Gray;
    ((buFile5.GCodeRead) this).colorHeaderFore = Color.Black;
    ((buFile5.GCodeRead) this).colorFore = Color.Black;
    ((buFile5.GCodeRead) this).colorCell = Color.WhiteSmoke;
    ((buFile5.GCodeRead) this).colorCellSelected = Color.Silver;
    ((buFile5.GCodeRead) this).colorGrid = Color.Black;
    // ISSUE: explicit constructor call
    ((buSerilization) this).\u002Ector();
  }

  public buMatrix5(hmiUIDataGridView data)
  {
    ((buFile5.GCodeRead) this).fontHeader = new Font("Arial", 14f, FontStyle.Bold);
    ((buFile5.GCodeRead) this).fontCell = new Font("Times New Roman", 10f, FontStyle.Bold);
    ((buFile5.GCodeRead) this).colorBackGround = Color.LightGray;
    ((buFile5.GCodeRead) this).colorHeader = Color.Gray;
    ((buFile5.GCodeRead) this).colorHeaderFore = Color.Black;
    ((buFile5.GCodeRead) this).colorFore = Color.Black;
    ((buFile5.GCodeRead) this).colorCell = Color.WhiteSmoke;
    ((buFile5.GCodeRead) this).colorCellSelected = Color.Silver;
    ((buFile5.GCodeRead) this).colorGrid = Color.Black;
    // ISSUE: explicit constructor call
    ((buSerilization) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }

  public abstract void m0003AC();

  public buMatrix5()
  {
    ((buFile5.GCodeRead) this).ArrowTotalLen = 30.0;
    ((buFile5.GCodeRead) this).ArrowDiameter = 4.0;
    ((buFile5.GCodeRead) this).ArrowConeDiameter = 6.0;
    ((buFile5.GCodeAssingmentArgs) this).ArrowConeLen = 9.0;
    ((buFile5.GCodeAssingmentArgs) this).BallDiameter = 6.0;
    ((buFile5.HPGLFile) this).XAxisColor = Color.Red;
    // ISSUE: reference to a compiler-generated field
    ((buFile5.\u003C\u003Ec) this).YAxisColor = Color.Blue;
    // ISSUE: reference to a compiler-generated field
    ((buFile5.\u003C\u003Ec) this).ZAxisColor = Color.Green;
    // ISSUE: reference to a compiler-generated field
    ((buFile5.\u0001) this).BallColor = Color.Gray;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buMatrix5(UCSObjectData data)
  {
    ((buFile5.GCodeRead) this).ArrowTotalLen = 30.0;
    ((buFile5.GCodeRead) this).ArrowDiameter = 4.0;
    ((buFile5.GCodeRead) this).ArrowConeDiameter = 6.0;
    ((buFile5.GCodeAssingmentArgs) this).ArrowConeLen = 9.0;
    ((buFile5.GCodeAssingmentArgs) this).BallDiameter = 6.0;
    ((buFile5.HPGLFile) this).XAxisColor = Color.Red;
    // ISSUE: reference to a compiler-generated field
    ((buFile5.\u003C\u003Ec) this).YAxisColor = Color.Blue;
    // ISSUE: reference to a compiler-generated field
    ((buFile5.\u003C\u003Ec) this).ZAxisColor = Color.Green;
    // ISSUE: reference to a compiler-generated field
    ((buFile5.\u0001) this).BallColor = Color.Gray;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }

  public static void CreateUCSDataFromLength(double Length, ref UCSObjectData UcsData)
  {
    ((buFile5.GCodeRead) UcsData).ArrowTotalLen = Length;
    ((buFile5.GCodeAssingmentArgs) UcsData).ArrowConeLen = Length * 0.3;
    ((buFile5.GCodeRead) UcsData).ArrowDiameter = Length * 0.2;
    ((buFile5.GCodeRead) UcsData).ArrowConeDiameter = ((buFile5.GCodeRead) UcsData).ArrowDiameter * 1.3;
    ((buFile5.GCodeAssingmentArgs) UcsData).BallDiameter = ((buFile5.GCodeRead) UcsData).ArrowDiameter * 1.2;
  }

  public buMatrix5()
  {
    // ISSUE: reference to a compiler-generated field
    ((buFile5.\u0002) this).ItemPlane = planeNames.Top;
    // ISSUE: reference to a compiler-generated field
    ((buFile5.\u0003) this).Corner = CornerLocation.LeftTop;
    // ISSUE: reference to a compiler-generated field
    ((buFile5.\u0003) this).Alignment = ObjectAlignment.MiddleCenter;
    // ISSUE: reference to a compiler-generated field
    ((buFile5.\u0003) this).ItemType = ShapeTypes.Rectangle;
    // ISSUE: reference to a compiler-generated field
    ((buFile5.\u0003) this).UpDown = UpDownLocationType.Up;
    // ISSUE: reference to a compiler-generated field
    ((buFile5.\u0003) this).FrontBack = FrontBackType.Front;
    // ISSUE: reference to a compiler-generated field
    ((buFile5.\u0003) this).NotchOPType = ProfileNotchOperationType.Side;
    // ISSUE: reference to a compiler-generated field
    ((buFile5.\u0003) this).NotchStart = 10.0;
    // ISSUE: reference to a compiler-generated field
    ((buFile5.\u0003) this).BasePoint = new Point3D();
    // ISSUE: reference to a compiler-generated field
    ((buFile5.\u0004) this).Diameter = 10.0;
    // ISSUE: reference to a compiler-generated field
    ((buFile5.\u0004) this).Width = 20.0;
    // ISSUE: reference to a compiler-generated field
    ((buFile5.\u0004) this).Height = 20.0;
    // ISSUE: reference to a compiler-generated field
    ((buFile5.\u0004) this).Depth = 5.0;
    // ISSUE: reference to a compiler-generated field
    ((buFile5.\u0004) this).Radius = 0.0;
    // ISSUE: reference to a compiler-generated field
    ((buFile5.\u0004) this).Length = 20.0;
    // ISSUE: reference to a compiler-generated field
    ((buFile5.\u0004) this).Angle = 0.0;
    // ISSUE: reference to a compiler-generated field
    ((buFile5.\u0004) this).Side = 6;
    // ISSUE: reference to a compiler-generated field
    ((buFile5.\u0004) this).ManuelZ = false;
    ((buGCodeCreate) this).Option1 = "";
    ((buGCodeCreate) this).Option2 = "";
    ((buGCodeCreate) this).Option3 = "";
    ((buGCodeCreate) this).Option4 = "";
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buMatrix5(MacroItem data)
  {
    // ISSUE: reference to a compiler-generated field
    ((buFile5.\u0002) this).ItemPlane = planeNames.Top;
    // ISSUE: reference to a compiler-generated field
    ((buFile5.\u0003) this).Corner = CornerLocation.LeftTop;
    // ISSUE: reference to a compiler-generated field
    ((buFile5.\u0003) this).Alignment = ObjectAlignment.MiddleCenter;
    // ISSUE: reference to a compiler-generated field
    ((buFile5.\u0003) this).ItemType = ShapeTypes.Rectangle;
    // ISSUE: reference to a compiler-generated field
    ((buFile5.\u0003) this).UpDown = UpDownLocationType.Up;
    // ISSUE: reference to a compiler-generated field
    ((buFile5.\u0003) this).FrontBack = FrontBackType.Front;
    // ISSUE: reference to a compiler-generated field
    ((buFile5.\u0003) this).NotchOPType = ProfileNotchOperationType.Side;
    // ISSUE: reference to a compiler-generated field
    ((buFile5.\u0003) this).NotchStart = 10.0;
    // ISSUE: reference to a compiler-generated field
    ((buFile5.\u0003) this).BasePoint = new Point3D();
    // ISSUE: reference to a compiler-generated field
    ((buFile5.\u0004) this).Diameter = 10.0;
    // ISSUE: reference to a compiler-generated field
    ((buFile5.\u0004) this).Width = 20.0;
    // ISSUE: reference to a compiler-generated field
    ((buFile5.\u0004) this).Height = 20.0;
    // ISSUE: reference to a compiler-generated field
    ((buFile5.\u0004) this).Depth = 5.0;
    // ISSUE: reference to a compiler-generated field
    ((buFile5.\u0004) this).Radius = 0.0;
    // ISSUE: reference to a compiler-generated field
    ((buFile5.\u0004) this).Length = 20.0;
    // ISSUE: reference to a compiler-generated field
    ((buFile5.\u0004) this).Angle = 0.0;
    // ISSUE: reference to a compiler-generated field
    ((buFile5.\u0004) this).Side = 6;
    // ISSUE: reference to a compiler-generated field
    ((buFile5.\u0004) this).ManuelZ = false;
    ((buGCodeCreate) this).Option1 = "";
    ((buGCodeCreate) this).Option2 = "";
    ((buGCodeCreate) this).Option3 = "";
    ((buGCodeCreate) this).Option4 = "";
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }

  public abstract void m0003B2();

  public buMatrix5()
  {
    ((buGCodeCreate) this).IntersectionRules = SortingIntersectionRulesType.LowerIndex;
    ((buGCodeCreate) this).NextFroupRules = SortingNextGroupFindRulesType.ClosestLength;
    ((buGCodeCreate) this).SortResolution = 0.05;
    ((buGCodeCreate) this).ClockDirection = ClockDirectionType.CCW;
    ((buGCodeCreate) this).InsideClockDirection = ClockDirectionType.CCW;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public int Height
  {
    [SpecialName] get => ((buVector5) this).\u0001.GetLength(0);
  }

  public int Width
  {
    [SpecialName] get => ((buVector5) this).\u0001.GetLength(1);
  }

  public double this[int x, int y]
  {
    [SpecialName] get => ((buVector5) this).\u0001[x, y];
    [SpecialName] set => ((buVector5) this).\u0001[x, y] = value;
  }
}
