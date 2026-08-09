using System.Diagnostics;

namespace devDept.Eyeshot.Triangulation;

public class PictureData<T> where T : struct
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private T[,] _0023_003DzLAyFAZa9sPi_0024;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzcrYuyRw_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DztHnYQdk_003D;

	public T[,] Pixels => _0023_003DzLAyFAZa9sPi_0024;

	public int Rows => _0023_003DzcrYuyRw_003D;

	public int Columns => _0023_003DztHnYQdk_003D;

	public PictureData(int rows, int columns)
	{
		_0023_003DzcrYuyRw_003D = rows;
		_0023_003DztHnYQdk_003D = columns;
		_0023_003DzLAyFAZa9sPi_0024 = new T[rows, columns];
	}
}
