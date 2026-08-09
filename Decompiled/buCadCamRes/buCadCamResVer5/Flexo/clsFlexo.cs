using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buEyeBaseVer5;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buCadCamResVer5.Flexo;

public class clsFlexo
{
	public List<string> cmdExceptionID = new List<string>();

	public Design viewportSimilasyon;

	[CompilerGenerated]
	private OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler_0;

	public event OkCommandWithTwoDataEventHandler ObjectSelected
	{
		[CompilerGenerated]
		add
		{
			OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler = okCommandWithTwoDataEventHandler_0;
			OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler2;
			do
			{
				okCommandWithTwoDataEventHandler2 = okCommandWithTwoDataEventHandler;
				OkCommandWithTwoDataEventHandler value2 = (OkCommandWithTwoDataEventHandler)Delegate.Combine(okCommandWithTwoDataEventHandler2, value);
				okCommandWithTwoDataEventHandler = Interlocked.CompareExchange(ref okCommandWithTwoDataEventHandler_0, value2, okCommandWithTwoDataEventHandler2);
			}
			while ((object)okCommandWithTwoDataEventHandler != okCommandWithTwoDataEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler = okCommandWithTwoDataEventHandler_0;
			OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler2;
			do
			{
				okCommandWithTwoDataEventHandler2 = okCommandWithTwoDataEventHandler;
				OkCommandWithTwoDataEventHandler value2 = (OkCommandWithTwoDataEventHandler)Delegate.Remove(okCommandWithTwoDataEventHandler2, value);
				okCommandWithTwoDataEventHandler = Interlocked.CompareExchange(ref okCommandWithTwoDataEventHandler_0, value2, okCommandWithTwoDataEventHandler2);
			}
			while ((object)okCommandWithTwoDataEventHandler != okCommandWithTwoDataEventHandler2);
		}
	}

	public void Init()
	{
		cmdExceptionID.Add("clsProfile - ID = 101-00100");
		cmdExceptionID.Add("clsProfile - ID = 101-00101");
		cmdExceptionID.Add("clsProfile - ID = 101-00102");
		cmdExceptionID.Add("clsProfile - ID = 101-00103");
		cmdExceptionID.Add("clsProfile - ID = 101-00104");
		cmdExceptionID.Add("clsProfile - ID = 101-00105");
		cmdExceptionID.Add("clsProfile - ID = 101-00106");
		cmdExceptionID.Add("clsProfile - ID = 101-00107");
		cmdExceptionID.Add("clsProfile - ID = 101-00108");
		cmdExceptionID.Add("clsProfile - ID = 101-00109");
		cmdExceptionID.Add("clsProfile - ID = 101-00110");
		cmdExceptionID.Add("clsProfile - ID = 101-00111");
		cmdExceptionID.Add("clsProfile - ID = 101-00112");
		cmdExceptionID.Add("clsProfile - ID = 101-00113");
		cmdExceptionID.Add("clsProfile - ID = 101-00114");
		cmdExceptionID.Add("clsProfile - ID = 101-00115");
		cmdExceptionID.Add("clsProfile - ID = 101-00116");
		cmdExceptionID.Add("clsProfile - ID = 101-00117");
		cmdExceptionID.Add("clsProfile - ID = 101-00118");
		cmdExceptionID.Add("clsProfile - ID = 101-00119");
		cmdExceptionID.Add("clsProfile - ID = 101-00120");
		cmdExceptionID.Add("clsProfile - ID = 101-00121");
		cmdExceptionID.Add("clsProfile - ID = 101-00122");
		cmdExceptionID.Add("clsProfile - ID = 101-00123");
		cmdExceptionID.Add("clsProfile - ID = 101-00124");
		cmdExceptionID.Add("clsProfile - ID = 101-00125");
		cmdExceptionID.Add("clsProfile - ID = 101-00126");
		cmdExceptionID.Add("clsProfile - ID = 101-00127");
		cmdExceptionID.Add("clsProfile - ID = 101-00128");
		cmdExceptionID.Add("clsProfile - ID = 101-00129");
		cmdExceptionID.Add("clsProfile - ID = 101-00130");
		cmdExceptionID.Add("clsProfile - ID = 101-00131");
		cmdExceptionID.Add("clsProfile - ID = 101-00132");
		cmdExceptionID.Add("clsProfile - ID = 101-00133");
	}

	public void InitSimulation()
	{
		AppPath.MachineSimConfig = AppPath.Machine + "\\MachineData";
		clsFiles.OpenMachineConfig(AppPath.MachineSimConfig + "\\Machine.bumachdef", ref ccVars.SimMachine);
		if (viewportSimilasyon == null)
		{
			EyeCreateProps eyeCreateProps = new EyeCreateProps();
			eyeCreateProps.ShowToolBar = false;
			eyeCreateProps.ShowViewCube = false;
			eyeCreateProps.ShowCoordinateArrow = false;
			eyeCreateProps.PanMouseButton.Button = mouseButtonsZPR.Middle;
			eyeCreateProps.PanMouseButton.ModifierKey = devDept.Eyeshot.Control.modifierKeys.None;
			eyeCreateProps.RotateMouseButton.Button = mouseButtonsZPR.Middle;
			eyeCreateProps.RotateMouseButton.ModifierKey = devDept.Eyeshot.Control.modifierKeys.Ctrl;
			eyeCreateProps.ZoomMouseButton.Button = mouseButtonsZPR.Middle;
			eyeCreateProps.ZoomMouseButton.ModifierKey = devDept.Eyeshot.Control.modifierKeys.Shift;
			buEyeShotFunctions.CreateControlsTool(FirstCreate: true, eyeCreateProps, ref viewportSimilasyon);
			viewportSimilasyon.Dock = DockStyle.Fill;
		}
		for (int i = 0; i <= viewportSimilasyon.Layers.Count - 1; i++)
		{
			viewportSimilasyon.Layers[i].Visible = true;
		}
		viewportSimilasyon.Layers.Add(new Layer("Operation", Color.Cyan));
		viewportSimilasyon.Layers.Add(new Layer("Cam", Color.Red));
		viewportSimilasyon.Layers.Add(new Layer("Drawing", Color.Black));
		viewportSimilasyon.Layers.Add(new Layer("Machine", Color.DarkOrange));
		viewportSimilasyon.TempEntities.Clear();
		viewportSimilasyon.ActiveViewport.DisplayMode = displayType.Flat;
		viewportSimilasyon.StartAnimation();
		if (viewportSimilasyon.Blocks.Count > 1)
		{
			for (int num = viewportSimilasyon.Blocks.Count - 1; num >= 1; num--)
			{
				viewportSimilasyon.Blocks.RemoveAt(num);
			}
		}
		new List<Entity>();
		List<Entity> list = new List<Entity>();
		if (ccVars.SimMachine == null)
		{
			ccVars.SimMachine = new MachineDef();
		}
		if (ccVars.SimMachine != null)
		{
			if (ccVars.SimMachine.MachineParts.Count > 0)
			{
				for (int j = 0; j <= ccVars.SimMachine.MachineParts.Count - 1; j++)
				{
					for (int k = 0; k <= ccVars.SimMachine.MachineParts[j].Entities.Count - 1; k++)
					{
						Entity entity = buVector5.CopyEntities(ccVars.SimMachine.MachineParts[j].Entities[k]);
						CustomData customData = new CustomData();
						customData.typeDefination = entityTypeDefination.MachineParts;
						customData.EntityName = ccVars.SimMachine.MachineParts[j].PartName;
						entity.EntityData = customData;
						entity.Regen(new RegenParams(buSystem.RegenDeviation, viewportSimilasyon));
						if (!ccVars.SimMachine.MachineParts[j].AddAsMesh)
						{
							list.Add(entity);
						}
					}
				}
			}
			if (list.Count > 0)
			{
				for (int l = 0; l <= list.Count - 1; l++)
				{
					string text = ((CustomData)list[l].EntityData).EntityName;
					if (text.Length == 0)
					{
						text = "Block" + l;
					}
					Block block = new Block(text);
					Entity entity2 = buVector5.CopyEntities(list[l]);
					entity2.Color = Color.Linen;
					int alpha = 255;
					if ((ccVars.SimMachine.MachineParts[l].Transparency >= 0) & (ccVars.SimMachine.MachineParts[l].Transparency <= 255))
					{
						alpha = ccVars.SimMachine.MachineParts[l].Transparency;
					}
					if (l <= ccVars.SimMachine.MachineParts.Count - 1)
					{
						entity2.Color = Color.FromArgb(alpha, ccVars.SimMachine.MachineParts[l].Color);
					}
					entity2.ColorMethod = colorMethodType.byEntity;
					block.Entities.Add(entity2);
					viewportSimilasyon.Blocks.Add(block);
				}
			}
		}
		viewportSimilasyon.MouseDown += MouseDown_Event;
		viewportSimilasyon.MouseMove += MouseMove_Event;
		viewportSimilasyon.MouseUp += MouseUp_Event;
	}

	public void MouseMove_Event(object sender, MouseEventArgs e)
	{
	}

	public void MouseUp_Event(object sender, MouseEventArgs e)
	{
	}

	public void MouseDown_Event(object sender, MouseEventArgs e)
	{
		int entityUnderMouseCursor = viewportSimilasyon.GetEntityUnderMouseCursor(e.Location);
		if (entityUnderMouseCursor < 0)
		{
			return;
		}
		if (!(viewportSimilasyon.Entities[entityUnderMouseCursor] is buMachinePart))
		{
			if (!(viewportSimilasyon.Entities[entityUnderMouseCursor] is Mesh))
			{
				return;
			}
			Mesh mesh = viewportSimilasyon.Entities[entityUnderMouseCursor] as Mesh;
			if ((mesh.EntityData != null) & (mesh.EntityData is CustomData))
			{
				CustomData customData = mesh.EntityData as CustomData;
				if (okCommandWithTwoDataEventHandler_0 != null)
				{
					okCommandWithTwoDataEventHandler_0(customData.EntityName, "");
				}
			}
		}
		else
		{
			buMachinePart buMachinePart2 = viewportSimilasyon.Entities[entityUnderMouseCursor] as buMachinePart;
			if (okCommandWithTwoDataEventHandler_0 != null)
			{
				okCommandWithTwoDataEventHandler_0(buMachinePart2.BlockName, "");
			}
		}
	}

	public void DrawSimulationEntities(bool machine)
	{
		viewportSimilasyon.Entities.Clear();
		CustomData customData = null;
		if (machine)
		{
			for (int i = 0; i <= ccVars.SimMachine.MachineParts.Count - 1; i++)
			{
				for (int j = 0; j <= ccVars.SimMachine.MachineParts[i].Entities.Count - 1; j++)
				{
					if (ccVars.SimMachine.MachineParts[i].AddAsMesh)
					{
						Mesh mesh = (Mesh)ccVars.SimMachine.MachineParts[i].Entities[0].Clone();
						customData = new CustomData();
						customData.typeDefination = entityTypeDefination.MachineBody;
						customData.OriginalEntityIndex = viewportSimilasyon.Entities.Count;
						customData.EntityName = ccVars.SimMachine.MachineParts[i].PartName;
						int alpha = 255;
						if ((ccVars.SimMachine.MachineParts[i].Transparency >= 0) & (ccVars.SimMachine.MachineParts[i].Transparency <= 255))
						{
							alpha = ccVars.SimMachine.MachineParts[i].Transparency;
						}
						mesh.Color = Color.FromArgb(alpha, ccVars.SimMachine.MachineParts[i].Color);
						mesh.ColorMethod = colorMethodType.byEntity;
						mesh.EntityData = customData;
						mesh.LayerName = "Machine";
						double dx = ccVars.SimMachine.MachineParts[i].PositionBaseOffset.X + ccVars.SimMachine.MachineParts[i].PositionAuxOffset.X;
						double dy = ccVars.SimMachine.MachineParts[i].PositionBaseOffset.Y + ccVars.SimMachine.MachineParts[i].PositionAuxOffset.Y;
						double dz = ccVars.SimMachine.MachineParts[i].PositionBaseOffset.Z + ccVars.SimMachine.MachineParts[i].PositionAuxOffset.Z;
						mesh.Translate(dx, dy, dz);
						viewportSimilasyon.Entities.Add(mesh);
						continue;
					}
					buMachinePart buMachinePart2 = new buMachinePart(ccVars.SimMachine.MachineParts[i].PartName);
					buMachinePart2.ARotation = ccVars.SimMachine.MachineParts[i].MoveAxisPermision.A;
					buMachinePart2.BRotation = ccVars.SimMachine.MachineParts[i].MoveAxisPermision.B;
					buMachinePart2.CRotation = ccVars.SimMachine.MachineParts[i].MoveAxisPermision.C;
					buMachinePart2.XMove = ccVars.SimMachine.MachineParts[i].MoveAxisPermision.X;
					buMachinePart2.YMove = ccVars.SimMachine.MachineParts[i].MoveAxisPermision.Y;
					buMachinePart2.ZMove = ccVars.SimMachine.MachineParts[i].MoveAxisPermision.Z;
					buMachinePart2.xRot = ccVars.SimMachine.MachineParts[i].RotationCenter.X;
					buMachinePart2.yRot = ccVars.SimMachine.MachineParts[i].RotationCenter.Y;
					buMachinePart2.zRot = ccVars.SimMachine.MachineParts[i].RotationCenter.Z;
					int alpha2 = 255;
					if ((ccVars.SimMachine.MachineParts[i].Transparency >= 0) & (ccVars.SimMachine.MachineParts[i].Transparency <= 255))
					{
						alpha2 = ccVars.SimMachine.MachineParts[i].Transparency;
					}
					buMachinePart2.Color = Color.FromArgb(alpha2, ccVars.SimMachine.MachineParts[i].Color);
					buMachinePart2.ColorMethod = colorMethodType.byEntity;
					double dx2 = ccVars.SimMachine.MachineParts[i].PositionBaseOffset.X + ccVars.SimMachine.MachineParts[i].PositionAuxOffset.X;
					double dy2 = ccVars.SimMachine.MachineParts[i].PositionBaseOffset.Y + ccVars.SimMachine.MachineParts[i].PositionAuxOffset.Y;
					double dz2 = ccVars.SimMachine.MachineParts[i].PositionBaseOffset.Z + ccVars.SimMachine.MachineParts[i].PositionAuxOffset.Z;
					buMachinePart2.Translate(dx2, dy2, dz2);
					customData = new CustomData();
					customData.typeDefination = entityTypeDefination.MachineBody;
					customData.OriginalEntityIndex = viewportSimilasyon.Entities.Count;
					buMachinePart2.EntityData = customData;
					buMachinePart2.Regen(new RegenParams(buSystem.RegenDeviation, viewportSimilasyon));
					buMachinePart2.LayerName = "Machine";
					viewportSimilasyon.Entities.Add(buMachinePart2);
				}
			}
		}
		viewportSimilasyon.Entities.Regen(new RegenOptions());
		viewportSimilasyon.Invalidate();
	}

	public void AddWinder(Point3D Position, double Diameter, double Length, Color clr)
	{
		for (int i = 0; i <= viewportSimilasyon.Entities.Count - 1; i++)
		{
			if (viewportSimilasyon.Entities[i].EntityData != null && viewportSimilasyon.Entities[i].EntityData is CustomData && ((CustomData)viewportSimilasyon.Entities[i].EntityData).EntityName == "Winder")
			{
				viewportSimilasyon.Entities[i].Selected = true;
			}
		}
		viewportSimilasyon.Entities.DeleteSelected();
		Circle circle = new Circle(Plane.XZ, Position, Diameter / 2.0);
		devDept.Eyeshot.Entities.Region region = new devDept.Eyeshot.Entities.Region(circle);
		CustomData customData = new CustomData();
		customData.EntityName = "Winder";
		circle.EntityData = new CustomData();
		Mesh mesh = region.ExtrudeAsMesh(new Vector3D(0.0, Length, 0.0), 0.1, Mesh.natureType.RichPlain);
		mesh.Color = clr;
		mesh.ColorMethod = colorMethodType.byEntity;
		mesh.EntityData = customData;
		viewportSimilasyon.Entities.Add(mesh);
		viewportSimilasyon.Invalidate();
	}

	public void AddUnWinder(Point3D Position, double Diameter, double Length, Color clr)
	{
		for (int i = 0; i <= viewportSimilasyon.Entities.Count - 1; i++)
		{
			if (viewportSimilasyon.Entities[i].EntityData != null && viewportSimilasyon.Entities[i].EntityData is CustomData && ((CustomData)viewportSimilasyon.Entities[i].EntityData).EntityName == "UnWinder")
			{
				viewportSimilasyon.Entities[i].Selected = true;
			}
		}
		viewportSimilasyon.Entities.DeleteSelected();
		Circle circle = new Circle(Plane.XZ, Position, Diameter / 2.0);
		devDept.Eyeshot.Entities.Region region = new devDept.Eyeshot.Entities.Region(circle);
		CustomData customData = new CustomData();
		customData.EntityName = "UnWinder";
		circle.EntityData = new CustomData();
		Mesh mesh = region.ExtrudeAsMesh(new Vector3D(0.0, Length, 0.0), 0.1, Mesh.natureType.RichPlain);
		mesh.Color = clr;
		mesh.ColorMethod = colorMethodType.byEntity;
		mesh.EntityData = customData;
		viewportSimilasyon.Entities.Add(mesh);
		viewportSimilasyon.Invalidate();
	}

	public void MoveUnWinderFront(double Distance)
	{
		for (int i = 0; i <= viewportSimilasyon.Entities.Count - 1; i++)
		{
			if (!(viewportSimilasyon.Entities[i] is buMachinePart))
			{
				continue;
			}
			buMachinePart buMachinePart2 = viewportSimilasyon.Entities[i] as buMachinePart;
			if ((viewportSimilasyon.Entities[i].EntityData != null) & (viewportSimilasyon.Entities[i].EntityData is CustomData))
			{
				_ = viewportSimilasyon.Entities[i].EntityData is CustomData;
				if (buMachinePart2.BlockName == "UnwinderFront")
				{
					buMachinePart2.yPos = Distance;
				}
			}
		}
		viewportSimilasyon.Invalidate();
	}

	public void MoveUnWinderBack(double Distance)
	{
		for (int i = 0; i <= viewportSimilasyon.Entities.Count - 1; i++)
		{
			if (!(viewportSimilasyon.Entities[i] is buMachinePart))
			{
				continue;
			}
			buMachinePart buMachinePart2 = viewportSimilasyon.Entities[i] as buMachinePart;
			if ((viewportSimilasyon.Entities[i].EntityData != null) & (viewportSimilasyon.Entities[i].EntityData is CustomData))
			{
				_ = viewportSimilasyon.Entities[i].EntityData is CustomData;
				if (buMachinePart2.BlockName == "UnwinderBack")
				{
					buMachinePart2.yPos = Distance;
				}
			}
		}
		viewportSimilasyon.Invalidate();
	}

	public void MoveUnWinderFrontBack(double Distance)
	{
		MoveUnWinderFront(Distance);
		MoveUnWinderBack(0.0 - Distance);
	}

	public void MoveWinderFront(double Distance)
	{
		for (int i = 0; i <= viewportSimilasyon.Entities.Count - 1; i++)
		{
			if (!(viewportSimilasyon.Entities[i] is buMachinePart))
			{
				continue;
			}
			buMachinePart buMachinePart2 = viewportSimilasyon.Entities[i] as buMachinePart;
			if ((viewportSimilasyon.Entities[i].EntityData != null) & (viewportSimilasyon.Entities[i].EntityData is CustomData))
			{
				_ = viewportSimilasyon.Entities[i].EntityData is CustomData;
				if (buMachinePart2.BlockName == "WinderFront")
				{
					buMachinePart2.yPos = Distance;
				}
			}
		}
		viewportSimilasyon.Invalidate();
	}

	public void MoveWinderBack(double Distance)
	{
		for (int i = 0; i <= viewportSimilasyon.Entities.Count - 1; i++)
		{
			if (!(viewportSimilasyon.Entities[i] is buMachinePart))
			{
				continue;
			}
			buMachinePart buMachinePart2 = viewportSimilasyon.Entities[i] as buMachinePart;
			if ((viewportSimilasyon.Entities[i].EntityData != null) & (viewportSimilasyon.Entities[i].EntityData is CustomData))
			{
				_ = viewportSimilasyon.Entities[i].EntityData is CustomData;
				if (buMachinePart2.BlockName == "WinderBack")
				{
					buMachinePart2.yPos = Distance;
				}
			}
		}
		viewportSimilasyon.Invalidate();
	}

	public void MoveWinderFrontBack(double Distance)
	{
		MoveWinderFront(Distance);
		MoveWinderBack(0.0 - Distance);
	}

	public void SetObjectColor(string ObjectName, Color clr)
	{
		for (int i = 0; i <= viewportSimilasyon.Blocks.Count - 1; i++)
		{
			if (viewportSimilasyon.Blocks[i].Name == ObjectName)
			{
				viewportSimilasyon.Blocks[i].Entities[0].Color = clr;
			}
		}
		for (int j = 0; j <= viewportSimilasyon.Entities.Count - 1; j++)
		{
			if (!(viewportSimilasyon.Entities[j] is buMachinePart))
			{
				if (!(viewportSimilasyon.Entities[j] is Mesh))
				{
					continue;
				}
				Mesh mesh = viewportSimilasyon.Entities[j] as Mesh;
				if ((mesh.EntityData != null) & (mesh.EntityData is CustomData))
				{
					CustomData customData = mesh.EntityData as CustomData;
					if (customData.EntityName.ToLower() == ObjectName.ToLower())
					{
						mesh.Color = clr;
					}
				}
			}
			else
			{
				_ = viewportSimilasyon.Entities[j] is buMachinePart;
			}
		}
		viewportSimilasyon.Invalidate();
	}

	public void ScaleLine(double NewLength)
	{
		for (int i = 0; i <= viewportSimilasyon.Entities.Count - 1; i++)
		{
			if (!(viewportSimilasyon.Entities[i] is Mesh))
			{
				continue;
			}
			Mesh mesh = viewportSimilasyon.Entities[i] as Mesh;
			if (((CustomData)mesh.EntityData).EntityName == "Line")
			{
				mesh.Regen(new RegenParams(0.01, viewportSimilasyon));
				double num = mesh.BoxMax.Y - mesh.BoxMin.Y;
				if (num > 0.0)
				{
					Point3D fixedPoint = clsInit.cVector5.MiddlePointOfLine(mesh.BoxMin, mesh.BoxMax);
					double sy = NewLength / num;
					mesh.Scale(fixedPoint, 1.0, sy);
					mesh.Regen(new RegenParams(0.01, viewportSimilasyon));
				}
			}
		}
		viewportSimilasyon.Entities.Regen();
		viewportSimilasyon.Invalidate();
	}
}
