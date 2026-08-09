using System;
using System.Collections.Generic;
using System.Reflection;
using buCadCamResVer5.Forms;
using buClass;
using buEyeBaseVer5;

namespace buCadCamResVer5;

public class Pages : IDisposable
{
	private bool bool_0 = false;

	public List<PageScene> Scene = new List<PageScene>();

	public List<camTp> Cams = new List<camTp>();

	public F_Drawing Form = null;

	public List<LayerBase5> Layers = new List<LayerBase5>();

	public List<UndoV5> UndoBuffer = new List<UndoV5>();

	public List<UndoV5> RedoBuffer = new List<UndoV5>();

	public List<OsnapPoint> OsnapPoints = new List<OsnapPoint>();

	public List<OsnapPoint> OsnapTempPoints = new List<OsnapPoint>();

	public List<OsnapPoint> OsnapOtherPoints = new List<OsnapPoint>();

	public pageInfo Info = new pageInfo();

	public Vec3D MovedDistanceWhenImport = new Vec3D();

	public string PageName = "";

	public int SceneIndex = 0;

	public string SceneName = "";

	public int LayerIndex = 0;

	public int GroupIndex = 0;

	public int CamIndex = 0;

	public int BlockIndex = 0;

	public int EntityIndex = 0;

	public int EntityCounter = 1;

	public string FileName = "";

	public string LayerName = "";

	public bool Changed = false;

	public Pages()
	{
	}

	public Pages(Pages data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null))
		{
			return;
		}
		if (GetType() == CopiedClass.GetType())
		{
			FieldInfo[] fields = GetType().GetFields();
			if (fields != null)
			{
				for (int i = 0; i <= fields.Length - 1; i++)
				{
					_ = fields[i].Name;
					object value = fields[i].GetValue(CopiedClass);
					fields[i].SetValue(this, value);
				}
			}
		}
		Info = new pageInfo(data.Info);
		Form = data.Form;
		Form.viewportcad = data.Form.viewportcad.DeepClone();
		Layers.Clear();
		Cams.Clear();
		camTp.CopyCam(data.Cams, ref Cams);
		for (int j = 0; j <= data.Layers.Count - 1; j++)
		{
			LayerBase5 item = new LayerBase5(data.Layers[j]);
			Layers.Add(item);
		}
		for (int k = 0; k <= data.Scene.Count - 1; k++)
		{
			PageScene item2 = new PageScene(data.Scene[k]);
			Scene.Add(item2);
		}
	}

	~Pages()
	{
		Dispose(disposing: false);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!bool_0 && disposing)
		{
			Form.viewportcad.Dispose();
			Form.viewportcad = null;
			Layers.Clear();
			UndoBuffer.Clear();
			RedoBuffer.Clear();
			OsnapPoints.Clear();
			OsnapTempPoints.Clear();
			Scene.Clear();
			Cams.Clear();
			Scene = null;
			Form = null;
			Layers = null;
			UndoBuffer = null;
			RedoBuffer = null;
			Cams = null;
		}
		bool_0 = true;
	}
}
