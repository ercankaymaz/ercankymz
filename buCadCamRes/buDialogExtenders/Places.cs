// Decompiled with JetBrains decompiler
// Type: buDialogExtenders.Places
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using System.ComponentModel;

#nullable disable
namespace buDialogExtenders;

public enum Places
{
  [Description("Desktop")] Desktop = 0,
  [Description("Internet Explorer ")] InternetExplorer = 1,
  [Description("Program Files")] Programs = 2,
  [Description("Control Panel")] ControlPanel = 3,
  [Description("Printers")] Printers = 4,
  [Description("My Documents")] MyDocuments = 5,
  [Description("Favorites")] Favorites = 6,
  [Description("Startup folder")] StartupFolder = 7,
  [Description("Recent Files")] RecentFiles = 8,
  [Description("Send To")] SendTo = 9,
  [Description("Recycle Bin")] RecycleBin = 10, // 0x0000000A
  [Description("Start menu")] StartMenu = 11, // 0x0000000B
  [Description("Logical My Documents")] Logical_MyDocuments = 12, // 0x0000000C
  [Description("My Music")] MyMusic = 13, // 0x0000000D
  [Description("My Videos")] MyVideos = 14, // 0x0000000E
  [Description("<user name>\\Desktop")] UserName_Desktop = 16, // 0x00000010
  [Description("My Computer")] MyComputer = 17, // 0x00000011
  [Description("My Network Places")] MyNetworkPlaces = 18, // 0x00000012
  [Description("<user name>\nethood")] User_Name_Nethood = 19, // 0x00000013
  [Description("Fonts")] Fonts = 20, // 0x00000014
  [Description("All Users\\Start Menu")] All_Users_StartMenu = 22, // 0x00000016
  [Description("All Users\\Start Menu\\Programs ")] All_Users_StartMenu_Programs = 23, // 0x00000017
  [Description("All Users\\Startup")] All_Users_Startup = 24, // 0x00000018
  [Description("All Users\\Desktop")] All_Users_Desktop = 25, // 0x00000019
  [Description("<user name>\\Application Data ")] User_name_ApplicationData = 26, // 0x0000001A
  [Description("<user name>\\PrintHood ")] User_Name_PrintHood = 27, // 0x0000001B
  [Description("<user name>\\Local Settings\\Applicaiton Data (nonroaming)")] Local_ApplicaitonData = 28, // 0x0000001C
  [Description("Nonlocalized common startup ")] NonlocalizedCommonStartup = 30, // 0x0000001E
  [Description("")] CommonFavorites = 31, // 0x0000001F
  [Description("Internet Cache ")] InternetCache = 32, // 0x00000020
  [Description("Cookies ")] Cookies = 33, // 0x00000021
  [Description("History")] History = 34, // 0x00000022
  [Description("All Users\\Application Data ")] All_Users_ApplicationData = 35, // 0x00000023
  [Description("Windows Directory")] WindowsDirectory = 36, // 0x00000024
  [Description("System Directory")] SystemDirectory = 37, // 0x00000025
  [Description("Program Files ")] ProgramFiles = 38, // 0x00000026
  [Description("My Pictures ")] MyPictures = 39, // 0x00000027
  [Description("USERPROFILE")] USERPROFILE = 40, // 0x00000028
  [Description("system directory on RISC")] SYSTEN_RISC = 41, // 0x00000029
  [Description("Program Files on RISC ")] Program_Files_RISC = 42, // 0x0000002A
  [Description("Program Files\\Common")] Common = 43, // 0x0000002B
  [Description("Program Files\\Common on RISC")] Common_RISC = 44, // 0x0000002C
  [Description("All Users\\Templates ")] Templates = 45, // 0x0000002D
  [Description("All Users\\Documents")] All_Users_Documents = 46, // 0x0000002E
  [Description("All Users\\Start Menu\\Programs\\Administrative Tools")] AdministrativeTools = 47, // 0x0000002F
  [Description("<user name>\\Start Menu\\Programs\\Administrative Tools")] USER_AdministrativeTools = 48, // 0x00000030
  [Description("Network and Dial-up Connections")] Network_DialUp_Connections = 49, // 0x00000031
  [Description("All Users\\My Music")] All_Users_MyMusic = 53, // 0x00000035
  [Description("All Users\\My Pictures")] All_Users_MyPictures = 54, // 0x00000036
  [Description("All Users\\My Video")] All_Users_MyVideo = 55, // 0x00000037
  [Description("Resource Directory")] Resource = 56, // 0x00000038
  [Description("Localized Resource Directory ")] Localized_Resource = 57, // 0x00000039
  [Description("OEM specific apps")] OEM_Specific = 58, // 0x0000003A
  [Description("USERPROFILE\\Local Settings\\Application Data\\Microsoft\\CD Burning")] CDBurning = 59, // 0x0000003B
}
