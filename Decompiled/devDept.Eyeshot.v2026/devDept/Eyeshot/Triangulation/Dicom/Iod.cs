using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace devDept.Eyeshot.Triangulation.Dicom;

public class Iod
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<XElement, bool> _0023_003Dz7WKXDUM7qNCMbf2s2g_003D_003D;

		internal bool _0023_003DzrWSEnM9Bu5BW64D4_gJ_Ms4_003D(XElement _0023_003DzB68dg9Q_003D)
		{
			return _0023_003DzB68dg9Q_003D.Name.LocalName == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303016184);
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private XDocument _0023_003Dzx_0024DLVNzgm92pyQuudg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzMAwxuaPlkGJ_BdB1Tg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dz1pTA6dP2CnjlKPQgUzzTgZhv_0024yaq;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dz2AFsbyw8XMG3imyKMmV89tc_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzkdD2A5zS9X0RN7130TDzU_0024I_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzzUS7uwS0VsEsC7reFNJIOvU_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzzhyHTvQAZY6NvY6NfYnQnjY_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dz_0024dkQ3HmZuYuoaZrvpzZICbQNBKQe;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzuKyUFUoIzerOicsTIpG_00242wY_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzMkQCNJd_0024QW57kb29DSVcd7Y_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly _0023_003Dz0MxVpFyvuh9b1awEOcFbBDKTBN7_b2IDh_0024DbTuDGKh4DLkB0KcSnUif8hCth _0023_003DzQdWLNyMJN6IX2Clo4g_003D_003D;

	public XDocument XDocument
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzx_0024DLVNzgm92pyQuudg_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzx_0024DLVNzgm92pyQuudg_003D_003D = value;
		}
	}

	public string FilePath
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzMAwxuaPlkGJ_BdB1Tg_003D_003D;
		}
	}

	public string StudyInstanceUid
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz1pTA6dP2CnjlKPQgUzzTgZhv_0024yaq;
		}
	}

	public string SeriesInstanceUid
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz2AFsbyw8XMG3imyKMmV89tc_003D;
		}
	}

	public string SopInstanceUid
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzkdD2A5zS9X0RN7130TDzU_0024I_003D;
		}
	}

	public string SopClassUid
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzzUS7uwS0VsEsC7reFNJIOvU_003D;
		}
	}

	public string SopClassName
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzzhyHTvQAZY6NvY6NfYnQnjY_003D;
		}
	}

	public string PatientName
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz_0024dkQ3HmZuYuoaZrvpzZICbQNBKQe;
		}
	}

	public string TransferSyntaxUid
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzuKyUFUoIzerOicsTIpG_00242wY_003D;
		}
	}

	public Iod(string filePath)
	{
		_0023_003DzQdWLNyMJN6IX2Clo4g_003D_003D = new _0023_003Dz0MxVpFyvuh9b1awEOcFbBDKTBN7_b2IDh_0024DbTuDGKh4DLkB0KcSnUif8hCth(filePath);
		XDocument = _0023_003DzQdWLNyMJN6IX2Clo4g_003D_003D._0023_003DzXrF1G6Y_003D();
		_0023_003Dzx2KzSAV_00249k6c(filePath);
		_0023_003DztlboC10DWe7KjpH58g_003D_003D(_0023_003DzTYxDR6Eniqu_rc8L34NyyuHwnFqZquiWq5OiLSCrewrbnb9g4TB67Lp2Vbnq_TxY8g_003D_003D._0023_003DzqpYYyyJXlLSrBtUP7A_003D_003D(XDocument, 2097165u));
		_0023_003DzAI5cbCk_EXwN(_0023_003DzTYxDR6Eniqu_rc8L34NyyuHwnFqZquiWq5OiLSCrewrbnb9g4TB67Lp2Vbnq_TxY8g_003D_003D._0023_003DzqpYYyyJXlLSrBtUP7A_003D_003D(XDocument, 2097166u));
		_0023_003Dz2pBIcmGxdqueTyVZ2Q_003D_003D(_0023_003DzTYxDR6Eniqu_rc8L34NyyuHwnFqZquiWq5OiLSCrewrbnb9g4TB67Lp2Vbnq_TxY8g_003D_003D._0023_003DzqpYYyyJXlLSrBtUP7A_003D_003D(XDocument, 524312u));
		_0023_003DzZa9KNdKEjLlgf_0024ueLg_003D_003D(_0023_003DzTYxDR6Eniqu_rc8L34NyyuHwnFqZquiWq5OiLSCrewrbnb9g4TB67Lp2Vbnq_TxY8g_003D_003D._0023_003DzqpYYyyJXlLSrBtUP7A_003D_003D(XDocument, 524310u));
		_0023_003DzUj5FIK4SVsll(SopClassDictionary.GetSopClassName(SopClassUid));
		_0023_003DzhSY6o5wEYl5sWLhhCQ_003D_003D(_0023_003DzTYxDR6Eniqu_rc8L34NyyuHwnFqZquiWq5OiLSCrewrbnb9g4TB67Lp2Vbnq_TxY8g_003D_003D._0023_003DzqpYYyyJXlLSrBtUP7A_003D_003D(XDocument, 1048592u));
		_0023_003Dz5nkp9Et4tCGgqKpqxQ_003D_003D(_0023_003DzTYxDR6Eniqu_rc8L34NyyuHwnFqZquiWq5OiLSCrewrbnb9g4TB67Lp2Vbnq_TxY8g_003D_003D._0023_003DzqpYYyyJXlLSrBtUP7A_003D_003D(XDocument, 131088u));
		_0023_003Dz6oHOhTff2RxQ(_0023_003DzTYxDR6Eniqu_rc8L34NyyuHwnFqZquiWq5OiLSCrewrbnb9g4TB67Lp2Vbnq_TxY8g_003D_003D._0023_003DzpCbgJ2XQpT_0024kCIb2cQ_003D_003D(XDocument, 2097171u, -1.0));
	}

	private void _0023_003Dzx2KzSAV_00249k6c(string _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzMAwxuaPlkGJ_BdB1Tg_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	private void _0023_003DztlboC10DWe7KjpH58g_003D_003D(string _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003Dz1pTA6dP2CnjlKPQgUzzTgZhv_0024yaq = _0023_003DzPzO_0024GUk_003D;
	}

	private void _0023_003DzAI5cbCk_EXwN(string _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003Dz2AFsbyw8XMG3imyKMmV89tc_003D = _0023_003DzPzO_0024GUk_003D;
	}

	private void _0023_003Dz2pBIcmGxdqueTyVZ2Q_003D_003D(string _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzkdD2A5zS9X0RN7130TDzU_0024I_003D = _0023_003DzPzO_0024GUk_003D;
	}

	private void _0023_003DzZa9KNdKEjLlgf_0024ueLg_003D_003D(string _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzzUS7uwS0VsEsC7reFNJIOvU_003D = _0023_003DzPzO_0024GUk_003D;
	}

	private void _0023_003DzUj5FIK4SVsll(string _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzzhyHTvQAZY6NvY6NfYnQnjY_003D = _0023_003DzPzO_0024GUk_003D;
	}

	private void _0023_003DzhSY6o5wEYl5sWLhhCQ_003D_003D(string _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003Dz_0024dkQ3HmZuYuoaZrvpzZICbQNBKQe = _0023_003DzPzO_0024GUk_003D;
	}

	private void _0023_003Dz5nkp9Et4tCGgqKpqxQ_003D_003D(string _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzuKyUFUoIzerOicsTIpG_00242wY_003D = _0023_003DzPzO_0024GUk_003D;
	}

	internal double _0023_003DzjF9bVn7cmceA()
	{
		return _0023_003DzMkQCNJd_0024QW57kb29DSVcd7Y_003D;
	}

	internal void _0023_003Dz6oHOhTff2RxQ(double _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzMkQCNJd_0024QW57kb29DSVcd7Y_003D = _0023_003DzPzO_0024GUk_003D;
	}

	internal DicomVersion _0023_003Dz8mKCrvnmRs_00243pxn8uw_003D_003D()
	{
		return _0023_003DzQdWLNyMJN6IX2Clo4g_003D_003D._0023_003Dz8mKCrvnmRs_00243pxn8uw_003D_003D();
	}

	public bool IsValid()
	{
		if (XDocument == null || XDocument.Descendants().Count(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzrWSEnM9Bu5BW64D4_gJ_Ms4_003D) < 2)
		{
			return false;
		}
		return true;
	}
}
