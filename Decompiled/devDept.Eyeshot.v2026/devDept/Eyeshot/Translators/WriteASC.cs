using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Translators;

public class WriteASC : WriteFileAsync
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly FastPointCloud _0023_003DzT7_0024nBC4FG7Ix;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly char _0023_003DzVQo8al4_003D;

	public static supportedLinearUnitsType SupportedLinearUnitsType => supportedLinearUnitsType.Unitless;

	public WriteASC(FastPointCloud fastPointCloud, string filePath, char separator = ' ')
		: base(new WriteParams(new List<Entity> { fastPointCloud }), filePath)
	{
		_0023_003DzT7_0024nBC4FG7Ix = fastPointCloud;
		_0023_003DzVQo8al4_003D = separator;
	}

	public WriteASC(FastPointCloud fastPointCloud, Stream stream, char separator = ' ')
		: base(new WriteParams(new List<Entity> { fastPointCloud }), stream)
	{
		_0023_003DzT7_0024nBC4FG7Ix = fastPointCloud;
		_0023_003DzVQo8al4_003D = separator;
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		bool flag = true;
		object[] array = null;
		array = new object[1] { flag };
		_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "%fQD,q\"ac>", array);
		try
		{
			TextWriter textWriter = new StreamWriter(base.Stream ?? File.Open(base.FilePath, FileMode.Create, FileAccess.Write), Encoding.ASCII);
			SetWriter(textWriter);
			int num = 0;
			int num2 = _0023_003DzT7_0024nBC4FG7Ix.PointArray.Length;
			for (int i = 0; i < _0023_003DzT7_0024nBC4FG7Ix.PointArray.Length; i += 3)
			{
				string text = _0023_003DzT7_0024nBC4FG7Ix.PointArray[i].ToString() + _0023_003DzVQo8al4_003D + _0023_003DzT7_0024nBC4FG7Ix.PointArray[i + 1] + _0023_003DzVQo8al4_003D + _0023_003DzT7_0024nBC4FG7Ix.PointArray[i + 2];
				if (_0023_003DzT7_0024nBC4FG7Ix.ColorArray != null)
				{
					text += _0023_003DzT7_0024nBC4FG7Ix.ColorArray[i] + _0023_003DzVQo8al4_003D + _0023_003DzT7_0024nBC4FG7Ix.ColorArray[i + 1] + _0023_003DzVQo8al4_003D + _0023_003DzT7_0024nBC4FG7Ix.ColorArray[i + 2];
				}
				textWriter.WriteLine(text);
				if (!UpdateProgressAndCheckCancelled(++num, num2, base.ComposingText, progress, ct))
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
		}
	}
}
