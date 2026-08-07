// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buEntities.buCurve
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls;
using buControls.Controls;
using buControls.Forms.WinControlForms.ClassForm;
using buCore;
using buEyeBaseVer5.ClassViewer;
using buEyeBaseVer5.Forms.Cam;
using buEyeBaseVer5.Forms.ClassForm;
using System;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.buEntities;

[Serializable]
public class buCurve : buEntity
{
  public buCheckBox chk_WAngleLimit;
  public buCheckBox chk_CAngleLimit;
  public buCheckBox chk_AAngleLimit;
  public buSpin spn_smoothmaxtiltangle;

  internal void \u0001([In] object obj0, [In] Color obj1)
  {
    Control control = (Control) obj0;
    if (!(control.GetType() == typeof (setColorComboControl)))
      return;
    ((buCompositeCurveCam) control).EditValue = (object) obj1;
    cParameter5 cParameter5 = (cParameter5) new buVector5(control.Tag.ToString(), ((buCompositeCurveCam) control).EditValue);
    buSerilization5.SetClassVariable(ref ((buMachinePart) this).ClassObject, cParameter5);
    // ISSUE: reference to a compiler-generated field
    if (((buMachinePart) this).\u0001 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    ((buCompositeCurve) ((buMachinePart) this).\u0001).Invoke((object) this, ((buCompositeCurveCam) control).EditValue, cParameter5);
  }

  private new void \u0003([In] object obj0, [In] EventArgs obj1)
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
      buSerilization5.SetClassVariable(ref ((buMachinePart) this).ClassObject, cParameter5);
      // ISSUE: reference to a compiler-generated field
      if (((buMachinePart) this).\u0001 != null)
      {
        // ISSUE: reference to a compiler-generated field
        ((buCompositeCurve) ((buMachinePart) this).\u0001).Invoke((object) this, ((buShapeVisualition) control).EditValue, cParameter5);
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
      buSerilization5.SetClassVariable(ref ((buMachinePart) this).ClassObject, cParameter5);
      // ISSUE: reference to a compiler-generated field
      if (((buMachinePart) this).\u0001 != null)
      {
        // ISSUE: reference to a compiler-generated field
        ((buCompositeCurve) ((buMachinePart) this).\u0001).Invoke((object) this, ((buShapeVisualition) control).EditValue, cParameter5);
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
      buSerilization5.SetClassVariable(ref ((buMachinePart) this).ClassObject, cParameter5);
      // ISSUE: reference to a compiler-generated field
      if (((buMachinePart) this).\u0001 != null)
      {
        // ISSUE: reference to a compiler-generated field
        ((buCompositeCurve) ((buMachinePart) this).\u0001).Invoke((object) this, ((buShapeVisualition) control).EditValue, cParameter5);
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
      buSerilization5.SetClassVariable(ref ((buMachinePart) this).ClassObject, cParameter5);
      // ISSUE: reference to a compiler-generated field
      if (((buMachinePart) this).\u0001 != null)
      {
        // ISSUE: reference to a compiler-generated field
        ((buCompositeCurve) ((buMachinePart) this).\u0001).Invoke((object) this, ((buShapeVisualition) control).EditValue, cParameter5);
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
      buSerilization5.SetClassVariable(ref ((buMachinePart) this).ClassObject, cParameter5);
      // ISSUE: reference to a compiler-generated field
      if (((buMachinePart) this).\u0001 != null)
      {
        // ISSUE: reference to a compiler-generated field
        ((buCompositeCurve) ((buMachinePart) this).\u0001).Invoke((object) this, ((buShapeVisualition) control).EditValue, cParameter5);
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
      buSerilization5.SetClassVariable(ref ((buMachinePart) this).ClassObject, cParameter5);
      // ISSUE: reference to a compiler-generated field
      if (((buMachinePart) this).\u0001 != null)
      {
        // ISSUE: reference to a compiler-generated field
        ((buCompositeCurve) ((buMachinePart) this).\u0001).Invoke((object) this, ((buShapeVisualition) control).EditValue, cParameter5);
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
      buSerilization5.SetClassVariable(ref ((buMachinePart) this).ClassObject, cParameter5);
      // ISSUE: reference to a compiler-generated field
      if (((buMachinePart) this).\u0001 != null)
      {
        // ISSUE: reference to a compiler-generated field
        ((buCompositeCurve) ((buMachinePart) this).\u0001).Invoke((object) this, ((buShapeVisualition) control).EditValue, cParameter5);
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
      buSerilization5.SetClassVariable(ref ((buMachinePart) this).ClassObject, cParameter5);
      // ISSUE: reference to a compiler-generated field
      if (((buMachinePart) this).\u0001 != null)
      {
        // ISSUE: reference to a compiler-generated field
        ((buCompositeCurve) ((buMachinePart) this).\u0001).Invoke((object) this, ((buShapeVisualition) control).EditValue, cParameter5);
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
      buSerilization5.SetClassVariable(ref ((buMachinePart) this).ClassObject, cParameter5);
      // ISSUE: reference to a compiler-generated field
      if (((buMachinePart) this).\u0001 != null)
      {
        // ISSUE: reference to a compiler-generated field
        ((buCompositeCurve) ((buMachinePart) this).\u0001).Invoke((object) this, ((buShapeVisualition) control).EditValue, cParameter5);
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
      buSerilization5.SetClassVariable(ref ((buMachinePart) this).ClassObject, cParameter5);
      // ISSUE: reference to a compiler-generated field
      if (((buMachinePart) this).\u0001 != null)
      {
        // ISSUE: reference to a compiler-generated field
        ((buCompositeCurve) ((buMachinePart) this).\u0001).Invoke((object) this, ((buShapeVisualition) control).EditValue, cParameter5);
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
      buSerilization5.SetClassVariable(ref ((buMachinePart) this).ClassObject, cParameter5);
      // ISSUE: reference to a compiler-generated field
      if (((buMachinePart) this).\u0001 != null)
      {
        // ISSUE: reference to a compiler-generated field
        ((buCompositeCurve) ((buMachinePart) this).\u0001).Invoke((object) this, ((buShapeVisualition) control).EditValue, cParameter5);
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
      buSerilization5.SetClassVariable(ref ((buMachinePart) this).ClassObject, cParameter5);
      // ISSUE: reference to a compiler-generated field
      if (((buMachinePart) this).\u0001 != null)
      {
        // ISSUE: reference to a compiler-generated field
        ((buCompositeCurve) ((buMachinePart) this).\u0001).Invoke((object) this, ((buShapeVisualition) control).EditValue, cParameter5);
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
    buSerilization5.SetClassVariable(ref ((buMachinePart) this).ClassObject, cParameter5_1);
    // ISSUE: reference to a compiler-generated field
    if (((buMachinePart) this).\u0001 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    ((buCompositeCurve) ((buMachinePart) this).\u0001).Invoke((object) this, ((buShapeVisualition) control).EditValue, cParameter5_1);
  }

  internal new void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      if (!AppBool.TouchPad)
        return;
      if (obj0.GetType() == typeof (TextBox))
      {
        TextBox textBox = new TextBox();
        buControlCommands.ShowKeyPad(((buMachinePart) this).OwnerForm, (Control) obj0, ((buMachinePart) this).TouchPayStyle);
      }
      if (obj0.GetType() == typeof (NumericUpDown))
      {
        NumericUpDown numericUpDown = new NumericUpDown();
        buControlCommands.ShowKeyPad(((buMachinePart) this).OwnerForm, (Control) obj0, ((buMachinePart) this).TouchPayStyle);
      }
      if (obj0.GetType().BaseType == typeof (NumericUpDown))
      {
        NumericUpDown numericUpDown = new NumericUpDown();
        buControlCommands.ShowKeyPad(((buMachinePart) this).OwnerForm, (Control) obj0, ((buMachinePart) this).TouchPayStyle);
      }
      if (!(obj0.GetType().BaseType == typeof (TextBox)))
        return;
      TextBox textBox1 = new TextBox();
      buControlCommands.ShowKeyPad(((buMachinePart) this).OwnerForm, (Control) obj0, ((buMachinePart) this).TouchPayStyle);
    }
    catch (Exception ex)
    {
      string message = "";
      buException.throwException(new CalculationErrorEventArg(true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ex), true);
    }
  }

  private void \u0005([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == ((buMachinePart) this).\u0001.Name && ((buMachinePart) this).\u0001 != null)
    {
      // ISSUE: reference to a compiler-generated field
      ((buMachinePart) this).\u0001((object) this, obj1);
    }
    // ISSUE: reference to a compiler-generated field
    if (!(control2.Name == ((buMachinePart) this).\u0002.Name) || ((buMachinePart) this).\u0002 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    ((buMachinePart) this).\u0002((object) this, obj1);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((buMachinePart) this).\u0001 != null ? 1 : 0)) != 0)
      ((buMachinePart) this).\u0001.Dispose();
    // ISSUE: explicit non-virtual call
    __nonvirtual (((ContainerControl) this).Dispose(disposing));
  }

  public abstract void m001751();
}
