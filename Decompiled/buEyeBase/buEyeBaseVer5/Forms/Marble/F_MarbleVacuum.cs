using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buControls;
using buControls.Controls;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot;
using devDept.Geometry;
using ns71;

namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleVacuum : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public static List<string> Captions = new List<string>();

	public List<Point3D> pntList = new List<Point3D>();

	private Timer timer_0 = null;

	private DrawingTypes drawingTypes_0 = DrawingTypes.None;

	private List<buEntity> list_0 = new List<buEntity>();

	internal IContainer icontainer_0 = null;

	public buButton buButton1;

	public buButton btn_maximize;

	public buButton btn_close;

	public buGround buGround1;

	public buButton btn_ok;

	public Panel pnl_base;

	public Panel pnl_data;

	public buButton btn_cancel;

	public buButton btn_settings;

	public Panel pnl_viewport;

	public buButton btn_viewtop;

	public buButton btn_viewback;

	public buButton btn_viewfront;

	public buButton btn_viewleft;

	public buButton btn_viewright;

	public buButton btn_viewiso;

	public buButton btn_viewzoomfit;

	public buButton btn_rotate;

	public buButton btn_pan;

	internal ImageList imageList_0;

	public TreeView treeView1;

	public buLabel lbl_items;

	public buButton btn_leftup;

	public buButton btn_right;

	public buButton btn_rightdown;

	public buButton btn_left;

	public buButton btn_rightup;

	public buButton btn_up;

	public buButton btn_down;

	public buButton btn_leftdown;

	public buButton btn_undo;

	public buButton btn_clear;

	public buSpin spn_length;

	public F_MarbleVacuum()
	{
		Class186.smethod_55(this);
		timer_0 = new Timer();
		timer_0.Interval = 50;
		timer_0.Tick += timer_0_Tick;
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
		if (PropertiesForm.Height > 10)
		{
			base.Height = PropertiesForm.Height;
		}
		if (PropertiesForm.Width > 10)
		{
			base.Width = PropertiesForm.Width;
		}
		base.TopMost = PropertiesForm.TopMost;
		base.StartPosition = PropertiesForm.FormPosition;
		Class186.smethod_41(this);
		list_0.Clear();
		Class186.smethod_538(this);
		timer_0.Enabled = true;
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
		Class186.smethod_121(this);
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		if (PropertiesForm.Result != DialogResult.OK)
		{
			e.Cancel = true;
			PropertiesForm.Result = DialogResult.Cancel;
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		try
		{
			Control control = sender as Control;
			if (!(control.Name == btn_rotate.Name))
			{
				if (!(control.Name == btn_pan.Name))
				{
					if (!(control.Name == btn_viewtop.Name))
					{
						if (!(control.Name == btn_viewfront.Name))
						{
							if (!(control.Name == btn_viewback.Name))
							{
								if (!(control.Name == btn_viewleft.Name))
								{
									if (!(control.Name == btn_viewright.Name))
									{
										if (!(control.Name == btn_viewiso.Name))
										{
											if (!(control.Name == btn_viewzoomfit.Name))
											{
												if (control.Name == btn_clear.Name && buString5.MessageBoxQuestion(buLangTranslate.preSentences.DoYouWantToDelete) == DialogResult.Yes)
												{
													pntList.Clear();
													buEyeItems.viewportDialogs.Entities.Clear();
													buEyeItems.viewportDialogs.Invalidate();
												}
												if (!(control.Name == btn_settings.Name))
												{
												}
												if (control.Name == btn_ok.Name)
												{
													Class186.smethod_170(this);
													PropertiesForm.Result = DialogResult.OK;
													if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
													{
														Dispose();
													}
													if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
													{
														base.Visible = false;
													}
												}
												if ((control.Name == btn_cancel.Name) | (control.Name == btn_close.Name))
												{
													PropertiesForm.Result = DialogResult.Cancel;
													if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
													{
														Dispose();
													}
													if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
													{
														base.Visible = false;
													}
												}
											}
											else
											{
												buEyeItems.viewportDialogs.ZoomFit(10);
												buEyeItems.viewportDialogs.Invalidate();
											}
										}
										else
										{
											buEyeItems.viewportDialogs.SetView(viewType.Trimetric);
											buEyeItems.viewportDialogs.Invalidate();
										}
									}
									else
									{
										buEyeItems.viewportDialogs.SetView(viewType.Right);
										buEyeItems.viewportDialogs.Invalidate();
									}
								}
								else
								{
									buEyeItems.viewportDialogs.SetView(viewType.Left);
									buEyeItems.viewportDialogs.Invalidate();
								}
							}
							else
							{
								buEyeItems.viewportDialogs.SetView(viewType.Rear);
								buEyeItems.viewportDialogs.Invalidate();
							}
						}
						else
						{
							buEyeItems.viewportDialogs.SetView(viewType.Front);
							buEyeItems.viewportDialogs.Invalidate();
						}
					}
					else
					{
						buEyeItems.viewportDialogs.SetView(viewType.Top);
						buEyeItems.viewportDialogs.Invalidate();
					}
				}
				else if (buEyeItems.viewportDialogs.ActionMode != actionType.Pan)
				{
					buEyeItems.viewportDialogs.ActionMode = actionType.Pan;
				}
				else
				{
					buEyeItems.viewportDialogs.ActionMode = actionType.None;
				}
			}
			else if (buEyeItems.viewportDialogs.ActionMode != actionType.Rotate)
			{
				buEyeItems.viewportDialogs.ActionMode = actionType.Rotate;
			}
			else
			{
				buEyeItems.viewportDialogs.ActionMode = actionType.None;
			}
		}
		catch (Exception)
		{
		}
	}

	public void spn_Leave(object sender, EventArgs e)
	{
	}

	internal void method_2(object sender, TreeViewEventArgs e)
	{
	}

	internal void method_3(object sender, EventArgs e)
	{
	}

	internal void method_4(object sender, TreeNodeMouseClickEventArgs e)
	{
		if (!(AppBool.ListFilling | AppBool.TreeCollapsing | AppBool.TreeExpanding))
		{
			AppBool.TreeNodeClicked = true;
			buTreeNode buTreeNode2 = (buTreeNode)e.Node;
			string command = buTreeNode2.Command;
			string text = command;
			if (text == "main")
			{
			}
			AppBool.TreeNodeClicked = false;
		}
		else
		{
			AppBool.TreeCollapsing = false;
			AppBool.TreeExpanding = false;
		}
	}

	internal void method_5(object sender, TreeViewCancelEventArgs e)
	{
		AppBool.TreeExpanding = true;
	}

	internal void method_6(object sender, TreeViewCancelEventArgs e)
	{
		AppBool.TreeCollapsing = true;
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
