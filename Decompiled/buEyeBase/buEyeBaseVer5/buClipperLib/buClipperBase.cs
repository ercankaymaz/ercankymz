using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ns62;
using ns64;
using ns65;
using ns66;
using ns68;
using ns70;
using ns71;

namespace buEyeBaseVer5.buClipperLib;

public class buClipperBase
{
	public const long loRange = 1073741823L;

	public const long hiRange = 4611686018427387903L;

	internal Class178 class178_0;

	internal Class178 class178_1;

	internal List<List<Class177>> list_0 = new List<List<Class177>>();

	internal Class179 class179_0;

	internal List<Class181> list_1;

	internal Class177 class177_0;

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
		class178_0 = null;
		class178_1 = null;
		bool_0 = false;
		bool_1 = false;
	}

	public virtual void Clear()
	{
		Class186.smethod_239(this);
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
				List<Class177> list = new List<Class177>(num + 1);
				for (int i = 0; i <= num; i++)
				{
					list.Add(new Class177());
				}
				bool flag = true;
				list[1].intPoint_1 = pg[1];
				IntPoint intPoint_ = pg[0];
				Class186.smethod_498(intPoint_, this, ref bool_0);
				intPoint_ = pg[num];
				Class186.smethod_498(intPoint_, this, ref bool_0);
				Class177 @class = list[0];
				Class177 class177_ = list[1];
				Class177 class177_2 = list[num];
				IntPoint intPoint_2 = pg[0];
				Class186.smethod_139(intPoint_2, @class, this, class177_2, class177_);
				@class = list[num];
				class177_ = list[0];
				class177_2 = list[num - 1];
				intPoint_2 = pg[num];
				Class186.smethod_139(intPoint_2, @class, this, class177_2, class177_);
				for (int num2 = num - 1; num2 >= 1; num2--)
				{
					intPoint_ = pg[num2];
					Class186.smethod_498(intPoint_, this, ref bool_0);
					@class = list[num2];
					class177_ = list[num2 + 1];
					class177_2 = list[num2 - 1];
					intPoint_2 = pg[num2];
					Class186.smethod_139(intPoint_2, @class, this, class177_2, class177_);
				}
				Class177 class2 = list[0];
				Class177 class3 = class2;
				Class177 class4 = class2;
				do
				{
					IL_021e:
					if (!(class3.intPoint_1 == class3.class177_0.intPoint_1) || (!Closed && class3.class177_0 == class2))
					{
						if (class3.class177_1 == class3.class177_0)
						{
							break;
						}
						if (Closed)
						{
							IntPoint intPoint_3 = class3.class177_1.intPoint_1;
							IntPoint intPoint_4 = class3.intPoint_1;
							IntPoint intPoint_5 = class3.class177_0.intPoint_1;
							if (Class186.smethod_495(bool_0, intPoint_4, intPoint_5, intPoint_3))
							{
								if (PreserveCollinear)
								{
									IntPoint intPoint_6 = class3.class177_1.intPoint_1;
									IntPoint intPoint_7 = class3.intPoint_1;
									IntPoint intPoint_8 = class3.class177_0.intPoint_1;
									if (Class186.smethod_607(intPoint_8, this, intPoint_6, intPoint_7))
									{
										goto IL_0207;
									}
								}
								if (class3 == class2)
								{
									class2 = class3.class177_0;
								}
								class3 = Class186.smethod_784(this, class3);
								class3 = class3.class177_1;
								class4 = class3;
								goto IL_021e;
							}
						}
						goto IL_0207;
					}
					if (class3 == class3.class177_0)
					{
						break;
					}
					if (class3 == class2)
					{
						class2 = class3.class177_0;
					}
					class3 = Class186.smethod_784(this, class3);
					class4 = class3;
					goto IL_021e;
					IL_0207:
					class3 = class3.class177_0;
				}
				while (class3 != class4 && (Closed || class3.class177_0 != class2));
				if ((Closed || class3 != class3.class177_0) && (!Closed || class3.class177_1 != class3.class177_0))
				{
					if (!Closed)
					{
						bool_1 = true;
						class2.class177_1.int_3 = -2;
					}
					class3 = class2;
					do
					{
						Class186.smethod_740(polyType, this, class3);
						class3 = class3.class177_0;
						if (flag && class3.intPoint_1.Y != class2.intPoint_1.Y)
						{
							flag = false;
						}
					}
					while (class3 != class2);
					if (!flag)
					{
						list_0.Add(list);
						Class177 class5 = null;
						if (class3.class177_1.intPoint_0 == class3.class177_1.intPoint_2)
						{
							class3 = class3.class177_0;
						}
						while (true)
						{
							class3 = Class186.smethod_598(class3, this);
							if (class3 == class5)
							{
								break;
							}
							if (class5 == null)
							{
								class5 = class3;
							}
							Class178 class6 = new Class178();
							class6.class178_0 = null;
							class6.long_0 = class3.intPoint_0.Y;
							bool flag2;
							if (!(class3.double_0 < class3.class177_1.double_0))
							{
								class6.class177_0 = class3;
								class6.class177_1 = class3.class177_1;
								flag2 = true;
							}
							else
							{
								class6.class177_0 = class3.class177_1;
								class6.class177_1 = class3;
								flag2 = false;
							}
							class6.class177_0.enum16_0 = Enum16.const_0;
							class6.class177_1.enum16_0 = Enum16.const_1;
							if (Closed)
							{
								if (class6.class177_0.class177_0 != class6.class177_1)
								{
									class6.class177_0.int_0 = 1;
								}
								else
								{
									class6.class177_0.int_0 = -1;
								}
							}
							else
							{
								class6.class177_0.int_0 = 0;
							}
							class6.class177_1.int_0 = -class6.class177_0.int_0;
							class3 = Class186.smethod_223(this, class6.class177_0, flag2);
							if (class3.int_3 == -2)
							{
								class3 = Class186.smethod_223(this, class3, flag2);
							}
							Class177 class7 = Class186.smethod_223(this, class6.class177_1, !flag2);
							if (class7.int_3 == -2)
							{
								class7 = Class186.smethod_223(this, class7, !flag2);
							}
							if (class6.class177_0.int_3 != -2)
							{
								if (class6.class177_1.int_3 == -2)
								{
									class6.class177_1 = null;
								}
							}
							else
							{
								class6.class177_0 = null;
							}
							Class186.smethod_452(this, class6);
							if (!flag2)
							{
								class3 = class7;
							}
						}
						return true;
					}
					if (!Closed)
					{
						class3.class177_1.int_3 = -2;
						Class178 class8 = new Class178();
						class8.class178_0 = null;
						class8.long_0 = class3.intPoint_0.Y;
						class8.class177_0 = null;
						class8.class177_1 = class3;
						class8.class177_1.enum16_0 = Enum16.const_1;
						class8.class177_1.int_0 = 0;
						while (true)
						{
							if (class3.intPoint_0.X != class3.class177_1.intPoint_2.X)
							{
								Class186.smethod_628(class3, this);
							}
							if (class3.class177_0.int_3 == -2)
							{
								break;
							}
							class3.class177_2 = class3.class177_0;
							class3 = class3.class177_0;
						}
						Class186.smethod_452(this, class8);
						list_0.Add(list);
						return true;
					}
					return false;
				}
				return false;
			}
			return false;
		}
		throw new Exception1("AddPath: Open paths must be subject.");
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
		class178_1 = class178_0;
		if (class178_1 == null)
		{
			return;
		}
		class179_0 = null;
		for (Class178 @class = class178_0; @class != null; @class = @class.class178_0)
		{
			Class186.smethod_190(this, @class.long_0);
			Class177 class2 = @class.class177_0;
			if (class2 != null)
			{
				class2.intPoint_1 = class2.intPoint_0;
				class2.int_3 = -1;
			}
			class2 = @class.class177_1;
			if (class2 != null)
			{
				class2.intPoint_1 = class2.intPoint_0;
				class2.int_3 = -1;
			}
		}
		class177_0 = null;
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
