// Decompiled with JetBrains decompiler
// Type: buClass.Apps.ProfileOperation
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class ProfileOperation : buSerilization
{
  public static string strRectangle = "Rectangle";
  public static string strCircle = "Circle";
  public static string strEllipse = "Ellipse";
  public static string strHole = "Hole";
  public static string strKeyHole = "Key Hole";
  public static string strRoundRect = "Round Rect";
  public static string strSlot = "Slot";
  public static string strNotch = "Notch";
  public static string strFreeDraw = "Free";
  public static string strText = "Text";
  public static string strCut = "Cut";
  public double Depth = 0.0;
  public string Name = "";
  public string ID = "";
  public bool Used = false;
  public bool Enable = true;
  public bool isClamperOver = false;
  public bool MoveSafeBeforeOperation = false;
  public bool MoveSafeAfterOperation = false;
  public ProfileOperationData OperationData = new ProfileOperationData();
  public WorkPlane Plane = new WorkPlane();
  public Quad3D SlopePlane = new Quad3D();
  public planeNames SelectedPlane = planeNames.Top;
  public List<List<eEntities>> Entities = new List<List<eEntities>>();
  public List<List<eEntities>> NoRotatedEntities = new List<List<eEntities>>();
  public List<eEntities> SolidEntities = new List<eEntities>();
  public List<eEntities> AuxEntities = new List<eEntities>();
  public List<List<Pnt3D>> DrawPoints = new List<List<Pnt3D>>();
  public List<List<Pnt3D>> NoRotatedDrawPoints = new List<List<Pnt3D>>();
  public List<List<Pnt3D>> CamPoints = new List<List<Pnt3D>>();
  public List<camBase> CamCalculation = new List<camBase>();
  public camParameters CamParMilling = new camParameters();
  public camParameters CamParNotch = new camParameters();
  public ToolBase Tool = new ToolBase();
  public Pnt3D MinPoint = new Pnt3D();
  public Pnt3D MaxPoint = new Pnt3D();
  public Length3D GeoSize = new Length3D();
  public actionTypeBU Action = actionTypeBU.None;
  public List<ProfileClamper> ClampersOperations = new List<ProfileClamper>();
  public bool Error = false;

  public static void Copy(
    List<List<ProfileOperation>> RefOperation,
    ref List<List<ProfileOperation>> CopiedOperation)
  {
    CopiedOperation.Clear();
    CopiedOperation = new List<List<ProfileOperation>>();
    for (int index = 0; index <= RefOperation.Count - 1; ++index)
    {
      List<ProfileOperation> CopiedOperation1 = new List<ProfileOperation>();
      ProfileOperation.Copy(RefOperation[index], ref CopiedOperation1);
      CopiedOperation.Add(CopiedOperation1);
    }
  }

  public static void Copy(
    List<ProfileOperation> RefOperation,
    ref List<ProfileOperation> CopiedOperation)
  {
    CopiedOperation.Clear();
    CopiedOperation = new List<ProfileOperation>();
    for (int index = 0; index <= RefOperation.Count - 1; ++index)
    {
      ProfileOperation CopiedOperation1 = new ProfileOperation();
      ProfileOperation.Copy(RefOperation[index], ref CopiedOperation1);
      CopiedOperation.Add(CopiedOperation1);
    }
  }

  public static void Copy(ProfileOperation RefOperation, ref ProfileOperation CopiedOperation)
  {
    if (RefOperation.GetType() == typeof (ProfileOperationCircle))
      CopiedOperation = (ProfileOperation) new ProfileOperationCircle((ProfileOperationCircle) RefOperation);
    if (RefOperation.GetType() == typeof (ProfileOperationRectangle))
      CopiedOperation = (ProfileOperation) new ProfileOperationRectangle((ProfileOperationRectangle) RefOperation);
    if (RefOperation.GetType() == typeof (ProfileOperationRoundRectangle))
      CopiedOperation = (ProfileOperation) new ProfileOperationRoundRectangle((ProfileOperationRoundRectangle) RefOperation);
    if (RefOperation.GetType() == typeof (ProfileOperationBarrel))
      CopiedOperation = (ProfileOperation) new ProfileOperationBarrel((ProfileOperationBarrel) RefOperation);
    if (RefOperation.GetType() == typeof (ProfileOperationEllipse))
      CopiedOperation = (ProfileOperation) new ProfileOperationEllipse((ProfileOperationEllipse) RefOperation);
    if (RefOperation.GetType() == typeof (ProfileOperationFreeDraw))
      CopiedOperation = (ProfileOperation) new ProfileOperationFreeDraw((ProfileOperationFreeDraw) RefOperation);
    if (RefOperation.GetType() == typeof (ProfileOperationText))
      CopiedOperation = (ProfileOperation) new ProfileOperationText((ProfileOperationText) RefOperation);
    if (RefOperation.GetType() == typeof (ProfileOperationHole))
      CopiedOperation = (ProfileOperation) new ProfileOperationHole((ProfileOperationHole) RefOperation);
    if (RefOperation.GetType() == typeof (ProfileOperationSlot))
      CopiedOperation = (ProfileOperation) new ProfileOperationSlot((ProfileOperationSlot) RefOperation);
    if (RefOperation.GetType() == typeof (ProfileOperationCut))
      CopiedOperation = (ProfileOperation) new ProfileOperationCut((ProfileOperationCut) RefOperation);
    if (RefOperation.GetType() == typeof (ProfileOperationNotch))
      CopiedOperation = (ProfileOperation) new ProfileOperationNotch((ProfileOperationNotch) RefOperation);
    if (RefOperation.GetType() == typeof (ProfileOperationMoveClamper))
      CopiedOperation = (ProfileOperation) new ProfileOperationMoveClamper((ProfileOperationMoveClamper) RefOperation);
    CopiedOperation.ClampersOperations.Clear();
    CopiedOperation.ClampersOperations = new List<ProfileClamper>();
    for (int index = 0; index <= RefOperation.ClampersOperations.Count - 1; ++index)
    {
      ProfileClamper profileClamper = new ProfileClamper(RefOperation.ClampersOperations[index]);
      CopiedOperation.ClampersOperations.Add(profileClamper);
    }
    CopiedOperation.Entities.Clear();
    eEntities.CopyEntities(RefOperation.Entities, ref CopiedOperation.Entities);
    CopiedOperation.AuxEntities.Clear();
    eEntities.CopyEntities(RefOperation.AuxEntities, ref CopiedOperation.AuxEntities);
    CopiedOperation.SolidEntities.Clear();
    eEntities.CopyEntities(RefOperation.SolidEntities, ref CopiedOperation.SolidEntities);
    CopiedOperation.NoRotatedEntities.Clear();
    eEntities.CopyEntities(RefOperation.NoRotatedEntities, ref CopiedOperation.NoRotatedEntities);
    CopiedOperation.CamCalculation.Clear();
    CopiedOperation.CamCalculation = new List<camBase>();
    for (int index = 0; index <= RefOperation.CamCalculation.Count - 1; ++index)
    {
      camBase camBase = new camBase(RefOperation.CamCalculation[index]);
      CopiedOperation.CamCalculation.Add(camBase);
    }
  }

  public static ArrayList ToDef(List<List<ProfileOperation>> Items, string Char, int Space)
  {
    string str = new string(' ', Space + 2);
    ArrayList def = new ArrayList();
    for (int index1 = 0; index1 <= Items.Count - 1; ++index1)
    {
      ArrayList arrayList = new ArrayList();
      arrayList.Add((object) (str + "<ProfileOperationMain>"));
      for (int index2 = 0; index2 <= Items[index1].Count - 1; ++index2)
      {
        arrayList.Add((object) (str + "<ProfileOperation>"));
        arrayList.AddRange((ICollection) ProfileOperation.ToDef(Items[index1], Char, Space + 2).ToArray());
        arrayList.Add((object) (str + "</ProfileOperation>"));
      }
      arrayList.Add((object) (str + "</ProfileOperationMain>"));
      def.AddRange((ICollection) arrayList.ToArray());
    }
    return def;
  }

  public static ArrayList ToDef(List<ProfileOperation> Items, string Char, int Space)
  {
    string str = new string(' ', Space + 2);
    ArrayList def = new ArrayList();
    for (int index = 0; index <= Items.Count - 1; ++index)
    {
      ArrayList arrayList = new ArrayList();
      arrayList.Add((object) $"{str}<ProfileOperation{Char}>");
      arrayList.AddRange((ICollection) ProfileOperation.ToDef(Items[index], "", Space + 2).ToArray());
      arrayList.Add((object) $"{str}</ProfileOperation{Char}>");
      def.AddRange((ICollection) arrayList.ToArray());
    }
    return def;
  }

  public static ArrayList ToDef(ProfileOperation Item, string Char, int Space)
  {
    string str = new string(' ', Space);
    ArrayList def = new ArrayList();
    def.AddRange((ICollection) Item.ToDefAll(Char, Space + 2, SerilizationMode.MultiLine));
    def.AddRange((ICollection) Item.OperationData.CircleData.ToDefAll(Char, Space + 2, SerilizationMode.MultiLine));
    def.AddRange((ICollection) Item.OperationData.RectangleData.ToDefAll(Char, Space + 2, SerilizationMode.MultiLine));
    def.AddRange((ICollection) Item.OperationData.BarelData.ToDefAll(Char, Space + 2, SerilizationMode.MultiLine));
    def.AddRange((ICollection) Item.OperationData.EllipseData.ToDefAll(Char, Space + 2, SerilizationMode.MultiLine));
    def.AddRange((ICollection) Item.OperationData.FreeDrawData.ToDefAll(Char, Space + 2, SerilizationMode.MultiLine));
    def.AddRange((ICollection) Item.OperationData.HoleData.ToDefAll(Char, Space + 2, SerilizationMode.MultiLine));
    def.AddRange((ICollection) Item.OperationData.NotchData.ToDefAll(Char, Space + 2, SerilizationMode.MultiLine));
    def.AddRange((ICollection) Item.OperationData.RectangleRoundData.ToDefAll(Char, Space + 2, SerilizationMode.MultiLine));
    def.AddRange((ICollection) Item.OperationData.SlotData.ToDefAll(Char, Space + 2, SerilizationMode.MultiLine));
    def.AddRange((ICollection) Item.OperationData.TextData.ToDefAll(Char, Space + 2, SerilizationMode.MultiLine));
    def.AddRange((ICollection) Item.OperationData.CutData.ToDefAll(Char, Space + 2, SerilizationMode.MultiLine));
    def.Add((object) (new string(' ', Space + 2) + "<ClampersOperations>"));
    for (int index = 0; index <= Item.ClampersOperations.Count - 1; ++index)
      def.AddRange((ICollection) Item.ClampersOperations[index].ToDefAll(Char, Space + 6, SerilizationMode.MultiLine));
    def.Add((object) (new string(' ', Space + 2) + "</ClampersOperations>"));
    def.Add((object) (new string(' ', Space + 2) + "<DepthSelectedValues>"));
    for (int index = 0; index <= Item.OperationData.DepthSelectedValues.Count - 1; ++index)
      def.AddRange((ICollection) Item.OperationData.DepthSelectedValues[index].ToDefAll(Char, Space + 6, SerilizationMode.MultiLine));
    def.Add((object) (new string(' ', Space + 2) + "</DepthSelectedValues>"));
    def.Add((object) (new string(' ', Space + 2) + "<DepthValues>"));
    for (int index = 0; index <= Item.OperationData.DepthValues.Count - 1; ++index)
      def.AddRange((ICollection) Item.OperationData.DepthValues[index].ToDefAll(Char, Space + 6, SerilizationMode.MultiLine));
    def.Add((object) (new string(' ', Space + 2) + "</DepthValues>"));
    def.Add((object) (new string(' ', Space + 2) + "<OperationsDrawPoints>"));
    for (int index = 0; index <= Item.Entities.Count - 1; ++index)
    {
      def.Add((object) (new string(' ', Space + 4) + "<PointVertices>"));
      def.Add((object) (new string(' ', Space + 4) + "</PointVertices>"));
    }
    def.Add((object) (new string(' ', Space + 2) + "</OperationsDrawPoints>"));
    return def;
  }

  public static void Decode(ArrayList AL, ref ProfileOperation OP)
  {
    OP = new ProfileOperation();
    if (AL.Count <= 0)
      return;
    string str = AL[0].ToString();
    if (str.IndexOf("ProfileOperationCircle") >= 0)
    {
      OP = (ProfileOperation) new ProfileOperationCircle();
      buSerilization.Decode(AL, "", SerilizationMode.MultiLine, (object) OP);
    }
    if (str.IndexOf("ProfileOperationRectangle") >= 0)
    {
      OP = (ProfileOperation) new ProfileOperationRectangle();
      buSerilization.Decode(AL, "", SerilizationMode.MultiLine, (object) OP);
    }
    if (str.IndexOf("ProfileOperationBarrel") >= 0)
    {
      OP = (ProfileOperation) new ProfileOperationBarrel();
      buSerilization.Decode(AL, "", SerilizationMode.MultiLine, (object) OP);
    }
    if (str.IndexOf("ProfileOperationEllipse") >= 0)
    {
      OP = (ProfileOperation) new ProfileOperationEllipse();
      buSerilization.Decode(AL, "", SerilizationMode.MultiLine, (object) OP);
    }
    if (str.IndexOf("ProfileOperationSlot") >= 0)
    {
      OP = (ProfileOperation) new ProfileOperationSlot();
      buSerilization.Decode(AL, "", SerilizationMode.MultiLine, (object) OP);
    }
    if (str.IndexOf("ProfileOperationCut") >= 0)
    {
      OP = (ProfileOperation) new ProfileOperationCut();
      buSerilization.Decode(AL, "", SerilizationMode.MultiLine, (object) OP);
    }
    if (str.IndexOf("ProfileOperationFreeDraw") >= 0)
    {
      OP = (ProfileOperation) new ProfileOperationFreeDraw();
      buSerilization.Decode(AL, "", SerilizationMode.MultiLine, (object) OP);
    }
    if (str.IndexOf("ProfileOperationHole") >= 0)
    {
      OP = (ProfileOperation) new ProfileOperationHole();
      buSerilization.Decode(AL, "", SerilizationMode.MultiLine, (object) OP);
    }
    if (str.IndexOf("ProfileOperationNotch") >= 0)
    {
      OP = (ProfileOperation) new ProfileOperationNotch();
      buSerilization.Decode(AL, "", SerilizationMode.MultiLine, (object) OP);
    }
    if (str.IndexOf("ProfileOperationRoundRectangle") >= 0)
    {
      OP = (ProfileOperation) new ProfileOperationRoundRectangle();
      buSerilization.Decode(AL, "", SerilizationMode.MultiLine, (object) OP);
    }
    if (str.IndexOf("ProfileOperationText") >= 0)
    {
      OP = (ProfileOperation) new ProfileOperationText();
      buSerilization.Decode(AL, "", SerilizationMode.MultiLine, (object) OP);
    }
    if (str.IndexOf("ProfileOperationMoveClamper") >= 0)
    {
      OP = (ProfileOperation) new ProfileOperationMoveClamper();
      buSerilization.Decode(AL, "", SerilizationMode.MultiLine, (object) OP);
    }
    buSerilization.Decode(AL, "", SerilizationMode.MultiLine, (object) OP.OperationData);
    List<string> CalcList1 = new List<string>();
    buStatics.ListToSpecificList("<ProfileOperationDataCircle>", "</ProfileOperationDataCircle>", true, AL, ref CalcList1);
    buSerilization.Decode(CalcList1, "", SerilizationMode.MultiLine, (object) OP.OperationData.CircleData);
    List<string> CalcList2 = new List<string>();
    buStatics.ListToSpecificList("<ProfileOperationDataRectangle>", "</ProfileOperationDataRectangle>", true, AL, ref CalcList2);
    buSerilization.Decode(CalcList2, "", SerilizationMode.MultiLine, (object) OP.OperationData.RectangleData);
    List<string> CalcList3 = new List<string>();
    buStatics.ListToSpecificList("<ProfileOperationDataBarel>", "</ProfileOperationDataBarel>", true, AL, ref CalcList3);
    buSerilization.Decode(CalcList3, "", SerilizationMode.MultiLine, (object) OP.OperationData.BarelData);
    List<string> CalcList4 = new List<string>();
    buStatics.ListToSpecificList("<ProfileOperationDataEllipse>", "</ProfileOperationDataEllipse>", true, AL, ref CalcList4);
    buSerilization.Decode(CalcList4, "", SerilizationMode.MultiLine, (object) OP.OperationData.EllipseData);
    CalcList4 = new List<string>();
    buStatics.ListToSpecificList("<ProfileOperationDataFreeDraw>", "</ProfileOperationDataFreeDraw>", true, AL, ref CalcList4);
    buSerilization.Decode(CalcList4, "", SerilizationMode.MultiLine, (object) OP.OperationData.FreeDrawData);
    CalcList4 = new List<string>();
    buStatics.ListToSpecificList("<ProfileOperationDataHole>", "</ProfileOperationDataHole>", true, AL, ref CalcList4);
    buSerilization.Decode(CalcList4, "", SerilizationMode.MultiLine, (object) OP.OperationData.HoleData);
    CalcList4 = new List<string>();
    buStatics.ListToSpecificList("<ProfileOperationDataNotch>", "</ProfileOperationDataNotch>", true, AL, ref CalcList4);
    buSerilization.Decode(CalcList4, "", SerilizationMode.MultiLine, (object) OP.OperationData.NotchData);
    CalcList4 = new List<string>();
    buStatics.ListToSpecificList("<ProfileOperationDataRectangleRound>", "</ProfileOperationDataRectangleRound>", true, AL, ref CalcList4);
    buSerilization.Decode(CalcList4, "", SerilizationMode.MultiLine, (object) OP.OperationData.RectangleRoundData);
    CalcList4 = new List<string>();
    buStatics.ListToSpecificList("<ProfileOperationDataSlot>", "</ProfileOperationDataSlot>", true, AL, ref CalcList4);
    buSerilization.Decode(CalcList4, "", SerilizationMode.MultiLine, (object) OP.OperationData.SlotData);
    CalcList4 = new List<string>();
    buStatics.ListToSpecificList("<ProfileOperationDataCut>", "</ProfileOperationDataCut>", true, AL, ref CalcList4);
    buSerilization.Decode(CalcList4, "", SerilizationMode.MultiLine, (object) OP.OperationData.CutData);
    CalcList4 = new List<string>();
    buStatics.ListToSpecificList("<ProfileOperationDataText>", "</ProfileOperationDataText>", true, AL, ref CalcList4);
    buSerilization.Decode(CalcList4, "", SerilizationMode.MultiLine, (object) OP.OperationData.TextData);
    CalcList4 = new List<string>();
    List<List<string>> CalcList5 = new List<List<string>>();
    buStatics.ListToSpecificList("<DepthSelectedValues>", "</DepthSelectedValues>", true, AL, ref CalcList4);
    buStatics.ListToSpecificList("<DepthHeight>", "</DepthHeight>", true, CalcList4, ref CalcList5);
    for (int index = 0; index <= CalcList5.Count - 1; ++index)
    {
      DepthPosition depthPosition = new DepthPosition();
      buSerilization.Decode(CalcList5[index], "", SerilizationMode.MultiLine, (object) depthPosition);
      OP.OperationData.DepthSelectedValues.Add(depthPosition);
    }
    CalcList4 = new List<string>();
    List<List<string>> CalcList6 = new List<List<string>>();
    buStatics.ListToSpecificList("<DepthValues>", "</DepthValues>", true, AL, ref CalcList4);
    buStatics.ListToSpecificList("<DepthHeight>", "</DepthHeight>", true, CalcList4, ref CalcList6);
    for (int index = 0; index <= CalcList6.Count - 1; ++index)
    {
      DepthPosition depthPosition = new DepthPosition();
      buSerilization.Decode(CalcList6[index], "", SerilizationMode.MultiLine, (object) depthPosition);
      OP.OperationData.DepthValues.Add(depthPosition);
    }
    CalcList4 = new List<string>();
    List<List<string>> CalcList7 = new List<List<string>>();
    buStatics.ListToSpecificList("<ClampersOperations>", "</ClampersOperations>", true, AL, ref CalcList4);
    buStatics.ListToSpecificList("<ProfileClamper>", "</ProfileClamper>", true, CalcList4, ref CalcList7);
    for (int index = 0; index <= CalcList7.Count - 1; ++index)
    {
      ProfileClamper profileClamper = new ProfileClamper();
      buSerilization.Decode(CalcList7[index], "", SerilizationMode.MultiLine, (object) profileClamper);
      OP.ClampersOperations.Add(profileClamper);
    }
  }

  public override string ToString()
  {
    if (this.GetType() == typeof (ProfileOperationCircle))
      return $"{this.Name} - {ProfileOperation.strCircle} D: {((ProfileOperationCircle) this).Diameter.ToString("f3")}";
    if (this.GetType() == typeof (ProfileOperationRectangle))
      return $"{this.Name} - {ProfileOperation.strRectangle} W: {((ProfileOperationRectangle) this).Width.ToString("f3")} - H: {((ProfileOperationRectangle) this).Height.ToString("f3")}";
    if (this.GetType() == typeof (ProfileOperationRoundRectangle))
      return $"{this.Name} - {ProfileOperation.strRoundRect} W: {((ProfileOperationRoundRectangle) this).Width.ToString("f3")} - H: {((ProfileOperationRoundRectangle) this).Height.ToString("f3")} - R: {((ProfileOperationRoundRectangle) this).Radius.ToString("f3")}";
    if (this.GetType() == typeof (ProfileOperationSlot))
      return $"{this.Name} - {ProfileOperation.strSlot}W: {((ProfileOperationSlot) this).Width.ToString("f3")} - D: {((ProfileOperationSlot) this).Diameter.ToString("f3")}";
    if (this.GetType() == typeof (ProfileOperationBarrel))
      return $"{this.Name} - W: {((ProfileOperationBarrel) this).Width.ToString("f3")} - D: {((ProfileOperationBarrel) this).Diameter.ToString("f3")}";
    if (this.GetType() == typeof (ProfileOperationEllipse))
      return $"{this.Name} - {ProfileOperation.strEllipse}W: {((ProfileOperationEllipse) this).Width.ToString("f3")} - H: {((ProfileOperationEllipse) this).Height.ToString("f3")}";
    if (this.GetType() == typeof (ProfileOperationHole))
      return $"{this.Name} - {ProfileOperation.strHole}D: {((ProfileOperationHole) this).Diameter.ToString("f3")}";
    if (this.GetType() == typeof (ProfileOperationNotch))
      return $"{this.Name} - {ProfileOperation.strNotch}W: {((ProfileOperationNotch) this).Width.ToString("f3")} - H: {((ProfileOperationNotch) this).Height.ToString("f3")}";
    if (this.GetType() == typeof (ProfileOperationFreeDraw))
      return $"{this.Name} -{ProfileOperation.strFreeDraw} W: {this.DrawPoints.Count.ToString("f3")} - H: {((ProfileOperationFreeDraw) this).Height.ToString("f3")}";
    if (!(this.GetType() == typeof (ProfileOperationText)))
      return this.Name;
    return $"{this.Name} - {ProfileOperation.strText}T: {((ProfileOperationText) this).Text.ToString()} - H: {((ProfileOperationText) this).Height.ToString("f3")}";
  }
}
