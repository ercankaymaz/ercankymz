using System;
using System.Windows.Forms;

namespace buClass;

[Serializable]
public class AppProcess : buSerilization
{
	public static int SelectedAxis = -1;

	public static double SelectedMolt = 0.1;

	public static int Status = 0;

	public static int ActiveLine = -1;

	public static int ActiveTool = -1;

	public static int ActiveMCode = -1;

	public static int WarningID = 0;

	public static int AlarmCount = 0;

	public static int WarningCount = 0;

	public static int GCodeStartLine = -1;

	public static int GCodeTotalLineCount = 0;

	public static int TickSave = 0;

	public static int TickGeneral = 0;

	public static double FeedVelocity = 0.0;

	public static double FeedOverride = 0.0;

	public static double SpindleSpeed = 0.0;

	public static double SpindleOverride = 0.0;

	public static bool Automatic = false;

	public static bool Manuel = false;

	public static bool Paused = false;

	public static bool Alarmmm = false;

	public static bool Warning = false;

	public static AppWarning activeWarning = new AppWarning();

	public static AppAlarm activeAlarm = new AppAlarm();

	public static DateTime StartedTime = default(DateTime);

	public static string LastLoadedFileName = Application.StartupPath;

	public static string LastLoadedFolder = Application.StartupPath;
}
