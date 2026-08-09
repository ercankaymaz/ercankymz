using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buControls.ClassViewer;
using buControls.DialogBox;
using buCore;
using ns71;

namespace buEyeBaseVer5.Forms;

public class F_SettingTreeView : Form
{
	public delegate void ApplyClickEvent();

	public delegate void DefaultClickEvent();

	public static List<string> Captions = new List<string>();

	public List<object> Classes = new List<object>();

	public List<string> CaptionHeader = new List<string>();

	public List<List<string>> CaptionSubHeader = new List<List<string>>();

	public List<List<List<string>>> CaptionVariables = new List<List<List<string>>>();

	public DialogResult Result = DialogResult.Cancel;

	public TouchPadType TouchPadStyle = TouchPadType.buControlStyleBasic;

	public int AccessPasswordLevel = 0;

	private buClassViewer buClassViewer_0 = new buClassViewer();

	private bool bool_0 = false;

	public bool FormTopMost = false;

	public bool ReadOnly = false;

	public bool ScreenCenter = true;

	public bool TouchPad = false;

	public List<object> tempClasses = new List<object>();

	[CompilerGenerated]
	private ApplyClickEvent applyClickEvent_0;

	[CompilerGenerated]
	private DefaultClickEvent defaultClickEvent_0;

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	internal TreeView treeView_0;

	public Button btn_default;

	public Button btn_cancel;

	public Button btn_ok;

	public Button btn_apply;

	public Button btn_saveastext;

	internal ContextMenuStrip contextMenuStrip_0;

	internal ToolStripMenuItem toolStripMenuItem_0;

	internal Panel panel_0;

	public event ApplyClickEvent ApplyClick
	{
		[CompilerGenerated]
		add
		{
			ApplyClickEvent applyClickEvent = applyClickEvent_0;
			ApplyClickEvent applyClickEvent2;
			do
			{
				applyClickEvent2 = applyClickEvent;
				ApplyClickEvent value2 = (ApplyClickEvent)Delegate.Combine(applyClickEvent2, value);
				applyClickEvent = Interlocked.CompareExchange(ref applyClickEvent_0, value2, applyClickEvent2);
			}
			while ((object)applyClickEvent != applyClickEvent2);
		}
		[CompilerGenerated]
		remove
		{
			ApplyClickEvent applyClickEvent = applyClickEvent_0;
			ApplyClickEvent applyClickEvent2;
			do
			{
				applyClickEvent2 = applyClickEvent;
				ApplyClickEvent value2 = (ApplyClickEvent)Delegate.Remove(applyClickEvent2, value);
				applyClickEvent = Interlocked.CompareExchange(ref applyClickEvent_0, value2, applyClickEvent2);
			}
			while ((object)applyClickEvent != applyClickEvent2);
		}
	}

	public event DefaultClickEvent DefaultClick
	{
		[CompilerGenerated]
		add
		{
			DefaultClickEvent defaultClickEvent = defaultClickEvent_0;
			DefaultClickEvent defaultClickEvent2;
			do
			{
				defaultClickEvent2 = defaultClickEvent;
				DefaultClickEvent value2 = (DefaultClickEvent)Delegate.Combine(defaultClickEvent2, value);
				defaultClickEvent = Interlocked.CompareExchange(ref defaultClickEvent_0, value2, defaultClickEvent2);
			}
			while ((object)defaultClickEvent != defaultClickEvent2);
		}
		[CompilerGenerated]
		remove
		{
			DefaultClickEvent defaultClickEvent = defaultClickEvent_0;
			DefaultClickEvent defaultClickEvent2;
			do
			{
				defaultClickEvent2 = defaultClickEvent;
				DefaultClickEvent value2 = (DefaultClickEvent)Delegate.Remove(defaultClickEvent2, value);
				defaultClickEvent = Interlocked.CompareExchange(ref defaultClickEvent_0, value2, defaultClickEvent2);
			}
			while ((object)defaultClickEvent != defaultClickEvent2);
		}
	}

	public F_SettingTreeView()
	{
		Class186.smethod_646(this);
		buClassViewer_0.Dock = DockStyle.Fill;
	}

	internal void method_0(object sender, EventArgs e)
	{
	}

	internal void method_1(object sender, EventArgs e)
	{
		method_3(treeView_0, null);
	}

	internal void method_2(object sender, FormClosingEventArgs e)
	{
		e.Cancel = true;
		base.Visible = false;
	}

	public void Init()
	{
		buClassViewer_0.TouchPayStyle = TouchPadStyle;
		buClassViewer_0.OwnerForm = this;
		tempClasses.Clear();
		tempClasses = new List<object>();
		for (int i = 0; i <= Classes.Count - 1; i++)
		{
			object obj = new object();
			obj = Activator.CreateInstance(Classes[i].GetType());
			List<cParameter5> Vars = new List<cParameter5>();
			buSerilization5.GetClassVariables(Classes[i], ref Vars);
			buSerilization5.SetClassVariables(ref obj, Vars);
			tempClasses.Add(obj);
		}
		treeView_0.Nodes.Clear();
		if (AppSecurity.PasswordLevel >= AccessPasswordLevel)
		{
			buClassViewer_0.Enabled = true;
			btn_apply.Enabled = true;
			btn_ok.Enabled = true;
			btn_default.Enabled = true;
		}
		else
		{
			buClassViewer_0.Enabled = false;
			btn_apply.Enabled = false;
			btn_ok.Enabled = false;
			btn_default.Enabled = false;
		}
		treeView_0.SelectedNode = null;
		new List<string>();
		for (int j = 0; j <= tempClasses.Count - 1; j++)
		{
			if (tempClasses[j] == null)
			{
				continue;
			}
			List<cParameter5> Vars2 = new List<cParameter5>();
			Type type = tempClasses[j].GetType();
			string text = type.Name;
			if ((CaptionHeader.Count > 0) & (j <= CaptionHeader.Count - 1))
			{
				text = CaptionHeader[j];
			}
			TreeNodeSettings treeNodeSettings = new TreeNodeSettings();
			buSerilization5.GetClassVariables(tempClasses[j], ref Vars2);
			for (int k = 0; k <= Vars2.Count - 1; k++)
			{
				Type type2 = Vars2[k].Value.GetType();
				if (!type2.IsClass)
				{
					continue;
				}
				bool flag = false;
				if (type2.Name.ToLower() == "SolidItemDisplay")
				{
					flag = true;
				}
				if (type2.Name.ToLower() == "drawpropertiestype")
				{
					flag = true;
				}
				if ((type2.Name == "MouseKeyboardConfigration") | (type2.Name == "EntityResolution"))
				{
					flag = true;
				}
				if (!(type2.BaseType.Namespace == "buClass" && !flag))
				{
					continue;
				}
				List<cParameter5> Vars3 = new List<cParameter5>();
				buSerilization5.GetClassVariables(Vars2[k].Value, ref Vars3);
				TreeNodeSettings treeNodeSettings2 = new TreeNodeSettings();
				for (int l = 0; l <= Vars3.Count - 1; l++)
				{
					Type type3 = Vars3[l].Value.GetType();
					if (type3.IsClass && type3.BaseType.Namespace == "buClass")
					{
						TreeNodeSettings treeNodeSettings3 = new TreeNodeSettings();
						treeNodeSettings3.Text = Vars3[l].Name;
						treeNodeSettings3.Tag = Vars3[l].Value;
						treeNodeSettings3.ImageIndex = 1;
						treeNodeSettings3.SelectedImageIndex = 1;
						treeNodeSettings3.ClassIndex = j;
						treeNodeSettings3.ClassSubIndex = k;
						treeNodeSettings2.Nodes.Add(treeNodeSettings3);
					}
				}
				treeNodeSettings2.Text = Vars2[k].Name;
				treeNodeSettings2.Tag = Vars2[k].Value;
				treeNodeSettings2.ImageIndex = 1;
				treeNodeSettings2.SelectedImageIndex = 1;
				treeNodeSettings2.ClassIndex = j;
				treeNodeSettings2.ClassSubIndex = k;
				treeNodeSettings.Nodes.Add(treeNodeSettings2);
			}
			treeNodeSettings.Text = text;
			treeNodeSettings.Tag = tempClasses[j];
			treeNodeSettings.ImageIndex = 2;
			treeNodeSettings.SelectedImageIndex = 2;
			treeNodeSettings.ClassIndex = j;
			treeNodeSettings.ClassSubIndex = 0;
			treeView_0.Nodes.Add(treeNodeSettings);
		}
		if (tempClasses.Count > 0)
		{
			treeView_0.SelectedNode = treeView_0.Nodes[0];
		}
		base.TopMost = FormTopMost;
		if (ScreenCenter)
		{
			base.StartPosition = FormStartPosition.CenterScreen;
		}
		bool_0 = true;
		LoadLangueage();
	}

	public void LoadLangueage()
	{
		string callMethod = "SettingsTreeView LoadLanguage";
		try
		{
			if (Captions.Count >= 7)
			{
				Text = Captions[0];
				btn_default.Text = Captions[1];
				btn_saveastext.Text = Captions[2];
				btn_apply.Text = Captions[3];
				btn_ok.Text = Captions[4];
				btn_cancel.Text = Captions[5];
				toolStripMenuItem_0.Text = Captions[6];
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", callMethod);
			buException.throwException(mSException, callMethod, ShowMessageBox: true, text);
		}
	}

	internal void method_3(object sender, TreeViewEventArgs e)
	{
		if (bool_0 && e != null && treeView_0.SelectedNode.Tag != null && treeView_0.SelectedNode.Nodes != null)
		{
			object tag = treeView_0.SelectedNode.Tag;
			buClassViewer_0.ClassObject = tag;
			buClassViewer_0.Init();
		}
	}

	internal void method_4(object sender, EventArgs e)
	{
		if (treeView_0.SelectedNode != null)
		{
			method_6(sender, e);
			tempClasses = new List<object>();
			_ = treeView_0.SelectedNode.Tag;
			Result = DialogResult.OK;
			base.Visible = false;
		}
		else
		{
			base.Visible = false;
		}
	}

	internal void method_5(object sender, EventArgs e)
	{
		tempClasses = new List<object>();
		Result = DialogResult.Cancel;
		base.Visible = false;
	}

	internal void method_6(object sender, EventArgs e)
	{
		if (treeView_0.SelectedNode != null)
		{
			btn_apply.Focus();
			for (int i = 0; i <= treeView_0.Nodes.Count - 1; i++)
			{
				object value = tempClasses[i];
				if (treeView_0.Nodes[i].Nodes != null)
				{
					for (int j = 0; j <= treeView_0.Nodes[i].Nodes.Count - 1; j++)
					{
						List<cParameter5> Vars = new List<cParameter5>();
						object ObjPar = treeView_0.Nodes[i].Nodes[j].Tag;
						buSerilization5.GetClassVariables(ObjPar, ref Vars);
						buSerilization5.SetClassVariables(ref ObjPar, Vars);
					}
				}
				_ = treeView_0.Nodes[i].Tag;
				tempClasses[i] = value;
			}
			for (int k = 0; k <= tempClasses.Count - 1; k++)
			{
				object obj = new object();
				obj = Activator.CreateInstance(tempClasses[k].GetType());
				buSerilization5.CopyClass(tempClasses[k], ref obj);
				Classes[k] = obj;
			}
			if (applyClickEvent_0 != null)
			{
				applyClickEvent_0();
			}
		}
		else
		{
			base.Visible = false;
		}
	}

	internal void method_7(object sender, EventArgs e)
	{
		if (defaultClickEvent_0 != null)
		{
			defaultClickEvent_0();
		}
		base.Visible = false;
	}

	internal void method_8(object sender, EventArgs e)
	{
		List<string> list = new List<string>();
		string text = "";
		SaveFileDialog saveFileDialog = new SaveFileDialog();
		saveFileDialog.InitialDirectory = Application.StartupPath;
		saveFileDialog.Filter = "Settings CSV Files (*.csv)|*.csv";
		saveFileDialog.FilterIndex = 1;
		saveFileDialog.FileName = "";
		if (saveFileDialog.ShowDialog() != DialogResult.OK)
		{
			return;
		}
		for (int i = 0; i <= treeView_0.Nodes.Count - 1; i++)
		{
			object value = tempClasses[i];
			if (treeView_0.Nodes[i].Nodes != null)
			{
				if (treeView_0.Nodes[i].Nodes.Count <= 0)
				{
					List<cParameter5> Vars = new List<cParameter5>();
					object tag = treeView_0.Nodes[i].Tag;
					buSerilization5.GetClassVariables(tag, ref Vars);
					for (int j = 0; j <= Vars.Count - 1; j++)
					{
						text = treeView_0.Nodes[i].Text + " ;  - ; " + Vars[j].Name + " ; " + Vars[j].ValueAsString.ToString();
						list.Add(text);
					}
				}
				else
				{
					for (int k = 0; k <= treeView_0.Nodes[i].Nodes.Count - 1; k++)
					{
						List<cParameter5> Vars2 = new List<cParameter5>();
						object tag2 = treeView_0.Nodes[i].Nodes[k].Tag;
						buSerilization5.GetClassVariables(tag2, ref Vars2);
						for (int l = 0; l <= Vars2.Count - 1; l++)
						{
							text = treeView_0.Nodes[i].Text + " ; " + treeView_0.Nodes[i].Nodes[k].Text + "; " + Vars2[l].Name + " ; " + Vars2[l].ValueAsString.ToString();
							list.Add(text);
						}
					}
				}
			}
			_ = treeView_0.Nodes[i].Tag;
			tempClasses[i] = value;
		}
		buFile.SaveToFile(list, saveFileDialog.FileName);
	}

	internal void method_9(object sender, EventArgs e)
	{
		DialogBoxList dialogBoxList = new DialogBoxList();
		CodesysAxis codesysAxis = null;
		if (treeView_0.SelectedNode.Parent == null && treeView_0.SelectedNode.Tag.GetType() == typeof(CodesysAxis))
		{
			codesysAxis = new CodesysAxis((CodesysAxis)treeView_0.SelectedNode.Tag);
		}
		if (codesysAxis == null)
		{
			return;
		}
		for (int i = 0; i <= Classes.Count - 1; i++)
		{
			if (Classes[i].GetType() == typeof(CodesysAxis))
			{
				dialogBoxList.Items.Add(((CodesysAxis)Classes[i]).Base.baseChar);
			}
		}
		dialogBoxList.Init();
		dialogBoxList.ShowDialog();
		if (dialogBoxList.Result == DialogResult.OK)
		{
			if (Classes[dialogBoxList.SelectedIndex].GetType() == typeof(CodesysAxis))
			{
				Classes[dialogBoxList.SelectedIndex] = new CodesysAxis(codesysAxis);
			}
			Init();
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
