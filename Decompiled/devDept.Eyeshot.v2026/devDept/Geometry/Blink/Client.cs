using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO.Pipes;
using System.Linq;
using System.Threading;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry.Blink.Message;
using devDept.Graphics;

namespace devDept.Geometry.Blink;

internal static class Client
{
	private sealed class _0023_003DzL8s0pp6bLIRBrP4TcyR5TqE_003D<_0023_003DzWWgGxds_003D> where _0023_003DzWWgGxds_003D : Entity
	{
		public Color? _0023_003Dz1MMYB1g_003D;

		public float? _0023_003DzxOQTW6c4mcu_0024;

		public string _0023_003DzaROjBYA_003D;

		internal EntityMsg _0023_003DzAiWohOMqg2cgoodm2Q_003D_003D(_0023_003DzWWgGxds_003D _0023_003DzvM_00244CJo_003D)
		{
			return new EntityMsg(_0023_003DzvM_00244CJo_003D, _0023_003Dz1MMYB1g_003D, _0023_003DzxOQTW6c4mcu_0024, _0023_003DzaROjBYA_003D);
		}
	}

	private static class _0023_003DzQm9ltrs_003D
	{
		public static TimerCallback _0023_003DzvIrwTx3gZ0r6_uMHlQ_003D_003D;
	}

	private sealed class _0023_003DzUmLfqmvLa9bTfAncEAxGQy8_003D<_0023_003DzWWgGxds_003D> where _0023_003DzWWgGxds_003D : Vector2D
	{
		public Point3D _0023_003DzyJ5nTo4SqUIy;

		public Color? _0023_003Dz1MMYB1g_003D;

		public string _0023_003DzaROjBYA_003D;

		internal VectorMsg _0023_003DzAiWohOMqg2cgoodm2Q_003D_003D(_0023_003DzWWgGxds_003D _0023_003DzvM_00244CJo_003D)
		{
			return new VectorMsg(_0023_003DzvM_00244CJo_003D, _0023_003DzyJ5nTo4SqUIy, _0023_003Dz1MMYB1g_003D, _0023_003DzaROjBYA_003D);
		}
	}

	private sealed class _0023_003DzsltMXTiISeGlAv_0024UcQ_003D_003D
	{
		public Color _0023_003Dzt_m8zV0_003D;

		public float _0023_003DzWPFOr9I_003D;

		internal LabelMsg _0023_003DzAiWohOMqg2cgoodm2Q_003D_003D(_0023_003DzDzTyQ_0024VEnE2r_qbrJj1pFW2kd2ku87Rgmw_003D_003D _0023_003Dzk_kguF0_003D)
		{
			return new LabelMsg(_0023_003Dzk_kguF0_003D._0023_003DzGXUYGeo_003D, _0023_003Dzk_kguF0_003D._0023_003DzILC_NQY_003D, _0023_003Dzt_m8zV0_003D, _0023_003DzWPFOr9I_003D);
		}
	}

	private static Timer _timer;

	private static readonly List<BlinkMsg> _bag = new List<BlinkMsg>();

	private static readonly Stopwatch _stopwatch = new Stopwatch();

	private static ClientConfiguration _config;

	private static readonly _0023_003DzaJA7Sza6xVxt0VGS3iKiqtzfO0aguMmL7aIogsQ_003D _serializer = new _0023_003DzaJA7Sza6xVxt0VGS3iKiqtzfO0aguMmL7aIogsQ_003D();

	public static void Blink(this Entity entity, Color? color = null, float? lineWeight = null, string layerName = null)
	{
		if (entity != null)
		{
			new Entity[1] { entity }.Blink(color, lineWeight, layerName);
		}
	}

	public static void Blink<T>(this IEnumerable<T> entities, Color? color = null, float? lineWeight = null, string layerName = null) where T : Entity
	{
		_0023_003DzL8s0pp6bLIRBrP4TcyR5TqE_003D<T> _0023_003DzL8s0pp6bLIRBrP4TcyR5TqE_003D2 = new _0023_003DzL8s0pp6bLIRBrP4TcyR5TqE_003D<T>();
		_0023_003DzL8s0pp6bLIRBrP4TcyR5TqE_003D2._0023_003Dz1MMYB1g_003D = color;
		_0023_003DzL8s0pp6bLIRBrP4TcyR5TqE_003D2._0023_003DzxOQTW6c4mcu_0024 = lineWeight;
		_0023_003DzL8s0pp6bLIRBrP4TcyR5TqE_003D2._0023_003DzaROjBYA_003D = layerName;
		TimedBlink(entities.Select(_0023_003DzL8s0pp6bLIRBrP4TcyR5TqE_003D2._0023_003DzAiWohOMqg2cgoodm2Q_003D_003D));
	}

	public static void Blink(this Vector2D vector, Point3D applicationPoint = null, Color? color = null, string layerName = null)
	{
		if (!(vector == null))
		{
			new Vector2D[1] { vector }.Blink(applicationPoint, color, layerName);
		}
	}

	public static void Blink<T>(this IEnumerable<T> vectors, Point3D applicationPoint, Color? color = null, string layerName = null) where T : Vector2D
	{
		_0023_003DzUmLfqmvLa9bTfAncEAxGQy8_003D<T> _0023_003DzUmLfqmvLa9bTfAncEAxGQy8_003D2 = new _0023_003DzUmLfqmvLa9bTfAncEAxGQy8_003D<T>();
		_0023_003DzUmLfqmvLa9bTfAncEAxGQy8_003D2._0023_003DzyJ5nTo4SqUIy = applicationPoint;
		_0023_003DzUmLfqmvLa9bTfAncEAxGQy8_003D2._0023_003Dz1MMYB1g_003D = color;
		_0023_003DzUmLfqmvLa9bTfAncEAxGQy8_003D2._0023_003DzaROjBYA_003D = layerName;
		TimedBlink(vectors.Select(_0023_003DzUmLfqmvLa9bTfAncEAxGQy8_003D2._0023_003DzAiWohOMqg2cgoodm2Q_003D_003D));
	}

	public static void Blink(IEnumerable<_0023_003DzDzTyQ_0024VEnE2r_qbrJj1pFW2kd2ku87Rgmw_003D_003D> labels, Color? color = null, float? fontSize = null)
	{
		_0023_003DzsltMXTiISeGlAv_0024UcQ_003D_003D _0023_003DzsltMXTiISeGlAv_0024UcQ_003D_003D2 = new _0023_003DzsltMXTiISeGlAv_0024UcQ_003D_003D();
		_0023_003DzsltMXTiISeGlAv_0024UcQ_003D_003D2._0023_003Dzt_m8zV0_003D = color ?? Color.CornflowerBlue;
		_0023_003DzsltMXTiISeGlAv_0024UcQ_003D_003D2._0023_003DzWPFOr9I_003D = fontSize ?? 10f;
		LabelMsg[] array = labels.Select(_0023_003DzsltMXTiISeGlAv_0024UcQ_003D_003D2._0023_003DzAiWohOMqg2cgoodm2Q_003D_003D).ToArray();
		if (array.Length >= 1)
		{
			TimedBlink(array);
		}
	}

	public static void Blink(MaterialKeyedCollection materials)
	{
		if (materials.Document != null)
		{
			MaterialKeyedCollection materialKeyedCollection = new MaterialKeyedCollection();
			foreach (Material material2 in materials)
			{
				Material material = (Material)material2.Clone();
				material.TextureLength = (float)((double)material2.TextureLength * Utility.GetLinearUnitsConversionFactor(linearUnitsType.Meters, materials.Document.Units));
				materialKeyedCollection.Add(material);
			}
			CollectionsMsg collectionsMsg = new CollectionsMsg
			{
				Materials = materialKeyedCollection
			};
			TimedBlink(new CollectionsMsg[1] { collectionsMsg });
		}
		else
		{
			CollectionsMsg collectionsMsg = new CollectionsMsg
			{
				Materials = materials
			};
			TimedBlink(new CollectionsMsg[1] { collectionsMsg });
		}
	}

	public static void Blink(TextStyleKeyedCollection textStyles)
	{
		if (textStyles.Document != null)
		{
			TextStyleKeyedCollection textStyleKeyedCollection = new TextStyleKeyedCollection();
			foreach (TextStyle textStyle in textStyles)
			{
				TextStyle item = (TextStyle)textStyle.Clone();
				textStyleKeyedCollection.Add(item);
			}
			CollectionsMsg collectionsMsg = new CollectionsMsg
			{
				TextStyles = textStyleKeyedCollection
			};
			TimedBlink(new CollectionsMsg[1] { collectionsMsg });
		}
		else
		{
			CollectionsMsg collectionsMsg = new CollectionsMsg
			{
				TextStyles = textStyles
			};
			TimedBlink(new CollectionsMsg[1] { collectionsMsg });
		}
	}

	public static void Blink(this string text, Point3D position, Color? color = null, float? fontSize = null)
	{
		TimedBlink(new LabelMsg[1]
		{
			new LabelMsg(text, position, color ?? Color.DodgerBlue, fontSize ?? 10f)
		});
	}

	public static void Clear(string layer = null)
	{
		TimedBlink(new ClearMsg[1]
		{
			new ClearMsg(layer)
		});
	}

	public static void SetView(viewType view)
	{
		TimedBlink(new ViewMsg[1]
		{
			new ViewMsg(view)
		});
	}

	public static void ZoomFit(IList<Entity> entList = null)
	{
		TimedBlink(new FitMsg[1]
		{
			new FitMsg(entList)
		});
	}

	public static void SetBackfaceColorMethod(backfaceColorMethodType colorMethod)
	{
		TimedBlink(new BackfaceMsg[1]
		{
			new BackfaceMsg(colorMethod)
		});
	}

	private static void TimedBlink(IEnumerable<BlinkMsg> messages)
	{
		if (!Debugger.IsAttached || !BlinkCommands._0023_003Dzt6sRNJEKlIH5())
		{
			return;
		}
		if (!_stopwatch.IsRunning || _stopwatch.ElapsedMilliseconds > 1000)
		{
			_config = GetConfiguration();
			_stopwatch.Restart();
		}
		if (!_config.Bagging)
		{
			Blink(messages);
			return;
		}
		lock (_bag)
		{
			_bag.AddRange(messages);
			if (_timer == null)
			{
				_timer = new Timer(TimerTick, null, 20, -1);
			}
		}
	}

	private static void TimerTick(object sender)
	{
		ForceSend();
		_timer.Dispose();
		_timer = null;
	}

	public static void ForceSend()
	{
		lock (_bag)
		{
			if (_bag.Count > 0)
			{
				Blink(_bag);
				_bag.Clear();
			}
		}
	}

	private static void Blink(IEnumerable<BlinkMsg> messages)
	{
		NamedPipeClientStream namedPipeClientStream = new NamedPipeClientStream(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908290), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302654853), PipeDirection.Out, PipeOptions.None);
		try
		{
			namedPipeClientStream.Connect();
			foreach (BlinkMsg message in messages)
			{
				_serializer._0023_003Dz18lsJP2p7ers(namedPipeClientStream, message, 1);
			}
		}
		finally
		{
			((IDisposable)namedPipeClientStream).Dispose();
		}
		_serializer._0023_003DzUal_0024ApYHAIaM();
	}

	private static ClientConfiguration GetConfiguration()
	{
		NamedPipeClientStream namedPipeClientStream = new NamedPipeClientStream(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908290), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302654560), PipeDirection.In, PipeOptions.None);
		ClientConfiguration result;
		try
		{
			namedPipeClientStream.Connect();
			result = _serializer._0023_003Dzc25DZSkxWle7<ClientConfiguration>(namedPipeClientStream, out var _, 1);
		}
		finally
		{
			((IDisposable)namedPipeClientStream).Dispose();
		}
		_serializer._0023_003DzUal_0024ApYHAIaM();
		return result;
	}
}
