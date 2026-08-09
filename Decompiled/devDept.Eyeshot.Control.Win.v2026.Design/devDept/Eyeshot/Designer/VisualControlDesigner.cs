#define WINFORMS
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Runtime.Serialization;
using System.Windows.Forms;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Control.Labels;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Designer;

public class VisualControlDesigner : Form
{
	internal static class _0023_003DzjKucw_SOIA1l
	{
		public static object _0023_003DzhL8JyLIuKkZd(object _0023_003DzD_pGWFc_003D)
		{
			Type type = _0023_003DzD_pGWFc_003D.GetType();
			if (type.IsPrimitive || type.IsEnum || type == typeof(string) || type.IsValueType || type == typeof(Bitmap))
			{
				return _0023_003DzD_pGWFc_003D;
			}
			if (type.IsArray)
			{
				Type type2 = type.GetElementType();
				Array array = _0023_003DzD_pGWFc_003D as Array;
				Array array2 = Array.CreateInstance(type2, array.Length);
				for (int i = 0; i < array.Length; i++)
				{
					object value = _0023_003DzhL8JyLIuKkZd(array.GetValue(i));
					array2.SetValue(value, i);
				}
				return array2;
			}
			if (type == typeof(ToolBarButtonList))
			{
				ToolBarButtonList toolBarButtonList = (ToolBarButtonList)_0023_003DzD_pGWFc_003D;
				ToolBarButtonList toolBarButtonList2 = new ToolBarButtonList(toolBarButtonList.ParentToolBar);
				for (int j = 0; j < toolBarButtonList.Count; j++)
				{
					object obj = _0023_003DzhL8JyLIuKkZd(toolBarButtonList[j]);
					toolBarButtonList2.Add(obj as devDept.Eyeshot.Control.ToolBarButton);
				}
				return toolBarButtonList2;
			}
			if (type == typeof(Camera))
			{
				return ((Camera)_0023_003DzD_pGWFc_003D).Clone();
			}
			if (type.IsClass)
			{
				object obj2 = ((!(_0023_003DzD_pGWFc_003D.GetType().GetConstructor(new Type[0]) != null)) ? FormatterServices.GetUninitializedObject(_0023_003DzD_pGWFc_003D.GetType()) : Activator.CreateInstance(_0023_003DzD_pGWFc_003D.GetType()));
				List<MemberInfo> list = new List<MemberInfo>();
				FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public);
				list.AddRange(fields);
				PropertyInfo[] properties = type.GetProperties();
				list.AddRange(properties);
				{
					foreach (MemberInfo item in list)
					{
						try
						{
							if (item is PropertyInfo propertyInfo && propertyInfo.GetSetMethod() != null)
							{
								if (item.Name.Equals(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318105)) || item.Name.Equals(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318090)))
								{
									continue;
								}
								object[] indexParameters = propertyInfo.GetIndexParameters();
								object[] array3 = indexParameters;
								if (array3.Length == 0)
								{
									object value2 = propertyInfo.GetValue(_0023_003DzD_pGWFc_003D, null);
									_0023_003DzqWMBVLs_003D(propertyInfo, value2, obj2);
									continue;
								}
								object[] array4 = new object[array3.Length];
								for (int k = 0; k < array3.Length; k++)
								{
									array4[k] = propertyInfo.GetValue(_0023_003DzD_pGWFc_003D, array3);
								}
								propertyInfo.SetValue(obj2, array4, null);
								continue;
							}
							if (item is FieldInfo fieldInfo)
							{
								object value3 = fieldInfo.GetValue(_0023_003DzD_pGWFc_003D);
								if (value3 != null)
								{
									fieldInfo.SetValue(obj2, _0023_003DzhL8JyLIuKkZd(value3));
								}
							}
						}
						catch (Exception)
						{
						}
					}
					return obj2;
				}
			}
			return null;
		}

		private static void _0023_003DzqWMBVLs_003D(PropertyInfo _0023_003Dzi6elBlk_003D, object _0023_003DzjmKplyA_003D, object _0023_003DzR_fiRbg_003D)
		{
			if (_0023_003DzjmKplyA_003D == null || _0023_003DzjmKplyA_003D is EyeshotCollection<Mesh>)
			{
				return;
			}
			if (_0023_003DzjmKplyA_003D is LabelList)
			{
				LabelList obj = (LabelList)_0023_003DzjmKplyA_003D;
				LabelList labelList = new LabelList((Viewport)_0023_003DzR_fiRbg_003D);
				foreach (devDept.Eyeshot.Control.Labels.Label item in obj)
				{
					labelList.Add((devDept.Eyeshot.Control.Labels.Label)_0023_003DzhL8JyLIuKkZd(item));
				}
				_0023_003Dzi6elBlk_003D.SetValue(_0023_003DzR_fiRbg_003D, labelList, null);
				return;
			}
			if (_0023_003DzjmKplyA_003D is Quaternion)
			{
				Quaternion quaternion = (Quaternion)_0023_003DzjmKplyA_003D;
				Quaternion value = new Quaternion(quaternion.X, quaternion.Y, quaternion.Z, quaternion.W);
				_0023_003Dzi6elBlk_003D.SetValue(_0023_003DzR_fiRbg_003D, value, null);
				return;
			}
			if (_0023_003DzjmKplyA_003D is Plane)
			{
				Plane plane = (Plane)_0023_003DzjmKplyA_003D;
				Plane value2 = new Plane(plane.Origin, plane.AxisZ);
				_0023_003Dzi6elBlk_003D.SetValue(_0023_003DzR_fiRbg_003D, value2, null);
				return;
			}
			try
			{
				if (_0023_003DzjmKplyA_003D is Font)
				{
					_0023_003Dzi6elBlk_003D.SetValue(_0023_003DzR_fiRbg_003D, ((Font)_0023_003DzjmKplyA_003D).Clone(), null);
				}
				else if (!(_0023_003DzR_fiRbg_003D is DefaultToolBarButton) || (!(_0023_003Dzi6elBlk_003D.Name == _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318207)) && !(_0023_003Dzi6elBlk_003D.Name == _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318180)) && !(_0023_003Dzi6elBlk_003D.Name == _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318168)) && !(_0023_003Dzi6elBlk_003D.Name == _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318152)) && !(_0023_003Dzi6elBlk_003D.Name == _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318007)) && !(_0023_003Dzi6elBlk_003D.Name == _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564317987)) && !(_0023_003Dzi6elBlk_003D.Name == _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564317979))))
				{
					if (_0023_003DzR_fiRbg_003D is Histogram && _0023_003DzjmKplyA_003D is HistogramData)
					{
						_0023_003Dzi6elBlk_003D.SetValue(_0023_003DzR_fiRbg_003D, Histogram.DefaultHistogram, null);
					}
					else
					{
						_0023_003Dzi6elBlk_003D.SetValue(_0023_003DzR_fiRbg_003D, _0023_003DzhL8JyLIuKkZd(_0023_003DzjmKplyA_003D), null);
					}
				}
			}
			catch (Exception)
			{
			}
		}

		internal static void _0023_003DzhL8JyLIuKkZd(Design _0023_003Dztw41EQ0_003D, Design _0023_003DzJDUS46c_003D)
		{
			HashSet<string> hashSet = new HashSet<string>
			{
				_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318071),
				_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318056),
				_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313322),
				_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318037),
				_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318024),
				_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564317880),
				_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312891),
				_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312863),
				_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564317883),
				_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564317870),
				_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564317856),
				_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313433),
				_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313432),
				_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312786),
				_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564317827),
				_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564317951),
				_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564317908),
				_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312626),
				_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564317889),
				_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312820),
				_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564317749),
				_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564317731),
				_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313465),
				_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564317713),
				_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564317700),
				_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564317705),
				_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564317823),
				_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564317783),
				_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564317773),
				_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319656),
				_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319637),
				_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319629),
				_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319720),
				_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319703),
				_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319684),
				_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319542),
				_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318301),
				_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319525),
				_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318314)
			};
			PropertyInfo[] properties = typeof(Workspace).GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
			((IWorkspaceInternal)_0023_003DzJDUS46c_003D).SuspendUpdate(true);
			PropertyInfo[] array = properties;
			foreach (PropertyInfo propertyInfo in array)
			{
				if (hashSet.Contains(propertyInfo.Name))
				{
					continue;
				}
				try
				{
					if (!(propertyInfo.GetSetMethod() != null))
					{
						continue;
					}
					object[] indexParameters = propertyInfo.GetIndexParameters();
					object[] array2 = indexParameters;
					if (array2.Length == 0)
					{
						object value = propertyInfo.GetValue(_0023_003Dztw41EQ0_003D, null);
						_0023_003DzqWMBVLs_003D(propertyInfo, value, _0023_003DzJDUS46c_003D);
						continue;
					}
					object[] array3 = new object[array2.Length];
					for (int j = 0; j < array2.Length; j++)
					{
						array3[j] = propertyInfo.GetValue(_0023_003Dztw41EQ0_003D, array2);
					}
					propertyInfo.SetValue(_0023_003DzJDUS46c_003D, array3, null);
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
			_0023_003DzJDUS46c_003D.Viewports.Clear();
			for (int k = 0; k < _0023_003Dztw41EQ0_003D.Viewports.Count; k++)
			{
				_0023_003DzJDUS46c_003D.Viewports.Add((Viewport)_0023_003DzhL8JyLIuKkZd(_0023_003Dztw41EQ0_003D.Viewports[k]));
			}
			((IWorkspaceInternal)_0023_003DzJDUS46c_003D).SuspendUpdate(false);
		}
	}

	private enum _0023_003Dzw2wjIKY_003D
	{

	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003Dz9yvIszad5kdpzWqoamfk8q5NGEfFxXmFXXZrywI_003D _0023_003Dz_BTD2UJxnCv4;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Design _0023_003Dz5sebEohlWR6e;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IContainer _0023_003Dzg7NzHjo_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TreeView _0023_003DzqnC_Ihh1mO5B;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button _0023_003DzXJs2BUs_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button _0023_003DzzJNwkaE_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button _0023_003Dza3_0024yxbgYpN7F;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button _0023_003Dz3fmK_bbrL_00247r;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button _0023_003Dz_0024jum24VhH0qw;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button _0023_003DzvepV2Lg_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button _0023_003DzexYCIiQ_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private SplitContainer _0023_003Dz3VM1Ns7rda_0024g;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ImageList _0023_003DzWXu3Hicmzd0k;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ImageList _0023_003Dzq9FErV3D6nUi;

	public Design Design => (Design)_0023_003Dz_BTD2UJxnCv4;

	public VisualControlDesigner(Design design)
	{
		_0023_003Dz5sebEohlWR6e = design;
		_0023_003Dz_Y_0024H3f68zohJ();
	}

	private void _0023_003DzUTc9_dmeZ1_E()
	{
		Size _0023_003Dzu52ZPXg_003D = _0023_003Dz_BTD2UJxnCv4._0023_003Dz7qa6UGU_003D();
		PresetManager.AdjustScalingLevel(this);
		_0023_003Dz_BTD2UJxnCv4._0023_003DzrhWXqVc_003D(_0023_003Dzu52ZPXg_003D);
	}

	protected override void OnLoad(EventArgs e)
	{
		base.OnLoad(e);
		_0023_003Dzvhd7LYEs5XO_();
		_0023_003DzUTc9_dmeZ1_E();
		_0023_003Dz_BTD2UJxnCv4._0023_003DzjF_DGEk_003D(_0023_003DzS3ORVrs_003D: true);
		if (_0023_003Dz5sebEohlWR6e.Viewports.Count > 0)
		{
			_0023_003DzjKucw_SOIA1l._0023_003DzhL8JyLIuKkZd(_0023_003Dz5sebEohlWR6e, Design);
			_0023_003Dz_BTD2UJxnCv4.UpdateViewportsSizeAndLocation();
		}
		_0023_003Dz_BTD2UJxnCv4._0023_003DzjF_DGEk_003D(_0023_003DzS3ORVrs_003D: false);
		TreeNode treeNode = _0023_003DzqnC_Ihh1mO5B.Nodes[0];
		treeNode.ContextMenuStrip = new ContextMenuStrip();
		treeNode.ContextMenuStrip.Items.Add(new ToolStripMenuItem(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319530), _0023_003Dz7cZkooqx14_TV6kCjyrvJyRLgYZv2GUZ4A_003D_003D._0023_003DzUl4oZ1lrSBUNV_0024V_0024Jg_003D_003D(), _0023_003DzqYfiwDVCOnWw));
		treeNode.ContextMenuStrip.Items.Add(new ToolStripMenuItem(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319489), _0023_003Dz7cZkooqx14_TV6kCjyrvJyRLgYZv2GUZ4A_003D_003D._0023_003DzUl4oZ1lrSBUNV_0024V_0024Jg_003D_003D(), _0023_003DzioBc9k9Rxve5));
		_0023_003DzqnC_Ihh1mO5B.ItemHeight += 4;
		_0023_003DzgN2J94Qd29Os();
		_0023_003Dzd4pw9rOD5nDKELa9WA_003D_003D();
		BringToFront();
		Refresh();
	}

	private void _0023_003Dzd4pw9rOD5nDKELa9WA_003D_003D()
	{
		_0023_003Dz_BTD2UJxnCv4._0023_003DzQyfmwPiEMUJskDzFSg_003D_003D();
		_0023_003Dz_BTD2UJxnCv4.Invalidate();
	}

	private void _0023_003DzqYfiwDVCOnWw(object _0023_003DzUNNLWvM_003D, EventArgs _0023_003Dz9I8ZVlc_003D)
	{
		PresetManager presetManager = new PresetManager(Design);
		PresetManager.AdjustScalingLevel(presetManager);
		if (presetManager.ShowDialog() == DialogResult.OK)
		{
			presetManager.SetTheme(Design);
			_0023_003Dzd4pw9rOD5nDKELa9WA_003D_003D();
			_0023_003DzqnC_Ihh1mO5B.Nodes[0].Nodes.Clear();
			_0023_003DzgN2J94Qd29Os();
		}
	}

	private void _0023_003DzioBc9k9Rxve5(object _0023_003DzUNNLWvM_003D, EventArgs _0023_003Dz_0024E5gy9fpCRKh)
	{
		_0023_003DzqjhbqOw_003D();
	}

	private void _0023_003DzgN2J94Qd29Os()
	{
		_0023_003DzPrYkrCGpEvi5();
		for (int i = 0; i < _0023_003Dz_BTD2UJxnCv4._0023_003DzxhpCzYbg90ykH50_0024kw_003D_003D().Count; i++)
		{
			_0023_003DzW6f7GQbK_goU(_0023_003Dz_BTD2UJxnCv4._0023_003DzxhpCzYbg90ykH50_0024kw_003D_003D()[i], i + 1);
		}
		_0023_003DzqnC_Ihh1mO5B.ExpandAll();
		if (_0023_003Dz_BTD2UJxnCv4._0023_003DzNlUL249nQ2VQ() >= 0)
		{
			_0023_003DzqnC_Ihh1mO5B.SelectedNode = _0023_003DzqnC_Ihh1mO5B.Nodes[0].Nodes[_0023_003Dz_BTD2UJxnCv4._0023_003DzNlUL249nQ2VQ()];
		}
	}

	private void _0023_003DzqjhbqOw_003D()
	{
		int count = _0023_003Dz_BTD2UJxnCv4._0023_003DzxhpCzYbg90ykH50_0024kw_003D_003D().Count;
		_0023_003Dz_BTD2UJxnCv4._0023_003DzxhpCzYbg90ykH50_0024kw_003D_003D().Add(new Viewport());
		_0023_003DzWaTgUyV4hcwF(count);
		_0023_003Dzd4pw9rOD5nDKELa9WA_003D_003D();
	}

	private void _0023_003DzWaTgUyV4hcwF(int _0023_003Dz3WEuy8OPqSabkGdApw_003D_003D)
	{
		_0023_003Dz_BTD2UJxnCv4.LayoutMode = _0023_003Dz_BTD2UJxnCv4._0023_003DzbeBFjCZDv6nS();
		_0023_003DzW6f7GQbK_goU(_0023_003Dz_BTD2UJxnCv4._0023_003DzxhpCzYbg90ykH50_0024kw_003D_003D()[_0023_003Dz_BTD2UJxnCv4._0023_003DzxhpCzYbg90ykH50_0024kw_003D_003D().Count - 1], _0023_003Dz_BTD2UJxnCv4._0023_003DzxhpCzYbg90ykH50_0024kw_003D_003D().Count);
		_0023_003DzqnC_Ihh1mO5B.ExpandAll();
	}

	private void _0023_003DzPrYkrCGpEvi5()
	{
		TreeNode treeNode = _0023_003DzqnC_Ihh1mO5B.Nodes[0];
		TreeNode treeNode2 = _0023_003DzZhf_00243x8_003D(treeNode.Nodes, _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319614), 11);
		treeNode2.ContextMenuStrip = new ContextMenuStrip();
		treeNode2.ContextMenuStrip.Items.Add(new ToolStripMenuItem(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319596), _0023_003Dz7cZkooqx14_TV6kCjyrvJyRLgYZv2GUZ4A_003D_003D._0023_003Dz6hodpW_0024XqmJl(), _0023_003DzsGQGHSVy2BAEI4WXYA_003D_003D));
	}

	private void _0023_003DzW6f7GQbK_goU(Viewport _0023_003Dz7Tv1nWI_003D, int _0023_003Dz50B94qI_003D)
	{
		TreeNode treeNode = _0023_003DzqnC_Ihh1mO5B.Nodes[0];
		TreeNode treeNode2 = _0023_003DzcPA5Jpo_003D(treeNode.Nodes, _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319558) + _0023_003Dz50B94qI_003D, 6, treeNode.Nodes.Count - 1);
		treeNode2.ContextMenuStrip = new ContextMenuStrip();
		treeNode2.ContextMenuStrip.Items.Add(new ToolStripMenuItem(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319596), _0023_003Dz7cZkooqx14_TV6kCjyrvJyRLgYZv2GUZ4A_003D_003D._0023_003DzUl4oZ1lrSBUNV_0024V_0024Jg_003D_003D(), _0023_003DzUwfsnxtAemdTNLOStQ_003D_003D));
		treeNode2.ContextMenuStrip.Items.Add(new ToolStripMenuItem(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319414), _0023_003Dz7cZkooqx14_TV6kCjyrvJyRLgYZv2GUZ4A_003D_003D._0023_003DzRuoevYo_003D(), _0023_003DzCBiHfLttCZIO));
		TreeNode treeNode3 = _0023_003DzZhf_00243x8_003D(treeNode2.Nodes, _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313432), 8);
		treeNode3.ContextMenuStrip = new ContextMenuStrip();
		treeNode3.ContextMenuStrip.Items.Add(new ToolStripMenuItem(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319408), _0023_003Dz7cZkooqx14_TV6kCjyrvJyRLgYZv2GUZ4A_003D_003D._0023_003DzRqCycrvFUsVd(), _0023_003Dz1iFlE9J5RtJO));
		TreeNode treeNode4 = treeNode3;
		for (int i = 0; i < _0023_003Dz7Tv1nWI_003D.ToolBars.Length; i++)
		{
			TreeNode treeNode5 = _0023_003DzZhf_00243x8_003D(treeNode4.Nodes, _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312749) + (i + 1), 1);
			treeNode5.ContextMenuStrip = new ContextMenuStrip();
			treeNode5.ContextMenuStrip.Items.Add(new ToolStripMenuItem(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319596), _0023_003Dz7cZkooqx14_TV6kCjyrvJyRLgYZv2GUZ4A_003D_003D._0023_003DzRqCycrvFUsVd(), _0023_003DznormPskr_k4SHogpBg_003D_003D));
			treeNode5.ContextMenuStrip.Items.Add(new ToolStripMenuItem(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319390), _0023_003Dz7cZkooqx14_TV6kCjyrvJyRLgYZv2GUZ4A_003D_003D._0023_003DzRuoevYo_003D(), delegate
			{
				Viewport viewport = _0023_003Dz_BTD2UJxnCv4._0023_003DzxhpCzYbg90ykH50_0024kw_003D_003D()[_0023_003DzUpTbozfGo6_0024S(_0023_003DzqnC_Ihh1mO5B.SelectedNode.Parent.Parent.Text)];
				if (viewport.ToolBars.Length > 1)
				{
					viewport.ToolBars = _0023_003Dz_59xj9uq1akJ(viewport.ToolBars, _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313433));
					_0023_003Dzd4pw9rOD5nDKELa9WA_003D_003D();
				}
				else
				{
					MessageBox.Show(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319356), _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319160));
				}
			}));
		}
		TreeNode treeNode6 = _0023_003DzZhf_00243x8_003D(treeNode2.Nodes, _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312935), 2);
		treeNode6.ContextMenuStrip = new ContextMenuStrip();
		treeNode6.ContextMenuStrip.Items.Add(new ToolStripMenuItem(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319596), _0023_003Dz7cZkooqx14_TV6kCjyrvJyRLgYZv2GUZ4A_003D_003D._0023_003Dz2tAdLapJks4G(), _0023_003Dz4w9JSbdrQ1vZANb__A_003D_003D));
		TreeNode treeNode7 = _0023_003DzZhf_00243x8_003D(treeNode2.Nodes, _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312756), 3);
		treeNode7.ContextMenuStrip = new ContextMenuStrip();
		treeNode7.ContextMenuStrip.Items.Add(new ToolStripMenuItem(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319596), _0023_003Dz7cZkooqx14_TV6kCjyrvJyRLgYZv2GUZ4A_003D_003D._0023_003Dz6jcsRYXDVi4a6RrGAw_003D_003D(), delegate
		{
			Viewport viewport = _0023_003Dz_BTD2UJxnCv4._0023_003DzxhpCzYbg90ykH50_0024kw_003D_003D()[_0023_003Dzh4FZ_BwzftUG(_0023_003DzqnC_Ihh1mO5B.SelectedNode.Parent.Text)];
			_0023_003DzisWXpO8vO50RcQdswsH4ivEOd0ef696J_TQcFtA_003D._0023_003DzhJgtIpS0EV9xUtYcdg_003D_003D(new UIElementDesignerForm<CoordinateSystemIcon>(viewport, viewport.CoordinateSystemIcon, _0023_003Dz5sebEohlWR6e.Site));
			_0023_003Dzd4pw9rOD5nDKELa9WA_003D_003D();
		}));
		TreeNode treeNode8 = _0023_003DzZhf_00243x8_003D(treeNode2.Nodes, _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312920), 12);
		treeNode8.ContextMenuStrip = new ContextMenuStrip();
		treeNode8.ContextMenuStrip.Items.Add(new ToolStripMenuItem(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319596), _0023_003Dz7cZkooqx14_TV6kCjyrvJyRLgYZv2GUZ4A_003D_003D._0023_003DzoWqO4uF6s1B9(), delegate
		{
			Viewport viewport = _0023_003Dz_BTD2UJxnCv4._0023_003DzxhpCzYbg90ykH50_0024kw_003D_003D()[_0023_003Dzh4FZ_BwzftUG(_0023_003DzqnC_Ihh1mO5B.SelectedNode.Parent.Text)];
			_0023_003DzisWXpO8vO50RcQdswsH4ivEOd0ef696J_TQcFtA_003D._0023_003DzhJgtIpS0EV9xUtYcdg_003D_003D(new UIElementDesignerForm<Histogram>(viewport, viewport.Histogram, _0023_003Dz5sebEohlWR6e.Site));
			_0023_003Dzd4pw9rOD5nDKELa9WA_003D_003D();
		}));
		TreeNode treeNode9 = _0023_003DzZhf_00243x8_003D(treeNode2.Nodes, _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564317827), 8);
		treeNode9.ContextMenuStrip = new ContextMenuStrip();
		treeNode9.ContextMenuStrip.Items.Add(new ToolStripMenuItem(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319369), _0023_003Dz7cZkooqx14_TV6kCjyrvJyRLgYZv2GUZ4A_003D_003D._0023_003DzQdXUIb0GxLaB(), _0023_003DzCdxCZEPklyIU));
		TreeNode treeNode10 = treeNode9;
		for (int num = 0; num < _0023_003Dz7Tv1nWI_003D.OriginSymbols.Length; num++)
		{
			TreeNode treeNode11 = _0023_003DzZhf_00243x8_003D(treeNode10.Nodes, _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312904) + (num + 1), 4);
			treeNode11.ContextMenuStrip = new ContextMenuStrip();
			treeNode11.ContextMenuStrip.Items.Add(new ToolStripMenuItem(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319596), _0023_003Dz7cZkooqx14_TV6kCjyrvJyRLgYZv2GUZ4A_003D_003D._0023_003DzQdXUIb0GxLaB(), delegate
			{
				int index = _0023_003Dzh4FZ_BwzftUG(_0023_003DzqnC_Ihh1mO5B.SelectedNode.Parent.Parent.Text);
				int num4 = _0023_003DzF_0024z55cDEsVLn(_0023_003DzqnC_Ihh1mO5B.SelectedNode.Text);
				Viewport viewport = _0023_003Dz_BTD2UJxnCv4._0023_003DzxhpCzYbg90ykH50_0024kw_003D_003D()[index];
				OriginSymbol element = viewport.OriginSymbols[num4];
				_0023_003DzisWXpO8vO50RcQdswsH4ivEOd0ef696J_TQcFtA_003D._0023_003DzhJgtIpS0EV9xUtYcdg_003D_003D(new UIElementDesignerForm<OriginSymbol>(viewport, element, _0023_003Dz5sebEohlWR6e.Site));
				_0023_003Dzd4pw9rOD5nDKELa9WA_003D_003D();
			}));
			treeNode11.ContextMenuStrip.Items.Add(new ToolStripMenuItem(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319458), _0023_003Dz7cZkooqx14_TV6kCjyrvJyRLgYZv2GUZ4A_003D_003D._0023_003DzRuoevYo_003D(), _0023_003DzIzdrIscVKrld));
		}
		TreeNode treeNode12 = _0023_003DzZhf_00243x8_003D(treeNode2.Nodes, _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564317870), 8);
		treeNode12.ContextMenuStrip = new ContextMenuStrip();
		treeNode12.ContextMenuStrip.Items.Add(new ToolStripMenuItem(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319432), _0023_003Dz7cZkooqx14_TV6kCjyrvJyRLgYZv2GUZ4A_003D_003D._0023_003DzRSsGqtH7p64jgyOwNg_003D_003D(), _0023_003DzkFZeqiP8MUHg));
		TreeNode treeNode13 = treeNode12;
		for (int num2 = 0; num2 < _0023_003Dz7Tv1nWI_003D.Legends.Length; num2++)
		{
			TreeNode treeNode14 = _0023_003DzZhf_00243x8_003D(treeNode13.Nodes, _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312734) + (num2 + 1), 5);
			treeNode14.ContextMenuStrip = new ContextMenuStrip();
			treeNode14.ContextMenuStrip.Items.Add(new ToolStripMenuItem(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319596), _0023_003Dz7cZkooqx14_TV6kCjyrvJyRLgYZv2GUZ4A_003D_003D._0023_003DzRSsGqtH7p64jgyOwNg_003D_003D(), _0023_003Dzq2oxTHzJKE8WsgjKdg_003D_003D));
			treeNode14.ContextMenuStrip.Items.Add(new ToolStripMenuItem(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319287), _0023_003Dz7cZkooqx14_TV6kCjyrvJyRLgYZv2GUZ4A_003D_003D._0023_003DzRuoevYo_003D(), _0023_003DzAPX2KwIbTQYe));
		}
		TreeNode treeNode15 = _0023_003DzZhf_00243x8_003D(treeNode2.Nodes, _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564317889), 8);
		treeNode15.ContextMenuStrip = new ContextMenuStrip();
		treeNode15.ContextMenuStrip.Items.Add(new ToolStripMenuItem(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319267), _0023_003Dz7cZkooqx14_TV6kCjyrvJyRLgYZv2GUZ4A_003D_003D._0023_003Dzs_Va_00246fxxzEt(), _0023_003DzeHg79Xy2q1UO));
		TreeNode treeNode16 = treeNode15;
		for (int num3 = 0; num3 < _0023_003Dz7Tv1nWI_003D.Grids.Length; num3++)
		{
			TreeNode treeNode17 = _0023_003DzZhf_00243x8_003D(treeNode16.Nodes, _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312720) + (num3 + 1), 10);
			treeNode17.ContextMenuStrip = new ContextMenuStrip();
			treeNode17.ContextMenuStrip.Items.Add(new ToolStripMenuItem(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319596), _0023_003Dz7cZkooqx14_TV6kCjyrvJyRLgYZv2GUZ4A_003D_003D._0023_003Dzs_Va_00246fxxzEt(), _0023_003DzxcZQfVGrE27Hq7JIMg_003D_003D));
			treeNode17.ContextMenuStrip.Items.Add(new ToolStripMenuItem(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319252), _0023_003Dz7cZkooqx14_TV6kCjyrvJyRLgYZv2GUZ4A_003D_003D._0023_003DzRuoevYo_003D(), _0023_003DztFCOe0OeUjZX));
		}
		TreeNode treeNode18 = _0023_003DzZhf_00243x8_003D(treeNode2.Nodes, _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312820), 13);
		treeNode18.ContextMenuStrip = new ContextMenuStrip();
		treeNode18.ContextMenuStrip.Items.Add(new ToolStripMenuItem(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319596), _0023_003Dz7cZkooqx14_TV6kCjyrvJyRLgYZv2GUZ4A_003D_003D._0023_003Dz2zk9sCrygrSizu_0024Tpw_003D_003D(), delegate
		{
			Viewport viewport = _0023_003Dz_BTD2UJxnCv4._0023_003DzxhpCzYbg90ykH50_0024kw_003D_003D()[_0023_003Dzh4FZ_BwzftUG(_0023_003DzqnC_Ihh1mO5B.SelectedNode.Parent.Text)];
			_0023_003DzisWXpO8vO50RcQdswsH4ivEOd0ef696J_TQcFtA_003D._0023_003DzhJgtIpS0EV9xUtYcdg_003D_003D(new UIElementDesignerForm<ScaleBar>(viewport, viewport.ScaleBar, _0023_003Dz5sebEohlWR6e.Site));
			_0023_003Dzd4pw9rOD5nDKELa9WA_003D_003D();
		}));
	}

	private T[] _0023_003Dz_59xj9uq1akJ<T>(T[] _0023_003Dz9H_0024mxvM_003D, string _0023_003DzSYuYstc_003D) where T : new()
	{
		int num = _0023_003Dz25hscC8_003D(_0023_003DzqnC_Ihh1mO5B.SelectedNode.Text, _0023_003DzSYuYstc_003D);
		T[] array = new T[_0023_003Dz9H_0024mxvM_003D.Length - 1];
		int num2 = 0;
		for (int i = 0; i < _0023_003Dz9H_0024mxvM_003D.Length; i++)
		{
			if (i != num)
			{
				array[num2++] = _0023_003Dz9H_0024mxvM_003D[i];
			}
		}
		TreeNode treeNode = _0023_003DzqnC_Ihh1mO5B.SelectedNode.Parent;
		treeNode.Nodes.RemoveAt(num);
		for (int j = 0; j < treeNode.Nodes.Count; j++)
		{
			treeNode.Nodes[j].Text = _0023_003DzSYuYstc_003D + _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319234) + (j + 1);
		}
		return array;
	}

	private int _0023_003Dz25hscC8_003D(string _0023_003Dz68rgvJU_003D, string _0023_003DzSYuYstc_003D)
	{
		return Convert.ToInt32(_0023_003Dz68rgvJU_003D.Substring(_0023_003DzSYuYstc_003D.Length + 1)) - 1;
	}

	private void _0023_003DztFCOe0OeUjZX(object _0023_003DzUNNLWvM_003D, EventArgs _0023_003Dz9I8ZVlc_003D)
	{
		Viewport viewport = _0023_003Dz_BTD2UJxnCv4._0023_003DzxhpCzYbg90ykH50_0024kw_003D_003D()[_0023_003Dzh4FZ_BwzftUG(_0023_003DzqnC_Ihh1mO5B.SelectedNode.Parent.Parent.Text)];
		viewport.Grids = _0023_003Dz_59xj9uq1akJ(viewport.Grids, _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312626));
		_0023_003Dzd4pw9rOD5nDKELa9WA_003D_003D();
	}

	private int _0023_003DzfaLDxG2Fjmb1(string _0023_003Dz68rgvJU_003D)
	{
		return _0023_003Dz25hscC8_003D(_0023_003Dz68rgvJU_003D, _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312626));
	}

	private void _0023_003DzxcZQfVGrE27Hq7JIMg_003D_003D(object _0023_003DzUNNLWvM_003D, EventArgs _0023_003Dz9I8ZVlc_003D)
	{
		int index = _0023_003Dzh4FZ_BwzftUG(_0023_003DzqnC_Ihh1mO5B.SelectedNode.Parent.Parent.Text);
		int num = _0023_003DzfaLDxG2Fjmb1(_0023_003DzqnC_Ihh1mO5B.SelectedNode.Text);
		Grid element = _0023_003Dz_BTD2UJxnCv4._0023_003DzxhpCzYbg90ykH50_0024kw_003D_003D()[index].Grids[num];
		_0023_003DzisWXpO8vO50RcQdswsH4ivEOd0ef696J_TQcFtA_003D._0023_003DzhJgtIpS0EV9xUtYcdg_003D_003D(new UIElementDesignerForm<Grid>(_0023_003Dz_BTD2UJxnCv4._0023_003DzxhpCzYbg90ykH50_0024kw_003D_003D()[index], element, _0023_003Dz5sebEohlWR6e.Site));
		_0023_003Dzd4pw9rOD5nDKELa9WA_003D_003D();
	}

	private void _0023_003DzeHg79Xy2q1UO(object _0023_003DzUNNLWvM_003D, EventArgs _0023_003Dz9I8ZVlc_003D)
	{
		int _0023_003Dzcp3dyG4_003D = _0023_003Dzh4FZ_BwzftUG(_0023_003DzqnC_Ihh1mO5B.SelectedNode.Parent.Text);
		_0023_003DzXM6UYeFB6PXg(_0023_003Dzcp3dyG4_003D, new Grid());
		_0023_003Dzd4pw9rOD5nDKELa9WA_003D_003D();
	}

	private T[] _0023_003Dzb1SdwLwbxaF9<T>(T[] _0023_003Dz9H_0024mxvM_003D, T _0023_003DzPxNQpc8_003D, string _0023_003DzSYuYstc_003D, Bitmap _0023_003DzAwCvcQQ_003D, int _0023_003Dz5TdGSkE_003D, EventHandler _0023_003DzPhTZxf_2SL6L, EventHandler _0023_003Dz1qrXvHRLQdyY) where T : new()
	{
		T[] array = new T[_0023_003Dz9H_0024mxvM_003D.Length + 1];
		Array.Copy(_0023_003Dz9H_0024mxvM_003D, array, _0023_003Dz9H_0024mxvM_003D.Length);
		array[array.Length - 1] = _0023_003DzPxNQpc8_003D;
		TreeNode treeNode = _0023_003DzZhf_00243x8_003D(_0023_003DzqnC_Ihh1mO5B.SelectedNode.Nodes, _0023_003DzSYuYstc_003D + _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319234) + array.Length, _0023_003Dz5TdGSkE_003D);
		treeNode.ContextMenuStrip = new ContextMenuStrip();
		treeNode.ContextMenuStrip.Items.Add(new ToolStripMenuItem(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319596), _0023_003DzAwCvcQQ_003D, _0023_003DzPhTZxf_2SL6L));
		treeNode.ContextMenuStrip.Items.Add(new ToolStripMenuItem(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319242) + _0023_003DzSYuYstc_003D, _0023_003Dz7cZkooqx14_TV6kCjyrvJyRLgYZv2GUZ4A_003D_003D._0023_003DzQk5ptKRUh0mB(), _0023_003Dz1qrXvHRLQdyY));
		return array;
	}

	private void _0023_003DzXM6UYeFB6PXg(int _0023_003Dzcp3dyG4_003D, Grid _0023_003DzZs4nYYE_003D)
	{
		Viewport viewport = _0023_003Dz_BTD2UJxnCv4._0023_003DzxhpCzYbg90ykH50_0024kw_003D_003D()[_0023_003Dzcp3dyG4_003D];
		viewport.Grids = _0023_003Dzb1SdwLwbxaF9(viewport.Grids, _0023_003DzZs4nYYE_003D, _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312626), _0023_003Dz7cZkooqx14_TV6kCjyrvJyRLgYZv2GUZ4A_003D_003D._0023_003Dzs_Va_00246fxxzEt(), 10, _0023_003DzxcZQfVGrE27Hq7JIMg_003D_003D, _0023_003DztFCOe0OeUjZX);
	}

	private void _0023_003DzUwfsnxtAemdTNLOStQ_003D_003D(object _0023_003DzUNNLWvM_003D, EventArgs _0023_003Dz9I8ZVlc_003D)
	{
		int index = _0023_003Dzh4FZ_BwzftUG(_0023_003DzqnC_Ihh1mO5B.SelectedNode.Text);
		new global::_0023_003DzRW_0024jW9nQffY2PQF66NmBPMsHZgFjqpF7bYSB0mk_003D<Viewport>(_0023_003Dz_BTD2UJxnCv4._0023_003DzxhpCzYbg90ykH50_0024kw_003D_003D()[index], _0023_003Dz5sebEohlWR6e.Site).ShowDialog();
		_0023_003Dzd4pw9rOD5nDKELa9WA_003D_003D();
	}

	private TreeNode _0023_003DzZhf_00243x8_003D(TreeNodeCollection _0023_003DzkFkEFX8_003D, string _0023_003Dz68rgvJU_003D, int _0023_003Dz5TdGSkE_003D)
	{
		return _0023_003DzcPA5Jpo_003D(_0023_003DzkFkEFX8_003D, _0023_003Dz68rgvJU_003D, _0023_003Dz5TdGSkE_003D, _0023_003DzkFkEFX8_003D.Count);
	}

	private TreeNode _0023_003DzcPA5Jpo_003D(TreeNodeCollection _0023_003DzkFkEFX8_003D, string _0023_003Dz68rgvJU_003D, int _0023_003Dz5TdGSkE_003D, int _0023_003Dz2XS3b4Q_003D)
	{
		TreeNode treeNode = _0023_003DzkFkEFX8_003D.Insert(_0023_003Dz2XS3b4Q_003D, _0023_003Dz68rgvJU_003D);
		treeNode.ImageIndex = _0023_003Dz5TdGSkE_003D;
		treeNode.SelectedImageIndex = _0023_003Dz5TdGSkE_003D;
		return treeNode;
	}

	private void _0023_003DzAPX2KwIbTQYe(object _0023_003DzUNNLWvM_003D, EventArgs _0023_003Dz9I8ZVlc_003D)
	{
		Viewport viewport = _0023_003Dz_BTD2UJxnCv4._0023_003DzxhpCzYbg90ykH50_0024kw_003D_003D()[_0023_003Dzh4FZ_BwzftUG(_0023_003DzqnC_Ihh1mO5B.SelectedNode.Parent.Parent.Text)];
		viewport.Legends = _0023_003Dz_59xj9uq1akJ(viewport.Legends, _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312783));
		_0023_003Dzd4pw9rOD5nDKELa9WA_003D_003D();
	}

	private int _0023_003DzTTiqM0fMIWpZ(string _0023_003Dz68rgvJU_003D)
	{
		return _0023_003Dz25hscC8_003D(_0023_003Dz68rgvJU_003D, _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312783));
	}

	private void _0023_003DzVVOq8jD_0024cwn0(object _0023_003DzUNNLWvM_003D, EventArgs _0023_003Dz9I8ZVlc_003D)
	{
		Viewport viewport = _0023_003Dz_BTD2UJxnCv4._0023_003DzxhpCzYbg90ykH50_0024kw_003D_003D()[_0023_003DzUpTbozfGo6_0024S(_0023_003DzqnC_Ihh1mO5B.SelectedNode.Parent.Parent.Text)];
		if (viewport.ToolBars.Length > 1)
		{
			viewport.ToolBars = _0023_003Dz_59xj9uq1akJ(viewport.ToolBars, _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313433));
			_0023_003Dzd4pw9rOD5nDKELa9WA_003D_003D();
		}
		else
		{
			MessageBox.Show(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319356), _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319160));
		}
	}

	private int _0023_003DzUpTbozfGo6_0024S(string _0023_003Dz68rgvJU_003D)
	{
		return _0023_003Dz25hscC8_003D(_0023_003Dz68rgvJU_003D, _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313433));
	}

	private int _0023_003Dzh4FZ_BwzftUG(string _0023_003Dz68rgvJU_003D)
	{
		if (_0023_003DzqnC_Ihh1mO5B.Nodes[0].Nodes.Count == 1)
		{
			return -1;
		}
		return Convert.ToInt32(_0023_003Dz68rgvJU_003D.Substring(9)) - 1;
	}

	private void _0023_003Dzq2oxTHzJKE8WsgjKdg_003D_003D(object _0023_003DzUNNLWvM_003D, EventArgs _0023_003Dz_0024E5gy9fpCRKh)
	{
		int index = _0023_003Dzh4FZ_BwzftUG(_0023_003DzqnC_Ihh1mO5B.SelectedNode.Parent.Parent.Text);
		int num = _0023_003DzTTiqM0fMIWpZ(_0023_003DzqnC_Ihh1mO5B.SelectedNode.Text);
		Legend legend = _0023_003Dz_BTD2UJxnCv4._0023_003DzxhpCzYbg90ykH50_0024kw_003D_003D()[index].Legends[num];
		Rectangle bounds = legend.GetBounds(_0023_003Dz_BTD2UJxnCv4._0023_003DzxhpCzYbg90ykH50_0024kw_003D_003D()[index]);
		if (bounds.Width == 0 || bounds.Height == 0)
		{
			bool visible = legend.Visible;
			legend.Visible = true;
			_0023_003Dz_BTD2UJxnCv4._0023_003DzQyfmwPiEMUJskDzFSg_003D_003D();
			legend.Visible = visible;
		}
		_0023_003DzisWXpO8vO50RcQdswsH4ivEOd0ef696J_TQcFtA_003D._0023_003DzhJgtIpS0EV9xUtYcdg_003D_003D(new UIElementDesignerForm<Legend>(_0023_003Dz_BTD2UJxnCv4._0023_003DzxhpCzYbg90ykH50_0024kw_003D_003D()[index], legend, _0023_003Dz5sebEohlWR6e.Site));
		_0023_003Dzd4pw9rOD5nDKELa9WA_003D_003D();
	}

	private void _0023_003DzkFZeqiP8MUHg(object _0023_003DzUNNLWvM_003D, EventArgs _0023_003Dz_0024E5gy9fpCRKh)
	{
		int index = _0023_003Dzh4FZ_BwzftUG(_0023_003DzqnC_Ihh1mO5B.SelectedNode.Parent.Text);
		Viewport _0023_003Dzy6tHi4E_003D = _0023_003Dz_BTD2UJxnCv4._0023_003DzxhpCzYbg90ykH50_0024kw_003D_003D()[index];
		_0023_003Dz5fSJN6Qle8Fd(_0023_003Dzy6tHi4E_003D, new Legend());
		_0023_003Dzd4pw9rOD5nDKELa9WA_003D_003D();
	}

	private void _0023_003Dz5fSJN6Qle8Fd(Viewport _0023_003Dzy6tHi4E_003D, Legend _0023_003DzDQEwRLKjoA2T)
	{
		_0023_003Dzy6tHi4E_003D.Legends = _0023_003Dzb1SdwLwbxaF9(_0023_003Dzy6tHi4E_003D.Legends, _0023_003DzDQEwRLKjoA2T, _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312783), _0023_003Dz7cZkooqx14_TV6kCjyrvJyRLgYZv2GUZ4A_003D_003D._0023_003DzRSsGqtH7p64jgyOwNg_003D_003D(), 5, _0023_003Dzq2oxTHzJKE8WsgjKdg_003D_003D, _0023_003DzAPX2KwIbTQYe);
	}

	private void _0023_003Dz1iFlE9J5RtJO(object _0023_003DzUNNLWvM_003D, EventArgs _0023_003Dz_0024E5gy9fpCRKh)
	{
		int index = _0023_003Dzh4FZ_BwzftUG(_0023_003DzqnC_Ihh1mO5B.SelectedNode.Parent.Text);
		Viewport _0023_003Dzy6tHi4E_003D = _0023_003Dz_BTD2UJxnCv4._0023_003DzxhpCzYbg90ykH50_0024kw_003D_003D()[index];
		_0023_003DzdW0e_sO49fU5(_0023_003Dzy6tHi4E_003D, devDept.Eyeshot.Control.ToolBar.GetDefaultToolBar());
		_0023_003Dzd4pw9rOD5nDKELa9WA_003D_003D();
	}

	private void _0023_003DzdW0e_sO49fU5(Viewport _0023_003Dzy6tHi4E_003D, devDept.Eyeshot.Control.ToolBar _0023_003DzOBVza_0024iudg3f)
	{
		_0023_003Dzy6tHi4E_003D.ToolBars = _0023_003Dzb1SdwLwbxaF9(_0023_003Dzy6tHi4E_003D.ToolBars, _0023_003DzOBVza_0024iudg3f, _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313433), _0023_003Dz7cZkooqx14_TV6kCjyrvJyRLgYZv2GUZ4A_003D_003D._0023_003DzRqCycrvFUsVd(), 1, _0023_003DznormPskr_k4SHogpBg_003D_003D, delegate
		{
			Viewport viewport = _0023_003Dz_BTD2UJxnCv4._0023_003DzxhpCzYbg90ykH50_0024kw_003D_003D()[_0023_003DzUpTbozfGo6_0024S(_0023_003DzqnC_Ihh1mO5B.SelectedNode.Parent.Parent.Text)];
			if (viewport.ToolBars.Length > 1)
			{
				viewport.ToolBars = _0023_003Dz_59xj9uq1akJ(viewport.ToolBars, _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313433));
				_0023_003Dzd4pw9rOD5nDKELa9WA_003D_003D();
			}
			else
			{
				MessageBox.Show(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319356), _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319160));
			}
		});
	}

	private int _0023_003DzF_0024z55cDEsVLn(string _0023_003Dz68rgvJU_003D)
	{
		return _0023_003Dz25hscC8_003D(_0023_003Dz68rgvJU_003D, _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312786));
	}

	private void _0023_003DzIzdrIscVKrld(object _0023_003DzUNNLWvM_003D, EventArgs _0023_003Dz9I8ZVlc_003D)
	{
		Viewport viewport = _0023_003Dz_BTD2UJxnCv4._0023_003DzxhpCzYbg90ykH50_0024kw_003D_003D()[_0023_003Dzh4FZ_BwzftUG(_0023_003DzqnC_Ihh1mO5B.SelectedNode.Parent.Parent.Text)];
		viewport.OriginSymbols = _0023_003Dz_59xj9uq1akJ(viewport.OriginSymbols, _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312786));
		_0023_003Dzd4pw9rOD5nDKELa9WA_003D_003D();
	}

	private void _0023_003DzCdxCZEPklyIU(object _0023_003DzUNNLWvM_003D, EventArgs _0023_003Dz9I8ZVlc_003D)
	{
		int _0023_003Dzcp3dyG4_003D = _0023_003Dzh4FZ_BwzftUG(_0023_003DzqnC_Ihh1mO5B.SelectedNode.Parent.Text);
		_0023_003DzRGwsdgn043YG(_0023_003Dzcp3dyG4_003D, OriginSymbol.GetDefaultOriginSymbol());
		_0023_003Dzd4pw9rOD5nDKELa9WA_003D_003D();
	}

	private void _0023_003DzRGwsdgn043YG(int _0023_003Dzcp3dyG4_003D, OriginSymbol _0023_003DzZAfCTqw_003D)
	{
		Viewport viewport = _0023_003Dz_BTD2UJxnCv4._0023_003DzxhpCzYbg90ykH50_0024kw_003D_003D()[_0023_003Dzcp3dyG4_003D];
		viewport.OriginSymbols = _0023_003Dzb1SdwLwbxaF9(viewport.OriginSymbols, _0023_003DzZAfCTqw_003D, _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312786), _0023_003Dz7cZkooqx14_TV6kCjyrvJyRLgYZv2GUZ4A_003D_003D._0023_003DzQdXUIb0GxLaB(), 4, delegate
		{
			int index = _0023_003Dzh4FZ_BwzftUG(_0023_003DzqnC_Ihh1mO5B.SelectedNode.Parent.Parent.Text);
			int num = _0023_003DzF_0024z55cDEsVLn(_0023_003DzqnC_Ihh1mO5B.SelectedNode.Text);
			Viewport viewport2 = _0023_003Dz_BTD2UJxnCv4._0023_003DzxhpCzYbg90ykH50_0024kw_003D_003D()[index];
			OriginSymbol element = viewport2.OriginSymbols[num];
			_0023_003DzisWXpO8vO50RcQdswsH4ivEOd0ef696J_TQcFtA_003D._0023_003DzhJgtIpS0EV9xUtYcdg_003D_003D(new UIElementDesignerForm<OriginSymbol>(viewport2, element, _0023_003Dz5sebEohlWR6e.Site));
			_0023_003Dzd4pw9rOD5nDKELa9WA_003D_003D();
		}, _0023_003DzIzdrIscVKrld);
	}

	private void _0023_003Dznbahk1U9E_0024a8nP4GfQ_003D_003D(object _0023_003DzUNNLWvM_003D, EventArgs _0023_003Dz_0024E5gy9fpCRKh)
	{
		int index = _0023_003Dzh4FZ_BwzftUG(_0023_003DzqnC_Ihh1mO5B.SelectedNode.Parent.Parent.Text);
		int num = _0023_003DzF_0024z55cDEsVLn(_0023_003DzqnC_Ihh1mO5B.SelectedNode.Text);
		Viewport viewport = _0023_003Dz_BTD2UJxnCv4._0023_003DzxhpCzYbg90ykH50_0024kw_003D_003D()[index];
		OriginSymbol element = viewport.OriginSymbols[num];
		_0023_003DzisWXpO8vO50RcQdswsH4ivEOd0ef696J_TQcFtA_003D._0023_003DzhJgtIpS0EV9xUtYcdg_003D_003D(new UIElementDesignerForm<OriginSymbol>(viewport, element, _0023_003Dz5sebEohlWR6e.Site));
		_0023_003Dzd4pw9rOD5nDKELa9WA_003D_003D();
	}

	private void _0023_003DzW9SY_00247T1_HKfwiketaUto00_003D(object _0023_003DzUNNLWvM_003D, EventArgs _0023_003Dz_0024E5gy9fpCRKh)
	{
		Viewport viewport = _0023_003Dz_BTD2UJxnCv4._0023_003DzxhpCzYbg90ykH50_0024kw_003D_003D()[_0023_003Dzh4FZ_BwzftUG(_0023_003DzqnC_Ihh1mO5B.SelectedNode.Parent.Text)];
		_0023_003DzisWXpO8vO50RcQdswsH4ivEOd0ef696J_TQcFtA_003D._0023_003DzhJgtIpS0EV9xUtYcdg_003D_003D(new UIElementDesignerForm<CoordinateSystemIcon>(viewport, viewport.CoordinateSystemIcon, _0023_003Dz5sebEohlWR6e.Site));
		_0023_003Dzd4pw9rOD5nDKELa9WA_003D_003D();
	}

	private void _0023_003Dzh_cAjFzr_0024jVjB_zFgQ_003D_003D(object _0023_003DzUNNLWvM_003D, EventArgs _0023_003Dz_0024E5gy9fpCRKh)
	{
		Viewport viewport = _0023_003Dz_BTD2UJxnCv4._0023_003DzxhpCzYbg90ykH50_0024kw_003D_003D()[_0023_003Dzh4FZ_BwzftUG(_0023_003DzqnC_Ihh1mO5B.SelectedNode.Parent.Text)];
		_0023_003DzisWXpO8vO50RcQdswsH4ivEOd0ef696J_TQcFtA_003D._0023_003DzhJgtIpS0EV9xUtYcdg_003D_003D(new UIElementDesignerForm<Histogram>(viewport, viewport.Histogram, _0023_003Dz5sebEohlWR6e.Site));
		_0023_003Dzd4pw9rOD5nDKELa9WA_003D_003D();
	}

	private void _0023_003DznormPskr_k4SHogpBg_003D_003D(object _0023_003DzUNNLWvM_003D, EventArgs _0023_003Dz_0024E5gy9fpCRKh)
	{
		int index = _0023_003Dzh4FZ_BwzftUG(_0023_003DzqnC_Ihh1mO5B.SelectedNode.Parent.Parent.Text);
		int num = _0023_003DzUpTbozfGo6_0024S(_0023_003DzqnC_Ihh1mO5B.SelectedNode.Text);
		devDept.Eyeshot.Control.ToolBar toolBar = _0023_003Dz_BTD2UJxnCv4._0023_003DzxhpCzYbg90ykH50_0024kw_003D_003D()[index].ToolBars[num];
		Rectangle bounds = toolBar.GetBounds(_0023_003Dz_BTD2UJxnCv4._0023_003DzxhpCzYbg90ykH50_0024kw_003D_003D()[index]);
		if (bounds.Width == 0 || bounds.Height == 0)
		{
			bool visible = toolBar.Visible;
			toolBar.Visible = true;
			_0023_003Dz_BTD2UJxnCv4._0023_003DzQyfmwPiEMUJskDzFSg_003D_003D();
			toolBar.Visible = visible;
		}
		Viewport viewport = _0023_003Dz_BTD2UJxnCv4._0023_003DzxhpCzYbg90ykH50_0024kw_003D_003D()[index];
		_0023_003DzisWXpO8vO50RcQdswsH4ivEOd0ef696J_TQcFtA_003D._0023_003DzhJgtIpS0EV9xUtYcdg_003D_003D(new UIElementDesignerForm<devDept.Eyeshot.Control.ToolBar>(viewport, viewport.ToolBar, _0023_003Dz5sebEohlWR6e.Site));
		_0023_003Dzd4pw9rOD5nDKELa9WA_003D_003D();
	}

	private void _0023_003Dz4w9JSbdrQ1vZANb__A_003D_003D(object _0023_003DzUNNLWvM_003D, EventArgs _0023_003Dz_0024E5gy9fpCRKh)
	{
		Viewport viewport = _0023_003Dz_BTD2UJxnCv4._0023_003DzxhpCzYbg90ykH50_0024kw_003D_003D()[_0023_003Dzh4FZ_BwzftUG(_0023_003DzqnC_Ihh1mO5B.SelectedNode.Parent.Text)];
		_0023_003DzisWXpO8vO50RcQdswsH4ivEOd0ef696J_TQcFtA_003D._0023_003DzhJgtIpS0EV9xUtYcdg_003D_003D(new UIElementDesignerForm<ViewCubeIcon>(viewport, viewport.ViewCubeIcon, _0023_003Dz5sebEohlWR6e.Site));
		_0023_003Dzd4pw9rOD5nDKELa9WA_003D_003D();
	}

	private void _0023_003DzsGQGHSVy2BAEI4WXYA_003D_003D(object _0023_003DzUNNLWvM_003D, EventArgs _0023_003Dz9I8ZVlc_003D)
	{
		_0023_003DzisWXpO8vO50RcQdswsH4ivEOd0ef696J_TQcFtA_003D._0023_003DzhJgtIpS0EV9xUtYcdg_003D_003D(new UIElementDesignerForm<devDept.Eyeshot.Control.ProgressBar>(_0023_003Dz_BTD2UJxnCv4._0023_003DzaJkT5o_GPTVq(), _0023_003Dz_BTD2UJxnCv4._0023_003Dzitnp83w1mzyV(), _0023_003Dz5sebEohlWR6e.Site));
		_0023_003Dzd4pw9rOD5nDKELa9WA_003D_003D();
	}

	private void _0023_003DzduelG_0024WlnYWUj8OCOQ_003D_003D(object _0023_003DzUNNLWvM_003D, EventArgs _0023_003Dz_0024E5gy9fpCRKh)
	{
		Viewport viewport = _0023_003Dz_BTD2UJxnCv4._0023_003DzxhpCzYbg90ykH50_0024kw_003D_003D()[_0023_003Dzh4FZ_BwzftUG(_0023_003DzqnC_Ihh1mO5B.SelectedNode.Parent.Text)];
		_0023_003DzisWXpO8vO50RcQdswsH4ivEOd0ef696J_TQcFtA_003D._0023_003DzhJgtIpS0EV9xUtYcdg_003D_003D(new UIElementDesignerForm<ScaleBar>(viewport, viewport.ScaleBar, _0023_003Dz5sebEohlWR6e.Site));
		_0023_003Dzd4pw9rOD5nDKELa9WA_003D_003D();
	}

	private void _0023_003DzCBiHfLttCZIO(object _0023_003DzUNNLWvM_003D, EventArgs _0023_003Dz_0024E5gy9fpCRKh)
	{
		int index = _0023_003Dzh4FZ_BwzftUG(_0023_003DzqnC_Ihh1mO5B.SelectedNode.Text);
		_0023_003Dz_BTD2UJxnCv4._0023_003DzxhpCzYbg90ykH50_0024kw_003D_003D().RemoveAt(index);
		_0023_003DzqnC_Ihh1mO5B.Nodes.Remove(_0023_003DzqnC_Ihh1mO5B.SelectedNode);
		if (_0023_003Dz_BTD2UJxnCv4._0023_003DzxhpCzYbg90ykH50_0024kw_003D_003D().Count > 0)
		{
			if (_0023_003Dz_BTD2UJxnCv4._0023_003DzNlUL249nQ2VQ() >= _0023_003Dz_BTD2UJxnCv4._0023_003DzxhpCzYbg90ykH50_0024kw_003D_003D().Count)
			{
				_0023_003Dz_BTD2UJxnCv4._0023_003DzNiHkPug7sG0i(_0023_003Dz_BTD2UJxnCv4._0023_003DzxhpCzYbg90ykH50_0024kw_003D_003D().Count - 1);
			}
			TreeNode treeNode = _0023_003DzqnC_Ihh1mO5B.Nodes[0];
			for (int i = 0; i < treeNode.Nodes.Count - 1; i++)
			{
				treeNode.Nodes[i].Text = _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319558) + (i + 1);
			}
			if (_0023_003Dz_BTD2UJxnCv4._0023_003DzxhpCzYbg90ykH50_0024kw_003D_003D().Count != 0)
			{
				_0023_003Dz_BTD2UJxnCv4.LayoutMode = _0023_003Dz_BTD2UJxnCv4._0023_003DzbeBFjCZDv6nS();
			}
			if (_0023_003Dz_BTD2UJxnCv4._0023_003DzNlUL249nQ2VQ() >= _0023_003Dz_BTD2UJxnCv4._0023_003DzxhpCzYbg90ykH50_0024kw_003D_003D().Count)
			{
				_0023_003Dz_BTD2UJxnCv4._0023_003DzNiHkPug7sG0i(_0023_003Dz_BTD2UJxnCv4._0023_003DzxhpCzYbg90ykH50_0024kw_003D_003D().Count - 1);
			}
		}
		_0023_003Dzd4pw9rOD5nDKELa9WA_003D_003D();
	}

	private System.Windows.Forms.Control _0023_003DzuU3Z_0024G4_003D<T>(Size _0023_003DzGjBPRY8_003D, System.Drawing.Point _0023_003DzRKv_GPMos6QE) where T : Design, new()
	{
		T val = new T();
		val.Tag = _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313235);
		val.Size = _0023_003DzGjBPRY8_003D;
		val.Dock = DockStyle.None;
		val.Anchor = AnchorStyles.None;
		val.Location = _0023_003DzRKv_GPMos6QE;
		val.InitializeViewports();
		val.CreateControl();
		val.CreateGraphics();
		val.Enabled = false;
		return val;
	}

	private void _0023_003Dzvhd7LYEs5XO_()
	{
		if (_0023_003Dz5sebEohlWR6e.GetType() == typeof(Manufacture))
		{
			_0023_003Dz_BTD2UJxnCv4 = (_0023_003DzXFeWo1_MCso7L4um1qNh5rapS7zbQgwMWXqv_0024kRZvu0BkR0AjA_003D_003D)_0023_003DzuU3Z_0024G4_003D<_0023_003DzXFeWo1_MCso7L4um1qNh5rapS7zbQgwMWXqv_0024kRZvu0BkR0AjA_003D_003D>(_0023_003Dz5sebEohlWR6e.Size, new System.Drawing.Point(0, 0));
		}
		else if (_0023_003Dz5sebEohlWR6e.GetType() == typeof(Simulation))
		{
			_0023_003Dz_BTD2UJxnCv4 = (_0023_003DzlL6NW6ZOw4YTWDopi2MLYOVPJD8a_oo46w3V3QY_003D)_0023_003DzuU3Z_0024G4_003D<_0023_003DzlL6NW6ZOw4YTWDopi2MLYOVPJD8a_oo46w3V3QY_003D>(_0023_003Dz5sebEohlWR6e.Size, new System.Drawing.Point(0, 0));
		}
		else
		{
			_0023_003Dz_BTD2UJxnCv4 = (_0023_003DzDtEp791czsNlmMYD7E1UmBirhU0g63fDPyowcUk_003D)_0023_003DzuU3Z_0024G4_003D<_0023_003DzDtEp791czsNlmMYD7E1UmBirhU0g63fDPyowcUk_003D>(_0023_003Dz5sebEohlWR6e.Size, new System.Drawing.Point(0, 0));
		}
		if (_0023_003Dz5sebEohlWR6e.Viewports.Count == 0)
		{
			_0023_003Dz_BTD2UJxnCv4._0023_003DzxhpCzYbg90ykH50_0024kw_003D_003D().Clear();
		}
		_0023_003Dz_BTD2UJxnCv4._0023_003DzrqznuO7LfyHq(_0023_003Dz0VEuMGyLvKtkOSUZPw_003D_003D);
		_0023_003Dz_BTD2UJxnCv4._0023_003DzLtYE0GwrHxYjk4GUbQ_003D_003D(_0023_003Dzq20n3T5CF1yUk3Rx0eB135w_003D);
		_0023_003Dz_BTD2UJxnCv4._0023_003DzlyCYov26sIYm(_0023_003DzOu7enVq4K6yNKW4mOw_003D_003D);
		if (_0023_003Dz_BTD2UJxnCv4 != null)
		{
			_0023_003Dz3VM1Ns7rda_0024g.SplitterDistance = Convert.ToInt32((float)_0023_003Dz3VM1Ns7rda_0024g.SplitterDistance / PresetManager.ScalingLevel.Width);
			_0023_003Dz_BTD2UJxnCv4._0023_003DzLofopdg_003D(_0023_003Dz3VM1Ns7rda_0024g.Panel1);
			_0023_003Dz_BTD2UJxnCv4.Dock = DockStyle.Fill;
		}
	}

	private void _0023_003DzOu7enVq4K6yNKW4mOw_003D_003D(object _0023_003DzUNNLWvM_003D, EventArgs _0023_003Dz_0024E5gy9fpCRKh)
	{
		_0023_003Dzd4pw9rOD5nDKELa9WA_003D_003D();
	}

	private void _0023_003Dzq20n3T5CF1yUk3Rx0eB135w_003D()
	{
		_0023_003DzqnC_Ihh1mO5B.SelectedNode = _0023_003DzqnC_Ihh1mO5B.Nodes[0].Nodes[_0023_003DzqnC_Ihh1mO5B.Nodes[0].Nodes.Count - 1];
		_0023_003DzqnC_Ihh1mO5B.Invalidate();
		_0023_003DzqnC_Ihh1mO5B.Focus();
		_0023_003DzvtXbRSRSoPe6();
	}

	private void _0023_003Dz0VEuMGyLvKtkOSUZPw_003D_003D()
	{
		_0023_003DzqnC_Ihh1mO5B.SelectedNode = _0023_003DzqnC_Ihh1mO5B.Nodes[0].Nodes[_0023_003Dz_BTD2UJxnCv4._0023_003DzNlUL249nQ2VQ()];
		_0023_003DzqnC_Ihh1mO5B.Invalidate();
		_0023_003DzqnC_Ihh1mO5B.Focus();
		_0023_003DzvtXbRSRSoPe6();
	}

	private void _0023_003Dza9gDGvnGMhnIdeHzyQ_003D_003D(object _0023_003DzUNNLWvM_003D, MouseEventArgs _0023_003Dz9I8ZVlc_003D)
	{
		_0023_003DzqnC_Ihh1mO5B.SelectedNode = _0023_003DzqnC_Ihh1mO5B.GetNodeAt(_0023_003Dz9I8ZVlc_003D.X, _0023_003Dz9I8ZVlc_003D.Y);
		int num = _0023_003DzXAYkC_0024b_bKEV();
		if (num != -1)
		{
			_0023_003Dz_BTD2UJxnCv4._0023_003DzNiHkPug7sG0i(num);
			_0023_003Dzd4pw9rOD5nDKELa9WA_003D_003D();
		}
		_0023_003DzvtXbRSRSoPe6();
	}

	private void _0023_003DzvtXbRSRSoPe6()
	{
		switch (_0023_003Dz_0024mqmju0_003D(_0023_003DzqnC_Ihh1mO5B.SelectedNode))
		{
		case (_0023_003Dzw2wjIKY_003D)1:
			_0023_003DzXJs2BUs_003D.Enabled = true;
			_0023_003DzzJNwkaE_003D.Enabled = false;
			_0023_003Dz3fmK_bbrL_00247r.Enabled = false;
			break;
		case (_0023_003Dzw2wjIKY_003D)2:
			_0023_003DzXJs2BUs_003D.Enabled = false;
			_0023_003DzzJNwkaE_003D.Enabled = true;
			_0023_003Dz3fmK_bbrL_00247r.Enabled = true;
			break;
		case (_0023_003Dzw2wjIKY_003D)3:
		case (_0023_003Dzw2wjIKY_003D)5:
		case (_0023_003Dzw2wjIKY_003D)9:
		case (_0023_003Dzw2wjIKY_003D)12:
			_0023_003DzXJs2BUs_003D.Enabled = true;
			_0023_003DzzJNwkaE_003D.Enabled = false;
			_0023_003Dz3fmK_bbrL_00247r.Enabled = false;
			break;
		case (_0023_003Dzw2wjIKY_003D)4:
		case (_0023_003Dzw2wjIKY_003D)6:
		case (_0023_003Dzw2wjIKY_003D)10:
		case (_0023_003Dzw2wjIKY_003D)13:
			_0023_003DzXJs2BUs_003D.Enabled = false;
			_0023_003DzzJNwkaE_003D.Enabled = true;
			_0023_003Dz3fmK_bbrL_00247r.Enabled = true;
			break;
		case (_0023_003Dzw2wjIKY_003D)7:
		case (_0023_003Dzw2wjIKY_003D)8:
		case (_0023_003Dzw2wjIKY_003D)11:
		case (_0023_003Dzw2wjIKY_003D)14:
			_0023_003DzXJs2BUs_003D.Enabled = false;
			_0023_003DzzJNwkaE_003D.Enabled = false;
			_0023_003Dz3fmK_bbrL_00247r.Enabled = false;
			break;
		}
	}

	private _0023_003Dzw2wjIKY_003D _0023_003Dz_0024mqmju0_003D(TreeNode _0023_003DzppmQ_0024i4_003D)
	{
		if (_0023_003DzppmQ_0024i4_003D == null || string.IsNullOrEmpty(_0023_003DzppmQ_0024i4_003D.Text))
		{
			return (_0023_003Dzw2wjIKY_003D)0;
		}
		if (_0023_003DzppmQ_0024i4_003D.Text.StartsWith(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319162)))
		{
			return (_0023_003Dzw2wjIKY_003D)1;
		}
		if (_0023_003DzppmQ_0024i4_003D.Text.StartsWith(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319146)))
		{
			return (_0023_003Dzw2wjIKY_003D)2;
		}
		if (_0023_003DzppmQ_0024i4_003D.Text.StartsWith(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312734)))
		{
			return (_0023_003Dzw2wjIKY_003D)10;
		}
		if (_0023_003DzppmQ_0024i4_003D.Text.StartsWith(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564317870)))
		{
			return (_0023_003Dzw2wjIKY_003D)9;
		}
		if (_0023_003DzppmQ_0024i4_003D.Text.StartsWith(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313432)))
		{
			return (_0023_003Dzw2wjIKY_003D)3;
		}
		if (_0023_003DzppmQ_0024i4_003D.Text.StartsWith(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313433)))
		{
			return (_0023_003Dzw2wjIKY_003D)4;
		}
		if (_0023_003DzppmQ_0024i4_003D.Text.StartsWith(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564317827)))
		{
			return (_0023_003Dzw2wjIKY_003D)5;
		}
		if (_0023_003DzppmQ_0024i4_003D.Text.StartsWith(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312786)))
		{
			return (_0023_003Dzw2wjIKY_003D)6;
		}
		if (_0023_003DzppmQ_0024i4_003D.Text.StartsWith(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312756)))
		{
			return (_0023_003Dzw2wjIKY_003D)7;
		}
		if (_0023_003DzppmQ_0024i4_003D.Text.StartsWith(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312935)))
		{
			return (_0023_003Dzw2wjIKY_003D)8;
		}
		if (_0023_003DzppmQ_0024i4_003D.Text.StartsWith(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319614)))
		{
			return (_0023_003Dzw2wjIKY_003D)11;
		}
		if (_0023_003DzppmQ_0024i4_003D.Text.StartsWith(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564317889)))
		{
			return (_0023_003Dzw2wjIKY_003D)12;
		}
		if (_0023_003DzppmQ_0024i4_003D.Text.StartsWith(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312720)))
		{
			return (_0023_003Dzw2wjIKY_003D)13;
		}
		if (_0023_003DzppmQ_0024i4_003D.Text.StartsWith(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312920)))
		{
			return (_0023_003Dzw2wjIKY_003D)14;
		}
		return (_0023_003Dzw2wjIKY_003D)1;
	}

	private int _0023_003DzXAYkC_0024b_bKEV()
	{
		if (_0023_003DzqnC_Ihh1mO5B.SelectedNode != null)
		{
			switch (_0023_003Dz_0024mqmju0_003D(_0023_003DzqnC_Ihh1mO5B.SelectedNode))
			{
			case (_0023_003Dzw2wjIKY_003D)1:
				return -1;
			case (_0023_003Dzw2wjIKY_003D)2:
				return _0023_003Dzh4FZ_BwzftUG(_0023_003DzqnC_Ihh1mO5B.SelectedNode.Text);
			case (_0023_003Dzw2wjIKY_003D)4:
			case (_0023_003Dzw2wjIKY_003D)6:
			case (_0023_003Dzw2wjIKY_003D)10:
			case (_0023_003Dzw2wjIKY_003D)13:
				return _0023_003Dzh4FZ_BwzftUG(_0023_003DzqnC_Ihh1mO5B.SelectedNode.Parent.Parent.Text);
			case (_0023_003Dzw2wjIKY_003D)11:
				if (_0023_003DzqnC_Ihh1mO5B.Nodes[0].Nodes.Count == 1)
				{
					return -1;
				}
				return _0023_003Dz_BTD2UJxnCv4._0023_003DzNlUL249nQ2VQ();
			default:
				return _0023_003Dzh4FZ_BwzftUG(_0023_003DzqnC_Ihh1mO5B.SelectedNode.Parent.Text);
			}
		}
		return -1;
	}

	private void _0023_003DzGtz87rDHyBnN(object _0023_003DzUNNLWvM_003D, EventArgs _0023_003Dz9I8ZVlc_003D)
	{
		if (_0023_003Dz_BTD2UJxnCv4._0023_003DzxhpCzYbg90ykH50_0024kw_003D_003D().Count == 0)
		{
			_0023_003Dz5sebEohlWR6e.Viewports.Clear();
		}
		else
		{
			_0023_003DzjKucw_SOIA1l._0023_003DzhL8JyLIuKkZd(Design, _0023_003Dz5sebEohlWR6e);
		}
		_0023_003Dz5sebEohlWR6e.UpdateDesignModeScene();
	}

	private void _0023_003DzQ4A8qbPnW5Xt(object _0023_003DzUNNLWvM_003D, EventArgs _0023_003Dz9I8ZVlc_003D)
	{
		switch (_0023_003Dz_0024mqmju0_003D(_0023_003DzqnC_Ihh1mO5B.SelectedNode))
		{
		case (_0023_003Dzw2wjIKY_003D)1:
			_0023_003DzqjhbqOw_003D();
			break;
		case (_0023_003Dzw2wjIKY_003D)9:
			_0023_003DzkFZeqiP8MUHg(null, null);
			break;
		case (_0023_003Dzw2wjIKY_003D)12:
			_0023_003DzeHg79Xy2q1UO(null, null);
			break;
		case (_0023_003Dzw2wjIKY_003D)3:
			_0023_003Dz1iFlE9J5RtJO(null, null);
			break;
		case (_0023_003Dzw2wjIKY_003D)5:
			_0023_003DzCdxCZEPklyIU(null, null);
			break;
		}
	}

	private void _0023_003DzyBlhSIYcI4WL(object _0023_003DzUNNLWvM_003D, EventArgs _0023_003Dz9I8ZVlc_003D)
	{
		switch (_0023_003Dz_0024mqmju0_003D(_0023_003DzqnC_Ihh1mO5B.SelectedNode))
		{
		case (_0023_003Dzw2wjIKY_003D)2:
			_0023_003DzCBiHfLttCZIO(null, null);
			break;
		case (_0023_003Dzw2wjIKY_003D)10:
			_0023_003DzAPX2KwIbTQYe(null, null);
			break;
		case (_0023_003Dzw2wjIKY_003D)13:
			_0023_003DztFCOe0OeUjZX(null, null);
			break;
		case (_0023_003Dzw2wjIKY_003D)4:
			_0023_003DzVVOq8jD_0024cwn0(null, null);
			break;
		case (_0023_003Dzw2wjIKY_003D)6:
			_0023_003DzIzdrIscVKrld(null, null);
			break;
		}
	}

	private void _0023_003DzAnWSxIm8SwRx(object _0023_003DzUNNLWvM_003D, EventArgs _0023_003Dz9I8ZVlc_003D)
	{
	}

	private void _0023_003DzmlNIXIiSDEf8(object _0023_003DzUNNLWvM_003D, EventArgs _0023_003Dz9I8ZVlc_003D)
	{
		int num = 0;
		switch (_0023_003Dz_0024mqmju0_003D(_0023_003DzqnC_Ihh1mO5B.SelectedNode))
		{
		case (_0023_003Dzw2wjIKY_003D)2:
		{
			int index = _0023_003Dzh4FZ_BwzftUG(_0023_003DzqnC_Ihh1mO5B.SelectedNode.Text);
			Viewport _0023_003Dzy6tHi4E_003D = _0023_003Dz_BTD2UJxnCv4._0023_003DzxhpCzYbg90ykH50_0024kw_003D_003D()[index];
			_0023_003Dz_BTD2UJxnCv4._0023_003DzxhpCzYbg90ykH50_0024kw_003D_003D().Add((Viewport)_0023_003DzjKucw_SOIA1l._0023_003DzhL8JyLIuKkZd(_0023_003Dzy6tHi4E_003D));
			_0023_003DzWaTgUyV4hcwF(_0023_003Dz_BTD2UJxnCv4._0023_003DzxhpCzYbg90ykH50_0024kw_003D_003D().Count - 1);
			_0023_003Dz_BTD2UJxnCv4.UpdateViewportsSizeAndLocation();
			_0023_003Dzd4pw9rOD5nDKELa9WA_003D_003D();
			break;
		}
		case (_0023_003Dzw2wjIKY_003D)10:
		{
			int num5 = _0023_003DzTTiqM0fMIWpZ(_0023_003DzqnC_Ihh1mO5B.SelectedNode.Text);
			num = _0023_003Dzh4FZ_BwzftUG(_0023_003DzqnC_Ihh1mO5B.SelectedNode.Parent.Parent.Text);
			_0023_003DzqnC_Ihh1mO5B.SelectedNode = _0023_003DzqnC_Ihh1mO5B.SelectedNode.Parent;
			Viewport _0023_003Dzy6tHi4E_003D = _0023_003Dz_BTD2UJxnCv4._0023_003DzxhpCzYbg90ykH50_0024kw_003D_003D()[num];
			_0023_003Dz5fSJN6Qle8Fd(_0023_003Dzy6tHi4E_003D, (Legend)_0023_003DzjKucw_SOIA1l._0023_003DzhL8JyLIuKkZd(_0023_003Dz_BTD2UJxnCv4._0023_003DzxhpCzYbg90ykH50_0024kw_003D_003D()[num].Legends[num5]));
			_0023_003DzqnC_Ihh1mO5B.SelectedNode = _0023_003DzqnC_Ihh1mO5B.SelectedNode.Nodes[num5];
			break;
		}
		case (_0023_003Dzw2wjIKY_003D)13:
		{
			int num4 = _0023_003DzfaLDxG2Fjmb1(_0023_003DzqnC_Ihh1mO5B.SelectedNode.Text);
			num = _0023_003Dzh4FZ_BwzftUG(_0023_003DzqnC_Ihh1mO5B.SelectedNode.Parent.Parent.Text);
			_0023_003DzqnC_Ihh1mO5B.SelectedNode = _0023_003DzqnC_Ihh1mO5B.SelectedNode.Parent;
			_0023_003DzXM6UYeFB6PXg(num, (Grid)_0023_003DzjKucw_SOIA1l._0023_003DzhL8JyLIuKkZd(_0023_003Dz_BTD2UJxnCv4._0023_003DzxhpCzYbg90ykH50_0024kw_003D_003D()[num].Grids[num4]));
			_0023_003DzqnC_Ihh1mO5B.SelectedNode = _0023_003DzqnC_Ihh1mO5B.SelectedNode.Nodes[num4];
			break;
		}
		case (_0023_003Dzw2wjIKY_003D)4:
		{
			int num3 = _0023_003DzUpTbozfGo6_0024S(_0023_003DzqnC_Ihh1mO5B.SelectedNode.Text);
			num = _0023_003Dzh4FZ_BwzftUG(_0023_003DzqnC_Ihh1mO5B.SelectedNode.Parent.Parent.Text);
			_0023_003DzqnC_Ihh1mO5B.SelectedNode = _0023_003DzqnC_Ihh1mO5B.SelectedNode.Parent;
			Viewport _0023_003Dzy6tHi4E_003D = _0023_003Dz_BTD2UJxnCv4._0023_003DzxhpCzYbg90ykH50_0024kw_003D_003D()[num];
			_0023_003DzdW0e_sO49fU5(_0023_003Dzy6tHi4E_003D, (devDept.Eyeshot.Control.ToolBar)_0023_003DzjKucw_SOIA1l._0023_003DzhL8JyLIuKkZd(_0023_003Dz_BTD2UJxnCv4._0023_003DzxhpCzYbg90ykH50_0024kw_003D_003D()[num].ToolBars[num3]));
			_0023_003DzqnC_Ihh1mO5B.SelectedNode = _0023_003DzqnC_Ihh1mO5B.SelectedNode.Nodes[num3];
			break;
		}
		case (_0023_003Dzw2wjIKY_003D)6:
		{
			int num2 = _0023_003DzF_0024z55cDEsVLn(_0023_003DzqnC_Ihh1mO5B.SelectedNode.Text);
			num = _0023_003Dzh4FZ_BwzftUG(_0023_003DzqnC_Ihh1mO5B.SelectedNode.Parent.Parent.Text);
			_0023_003DzqnC_Ihh1mO5B.SelectedNode = _0023_003DzqnC_Ihh1mO5B.SelectedNode.Parent;
			_0023_003DzRGwsdgn043YG(num, (OriginSymbol)_0023_003DzjKucw_SOIA1l._0023_003DzhL8JyLIuKkZd(_0023_003Dz_BTD2UJxnCv4._0023_003DzxhpCzYbg90ykH50_0024kw_003D_003D()[num].OriginSymbols[num2]));
			_0023_003DzqnC_Ihh1mO5B.SelectedNode = _0023_003DzqnC_Ihh1mO5B.SelectedNode.Nodes[num2];
			break;
		}
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && _0023_003Dzg7NzHjo_003D != null)
		{
			_0023_003Dzg7NzHjo_003D.Dispose();
		}
		base.Dispose(disposing);
	}

	private void _0023_003Dz_Y_0024H3f68zohJ()
	{
		_0023_003Dzg7NzHjo_003D = new Container();
		TreeNode treeNode = new TreeNode(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319131), 7, 7);
		new ComponentResourceManager(typeof(VisualControlDesigner));
		_0023_003DzqnC_Ihh1mO5B = new TreeView();
		_0023_003DzWXu3Hicmzd0k = new ImageList(_0023_003Dzg7NzHjo_003D);
		_0023_003Dz_0024jum24VhH0qw = new Button();
		_0023_003DzvepV2Lg_003D = new Button();
		_0023_003DzexYCIiQ_003D = new Button();
		_0023_003Dz3VM1Ns7rda_0024g = new SplitContainer();
		_0023_003DzXJs2BUs_003D = new Button();
		_0023_003Dzq9FErV3D6nUi = new ImageList(_0023_003Dzg7NzHjo_003D);
		_0023_003DzzJNwkaE_003D = new Button();
		_0023_003Dza3_0024yxbgYpN7F = new Button();
		_0023_003Dz3fmK_bbrL_00247r = new Button();
		((ISupportInitialize)_0023_003Dz3VM1Ns7rda_0024g).BeginInit();
		_0023_003Dz3VM1Ns7rda_0024g.Panel2.SuspendLayout();
		_0023_003Dz3VM1Ns7rda_0024g.SuspendLayout();
		SuspendLayout();
		_0023_003DzqnC_Ihh1mO5B.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		_0023_003DzqnC_Ihh1mO5B.ImageIndex = 0;
		_0023_003DzqnC_Ihh1mO5B.ImageList = _0023_003DzWXu3Hicmzd0k;
		_0023_003DzqnC_Ihh1mO5B.Location = new System.Drawing.Point(2, 32);
		_0023_003DzqnC_Ihh1mO5B.Name = _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319118);
		treeNode.ImageIndex = 7;
		treeNode.Name = _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319230);
		treeNode.SelectedImageIndex = 7;
		treeNode.Text = _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319131);
		_0023_003DzqnC_Ihh1mO5B.Nodes.AddRange(new TreeNode[1] { treeNode });
		_0023_003DzqnC_Ihh1mO5B.SelectedImageIndex = 0;
		_0023_003DzqnC_Ihh1mO5B.Size = new Size(321, 600);
		_0023_003DzqnC_Ihh1mO5B.TabIndex = 1;
		_0023_003DzqnC_Ihh1mO5B.MouseUp += _0023_003Dza9gDGvnGMhnIdeHzyQ_003D_003D;
		_0023_003DzWXu3Hicmzd0k.TransparentColor = Color.Transparent;
		_0023_003DzWXu3Hicmzd0k.Images.Add(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319202), _0023_003Dz7cZkooqx14_TV6kCjyrvJyRLgYZv2GUZ4A_003D_003D._0023_003DzQk5ptKRUh0mB());
		_0023_003DzWXu3Hicmzd0k.Images.Add(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319196), _0023_003Dz7cZkooqx14_TV6kCjyrvJyRLgYZv2GUZ4A_003D_003D._0023_003DzRqCycrvFUsVd());
		_0023_003DzWXu3Hicmzd0k.Images.Add(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319178), _0023_003Dz7cZkooqx14_TV6kCjyrvJyRLgYZv2GUZ4A_003D_003D._0023_003Dz2tAdLapJks4G());
		_0023_003DzWXu3Hicmzd0k.Images.Add(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319015), _0023_003Dz7cZkooqx14_TV6kCjyrvJyRLgYZv2GUZ4A_003D_003D._0023_003Dz6jcsRYXDVi4a6RrGAw_003D_003D());
		_0023_003DzWXu3Hicmzd0k.Images.Add(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318996), _0023_003Dz7cZkooqx14_TV6kCjyrvJyRLgYZv2GUZ4A_003D_003D._0023_003DzQdXUIb0GxLaB());
		_0023_003DzWXu3Hicmzd0k.Images.Add(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318979), _0023_003Dz7cZkooqx14_TV6kCjyrvJyRLgYZv2GUZ4A_003D_003D._0023_003DzRSsGqtH7p64jgyOwNg_003D_003D());
		_0023_003DzWXu3Hicmzd0k.Images.Add(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319090), _0023_003Dz7cZkooqx14_TV6kCjyrvJyRLgYZv2GUZ4A_003D_003D._0023_003Dzzt5DLm_0024q0VK9());
		_0023_003DzWXu3Hicmzd0k.Images.Add(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319073), _0023_003Dz7cZkooqx14_TV6kCjyrvJyRLgYZv2GUZ4A_003D_003D._0023_003DzUl4oZ1lrSBUNV_0024V_0024Jg_003D_003D());
		_0023_003DzWXu3Hicmzd0k.Images.Add(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319072), _0023_003Dz7cZkooqx14_TV6kCjyrvJyRLgYZv2GUZ4A_003D_003D._0023_003DzqtgbONt1rAPt());
		_0023_003DzWXu3Hicmzd0k.Images.Add(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319053), _0023_003Dz7cZkooqx14_TV6kCjyrvJyRLgYZv2GUZ4A_003D_003D._0023_003DzRuoevYo_003D());
		_0023_003DzWXu3Hicmzd0k.Images.Add(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318908), _0023_003Dz7cZkooqx14_TV6kCjyrvJyRLgYZv2GUZ4A_003D_003D._0023_003Dzs_Va_00246fxxzEt());
		_0023_003DzWXu3Hicmzd0k.Images.Add(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318893), _0023_003Dz7cZkooqx14_TV6kCjyrvJyRLgYZv2GUZ4A_003D_003D._0023_003Dz6hodpW_0024XqmJl());
		_0023_003DzWXu3Hicmzd0k.Images.Add(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318874), _0023_003Dz7cZkooqx14_TV6kCjyrvJyRLgYZv2GUZ4A_003D_003D._0023_003DzoWqO4uF6s1B9());
		_0023_003DzWXu3Hicmzd0k.Images.Add(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318966), _0023_003Dz7cZkooqx14_TV6kCjyrvJyRLgYZv2GUZ4A_003D_003D._0023_003Dz2zk9sCrygrSizu_0024Tpw_003D_003D());
		_0023_003Dz_0024jum24VhH0qw.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		_0023_003Dz_0024jum24VhH0qw.Location = new System.Drawing.Point(1174, 650);
		_0023_003Dz_0024jum24VhH0qw.Name = _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318947);
		_0023_003Dz_0024jum24VhH0qw.Size = new Size(75, 23);
		_0023_003Dz_0024jum24VhH0qw.TabIndex = 8;
		_0023_003Dz_0024jum24VhH0qw.Text = _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318929);
		_0023_003Dz_0024jum24VhH0qw.UseVisualStyleBackColor = true;
		_0023_003Dz_0024jum24VhH0qw.Click += _0023_003DzGtz87rDHyBnN;
		_0023_003DzvepV2Lg_003D.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		_0023_003DzvepV2Lg_003D.DialogResult = DialogResult.Cancel;
		_0023_003DzvepV2Lg_003D.Location = new System.Drawing.Point(1092, 650);
		_0023_003DzvepV2Lg_003D.Name = _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318917);
		_0023_003DzvepV2Lg_003D.Size = new Size(75, 23);
		_0023_003DzvepV2Lg_003D.TabIndex = 7;
		_0023_003DzvepV2Lg_003D.Text = _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318386);
		_0023_003DzvepV2Lg_003D.UseVisualStyleBackColor = true;
		_0023_003DzexYCIiQ_003D.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		_0023_003DzexYCIiQ_003D.DialogResult = DialogResult.OK;
		_0023_003DzexYCIiQ_003D.Location = new System.Drawing.Point(1010, 650);
		_0023_003DzexYCIiQ_003D.Name = _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318775);
		_0023_003DzexYCIiQ_003D.Size = new Size(75, 23);
		_0023_003DzexYCIiQ_003D.TabIndex = 6;
		_0023_003DzexYCIiQ_003D.Text = _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318558);
		_0023_003DzexYCIiQ_003D.UseVisualStyleBackColor = true;
		_0023_003Dz3VM1Ns7rda_0024g.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		_0023_003Dz3VM1Ns7rda_0024g.FixedPanel = FixedPanel.Panel2;
		_0023_003Dz3VM1Ns7rda_0024g.Location = new System.Drawing.Point(12, 12);
		_0023_003Dz3VM1Ns7rda_0024g.Name = _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318342);
		_0023_003Dz3VM1Ns7rda_0024g.Panel2.Controls.Add(_0023_003DzqnC_Ihh1mO5B);
		_0023_003Dz3VM1Ns7rda_0024g.Panel2.Controls.Add(_0023_003DzXJs2BUs_003D);
		_0023_003Dz3VM1Ns7rda_0024g.Panel2.Controls.Add(_0023_003DzzJNwkaE_003D);
		_0023_003Dz3VM1Ns7rda_0024g.Panel2.Controls.Add(_0023_003Dza3_0024yxbgYpN7F);
		_0023_003Dz3VM1Ns7rda_0024g.Panel2.Controls.Add(_0023_003Dz3fmK_bbrL_00247r);
		_0023_003Dz3VM1Ns7rda_0024g.Size = new Size(1240, 632);
		_0023_003Dz3VM1Ns7rda_0024g.SplitterDistance = 910;
		_0023_003Dz3VM1Ns7rda_0024g.TabIndex = 12;
		_0023_003DzXJs2BUs_003D.ImageAlign = ContentAlignment.MiddleRight;
		_0023_003DzXJs2BUs_003D.ImageIndex = 0;
		_0023_003DzXJs2BUs_003D.ImageList = _0023_003Dzq9FErV3D6nUi;
		_0023_003DzXJs2BUs_003D.Location = new System.Drawing.Point(4, 0);
		_0023_003DzXJs2BUs_003D.Name = _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318777);
		_0023_003DzXJs2BUs_003D.Size = new Size(74, 23);
		_0023_003DzXJs2BUs_003D.TabIndex = 2;
		_0023_003DzXJs2BUs_003D.Text = _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564315383);
		_0023_003DzXJs2BUs_003D.TextImageRelation = TextImageRelation.ImageBeforeText;
		_0023_003DzXJs2BUs_003D.UseVisualStyleBackColor = true;
		_0023_003DzXJs2BUs_003D.Click += _0023_003DzQ4A8qbPnW5Xt;
		_0023_003Dzq9FErV3D6nUi.TransparentColor = Color.Transparent;
		_0023_003Dzq9FErV3D6nUi.Images.Add(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318761), _0023_003Dz7cZkooqx14_TV6kCjyrvJyRLgYZv2GUZ4A_003D_003D._0023_003DzZwdHkEk_003D());
		_0023_003Dzq9FErV3D6nUi.Images.Add(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319053), _0023_003Dz7cZkooqx14_TV6kCjyrvJyRLgYZv2GUZ4A_003D_003D._0023_003DzRuoevYo_003D());
		_0023_003Dzq9FErV3D6nUi.Images.Add(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318747), _0023_003Dz7cZkooqx14_TV6kCjyrvJyRLgYZv2GUZ4A_003D_003D._0023_003DzIAH1GQ6l_Edx());
		_0023_003Dzq9FErV3D6nUi.Images.Add(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318732), _0023_003Dz7cZkooqx14_TV6kCjyrvJyRLgYZv2GUZ4A_003D_003D._0023_003Dz6W_Zqk6sV53n());
		_0023_003DzzJNwkaE_003D.ImageAlign = ContentAlignment.MiddleRight;
		_0023_003DzzJNwkaE_003D.ImageIndex = 1;
		_0023_003DzzJNwkaE_003D.ImageList = _0023_003Dzq9FErV3D6nUi;
		_0023_003DzzJNwkaE_003D.Location = new System.Drawing.Point(84, 0);
		_0023_003DzzJNwkaE_003D.Name = _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318824);
		_0023_003DzzJNwkaE_003D.Size = new Size(75, 23);
		_0023_003DzzJNwkaE_003D.TabIndex = 3;
		_0023_003DzzJNwkaE_003D.Text = _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318805);
		_0023_003DzzJNwkaE_003D.TextImageRelation = TextImageRelation.ImageBeforeText;
		_0023_003DzzJNwkaE_003D.UseVisualStyleBackColor = true;
		_0023_003DzzJNwkaE_003D.Click += _0023_003DzyBlhSIYcI4WL;
		_0023_003Dza3_0024yxbgYpN7F.ImageAlign = ContentAlignment.MiddleRight;
		_0023_003Dza3_0024yxbgYpN7F.ImageIndex = 2;
		_0023_003Dza3_0024yxbgYpN7F.ImageList = _0023_003Dzq9FErV3D6nUi;
		_0023_003Dza3_0024yxbgYpN7F.Location = new System.Drawing.Point(246, 0);
		_0023_003Dza3_0024yxbgYpN7F.Name = _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318792);
		_0023_003Dza3_0024yxbgYpN7F.Size = new Size(75, 23);
		_0023_003Dza3_0024yxbgYpN7F.TabIndex = 4;
		_0023_003Dza3_0024yxbgYpN7F.Text = _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564316597);
		_0023_003Dza3_0024yxbgYpN7F.TextImageRelation = TextImageRelation.ImageBeforeText;
		_0023_003Dza3_0024yxbgYpN7F.UseVisualStyleBackColor = true;
		_0023_003Dza3_0024yxbgYpN7F.Visible = false;
		_0023_003Dza3_0024yxbgYpN7F.Click += _0023_003DzAnWSxIm8SwRx;
		_0023_003Dz3fmK_bbrL_00247r.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		_0023_003Dz3fmK_bbrL_00247r.ImageAlign = ContentAlignment.MiddleRight;
		_0023_003Dz3fmK_bbrL_00247r.ImageIndex = 3;
		_0023_003Dz3fmK_bbrL_00247r.ImageList = _0023_003Dzq9FErV3D6nUi;
		_0023_003Dz3fmK_bbrL_00247r.Location = new System.Drawing.Point(165, 0);
		_0023_003Dz3fmK_bbrL_00247r.Name = _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564316584);
		_0023_003Dz3fmK_bbrL_00247r.Size = new Size(75, 23);
		_0023_003Dz3fmK_bbrL_00247r.TabIndex = 5;
		_0023_003Dz3fmK_bbrL_00247r.Text = _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564316562);
		_0023_003Dz3fmK_bbrL_00247r.TextImageRelation = TextImageRelation.ImageBeforeText;
		_0023_003Dz3fmK_bbrL_00247r.UseVisualStyleBackColor = true;
		_0023_003Dz3fmK_bbrL_00247r.Click += _0023_003DzmlNIXIiSDEf8;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(1264, 681);
		base.Controls.Add(_0023_003Dz3VM1Ns7rda_0024g);
		base.Controls.Add(_0023_003DzexYCIiQ_003D);
		base.Controls.Add(_0023_003DzvepV2Lg_003D);
		base.Controls.Add(_0023_003Dz_0024jum24VhH0qw);
		Font = new Font(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318250), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		base.Icon = _0023_003Dz7cZkooqx14_TV6kCjyrvJyRLgYZv2GUZ4A_003D_003D._0023_003DzEq19E6zMfrOrPjwJIA_003D_003D();
		base.Name = _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564316546);
		Text = _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564316646);
		base.StartPosition = FormStartPosition.CenterScreen;
		_0023_003Dz3VM1Ns7rda_0024g.Panel2.ResumeLayout(performLayout: false);
		_0023_003Dz3VM1Ns7rda_0024g.Panel2.PerformLayout();
		((ISupportInitialize)_0023_003Dz3VM1Ns7rda_0024g).EndInit();
		_0023_003Dz3VM1Ns7rda_0024g.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
	}
}
