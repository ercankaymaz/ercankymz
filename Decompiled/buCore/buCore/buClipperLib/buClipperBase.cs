using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ns53;
using ns54;
using ns56;
using ns57;

namespace buCore.buClipperLib;

public class buClipperBase
{
	public const long loRange = 1073741823L;

	public const long hiRange = 4611686018427387903L;

	internal Class149 class149_0;

	internal Class149 class149_1;

	internal List<List<Class148>> list_0 = new List<List<Class148>>();

	internal Class150 class150_0;

	internal List<Class152> list_1;

	internal Class148 class148_0;

	internal bool bool_0;

	internal bool bool_1;

	[CompilerGenerated]
	private bool bool_2;

	public bool PreserveCollinear
	{
		[CompilerGenerated]
		get
		{
			return bool_2;
		}
		[CompilerGenerated]
		set
		{
			bool_2 = value;
		}
	}

	public void Swap(ref long val1, ref long val2)
	{
		long num = val1;
		val1 = val2;
		val2 = num;
	}

	internal buClipperBase()
	{
		class149_0 = null;
		class149_1 = null;
		bool_0 = false;
		bool_1 = false;
	}

	public virtual void Clear()
	{
		Class156.smethod_286(this);
		for (int i = 0; i < list_0.Count; i++)
		{
			for (int j = 0; j < list_0[i].Count; j++)
			{
				list_0[i][j] = null;
			}
			list_0[i].Clear();
		}
		list_0.Clear();
		bool_0 = false;
		bool_1 = false;
	}

	public bool AddPath(List<IntPoint> pg, PolyType polyType, bool Closed)
	{
		if (Closed || polyType != PolyType.ptClip)
		{
			int num = pg.Count - 1;
			if (Closed)
			{
				while (num > 0 && pg[num] == pg[0])
				{
					num--;
				}
			}
			while (num > 0 && pg[num] == pg[num - 1])
			{
				num--;
			}
			if ((!Closed || num >= 2) && (Closed || num >= 1))
			{
				List<Class148> list = new List<Class148>(num + 1);
				for (int i = 0; i <= num; i++)
				{
					list.Add(new Class148());
				}
				bool flag = true;
				list[1].intPoint_1 = pg[1];
				IntPoint intPoint_ = pg[0];
				Class156.smethod_15(intPoint_, ref bool_0, this);
				intPoint_ = pg[num];
				Class156.smethod_15(intPoint_, ref bool_0, this);
				Class148 @class = list[0];
				Class148 class148_ = list[1];
				Class148 class148_2 = list[num];
				IntPoint intPoint_2 = pg[0];
				Class156.smethod_48(@class, this, class148_, class148_2, intPoint_2);
				@class = list[num];
				class148_ = list[0];
				class148_2 = list[num - 1];
				intPoint_2 = pg[num];
				Class156.smethod_48(@class, this, class148_, class148_2, intPoint_2);
				for (int num2 = num - 1; num2 >= 1; num2--)
				{
					intPoint_ = pg[num2];
					Class156.smethod_15(intPoint_, ref bool_0, this);
					@class = list[num2];
					class148_ = list[num2 + 1];
					class148_2 = list[num2 - 1];
					intPoint_2 = pg[num2];
					Class156.smethod_48(@class, this, class148_, class148_2, intPoint_2);
				}
				Class148 class2 = list[0];
				Class148 class3 = class2;
				Class148 class4 = class2;
				do
				{
					IL_021e:
					if (!(class3.intPoint_1 == class3.class148_0.intPoint_1) || (!Closed && class3.class148_0 == class2))
					{
						if (class3.class148_1 == class3.class148_0)
						{
							break;
						}
						if (Closed)
						{
							IntPoint intPoint_3 = class3.class148_1.intPoint_1;
							IntPoint intPoint_4 = class3.intPoint_1;
							IntPoint intPoint_5 = class3.class148_0.intPoint_1;
							if (Class156.smethod_103(bool_0, intPoint_4, intPoint_5, intPoint_3))
							{
								if (PreserveCollinear)
								{
									IntPoint intPoint_6 = class3.class148_1.intPoint_1;
									IntPoint intPoint_7 = class3.intPoint_1;
									IntPoint intPoint_8 = class3.class148_0.intPoint_1;
									if (Class156.smethod_32(intPoint_6, intPoint_7, this, intPoint_8))
									{
										goto IL_0207;
									}
								}
								if (class3 == class2)
								{
									class2 = class3.class148_0;
								}
								class3 = Class156.smethod_202(this, class3);
								class3 = class3.class148_1;
								class4 = class3;
								goto IL_021e;
							}
						}
						goto IL_0207;
					}
					if (class3 == class3.class148_0)
					{
						break;
					}
					if (class3 == class2)
					{
						class2 = class3.class148_0;
					}
					class3 = Class156.smethod_202(this, class3);
					class4 = class3;
					goto IL_021e;
					IL_0207:
					class3 = class3.class148_0;
				}
				while (class3 != class4 && (Closed || class3.class148_0 != class2));
				if ((Closed || class3 != class3.class148_0) && (!Closed || class3.class148_1 != class3.class148_0))
				{
					if (!Closed)
					{
						bool_1 = true;
						class2.class148_1.int_3 = -2;
					}
					class3 = class2;
					do
					{
						Class156.smethod_74(polyType, class3, this);
						class3 = class3.class148_0;
						if (flag && class3.intPoint_1.Y != class2.intPoint_1.Y)
						{
							flag = false;
						}
					}
					while (class3 != class2);
					if (!flag)
					{
						list_0.Add(list);
						Class148 class5 = null;
						if (class3.class148_1.intPoint_0 == class3.class148_1.intPoint_2)
						{
							class3 = class3.class148_0;
						}
						while (true)
						{
							class3 = Class156.smethod_105(class3, this);
							if (class3 == class5)
							{
								break;
							}
							if (class5 == null)
							{
								class5 = class3;
							}
							Class149 class6 = new Class149();
							class6.class149_0 = null;
							class6.long_0 = class3.intPoint_0.Y;
							bool flag2;
							if (!(class3.double_0 < class3.class148_1.double_0))
							{
								class6.class148_0 = class3;
								class6.class148_1 = class3.class148_1;
								flag2 = true;
							}
							else
							{
								class6.class148_0 = class3.class148_1;
								class6.class148_1 = class3;
								flag2 = false;
							}
							class6.class148_0.enum11_0 = Enum11.const_0;
							class6.class148_1.enum11_0 = Enum11.const_1;
							if (Closed)
							{
								if (class6.class148_0.class148_0 != class6.class148_1)
								{
									class6.class148_0.int_0 = 1;
								}
								else
								{
									class6.class148_0.int_0 = -1;
								}
							}
							else
							{
								class6.class148_0.int_0 = 0;
							}
							class6.class148_1.int_0 = -class6.class148_0.int_0;
							class3 = Class156.smethod_243(this, class6.class148_0, flag2);
							if (class3.int_3 == -2)
							{
								class3 = Class156.smethod_243(this, class3, flag2);
							}
							Class148 class7 = Class156.smethod_243(this, class6.class148_1, !flag2);
							if (class7.int_3 == -2)
							{
								class7 = Class156.smethod_243(this, class7, !flag2);
							}
							if (class6.class148_0.int_3 != -2)
							{
								if (class6.class148_1.int_3 == -2)
								{
									class6.class148_1 = null;
								}
							}
							else
							{
								class6.class148_0 = null;
							}
							Class156.smethod_92(this, class6);
							if (!flag2)
							{
								class3 = class7;
							}
						}
						return true;
					}
					if (!Closed)
					{
						class3.class148_1.int_3 = -2;
						Class149 class8 = new Class149();
						class8.class149_0 = null;
						class8.long_0 = class3.intPoint_0.Y;
						class8.class148_0 = null;
						class8.class148_1 = class3;
						class8.class148_1.enum11_0 = Enum11.const_1;
						class8.class148_1.int_0 = 0;
						while (true)
						{
							if (class3.intPoint_0.X != class3.class148_1.intPoint_2.X)
							{
								Class156.smethod_284(this, class3);
							}
							if (class3.class148_0.int_3 == -2)
							{
								break;
							}
							class3.class148_2 = class3.class148_0;
							class3 = class3.class148_0;
						}
						Class156.smethod_92(this, class8);
						list_0.Add(list);
						return true;
					}
					return false;
				}
				return false;
			}
			return false;
		}
		throw new Exception0("AddPath: Open paths must be subject.");
	}

	public bool AddPaths(List<List<IntPoint>> ppg, PolyType polyType, bool closed)
	{
		bool result = false;
		for (int i = 0; i < ppg.Count; i++)
		{
			if (AddPath(ppg[i], polyType, closed))
			{
				result = true;
			}
		}
		return result;
	}

	internal virtual void vmethod_0()
	{
		class149_1 = class149_0;
		if (class149_1 == null)
		{
			return;
		}
		class150_0 = null;
		for (Class149 @class = class149_0; @class != null; @class = @class.class149_0)
		{
			Class156.smethod_232(this, @class.long_0);
			Class148 class2 = @class.class148_0;
			if (class2 != null)
			{
				class2.intPoint_1 = class2.intPoint_0;
				class2.int_3 = -1;
			}
			class2 = @class.class148_1;
			if (class2 != null)
			{
				class2.intPoint_1 = class2.intPoint_0;
				class2.int_3 = -1;
			}
		}
		class148_0 = null;
	}

	public static IntRect GetBounds(List<List<IntPoint>> paths)
	{
		int i = 0;
		int count;
		for (count = paths.Count; i < count && paths[i].Count == 0; i++)
		{
		}
		if (i != count)
		{
			IntRect result = default(IntRect);
			result.left = paths[i][0].X;
			result.right = result.left;
			result.top = paths[i][0].Y;
			result.bottom = result.top;
			for (; i < count; i++)
			{
				for (int j = 0; j < paths[i].Count; j++)
				{
					if (paths[i][j].X >= result.left)
					{
						if (paths[i][j].X > result.right)
						{
							result.right = paths[i][j].X;
						}
					}
					else
					{
						result.left = paths[i][j].X;
					}
					if (paths[i][j].Y >= result.top)
					{
						if (paths[i][j].Y > result.bottom)
						{
							result.bottom = paths[i][j].Y;
						}
					}
					else
					{
						result.top = paths[i][j].Y;
					}
				}
			}
			return result;
		}
		return new IntRect(0L, 0L, 0L, 0L);
	}
}
