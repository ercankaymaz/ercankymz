// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buEntities.buCircle
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buControls.Forms.WinControlForms.ClassForm;
using buCore;
using buEyeBaseVer5.ClassViewer;
using buEyeBaseVer5.Forms.Cam;
using buEyeBaseVer5.Forms.ClassForm;
using buEyeBaseVer5.Variables;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.buEntities;

[Serializable]
public class buCircle : buEntity
{
  public buSpin spn_BAngleLimitStartInXZPlane;
  public buSpin spn_BAngleLimitEndInXZPlane;
  public buSpin spn_MaxAngleChange;

  [CompilerGenerated]
  [SpecialName]
  public void remove_OkButtonClicked(EventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    EventHandler eventHandler = ((buTool) this).\u0001;
    EventHandler comparand;
    do
    {
      comparand = eventHandler;
      // ISSUE: reference to a compiler-generated field
      eventHandler = Interlocked.CompareExchange<EventHandler>(ref ((buTool) this).\u0001, comparand - value, comparand);
    }
    while (eventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_CancelButtonClicked(EventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    EventHandler eventHandler = ((buTool) this).\u0002;
    EventHandler comparand;
    do
    {
      comparand = eventHandler;
      // ISSUE: reference to a compiler-generated field
      eventHandler = Interlocked.CompareExchange<EventHandler>(ref ((buTool) this).\u0002, comparand + value, comparand);
    }
    while (eventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_CancelButtonClicked(EventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    EventHandler eventHandler = ((buTool) this).\u0002;
    EventHandler comparand;
    do
    {
      comparand = eventHandler;
      // ISSUE: reference to a compiler-generated field
      eventHandler = Interlocked.CompareExchange<EventHandler>(ref ((buTool) this).\u0002, comparand - value, comparand);
    }
    while (eventHandler != comparand);
  }

  public new void Init()
  {
    List<cParameter5> Vars = new List<cParameter5>();
    List<string> Captions = new List<string>();
    buSerilization5.GetClassVariables(((buArcCam) this).ClassObject, ref Vars);
    buSerilization5.GetCaptionsOfClass(((buArcCam) this).ClassObject, ref Captions);
    ((buTool) this).ControlList.Clear();
    ((buTool) this).ControlList = new List<Control>();
    int num = 0;
    ((buTool) this).\u0001.Controls.Clear();
    for (int index = 0; index <= Vars.Count - 1; ++index)
    {
      System.Type type = ((EditorRuntimeSettings) Vars[index]).Value.GetType();
      ((buTool) this).\u0001 = new Label();
      ((buTool) this).\u0001.BorderStyle = BorderStyle.FixedSingle;
      ((buTool) this).\u0001.Text = ((EditorRuntimeSettings) Vars[index]).Name;
      if (Captions.Count > 0 & index <= Captions.Count - 1)
        ((buTool) this).\u0001.Text = Captions[index];
      if (((buLineCam) this).ParCaptions.Count > 0 & index <= ((buLineCam) this).ParCaptions.Count - 1)
        ((buTool) this).\u0001.Text = ((buLineCam) this).ParCaptions[index];
      ((buTool) this).\u0001.Font = ((buLinearPathCam) this).FontCaptions;
      ((buTool) this).\u0001.Size = new Size(((Control) this).Width - ((buLinearPathCam) this).ValueWidth - ((buCompositeCurveCam) this).RowSpace * 9, ((buCompositeCurveCam) this).RowHeight);
      ((buTool) this).\u0001.Location = new Point(((buCompositeCurveCam) this).RowSpace, ((buCompositeCurveCam) this).RowSpace + num * (((buCompositeCurveCam) this).RowHeight + ((buCompositeCurveCam) this).RowSpace));
      if (type == typeof (ColorType))
      {
        ColorType colorType1 = (ColorType) new GeometryTableItem();
        ColorType colorType2 = (ColorType) ((EditorRuntimeSettings) Vars[index]).Value;
        bool result = false;
        bool.TryParse(((EditorRuntimeSettings) Vars[index]).ValueAsString, out result);
        ((buTool) this).\u0001 = (setLabelControl) new buArc();
        ref setLabelControl local = ref ((buTool) this).\u0001;
        string str = colorType2.ToString();
        string name = ((EditorRuntimeSettings) Vars[index]).Name;
        Color color = ((hmiUIOptions) colorType2).Color;
        \u0007.\u0001.\u0001(ref local, (buClassViewerColor5) this, str, color, name);
        ((buTool) this).\u0001.DoubleClick += new EventHandler(this.\u0001);
        ((buTool) this).\u0001.Location = new Point(((buTool) this).\u0001.Left + ((buTool) this).\u0001.Width + ((buCompositeCurveCam) this).RowSpace, ((buCompositeCurveCam) this).RowSpace + num * (((buCompositeCurveCam) this).RowHeight + ((buCompositeCurveCam) this).RowSpace));
        ((buShapeVisualition) ((buTool) this).\u0001).EditValue = ((EditorRuntimeSettings) Vars[index]).Value;
        ((buTool) this).\u0001.Font = new Font("Times New Roman", 8f);
        new ToolTip().SetToolTip((Control) ((buTool) this).\u0001, ((buTool) this).\u0001.Text);
        ((buTool) this).\u0001.Controls.Add((Control) ((buTool) this).\u0001);
        ((buTool) this).\u0001.Controls.Add((Control) ((buTool) this).\u0001);
        ((buTool) this).ControlList.Add((Control) ((buTool) this).\u0001);
        ++num;
      }
      if (type == typeof (ColorDrawType))
      {
        ColorDrawType colorDrawType1 = (ColorDrawType) new CircularSpeedReduction();
        ColorDrawType colorDrawType2 = (ColorDrawType) ((EditorRuntimeSettings) Vars[index]).Value;
        bool result = false;
        bool.TryParse(((EditorRuntimeSettings) Vars[index]).ValueAsString, out result);
        ((buTool) this).\u0001 = (setLabelControl) new buArc();
        ref setLabelControl local = ref ((buTool) this).\u0001;
        string str = colorDrawType2.ToString();
        string name = ((EditorRuntimeSettings) Vars[index]).Name;
        Color color = ((hmiUIDataGridView) colorDrawType2).Color;
        \u0007.\u0001.\u0001(ref local, (buClassViewerColor5) this, str, color, name);
        ((buTool) this).\u0001.DoubleClick += new EventHandler(this.\u0001);
        ((buTool) this).\u0001.Location = new Point(((buTool) this).\u0001.Left + ((buTool) this).\u0001.Width + ((buCompositeCurveCam) this).RowSpace, ((buCompositeCurveCam) this).RowSpace + num * (((buCompositeCurveCam) this).RowHeight + ((buCompositeCurveCam) this).RowSpace));
        ((buShapeVisualition) ((buTool) this).\u0001).EditValue = ((EditorRuntimeSettings) Vars[index]).Value;
        ((buTool) this).\u0001.Font = new Font("Times New Roman", 8f);
        new ToolTip().SetToolTip((Control) ((buTool) this).\u0001, ((buTool) this).\u0001.Text);
        ((buTool) this).\u0001.Controls.Add((Control) ((buTool) this).\u0001);
        ((buTool) this).\u0001.Controls.Add((Control) ((buTool) this).\u0001);
        ((buTool) this).ControlList.Add((Control) ((buTool) this).\u0001);
        ++num;
      }
    }
    if (((buLinearPathCam) this).ShowOkButton)
    {
      ((buTool) this).\u0001.Location = new Point(((buCompositeCurveCam) this).RowSpace, ((buCompositeCurveCam) this).RowSpace + num * (((buCompositeCurveCam) this).RowHeight + ((buCompositeCurveCam) this).RowSpace) + 4);
      ((buTool) this).\u0001.Height = 40;
      ((buTool) this).\u0001.Width = ((Control) this).Width - ((buLinearPathCam) this).ValueWidth - ((buCompositeCurveCam) this).RowSpace * 9;
      ((buTool) this).\u0001.Text = "  Ok";
      ((buTool) this).\u0001.ImageAlign = ContentAlignment.MiddleLeft;
      if (((buArcCam) this).OkButtonText.Length > 0)
        ((buTool) this).\u0001.Text = "  " + ((buArcCam) this).OkButtonText;
      ((buTool) this).\u0001.Visible = true;
      ((buTool) this).\u0001.Click += new EventHandler(this.\u0002);
      ((buTool) this).\u0001.Controls.Add((Control) ((buTool) this).\u0001);
    }
    if (!((buArcCam) this).ShowCancelButton)
      return;
    ((buTool) this).\u0002.Location = new Point(((Control) this).Width - (((buLinearPathCam) this).ValueWidth - ((buCompositeCurveCam) this).RowSpace * 9) - 8, ((buCompositeCurveCam) this).RowSpace + num * (((buCompositeCurveCam) this).RowHeight + ((buCompositeCurveCam) this).RowSpace) + 4);
    ((buTool) this).\u0002.Height = 40;
    ((buTool) this).\u0002.Width = ((buLinearPathCam) this).ValueWidth - ((buCompositeCurveCam) this).RowSpace * 9;
    ((buTool) this).\u0002.Text = "  Cancel";
    ((buTool) this).\u0002.ImageAlign = ContentAlignment.MiddleLeft;
    if (((buArcCam) this).CancelButtonText.Length > 0)
      ((buTool) this).\u0002.Text = "  " + ((buArcCam) this).CancelButtonText;
    ((buTool) this).\u0002.Visible = true;
    ((buTool) this).\u0002.Click += new EventHandler(this.\u0002);
    ((buTool) this).\u0001.Controls.Add((Control) ((buTool) this).\u0002);
  }

  private new void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control = (Control) obj0;
    if (control.GetType() == typeof (setNumericUpDownControl))
      ;
    if (control.GetType() == typeof (setTextBoxControl))
      ;
    if (control.GetType() == typeof (setCheckBoxControl))
      ;
    if (control.GetType() == typeof (setComboBoxControl))
      ;
    if (!(control.GetType() == typeof (setLabelControl)))
      return;
    if (((buShapeVisualition) control).EditValue.GetType() == typeof (drawPropertiesType))
    {
      F_DrawPropertiesType drawPropertiesType = new F_DrawPropertiesType();
      drawPropertiesType.Value = (drawPropertiesType) ((buShapeVisualition) control).EditValue;
      drawPropertiesType.Init();
      drawPropertiesType.StartPosition = FormStartPosition.CenterParent;
      int num = (int) drawPropertiesType.ShowDialog((IWin32Window) ((Control) this).Parent);
      ((buShapeVisualition) control).EditValue = (object) drawPropertiesType.Value;
      control.Text = ((drawPropertiesType) ((buShapeVisualition) control).EditValue).ToString();
      control.BackColor = ((drawPropertiesType) ((buShapeVisualition) control).EditValue).Color;
      control.ForeColor = buImage.InvertColor(control.BackColor);
      cParameter5 cParameter5 = (cParameter5) new buVector5(control.Tag.ToString(), ((buShapeVisualition) control).EditValue);
      buSerilization5.SetClassVariable(ref ((buArcCam) this).ClassObject, cParameter5);
      // ISSUE: reference to a compiler-generated field
      if (((buTool) this).\u0001 != null)
      {
        // ISSUE: reference to a compiler-generated field
        ((buEllipse) ((buTool) this).\u0001).Invoke((object) this, ((buShapeVisualition) control).EditValue, cParameter5);
      }
    }
    if (((buShapeVisualition) control).EditValue.GetType() == typeof (ColorType))
    {
      F_ColorType fColorType = (F_ColorType) new buClassViewer5();
      ((F_CamSequence) fColorType).Value = (ColorType) ((buShapeVisualition) control).EditValue;
      ((buClassViewer5) fColorType).Init();
      fColorType.StartPosition = FormStartPosition.CenterParent;
      int num = (int) fColorType.ShowDialog((IWin32Window) ((Control) this).Parent);
      ((buShapeVisualition) control).EditValue = (object) ((F_CamSequence) fColorType).Value;
      control.Text = ((ColorType) ((buShapeVisualition) control).EditValue).ToString();
      control.BackColor = ((hmiUIOptions) ((buShapeVisualition) control).EditValue).Color;
      control.ForeColor = buImage.InvertColor(control.BackColor);
      cParameter5 cParameter5 = (cParameter5) new buVector5(control.Tag.ToString(), ((buShapeVisualition) control).EditValue);
      buSerilization5.SetClassVariable(ref ((buArcCam) this).ClassObject, cParameter5);
      // ISSUE: reference to a compiler-generated field
      if (((buTool) this).\u0001 != null)
      {
        // ISSUE: reference to a compiler-generated field
        ((buEllipse) ((buTool) this).\u0001).Invoke((object) this, ((buShapeVisualition) control).EditValue, cParameter5);
      }
    }
    if (((buShapeVisualition) control).EditValue.GetType() == typeof (ColorDrawType))
    {
      F_ColorDrawType fColorDrawType = (F_ColorDrawType) new buClassViewer5();
      ((F_CamTable) fColorDrawType).Value = (ColorDrawType) ((buShapeVisualition) control).EditValue;
      ((buClassViewer5) fColorDrawType).Init();
      fColorDrawType.StartPosition = FormStartPosition.CenterParent;
      int num = (int) fColorDrawType.ShowDialog((IWin32Window) ((Control) this).Parent);
      ((buShapeVisualition) control).EditValue = (object) ((F_CamTable) fColorDrawType).Value;
      control.Text = ((ColorDrawType) ((buShapeVisualition) control).EditValue).ToString();
      control.BackColor = ((hmiUIDataGridView) ((buShapeVisualition) control).EditValue).Color;
      control.ForeColor = buImage.InvertColor(control.BackColor);
      cParameter5 cParameter5 = (cParameter5) new buVector5(control.Tag.ToString(), ((buShapeVisualition) control).EditValue);
      buSerilization5.SetClassVariable(ref ((buArcCam) this).ClassObject, cParameter5);
      // ISSUE: reference to a compiler-generated field
      if (((buTool) this).\u0001 != null)
      {
        // ISSUE: reference to a compiler-generated field
        ((buEllipse) ((buTool) this).\u0001).Invoke((object) this, ((buShapeVisualition) control).EditValue, cParameter5);
      }
    }
    if (((buShapeVisualition) control).EditValue.GetType() == typeof (MouseKeyboardConfigration))
    {
      F_MouseKeyboardConfig mouseKeyboardConfig = new F_MouseKeyboardConfig();
      mouseKeyboardConfig.Value = (MouseKeyboardConfigration) ((buShapeVisualition) control).EditValue;
      mouseKeyboardConfig.Init();
      mouseKeyboardConfig.StartPosition = FormStartPosition.CenterParent;
      int num = (int) mouseKeyboardConfig.ShowDialog((IWin32Window) ((Control) this).Parent);
      ((buShapeVisualition) control).EditValue = (object) mouseKeyboardConfig.Value;
      control.Text = ((MouseKeyboardConfigration) ((buShapeVisualition) control).EditValue).ToString();
      cParameter5 cParameter5 = (cParameter5) new buVector5(control.Tag.ToString(), ((buShapeVisualition) control).EditValue);
      buSerilization5.SetClassVariable(ref ((buArcCam) this).ClassObject, cParameter5);
      // ISSUE: reference to a compiler-generated field
      if (((buTool) this).\u0001 != null)
      {
        // ISSUE: reference to a compiler-generated field
        ((buEllipse) ((buTool) this).\u0001).Invoke((object) this, ((buShapeVisualition) control).EditValue, cParameter5);
      }
    }
    if (((buShapeVisualition) control).EditValue.GetType() == typeof (EntityResolution))
    {
      F_EntitiyResolution entitiyResolution = new F_EntitiyResolution();
      entitiyResolution.Value = (EntityResolution) ((buShapeVisualition) control).EditValue;
      entitiyResolution.Init();
      entitiyResolution.StartPosition = FormStartPosition.CenterParent;
      int num = (int) entitiyResolution.ShowDialog((IWin32Window) ((Control) this).Parent);
      ((buShapeVisualition) control).EditValue = (object) entitiyResolution.Value;
      control.Text = ((EntityResolution) ((buShapeVisualition) control).EditValue).ToString();
      cParameter5 cParameter5 = (cParameter5) new buVector5(control.Tag.ToString(), ((buShapeVisualition) control).EditValue);
      buSerilization5.SetClassVariable(ref ((buArcCam) this).ClassObject, cParameter5);
      // ISSUE: reference to a compiler-generated field
      if (((buTool) this).\u0001 != null)
      {
        // ISSUE: reference to a compiler-generated field
        ((buEllipse) ((buTool) this).\u0001).Invoke((object) this, ((buShapeVisualition) control).EditValue, cParameter5);
      }
    }
    if (((buShapeVisualition) control).EditValue.GetType() == typeof (SolidItemDisplay))
    {
      F_SolidItemDisplay solidItemDisplay = new F_SolidItemDisplay();
      solidItemDisplay.Value = (SolidItemDisplay) ((buShapeVisualition) control).EditValue;
      solidItemDisplay.Init();
      solidItemDisplay.StartPosition = FormStartPosition.CenterParent;
      int num = (int) solidItemDisplay.ShowDialog((IWin32Window) ((Control) this).Parent);
      ((buShapeVisualition) control).EditValue = (object) solidItemDisplay.Value;
      control.Text = ((SolidItemDisplay) ((buShapeVisualition) control).EditValue).ToString();
      cParameter5 cParameter5 = (cParameter5) new buVector5(control.Tag.ToString(), ((buShapeVisualition) control).EditValue);
      buSerilization5.SetClassVariable(ref ((buArcCam) this).ClassObject, cParameter5);
      // ISSUE: reference to a compiler-generated field
      if (((buTool) this).\u0001 != null)
      {
        // ISSUE: reference to a compiler-generated field
        ((buEllipse) ((buTool) this).\u0001).Invoke((object) this, ((buShapeVisualition) control).EditValue, cParameter5);
      }
    }
    if (((buShapeVisualition) control).EditValue.GetType() == typeof (Pnt2D))
    {
      F_Pnt3D fPnt3D = new F_Pnt3D();
      fPnt3D.Mode2D = true;
      fPnt3D.Value = buConversion.Pnt2DToPnt3D((Pnt2D) ((buShapeVisualition) control).EditValue);
      fPnt3D.Init();
      fPnt3D.StartPosition = FormStartPosition.CenterParent;
      int num = (int) fPnt3D.ShowDialog((IWin32Window) ((Control) this).Parent);
      ((buShapeVisualition) control).EditValue = (object) buConversion.Pnt3DToPnt2D(fPnt3D.Value);
      control.Text = ((Pnt2D) ((buShapeVisualition) control).EditValue).ToString();
      cParameter5 cParameter5 = (cParameter5) new buVector5(control.Tag.ToString(), ((buShapeVisualition) control).EditValue);
      buSerilization5.SetClassVariable(ref ((buArcCam) this).ClassObject, cParameter5);
      // ISSUE: reference to a compiler-generated field
      if (((buTool) this).\u0001 != null)
      {
        // ISSUE: reference to a compiler-generated field
        ((buEllipse) ((buTool) this).\u0001).Invoke((object) this, ((buShapeVisualition) control).EditValue, cParameter5);
      }
    }
    if (((buShapeVisualition) control).EditValue.GetType() == typeof (Pnt3D))
    {
      F_Pnt3D fPnt3D = new F_Pnt3D();
      fPnt3D.Value = (Pnt3D) ((buShapeVisualition) control).EditValue;
      fPnt3D.Init();
      fPnt3D.StartPosition = FormStartPosition.CenterParent;
      int num = (int) fPnt3D.ShowDialog((IWin32Window) ((Control) this).Parent);
      ((buShapeVisualition) control).EditValue = (object) fPnt3D.Value;
      control.Text = ((Pnt3D) ((buShapeVisualition) control).EditValue).ToString();
      cParameter5 cParameter5 = (cParameter5) new buVector5(control.Tag.ToString(), ((buShapeVisualition) control).EditValue);
      buSerilization5.SetClassVariable(ref ((buArcCam) this).ClassObject, cParameter5);
      // ISSUE: reference to a compiler-generated field
      if (((buTool) this).\u0001 != null)
      {
        // ISSUE: reference to a compiler-generated field
        ((buEllipse) ((buTool) this).\u0001).Invoke((object) this, ((buShapeVisualition) control).EditValue, cParameter5);
      }
    }
    if (((buShapeVisualition) control).EditValue.GetType() == typeof (Point))
    {
      F_Pnt3D fPnt3D = new F_Pnt3D();
      fPnt3D.IntergerMode = true;
      fPnt3D.Mode2D = true;
      fPnt3D.Value = buConversion.PointToPnt3D((Point) ((buShapeVisualition) control).EditValue);
      fPnt3D.Init();
      fPnt3D.StartPosition = FormStartPosition.CenterParent;
      int num = (int) fPnt3D.ShowDialog((IWin32Window) ((Control) this).Parent);
      ((buShapeVisualition) control).EditValue = (object) buConversion.Pnt3DToPoint(fPnt3D.Value);
      control.Text = buConversion.PointToString((Point) ((buShapeVisualition) control).EditValue);
      cParameter5 cParameter5 = (cParameter5) new buVector5(control.Tag.ToString(), ((buShapeVisualition) control).EditValue);
      buSerilization5.SetClassVariable(ref ((buArcCam) this).ClassObject, cParameter5);
      // ISSUE: reference to a compiler-generated field
      if (((buTool) this).\u0001 != null)
      {
        // ISSUE: reference to a compiler-generated field
        ((buEllipse) ((buTool) this).\u0001).Invoke((object) this, ((buShapeVisualition) control).EditValue, cParameter5);
      }
    }
    if (((buShapeVisualition) control).EditValue.GetType() == typeof (PointF))
    {
      F_Pnt3D fPnt3D = new F_Pnt3D();
      fPnt3D.Mode2D = true;
      fPnt3D.Value = buConversion.PointFToPnt3D((PointF) ((buShapeVisualition) control).EditValue);
      fPnt3D.Init();
      fPnt3D.StartPosition = FormStartPosition.CenterParent;
      int num = (int) fPnt3D.ShowDialog((IWin32Window) ((Control) this).Parent);
      ((buShapeVisualition) control).EditValue = (object) buConversion.Pnt3DToPointF(fPnt3D.Value);
      control.Text = buConversion.PointFToString((PointF) ((buShapeVisualition) control).EditValue);
      cParameter5 cParameter5 = (cParameter5) new buVector5(control.Tag.ToString(), ((buShapeVisualition) control).EditValue);
      buSerilization5.SetClassVariable(ref ((buArcCam) this).ClassObject, cParameter5);
      // ISSUE: reference to a compiler-generated field
      if (((buTool) this).\u0001 != null)
      {
        // ISSUE: reference to a compiler-generated field
        ((buEllipse) ((buTool) this).\u0001).Invoke((object) this, ((buShapeVisualition) control).EditValue, cParameter5);
      }
    }
    if (((buShapeVisualition) control).EditValue.GetType() == typeof (Size))
    {
      F_Size fSize = new F_Size();
      fSize.IntergerMode = true;
      fSize.Value = buConversion.SizeToSizeF((Size) ((buShapeVisualition) control).EditValue);
      fSize.Init();
      fSize.StartPosition = FormStartPosition.CenterParent;
      int num = (int) fSize.ShowDialog((IWin32Window) ((Control) this).Parent);
      ((buShapeVisualition) control).EditValue = (object) buConversion.SizeFToSize(fSize.Value);
      control.Text = buConversion.SizeToString((Size) ((buShapeVisualition) control).EditValue);
      cParameter5 cParameter5 = (cParameter5) new buVector5(control.Tag.ToString(), ((buShapeVisualition) control).EditValue);
      buSerilization5.SetClassVariable(ref ((buArcCam) this).ClassObject, cParameter5);
      // ISSUE: reference to a compiler-generated field
      if (((buTool) this).\u0001 != null)
      {
        // ISSUE: reference to a compiler-generated field
        ((buEllipse) ((buTool) this).\u0001).Invoke((object) this, ((buShapeVisualition) control).EditValue, cParameter5);
      }
    }
    if (((buShapeVisualition) control).EditValue.GetType() == typeof (SizeF))
    {
      F_Size fSize = new F_Size();
      fSize.Value = (SizeF) ((buShapeVisualition) control).EditValue;
      fSize.Init();
      fSize.StartPosition = FormStartPosition.CenterParent;
      int num = (int) fSize.ShowDialog((IWin32Window) ((Control) this).Parent);
      ((buShapeVisualition) control).EditValue = (object) fSize.Value;
      control.Text = buConversion.SizeFToString((SizeF) ((buShapeVisualition) control).EditValue);
      cParameter5 cParameter5 = (cParameter5) new buVector5(control.Tag.ToString(), ((buShapeVisualition) control).EditValue);
      buSerilization5.SetClassVariable(ref ((buArcCam) this).ClassObject, cParameter5);
      // ISSUE: reference to a compiler-generated field
      if (((buTool) this).\u0001 != null)
      {
        // ISSUE: reference to a compiler-generated field
        ((buEllipse) ((buTool) this).\u0001).Invoke((object) this, ((buShapeVisualition) control).EditValue, cParameter5);
      }
    }
    if (!(((buShapeVisualition) control).EditValue.GetType() == typeof (Font)))
      return;
    FontDialog fontDialog = new FontDialog();
    fontDialog.Font = (Font) ((buShapeVisualition) control).EditValue;
    if (fontDialog.ShowDialog() != DialogResult.OK)
      return;
    ((buShapeVisualition) control).EditValue = (object) fontDialog.Font;
    control.Text = $"{((Font) ((buShapeVisualition) control).EditValue).Name} - {((Font) ((buShapeVisualition) control).EditValue).Size.ToString()}";
    cParameter5 cParameter5_1 = (cParameter5) new buVector5(control.Tag.ToString(), ((buShapeVisualition) control).EditValue);
    buSerilization5.SetClassVariable(ref ((buArcCam) this).ClassObject, cParameter5_1);
    // ISSUE: reference to a compiler-generated field
    if (((buTool) this).\u0001 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    ((buEllipse) ((buTool) this).\u0001).Invoke((object) this, ((buShapeVisualition) control).EditValue, cParameter5_1);
  }

  private new void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == ((buTool) this).\u0001.Name && ((buTool) this).\u0001 != null)
    {
      // ISSUE: reference to a compiler-generated field
      ((buTool) this).\u0001((object) this, obj1);
    }
    // ISSUE: reference to a compiler-generated field
    if (!(control2.Name == ((buTool) this).\u0002.Name) || ((buTool) this).\u0002 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    ((buTool) this).\u0002((object) this, obj1);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((buTool) this).\u0001 != null ? 1 : 0)) != 0)
      ((buTool) this).\u0001.Dispose();
    // ISSUE: explicit non-virtual call
    __nonvirtual (((ContainerControl) this).Dispose(disposing));
  }

  public abstract void m00173D();

  [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
  public extern buCircle(object @object, IntPtr method);
}
