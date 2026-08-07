// Decompiled with JetBrains decompiler
// Type: buDahengSolutions.Form1
// Assembly: buCameraSolutions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81083553-F2AE-41B0-A4DA-8E8442C4C023
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\Camera\Canon\buCameraSolutions.dll

using buCamera.Canoncamera;
using buCameraSolutions;
using buImageProcessing.ColorFunctions;
using buImageProcessing.DigitizeFunctions;
using buImageProcessing.EdgeFunctions;
using buImageProcessing.ResizeFunctions;
using buImageProcessing.SaveFunctions;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using MvCameraControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

#nullable enable
namespace buDahengSolutions;

public class Form1 : Form
{
  private buDigitizeFunctions DigitizeFunctions = new buDigitizeFunctions();
  private buSaveFunctions SaveFunctions = new buSaveFunctions();
  private buResizeFunctions ResizeFunctions = new buResizeFunctions();
  private buCamera.GenCam.GenCam GenCamFunctions = new buCamera.GenCam.GenCam();
  private buColorFunctions ColorFunctions = new buColorFunctions();
  private buEdgeFunctions EdgeFunctions = new buEdgeFunctions();
  private FormComponents formComponents = new FormComponents();
  private buDigitizeFunctions.DigitizeConfig DigitizeConfig = new buDigitizeFunctions.DigitizeConfig();
  private CalibrationSettings calibSettingsForm = new CalibrationSettings();
  private static string imgFile;
  private static string imgSavePath;
  private static string pointsFile;
  private static string calibFile;
  private static string settingsFile;
  private int a = 0;
  private string configFile;
  private string menuSettings;
  private string canonSettings;
  private string gencamSettings;
  private string edgeSettings;
  private string offsetPath;
  private static Image<Bgr, byte> loadedImage;
  private static Image<Bgr, byte> dynamicImg;
  private static Image<Bgr, byte> workImg;
  private bool isBackroundDetect = false;
  private double bgrBlue;
  private double bgrGreen;
  private double bgrRed;
  private string colorConvType = "BGR2LAB";
  public VectorOfVectorOfPoint contourEdgeFunc = (VectorOfVectorOfPoint) null;
  public Mat outputHierarcy = (Mat) null;
  private double pix2mmCB = 1.0;
  private static List<Vector2> reducedPoints = new List<Vector2>();
  private static List<Vector2> outputVectors = new List<Vector2>();
  private List<List<Vector2>> outputContoursList = new List<List<Vector2>>();
  private List<List<List<Vector2>>> insideContoursList = new List<List<List<Vector2>>>();
  private List<List<Point>> scaledDrawnContours = new List<List<Point>>();
  private List<List<List<Point>>> drawnscaled2contours = new List<List<List<Point>>>();
  private static List<List<Vector3>> outputVector3 = new List<List<Vector3>>();
  private static List<List<List<Vector3>>> insideVector3 = new List<List<List<Vector3>>>();
  private List<List<Point>> allDrawPoints = new List<List<Point>>();
  private List<List<Point>> deleteZones = new List<List<Point>>();
  private List<Point> currentPoints = new List<Point>();
  private List<Point> currentDeletePoints = new List<Point>();
  private Mat transformMatrix = new Mat();
  private double pix2mmX = 1.0;
  private double pix2mmY = 1.0;
  public static int turnDeg = 0;
  public static bool flipH = false;
  public static bool flipV = false;
  public static volatile bool threadState = false;
  private List<IDeviceInfo> deviceInfoList = new List<IDeviceInfo>();
  private readonly DeviceTLayerType enumTLayerType = DeviceTLayerType.MvGigEDevice | DeviceTLayerType.MvUsbDevice | DeviceTLayerType.MvGenTLGigEDevice | DeviceTLayerType.MvGenTLCameraLinkDevice | DeviceTLayerType.MvGenTLCXPDevice | DeviceTLayerType.MvGenTLXoFDevice;
  private IDevice device = (IDevice) null;
  private bool isGrabbing = false;
  private bool isRecord = false;
  private Thread receiveThread = (Thread) null;
  private IFrameOut frameForSave;
  private readonly object saveImageLock = new object();
  private int? draggingIndex = new int?();
  private const int handleSize = 10;
  public static DigitizeSettings digitizSettingsForm;
  public static EdgeDetectSettings edgeSettingsForm;
  private static CanonSDK _sdk = new CanonSDK();
  private CanonCamera _camera;
  private Bgr backColor = new Bgr(0.0, (double) byte.MaxValue, 0.0);
  private PointF renderingOffset = new PointF(0.0f, 0.0f);
  private string articlePath;
  private string dragPath;
  private float currentZoom = 1f;
  private PointF panOffset = new PointF(0.0f, 0.0f);
  private bool _isInternalChange = false;
  private int? draggingArticleIndex = new int?();
  private Stack<PointF[]> dragHistory = new Stack<PointF[]>();
  private Stack<List<PointF>> articleHistory = new Stack<List<PointF>>();
  private Stack<PointF[]> dragRedoHistory = new Stack<PointF[]>();
  private Stack<List<PointF>> articleRedoHistory = new Stack<List<PointF>>();
  private const int MaxHistory = 20;
  private RectangleF selectionRect;
  private bool isSelecting = false;
  private PointF selectionStart;
  private StringBuilder outBuilder = new StringBuilder();
  private StringBuilder inBuilder = new StringBuilder();
  private TaskCompletionSource<bool> _genCamTaskCompletionSource;
  private bool isDualCam = true;
  private float _lastAppliedExp = -1f;
  private float _lastAppliedGain = -1f;
  private Mat currentCameraMatrix = new Mat();
  private Mat currentRvec = new Mat();
  private Mat currentTvec = new Mat();
  private Mat currentPaddedHomography = new Mat();
  private IFrameOut frameOutLocal;
  private bool isPanning = false;
  private Point lastMousePos;
  private List<PointF> articlePre1;
  private PointF[] dragPre1;
  private bool isSyncing = false;
  private Color gridColor = Color.FromArgb(150, Color.White);
  private 
  #nullable disable
  IContainer components = (IContainer) null;
  private PictureBox pboxEdit;
  private Button btnLoad;
  private Button btnSave;
  private Button btnUndo;
  private Button btnVideoMode;
  private Button btnRefresh;
  private Button btnTakePhoto;
  private Button btnCalibDual;
  private Button btnFindContour;
  private Button btnRemoveBack;
  private Button btnLoadAsDrag;
  private Button btnSaveAsDrag;
  private Button btnLoadAsArticle;
  private Button btnSaveAsArticle;
  private Button btnResetMarker;
  private Button btnResetDrag;
  private Button btnResetImage;
  private Button btnGridColor;
  private Button btnSavePre1;
  private Button btnLoadPre1;
  private Button btnTabCanon;
  private Button btnTabGencam;
  private Button btnHardReset;
  private Button btnSwitchGencam;
  private Button btnCancel;
  private Button btnExtend;
  private Button btnMinimize;
  private Button btnLockIP;
  private Button btnTabEdge;
  private NumericUpDown numUDGCManExp;
  private NumericUpDown numUDGain;
  private NumericUpDown numUDExpAutoLow;
  private NumericUpDown numUDExpAutoUp;
  private NumericUpDown numUDGridX;
  private NumericUpDown numUDGridY;
  private NumericUpDown numUDGridThick;
  private NumericUpDown numUDTLX;
  private NumericUpDown numUDTLY;
  private NumericUpDown numUDTRX;
  private NumericUpDown numUDTRY;
  private NumericUpDown numUDBLX;
  private NumericUpDown numUDBLY;
  private NumericUpDown numUDBRX;
  private NumericUpDown numUDBRY;
  private Label lblExposure;
  private Label lblGain;
  private Label lblLowLimit;
  private Label lblUpLimit;
  private Label lblCoordX;
  private Label lblCoordY;
  private Label lblBackColor;
  private Label lblPboxMode;
  private Label lblGridThick;
  private Label label5;
  private Label label6;
  private Label lblAV;
  private Label lblISO;
  private Label lblTV;
  private Label lblSecCamera;
  private Label lblSecExposure;
  private Label lblSecCapture;
  private Label lblSecViewMode;
  private Label lblSecBgColor;
  private Label lblSecGrid;
  private Label lblCamStatus;
  private Label lblScaleInfo;
  private Label lblZoom;
  private Label lblStretchMethod;
  private CheckBox cboxExpAuto;
  private CheckBox cbGrid;
  private TabControl tabControlAllCams;
  private TabPage tabGenCam;
  private TabPage tabCanon;
  private TabPage tabWebcam;
  private RadioButton rbPan;
  private RadioButton rbBackround;
  private RadioButton rbStretch;
  private RadioButton rbArticle;
  private RadioButton rbNone;
  private RadioButton rbStretchNormal;
  private RadioButton rbStretchRegional;
  private MenuStrip menuStrip1;
  private ToolStripMenuItem menuDigitizeSettings;
  private ToolStripMenuItem menuEdgeSettings;
  private ToolStripMenuItem menuCalibSettings;
  private PictureBox pboxBackColor;
  private PictureBox pboxPreview1;
  private ListBox lbDrag;
  private ListBox lbArticle;
  private Panel pnlLeft;
  private Panel pnlRight;
  private Panel pnlTitleBar;
  private Panel pnlStatusBar;
  private Panel pnlCapture;
  private Panel pnlExposure;
  private Panel pnlViewMode;
  private Panel pnlBackground;
  private Panel pnlGridOverlay;
  private Panel pnlPreview;
  private Panel pnlLists;
  private Panel pnlCamControl;
  private Panel pnlPboxMode;
  private Panel pnlDigitize;
  private Panel pnlPicturebox;
  private Panel panel1;
  private Panel pnlLBorder;
  private Panel secCam;
  private Label hdrCam;
  private Panel divHdrCam;
  private Panel bodyCam;
  private Label lblConn;
  private Panel divBotCam;
  private Panel secExp;
  private Label hdrExp;
  private Panel divHdrExp;
  private Panel bodyExp;
  private Panel boxLow;
  private Panel boxHigh;
  private Panel boxManExp;
  private Panel boxGain;
  private Panel divBotExp;
  private Panel secCap;
  private Label hdrCap;
  private Panel divHdrCap;
  private Panel bodyCap;
  private Panel divBotCap;
  private Panel secView;
  private Label hdrView;
  private Panel divHdrView;
  private Panel bodyView;
  private Panel divBotView;
  private Panel secBg;
  private Label hdrBg;
  private Panel divHdrBg;
  private Panel bodyBg;
  private Panel divBotBg;
  private Panel secGrid;
  private Label hdrGrid;
  private Panel divHdrGrid;
  private Panel bodyGrid;
  private Panel divBotGrid;
  private Panel pnlRBorder;
  private Label lblRHdr;
  private Panel pnlRHdrDiv;
  private Panel pnlCoord;
  private Label lXl;
  private Label lXv;
  private Label lYl;
  private Label lYv;
  private Label lblDragHdr;
  private Label lblArticleHdr;
  private Panel pnlAccentLine;
  private Panel pnlBrand;
  private Label lblBrandMark;
  private Label lblBrandName;
  private Panel pnlBrandBorder;
  private Button btnMenuDig;
  private Button btnMenuEdge;
  private Button btnMenuCalib;
  private Panel pnlSTop;
  private Button btnTopView;
  private Button btnTopViewV2;
  private Button btnCalibrateV2;
  private ComboBox cboxCamAV;
  private ComboBox cboxCamISO;
  private ComboBox cboxCamTV;
  private Label lblCanonControls;
  private Button btnDistortion;
  private Button btnDistV2;
  private Button btnDistV3;

  public Form1()
  {
    Form1.CultureSettings();
    Application.EnableVisualStyles();
    this.DoubleBuffered = true;
    this.InitializeComponent();
    Form1.imgFile = this.CreateImgFile();
    Form1.pointsFile = this.CreatePointFile();
    Form1.calibFile = this.CreateCalibFile();
    Form1.settingsFile = this.CreateSettingsFile();
    this.menuSettings = Path.Combine(Form1.settingsFile, "menuSettings.txt");
    this.configFile = Path.Combine(Form1.settingsFile, "programSettings.txt");
    this.canonSettings = Path.Combine(Form1.settingsFile, "canonSettings.txt");
    this.gencamSettings = Path.Combine(Form1.settingsFile, "gencamSettings.txt");
    this.edgeSettings = Path.Combine(Form1.settingsFile, "edgeSettings.txt");
    this.offsetPath = Path.Combine(Form1.calibFile, "calculationOffset.txt");
    Form1.digitizSettingsForm = new DigitizeSettings(this.menuSettings, this.offsetPath, Application.CurrentCulture);
    Form1.edgeSettingsForm = new EdgeDetectSettings(this.edgeSettings);
    this.pboxEdit.MouseWheel += new MouseEventHandler(this.pboxEdit_MouseWheel);
    this.pboxEdit.MouseDoubleClick += new MouseEventHandler(this.pboxEdit_MouseDoubleClick);
    this.pboxEdit.MouseEnter += (EventHandler) ((s, e) => this.pboxEdit.Focus());
    this.KeyPreview = true;
  }

  protected virtual bool ProcessCmdKey(ref Message msg, Keys keyData)
  {
    if (keyData == (Keys.Z | Keys.Control))
    {
      this.Undo();
      return true;
    }
    if (keyData != (Keys.Y | Keys.Control))
      return base.ProcessCmdKey(ref msg, keyData);
    this.Redo();
    return true;
  }

  public static void CultureSettings()
  {
    try
    {
      int[] numArray = new int[3]{ 3, 2, 2 };
      CultureInfo cultureInfo = new CultureInfo("en-US");
      DateTimeFormatInfo dateTimeFormatInfo = new DateTimeFormatInfo();
      cultureInfo.NumberFormat = new NumberFormatInfo()
      {
        CurrencySymbol = "Rs",
        CurrencyDecimalDigits = 3,
        CurrencyDecimalSeparator = ".",
        CurrencyGroupSizes = numArray,
        CurrencyGroupSeparator = ",",
        PositiveInfinitySymbol = " "
      };
      Application.CurrentCulture = cultureInfo;
      Thread.CurrentThread.CurrentCulture = cultureInfo;
      Thread.CurrentThread.CurrentUICulture = cultureInfo;
    }
    catch (Exception ex)
    {
    }
  }

  private 
  #nullable enable
  string CreateImgFile()
  {
    string imgFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");
    if (!Directory.Exists(imgFile))
      Directory.CreateDirectory(imgFile);
    return imgFile;
  }

  private string CreatePointFile()
  {
    string pointFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Points");
    if (!Directory.Exists(pointFile))
      Directory.CreateDirectory(pointFile);
    return pointFile;
  }

  private string CreateCalibFile()
  {
    string calibFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Calibration");
    if (!Directory.Exists(calibFile))
      Directory.CreateDirectory(calibFile);
    return calibFile;
  }

  private string CreateSettingsFile()
  {
    string settingsFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Settings");
    if (!Directory.Exists(settingsFile))
      Directory.CreateDirectory(settingsFile);
    return settingsFile;
  }

  private bool OpenCanon()
  {
    bool flag = false;
    try
    {
      this._camera = new CanonCamera(Form1._sdk);
      if (this._camera.CameraDetected)
      {
        this.cboxCamTV.Items.Clear();
        this.cboxCamISO.Items.Clear();
        this.cboxCamAV.Items.Clear();
        this.PopulateComboBoxes();
        if (!File.Exists(Path.Combine(Form1.settingsFile, "canonSettings.txt")))
          throw new FileNotFoundException("Settings file not found.", Form1.settingsFile);
        flag = true;
      }
      else
      {
        int num = (int) MessageBox.Show("No camera detected");
        return false;
      }
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show(ex.Message);
    }
    if (flag)
      this.WriteSettings4CboxCanon(Path.Combine(Form1.settingsFile, "canonSettings.txt"));
    return flag;
  }

  private void PopulateComboBoxes()
  {
    this.cboxCamTV.Items.AddRange((object[]) this._camera.TvValues.Keys.ToArray<string>());
    this.cboxCamISO.Items.AddRange((object[]) this._camera.IsoValues.Keys.ToArray<string>());
    this.cboxCamAV.Items.AddRange((object[]) this._camera.AvValues.Keys.ToArray<string>());
  }

  private void WriteSettings4CboxCanon(string filePath)
  {
    if (!File.Exists(filePath))
    {
      int num1 = (int) MessageBox.Show("Settings file not found.", filePath);
    }
    else
    {
      try
      {
        Variables.ReadCanonSettings(filePath);
        if (this.cboxCamTV.Items.Contains((object) Variables.canonTv))
        {
          this.cboxCamTV.SelectedItem = (object) Variables.canonTv;
        }
        else
        {
          int num2 = (int) MessageBox.Show($"Shutter speed '{Variables.canonTv}' not found in ComboBox.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        if (this.cboxCamISO.Items.Contains((object) Variables.canonIso))
        {
          this.cboxCamISO.SelectedItem = (object) Variables.canonIso;
        }
        else
        {
          int num3 = (int) MessageBox.Show($"ISO '{Variables.canonIso}' not found in ComboBox.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        if (this.cboxCamAV.Items.Contains((object) Variables.canonAv))
        {
          this.cboxCamAV.SelectedItem = (object) Variables.canonAv;
        }
        else
        {
          int num4 = (int) MessageBox.Show($"Aperture '{Variables.canonAv}' not found in ComboBox.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
      }
      catch (Exception ex)
      {
        int num5 = (int) MessageBox.Show("Failed to load camera settings: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }
  }

  private void OpenCamera()
  {
    switch (Variables.camModel)
    {
      case "Gencam":
        Variables.ReadCanonSettings(Path.Combine(Form1.settingsFile, "gencamSettings.txt"));
        this.RefreshDeviceList();
        Control.CheckForIllegalCrossThreadCalls = false;
        this.OpenGenCam();
        break;
      case "Canon":
        Variables.ReadCanonSettings(Path.Combine(Form1.settingsFile, "canonSettings.txt"));
        SDKSystem.Initialize();
        break;
    }
  }

  public void WriteCanonSettings(
    string cameraSettings,
    string tv,
    string iso,
    string av,
    bool isQuick)
  {
    try
    {
      using (StreamWriter streamWriter = new StreamWriter(cameraSettings))
      {
        if (string.IsNullOrWhiteSpace(tv))
          throw new Exception("TV (Shutter speed) cannot be empty.");
        ((TextWriter) streamWriter).WriteLine("TV: " + tv);
        if (string.IsNullOrWhiteSpace(iso))
          throw new Exception("ISO cannot be empty.");
        ((TextWriter) streamWriter).WriteLine("ISO: " + iso);
        if (string.IsNullOrWhiteSpace(av))
          throw new Exception("AV (Aperture) cannot be empty.");
        ((TextWriter) streamWriter).WriteLine("AV: " + av);
      }
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show("Error writing to camera settings file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      throw;
    }
  }

  private void ShowErrorMsg(string message, int errorCode)
  {
    if (Variables.exeMode == "Quick")
      return;
    string text = errorCode != 0 ? $"{message}: Error ={$"{errorCode:X}"}" : message;
    switch (errorCode)
    {
      case int.MinValue:
        text += " Error or invalid handle ";
        break;
      case -2147483647 /*0x80000001*/:
        text += " Not supported function ";
        break;
      case -2147483646 /*0x80000002*/:
        text += " Cache is full ";
        break;
      case -2147483645 /*0x80000003*/:
        text += " Function calling order error ";
        break;
      case -2147483644 /*0x80000004*/:
        text += " Incorrect parameter ";
        break;
      case -2147483642 /*0x80000006*/:
        text += " Applying resource failed ";
        break;
      case -2147483641 /*0x80000007*/:
        text += " No data ";
        break;
      case -2147483640 /*0x80000008*/:
        text += " Precondition error, or running environment changed ";
        break;
      case -2147483639 /*0x80000009*/:
        text += " Version mismatches ";
        break;
      case -2147483638 /*0x8000000A*/:
        text += " Insufficient memory ";
        break;
      case -2147483393 /*0x800000FF*/:
        text += " Unknown error ";
        break;
      case -2147483392 /*0x80000100*/:
        text += " General error ";
        break;
      case -2147483386 /*0x80000106*/:
        text += " Node accessing condition error ";
        break;
      case -2147483133 /*0x80000203*/:
        text += " No permission ";
        break;
      case -2147483132 /*0x80000204*/:
        text += " Device is busy, or network disconnected ";
        break;
      case -2147483130 /*0x80000206*/:
        text += " Network error ";
        break;
    }
    if (!(Variables.exeMode != "Quick"))
      return;
    int num = (int) MessageBox.Show(text, "PROMPT");
  }

  public static async Task RestartAdapterAsync(string adapterName)
  {
    ProcessStartInfo disable = new ProcessStartInfo("powershell", $"-Command \"Get-NetAdapter -Name '{adapterName}' | Disable-NetAdapter -Confirm:$false\"")
    {
      CreateNoWindow = true,
      UseShellExecute = false
    };
    Process.Start(disable)?.WaitForExit();
    await Task.Delay(5000);
    ProcessStartInfo enable = new ProcessStartInfo("powershell", $"-Command \"Get-NetAdapter -Name '{adapterName}' | Enable-NetAdapter -Confirm:$false\"")
    {
      CreateNoWindow = true,
      UseShellExecute = false
    };
    Process process = Process.Start(enable);
    if (process == null)
    {
      disable = (ProcessStartInfo) null;
      enable = (ProcessStartInfo) null;
    }
    else
    {
      process.WaitForExit();
      disable = (ProcessStartInfo) null;
      enable = (ProcessStartInfo) null;
    }
  }

  private void RefreshDeviceList()
  {
    int errorCode = DeviceEnumerator.EnumDevices(this.enumTLayerType, out this.deviceInfoList);
    if (errorCode == 0)
      return;
    this.ShowErrorMsg("Enumerate devices fail!", errorCode);
  }

  private bool VideoMode()
  {
    if (this.device != null)
    {
      this.device.StreamGrabber.StopGrabbing();
      this.device.Parameters.SetEnumValueByString("AcquisitionMode", "Continuous");
      this.device.Parameters.SetEnumValueByString("TriggerMode", "Off");
      this.device.Parameters.SetBoolValue("AcquisitionFrameRateEnable", true);
      int errorCode1 = this.device.Parameters.SetFloatValue("AcquisitionFrameRate", 30f);
      if (errorCode1 != 0)
        this.ShowErrorMsg("Set Frame Rate Fail!", errorCode1);
      int errorCode2 = this.device.StreamGrabber.StartGrabbing();
      if (errorCode2 == 0)
        return true;
      this.ShowErrorMsg("Failed to restart grabber for video mode!", errorCode2);
      return false;
    }
    int num = (int) MessageBox.Show("Device not found, closing application!");
    return false;
  }

  public void LockCameraToStaticIP()
  {
    if (this.device == null)
    {
      int num1 = (int) MessageBox.Show("Please connect to the camera first!");
    }
    else
    {
      try
      {
        int errorCode1 = this.device.Parameters.SetBoolValue("GevCurrentIPConfigurationPersistentIP", true);
        if (errorCode1 != 0)
          this.ShowErrorMsg("Open Device fail after retry!", errorCode1);
        int errorCode2 = this.device.Parameters.SetBoolValue("GevCurrentIPConfigurationDHCP", false);
        if (errorCode2 != 0)
          this.ShowErrorMsg("Open Device fail after retry!", errorCode2);
        long num2 = (long) this.ConvertIPToUInt("172.16.39.20");
        long num3 = (long) this.ConvertIPToUInt("255.255.0.0");
        long num4 = (long) this.ConvertIPToUInt("172.16.39.201");
        int errorCode3 = this.device.Parameters.SetIntValue("GevPersistentIPAddress", num2);
        if (errorCode3 != 0)
          this.ShowErrorMsg("Open Device fail after retry!", errorCode3);
        int errorCode4 = this.device.Parameters.SetIntValue("GevPersistentSubnetMask", num3);
        if (errorCode4 != 0)
          this.ShowErrorMsg("Open Device fail after retry!", errorCode4);
        int errorCode5 = this.device.Parameters.SetIntValue("GevPersistentDefaultGateway", num4);
        if (errorCode5 != 0)
          this.ShowErrorMsg("Open Device fail after retry!", errorCode5);
        int num5 = (int) MessageBox.Show("Success! Camera hardware is permanently locked to 172.16.39.20.");
      }
      catch (Exception ex)
      {
        int num6 = (int) MessageBox.Show("Failed to set static IP: " + ex.Message);
      }
    }
  }

  private uint ConvertIPToUInt(string ipAddress)
  {
    string[] strArray = ipAddress.Split('.', StringSplitOptions.None);
    return strArray.Length != 4 ? 0U : (uint) (0 | (int) uint.Parse(strArray[0]) << 24) | uint.Parse(strArray[1]) << 16 /*0x10*/ | uint.Parse(strArray[2]) << 8 | uint.Parse(strArray[3]);
  }

  private async Task<bool> OpenGenCam()
  {
    if (this.deviceInfoList.Count == 0)
    {
      this.ShowErrorMsg("No device detected", 0);
      return false;
    }
    IDeviceInfo deviceInfo = this.deviceInfoList[0];
    try
    {
      this.device = DeviceFactory.CreateDevice(deviceInfo);
    }
    catch (Exception ex)
    {
      if (Variables.exeMode != "Quick")
      {
        int num = (int) MessageBox.Show("Create Device fail!" + ex.Message);
      }
      return false;
    }
    int result = this.device.Open();
    if (result == -2147483130 /*0x80000206*/ || result != 0)
    {
      this.device.Close();
      this.device.Dispose();
      await Task.Delay(1000);
      this.device = DeviceFactory.CreateDevice(deviceInfo);
      result = this.device.Open();
      if (result != 0)
      {
        this.ShowErrorMsg("Open Device fail after retry!", result);
        return false;
      }
    }
    if (result != 0)
    {
      this.ShowErrorMsg("Open Device fail!", result);
      return false;
    }
    if (this.device is IGigEDevice)
    {
      IGigEDevice gigEDevice = this.device as IGigEDevice;
      result = this.device.Parameters.SetIntValue("GevSCPSPacketSize", 1500L);
      if (result != 0)
      {
        this.ShowErrorMsg("Warning: Get Packet Size failed!", result);
        return false;
      }
      gigEDevice = (IGigEDevice) null;
    }
    this.GetCamParam();
    this.device.Parameters.SetEnumValueByString("TriggerMode", "On");
    this.device.Parameters.SetEnumValueByString("TriggerSource", "Software");
    this.StartGrabCam();
    return true;
  }

  private void StartGrabCam()
  {
    try
    {
      this.isGrabbing = true;
      this.receiveThread = new Thread((ThreadStart) (() => this.ReceiveThreadProcess(this.pboxEdit)));
      this.receiveThread.Start();
    }
    catch (Exception ex)
    {
      if (Variables.exeMode != "Quick")
      {
        int num = (int) MessageBox.Show("Start thread failed!, " + ex.Message);
      }
      throw;
    }
    int errorCode = this.device.StreamGrabber.StartGrabbing();
    if (errorCode == 0)
      return;
    this.isGrabbing = false;
    this.receiveThread.Join();
    this.ShowErrorMsg("Start Grabbing Fail!", errorCode);
  }

  private void StopGrabCam()
  {
    this.isGrabbing = false;
    this.receiveThread.Join();
    int errorCode = this.device.StreamGrabber.StopGrabbing();
    if (errorCode == 0)
      return;
    this.ShowErrorMsg("Stop Grabbing Fail!", errorCode);
  }

  private void CloseGenCam()
  {
    if (this.isGrabbing)
      this.StopGrabCam();
    if (this.device == null)
      return;
    this.device.Close();
  }

  public void ReceiveThreadProcess(PictureBox pbox)
  {
    while (this.isGrabbing)
    {
      if (this.device.StreamGrabber.GetImageBuffer(50U, out this.frameOutLocal) == 0)
      {
        try
        {
          if (Variables.exeMode == "Video")
          {
            if (pbox != null)
              this.device.ImageRender.DisplayOneFrame(pbox.Handle, this.frameOutLocal.Image);
          }
          else
          {
            lock (this.saveImageLock)
            {
              try
              {
                int errorCode = this.SaveImage(new ImageFormatInfo()
                {
                  FormatType = ImageFormatType.Bmp
                }, Path.Combine(Form1.imgFile, "Original.bmp"));
                if (errorCode != 0)
                {
                  this.ShowErrorMsg("Save Image Fail!", errorCode);
                  break;
                }
                this._genCamTaskCompletionSource?.TrySetResult(true);
              }
              catch (Exception ex)
              {
                if (!(Variables.exeMode != "Quick"))
                  break;
                int num = (int) MessageBox.Show("Save Image Failed, " + ex.Message);
                break;
              }
            }
          }
        }
        finally
        {
          this.device.StreamGrabber.FreeImageBuffer(this.frameOutLocal);
        }
      }
      else
        Thread.Sleep(5);
    }
  }

  private int SaveImage(ImageFormatInfo imageFormatInfo, string imagePath)
  {
    if (this.frameOutLocal == null)
      throw new Exception("No vaild image");
    lock (this.saveImageLock)
      return this.device.ImageSaver.SaveImageToFile(imagePath, this.frameOutLocal.Image, imageFormatInfo, CFAMethod.Equilibrated);
  }

  private void GetCamParam()
  {
    this.GetTriggerMode();
    IFloatValue floatValue;
    if (this.device.Parameters.GetFloatValue("ExposureTime", out floatValue) != 0)
      ;
    if (this.device.Parameters.GetFloatValue("Gain", out floatValue) != 0)
      ;
    if (this.device.Parameters.GetFloatValue("ResultingFrameRate", out floatValue) != 0)
      ;
    IEnumValue enumValue;
    if (this.device.Parameters.GetEnumValue("PixelFormat", out enumValue) != 0)
      return;
    foreach (IEnumEntry supportEnumEntry in enumValue.SupportEnumEntries)
      ;
  }

  private bool SetCamParamGencam()
  {
    if (this.device == null)
      return false;
    if (!this.cboxExpAuto.Checked)
    {
      if ((double) this._lastAppliedExp != (double) (float) Variables.gencamExpManual)
      {
        this.device.Parameters.SetEnumValue("ExposureAuto", 0U);
        int errorCode = this.device.Parameters.SetFloatValue("ExposureTime", (float) Variables.gencamExpManual);
        if (errorCode != 0)
        {
          this.ShowErrorMsg("Set Exposure Time Fail!", errorCode);
          return false;
        }
        this._lastAppliedExp = (float) Variables.gencamExpManual;
      }
    }
    else
    {
      this.device.Parameters.SetEnumValue("ExposureAuto", 2U);
      int errorCode1 = this.device.Parameters.SetIntValue("AutoExposureTimeLowerLimit", (long) Variables.gencamExpLowL);
      if (errorCode1 != 0)
      {
        this.ShowErrorMsg("Auto exposure lower limit failed!", errorCode1);
        return false;
      }
      int errorCode2 = this.device.Parameters.SetIntValue("AutoExposureTimeUpperLimit", (long) Variables.gencamExpUpL);
      if (errorCode2 != 0)
      {
        this.ShowErrorMsg("Auto exposure upper limit failed!", errorCode2);
        return false;
      }
    }
    this.device.Parameters.SetEnumValue("GainAuto", 0U);
    if ((double) this._lastAppliedGain != (double) (float) Variables.gencamGain)
    {
      int errorCode = this.device.Parameters.SetFloatValue("Gain", (float) Variables.gencamGain);
      if (errorCode != 0)
      {
        this.ShowErrorMsg("Set Gain Fail!", errorCode);
        return false;
      }
      this._lastAppliedGain = (float) Variables.gencamGain;
    }
    return true;
  }

  private bool SetCamParamCanon()
  {
    uint tvValue;
    if (this._camera.TvValues.TryGetValue(Variables.canonTv, out tvValue))
    {
      this._camera.SetTv(tvValue);
      uint isoValue;
      if (this._camera.IsoValues.TryGetValue(Variables.canonIso, out isoValue))
      {
        this._camera.SetIso(isoValue);
        uint avValue;
        if (this._camera.AvValues.TryGetValue(Variables.canonAv, out avValue))
        {
          this._camera.SetAv(avValue);
          return true;
        }
        int num = (int) MessageBox.Show("Invalid AV value");
        return false;
      }
      int num1 = (int) MessageBox.Show("Invalid ISO value");
      return false;
    }
    int num2 = (int) MessageBox.Show("Failed to set TV (shutter speed)");
    return false;
  }

  private void GetTriggerMode()
  {
    IEnumValue enumValue;
    if (this.device.Parameters.GetEnumValue("TriggerMode", out enumValue) != 0 || !(enumValue.CurEnumEntry.Symbolic == "On") || this.device.Parameters.GetEnumValue("TriggerSource", out enumValue) != 0 || !(enumValue.CurEnumEntry.Symbolic == "TriggerSoftware"))
      ;
  }

  private void pboxEdit_MouseWheel(object sender, MouseEventArgs e)
  {
    if (this.pboxEdit.Image == null)
      return;
    PointF image = this.ControlToImage(e.Location);
    float num = 1.1f;
    if (e.Delta > 0)
      this.currentZoom *= num;
    else
      this.currentZoom /= num;
    this.currentZoom = Math.Max(1f, Math.Min(this.currentZoom, 20f));
    if ((double) this.currentZoom == 1.0)
    {
      this.panOffset = new PointF(0.0f, 0.0f);
    }
    else
    {
      Point control = this.ImageToControl(image);
      this.panOffset.X += (float) (e.Location.X - control.X);
      this.panOffset.Y += (float) (e.Location.Y - control.Y);
    }
    this.pboxEdit.Invalidate();
    GC.Collect();
  }

  private async void btnTakePhoto_Click(object sender, EventArgs e)
  {
    this.btnTakePhoto.Enabled = false;
    await Task.Yield();
    Variables.ReadMenuSettings(this.menuSettings);
    await this.TakePhotoReadSettings();
    Variables.WriteCameraSettings(Form1.settingsFile);
    GC.Collect();
    this.btnTakePhoto.Enabled = true;
  }

  private void UpdateVariables()
  {
    switch (Variables.camModel)
    {
      case "Gencam":
        Variables.gencamExpManual = this.numUDGCManExp.Value;
        Variables.gencamExpAuto = this.cboxExpAuto.Checked;
        Variables.gencamExpLowL = this.numUDExpAutoLow.Value;
        Variables.gencamExpUpL = this.numUDExpAutoUp.Value;
        Variables.gencamGain = this.numUDGain.Value;
        break;
      case "Canon":
        Variables.canonTv = this.cboxCamTV.SelectedItem.ToString();
        Variables.canonIso = this.cboxCamISO.SelectedItem.ToString();
        Variables.canonAv = this.cboxCamAV.SelectedItem.ToString();
        break;
    }
  }

  private void UpdateFormSettings()
  {
    switch (Variables.camModel)
    {
      case "Gencam":
        this.numUDGCManExp.Value = Variables.gencamExpManual;
        this.cboxExpAuto.Checked = Variables.gencamExpAuto;
        this.numUDExpAutoLow.Value = Variables.gencamExpLowL;
        this.numUDExpAutoUp.Value = Variables.gencamExpUpL;
        this.numUDGain.Value = Variables.gencamGain;
        break;
      case "Canon":
        if (this.cboxCamTV.Items.Contains((object) Variables.canonTv))
        {
          this.cboxCamTV.SelectedItem = (object) Variables.canonTv;
        }
        else
        {
          int num1 = (int) MessageBox.Show($"Shutter speed '{Variables.canonTv}' not found in ComboBox.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        if (this.cboxCamISO.Items.Contains((object) Variables.canonIso))
        {
          this.cboxCamISO.SelectedItem = (object) Variables.canonIso;
        }
        else
        {
          int num2 = (int) MessageBox.Show($"ISO '{Variables.canonIso}' not found in ComboBox.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        if (this.cboxCamAV.Items.Contains((object) Variables.canonAv))
        {
          this.cboxCamAV.SelectedItem = (object) Variables.canonAv;
          break;
        }
        int num3 = (int) MessageBox.Show($"Aperture '{Variables.canonAv}' not found in ComboBox.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        break;
    }
  }

  private void SaveToHistory()
  {
    if (this.pboxEdit.Image == null)
      return;
    try
    {
      string str1 = Path.Combine(Form1.imgFile, "History");
      if (!Directory.Exists(str1))
        Directory.CreateDirectory(str1);
      string str2 = $"img_{DateTime.Now.ToString("dd_HH_mm_ss")}.bmp";
      this.pboxEdit.Image.Save(Path.Combine(str1, str2), ImageFormat.Bmp);
      FileInfo[] array = ((IEnumerable<FileInfo>) new DirectoryInfo(str1).GetFiles("img_*.bmp")).OrderBy<FileInfo, DateTime>((Func<FileInfo, DateTime>) (f => ((FileSystemInfo) f).CreationTime)).ToArray<FileInfo>();
      if (array.Length <= 50)
        return;
      int num = array.Length - 50;
      for (int index = 0; index < num; ++index)
        ((FileSystemInfo) array[index]).Delete();
    }
    catch (Exception ex)
    {
      Debug.WriteLine("Failed to save to history: " + ex.Message);
    }
  }

  private void GenCamTakePhoto()
  {
    int errorCode = this.device.Parameters.SetCommandValue("TriggerSoftware");
    if (errorCode == 0)
      return;
    this.ShowErrorMsg("Trigger Software Fail!", errorCode);
  }

  private async Task<bool> GenCamTakePhotoAsync(int delay)
  {
    this._genCamTaskCompletionSource = new TaskCompletionSource<bool>();
    int result = this.device.Parameters.SetCommandValue("TriggerSoftware");
    if (result != 0)
    {
      this.ShowErrorMsg("Trigger Software Fail!", result);
      return false;
    }
    Task delayTask = Task.Delay(delay);
    Task completedTask = await Task.WhenAny((Task) this._genCamTaskCompletionSource.Task, delayTask);
    if (completedTask == delayTask)
    {
      if (Variables.exeMode != "Quick")
      {
        int num = (int) MessageBox.Show("Camera timeout: GenCam did not capture and save the image fast enough.");
      }
      return false;
    }
    bool task = await this._genCamTaskCompletionSource.Task;
    return task;
  }

  private async Task<bool> CanonTakePhoto(int delay)
  {
    string photoPath = Form1.imgFile + "\\Original.bmp";
    try
    {
      bool photoFastAsyncV2 = await this._camera.TakeAndSavePhotoFastAsyncV2(photoPath, delay);
      return photoFastAsyncV2;
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show(ex.Message);
      return false;
    }
  }

  private async Task TakePhotoOnceAsync()
  {
    int delayTime = (int) Variables.DelayTime;
    string str = Variables.camModel;
    switch (str)
    {
      case "Gencam":
        int num1 = await this.GenCamTakePhotoAsync(delayTime) ? 1 : 0;
        break;
      case "Canon":
        int num2 = await this.CanonTakePhoto(delayTime) ? 1 : 0;
        break;
    }
    str = (string) null;
  }

  private async void Form1_Load(object sender, EventArgs e)
  {
    this.Visible = false;
    this.ShowInTaskbar = false;
    Variables.ReadExeSettings(Path.Combine(Form1.settingsFile, "exeSettings.txt"));
    Variables.ReadMenuSettings(Path.Combine(Form1.settingsFile, "menuSettings.txt"));
    Variables.ReadCalibOffsetStone(Path.Combine(Form1.calibFile, "calculationOffset.txt"), Application.CurrentCulture);
    Variables.ReadCameraSettings(Form1.settingsFile);
    string str = Variables.camModel;
    switch (str)
    {
      case "Gencam":
        this.RefreshDeviceList();
        Control.CheckForIllegalCrossThreadCalls = false;
        this.OpenGenCam();
        this.btnTabGencam_Click((object) null, (EventArgs) null);
        break;
      case "Canon":
        SDKSystem.Initialize();
        this.OpenCanon();
        this.btnTabCanon_Click((object) null, (EventArgs) null);
        break;
    }
    str = (string) null;
    this.UpdateFormSettings();
    switch (Variables.exeMode)
    {
      case "Reset":
        Form statusDialog = this.CreateCountdownDialog("Network Adapter Reset", "Initializing hardware cycle...", 60);
        statusDialog.Show();
        Application.DoEvents();
        CancellationTokenSource cts = new CancellationTokenSource();
        Task countdownTask = this.StartDialogCountdownAsync(statusDialog, 60, cts.Token);
        bool isSuccesfull = await this.HardReset();
        cts.Cancel();
        statusDialog.Close();
        statusDialog.Dispose();
        if (isSuccesfull)
        {
          int num = (int) MessageBox.Show("Hardware reset completed successfully! Initializing baseline data capture.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          await this.TakePhotoReadSettings();
          Application.Exit();
          break;
        }
        int num1 = (int) MessageBox.Show("Reset failed. Please verify physical Ethernet link state, adapter naming mappings, and camera power configurations.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        Application.Exit();
        break;
      case "Quick":
        await this.TakePhotoReadSettings();
        Application.Exit();
        break;
      case "Video":
        this.isGrabbing = false;
        this.receiveThread?.Join();
        if (this.VideoMode())
        {
          this.isGrabbing = true;
          Instances.videoForm.Setup(this.device, Form1.settingsFile);
          this.receiveThread = new Thread((ThreadStart) (() => this.ReceiveThreadProcess(Instances.videoForm.pboxVideo)));
          this.receiveThread.Start();
          int num2 = (int) Instances.videoForm.ShowDialog();
          this.isGrabbing = false;
          this.receiveThread?.Join();
        }
        Application.Exit();
        break;
      case "Calibrate":
        Image<Bgr, byte> photoDistRemove = await this.TakePhotoDistRemove();
        try
        {
          this.btnCalibDual_Click((object) null, (EventArgs) null);
        }
        catch (Exception ex)
        {
          int num3 = (int) MessageBox.Show("Error during calibration: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
          Application.Exit();
          break;
        }
        Application.Exit();
        break;
      default:
        this.backColor = this.LoadBackroundColors(Form1.calibFile);
        this.PboxLoadBackColor(this.pboxBackColor, this.backColor);
        this.Visible = true;
        this.ShowInTaskbar = true;
        break;
    }
  }

  private Form CreateCountdownDialog(string title, string initialMessage, int seconds)
  {
    Form form = new Form();
    form.Text = title;
    form.Size = new Size(400, 150);
    form.FormBorderStyle = FormBorderStyle.FixedDialog;
    form.StartPosition = FormStartPosition.CenterScreen;
    form.MaximizeBox = false;
    form.MinimizeBox = false;
    form.ControlBox = false;
    form.TopMost = true;
    Form countdownDialog = form;
    Label label1 = new Label();
    label1.Text = $"{initialMessage}\r\nTime Remaining: {seconds} seconds";
    label1.Dock = DockStyle.Fill;
    label1.TextAlign = ContentAlignment.MiddleCenter;
    label1.Font = new Font("Segoe UI", 10f, FontStyle.Regular);
    label1.Name = "lblCountdownMessage";
    Label label2 = label1;
    countdownDialog.Controls.Add((Control) label2);
    return countdownDialog;
  }

  private async Task StartDialogCountdownAsync(
    Form dialog,
    int totalSeconds,
    CancellationToken token)
  {
    Label lbl = dialog.Controls["lblCountdownMessage"] as Label;
    int remaining = totalSeconds;
    try
    {
      while (remaining > 0 && !token.IsCancellationRequested)
      {
        await Task.Delay(1000, token);
        --remaining;
        if (dialog.Visible && lbl != null && !dialog.IsDisposed)
          dialog.Invoke((Action) (() => lbl.Text = $"Flushing network adapters and waiting for device socket registration...\r\nTime Remaining: {remaining} seconds"));
      }
      if (remaining > 0 || token.IsCancellationRequested)
        ;
      else
        dialog.Invoke((Action) (() => dialog.Close()));
    }
    catch (TaskCanceledException ex)
    {
    }
  }

  private void PboxLoadBackColor(PictureBox pbox, Bgr color)
  {
    pbox.BackColor = Color.FromArgb((int) color.Red, (int) color.Green, (int) color.Blue);
  }

  private void ApplySettings4Cam()
  {
    this.numUDGCManExp.Value = Variables.gencamExpManual;
    this.numUDGain.Value = Variables.gencamGain;
  }

  private void TriggerCam()
  {
    int errorCode = this.device.Parameters.SetCommandValue("TriggerSoftware");
    if (errorCode == 0)
      return;
    this.ShowErrorMsg("Trigger Software Fail!", errorCode);
  }

  private async Task TakePhotoReadSettings()
  {
    this.UpdateVariables();
    this.ApplyCamSettings();
    await this.TakePhotoOnceAsync();
    Form1.loadedImage = new Image<Bgr, byte>(Path.Combine(Form1.imgFile, "Original.bmp"));
    Form1.dynamicImg = new Image<Bgr, byte>(Path.Combine(Form1.imgFile, "Original.bmp"));
    if (Variables.RotationFirst)
    {
      if (Variables.AutoRotation && Variables.RotationValue != 0M)
        this.DigitizeFunctions.RotateImage((double) Variables.RotationValue / 100.0, ref Form1.dynamicImg);
      if (Variables.AutoCorrectLens && Variables.DistStrK1 != 0M)
      {
        string str = Variables.camModel;
        switch (str)
        {
          case "Canon":
            Form1.dynamicImg = this.DigitizeFunctions.UndistortCanon(Form1.dynamicImg, (double) Variables.DistStrK1, (double) Variables.DistStrK2, (double) Variables.DistX, (double) Variables.DistY);
            break;
          case "Gencam":
            Form1.dynamicImg = this.DigitizeFunctions.UndistortHikrobot12MP(Form1.dynamicImg, (double) Variables.DistStrK1, (double) Variables.DistStrK2, (double) Variables.DistX, (double) Variables.DistY);
            break;
        }
        str = (string) null;
      }
    }
    else
    {
      if (Variables.AutoCorrectLens && Variables.DistStrK1 != 0M)
      {
        string str = Variables.camModel;
        switch (str)
        {
          case "Canon":
            Form1.dynamicImg = this.DigitizeFunctions.UndistortCanon(Form1.dynamicImg, (double) Variables.DistStrK1, (double) Variables.DistStrK2, (double) Variables.DistX, (double) Variables.DistY);
            break;
          case "Gencam":
            Form1.dynamicImg = this.DigitizeFunctions.UndistortHikrobot12MP(Form1.dynamicImg, (double) Variables.DistStrK1, (double) Variables.DistStrK2, (double) Variables.DistX, (double) Variables.DistY);
            break;
        }
        str = (string) null;
      }
      if (Variables.AutoRotation && Variables.RotationValue != 0M)
        this.DigitizeFunctions.RotateImage((double) Variables.RotationValue / 100.0, ref Form1.dynamicImg);
    }
    if (Variables.AutoTopView)
    {
      Image<Bgr, byte> imgInput = Form1.dynamicImg.Clone();
      Mat matAruco = new Mat();
      int width = 0;
      int height = 0;
      string camTransform = "arucoTransform";
      string str = Variables.camModel;
      switch (str)
      {
        case "Canon":
          camTransform = "canonTransform";
          break;
        case "Gencam":
          camTransform = "gencamTransform";
          break;
      }
      str = (string) null;
      switch (Variables.StretchType)
      {
        case "Normal":
          (this.transformMatrix, width, height) = this.SaveFunctions.ReadMatrixAndDimensions(Path.Combine(Form1.calibFile, camTransform + "Normal.txt"));
          break;
        case "Outer":
          (this.transformMatrix, width, height) = this.SaveFunctions.ReadMatrixAndDimensions(Path.Combine(Form1.calibFile, camTransform + "Outer.txt"));
          break;
        case "Inner":
          (this.transformMatrix, width, height) = this.SaveFunctions.ReadMatrixAndDimensions(Path.Combine(Form1.calibFile, camTransform + "Inner.txt"));
          break;
      }
      CvInvoke.WarpPerspective((IInputArray) imgInput.Mat, (IOutputArray) matAruco, (IInputArray) this.transformMatrix, new Size(width, height), Inter.Lanczos4);
      Image<Bgr, byte> imgAruco = matAruco.ToImage<Bgr, byte>();
      Form1.dynamicImg = imgAruco.Clone();
      if (Variables.AutoCalcOffset)
        this.btnDistV2_Click((object) null, (EventArgs) null);
      imgInput = (Image<Bgr, byte>) null;
      matAruco = (Mat) null;
      camTransform = (string) null;
      imgAruco = (Image<Bgr, byte>) null;
    }
    Form1.workImg = Form1.dynamicImg.Clone();
    Variables.articlePoints.Clear();
    Variables.dragPoints = new PointF[16 /*0x10*/];
    float w = (float) Form1.workImg.Width;
    float h = (float) Form1.workImg.Height;
    for (int r = 0; r < 4; ++r)
    {
      for (int c = 0; c < 4; ++c)
        Variables.dragPoints[r * 4 + c] = new PointF((float) c * (w / 3f), (float) r * (h / 3f));
    }
    this.renderingOffset = new PointF(0.0f, 0.0f);
    if (Variables.AutoStretch)
    {
      string autoPath = Path.Combine(Form1.pointsFile, "Stretch\\stretchAuto.txt");
      if (File.Exists(autoPath))
      {
        PointF[] dragPointsTemp = Variables.dragPoints;
        this.SaveFunctions.LoadDragPoints(autoPath, ref dragPointsTemp);
        Variables.dragPoints = dragPointsTemp;
        dragPointsTemp = (PointF[]) null;
      }
      autoPath = (string) null;
    }
    if (Variables.AutoRotateLeft)
      this.RotateLeft(ref Form1.dynamicImg);
    if (Variables.AutoRotateRight)
      this.RotateRight(ref Form1.dynamicImg);
    if (Variables.AutoMirrorHorizontal)
      this.MirrorHorizontal(ref Form1.dynamicImg);
    if (Variables.AutoMirrorVertical)
      this.MirrorVertical(ref Form1.dynamicImg);
    Form1.workImg = Form1.dynamicImg.Clone();
    if (Variables.AutoStretch)
      this.LoadDragAuto();
    if (Variables.AutoContour)
      this.btnFindContour_Click((object) null, (EventArgs) null);
    if (Variables.addOffset)
      this.AddPadding();
    Form1.workImg = Form1.dynamicImg.Clone();
    Form1.dynamicImg.Save(Form1.imgFile + "\\Converter.bmp");
    this.pboxEdit.Image = (Image) Form1.dynamicImg.ToBitmap<Bgr, byte>();
    this.RefreshListBoxes();
    this.pboxEdit.Invalidate();
    this.SaveToHistory();
    GC.Collect();
  }

  private async Task<Image<Bgr, byte>> TakePhotoDistRemove()
  {
    this.ApplyCamSettings();
    await this.TakePhotoOnceAsync();
    Form1.loadedImage = new Image<Bgr, byte>(Path.Combine(Form1.imgFile, "Original.png"));
    Form1.dynamicImg = new Image<Bgr, byte>(Path.Combine(Form1.imgFile, "Original.png"));
    string str = Variables.camModel;
    switch (str)
    {
      case "Canon":
        Form1.dynamicImg = this.DigitizeFunctions.UndistortCanon(Form1.dynamicImg, (double) Variables.DistStrK1, (double) Variables.DistStrK2, (double) Variables.DistX, (double) Variables.DistY);
        break;
      case "Gencam":
        Form1.dynamicImg = this.DigitizeFunctions.UndistortHikrobot12MP(Form1.dynamicImg, (double) Variables.DistStrK1, (double) Variables.DistStrK2, (double) Variables.DistX, (double) Variables.DistY);
        break;
    }
    str = (string) null;
    this.pboxEdit.Image = (Image) Form1.dynamicImg.ToBitmap<Bgr, byte>();
    Form1.dynamicImg.Save(Form1.imgFile + "\\Converter.png");
    Form1.loadedImage = Form1.dynamicImg.Clone();
    Form1.workImg = Form1.dynamicImg.Clone();
    GC.Collect();
    return Form1.dynamicImg;
  }

  private void RotateLeft(ref Image<Bgr, byte> img)
  {
    float width = (float) img.Width;
    float height = (float) img.Height;
    Bitmap bitmap = img.ToBitmap<Bgr, byte>();
    bitmap.RotateFlip(RotateFlipType.Rotate270FlipNone);
    Form1.turnDeg = (Form1.turnDeg + 270) % 360;
    img = bitmap.ToImage<Bgr, byte>();
    if (Variables.dragPoints != null && Variables.dragPoints.Length == 16 /*0x10*/)
    {
      PointF[] pointFArray = new PointF[16 /*0x10*/];
      for (int index1 = 0; index1 < 4; ++index1)
      {
        for (int index2 = 0; index2 < 4; ++index2)
        {
          int index3 = index2 * 4 + (3 - index1);
          float x = Variables.dragPoints[index3].X;
          float y = Variables.dragPoints[index3].Y;
          pointFArray[index1 * 4 + index2] = new PointF(y, width - x);
        }
      }
      Variables.dragPoints = pointFArray;
    }
    if (Variables.articlePoints == null)
      return;
    for (int index4 = 0; index4 < Variables.articlePoints.Count; ++index4)
    {
      List<PointF> articlePoints = Variables.articlePoints;
      int index5 = index4;
      PointF articlePoint = Variables.articlePoints[index4];
      double y1 = (double) articlePoint.Y;
      double num = (double) width;
      articlePoint = Variables.articlePoints[index4];
      double x = (double) articlePoint.X;
      double y2 = num - x;
      PointF pointF = new PointF((float) y1, (float) y2);
      articlePoints[index5] = pointF;
    }
  }

  private void RotateRight(ref Image<Bgr, byte> img)
  {
    float width = (float) img.Width;
    float height = (float) img.Height;
    Bitmap bitmap = img.ToBitmap<Bgr, byte>();
    bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
    Form1.turnDeg = (Form1.turnDeg + 90) % 360;
    img = bitmap.ToImage<Bgr, byte>();
    if (Variables.dragPoints != null && Variables.dragPoints.Length == 16 /*0x10*/)
    {
      PointF[] pointFArray = new PointF[16 /*0x10*/];
      for (int index1 = 0; index1 < 4; ++index1)
      {
        for (int index2 = 0; index2 < 4; ++index2)
        {
          int index3 = (3 - index2) * 4 + index1;
          float x = Variables.dragPoints[index3].X;
          float y = Variables.dragPoints[index3].Y;
          pointFArray[index1 * 4 + index2] = new PointF(height - y, x);
        }
      }
      Variables.dragPoints = pointFArray;
    }
    if (Variables.articlePoints == null)
      return;
    for (int index = 0; index < Variables.articlePoints.Count; ++index)
      Variables.articlePoints[index] = new PointF(height - Variables.articlePoints[index].Y, Variables.articlePoints[index].X);
  }

  private void MirrorHorizontal(ref Image<Bgr, byte> img)
  {
    float width = (float) img.Width;
    img = this.ResizeFunctions.FlipImage(img, "Horizontal");
    Form1.flipH = !Form1.flipH;
    if (Variables.dragPoints != null && Variables.dragPoints.Length == 16 /*0x10*/)
    {
      PointF[] pointFArray = new PointF[16 /*0x10*/];
      for (int index1 = 0; index1 < 4; ++index1)
      {
        for (int index2 = 0; index2 < 4; ++index2)
        {
          int index3 = index1 * 4 + (3 - index2);
          float x = Variables.dragPoints[index3].X;
          float y = Variables.dragPoints[index3].Y;
          pointFArray[index1 * 4 + index2] = new PointF(width - x, y);
        }
      }
      Variables.dragPoints = pointFArray;
    }
    if (Variables.articlePoints == null)
      return;
    for (int index = 0; index < Variables.articlePoints.Count; ++index)
      Variables.articlePoints[index] = new PointF(width - Variables.articlePoints[index].X, Variables.articlePoints[index].Y);
  }

  private void MirrorVertical(ref Image<Bgr, byte> img)
  {
    float height = (float) img.Height;
    img = this.ResizeFunctions.FlipImage(img, "Vertical");
    Form1.flipV = !Form1.flipV;
    if (Variables.dragPoints != null && Variables.dragPoints.Length == 16 /*0x10*/)
    {
      PointF[] pointFArray = new PointF[16 /*0x10*/];
      for (int index1 = 0; index1 < 4; ++index1)
      {
        for (int index2 = 0; index2 < 4; ++index2)
        {
          int index3 = (3 - index1) * 4 + index2;
          float x = Variables.dragPoints[index3].X;
          float y = Variables.dragPoints[index3].Y;
          pointFArray[index1 * 4 + index2] = new PointF(x, height - y);
        }
      }
      Variables.dragPoints = pointFArray;
    }
    if (Variables.articlePoints == null)
      return;
    for (int index4 = 0; index4 < Variables.articlePoints.Count; ++index4)
    {
      List<PointF> articlePoints = Variables.articlePoints;
      int index5 = index4;
      PointF articlePoint = Variables.articlePoints[index4];
      double x = (double) articlePoint.X;
      double num = (double) height;
      articlePoint = Variables.articlePoints[index4];
      double y1 = (double) articlePoint.Y;
      double y2 = num - y1;
      PointF pointF = new PointF((float) x, (float) y2);
      articlePoints[index5] = pointF;
    }
  }

  private void btnCalibAruco_Click(object sender, EventArgs e)
  {
    Image<Bgr, byte> image1 = new Image<Bgr, byte>(Form1.dynamicImg.Width, Form1.dynamicImg.Height);
    Size size1 = new Size(image1.Width, image1.Height);
    Mat mat1 = new Mat();
    (Image<Bgr, byte> image2, double num1, double num2, Mat mat2, Size size2) = this.DigitizeFunctions.StretchFromArucoV4(Form1.dynamicImg, (int) Variables.TopViewWidth, (int) Variables.TopViewHeight, (double) Variables.MarkerSize);
    if (mat2 == null)
      return;
    this.transformMatrix = mat2;
    this.pix2mmX = num1;
    this.pix2mmY = num2;
    Form1.dynamicImg.Save(Form1.imgFile + "\\BaseIMGForCalib.bmp");
    this.SaveFunctions.WriteMatrixAndDimensions(this.transformMatrix, size2.Width, size2.Height, Path.Combine(Form1.calibFile, "arucoTransformNormal.txt"));
    (image2, this.pix2mmX, this.pix2mmY, this.transformMatrix, size2) = this.DigitizeFunctions.StretchFromArucoV3(Form1.dynamicImg, (int) Variables.TopViewWidth, (int) Variables.TopViewHeight, (double) Variables.MarkerSize, "OUTER");
    this.SaveFunctions.WriteMatrixAndDimensions(this.transformMatrix, size2.Width, size2.Height, Path.Combine(Form1.calibFile, "arucoTransformOuter.txt"));
    Image<Bgr, byte> image3;
    (image3, this.pix2mmX, this.pix2mmY, this.transformMatrix, size2) = this.DigitizeFunctions.StretchFromArucoV3(Form1.dynamicImg, (int) Variables.TopViewWidth, (int) Variables.TopViewHeight, (double) Variables.MarkerSize, "INNER");
    this.SaveFunctions.WriteMatrixAndDimensions(this.transformMatrix, size2.Width, size2.Height, Path.Combine(Form1.calibFile, "arucoTransformInner.txt"));
    Form1.dynamicImg = image3.Clone();
    this.pboxEdit.Image = (Image) image3.ToBitmap<Bgr, byte>();
    GC.Collect();
  }

  public void InitializeImagePoints()
  {
    if (Form1.workImg == null)
      return;
    this.renderingOffset = new PointF(0.0f, 0.0f);
    Variables.dragPoints = new PointF[16 /*0x10*/];
    float width = (float) Form1.workImg.Width;
    float height = (float) Form1.workImg.Height;
    for (int index1 = 0; index1 < 4; ++index1)
    {
      for (int index2 = 0; index2 < 4; ++index2)
        Variables.dragPoints[index1 * 4 + index2] = new PointF((float) index2 * (width / 3f), (float) index1 * (height / 3f));
    }
    Bitmap image = this.pboxEdit.Image as Bitmap;
    this.pboxEdit.Image = (Image) Form1.workImg.ToBitmap<Bgr, byte>();
    image?.Dispose();
  }

  private void ApplyWarp()
  {
    if (this.rbStretchRegional.Checked)
      this.ApplyMeshWarp();
    else
      this.ApplyNormalWarp();
  }

  private void ApplyNormalWarp()
  {
    if (Form1.workImg == null || Variables.dragPoints == null || Variables.dragPoints.Length < 16 /*0x10*/)
      return;
    PointF dragPoint1 = Variables.dragPoints[0];
    PointF dragPoint2 = Variables.dragPoints[3];
    PointF dragPoint3 = Variables.dragPoints[15];
    PointF dragPoint4 = Variables.dragPoints[12];
    for (int index1 = 0; index1 <= 3; ++index1)
    {
      for (int index2 = 0; index2 <= 3; ++index2)
      {
        if ((index1 != 0 || index2 != 0) && (index1 != 0 || index2 != 3) && (index1 != 3 || index2 != 3) && (index1 != 3 || index2 != 0))
          Variables.dragPoints[index1 * 4 + index2] = this.ResizeFunctions.BiLerp(dragPoint1, dragPoint2, dragPoint4, dragPoint3, (float) index2 / 3f, (float) index1 / 3f);
      }
    }
    PointF[] source = new PointF[4]
    {
      dragPoint1,
      dragPoint2,
      dragPoint3,
      dragPoint4
    };
    float x = ((IEnumerable<PointF>) source).Min<PointF>((Func<PointF, float>) (p => p.X));
    float y = ((IEnumerable<PointF>) source).Min<PointF>((Func<PointF, float>) (p => p.Y));
    float num1 = ((IEnumerable<PointF>) source).Max<PointF>((Func<PointF, float>) (p => p.X));
    float num2 = ((IEnumerable<PointF>) source).Max<PointF>((Func<PointF, float>) (p => p.Y));
    int width = (int) ((double) num1 - (double) x);
    int height = (int) ((double) num2 - (double) y);
    if (width <= 0 || height <= 0)
      return;
    this.renderingOffset = new PointF(x, y);
    PointF[] dest = new PointF[4]
    {
      new PointF(dragPoint1.X - x, dragPoint1.Y - y),
      new PointF(dragPoint2.X - x, dragPoint2.Y - y),
      new PointF(dragPoint3.X - x, dragPoint3.Y - y),
      new PointF(dragPoint4.X - x, dragPoint4.Y - y)
    };
    using (Mat perspectiveTransform = CvInvoke.GetPerspectiveTransform(new PointF[4]
    {
      new PointF(0.0f, 0.0f),
      new PointF((float) Form1.workImg.Width, 0.0f),
      new PointF((float) Form1.workImg.Width, (float) Form1.workImg.Height),
      new PointF(0.0f, (float) Form1.workImg.Height)
    }, dest))
    {
      if (Form1.dynamicImg != null)
        Form1.dynamicImg.Dispose();
      Form1.dynamicImg = new Image<Bgr, byte>(new Size(width, height));
      Form1.dynamicImg.SetValue(new Bgr(0.0, 0.0, 0.0));
      CvInvoke.WarpPerspective((IInputArray) Form1.workImg, (IOutputArray) Form1.dynamicImg, (IInputArray) perspectiveTransform, Form1.dynamicImg.Size);
    }
    Bitmap image = this.pboxEdit.Image as Bitmap;
    this.pboxEdit.Image = (Image) Form1.dynamicImg.ToBitmap<Bgr, byte>();
    image?.Dispose();
  }

  private void btnLoad_Click(object sender, EventArgs e)
  {
    try
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.JPEG;*.PNG)|*.bmp;*.jpg;*.jpeg;*.png|All files (*.*)|*.*";
      openFileDialog.Title = "Select Source Image Asset";
      if (DialogResult.OK != openFileDialog.ShowDialog())
        return;
      Form1.loadedImage = new Image<Bgr, byte>(openFileDialog.FileName);
      Form1.dynamicImg = new Image<Bgr, byte>(openFileDialog.FileName);
      Form1.workImg = new Image<Bgr, byte>(openFileDialog.FileName);
      this.InitializeImagePoints();
      Variables.articlePoints.Clear();
      this.RefreshListBoxes();
      this.pboxEdit.Image = (Image) Form1.loadedImage.ToBitmap<Bgr, byte>();
      Form1.workImg = Form1.loadedImage.Clone();
      GC.Collect();
    }
    catch (Exception ex)
    {
      Console.WriteLine("Error: " + ex.Message);
    }
  }

  private void btnSave_Click(object sender, EventArgs e)
  {
    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
    {
      saveFileDialog.Filter = "Jpeg Image|*.jpg|Png Image|*.png";
      saveFileDialog.Title = "Export Processed Image";
      bool includeMarkers = false;
      if (saveFileDialog.ShowDialog() != DialogResult.OK)
        return;
      if (Variables.articlePoints.Count > 0)
        includeMarkers = MessageBox.Show("Include red article markers in the saved image?", "Export Options", MessageBoxButtons.YesNo) == DialogResult.Yes;
      this.ExportImage(saveFileDialog.FileName, includeMarkers);
      int num = (int) MessageBox.Show("Image saved successfully!");
    }
  }

  private void Form1_FormClosing(object sender, FormClosingEventArgs e)
  {
    this.CloseGenCam();
    if (this.device != null)
    {
      this.device.Close();
      this.device.Dispose();
      this.device = (IDevice) null;
    }
    SDKSystem.Finalize();
    Application.Exit();
  }

  public void AddPadding()
  {
    if (Form1.dynamicImg == null)
      return;
    Bitmap bitmap = new Bitmap(Form1.dynamicImg.Width + (int) Variables.offsetLeft + (int) Variables.offsetRight, Form1.dynamicImg.Height + (int) Variables.offsetTop + (int) Variables.offsetBottom);
    using (Graphics graphics = Graphics.FromImage((Image) bitmap))
    {
      graphics.Clear(Color.FromArgb(139, 90, 43));
      graphics.DrawImage((Image) Form1.dynamicImg.ToBitmap<Bgr, byte>(), (int) Variables.offsetLeft, (int) Variables.offsetTop);
    }
    if (this.pboxEdit.Image != null)
      this.pboxEdit.Image.Dispose();
    Form1.dynamicImg = bitmap.ToImage<Bgr, byte>();
    this.pboxEdit.Image = (Image) Form1.dynamicImg.ToBitmap<Bgr, byte>();
    this.ShiftPointsForPadding((int) Variables.offsetLeft, (int) Variables.offsetTop);
    this.pboxEdit.Invalidate();
  }

  private void ShiftPointsForPadding(int shiftX, int shiftY)
  {
    this.SaveState();
    for (int index = 0; index < Variables.dragPoints.Length; ++index)
      Variables.dragPoints[index] = new PointF(Variables.dragPoints[index].X + (float) shiftX, Variables.dragPoints[index].Y + (float) shiftY);
    for (int index1 = 0; index1 < Variables.articlePoints.Count; ++index1)
    {
      List<PointF> articlePoints = Variables.articlePoints;
      int index2 = index1;
      PointF articlePoint = Variables.articlePoints[index1];
      double x = (double) articlePoint.X + (double) shiftX;
      articlePoint = Variables.articlePoints[index1];
      double y = (double) articlePoint.Y + (double) shiftY;
      PointF pointF = new PointF((float) x, (float) y);
      articlePoints[index2] = pointF;
    }
    this.SyncPointsToNumeric();
    this.RefreshListBoxes();
  }

  private void ApplyCamSettings()
  {
    bool flag = false;
    try
    {
      switch (Variables.camModel)
      {
        case "Gencam":
          flag = this.SetCamParamGencam();
          break;
        case "Canon":
          flag = this.SetCamParamCanon();
          break;
      }
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show("Error: " + ex.Message);
    }
  }

  private void btnVideoMode_Click(object sender, EventArgs e)
  {
    this.isGrabbing = false;
    this.receiveThread?.Join();
    if (!this.VideoMode())
      return;
    string exeMode = Variables.exeMode;
    Variables.exeMode = "Video";
    this.isGrabbing = true;
    Instances.videoForm.Setup(this.device, Form1.settingsFile);
    this.receiveThread = new Thread((ThreadStart) (() => this.ReceiveThreadProcess(Instances.videoForm.pboxVideo)));
    this.receiveThread.Start();
    int num = (int) Instances.videoForm.ShowDialog();
    this.UpdateFormSettings();
    this.isGrabbing = false;
    this.receiveThread?.Join();
    this.device.StreamGrabber.StopGrabbing();
    Variables.exeMode = exeMode;
    this.device.Parameters.SetEnumValueByString("TriggerMode", "On");
    this.device.Parameters.SetEnumValueByString("TriggerSource", "Software");
    this.StartGrabCam();
  }

  public void RotateImage(double angleDegrees, ref Image<Bgr, byte> inputImage)
  {
    if (inputImage == null)
    {
      int num1 = (int) MessageBox.Show("Input image is null. Cannot rotate.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }
    else
    {
      try
      {
        PointF center = new PointF((float) inputImage.Width / 2f, (float) inputImage.Height / 2f);
        Bgr background = new Bgr(0.0, 0.0, 0.0);
        Image<Bgr, byte> image = inputImage.Rotate(angleDegrees, center, Inter.Linear, background, false);
        inputImage = image;
      }
      catch (Exception ex)
      {
        int num2 = (int) MessageBox.Show($"Error during image rotation: {ex.Message}. Returning original image.", "Emgu CV Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }
  }

  public Image<Bgr, byte> UndistortWithDatasheet(
    Image<Bgr, byte> inputImage,
    double k1Strength = 100.0,
    double k2Strength = 0.0,
    double strengthX = 100.0,
    double strengthY = 100.0)
  {
    if (inputImage == null)
    {
      int num = (int) MessageBox.Show("Input image is null. Cannot undistort.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      return (Image<Bgr, byte>) null;
    }
    try
    {
      double num1 = -0.0412;
      double num2 = 0.02;
      int width = inputImage.Width;
      int height = inputImage.Height;
      double num3 = 0.5 * Math.Sqrt((double) (width * width + height * height));
      if (strengthX < 0.1)
        strengthX = 0.1;
      if (strengthY < 0.1)
        strengthY = 0.1;
      double num4 = num3 / (strengthX / 100.0);
      double num5 = num3 / (strengthY / 100.0);
      Matrix<double> cameraMatrix = new Matrix<double>(3, 3);
      cameraMatrix[0, 0] = num4;
      cameraMatrix[0, 1] = 0.0;
      cameraMatrix[0, 2] = (double) width / 2.0;
      cameraMatrix[1, 0] = 0.0;
      cameraMatrix[1, 1] = num5;
      cameraMatrix[1, 2] = (double) height / 2.0;
      cameraMatrix[2, 0] = 0.0;
      cameraMatrix[2, 1] = 0.0;
      cameraMatrix[2, 2] = 1.0;
      double num6 = num1 * (k1Strength / 100.0);
      double num7 = num2 * (k2Strength / 100.0);
      Matrix<double> distortionCoeffs = new Matrix<double>(5, 1);
      distortionCoeffs[0, 0] = num6;
      distortionCoeffs[1, 0] = num7;
      distortionCoeffs[2, 0] = 0.0;
      distortionCoeffs[3, 0] = 0.0;
      distortionCoeffs[4, 0] = 0.0;
      Image<Bgr, byte> dst = new Image<Bgr, byte>(inputImage.Size);
      CvInvoke.Undistort((IInputArray) inputImage, (IOutputArray) dst, (IInputArray) cameraMatrix, (IInputArray) distortionCoeffs);
      cameraMatrix.Dispose();
      distortionCoeffs.Dispose();
      return dst;
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show("Error during datasheet undistortion: " + ex.Message, "Emgu CV Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      return inputImage;
    }
  }

  public Image<Bgr, byte> SmartStretchCorners(
    Image<Bgr, byte> inputImage,
    PointF shiftTL,
    PointF shiftTR,
    PointF shiftBR,
    PointF shiftBL)
  {
    if (inputImage == null)
    {
      int num = (int) MessageBox.Show("Input image is null.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      return (Image<Bgr, byte>) null;
    }
    try
    {
      float width1 = (float) inputImage.Width;
      float height1 = (float) inputImage.Height;
      PointF[] src = new PointF[4]
      {
        new PointF(0.0f, 0.0f),
        new PointF(width1, 0.0f),
        new PointF(width1, height1),
        new PointF(0.0f, height1)
      };
      PointF[] source = new PointF[4]
      {
        new PointF(0.0f + shiftTL.X, 0.0f + shiftTL.Y),
        new PointF(width1 + shiftTR.X, 0.0f + shiftTR.Y),
        new PointF(width1 + shiftBR.X, height1 + shiftBR.Y),
        new PointF(0.0f + shiftBL.X, height1 + shiftBL.Y)
      };
      float num1 = ((IEnumerable<PointF>) source).Min<PointF>((Func<PointF, float>) (p => p.X));
      float num2 = ((IEnumerable<PointF>) source).Min<PointF>((Func<PointF, float>) (p => p.Y));
      float num3 = ((IEnumerable<PointF>) source).Max<PointF>((Func<PointF, float>) (p => p.X));
      float num4 = ((IEnumerable<PointF>) source).Max<PointF>((Func<PointF, float>) (p => p.Y));
      float num5 = -num1;
      float num6 = -num2;
      PointF[] dest = new PointF[4];
      for (int index = 0; index < 4; ++index)
        dest[index] = new PointF(source[index].X + num5, source[index].Y + num6);
      int width2 = (int) Math.Ceiling((double) num3 - (double) num1);
      int height2 = (int) Math.Ceiling((double) num4 - (double) num2);
      using (Mat perspectiveTransform = CvInvoke.GetPerspectiveTransform(src, dest))
      {
        Image<Bgr, byte> dst = new Image<Bgr, byte>(width2, height2);
        CvInvoke.WarpPerspective((IInputArray) inputImage, (IOutputArray) dst, (IInputArray) perspectiveTransform, new Size(width2, height2), borderValue: new MCvScalar(0.0, 0.0, 0.0));
        return dst;
      }
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show("Error during smart stretch: " + ex.Message, "Emgu CV Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      return inputImage;
    }
  }

  private void btnStretch_Click(object sender, EventArgs e)
  {
    Form1.dynamicImg = this.SmartStretchCorners(Form1.dynamicImg, new PointF(-500f, -300f), new PointF(0.0f, -200f), new PointF(1000f, 400f), new PointF(0.0f, 0.0f));
    this.pboxEdit.Image = (Image) Form1.dynamicImg.ToBitmap<Bgr, byte>();
  }

  private void cboxExpAuto_CheckedChanged(object sender, EventArgs e)
  {
    if (this.cboxExpAuto.Checked)
    {
      int errorCode1 = this.device.Parameters.SetEnumValue("ExposureAuto", 2U);
      if (errorCode1 != 0)
      {
        this.ShowErrorMsg("Enumerate devices fail, trying mode 1!", errorCode1);
        int errorCode2 = this.device.Parameters.SetEnumValue("ExposureAuto", 1U);
        if (errorCode2 != 0)
          this.ShowErrorMsg("Enumerate devices fail, both 2 and 1 failed!", errorCode2);
      }
      int errorCode3 = this.device.Parameters.SetFloatValue("AutoExposureTimeLowerLimit", (float) this.numUDExpAutoLow.Value);
      if (errorCode3 != 0)
        this.ShowErrorMsg("Auto exposure lower limit failed!", errorCode3);
      int errorCode4 = this.device.Parameters.SetFloatValue("AutoExposureTimeUpperLimit", (float) this.numUDExpAutoUp.Value);
      if (errorCode4 == 0)
        return;
      this.ShowErrorMsg("Auto exposure upper limit failed!", errorCode4);
    }
    else
      this.device.Parameters.SetEnumValue("ExposureAuto", 0U);
  }

  private void numUDExpAutoLow_ValueChanged(object sender, EventArgs e)
  {
    int errorCode = this.device.Parameters.SetFloatValue("AutoExposureTimeLowerLimit", (float) this.numUDExpAutoLow.Value);
    if (errorCode == 0)
      return;
    this.ShowErrorMsg("Auto exposure lower limit failed!", errorCode);
  }

  private void numUDExpAutoUp_ValueChanged(object sender, EventArgs e)
  {
    int errorCode = this.device.Parameters.SetFloatValue("AutoExposureTimeUpperLimit", (float) this.numUDExpAutoUp.Value);
    if (errorCode == 0)
      return;
    this.ShowErrorMsg("Auto exposure upper limit failed!", errorCode);
  }

  private void pboxEdit_MouseMove(object sender, MouseEventArgs e)
  {
    if (this.pboxEdit.Image == null)
      return;
    PointF image = this.ControlToImage(e.Location);
    float num1 = image.X - this.renderingOffset.X;
    float num2 = image.Y - this.renderingOffset.Y;
    this.lXv.Text = $"X: {num1:F1}";
    this.lYv.Text = $"Y: {num2:F1}";
    if (e.Button == MouseButtons.Middle && this.isPanning || e.Button == MouseButtons.Left && this.rbPan.Checked && this.isPanning)
    {
      this.panOffset.X += (float) (e.X - this.lastMousePos.X);
      this.panOffset.Y += (float) (e.Y - this.lastMousePos.Y);
      this.lastMousePos = e.Location;
      this.pboxEdit.Invalidate();
      GC.Collect();
    }
    else if (this.draggingArticleIndex.HasValue)
    {
      Variables.articlePoints[this.draggingArticleIndex.Value] = image;
      this.pboxEdit.Invalidate();
      GC.Collect();
    }
    else
    {
      if (this.rbStretch.Checked)
      {
        if (this.isSelecting)
        {
          float x = Math.Min(this.selectionStart.X, image.X);
          float y = Math.Min(this.selectionStart.Y, image.Y);
          float width = Math.Abs(this.selectionStart.X - image.X);
          float height = Math.Abs(this.selectionStart.Y - image.Y);
          this.selectionRect = new RectangleF(x, y, width, height);
          Variables.dragPoints[0] = new PointF(x, y);
          Variables.dragPoints[1] = new PointF(x + width, y);
          Variables.dragPoints[2] = new PointF(x + width, y + height);
          Variables.dragPoints[3] = new PointF(x, y + height);
          this.pboxEdit.Invalidate();
        }
        else if (this.draggingIndex.HasValue)
        {
          Variables.dragPoints[this.draggingIndex.Value] = image;
          this.ApplyWarp();
          this.pboxEdit.Invalidate();
        }
      }
      GC.Collect();
    }
  }

  private void pboxEdit_MouseLeave(object sender, EventArgs e)
  {
    this.lXv.Text = "X: -";
    this.lYv.Text = "Y: -";
  }

  private void menuDigitizeSettings_Click(object sender, EventArgs e)
  {
    int num = (int) Form1.digitizSettingsForm.ShowDialog();
  }

  private void canonToolStripMenuItem_Click(object sender, EventArgs e)
  {
  }

  private void cboxCamTV_SelectedIndexChanged(object sender, EventArgs e)
  {
  }

  private void cboxCamISO_SelectedIndexChanged(object sender, EventArgs e)
  {
  }

  private void cboxCamAV_SelectedIndexChanged(object sender, EventArgs e)
  {
  }

  private void pboxEdit_MouseDown(object sender, MouseEventArgs e)
  {
    PointF image = this.ControlToImage(e.Location);
    int num = 200;
    if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
      this.SaveState();
    if (e.Button == MouseButtons.Middle || e.Button == MouseButtons.Left && this.rbPan.Checked)
    {
      this.isPanning = true;
      this.pboxEdit.Cursor = Cursors.SizeAll;
      this.lastMousePos = e.Location;
      GC.Collect();
    }
    else
    {
      if (e.Button == MouseButtons.Right)
      {
        for (int index = 0; index < Variables.articlePoints.Count; ++index)
        {
          if ((double) this.GetDistanceSq(image, Variables.articlePoints[index]) < (double) (num * num))
          {
            this.draggingArticleIndex = new int?(index);
            this.lbArticle.SelectedIndex = index;
            this.pboxEdit.Invalidate();
            GC.Collect();
            return;
          }
        }
      }
      if (e.Button == MouseButtons.Left)
      {
        if (this.rbArticle.Checked)
        {
          Variables.articlePoints.Add(image);
          this.RefreshListBoxes();
          this.pboxEdit.Invalidate();
          GC.Collect();
        }
        else if (this.rbStretch.Checked)
        {
          for (int index = 0; index < Variables.dragPoints.Length; ++index)
          {
            Point control = this.ImageToControl(Variables.dragPoints[index]);
            if ((double) this.GetDistanceSq((PointF) e.Location, (PointF) control) < 225.0)
            {
              this.draggingIndex = new int?(index);
              this.pboxEdit.Invalidate();
              GC.Collect();
              return;
            }
          }
          if (this.rbStretchRegional.Checked)
          {
            this.isSelecting = true;
            this.selectionStart = image;
            this.selectionRect = RectangleF.Empty;
            this.pboxEdit.Invalidate();
          }
        }
      }
      GC.Collect();
    }
  }

  private float GetDistanceSq(PointF p1, PointF p2)
  {
    return (float) (((double) p1.X - (double) p2.X) * ((double) p1.X - (double) p2.X) + ((double) p1.Y - (double) p2.Y) * ((double) p1.Y - (double) p2.Y));
  }

  private void ResetView()
  {
    this.currentZoom = 1f;
    this.panOffset = new PointF(0.0f, 0.0f);
    this.pboxEdit.Invalidate();
  }

  private void pboxEdit_MouseDoubleClick(object sender, MouseEventArgs e)
  {
    if (e.Button == MouseButtons.Middle)
      this.ResetView();
    GC.Collect();
  }

  private void pboxEdit_MouseUp(object sender, MouseEventArgs e)
  {
    if (e.Button == MouseButtons.Middle || e.Button == MouseButtons.Left && this.rbPan.Checked)
    {
      this.isPanning = false;
      this.pboxEdit.Cursor = this.rbArticle.Checked ? Cursors.Cross : Cursors.Default;
    }
    if (this.draggingArticleIndex.HasValue)
    {
      this.draggingArticleIndex = new int?();
      this.RefreshListBoxes();
    }
    if (this.isSelecting)
    {
      this.isSelecting = false;
      float width = this.selectionRect.Width;
      float height = this.selectionRect.Height;
      for (int index1 = 0; index1 < 4; ++index1)
      {
        for (int index2 = 0; index2 < 4; ++index2)
          Variables.dragPoints[index1 * 4 + index2] = new PointF(this.selectionRect.X + (float) index2 / 3f * width, this.selectionRect.Y + (float) index1 / 3f * height);
      }
      this.ApplyWarp();
      this.pboxEdit.Refresh();
    }
    else if (this.draggingIndex.HasValue)
    {
      this.ApplyWarp();
      this.draggingIndex = new int?();
      this.pboxEdit.Refresh();
    }
    this.draggingIndex = new int?();
    this.RefreshListBoxes();
    GC.Collect();
  }

  private void pboxEdit_Paint(object sender, PaintEventArgs e)
  {
    e.Graphics.Clear(this.pboxEdit.BackColor);
    if (this.pboxEdit.Image == null)
      return;
    float num1 = Math.Min((float) this.pboxEdit.ClientSize.Width / (float) this.pboxEdit.Image.Width, (float) this.pboxEdit.ClientSize.Height / (float) this.pboxEdit.Image.Height) * this.currentZoom;
    int width = (int) ((double) this.pboxEdit.Image.Width * (double) num1);
    int height = (int) ((double) this.pboxEdit.Image.Height * (double) num1);
    Point control1 = this.ImageToControl(this.renderingOffset);
    e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
    e.Graphics.DrawImage(this.pboxEdit.Image, control1.X, control1.Y, width, height);
    if (this.rbStretch.Checked && this.rbStretchRegional.Checked && Variables.dragPoints != null && Variables.dragPoints.Length == 16 /*0x10*/)
    {
      using (Pen pen = new Pen(Color.Yellow, 2f))
      {
        int num2 = 10;
        for (int index1 = 0; index1 <= num2; ++index1)
        {
          float num3 = (float) index1 / (float) num2;
          List<Point> pointList1 = new List<Point>();
          List<Point> pointList2 = new List<Point>();
          for (int index2 = 0; index2 <= num2; ++index2)
          {
            pointList1.Add(this.ImageToControl(this.ResizeFunctions.BezierSurface2D(Variables.dragPoints, num3, (float) index2 / (float) num2)));
            pointList2.Add(this.ImageToControl(this.ResizeFunctions.BezierSurface2D(Variables.dragPoints, (float) index2 / (float) num2, num3)));
          }
          e.Graphics.DrawLines(pen, pointList1.ToArray());
          e.Graphics.DrawLines(pen, pointList2.ToArray());
        }
      }
    }
    if (this.cbGrid.Checked)
      this.DrawPerspectiveGrid(e.Graphics);
    for (int index = 0; index < Variables.articlePoints.Count; ++index)
    {
      Point control2 = this.ImageToControl(Variables.articlePoints[index]);
      int num4 = 10;
      bool flag = this.lbArticle.SelectedIndex == index;
      using (Pen pen = new Pen(flag ? Color.Blue : Color.Red, flag ? 4f : 2f))
      {
        e.Graphics.DrawLine(pen, control2.X - num4, control2.Y, control2.X + num4, control2.Y);
        e.Graphics.DrawLine(pen, control2.X, control2.Y - num4, control2.X, control2.Y + num4);
        if (flag)
          e.Graphics.DrawEllipse(pen, control2.X - 12, control2.Y - 12, 24, 24);
      }
    }
    if (this.rbStretch.Checked && (this.rbStretchNormal.Checked || this.rbStretchRegional.Checked) && Variables.dragPoints != null)
    {
      int[] numArray = new int[4]{ 0, 3, 15, 12 };
      for (int index3 = 0; index3 < 4; ++index3)
      {
        int index4 = numArray[index3];
        if (index4 < Variables.dragPoints.Length)
        {
          Point control3 = this.ImageToControl(Variables.dragPoints[index4]);
          Brush brush = this.lbDrag.SelectedIndex == index3 ? Brushes.Yellow : Brushes.LimeGreen;
          e.Graphics.FillEllipse(brush, control3.X - 6, control3.Y - 6, 12, 12);
          e.Graphics.DrawEllipse(Pens.White, control3.X - 6, control3.Y - 6, 12, 12);
        }
      }
    }
    GC.Collect();
  }

  private Point ImageToControl(PointF pt)
  {
    if (this.pboxEdit.Image == null)
      return Point.Empty;
    float num1 = Math.Min((float) this.pboxEdit.ClientSize.Width / (float) this.pboxEdit.Image.Width, (float) this.pboxEdit.ClientSize.Height / (float) this.pboxEdit.Image.Height) * this.currentZoom;
    float num2 = (float) (((double) this.pboxEdit.ClientSize.Width - (double) this.pboxEdit.Image.Width * (double) num1) / 2.0);
    float num3 = (float) (((double) this.pboxEdit.ClientSize.Height - (double) this.pboxEdit.Image.Height * (double) num1) / 2.0);
    float num4 = pt.X - this.renderingOffset.X;
    float num5 = pt.Y - this.renderingOffset.Y;
    return new Point((int) (num4 * num1 + num2 + this.panOffset.X), (int) (num5 * num1 + num3 + this.panOffset.Y));
  }

  private PointF ControlToImage(Point p)
  {
    if (this.pboxEdit.Image == null)
      return PointF.Empty;
    float num1 = Math.Min((float) this.pboxEdit.ClientSize.Width / (float) this.pboxEdit.Image.Width, (float) this.pboxEdit.ClientSize.Height / (float) this.pboxEdit.Image.Height) * this.currentZoom;
    float num2 = (float) (((double) this.pboxEdit.ClientSize.Width - (double) this.pboxEdit.Image.Width * (double) num1) / 2.0);
    float num3 = (float) (((double) this.pboxEdit.ClientSize.Height - (double) this.pboxEdit.Image.Height * (double) num1) / 2.0);
    return new PointF(((float) p.X - this.panOffset.X - num2) / num1 + this.renderingOffset.X, ((float) p.Y - this.panOffset.Y - num3) / num1 + this.renderingOffset.Y);
  }

  public void ExportImage(string filePath, bool includeMarkers)
  {
    if (Form1.dynamicImg == null)
      return;
    using (Bitmap bitmap = Form1.dynamicImg.ToBitmap<Bgr, byte>())
    {
      if (includeMarkers)
      {
        using (Graphics graphics = Graphics.FromImage((Image) bitmap))
        {
          graphics.SmoothingMode = SmoothingMode.AntiAlias;
          float num1 = (float) bitmap.Width * 0.01f;
          using (Pen pen = new Pen(Color.Red, Math.Max(1f, num1 * 0.1f)))
          {
            foreach (PointF articlePoint in Variables.articlePoints)
            {
              float num2 = articlePoint.X - this.renderingOffset.X;
              float num3 = articlePoint.Y - this.renderingOffset.Y;
              graphics.DrawLine(pen, num2 - num1, num3, num2 + num1, num3);
              graphics.DrawLine(pen, num2, num3 - num1, num2, num3 + num1);
            }
          }
        }
      }
      bitmap.Save(filePath, ImageFormat.Jpeg);
    }
  }

  private void menuEdgeSettings_Click(object sender, EventArgs e)
  {
    int num = (int) Form1.edgeSettingsForm.ShowDialog();
  }

  private void btnRemoveBack_Click(object sender, EventArgs e)
  {
    Variables.ReadEdgeSettings(this.edgeSettings);
    this.RemoveBackround();
  }

  private void btnRefresh_Click(object sender, EventArgs e)
  {
    switch (Variables.camModel)
    {
      case "Gencam":
        this.CloseGenCam();
        if (this.device != null)
        {
          this.device.Close();
          this.device.Dispose();
          this.device = (IDevice) null;
        }
        this.RefreshDeviceList();
        Control.CheckForIllegalCrossThreadCalls = false;
        this.OpenGenCam();
        break;
      case "Canon":
        SDKSystem.Finalize();
        SDKSystem.Initialize();
        this.OpenCanon();
        break;
    }
  }

  private void cboxArticleMode_CheckedChanged(object sender, EventArgs e)
  {
  }

  private void btnNewMarker_Click(object sender, EventArgs e)
  {
  }

  private void rbStretch_CheckedChanged(object sender, EventArgs e)
  {
  }

  private void rbArticle_CheckedChanged(object sender, EventArgs e)
  {
    if (this.rbArticle.Checked)
      this.pboxEdit.Cursor = Cursors.Cross;
    else
      this.pboxEdit.Cursor = Cursors.Default;
  }

  private void PboxModeChanged(object sender, EventArgs e)
  {
    this.pboxEdit.Invalidate();
    if (this.rbArticle.Checked)
      this.pboxEdit.Cursor = Cursors.Cross;
    else
      this.pboxEdit.Cursor = Cursors.Default;
  }

  private void btnSavePre1_Click(object sender, EventArgs e)
  {
    if (Variables.dragPoints != null)
      this.dragPre1 = (PointF[]) Variables.dragPoints.Clone();
    if (Variables.articlePoints != null)
      this.articlePre1 = new List<PointF>((IEnumerable<PointF>) Variables.articlePoints);
    this.SaveToPicturebox(this.pboxPreview1);
  }

  private void SaveToPicturebox(PictureBox pbox)
  {
    pbox.Image?.Dispose();
    pbox.Image = (Image) this.pboxEdit.Image.Clone();
    pbox.Invalidate();
  }

  private void btnLoadPre1_Click(object sender, EventArgs e)
  {
    if (this.dragPre1 != null)
      Variables.dragPoints = (PointF[]) this.dragPre1.Clone();
    if (this.articlePre1 != null)
      Variables.articlePoints = new List<PointF>((IEnumerable<PointF>) this.articlePre1);
    this.pboxEdit.Image = (Image) ((Bitmap) this.pboxPreview1.Image).ToImage<Bgr, byte>().ToBitmap<Bgr, byte>();
    this.ApplyWarp();
    this.RefreshListBoxes();
    this.pboxEdit.Invalidate();
    GC.Collect();
  }

  private void pboxEdit_MouseClick(object sender, MouseEventArgs e)
  {
    if (this.rbBackround.Checked)
      this.DetectBackround(e);
    GC.Collect();
  }

  private void DetectBackround(MouseEventArgs e)
  {
    Rectangle imageDisplayArea = this.ResizeFunctions.GetImageDisplayArea(this.pboxEdit);
    if (!imageDisplayArea.Contains(e.Location))
      return;
    int num1 = e.X - imageDisplayArea.X;
    int num2 = e.Y - imageDisplayArea.Y;
    float num3 = (float) Form1.dynamicImg.Width / (float) imageDisplayArea.Width;
    float num4 = (float) Form1.dynamicImg.Height / (float) imageDisplayArea.Height;
    int column = (int) ((double) num1 * (double) num3);
    int row = (int) ((double) num2 * (double) num4);
    if (column < 0 || column >= Form1.dynamicImg.Width || row < 0 || row >= Form1.dynamicImg.Height)
      return;
    Bgr bgr = Form1.workImg[row, column];
    this.pboxBackColor.BackColor = Color.FromArgb((int) bgr.Red, (int) bgr.Green, (int) bgr.Blue);
    this.backColor = new Bgr((double) (int) bgr.Blue, (double) (int) bgr.Green, (double) (int) bgr.Red);
    string path = Path.Combine(Form1.calibFile, "backroundColor.txt");
    switch (Variables.camModel)
    {
      case "Gencam":
        path = Path.Combine(Form1.calibFile, "backroundColorGencam.txt");
        break;
      case "Canon":
        path = Path.Combine(Form1.calibFile, "backroundColorCanon.txt");
        break;
    }
    this.SaveFunctions.SaveBackroundColors(path, bgr.Blue, bgr.Green, bgr.Red);
    Debug.WriteLine($"Selected BGR: B={bgr.Blue}, G={bgr.Green}, R={bgr.Red}");
  }

  private void RemoveBackround()
  {
    Image<Bgr, byte> inputImage = Form1.dynamicImg.Clone();
    this.backColor = this.LoadBackroundColors(Form1.calibFile);
    Image<Bgr, byte> image1;
    VectorOfVectorOfPoint vectorOfVectorOfPoint;
    Mat mat;
    TupleExtensions.Deconstruct<Image<Bgr, byte>, VectorOfVectorOfPoint, Mat>(this.ColorFunctions.ProcessImage(inputImage, Variables.backColorspace, this.backColor, (int) Variables.backHueRange, (int) Variables.backSatRange, (int) Variables.backValRange), ref image1, ref vectorOfVectorOfPoint, ref mat);
    Image<Bgr, byte> image2 = image1;
    this.contourEdgeFunc = vectorOfVectorOfPoint;
    this.outputHierarcy = mat;
    Form1.dynamicImg?.Dispose();
    Form1.dynamicImg = image2.Clone();
    this.pboxEdit.Image?.Dispose();
    this.pboxEdit.Image = (Image) image2.ToBitmap<Bgr, byte>();
  }

  private Bgr LoadBackroundColors(string path)
  {
    string str1 = Path.Combine(path, "backroundColor.txt");
    switch (Variables.camModel)
    {
      case "Gencam":
        str1 = Path.Combine(path, "backroundColorGencam.txt");
        break;
      case "Canon":
        str1 = Path.Combine(path, "backroundColorCanon.txt");
        break;
    }
    Bgr bgr = new Bgr(0.0, (double) byte.MaxValue, 0.0);
    try
    {
      if (!File.Exists(str1))
      {
        Debug.WriteLine("Background color file not found. Returning default values.");
        return new Bgr(0.0, (double) byte.MaxValue, 0.0);
      }
      using (StreamReader streamReader = new StreamReader(str1))
      {
        string str2 = ((TextReader) streamReader).ReadLine();
        if (string.IsNullOrEmpty(str2))
        {
          Debug.WriteLine("Background color file is empty. Returning default values.");
          return new Bgr(0.0, (double) byte.MaxValue, 0.0);
        }
        string[] strArray = str2.Split(',', StringSplitOptions.None);
        bgr = new Bgr(double.Parse(strArray[0].Trim()), double.Parse(strArray[1].Trim()), double.Parse(strArray[2].Trim()));
        Debug.WriteLine($"Loaded BGR: Blue={bgr.Blue}, Green={bgr.Green}, Red={bgr.Red}");
      }
    }
    catch (Exception ex)
    {
      Debug.WriteLine($"Error reading background color file: {ex.Message}. Returning default values.");
      return new Bgr(0.0, (double) byte.MaxValue, 0.0);
    }
    return bgr;
  }

  private void DrawPerspectiveGrid(Graphics g)
  {
    if (this.pboxEdit.Image == null)
      return;
    Point control1 = this.ImageToControl(new PointF(this.renderingOffset.X, this.renderingOffset.Y));
    Point control2 = this.ImageToControl(new PointF(this.renderingOffset.X + (float) this.pboxEdit.Image.Width, this.renderingOffset.Y + (float) this.pboxEdit.Image.Height));
    int x = control1.X;
    int y = control1.Y;
    int num1 = control2.X - control1.X;
    int num2 = control2.Y - control1.Y;
    using (Pen pen = new Pen(this.gridColor, (float) this.numUDGridThick.Value))
    {
      int num3 = (int) this.numUDGridY.Value;
      for (int index = 0; index <= num3; ++index)
      {
        float num4 = (float) y + (float) index * ((float) num2 / (float) num3);
        g.DrawLine(pen, (float) x, num4, (float) (x + num1), num4);
      }
      int num5 = (int) this.numUDGridX.Value;
      for (int index = 0; index <= num5; ++index)
      {
        float num6 = (float) x + (float) index * ((float) num1 / (float) num5);
        g.DrawLine(pen, num6, (float) y, num6, (float) (y + num2));
      }
    }
  }

  private PointF LerpPoint(PointF a, PointF b, float t)
  {
    return new PointF(a.X + (b.X - a.X) * t, a.Y + (b.Y - a.Y) * t);
  }

  private void btnFindContour_Click(object sender, EventArgs e)
  {
    Variables.ReadEdgeSettings(this.edgeSettings);
    this.RemoveBackround();
    this.ClearDeleteZones();
    Rectangle imageDisplayArea = this.ResizeFunctions.GetImageDisplayArea(this.pboxEdit);
    List<List<Vector2>> vector2ListList1 = new List<List<Vector2>>();
    List<List<List<Vector2>>> vector2ListListList1 = new List<List<List<Vector2>>>();
    List<List<Vector3>> vector3ListList = new List<List<Vector3>>();
    List<List<List<Vector3>>> vector3ListListList = new List<List<List<Vector3>>>();
    Form1.dynamicImg.Clone();
    Image<Bgr, byte> image1;
    List<List<Vector2>> vector2ListList2;
    List<List<List<Vector2>>> vector2ListListList2;
    List<List<Point>> pointListList;
    List<List<List<Point>>> pointListListList;
    List<List<Vector2>> vector2ListList3;
    List<List<List<Vector2>>> vector2ListListList3;
    TupleExtensions.Deconstruct<Image<Bgr, byte>, List<List<Vector2>>, List<List<List<Vector2>>>, List<List<Point>>, List<List<List<Point>>>, List<List<Vector2>>, List<List<List<Vector2>>>>(this.EdgeFunctions.DetectOnlyEdges(Form1.dynamicImg, Variables.contourMethod, (double) Variables.contourDist, (double) Variables.DistX, (double) Variables.DistY, 1, (int) Variables.minArea, Variables.contourShowArea, Variables.contourShowPoints, this.allDrawPoints, imageDisplayArea.Width, imageDisplayArea.Height, imageDisplayArea.X, imageDisplayArea.Y, Variables.contourMethod, Variables.contourShowcase, this.pix2mmCB, (double) Variables.contourSensitivity, this.contourEdgeFunc, this.outputHierarcy), ref image1, ref vector2ListList2, ref vector2ListListList2, ref pointListList, ref pointListListList, ref vector2ListList3, ref vector2ListListList3);
    Image<Bgr, byte> image2 = image1;
    this.outputContoursList = vector2ListList2;
    this.insideContoursList = vector2ListListList2;
    this.scaledDrawnContours = pointListList;
    this.drawnscaled2contours = pointListListList;
    vector2ListList1 = vector2ListList3;
    vector2ListListList1 = vector2ListListList3;
    if (Variables.exeMode != "Quick")
      Form1.dynamicImg = image2.Clone();
    if (Variables.exeMode != "Quick")
    {
      Form1.dynamicImg = this.EdgeFunctions.DrawHybridSegments(Form1.dynamicImg, this.EdgeFunctions.outerDensedList, this.EdgeFunctions.outerSimplifiedList, (double) Variables.contourLineFit);
      for (int index = 0; index < this.EdgeFunctions.innerDensedList.Count; ++index)
        Form1.dynamicImg = this.EdgeFunctions.DrawHybridSegments(Form1.dynamicImg, this.EdgeFunctions.innerDensedList[index], this.EdgeFunctions.innerSimplifiedList[index], (double) Variables.contourLineFit);
    }
    float height = (float) Form1.dynamicImg.Height;
    this.EdgeFunctions.MirrorY(this.EdgeFunctions.outerDensedList, height);
    this.EdgeFunctions.MirrorY(this.EdgeFunctions.outerSimplifiedList, height);
    this.EdgeFunctions.MirrorY(this.EdgeFunctions.innerDensedList, height);
    this.EdgeFunctions.MirrorY(this.EdgeFunctions.innerSimplifiedList, height);
    this.EdgeFunctions.MirrorYPoints(this.EdgeFunctions.deadzonesPerOuterContour, (int) height);
    this.SaveFunctions.WriteContour2FileOptimizedV2(this.EdgeFunctions.outerDensedList, this.EdgeFunctions.outerSimplifiedList, this.EdgeFunctions.innerDensedList, this.EdgeFunctions.innerSimplifiedList, this.EdgeFunctions.deadzonesPerOuterContour, 1.0, 1.0, Path.Combine(Form1.pointsFile, "all_points_optimized.buteach"), (double) Variables.contourLineFit, false, false);
    this.EdgeFunctions.outerDensedList.Clear();
    this.EdgeFunctions.outerSimplifiedList.Clear();
    this.EdgeFunctions.innerDensedList.Clear();
    this.EdgeFunctions.innerSimplifiedList.Clear();
    this.EdgeFunctions.deadzonesPerOuterContour.Clear();
    this.pboxEdit.Image = (Image) Form1.dynamicImg.ToBitmap<Bgr, byte>();
    GC.Collect();
  }

  private void ClearDeleteZones()
  {
    this.currentDeletePoints.Clear();
    this.deleteZones.Clear();
    this.pboxEdit.Invalidate();
  }

  private void btnSaveArticle_Click(object sender, EventArgs e)
  {
    this.SaveFunctions.SaveArticlePoints(Variables.articlePoints, Path.Combine(Form1.pointsFile, "Article\\articlePoints.txt"));
  }

  private void btnLoadArticle_Click(object sender, EventArgs e)
  {
    this.SaveFunctions.LoadArticlePoints(Variables.articlePoints, Path.Combine(Form1.pointsFile, "Article\\articlePoints.txt"));
    this.RefreshListBoxes();
    this.pboxEdit.Invalidate();
  }

  private void btnSaveStretchQuick_Click(object sender, EventArgs e)
  {
    this.SaveFunctions.SaveDragPoints(Variables.dragPoints, Path.Combine(Form1.pointsFile, "Stretch\\stretchAuto.txt"));
  }

  private void btnLoadStretchQuick_Click(object sender, EventArgs e)
  {
    PointF[] dragPoints = Variables.dragPoints;
    this.SaveFunctions.LoadDragPoints(Path.Combine(Form1.pointsFile, "Stretch\\stretchAuto.txt"), ref dragPoints);
    Variables.dragPoints = dragPoints;
    this.ApplyWarp();
    this.RefreshListBoxes();
    this.pboxEdit.Invalidate();
  }

  private void btnResetImage_Click(object sender, EventArgs e)
  {
    this.InitializeImagePoints();
    Variables.articlePoints.Clear();
    this.RefreshListBoxes();
    Form1.dynamicImg = Form1.workImg.Clone();
    this.pboxEdit.Image = (Image) Form1.workImg.ToBitmap<Bgr, byte>();
    this.pboxEdit.Invalidate();
  }

  private void cbGrid_CheckedChanged(object sender, EventArgs e) => this.pboxEdit.Invalidate();

  private void RefreshListBoxes()
  {
    this.lbDrag.BeginUpdate();
    this.lbArticle.BeginUpdate();
    this.lbDrag.Items.Clear();
    this.lbArticle.Items.Clear();
    if (Variables.dragPoints != null && Variables.dragPoints.Length >= 16 /*0x10*/)
    {
      int[] numArray = new int[4]{ 0, 3, 15, 12 };
      string[] strArray = new string[4]
      {
        "TL",
        "TR",
        "BR",
        "BL"
      };
      for (int index = 0; index < 4; ++index)
      {
        PointF dragPoint = Variables.dragPoints[numArray[index]];
        float num1 = dragPoint.X - this.renderingOffset.X;
        float num2 = dragPoint.Y - this.renderingOffset.Y;
        this.lbDrag.Items.Add((object) $"[{strArray[index]}] X: {num1:f1}, Y: {num2:f1}");
      }
    }
    if (Variables.articlePoints != null)
    {
      for (int index = 0; index < Variables.articlePoints.Count; ++index)
      {
        PointF articlePoint = Variables.articlePoints[index];
        float num3 = articlePoint.X - this.renderingOffset.X;
        float num4 = articlePoint.Y - this.renderingOffset.Y;
        this.lbArticle.Items.Add((object) $"#{index + 1} X: {num3:f1}, Y: {num4:f1}");
      }
    }
    this.lbDrag.EndUpdate();
    this.lbArticle.EndUpdate();
    this.SyncPointsToNumeric();
  }

  private void LBPaintIndexChanged(object sender, EventArgs e) => this.pboxEdit.Invalidate();

  private void RemoveSelectedArticle()
  {
    int selectedIndex = this.lbArticle.SelectedIndex;
    if (selectedIndex < 0 || selectedIndex >= Variables.articlePoints.Count)
      return;
    Variables.articlePoints.RemoveAt(selectedIndex);
    this.RefreshListBoxes();
    this.pboxEdit.Invalidate();
  }

  private void lbArticle_KeyDown(object sender, KeyEventArgs e)
  {
    if (e.KeyCode != Keys.Delete)
      return;
    this.RemoveSelectedArticle();
  }

  private void btnSaveAsArticle_Click(object sender, EventArgs e)
  {
    this.articlePath = this.SaveFunctions.SaveAsTxt();
    if (this.articlePath == null)
      return;
    this.SaveFunctions.SaveArticlePoints(Variables.articlePoints, this.articlePath);
    int num = (int) MessageBox.Show("Article points saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
  }

  private void btnSaveAsDrag_Click(object sender, EventArgs e)
  {
    this.dragPath = this.SaveFunctions.SaveAsTxt();
    if (this.dragPath == null)
      return;
    this.SaveFunctions.SaveDragPoints(Variables.dragPoints, this.dragPath);
    int num = (int) MessageBox.Show("Drag points saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
  }

  private void btnLoadAsArticle_Click(object sender, EventArgs e)
  {
    this.articlePath = this.SaveFunctions.LoadAsTxt();
    if (this.articlePath == null)
      return;
    this.SaveFunctions.LoadArticlePoints(Variables.articlePoints, this.articlePath);
    this.RefreshListBoxes();
    this.pboxEdit.Invalidate();
  }

  private void btnLoadAsDrag_Click(object sender, EventArgs e)
  {
    this.dragPath = this.SaveFunctions.LoadAsTxt();
    if (this.dragPath == null)
      return;
    PointF[] dragPoints = Variables.dragPoints;
    this.SaveFunctions.LoadDragPoints(this.dragPath, ref dragPoints);
    Variables.dragPoints = dragPoints;
    this.ApplyWarp();
    this.RefreshListBoxes();
    this.pboxEdit.Invalidate();
  }

  private void LoadDragAuto()
  {
    string filePath = Path.Combine(Form1.pointsFile, "Stretch\\stretchAuto.txt");
    if (!File.Exists(filePath))
      return;
    PointF[] dragPoints = Variables.dragPoints;
    this.SaveFunctions.LoadDragPoints(filePath, ref dragPoints);
    Variables.dragPoints = dragPoints;
    this.ApplyWarp();
    this.RefreshListBoxes();
    this.pboxEdit.Invalidate();
  }

  private void numUDGridDiv_ValueChanged(object sender, EventArgs e) => this.pboxEdit.Invalidate();

  private void btnResetMarker_Click(object sender, EventArgs e)
  {
    Variables.articlePoints.Clear();
    this.RefreshListBoxes();
    this.pboxEdit.Invalidate();
  }

  private void btnResetDrag_Click(object sender, EventArgs e)
  {
    this.InitializeImagePoints();
    this.RefreshListBoxes();
    this.pboxEdit.Invalidate();
  }

  private void ToggleNumericEvents(bool enable) => this.isSyncing = !enable;

  private void numUDStretch_ValueChanged(object sender, EventArgs e)
  {
    if (this._isInternalChange || Variables.dragPoints == null || Variables.dragPoints.Length < 16 /*0x10*/)
      return;
    Variables.dragPoints[0] = new PointF((float) this.numUDTLX.Value + this.renderingOffset.X, (float) this.numUDTLY.Value + this.renderingOffset.Y);
    Variables.dragPoints[3] = new PointF((float) this.numUDTRX.Value + this.renderingOffset.X, (float) this.numUDTRY.Value + this.renderingOffset.Y);
    Variables.dragPoints[15] = new PointF((float) this.numUDBRX.Value + this.renderingOffset.X, (float) this.numUDBRY.Value + this.renderingOffset.Y);
    Variables.dragPoints[12] = new PointF((float) this.numUDBLX.Value + this.renderingOffset.X, (float) this.numUDBLY.Value + this.renderingOffset.Y);
    this.ApplyWarp();
    this.pboxEdit.Invalidate();
  }

  private void SyncPointsToNumeric()
  {
    if (Variables.dragPoints == null || Variables.dragPoints.Length < 16 /*0x10*/)
      return;
    this._isInternalChange = true;
    this.numUDTLX.Value = (Decimal) Variables.dragPoints[0].X - (Decimal) this.renderingOffset.X;
    this.numUDTLY.Value = (Decimal) Variables.dragPoints[0].Y - (Decimal) this.renderingOffset.Y;
    this.numUDTRX.Value = (Decimal) Variables.dragPoints[3].X - (Decimal) this.renderingOffset.X;
    this.numUDTRY.Value = (Decimal) Variables.dragPoints[3].Y - (Decimal) this.renderingOffset.Y;
    this.numUDBRX.Value = (Decimal) Variables.dragPoints[15].X - (Decimal) this.renderingOffset.X;
    this.numUDBRY.Value = (Decimal) Variables.dragPoints[15].Y - (Decimal) this.renderingOffset.Y;
    this.numUDBLX.Value = (Decimal) Variables.dragPoints[12].X - (Decimal) this.renderingOffset.X;
    this.numUDBLY.Value = (Decimal) Variables.dragPoints[12].Y - (Decimal) this.renderingOffset.Y;
    this._isInternalChange = false;
  }

  private void btnGridColor_Click(object sender, EventArgs e)
  {
    using (ColorDialog colorDialog = new ColorDialog())
    {
      colorDialog.Color = this.gridColor;
      if (colorDialog.ShowDialog() != DialogResult.OK)
        return;
      this.gridColor = Color.FromArgb(150, colorDialog.Color);
      this.pboxEdit.Invalidate();
    }
  }

  private void SaveState()
  {
    if (Variables.dragPoints != null)
      this.dragHistory.Push((PointF[]) Variables.dragPoints.Clone());
    if (Variables.articlePoints != null)
      this.articleHistory.Push(new List<PointF>((IEnumerable<PointF>) Variables.articlePoints));
    this.dragRedoHistory.Clear();
    this.articleRedoHistory.Clear();
    if (this.dragHistory.Count <= 20)
      return;
    List<PointF[]> list1 = this.dragHistory.ToList<PointF[]>();
    List<List<PointF>> list2 = this.articleHistory.ToList<List<PointF>>();
    this.dragHistory = new Stack<PointF[]>(list1.Take<PointF[]>(20).Reverse<PointF[]>());
    this.articleHistory = new Stack<List<PointF>>(list2.Take<List<PointF>>(20).Reverse<List<PointF>>());
  }

  private void Undo()
  {
    if (this.dragHistory.Count > 0 && this.articleHistory.Count > 0)
    {
      this.dragRedoHistory.Push((PointF[]) Variables.dragPoints.Clone());
      this.articleRedoHistory.Push(new List<PointF>((IEnumerable<PointF>) Variables.articlePoints));
      Variables.dragPoints = this.dragHistory.Pop();
      Variables.articlePoints = this.articleHistory.Pop();
      this.SyncPointsToNumeric();
      this.ApplyWarp();
      this.RefreshListBoxes();
      this.pboxEdit.Invalidate();
    }
    else
    {
      int num = (int) MessageBox.Show("No more actions to undo.");
    }
  }

  private void Redo()
  {
    if (this.dragRedoHistory.Count > 0 && this.articleRedoHistory.Count > 0)
    {
      this.dragHistory.Push((PointF[]) Variables.dragPoints.Clone());
      this.articleHistory.Push(new List<PointF>((IEnumerable<PointF>) Variables.articlePoints));
      Variables.dragPoints = this.dragRedoHistory.Pop();
      Variables.articlePoints = this.articleRedoHistory.Pop();
      this.SyncPointsToNumeric();
      this.ApplyWarp();
      this.RefreshListBoxes();
      this.pboxEdit.Invalidate();
    }
    else
    {
      int num = (int) MessageBox.Show("No more actions to redo.");
    }
  }

  private void btnUndo_Click(object sender, EventArgs e) => this.Undo();

  private void ApplyMeshWarp()
  {
    if (Form1.workImg == null || Variables.dragPoints == null || Variables.dragPoints.Length < 16 /*0x10*/)
      return;
    float x = ((IEnumerable<PointF>) Variables.dragPoints).Min<PointF>((Func<PointF, float>) (p => p.X));
    float y = ((IEnumerable<PointF>) Variables.dragPoints).Min<PointF>((Func<PointF, float>) (p => p.Y));
    float num1 = ((IEnumerable<PointF>) Variables.dragPoints).Max<PointF>((Func<PointF, float>) (p => p.X));
    float num2 = ((IEnumerable<PointF>) Variables.dragPoints).Max<PointF>((Func<PointF, float>) (p => p.Y));
    int width = Math.Max(1, (int) ((double) num1 - (double) x));
    int height = Math.Max(1, (int) ((double) num2 - (double) y));
    this.renderingOffset = new PointF(x, y);
    if (Form1.dynamicImg != null)
      Form1.dynamicImg.Dispose();
    Form1.dynamicImg = new Image<Bgr, byte>(new Size(width, height));
    Form1.dynamicImg.SetValue(new Bgr(0.0, 0.0, 0.0));
    int num3 = 15;
    for (int index1 = 0; index1 < num3; ++index1)
    {
      for (int index2 = 0; index2 < num3; ++index2)
      {
        float u1 = (float) index2 / (float) num3;
        float v1 = (float) index1 / (float) num3;
        float u2 = (float) (index2 + 1) / (float) num3;
        float v2 = (float) (index1 + 1) / (float) num3;
        PointF[] pointFArray = new PointF[4]
        {
          new PointF(u1 * (float) Form1.workImg.Width, v1 * (float) Form1.workImg.Height),
          new PointF(u2 * (float) Form1.workImg.Width, v1 * (float) Form1.workImg.Height),
          new PointF(u2 * (float) Form1.workImg.Width, v2 * (float) Form1.workImg.Height),
          new PointF(u1 * (float) Form1.workImg.Width, v2 * (float) Form1.workImg.Height)
        };
        Rectangle roi = Rectangle.Round(new RectangleF(u1 * (float) Form1.workImg.Width, v1 * (float) Form1.workImg.Height, (u2 - u1) * (float) Form1.workImg.Width, (v2 - v1) * (float) Form1.workImg.Height));
        roi.Intersect(new Rectangle(0, 0, Form1.workImg.Width, Form1.workImg.Height));
        if (roi.Width > 0 && roi.Height > 0)
        {
          PointF[] dest = new PointF[4]
          {
            this.ResizeFunctions.BezierSurface2D(Variables.dragPoints, u1, v1),
            this.ResizeFunctions.BezierSurface2D(Variables.dragPoints, u2, v1),
            this.ResizeFunctions.BezierSurface2D(Variables.dragPoints, u2, v2),
            this.ResizeFunctions.BezierSurface2D(Variables.dragPoints, u1, v2)
          };
          for (int index3 = 0; index3 < 4; ++index3)
          {
            dest[index3].X -= x;
            dest[index3].Y -= y;
          }
          using (Image<Bgr, byte> src = Form1.workImg.Copy(roi))
          {
            using (Mat perspectiveTransform = CvInvoke.GetPerspectiveTransform(new PointF[4]
            {
              new PointF(0.0f, 0.0f),
              new PointF((float) roi.Width, 0.0f),
              new PointF((float) roi.Width, (float) roi.Height),
              new PointF(0.0f, (float) roi.Height)
            }, dest))
              CvInvoke.WarpPerspective((IInputArray) src, (IOutputArray) Form1.dynamicImg, (IInputArray) perspectiveTransform, Form1.dynamicImg.Size, borderMode: BorderType.Transparent);
          }
        }
      }
    }
    Bitmap image = this.pboxEdit.Image as Bitmap;
    this.pboxEdit.Image = (Image) Form1.dynamicImg.ToBitmap<Bgr, byte>();
    image?.Dispose();
  }

  private void DrawCurvedGrid(Graphics g, PointF[] mesh)
  {
    using (Pen pen = new Pen(this.gridColor, (float) this.numUDGridThick.Value))
    {
      for (int index = 0; index < 4; ++index)
      {
        PointF[] points = new PointF[4]
        {
          (PointF) this.ImageToControl(mesh[index * 4]),
          (PointF) this.ImageToControl(mesh[index * 4 + 1]),
          (PointF) this.ImageToControl(mesh[index * 4 + 2]),
          (PointF) this.ImageToControl(mesh[index * 4 + 3])
        };
        g.DrawCurve(pen, points);
      }
      for (int index = 0; index < 4; ++index)
      {
        PointF[] points = new PointF[4]
        {
          (PointF) this.ImageToControl(mesh[index]),
          (PointF) this.ImageToControl(mesh[index + 4]),
          (PointF) this.ImageToControl(mesh[index + 8]),
          (PointF) this.ImageToControl(mesh[index + 12])
        };
        g.DrawCurve(pen, points);
      }
    }
  }

  private Image<Bgr, byte> ApplyDeleteZones()
  {
    Image<Bgr, byte> image = Form1.dynamicImg.Clone();
    if (image == null || this.deleteZones == null || this.deleteZones.Count == 0)
      return Form1.dynamicImg;
    using (VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint())
    {
      foreach (List<Point> deleteZone in this.deleteZones)
      {
        if (deleteZone != null && deleteZone.Count >= 3)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: method pointer
          Point[] values = Array.ConvertAll<Point, Point>(deleteZone.ToArray(), Form1.\u003C\u003Ec.\u003C\u003E9__228_0 ?? (Form1.\u003C\u003Ec.\u003C\u003E9__228_0 = new Converter<Point, Point>((object) Form1.\u003C\u003Ec.\u003C\u003E9, __methodptr(\u003CApplyDeleteZones\u003Eb__228_0))));
          contours.Push(new VectorOfPoint(values));
        }
      }
      if (contours.Size > 0)
        CvInvoke.DrawContours((IInputOutputArray) image, (IInputArrayOfArrays) contours, -1, new MCvScalar(0.0, 0.0, 0.0), -1);
    }
    this.pboxEdit.Image?.Dispose();
    this.pboxEdit.Image = (Image) Form1.dynamicImg.ToBitmap<Bgr, byte>();
    return image;
  }

  private void LoadCameraAndWorkspaceConfig()
  {
    this.DigitizeConfig.FocalLengthMm = Variables.FocalLength;
    this.DigitizeConfig.SensorWidthMm = Variables.SensorWidth;
    this.DigitizeConfig.SensorHeightMm = Variables.SensorHeight;
    this.DigitizeConfig.PrincipalPointX = Variables.PrincipalPointX;
    this.DigitizeConfig.PrincipalPointY = Variables.PrincipalPointY;
    this.DigitizeConfig.DistortionCoeffs = new double[5]
    {
      (double) Variables.DistStrK1,
      (double) Variables.DistStrK2,
      0.0,
      0.0,
      0.0
    };
    this.DigitizeConfig.MarkerSizeMm = (double) Variables.MarkerSize;
    this.DigitizeConfig.SurfaceWidthMm = (double) Variables.TopViewWidth;
    this.DigitizeConfig.SurfaceHeightMm = (double) Variables.TopViewHeight;
  }

  private void btnTabCamera_Click(object sender, EventArgs e)
  {
  }

  private void btnTabEdge_Click(object sender, EventArgs e)
  {
  }

  private void pboxEdit_SizeChanged(object sender, EventArgs e)
  {
    this.pboxEdit.Refresh();
    GC.Collect();
  }

  private void btnTabCanon_Click(object sender, EventArgs e)
  {
    this.CloseGenCam();
    if (this.device != null)
    {
      this.device.Close();
      this.device.Dispose();
      this.device = (IDevice) null;
    }
    SDKSystem.Initialize();
    if (this.OpenCanon())
    {
      Variables.camModel = "Canon";
      Variables.ReadCameraSettings(Form1.settingsFile);
      this.UpdateFormSettings();
      this.backColor = this.LoadBackroundColors(Form1.calibFile);
      this.PboxLoadBackColor(this.pboxBackColor, this.backColor);
      this.tabControlAllCams.SelectedTab = this.tabCanon;
      this.btnTabCanon.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnTabGencam.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
    }
    else
      this.btnRefresh_Click((object) null, (EventArgs) null);
  }

  private async void btnTabGencam_Click(object sender, EventArgs e)
  {
    SDKSystem.Finalize();
    this.RefreshDeviceList();
    Control.CheckForIllegalCrossThreadCalls = false;
    if (await this.OpenGenCam())
    {
      Variables.camModel = "Gencam";
      Variables.ReadCameraSettings(Form1.settingsFile);
      this.UpdateFormSettings();
      this.backColor = this.LoadBackroundColors(Form1.calibFile);
      this.PboxLoadBackColor(this.pboxBackColor, this.backColor);
      this.tabControlAllCams.SelectedTab = this.tabGenCam;
      this.btnTabCanon.Font = new Font("Segoe UI", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnTabGencam.Font = new Font("Segoe UI", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    }
    else
      this.btnRefresh_Click((object) null, (EventArgs) null);
  }

  private void btnCancel_Click(object sender, EventArgs e)
  {
    this.Form1_FormClosing((object) null, (FormClosingEventArgs) null);
  }

  private void btnSwitchCanon_Click(object sender, EventArgs e)
  {
    this.CloseGenCam();
    if (this.device != null)
    {
      this.device.Close();
      this.device.Dispose();
      this.device = (IDevice) null;
    }
    SDKSystem.Initialize();
    if (this.OpenCanon())
    {
      this.btnTabCanon_Click((object) null, (EventArgs) null);
      Variables.camModel = "Canon";
    }
    else
      this.btnRefresh_Click((object) null, (EventArgs) null);
  }

  private async void btnSwitchGencam_Click(object sender, EventArgs e)
  {
    SDKSystem.Finalize();
    this.RefreshDeviceList();
    Control.CheckForIllegalCrossThreadCalls = false;
    if (await this.OpenGenCam())
    {
      this.btnTabGencam_Click((object) null, (EventArgs) null);
      Variables.camModel = "Gencam";
    }
    else
      this.btnRefresh_Click((object) null, (EventArgs) null);
  }

  private void btnCalibDual_Click(object sender, EventArgs e)
  {
    Image<Bgr, byte> image1 = new Image<Bgr, byte>(Form1.dynamicImg.Width, Form1.dynamicImg.Height);
    Size size1 = new Size(image1.Width, image1.Height);
    Mat mat1 = new Mat();
    (Image<Bgr, byte> image2, double num1, double num2, Mat mat2, Size size2) = this.DigitizeFunctions.StretchFromArucoV4(Form1.dynamicImg, (int) Variables.TopViewWidth, (int) Variables.TopViewHeight, (double) Variables.MarkerSize);
    if (mat2 == null)
      return;
    this.transformMatrix = mat2;
    this.pix2mmX = num1;
    this.pix2mmY = num2;
    Form1.dynamicImg.Save(Form1.imgFile + "\\BaseIMGForCalib.bmp");
    string str = "arucoTransform";
    switch (Variables.camModel)
    {
      case "Canon":
        str = "canonTransform";
        break;
      case "Gencam":
        str = "gencamTransform";
        break;
    }
    this.SaveFunctions.WriteMatrixAndDimensions(this.transformMatrix, size2.Width, size2.Height, Path.Combine(Form1.calibFile, str + "Normal.txt"));
    Image<Bgr, byte> image3 = image2.Clone();
    Image<Bgr, byte> image4;
    (image4, this.pix2mmX, this.pix2mmY, this.transformMatrix, size2) = this.DigitizeFunctions.StretchFromArucoV3(Form1.dynamicImg, (int) Variables.TopViewWidth, (int) Variables.TopViewHeight, (double) Variables.MarkerSize, "OUTER");
    this.SaveFunctions.WriteMatrixAndDimensions(this.transformMatrix, size2.Width, size2.Height, Path.Combine(Form1.calibFile, str + "Outer.txt"));
    if (Variables.StretchType == "Outer")
      image3 = image4.Clone();
    Image<Bgr, byte> image5;
    (image5, this.pix2mmX, this.pix2mmY, this.transformMatrix, size2) = this.DigitizeFunctions.StretchFromArucoV3(Form1.dynamicImg, (int) Variables.TopViewWidth, (int) Variables.TopViewHeight, (double) Variables.MarkerSize, "INNER");
    this.SaveFunctions.WriteMatrixAndDimensions(this.transformMatrix, size2.Width, size2.Height, Path.Combine(Form1.calibFile, str + "Inner.txt"));
    if (Variables.StretchType == "Inner")
      image3 = image5.Clone();
    Form1.dynamicImg = image3.Clone();
    this.pboxEdit.Image = (Image) image3.ToBitmap<Bgr, byte>();
    GC.Collect();
  }

  private void btnExtend_Click(object sender, EventArgs e)
  {
    if (this.WindowState == FormWindowState.Maximized)
      this.WindowState = FormWindowState.Normal;
    else
      this.WindowState = FormWindowState.Maximized;
    this.Invalidate();
  }

  private void btnMinimize_Click(object sender, EventArgs e)
  {
    this.WindowState = FormWindowState.Minimized;
  }

  private void menuCalibSettings_Click(object sender, EventArgs e)
  {
    if (Form1.loadedImage == null)
    {
      int num1 = (int) MessageBox.Show("Please load or take a photo first to calibrate.");
    }
    else
    {
      Image<Bgr, byte> inputImage = Form1.loadedImage.Clone();
      if (Variables.AutoCorrectLens && Variables.DistStrK1 != 0M)
      {
        switch (Variables.camModel)
        {
          case "Canon":
            inputImage = this.DigitizeFunctions.UndistortCanon(inputImage, (double) Variables.DistStrK1, (double) Variables.DistStrK2, (double) Variables.DistX, (double) Variables.DistY);
            break;
          case "Gencam":
            inputImage = this.DigitizeFunctions.UndistortHikrobot12MP(inputImage, (double) Variables.DistStrK1, (double) Variables.DistStrK2, (double) Variables.DistX, (double) Variables.DistY);
            break;
        }
      }
      if (Variables.AutoRotation && Variables.RotationValue != 0M)
        this.DigitizeFunctions.RotateImage((double) Variables.RotationValue / 100.0, ref inputImage);
      this.calibSettingsForm.Initialize(Variables.camModel, Form1.calibFile, inputImage, Application.CurrentCulture);
      int num2 = (int) this.calibSettingsForm.ShowDialog();
      inputImage?.Dispose();
    }
  }

  private void btnLockIP_Click(object sender, EventArgs e) => this.LockCameraToStaticIP();

  private void GridValueChanged(object sender, EventArgs e) => this.pboxEdit.Invalidate();

  private void HardRestartNetworkAdapter(string adapterName)
  {
    try
    {
      ProcessStartInfo startInfo = new ProcessStartInfo();
      startInfo.FileName = "powershell.exe";
      string str = $"Disable-NetAdapter -Name '{adapterName}' -Confirm:$false; Start-Sleep -Seconds 1.5; Enable-NetAdapter -Name '{adapterName}' -Confirm:$false; Clear-NetNeighbor -InterfaceAlias '{adapterName}' -Confirm:$false";
      startInfo.Arguments = $"-Command \"{str}\"";
      startInfo.Verb = "runas";
      startInfo.UseShellExecute = true;
      startInfo.WindowStyle = (ProcessWindowStyle) 1;
      using (Process process = Process.Start(startInfo))
        process?.WaitForExit();
    }
    catch (Exception ex)
    {
      Debug.WriteLine("PowerShell Fast Reset Failed: " + ex.Message);
    }
  }

  private async void btnHardReset_Click(object sender, EventArgs e)
  {
    if (sender is Button btn)
    {
      btn.Enabled = false;
      btn.Text = "Flushing NIC...";
    }
    this.isGrabbing = false;
    await Task.Run((Action) (() =>
    {
      try
      {
        this.receiveThread?.Join(1000);
      }
      catch
      {
      }
    }));
    if (this.device != null)
    {
      try
      {
        this.device.StreamGrabber?.StopGrabbing();
      }
      catch
      {
      }
      try
      {
        this.device.Close();
      }
      catch
      {
      }
      try
      {
        this.device.Dispose();
      }
      catch
      {
      }
      this.device = (IDevice) null;
    }
    if (btn != null)
      btn.Text = "Cycling Port...";
    await Task.Run((Action) (() => this.HardRestartNetworkAdapterNative(Variables.EthernetName)));
    if (btn != null)
      btn.Text = "Waking Stack...";
    await Task.Delay(4000);
    bool isConnectedAndOpened = await this.TryOpenDeviceAsynchronously(btn);
    if (isConnectedAndOpened && this.device != null)
    {
      if (btn != null)
        btn.Text = "Streaming...";
      await Task.Delay(300);
      this.StartGrabCam();
      if (btn == null)
      {
        btn = (Button) null;
      }
      else
      {
        btn.Text = "Hard Refresh";
        btn.Enabled = true;
        btn = (Button) null;
      }
    }
    else
    {
      int num = (int) MessageBox.Show("Asynchronous native deep reset timed out during handle binding.");
      btn = (Button) null;
    }
  }

  private async Task<bool> HardReset()
  {
    this.isGrabbing = false;
    await Task.Run((Action) (() =>
    {
      try
      {
        this.receiveThread?.Join(1000);
      }
      catch
      {
      }
    }));
    if (this.device != null)
    {
      try
      {
        this.device.StreamGrabber?.StopGrabbing();
      }
      catch
      {
      }
      try
      {
        this.device.Close();
      }
      catch
      {
      }
      try
      {
        this.device.Dispose();
      }
      catch
      {
      }
      this.device = (IDevice) null;
    }
    await Task.Run((Action) (() => this.HardRestartNetworkAdapterNative(Variables.EthernetName)));
    await Task.Delay(4000);
    bool isConnectedAndOpened = await this.TryOpenDeviceAsynchronously((Button) null);
    if (isConnectedAndOpened && this.device != null)
    {
      await Task.Delay(300);
      this.StartGrabCam();
      return true;
    }
    int num = (int) MessageBox.Show("Asynchronous native deep reset timed out during handle binding.");
    return false;
  }

  private void SetNetworkAdapterState(string adapterName, bool enable)
  {
    try
    {
      ProcessStartInfo startInfo = new ProcessStartInfo();
      startInfo.FileName = "powershell.exe";
      string str = enable ? "Enable-NetAdapter" : "Disable-NetAdapter";
      startInfo.Arguments = $"-Command \"{str} -Name '{adapterName}' -Confirm:$false\"";
      startInfo.Verb = "runas";
      startInfo.UseShellExecute = true;
      startInfo.WindowStyle = (ProcessWindowStyle) 1;
      using (Process process = Process.Start(startInfo))
        process?.WaitForExit();
    }
    catch (Exception ex)
    {
      Debug.WriteLine("PowerShell Adapter Error: " + ex.Message);
    }
  }

  private async Task<bool> TryOpenDeviceAsynchronously(Button statusButton)
  {
    int maxTimeoutSeconds = 25;
    bool cameraNetworkReady = false;
    for (int i = 1; i <= maxTimeoutSeconds * 5; ++i)
    {
      double elapsedSeconds = Math.Round((double) i * 0.2, 1);
      if (statusButton != null)
        statusButton.Text = $"Waiting for Link ({elapsedSeconds}s)...";
      try
      {
        using (Ping pingCheck = new Ping())
        {
          PingReply reply = await Task.Run<PingReply>((Func<PingReply>) (() =>
          {
            try
            {
              return pingCheck.Send(Variables.EthernetCameraIP, 150);
            }
            catch
            {
              return (PingReply) null;
            }
          }));
          if (reply != null && reply.Status == IPStatus.Success)
          {
            cameraNetworkReady = true;
            break;
          }
          reply = (PingReply) null;
        }
      }
      catch
      {
      }
      await Task.Delay(200);
    }
    if (!cameraNetworkReady)
      return false;
    if (statusButton != null)
      statusButton.Text = "Binding Camera Handles...";
    for (int attempt = 0; attempt < 10; ++attempt)
    {
      this.RefreshDeviceList();
      if (this.deviceInfoList.Count > 0)
      {
        IDeviceInfo deviceInfo = this.deviceInfoList[0];
        try
        {
          IDevice tempDevice = DeviceFactory.CreateDevice(deviceInfo);
          if (tempDevice is IGigEDevice gigEDevice)
          {
            uint cameraIP = this.ConvertIPToUInt(Variables.EthernetCameraIP);
            uint subnetMask = this.ConvertIPToUInt("255.255.0.0");
            uint defaultGateway = this.ConvertIPToUInt("172.16.39.201");
            gigEDevice.ForceIp(cameraIP, subnetMask, defaultGateway);
            tempDevice.Parameters.SetIntValue("GevSCPSPacketSize", 1500L);
          }
          int openResult = tempDevice.Open(DeviceAccessMode.AccessExclusiveWithSwitch, 0U);
          if (openResult != 0)
            openResult = tempDevice.Open();
          if (openResult == 0)
          {
            this.device = tempDevice;
            return true;
          }
          Debug.WriteLine($"Binding allocation rejected with error: {openResult}");
          tempDevice.Close();
          tempDevice.Dispose();
          tempDevice = (IDevice) null;
          gigEDevice = (IGigEDevice) null;
        }
        catch (Exception ex)
        {
          Debug.WriteLine("Binding exception: " + ex.Message);
        }
        deviceInfo = (IDeviceInfo) null;
      }
      await Task.Delay(1000);
    }
    return false;
  }

  private void HardRestartNetworkAdapterNative(string adapterName)
  {
    try
    {
      using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher($"SELECT * FROM Win32_NetworkAdapter WHERE NetConnectionID = '{adapterName}'"))
      {
        foreach (ManagementObject managementObject in managementObjectSearcher.Get())
        {
          managementObject.InvokeMethod("Disable", (object[]) null);
          Thread.Sleep(5000);
          managementObject.InvokeMethod("Enable", (object[]) null);
        }
      }
    }
    catch (Exception ex)
    {
      Debug.WriteLine("Native hardware modification failed: " + ex.Message);
    }
  }

  private void btnTopView_Click(object sender, EventArgs e)
  {
    if (!Variables.AutoTopView)
      return;
    Image<Bgr, byte> image = Form1.dynamicImg.Clone();
    Mat dst = new Mat();
    int width = 0;
    int height = 0;
    string str = "arucoTransform";
    switch (Variables.camModel)
    {
      case "Canon":
        str = "canonTransform";
        break;
      case "Gencam":
        str = "gencamTransform";
        break;
    }
    switch (Variables.StretchType)
    {
      case "Normal":
        (this.transformMatrix, width, height) = this.SaveFunctions.ReadMatrixAndDimensions(Path.Combine(Form1.calibFile, str + "Normal.txt"));
        break;
      case "Outer":
        (this.transformMatrix, width, height) = this.SaveFunctions.ReadMatrixAndDimensions(Path.Combine(Form1.calibFile, str + "Outer.txt"));
        break;
      case "Inner":
        (this.transformMatrix, width, height) = this.SaveFunctions.ReadMatrixAndDimensions(Path.Combine(Form1.calibFile, str + "Inner.txt"));
        break;
    }
    CvInvoke.WarpPerspective((IInputArray) image.Mat, (IOutputArray) dst, (IInputArray) this.transformMatrix, new Size(width, height), Inter.Lanczos4);
    Form1.dynamicImg = dst.ToImage<Bgr, byte>().Clone();
    PointF zeroPoint = new PointF((float) (int) Variables.OffsetCenterX, (float) (int) Variables.OffsetCenterY);
    Color woodColor = Color.FromArgb(139, 90, 43);
    Form1.dynamicImg = this.ApplyThicknessBasedParallaxCorrection(Form1.dynamicImg.Clone(), zeroPoint, Variables.StoneThickness, Variables.OffsetMpX, Variables.OffsetMpY, woodColor);
    Form1.workImg = Form1.dynamicImg.Clone();
    Form1.dynamicImg.Save(Form1.imgFile + "\\TopView.bmp");
    this.pboxEdit.Image = (Image) Form1.dynamicImg.ToBitmap<Bgr, byte>();
    this.RefreshListBoxes();
    this.pboxEdit.Invalidate();
    GC.Collect();
  }

  public unsafe Image<Bgr, byte> ApplyThicknessBasedParallaxCorrection(
    Image<Bgr, byte> srcImage,
    PointF zeroPoint,
    double stoneThickness,
    double factorX,
    double factorY,
    Color woodColor)
  {
    int w = srcImage.Width;
    int height = srcImage.Height;
    Mat map1 = new Mat(height, w, DepthType.Cv32F, 1);
    Mat map2 = new Mat(height, w, DepthType.Cv32F, 1);
    float* ptrX = (float*) map1.DataPointer.ToPointer();
    float* ptrY = (float*) map2.DataPointer.ToPointer();
    float cx = zeroPoint.X;
    float cy = zeroPoint.Y;
    float scaleX = 1f + (float) (factorX * stoneThickness);
    float scaleY = 1f + (float) (factorY * stoneThickness);
    Parallel.For(0, height, (Action<int>) (y =>
    {
      float* numPtr1 = ptrX + y * w;
      float* numPtr2 = ptrY + y * w;
      float num1 = cy + ((float) y - cy) * scaleY;
      for (int index = 0; index < w; ++index)
      {
        float num2 = cx + ((float) index - cx) * scaleX;
        numPtr1[index] = num2;
        numPtr2[index] = num1;
      }
    }));
    Image<Bgr, byte> dst = new Image<Bgr, byte>(w, height);
    MCvScalar borderValue = new MCvScalar((double) woodColor.B, (double) woodColor.G, (double) woodColor.R);
    CvInvoke.Remap((IInputArray) srcImage, (IOutputArray) dst, (IInputArray) map1, (IInputArray) map2, Inter.Lanczos4, borderValue: borderValue);
    map1.Dispose();
    map2.Dispose();
    return dst;
  }

  public unsafe Image<Bgr, byte> ApplyLocalizedGaussianOffset(
    Image<Bgr, byte> srcImage,
    PointF targetPoint,
    double maxPixelShiftX,
    double spreadX)
  {
    int w = srcImage.Width;
    int height = srcImage.Height;
    Mat map1 = new Mat(height, w, DepthType.Cv32F, 1);
    Mat map2 = new Mat(height, w, DepthType.Cv32F, 1);
    float* ptrX = (float*) map1.DataPointer.ToPointer();
    float* ptrY = (float*) map2.DataPointer.ToPointer();
    float cx = targetPoint.X;
    float f_shiftX = (float) maxPixelShiftX;
    float f_spreadX = (float) spreadX;
    if ((double) f_spreadX <= 0.0)
      f_spreadX = 1f;
    Parallel.For(0, height, (Action<int>) (y =>
    {
      float* numPtr1 = ptrX + y * w;
      float* numPtr2 = ptrY + y * w;
      for (int index = 0; index < w; ++index)
      {
        float num1 = (float) index - cx;
        float num2 = (float) Math.Exp(-((double) num1 * (double) num1) / ((double) f_spreadX * (double) f_spreadX));
        float num3 = (float) index + f_shiftX * num2;
        float num4 = (float) y;
        numPtr1[index] = num3;
        numPtr2[index] = num4;
      }
    }));
    Image<Bgr, byte> dst = new Image<Bgr, byte>(w, height);
    CvInvoke.Remap((IInputArray) srcImage, (IOutputArray) dst, (IInputArray) map1, (IInputArray) map2, Inter.Lanczos4, BorderType.Replicate, new MCvScalar(0.0, 0.0, 0.0));
    map1.Dispose();
    map2.Dispose();
    return dst;
  }

  public unsafe Image<Bgr, byte> ApplyLinearYParallaxCorrection(
    Image<Bgr, byte> srcImage,
    double stoneThickness,
    double factorY,
    double offsetY,
    Color woodColor)
  {
    int w = srcImage.Width;
    int height = srcImage.Height;
    Mat map1 = new Mat(height, w, DepthType.Cv32F, 1);
    Mat map2 = new Mat(height, w, DepthType.Cv32F, 1);
    float* ptrX = (float*) map1.DataPointer.ToPointer();
    float* ptrY = (float*) map2.DataPointer.ToPointer();
    float f_thickness = (float) stoneThickness;
    float f_factorY = (float) factorY;
    float f_offsetY = (float) offsetY;
    Parallel.For(0, height, (Action<int>) (y =>
    {
      float* numPtr1 = ptrX + y * w;
      float* numPtr2 = ptrY + y * w;
      float num = (float) y + ((float) y * f_factorY + f_offsetY) * f_thickness;
      for (int index = 0; index < w; ++index)
      {
        numPtr1[index] = (float) index;
        numPtr2[index] = num;
      }
    }));
    Image<Bgr, byte> dst = new Image<Bgr, byte>(w, height);
    MCvScalar borderValue = new MCvScalar((double) woodColor.B, (double) woodColor.G, (double) woodColor.R);
    CvInvoke.Remap((IInputArray) srcImage, (IOutputArray) dst, (IInputArray) map1, (IInputArray) map2, Inter.Lanczos4, borderValue: borderValue);
    map1.Dispose();
    map2.Dispose();
    return dst;
  }

  private void btnTopViewV2_Click(object sender, EventArgs e)
  {
    switch (Variables.camModel)
    {
      case "Canon":
        Form1.dynamicImg = this.DigitizeFunctions.UndistortCanon(Form1.dynamicImg, (double) Variables.DistStrK1, (double) Variables.DistStrK2, (double) Variables.DistX, (double) Variables.DistY);
        break;
      case "Gencam":
        Form1.dynamicImg = this.DigitizeFunctions.UndistortHikrobot12MP(Form1.dynamicImg, (double) Variables.DistStrK1, (double) Variables.DistStrK2, (double) Variables.DistX, (double) Variables.DistY);
        break;
    }
    if (!Variables.AutoTopView)
      return;
    if (Variables.AutoCalcOffset)
    {
      float topViewWidth = (float) Variables.TopViewWidth;
      float topViewHeight = (float) Variables.TopViewHeight;
      float stoneThickness = (float) Variables.StoneThickness;
      Form1.dynamicImg = this.DigitizeFunctions.GenerateTopView4Offset(Form1.dynamicImg.Clone(), stoneThickness, topViewWidth, topViewHeight, new Size((int) Variables.TopViewWidth, (int) Variables.TopViewHeight)).Clone();
    }
    else
    {
      Mat dst = new Mat();
      int width;
      int height;
      (this.transformMatrix, width, height) = this.SaveFunctions.ReadMatrixAndDimensions(Path.Combine(Form1.calibFile, "arucoTransformNormal.txt"));
      CvInvoke.WarpPerspective((IInputArray) Form1.dynamicImg.Mat, (IOutputArray) dst, (IInputArray) this.transformMatrix, new Size(width, height), Inter.Lanczos4);
      Form1.dynamicImg = dst.ToImage<Bgr, byte>();
    }
  }

  private void btnCalibDualV2_Click(object sender, EventArgs e)
  {
    Image<Bgr, byte> image1 = new Image<Bgr, byte>(Form1.dynamicImg.Width, Form1.dynamicImg.Height);
    Size size1 = new Size(image1.Width, image1.Height);
    Mat mat1 = new Mat();
    (Image<Bgr, byte> image2, double num1, double num2, Mat mat2, Size size2) = this.DigitizeFunctions.StretchFromArucoV5(Form1.dynamicImg, (int) Variables.TopViewWidth, (int) Variables.TopViewHeight, (double) Variables.MarkerSize, Variables.StretchType);
    if (mat2 == null)
      return;
    this.transformMatrix = mat2;
    this.pix2mmX = num1;
    this.pix2mmY = num2;
    Form1.dynamicImg.Save(Form1.imgFile + "\\BaseIMGForCalib.bmp");
    string str = "arucoTransform";
    switch (Variables.camModel)
    {
      case "Canon":
        str = "canonTransform";
        break;
      case "Gencam":
        str = "gencamTransform";
        break;
    }
    this.SaveFunctions.WriteMatrixAndDimensions(this.transformMatrix, size2.Width, size2.Height, Path.Combine(Form1.calibFile, str + "Normal.txt"));
    Image<Bgr, byte> image3 = image2.Clone();
    Image<Bgr, byte> image4;
    (image4, this.pix2mmX, this.pix2mmY, this.transformMatrix, size2) = this.DigitizeFunctions.StretchFromArucoV5(Form1.dynamicImg, (int) Variables.TopViewWidth, (int) Variables.TopViewHeight, (double) Variables.MarkerSize, "OUTER");
    this.SaveFunctions.WriteMatrixAndDimensions(this.transformMatrix, size2.Width, size2.Height, Path.Combine(Form1.calibFile, str + "Outer.txt"));
    if (Variables.StretchType == "Outer")
      image3 = image4.Clone();
    Form1.dynamicImg = image3.Clone();
    this.pboxEdit.Image = (Image) image3.ToBitmap<Bgr, byte>();
    GC.Collect();
  }

  private void btnDistortion_Click(object sender, EventArgs e)
  {
    if (Variables.AutoCorrectLens && Variables.DistStrK1 != 0M)
    {
      switch (Variables.camModel)
      {
        case "Canon":
          Form1.dynamicImg = this.DigitizeFunctions.UndistortCanon(Form1.dynamicImg, (double) Variables.DistStrK1, (double) Variables.DistStrK2, (double) Variables.DistX, (double) Variables.DistY);
          break;
        case "Gencam":
          Form1.dynamicImg = this.DigitizeFunctions.UndistortHikrobot12MP(Form1.dynamicImg, (double) Variables.DistStrK1, (double) Variables.DistStrK2, (double) Variables.DistX, (double) Variables.DistY);
          break;
      }
    }
    this.pboxEdit.Image = (Image) Form1.dynamicImg.ToBitmap<Bgr, byte>();
  }

  private void btnDistV2_Click(object sender, EventArgs e)
  {
    PointF centerPoint = new PointF(1238f, (float) Form1.dynamicImg.Height / 2f);
    double spreadX = (double) Form1.dynamicImg.Width / 5.7;
    double strengthX = -0.08;
    double peakLimit = 1.0;
    Form1.dynamicImg = this.DigitizeFunctions.ApplyGaussianDistortionCorrection(Form1.dynamicImg, centerPoint, strengthX, spreadX, peakLimit);
    PointF zeroPoint = new PointF((float) (int) Variables.OffsetCenterX, (float) (int) Variables.OffsetCenterY);
    Color woodColor = Color.FromArgb(139, 90, 43);
    Form1.dynamicImg = this.ApplyThicknessBasedParallaxCorrection(Form1.dynamicImg, zeroPoint, Variables.StoneThickness, Variables.OffsetMpX, Variables.OffsetMpY, woodColor);
    this.pboxEdit.Image = (Image) Form1.dynamicImg.ToBitmap<Bgr, byte>();
  }

  private void btnDistV3_Click(object sender, EventArgs e)
  {
    PointF targetPoint = new PointF(1202f, (float) Form1.dynamicImg.Height / 2f);
    double maxPixelShiftX = 7.0;
    double spreadX = 250.0;
    Form1.dynamicImg = this.ApplyLocalizedGaussianOffset(Form1.dynamicImg, targetPoint, maxPixelShiftX, spreadX);
    this.pboxEdit.Image = (Image) Form1.dynamicImg.ToBitmap<Bgr, byte>();
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.components != null)
      this.components.Dispose();
    base.Dispose(disposing);
  }

  private void InitializeComponent()
  {
    this.pboxEdit = new PictureBox();
    this.btnLoad = new Button();
    this.btnSave = new Button();
    this.btnUndo = new Button();
    this.btnVideoMode = new Button();
    this.btnRefresh = new Button();
    this.btnTakePhoto = new Button();
    this.btnCalibDual = new Button();
    this.btnFindContour = new Button();
    this.btnRemoveBack = new Button();
    this.btnLoadAsDrag = new Button();
    this.btnSaveAsDrag = new Button();
    this.btnLoadAsArticle = new Button();
    this.btnSaveAsArticle = new Button();
    this.btnResetMarker = new Button();
    this.btnResetDrag = new Button();
    this.btnResetImage = new Button();
    this.btnGridColor = new Button();
    this.btnSavePre1 = new Button();
    this.btnLoadPre1 = new Button();
    this.btnTabCanon = new Button();
    this.btnTabGencam = new Button();
    this.btnHardReset = new Button();
    this.btnSwitchGencam = new Button();
    this.btnLockIP = new Button();
    this.btnTabEdge = new Button();
    this.numUDGCManExp = new NumericUpDown();
    this.numUDGain = new NumericUpDown();
    this.numUDExpAutoLow = new NumericUpDown();
    this.numUDExpAutoUp = new NumericUpDown();
    this.numUDGridX = new NumericUpDown();
    this.numUDGridY = new NumericUpDown();
    this.numUDGridThick = new NumericUpDown();
    this.numUDTLX = new NumericUpDown();
    this.numUDTLY = new NumericUpDown();
    this.numUDTRX = new NumericUpDown();
    this.numUDTRY = new NumericUpDown();
    this.numUDBLX = new NumericUpDown();
    this.numUDBLY = new NumericUpDown();
    this.numUDBRX = new NumericUpDown();
    this.numUDBRY = new NumericUpDown();
    this.lblExposure = new Label();
    this.lblGain = new Label();
    this.lblLowLimit = new Label();
    this.lblUpLimit = new Label();
    this.lblCoordX = new Label();
    this.lblCoordY = new Label();
    this.lblBackColor = new Label();
    this.lblPboxMode = new Label();
    this.lblGridThick = new Label();
    this.label5 = new Label();
    this.label6 = new Label();
    this.lblAV = new Label();
    this.lblISO = new Label();
    this.lblTV = new Label();
    this.lblSecCamera = new Label();
    this.lblSecExposure = new Label();
    this.lblSecCapture = new Label();
    this.lblSecViewMode = new Label();
    this.lblSecBgColor = new Label();
    this.lblSecGrid = new Label();
    this.lblCamStatus = new Label();
    this.lblScaleInfo = new Label();
    this.lblZoom = new Label();
    this.cboxExpAuto = new CheckBox();
    this.cbGrid = new CheckBox();
    this.tabControlAllCams = new TabControl();
    this.tabGenCam = new TabPage();
    this.tabCanon = new TabPage();
    this.tabWebcam = new TabPage();
    this.rbPan = new RadioButton();
    this.rbBackround = new RadioButton();
    this.rbStretch = new RadioButton();
    this.rbArticle = new RadioButton();
    this.rbNone = new RadioButton();
    this.rbStretchNormal = new RadioButton();
    this.rbStretchRegional = new RadioButton();
    this.menuStrip1 = new MenuStrip();
    this.menuDigitizeSettings = new ToolStripMenuItem();
    this.menuEdgeSettings = new ToolStripMenuItem();
    this.menuCalibSettings = new ToolStripMenuItem();
    this.pboxBackColor = new PictureBox();
    this.pboxPreview1 = new PictureBox();
    this.lbDrag = new ListBox();
    this.lbArticle = new ListBox();
    this.pnlLeft = new Panel();
    this.pnlLBorder = new Panel();
    this.secCam = new Panel();
    this.hdrCam = new Label();
    this.divHdrCam = new Panel();
    this.bodyCam = new Panel();
    this.divBotCam = new Panel();
    this.secExp = new Panel();
    this.hdrExp = new Label();
    this.divHdrExp = new Panel();
    this.bodyExp = new Panel();
    this.boxLow = new Panel();
    this.boxHigh = new Panel();
    this.boxManExp = new Panel();
    this.boxGain = new Panel();
    this.divBotExp = new Panel();
    this.secCap = new Panel();
    this.hdrCap = new Label();
    this.divHdrCap = new Panel();
    this.bodyCap = new Panel();
    this.divBotCap = new Panel();
    this.secView = new Panel();
    this.hdrView = new Label();
    this.divHdrView = new Panel();
    this.bodyView = new Panel();
    this.divBotView = new Panel();
    this.secBg = new Panel();
    this.hdrBg = new Label();
    this.divHdrBg = new Panel();
    this.bodyBg = new Panel();
    this.divBotBg = new Panel();
    this.secGrid = new Panel();
    this.hdrGrid = new Label();
    this.divHdrGrid = new Panel();
    this.bodyGrid = new Panel();
    this.divBotGrid = new Panel();
    this.lblConn = new Label();
    this.pnlRight = new Panel();
    this.btnCalibrateV2 = new Button();
    this.btnTopViewV2 = new Button();
    this.pnlRBorder = new Panel();
    this.lblRHdr = new Label();
    this.pnlRHdrDiv = new Panel();
    this.pnlCoord = new Panel();
    this.lXl = new Label();
    this.lXv = new Label();
    this.lYl = new Label();
    this.lYv = new Label();
    this.lblDragHdr = new Label();
    this.lblArticleHdr = new Label();
    this.pnlTitleBar = new Panel();
    this.btnDistV2 = new Button();
    this.btnDistortion = new Button();
    this.lblCanonControls = new Label();
    this.cboxCamAV = new ComboBox();
    this.cboxCamISO = new ComboBox();
    this.cboxCamTV = new ComboBox();
    this.btnTopView = new Button();
    this.pnlAccentLine = new Panel();
    this.pnlBrand = new Panel();
    this.lblBrandMark = new Label();
    this.lblBrandName = new Label();
    this.pnlBrandBorder = new Panel();
    this.btnMenuDig = new Button();
    this.btnMenuEdge = new Button();
    this.btnMenuCalib = new Button();
    this.btnCancel = new Button();
    this.btnMinimize = new Button();
    this.btnExtend = new Button();
    this.pnlStatusBar = new Panel();
    this.pnlSTop = new Panel();
    this.pnlCapture = new Panel();
    this.pnlExposure = new Panel();
    this.pnlViewMode = new Panel();
    this.pnlBackground = new Panel();
    this.pnlGridOverlay = new Panel();
    this.pnlPreview = new Panel();
    this.pnlLists = new Panel();
    this.pnlCamControl = new Panel();
    this.pnlPboxMode = new Panel();
    this.pnlDigitize = new Panel();
    this.pnlPicturebox = new Panel();
    this.panel1 = new Panel();
    this.lblStretchMethod = new Label();
    this.btnDistV3 = new Button();
    ((ISupportInitialize) this.pboxEdit).BeginInit();
    ((ISupportInitialize) this.numUDGCManExp).BeginInit();
    ((ISupportInitialize) this.numUDGain).BeginInit();
    ((ISupportInitialize) this.numUDExpAutoLow).BeginInit();
    ((ISupportInitialize) this.numUDExpAutoUp).BeginInit();
    ((ISupportInitialize) this.numUDGridX).BeginInit();
    ((ISupportInitialize) this.numUDGridY).BeginInit();
    ((ISupportInitialize) this.numUDGridThick).BeginInit();
    ((ISupportInitialize) this.numUDTLX).BeginInit();
    ((ISupportInitialize) this.numUDTLY).BeginInit();
    ((ISupportInitialize) this.numUDTRX).BeginInit();
    ((ISupportInitialize) this.numUDTRY).BeginInit();
    ((ISupportInitialize) this.numUDBLX).BeginInit();
    ((ISupportInitialize) this.numUDBLY).BeginInit();
    ((ISupportInitialize) this.numUDBRX).BeginInit();
    ((ISupportInitialize) this.numUDBRY).BeginInit();
    ((ISupportInitialize) this.pboxBackColor).BeginInit();
    ((ISupportInitialize) this.pboxPreview1).BeginInit();
    this.pnlLeft.SuspendLayout();
    this.secCam.SuspendLayout();
    this.bodyCam.SuspendLayout();
    this.secExp.SuspendLayout();
    this.bodyExp.SuspendLayout();
    this.boxLow.SuspendLayout();
    this.boxHigh.SuspendLayout();
    this.boxManExp.SuspendLayout();
    this.boxGain.SuspendLayout();
    this.secCap.SuspendLayout();
    this.bodyCap.SuspendLayout();
    this.secView.SuspendLayout();
    this.bodyView.SuspendLayout();
    this.secBg.SuspendLayout();
    this.bodyBg.SuspendLayout();
    this.secGrid.SuspendLayout();
    this.bodyGrid.SuspendLayout();
    this.pnlRight.SuspendLayout();
    this.pnlCoord.SuspendLayout();
    this.pnlTitleBar.SuspendLayout();
    this.pnlBrand.SuspendLayout();
    this.pnlStatusBar.SuspendLayout();
    this.SuspendLayout();
    this.pboxEdit.BackColor = Color.FromArgb(42, 36, 32 /*0x20*/);
    this.pboxEdit.Cursor = Cursors.Cross;
    this.pboxEdit.Dock = DockStyle.Fill;
    this.pboxEdit.Location = new Point(268, 46);
    this.pboxEdit.Name = "pboxEdit";
    this.pboxEdit.Size = new Size(1086, 851);
    this.pboxEdit.SizeMode = PictureBoxSizeMode.Zoom;
    this.pboxEdit.TabIndex = 1;
    this.pboxEdit.TabStop = false;
    this.pboxEdit.SizeChanged += new EventHandler(this.pboxEdit_SizeChanged);
    this.pboxEdit.Paint += new PaintEventHandler(this.pboxEdit_Paint);
    this.pboxEdit.MouseClick += new MouseEventHandler(this.pboxEdit_MouseClick);
    this.pboxEdit.MouseDown += new MouseEventHandler(this.pboxEdit_MouseDown);
    this.pboxEdit.MouseLeave += new EventHandler(this.pboxEdit_MouseLeave);
    this.pboxEdit.MouseMove += new MouseEventHandler(this.pboxEdit_MouseMove);
    this.pboxEdit.MouseUp += new MouseEventHandler(this.pboxEdit_MouseUp);
    this.btnLoad.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.btnLoad.BackColor = Color.FromArgb(20, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
    this.btnLoad.Cursor = Cursors.Hand;
    this.btnLoad.FlatAppearance.BorderColor = Color.FromArgb(35, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
    this.btnLoad.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
    this.btnLoad.FlatStyle = FlatStyle.Flat;
    this.btnLoad.Font = new Font("Segoe UI", 8f);
    this.btnLoad.ForeColor = Color.FromArgb(245, 240 /*0xF0*/, 232);
    this.btnLoad.Location = new Point(912, 8);
    this.btnLoad.Name = "btnLoad";
    this.btnLoad.Size = new Size(78, 28);
    this.btnLoad.TabIndex = 5;
    this.btnLoad.Text = "Load Image";
    this.btnLoad.UseVisualStyleBackColor = false;
    this.btnLoad.Click += new EventHandler(this.btnLoad_Click);
    this.btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.btnSave.BackColor = Color.FromArgb(20, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
    this.btnSave.Cursor = Cursors.Hand;
    this.btnSave.FlatAppearance.BorderColor = Color.FromArgb(35, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
    this.btnSave.FlatStyle = FlatStyle.Flat;
    this.btnSave.Font = new Font("Segoe UI", 9f);
    this.btnSave.ForeColor = Color.FromArgb(240 /*0xF0*/, 168, 107);
    this.btnSave.Location = new Point(2890, 9);
    this.btnSave.Name = "btnSave";
    this.btnSave.Size = new Size(30, 28);
    this.btnSave.TabIndex = 7;
    this.btnSave.UseVisualStyleBackColor = false;
    this.btnSave.Click += new EventHandler(this.btnSave_Click);
    this.btnUndo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.btnUndo.BackColor = Color.FromArgb(20, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
    this.btnUndo.Cursor = Cursors.Hand;
    this.btnUndo.FlatAppearance.BorderColor = Color.FromArgb(35, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
    this.btnUndo.FlatStyle = FlatStyle.Flat;
    this.btnUndo.Font = new Font("Segoe UI", 9f);
    this.btnUndo.ForeColor = Color.FromArgb(184, 173, 154);
    this.btnUndo.Location = new Point(2890, 9);
    this.btnUndo.Name = "btnUndo";
    this.btnUndo.Size = new Size(30, 28);
    this.btnUndo.TabIndex = 8;
    this.btnUndo.UseVisualStyleBackColor = false;
    this.btnUndo.Click += new EventHandler(this.btnUndo_Click);
    this.btnVideoMode.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.btnVideoMode.BackColor = Color.FromArgb(196, 98, 26);
    this.btnVideoMode.Cursor = Cursors.Hand;
    this.btnVideoMode.FlatAppearance.BorderColor = Color.FromArgb(232, 137, 90);
    this.btnVideoMode.FlatStyle = FlatStyle.Flat;
    this.btnVideoMode.Font = new Font("Segoe UI", 8f);
    this.btnVideoMode.ForeColor = Color.White;
    this.btnVideoMode.Location = new Point(2890, 9);
    this.btnVideoMode.Name = "btnVideoMode";
    this.btnVideoMode.Size = new Size(70, 28);
    this.btnVideoMode.TabIndex = 9;
    this.btnVideoMode.Text = "● Video";
    this.btnVideoMode.UseVisualStyleBackColor = false;
    this.btnVideoMode.Click += new EventHandler(this.btnVideoMode_Click);
    this.btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.btnRefresh.BackColor = Color.FromArgb(20, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
    this.btnRefresh.Cursor = Cursors.Hand;
    this.btnRefresh.FlatAppearance.BorderColor = Color.FromArgb(35, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
    this.btnRefresh.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
    this.btnRefresh.FlatStyle = FlatStyle.Flat;
    this.btnRefresh.Font = new Font("Segoe UI", 8f);
    this.btnRefresh.ForeColor = Color.FromArgb(245, 240 /*0xF0*/, 232);
    this.btnRefresh.Location = new Point(2890, 9);
    this.btnRefresh.Name = "btnRefresh";
    this.btnRefresh.Size = new Size(90, 28);
    this.btnRefresh.TabIndex = 6;
    this.btnRefresh.Text = "Refresh Cam";
    this.btnRefresh.UseVisualStyleBackColor = false;
    this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);
    this.btnTakePhoto.BackColor = Color.FromArgb(196, 98, 26);
    this.btnTakePhoto.Cursor = Cursors.Hand;
    this.btnTakePhoto.FlatAppearance.BorderColor = Color.FromArgb(232, 137, 90);
    this.btnTakePhoto.FlatStyle = FlatStyle.Flat;
    this.btnTakePhoto.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
    this.btnTakePhoto.ForeColor = Color.White;
    this.btnTakePhoto.Location = new Point(14, 11);
    this.btnTakePhoto.Name = "btnTakePhoto";
    this.btnTakePhoto.Size = new Size(110, 28);
    this.btnTakePhoto.TabIndex = 0;
    this.btnTakePhoto.Text = "Take Photo";
    this.btnTakePhoto.UseVisualStyleBackColor = false;
    this.btnTakePhoto.Click += new EventHandler(this.btnTakePhoto_Click);
    this.btnCalibDual.BackColor = Color.FromArgb(245, 240 /*0xF0*/, 232);
    this.btnCalibDual.Cursor = Cursors.Hand;
    this.btnCalibDual.FlatAppearance.BorderColor = Color.FromArgb(207, 197, 176 /*0xB0*/);
    this.btnCalibDual.FlatStyle = FlatStyle.Flat;
    this.btnCalibDual.Font = new Font("Segoe UI", 9f);
    this.btnCalibDual.ForeColor = Color.FromArgb(58, 48 /*0x30*/, 40);
    this.btnCalibDual.Location = new Point(132, 11);
    this.btnCalibDual.Name = "btnCalibDual";
    this.btnCalibDual.Size = new Size(110, 28);
    this.btnCalibDual.TabIndex = 1;
    this.btnCalibDual.Text = "Calibrate";
    this.btnCalibDual.UseVisualStyleBackColor = false;
    this.btnCalibDual.Click += new EventHandler(this.btnCalibDual_Click);
    this.btnFindContour.BackColor = Color.FromArgb(245, 240 /*0xF0*/, 232);
    this.btnFindContour.Cursor = Cursors.Hand;
    this.btnFindContour.FlatAppearance.BorderColor = Color.FromArgb(207, 197, 176 /*0xB0*/);
    this.btnFindContour.FlatStyle = FlatStyle.Flat;
    this.btnFindContour.Font = new Font("Segoe UI", 9f);
    this.btnFindContour.ForeColor = Color.FromArgb(58, 48 /*0x30*/, 40);
    this.btnFindContour.Location = new Point(14, 45);
    this.btnFindContour.Name = "btnFindContour";
    this.btnFindContour.Size = new Size(110, 28);
    this.btnFindContour.TabIndex = 2;
    this.btnFindContour.Text = "Find Contour";
    this.btnFindContour.UseVisualStyleBackColor = false;
    this.btnFindContour.Click += new EventHandler(this.btnFindContour_Click);
    this.btnRemoveBack.BackColor = Color.FromArgb(250, 232, 224 /*0xE0*/);
    this.btnRemoveBack.Cursor = Cursors.Hand;
    this.btnRemoveBack.FlatAppearance.BorderColor = Color.FromArgb(245, 196, 179);
    this.btnRemoveBack.FlatStyle = FlatStyle.Flat;
    this.btnRemoveBack.Font = new Font("Segoe UI", 9f);
    this.btnRemoveBack.ForeColor = Color.FromArgb(155, 58, 26);
    this.btnRemoveBack.Location = new Point(132, 45);
    this.btnRemoveBack.Name = "btnRemoveBack";
    this.btnRemoveBack.Size = new Size(110, 28);
    this.btnRemoveBack.TabIndex = 3;
    this.btnRemoveBack.Text = "Remove BG";
    this.btnRemoveBack.UseVisualStyleBackColor = false;
    this.btnRemoveBack.Click += new EventHandler(this.btnRemoveBack_Click);
    this.btnLoadAsDrag.BackColor = Color.FromArgb(245, 240 /*0xF0*/, 232);
    this.btnLoadAsDrag.Cursor = Cursors.Hand;
    this.btnLoadAsDrag.FlatAppearance.BorderColor = Color.FromArgb(207, 197, 176 /*0xB0*/);
    this.btnLoadAsDrag.FlatStyle = FlatStyle.Flat;
    this.btnLoadAsDrag.Font = new Font("Segoe UI", 9f);
    this.btnLoadAsDrag.ForeColor = Color.FromArgb(92, 81, 68);
    this.btnLoadAsDrag.Location = new Point(14, 81);
    this.btnLoadAsDrag.Name = "btnLoadAsDrag";
    this.btnLoadAsDrag.Size = new Size(108, 24);
    this.btnLoadAsDrag.TabIndex = 4;
    this.btnLoadAsDrag.Text = "Load Stretch";
    this.btnLoadAsDrag.UseVisualStyleBackColor = false;
    this.btnLoadAsDrag.Click += new EventHandler(this.btnLoadAsDrag_Click);
    this.btnSaveAsDrag.BackColor = Color.FromArgb(245, 240 /*0xF0*/, 232);
    this.btnSaveAsDrag.Cursor = Cursors.Hand;
    this.btnSaveAsDrag.FlatAppearance.BorderColor = Color.FromArgb(207, 197, 176 /*0xB0*/);
    this.btnSaveAsDrag.FlatStyle = FlatStyle.Flat;
    this.btnSaveAsDrag.Font = new Font("Segoe UI", 9f);
    this.btnSaveAsDrag.ForeColor = Color.FromArgb(92, 81, 68);
    this.btnSaveAsDrag.Location = new Point(132, 81);
    this.btnSaveAsDrag.Name = "btnSaveAsDrag";
    this.btnSaveAsDrag.Size = new Size(108, 24);
    this.btnSaveAsDrag.TabIndex = 5;
    this.btnSaveAsDrag.Text = "Save Stretch";
    this.btnSaveAsDrag.UseVisualStyleBackColor = false;
    this.btnSaveAsDrag.Click += new EventHandler(this.btnSaveAsDrag_Click);
    this.btnLoadAsArticle.BackColor = Color.FromArgb(245, 240 /*0xF0*/, 232);
    this.btnLoadAsArticle.Cursor = Cursors.Hand;
    this.btnLoadAsArticle.FlatAppearance.BorderColor = Color.FromArgb(207, 197, 176 /*0xB0*/);
    this.btnLoadAsArticle.FlatStyle = FlatStyle.Flat;
    this.btnLoadAsArticle.Font = new Font("Segoe UI", 9f);
    this.btnLoadAsArticle.ForeColor = Color.FromArgb(92, 81, 68);
    this.btnLoadAsArticle.Location = new Point(14, 111);
    this.btnLoadAsArticle.Name = "btnLoadAsArticle";
    this.btnLoadAsArticle.Size = new Size(108, 24);
    this.btnLoadAsArticle.TabIndex = 6;
    this.btnLoadAsArticle.Text = "Load Article";
    this.btnLoadAsArticle.UseVisualStyleBackColor = false;
    this.btnLoadAsArticle.Click += new EventHandler(this.btnLoadAsArticle_Click);
    this.btnSaveAsArticle.BackColor = Color.FromArgb(245, 240 /*0xF0*/, 232);
    this.btnSaveAsArticle.Cursor = Cursors.Hand;
    this.btnSaveAsArticle.FlatAppearance.BorderColor = Color.FromArgb(207, 197, 176 /*0xB0*/);
    this.btnSaveAsArticle.FlatStyle = FlatStyle.Flat;
    this.btnSaveAsArticle.Font = new Font("Segoe UI", 9f);
    this.btnSaveAsArticle.ForeColor = Color.FromArgb(92, 81, 68);
    this.btnSaveAsArticle.Location = new Point(132, 111);
    this.btnSaveAsArticle.Name = "btnSaveAsArticle";
    this.btnSaveAsArticle.Size = new Size(108, 24);
    this.btnSaveAsArticle.TabIndex = 7;
    this.btnSaveAsArticle.Text = "Save Article";
    this.btnSaveAsArticle.UseVisualStyleBackColor = false;
    this.btnSaveAsArticle.Click += new EventHandler(this.btnSaveAsArticle_Click);
    this.btnResetMarker.BackColor = Color.FromArgb(245, 240 /*0xF0*/, 232);
    this.btnResetMarker.Cursor = Cursors.Hand;
    this.btnResetMarker.FlatAppearance.BorderColor = Color.FromArgb(207, 197, 176 /*0xB0*/);
    this.btnResetMarker.FlatStyle = FlatStyle.Flat;
    this.btnResetMarker.Font = new Font("Segoe UI", 9f);
    this.btnResetMarker.ForeColor = Color.FromArgb(92, 81, 68);
    this.btnResetMarker.Location = new Point(14, 44);
    this.btnResetMarker.Name = "btnResetMarker";
    this.btnResetMarker.Size = new Size(72, 47);
    this.btnResetMarker.TabIndex = 2;
    this.btnResetMarker.Text = "Reset Marker";
    this.btnResetMarker.UseVisualStyleBackColor = false;
    this.btnResetMarker.Click += new EventHandler(this.btnResetMarker_Click);
    this.btnResetDrag.BackColor = Color.FromArgb(245, 240 /*0xF0*/, 232);
    this.btnResetDrag.Cursor = Cursors.Hand;
    this.btnResetDrag.FlatAppearance.BorderColor = Color.FromArgb(207, 197, 176 /*0xB0*/);
    this.btnResetDrag.FlatStyle = FlatStyle.Flat;
    this.btnResetDrag.Font = new Font("Segoe UI", 9f);
    this.btnResetDrag.ForeColor = Color.FromArgb(92, 81, 68);
    this.btnResetDrag.Location = new Point(92, 44);
    this.btnResetDrag.Name = "btnResetDrag";
    this.btnResetDrag.Size = new Size(72, 47);
    this.btnResetDrag.TabIndex = 3;
    this.btnResetDrag.Text = "Reset Stretch";
    this.btnResetDrag.UseVisualStyleBackColor = false;
    this.btnResetDrag.Click += new EventHandler(this.btnResetDrag_Click);
    this.btnResetImage.BackColor = Color.FromArgb(245, 240 /*0xF0*/, 232);
    this.btnResetImage.Cursor = Cursors.Hand;
    this.btnResetImage.FlatAppearance.BorderColor = Color.FromArgb(207, 197, 176 /*0xB0*/);
    this.btnResetImage.FlatStyle = FlatStyle.Flat;
    this.btnResetImage.Font = new Font("Segoe UI", 9f);
    this.btnResetImage.ForeColor = Color.FromArgb(92, 81, 68);
    this.btnResetImage.Location = new Point(170, 44);
    this.btnResetImage.Name = "btnResetImage";
    this.btnResetImage.Size = new Size(72, 47);
    this.btnResetImage.TabIndex = 4;
    this.btnResetImage.Text = "Reset Image";
    this.btnResetImage.UseVisualStyleBackColor = false;
    this.btnResetImage.Click += new EventHandler(this.btnResetImage_Click);
    this.btnGridColor.BackColor = Color.FromArgb(245, 240 /*0xF0*/, 232);
    this.btnGridColor.Cursor = Cursors.Hand;
    this.btnGridColor.FlatAppearance.BorderColor = Color.FromArgb(207, 197, 176 /*0xB0*/);
    this.btnGridColor.FlatStyle = FlatStyle.Flat;
    this.btnGridColor.Font = new Font("Segoe UI", 9f);
    this.btnGridColor.ForeColor = Color.FromArgb(92, 81, 68);
    this.btnGridColor.Location = new Point(166, 9);
    this.btnGridColor.Name = "btnGridColor";
    this.btnGridColor.Size = new Size(84, 22);
    this.btnGridColor.TabIndex = 1;
    this.btnGridColor.Text = "Grid Color";
    this.btnGridColor.UseVisualStyleBackColor = false;
    this.btnGridColor.Click += new EventHandler(this.btnGridColor_Click);
    this.btnSavePre1.BackColor = Color.FromArgb(245, 240 /*0xF0*/, 232);
    this.btnSavePre1.Cursor = Cursors.Hand;
    this.btnSavePre1.FlatAppearance.BorderColor = Color.FromArgb(207, 197, 176 /*0xB0*/);
    this.btnSavePre1.FlatStyle = FlatStyle.Flat;
    this.btnSavePre1.Font = new Font("Segoe UI", 9f);
    this.btnSavePre1.ForeColor = Color.FromArgb(58, 48 /*0x30*/, 40);
    this.btnSavePre1.Location = new Point(10, 164);
    this.btnSavePre1.Name = "btnSavePre1";
    this.btnSavePre1.Size = new Size(176 /*0xB0*/, 24);
    this.btnSavePre1.TabIndex = 4;
    this.btnSavePre1.Text = "Save Preview";
    this.btnSavePre1.UseVisualStyleBackColor = false;
    this.btnSavePre1.Click += new EventHandler(this.btnSavePre1_Click);
    this.btnLoadPre1.BackColor = Color.FromArgb(245, 240 /*0xF0*/, 232);
    this.btnLoadPre1.Cursor = Cursors.Hand;
    this.btnLoadPre1.FlatAppearance.BorderColor = Color.FromArgb(207, 197, 176 /*0xB0*/);
    this.btnLoadPre1.FlatStyle = FlatStyle.Flat;
    this.btnLoadPre1.Font = new Font("Segoe UI", 9f);
    this.btnLoadPre1.ForeColor = Color.FromArgb(58, 48 /*0x30*/, 40);
    this.btnLoadPre1.Location = new Point(10, 194);
    this.btnLoadPre1.Name = "btnLoadPre1";
    this.btnLoadPre1.Size = new Size(176 /*0xB0*/, 24);
    this.btnLoadPre1.TabIndex = 5;
    this.btnLoadPre1.Text = "Load Preview";
    this.btnLoadPre1.UseVisualStyleBackColor = false;
    this.btnLoadPre1.Click += new EventHandler(this.btnLoadPre1_Click);
    this.btnTabCanon.BackColor = Color.FromArgb(226, 217, 200);
    this.btnTabCanon.Cursor = Cursors.Hand;
    this.btnTabCanon.FlatAppearance.BorderColor = Color.FromArgb(207, 197, 176 /*0xB0*/);
    this.btnTabCanon.FlatStyle = FlatStyle.Flat;
    this.btnTabCanon.Font = new Font("Segoe UI", 8.25f);
    this.btnTabCanon.ForeColor = Color.FromArgb(92, 81, 68);
    this.btnTabCanon.Location = new Point(91, 12);
    this.btnTabCanon.Name = "btnTabCanon";
    this.btnTabCanon.Size = new Size(71, 26);
    this.btnTabCanon.TabIndex = 1;
    this.btnTabCanon.Text = "Canon";
    this.btnTabCanon.UseVisualStyleBackColor = false;
    this.btnTabCanon.Click += new EventHandler(this.btnTabCanon_Click);
    this.btnTabGencam.BackColor = Color.FromArgb(245, 240 /*0xF0*/, 232);
    this.btnTabGencam.Cursor = Cursors.Hand;
    this.btnTabGencam.FlatAppearance.BorderColor = Color.FromArgb(232, 137, 90);
    this.btnTabGencam.FlatStyle = FlatStyle.Flat;
    this.btnTabGencam.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.btnTabGencam.ForeColor = Color.FromArgb(196, 98, 26);
    this.btnTabGencam.Location = new Point(14, 12);
    this.btnTabGencam.Name = "btnTabGencam";
    this.btnTabGencam.Size = new Size(71, 26);
    this.btnTabGencam.TabIndex = 0;
    this.btnTabGencam.Text = "GenCam";
    this.btnTabGencam.UseVisualStyleBackColor = false;
    this.btnTabGencam.Click += new EventHandler(this.btnTabGencam_Click);
    this.btnHardReset.BackColor = Color.FromArgb((int) byte.MaxValue, 232, 224 /*0xE0*/);
    this.btnHardReset.Cursor = Cursors.Hand;
    this.btnHardReset.FlatAppearance.BorderColor = Color.FromArgb(180, 58, 26);
    this.btnHardReset.FlatStyle = FlatStyle.Flat;
    this.btnHardReset.Font = new Font("Segoe UI", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.btnHardReset.ForeColor = Color.FromArgb(180, 58, 26);
    this.btnHardReset.Location = new Point(14, 47);
    this.btnHardReset.Name = "btnHardReset";
    this.btnHardReset.Size = new Size(107, 26);
    this.btnHardReset.TabIndex = 3;
    this.btnHardReset.Text = "Hard reset";
    this.btnHardReset.UseVisualStyleBackColor = false;
    this.btnHardReset.Click += new EventHandler(this.btnHardReset_Click);
    this.btnSwitchGencam.BackColor = Color.FromArgb(226, 217, 200);
    this.btnSwitchGencam.Cursor = Cursors.Hand;
    this.btnSwitchGencam.FlatAppearance.BorderColor = Color.FromArgb(207, 197, 176 /*0xB0*/);
    this.btnSwitchGencam.FlatStyle = FlatStyle.Flat;
    this.btnSwitchGencam.Font = new Font("Segoe UI", 8.25f);
    this.btnSwitchGencam.ForeColor = Color.FromArgb(92, 81, 68);
    this.btnSwitchGencam.Location = new Point(168, 12);
    this.btnSwitchGencam.Name = "btnSwitchGencam";
    this.btnSwitchGencam.Size = new Size(71, 26);
    this.btnSwitchGencam.TabIndex = 2;
    this.btnSwitchGencam.Text = "Webcam";
    this.btnSwitchGencam.UseVisualStyleBackColor = false;
    this.btnSwitchGencam.Click += new EventHandler(this.btnSwitchGencam_Click);
    this.btnLockIP.BackColor = Color.FromArgb(237, 231, 217);
    this.btnLockIP.Cursor = Cursors.Hand;
    this.btnLockIP.FlatAppearance.BorderColor = Color.FromArgb(207, 197, 176 /*0xB0*/);
    this.btnLockIP.FlatStyle = FlatStyle.Flat;
    this.btnLockIP.Font = new Font("Segoe UI", 9f);
    this.btnLockIP.ForeColor = Color.FromArgb(140, (int) sbyte.MaxValue, 110);
    this.btnLockIP.Location = new Point(128 /*0x80*/, 47);
    this.btnLockIP.Name = "btnLockIP";
    this.btnLockIP.Size = new Size(107, 26);
    this.btnLockIP.TabIndex = 4;
    this.btnLockIP.Text = "Lock IP";
    this.btnLockIP.UseVisualStyleBackColor = false;
    this.btnLockIP.Click += new EventHandler(this.btnLockIP_Click);
    this.btnTabEdge.Location = new Point(0, 0);
    this.btnTabEdge.Name = "btnTabEdge";
    this.btnTabEdge.Size = new Size(75, 23);
    this.btnTabEdge.TabIndex = 16 /*0x10*/;
    this.btnTabEdge.Visible = false;
    this.numUDGCManExp.BackColor = Color.FromArgb(245, 240 /*0xF0*/, 232);
    this.numUDGCManExp.BorderStyle = BorderStyle.None;
    this.numUDGCManExp.Font = new Font("Consolas", 9f, FontStyle.Bold);
    this.numUDGCManExp.ForeColor = Color.FromArgb(34, 28, 20);
    this.numUDGCManExp.Location = new Point(4, 4);
    this.numUDGCManExp.Maximum = new Decimal(new int[4]
    {
      2300000,
      0,
      0,
      0
    });
    this.numUDGCManExp.Name = "numUDGCManExp";
    this.numUDGCManExp.Size = new Size(96 /*0x60*/, 18);
    this.numUDGCManExp.TabIndex = 0;
    this.numUDGCManExp.Value = new Decimal(new int[4]
    {
      1000000,
      0,
      0,
      0
    });
    this.numUDGain.BackColor = Color.FromArgb(245, 240 /*0xF0*/, 232);
    this.numUDGain.BorderStyle = BorderStyle.None;
    this.numUDGain.Font = new Font("Consolas", 9f, FontStyle.Bold);
    this.numUDGain.ForeColor = Color.FromArgb(34, 28, 20);
    this.numUDGain.Location = new Point(4, 4);
    this.numUDGain.Maximum = new Decimal(new int[4]
    {
      25,
      0,
      0,
      0
    });
    this.numUDGain.Name = "numUDGain";
    this.numUDGain.Size = new Size(96 /*0x60*/, 18);
    this.numUDGain.TabIndex = 0;
    this.numUDExpAutoLow.BackColor = Color.FromArgb(245, 240 /*0xF0*/, 232);
    this.numUDExpAutoLow.BorderStyle = BorderStyle.None;
    this.numUDExpAutoLow.Font = new Font("Consolas", 9f, FontStyle.Bold);
    this.numUDExpAutoLow.ForeColor = Color.FromArgb(34, 28, 20);
    this.numUDExpAutoLow.Location = new Point(4, 5);
    this.numUDExpAutoLow.Maximum = new Decimal(new int[4]
    {
      10000000,
      0,
      0,
      0
    });
    this.numUDExpAutoLow.Minimum = new Decimal(new int[4]
    {
      19,
      0,
      0,
      0
    });
    this.numUDExpAutoLow.Name = "numUDExpAutoLow";
    this.numUDExpAutoLow.Size = new Size(96 /*0x60*/, 18);
    this.numUDExpAutoLow.TabIndex = 0;
    this.numUDExpAutoLow.Value = new Decimal(new int[4]
    {
      10000,
      0,
      0,
      0
    });
    this.numUDExpAutoUp.BackColor = Color.FromArgb(245, 240 /*0xF0*/, 232);
    this.numUDExpAutoUp.BorderStyle = BorderStyle.None;
    this.numUDExpAutoUp.Font = new Font("Consolas", 9f, FontStyle.Bold);
    this.numUDExpAutoUp.ForeColor = Color.FromArgb(34, 28, 20);
    this.numUDExpAutoUp.Location = new Point(4, 5);
    this.numUDExpAutoUp.Maximum = new Decimal(new int[4]
    {
      1000000,
      0,
      0,
      0
    });
    this.numUDExpAutoUp.Minimum = new Decimal(new int[4]
    {
      1,
      0,
      0,
      0
    });
    this.numUDExpAutoUp.Name = "numUDExpAutoUp";
    this.numUDExpAutoUp.Size = new Size(96 /*0x60*/, 18);
    this.numUDExpAutoUp.TabIndex = 0;
    this.numUDExpAutoUp.Value = new Decimal(new int[4]
    {
      1000000,
      0,
      0,
      0
    });
    this.numUDGridX.BackColor = Color.FromArgb(245, 240 /*0xF0*/, 232);
    this.numUDGridX.BorderStyle = BorderStyle.None;
    this.numUDGridX.Font = new Font("Consolas", 9f, FontStyle.Bold);
    this.numUDGridX.ForeColor = Color.FromArgb(34, 28, 20);
    this.numUDGridX.Location = new Point(14, 55);
    this.numUDGridX.Name = "numUDGridX";
    this.numUDGridX.Size = new Size(68, 18);
    this.numUDGridX.TabIndex = 5;
    this.numUDGridX.Value = new Decimal(new int[4]
    {
      11,
      0,
      0,
      0
    });
    this.numUDGridX.ValueChanged += new EventHandler(this.GridValueChanged);
    this.numUDGridY.BackColor = Color.FromArgb(245, 240 /*0xF0*/, 232);
    this.numUDGridY.BorderStyle = BorderStyle.None;
    this.numUDGridY.Font = new Font("Consolas", 9f, FontStyle.Bold);
    this.numUDGridY.ForeColor = Color.FromArgb(34, 28, 20);
    this.numUDGridY.Location = new Point(94, 55);
    this.numUDGridY.Name = "numUDGridY";
    this.numUDGridY.Size = new Size(68, 18);
    this.numUDGridY.TabIndex = 6;
    this.numUDGridY.Value = new Decimal(new int[4]
    {
      11,
      0,
      0,
      0
    });
    this.numUDGridY.ValueChanged += new EventHandler(this.GridValueChanged);
    this.numUDGridThick.BackColor = Color.FromArgb(245, 240 /*0xF0*/, 232);
    this.numUDGridThick.BorderStyle = BorderStyle.None;
    this.numUDGridThick.Font = new Font("Consolas", 9f, FontStyle.Bold);
    this.numUDGridThick.ForeColor = Color.FromArgb(34, 28, 20);
    this.numUDGridThick.Location = new Point(172, 55);
    this.numUDGridThick.Name = "numUDGridThick";
    this.numUDGridThick.Size = new Size(68, 18);
    this.numUDGridThick.TabIndex = 7;
    this.numUDGridThick.Value = new Decimal(new int[4]
    {
      2,
      0,
      0,
      0
    });
    this.numUDGridThick.ValueChanged += new EventHandler(this.GridValueChanged);
    this.numUDTLX.BackColor = Color.FromArgb(30, 27, 24);
    this.numUDTLX.BorderStyle = BorderStyle.None;
    this.numUDTLX.Font = new Font("Consolas", 9f);
    this.numUDTLX.ForeColor = Color.FromArgb(240 /*0xF0*/, 168, 107);
    this.numUDTLX.Location = new Point(285, 56);
    this.numUDTLX.Maximum = new Decimal(new int[4]
    {
      20000,
      0,
      0,
      0
    });
    this.numUDTLX.Minimum = new Decimal(new int[4]
    {
      20000,
      0,
      0,
      int.MinValue
    });
    this.numUDTLX.Name = "numUDTLX";
    this.numUDTLX.Size = new Size(62, 18);
    this.numUDTLX.TabIndex = 6;
    this.numUDTLX.ValueChanged += new EventHandler(this.numUDStretch_ValueChanged);
    this.numUDTLY.BackColor = Color.FromArgb(30, 27, 24);
    this.numUDTLY.BorderStyle = BorderStyle.None;
    this.numUDTLY.Font = new Font("Consolas", 9f);
    this.numUDTLY.ForeColor = Color.FromArgb(240 /*0xF0*/, 168, 107);
    this.numUDTLY.Location = new Point(351, 56);
    this.numUDTLY.Maximum = new Decimal(new int[4]
    {
      20000,
      0,
      0,
      0
    });
    this.numUDTLY.Minimum = new Decimal(new int[4]
    {
      20000,
      0,
      0,
      int.MinValue
    });
    this.numUDTLY.Name = "numUDTLY";
    this.numUDTLY.Size = new Size(62, 18);
    this.numUDTLY.TabIndex = 7;
    this.numUDTLY.ValueChanged += new EventHandler(this.numUDStretch_ValueChanged);
    this.numUDTRX.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.numUDTRX.BackColor = Color.FromArgb(30, 27, 24);
    this.numUDTRX.BorderStyle = BorderStyle.None;
    this.numUDTRX.Font = new Font("Consolas", 9f);
    this.numUDTRX.ForeColor = Color.FromArgb(240 /*0xF0*/, 168, 107);
    this.numUDTRX.Location = new Point(1130, 56);
    this.numUDTRX.Maximum = new Decimal(new int[4]
    {
      20000,
      0,
      0,
      0
    });
    this.numUDTRX.Minimum = new Decimal(new int[4]
    {
      20000,
      0,
      0,
      int.MinValue
    });
    this.numUDTRX.Name = "numUDTRX";
    this.numUDTRX.Size = new Size(62, 18);
    this.numUDTRX.TabIndex = 8;
    this.numUDTRX.ValueChanged += new EventHandler(this.numUDStretch_ValueChanged);
    this.numUDTRY.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.numUDTRY.BackColor = Color.FromArgb(30, 27, 24);
    this.numUDTRY.BorderStyle = BorderStyle.None;
    this.numUDTRY.Font = new Font("Consolas", 9f);
    this.numUDTRY.ForeColor = Color.FromArgb(240 /*0xF0*/, 168, 107);
    this.numUDTRY.Location = new Point(1196, 56);
    this.numUDTRY.Maximum = new Decimal(new int[4]
    {
      20000,
      0,
      0,
      0
    });
    this.numUDTRY.Minimum = new Decimal(new int[4]
    {
      20000,
      0,
      0,
      int.MinValue
    });
    this.numUDTRY.Name = "numUDTRY";
    this.numUDTRY.Size = new Size(62, 18);
    this.numUDTRY.TabIndex = 9;
    this.numUDTRY.ValueChanged += new EventHandler(this.numUDStretch_ValueChanged);
    this.numUDBLX.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
    this.numUDBLX.BackColor = Color.FromArgb(30, 27, 24);
    this.numUDBLX.BorderStyle = BorderStyle.None;
    this.numUDBLX.Font = new Font("Consolas", 9f);
    this.numUDBLX.ForeColor = Color.FromArgb(240 /*0xF0*/, 168, 107);
    this.numUDBLX.Location = new Point(285, 855);
    this.numUDBLX.Maximum = new Decimal(new int[4]
    {
      20000,
      0,
      0,
      0
    });
    this.numUDBLX.Minimum = new Decimal(new int[4]
    {
      20000,
      0,
      0,
      int.MinValue
    });
    this.numUDBLX.Name = "numUDBLX";
    this.numUDBLX.Size = new Size(62, 18);
    this.numUDBLX.TabIndex = 10;
    this.numUDBLX.ValueChanged += new EventHandler(this.numUDStretch_ValueChanged);
    this.numUDBLY.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
    this.numUDBLY.BackColor = Color.FromArgb(30, 27, 24);
    this.numUDBLY.BorderStyle = BorderStyle.None;
    this.numUDBLY.Font = new Font("Consolas", 9f);
    this.numUDBLY.ForeColor = Color.FromArgb(240 /*0xF0*/, 168, 107);
    this.numUDBLY.Location = new Point(351, 855);
    this.numUDBLY.Maximum = new Decimal(new int[4]
    {
      20000,
      0,
      0,
      0
    });
    this.numUDBLY.Minimum = new Decimal(new int[4]
    {
      20000,
      0,
      0,
      int.MinValue
    });
    this.numUDBLY.Name = "numUDBLY";
    this.numUDBLY.Size = new Size(62, 18);
    this.numUDBLY.TabIndex = 11;
    this.numUDBLY.ValueChanged += new EventHandler(this.numUDStretch_ValueChanged);
    this.numUDBRX.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
    this.numUDBRX.BackColor = Color.FromArgb(30, 27, 24);
    this.numUDBRX.BorderStyle = BorderStyle.None;
    this.numUDBRX.Font = new Font("Consolas", 9f);
    this.numUDBRX.ForeColor = Color.FromArgb(240 /*0xF0*/, 168, 107);
    this.numUDBRX.Location = new Point(1130, 855);
    this.numUDBRX.Maximum = new Decimal(new int[4]
    {
      20000,
      0,
      0,
      0
    });
    this.numUDBRX.Minimum = new Decimal(new int[4]
    {
      20000,
      0,
      0,
      int.MinValue
    });
    this.numUDBRX.Name = "numUDBRX";
    this.numUDBRX.Size = new Size(62, 18);
    this.numUDBRX.TabIndex = 12;
    this.numUDBRX.ValueChanged += new EventHandler(this.numUDStretch_ValueChanged);
    this.numUDBRY.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
    this.numUDBRY.BackColor = Color.FromArgb(30, 27, 24);
    this.numUDBRY.BorderStyle = BorderStyle.None;
    this.numUDBRY.Font = new Font("Consolas", 9f);
    this.numUDBRY.ForeColor = Color.FromArgb(240 /*0xF0*/, 168, 107);
    this.numUDBRY.Location = new Point(1196, 855);
    this.numUDBRY.Maximum = new Decimal(new int[4]
    {
      20000,
      0,
      0,
      0
    });
    this.numUDBRY.Minimum = new Decimal(new int[4]
    {
      20000,
      0,
      0,
      int.MinValue
    });
    this.numUDBRY.Name = "numUDBRY";
    this.numUDBRY.Size = new Size(62, 18);
    this.numUDBRY.TabIndex = 13;
    this.numUDBRY.ValueChanged += new EventHandler(this.numUDStretch_ValueChanged);
    this.lblExposure.AutoSize = true;
    this.lblExposure.Font = new Font("Segoe UI", 9f);
    this.lblExposure.ForeColor = Color.FromArgb(92, 81, 68);
    this.lblExposure.Location = new Point(14, 91);
    this.lblExposure.Name = "lblExposure";
    this.lblExposure.Size = new Size(71, 15);
    this.lblExposure.TabIndex = 5;
    this.lblExposure.Text = "Manual exp.";
    this.lblGain.AutoSize = true;
    this.lblGain.Font = new Font("Segoe UI", 9f);
    this.lblGain.ForeColor = Color.FromArgb(92, 81, 68);
    this.lblGain.Location = new Point(14, 123);
    this.lblGain.Name = "lblGain";
    this.lblGain.Size = new Size(31 /*0x1F*/, 15);
    this.lblGain.TabIndex = 7;
    this.lblGain.Text = "Gain";
    this.lblLowLimit.AutoSize = true;
    this.lblLowLimit.Font = new Font("Segoe UI", 7.5f);
    this.lblLowLimit.ForeColor = Color.FromArgb(184, 173, 154);
    this.lblLowLimit.Location = new Point(14, 39);
    this.lblLowLimit.Name = "lblLowLimit";
    this.lblLowLimit.Size = new Size(52, 12);
    this.lblLowLimit.TabIndex = 1;
    this.lblLowLimit.Text = "Lower limit";
    this.lblUpLimit.AutoSize = true;
    this.lblUpLimit.Font = new Font("Segoe UI", 7.5f);
    this.lblUpLimit.ForeColor = Color.FromArgb(184, 173, 154);
    this.lblUpLimit.Location = new Point(130, 39);
    this.lblUpLimit.Name = "lblUpLimit";
    this.lblUpLimit.Size = new Size(53, 12);
    this.lblUpLimit.TabIndex = 2;
    this.lblUpLimit.Text = "Upper limit";
    this.lblCoordX.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.lblCoordX.AutoSize = true;
    this.lblCoordX.BackColor = Color.Transparent;
    this.lblCoordX.Font = new Font("Consolas", 9f);
    this.lblCoordX.ForeColor = Color.FromArgb(240 /*0xF0*/, 168, 107);
    this.lblCoordX.Location = new Point(1300, 5);
    this.lblCoordX.Name = "lblCoordX";
    this.lblCoordX.Size = new Size(35, 14);
    this.lblCoordX.TabIndex = 4;
    this.lblCoordX.Text = "X: —";
    this.lblCoordX.Visible = false;
    this.lblCoordY.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.lblCoordY.AutoSize = true;
    this.lblCoordY.BackColor = Color.Transparent;
    this.lblCoordY.Font = new Font("Consolas", 9f);
    this.lblCoordY.ForeColor = Color.FromArgb(240 /*0xF0*/, 168, 107);
    this.lblCoordY.Location = new Point(1350, 5);
    this.lblCoordY.Name = "lblCoordY";
    this.lblCoordY.Size = new Size(35, 14);
    this.lblCoordY.TabIndex = 5;
    this.lblCoordY.Text = "Y: —";
    this.lblCoordY.Visible = false;
    this.lblBackColor.AutoSize = true;
    this.lblBackColor.Font = new Font("Segoe UI", 9f);
    this.lblBackColor.ForeColor = Color.FromArgb(92, 81, 68);
    this.lblBackColor.Location = new Point(50, 12);
    this.lblBackColor.Name = "lblBackColor";
    this.lblBackColor.Size = new Size(83, 15);
    this.lblBackColor.TabIndex = 0;
    this.lblBackColor.Text = "Removal color";
    this.lblPboxMode.Location = new Point(0, 0);
    this.lblPboxMode.Name = "lblPboxMode";
    this.lblPboxMode.Size = new Size(100, 23);
    this.lblPboxMode.TabIndex = 0;
    this.lblGridThick.AutoSize = true;
    this.lblGridThick.Font = new Font("Segoe UI", 7.5f);
    this.lblGridThick.ForeColor = Color.FromArgb(184, 173, 154);
    this.lblGridThick.Location = new Point(172, 41);
    this.lblGridThick.Name = "lblGridThick";
    this.lblGridThick.Size = new Size(47, 12);
    this.lblGridThick.TabIndex = 4;
    this.lblGridThick.Text = "Thickness";
    this.label5.AutoSize = true;
    this.label5.Font = new Font("Segoe UI", 7.5f);
    this.label5.ForeColor = Color.FromArgb(184, 173, 154);
    this.label5.Location = new Point(14, 41);
    this.label5.Name = "label5";
    this.label5.Size = new Size(32 /*0x20*/, 12);
    this.label5.TabIndex = 2;
    this.label5.Text = "Grid X";
    this.label6.AutoSize = true;
    this.label6.Font = new Font("Segoe UI", 7.5f);
    this.label6.ForeColor = Color.FromArgb(184, 173, 154);
    this.label6.Location = new Point(94, 41);
    this.label6.Name = "label6";
    this.label6.Size = new Size(32 /*0x20*/, 12);
    this.label6.TabIndex = 3;
    this.label6.Text = "Grid Y";
    this.lblAV.Location = new Point(0, 0);
    this.lblAV.Name = "lblAV";
    this.lblAV.Size = new Size(100, 23);
    this.lblAV.TabIndex = 0;
    this.lblISO.Location = new Point(0, 0);
    this.lblISO.Name = "lblISO";
    this.lblISO.Size = new Size(100, 23);
    this.lblISO.TabIndex = 0;
    this.lblTV.Location = new Point(0, 0);
    this.lblTV.Name = "lblTV";
    this.lblTV.Size = new Size(100, 23);
    this.lblTV.TabIndex = 0;
    this.lblSecCamera.Location = new Point(0, 0);
    this.lblSecCamera.Name = "lblSecCamera";
    this.lblSecCamera.Size = new Size(100, 23);
    this.lblSecCamera.TabIndex = 0;
    this.lblSecExposure.Location = new Point(0, 0);
    this.lblSecExposure.Name = "lblSecExposure";
    this.lblSecExposure.Size = new Size(100, 23);
    this.lblSecExposure.TabIndex = 0;
    this.lblSecCapture.Location = new Point(0, 0);
    this.lblSecCapture.Name = "lblSecCapture";
    this.lblSecCapture.Size = new Size(100, 23);
    this.lblSecCapture.TabIndex = 0;
    this.lblSecViewMode.Location = new Point(0, 0);
    this.lblSecViewMode.Name = "lblSecViewMode";
    this.lblSecViewMode.Size = new Size(100, 23);
    this.lblSecViewMode.TabIndex = 0;
    this.lblSecBgColor.Location = new Point(0, 0);
    this.lblSecBgColor.Name = "lblSecBgColor";
    this.lblSecBgColor.Size = new Size(100, 23);
    this.lblSecBgColor.TabIndex = 0;
    this.lblSecGrid.Location = new Point(0, 0);
    this.lblSecGrid.Name = "lblSecGrid";
    this.lblSecGrid.Size = new Size(100, 23);
    this.lblSecGrid.TabIndex = 0;
    this.lblCamStatus.AutoSize = true;
    this.lblCamStatus.BackColor = Color.Transparent;
    this.lblCamStatus.Font = new Font("Consolas", 9f);
    this.lblCamStatus.ForeColor = Color.FromArgb(39, 201, 63 /*0x3F*/);
    this.lblCamStatus.Location = new Point(12, 5);
    this.lblCamStatus.Name = "lblCamStatus";
    this.lblCamStatus.Size = new Size(112 /*0x70*/, 14);
    this.lblCamStatus.TabIndex = 1;
    this.lblCamStatus.Text = "● GenCam active";
    this.lblScaleInfo.AutoSize = true;
    this.lblScaleInfo.BackColor = Color.Transparent;
    this.lblScaleInfo.Font = new Font("Consolas", 9f);
    this.lblScaleInfo.ForeColor = Color.FromArgb(140, (int) sbyte.MaxValue, 110);
    this.lblScaleInfo.Location = new Point(165, 5);
    this.lblScaleInfo.Name = "lblScaleInfo";
    this.lblScaleInfo.Size = new Size(105, 14);
    this.lblScaleInfo.TabIndex = 2;
    this.lblScaleInfo.Text = "1 px = 1.00 mm";
    this.lblZoom.AutoSize = true;
    this.lblZoom.BackColor = Color.Transparent;
    this.lblZoom.Font = new Font("Consolas", 9f);
    this.lblZoom.ForeColor = Color.FromArgb(140, (int) sbyte.MaxValue, 110);
    this.lblZoom.Location = new Point(310, 5);
    this.lblZoom.Name = "lblZoom";
    this.lblZoom.Size = new Size(35, 14);
    this.lblZoom.TabIndex = 3;
    this.lblZoom.Text = "100%";
    this.cboxExpAuto.AutoSize = true;
    this.cboxExpAuto.BackColor = Color.Transparent;
    this.cboxExpAuto.Font = new Font("Segoe UI", 9f);
    this.cboxExpAuto.ForeColor = Color.FromArgb(92, 81, 68);
    this.cboxExpAuto.Location = new Point(14, 10);
    this.cboxExpAuto.Name = "cboxExpAuto";
    this.cboxExpAuto.Size = new Size(102, 19);
    this.cboxExpAuto.TabIndex = 0;
    this.cboxExpAuto.Text = "Auto exposure";
    this.cboxExpAuto.UseVisualStyleBackColor = false;
    this.cbGrid.AutoSize = true;
    this.cbGrid.BackColor = Color.Transparent;
    this.cbGrid.Font = new Font("Segoe UI", 9f);
    this.cbGrid.ForeColor = Color.FromArgb(92, 81, 68);
    this.cbGrid.Location = new Point(14, 11);
    this.cbGrid.Name = "cbGrid";
    this.cbGrid.Size = new Size(79, 19);
    this.cbGrid.TabIndex = 0;
    this.cbGrid.Text = "Show grid";
    this.cbGrid.UseVisualStyleBackColor = false;
    this.tabControlAllCams.Location = new Point(0, 0);
    this.tabControlAllCams.Name = "tabControlAllCams";
    this.tabControlAllCams.SelectedIndex = 0;
    this.tabControlAllCams.Size = new Size(200, 100);
    this.tabControlAllCams.TabIndex = 17;
    this.tabControlAllCams.Visible = false;
    this.tabGenCam.Location = new Point(0, 0);
    this.tabGenCam.Name = "tabGenCam";
    this.tabGenCam.Size = new Size(200, 100);
    this.tabGenCam.TabIndex = 0;
    this.tabCanon.Location = new Point(0, 0);
    this.tabCanon.Name = "tabCanon";
    this.tabCanon.Size = new Size(200, 100);
    this.tabCanon.TabIndex = 0;
    this.tabWebcam.Location = new Point(0, 0);
    this.tabWebcam.Name = "tabWebcam";
    this.tabWebcam.Size = new Size(200, 100);
    this.tabWebcam.TabIndex = 0;
    this.rbPan.Appearance = Appearance.Button;
    this.rbPan.BackColor = Color.FromArgb(245, 240 /*0xF0*/, 232);
    this.rbPan.Checked = true;
    this.rbPan.Cursor = Cursors.Hand;
    this.rbPan.FlatAppearance.BorderColor = Color.FromArgb(226, 217, 200);
    this.rbPan.FlatAppearance.CheckedBackColor = Color.FromArgb(253, 241, 231);
    this.rbPan.FlatAppearance.MouseOverBackColor = Color.FromArgb(226, 217, 200);
    this.rbPan.FlatStyle = FlatStyle.Flat;
    this.rbPan.Font = new Font("Segoe UI", 9f);
    this.rbPan.ForeColor = Color.FromArgb(140, (int) sbyte.MaxValue, 110);
    this.rbPan.Location = new Point(14, 11);
    this.rbPan.Name = "rbPan";
    this.rbPan.Size = new Size(108, 28);
    this.rbPan.TabIndex = 0;
    this.rbPan.TabStop = true;
    this.rbPan.Text = "Panning";
    this.rbPan.TextAlign = ContentAlignment.MiddleCenter;
    this.rbPan.UseVisualStyleBackColor = false;
    this.rbBackround.Appearance = Appearance.Button;
    this.rbBackround.BackColor = Color.FromArgb(245, 240 /*0xF0*/, 232);
    this.rbBackround.Cursor = Cursors.Hand;
    this.rbBackround.FlatAppearance.BorderColor = Color.FromArgb(226, 217, 200);
    this.rbBackround.FlatAppearance.CheckedBackColor = Color.FromArgb(253, 241, 231);
    this.rbBackround.FlatAppearance.MouseOverBackColor = Color.FromArgb(226, 217, 200);
    this.rbBackround.FlatStyle = FlatStyle.Flat;
    this.rbBackround.Font = new Font("Segoe UI", 9f);
    this.rbBackround.ForeColor = Color.FromArgb(140, (int) sbyte.MaxValue, 110);
    this.rbBackround.Location = new Point(132, 11);
    this.rbBackround.Name = "rbBackround";
    this.rbBackround.Size = new Size(108, 28);
    this.rbBackround.TabIndex = 1;
    this.rbBackround.Text = "Background";
    this.rbBackround.TextAlign = ContentAlignment.MiddleCenter;
    this.rbBackround.UseVisualStyleBackColor = false;
    this.rbStretch.Appearance = Appearance.Button;
    this.rbStretch.BackColor = Color.FromArgb(245, 240 /*0xF0*/, 232);
    this.rbStretch.Cursor = Cursors.Hand;
    this.rbStretch.FlatAppearance.BorderColor = Color.FromArgb(226, 217, 200);
    this.rbStretch.FlatAppearance.CheckedBackColor = Color.FromArgb(253, 241, 231);
    this.rbStretch.FlatAppearance.MouseOverBackColor = Color.FromArgb(226, 217, 200);
    this.rbStretch.FlatStyle = FlatStyle.Flat;
    this.rbStretch.Font = new Font("Segoe UI", 9f);
    this.rbStretch.ForeColor = Color.FromArgb(140, (int) sbyte.MaxValue, 110);
    this.rbStretch.Location = new Point(14, 45);
    this.rbStretch.Name = "rbStretch";
    this.rbStretch.Size = new Size(108, 28);
    this.rbStretch.TabIndex = 2;
    this.rbStretch.Text = "Stretch";
    this.rbStretch.TextAlign = ContentAlignment.MiddleCenter;
    this.rbStretch.UseVisualStyleBackColor = false;
    this.rbArticle.Appearance = Appearance.Button;
    this.rbArticle.BackColor = Color.FromArgb(245, 240 /*0xF0*/, 232);
    this.rbArticle.Cursor = Cursors.Hand;
    this.rbArticle.FlatAppearance.BorderColor = Color.FromArgb(226, 217, 200);
    this.rbArticle.FlatAppearance.CheckedBackColor = Color.FromArgb(253, 241, 231);
    this.rbArticle.FlatAppearance.MouseOverBackColor = Color.FromArgb(226, 217, 200);
    this.rbArticle.FlatStyle = FlatStyle.Flat;
    this.rbArticle.Font = new Font("Segoe UI", 9f);
    this.rbArticle.ForeColor = Color.FromArgb(140, (int) sbyte.MaxValue, 110);
    this.rbArticle.Location = new Point(132, 45);
    this.rbArticle.Name = "rbArticle";
    this.rbArticle.Size = new Size(108, 28);
    this.rbArticle.TabIndex = 3;
    this.rbArticle.Text = "Article";
    this.rbArticle.TextAlign = ContentAlignment.MiddleCenter;
    this.rbArticle.UseVisualStyleBackColor = false;
    this.rbNone.Location = new Point(0, 0);
    this.rbNone.Name = "rbNone";
    this.rbNone.Size = new Size(104, 24);
    this.rbNone.TabIndex = 15;
    this.rbNone.Visible = false;
    this.rbStretchNormal.Location = new Point(0, 0);
    this.rbStretchNormal.Name = "rbStretchNormal";
    this.rbStretchNormal.Size = new Size(104, 24);
    this.rbStretchNormal.TabIndex = 0;
    this.rbStretchRegional.Location = new Point(0, 0);
    this.rbStretchRegional.Name = "rbStretchRegional";
    this.rbStretchRegional.Size = new Size(104, 24);
    this.rbStretchRegional.TabIndex = 0;
    this.menuStrip1.Location = new Point(0, 0);
    this.menuStrip1.Name = "menuStrip1";
    this.menuStrip1.Size = new Size(200, 24);
    this.menuStrip1.TabIndex = 0;
    this.menuStrip1.Visible = false;
    this.menuDigitizeSettings.Name = "menuDigitizeSettings";
    this.menuDigitizeSettings.Size = new Size(32 /*0x20*/, 19);
    this.menuEdgeSettings.Name = "menuEdgeSettings";
    this.menuEdgeSettings.Size = new Size(32 /*0x20*/, 19);
    this.menuCalibSettings.Name = "menuCalibSettings";
    this.menuCalibSettings.Size = new Size(32 /*0x20*/, 19);
    this.pboxBackColor.BackColor = Color.FromArgb(0, 128 /*0x80*/, 96 /*0x60*/);
    this.pboxBackColor.BorderStyle = BorderStyle.FixedSingle;
    this.pboxBackColor.Cursor = Cursors.Hand;
    this.pboxBackColor.Location = new Point(14, 10);
    this.pboxBackColor.Name = "pboxBackColor";
    this.pboxBackColor.Size = new Size(26, 26);
    this.pboxBackColor.TabIndex = 1;
    this.pboxBackColor.TabStop = false;
    this.pboxPreview1.BackColor = Color.FromArgb(226, 217, 200);
    this.pboxPreview1.BorderStyle = BorderStyle.FixedSingle;
    this.pboxPreview1.Location = new Point(10, 30);
    this.pboxPreview1.Name = "pboxPreview1";
    this.pboxPreview1.Size = new Size(176 /*0xB0*/, 126);
    this.pboxPreview1.SizeMode = PictureBoxSizeMode.Zoom;
    this.pboxPreview1.TabIndex = 3;
    this.pboxPreview1.TabStop = false;
    this.lbDrag.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
    this.lbDrag.BackColor = Color.FromArgb(245, 240 /*0xF0*/, 232);
    this.lbDrag.BorderStyle = BorderStyle.FixedSingle;
    this.lbDrag.Font = new Font("Consolas", 9f);
    this.lbDrag.ForeColor = Color.FromArgb(92, 81, 68);
    this.lbDrag.ItemHeight = 14;
    this.lbDrag.Location = new Point(10, 298);
    this.lbDrag.Name = "lbDrag";
    this.lbDrag.Size = new Size(176 /*0xB0*/, 100);
    this.lbDrag.TabIndex = 8;
    this.lbDrag.SelectedIndexChanged += new EventHandler(this.LBPaintIndexChanged);
    this.lbArticle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
    this.lbArticle.BackColor = Color.FromArgb(245, 240 /*0xF0*/, 232);
    this.lbArticle.BorderStyle = BorderStyle.FixedSingle;
    this.lbArticle.Font = new Font("Consolas", 9f);
    this.lbArticle.ForeColor = Color.FromArgb(92, 81, 68);
    this.lbArticle.ItemHeight = 14;
    this.lbArticle.Location = new Point(10, 434);
    this.lbArticle.Name = "lbArticle";
    this.lbArticle.Size = new Size(176 /*0xB0*/, 100);
    this.lbArticle.TabIndex = 10;
    this.lbArticle.SelectedIndexChanged += new EventHandler(this.LBPaintIndexChanged);
    this.lbArticle.KeyDown += new KeyEventHandler(this.lbArticle_KeyDown);
    this.pnlLeft.AutoScroll = true;
    this.pnlLeft.BackColor = Color.FromArgb(237, 231, 217);
    this.pnlLeft.Controls.Add((Control) this.pnlLBorder);
    this.pnlLeft.Controls.Add((Control) this.secCam);
    this.pnlLeft.Controls.Add((Control) this.secExp);
    this.pnlLeft.Controls.Add((Control) this.secCap);
    this.pnlLeft.Controls.Add((Control) this.secView);
    this.pnlLeft.Controls.Add((Control) this.secBg);
    this.pnlLeft.Controls.Add((Control) this.secGrid);
    this.pnlLeft.Dock = DockStyle.Left;
    this.pnlLeft.Location = new Point(0, 46);
    this.pnlLeft.Name = "pnlLeft";
    this.pnlLeft.Size = new Size(268, 851);
    this.pnlLeft.TabIndex = 2;
    this.pnlLBorder.BackColor = Color.FromArgb(226, 217, 200);
    this.pnlLBorder.Dock = DockStyle.Right;
    this.pnlLBorder.Location = new Point(270, 0);
    this.pnlLBorder.Name = "pnlLBorder";
    this.pnlLBorder.Size = new Size(1, 834);
    this.pnlLBorder.TabIndex = 0;
    this.secCam.BackColor = Color.FromArgb(237, 231, 217);
    this.secCam.Controls.Add((Control) this.hdrCam);
    this.secCam.Controls.Add((Control) this.divHdrCam);
    this.secCam.Controls.Add((Control) this.bodyCam);
    this.secCam.Controls.Add((Control) this.divBotCam);
    this.secCam.Location = new Point(0, 0);
    this.secCam.Name = "secCam";
    this.secCam.Size = new Size(267, 112 /*0x70*/);
    this.secCam.TabIndex = 1;
    this.hdrCam.BackColor = Color.FromArgb(237, 231, 217);
    this.hdrCam.Font = new Font("Segoe UI", 7.5f, FontStyle.Bold);
    this.hdrCam.ForeColor = Color.FromArgb(140, (int) sbyte.MaxValue, 110);
    this.hdrCam.Location = new Point(0, 0);
    this.hdrCam.Name = "hdrCam";
    this.hdrCam.Padding = new Padding(14, 6, 0, 0);
    this.hdrCam.Size = new Size(267, 22);
    this.hdrCam.TabIndex = 0;
    this.hdrCam.Text = "CAMERA SOURCE";
    this.divHdrCam.BackColor = Color.FromArgb(226, 217, 200);
    this.divHdrCam.Location = new Point(0, 22);
    this.divHdrCam.Name = "divHdrCam";
    this.divHdrCam.Size = new Size(267, 1);
    this.divHdrCam.TabIndex = 1;
    this.bodyCam.BackColor = Color.FromArgb(237, 231, 217);
    this.bodyCam.Controls.Add((Control) this.btnTabGencam);
    this.bodyCam.Controls.Add((Control) this.btnTabCanon);
    this.bodyCam.Controls.Add((Control) this.btnSwitchGencam);
    this.bodyCam.Controls.Add((Control) this.btnHardReset);
    this.bodyCam.Controls.Add((Control) this.btnLockIP);
    this.bodyCam.Location = new Point(0, 23);
    this.bodyCam.Name = "bodyCam";
    this.bodyCam.Padding = new Padding(14, 7, 14, 9);
    this.bodyCam.Size = new Size(267, 88);
    this.bodyCam.TabIndex = 2;
    this.divBotCam.BackColor = Color.FromArgb(226, 217, 200);
    this.divBotCam.Location = new Point(0, 111);
    this.divBotCam.Name = "divBotCam";
    this.divBotCam.Size = new Size(267, 1);
    this.divBotCam.TabIndex = 3;
    this.secExp.BackColor = Color.FromArgb(237, 231, 217);
    this.secExp.Controls.Add((Control) this.hdrExp);
    this.secExp.Controls.Add((Control) this.btnDistortion);
    this.secExp.Controls.Add((Control) this.divHdrExp);
    this.secExp.Controls.Add((Control) this.bodyExp);
    this.secExp.Controls.Add((Control) this.divBotExp);
    this.secExp.Location = new Point(0, 112 /*0x70*/);
    this.secExp.Name = "secExp";
    this.secExp.Size = new Size(267, 189);
    this.secExp.TabIndex = 2;
    this.hdrExp.BackColor = Color.FromArgb(237, 231, 217);
    this.hdrExp.Font = new Font("Segoe UI", 7.5f, FontStyle.Bold);
    this.hdrExp.ForeColor = Color.FromArgb(140, (int) sbyte.MaxValue, 110);
    this.hdrExp.Location = new Point(0, 0);
    this.hdrExp.Name = "hdrExp";
    this.hdrExp.Padding = new Padding(14, 6, 0, 0);
    this.hdrExp.Size = new Size(267, 22);
    this.hdrExp.TabIndex = 0;
    this.hdrExp.Text = "EXPOSURE";
    this.divHdrExp.BackColor = Color.FromArgb(226, 217, 200);
    this.divHdrExp.Location = new Point(0, 22);
    this.divHdrExp.Name = "divHdrExp";
    this.divHdrExp.Size = new Size(267, 1);
    this.divHdrExp.TabIndex = 1;
    this.bodyExp.BackColor = Color.FromArgb(237, 231, 217);
    this.bodyExp.Controls.Add((Control) this.cboxExpAuto);
    this.bodyExp.Controls.Add((Control) this.lblLowLimit);
    this.bodyExp.Controls.Add((Control) this.lblUpLimit);
    this.bodyExp.Controls.Add((Control) this.boxLow);
    this.bodyExp.Controls.Add((Control) this.boxHigh);
    this.bodyExp.Controls.Add((Control) this.lblExposure);
    this.bodyExp.Controls.Add((Control) this.boxManExp);
    this.bodyExp.Controls.Add((Control) this.lblGain);
    this.bodyExp.Controls.Add((Control) this.boxGain);
    this.bodyExp.Location = new Point(3, 29);
    this.bodyExp.Name = "bodyExp";
    this.bodyExp.Padding = new Padding(14, 7, 14, 9);
    this.bodyExp.Size = new Size(267, 157);
    this.bodyExp.TabIndex = 2;
    this.boxLow.BackColor = Color.FromArgb(245, 240 /*0xF0*/, 232);
    this.boxLow.BorderStyle = BorderStyle.FixedSingle;
    this.boxLow.Controls.Add((Control) this.numUDExpAutoLow);
    this.boxLow.Location = new Point(14, 51);
    this.boxLow.Name = "boxLow";
    this.boxLow.Size = new Size(107, 30);
    this.boxLow.TabIndex = 3;
    this.boxHigh.BackColor = Color.FromArgb(245, 240 /*0xF0*/, 232);
    this.boxHigh.BorderStyle = BorderStyle.FixedSingle;
    this.boxHigh.Controls.Add((Control) this.numUDExpAutoUp);
    this.boxHigh.Location = new Point(130, 51);
    this.boxHigh.Name = "boxHigh";
    this.boxHigh.Size = new Size(107, 30);
    this.boxHigh.TabIndex = 4;
    this.boxManExp.BackColor = Color.FromArgb(245, 240 /*0xF0*/, 232);
    this.boxManExp.BorderStyle = BorderStyle.FixedSingle;
    this.boxManExp.Controls.Add((Control) this.numUDGCManExp);
    this.boxManExp.Location = new Point(130, 89);
    this.boxManExp.Name = "boxManExp";
    this.boxManExp.Size = new Size(107, 28);
    this.boxManExp.TabIndex = 6;
    this.boxGain.BackColor = Color.FromArgb(245, 240 /*0xF0*/, 232);
    this.boxGain.BorderStyle = BorderStyle.FixedSingle;
    this.boxGain.Controls.Add((Control) this.numUDGain);
    this.boxGain.Location = new Point(130, 121);
    this.boxGain.Name = "boxGain";
    this.boxGain.Size = new Size(107, 28);
    this.boxGain.TabIndex = 8;
    this.divBotExp.BackColor = Color.FromArgb(226, 217, 200);
    this.divBotExp.Location = new Point(0, 188);
    this.divBotExp.Name = "divBotExp";
    this.divBotExp.Size = new Size(267, 1);
    this.divBotExp.TabIndex = 3;
    this.secCap.BackColor = Color.FromArgb(237, 231, 217);
    this.secCap.Controls.Add((Control) this.hdrCap);
    this.secCap.Controls.Add((Control) this.divHdrCap);
    this.secCap.Controls.Add((Control) this.bodyCap);
    this.secCap.Controls.Add((Control) this.divBotCap);
    this.secCap.Location = new Point(1, 304);
    this.secCap.Name = "secCap";
    this.secCap.Size = new Size(267, 103);
    this.secCap.TabIndex = 3;
    this.hdrCap.BackColor = Color.FromArgb(237, 231, 217);
    this.hdrCap.Font = new Font("Segoe UI", 7.5f, FontStyle.Bold);
    this.hdrCap.ForeColor = Color.FromArgb(140, (int) sbyte.MaxValue, 110);
    this.hdrCap.Location = new Point(0, 0);
    this.hdrCap.Name = "hdrCap";
    this.hdrCap.Padding = new Padding(14, 4, 0, 0);
    this.hdrCap.Size = new Size(267, 19);
    this.hdrCap.TabIndex = 0;
    this.hdrCap.Text = "CAPTURE - PROCESS";
    this.divHdrCap.BackColor = Color.FromArgb(226, 217, 200);
    this.divHdrCap.Location = new Point(0, 20);
    this.divHdrCap.Name = "divHdrCap";
    this.divHdrCap.Size = new Size(267, 1);
    this.divHdrCap.TabIndex = 1;
    this.bodyCap.BackColor = Color.FromArgb(237, 231, 217);
    this.bodyCap.Controls.Add((Control) this.btnTakePhoto);
    this.bodyCap.Controls.Add((Control) this.btnCalibDual);
    this.bodyCap.Controls.Add((Control) this.btnFindContour);
    this.bodyCap.Controls.Add((Control) this.btnRemoveBack);
    this.bodyCap.Location = new Point(0, 23);
    this.bodyCap.Name = "bodyCap";
    this.bodyCap.Padding = new Padding(14, 7, 14, 9);
    this.bodyCap.Size = new Size(267, 80 /*0x50*/);
    this.bodyCap.TabIndex = 2;
    this.divBotCap.BackColor = Color.FromArgb(226, 217, 200);
    this.divBotCap.Location = new Point(0, 101);
    this.divBotCap.Name = "divBotCap";
    this.divBotCap.Size = new Size(267, 1);
    this.divBotCap.TabIndex = 3;
    this.secView.BackColor = Color.FromArgb(237, 231, 217);
    this.secView.Controls.Add((Control) this.hdrView);
    this.secView.Controls.Add((Control) this.divHdrView);
    this.secView.Controls.Add((Control) this.bodyView);
    this.secView.Controls.Add((Control) this.divBotView);
    this.secView.Location = new Point(3, 410);
    this.secView.Name = "secView";
    this.secView.Size = new Size(267, 170);
    this.secView.TabIndex = 4;
    this.hdrView.BackColor = Color.FromArgb(237, 231, 217);
    this.hdrView.Font = new Font("Segoe UI", 7.5f, FontStyle.Bold);
    this.hdrView.ForeColor = Color.FromArgb(140, (int) sbyte.MaxValue, 110);
    this.hdrView.Location = new Point(0, 0);
    this.hdrView.Name = "hdrView";
    this.hdrView.Padding = new Padding(14, 6, 0, 0);
    this.hdrView.Size = new Size(267, 22);
    this.hdrView.TabIndex = 0;
    this.hdrView.Text = "VIEW MODE";
    this.divHdrView.BackColor = Color.FromArgb(226, 217, 200);
    this.divHdrView.Location = new Point(0, 22);
    this.divHdrView.Name = "divHdrView";
    this.divHdrView.Size = new Size(267, 1);
    this.divHdrView.TabIndex = 1;
    this.bodyView.BackColor = Color.FromArgb(237, 231, 217);
    this.bodyView.Controls.Add((Control) this.rbPan);
    this.bodyView.Controls.Add((Control) this.rbBackround);
    this.bodyView.Controls.Add((Control) this.rbStretch);
    this.bodyView.Controls.Add((Control) this.rbArticle);
    this.bodyView.Controls.Add((Control) this.btnLoadAsDrag);
    this.bodyView.Controls.Add((Control) this.btnSaveAsDrag);
    this.bodyView.Controls.Add((Control) this.btnLoadAsArticle);
    this.bodyView.Controls.Add((Control) this.btnSaveAsArticle);
    this.bodyView.Location = new Point(0, 24);
    this.bodyView.Name = "bodyView";
    this.bodyView.Padding = new Padding(14, 7, 14, 9);
    this.bodyView.Size = new Size(267, 143);
    this.bodyView.TabIndex = 2;
    this.divBotView.BackColor = Color.FromArgb(226, 217, 200);
    this.divBotView.Location = new Point(0, 166);
    this.divBotView.Name = "divBotView";
    this.divBotView.Size = new Size(267, 1);
    this.divBotView.TabIndex = 3;
    this.secBg.BackColor = Color.FromArgb(237, 231, 217);
    this.secBg.Controls.Add((Control) this.hdrBg);
    this.secBg.Controls.Add((Control) this.divHdrBg);
    this.secBg.Controls.Add((Control) this.bodyBg);
    this.secBg.Controls.Add((Control) this.divBotBg);
    this.secBg.Location = new Point(3, 580);
    this.secBg.Name = "secBg";
    this.secBg.Size = new Size(267, 120);
    this.secBg.TabIndex = 5;
    this.hdrBg.BackColor = Color.FromArgb(237, 231, 217);
    this.hdrBg.Font = new Font("Segoe UI", 7.5f, FontStyle.Bold);
    this.hdrBg.ForeColor = Color.FromArgb(140, (int) sbyte.MaxValue, 110);
    this.hdrBg.Location = new Point(0, 0);
    this.hdrBg.Name = "hdrBg";
    this.hdrBg.Padding = new Padding(14, 6, 0, 0);
    this.hdrBg.Size = new Size(267, 22);
    this.hdrBg.TabIndex = 0;
    this.hdrBg.Text = "BACKGROUND COLOR";
    this.divHdrBg.BackColor = Color.FromArgb(226, 217, 200);
    this.divHdrBg.Location = new Point(0, 22);
    this.divHdrBg.Name = "divHdrBg";
    this.divHdrBg.Size = new Size(267, 1);
    this.divHdrBg.TabIndex = 1;
    this.bodyBg.BackColor = Color.FromArgb(237, 231, 217);
    this.bodyBg.Controls.Add((Control) this.lblBackColor);
    this.bodyBg.Controls.Add((Control) this.pboxBackColor);
    this.bodyBg.Controls.Add((Control) this.btnResetMarker);
    this.bodyBg.Controls.Add((Control) this.btnResetDrag);
    this.bodyBg.Controls.Add((Control) this.btnResetImage);
    this.bodyBg.Location = new Point(0, 23);
    this.bodyBg.Name = "bodyBg";
    this.bodyBg.Padding = new Padding(14, 7, 14, 9);
    this.bodyBg.Size = new Size(267, 97);
    this.bodyBg.TabIndex = 2;
    this.divBotBg.BackColor = Color.FromArgb(226, 217, 200);
    this.divBotBg.Location = new Point(0, 123);
    this.divBotBg.Name = "divBotBg";
    this.divBotBg.Size = new Size(267, 1);
    this.divBotBg.TabIndex = 3;
    this.secGrid.BackColor = Color.FromArgb(237, 231, 217);
    this.secGrid.Controls.Add((Control) this.hdrGrid);
    this.secGrid.Controls.Add((Control) this.divHdrGrid);
    this.secGrid.Controls.Add((Control) this.bodyGrid);
    this.secGrid.Controls.Add((Control) this.divBotGrid);
    this.secGrid.Location = new Point(3, 706);
    this.secGrid.Name = "secGrid";
    this.secGrid.Size = new Size(267, 123);
    this.secGrid.TabIndex = 6;
    this.hdrGrid.BackColor = Color.FromArgb(237, 231, 217);
    this.hdrGrid.Font = new Font("Segoe UI", 7.5f, FontStyle.Bold);
    this.hdrGrid.ForeColor = Color.FromArgb(140, (int) sbyte.MaxValue, 110);
    this.hdrGrid.Location = new Point(7, 3);
    this.hdrGrid.Name = "hdrGrid";
    this.hdrGrid.Padding = new Padding(6, 5, 0, 0);
    this.hdrGrid.Size = new Size(246, 22);
    this.hdrGrid.TabIndex = 0;
    this.hdrGrid.Text = "GRID OVERLAY";
    this.divHdrGrid.BackColor = Color.FromArgb(226, 217, 200);
    this.divHdrGrid.Location = new Point(0, 0);
    this.divHdrGrid.Name = "divHdrGrid";
    this.divHdrGrid.Size = new Size(267, 1);
    this.divHdrGrid.TabIndex = 1;
    this.bodyGrid.BackColor = Color.FromArgb(237, 231, 217);
    this.bodyGrid.Controls.Add((Control) this.cbGrid);
    this.bodyGrid.Controls.Add((Control) this.btnGridColor);
    this.bodyGrid.Controls.Add((Control) this.label5);
    this.bodyGrid.Controls.Add((Control) this.label6);
    this.bodyGrid.Controls.Add((Control) this.lblGridThick);
    this.bodyGrid.Controls.Add((Control) this.numUDGridX);
    this.bodyGrid.Controls.Add((Control) this.numUDGridY);
    this.bodyGrid.Controls.Add((Control) this.numUDGridThick);
    this.bodyGrid.Location = new Point(0, 28);
    this.bodyGrid.Name = "bodyGrid";
    this.bodyGrid.Padding = new Padding(14, 7, 14, 9);
    this.bodyGrid.Size = new Size(267, 86);
    this.bodyGrid.TabIndex = 2;
    this.divBotGrid.BackColor = Color.FromArgb(226, 217, 200);
    this.divBotGrid.Location = new Point(0, 120);
    this.divBotGrid.Name = "divBotGrid";
    this.divBotGrid.Size = new Size(267, 1);
    this.divBotGrid.TabIndex = 3;
    this.lblConn.BackColor = Color.FromArgb(226, 242, 238);
    this.lblConn.BorderStyle = BorderStyle.FixedSingle;
    this.lblConn.Font = new Font("Segoe UI", 7.5f);
    this.lblConn.ForeColor = Color.FromArgb(26, 107, 90);
    this.lblConn.Location = new Point(159, 14);
    this.lblConn.Name = "lblConn";
    this.lblConn.Size = new Size(86, 18);
    this.lblConn.TabIndex = 5;
    this.lblConn.Text = "● Connected";
    this.lblConn.TextAlign = ContentAlignment.MiddleCenter;
    this.lblConn.Visible = false;
    this.pnlRight.BackColor = Color.FromArgb(237, 231, 217);
    this.pnlRight.Controls.Add((Control) this.btnCalibrateV2);
    this.pnlRight.Controls.Add((Control) this.btnTopViewV2);
    this.pnlRight.Controls.Add((Control) this.pnlRBorder);
    this.pnlRight.Controls.Add((Control) this.lblRHdr);
    this.pnlRight.Controls.Add((Control) this.pnlRHdrDiv);
    this.pnlRight.Controls.Add((Control) this.pboxPreview1);
    this.pnlRight.Controls.Add((Control) this.btnSavePre1);
    this.pnlRight.Controls.Add((Control) this.btnLoadPre1);
    this.pnlRight.Controls.Add((Control) this.pnlCoord);
    this.pnlRight.Controls.Add((Control) this.lblDragHdr);
    this.pnlRight.Controls.Add((Control) this.lbDrag);
    this.pnlRight.Controls.Add((Control) this.lblArticleHdr);
    this.pnlRight.Controls.Add((Control) this.lbArticle);
    this.pnlRight.Dock = DockStyle.Right;
    this.pnlRight.Location = new Point(1354, 46);
    this.pnlRight.Name = "pnlRight";
    this.pnlRight.Size = new Size(196, 851);
    this.pnlRight.TabIndex = 3;
    this.btnCalibrateV2.BackColor = Color.FromArgb(245, 240 /*0xF0*/, 232);
    this.btnCalibrateV2.Cursor = Cursors.Hand;
    this.btnCalibrateV2.FlatAppearance.BorderColor = Color.FromArgb(207, 197, 176 /*0xB0*/);
    this.btnCalibrateV2.FlatStyle = FlatStyle.Flat;
    this.btnCalibrateV2.Font = new Font("Segoe UI", 9f);
    this.btnCalibrateV2.ForeColor = Color.FromArgb(58, 48 /*0x30*/, 40);
    this.btnCalibrateV2.Location = new Point(45, 766);
    this.btnCalibrateV2.Name = "btnCalibrateV2";
    this.btnCalibrateV2.Size = new Size(110, 28);
    this.btnCalibrateV2.TabIndex = 1;
    this.btnCalibrateV2.Text = "Calibrate V2";
    this.btnCalibrateV2.UseVisualStyleBackColor = false;
    this.btnCalibrateV2.Visible = false;
    this.btnCalibrateV2.Click += new EventHandler(this.btnCalibDualV2_Click);
    this.btnTopViewV2.BackColor = Color.FromArgb(196, 98, 26);
    this.btnTopViewV2.Cursor = Cursors.Hand;
    this.btnTopViewV2.FlatAppearance.BorderColor = Color.FromArgb(232, 137, 90);
    this.btnTopViewV2.FlatStyle = FlatStyle.Flat;
    this.btnTopViewV2.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
    this.btnTopViewV2.ForeColor = Color.White;
    this.btnTopViewV2.Location = new Point(45, 732);
    this.btnTopViewV2.Name = "btnTopViewV2";
    this.btnTopViewV2.Size = new Size(110, 28);
    this.btnTopViewV2.TabIndex = 0;
    this.btnTopViewV2.Text = "Top View V2";
    this.btnTopViewV2.UseVisualStyleBackColor = false;
    this.btnTopViewV2.Visible = false;
    this.btnTopViewV2.Click += new EventHandler(this.btnTopViewV2_Click);
    this.pnlRBorder.BackColor = Color.FromArgb(226, 217, 200);
    this.pnlRBorder.Dock = DockStyle.Left;
    this.pnlRBorder.Location = new Point(0, 0);
    this.pnlRBorder.Name = "pnlRBorder";
    this.pnlRBorder.Size = new Size(1, 851);
    this.pnlRBorder.TabIndex = 0;
    this.lblRHdr.BackColor = Color.FromArgb(237, 231, 217);
    this.lblRHdr.Font = new Font("Segoe UI", 7.5f, FontStyle.Bold);
    this.lblRHdr.ForeColor = Color.FromArgb(140, (int) sbyte.MaxValue, 110);
    this.lblRHdr.Location = new Point(0, 0);
    this.lblRHdr.Name = "lblRHdr";
    this.lblRHdr.Padding = new Padding(12, 6, 0, 0);
    this.lblRHdr.Size = new Size(196, 22);
    this.lblRHdr.TabIndex = 1;
    this.lblRHdr.Text = "PREVIEW";
    this.pnlRHdrDiv.BackColor = Color.FromArgb(226, 217, 200);
    this.pnlRHdrDiv.Location = new Point(0, 22);
    this.pnlRHdrDiv.Name = "pnlRHdrDiv";
    this.pnlRHdrDiv.Size = new Size(196, 1);
    this.pnlRHdrDiv.TabIndex = 2;
    this.pnlCoord.BackColor = Color.FromArgb(245, 240 /*0xF0*/, 232);
    this.pnlCoord.BorderStyle = BorderStyle.FixedSingle;
    this.pnlCoord.Controls.Add((Control) this.lXl);
    this.pnlCoord.Controls.Add((Control) this.lXv);
    this.pnlCoord.Controls.Add((Control) this.lYl);
    this.pnlCoord.Controls.Add((Control) this.lYv);
    this.pnlCoord.Location = new Point(10, 228);
    this.pnlCoord.Name = "pnlCoord";
    this.pnlCoord.Size = new Size(176 /*0xB0*/, 44);
    this.pnlCoord.TabIndex = 6;
    this.lXl.AutoSize = true;
    this.lXl.Font = new Font("Segoe UI", 7.5f);
    this.lXl.ForeColor = Color.FromArgb(184, 173, 154);
    this.lXl.Location = new Point(6, 4);
    this.lXl.Name = "lXl";
    this.lXl.Size = new Size(52, 12);
    this.lXl.TabIndex = 0;
    this.lXl.Text = "CURSOR X";
    this.lXv.AutoSize = true;
    this.lXv.Font = new Font("Consolas", 11.25f, FontStyle.Bold);
    this.lXv.ForeColor = Color.FromArgb(196, 98, 26);
    this.lXv.Location = new Point(6, 16 /*0x10*/);
    this.lXv.Name = "lXv";
    this.lXv.Size = new Size(16 /*0x10*/, 18);
    this.lXv.TabIndex = 1;
    this.lXv.Text = "—";
    this.lYl.AutoSize = true;
    this.lYl.Font = new Font("Segoe UI", 7.5f);
    this.lYl.ForeColor = Color.FromArgb(184, 173, 154);
    this.lYl.Location = new Point(92, 4);
    this.lYl.Name = "lYl";
    this.lYl.Size = new Size(52, 12);
    this.lYl.TabIndex = 2;
    this.lYl.Text = "CURSOR Y";
    this.lYv.AutoSize = true;
    this.lYv.Font = new Font("Consolas", 11.25f, FontStyle.Bold);
    this.lYv.ForeColor = Color.FromArgb(196, 98, 26);
    this.lYv.Location = new Point(92, 16 /*0x10*/);
    this.lYv.Name = "lYv";
    this.lYv.Size = new Size(16 /*0x10*/, 18);
    this.lYv.TabIndex = 3;
    this.lYv.Text = "—";
    this.lblDragHdr.AutoSize = true;
    this.lblDragHdr.Font = new Font("Segoe UI", 7.5f, FontStyle.Bold);
    this.lblDragHdr.ForeColor = Color.FromArgb(140, (int) sbyte.MaxValue, 110);
    this.lblDragHdr.Location = new Point(10, 282);
    this.lblDragHdr.Name = "lblDragHdr";
    this.lblDragHdr.Size = new Size(82, 12);
    this.lblDragHdr.TabIndex = 7;
    this.lblDragHdr.Text = "STRETCH ITEMS";
    this.lblArticleHdr.AutoSize = true;
    this.lblArticleHdr.Font = new Font("Segoe UI", 7.5f, FontStyle.Bold);
    this.lblArticleHdr.ForeColor = Color.FromArgb(140, (int) sbyte.MaxValue, 110);
    this.lblArticleHdr.Location = new Point(10, 418);
    this.lblArticleHdr.Name = "lblArticleHdr";
    this.lblArticleHdr.Size = new Size(77, 12);
    this.lblArticleHdr.TabIndex = 9;
    this.lblArticleHdr.Text = "ARTICLE ITEMS";
    this.pnlTitleBar.BackColor = Color.FromArgb(58, 48 /*0x30*/, 40);
    this.pnlTitleBar.Controls.Add((Control) this.btnDistV3);
    this.pnlTitleBar.Controls.Add((Control) this.btnDistV2);
    this.pnlTitleBar.Controls.Add((Control) this.lblCanonControls);
    this.pnlTitleBar.Controls.Add((Control) this.cboxCamAV);
    this.pnlTitleBar.Controls.Add((Control) this.cboxCamISO);
    this.pnlTitleBar.Controls.Add((Control) this.cboxCamTV);
    this.pnlTitleBar.Controls.Add((Control) this.btnTopView);
    this.pnlTitleBar.Controls.Add((Control) this.pnlAccentLine);
    this.pnlTitleBar.Controls.Add((Control) this.pnlBrand);
    this.pnlTitleBar.Controls.Add((Control) this.btnMenuDig);
    this.pnlTitleBar.Controls.Add((Control) this.btnMenuEdge);
    this.pnlTitleBar.Controls.Add((Control) this.btnMenuCalib);
    this.pnlTitleBar.Controls.Add((Control) this.btnLoad);
    this.pnlTitleBar.Controls.Add((Control) this.btnRefresh);
    this.pnlTitleBar.Controls.Add((Control) this.btnSave);
    this.pnlTitleBar.Controls.Add((Control) this.btnUndo);
    this.pnlTitleBar.Controls.Add((Control) this.btnVideoMode);
    this.pnlTitleBar.Controls.Add((Control) this.btnCancel);
    this.pnlTitleBar.Controls.Add((Control) this.btnMinimize);
    this.pnlTitleBar.Controls.Add((Control) this.btnExtend);
    this.pnlTitleBar.Dock = DockStyle.Top;
    this.pnlTitleBar.Location = new Point(0, 0);
    this.pnlTitleBar.Name = "pnlTitleBar";
    this.pnlTitleBar.Size = new Size(1550, 46);
    this.pnlTitleBar.TabIndex = 4;
    this.btnDistV2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.btnDistV2.BackColor = Color.FromArgb(196, 98, 26);
    this.btnDistV2.Cursor = Cursors.Hand;
    this.btnDistV2.FlatAppearance.BorderColor = Color.FromArgb(232, 137, 90);
    this.btnDistV2.FlatStyle = FlatStyle.Flat;
    this.btnDistV2.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
    this.btnDistV2.ForeColor = Color.White;
    this.btnDistV2.Location = new Point(696, 7);
    this.btnDistV2.Name = "btnDistV2";
    this.btnDistV2.Size = new Size(83, 28);
    this.btnDistV2.TabIndex = 0;
    this.btnDistV2.Text = "Distortion";
    this.btnDistV2.UseVisualStyleBackColor = false;
    this.btnDistV2.Click += new EventHandler(this.btnDistV2_Click);
    this.btnDistortion.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.btnDistortion.BackColor = Color.FromArgb(196, 98, 26);
    this.btnDistortion.Cursor = Cursors.Hand;
    this.btnDistortion.FlatAppearance.BorderColor = Color.FromArgb(232, 137, 90);
    this.btnDistortion.FlatStyle = FlatStyle.Flat;
    this.btnDistortion.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
    this.btnDistortion.ForeColor = Color.White;
    this.btnDistortion.Location = new Point(133, -1);
    this.btnDistortion.Name = "btnDistortion";
    this.btnDistortion.Size = new Size(83, 28);
    this.btnDistortion.TabIndex = 0;
    this.btnDistortion.Text = "Distortion";
    this.btnDistortion.UseVisualStyleBackColor = false;
    this.btnDistortion.Click += new EventHandler(this.btnDistortion_Click);
    this.lblCanonControls.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.lblCanonControls.AutoSize = true;
    this.lblCanonControls.ForeColor = Color.White;
    this.lblCanonControls.Location = new Point(1078, 14);
    this.lblCanonControls.Name = "lblCanonControls";
    this.lblCanonControls.Size = new Size(93, 15);
    this.lblCanonControls.TabIndex = 14;
    this.lblCanonControls.Text = "Canon Controls:";
    this.cboxCamAV.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.cboxCamAV.FormattingEnabled = true;
    this.cboxCamAV.Location = new Point(1313, 10);
    this.cboxCamAV.Name = "cboxCamAV";
    this.cboxCamAV.Size = new Size(62, 23);
    this.cboxCamAV.TabIndex = 13;
    this.cboxCamISO.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.cboxCamISO.FormattingEnabled = true;
    this.cboxCamISO.Location = new Point(1245, 10);
    this.cboxCamISO.Name = "cboxCamISO";
    this.cboxCamISO.Size = new Size(62, 23);
    this.cboxCamISO.TabIndex = 13;
    this.cboxCamTV.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.cboxCamTV.FormattingEnabled = true;
    this.cboxCamTV.Location = new Point(1177, 10);
    this.cboxCamTV.Name = "cboxCamTV";
    this.cboxCamTV.Size = new Size(62, 23);
    this.cboxCamTV.TabIndex = 13;
    this.btnTopView.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.btnTopView.BackColor = Color.FromArgb(196, 98, 26);
    this.btnTopView.Cursor = Cursors.Hand;
    this.btnTopView.FlatAppearance.BorderColor = Color.FromArgb(232, 137, 90);
    this.btnTopView.FlatStyle = FlatStyle.Flat;
    this.btnTopView.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
    this.btnTopView.ForeColor = Color.White;
    this.btnTopView.Location = new Point(996, 8);
    this.btnTopView.Name = "btnTopView";
    this.btnTopView.Size = new Size(76, 28);
    this.btnTopView.TabIndex = 0;
    this.btnTopView.Text = "Top View";
    this.btnTopView.UseVisualStyleBackColor = false;
    this.btnTopView.Click += new EventHandler(this.btnTopView_Click);
    this.pnlAccentLine.BackColor = Color.FromArgb(196, 98, 26);
    this.pnlAccentLine.Dock = DockStyle.Bottom;
    this.pnlAccentLine.Location = new Point(0, 44);
    this.pnlAccentLine.Name = "pnlAccentLine";
    this.pnlAccentLine.Size = new Size(1550, 2);
    this.pnlAccentLine.TabIndex = 0;
    this.pnlBrand.BackColor = Color.Transparent;
    this.pnlBrand.Controls.Add((Control) this.lblBrandMark);
    this.pnlBrand.Controls.Add((Control) this.lblBrandName);
    this.pnlBrand.Controls.Add((Control) this.pnlBrandBorder);
    this.pnlBrand.Controls.Add((Control) this.lblConn);
    this.pnlBrand.Location = new Point(0, 0);
    this.pnlBrand.Name = "pnlBrand";
    this.pnlBrand.Size = new Size(268, 46);
    this.pnlBrand.TabIndex = 1;
    this.lblBrandMark.BackColor = Color.FromArgb(196, 98, 26);
    this.lblBrandMark.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
    this.lblBrandMark.ForeColor = Color.White;
    this.lblBrandMark.Location = new Point(14, 12);
    this.lblBrandMark.Name = "lblBrandMark";
    this.lblBrandMark.Size = new Size(22, 22);
    this.lblBrandMark.TabIndex = 0;
    this.lblBrandMark.Text = "DP";
    this.lblBrandMark.TextAlign = ContentAlignment.MiddleCenter;
    this.lblBrandName.AutoSize = true;
    this.lblBrandName.BackColor = Color.Transparent;
    this.lblBrandName.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
    this.lblBrandName.ForeColor = Color.FromArgb(245, 240 /*0xF0*/, 232);
    this.lblBrandName.Location = new Point(42, 14);
    this.lblBrandName.Name = "lblBrandName";
    this.lblBrandName.Size = new Size(100, 15);
    this.lblBrandName.TabIndex = 1;
    this.lblBrandName.Text = "Digitizer Pro  2.0";
    this.pnlBrandBorder.BackColor = Color.FromArgb(25, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
    this.pnlBrandBorder.Dock = DockStyle.Right;
    this.pnlBrandBorder.Location = new Point(267, 0);
    this.pnlBrandBorder.Name = "pnlBrandBorder";
    this.pnlBrandBorder.Size = new Size(1, 46);
    this.pnlBrandBorder.TabIndex = 2;
    this.btnMenuDig.BackColor = Color.Transparent;
    this.btnMenuDig.Cursor = Cursors.Hand;
    this.btnMenuDig.FlatAppearance.BorderSize = 0;
    this.btnMenuDig.FlatAppearance.MouseOverBackColor = Color.FromArgb(15, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
    this.btnMenuDig.FlatStyle = FlatStyle.Flat;
    this.btnMenuDig.Font = new Font("Segoe UI", 8f);
    this.btnMenuDig.ForeColor = Color.FromArgb(184, 173, 154);
    this.btnMenuDig.Location = new Point(278, 0);
    this.btnMenuDig.Name = "btnMenuDig";
    this.btnMenuDig.Size = new Size(138, 44);
    this.btnMenuDig.TabIndex = 2;
    this.btnMenuDig.Text = "Digitize Settings";
    this.btnMenuDig.UseVisualStyleBackColor = false;
    this.btnMenuDig.Click += new EventHandler(this.menuDigitizeSettings_Click);
    this.btnMenuEdge.BackColor = Color.Transparent;
    this.btnMenuEdge.Cursor = Cursors.Hand;
    this.btnMenuEdge.FlatAppearance.BorderSize = 0;
    this.btnMenuEdge.FlatAppearance.MouseOverBackColor = Color.FromArgb(15, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
    this.btnMenuEdge.FlatStyle = FlatStyle.Flat;
    this.btnMenuEdge.Font = new Font("Segoe UI", 8f);
    this.btnMenuEdge.ForeColor = Color.FromArgb(184, 173, 154);
    this.btnMenuEdge.Location = new Point(422, 0);
    this.btnMenuEdge.Name = "btnMenuEdge";
    this.btnMenuEdge.Size = new Size(138, 44);
    this.btnMenuEdge.TabIndex = 3;
    this.btnMenuEdge.Text = "Edge Detection";
    this.btnMenuEdge.UseVisualStyleBackColor = false;
    this.btnMenuEdge.Click += new EventHandler(this.menuEdgeSettings_Click);
    this.btnMenuCalib.BackColor = Color.Transparent;
    this.btnMenuCalib.Cursor = Cursors.Hand;
    this.btnMenuCalib.FlatAppearance.BorderSize = 0;
    this.btnMenuCalib.FlatAppearance.MouseOverBackColor = Color.FromArgb(15, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
    this.btnMenuCalib.FlatStyle = FlatStyle.Flat;
    this.btnMenuCalib.Font = new Font("Segoe UI", 8f);
    this.btnMenuCalib.ForeColor = Color.FromArgb(184, 173, 154);
    this.btnMenuCalib.Location = new Point(566, 0);
    this.btnMenuCalib.Name = "btnMenuCalib";
    this.btnMenuCalib.Size = new Size(138, 44);
    this.btnMenuCalib.TabIndex = 4;
    this.btnMenuCalib.Text = "Calibration";
    this.btnMenuCalib.UseVisualStyleBackColor = false;
    this.btnMenuCalib.Click += new EventHandler(this.menuCalibSettings_Click);
    this.btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.btnCancel.BackColor = Color.FromArgb((int) byte.MaxValue, 95, 86);
    this.btnCancel.Cursor = Cursors.Hand;
    this.btnCancel.FlatAppearance.BorderSize = 0;
    this.btnCancel.FlatAppearance.MouseOverBackColor = Color.FromArgb(193, 10, 0);
    this.btnCancel.FlatStyle = FlatStyle.Flat;
    this.btnCancel.Location = new Point(1518, 15);
    this.btnCancel.Name = "btnCancel";
    this.btnCancel.Size = new Size(13, 13);
    this.btnCancel.TabIndex = 10;
    this.btnCancel.UseVisualStyleBackColor = false;
    this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
    this.btnMinimize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.btnMinimize.BackColor = Color.FromArgb((int) byte.MaxValue, 189, 46);
    this.btnMinimize.Cursor = Cursors.Hand;
    this.btnMinimize.FlatAppearance.BorderSize = 0;
    this.btnMinimize.FlatAppearance.MouseOverBackColor = Color.FromArgb(170, 115, 0);
    this.btnMinimize.FlatStyle = FlatStyle.Flat;
    this.btnMinimize.Location = new Point(1451, 15);
    this.btnMinimize.Name = "btnMinimize";
    this.btnMinimize.Size = new Size(13, 13);
    this.btnMinimize.TabIndex = 11;
    this.btnMinimize.UseVisualStyleBackColor = false;
    this.btnMinimize.Click += new EventHandler(this.btnMinimize_Click);
    this.btnExtend.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.btnExtend.BackColor = Color.FromArgb(39, 201, 63 /*0x3F*/);
    this.btnExtend.Cursor = Cursors.Hand;
    this.btnExtend.FlatAppearance.BorderSize = 0;
    this.btnExtend.FlatAppearance.MouseOverBackColor = Color.FromArgb(22, 114, 36);
    this.btnExtend.FlatStyle = FlatStyle.Flat;
    this.btnExtend.Location = new Point(1485, 15);
    this.btnExtend.Name = "btnExtend";
    this.btnExtend.Size = new Size(13, 13);
    this.btnExtend.TabIndex = 12;
    this.btnExtend.UseVisualStyleBackColor = false;
    this.btnExtend.Click += new EventHandler(this.btnExtend_Click);
    this.pnlStatusBar.BackColor = Color.FromArgb(58, 48 /*0x30*/, 40);
    this.pnlStatusBar.Controls.Add((Control) this.pnlSTop);
    this.pnlStatusBar.Controls.Add((Control) this.lblCamStatus);
    this.pnlStatusBar.Controls.Add((Control) this.lblScaleInfo);
    this.pnlStatusBar.Controls.Add((Control) this.lblZoom);
    this.pnlStatusBar.Controls.Add((Control) this.lblCoordX);
    this.pnlStatusBar.Controls.Add((Control) this.lblCoordY);
    this.pnlStatusBar.Dock = DockStyle.Bottom;
    this.pnlStatusBar.Location = new Point(0, 897);
    this.pnlStatusBar.Name = "pnlStatusBar";
    this.pnlStatusBar.Size = new Size(1550, 26);
    this.pnlStatusBar.TabIndex = 5;
    this.pnlSTop.BackColor = Color.FromArgb(18, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
    this.pnlSTop.Dock = DockStyle.Top;
    this.pnlSTop.Location = new Point(0, 0);
    this.pnlSTop.Name = "pnlSTop";
    this.pnlSTop.Size = new Size(1550, 1);
    this.pnlSTop.TabIndex = 0;
    this.pnlCapture.Location = new Point(0, 0);
    this.pnlCapture.Name = "pnlCapture";
    this.pnlCapture.Size = new Size(200, 100);
    this.pnlCapture.TabIndex = 0;
    this.pnlExposure.Location = new Point(0, 0);
    this.pnlExposure.Name = "pnlExposure";
    this.pnlExposure.Size = new Size(200, 100);
    this.pnlExposure.TabIndex = 0;
    this.pnlViewMode.Location = new Point(0, 0);
    this.pnlViewMode.Name = "pnlViewMode";
    this.pnlViewMode.Size = new Size(200, 100);
    this.pnlViewMode.TabIndex = 0;
    this.pnlBackground.Location = new Point(0, 0);
    this.pnlBackground.Name = "pnlBackground";
    this.pnlBackground.Size = new Size(200, 100);
    this.pnlBackground.TabIndex = 0;
    this.pnlGridOverlay.Location = new Point(0, 0);
    this.pnlGridOverlay.Name = "pnlGridOverlay";
    this.pnlGridOverlay.Size = new Size(200, 100);
    this.pnlGridOverlay.TabIndex = 0;
    this.pnlPreview.Location = new Point(0, 0);
    this.pnlPreview.Name = "pnlPreview";
    this.pnlPreview.Size = new Size(200, 100);
    this.pnlPreview.TabIndex = 0;
    this.pnlLists.Location = new Point(0, 0);
    this.pnlLists.Name = "pnlLists";
    this.pnlLists.Size = new Size(200, 100);
    this.pnlLists.TabIndex = 0;
    this.pnlCamControl.Location = new Point(0, 0);
    this.pnlCamControl.Name = "pnlCamControl";
    this.pnlCamControl.Size = new Size(200, 100);
    this.pnlCamControl.TabIndex = 18;
    this.pnlCamControl.Visible = false;
    this.pnlPboxMode.Location = new Point(0, 0);
    this.pnlPboxMode.Name = "pnlPboxMode";
    this.pnlPboxMode.Size = new Size(200, 100);
    this.pnlPboxMode.TabIndex = 19;
    this.pnlPboxMode.Visible = false;
    this.pnlDigitize.Location = new Point(0, 0);
    this.pnlDigitize.Name = "pnlDigitize";
    this.pnlDigitize.Size = new Size(200, 100);
    this.pnlDigitize.TabIndex = 20;
    this.pnlDigitize.Visible = false;
    this.pnlPicturebox.Location = new Point(0, 0);
    this.pnlPicturebox.Name = "pnlPicturebox";
    this.pnlPicturebox.Size = new Size(200, 100);
    this.pnlPicturebox.TabIndex = 21;
    this.pnlPicturebox.Visible = false;
    this.panel1.Location = new Point(0, 0);
    this.panel1.Name = "panel1";
    this.panel1.Size = new Size(200, 100);
    this.panel1.TabIndex = 14;
    this.panel1.Visible = false;
    this.lblStretchMethod.Location = new Point(0, 0);
    this.lblStretchMethod.Name = "lblStretchMethod";
    this.lblStretchMethod.Size = new Size(100, 23);
    this.lblStretchMethod.TabIndex = 0;
    this.btnDistV3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.btnDistV3.BackColor = Color.FromArgb(196, 98, 26);
    this.btnDistV3.Cursor = Cursors.Hand;
    this.btnDistV3.FlatAppearance.BorderColor = Color.FromArgb(232, 137, 90);
    this.btnDistV3.FlatStyle = FlatStyle.Flat;
    this.btnDistV3.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
    this.btnDistV3.ForeColor = Color.White;
    this.btnDistV3.Location = new Point(785, 7);
    this.btnDistV3.Name = "btnDistV3";
    this.btnDistV3.Size = new Size(83, 28);
    this.btnDistV3.TabIndex = 0;
    this.btnDistV3.Text = "Distortion";
    this.btnDistV3.UseVisualStyleBackColor = false;
    this.btnDistV3.Click += new EventHandler(this.btnDistV3_Click);
    this.BackColor = Color.FromArgb(42, 36, 32 /*0x20*/);
    this.ClientSize = new Size(1550, 923);
    this.Controls.Add((Control) this.menuStrip1);
    this.Controls.Add((Control) this.pboxEdit);
    this.Controls.Add((Control) this.pnlLeft);
    this.Controls.Add((Control) this.pnlRight);
    this.Controls.Add((Control) this.pnlTitleBar);
    this.Controls.Add((Control) this.pnlStatusBar);
    this.Controls.Add((Control) this.numUDTLX);
    this.Controls.Add((Control) this.numUDTLY);
    this.Controls.Add((Control) this.numUDTRX);
    this.Controls.Add((Control) this.numUDTRY);
    this.Controls.Add((Control) this.numUDBLX);
    this.Controls.Add((Control) this.numUDBLY);
    this.Controls.Add((Control) this.numUDBRX);
    this.Controls.Add((Control) this.numUDBRY);
    this.Controls.Add((Control) this.panel1);
    this.Controls.Add((Control) this.rbNone);
    this.Controls.Add((Control) this.btnTabEdge);
    this.Controls.Add((Control) this.tabControlAllCams);
    this.Controls.Add((Control) this.pnlCamControl);
    this.Controls.Add((Control) this.pnlPboxMode);
    this.Controls.Add((Control) this.pnlDigitize);
    this.Controls.Add((Control) this.pnlPicturebox);
    this.FormBorderStyle = FormBorderStyle.None;
    this.Name = nameof (Form1);
    this.Text = "Digitizer Pro";
    this.FormClosing += new FormClosingEventHandler(this.Form1_FormClosing);
    this.Load += new EventHandler(this.Form1_Load);
    ((ISupportInitialize) this.pboxEdit).EndInit();
    ((ISupportInitialize) this.numUDGCManExp).EndInit();
    ((ISupportInitialize) this.numUDGain).EndInit();
    ((ISupportInitialize) this.numUDExpAutoLow).EndInit();
    ((ISupportInitialize) this.numUDExpAutoUp).EndInit();
    ((ISupportInitialize) this.numUDGridX).EndInit();
    ((ISupportInitialize) this.numUDGridY).EndInit();
    ((ISupportInitialize) this.numUDGridThick).EndInit();
    ((ISupportInitialize) this.numUDTLX).EndInit();
    ((ISupportInitialize) this.numUDTLY).EndInit();
    ((ISupportInitialize) this.numUDTRX).EndInit();
    ((ISupportInitialize) this.numUDTRY).EndInit();
    ((ISupportInitialize) this.numUDBLX).EndInit();
    ((ISupportInitialize) this.numUDBLY).EndInit();
    ((ISupportInitialize) this.numUDBRX).EndInit();
    ((ISupportInitialize) this.numUDBRY).EndInit();
    ((ISupportInitialize) this.pboxBackColor).EndInit();
    ((ISupportInitialize) this.pboxPreview1).EndInit();
    this.pnlLeft.ResumeLayout(false);
    this.secCam.ResumeLayout(false);
    this.bodyCam.ResumeLayout(false);
    this.secExp.ResumeLayout(false);
    this.bodyExp.ResumeLayout(false);
    this.bodyExp.PerformLayout();
    this.boxLow.ResumeLayout(false);
    this.boxHigh.ResumeLayout(false);
    this.boxManExp.ResumeLayout(false);
    this.boxGain.ResumeLayout(false);
    this.secCap.ResumeLayout(false);
    this.bodyCap.ResumeLayout(false);
    this.secView.ResumeLayout(false);
    this.bodyView.ResumeLayout(false);
    this.secBg.ResumeLayout(false);
    this.bodyBg.ResumeLayout(false);
    this.bodyBg.PerformLayout();
    this.secGrid.ResumeLayout(false);
    this.bodyGrid.ResumeLayout(false);
    this.bodyGrid.PerformLayout();
    this.pnlRight.ResumeLayout(false);
    this.pnlRight.PerformLayout();
    this.pnlCoord.ResumeLayout(false);
    this.pnlCoord.PerformLayout();
    this.pnlTitleBar.ResumeLayout(false);
    this.pnlTitleBar.PerformLayout();
    this.pnlBrand.ResumeLayout(false);
    this.pnlBrand.PerformLayout();
    this.pnlStatusBar.ResumeLayout(false);
    this.pnlStatusBar.PerformLayout();
    this.ResumeLayout(false);
    this.PerformLayout();
  }
}
