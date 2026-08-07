// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.buMarbleControls
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

public class buMarbleControls
{
  public bool UpdateTree;
  public static int None;
  public static int Main;
  public static int Cancel;
  public static int Sink;
  public static int BuiltIn;
  public static int Tap;

  public buMarbleControls()
  {
    ((marbleProfileCutPars) this).SC1Left = 0;
    ((marbleProfileCutPars) this).SC1Top = 0;
    ((marbleProfileCutPars) this).SC1Width = 1920;
    ((marbleProfileCutPars) this).SC1Height = 1080;
    ((marbleProfileCutPars) this).SC1AutoSave = false;
    ((marbleProfileCutPars) this).SC1Enable = true;
    ((marbleProfileCutPars) this).SC2Left = 0;
    ((marbleProfileCutPars) this).SC2Top = 0;
    ((marbleProfileCutPars) this).SC2Width = 1920;
    ((marbleProfileCutPars) this).SC2Height = 1080;
    ((marbleProfileCutPars) this).SC2AutoSave = false;
    ((marbleProfileCutPars) this).SC2Enable = true;
    ((marbleProfileCutPars) this).SC3Left = 0;
    ((marbleProfileCutPars) this).SC3Top = 0;
    ((marbleProfileCutPars) this).SC3Width = 1920;
    ((marbleProfileCutPars) this).SC3Height = 1080;
    ((marbleProfileCutPars) this).SC3AutoSave = false;
    ((marbleProfileCutPars) this).SC3Enable = true;
    ((marbleProfileCutPars) this).SC4Left = 0;
    ((marbleProfileCutPars) this).SC4Top = 0;
    ((marbleProfileCutPars) this).SC4Width = 1920;
    ((marbleProfileCutPars) this).SC4Height = 1080;
    ((marbleProfileCutPars) this).SC4AutoSave = false;
    ((marbleProfileCutPars) this).SC4Enable = true;
    ((marbleProfileCutPars) this).SC5Left = 0;
    ((marbleProfileCutPars) this).SC5Top = 0;
    ((marbleProfileCutPars) this).SC5Width = 1920;
    ((marbleProfileCutPars) this).SC5Height = 1080;
    ((marbleProfileCutPars) this).SC5AutoSave = false;
    ((marbleProfileCutPars) this).SC5Enable = true;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buMarbleControls(MarbleScreenCaptureSettings data)
  {
    ((marbleProfileCutPars) this).SC1Left = 0;
    ((marbleProfileCutPars) this).SC1Top = 0;
    ((marbleProfileCutPars) this).SC1Width = 1920;
    ((marbleProfileCutPars) this).SC1Height = 1080;
    ((marbleProfileCutPars) this).SC1AutoSave = false;
    ((marbleProfileCutPars) this).SC1Enable = true;
    ((marbleProfileCutPars) this).SC2Left = 0;
    ((marbleProfileCutPars) this).SC2Top = 0;
    ((marbleProfileCutPars) this).SC2Width = 1920;
    ((marbleProfileCutPars) this).SC2Height = 1080;
    ((marbleProfileCutPars) this).SC2AutoSave = false;
    ((marbleProfileCutPars) this).SC2Enable = true;
    ((marbleProfileCutPars) this).SC3Left = 0;
    ((marbleProfileCutPars) this).SC3Top = 0;
    ((marbleProfileCutPars) this).SC3Width = 1920;
    ((marbleProfileCutPars) this).SC3Height = 1080;
    ((marbleProfileCutPars) this).SC3AutoSave = false;
    ((marbleProfileCutPars) this).SC3Enable = true;
    ((marbleProfileCutPars) this).SC4Left = 0;
    ((marbleProfileCutPars) this).SC4Top = 0;
    ((marbleProfileCutPars) this).SC4Width = 1920;
    ((marbleProfileCutPars) this).SC4Height = 1080;
    ((marbleProfileCutPars) this).SC4AutoSave = false;
    ((marbleProfileCutPars) this).SC4Enable = true;
    ((marbleProfileCutPars) this).SC5Left = 0;
    ((marbleProfileCutPars) this).SC5Top = 0;
    ((marbleProfileCutPars) this).SC5Width = 1920;
    ((marbleProfileCutPars) this).SC5Height = 1080;
    ((marbleProfileCutPars) this).SC5AutoSave = false;
    ((marbleProfileCutPars) this).SC5Enable = true;
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
}
