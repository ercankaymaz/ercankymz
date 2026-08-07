// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buEntities.buLinearPath
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buCore;
using buEyeBaseVer5.ClassViewer;
using buEyeBaseVer5.Variables;
using dummy_ptr;
using SmartAssembly.HouseOfCards;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.buEntities;

[Serializable]
public class buLinearPath : buEntity
{
  [CompilerGenerated]
  [SpecialName]
  public void remove_OkButtonClicked(EventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    EventHandler eventHandler = ((buMachinePart) this).\u0001;
    EventHandler comparand;
    do
    {
      comparand = eventHandler;
      // ISSUE: reference to a compiler-generated field
      eventHandler = Interlocked.CompareExchange<EventHandler>(ref ((buMachinePart) this).\u0001, comparand - value, comparand);
    }
    while (eventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_CancelButtonClicked(EventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    EventHandler eventHandler = ((buMachinePart) this).\u0002;
    EventHandler comparand;
    do
    {
      comparand = eventHandler;
      // ISSUE: reference to a compiler-generated field
      eventHandler = Interlocked.CompareExchange<EventHandler>(ref ((buMachinePart) this).\u0002, comparand + value, comparand);
    }
    while (eventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_CancelButtonClicked(EventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    EventHandler eventHandler = ((buMachinePart) this).\u0002;
    EventHandler comparand;
    do
    {
      comparand = eventHandler;
      // ISSUE: reference to a compiler-generated field
      eventHandler = Interlocked.CompareExchange<EventHandler>(ref ((buMachinePart) this).\u0002, comparand - value, comparand);
    }
    while (eventHandler != comparand);
  }

  public new void Init()
  {
    List<cParameter5> Vars = new List<cParameter5>();
    List<string> Captions = new List<string>();
    buSerilization5.GetClassVariables(((buMachinePart) this).ClassObject, ref Vars);
    buSerilization5.GetCaptionsOfClass(((buMachinePart) this).ClassObject, ref Captions);
    ((buMachinePart) this).ControlList.Clear();
    ((buMachinePart) this).ControlList = new List<Control>();
    int num = 0;
    ((buMachinePart) this).\u0001.Controls.Clear();
    for (int index1 = 0; index1 <= Vars.Count - 1; ++index1)
    {
      System.Type type = ((EditorRuntimeSettings) Vars[index1]).Value.GetType();
      ((buMachinePart) this).\u0001 = new Label();
      ((buMachinePart) this).\u0001.BorderStyle = BorderStyle.FixedSingle;
      ((buMachinePart) this).\u0001.Text = ((EditorRuntimeSettings) Vars[index1]).Name;
      if (Captions.Count > 0 & index1 <= Captions.Count - 1)
        ((buMachinePart) this).\u0001.Text = Captions[index1];
      if (((buMachinePart) this).ParCaptions.Count > 0 & index1 <= ((buMachinePart) this).ParCaptions.Count - 1)
        ((buMachinePart) this).\u0001.Text = ((buMachinePart) this).ParCaptions[index1];
      ((buMachinePart) this).\u0001.Font = ((buMachinePart) this).FontCaptions;
      ((buMachinePart) this).\u0001.Size = new Size(((Control) this).Width - ((buMachinePart) this).ValueWidth - ((buMachinePart) this).RowSpace * 9, ((buMachinePart) this).RowHeight);
      ((buMachinePart) this).\u0001.Location = new Point(((buMachinePart) this).RowSpace, ((buMachinePart) this).RowSpace + num * (((buMachinePart) this).RowHeight + ((buMachinePart) this).RowSpace));
      if (type == typeof (double) | type == typeof (float))
      {
        Decimal result = 0M;
        Decimal.TryParse(((EditorRuntimeSettings) Vars[index1]).ValueAsString, out result);
        ((buMachinePart) this).\u0001 = (setNumericUpDownControl) new buArc();
        ref setNumericUpDownControl local = ref ((buMachinePart) this).\u0001;
        string name = ((EditorRuntimeSettings) Vars[index1]).Name;
        int decimalPlace = ((buMachinePart) this).DecimalPlace;
        \u0007.\u0001.\u0001(name, (buClassViewer5) this, ref local, decimalPlace, result);
        ((buMachinePart) this).\u0001.Location = new Point(((buMachinePart) this).\u0001.Left + ((buMachinePart) this).\u0001.Width + ((buMachinePart) this).RowSpace, ((buMachinePart) this).RowSpace + num * (((buMachinePart) this).RowHeight + ((buMachinePart) this).RowSpace));
        ((buMachinePart) this).\u0001.Controls.Add((Control) ((buMachinePart) this).\u0001);
        ((buMachinePart) this).\u0001.Controls.Add((Control) ((buMachinePart) this).\u0001);
        ((buMachinePart) this).ControlList.Add((Control) ((buMachinePart) this).\u0001);
        ++num;
      }
      if (type == typeof (int) | type == typeof (byte) | type == typeof (long))
      {
        Decimal result = 0M;
        Decimal.TryParse(((EditorRuntimeSettings) Vars[index1]).ValueAsString, out result);
        ((buMachinePart) this).\u0001 = (setNumericUpDownControl) new buArc();
        ref setNumericUpDownControl local = ref ((buMachinePart) this).\u0001;
        \u0007.\u0001.\u0001(((EditorRuntimeSettings) Vars[index1]).Name, (buClassViewer5) this, ref local, 0, result);
        ((buMachinePart) this).\u0001.Location = new Point(((buMachinePart) this).\u0001.Left + ((buMachinePart) this).\u0001.Width + ((buMachinePart) this).RowSpace, ((buMachinePart) this).RowSpace + num * (((buMachinePart) this).RowHeight + ((buMachinePart) this).RowSpace));
        ((buMachinePart) this).\u0001.Controls.Add((Control) ((buMachinePart) this).\u0001);
        ((buMachinePart) this).\u0001.Controls.Add((Control) ((buMachinePart) this).\u0001);
        ((buMachinePart) this).ControlList.Add((Control) ((buMachinePart) this).\u0001);
        ++num;
      }
      if (type == typeof (bool))
      {
        bool result = false;
        bool.TryParse(((EditorRuntimeSettings) Vars[index1]).ValueAsString, out result);
        ((buMachinePart) this).\u0001 = (setCheckBoxControl) new buArc();
        ref setCheckBoxControl local = ref ((buMachinePart) this).\u0001;
        Strings.\u0001(((EditorRuntimeSettings) Vars[index1]).Name, ref local, result, (buClassViewer5) this);
        ((buMachinePart) this).\u0001.Location = new Point(((buMachinePart) this).\u0001.Left + ((buMachinePart) this).\u0001.Width + ((buMachinePart) this).RowSpace, ((buMachinePart) this).RowSpace + num * (((buMachinePart) this).RowHeight + ((buMachinePart) this).RowSpace));
        ((buMachinePart) this).\u0001.Controls.Add((Control) ((buMachinePart) this).\u0001);
        ((buMachinePart) this).\u0001.Controls.Add((Control) ((buMachinePart) this).\u0001);
        ((buMachinePart) this).ControlList.Add((Control) ((buMachinePart) this).\u0001);
        ++num;
      }
      if (type == typeof (string))
      {
        bool result = false;
        bool.TryParse(((EditorRuntimeSettings) Vars[index1]).ValueAsString, out result);
        ((buMachinePart) this).\u0001 = (setTextBoxControl) new buArc();
        ref setTextBoxControl local = ref ((buMachinePart) this).\u0001;
        string valueAsString = ((EditorRuntimeSettings) Vars[index1]).ValueAsString;
        string name = ((EditorRuntimeSettings) Vars[index1]).Name;
        \u0007.\u0001.\u0001(valueAsString, ref local, name, (buClassViewer5) this);
        ((buMachinePart) this).\u0001.Location = new Point(((buMachinePart) this).\u0001.Left + ((buMachinePart) this).\u0001.Width + ((buMachinePart) this).RowSpace, ((buMachinePart) this).RowSpace + num * (((buMachinePart) this).RowHeight + ((buMachinePart) this).RowSpace));
        ((buMachinePart) this).\u0001.Controls.Add((Control) ((buMachinePart) this).\u0001);
        ((buMachinePart) this).\u0001.Controls.Add((Control) ((buMachinePart) this).\u0001);
        ((buMachinePart) this).ControlList.Add((Control) ((buMachinePart) this).\u0001);
        ++num;
      }
      if (type.IsEnum)
      {
        bool result = false;
        bool.TryParse(((EditorRuntimeSettings) Vars[index1]).ValueAsString, out result);
        ArrayList arrayList = new ArrayList();
        Array values = Enum.GetValues(type);
        for (int index2 = 0; index2 <= values.Length - 1; ++index2)
          arrayList.Add(values.GetValue(index2));
        ((buMachinePart) this).\u0001 = (setComboBoxControl) new buArc();
        ref setComboBoxControl local = ref ((buMachinePart) this).\u0001;
        string str = ((EditorRuntimeSettings) Vars[index1]).Value.ToString();
        \u0007.\u0001.\u0001(((EditorRuntimeSettings) Vars[index1]).Name, (buClassViewer5) this, arrayList, ref local, str);
        ((buMachinePart) this).\u0001.Location = new Point(((buMachinePart) this).\u0001.Left + ((buMachinePart) this).\u0001.Width + ((buMachinePart) this).RowSpace, ((buMachinePart) this).RowSpace + num * (((buMachinePart) this).RowHeight + ((buMachinePart) this).RowSpace));
        ((buMachinePart) this).\u0001.Controls.Add((Control) ((buMachinePart) this).\u0001);
        ((buMachinePart) this).\u0001.Controls.Add((Control) ((buMachinePart) this).\u0001);
        ((buMachinePart) this).ControlList.Add((Control) ((buMachinePart) this).\u0001);
        ++num;
      }
      if (type == typeof (float[]))
      {
        ((buMachinePart) this).\u0001 = (setTextBoxControl) new buArc();
        string str = "";
        float[] numArray = (float[]) ((EditorRuntimeSettings) Vars[index1]).Value;
        for (int index3 = 0; index3 <= numArray.Length - 1; ++index3)
          str = index3 != 0 ? $"{str};{numArray[index3].ToString()}" : numArray[index3].ToString();
        ref setTextBoxControl local = ref ((buMachinePart) this).\u0001;
        string name = ((EditorRuntimeSettings) Vars[index1]).Name;
        \u0007.\u0001.\u0001(str, ref local, name, (buClassViewer5) this);
        ((buMachinePart) this).\u0001.Location = new Point(((buMachinePart) this).\u0001.Left + ((buMachinePart) this).\u0001.Width + ((buMachinePart) this).RowSpace, ((buMachinePart) this).RowSpace + num * (((buMachinePart) this).RowHeight + ((buMachinePart) this).RowSpace));
        ((buMachinePart) this).\u0001.Controls.Add((Control) ((buMachinePart) this).\u0001);
        ((buMachinePart) this).\u0001.Controls.Add((Control) ((buMachinePart) this).\u0001);
        ((buMachinePart) this).ControlList.Add((Control) ((buMachinePart) this).\u0001);
        ++num;
      }
      if (type == typeof (double[]))
      {
        ((buMachinePart) this).\u0001 = (setTextBoxControl) new buArc();
        string str = "";
        double[] numArray = (double[]) ((EditorRuntimeSettings) Vars[index1]).Value;
        for (int index4 = 0; index4 <= numArray.Length - 1; ++index4)
          str = index4 != 0 ? $"{str};{numArray[index4].ToString()}" : numArray[index4].ToString();
        ref setTextBoxControl local = ref ((buMachinePart) this).\u0001;
        string name = ((EditorRuntimeSettings) Vars[index1]).Name;
        \u0007.\u0001.\u0001(str, ref local, name, (buClassViewer5) this);
        ((buMachinePart) this).\u0001.Location = new Point(((buMachinePart) this).\u0001.Left + ((buMachinePart) this).\u0001.Width + ((buMachinePart) this).RowSpace, ((buMachinePart) this).RowSpace + num * (((buMachinePart) this).RowHeight + ((buMachinePart) this).RowSpace));
        ((buMachinePart) this).\u0001.Controls.Add((Control) ((buMachinePart) this).\u0001);
        ((buMachinePart) this).\u0001.Controls.Add((Control) ((buMachinePart) this).\u0001);
        ((buMachinePart) this).ControlList.Add((Control) ((buMachinePart) this).\u0001);
        ++num;
      }
      if (type == typeof (int[]))
      {
        ((buMachinePart) this).\u0001 = (setTextBoxControl) new buArc();
        string str = "";
        int[] numArray = (int[]) ((EditorRuntimeSettings) Vars[index1]).Value;
        for (int index5 = 0; index5 <= numArray.Length - 1; ++index5)
          str = index5 != 0 ? $"{str};{numArray[index5].ToString()}" : numArray[index5].ToString();
        ref setTextBoxControl local = ref ((buMachinePart) this).\u0001;
        string name = ((EditorRuntimeSettings) Vars[index1]).Name;
        \u0007.\u0001.\u0001(str, ref local, name, (buClassViewer5) this);
        ((buMachinePart) this).\u0001.Location = new Point(((buMachinePart) this).\u0001.Left + ((buMachinePart) this).\u0001.Width + ((buMachinePart) this).RowSpace, ((buMachinePart) this).RowSpace + num * (((buMachinePart) this).RowHeight + ((buMachinePart) this).RowSpace));
        ((buMachinePart) this).\u0001.Controls.Add((Control) ((buMachinePart) this).\u0001);
        ((buMachinePart) this).\u0001.Controls.Add((Control) ((buMachinePart) this).\u0001);
        ((buMachinePart) this).ControlList.Add((Control) ((buMachinePart) this).\u0001);
        ++num;
      }
      if (type == typeof (bool[]))
      {
        ((buMachinePart) this).\u0001 = (setTextBoxControl) new buArc();
        string str = "";
        bool[] flagArray = (bool[]) ((EditorRuntimeSettings) Vars[index1]).Value;
        for (int index6 = 0; index6 <= flagArray.Length - 1; ++index6)
          str = index6 != 0 ? $"{str};{flagArray[index6].ToString()}" : flagArray[index6].ToString();
        ref setTextBoxControl local = ref ((buMachinePart) this).\u0001;
        string name = ((EditorRuntimeSettings) Vars[index1]).Name;
        \u0007.\u0001.\u0001(str, ref local, name, (buClassViewer5) this);
        ((buMachinePart) this).\u0001.Location = new Point(((buMachinePart) this).\u0001.Left + ((buMachinePart) this).\u0001.Width + ((buMachinePart) this).RowSpace, ((buMachinePart) this).RowSpace + num * (((buMachinePart) this).RowHeight + ((buMachinePart) this).RowSpace));
        ((buMachinePart) this).\u0001.Controls.Add((Control) ((buMachinePart) this).\u0001);
        ((buMachinePart) this).\u0001.Controls.Add((Control) ((buMachinePart) this).\u0001);
        ((buMachinePart) this).ControlList.Add((Control) ((buMachinePart) this).\u0001);
        ++num;
      }
      if (type == typeof (ArrayList))
      {
        ((buMachinePart) this).\u0001 = (setTextBoxControl) new buArc();
        string str = "";
        ArrayList arrayList = (ArrayList) ((EditorRuntimeSettings) Vars[index1]).Value;
        for (int index7 = 0; index7 <= arrayList.Count - 1; ++index7)
          str = index7 != 0 ? str + Environment.NewLine + arrayList[index7].ToString() : arrayList[index7].ToString();
        ref setTextBoxControl local = ref ((buMachinePart) this).\u0001;
        string name = ((EditorRuntimeSettings) Vars[index1]).Name;
        \u0007.\u0001.\u0001(str, ref local, name, (buClassViewer5) this);
        ((buMachinePart) this).\u0001.Height = ((buMachinePart) this).RowHeight * 3 + ((buMachinePart) this).RowSpace * 2;
        ((buMachinePart) this).\u0001.Multiline = true;
        ((buMachinePart) this).\u0001.ScrollBars = ScrollBars.Both;
        ((buMachinePart) this).\u0001.Location = new Point(((buMachinePart) this).\u0001.Left + ((buMachinePart) this).\u0001.Width + ((buMachinePart) this).RowSpace, ((buMachinePart) this).RowSpace + num * (((buMachinePart) this).RowHeight + ((buMachinePart) this).RowSpace));
        ((buMachinePart) this).\u0001.Controls.Add((Control) ((buMachinePart) this).\u0001);
        ((buMachinePart) this).\u0001.Controls.Add((Control) ((buMachinePart) this).\u0001);
        ((buMachinePart) this).ControlList.Add((Control) ((buMachinePart) this).\u0001);
        num = num + 1 + 1 + 1;
      }
      if (type == typeof (Pnt3D))
      {
        Pnt3D pnt3D1 = new Pnt3D();
        Pnt3D pnt3D2 = (Pnt3D) ((EditorRuntimeSettings) Vars[index1]).Value;
        ((buMachinePart) this).\u0001 = (setLabelControl) new buArc();
        ref setLabelControl local = ref ((buMachinePart) this).\u0001;
        string str = pnt3D2.ToString();
        string name = ((EditorRuntimeSettings) Vars[index1]).Name;
        Color backColor = ((buMachinePart) this).\u0001.BackColor;
        \u0007.\u0001.\u0001(name, (buClassViewer5) this, ref local, backColor, str);
        ((buMachinePart) this).\u0001.DoubleClick += new EventHandler(((buCurve) this).\u0003);
        ((buMachinePart) this).\u0001.Location = new Point(((buMachinePart) this).\u0001.Left + ((buMachinePart) this).\u0001.Width + ((buMachinePart) this).RowSpace, ((buMachinePart) this).RowSpace + num * (((buMachinePart) this).RowHeight + ((buMachinePart) this).RowSpace));
        ((buShapeVisualition) ((buMachinePart) this).\u0001).EditValue = ((EditorRuntimeSettings) Vars[index1]).Value;
        ((buMachinePart) this).\u0001.Controls.Add((Control) ((buMachinePart) this).\u0001);
        ((buMachinePart) this).\u0001.Controls.Add((Control) ((buMachinePart) this).\u0001);
        ((buMachinePart) this).ControlList.Add((Control) ((buMachinePart) this).\u0001);
        ++num;
      }
      if (type == typeof (Pnt2D))
      {
        Pnt2D pnt2D1 = new Pnt2D();
        Pnt2D pnt2D2 = (Pnt2D) ((EditorRuntimeSettings) Vars[index1]).Value;
        ((buMachinePart) this).\u0001 = (setLabelControl) new buArc();
        ref setLabelControl local = ref ((buMachinePart) this).\u0001;
        string str = pnt2D2.ToString();
        string name = ((EditorRuntimeSettings) Vars[index1]).Name;
        Color backColor = ((buMachinePart) this).\u0001.BackColor;
        \u0007.\u0001.\u0001(name, (buClassViewer5) this, ref local, backColor, str);
        ((buMachinePart) this).\u0001.DoubleClick += new EventHandler(((buCurve) this).\u0003);
        ((buMachinePart) this).\u0001.Location = new Point(((buMachinePart) this).\u0001.Left + ((buMachinePart) this).\u0001.Width + ((buMachinePart) this).RowSpace, ((buMachinePart) this).RowSpace + num * (((buMachinePart) this).RowHeight + ((buMachinePart) this).RowSpace));
        ((buShapeVisualition) ((buMachinePart) this).\u0001).EditValue = ((EditorRuntimeSettings) Vars[index1]).Value;
        ((buMachinePart) this).\u0001.Controls.Add((Control) ((buMachinePart) this).\u0001);
        ((buMachinePart) this).\u0001.Controls.Add((Control) ((buMachinePart) this).\u0001);
        ((buMachinePart) this).ControlList.Add((Control) ((buMachinePart) this).\u0001);
        ++num;
      }
      if (type == typeof (Point))
      {
        Point point = new Point();
        Point S = (Point) ((EditorRuntimeSettings) Vars[index1]).Value;
        ((buMachinePart) this).\u0001 = (setLabelControl) new buArc();
        ref setLabelControl local = ref ((buMachinePart) this).\u0001;
        string str = buConversion.PointToString(S);
        string name = ((EditorRuntimeSettings) Vars[index1]).Name;
        Color backColor = ((buMachinePart) this).\u0001.BackColor;
        \u0007.\u0001.\u0001(name, (buClassViewer5) this, ref local, backColor, str);
        ((buMachinePart) this).\u0001.DoubleClick += new EventHandler(((buCurve) this).\u0003);
        ((buMachinePart) this).\u0001.Location = new Point(((buMachinePart) this).\u0001.Left + ((buMachinePart) this).\u0001.Width + ((buMachinePart) this).RowSpace, ((buMachinePart) this).RowSpace + num * (((buMachinePart) this).RowHeight + ((buMachinePart) this).RowSpace));
        ((buShapeVisualition) ((buMachinePart) this).\u0001).EditValue = ((EditorRuntimeSettings) Vars[index1]).Value;
        ((buMachinePart) this).\u0001.Controls.Add((Control) ((buMachinePart) this).\u0001);
        ((buMachinePart) this).\u0001.Controls.Add((Control) ((buMachinePart) this).\u0001);
        ((buMachinePart) this).ControlList.Add((Control) ((buMachinePart) this).\u0001);
        ++num;
      }
      if (type == typeof (PointF))
      {
        PointF pointF = new PointF();
        PointF S = (PointF) ((EditorRuntimeSettings) Vars[index1]).Value;
        ((buMachinePart) this).\u0001 = (setLabelControl) new buArc();
        ref setLabelControl local = ref ((buMachinePart) this).\u0001;
        string str = buConversion.PointFToString(S);
        string name = ((EditorRuntimeSettings) Vars[index1]).Name;
        Color backColor = ((buMachinePart) this).\u0001.BackColor;
        \u0007.\u0001.\u0001(name, (buClassViewer5) this, ref local, backColor, str);
        ((buMachinePart) this).\u0001.DoubleClick += new EventHandler(((buCurve) this).\u0003);
        ((buMachinePart) this).\u0001.Location = new Point(((buMachinePart) this).\u0001.Left + ((buMachinePart) this).\u0001.Width + ((buMachinePart) this).RowSpace, ((buMachinePart) this).RowSpace + num * (((buMachinePart) this).RowHeight + ((buMachinePart) this).RowSpace));
        ((buShapeVisualition) ((buMachinePart) this).\u0001).EditValue = ((EditorRuntimeSettings) Vars[index1]).Value;
        ((buMachinePart) this).\u0001.Controls.Add((Control) ((buMachinePart) this).\u0001);
        ((buMachinePart) this).\u0001.Controls.Add((Control) ((buMachinePart) this).\u0001);
        ((buMachinePart) this).ControlList.Add((Control) ((buMachinePart) this).\u0001);
        ++num;
      }
      if (type == typeof (Size))
      {
        Size size = new Size();
        Size S = (Size) ((EditorRuntimeSettings) Vars[index1]).Value;
        ((buMachinePart) this).\u0001 = (setLabelControl) new buArc();
        ref setLabelControl local = ref ((buMachinePart) this).\u0001;
        string str = buConversion.SizeToString(S);
        string name = ((EditorRuntimeSettings) Vars[index1]).Name;
        Color backColor = ((buMachinePart) this).\u0001.BackColor;
        \u0007.\u0001.\u0001(name, (buClassViewer5) this, ref local, backColor, str);
        ((buMachinePart) this).\u0001.DoubleClick += new EventHandler(((buCurve) this).\u0003);
        ((buMachinePart) this).\u0001.Location = new Point(((buMachinePart) this).\u0001.Left + ((buMachinePart) this).\u0001.Width + ((buMachinePart) this).RowSpace, ((buMachinePart) this).RowSpace + num * (((buMachinePart) this).RowHeight + ((buMachinePart) this).RowSpace));
        ((buShapeVisualition) ((buMachinePart) this).\u0001).EditValue = ((EditorRuntimeSettings) Vars[index1]).Value;
        ((buMachinePart) this).\u0001.Controls.Add((Control) ((buMachinePart) this).\u0001);
        ((buMachinePart) this).\u0001.Controls.Add((Control) ((buMachinePart) this).\u0001);
        ((buMachinePart) this).ControlList.Add((Control) ((buMachinePart) this).\u0001);
        ++num;
      }
      if (type == typeof (SizeF))
      {
        SizeF sizeF = new SizeF();
        SizeF S = (SizeF) ((EditorRuntimeSettings) Vars[index1]).Value;
        ((buMachinePart) this).\u0001 = (setLabelControl) new buArc();
        ref setLabelControl local = ref ((buMachinePart) this).\u0001;
        string str = buConversion.SizeFToString(S);
        string name = ((EditorRuntimeSettings) Vars[index1]).Name;
        Color backColor = ((buMachinePart) this).\u0001.BackColor;
        \u0007.\u0001.\u0001(name, (buClassViewer5) this, ref local, backColor, str);
        ((buMachinePart) this).\u0001.DoubleClick += new EventHandler(((buCurve) this).\u0003);
        ((buMachinePart) this).\u0001.Location = new Point(((buMachinePart) this).\u0001.Left + ((buMachinePart) this).\u0001.Width + ((buMachinePart) this).RowSpace, ((buMachinePart) this).RowSpace + num * (((buMachinePart) this).RowHeight + ((buMachinePart) this).RowSpace));
        ((buShapeVisualition) ((buMachinePart) this).\u0001).EditValue = ((EditorRuntimeSettings) Vars[index1]).Value;
        ((buMachinePart) this).\u0001.Controls.Add((Control) ((buMachinePart) this).\u0001);
        ((buMachinePart) this).\u0001.Controls.Add((Control) ((buMachinePart) this).\u0001);
        ((buMachinePart) this).ControlList.Add((Control) ((buMachinePart) this).\u0001);
        ++num;
      }
      if (type == typeof (Color))
      {
        bool result = false;
        bool.TryParse(((EditorRuntimeSettings) Vars[index1]).ValueAsString, out result);
        ((buMachinePart) this).\u0001 = (setColorComboControl) new buArc();
        ref setColorComboControl local = ref ((buMachinePart) this).\u0001;
        \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((Color) ((EditorRuntimeSettings) Vars[index1]).Value, ((EditorRuntimeSettings) Vars[index1]).Name, ref local, 0, (buClassViewer5) this);
        ((buMachinePart) this).\u0001.Location = new Point(((buMachinePart) this).\u0001.Left + ((buMachinePart) this).\u0001.Width + ((buMachinePart) this).RowSpace, ((buMachinePart) this).RowSpace + num * (((buMachinePart) this).RowHeight + ((buMachinePart) this).RowSpace));
        ((buMachinePart) this).\u0001.Controls.Add((Control) ((buMachinePart) this).\u0001);
        ((buMachinePart) this).\u0001.Controls.Add((Control) ((buMachinePart) this).\u0001);
        ((buMachinePart) this).ControlList.Add((Control) ((buMachinePart) this).\u0001);
        ++num;
      }
      if (type == typeof (Font))
      {
        bool result = false;
        bool.TryParse(((EditorRuntimeSettings) Vars[index1]).ValueAsString, out result);
        ((buMachinePart) this).\u0001 = (setLabelControl) new buArc();
        ref setLabelControl local = ref ((buMachinePart) this).\u0001;
        string valueAsString = ((EditorRuntimeSettings) Vars[index1]).ValueAsString;
        string name = ((EditorRuntimeSettings) Vars[index1]).Name;
        Color backColor = ((buMachinePart) this).\u0001.BackColor;
        \u0007.\u0001.\u0001(name, (buClassViewer5) this, ref local, backColor, valueAsString);
        ((buMachinePart) this).\u0001.Location = new Point(((buMachinePart) this).\u0001.Left + ((buMachinePart) this).\u0001.Width + ((buMachinePart) this).RowSpace, ((buMachinePart) this).RowSpace + num * (((buMachinePart) this).RowHeight + ((buMachinePart) this).RowSpace));
        ((buShapeVisualition) ((buMachinePart) this).\u0001).EditValue = ((EditorRuntimeSettings) Vars[index1]).Value;
        ((buMachinePart) this).\u0001.DoubleClick += new EventHandler(((buCurve) this).\u0003);
        ((buMachinePart) this).\u0001.Controls.Add((Control) ((buMachinePart) this).\u0001);
        ((buMachinePart) this).\u0001.Controls.Add((Control) ((buMachinePart) this).\u0001);
        ((buMachinePart) this).ControlList.Add((Control) ((buMachinePart) this).\u0001);
        ++num;
      }
      if (type == typeof (DateTime))
      {
        DateTime result = DateTime.Now;
        DateTime.TryParse(((EditorRuntimeSettings) Vars[index1]).ValueAsString, out result);
        ((buMachinePart) this).\u0001 = (setDateTimeControl) new buArc();
        ref setDateTimeControl local = ref ((buMachinePart) this).\u0001;
        string name = ((EditorRuntimeSettings) Vars[index1]).Name;
        \u0007.\u0001.\u0001(ref local, result, 0, name, (buClassViewer5) this);
        ((buMachinePart) this).\u0001.Location = new Point(((buMachinePart) this).\u0001.Left + ((buMachinePart) this).\u0001.Width + ((buMachinePart) this).RowSpace, ((buMachinePart) this).RowSpace + num * (((buMachinePart) this).RowHeight + ((buMachinePart) this).RowSpace));
        ((buMachinePart) this).\u0001.Controls.Add((Control) ((buMachinePart) this).\u0001);
        ((buMachinePart) this).\u0001.Controls.Add((Control) ((buMachinePart) this).\u0001);
        ((buMachinePart) this).ControlList.Add((Control) ((buMachinePart) this).\u0001);
        ++num;
      }
      if (type == typeof (drawPropertiesType))
      {
        drawPropertiesType drawPropertiesType1 = new drawPropertiesType();
        drawPropertiesType drawPropertiesType2 = (drawPropertiesType) ((EditorRuntimeSettings) Vars[index1]).Value;
        bool result = false;
        bool.TryParse(((EditorRuntimeSettings) Vars[index1]).ValueAsString, out result);
        ((buMachinePart) this).\u0001 = (setLabelControl) new buArc();
        ref setLabelControl local = ref ((buMachinePart) this).\u0001;
        string str = drawPropertiesType2.ToString();
        string name = ((EditorRuntimeSettings) Vars[index1]).Name;
        Color color = drawPropertiesType2.Color;
        \u0007.\u0001.\u0001(name, (buClassViewer5) this, ref local, color, str);
        ((buMachinePart) this).\u0001.DoubleClick += new EventHandler(((buCurve) this).\u0003);
        ((buMachinePart) this).\u0001.Location = new Point(((buMachinePart) this).\u0001.Left + ((buMachinePart) this).\u0001.Width + ((buMachinePart) this).RowSpace, ((buMachinePart) this).RowSpace + num * (((buMachinePart) this).RowHeight + ((buMachinePart) this).RowSpace));
        ((buShapeVisualition) ((buMachinePart) this).\u0001).EditValue = ((EditorRuntimeSettings) Vars[index1]).Value;
        ((buMachinePart) this).\u0001.Font = new Font("Times New Roman", 8f);
        new ToolTip().SetToolTip((Control) ((buMachinePart) this).\u0001, ((buMachinePart) this).\u0001.Text);
        ((buMachinePart) this).\u0001.Controls.Add((Control) ((buMachinePart) this).\u0001);
        ((buMachinePart) this).\u0001.Controls.Add((Control) ((buMachinePart) this).\u0001);
        ((buMachinePart) this).ControlList.Add((Control) ((buMachinePart) this).\u0001);
        ++num;
      }
      if (type == typeof (ColorType))
      {
        ColorType colorType1 = (ColorType) new GeometryTableItem();
        ColorType colorType2 = (ColorType) ((EditorRuntimeSettings) Vars[index1]).Value;
        bool result = false;
        bool.TryParse(((EditorRuntimeSettings) Vars[index1]).ValueAsString, out result);
        ((buMachinePart) this).\u0001 = (setLabelControl) new buArc();
        ref setLabelControl local = ref ((buMachinePart) this).\u0001;
        string str = colorType2.ToString();
        string name = ((EditorRuntimeSettings) Vars[index1]).Name;
        Color color = ((hmiUIOptions) colorType2).Color;
        \u0007.\u0001.\u0001(name, (buClassViewer5) this, ref local, color, str);
        ((buMachinePart) this).\u0001.DoubleClick += new EventHandler(((buCurve) this).\u0003);
        ((buMachinePart) this).\u0001.Location = new Point(((buMachinePart) this).\u0001.Left + ((buMachinePart) this).\u0001.Width + ((buMachinePart) this).RowSpace, ((buMachinePart) this).RowSpace + num * (((buMachinePart) this).RowHeight + ((buMachinePart) this).RowSpace));
        ((buShapeVisualition) ((buMachinePart) this).\u0001).EditValue = ((EditorRuntimeSettings) Vars[index1]).Value;
        ((buMachinePart) this).\u0001.Font = new Font("Times New Roman", 8f);
        new ToolTip().SetToolTip((Control) ((buMachinePart) this).\u0001, ((buMachinePart) this).\u0001.Text);
        ((buMachinePart) this).\u0001.Controls.Add((Control) ((buMachinePart) this).\u0001);
        ((buMachinePart) this).\u0001.Controls.Add((Control) ((buMachinePart) this).\u0001);
        ((buMachinePart) this).ControlList.Add((Control) ((buMachinePart) this).\u0001);
        ++num;
      }
      if (type == typeof (ColorDrawType))
      {
        ColorDrawType colorDrawType1 = (ColorDrawType) new CircularSpeedReduction();
        ColorDrawType colorDrawType2 = (ColorDrawType) ((EditorRuntimeSettings) Vars[index1]).Value;
        bool result = false;
        bool.TryParse(((EditorRuntimeSettings) Vars[index1]).ValueAsString, out result);
        ((buMachinePart) this).\u0001 = (setLabelControl) new buArc();
        ref setLabelControl local = ref ((buMachinePart) this).\u0001;
        string str = colorDrawType2.ToString();
        string name = ((EditorRuntimeSettings) Vars[index1]).Name;
        Color color = ((hmiUIDataGridView) colorDrawType2).Color;
        \u0007.\u0001.\u0001(name, (buClassViewer5) this, ref local, color, str);
        ((buMachinePart) this).\u0001.DoubleClick += new EventHandler(((buCurve) this).\u0003);
        ((buMachinePart) this).\u0001.Location = new Point(((buMachinePart) this).\u0001.Left + ((buMachinePart) this).\u0001.Width + ((buMachinePart) this).RowSpace, ((buMachinePart) this).RowSpace + num * (((buMachinePart) this).RowHeight + ((buMachinePart) this).RowSpace));
        ((buShapeVisualition) ((buMachinePart) this).\u0001).EditValue = ((EditorRuntimeSettings) Vars[index1]).Value;
        ((buMachinePart) this).\u0001.Font = new Font("Times New Roman", 8f);
        new ToolTip().SetToolTip((Control) ((buMachinePart) this).\u0001, ((buMachinePart) this).\u0001.Text);
        ((buMachinePart) this).\u0001.Controls.Add((Control) ((buMachinePart) this).\u0001);
        ((buMachinePart) this).\u0001.Controls.Add((Control) ((buMachinePart) this).\u0001);
        ((buMachinePart) this).ControlList.Add((Control) ((buMachinePart) this).\u0001);
        ++num;
      }
      if (type == typeof (MouseKeyboardConfigration))
      {
        MouseKeyboardConfigration keyboardConfigration1 = new MouseKeyboardConfigration();
        MouseKeyboardConfigration keyboardConfigration2 = (MouseKeyboardConfigration) ((EditorRuntimeSettings) Vars[index1]).Value;
        bool result = false;
        bool.TryParse(((EditorRuntimeSettings) Vars[index1]).ValueAsString, out result);
        ((buMachinePart) this).\u0001 = (setLabelControl) new buArc();
        ref setLabelControl local = ref ((buMachinePart) this).\u0001;
        string str = keyboardConfigration2.ToString();
        string name = ((EditorRuntimeSettings) Vars[index1]).Name;
        Color backColor = ((buMachinePart) this).\u0001.BackColor;
        \u0007.\u0001.\u0001(name, (buClassViewer5) this, ref local, backColor, str);
        ((buMachinePart) this).\u0001.DoubleClick += new EventHandler(((buCurve) this).\u0003);
        ((buMachinePart) this).\u0001.Location = new Point(((buMachinePart) this).\u0001.Left + ((buMachinePart) this).\u0001.Width + ((buMachinePart) this).RowSpace, ((buMachinePart) this).RowSpace + num * (((buMachinePart) this).RowHeight + ((buMachinePart) this).RowSpace));
        ((buShapeVisualition) ((buMachinePart) this).\u0001).EditValue = ((EditorRuntimeSettings) Vars[index1]).Value;
        ((buMachinePart) this).\u0001.Font = new Font("Times New Roman", 8f);
        new ToolTip().SetToolTip((Control) ((buMachinePart) this).\u0001, ((buMachinePart) this).\u0001.Text);
        ((buMachinePart) this).\u0001.Controls.Add((Control) ((buMachinePart) this).\u0001);
        ((buMachinePart) this).\u0001.Controls.Add((Control) ((buMachinePart) this).\u0001);
        ((buMachinePart) this).ControlList.Add((Control) ((buMachinePart) this).\u0001);
        ++num;
      }
      if (type == typeof (EntityResolution))
      {
        EntityResolution entityResolution1 = new EntityResolution();
        EntityResolution entityResolution2 = (EntityResolution) ((EditorRuntimeSettings) Vars[index1]).Value;
        bool result = false;
        bool.TryParse(((EditorRuntimeSettings) Vars[index1]).ValueAsString, out result);
        ((buMachinePart) this).\u0001 = (setLabelControl) new buArc();
        ref setLabelControl local = ref ((buMachinePart) this).\u0001;
        string str = entityResolution2.ToString();
        string name = ((EditorRuntimeSettings) Vars[index1]).Name;
        Color backColor = ((buMachinePart) this).\u0001.BackColor;
        \u0007.\u0001.\u0001(name, (buClassViewer5) this, ref local, backColor, str);
        ((buMachinePart) this).\u0001.DoubleClick += new EventHandler(((buCurve) this).\u0003);
        ((buMachinePart) this).\u0001.Font = new Font("Times New Roman", 8f);
        ((buMachinePart) this).\u0001.Location = new Point(((buMachinePart) this).\u0001.Left + ((buMachinePart) this).\u0001.Width + ((buMachinePart) this).RowSpace, ((buMachinePart) this).RowSpace + num * (((buMachinePart) this).RowHeight + ((buMachinePart) this).RowSpace));
        ((buShapeVisualition) ((buMachinePart) this).\u0001).EditValue = ((EditorRuntimeSettings) Vars[index1]).Value;
        new ToolTip() { InitialDelay = 100, ReshowDelay = 100 }.SetToolTip((Control) ((buMachinePart) this).\u0001, ((buMachinePart) this).\u0001.Text);
        ((buMachinePart) this).\u0001.Controls.Add((Control) ((buMachinePart) this).\u0001);
        ((buMachinePart) this).\u0001.Controls.Add((Control) ((buMachinePart) this).\u0001);
        ((buMachinePart) this).ControlList.Add((Control) ((buMachinePart) this).\u0001);
        ++num;
      }
      if (type == typeof (SolidItemDisplay))
      {
        SolidItemDisplay solidItemDisplay1 = new SolidItemDisplay();
        SolidItemDisplay solidItemDisplay2 = (SolidItemDisplay) ((EditorRuntimeSettings) Vars[index1]).Value;
        bool result = false;
        bool.TryParse(((EditorRuntimeSettings) Vars[index1]).ValueAsString, out result);
        ((buMachinePart) this).\u0001 = (setLabelControl) new buArc();
        ref setLabelControl local = ref ((buMachinePart) this).\u0001;
        string str = solidItemDisplay2.ToString();
        string name = ((EditorRuntimeSettings) Vars[index1]).Name;
        Color backColor = ((buMachinePart) this).\u0001.BackColor;
        \u0007.\u0001.\u0001(name, (buClassViewer5) this, ref local, backColor, str);
        ((buMachinePart) this).\u0001.DoubleClick += new EventHandler(((buCurve) this).\u0003);
        ((buMachinePart) this).\u0001.Font = new Font("Times New Roman", 8f);
        ((buMachinePart) this).\u0001.Location = new Point(((buMachinePart) this).\u0001.Left + ((buMachinePart) this).\u0001.Width + ((buMachinePart) this).RowSpace, ((buMachinePart) this).RowSpace + num * (((buMachinePart) this).RowHeight + ((buMachinePart) this).RowSpace));
        ((buShapeVisualition) ((buMachinePart) this).\u0001).EditValue = ((EditorRuntimeSettings) Vars[index1]).Value;
        new ToolTip() { InitialDelay = 100, ReshowDelay = 100 }.SetToolTip((Control) ((buMachinePart) this).\u0001, ((buMachinePart) this).\u0001.Text);
        ((buMachinePart) this).\u0001.Controls.Add((Control) ((buMachinePart) this).\u0001);
        ((buMachinePart) this).\u0001.Controls.Add((Control) ((buMachinePart) this).\u0001);
        ((buMachinePart) this).ControlList.Add((Control) ((buMachinePart) this).\u0001);
        ++num;
      }
    }
    if (((buMachinePart) this).ShowOkButton)
    {
      ((buMachinePart) this).\u0001.Location = new Point(((buMachinePart) this).RowSpace, ((buMachinePart) this).RowSpace + num * (((buMachinePart) this).RowHeight + ((buMachinePart) this).RowSpace) + 4);
      ((buMachinePart) this).\u0001.Height = 40;
      ((buMachinePart) this).\u0001.Width = ((Control) this).Width - ((buMachinePart) this).ValueWidth - ((buMachinePart) this).RowSpace * 9;
      ((buMachinePart) this).\u0001.Text = "  Ok";
      ((buMachinePart) this).\u0001.ImageAlign = ContentAlignment.MiddleLeft;
      if (((buMachinePart) this).OkButtonText.Length > 0)
        ((buMachinePart) this).\u0001.Text = "  " + ((buMachinePart) this).OkButtonText;
      ((buMachinePart) this).\u0001.Visible = true;
      ((buMachinePart) this).\u0001.Click += new EventHandler(((buCurve) this).\u0005);
      ((buMachinePart) this).\u0001.Controls.Add((Control) ((buMachinePart) this).\u0001);
    }
    if (!((buMachinePart) this).ShowCancelButton)
      return;
    ((buMachinePart) this).\u0002.Location = new Point(((Control) this).Width - (((buMachinePart) this).ValueWidth - ((buMachinePart) this).RowSpace * 9) - 8, ((buMachinePart) this).RowSpace + num * (((buMachinePart) this).RowHeight + ((buMachinePart) this).RowSpace) + 4);
    ((buMachinePart) this).\u0002.Height = 40;
    ((buMachinePart) this).\u0002.Width = ((buMachinePart) this).ValueWidth - ((buMachinePart) this).RowSpace * 9;
    ((buMachinePart) this).\u0002.Text = "  Cancel";
    ((buMachinePart) this).\u0002.ImageAlign = ContentAlignment.MiddleLeft;
    if (((buMachinePart) this).CancelButtonText.Length > 0)
      ((buMachinePart) this).\u0002.Text = "  " + ((buMachinePart) this).CancelButtonText;
    ((buMachinePart) this).\u0002.Visible = true;
    ((buMachinePart) this).\u0002.Click += new EventHandler(((buCurve) this).\u0005);
    ((buMachinePart) this).\u0001.Controls.Add((Control) ((buMachinePart) this).\u0002);
  }

  internal new void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    ((HandledMouseEventArgs) obj1).Handled = true;
  }

  internal new void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    Control control = (Control) obj0;
    if (control.GetType() == typeof (setNumericUpDownControl))
    {
      ((buShapeVisualition) control).EditValue = (object) (double) ((NumericUpDown) control).Value;
      cParameter5 cParameter5 = (cParameter5) new buVector5(control.Tag.ToString(), ((buShapeVisualition) control).EditValue);
      buSerilization5.SetClassVariable(ref ((buMachinePart) this).ClassObject, cParameter5);
      // ISSUE: reference to a compiler-generated field
      if (((buMachinePart) this).\u0001 != null)
      {
        // ISSUE: reference to a compiler-generated field
        ((buCompositeCurve) ((buMachinePart) this).\u0001).Invoke((object) this, ((buShapeVisualition) control).EditValue, cParameter5);
      }
    }
    if (control.GetType() == typeof (setTextBoxControl))
    {
      ((buShapeVisualition) control).EditValue = (object) control.Text;
      cParameter5 cParameter5 = (cParameter5) new buVector5(control.Tag.ToString(), ((buShapeVisualition) control).EditValue);
      buSerilization5.SetClassVariable(ref ((buMachinePart) this).ClassObject, cParameter5);
      // ISSUE: reference to a compiler-generated field
      if (((buMachinePart) this).\u0001 != null)
      {
        // ISSUE: reference to a compiler-generated field
        ((buCompositeCurve) ((buMachinePart) this).\u0001).Invoke((object) this, ((buShapeVisualition) control).EditValue, cParameter5);
      }
    }
    if (control.GetType() == typeof (setCheckBoxControl))
    {
      ((buShapeVisualition) control).EditValue = (object) ((CheckBox) control).Checked;
      cParameter5 cParameter5 = (cParameter5) new buVector5(control.Tag.ToString(), ((buShapeVisualition) control).EditValue);
      buSerilization5.SetClassVariable(ref ((buMachinePart) this).ClassObject, cParameter5);
      // ISSUE: reference to a compiler-generated field
      if (((buMachinePart) this).\u0001 != null)
      {
        // ISSUE: reference to a compiler-generated field
        ((buCompositeCurve) ((buMachinePart) this).\u0001).Invoke((object) this, ((buShapeVisualition) control).EditValue, cParameter5);
      }
    }
    if (control.GetType() == typeof (setDateTimeControl))
    {
      ((buShapeVisualition) control).EditValue = (object) ((DateTimePicker) control).Value;
      cParameter5 cParameter5 = (cParameter5) new buVector5(control.Tag.ToString(), ((buShapeVisualition) control).EditValue);
      buSerilization5.SetClassVariable(ref ((buMachinePart) this).ClassObject, cParameter5);
      // ISSUE: reference to a compiler-generated field
      if (((buMachinePart) this).\u0001 != null)
      {
        // ISSUE: reference to a compiler-generated field
        ((buCompositeCurve) ((buMachinePart) this).\u0001).Invoke((object) this, ((buShapeVisualition) control).EditValue, cParameter5);
      }
    }
    if (!(control.GetType() == typeof (setComboBoxControl)))
      return;
    ((buShapeVisualition) control).EditValue = (object) control.Text;
    cParameter5 cParameter5_1 = (cParameter5) new buVector5(control.Tag.ToString(), ((buShapeVisualition) control).EditValue);
    buSerilization5.SetClassVariable(ref ((buMachinePart) this).ClassObject, cParameter5_1);
    // ISSUE: reference to a compiler-generated field
    if (((buMachinePart) this).\u0001 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    ((buCompositeCurve) ((buMachinePart) this).\u0001).Invoke((object) this, ((buShapeVisualition) control).EditValue, cParameter5_1);
  }
}
