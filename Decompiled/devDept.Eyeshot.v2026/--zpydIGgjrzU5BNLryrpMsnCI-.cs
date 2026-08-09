using System;
using System.Linq;
using System.Net.NetworkInformation;

internal sealed class _0023_003DzpydIGgjrzU5BNLryrpMsnCI_003D
{
	private static class _0023_003DzQm9ltrs_003D
	{
		public static Func<string[], bool> _0023_003Dzwm7YfRpRvm0R4mCIVqulrH8_003D;
	}

	private static string _0023_003DzfCCAZuTbtflJ;

	public static string _0023_003DzCQEUdvylSN_0024X()
	{
		return (string)_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzrXgUYL0XH6cHIwqkUbl2jAY_003D(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "qu-Noq\"abJ", null);
	}

	private static string _0023_003DzRfanCdnohW5Q()
	{
		string[] array = _0023_003DzG_qjOUV5KbpIFu9FX9yjVAs_003D._0023_003DzEtoW85hrfAy0().FirstOrDefault(_0023_003DzoYPez13fBbFj);
		if (array == null)
		{
			return string.Empty;
		}
		return array[3];
	}

	private static bool _0023_003DzoYPez13fBbFj(string[] _0023_003Dzsq5cMMlmsy3P)
	{
		if (_0023_003Dzsq5cMMlmsy3P[0].Equals(NetworkInterfaceType.Wireless80211.ToString()))
		{
			return false;
		}
		string text = _0023_003Dzsq5cMMlmsy3P[1].Trim();
		if (text.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302673390)) > -1 || text.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302673345)) > -1 || text.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302673329)) > -1)
		{
			return false;
		}
		string text2 = _0023_003Dzsq5cMMlmsy3P[3];
		if (string.IsNullOrEmpty(text2) || text2.Equals(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302673339)))
		{
			return false;
		}
		return true;
	}
}
