// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.F_Move
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms;

public class F_Move : Form
{
  internal Label \u0001;
  internal Label \u0002;
  internal Label \u0003;
  internal NumericUpDown \u0001;
  internal Label \u0004;
  internal Label \u0005;
  internal Label \u0006;
  internal Panel \u0001;
  internal NumericUpDown \u0002;
  internal Panel \u0002;
  internal Button \u0001;
  internal ImageList \u0001;
  internal Button \u0002;
  internal Panel \u0003;
  internal ComboBox \u0001;
  internal Label \u0007;
  internal Label \u0008;
  internal Panel \u0004;
  internal Label \u000E;
  internal Label \u000F;
  internal CheckBox \u0001;
  public static byte f000AD4;
  public FormProperties PropertiesForm;
  private int \u0001;
  private int \u0002;
  public AnalyseEntitiesResult Result;

  internal LinearPath \u0002([In] Point3D[] obj0) => new LinearPath(obj0);

  internal LinearPath \u0003([In] Point3D[] obj0) => new LinearPath(obj0);

  public F_Move()
  {
  }

  internal bool \u0001([In] LayerBase5 obj0)
  {
    return ((DevideEventFormVars) obj0).Name == ((F_CutterMachineSettings) this).\u0001;
  }

  public F_Move()
  {
  }

  internal bool \u0001([In] LayerBase5 obj0)
  {
    return ((DevideEventFormVars) obj0).Name == ((F_CutterMachineSettings) this).\u0001;
  }

  public F_Move()
  {
    ((F_CutterMachineSettings) this).AxesList = new List<MachineAxisInfo>();
    ((F_CutterMachineSettings) this).MCodeList = new List<MachineMCodeInfo>();
    ((F_CutterMachineSettings) this).OtherCodeList = new List<MachineOtherCodeInfo>();
    ((F_CutterMachineSettings) this).ExstraTime = 0.0;
    ((F_CutterMachineSettings) this).LengthType = LengthUnit.mm;
    ((F_CutterOffsetEntities) this).SpeedType = SpeedUnit.mmPerMin;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public F_Move(MachineGCodeConfigrasyon data)
  {
    ((F_CutterMachineSettings) this).AxesList = new List<MachineAxisInfo>();
    ((F_CutterMachineSettings) this).MCodeList = new List<MachineMCodeInfo>();
    ((F_CutterMachineSettings) this).OtherCodeList = new List<MachineOtherCodeInfo>();
    ((F_CutterMachineSettings) this).ExstraTime = 0.0;
    ((F_CutterMachineSettings) this).LengthType = LengthUnit.mm;
    ((F_CutterOffsetEntities) this).SpeedType = SpeedUnit.mmPerMin;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
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
    for (int index = 0; index <= ((F_CutterMachineSettings) data).AxesList.Count - 1; ++index)
      ((F_CutterMachineSettings) this).AxesList.Add((MachineAxisInfo) new F_Devide(((F_CutterMachineSettings) data).AxesList[index]));
    for (int index = 0; index <= ((F_CutterMachineSettings) data).MCodeList.Count - 1; ++index)
      ((F_CutterMachineSettings) this).MCodeList.Add((MachineMCodeInfo) new F_Devide(((F_CutterMachineSettings) data).MCodeList[index]));
    for (int index = 0; index <= ((F_CutterMachineSettings) data).OtherCodeList.Count - 1; ++index)
      ((F_CutterMachineSettings) this).OtherCodeList.Add((MachineOtherCodeInfo) new F_Devide(((F_CutterMachineSettings) data).OtherCodeList[index]));
  }

  public override string ToString()
  {
    int count = ((F_CutterMachineSettings) this).AxesList.Count;
    string str1 = count.ToString("");
    count = ((F_CutterMachineSettings) this).MCodeList.Count;
    string str2 = count.ToString("");
    return $"Axis : {str1} - MCode: {str2}";
  }

  public static ArrayList ToDef(MachineGCodeConfigrasyon GCodeConfig, int Space)
  {
    string str1 = new string(' ', Space);
    ArrayList def = new ArrayList();
    GCodeConfig.ToDefAll("", Space, (SerilizationMode5) 1);
    def.Add((object) (str1 + "<MachineGCodeConfigrasyonMain>"));
    string str2 = buImage5.SpaceChar(Space + 2) + buSerilization5.ClassToString((object) GCodeConfig);
    def.Add((object) str2);
    def.Add((object) (str1 + "</MachineGCodeConfigrasyonMain>"));
    def.Add((object) (str1 + "<MachineAxisInfoMain>"));
    for (int index = 0; index <= ((F_CutterMachineSettings) GCodeConfig).AxesList.Count - 1; ++index)
      def.AddRange((ICollection) ((F_CutterMachineSettings) GCodeConfig).AxesList[index].ToDefAll("", 2 + Space, (SerilizationMode5) 1));
    def.Add((object) (str1 + "</MachineAxisInfoMain>"));
    def.Add((object) (str1 + "<MachineMCodeInfoMain>"));
    for (int index = 0; index <= ((F_CutterMachineSettings) GCodeConfig).MCodeList.Count - 1; ++index)
      def.AddRange((ICollection) ((F_CutterMachineSettings) GCodeConfig).MCodeList[index].ToDefAll("", 2 + Space, (SerilizationMode5) 1));
    def.Add((object) (str1 + "</MachineMCodeInfoMain>"));
    def.Add((object) (str1 + "<MachineOtherCodeInfoMain>"));
    for (int index = 0; index <= ((F_CutterMachineSettings) GCodeConfig).OtherCodeList.Count - 1; ++index)
      def.AddRange((ICollection) ((F_CutterMachineSettings) GCodeConfig).OtherCodeList[index].ToDefAll("", 2 + Space, (SerilizationMode5) 1));
    def.Add((object) (str1 + "</MachineOtherCodeInfoMain>"));
    return def;
  }

  public static void Decode(List<string> Lines, ref MachineGCodeConfigrasyon GCodeConfig)
  {
    List<string> CalcList1 = new List<string>();
    buStatics.ListToSpecificList("<MachineGCodeConfigrasyonMain>", "</MachineGCodeConfigrasyonMain>", false, Lines, ref CalcList1);
    if (CalcList1.Count > 0)
    {
      object ObjPar = (object) GCodeConfig;
      buSerilization5.StringToClass(ref ObjPar, CalcList1[0]);
    }
    CalcList1.Clear();
    List<List<string>> CalcList2 = new List<List<string>>();
    buStatics.ListToSpecificList("<MachineAxisInfo>", "</MachineAxisInfo>", true, Lines, ref CalcList2);
    if (CalcList2.Count > 0)
    {
      for (int index = 0; index <= CalcList2.Count - 1; ++index)
      {
        MachineAxisInfo machineAxisInfo = (MachineAxisInfo) new F_Move();
        buSerilization5.Decode(CalcList2[index], "", (SerilizationMode5) 1, (object) machineAxisInfo);
        ((F_CutterMachineSettings) GCodeConfig).AxesList.Add(machineAxisInfo);
        CalcList2[index].Clear();
      }
      CalcList2.Clear();
    }
    List<List<string>> CalcList3 = new List<List<string>>();
    buStatics.ListToSpecificList("<MachineMCodeInfo>", "</MachineMCodeInfo>", true, Lines, ref CalcList3);
    if (CalcList3.Count > 0)
    {
      for (int index = 0; index <= CalcList3.Count - 1; ++index)
      {
        MachineMCodeInfo machineMcodeInfo = (MachineMCodeInfo) new F_Devide();
        buSerilization5.Decode(CalcList3[index], "", (SerilizationMode5) 1, (object) machineMcodeInfo);
        ((F_CutterMachineSettings) GCodeConfig).MCodeList.Add(machineMcodeInfo);
        CalcList3[index].Clear();
      }
      CalcList3.Clear();
    }
    List<List<string>> CalcList4 = new List<List<string>>();
    buStatics.ListToSpecificList("<MachineOtherCodeInfo>", "</MachineOtherCodeInfo>", true, Lines, ref CalcList4);
    if (CalcList4.Count <= 0)
      return;
    for (int index = 0; index <= CalcList4.Count - 1; ++index)
    {
      MachineOtherCodeInfo machineOtherCodeInfo = (MachineOtherCodeInfo) new F_Devide();
      buSerilization5.Decode(CalcList4[index], "", (SerilizationMode5) 1, (object) machineOtherCodeInfo);
      ((F_CutterMachineSettings) GCodeConfig).OtherCodeList.Add(machineOtherCodeInfo);
      CalcList4[index].Clear();
    }
    CalcList4.Clear();
  }

  public abstract void m000954();

  public F_Move()
  {
    ((F_CutterOffsetEntities) this).AxisName = "X";
    ((F_CutterOffsetEntities) this).MaxSpeed = 3000.0;
    ((F_CutterOffsetEntities) this).Acceleration = 10000.0;
    ((F_CutterOffsetEntities) this).Deceleration = 10000.0;
    ((F_CutterOffsetEntities) this).Jerk = 4000.0;
    ((F_CutterOffsetEntities) this).AxisExplanation = "";
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public event OkCommandWithDataEventHandler CommandOk;

  public event CancelCommandEventHandler CommandCancel;

  public event ApplyCommandWithDataEventHandler CommandApply;
}
