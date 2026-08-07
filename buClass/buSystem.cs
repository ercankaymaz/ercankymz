// Decompiled with JetBrains decompiler
// Type: buClass.buSystem
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System.Globalization;
using System.Windows.Forms;

#nullable disable
namespace buClass;

public class buSystem
{
  public static double valCheckFactor = 0.0;
  public static double valMidPointConstant = 0.0;
  public static string a1 = "jrtseagrenhjsyrHGTREYA";
  public static string a2 = "/&%HRYKŞPIĞGSDGSFDGTY46by64ysdfx5c";
  public static double Code = 0.0;
  public static string strIDScale = "";
  public static string strTest = "";
  public static double resolutionCompare = 0.001;
  public static double resolutionGCode = 0.001;
  public static double resolutionSorting = 0.01;
  public static double RegenDeviation = 0.01;
  public static double MmToInchRatio = 5.0 / (double) sbyte.MaxValue;
  public static double InchToMmRatio = 25.4;
  public static EntityResolution EntitiesResolution = new EntityResolution(0.5, 20, 20.0, EntityResolutionType.ByLnRadius);
  public static PointsToEntitiesPar PointsToEntities = new PointsToEntitiesPar(170.0, 0.01, 3.0);
  public static string fileNameException = Application.StartupPath + "\\buException.csv";
  public static string fileNameLog = Application.StartupPath + "\\buLog5.csv";
  public static string fileNameExceptionLog = Application.StartupPath + "\\buLogException5.csv";
  public static string fileUndo = Application.StartupPath + "\\Undo.und";
  public static int DoubleToIntegerConts = 1000;
  public static CultureInfo CI = new CultureInfo("en-US", false);
  public static bool Cancel = false;
  public static bool Canceled = false;
  public static bool DoEventEnable = true;
  public static bool ProgressControlEnable = true;
  public static string strSpace2 = new string(' ', 2);
  public static string strSpace4 = new string(' ', 4);
  public static string strSpace6 = new string(' ', 6);
  public static string strSpace8 = new string(' ', 8);
  public static string strSpace10 = new string(' ', 10);
  public static string strSpace12 = new string(' ', 12);
}
