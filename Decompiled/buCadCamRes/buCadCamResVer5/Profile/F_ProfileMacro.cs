using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot;
using ns8;

namespace buCadCamResVer5.Profile;

public class F_ProfileMacro : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public Timer timInit = new Timer();

	public ProfileItem Item = new ProfileItem();

	public List<ProfileOperation> Operations = new List<ProfileOperation>();

	internal IContainer icontainer_0 = null;

	internal Button button_0;

	internal Button button_1;

	internal ImageList imageList_0;

	internal ImageList imageList_1;

	internal Button button_2;

	public Panel pnl_viewport;

	internal CheckedListBox checkedListBox_0;

	internal CheckBox checkBox_0;

	internal NumericUpDown numericUpDown_0;

	internal Label label_0;

	public F_ProfileMacro()
	{
		Class5.smethod_81(this);
		timInit.Tick += Init_Tick;
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
		base.TopMost = PropertiesForm.TopMost;
		base.StartPosition = PropertiesForm.FormPosition;
		timInit.Interval = 200;
		timInit.Enabled = true;
		checkedListBox_0.Items.Clear();
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	internal void method_0(object sender, EventArgs e)
	{
	}

	public void Init_Tick(object sender, EventArgs e)
	{
		timInit.Enabled = false;
		clsInit.appProfile.DrawMacroEntities(Item);
	}

	internal void method_1(object sender, EventArgs e)
	{
		PropertiesForm.Inited = false;
		PropertiesForm.Inited = true;
	}

	internal void method_2(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == button_0.Name)
		{
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
		if (control.Name == button_1.Name)
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
		if (!(control.Name == button_2.Name))
		{
			return;
		}
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.InitialDirectory = AppPath.Macro;
		openFileDialog.Filter = "Profile Macro Files (*.buOPmacro)|*.buOPmacro";
		openFileDialog.FilterIndex = 1;
		if (openFileDialog.ShowDialog() != DialogResult.OK)
		{
			return;
		}
		Operations.Clear();
		AppPath.Macro = buFile5.GetPath(openFileDialog.FileName);
		ArrayList StringList = new ArrayList();
		buFile5.OpenFromFile(openFileDialog.FileName, ref StringList);
		List<List<string>> CalcList = new List<List<string>>();
		buStatics.ListToSpecificList("<PrfOperation>", "</PrfOperation>", AddStartEndKey: false, StringList, ref CalcList);
		if (CalcList.Count == 0)
		{
			buStatics.ListToSpecificList("<Operations>", "</Operations>", AddStartEndKey: false, StringList, ref CalcList);
		}
		for (int i = 0; i <= CalcList.Count - 1; i++)
		{
			ArrayList arrayList = new ArrayList();
			arrayList.AddRange(CalcList[i].ToArray());
			ProfileOperation OP = new ProfileOperation();
			ProfileOperation.Decode(CalcList[i], ref OP);
			if (OP.MinPoint.X == OP.MaxPoint.X)
			{
				continue;
			}
			OP.OperationData.CamParNotch.Notch.NotchCutType = OP.CamOPData.NotchCutType;
			if (OP.OperationData.OperationType == ProfileOperationTypes.FreeDraw)
			{
				OP.EntityMultiContour = new List<buEntity>();
				List<string> CalcList2 = new List<string>();
				buStatics.ListToSpecificList("<ContourEntitites>", "</ContourEntitites>", AddStartEndKey: false, CalcList[i], ref CalcList2);
				if (CalcList2.Count > 0)
				{
					List<List<string>> CalcList3 = new List<List<string>>();
					buStatics.ListToSpecificList("<buEntity>", "</buEntity>", AddStartEndKey: false, CalcList2, ref CalcList3);
					for (int j = 0; j <= CalcList3.Count - 1; j++)
					{
						buEntity buEntity2 = buEntity.Decode(CalcList3[j]);
						if (buEntity2 != null)
						{
							OP.EntityMultiContour.Add(buEntity2);
						}
					}
				}
			}
			Operations.Add(OP);
		}
		DrawOperations();
		clsInit.appProfile.viewportCommon.SetView(viewType.vcFrontFaceTopLeft);
		clsInit.appProfile.viewportCommon.ZoomFit(10);
		OperationTreeFill();
	}

	internal void method_3(object sender, FormClosingEventArgs e)
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

	internal void method_4(object sender, EventArgs e)
	{
		if (PropertiesForm.Inited)
		{
			DrawOperations();
		}
	}

	public void OperationTreeFill()
	{
		checkedListBox_0.Items.Clear();
		for (int i = 0; i <= Item.Operations.Count - 1; i++)
		{
			checkedListBox_0.Items.Add(buProfileCalc.OperationItemString(Item.Operations[i]), isChecked: true);
		}
	}

	public void DrawOperations()
	{
		this.Item.Operations.Clear();
		SizeObject sizeObject = new SizeObject(this.Item.Length, this.Item.Width, this.Item.Height);
		if (Operations.Count <= 0)
		{
			return;
		}
		double num = 0.0;
		if (checkBox_0.Checked)
		{
			num = 100000.0;
			for (int i = 0; i <= Operations.Count - 1; i++)
			{
				if (Operations[i].OperationData.Position.X < num)
				{
					num = Operations[i].OperationData.Position.X;
				}
			}
		}
		SizeObject sizeObject2 = new SizeObject(Operations[0].ProfileLength, Operations[0].ProfileWidth, Operations[0].ProfileHeight);
		for (int j = 0; j <= Operations.Count - 1; j++)
		{
			ProfileOperation CopiedOperation = new ProfileOperation();
			ProfileOperation.Copy(Operations[j], ref CopiedOperation);
			if (checkBox_0.Checked)
			{
				if (CopiedOperation.OperationData.Corner == CornerLocation.RightBottom)
				{
					CopiedOperation.OperationData.Corner = CornerLocation.LeftBottom;
					CopiedOperation.OperationData.basePosition.X = CopiedOperation.OperationData.Position.X;
				}
				if (CopiedOperation.OperationData.Corner == CornerLocation.RightCenter)
				{
					CopiedOperation.OperationData.Corner = CornerLocation.LeftCenter;
					CopiedOperation.OperationData.basePosition.X = CopiedOperation.OperationData.Position.X;
				}
				if (CopiedOperation.OperationData.Corner == CornerLocation.RightTop)
				{
					CopiedOperation.OperationData.Corner = CornerLocation.LeftTop;
					CopiedOperation.OperationData.basePosition.X = CopiedOperation.OperationData.Position.X;
				}
				if (CopiedOperation.OperationData.Corner == CornerLocation.BottomCenter)
				{
					CopiedOperation.OperationData.Corner = CornerLocation.LeftBottom;
					CopiedOperation.OperationData.basePosition.X = CopiedOperation.OperationData.Position.X;
				}
				if (CopiedOperation.OperationData.Corner == CornerLocation.TopCenter)
				{
					CopiedOperation.OperationData.Corner = CornerLocation.LeftTop;
					CopiedOperation.OperationData.basePosition.X = CopiedOperation.OperationData.Position.X;
				}
				CopiedOperation.OperationData.basePosition.X = CopiedOperation.OperationData.basePosition.X + (double)numericUpDown_0.Value - num;
			}
			else
			{
				if ((CopiedOperation.OperationData.Corner == CornerLocation.LeftBottom) | (CopiedOperation.OperationData.Corner == CornerLocation.LeftCenter) | (CopiedOperation.OperationData.Corner == CornerLocation.LeftTop))
				{
					CopiedOperation.OperationData.basePosition.X = CopiedOperation.OperationData.basePosition.X + (double)numericUpDown_0.Value;
				}
				if ((CopiedOperation.OperationData.Corner == CornerLocation.RightBottom) | (CopiedOperation.OperationData.Corner == CornerLocation.RightCenter) | (CopiedOperation.OperationData.Corner == CornerLocation.RightTop))
				{
					CopiedOperation.OperationData.basePosition.X = CopiedOperation.OperationData.basePosition.X - (double)numericUpDown_0.Value;
				}
			}
			CopiedOperation.OperationData.DepthForced = true;
			for (int k = 0; k <= CopiedOperation.OperationData.DepthValues.Count - 1; k++)
			{
				if (CopiedOperation.OperationData.selectedPlaneName == planeNames.Front)
				{
					CopiedOperation.OperationData.DepthValues[k].TopPosition = CopiedOperation.OperationData.DepthValues[k].TopPosition - (sizeObject.Height - sizeObject2.Height);
					CopiedOperation.OperationData.DepthValues[k].BottomPosition = CopiedOperation.OperationData.DepthValues[k].BottomPosition - (sizeObject.Height - sizeObject2.Height);
				}
				if (CopiedOperation.OperationData.selectedPlaneName == planeNames.Top)
				{
					CopiedOperation.OperationData.DepthValues[k].TopPosition = CopiedOperation.OperationData.DepthValues[k].TopPosition + (sizeObject.Depth - sizeObject2.Depth);
					CopiedOperation.OperationData.DepthValues[k].BottomPosition = CopiedOperation.OperationData.DepthValues[k].BottomPosition + (sizeObject.Depth - sizeObject2.Depth);
				}
			}
			buShape Item = new buShapeRectangle();
			Item.BasePoint.X = CopiedOperation.OperationData.basePosition.X;
			Item.BasePoint.Y = CopiedOperation.OperationData.basePosition.Y;
			Item.BasePoint.Z = CopiedOperation.OperationData.basePosition.Z;
			clsInit.cVector5.CoordinateFromPlaneAndCorner(sizeObject, CopiedOperation.OperationData.Corner, buConversion5.PlaneNamesToPlaneBoxNames(CopiedOperation.OperationData.selectedPlaneName), ref Item, ref CopiedOperation.OperationData.Position, 1.0, -1.0);
			if ((CopiedOperation.OperationData.selectedPlaneName == planeNames.Front) | (CopiedOperation.OperationData.selectedPlaneName == planeNames.Back))
			{
				CopiedOperation.OperationData.Position.Y = CopiedOperation.OperationData.Position.Z;
			}
			if (this.Item.XReferanceLocation == LeftRightType.Right)
			{
				Item.CornerPoint.X = this.Item.Length;
			}
			if (!clsInit.cVector5.FindToolWithToolName(ccVars.Tools, CopiedOperation.OperationData.ToolName, ref ccVars.toolActive))
			{
				clsInit.cVector5.FindToolSmallMillingDiameter(ccVars.Tools, ref ccVars.toolActive);
			}
			clsInit.appProfile.doCreateOperation(CopiedOperation.Action, ccVars.toolActive, OnlyDrawing: false, AutoTool: false, ref CopiedOperation);
			this.Item.Operations.Add(CopiedOperation);
		}
		clsInit.appProfile.DrawMacroEntities(this.Item);
	}

	internal void method_5(object sender, EventArgs e)
	{
		if ((checkedListBox_0.SelectedIndex >= 0) & (checkedListBox_0.SelectedIndex <= Item.Operations.Count - 1))
		{
			CheckState itemCheckState = checkedListBox_0.GetItemCheckState(checkedListBox_0.SelectedIndex);
			if (itemCheckState != CheckState.Checked)
			{
				Item.Operations[checkedListBox_0.SelectedIndex].Enable = false;
			}
			else
			{
				Item.Operations[checkedListBox_0.SelectedIndex].Enable = true;
			}
			clsInit.appProfile.DrawMacroEntities(Item);
		}
	}

	internal void method_6(object sender, EventArgs e)
	{
		if (PropertiesForm.Inited)
		{
			DrawOperations();
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
