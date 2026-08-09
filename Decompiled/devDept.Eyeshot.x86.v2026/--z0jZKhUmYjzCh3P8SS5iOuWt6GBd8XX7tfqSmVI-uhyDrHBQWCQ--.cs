using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using ODA.Drawings.TD_DbCoreIntegrated;
using ODA.Kernel.TD_RootIntegrated;
using devDept;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Translators;
using devDept.Geometry;

internal sealed class _0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D
{
	private static Dictionary<int, int> _0023_003Dz_sf9dBZZ1poK;

	public static void _0023_003DzDJGXEx72FcYc4Bhhew_003D_003D(IEntity _0023_003DzTF6VxYwN0Yi5DFhN4A_003D_003D, OdDbEntity _0023_003Dz8OfpZ7wlx6QF, WriteDatabase._0023_003DzKyfEzVn70e7f _0023_003DzwzL57J6ueMIu)
	{
		OdDbLayerTable odDbLayerTable = (OdDbLayerTable)_0023_003DzwzL57J6ueMIu._0023_003DzbXRspLkELXCh().getLayerTableId().openObject(OdDb_OpenMode.kForWrite);
		_0023_003Dz8OfpZ7wlx6QF.setLayer(odDbLayerTable.getAt(_0023_003DzTF6VxYwN0Yi5DFhN4A_003D_003D.LayerName));
		_0023_003Dz8OfpZ7wlx6QF.setVisibility((!_0023_003DzTF6VxYwN0Yi5DFhN4A_003D_003D.Visible) ? OdDb_Visibility.kInvisible : OdDb_Visibility.kVisible);
		OdCmColor odCmColor = null;
		OdCmTransparency transparency = null;
		switch (_0023_003DzTF6VxYwN0Yi5DFhN4A_003D_003D.ColorMethod)
		{
		case colorMethodType.byEntity:
			odCmColor = _0023_003DztRLzArIqOrBK0lmTPw_003D_003D(_0023_003DzTF6VxYwN0Yi5DFhN4A_003D_003D.Color, _0023_003DzwzL57J6ueMIu._0023_003DzujvIJ3_tyt6U(), _0023_003DzwzL57J6ueMIu._0023_003DzFVrp9CCbpZz_0024());
			transparency = new OdCmTransparency(_0023_003DzTF6VxYwN0Yi5DFhN4A_003D_003D.Color.A);
			break;
		case colorMethodType.byLayer:
			odCmColor = new OdCmColor(OdCmEntityColor_ColorMethod.kByLayer);
			odCmColor.setColorIndex(256);
			transparency = new OdCmTransparency(OdCmTransparency_transparencyMethod.kByLayer);
			_0023_003Dz8OfpZ7wlx6QF.setMaterial(_0023_003DzwzL57J6ueMIu._0023_003DzbXRspLkELXCh().byLayerMaterialId());
			break;
		case colorMethodType.byParent:
			odCmColor = new OdCmColor(OdCmEntityColor_ColorMethod.kByBlock);
			odCmColor.setColorIndex(0);
			transparency = new OdCmTransparency(OdCmTransparency_transparencyMethod.kByBlock);
			_0023_003Dz8OfpZ7wlx6QF.setMaterial(_0023_003DzwzL57J6ueMIu._0023_003DzbXRspLkELXCh().byBlockMaterialId());
			break;
		}
		_0023_003Dz8OfpZ7wlx6QF.setColor(odCmColor);
		_0023_003Dz8OfpZ7wlx6QF.setTransparency(transparency);
		if (_0023_003DzTF6VxYwN0Yi5DFhN4A_003D_003D is Entity entity && !string.IsNullOrEmpty(entity.MaterialName))
		{
			_0023_003Dz8OfpZ7wlx6QF.setMaterial(entity.MaterialName);
		}
		switch (_0023_003DzTF6VxYwN0Yi5DFhN4A_003D_003D.LineTypeMethod)
		{
		case colorMethodType.byLayer:
			_0023_003Dz8OfpZ7wlx6QF.setLinetype(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355530449));
			break;
		case colorMethodType.byEntity:
			if (!string.IsNullOrEmpty(_0023_003DzTF6VxYwN0Yi5DFhN4A_003D_003D.LineTypeName))
			{
				_0023_003Dz8OfpZ7wlx6QF.setLinetype(_0023_003DzTF6VxYwN0Yi5DFhN4A_003D_003D.LineTypeName);
			}
			else
			{
				_0023_003Dz8OfpZ7wlx6QF.setLinetype(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532605));
			}
			break;
		case colorMethodType.byParent:
			_0023_003Dz8OfpZ7wlx6QF.setLinetype(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355530463));
			break;
		}
		_0023_003Dz8OfpZ7wlx6QF.setLinetypeScale(_0023_003DzTF6VxYwN0Yi5DFhN4A_003D_003D.LineTypeScale);
		switch (_0023_003DzTF6VxYwN0Yi5DFhN4A_003D_003D.LineWeightMethod)
		{
		case colorMethodType.byLayer:
			_0023_003Dz8OfpZ7wlx6QF.setLineWeight(LineWeight.kLnWtByLayer);
			break;
		case colorMethodType.byEntity:
			_0023_003Dz8OfpZ7wlx6QF.setLineWeight(WriteDatabase._0023_003Dz6rzgaSHBY5QMk_0024oC226vguvdkkCP(_0023_003DzTF6VxYwN0Yi5DFhN4A_003D_003D.LineWeight, _0023_003DzwzL57J6ueMIu._0023_003Dz_GNl1_0024oPxrrc()));
			break;
		case colorMethodType.byParent:
			_0023_003Dz8OfpZ7wlx6QF.setLineWeight(LineWeight.kLnWtByBlock);
			break;
		}
		if (_0023_003DzTF6VxYwN0Yi5DFhN4A_003D_003D.AutodeskProperties?.XData != null)
		{
			KeyValuePair<short, object>[] _0023_003DzU3o1kV6AvBoG = _0023_003DzsU8xs6EN_FSS(_0023_003DzTF6VxYwN0Yi5DFhN4A_003D_003D.AutodeskProperties.XData, _0023_003DzwzL57J6ueMIu._0023_003DzbXRspLkELXCh());
			try
			{
				OdResBuf xData = _0023_003DzFAdNEnYlqrJZ(_0023_003DzU3o1kV6AvBoG);
				_0023_003Dz8OfpZ7wlx6QF.setXData(xData);
			}
			catch (Exception)
			{
				throw new EyeshotException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355531441));
			}
		}
	}

	internal static KeyValuePair<short, object>[] _0023_003DzsU8xs6EN_FSS(List<KeyValuePair<short, object>> _0023_003Dzgh2w2yI_003D, OdDbDatabase _0023_003Dzd2hFvl0_003D)
	{
		List<KeyValuePair<short, object>> list = _0023_003DzyNqfKmqDYQO3joZJJQ_003D_003D(_0023_003Dzgh2w2yI_003D);
		int num = 0;
		KeyValuePair<short, object>[] array = new KeyValuePair<short, object>[list.Count];
		List<string> list2 = new List<string>();
		foreach (KeyValuePair<short, object> item in list)
		{
			array[num++] = new KeyValuePair<short, object>(item.Key, item.Value);
			if (item.Key == 1001)
			{
				list2.Add(item.Value.ToString());
			}
		}
		bool[] array2 = new bool[list2.Count];
		OdDbRegAppTable odDbRegAppTable = (OdDbRegAppTable)_0023_003Dzd2hFvl0_003D.getRegAppTableId().openObject(OdDb_OpenMode.kForWrite);
		OdDbSymbolTableIterator odDbSymbolTableIterator = odDbRegAppTable.newIterator();
		odDbSymbolTableIterator.start();
		while (!odDbSymbolTableIterator.done())
		{
			OdDbRegAppTableRecord odDbRegAppTableRecord = (OdDbRegAppTableRecord)odDbSymbolTableIterator.getRecord(OdDb_OpenMode.kForRead);
			for (int i = 0; i < list2.Count; i++)
			{
				if (!array2[i] && string.Equals(odDbRegAppTableRecord.getName(), list2[i], StringComparison.OrdinalIgnoreCase))
				{
					array2[i] = true;
				}
			}
			odDbSymbolTableIterator.step();
		}
		for (int j = 0; j < array2.Length; j++)
		{
			if (!array2[j])
			{
				OdDbRegAppTableRecord odDbRegAppTableRecord2 = OdDbRegAppTableRecord.createObject();
				odDbRegAppTableRecord2.setName(list2[j]);
				odDbRegAppTable.add(odDbRegAppTableRecord2);
				array2[j] = true;
			}
		}
		return array;
	}

	internal static OdDbObjectId _0023_003DzQnE4k6_0024RHM2tjCasTiJl7R8_003D(displayType _0023_003DzMvWHUNc_003D, OdDbDictionary _0023_003DzlJd_0024w_llT80Y)
	{
		return _0023_003DzMvWHUNc_003D switch
		{
			displayType.Wireframe => _0023_003DzlJd_0024w_llT80Y.getAt(AutodeskProperties.visualStyleType.Wireframe.GetDisplayName()), 
			displayType.Shaded => _0023_003DzlJd_0024w_llT80Y.getAt(AutodeskProperties.visualStyleType.ShadedWithEdges.GetDisplayName()), 
			displayType.Rendered => _0023_003DzlJd_0024w_llT80Y.getAt(AutodeskProperties.visualStyleType.Realistic.GetDisplayName()), 
			displayType.Flat => _0023_003DzlJd_0024w_llT80Y.getAt(AutodeskProperties.visualStyleType.Conceptual.GetDisplayName()), 
			displayType.HiddenLines => _0023_003DzlJd_0024w_llT80Y.getAt(AutodeskProperties.visualStyleType.Hidden.GetDisplayName()), 
			_ => null, 
		};
	}

	internal static AutodeskProperties.visualStyleType _0023_003DzzNCQc50QBJ_Z(OdGiVisualStyle_Type _0023_003DzBsV8oWv6Tt_00245)
	{
		return _0023_003DzBsV8oWv6Tt_00245 switch
		{
			OdGiVisualStyle_Type.k2DWireframe => AutodeskProperties.visualStyleType.Wireframe2D, 
			OdGiVisualStyle_Type.k3DWireframe => AutodeskProperties.visualStyleType.Wireframe, 
			OdGiVisualStyle_Type.kHidden => AutodeskProperties.visualStyleType.Hidden, 
			OdGiVisualStyle_Type.kRealistic => AutodeskProperties.visualStyleType.Realistic, 
			OdGiVisualStyle_Type.kConceptual => AutodeskProperties.visualStyleType.Conceptual, 
			OdGiVisualStyle_Type.kShaded => AutodeskProperties.visualStyleType.Shaded, 
			OdGiVisualStyle_Type.kShadedWithEdges => AutodeskProperties.visualStyleType.ShadedWithEdges, 
			OdGiVisualStyle_Type.kShadesOfGray => AutodeskProperties.visualStyleType.ShadesOfGray, 
			OdGiVisualStyle_Type.kSketchy => AutodeskProperties.visualStyleType.Sketchy, 
			OdGiVisualStyle_Type.kXRay => AutodeskProperties.visualStyleType.XRay, 
			_ => AutodeskProperties.visualStyleType.Realistic, 
		};
	}

	internal static OdCmColor _0023_003DztRLzArIqOrBK0lmTPw_003D_003D(byte _0023_003DzX_VRnyU_003D, byte _0023_003DzZzVr6_0024U_003D, byte _0023_003DzgCCmJLk_003D, bool _0023_003Dz_sf9dBZZ1poK, Color _0023_003DzYh4eDvc_003D)
	{
		ushort _0023_003DzPqe3X00_003D = 0;
		OdCmColor odCmColor = new OdCmColor();
		if (_0023_003Dz_sf9dBZZ1poK && _0023_003Dz3_j8ceELOeYJ(_0023_003DzX_VRnyU_003D, _0023_003DzZzVr6_0024U_003D, _0023_003DzgCCmJLk_003D, _0023_003DzYh4eDvc_003D, ref _0023_003DzPqe3X00_003D))
		{
			odCmColor.setColorMethod(OdCmEntityColor_ColorMethod.kByACI);
			odCmColor.setColorIndex(_0023_003DzPqe3X00_003D);
		}
		else
		{
			odCmColor.setRGB(_0023_003DzX_VRnyU_003D, _0023_003DzZzVr6_0024U_003D, _0023_003DzgCCmJLk_003D);
		}
		return odCmColor;
	}

	internal static OdCmColor _0023_003DztRLzArIqOrBK0lmTPw_003D_003D(Color _0023_003DzJBUBFWA_003D, bool _0023_003Dz_sf9dBZZ1poK, Color _0023_003DzYh4eDvc_003D)
	{
		return _0023_003DztRLzArIqOrBK0lmTPw_003D_003D(_0023_003DzJBUBFWA_003D.R, _0023_003DzJBUBFWA_003D.G, _0023_003DzJBUBFWA_003D.B, _0023_003Dz_sf9dBZZ1poK, _0023_003DzYh4eDvc_003D);
	}

	private static bool _0023_003Dz3_j8ceELOeYJ(byte _0023_003DzX_VRnyU_003D, byte _0023_003DzZzVr6_0024U_003D, byte _0023_003DzgCCmJLk_003D, Color _0023_003DzYh4eDvc_003D, ref ushort _0023_003DzPqe3X00_003D)
	{
		if (_0023_003DzX_VRnyU_003D == 0 && _0023_003DzZzVr6_0024U_003D == 0 && _0023_003DzgCCmJLk_003D == 0)
		{
			if (_0023_003DzYh4eDvc_003D.ToArgb() == Color.Black.ToArgb())
			{
				_0023_003DzPqe3X00_003D = 7;
				return true;
			}
			return false;
		}
		if (_0023_003DzX_VRnyU_003D == byte.MaxValue && _0023_003DzZzVr6_0024U_003D == byte.MaxValue && _0023_003DzgCCmJLk_003D == byte.MaxValue)
		{
			_0023_003DzPqe3X00_003D = (ushort)((_0023_003DzYh4eDvc_003D.ToArgb() == Color.White.ToArgb()) ? 7 : 255);
			return true;
		}
		int key = (_0023_003DzX_VRnyU_003D << 16) + (_0023_003DzZzVr6_0024U_003D << 8) + _0023_003DzgCCmJLk_003D;
		if (_0023_003Dz_sf9dBZZ1poK.ContainsKey(key))
		{
			_0023_003DzPqe3X00_003D = (ushort)_0023_003Dz_sf9dBZZ1poK[key];
			return true;
		}
		return false;
	}

	internal static void _0023_003DzSothfIG2mlbP()
	{
		if (_0023_003Dz_sf9dBZZ1poK != null)
		{
			return;
		}
		_0023_003Dz_sf9dBZZ1poK = new Dictionary<int, int>();
		byte[] array = new byte[768]
		{
			0, 0, 0, 255, 0, 0, 255, 255, 0, 0,
			255, 0, 0, 255, 255, 0, 0, 255, 255, 0,
			255, 255, 255, 255, 128, 128, 128, 192, 192, 192,
			255, 0, 0, 255, 127, 127, 204, 0, 0, 204,
			102, 102, 153, 0, 0, 153, 76, 76, 127, 0,
			0, 127, 63, 63, 76, 0, 0, 76, 38, 38,
			255, 63, 0, 255, 159, 127, 204, 51, 0, 204,
			127, 102, 153, 38, 0, 153, 95, 76, 127, 31,
			0, 127, 79, 63, 76, 19, 0, 76, 47, 38,
			255, 127, 0, 255, 191, 127, 204, 102, 0, 204,
			153, 102, 153, 76, 0, 153, 114, 76, 127, 63,
			0, 127, 95, 63, 76, 38, 0, 76, 57, 38,
			255, 191, 0, 255, 223, 127, 204, 153, 0, 204,
			178, 102, 153, 114, 0, 153, 133, 76, 127, 95,
			0, 127, 111, 63, 76, 57, 0, 76, 66, 38,
			255, 255, 0, 255, 255, 127, 204, 204, 0, 204,
			204, 102, 153, 153, 0, 153, 153, 76, 127, 127,
			0, 127, 127, 63, 76, 76, 0, 76, 76, 38,
			191, 255, 0, 223, 255, 127, 153, 204, 0, 178,
			204, 102, 114, 153, 0, 133, 153, 76, 95, 127,
			0, 111, 127, 63, 57, 76, 0, 66, 76, 38,
			127, 255, 0, 191, 255, 127, 102, 204, 0, 153,
			204, 102, 76, 153, 0, 114, 153, 76, 63, 127,
			0, 95, 127, 63, 38, 76, 0, 57, 76, 38,
			63, 255, 0, 159, 255, 127, 51, 204, 0, 127,
			204, 102, 38, 153, 0, 95, 153, 76, 31, 127,
			0, 79, 127, 63, 19, 76, 0, 47, 76, 38,
			0, 255, 0, 127, 255, 127, 0, 204, 0, 102,
			204, 102, 0, 153, 0, 76, 153, 76, 0, 127,
			0, 63, 127, 63, 0, 76, 0, 38, 76, 38,
			0, 255, 63, 127, 255, 159, 0, 204, 51, 102,
			204, 127, 0, 153, 38, 76, 153, 95, 0, 127,
			31, 63, 127, 79, 0, 76, 19, 38, 76, 47,
			0, 255, 127, 127, 255, 191, 0, 204, 102, 102,
			204, 153, 0, 153, 76, 76, 153, 114, 0, 127,
			63, 63, 127, 95, 0, 76, 38, 38, 76, 57,
			0, 255, 191, 127, 255, 223, 0, 204, 153, 102,
			204, 178, 0, 153, 114, 76, 153, 133, 0, 127,
			95, 63, 127, 111, 0, 76, 57, 38, 76, 66,
			0, 255, 255, 127, 255, 255, 0, 204, 204, 102,
			204, 204, 0, 153, 153, 76, 153, 153, 0, 127,
			127, 63, 127, 127, 0, 76, 76, 38, 76, 76,
			0, 191, 255, 127, 223, 255, 0, 153, 204, 102,
			178, 204, 0, 114, 153, 76, 133, 153, 0, 95,
			127, 63, 111, 127, 0, 57, 76, 38, 66, 76,
			0, 127, 255, 127, 191, 255, 0, 102, 204, 102,
			153, 204, 0, 76, 153, 76, 114, 153, 0, 63,
			127, 63, 95, 127, 0, 38, 76, 38, 57, 76,
			0, 63, 255, 127, 159, 255, 0, 51, 204, 102,
			127, 204, 0, 38, 153, 76, 95, 153, 0, 31,
			127, 63, 79, 127, 0, 19, 76, 38, 47, 76,
			0, 0, 255, 127, 127, 255, 0, 0, 204, 102,
			102, 204, 0, 0, 153, 76, 76, 153, 0, 0,
			127, 63, 63, 127, 0, 0, 76, 38, 38, 76,
			63, 0, 255, 159, 127, 255, 51, 0, 204, 127,
			102, 204, 38, 0, 153, 95, 76, 153, 31, 0,
			127, 79, 63, 127, 19, 0, 76, 47, 38, 76,
			127, 0, 255, 191, 127, 255, 102, 0, 204, 153,
			102, 204, 76, 0, 153, 114, 76, 153, 63, 0,
			127, 95, 63, 127, 38, 0, 76, 57, 38, 76,
			191, 0, 255, 223, 127, 255, 153, 0, 204, 178,
			102, 204, 114, 0, 153, 133, 76, 153, 95, 0,
			127, 111, 63, 127, 57, 0, 76, 66, 38, 76,
			255, 0, 255, 255, 127, 255, 204, 0, 204, 204,
			102, 204, 153, 0, 153, 153, 76, 153, 127, 0,
			127, 127, 63, 127, 76, 0, 76, 76, 38, 76,
			255, 0, 191, 255, 127, 223, 204, 0, 153, 204,
			102, 178, 153, 0, 114, 153, 76, 133, 127, 0,
			95, 127, 63, 111, 76, 0, 57, 76, 38, 66,
			255, 0, 127, 255, 127, 191, 204, 0, 102, 204,
			102, 153, 153, 0, 76, 153, 76, 114, 127, 0,
			63, 127, 63, 95, 76, 0, 38, 76, 38, 57,
			255, 0, 63, 255, 127, 159, 204, 0, 51, 204,
			102, 127, 153, 0, 38, 153, 76, 95, 127, 0,
			31, 127, 63, 79, 76, 0, 19, 76, 38, 47,
			51, 51, 51, 91, 91, 91, 132, 132, 132, 173,
			173, 173, 214, 214, 214, 255, 255, 255
		};
		int num = 0;
		int num2 = 0;
		while (num2 < array.Length)
		{
			int key = (array[num2++] << 16) + (array[num2++] << 8) + array[num2++];
			if (!_0023_003Dz_sf9dBZZ1poK.ContainsKey(key))
			{
				_0023_003Dz_sf9dBZZ1poK.Add(key, num);
			}
			num++;
		}
	}

	private static List<KeyValuePair<short, object>> _0023_003DzyNqfKmqDYQO3joZJJQ_003D_003D(List<KeyValuePair<short, object>> _0023_003DzU3o1kV6AvBoG)
	{
		List<KeyValuePair<short, object>> list = new List<KeyValuePair<short, object>>();
		for (int i = 0; i < _0023_003DzU3o1kV6AvBoG.Count; i++)
		{
			if (_0023_003DzU3o1kV6AvBoG[i].Key == 1004)
			{
				if (((byte[])_0023_003DzU3o1kV6AvBoG[i].Value).Length != 0)
				{
					list.Add(_0023_003DzU3o1kV6AvBoG[i]);
				}
			}
			else
			{
				list.Add(_0023_003DzU3o1kV6AvBoG[i]);
			}
		}
		return list;
	}

	public static OdGeMatrix3d _0023_003DzYFVWlzSSG2ILFnF0uNYYSSaVffW1(PlanarEntity _0023_003DzSd2TVyQ_003D)
	{
		return _0023_003DzYFVWlzSSG2ILFnF0uNYYSSaVffW1(_0023_003DzSd2TVyQ_003D.Plane);
	}

	public static OdGeMatrix3d _0023_003DzYFVWlzSSG2ILFnF0uNYYSSaVffW1(Plane _0023_003DzvGhbQYRYeBOH)
	{
		OdGeMatrix3d odGeMatrix3d = new OdGeMatrix3d();
		odGeMatrix3d.setCoordSystem(new OdGePoint3d(_0023_003DzvGhbQYRYeBOH.Origin.X, _0023_003DzvGhbQYRYeBOH.Origin.Y, _0023_003DzvGhbQYRYeBOH.Origin.Z), new OdGeVector3d(_0023_003DzvGhbQYRYeBOH.AxisX.X, _0023_003DzvGhbQYRYeBOH.AxisX.Y, _0023_003DzvGhbQYRYeBOH.AxisX.Z), new OdGeVector3d(_0023_003DzvGhbQYRYeBOH.AxisY.X, _0023_003DzvGhbQYRYeBOH.AxisY.Y, _0023_003DzvGhbQYRYeBOH.AxisY.Z), new OdGeVector3d(_0023_003DzvGhbQYRYeBOH.AxisZ.X, _0023_003DzvGhbQYRYeBOH.AxisZ.Y, _0023_003DzvGhbQYRYeBOH.AxisZ.Z));
		return odGeMatrix3d;
	}

	private static int _0023_003Dz23yFKuoBPVvreFZ2hw_003D_003D(int _0023_003Dzm6KNqNI_003D, bool _0023_003Dzdc1k2Kc_003D)
	{
		if (_0023_003Dzdc1k2Kc_003D)
		{
			return _0023_003Dzm6KNqNI_003D | 4;
		}
		return _0023_003Dzm6KNqNI_003D & -5;
	}

	private static int _0023_003Dzq8nhNaqflnczyBCILg_003D_003D(int _0023_003Dzm6KNqNI_003D, bool _0023_003Dzdc1k2Kc_003D)
	{
		if (_0023_003Dzdc1k2Kc_003D)
		{
			return _0023_003Dzm6KNqNI_003D | 8;
		}
		return _0023_003Dzm6KNqNI_003D & -9;
	}

	public static void _0023_003DzVEPQ9BWhB6LpsppsyE_7s5k_003D(Dimension _0023_003DzC7d5dBXYZYqbndne3w_003D_003D, OdDbDimension _0023_003DzCPdvaZCXbT3o, WriteDatabase._0023_003DzKyfEzVn70e7f _0023_003DzwzL57J6ueMIu)
	{
		_0023_003DzCPdvaZCXbT3o.transformBy(_0023_003DzYFVWlzSSG2ILFnF0uNYYSSaVffW1(_0023_003DzC7d5dBXYZYqbndne3w_003D_003D));
		_0023_003DzCPdvaZCXbT3o.setDimlunit((short)_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.LinearDimensionUnits);
		_0023_003DzaajJPnOHoY7P(_0023_003DzC7d5dBXYZYqbndne3w_003D_003D, _0023_003DzCPdvaZCXbT3o);
		if (_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.StyleName != null)
		{
			_0023_003DzCPdvaZCXbT3o.setDimtxsty(_0023_003DzwzL57J6ueMIu._0023_003Dz4c0qJg8waJ38[_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.StyleName]);
		}
		if (_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.TextColorMethod == colorMethodType.byLayer)
		{
			_0023_003DzCPdvaZCXbT3o.setDimclrt(new OdCmColor(OdCmEntityColor_ColorMethod.kByLayer));
		}
		else if (_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.TextColorMethod == colorMethodType.byParent)
		{
			_0023_003DzCPdvaZCXbT3o.setDimclrt(new OdCmColor(OdCmEntityColor_ColorMethod.kByBlock));
		}
		else
		{
			_0023_003DzCPdvaZCXbT3o.setDimclrt(_0023_003DztRLzArIqOrBK0lmTPw_003D_003D(_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.TextColor, _0023_003DzwzL57J6ueMIu._0023_003DzujvIJ3_tyt6U(), _0023_003DzwzL57J6ueMIu._0023_003DzFVrp9CCbpZz_0024()));
		}
		_0023_003DzCPdvaZCXbT3o.setDimtxt(_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.Height);
		_0023_003DzCPdvaZCXbT3o.setDimscale(_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.ScaleOverall);
		if (_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.ToleranceMode == toleranceType.Basic)
		{
			_0023_003DzCPdvaZCXbT3o.setDimgap(0.0 - _0023_003DzC7d5dBXYZYqbndne3w_003D_003D.TextGap);
		}
		else
		{
			_0023_003DzCPdvaZCXbT3o.setDimgap(_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.TextGap);
		}
		_0023_003DzCPdvaZCXbT3o.setDimasz(_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.ArrowheadSize);
		string text = (string.IsNullOrEmpty(_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.TextPrefix) ? string.Empty : (_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.TextPrefix + _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532554)));
		if (!string.IsNullOrEmpty(_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.TextSuffix))
		{
			if (string.IsNullOrEmpty(text))
			{
				text += _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532554);
			}
			text += _0023_003DzC7d5dBXYZYqbndne3w_003D_003D.TextSuffix;
		}
		_0023_003DzCPdvaZCXbT3o.setDimpost(text);
		_0023_003DzCPdvaZCXbT3o.setDimensionText(_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.TextOverride);
		_0023_003DzCPdvaZCXbT3o.setDimjust(_0023_003DzQMz3i_E_0rKndiZAAFXdh9A_003D(_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.TextHorizontalPosition));
		_0023_003DzCPdvaZCXbT3o.setDimtad(_0023_003DzZfnEHccvmBPolTomfAfo9mk_003D(_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.TextVerticalPosition));
		_0023_003DzCPdvaZCXbT3o.setDimtoh(val: false);
		_0023_003DzCPdvaZCXbT3o.setDimtih(val: false);
		_0023_003DzCPdvaZCXbT3o.setDimtix(val: false);
		if (_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.UseDefaultTextPosition)
		{
			_0023_003DzCPdvaZCXbT3o.useDefaultTextPosition();
		}
		else
		{
			_0023_003DzCPdvaZCXbT3o.useSetTextPosition();
		}
		_0023_003DzCPdvaZCXbT3o.setDimlfac(_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.LinearScale);
		_0023_003DzCPdvaZCXbT3o.setDimtol(_0023_003Dz6vKyKJI9wfNN(_0023_003DzC7d5dBXYZYqbndne3w_003D_003D));
		_0023_003DzCPdvaZCXbT3o.setDimlim(_0023_003DzdDg_0024l419IeDg(_0023_003DzC7d5dBXYZYqbndne3w_003D_003D));
		_0023_003DzCPdvaZCXbT3o.setDimtp(_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.UpperValue);
		_0023_003DzCPdvaZCXbT3o.setDimtm(_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.LowerValue);
		_0023_003DzCPdvaZCXbT3o.setDimtfac(_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.ScalingForHeight);
		_0023_003DzCPdvaZCXbT3o.setDIMTALN(_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.ToleranceAlignment);
		int _0023_003Dzm6KNqNI_003D = _0023_003DzCPdvaZCXbT3o.dimtzin();
		_0023_003Dzm6KNqNI_003D = _0023_003Dz23yFKuoBPVvreFZ2hw_003D_003D(_0023_003Dzm6KNqNI_003D, _0023_003DzC7d5dBXYZYqbndne3w_003D_003D.ToleranceSuppressLeadingZeros);
		_0023_003Dzm6KNqNI_003D = _0023_003Dzq8nhNaqflnczyBCILg_003D_003D(_0023_003Dzm6KNqNI_003D, _0023_003DzC7d5dBXYZYqbndne3w_003D_003D.ToleranceSuppressTralingZeros);
		_0023_003DzCPdvaZCXbT3o.setDimtzin((byte)_0023_003Dzm6KNqNI_003D);
		_0023_003DzCPdvaZCXbT3o.setDimtdec((short)_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.TolerancePrecision);
	}

	private static void _0023_003DzaajJPnOHoY7P(Dimension _0023_003DzC7d5dBXYZYqbndne3w_003D_003D, OdDbDimension _0023_003DzCPdvaZCXbT3o)
	{
		if (_0023_003DzC7d5dBXYZYqbndne3w_003D_003D is AngularDim)
		{
			short dimazin = _0023_003DzCPdvaZCXbT3o.dimazin();
			if (_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.SuppressLeadingZeros && _0023_003DzC7d5dBXYZYqbndne3w_003D_003D.SuppressTrailingZeros)
			{
				dimazin = 3;
			}
			else if (_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.SuppressLeadingZeros)
			{
				dimazin = 1;
			}
			else if (_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.SuppressTrailingZeros)
			{
				dimazin = 2;
			}
			_0023_003DzCPdvaZCXbT3o.setDimazin(dimazin);
			_0023_003DzCPdvaZCXbT3o.setDimadec((short)_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.Precision);
		}
		else
		{
			int _0023_003Dzm6KNqNI_003D = _0023_003DzCPdvaZCXbT3o.dimzin();
			_0023_003Dzm6KNqNI_003D = _0023_003Dz23yFKuoBPVvreFZ2hw_003D_003D(_0023_003Dzm6KNqNI_003D, _0023_003DzC7d5dBXYZYqbndne3w_003D_003D.SuppressLeadingZeros);
			_0023_003Dzm6KNqNI_003D = _0023_003Dzq8nhNaqflnczyBCILg_003D_003D(_0023_003Dzm6KNqNI_003D, _0023_003DzC7d5dBXYZYqbndne3w_003D_003D.SuppressTrailingZeros);
			_0023_003DzCPdvaZCXbT3o.setDimzin((byte)_0023_003Dzm6KNqNI_003D);
			_0023_003DzCPdvaZCXbT3o.setDimdec((short)_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.Precision);
		}
	}

	private static void _0023_003Dz8jFNCWPoBQNN(Dimension _0023_003DzC7d5dBXYZYqbndne3w_003D_003D, OdDbDimension _0023_003Dz2JSVHDTm_myJ)
	{
		if (_0023_003DzC7d5dBXYZYqbndne3w_003D_003D is AngularDim)
		{
			short num = _0023_003Dz2JSVHDTm_myJ.dimazin();
			_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.SuppressLeadingZeros = (num & 1) != 0;
			_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.SuppressTrailingZeros = ((num >> 1) & 1) != 0;
		}
		else
		{
			byte b = _0023_003Dz2JSVHDTm_myJ.dimzin();
			_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.SuppressLeadingZeros = ((b >> 2) & 1) != 0;
			_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.SuppressTrailingZeros = ((b >> 3) & 1) != 0;
		}
	}

	public static OdDbDimStyleTableRecord _0023_003DzzCUl9noIHm5A2CdO2YRZsvQ_003D(Dimension _0023_003DzC7d5dBXYZYqbndne3w_003D_003D, OdDbDimension _0023_003Dz2JSVHDTm_myJ)
	{
		int num = _0023_003Dz2JSVHDTm_myJ.dimlunit();
		if (num < 7)
		{
			_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.LinearDimensionUnits = (linearDimensionUnitsType)num;
		}
		else
		{
			_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.LinearDimensionUnits = linearDimensionUnitsType.Decimal;
		}
		_0023_003Dz8jFNCWPoBQNN(_0023_003DzC7d5dBXYZYqbndne3w_003D_003D, _0023_003Dz2JSVHDTm_myJ);
		_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.ArrowheadSize = _0023_003Dz2JSVHDTm_myJ.dimasz();
		_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.TextGap = _0023_003Dz2JSVHDTm_myJ.dimgap();
		if (_0023_003Dz2JSVHDTm_myJ.getArrowFirstIsFlipped() && _0023_003Dz2JSVHDTm_myJ.getArrowSecondIsFlipped())
		{
			_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.ArrowsLocation = elementPositionType.Outside;
		}
		_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.TextHorizontalPosition = _0023_003Dz9P4k7LdZkz0iyJYzjKe58eM_003D(_0023_003Dz2JSVHDTm_myJ.dimjust());
		_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.TextVerticalPosition = _0023_003DzCramDgfhkBKzKjQpaUea4bs_003D(_0023_003Dz2JSVHDTm_myJ.dimtad());
		_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.UseDefaultTextPosition = _0023_003Dz2JSVHDTm_myJ.isUsingDefaultTextPosition();
		if (_0023_003Dz2JSVHDTm_myJ.dimclrt().isByBlock())
		{
			_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.TextColorMethod = colorMethodType.byParent;
		}
		else if (_0023_003Dz2JSVHDTm_myJ.dimclrt().isByLayer())
		{
			_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.TextColorMethod = colorMethodType.byLayer;
		}
		else
		{
			_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.TextColorMethod = colorMethodType.byEntity;
			OdCmColor odCmColor = _0023_003Dz2JSVHDTm_myJ.dimclrt();
			_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.TextColor = Color.FromArgb(odCmColor.red(), odCmColor.green(), odCmColor.blue());
		}
		_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.ToleranceMode = _0023_003Dz59SyRyZR2CU4(_0023_003Dz2JSVHDTm_myJ.dimtol(), _0023_003Dz2JSVHDTm_myJ.dimlim(), _0023_003Dz2JSVHDTm_myJ.dimtp(), _0023_003Dz2JSVHDTm_myJ.dimtm(), _0023_003Dz2JSVHDTm_myJ.dimgap());
		if (_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.ToleranceMode == toleranceType.Basic)
		{
			_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.TextGap = 0.0 - _0023_003DzC7d5dBXYZYqbndne3w_003D_003D.TextGap;
		}
		_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.UpperValue = _0023_003Dz2JSVHDTm_myJ.dimtp();
		_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.LowerValue = _0023_003Dz2JSVHDTm_myJ.dimtm();
		_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.ScalingForHeight = _0023_003Dz2JSVHDTm_myJ.dimtfac();
		_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.ToleranceAlignment = _0023_003Dz2JSVHDTm_myJ.getDIMTALN();
		byte b = _0023_003Dz2JSVHDTm_myJ.dimtzin();
		_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.ToleranceSuppressLeadingZeros = ((b >> 2) & 1) != 0;
		_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.ToleranceSuppressTralingZeros = ((b >> 3) & 1) != 0;
		_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.TolerancePrecision = _0023_003Dz2JSVHDTm_myJ.dimtdec();
		if (_0023_003Dz2JSVHDTm_myJ.dimscale() != 0.0)
		{
			_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.ScaleOverall = _0023_003Dz2JSVHDTm_myJ.dimscale();
		}
		OdDbDimStyleTableRecord odDbDimStyleTableRecord = (OdDbDimStyleTableRecord)_0023_003Dz2JSVHDTm_myJ.dimensionStyle().openObject(OdDb_OpenMode.kForRead);
		if (odDbDimStyleTableRecord != null)
		{
			_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.DimStyle = ((odDbDimStyleTableRecord.getName() == _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355531415)) ? string.Empty : odDbDimStyleTableRecord.getName());
		}
		else
		{
			_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.DimStyle = string.Empty;
		}
		OdDbDimStyleTableRecord odDbDimStyleTableRecord2 = OdDbDimStyleTableRecord.createObject();
		_0023_003Dz2JSVHDTm_myJ.getDimstyleData(odDbDimStyleTableRecord2);
		if (!object.Equals(odDbDimStyleTableRecord2.dimtxsty(), OdDbObjectId.kNull))
		{
			OdDbTextStyleTableRecord odDbTextStyleTableRecord = (OdDbTextStyleTableRecord)odDbDimStyleTableRecord2.dimtxsty().safeOpenObject(OdDb_OpenMode.kForRead);
			_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.StyleName = odDbTextStyleTableRecord.getName();
			if (odDbTextStyleTableRecord.textSize() != 0.0 && odDbDimStyleTableRecord2.dimscale() != 0.0)
			{
				_0023_003DzC7d5dBXYZYqbndne3w_003D_003D.Height = odDbTextStyleTableRecord.textSize() / odDbDimStyleTableRecord2.dimscale();
			}
		}
		return odDbDimStyleTableRecord2;
	}

	public static toleranceType _0023_003Dz59SyRyZR2CU4(bool _0023_003DzPXU1NeB9SEcq, bool _0023_003DzSKhjqswtbDeh, double _0023_003Dz4HCPGbmbnG87, double _0023_003DzhfnMh8_0024EA3jc, double _0023_003DzK3BVn8kgJ3hX)
	{
		if (!_0023_003DzPXU1NeB9SEcq && !_0023_003DzSKhjqswtbDeh)
		{
			if (_0023_003DzK3BVn8kgJ3hX < 0.0)
			{
				return toleranceType.Basic;
			}
			return toleranceType.None;
		}
		if (_0023_003DzPXU1NeB9SEcq)
		{
			if (Utility.Compare(_0023_003Dz4HCPGbmbnG87, _0023_003DzhfnMh8_0024EA3jc) == 0)
			{
				return toleranceType.Symmetrical;
			}
			return toleranceType.Deviation;
		}
		return toleranceType.Limits;
	}

	public static bool _0023_003Dz6vKyKJI9wfNN(Dimension _0023_003DzxGpozfDwcjuw)
	{
		toleranceType toleranceMode = _0023_003DzxGpozfDwcjuw.ToleranceMode;
		if (toleranceMode == toleranceType.None || toleranceMode - 3 <= toleranceType.Symmetrical)
		{
			return false;
		}
		return true;
	}

	public static bool _0023_003DzdDg_0024l419IeDg(Dimension _0023_003DzxGpozfDwcjuw)
	{
		if (_0023_003DzxGpozfDwcjuw.ToleranceMode == toleranceType.Limits)
		{
			return true;
		}
		return false;
	}

	public static void _0023_003DzfUoNhZH0qjiX(OdDbDatabase _0023_003DzByIi1wU_003D, OdDbDimension _0023_003DzkeRlGGg30I6n, arrowheadType _0023_003DznQiM5sQUFED_U86ubg_003D_003D, arrowheadType _0023_003DznX_0024wfdDcorUZDQMudw_003D_003D, elementPositionType _0023_003Dzk9a42qYfrinb)
	{
		if (_0023_003DznQiM5sQUFED_U86ubg_003D_003D != _0023_003DznX_0024wfdDcorUZDQMudw_003D_003D)
		{
			_0023_003DzkeRlGGg30I6n.setDimsah(val: true);
			_0023_003DzkeRlGGg30I6n.setDimblk1(new OdDbHardPointerId(TD_DbCoreIntegrated_Globals.OdDmUtil_getArrowId(ReadAutodesk._0023_003DzCpMAPMCSIWkbPePIPnwPrXvcxGji(_0023_003DznQiM5sQUFED_U86ubg_003D_003D), _0023_003DzByIi1wU_003D)));
			_0023_003DzkeRlGGg30I6n.setDimblk2(new OdDbHardPointerId(TD_DbCoreIntegrated_Globals.OdDmUtil_getArrowId(ReadAutodesk._0023_003DzCpMAPMCSIWkbPePIPnwPrXvcxGji(_0023_003DznX_0024wfdDcorUZDQMudw_003D_003D), _0023_003DzByIi1wU_003D)));
		}
		else
		{
			_0023_003DzkeRlGGg30I6n.setDimsah(val: false);
			_0023_003DzkeRlGGg30I6n.setDimblk(new OdDbHardPointerId(TD_DbCoreIntegrated_Globals.OdDmUtil_getArrowId(ReadAutodesk._0023_003DzCpMAPMCSIWkbPePIPnwPrXvcxGji(_0023_003DznQiM5sQUFED_U86ubg_003D_003D), _0023_003DzByIi1wU_003D)));
		}
		switch (_0023_003Dzk9a42qYfrinb)
		{
		case elementPositionType.Outside:
			_0023_003DzkeRlGGg30I6n.setArrowFirstIsFlipped(bIsFlipped: true);
			_0023_003DzkeRlGGg30I6n.setArrowSecondIsFlipped(bIsFlipped: true);
			break;
		case elementPositionType.Inside:
			_0023_003DzkeRlGGg30I6n.setArrowFirstIsFlipped(bIsFlipped: false);
			_0023_003DzkeRlGGg30I6n.setArrowSecondIsFlipped(bIsFlipped: false);
			break;
		}
	}

	internal static Dimension.horizontalAlignmentType _0023_003Dz9P4k7LdZkz0iyJYzjKe58eM_003D(ushort _0023_003DzQHIOLQ3Ghpxi)
	{
		return _0023_003DzQHIOLQ3Ghpxi switch
		{
			0 => Dimension.horizontalAlignmentType.Centered, 
			1 => Dimension.horizontalAlignmentType.FirstExtensionLine, 
			2 => Dimension.horizontalAlignmentType.SecondExtensionLine, 
			_ => Dimension.horizontalAlignmentType.Centered, 
		};
	}

	internal static Dimension.verticalAlignmentType _0023_003DzCramDgfhkBKzKjQpaUea4bs_003D(short _0023_003DzoK1HV6BENJJX)
	{
		return _0023_003DzoK1HV6BENJJX switch
		{
			0 => Dimension.verticalAlignmentType.Centered, 
			1 => Dimension.verticalAlignmentType.Above, 
			4 => Dimension.verticalAlignmentType.Below, 
			_ => Dimension.verticalAlignmentType.Above, 
		};
	}

	internal static ushort _0023_003DzQMz3i_E_0rKndiZAAFXdh9A_003D(Dimension.horizontalAlignmentType _0023_003Dz7_NmwEw_003D)
	{
		return _0023_003Dz7_NmwEw_003D switch
		{
			Dimension.horizontalAlignmentType.FirstExtensionLine => 1, 
			Dimension.horizontalAlignmentType.SecondExtensionLine => 2, 
			_ => 0, 
		};
	}

	internal static short _0023_003DzZfnEHccvmBPolTomfAfo9mk_003D(Dimension.verticalAlignmentType _0023_003Dz7_NmwEw_003D)
	{
		return _0023_003Dz7_NmwEw_003D switch
		{
			Dimension.verticalAlignmentType.Above => 1, 
			Dimension.verticalAlignmentType.Below => 4, 
			_ => 0, 
		};
	}

	internal static attributeReferenceVisibilityType _0023_003Dz9mZVFGzYrhJhKBqejt_VXZI6XVrfRahCFA_003D_003D(int _0023_003DzgW2OgB0_003D)
	{
		return _0023_003DzgW2OgB0_003D switch
		{
			0 => attributeReferenceVisibilityType.Off, 
			1 => attributeReferenceVisibilityType.Normal, 
			_ => attributeReferenceVisibilityType.On, 
		};
	}

	internal static int _0023_003DzMwUDQThh00ih_0024EW2k7ao5gzhI7BqcXziYA_003D_003D(attributeReferenceVisibilityType _0023_003DzgW2OgB0_003D)
	{
		return _0023_003DzgW2OgB0_003D switch
		{
			attributeReferenceVisibilityType.Off => 0, 
			attributeReferenceVisibilityType.Normal => 1, 
			_ => 2, 
		};
	}

	internal static OdResBuf _0023_003DzFAdNEnYlqrJZ(KeyValuePair<short, object>[] _0023_003DzU3o1kV6AvBoG)
	{
		OdResBuf odResBuf = null;
		OdResBuf odResBuf2 = null;
		for (int i = 0; i < _0023_003DzU3o1kV6AvBoG.Length; i++)
		{
			KeyValuePair<short, object> keyValuePair = _0023_003DzU3o1kV6AvBoG[i];
			OdResBuf odResBuf3 = OdResBuf.newRb(keyValuePair.Key);
			if (_0023_003DzDXD2XNUnQuhd(odResBuf3, keyValuePair.Key, keyValuePair.Value))
			{
				if (odResBuf == null)
				{
					odResBuf = (odResBuf2 = odResBuf3);
				}
				else
				{
					odResBuf2 = odResBuf2.setNext(odResBuf3);
				}
			}
		}
		return odResBuf;
	}

	internal static bool _0023_003DzDXD2XNUnQuhd(OdResBuf _0023_003DzXZdGov0_003D, int _0023_003Dzx2J_XgQ_003D, object _0023_003Dzdc1k2Kc_003D)
	{
		switch ((OdResBuf_ValueType)_0023_003Dzx2J_XgQ_003D)
		{
		case OdResBuf_ValueType.kRtPoint2d:
		{
			Point2D point2D = (Point2D)_0023_003Dzdc1k2Kc_003D;
			_0023_003DzXZdGov0_003D.setPoint2d(new OdGePoint2d(point2D.X, point2D.Y));
			break;
		}
		case OdResBuf_ValueType.kRtColor:
			_0023_003DzXZdGov0_003D.setColor((OdCmColor)_0023_003Dzdc1k2Kc_003D);
			break;
		case OdResBuf_ValueType.kRtEntName:
			_0023_003DzXZdGov0_003D.setObjectId((OdDbObjectId)_0023_003Dzdc1k2Kc_003D);
			break;
		default:
			switch (OdDxfCode._getType(_0023_003Dzx2J_XgQ_003D))
			{
			case OdDxfCode_Type.Name:
			case OdDxfCode_Type.String:
			case OdDxfCode_Type.LayerName:
				_0023_003DzXZdGov0_003D.setString((string)_0023_003Dzdc1k2Kc_003D);
				break;
			case OdDxfCode_Type.BinaryChunk:
			{
				OdUInt8Array values = new OdUInt8Array((byte[])_0023_003Dzdc1k2Kc_003D);
				OdBinaryData odBinaryData = new OdBinaryData();
				odBinaryData.AddRange(values);
				_0023_003DzXZdGov0_003D.setBinaryChunk(odBinaryData);
				break;
			}
			case OdDxfCode_Type.Handle:
			case OdDxfCode_Type.ObjectId:
			case OdDxfCode_Type.SoftPointerId:
			case OdDxfCode_Type.HardPointerId:
			case OdDxfCode_Type.SoftOwnershipId:
			case OdDxfCode_Type.HardOwnershipId:
				_0023_003DzXZdGov0_003D.setHandle(new OdDbHandle((string)_0023_003Dzdc1k2Kc_003D));
				break;
			case OdDxfCode_Type.Bool:
				_0023_003DzXZdGov0_003D.setBool(Convert.ToBoolean(_0023_003Dzdc1k2Kc_003D));
				break;
			case OdDxfCode_Type.Integer8:
				_0023_003DzXZdGov0_003D.setInt8(Convert.ToSByte(_0023_003Dzdc1k2Kc_003D));
				break;
			case OdDxfCode_Type.Integer16:
				_0023_003DzXZdGov0_003D.setInt16(Convert.ToInt16(_0023_003Dzdc1k2Kc_003D));
				break;
			case OdDxfCode_Type.Integer32:
				_0023_003DzXZdGov0_003D.setInt32(Convert.ToInt32(_0023_003Dzdc1k2Kc_003D));
				break;
			case OdDxfCode_Type.Double:
			case OdDxfCode_Type.Angle:
				_0023_003DzXZdGov0_003D.setDouble(Convert.ToDouble(_0023_003Dzdc1k2Kc_003D));
				break;
			case OdDxfCode_Type.Point:
				_0023_003DzXZdGov0_003D.setPoint3d(_0023_003Dzzh5VcS4KZoiIBUTAU9kkMuKCym7v_cHtxoIgjHLVjw33._0023_003DzbhysZL9VFmRcYmsohA_003D_003D((Point3D)_0023_003Dzdc1k2Kc_003D));
				break;
			default:
				return false;
			}
			break;
		case OdResBuf_ValueType.kRtNone:
		case OdResBuf_ValueType.kRtVoid:
		case OdResBuf_ValueType.kRtListBeg:
		case OdResBuf_ValueType.kRtListEnd:
		case OdResBuf_ValueType.kRtDote:
		case OdResBuf_ValueType.kRtNil:
		case OdResBuf_ValueType.kRtT:
			break;
		}
		return true;
	}

	internal static List<KeyValuePair<short, object>> _0023_003Dztyuk6QQ_003D(OdResBuf _0023_003DzGl0PeAQkFc1Z)
	{
		List<KeyValuePair<short, object>> list = new List<KeyValuePair<short, object>>();
		while (_0023_003DzGl0PeAQkFc1Z != null)
		{
			int value = _0023_003DzGl0PeAQkFc1Z.restype();
			list.Add(new KeyValuePair<short, object>(Convert.ToInt16(value), _0023_003DzYsPrEi_0024RdyUL(_0023_003DzGl0PeAQkFc1Z)));
			_0023_003DzGl0PeAQkFc1Z = _0023_003DzGl0PeAQkFc1Z.next();
		}
		return list;
	}

	internal static object _0023_003DzYsPrEi_0024RdyUL(OdResBuf _0023_003DzPQDREfkaCUKn)
	{
		if (_0023_003DzPQDREfkaCUKn == null)
		{
			return null;
		}
		int num = _0023_003DzPQDREfkaCUKn.restype();
		switch ((OdResBuf_ValueType)num)
		{
		case OdResBuf_ValueType.kRtPoint2d:
		{
			OdGePoint2d point2d = _0023_003DzPQDREfkaCUKn.getPoint2d();
			return new Point2D(point2d.x, point2d.y);
		}
		case OdResBuf_ValueType.kRtColor:
			return _0023_003DzPQDREfkaCUKn.getColor();
		case OdResBuf_ValueType.kRtNone:
		case OdResBuf_ValueType.kRtVoid:
		case OdResBuf_ValueType.kRtListBeg:
		case OdResBuf_ValueType.kRtListEnd:
		case OdResBuf_ValueType.kRtDote:
		case OdResBuf_ValueType.kRtNil:
		case OdResBuf_ValueType.kRtT:
			return null;
		default:
			switch (OdDxfCode._getType(num))
			{
			case OdDxfCode_Type.Name:
			case OdDxfCode_Type.String:
			case OdDxfCode_Type.LayerName:
				return _0023_003DzPQDREfkaCUKn.getString();
			case OdDxfCode_Type.Bool:
				return _0023_003DzPQDREfkaCUKn.getBool();
			case OdDxfCode_Type.Integer8:
				return _0023_003DzPQDREfkaCUKn.getInt8();
			case OdDxfCode_Type.Integer16:
				return _0023_003DzPQDREfkaCUKn.getInt16();
			case OdDxfCode_Type.Integer32:
				return _0023_003DzPQDREfkaCUKn.getInt32();
			case OdDxfCode_Type.Double:
				return _0023_003DzPQDREfkaCUKn.getDouble();
			case OdDxfCode_Type.Angle:
				return _0023_003DzPQDREfkaCUKn.getDouble();
			case OdDxfCode_Type.Point:
				return ReadAutodesk._0023_003DzHLWQmn1CvBx2(_0023_003DzPQDREfkaCUKn.getPoint3d());
			case OdDxfCode_Type.BinaryChunk:
			{
				OdBinaryData binaryChunk = _0023_003DzPQDREfkaCUKn.getBinaryChunk();
				byte[] array = new byte[binaryChunk.Count];
				for (int i = 0; i < binaryChunk.Count; i++)
				{
					array[i] = binaryChunk[i];
				}
				return array;
			}
			case OdDxfCode_Type.Handle:
			case OdDxfCode_Type.ObjectId:
			case OdDxfCode_Type.SoftPointerId:
			case OdDxfCode_Type.HardPointerId:
			case OdDxfCode_Type.SoftOwnershipId:
			case OdDxfCode_Type.HardOwnershipId:
				return _0023_003DzPQDREfkaCUKn.getHandle().ToString();
			default:
				return null;
			}
		}
	}

	internal static MemoryStream _0023_003DzUgzHlB5nH4GA(OdGiRasterImage _0023_003Dz3O_GxE4_003D)
	{
		uint num = _0023_003Dz3O_GxE4_003D.pixelWidth();
		uint num2 = _0023_003Dz3O_GxE4_003D.pixelHeight();
		_0023_003Dz3O_GxE4_003D.defaultResolution(out var xPelsPerUnit, out var yPelsPerUnit);
		ushort num3 = (ushort)_0023_003Dz3O_GxE4_003D.colorDepth();
		uint num4 = _0023_003Dz3O_GxE4_003D.paletteDataSize();
		uint num5 = _0023_003Dz3O_GxE4_003D.scanLineSize();
		uint num6 = OdGiRasterImage.calcBMPScanLineSize(num, num3);
		MemoryStream memoryStream = new MemoryStream();
		BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
		binaryWriter.Write((short)19778);
		uint num7 = 54 + num4;
		uint value = num7 + num6 * num2;
		binaryWriter.Write((int)value);
		binaryWriter.Write(0);
		binaryWriter.Write((int)num7);
		binaryWriter.Write(40);
		binaryWriter.Write((int)num);
		binaryWriter.Write((int)num2);
		binaryWriter.Write((short)1);
		binaryWriter.Write((short)num3);
		binaryWriter.Write(0);
		binaryWriter.Write(0);
		binaryWriter.Write((int)xPelsPerUnit);
		binaryWriter.Write((int)yPelsPerUnit);
		binaryWriter.Write(0);
		binaryWriter.Write(0);
		byte[] bytes = new byte[num4];
		_0023_003Dz3O_GxE4_003D.paletteData(ref bytes);
		binaryWriter.Write(bytes);
		byte[] array = _0023_003Dz3O_GxE4_003D.scanLines();
		if (array.Length != 0 && num5 == num6)
		{
			binaryWriter.Write(array, 0, (int)(num5 * num2));
		}
		else
		{
			byte[] scnLines = new byte[num6];
			for (uint num8 = 0u; num8 < num2; num8++)
			{
				_0023_003Dz3O_GxE4_003D.scanLines(ref scnLines, num8);
				binaryWriter.Write(scnLines);
			}
		}
		binaryWriter.Flush();
		return memoryStream;
	}

	internal static void _0023_003Dz_0024Ri82GA5O_VX(Stream _0023_003DzLugSv_I_003D, OdStreamBuf _0023_003DzEzzl3C4_003D)
	{
		byte[] buffer = new byte[_0023_003DzLugSv_I_003D.Length];
		_0023_003DzLugSv_I_003D.Read(buffer, 0, (int)_0023_003DzLugSv_I_003D.Length);
		_0023_003DzEzzl3C4_003D.putBytes(buffer);
	}

	internal static void _0023_003Dz_0024Ri82GA5O_VX(OdStreamBuf _0023_003DzLugSv_I_003D, Stream _0023_003DzEzzl3C4_003D)
	{
		int num = (int)_0023_003DzLugSv_I_003D.length();
		OdUInt8Array odUInt8Array = new OdUInt8Array(num);
		_0023_003DzLugSv_I_003D.getBytesByNum(odUInt8Array, 0uL, (uint)num);
		_0023_003DzEzzl3C4_003D.Write(odUInt8Array.ToArray(), 0, num);
	}
}
