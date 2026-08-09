using System.ComponentModel;

namespace buDialogExtenders;

public enum Places
{
	[Description("Desktop")]
	Desktop = 0,
	[Description("Internet Explorer ")]
	InternetExplorer = 1,
	[Description("Program Files")]
	Programs = 2,
	[Description("Control Panel")]
	ControlPanel = 3,
	[Description("Printers")]
	Printers = 4,
	[Description("My Documents")]
	MyDocuments = 5,
	[Description("Favorites")]
	Favorites = 6,
	[Description("Startup folder")]
	StartupFolder = 7,
	[Description("Recent Files")]
	RecentFiles = 8,
	[Description("Send To")]
	SendTo = 9,
	[Description("Recycle Bin")]
	RecycleBin = 10,
	[Description("Start menu")]
	StartMenu = 11,
	[Description("Logical My Documents")]
	Logical_MyDocuments = 12,
	[Description("My Music")]
	MyMusic = 13,
	[Description("My Videos")]
	MyVideos = 14,
	[Description("<user name>\\Desktop")]
	UserName_Desktop = 16,
	[Description("My Computer")]
	MyComputer = 17,
	[Description("My Network Places")]
	MyNetworkPlaces = 18,
	[Description("<user name>\nethood")]
	User_Name_Nethood = 19,
	[Description("Fonts")]
	Fonts = 20,
	[Description("All Users\\Start Menu")]
	All_Users_StartMenu = 22,
	[Description("All Users\\Start Menu\\Programs ")]
	All_Users_StartMenu_Programs = 23,
	[Description("All Users\\Startup")]
	All_Users_Startup = 24,
	[Description("All Users\\Desktop")]
	All_Users_Desktop = 25,
	[Description("<user name>\\Application Data ")]
	User_name_ApplicationData = 26,
	[Description("<user name>\\PrintHood ")]
	User_Name_PrintHood = 27,
	[Description("<user name>\\Local Settings\\Applicaiton Data (nonroaming)")]
	Local_ApplicaitonData = 28,
	[Description("Nonlocalized common startup ")]
	NonlocalizedCommonStartup = 30,
	[Description("")]
	CommonFavorites = 31,
	[Description("Internet Cache ")]
	InternetCache = 32,
	[Description("Cookies ")]
	Cookies = 33,
	[Description("History")]
	History = 34,
	[Description("All Users\\Application Data ")]
	All_Users_ApplicationData = 35,
	[Description("Windows Directory")]
	WindowsDirectory = 36,
	[Description("System Directory")]
	SystemDirectory = 37,
	[Description("Program Files ")]
	ProgramFiles = 38,
	[Description("My Pictures ")]
	MyPictures = 39,
	[Description("USERPROFILE")]
	USERPROFILE = 40,
	[Description("system directory on RISC")]
	SYSTEN_RISC = 41,
	[Description("Program Files on RISC ")]
	Program_Files_RISC = 42,
	[Description("Program Files\\Common")]
	Common = 43,
	[Description("Program Files\\Common on RISC")]
	Common_RISC = 44,
	[Description("All Users\\Templates ")]
	Templates = 45,
	[Description("All Users\\Documents")]
	All_Users_Documents = 46,
	[Description("All Users\\Start Menu\\Programs\\Administrative Tools")]
	AdministrativeTools = 47,
	[Description("<user name>\\Start Menu\\Programs\\Administrative Tools")]
	USER_AdministrativeTools = 48,
	[Description("Network and Dial-up Connections")]
	Network_DialUp_Connections = 49,
	[Description("All Users\\My Music")]
	All_Users_MyMusic = 53,
	[Description("All Users\\My Pictures")]
	All_Users_MyPictures = 54,
	[Description("All Users\\My Video")]
	All_Users_MyVideo = 55,
	[Description("Resource Directory")]
	Resource = 56,
	[Description("Localized Resource Directory ")]
	Localized_Resource = 57,
	[Description("OEM specific apps")]
	OEM_Specific = 58,
	[Description("USERPROFILE\\Local Settings\\Application Data\\Microsoft\\CD Burning")]
	CDBurning = 59
}
