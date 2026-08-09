using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using OpenGL;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.DocumentLayoutAnalysis;
using UglyToad.PdfPig.DocumentLayoutAnalysis.PageSegmenter;
using UglyToad.PdfPig.DocumentLayoutAnalysis.ReadingOrderDetector;
using UglyToad.PdfPig.DocumentLayoutAnalysis.WordExtractor;
using UglyToad.PdfPig.Filters;
using UglyToad.PdfPig.Filters.Dct.JpegLibrary;
using UglyToad.PdfPig.Graphics;
using UglyToad.PdfPig.Graphics.Colors;
using UglyToad.PdfPig.Tokens;
using UglyToad.PdfPig.XObjects;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Graphics;

namespace devDept.Eyeshot.Translators;

public class ReadPDF : ReadFileAsync
{
	private sealed class _0023_003DzDqPaXh2XD50m : BaseFilterProvider
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static readonly IFilterProvider _0023_003DzqWKLBHw_003D = new _0023_003DzDqPaXh2XD50m();

		private _0023_003DzDqPaXh2XD50m()
			: base(_0023_003DzjLFv3pU_003D())
		{
		}

		private static Dictionary<string, IFilter> _0023_003DzjLFv3pU_003D()
		{
			Ascii85Filter value = new Ascii85Filter();
			AsciiHexDecodeFilter value2 = new AsciiHexDecodeFilter();
			CcittFaxDecodeFilter value3 = new CcittFaxDecodeFilter();
			JpegLibraryDctDecodeFilter value4 = new JpegLibraryDctDecodeFilter();
			FlateFilter value5 = new FlateFilter();
			Jbig2DecodeFilter value6 = new Jbig2DecodeFilter();
			JpxDecodeFilter value7 = new JpxDecodeFilter();
			RunLengthFilter value8 = new RunLengthFilter();
			LzwFilter value9 = new LzwFilter();
			return new Dictionary<string, IFilter>
			{
				{
					NameToken.Ascii85Decode.Data,
					value
				},
				{
					NameToken.Ascii85DecodeAbbreviation.Data,
					value
				},
				{
					NameToken.AsciiHexDecode.Data,
					value2
				},
				{
					NameToken.AsciiHexDecodeAbbreviation.Data,
					value2
				},
				{
					NameToken.CcittfaxDecode.Data,
					value3
				},
				{
					NameToken.CcittfaxDecodeAbbreviation.Data,
					value3
				},
				{
					NameToken.DctDecode.Data,
					value4
				},
				{
					NameToken.DctDecodeAbbreviation.Data,
					value4
				},
				{
					NameToken.FlateDecode.Data,
					value5
				},
				{
					NameToken.FlateDecodeAbbreviation.Data,
					value5
				},
				{
					NameToken.Jbig2Decode.Data,
					value6
				},
				{
					NameToken.JpxDecode.Data,
					value7
				},
				{
					NameToken.RunLengthDecode.Data,
					value8
				},
				{
					NameToken.RunLengthDecodeAbbreviation.Data,
					value8
				},
				{
					NameToken.LzwDecode.Data,
					value9
				},
				{
					NameToken.LzwDecodeAbbreviation.Data,
					value9
				}
			};
		}
	}

	private static class _0023_003DzJmYT_002400_003D
	{
		public static Func<char, bool> _0023_003DzVAmNOPchxDnCDdRdBA_003D_003D;
	}

	[Serializable]
	private sealed class _0023_003DzP0sFNwY_003D
	{
		public static readonly _0023_003DzP0sFNwY_003D _0023_003Dz84eeg84_003D = new _0023_003DzP0sFNwY_003D();

		public static Func<Letter, int> _0023_003DzHuVcRn0Re8WQCi7HJg_003D_003D;

		public static Func<Letter, Letter, bool> _0023_003DzI2Zy2w6cOUbs0oWoxA_003D_003D;

		internal int _0023_003DzdQLvY3n6vvVJehwM8V2UHqoOixahEoV7uw_003D_003D(Letter _0023_003DzevtAwuM_003D)
		{
			return _0023_003DzevtAwuM_003D.TextSequence;
		}

		internal bool _0023_003DzMI7hlwoAkmdXUFb8nyF3CwI_003D(Letter _0023_003DzEPP3sKE_003D, Letter _0023_003DzsHOFCxU_003D)
		{
			if (string.IsNullOrWhiteSpace(_0023_003DzsHOFCxU_003D.Value))
			{
				return false;
			}
			double num = Math.Max(_0023_003DzEPP3sKE_003D.PointSize, _0023_003DzsHOFCxU_003D.PointSize);
			double num2 = Math.Min(_0023_003DzEPP3sKE_003D.PointSize, _0023_003DzsHOFCxU_003D.PointSize);
			if (num2 != 0.0 && num / num2 > 2.0)
			{
				return false;
			}
			Segment2D seg = new Segment2D(_0023_003DzEPP3sKE_003D.StartBaseLine.X, _0023_003DzEPP3sKE_003D.StartBaseLine.Y, _0023_003DzEPP3sKE_003D.EndBaseLine.X, _0023_003DzEPP3sKE_003D.EndBaseLine.Y);
			if (new Point2D(_0023_003DzsHOFCxU_003D.StartBaseLine.X, _0023_003DzsHOFCxU_003D.StartBaseLine.Y).DistanceTo(seg) > num / 3.0)
			{
				return false;
			}
			(double, double, double) tuple = _0023_003DzEPP3sKE_003D.Color.ToRGBValues();
			(double, double, double) other = _0023_003DzsHOFCxU_003D.Color.ToRGBValues();
			if (!tuple.Equals(other))
			{
				return false;
			}
			return true;
		}
	}

	[StructLayout(LayoutKind.Auto)]
	private struct _0023_003DzXHqx3qCiZHVfXXu6b01IUYM_003D
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public IPdfImage _0023_003DzIyN0clf233Pq;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public byte[] _0023_003Dzl0YtPYtc_EgG;
	}

	private sealed class _0023_003DzXfwo7Ys_003D
	{
		public int _0023_003DzbLUIkw4_003D;

		public double _0023_003Dz_0024a4I8eQ_003D;

		public _0023_003DzXfwo7Ys_003D(double _0023_003DzvF6nzKLBrk8w_vWb5g_003D_003D)
		{
			_0023_003DzbLUIkw4_003D = 0;
			_0023_003Dz_0024a4I8eQ_003D = _0023_003DzvF6nzKLBrk8w_vWb5g_003D_003D;
		}
	}

	public PdfPage[] Pages;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dz3IjCuye6TPiCApVz6UJVHho_003D = true;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<Entity> _0023_003DzO8Khowbenzbk;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<Tuple<RectangleF, double>> _0023_003DzvDJpMuWwM7kozVg0VzEs75s_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IntPtr _0023_003Dzp2m5s38gniuT;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IntPtr _0023_003DzgWbQQ_0024I_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private System.Windows.Forms.Control _0023_003DztWh7TuA_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzmaHfrAkg_836;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int[] _0023_003DztyQ_Z60OfXCM_LO9mvidwB8_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly Dictionary<Letter, string> _0023_003Dz_0024Pmo1X3Rpt77n9B11r9Pc_A_003D = new Dictionary<Letter, string>();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly Dictionary<PdfPath, string> _0023_003DzF4i8wHCxL4mDmP6lSg_003D_003D = new Dictionary<PdfPath, string>();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly Dictionary<IPdfImage, string> _0023_003DzEMzXeFoB43the2lRsA_003D_003D = new Dictionary<IPdfImage, string>();

	public override supportedLinearUnitsType SupportedLinearUnitsType => supportedLinearUnitsType.Millimeters;

	public bool ClipPaths
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz3IjCuye6TPiCApVz6UJVHho_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz3IjCuye6TPiCApVz6UJVHho_003D = value;
		}
	}

	public bool RightToLeft
	{
		get
		{
			return _0023_003DzmaHfrAkg_836;
		}
		set
		{
			_0023_003DzmaHfrAkg_836 = value;
		}
	}

	public int[] PagesToLoad
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DztyQ_Z60OfXCM_LO9mvidwB8_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DztyQ_Z60OfXCM_LO9mvidwB8_003D = value;
		}
	}

	public ReadPDF(string filePath)
		: base(filePath)
	{
	}

	public ReadPDF(Stream stream)
		: base(stream)
	{
	}

	public BlockReference OpenTo(int pageIndex, IDesign design, RegenOptions ro = null, bool removeJittering = false)
	{
		return OpenTo(pageIndex, design.Document, ro, removeJittering);
	}

	public BlockReference OpenTo(int pageIndex, DesignDocument designDoc, RegenOptions ro = null, bool removeJittering = false)
	{
		_0023_003Dzf81G_0024I3ezjRXoGGUKg_003D_003D(pageIndex);
		return OpenTo(designDoc, ro, removeJittering);
	}

	public BlockReference InsertTo(int pageIndex, IWorkspace workspace, RegenOptions ro = null, conflictPolicy conflictPolicy = conflictPolicy.Rename, bool scaleByUnits = true, Point3D insPoint = null, string blockName = null, bool removeJittering = false)
	{
		return InsertTo(pageIndex, workspace.Document, ro, conflictPolicy, scaleByUnits, insPoint, blockName, removeJittering);
	}

	public BlockReference InsertTo(int pageIndex, Document document, RegenOptions ro = null, conflictPolicy conflictPolicy = conflictPolicy.Rename, bool scaleByUnits = true, Point3D insPoint = null, string blockName = null, bool removeJittering = false)
	{
		_0023_003Dzf81G_0024I3ezjRXoGGUKg_003D_003D(pageIndex);
		return InsertTo(document, ro, conflictPolicy, scaleByUnits, insPoint, blockName, removeJittering);
	}

	public void AppendTo(int pageIndex, IWorkspace workspace, RegenOptions ro = null, conflictPolicy conflictPolicy = conflictPolicy.Rename, bool scaleByUnits = true)
	{
		AppendTo(pageIndex, workspace.Document, ro, conflictPolicy, scaleByUnits);
	}

	public void AppendTo(int pageIndex, Document document, RegenOptions ro = null, conflictPolicy conflictPolicy = conflictPolicy.Rename, bool scaleByUnits = true)
	{
		_0023_003Dzf81G_0024I3ezjRXoGGUKg_003D_003D(pageIndex);
		AppendTo(document, ro, conflictPolicy, scaleByUnits);
	}

	private void _0023_003Dzf81G_0024I3ezjRXoGGUKg_003D_003D(int _0023_003DzCUwiag4_003D)
	{
		base.Blocks.Clear(addRootBlock: true);
		base.Blocks.RootBlock.Entities.AddRange(Pages[_0023_003DzCUwiag4_003D].Entities);
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		bool flag = true;
		object[] array = null;
		array = new object[1] { flag };
		_0023_003DzyhuoqeH8sA2fipOFVu_0024vNrvZ5baZl1cB7KAOHYNB1gCDLfwzSg_003D_003D._0023_003DzJFvCOLF47QY9KjaoNO2URxP_00249fg9qG9I_0024MUMd5p_0024tKrBmG2JgA_003D_003D()._0023_003DzPpVzJh2WmrmhWqXh9NNYr_0024sLr3Oq(_0023_003DzyhuoqeH8sA2fipOFVu_0024vNrvZ5baZl1cB7KAOHYNB1gCDLfwzSg_003D_003D._0023_003Dzc3Qn0OgNn7PNyXPUMe9oTNMJcU481onqr2l7palyXDkZrhZNbQ_003D_003D(), "E;fe9q\"ad9", array);
		_0023_003DzwDZawsnueh1x(progress, ct);
	}

	private void _0023_003DzwDZawsnueh1x(IProgress<ProgressChangedEventArgs> _0023_003DzIIIDz8c_003D, CancellationToken _0023_003DzkIE5Tx8_003D)
	{
		Page[] array = null;
		IEnumerable<TextBlock>[] array2 = null;
		IEnumerable<IPdfImage>[] array3 = null;
		int num = 0;
		try
		{
			StartContinuousAnimation(base.ParsingText, _0023_003DzIIIDz8c_003D);
			_0023_003DztWh7TuA_003D = new System.Windows.Forms.Control();
			_0023_003DztWh7TuA_003D.CreateControl();
			_0023_003Dzp2m5s38gniuT = OpenGL.Windows.GetDC(_0023_003DztWh7TuA_003D.Handle);
			base.TextStyles = new TextStyleKeyedCollection();
			ParsingOptions options = new ParsingOptions
			{
				ClipPaths = ClipPaths,
				FilterProvider = _0023_003DzDqPaXh2XD50m._0023_003DzqWKLBHw_003D
			};
			using (PdfDocument pdfDocument = PdfDocument.Open(base.Stream, options))
			{
				array = new Page[pdfDocument.NumberOfPages];
				array2 = new IEnumerable<TextBlock>[pdfDocument.NumberOfPages];
				array3 = new IEnumerable<IPdfImage>[pdfDocument.NumberOfPages];
				Pages = new PdfPage[pdfDocument.NumberOfPages];
				for (int i = 0; i < pdfDocument.NumberOfPages; i++)
				{
					if (PagesToLoad == null || PagesToLoad.Contains(i))
					{
						array[i] = pdfDocument.GetPage(i + 1);
						array2[i] = _0023_003Dzx6_YaOpgGMo5f0Zak3neyuo_003D(array[i].Letters);
						array3[i] = array[i].GetImages();
						num += array2[i].Count() + array3[i].Count() + array[i].ExperimentalAccess.Paths.Count;
					}
				}
				int num2 = 0;
				for (int j = 0; j < array.Length; j++)
				{
					Pages[j] = new PdfPage();
					_0023_003DzO8Khowbenzbk = new List<Entity>();
					_0023_003DzvDJpMuWwM7kozVg0VzEs75s_003D = new List<Tuple<RectangleF, double>>();
					if (PagesToLoad != null && !PagesToLoad.Contains(j))
					{
						continue;
					}
					Page page = array[j];
					Pages[j].Size = new Size2D(page.Width * (127.0 / 360.0), page.Height * (127.0 / 360.0));
					_0023_003DzXfwo7Ys_003D _0023_003DzXfwo7Ys_003D2 = new _0023_003DzXfwo7Ys_003D(Math.Sqrt(page.Height * page.Height + page.Width * page.Width) * 1E-06);
					_0023_003Dz_0024DTgLLs_003D(page);
					foreach (TextBlock item in array2[j])
					{
						foreach (TextLine textLine in item.TextLines)
						{
							foreach (Word word in textLine.Words)
							{
								_0023_003DzvPUxzN4_003D(word, j, _0023_003DzXfwo7Ys_003D2);
							}
						}
						num2++;
						if (!UpdateProgressAndCheckCancelled(num2, num, base.ParsingEntitiesText, _0023_003DzIIIDz8c_003D, _0023_003DzkIE5Tx8_003D))
						{
							return;
						}
					}
					foreach (PdfPath path in page.ExperimentalAccess.Paths)
					{
						_0023_003Dz1wmQNQo_003D(path, j, _0023_003DzXfwo7Ys_003D2);
						num2++;
						if (!UpdateProgressAndCheckCancelled(num2, num, base.ParsingEntitiesText, _0023_003DzIIIDz8c_003D, _0023_003DzkIE5Tx8_003D))
						{
							return;
						}
					}
					foreach (IPdfImage item2 in array3[j])
					{
						_0023_003Dzmw_0v1k_003D(item2, j, _0023_003DzXfwo7Ys_003D2);
						num2++;
						if (!UpdateProgressAndCheckCancelled(num2, num, base.ParsingEntitiesText, _0023_003DzIIIDz8c_003D, _0023_003DzkIE5Tx8_003D))
						{
							return;
						}
					}
					Pages[j].Entities = _0023_003DzO8Khowbenzbk.ToArray();
					if (page.Dictionary.TryGet(NameToken.Create(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348590286)), out ArrayToken token))
					{
						foreach (IToken datum in token.Data)
						{
							if (datum is DictionaryToken dictionaryToken)
							{
								RectangleF? rectangleF = null;
								double? num3 = null;
								if (dictionaryToken.TryGet(NameToken.Create(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601908)), out ArrayToken token2))
								{
									float x = (float)(((NumericToken)token2[0]).Double * (127.0 / 360.0));
									float y = (float)(((NumericToken)token2[1]).Double * (127.0 / 360.0));
									float width = (float)(((NumericToken)token2[2]).Double * (127.0 / 360.0));
									float height = (float)(((NumericToken)token2[3]).Double * (127.0 / 360.0));
									rectangleF = new RectangleF(x, y, width, height);
								}
								if (dictionaryToken.TryGet(NameToken.Create(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601929)), out DictionaryToken token3) && token3.TryGet(NameToken.Create(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589185)), out ArrayToken token4) && token4.Length > 0 && rectangleF.HasValue && (token4[0] as DictionaryToken).TryGet(NameToken.C, out NumericToken token5))
								{
									double num4 = token5.Double;
									num3 = num4 / (127.0 / 360.0);
								}
								if (rectangleF.HasValue && num3.HasValue)
								{
									_0023_003DzvDJpMuWwM7kozVg0VzEs75s_003D.Add(new Tuple<RectangleF, double>(rectangleF.Value, num3.Value));
								}
							}
						}
					}
					Pages[j].Viewports = _0023_003DzvDJpMuWwM7kozVg0VzEs75s_003D.ToArray();
				}
			}
			PdfPage[] pages = Pages;
			for (int k = 0; k < pages.Length; k++)
			{
				Entity[] entities = pages[k].Entities;
				for (int l = 0; l < entities.Length; l++)
				{
					entities[l].Scale(127.0 / 360.0);
				}
			}
			if (Pages.Length != 0)
			{
				base.Blocks.RootBlock.Entities.AddRange(Pages[0].Entities);
			}
			base.Units = linearUnitsType.Millimeters;
			base.Result = true;
		}
		catch (Exception ex)
		{
			log.AppendLine(ex.Message);
			log.AppendLine();
		}
		finally
		{
			if (_0023_003Dzp2m5s38gniuT != IntPtr.Zero)
			{
				OpenGL.Windows.ReleaseDC(_0023_003DzgWbQQ_0024I_003D, _0023_003Dzp2m5s38gniuT);
			}
			_0023_003Dzp2m5s38gniuT = IntPtr.Zero;
			_0023_003DztWh7TuA_003D.Dispose();
			CloseStream();
			StopContinuousAnimation(_0023_003DzIIIDz8c_003D);
		}
	}

	private void _0023_003Dz_0024DTgLLs_003D(Page _0023_003DzdPtQav0_003D)
	{
		try
		{
			foreach (KeyValuePair<string, IReadOnlyList<OptionalContentGroupElement>> optionalContent in _0023_003DzdPtQav0_003D.ExperimentalAccess.GetOptionalContents())
			{
				base.Layers.TryAdd(new Layer(optionalContent.Key));
				foreach (OptionalContentGroupElement item in optionalContent.Value)
				{
					foreach (Letter letter in item.MarkedContent.Letters)
					{
						_0023_003Dz_0024Pmo1X3Rpt77n9B11r9Pc_A_003D.Add(letter, optionalContent.Key);
					}
					foreach (IPdfImage image in item.MarkedContent.Images)
					{
						_0023_003DzEMzXeFoB43the2lRsA_003D_003D.Add(image, optionalContent.Key);
					}
					foreach (PdfPath path in item.MarkedContent.Paths)
					{
						_0023_003DzF4i8wHCxL4mDmP6lSg_003D_003D.Add(path, optionalContent.Key);
					}
				}
			}
		}
		catch (Exception ex)
		{
			log.AppendLine(ex.Message);
		}
	}

	private void _0023_003Dzmw_0v1k_003D(IPdfImage _0023_003DzIyN0clf233Pq, int _0023_003DzDp118Pw_003D, _0023_003DzXfwo7Ys_003D _0023_003DzH2TsVi8NzU18)
	{
		_0023_003DzXHqx3qCiZHVfXXu6b01IUYM_003D _0023_003DzpEBu5QY_003D = default(_0023_003DzXHqx3qCiZHVfXXu6b01IUYM_003D);
		_0023_003DzpEBu5QY_003D._0023_003DzIyN0clf233Pq = _0023_003DzIyN0clf233Pq;
		_0023_003DzpEBu5QY_003D._0023_003Dzl0YtPYtc_EgG = Array.Empty<byte>();
		if (!(_0023_003DzpEBu5QY_003D._0023_003DzIyN0clf233Pq is XObjectImage))
		{
			if (_0023_003DzpEBu5QY_003D._0023_003DzIyN0clf233Pq is InlineImage)
			{
				_0023_003DzpEBu5QY_003D._0023_003Dzl0YtPYtc_EgG = _0023_003DqRE_0HQsAVWP_0024uz3L5kbHNaCD6UtT_NChpirbSsugxhdQ6Bbq3vgQ1dIWdLOfRxky(ref _0023_003DzpEBu5QY_003D);
			}
		}
		else if (!_0023_003DzpEBu5QY_003D._0023_003DzIyN0clf233Pq.TryGetPng(out _0023_003DzpEBu5QY_003D._0023_003Dzl0YtPYtc_EgG))
		{
			_0023_003DzpEBu5QY_003D._0023_003Dzl0YtPYtc_EgG = _0023_003DqRE_0HQsAVWP_0024uz3L5kbHNaCD6UtT_NChpirbSsugxhdQ6Bbq3vgQ1dIWdLOfRxky(ref _0023_003DzpEBu5QY_003D);
		}
		try
		{
			using Image image = Image.FromStream(new MemoryStream(_0023_003DzpEBu5QY_003D._0023_003Dzl0YtPYtc_EgG));
			if (image.PixelFormat.ToString() == _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601947))
			{
				throw new Exception();
			}
			PdfRectangle bounds = _0023_003DzpEBu5QY_003D._0023_003DzIyN0clf233Pq.Bounds;
			Point3D point3D = _0023_003DzcDRQm5jcxOyP(bounds.BottomLeft);
			Point3D p = _0023_003DzcDRQm5jcxOyP(bounds.BottomRight);
			Point3D p2 = _0023_003DzcDRQm5jcxOyP(bounds.TopLeft);
			Vector3D x = new Vector3D(point3D, p);
			Vector3D y = new Vector3D(point3D, p2);
			Plane plane = new Plane(point3D, x, y);
			Picture picture = image.CreatePicture(plane, bounds.Width, bounds.Height);
			picture.LayerName = (_0023_003DzEMzXeFoB43the2lRsA_003D_003D.TryGetValue(_0023_003DzpEBu5QY_003D._0023_003DzIyN0clf233Pq, out var value) ? value : Layer.DefaultLayerName);
			_0023_003Dzk3RV4Sg7fJzE(_0023_003DzDp118Pw_003D, picture, Color.Black, _0023_003DzH2TsVi8NzU18);
		}
		catch (Exception)
		{
			log.AppendLine(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601936));
		}
	}

	private void _0023_003DzvPUxzN4_003D(Word _0023_003DzE5XMqSo_003D, int _0023_003DzCUwiag4_003D, _0023_003DzXfwo7Ys_003D _0023_003DzH2TsVi8NzU18)
	{
		Letter letter = _0023_003DzE5XMqSo_003D.Letters[0];
		if (!base.TextStyles.Contains(_0023_003DzE5XMqSo_003D.FontName))
		{
			string _0023_003DzqheO7Oc_003D;
			string _0023_003Dzq_kQJ00_003D;
			string fontFamilyName = _0023_003Dzv7MVcNhYrNceBKuEI5fnhDTQGr_H(_0023_003DzE5XMqSo_003D.FontName, out _0023_003DzqheO7Oc_003D, out _0023_003Dzq_kQJ00_003D);
			fontStyle style = fontStyle.Regular;
			if (letter.Font.IsBold || _0023_003Dzq_kQJ00_003D == _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348602244))
			{
				style = fontStyle.Bold;
			}
			else if (letter.Font.IsItalic || _0023_003DzqheO7Oc_003D == _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348602265))
			{
				style = fontStyle.Italic;
			}
			TextStyle item = new TextStyle(_0023_003DzE5XMqSo_003D.FontName, fontFamilyName, style);
			base.TextStyles.Add(item);
		}
		Plane plane = Plane.XY;
		switch (_0023_003DzE5XMqSo_003D.TextOrientation)
		{
		case TextOrientation.Other:
		{
			Vector3D vector3D = new Vector3D(_0023_003DzcDRQm5jcxOyP(letter.StartBaseLine), _0023_003DzcDRQm5jcxOyP(letter.EndBaseLine));
			plane = new Plane(Point3D.Origin, vector3D, Vector3D.Cross(Vector3D.AxisZ, vector3D));
			break;
		}
		case TextOrientation.Rotate180:
			plane.Rotate(Math.PI, Vector3D.AxisZ);
			break;
		case TextOrientation.Rotate90:
			plane.Rotate(-Math.PI / 2.0, Vector3D.AxisZ);
			break;
		case TextOrientation.Rotate270:
			plane.Rotate(Math.PI / 2.0, Vector3D.AxisZ);
			break;
		default:
			throw new ArgumentOutOfRangeException();
		case TextOrientation.Horizontal:
			break;
		}
		plane.Origin = _0023_003DzcDRQm5jcxOyP(letter.Location);
		string value;
		Text text = new Text(plane, _0023_003DzE5XMqSo_003D.Text, letter.PointSize)
		{
			StyleName = _0023_003DzE5XMqSo_003D.FontName,
			Visible = (letter.RenderingMode != TextRenderingMode.Neither),
			LayerName = (_0023_003Dz_0024Pmo1X3Rpt77n9B11r9Pc_A_003D.TryGetValue(letter, out value) ? value : Layer.DefaultLayerName)
		};
		if (_0023_003Dzp2m5s38gniuT != IntPtr.Zero)
		{
			TextStyle textStyle = base.TextStyles[_0023_003DzE5XMqSo_003D.FontName];
			double num = RenderContext._0023_003Dz_0024CP_0024fAAqctOo(_0023_003Dzp2m5s38gniuT, textStyle.FontFamilyName, textStyle.Style);
			Font font = new Font(textStyle.FontFamilyName, 2048f, (FontStyle)textStyle.Style, GraphicsUnit.Point);
			IntPtr bmp;
			IntPtr bmp2;
			try
			{
				bmp = font.ToHfont();
				bmp2 = RenderContext.SelectObject(_0023_003Dzp2m5s38gniuT, bmp);
				RenderContext._0023_003DzRrN0c_hLnkUS0VJsjw_003D_003D(letter.Value, _0023_003Dzp2m5s38gniuT, 0.0, _0023_003Dz61oiirkEol0_0024: false, RightToLeft, out var _0023_003Dz9mP3GfVi8Gkv, out var _, num);
				if (_0023_003Dz9mP3GfVi8Gkv.Length != 0)
				{
					Point2D maxValue = Point2D.MaxValue;
					Point2D minValue = Point2D.MinValue;
					for (int i = 0; i < _0023_003Dz9mP3GfVi8Gkv.Length; i++)
					{
						for (int j = 0; j < _0023_003Dz9mP3GfVi8Gkv[i].Length; j++)
						{
							Utility.UpdateMinMaxQuick(_0023_003Dz9mP3GfVi8Gkv[i][j].X, _0023_003Dz9mP3GfVi8Gkv[i][j].Y, maxValue, minValue);
						}
					}
					double num2 = (minValue.Y - maxValue.Y) * text.Height;
					if (letter.GlyphRectangle.Height > 0.0 && num2 > letter.GlyphRectangle.Height)
					{
						text.Height = letter.GlyphRectangle.Height / (minValue.Y - maxValue.Y);
					}
				}
				using System.Drawing.Graphics dc = System.Drawing.Graphics.FromHwnd(IntPtr.Zero);
				double num3 = (double)TextRenderer.MeasureText(proposedSize: new Size(int.MaxValue, int.MaxValue), dc: dc, text: text.TextString, font: font, flags: TextFormatFlags.NoPrefix | TextFormatFlags.NoPadding).Width * num * text.Height;
				text.WidthFactor = _0023_003DzE5XMqSo_003D.BoundingBox.Width / num3;
			}
			finally
			{
				((IDisposable)font).Dispose();
			}
			RenderContext.SelectObject(_0023_003Dzp2m5s38gniuT, bmp2);
			RenderContext.DeleteObject(bmp);
		}
		_0023_003Dzk3RV4Sg7fJzE(_0023_003DzCUwiag4_003D, text, _0023_003DzyC34lnY_003D(letter.Color, _0023_003DzH2TsVi8NzU18._0023_003DzbLUIkw4_003D), _0023_003DzH2TsVi8NzU18);
	}

	private IEnumerable<TextBlock> _0023_003Dzx6_YaOpgGMo5f0Zak3neyuo_003D(IReadOnlyList<Letter> _0023_003Dzhi17VJ6QnuXJ)
	{
		List<TextBlock> list = new List<TextBlock>();
		foreach (IGrouping<int, Letter> item in _0023_003Dzhi17VJ6QnuXJ.GroupBy(_0023_003DzP0sFNwY_003D._0023_003Dz84eeg84_003D._0023_003DzdQLvY3n6vvVJehwM8V2UHqoOixahEoV7uw_003D_003D))
		{
			list.AddRange(_0023_003DzZuxHWc4nKK2q(item.ToList()));
		}
		return list;
	}

	private IEnumerable<TextBlock> _0023_003DzZuxHWc4nKK2q(IReadOnlyList<Letter> _0023_003Dzhi17VJ6QnuXJ)
	{
		IEnumerable<Word> words = new NearestNeighbourWordExtractor(new NearestNeighbourWordExtractor.NearestNeighbourWordExtractorOptions
		{
			Filter = _0023_003DzP0sFNwY_003D._0023_003Dz84eeg84_003D._0023_003DzMI7hlwoAkmdXUFb8nyF3CwI_003D
		}).GetWords(_0023_003Dzhi17VJ6QnuXJ);
		IReadOnlyList<TextBlock> blocks = new DocstrumBoundingBoxes().GetBlocks(words);
		return UnsupervisedReadingOrderDetector.Instance.Get(blocks);
	}

	private Color _0023_003DzyC34lnY_003D(IColor _0023_003Dzhpb8QNg_003D, int _0023_003Dz0hXXP54_003D)
	{
		if (_0023_003Dzhpb8QNg_003D == null)
		{
			return Color.Black;
		}
		if (_0023_003Dzhpb8QNg_003D is PatternColor)
		{
			log.AppendLine(string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348602284), _0023_003Dz0hXXP54_003D));
			return Color.Black;
		}
		(double, double, double) tuple = _0023_003Dzhpb8QNg_003D.ToRGBValues();
		return Color.FromArgb((int)(tuple.Item1 * 255.0), (int)(tuple.Item2 * 255.0), (int)(tuple.Item3 * 255.0));
	}

	private void _0023_003Dzk3RV4Sg7fJzE(int _0023_003DzCUwiag4_003D, Entity _0023_003DztJCl_0024mM_003D, Color _0023_003Dzhpb8QNg_003D, _0023_003DzXfwo7Ys_003D _0023_003Dzt5jpbHs_003D)
	{
		_0023_003DztJCl_0024mM_003D.ColorMethod = colorMethodType.byEntity;
		_0023_003DztJCl_0024mM_003D.Color = _0023_003Dzhpb8QNg_003D;
		_0023_003DztJCl_0024mM_003D.TranslationID = new TranslationIdentifier(_0023_003Dzt5jpbHs_003D._0023_003DzbLUIkw4_003D);
		_0023_003Dzt5jpbHs_003D._0023_003DzbLUIkw4_003D++;
		_0023_003DzO8Khowbenzbk.Add(_0023_003DztJCl_0024mM_003D);
	}

	private static Point3D _0023_003DzcDRQm5jcxOyP(PdfPoint _0023_003DzX_fksVgmDZGw)
	{
		return new Point3D(_0023_003DzX_fksVgmDZGw.X, _0023_003DzX_fksVgmDZGw.Y);
	}

	private void _0023_003Dz1wmQNQo_003D(PdfPath _0023_003DzalfEYyI_003D, int _0023_003DzCUwiag4_003D, _0023_003DzXfwo7Ys_003D _0023_003Dzt5jpbHs_003D)
	{
		List<Entity> list = new List<Entity>();
		Point3D point3D = null;
		Point3D _0023_003DzvzcSMOof9hKQ = null;
		foreach (PdfSubpath item2 in _0023_003DzalfEYyI_003D)
		{
			List<ICurve> list2 = new List<ICurve>();
			foreach (PdfSubpath.IPathCommand command in item2.Commands)
			{
				if (!(command is PdfSubpath.Move move))
				{
					if (!(command is PdfSubpath.BezierCurve bezierCurve))
					{
						if (!(command is PdfSubpath.Close))
						{
							if (!(command is PdfSubpath.Line line))
							{
								throw new ArgumentOutOfRangeException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348602115));
							}
							Line line2 = new Line(_0023_003DzcDRQm5jcxOyP(line.From), _0023_003DzcDRQm5jcxOyP(line.To));
							if (!line2.IsPoint)
							{
								list2.Add(line2);
								_0023_003DzvzcSMOof9hKQ = (Point3D)line2.EndPoint.Clone();
							}
							else
							{
								list2.Add(new devDept.Eyeshot.Entities.Point(line2.StartPoint));
							}
						}
						else
						{
							_0023_003DzVO7lAEilIqIe(list2, point3D, _0023_003DzvzcSMOof9hKQ);
						}
						continue;
					}
					Point3D[] array;
					if (!(bezierCurve is PdfSubpath.CubicBezierCurve cubicBezierCurve))
					{
						if (!(bezierCurve is PdfSubpath.QuadraticBezierCurve quadraticBezierCurve))
						{
							throw new ArgumentOutOfRangeException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348602357));
						}
						array = new Point3D[3]
						{
							_0023_003DzcDRQm5jcxOyP(quadraticBezierCurve.StartPoint),
							_0023_003DzcDRQm5jcxOyP(quadraticBezierCurve.ControlPoint),
							_0023_003DzcDRQm5jcxOyP(quadraticBezierCurve.EndPoint)
						};
					}
					else
					{
						array = new Point3D[4]
						{
							_0023_003DzcDRQm5jcxOyP(cubicBezierCurve.StartPoint),
							_0023_003DzcDRQm5jcxOyP(cubicBezierCurve.FirstControlPoint),
							_0023_003DzcDRQm5jcxOyP(cubicBezierCurve.SecondControlPoint),
							_0023_003DzcDRQm5jcxOyP(cubicBezierCurve.EndPoint)
						};
					}
					_0023_003DzvzcSMOof9hKQ = (Point3D)array.Last().Clone();
					_0023_003DzU03GNnKMrDhNQFN_0024_0024i3M3ps_003D _0023_003DzU03GNnKMrDhNQFN_0024_0024i3M3ps_003D2 = new _0023_003DzU03GNnKMrDhNQFN_0024_0024i3M3ps_003D();
					ICurve item;
					try
					{
						item = new Curve(array.Length - 1, array);
					}
					finally
					{
						((IDisposable)_0023_003DzU03GNnKMrDhNQFN_0024_0024i3M3ps_003D2).Dispose();
					}
					list2.Add(item);
				}
				else
				{
					point3D = _0023_003DzcDRQm5jcxOyP(move.Location);
					_0023_003DzvzcSMOof9hKQ = point3D;
				}
			}
			if (_0023_003DzalfEYyI_003D.IsFilled && list2.Count > 0 && list2.Last().EndPoint != point3D)
			{
				_0023_003DzVO7lAEilIqIe(list2, point3D, _0023_003DzvzcSMOof9hKQ);
			}
			_0023_003Dz3rF_kkOYTb_E(list, list2);
		}
		string value;
		string layerName = (_0023_003DzF4i8wHCxL4mDmP6lSg_003D_003D.TryGetValue(_0023_003DzalfEYyI_003D, out value) ? value : Layer.DefaultLayerName);
		if (_0023_003DzalfEYyI_003D.IsStroked)
		{
			Color _0023_003Dzhpb8QNg_003D = ((_0023_003DzalfEYyI_003D.StrokeColor != null) ? _0023_003DzyC34lnY_003D(_0023_003DzalfEYyI_003D.StrokeColor, _0023_003Dzt5jpbHs_003D._0023_003DzbLUIkw4_003D) : Color.Black);
			foreach (Entity item3 in list)
			{
				item3.LayerName = layerName;
				_0023_003Dzk3RV4Sg7fJzE(_0023_003DzCUwiag4_003D, item3, _0023_003Dzhpb8QNg_003D, _0023_003Dzt5jpbHs_003D);
			}
		}
		if (_0023_003DzalfEYyI_003D.IsFilled)
		{
			devDept.Eyeshot.Entities.Region[] array2 = Utility.DetectRegionsFromContours(list.Cast<ICurve>().ToArray(), Plane.XY);
			foreach (devDept.Eyeshot.Entities.Region region in array2)
			{
				region.LayerName = layerName;
				_0023_003Dzk3RV4Sg7fJzE(_0023_003DzCUwiag4_003D, region, _0023_003DzyC34lnY_003D(_0023_003DzalfEYyI_003D.FillColor, _0023_003Dzt5jpbHs_003D._0023_003DzbLUIkw4_003D), _0023_003Dzt5jpbHs_003D);
			}
		}
	}

	private void _0023_003DzVO7lAEilIqIe(List<ICurve> _0023_003DzRZwF40Wxr_0024ARJTAq0g_003D_003D, Point3D _0023_003DzUYFJQ6LLtHOF, Point3D _0023_003DzvzcSMOof9hKQ)
	{
		if (_0023_003DzUYFJQ6LLtHOF != null && _0023_003DzUYFJQ6LLtHOF != _0023_003DzvzcSMOof9hKQ)
		{
			Line item = new Line(_0023_003DzvzcSMOof9hKQ, _0023_003DzUYFJQ6LLtHOF);
			_0023_003DzRZwF40Wxr_0024ARJTAq0g_003D_003D.Add(item);
		}
	}

	private void _0023_003Dz3rF_kkOYTb_E(IList<Entity> _0023_003Dzr_0024GFKV1CNsOP, IList<ICurve> _0023_003DzPy9CLTJtv_gC)
	{
		if (_0023_003DzPy9CLTJtv_gC.Count > 0)
		{
			if (_0023_003DzPy9CLTJtv_gC.Count == 1)
			{
				_0023_003Dzr_0024GFKV1CNsOP.Add((Entity)_0023_003DzPy9CLTJtv_gC[0]);
			}
			else
			{
				_0023_003Dzr_0024GFKV1CNsOP.Add(new CompositeCurve(_0023_003DzPy9CLTJtv_gC));
			}
		}
	}

	private static string _0023_003Dzv7MVcNhYrNceBKuEI5fnhDTQGr_H(string _0023_003Dza_hu_V0_003D, out string _0023_003DzqheO7Oc_003D, out string _0023_003Dzq_kQJ00_003D)
	{
		_0023_003DzqheO7Oc_003D = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348602158);
		_0023_003Dzq_kQJ00_003D = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348602158);
		if (_0023_003Dza_hu_V0_003D.Contains('+') && _0023_003Dza_hu_V0_003D.Length > 7 && _0023_003Dza_hu_V0_003D[6] == '+')
		{
			string[] array = _0023_003Dza_hu_V0_003D.Split('+');
			if (array[0].All(char.IsUpper))
			{
				_0023_003Dza_hu_V0_003D = array[1];
			}
		}
		char[] separator = new char[2] { '-', ',' };
		string[] array2 = _0023_003Dza_hu_V0_003D.Split(separator);
		_0023_003Dza_hu_V0_003D = array2[0];
		for (int i = 1; i < array2.Length; i++)
		{
			string text = array2[i].ToLowerInvariant();
			if (text.Contains(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348602145)))
			{
				_0023_003Dzq_kQJ00_003D = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348602165);
			}
			else if (text.Contains(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348602183)))
			{
				_0023_003Dzq_kQJ00_003D = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348602183);
			}
			else if (text.Contains(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348602244)))
			{
				_0023_003Dzq_kQJ00_003D = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348602244);
			}
			if (text.Contains(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348602265)))
			{
				_0023_003DzqheO7Oc_003D = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348602265);
			}
			else if (text.Contains(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348602202)))
			{
				_0023_003DzqheO7Oc_003D = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348602202);
			}
		}
		return _0023_003Dza_hu_V0_003D;
	}

	internal static byte[] _0023_003DqRE_0HQsAVWP_0024uz3L5kbHNaCD6UtT_NChpirbSsugxhdQ6Bbq3vgQ1dIWdLOfRxky(ref _0023_003DzXHqx3qCiZHVfXXu6b01IUYM_003D _0023_003DzpEBu5QY_003D)
	{
		if (_0023_003DzpEBu5QY_003D._0023_003DzIyN0clf233Pq.TryGetBytesAsMemory(out var memory))
		{
			_0023_003DzpEBu5QY_003D._0023_003Dzl0YtPYtc_EgG = memory.ToArray();
		}
		else
		{
			_0023_003DzpEBu5QY_003D._0023_003Dzl0YtPYtc_EgG = _0023_003DqUd99tRMNnlTF_0024n6KeVME_dP5fm9Kms9OpyEIVdzGit_4r_mtExaZAoeK5pUi6abc(ref _0023_003DzpEBu5QY_003D);
		}
		return _0023_003DzpEBu5QY_003D._0023_003Dzl0YtPYtc_EgG;
	}

	internal static byte[] _0023_003DqUd99tRMNnlTF_0024n6KeVME_dP5fm9Kms9OpyEIVdzGit_4r_mtExaZAoeK5pUi6abc(ref _0023_003DzXHqx3qCiZHVfXXu6b01IUYM_003D _0023_003DzpEBu5QY_003D)
	{
		byte[] array = _0023_003DzpEBu5QY_003D._0023_003DzIyN0clf233Pq.RawBytes.ToArray();
		foreach (IFilter filter in DefaultFilterProvider.Instance.GetFilters(_0023_003DzpEBu5QY_003D._0023_003DzIyN0clf233Pq.ImageDictionary))
		{
			if (filter.IsSupported)
			{
				array = filter.Decode(array, _0023_003DzpEBu5QY_003D._0023_003DzIyN0clf233Pq.ImageDictionary, DefaultFilterProvider.Instance, 0).ToArray();
			}
		}
		return array;
	}
}
