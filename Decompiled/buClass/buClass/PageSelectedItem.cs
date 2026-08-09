using System;

namespace buClass;

[Serializable]
public class PageSelectedItem : buSerilization
{
	public PageModes Mode = PageModes.None;

	public int PageIndex = -1;

	public string PageName = "";

	public int SceneIndex = -1;

	public string SceneName = "";

	public int CamIndex = -1;

	public string CamName = "";

	public int BlockIndex = -1;

	public string BlockName = "";

	public int EntityIndex = -1;

	public string EntityType = "";

	public string EntityName = "";

	public int Index = -1;

	public int SubIndex = -1;

	public string Info = "";
}
