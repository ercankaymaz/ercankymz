using System.Collections.Generic;
using System.Drawing;

internal sealed class _0023_003DzPcRQnBLO6kcc0AFbtzf7o7YPuGQ5MZpu3A_003D_003D
{
	private readonly Dictionary<string, int> _0023_003Dz0uCq1ns_003D = new Dictionary<string, int>();

	public readonly List<(List<_0023_003Dzb2F0Dui7RGks4ARxJqE5972e5jaQ6yD35g_003D_003D>, Color?)> _0023_003DzxuUw1NQ_003D = new List<(List<_0023_003Dzb2F0Dui7RGks4ARxJqE5972e5jaQ6yD35g_003D_003D>, Color?)>();

	public void _0023_003DzPJNpNF4_003D(_0023_003Dzb2F0Dui7RGks4ARxJqE5972e5jaQ6yD35g_003D_003D _0023_003DzHEpjcdg2hk9U)
	{
		string key = (_0023_003DzHEpjcdg2hk9U._0023_003DzL2Ad0Sc_003D.Color.HasValue ? _0023_003DzHEpjcdg2hk9U._0023_003DzL2Ad0Sc_003D.Color.ToString() : _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963495));
		if (!_0023_003Dz0uCq1ns_003D.ContainsKey(key))
		{
			_0023_003Dz0uCq1ns_003D[key] = _0023_003DzxuUw1NQ_003D.Count;
			Color? item = (_0023_003DzHEpjcdg2hk9U._0023_003DzL2Ad0Sc_003D.Color.HasValue ? new Color?(_0023_003DzHEpjcdg2hk9U._0023_003DzL2Ad0Sc_003D.Color.Value) : ((Color?)null));
			_0023_003DzxuUw1NQ_003D.Add((new List<_0023_003Dzb2F0Dui7RGks4ARxJqE5972e5jaQ6yD35g_003D_003D>(), item));
		}
		_0023_003DzxuUw1NQ_003D[_0023_003Dz0uCq1ns_003D[key]].Item1.Add(_0023_003DzHEpjcdg2hk9U);
	}
}
