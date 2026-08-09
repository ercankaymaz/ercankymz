using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Milling;
using devDept.Geometry;

namespace devDept.Eyeshot.Translators;

public class WriteOBJ : WriteFileAsyncWithUnits
{
	protected MaterialKeyedCollection materials;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dz8gXPHSo_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzLHnEpAvwfDPc;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dz8zM9z9Q_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dz_9ZL2Pyk6uph;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dzj_00240wVoc_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzUBZTyC8Ml29h;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextWriter _0023_003DzQCdiuO2P7Dj8;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextWriter _0023_003DzTBWKPdAh9nCE;

	public static supportedLinearUnitsType SupportedLinearUnitsType => supportedLinearUnitsType.All;

	public WriteOBJ(IWorkspace workspace, string filePath, bool selectedOnly = false)
		: this(workspace.Document, filePath, selectedOnly)
	{
	}

	public WriteOBJ(Document document, string filePath, bool selectedOnly = false)
		: this(new WriteParamsWithMaterials(document, selectedOnly), filePath)
	{
	}

	public WriteOBJ(IWorkspace workspace, Stream stream, bool selectedOnly = false)
		: this(workspace.Document, stream, selectedOnly)
	{
	}

	public WriteOBJ(Document document, Stream stream, bool selectedOnly = false)
		: this(new WriteParamsWithMaterials(document, selectedOnly), stream)
	{
	}

	public WriteOBJ(IWorkspace workspace, string filePath, double deviation, bool selectedOnly = false)
		: this(workspace.Document, filePath, deviation, selectedOnly)
	{
	}

	public WriteOBJ(Document document, string filePath, double deviation, bool selectedOnly = false)
		: this(new WriteParamsWithMaterials(document, selectedOnly), filePath, deviation)
	{
	}

	public WriteOBJ(Document document, Stream stream, double deviation, bool selectedOnly = false)
		: this(new WriteParamsWithMaterials(document, selectedOnly), stream, deviation)
	{
	}

	public WriteOBJ(WriteParamsWithMaterials writeParams, string filePath)
		: base(writeParams, filePath)
	{
		_0023_003DzFbxKPRlUPcpd(writeParams);
	}

	public WriteOBJ(WriteParamsWithMaterials writeParams, Stream stream)
		: base(writeParams, stream)
	{
		_0023_003DzFbxKPRlUPcpd(writeParams);
	}

	public WriteOBJ(WriteParamsWithMaterials writeParams, string filePath, double deviation)
		: base(writeParams, filePath)
	{
		_0023_003DzFbxKPRlUPcpd(writeParams);
		base.Deviation = deviation;
	}

	public WriteOBJ(WriteParamsWithMaterials writeParams, Stream stream, double deviation)
		: base(writeParams, stream)
	{
		_0023_003DzFbxKPRlUPcpd(writeParams);
		base.Deviation = deviation;
	}

	[Obsolete("Use the constructor that accepts the WriteParams instead.")]
	public WriteOBJ(IList<Entity> entList, IEnumerable<Layer> layerList, IDictionary<string, Block> blockDict, IDictionary<string, Material> matDict, string filePath, linearUnitsType units, bool selectedOnly = false)
		: base(entList, layerList, blockDict, filePath, units)
	{
		_0023_003DzY0NfqR_0024ntDrYAcwHmw_003D_003D(matDict);
		base.selectedOnly = selectedOnly;
	}

	[Obsolete("Use the constructor that accepts the WriteParams instead.")]
	public WriteOBJ(IList<Entity> entList, IEnumerable<Layer> layerList, IDictionary<string, Block> blockDict, IDictionary<string, Material> matDict, Stream stream, linearUnitsType units, bool selectedOnly = false)
		: base(entList, layerList, blockDict, stream, units)
	{
		_0023_003DzY0NfqR_0024ntDrYAcwHmw_003D_003D(matDict);
		base.selectedOnly = selectedOnly;
	}

	[Obsolete("Use the constructor that accepts the WriteParams instead.")]
	public WriteOBJ(IList<Entity> entList, IEnumerable<Layer> layerList, IDictionary<string, Block> blockDict, IDictionary<string, Material> matDict, string filePath, double deviation, linearUnitsType units, bool selectedOnly = false)
		: base(entList, layerList, blockDict, filePath, units)
	{
		_0023_003DzY0NfqR_0024ntDrYAcwHmw_003D_003D(matDict);
		base.selectedOnly = selectedOnly;
		base.Deviation = deviation;
	}

	[Obsolete("Use the constructor that accepts the WriteParams instead.")]
	public WriteOBJ(IList<Entity> entList, IEnumerable<Layer> layerList, IDictionary<string, Block> blockDict, IDictionary<string, Material> matDict, Stream stream, double deviation, linearUnitsType units, bool selectedOnly = false)
		: base(entList, layerList, blockDict, stream, units)
	{
		_0023_003DzY0NfqR_0024ntDrYAcwHmw_003D_003D(matDict);
		base.selectedOnly = selectedOnly;
		base.Deviation = deviation;
	}

	private void _0023_003DzFbxKPRlUPcpd(WriteParamsWithMaterials _0023_003DzX6XgSWkagNXc)
	{
		materials = _0023_003DzX6XgSWkagNXc.Materials;
		_0023_003DzrtB0QILXyS1kXboL7g_003D_003D(ref materials);
	}

	private void _0023_003DzY0NfqR_0024ntDrYAcwHmw_003D_003D(IDictionary<string, Material> _0023_003Dz50RKVBfLAo0H)
	{
		foreach (KeyValuePair<string, Material> item in _0023_003Dz50RKVBfLAo0H)
		{
			materials.Add(item.Value);
		}
	}

	private string _0023_003DzM_0024sH6fHopWJj(Entity _0023_003Dzs_0024uS8LA_003D)
	{
		return (string)((_0023_003Dzs_0024uS8LA_003D.EntityData != null && _0023_003Dzs_0024uS8LA_003D.EntityData is string) ? _0023_003Dzs_0024uS8LA_003D.EntityData : string.Empty);
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		bool flag = true;
		object[] array = null;
		array = new object[1] { flag };
		_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "%fQD,q\"ac>", array);
		bool flag2 = !string.IsNullOrEmpty(base.FilePath);
		Stream stream = null;
		_0023_003DzTBWKPdAh9nCE = null;
		try
		{
			Stream stream2 = base.Stream ?? File.Open(base.FilePath, FileMode.Create, FileAccess.Write);
			_0023_003DzQCdiuO2P7Dj8 = new StreamWriter(stream2, Encoding.ASCII);
			SetWriter(_0023_003DzQCdiuO2P7Dj8);
			_0023_003DzQCdiuO2P7Dj8.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014855));
			_0023_003DzQCdiuO2P7Dj8.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014832));
			_0023_003DzQCdiuO2P7Dj8.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014503));
			if (!string.IsNullOrEmpty(author))
			{
				_0023_003DzQCdiuO2P7Dj8.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014464) + author);
			}
			if (!string.IsNullOrEmpty(organization))
			{
				_0023_003DzQCdiuO2P7Dj8.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014447) + organization);
			}
			if (!string.IsNullOrEmpty(originatingSystem))
			{
				_0023_003DzQCdiuO2P7Dj8.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014408) + originatingSystem);
			}
			_0023_003DzQCdiuO2P7Dj8.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014627) + units);
			_0023_003DzQCdiuO2P7Dj8.WriteLine(string.Empty);
			string empty = string.Empty;
			_0023_003DzUBZTyC8Ml29h = string.Empty;
			_0023_003Dzj_00240wVoc_003D = string.Empty;
			if (flag2)
			{
				_0023_003Dzj_00240wVoc_003D = Path.GetDirectoryName(base.FilePath);
				_0023_003DzUBZTyC8Ml29h = Directory.CreateDirectory(Path.Combine(_0023_003Dzj_00240wVoc_003D, Path.GetFileNameWithoutExtension(base.FilePath))).FullName;
				empty = ((!(_0023_003Dzj_00240wVoc_003D != string.Empty)) ? (Path.GetFileNameWithoutExtension(base.FilePath) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014617)) : Path.Combine(_0023_003Dzj_00240wVoc_003D, Path.GetFileNameWithoutExtension(base.FilePath) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014617)));
				_0023_003DzQCdiuO2P7Dj8.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014598) + Path.GetFileName(empty));
				empty = _0023_003DzHg_0024BPP4dJ1M_YPc_0024U3Hw5iGNjzzwMvEg8YR8GcmF6Kn6._0023_003Dzz6JDud_0024u1ojF(empty, _0023_003Dzmyw8uNw_003D: true);
				stream = File.Open(empty, FileMode.Create, FileAccess.Write);
				_0023_003DzTBWKPdAh9nCE = new StreamWriter(stream, Encoding.ASCII);
				_0023_003DzTBWKPdAh9nCE.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014580));
				_0023_003DzTBWKPdAh9nCE.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014832));
				_0023_003DzTBWKPdAh9nCE.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014503));
				_0023_003DzTBWKPdAh9nCE.WriteLine(string.Empty);
				foreach (Material material in materials)
				{
					_0023_003DzqhhPO1ja1drk(material, material.Name, _0023_003DzUBZTyC8Ml29h, log);
				}
				for (int i = 0; i < layers.Count; i++)
				{
					Layer layer = layers[i];
					if (layer.MaterialName == null)
					{
						Material _0023_003DzKPUTl6c_003D = new Material(layer.Name, layer.Color);
						_0023_003DzqhhPO1ja1drk(_0023_003DzKPUTl6c_003D, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014558) + layer.Name, _0023_003DzUBZTyC8Ml29h, log);
					}
				}
			}
			_0023_003Dz8gXPHSo_003D = 0;
			_0023_003DzLHnEpAvwfDPc = 0;
			_0023_003Dz8zM9z9Q_003D = 0;
			_0023_003Dz_9ZL2Pyk6uph = 0;
			IList<Entity> list = GetEntities();
			int count = list.Count;
			int num = 0;
			foreach (Entity item in list)
			{
				if (IsVisible(item, out var _))
				{
					if (!(item is BlockReference))
					{
						_0023_003DzQCdiuO2P7Dj8.WriteLine(string.Empty);
						_0023_003DzQCdiuO2P7Dj8.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014537) + _0023_003Dz_9ZL2Pyk6uph + _0023_003DzM_0024sH6fHopWJj(item));
					}
					_0023_003Dz5v26jTE_003D(item, units);
					_0023_003Dz_9ZL2Pyk6uph++;
				}
				if (!UpdateProgressAndCheckCancelled(++num, count, base.ComposingText, progress, ct))
				{
					return;
				}
			}
			UpdateProgressTo100(base.ComposingText, progress);
		}
		catch (Exception ex)
		{
			string message = ex.Message;
			log.AppendLine(message);
			throw new EyeshotException(message, ex);
		}
		finally
		{
			CloseStream();
			if (writeFileCloseStream)
			{
				if (_0023_003DzTBWKPdAh9nCE != null)
				{
					_0023_003DzTBWKPdAh9nCE.Close();
				}
				stream?.Close();
			}
		}
	}

	protected internal void WriteUsemtl(string materialName)
	{
		_0023_003DzQCdiuO2P7Dj8.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015289) + materialName);
	}

	protected internal void WriteUsemtl(Entity ent)
	{
		switch (ent.ColorMethod)
		{
		case colorMethodType.byLayer:
			if (layers.Count > 0)
			{
				Layer layer = layers[ent.LayerName];
				if (string.IsNullOrEmpty(layer.MaterialName))
				{
					_0023_003DzQCdiuO2P7Dj8.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015271) + ent.LayerName);
				}
				else
				{
					_0023_003DzQCdiuO2P7Dj8.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015289) + layer.MaterialName);
				}
			}
			break;
		case colorMethodType.byEntity:
			if (string.IsNullOrEmpty(ent.MaterialName))
			{
				Material _0023_003DzKPUTl6c_003D = new Material(ent.MaterialName, ent.Color);
				_0023_003DzqhhPO1ja1drk(_0023_003DzKPUTl6c_003D, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015259) + _0023_003Dz_9ZL2Pyk6uph + _0023_003DzM_0024sH6fHopWJj(ent), null, null);
				_0023_003DzQCdiuO2P7Dj8.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015241) + _0023_003Dz_9ZL2Pyk6uph + _0023_003DzM_0024sH6fHopWJj(ent));
			}
			else
			{
				_0023_003DzQCdiuO2P7Dj8.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015289) + ent.MaterialName);
			}
			break;
		}
	}

	private void _0023_003DzdBp9Yuc_003D(string _0023_003Dz9ETXvT8_003D, string _0023_003Dzalvl9z8_003D, string _0023_003DzfPTdgzI_003D, byte[] _0023_003DzqwYd0N8_003D)
	{
		if (_0023_003DzqwYd0N8_003D != null)
		{
			string text = WriteFileAsync.RemoveInvalidChars(_0023_003Dz9ETXvT8_003D) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302989229);
			string fullPath = Path.GetFullPath(string.IsNullOrEmpty(_0023_003DzUBZTyC8Ml29h) ? text : Path.Combine(_0023_003DzUBZTyC8Ml29h, text));
			Utility._0023_003DzJf6X3nCs4sU4hFurtQ_003D_003D(_0023_003DzqwYd0N8_003D, fullPath);
			_0023_003DzTBWKPdAh9nCE.WriteLine(Path.Combine(_0023_003DzfPTdgzI_003D + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + _0023_003Dzalvl9z8_003D, text));
		}
	}

	private void _0023_003DzqhhPO1ja1drk(Material _0023_003DzKPUTl6c_003D, string _0023_003DzS_00246o7tc_003D, string _0023_003DzCJkr8nY_003D, StringBuilder _0023_003DzqmF8XJ0_003D)
	{
		if (_0023_003DzTBWKPdAh9nCE == null)
		{
			return;
		}
		if (_0023_003DzqmF8XJ0_003D != null)
		{
			for (int i = 0; i < _0023_003DzS_00246o7tc_003D.Length; i++)
			{
				if (_0023_003DzS_00246o7tc_003D[i] >= '\u0080')
				{
					_0023_003DzqmF8XJ0_003D.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015232));
					break;
				}
			}
		}
		string _0023_003Dzalvl9z8_003D = string.Empty;
		if (!string.IsNullOrEmpty(_0023_003DzCJkr8nY_003D))
		{
			_0023_003Dzalvl9z8_003D = Directory.CreateDirectory(_0023_003DzCJkr8nY_003D).Name;
		}
		_0023_003DzTBWKPdAh9nCE.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015375) + _0023_003DzS_00246o7tc_003D);
		string text = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015357);
		float[] array = Utility.ColorToFloatArray(_0023_003DzKPUTl6c_003D.Ambient);
		_0023_003DzTBWKPdAh9nCE.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015336) + array[0].ToString(text, CultureInfo.InvariantCulture.NumberFormat) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + array[1].ToString(text, CultureInfo.InvariantCulture.NumberFormat) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + array[2].ToString(text, CultureInfo.InvariantCulture.NumberFormat));
		float[] array2 = Utility.ColorToFloatArray(_0023_003DzKPUTl6c_003D.Diffuse);
		_0023_003DzTBWKPdAh9nCE.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015314) + array2[0].ToString(text, CultureInfo.InvariantCulture.NumberFormat) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + array2[1].ToString(text, CultureInfo.InvariantCulture.NumberFormat) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + array2[2].ToString(text, CultureInfo.InvariantCulture.NumberFormat));
		float[] array3 = Utility.ColorToFloatArray(_0023_003DzKPUTl6c_003D.Specular);
		_0023_003DzTBWKPdAh9nCE.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015324) + array3[0].ToString(text, CultureInfo.InvariantCulture.NumberFormat) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + array3[1].ToString(text, CultureInfo.InvariantCulture.NumberFormat) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + array3[2].ToString(text, CultureInfo.InvariantCulture.NumberFormat));
		if (array2[3] != 1f)
		{
			_0023_003DzTBWKPdAh9nCE.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015302) + array2[3].ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat));
		}
		_0023_003DzdBp9Yuc_003D(_0023_003DzS_00246o7tc_003D, _0023_003Dzalvl9z8_003D, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011115), _0023_003DzKPUTl6c_003D.TextureImage);
		_0023_003DzdBp9Yuc_003D(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015309) + _0023_003DzS_00246o7tc_003D, _0023_003Dzalvl9z8_003D, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011281), _0023_003DzKPUTl6c_003D.AlphaMapImage);
		_0023_003DzdBp9Yuc_003D(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015036) + _0023_003DzS_00246o7tc_003D, _0023_003Dzalvl9z8_003D, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011293), _0023_003DzKPUTl6c_003D.EnvironmentMappingImage);
		_0023_003DzTBWKPdAh9nCE.WriteLine(string.Empty);
	}

	private void _0023_003Dz5v26jTE_003D(Entity _0023_003Dz9j7EUB0_003D, linearUnitsType _0023_003DzsAi4oSk_003D)
	{
		Point3D[] vertices;
		if (!(_0023_003Dz9j7EUB0_003D is Bar) && !(_0023_003Dz9j7EUB0_003D is Joint) && !(_0023_003Dz9j7EUB0_003D is devDept.Eyeshot.Entities.Region))
		{
			if (!(_0023_003Dz9j7EUB0_003D is Brep brep))
			{
				if (!(_0023_003Dz9j7EUB0_003D is BlockReference blockReference))
				{
					if (!(_0023_003Dz9j7EUB0_003D is Circle) && !(_0023_003Dz9j7EUB0_003D is Curve) && !(_0023_003Dz9j7EUB0_003D is Ellipse) && !(_0023_003Dz9j7EUB0_003D is Line) && !(_0023_003Dz9j7EUB0_003D is CompositeCurve) && !(_0023_003Dz9j7EUB0_003D is LinearPath))
					{
						IndexTriangle[] triangles;
						if (!(_0023_003Dz9j7EUB0_003D is Surface))
						{
							if (!(_0023_003Dz9j7EUB0_003D is Solid solid))
							{
								if (!(_0023_003Dz9j7EUB0_003D is SketchEntity sketchEntity))
								{
									if (!(_0023_003Dz9j7EUB0_003D is Triangle triangle))
									{
										if (!(_0023_003Dz9j7EUB0_003D is FastMesh fastMesh))
										{
											if (!(_0023_003Dz9j7EUB0_003D is Mesh mesh))
											{
												if (_0023_003Dz9j7EUB0_003D is Quad quad)
												{
													WriteUsemtl(quad);
													vertices = quad._vertices;
													foreach (Point3D point3D in vertices)
													{
														_0023_003DzQCdiuO2P7Dj8.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015013) + point3D.X.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + point3D.Y.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + point3D.Z.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat));
													}
													_0023_003DzQCdiuO2P7Dj8.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015024) + quad.Normal.X + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + quad.Normal.Y + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + quad.Normal.Z);
													_0023_003DzQCdiuO2P7Dj8.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015002) + (_0023_003Dz8gXPHSo_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014977) + (_0023_003Dz8zM9z9Q_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + (_0023_003Dz8gXPHSo_003D + 2) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014977) + (_0023_003Dz8zM9z9Q_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + (_0023_003Dz8gXPHSo_003D + 3) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014977) + (_0023_003Dz8zM9z9Q_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + (_0023_003Dz8gXPHSo_003D + 4) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014977) + (_0023_003Dz8zM9z9Q_003D + 1));
													_0023_003Dz8gXPHSo_003D += quad._vertices.Length;
													_0023_003Dz8zM9z9Q_003D++;
												}
												return;
											}
											if (mesh != null && (mesh.Normals == null || mesh.Normals.Length == 0))
											{
												mesh.Regen(base.Deviation);
											}
											if (mesh.Vertices == null || mesh.Vertices.Length == 0)
											{
												return;
											}
											if (((mesh.MeshNature != Mesh.natureType.RichPlain && mesh.MeshNature != Mesh.natureType.RichSmooth) || mesh.TextureCoords == null) && mesh.MeshNature != Mesh.natureType.ColorPlain && mesh.MeshNature != Mesh.natureType.ColorSmooth && mesh.MeshNature != Mesh.natureType.MulticolorSmooth)
											{
												WriteUsemtl(mesh);
											}
											bool flag = mesh.Vertices[0] is PointRGB;
											vertices = mesh.Vertices;
											foreach (Point3D point3D2 in vertices)
											{
												string text = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015013) + point3D2.X.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + point3D2.Y.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + point3D2.Z.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat);
												if (flag)
												{
													PointRGB obj = (PointRGB)point3D2;
													double num = (float)(int)obj.R / 255f;
													double num2 = (float)(int)obj.G / 255f;
													double num3 = (float)(int)obj.B / 255f;
													text = text + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + num.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + num2.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + num3.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat);
												}
												_0023_003DzQCdiuO2P7Dj8.WriteLine(text);
											}
											if (mesh.Normals != null)
											{
												Vector3D[] normals = mesh.Normals;
												foreach (Vector3D vector3D in normals)
												{
													_0023_003DzQCdiuO2P7Dj8.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015024) + vector3D.X.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + vector3D.Y.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + vector3D.Z.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat));
												}
											}
											if (mesh.TextureCoords != null)
											{
												PointF[] textureCoords = mesh.TextureCoords;
												for (int i = 0; i < textureCoords.Length; i++)
												{
													PointF pointF = textureCoords[i];
													_0023_003DzQCdiuO2P7Dj8.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014963) + pointF.X.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + pointF.Y.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat));
												}
											}
											switch (mesh.MeshNature)
											{
											case Mesh.natureType.ColorPlain:
											{
												List<Color> list2 = new List<Color>();
												Color color3 = Color.Empty;
												for (int m = 0; m < mesh.Triangles.Length; m++)
												{
													ColorTriangle colorTriangle = (ColorTriangle)mesh.Triangles[m];
													Color color4 = Color.FromArgb(colorTriangle.R, colorTriangle.G, colorTriangle.B);
													if (color4 != color3)
													{
														if (!list2.Contains(color4))
														{
															Material _0023_003DzKPUTl6c_003D2 = new Material(string.Empty, color4);
															_0023_003DzqhhPO1ja1drk(_0023_003DzKPUTl6c_003D2, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014973) + _0023_003Dz_9ZL2Pyk6uph + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014955) + color4.Name, null, null);
															list2.Add(color4);
														}
														_0023_003DzQCdiuO2P7Dj8.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014942) + _0023_003Dz_9ZL2Pyk6uph + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014955) + color4.Name);
														color3 = color4;
													}
													_0023_003DzQCdiuO2P7Dj8.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015002) + (colorTriangle.V1 + _0023_003Dz8gXPHSo_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014977) + (m + _0023_003Dz8zM9z9Q_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + (colorTriangle.V2 + _0023_003Dz8gXPHSo_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014977) + (m + _0023_003Dz8zM9z9Q_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + (colorTriangle.V3 + _0023_003Dz8gXPHSo_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014977) + (m + _0023_003Dz8zM9z9Q_003D + 1));
												}
												break;
											}
											case Mesh.natureType.Plain:
											case Mesh.natureType.MulticolorPlain:
											{
												for (int k = 0; k < mesh.Triangles.Length; k++)
												{
													IndexTriangle indexTriangle = mesh.Triangles[k];
													_0023_003DzQCdiuO2P7Dj8.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015002) + (indexTriangle.V1 + _0023_003Dz8gXPHSo_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014977) + (k + _0023_003Dz8zM9z9Q_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + (indexTriangle.V2 + _0023_003Dz8gXPHSo_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014977) + (k + _0023_003Dz8zM9z9Q_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + (indexTriangle.V3 + _0023_003Dz8gXPHSo_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014977) + (k + _0023_003Dz8zM9z9Q_003D + 1));
												}
												break;
											}
											case Mesh.natureType.ColorSmooth:
											{
												List<Color> list = new List<Color>();
												Color color = Color.Empty;
												for (int l = 0; l < mesh.Triangles.Length; l++)
												{
													ColorSmoothTriangle colorSmoothTriangle = (ColorSmoothTriangle)mesh.Triangles[l];
													Color color2 = Color.FromArgb(colorSmoothTriangle.R, colorSmoothTriangle.G, colorSmoothTriangle.B);
													if (color2 != color)
													{
														if (!list.Contains(color2))
														{
															Material _0023_003DzKPUTl6c_003D = new Material(string.Empty, color2);
															_0023_003DzqhhPO1ja1drk(_0023_003DzKPUTl6c_003D, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014973) + _0023_003Dz_9ZL2Pyk6uph + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014955) + color2.Name, null, null);
															list.Add(color2);
														}
														_0023_003DzQCdiuO2P7Dj8.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014942) + _0023_003Dz_9ZL2Pyk6uph + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014955) + color2.Name);
														color = color2;
													}
													_0023_003DzQCdiuO2P7Dj8.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015002) + (colorSmoothTriangle.V1 + _0023_003Dz8gXPHSo_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014977) + (colorSmoothTriangle.N1 + _0023_003Dz8zM9z9Q_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + (colorSmoothTriangle.V2 + _0023_003Dz8gXPHSo_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014977) + (colorSmoothTriangle.N2 + _0023_003Dz8zM9z9Q_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + (colorSmoothTriangle.V3 + _0023_003Dz8gXPHSo_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014977) + (colorSmoothTriangle.N3 + _0023_003Dz8zM9z9Q_003D + 1));
												}
												break;
											}
											case Mesh.natureType.Smooth:
											case Mesh.natureType.MulticolorSmooth:
											{
												triangles = mesh.Triangles;
												for (int i = 0; i < triangles.Length; i++)
												{
													SmoothTriangle smoothTriangle2 = (SmoothTriangle)triangles[i];
													_0023_003DzQCdiuO2P7Dj8.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015002) + (smoothTriangle2.V1 + _0023_003Dz8gXPHSo_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014977) + (smoothTriangle2.N1 + _0023_003Dz8zM9z9Q_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + (smoothTriangle2.V2 + _0023_003Dz8gXPHSo_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014977) + (smoothTriangle2.N2 + _0023_003Dz8zM9z9Q_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + (smoothTriangle2.V3 + _0023_003Dz8gXPHSo_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014977) + (smoothTriangle2.N3 + _0023_003Dz8zM9z9Q_003D + 1));
												}
												break;
											}
											case Mesh.natureType.RichPlain:
												if (mesh.TextureCoords != null)
												{
													WriteUsemtl(mesh.MaterialName);
													for (int n = 0; n < mesh.Triangles.Length; n++)
													{
														RichTriangle richTriangle = (RichTriangle)mesh.Triangles[n];
														_0023_003DzQCdiuO2P7Dj8.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015002) + (richTriangle.V1 + _0023_003Dz8gXPHSo_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302938636) + (richTriangle.T1 + _0023_003DzLHnEpAvwfDPc + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302938636) + (n + _0023_003Dz8zM9z9Q_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + (richTriangle.V2 + _0023_003Dz8gXPHSo_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302938636) + (richTriangle.T2 + _0023_003DzLHnEpAvwfDPc + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302938636) + (n + _0023_003Dz8zM9z9Q_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + (richTriangle.V3 + _0023_003Dz8gXPHSo_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302938636) + (richTriangle.T3 + _0023_003DzLHnEpAvwfDPc + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302938636) + (n + _0023_003Dz8zM9z9Q_003D + 1));
													}
												}
												else
												{
													for (int num4 = 0; num4 < mesh.Triangles.Length; num4++)
													{
														IndexTriangle indexTriangle2 = mesh.Triangles[num4];
														_0023_003DzQCdiuO2P7Dj8.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015002) + (indexTriangle2.V1 + _0023_003Dz8gXPHSo_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014977) + (num4 + _0023_003Dz8zM9z9Q_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + (indexTriangle2.V2 + _0023_003Dz8gXPHSo_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014977) + (num4 + _0023_003Dz8zM9z9Q_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + (indexTriangle2.V3 + _0023_003Dz8gXPHSo_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014977) + (num4 + _0023_003Dz8zM9z9Q_003D + 1));
													}
												}
												break;
											case Mesh.natureType.RichSmooth:
												if (mesh.TextureCoords != null)
												{
													WriteUsemtl(mesh.MaterialName);
													for (int j = 0; j < mesh.Triangles.Length; j++)
													{
														RichSmoothTriangle richSmoothTriangle = (RichSmoothTriangle)mesh.Triangles[j];
														_0023_003DzQCdiuO2P7Dj8.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015002) + (richSmoothTriangle.V1 + _0023_003Dz8gXPHSo_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302938636) + (richSmoothTriangle.T1 + _0023_003DzLHnEpAvwfDPc + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302938636) + (richSmoothTriangle.N1 + _0023_003Dz8zM9z9Q_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + (richSmoothTriangle.V2 + _0023_003Dz8gXPHSo_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302938636) + (richSmoothTriangle.T2 + _0023_003DzLHnEpAvwfDPc + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302938636) + (richSmoothTriangle.N2 + _0023_003Dz8zM9z9Q_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + (richSmoothTriangle.V3 + _0023_003Dz8gXPHSo_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302938636) + (richSmoothTriangle.T3 + _0023_003DzLHnEpAvwfDPc + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302938636) + (richSmoothTriangle.N3 + _0023_003Dz8zM9z9Q_003D + 1));
													}
												}
												else
												{
													triangles = mesh.Triangles;
													for (int i = 0; i < triangles.Length; i++)
													{
														SmoothTriangle smoothTriangle = (SmoothTriangle)triangles[i];
														_0023_003DzQCdiuO2P7Dj8.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015002) + (smoothTriangle.V1 + _0023_003Dz8gXPHSo_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014977) + (smoothTriangle.N1 + _0023_003Dz8zM9z9Q_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + (smoothTriangle.V2 + _0023_003Dz8gXPHSo_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014977) + (smoothTriangle.N2 + _0023_003Dz8zM9z9Q_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + (smoothTriangle.V3 + _0023_003Dz8gXPHSo_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014977) + (smoothTriangle.N3 + _0023_003Dz8zM9z9Q_003D + 1));
													}
												}
												break;
											}
											_0023_003Dz8gXPHSo_003D += mesh.Vertices.Length;
											if (mesh.TextureCoords != null)
											{
												_0023_003DzLHnEpAvwfDPc += mesh.TextureCoords.Length;
											}
											if (mesh.Normals != null)
											{
												_0023_003Dz8zM9z9Q_003D += mesh.Normals.Length;
											}
										}
										else
										{
											if (fastMesh.PointArray == null)
											{
												return;
											}
											int num5 = fastMesh.PointArray.Length;
											if (num5 == 0)
											{
												return;
											}
											bool flag2 = fastMesh.ColorArray != null;
											if (!flag2)
											{
												_ = fastMesh.ColorMethod;
											}
											if (!flag2)
											{
												WriteUsemtl(fastMesh);
											}
											for (int num6 = 0; num6 < num5; num6 += 3)
											{
												string text2 = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015013) + fastMesh.PointArray[num6].ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + fastMesh.PointArray[num6 + 1].ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + fastMesh.PointArray[num6 + 2].ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat);
												if (flag2)
												{
													text2 = text2 + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + ((double)(int)fastMesh.ColorArray[num6] / 255.0).ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957747), CultureInfo.InvariantCulture.NumberFormat) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + ((double)(int)fastMesh.ColorArray[num6 + 1] / 255.0).ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957747), CultureInfo.InvariantCulture.NumberFormat) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + ((double)(int)fastMesh.ColorArray[num6 + 2] / 255.0).ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957747), CultureInfo.InvariantCulture.NumberFormat);
												}
												_0023_003DzQCdiuO2P7Dj8.WriteLine(text2);
											}
											if (fastMesh.NormalArray != null)
											{
												int num7 = fastMesh.NormalArray.Length;
												for (int num8 = 0; num8 < num7; num8 += 3)
												{
													_0023_003DzQCdiuO2P7Dj8.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015024) + fastMesh.NormalArray[num8].ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + fastMesh.NormalArray[num8 + 1].ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + fastMesh.NormalArray[num8 + 2].ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat));
												}
											}
											if (fastMesh.TriangleArray != null)
											{
												int num9 = fastMesh.TriangleArray.Length;
												for (int num10 = 0; num10 < num9; num10 += 3)
												{
													_0023_003DzQCdiuO2P7Dj8.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015002) + (fastMesh.TriangleArray[num10] + _0023_003Dz8gXPHSo_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014977) + (fastMesh.TriangleArray[num10] + _0023_003Dz8zM9z9Q_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + (fastMesh.TriangleArray[num10 + 1] + _0023_003Dz8gXPHSo_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014977) + (fastMesh.TriangleArray[num10 + 1] + _0023_003Dz8zM9z9Q_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + (fastMesh.TriangleArray[num10 + 2] + _0023_003Dz8gXPHSo_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014977) + (fastMesh.TriangleArray[num10 + 2] + _0023_003Dz8zM9z9Q_003D + 1));
												}
											}
											else
											{
												int num11 = num5 / 3;
												for (int num12 = 0; num12 < num11; num12 += 3)
												{
													_0023_003DzQCdiuO2P7Dj8.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015002) + (num12 + _0023_003Dz8gXPHSo_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014977) + (num12 + _0023_003Dz8zM9z9Q_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + (num12 + 1 + _0023_003Dz8gXPHSo_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014977) + (num12 + 1 + _0023_003Dz8zM9z9Q_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + (num12 + 2 + _0023_003Dz8gXPHSo_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014977) + (num12 + 2 + _0023_003Dz8zM9z9Q_003D + 1));
												}
											}
											_0023_003Dz8gXPHSo_003D += num5 / 3;
											if (fastMesh.NormalArray != null)
											{
												_0023_003Dz8zM9z9Q_003D += fastMesh.NormalArray.Length / 3;
											}
											if (_0023_003Dz9j7EUB0_003D is SimulationStock)
											{
												FastMesh[] array = ((SimulationStock)_0023_003Dz9j7EUB0_003D)._0023_003Dz5j0tqfhMCbKvunROsGB6t_I_003D();
												foreach (FastMesh _0023_003Dz9j7EUB0_003D2 in array)
												{
													_0023_003Dz5v26jTE_003D(_0023_003Dz9j7EUB0_003D2, _0023_003DzsAi4oSk_003D);
												}
											}
										}
									}
									else
									{
										WriteUsemtl(triangle);
										vertices = triangle._vertices;
										foreach (Point3D point3D3 in vertices)
										{
											_0023_003DzQCdiuO2P7Dj8.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015013) + point3D3.X.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + point3D3.Y.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + point3D3.Z.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat));
										}
										_0023_003DzQCdiuO2P7Dj8.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015024) + triangle.Normal.X + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + triangle.Normal.Y + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + triangle.Normal.Z);
										_0023_003DzQCdiuO2P7Dj8.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015002) + (_0023_003Dz8gXPHSo_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014977) + (_0023_003Dz8zM9z9Q_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + (_0023_003Dz8gXPHSo_003D + 2) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014977) + (_0023_003Dz8zM9z9Q_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + (_0023_003Dz8gXPHSo_003D + 3) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014977) + (_0023_003Dz8zM9z9Q_003D + 1));
										_0023_003Dz8gXPHSo_003D += triangle._vertices.Length;
										_0023_003Dz8zM9z9Q_003D++;
									}
									return;
								}
								{
									foreach (ICurve curve in sketchEntity.CurveList)
									{
										_0023_003Dz5v26jTE_003D((Entity)curve, _0023_003DzsAi4oSk_003D);
									}
									return;
								}
							}
							if (solid.portions.Count > 0 && solid.portions[0].Triangles == null)
							{
								solid.Regen(1E-12);
							}
							if (solid.portions[0].TextureCoords == null)
							{
								WriteUsemtl(solid);
							}
							else
							{
								WriteUsemtl(solid.MaterialName);
							}
							for (int num13 = 0; num13 < solid.portions.Count; num13++)
							{
								Solid.Portion portion = solid.portions[num13];
								for (int num14 = 0; num14 < portion.vertexCount; num14++)
								{
									_0023_003DzQCdiuO2P7Dj8.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015013) + portion._vertices[num14].X.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + portion._vertices[num14].Y.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + portion._vertices[num14].Z.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat));
								}
							}
							for (int num15 = 0; num15 < solid.portions.Count; num15++)
							{
								Vector3D[] normals = solid.portions[num15].Normals;
								foreach (Vector3D vector3D2 in normals)
								{
									_0023_003DzQCdiuO2P7Dj8.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015024) + vector3D2.X.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + vector3D2.Y.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + vector3D2.Z.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat));
								}
							}
							for (int num16 = 0; num16 < solid.portions.Count; num16++)
							{
								Solid.Portion portion2 = solid.portions[num16];
								if (portion2.TextureCoords != null)
								{
									PointF[] textureCoords = portion2.TextureCoords;
									for (int i = 0; i < textureCoords.Length; i++)
									{
										PointF pointF2 = textureCoords[i];
										_0023_003DzQCdiuO2P7Dj8.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014963) + pointF2.X.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + pointF2.Y.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat));
									}
								}
							}
							for (int num17 = 0; num17 < solid.portions.Count; num17++)
							{
								Solid.Portion portion3 = solid.portions[num17];
								if (solid.UseInnerColors)
								{
									if (portion3.TextureCoords == null)
									{
										_0023_003Dz_9ZL2Pyk6uph++;
										WriteUsemtl(portion3);
									}
									else if (portion3._triangles[0] is RichSmoothTriangle || portion3._triangles[0] is RichTriangle)
									{
										WriteUsemtl(portion3.MaterialName ?? _0023_003Dz9j7EUB0_003D.MaterialName);
									}
								}
								if (portion3.TextureCoords != null)
								{
									triangles = portion3._triangles;
									for (int i = 0; i < triangles.Length; i++)
									{
										RichSmoothTriangle richSmoothTriangle2 = (RichSmoothTriangle)triangles[i];
										_0023_003DzQCdiuO2P7Dj8.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015002) + (richSmoothTriangle2.V1 + _0023_003Dz8gXPHSo_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302938636) + (richSmoothTriangle2.T1 + _0023_003DzLHnEpAvwfDPc + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302938636) + (richSmoothTriangle2.N1 + _0023_003Dz8zM9z9Q_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + (richSmoothTriangle2.V2 + _0023_003Dz8gXPHSo_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302938636) + (richSmoothTriangle2.T2 + _0023_003DzLHnEpAvwfDPc + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302938636) + (richSmoothTriangle2.N2 + _0023_003Dz8zM9z9Q_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + (richSmoothTriangle2.V3 + _0023_003Dz8gXPHSo_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302938636) + (richSmoothTriangle2.T3 + _0023_003DzLHnEpAvwfDPc + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302938636) + (richSmoothTriangle2.N3 + _0023_003Dz8zM9z9Q_003D + 1));
									}
									_0023_003DzLHnEpAvwfDPc += portion3.TextureCoords.Length;
								}
								else
								{
									triangles = portion3._triangles;
									for (int i = 0; i < triangles.Length; i++)
									{
										SmoothTriangle smoothTriangle3 = (SmoothTriangle)triangles[i];
										_0023_003DzQCdiuO2P7Dj8.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015002) + (smoothTriangle3.V1 + _0023_003Dz8gXPHSo_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014977) + (smoothTriangle3.N1 + _0023_003Dz8zM9z9Q_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + (smoothTriangle3.V2 + _0023_003Dz8gXPHSo_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014977) + (smoothTriangle3.N2 + _0023_003Dz8zM9z9Q_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + (smoothTriangle3.V3 + _0023_003Dz8gXPHSo_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014977) + (smoothTriangle3.N3 + _0023_003Dz8zM9z9Q_003D + 1));
									}
								}
								_0023_003Dz8gXPHSo_003D += portion3.vertexCount;
								_0023_003Dz8zM9z9Q_003D += portion3.Normals.Length;
							}
							return;
						}
						WriteUsemtl(_0023_003Dz9j7EUB0_003D);
						float num18 = 1f;
						if (materials != null && !string.IsNullOrEmpty(_0023_003Dz9j7EUB0_003D.MaterialName))
						{
							Material material = materials[_0023_003Dz9j7EUB0_003D.MaterialName];
							if (material != null)
							{
								num18 = (float)(Utility.GetLinearUnitsConversionFactor(material.LinearUnits, _0023_003DzsAi4oSk_003D) * (double)material.TextureLength);
							}
						}
						Surface surface = (Surface)_0023_003Dz9j7EUB0_003D;
						if (base.Deviation != 0.0)
						{
							surface = (Surface)_0023_003Dz9j7EUB0_003D.Clone();
							surface._0023_003DzcX3lwu4d7umF(base.Deviation, base.Angle, null, 0.0, null);
						}
						vertices = surface._vertices;
						for (int i = 0; i < vertices.Length; i++)
						{
							PointNormalUv pointNormalUv = (PointNormalUv)vertices[i];
							_0023_003DzQCdiuO2P7Dj8.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015013) + pointNormalUv.X.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + pointNormalUv.Y.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + pointNormalUv.Z.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat));
							_0023_003DzQCdiuO2P7Dj8.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015024) + pointNormalUv.Nx.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + pointNormalUv.Ny.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + pointNormalUv.Nz.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat));
							_0023_003DzQCdiuO2P7Dj8.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014963) + (pointNormalUv.U / (double)num18).ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + (pointNormalUv.V / (double)num18).ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat));
						}
						triangles = surface._triangles;
						foreach (IndexTriangle indexTriangle3 in triangles)
						{
							_0023_003DzQCdiuO2P7Dj8.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015002) + (indexTriangle3.V1 + _0023_003Dz8gXPHSo_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302938636) + (indexTriangle3.V1 + _0023_003DzLHnEpAvwfDPc + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302938636) + (indexTriangle3.V1 + _0023_003Dz8zM9z9Q_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + (indexTriangle3.V2 + _0023_003Dz8gXPHSo_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302938636) + (indexTriangle3.V2 + _0023_003DzLHnEpAvwfDPc + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302938636) + (indexTriangle3.V2 + _0023_003Dz8zM9z9Q_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + (indexTriangle3.V3 + _0023_003Dz8gXPHSo_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302938636) + (indexTriangle3.V3 + _0023_003DzLHnEpAvwfDPc + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302938636) + (indexTriangle3.V3 + _0023_003Dz8zM9z9Q_003D + 1));
						}
						_0023_003Dz8gXPHSo_003D += surface._vertices.Length;
						_0023_003DzLHnEpAvwfDPc += surface._vertices.Length;
						_0023_003Dz8zM9z9Q_003D += surface._vertices.Length;
					}
					else if (_0023_003Dz9j7EUB0_003D._vertices != null)
					{
						vertices = _0023_003Dz9j7EUB0_003D._vertices;
						foreach (Point3D point3D4 in vertices)
						{
							string value = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015013) + point3D4.X.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + point3D4.Y.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + point3D4.Z.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat);
							_0023_003DzQCdiuO2P7Dj8.WriteLine(value);
						}
						for (int num19 = 1; num19 < _0023_003Dz9j7EUB0_003D._vertices.Length; num19++)
						{
							_0023_003DzQCdiuO2P7Dj8.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014988) + (_0023_003Dz8gXPHSo_003D + num19) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + (_0023_003Dz8gXPHSo_003D + num19 + 1));
						}
						_0023_003Dz8gXPHSo_003D += _0023_003Dz9j7EUB0_003D._vertices.Length;
					}
					return;
				}
				bool flag3 = base.Deviation == 0.0;
				Entity[] array2 = blockReference.Explode(blocks, resolveByParent: true, flag3);
				foreach (Entity entity in array2)
				{
					if ((entity is Joint || entity is Bar || entity.RegenMode == regenType.RegenAndCompile || (!flag3 && (entity is Circle || entity is Ellipse || entity is Curve || entity is Surface || entity is Brep))) && !(entity is BlockReference) && !(entity is Hatch) && !(entity is Table) && !(entity is Text))
					{
						entity.Regen(base.Deviation);
					}
					_0023_003DzQCdiuO2P7Dj8.WriteLine(string.Empty);
					_0023_003DzQCdiuO2P7Dj8.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014537) + _0023_003Dz_9ZL2Pyk6uph + _0023_003DzM_0024sH6fHopWJj(entity));
					_0023_003Dz5v26jTE_003D(entity, blocks[blockReference.BlockName].Units);
					_0023_003Dz_9ZL2Pyk6uph++;
				}
			}
			else
			{
				Mesh mesh2 = (string.IsNullOrEmpty(_0023_003Dz9j7EUB0_003D.MaterialName) ? brep.ConvertToMesh(base.Deviation, base.Angle, Mesh.natureType.ColorSmooth, weldNow: true, 0.0, null, linearUnitsType.Unitless, _0023_003Dz9j7EUB0_003D.GetColor(layers)) : ((materials[_0023_003Dz9j7EUB0_003D.MaterialName].Texture == null) ? brep.ConvertToMesh(base.Deviation, base.Angle) : brep.ConvertToMesh(base.Deviation, base.Angle, Mesh.natureType.RichSmooth, weldNow: true, 0.0, materials, _0023_003DzsAi4oSk_003D)));
				mesh2.NormalAveragingMode = Mesh.normalAveragingType.AveragedByAngle;
				mesh2.UpdateNormals();
				mesh2.CopyAttributes(brep);
				_0023_003Dz5v26jTE_003D(mesh2, _0023_003DzsAi4oSk_003D);
			}
			return;
		}
		ITriangles triangles2 = (ITriangles)_0023_003Dz9j7EUB0_003D;
		WriteUsemtl(_0023_003Dz9j7EUB0_003D);
		vertices = _0023_003Dz9j7EUB0_003D._vertices;
		foreach (Point3D point3D5 in vertices)
		{
			_0023_003DzQCdiuO2P7Dj8.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015013) + point3D5.X.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + point3D5.Y.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + point3D5.Z.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat));
		}
		Plane plane = new Plane();
		Vector3D[] array3 = new Vector3D[1] { plane.AxisZ };
		if (array3 != null && _0023_003Dz9j7EUB0_003D is devDept.Eyeshot.Entities.Region)
		{
			Vector3D[] normals = array3;
			foreach (Vector3D vector3D3 in normals)
			{
				_0023_003DzQCdiuO2P7Dj8.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015024) + vector3D3.X.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + vector3D3.Y.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + vector3D3.Z.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat));
			}
		}
		for (int num20 = 0; num20 < triangles2.Triangles.Length; num20++)
		{
			IndexTriangle indexTriangle4 = triangles2.Triangles[num20];
			if (_0023_003Dz9j7EUB0_003D is devDept.Eyeshot.Entities.Region)
			{
				_0023_003DzQCdiuO2P7Dj8.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015002) + (indexTriangle4.V1 + _0023_003Dz8gXPHSo_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014977) + (_0023_003Dz8zM9z9Q_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + (indexTriangle4.V2 + _0023_003Dz8gXPHSo_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014977) + (_0023_003Dz8zM9z9Q_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + (indexTriangle4.V3 + _0023_003Dz8gXPHSo_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303014977) + (_0023_003Dz8zM9z9Q_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382));
			}
			else
			{
				_0023_003DzQCdiuO2P7Dj8.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015002) + (indexTriangle4.V1 + _0023_003Dz8gXPHSo_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + (indexTriangle4.V2 + _0023_003Dz8gXPHSo_003D + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + (indexTriangle4.V3 + _0023_003Dz8gXPHSo_003D + 1));
			}
		}
		_0023_003Dz8gXPHSo_003D += _0023_003Dz9j7EUB0_003D._vertices.Length;
		if (array3 != null)
		{
			_0023_003Dz8zM9z9Q_003D += array3.Length;
		}
	}
}
