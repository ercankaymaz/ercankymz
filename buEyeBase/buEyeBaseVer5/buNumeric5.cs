// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buNumeric5
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5;

public class buNumeric5
{
  public static void eyeEntityTogeoEntities(
    List<List<Entity>> eyeEntity,
    Color color,
    List<LayerBase5> Layers,
    ref List<List<geoEntity>> geoEntity)
  {
    geoEntity.Clear();
    for (int index1 = 0; index1 <= eyeEntity.Count - 1; ++index1)
    {
      List<geoEntity> geoEntityList = new List<geoEntity>();
      for (int index2 = 0; index2 <= eyeEntity[index1].Count - 1; ++index2)
      {
        geoEntity geoEntity1 = (geoEntity) null;
        buString5.eyeEntityTogeoEntities(eyeEntity[index1][index2], color, Layers, ref geoEntity1);
        if (geoEntity1 != null)
          geoEntityList.Add(geoEntity1);
      }
      if (geoEntityList.Count > 0)
        geoEntity.Add(geoEntityList);
    }
  }

  public static void EntityCommonProperties(
    ref Entity eyeEntity,
    eEntities cadEntity,
    List<LayerBase5> Layers)
  {
    eyeEntity.ColorMethod = colorMethodType.byLayer;
    eyeEntity.LineWeightMethod = colorMethodType.byLayer;
    eyeEntity.LineTypeMethod = colorMethodType.byLayer;
    eyeEntity.Color = cadEntity.dispColor;
    eyeEntity.LineWeight = cadEntity.dispThickness;
    if (cadEntity.LayerIndex < 0)
      cadEntity.LayerIndex = 0;
    if (cadEntity.LayerIndex >= 0 & cadEntity.LayerIndex <= Layers.Count - 1)
      eyeEntity.LayerName = ((DevideEventFormVars) Layers[cadEntity.LayerIndex]).Name;
    if (eyeEntity.EntityData == null || !(eyeEntity.EntityData is CustomData))
      return;
    ((CutterRuntimeSettings) eyeEntity.EntityData).set_typeDefination(cadEntity.TypeDefination);
  }

  public static ObjectAlignment CornerLocationToObjectAlignment(CornerLocation Location)
  {
    ObjectAlignment objectAlignment = ObjectAlignment.BottomCenter;
    if (Location == CornerLocation.RightBottom)
      objectAlignment = ObjectAlignment.BottomRight;
    if (Location == CornerLocation.RightCenter)
      objectAlignment = ObjectAlignment.MiddleRight;
    if (Location == CornerLocation.RightTop)
      objectAlignment = ObjectAlignment.TopRight;
    if (Location == CornerLocation.LeftBottom)
      objectAlignment = ObjectAlignment.BottomLeft;
    if (Location == CornerLocation.LeftCenter)
      objectAlignment = ObjectAlignment.MiddleLeft;
    if (Location == CornerLocation.LeftTop)
      objectAlignment = ObjectAlignment.TopLeft;
    if (Location == CornerLocation.TopCenter)
      objectAlignment = ObjectAlignment.TopCenter;
    if (Location == CornerLocation.BottomCenter)
      objectAlignment = ObjectAlignment.BottomCenter;
    return objectAlignment;
  }

  public static Color BoolToColor(bool State, Color OnColor, Color OffColor)
  {
    return !State ? OffColor : OnColor;
  }

  public static bool StringToBool(string Value)
  {
    try
    {
      return Value.Trim() == "1" | Value.Trim().ToLower() == "true";
    }
    catch (Exception ex)
    {
      return true;
    }
  }

  public static double StringToDouble(string Value)
  {
    try
    {
      double num = 0.0;
      if (buFile5.IsNumeric(Value))
        num = double.Parse(Value);
      return num;
    }
    catch (Exception ex)
    {
      return 0.0;
    }
  }

  public static int StringToInt(string Value)
  {
    try
    {
      int num = 0;
      if (buFile5.IsNumeric(Value))
        num = int.Parse(Value);
      return num;
    }
    catch (Exception ex)
    {
      return 0;
    }
  }

  public static float StringToFloat(string Value)
  {
    try
    {
      float num = 0.0f;
      if (buFile5.IsNumeric(Value))
        num = float.Parse(Value);
      return num;
    }
    catch (Exception ex)
    {
      return 0.0f;
    }
  }

  public static bool IntToBool(int Value)
  {
    try
    {
      return Value != 0;
    }
    catch (Exception ex)
    {
      return true;
    }
  }

  public static bool DoubleToBool(double Value)
  {
    try
    {
      return Value != 0.0;
    }
    catch (Exception ex)
    {
      return true;
    }
  }

  public static bool FloatToBool(float Value)
  {
    try
    {
      return (double) Value != 0.0;
    }
    catch (Exception ex)
    {
      return true;
    }
  }

  public static string ColorToString(Color clr, ColorConvertType Type)
  {
    try
    {
      return Type == ColorConvertType.Html ? ColorTranslator.ToHtml(clr) : clr.ToString();
    }
    catch (Exception ex)
    {
      return "Black";
    }
  }

  public static string FontToString(Font fnt)
  {
    try
    {
      return new FontConverter().ConvertToString((object) fnt);
    }
    catch (Exception ex)
    {
      return new FontConverter().ConvertToString((object) new Font("Arial", 10f));
    }
  }

  public static Color StringToColor(string Code, ColorConvertType Type)
  {
    Color color = new Color();
    color = Color.Black;
    try
    {
      if (Type == ColorConvertType.Html)
        return ColorTranslator.FromHtml(Code);
      Code = Code.Replace("Color", "");
      Code = Code.Replace("[", "");
      Code = Code.Replace("]", "");
      Code = Code.Trim();
      Color.FromName(Code);
      return Color.FromName(Code);
    }
    catch (Exception ex)
    {
      return Color.Black;
    }
  }

  public static Font StringToFont(string Code)
  {
    Font font = new Font("Arial", 10f);
    try
    {
      return new FontConverter().ConvertFromString(Code) as Font;
    }
    catch (Exception ex)
    {
      return font;
    }
  }

  public static List<string> EnumToString(System.Type enumVal)
  {
    List<string> stringList = new List<string>();
    Array values = Enum.GetValues(enumVal);
    if (values != null)
    {
      for (int index = 0; index <= values.Length - 1; ++index)
        stringList.Add(values.GetValue(index).ToString());
    }
    return stringList;
  }

  public static displayType DisplayModeConvert(DisplayModeType displayMode)
  {
    displayType displayType;
    switch (displayMode)
    {
      case DisplayModeType.Wireframe:
        displayType = displayType.Wireframe;
        break;
      case DisplayModeType.Shaded:
        displayType = displayType.Shaded;
        break;
      case DisplayModeType.Flat:
        displayType = displayType.Flat;
        break;
      case DisplayModeType.HiddenLines:
        displayType = displayType.HiddenLines;
        break;
      default:
        displayType = displayType.Rendered;
        break;
    }
    return displayType;
  }

  public static DisplayModeType DisplayModeConvert(displayType displayMode)
  {
    DisplayModeType displayModeType;
    switch (displayMode)
    {
      case displayType.Wireframe:
        displayModeType = DisplayModeType.Wireframe;
        break;
      case displayType.Shaded:
        displayModeType = DisplayModeType.Shaded;
        break;
      case displayType.Flat:
        displayModeType = DisplayModeType.Flat;
        break;
      case displayType.HiddenLines:
        displayModeType = DisplayModeType.HiddenLines;
        break;
      default:
        displayModeType = DisplayModeType.Rendered;
        break;
    }
    return displayModeType;
  }

  public static projectionType ProjectionTypeConvert(ProjectionModeType ProjectionMode)
  {
    return ProjectionMode != ProjectionModeType.Orthographic ? projectionType.Perspective : projectionType.Orthographic;
  }

  public static ProjectionModeType ProjectionTypeConvert(projectionType ProjectionMode)
  {
    return ProjectionMode != projectionType.Orthographic ? ProjectionModeType.Perspective : ProjectionModeType.Orthographic;
  }

  public static originSymbolStyleType OrigineIconConvert(OriginIconType OrigineIconType)
  {
    return OrigineIconType != OriginIconType.Ball ? originSymbolStyleType.CoordinateSystem : originSymbolStyleType.Ball;
  }

  public static OriginIconType OrigineIconConvert(originSymbolStyleType OrigineIconType)
  {
    return OrigineIconType != originSymbolStyleType.Ball ? OriginIconType.CoordinateSystem : OriginIconType.Ball;
  }

  public static mouseButtonsZPR MouseButtonConvert(mouseButtons Buttons)
  {
    mouseButtonsZPR mouseButtonsZpr;
    switch (Buttons)
    {
      case mouseButtons.Left:
        mouseButtonsZpr = mouseButtonsZPR.Left;
        break;
      case mouseButtons.Right:
        mouseButtonsZpr = mouseButtonsZPR.Right;
        break;
      case mouseButtons.LeftRight:
        mouseButtonsZpr = mouseButtonsZPR.LeftRight;
        break;
      case mouseButtons.Middle:
        mouseButtonsZpr = mouseButtonsZPR.Middle;
        break;
      case mouseButtons.LeftMiddle:
        mouseButtonsZpr = mouseButtonsZPR.LeftMiddle;
        break;
      case mouseButtons.MiddleRight:
        mouseButtonsZpr = mouseButtonsZPR.MiddleRight;
        break;
      case mouseButtons.LeftMiddleRight:
        mouseButtonsZpr = mouseButtonsZPR.LeftMiddleRight;
        break;
      case mouseButtons.XButton1:
        mouseButtonsZpr = mouseButtonsZPR.XButton1;
        break;
      case mouseButtons.XButton2:
        mouseButtonsZpr = mouseButtonsZPR.XButton2;
        break;
      default:
        mouseButtonsZpr = mouseButtonsZPR.None;
        break;
    }
    return mouseButtonsZpr;
  }

  public static devDept.Eyeshot.Control.modifierKeys ModifierKeyConvert(buClass.modifierKeys Keys)
  {
    devDept.Eyeshot.Control.modifierKeys modifierKeys;
    switch (Keys)
    {
      case buClass.modifierKeys.Shift:
        modifierKeys = devDept.Eyeshot.Control.modifierKeys.Shift;
        break;
      case buClass.modifierKeys.Ctrl:
        modifierKeys = devDept.Eyeshot.Control.modifierKeys.Ctrl;
        break;
      case buClass.modifierKeys.CtrlShift:
        modifierKeys = devDept.Eyeshot.Control.modifierKeys.CtrlShift;
        break;
      case buClass.modifierKeys.Alt:
        modifierKeys = devDept.Eyeshot.Control.modifierKeys.Alt;
        break;
      case buClass.modifierKeys.ShiftAlt:
        modifierKeys = devDept.Eyeshot.Control.modifierKeys.ShiftAlt;
        break;
      case buClass.modifierKeys.CtrlAlt:
        modifierKeys = devDept.Eyeshot.Control.modifierKeys.CtrlAlt;
        break;
      case buClass.modifierKeys.CtrlShiftAlt:
        modifierKeys = devDept.Eyeshot.Control.modifierKeys.CtrlShiftAlt;
        break;
      default:
        modifierKeys = devDept.Eyeshot.Control.modifierKeys.None;
        break;
    }
    return modifierKeys;
  }

  public static planeNames PlaneBoxNamesToPlaneNames(planeBoxNames Plane)
  {
    return (planeNames) Convert.ToInt32((object) Plane);
  }

  public static planeBoxNames PlaneNamesToPlaneBoxNames(planeNames Plane)
  {
    return (planeBoxNames) Convert.ToInt32((object) Plane);
  }

  public static ClockDirectionType ChangeClockDirection(ClockDirectionType Dir)
  {
    return Dir != ClockDirectionType.CCW ? ClockDirectionType.CCW : ClockDirectionType.CW;
  }

  public static double KeyCodeNumberToDouble(Keys Key)
  {
    double num;
    switch (Key)
    {
      case Keys.D0:
        num = 0.0;
        break;
      case Keys.D1:
        num = 1.0;
        break;
      case Keys.D2:
        num = 2.0;
        break;
      case Keys.D3:
        num = 3.0;
        break;
      case Keys.D4:
        num = 4.0;
        break;
      case Keys.D5:
        num = 5.0;
        break;
      case Keys.D6:
        num = 6.0;
        break;
      case Keys.D7:
        num = 8.0;
        break;
      case Keys.D8:
        num = 8.0;
        break;
      case Keys.D9:
        num = 9.0;
        break;
      default:
        num = 0.0;
        break;
    }
    return num;
  }

  public static Text.alignmentType buAligntoEyeAlign(ContentAlignment Align)
  {
    return Align != ContentAlignment.BottomLeft ? (Align != ContentAlignment.BottomCenter ? (Align != ContentAlignment.BottomRight ? (Align != ContentAlignment.MiddleCenter ? (Align != ContentAlignment.MiddleLeft ? (Align != ContentAlignment.MiddleRight ? (Align != ContentAlignment.TopCenter ? (Align != ContentAlignment.TopLeft ? (Align != ContentAlignment.TopRight ? (Align != ContentAlignment.BottomCenter ? Text.alignmentType.MiddleLeft : Text.alignmentType.BottomCenter) : Text.alignmentType.TopRight) : Text.alignmentType.TopLeft) : Text.alignmentType.TopCenter) : Text.alignmentType.MiddleRight) : Text.alignmentType.MiddleLeft) : Text.alignmentType.MiddleCenter) : Text.alignmentType.BottomRight) : Text.alignmentType.BottomCenter) : Text.alignmentType.BottomLeft;
  }

  public static ContentAlignment eyeAligntoBuAlign(Text.alignmentType Align)
  {
    return Align != Text.alignmentType.BottomLeft ? (Align != Text.alignmentType.BottomCenter ? (Align != Text.alignmentType.BottomRight ? (Align != Text.alignmentType.MiddleCenter ? (Align != Text.alignmentType.MiddleLeft ? (Align != Text.alignmentType.MiddleRight ? (Align != Text.alignmentType.TopCenter ? (Align != Text.alignmentType.TopLeft ? (Align != Text.alignmentType.TopRight ? (Align != Text.alignmentType.BottomCenter ? ContentAlignment.MiddleLeft : ContentAlignment.BottomCenter) : ContentAlignment.TopRight) : ContentAlignment.TopLeft) : ContentAlignment.TopCenter) : ContentAlignment.MiddleRight) : ContentAlignment.MiddleLeft) : ContentAlignment.MiddleCenter) : ContentAlignment.BottomRight) : ContentAlignment.BottomCenter) : ContentAlignment.BottomLeft;
  }

  public static viewType buViewTypeToEyeViewType(ViewportViewType View)
  {
    viewType eyeViewType;
    switch (View)
    {
      case ViewportViewType.Top:
        eyeViewType = viewType.Top;
        break;
      case ViewportViewType.Front:
        eyeViewType = viewType.Front;
        break;
      case ViewportViewType.Left:
        eyeViewType = viewType.Left;
        break;
      case ViewportViewType.Bottom:
        eyeViewType = viewType.Bottom;
        break;
      case ViewportViewType.Back:
        eyeViewType = viewType.Rear;
        break;
      case ViewportViewType.Right:
        eyeViewType = viewType.Right;
        break;
      case ViewportViewType.Isometric:
        eyeViewType = viewType.Isometric;
        break;
      case ViewportViewType.Trimetric:
        eyeViewType = viewType.Trimetric;
        break;
      default:
        eyeViewType = viewType.Top;
        break;
    }
    return eyeViewType;
  }

  public static mouseButtonsZPR MouseButtonConv(mouseButtons Button)
  {
    mouseButtonsZPR mouseButtonsZpr;
    switch (Button)
    {
      case mouseButtons.None:
        mouseButtonsZpr = mouseButtonsZPR.None;
        break;
      case mouseButtons.Left:
        mouseButtonsZpr = mouseButtonsZPR.Left;
        break;
      case mouseButtons.Right:
        mouseButtonsZpr = mouseButtonsZPR.Right;
        break;
      case mouseButtons.LeftRight:
        mouseButtonsZpr = mouseButtonsZPR.LeftRight;
        break;
      case mouseButtons.Middle:
        mouseButtonsZpr = mouseButtonsZPR.Middle;
        break;
      case mouseButtons.LeftMiddle:
        mouseButtonsZpr = mouseButtonsZPR.LeftMiddle;
        break;
      case mouseButtons.MiddleRight:
        mouseButtonsZpr = mouseButtonsZPR.MiddleRight;
        break;
      case mouseButtons.LeftMiddleRight:
        mouseButtonsZpr = mouseButtonsZPR.LeftMiddleRight;
        break;
      case mouseButtons.XButton1:
        mouseButtonsZpr = mouseButtonsZPR.XButton1;
        break;
      case mouseButtons.XButton2:
        mouseButtonsZpr = mouseButtonsZPR.XButton2;
        break;
      default:
        mouseButtonsZpr = mouseButtonsZPR.None;
        break;
    }
    return mouseButtonsZpr;
  }

  public static devDept.Eyeshot.Control.modifierKeys KeyConv(buClass.modifierKeys Key)
  {
    devDept.Eyeshot.Control.modifierKeys modifierKeys;
    switch (Key)
    {
      case buClass.modifierKeys.None:
        modifierKeys = devDept.Eyeshot.Control.modifierKeys.None;
        break;
      case buClass.modifierKeys.Shift:
        modifierKeys = devDept.Eyeshot.Control.modifierKeys.Shift;
        break;
      case buClass.modifierKeys.Ctrl:
        modifierKeys = devDept.Eyeshot.Control.modifierKeys.Ctrl;
        break;
      case buClass.modifierKeys.CtrlShift:
        modifierKeys = devDept.Eyeshot.Control.modifierKeys.CtrlShift;
        break;
      case buClass.modifierKeys.Alt:
        modifierKeys = devDept.Eyeshot.Control.modifierKeys.Alt;
        break;
      case buClass.modifierKeys.ShiftAlt:
        modifierKeys = devDept.Eyeshot.Control.modifierKeys.ShiftAlt;
        break;
      case buClass.modifierKeys.CtrlAlt:
        modifierKeys = devDept.Eyeshot.Control.modifierKeys.CtrlAlt;
        break;
      case buClass.modifierKeys.CtrlShiftAlt:
        modifierKeys = devDept.Eyeshot.Control.modifierKeys.CtrlShiftAlt;
        break;
      default:
        modifierKeys = devDept.Eyeshot.Control.modifierKeys.None;
        break;
    }
    return modifierKeys;
  }

  public static void eyeLayerTobuLayer(Layer eyeLayer, ref LayerBase5 buLayer)
  {
    ref LayerBase5 local = ref buLayer;
    EntityShapeInfo entityShapeInfo = new EntityShapeInfo();
    ((DevideEventFormVars) entityShapeInfo).Name = eyeLayer.Name;
    ((ScaleEventFormVars) entityShapeInfo).Enable = eyeLayer.Visible;
    ((DevideEventFormVars) entityShapeInfo).LayerColor = Color.FromArgb((int) byte.MaxValue, eyeLayer.Color);
    ((DevideEventFormVars) entityShapeInfo).LayerThickness = eyeLayer.LineWeight;
    ((DevideEventFormVars) entityShapeInfo).MaterialName = eyeLayer.MaterialName;
    ((ScaleEventFormVars) entityShapeInfo).Lock = eyeLayer.Locked;
    ((DevideEventFormVars) entityShapeInfo).LayerPurposes = LayerPurpose.General;
    local = (LayerBase5) entityShapeInfo;
    ((DevideEventFormVars) buLayer).Transparency = (int) eyeLayer.Color.A;
  }

  public static void buLayerToeyeLayer(LayerBase5 buLayer, ref Layer eyeLayer)
  {
    eyeLayer = new Layer(((DevideEventFormVars) buLayer).Name)
    {
      Name = ((DevideEventFormVars) buLayer).Name,
      Visible = ((ScaleEventFormVars) buLayer).Enable,
      LineWeight = ((DevideEventFormVars) buLayer).LayerThickness,
      MaterialName = ((DevideEventFormVars) buLayer).MaterialName,
      Locked = ((ScaleEventFormVars) buLayer).Lock
    };
    eyeLayer.Color = Color.FromArgb(((DevideEventFormVars) buLayer).Transparency, ((DevideEventFormVars) buLayer).LayerColor);
  }

  public static LayerKeyedCollection CopyEyeLayerToEyeLayer(LayerKeyedCollection BaseLayer)
  {
    LayerKeyedCollection eyeLayer = new LayerKeyedCollection();
    for (int index = 0; index <= BaseLayer.Count - 1; ++index)
    {
      Layer layer1 = new Layer(BaseLayer[index].Name);
      Layer layer2 = (Layer) BaseLayer[index].Clone();
      eyeLayer.Add(layer2);
    }
    return eyeLayer;
  }

  public static string SecondToTimeFormat(double Second, bool MiliSecond = false)
  {
    TimeSpan timeSpan = TimeSpan.FromSeconds(Second);
    string timeFormat;
    if (MiliSecond)
      timeFormat = $"{timeSpan.Hours:D2}h:{timeSpan.Minutes:D2}m:{timeSpan.Seconds:D2}s:{timeSpan.Milliseconds:D3}ms";
    else
      timeFormat = $"{timeSpan.Hours:D2}h:{timeSpan.Minutes:D2}m:{timeSpan.Seconds:D2}s";
    return timeFormat;
  }

  public static string ToolDirectionToString(Vec3D Direction)
  {
    string str = "-Z";
    if (Direction.Z == 1.0)
      str = "+Z";
    if (Direction.Z == -1.0)
      str = "-Z";
    if (Direction.X == 1.0)
      str = "+X";
    if (Direction.X == -1.0)
      str = "-X";
    if (Direction.Y == 1.0)
      str = "+Y";
    if (Direction.Y == -1.0)
      str = "-Y";
    return str;
  }

  public static selectionFilterType buDynamicSelectionModeToEyeDynamicSelection(
    DynamicalSelectionType selection)
  {
    selectionFilterType dynamicSelection;
    switch (selection)
    {
      case DynamicalSelectionType.Face:
        dynamicSelection = selectionFilterType.Face;
        break;
      case DynamicalSelectionType.Edge:
        dynamicSelection = selectionFilterType.Edge;
        break;
      case DynamicalSelectionType.Entity:
        dynamicSelection = selectionFilterType.Entity;
        break;
      default:
        dynamicSelection = selectionFilterType.Vertex;
        break;
    }
    return dynamicSelection;
  }

  public static DynamicalSelectionType eyeDynamicSelectionModeToBuDynamicSelection(
    selectionFilterType selection)
  {
    DynamicalSelectionType dynamicSelection;
    switch (selection)
    {
      case selectionFilterType.Entity:
        dynamicSelection = DynamicalSelectionType.Entity;
        break;
      case selectionFilterType.Edge:
        dynamicSelection = DynamicalSelectionType.Edge;
        break;
      case selectionFilterType.Face:
        dynamicSelection = DynamicalSelectionType.Face;
        break;
      default:
        dynamicSelection = DynamicalSelectionType.Vertex;
        break;
    }
    return dynamicSelection;
  }

  public abstract void m00049C();

  static buNumeric5()
  {
    // ISSUE: reference to a compiler-generated field
    buVector5.\u003C\u003Ec.\u003C\u003E9 = (buConversion5.\u003C\u003Ec) new buNumeric5();
  }

  public buNumeric5()
  {
  }

  internal int \u0001([In] char obj0) => int.Parse(obj0.ToString());

  public buNumeric5()
  {
    if (!buVector5.\u0001("buString5"))
      throw new RegisterException("buString5");
  }

  public static void MessageBoxInfo(string Message)
  {
    int num = (int) MessageBox.Show(Message, $"{Application.ProductName} ,  Ver : {Application.ProductVersion}", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
  }

  public static void MessageBoxError(string Message)
  {
    int num = (int) MessageBox.Show(Message, $"{Application.ProductName} ,  Ver : {Application.ProductVersion}", MessageBoxButtons.OK, MessageBoxIcon.Hand);
  }

  public static void MessageBoxWarning(string Message)
  {
    int num = (int) MessageBox.Show(Message, $"{Application.ProductName} ,  Ver : {Application.ProductVersion}", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
  }

  public static DialogResult MessageBoxQuestion(string Message)
  {
    return MessageBox.Show(Message, $"{Application.ProductName} ,  Ver : {Application.ProductVersion}", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
  }

  public static DialogResult MessageBoxQuestionYesNoCancel(string Message)
  {
    return MessageBox.Show(Message, $"{Application.ProductName} ,  Ver : {Application.ProductVersion}", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
  }
}
