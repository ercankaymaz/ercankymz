using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ns27;

namespace DevAge.Windows.Forms;

public class Resources
{
	private static Cursor cursor_0;

	private static Cursor cursor_1;

	public static Icon IconSortDown => Class76.smethod_726();

	public static Icon IconSortUp => Class76.smethod_748();

	public static Cursor CursorRightArrow => cursor_0;

	public static Cursor CursorLeftArrow => cursor_1;

	static Resources()
	{
		using (MemoryStream stream = new MemoryStream(Class76.smethod_585()))
		{
			cursor_0 = new Cursor(stream);
		}
		using MemoryStream stream2 = new MemoryStream(Class76.smethod_814());
		cursor_1 = new Cursor(stream2);
	}
}
