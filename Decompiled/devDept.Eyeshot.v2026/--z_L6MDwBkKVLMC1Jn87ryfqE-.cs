using System;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Graphics;

internal static class _0023_003Dz_L6MDwBkKVLMC1Jn87ryfqE_003D
{
	internal static double _0023_003DzjekZpV_0024JTS_m(double _0023_003Dzz_xccxac3hNxWzJ6HQ_003D_003D)
	{
		return _0023_003Dzz_xccxac3hNxWzJ6HQ_003D_003D * 0.25;
	}

	internal static Point3D[] _0023_003Dze5xydd_0024by0spLc2Qeze91TQ_003D(Plane _0023_003Dzrgqz890sj_0024X9, Transformation _0023_003Dz9ZUzIX4xmsyA, double _0023_003Dzz_xccxac3hNxWzJ6HQ_003D_003D)
	{
		Point3D[] array = new Point3D[4];
		float[] array2 = _0023_003DzzCXLkSM73GwupUILb0KaXdM_003D(_0023_003Dzz_xccxac3hNxWzJ6HQ_003D_003D);
		int i = 0;
		int num = 0;
		for (; i < 4; i++)
		{
			array[i] = _0023_003Dzrgqz890sj_0024X9.PointAt(_0023_003Dz9ZUzIX4xmsyA * new Point2D(array2[num++], array2[num++]));
		}
		return new Point3D[6]
		{
			array[0],
			array[1],
			array[2],
			(Point3D)array[0].Clone(),
			(Point3D)array[2].Clone(),
			array[3]
		};
	}

	internal static Point3D[] _0023_003DzAsickqGJmWyb(Plane _0023_003Dzrgqz890sj_0024X9, Transformation _0023_003Dz9ZUzIX4xmsyA, double _0023_003Dzz_xccxac3hNxWzJ6HQ_003D_003D)
	{
		Point3D[] array = new Point3D[4];
		float[] array2 = _0023_003DzzCXLkSM73GwupUILb0KaXdM_003D(_0023_003Dzz_xccxac3hNxWzJ6HQ_003D_003D);
		int i = 0;
		int num = 0;
		for (; i < 4; i++)
		{
			array[i] = _0023_003Dzrgqz890sj_0024X9.PointAt(_0023_003Dz9ZUzIX4xmsyA * new Point2D(array2[num++], array2[num++]));
		}
		return _0023_003DzHgbLDveinl6lQe7bAl4r3Ac_003D(array, _0023_003DzOWPHNio_003D: true);
	}

	internal static Point3D[] _0023_003Dz3G4PHFDwqBm63GjtmQ_003D_003D(Plane _0023_003Dzrgqz890sj_0024X9, Transformation _0023_003Dz9ZUzIX4xmsyA, double _0023_003Dzz_xccxac3hNxWzJ6HQ_003D_003D)
	{
		Point3D[] array = new Point3D[2];
		float[] array2 = _0023_003DzdOiIMde42WZspPfFdJkjWOh1QOSS(_0023_003Dzz_xccxac3hNxWzJ6HQ_003D_003D);
		int num = 0;
		int num2 = 0;
		while (num2 < array2.Length)
		{
			array[num++] = _0023_003Dzrgqz890sj_0024X9.PointAt(_0023_003Dz9ZUzIX4xmsyA * new Point2D(array2[num2++], array2[num2++]));
		}
		return array;
	}

	internal static Point3D[] _0023_003DzHgbLDveinl6lQe7bAl4r3Ac_003D(Point3D[] _0023_003DzrdSL0CI_003D, bool _0023_003DzOWPHNio_003D)
	{
		if (_0023_003DzrdSL0CI_003D.Length == 0)
		{
			return Array.Empty<Point3D>();
		}
		int num = _0023_003DzrdSL0CI_003D.Length * 2;
		if (!_0023_003DzOWPHNio_003D)
		{
			num -= 2;
		}
		Point3D[] array = new Point3D[num];
		int num2 = 0;
		for (int i = 0; i < _0023_003DzrdSL0CI_003D.Length - 1; i++)
		{
			array[num2++] = (Point3D)_0023_003DzrdSL0CI_003D[i].Clone();
			array[num2++] = (Point3D)_0023_003DzrdSL0CI_003D[i + 1].Clone();
		}
		if (_0023_003DzOWPHNio_003D)
		{
			array[num2++] = (Point3D)_0023_003DzrdSL0CI_003D[^1].Clone();
			array[num2++] = (Point3D)_0023_003DzrdSL0CI_003D[0].Clone();
		}
		return array;
	}

	internal static float[] _0023_003DzzCXLkSM73GwupUILb0KaXdM_003D(double _0023_003Dzz_xccxac3hNxWzJ6HQ_003D_003D)
	{
		float num = (float)_0023_003Dzz_xccxac3hNxWzJ6HQ_003D_003D / 2f;
		float num2 = (float)_0023_003Dzz_xccxac3hNxWzJ6HQ_003D_003D / 10f;
		return new float[8]
		{
			0f - num,
			0f - num2,
			num,
			0f - num2,
			num,
			num2,
			0f - num,
			num2
		};
	}

	internal static float[] _0023_003DzdOiIMde42WZspPfFdJkjWOh1QOSS(double _0023_003Dzz_xccxac3hNxWzJ6HQ_003D_003D)
	{
		float num = (float)(_0023_003Dzz_xccxac3hNxWzJ6HQ_003D_003D / 2.0);
		return new float[4]
		{
			0f - num,
			0f,
			num,
			0f
		};
	}

	internal static float[] _0023_003DzCyfKKqrtgq_0024qkD6wFwefLV4C7K4tH5iJYg_003D_003D(double _0023_003Dzz_xccxac3hNxWzJ6HQ_003D_003D)
	{
		return new float[6]
		{
			0f,
			0f,
			(float)_0023_003Dzz_xccxac3hNxWzJ6HQ_003D_003D,
			(float)(0.0 - _0023_003DzjekZpV_0024JTS_m(_0023_003Dzz_xccxac3hNxWzJ6HQ_003D_003D)),
			(float)_0023_003Dzz_xccxac3hNxWzJ6HQ_003D_003D,
			(float)_0023_003DzjekZpV_0024JTS_m(_0023_003Dzz_xccxac3hNxWzJ6HQ_003D_003D)
		};
	}

	internal static float[] _0023_003DzBooIHT7HNexxsTsZjU1vFCDtAG36KekHLg_003D_003D(double _0023_003Dzz_xccxac3hNxWzJ6HQ_003D_003D)
	{
		return new float[6]
		{
			0f,
			0f,
			(float)(0.0 - _0023_003Dzz_xccxac3hNxWzJ6HQ_003D_003D),
			(float)_0023_003DzjekZpV_0024JTS_m(_0023_003Dzz_xccxac3hNxWzJ6HQ_003D_003D),
			(float)(0.0 - _0023_003Dzz_xccxac3hNxWzJ6HQ_003D_003D),
			(float)(0.0 - _0023_003DzjekZpV_0024JTS_m(_0023_003Dzz_xccxac3hNxWzJ6HQ_003D_003D))
		};
	}

	internal static Point3D[] _0023_003DzEnQoWeHJm1_0024iaNzbcZJa97bjT6aF_eoxbQ_003D_003D(Plane _0023_003Dzrgqz890sj_0024X9, Transformation _0023_003Dz9ZUzIX4xmsyA, double _0023_003Dzz_xccxac3hNxWzJ6HQ_003D_003D)
	{
		float[] array = _0023_003DzCyfKKqrtgq_0024qkD6wFwefLV4C7K4tH5iJYg_003D_003D(_0023_003Dzz_xccxac3hNxWzJ6HQ_003D_003D);
		Point3D[] array2 = new Point3D[3];
		int i = 0;
		int num = 0;
		for (; i < 3; i++)
		{
			array2[i] = _0023_003Dzrgqz890sj_0024X9.PointAt(_0023_003Dz9ZUzIX4xmsyA * new Point2D(array[num++], array[num++]));
		}
		return array2;
	}

	internal static Point3D[] _0023_003DzlvD2fJo5d_yaFUbSOV7UWt4_003D(Plane _0023_003Dzrgqz890sj_0024X9, Transformation _0023_003Dz9ZUzIX4xmsyA, double _0023_003Dzz_xccxac3hNxWzJ6HQ_003D_003D)
	{
		float[] array = _0023_003DzCyfKKqrtgq_0024qkD6wFwefLV4C7K4tH5iJYg_003D_003D(_0023_003Dzz_xccxac3hNxWzJ6HQ_003D_003D);
		Point3D[] array2 = new Point3D[3];
		int i = 0;
		int num = 0;
		for (; i < 3; i++)
		{
			array2[i] = _0023_003Dzrgqz890sj_0024X9.PointAt(_0023_003Dz9ZUzIX4xmsyA * new Point2D(array[num++], array[num++]));
		}
		return _0023_003DzHgbLDveinl6lQe7bAl4r3Ac_003D(array2, _0023_003DzOWPHNio_003D: true);
	}

	internal static Point3D[] _0023_003Dzd7LiuW2xMrAeCjaaV_M04AQ_003D(Plane _0023_003Dzrgqz890sj_0024X9, Transformation _0023_003Dz9ZUzIX4xmsyA, double _0023_003Dzz_xccxac3hNxWzJ6HQ_003D_003D)
	{
		float[] array = _0023_003DzBooIHT7HNexxsTsZjU1vFCDtAG36KekHLg_003D_003D(_0023_003Dzz_xccxac3hNxWzJ6HQ_003D_003D);
		Point3D[] array2 = new Point3D[3];
		int i = 0;
		int num = 0;
		for (; i < 3; i++)
		{
			array2[i] = _0023_003Dzrgqz890sj_0024X9.PointAt(_0023_003Dz9ZUzIX4xmsyA * new Point2D(array[num++], array[num++]));
		}
		return _0023_003DzHgbLDveinl6lQe7bAl4r3Ac_003D(array2, _0023_003DzOWPHNio_003D: true);
	}

	internal static Point3D[] _0023_003Dzpu_0024SiOrrh6FwVfT56qseBNE9LpJM_DUquw_003D_003D(Plane _0023_003Dzrgqz890sj_0024X9, Transformation _0023_003Dz9ZUzIX4xmsyA, double _0023_003Dzz_xccxac3hNxWzJ6HQ_003D_003D)
	{
		float[] array = _0023_003DzBooIHT7HNexxsTsZjU1vFCDtAG36KekHLg_003D_003D(_0023_003Dzz_xccxac3hNxWzJ6HQ_003D_003D);
		Point3D[] array2 = new Point3D[3];
		int i = 0;
		int num = 0;
		for (; i < 3; i++)
		{
			array2[i] = _0023_003Dzrgqz890sj_0024X9.PointAt(_0023_003Dz9ZUzIX4xmsyA * new Point2D(array[num++], array[num++]));
		}
		return array2;
	}

	internal static Point3D[] _0023_003DzlsyUCWF65sos0mUqYJ69FdM_003D(Plane _0023_003Dzrgqz890sj_0024X9, Transformation _0023_003Dz9ZUzIX4xmsyA, double _0023_003Dzz_xccxac3hNxWzJ6HQ_003D_003D)
	{
		float[] array = _0023_003DzL53m6xG6wGal3GveHSAv178_003D(_0023_003Dzz_xccxac3hNxWzJ6HQ_003D_003D);
		int num = 10;
		Point3D[] array2 = new Point3D[num];
		int i = 0;
		int num2 = 0;
		for (; i < num; i++)
		{
			array2[i] = _0023_003Dzrgqz890sj_0024X9.PointAt(_0023_003Dz9ZUzIX4xmsyA * new Point2D(array[num2++], array[num2++]));
		}
		int num3 = num - 2;
		Point3D[] array3 = new Point3D[3 * num3];
		int num4 = 0;
		int num5 = 1;
		for (int j = 0; j < num3; j++)
		{
			array3[num4++] = (Point3D)array2[0].Clone();
			array3[num4++] = (Point3D)array2[num5++].Clone();
			array3[num4++] = (Point3D)array2[num5].Clone();
		}
		return array3;
	}

	internal static Point3D[] _0023_003DzEDm2bXouvM6M(Plane _0023_003Dzrgqz890sj_0024X9, Transformation _0023_003Dz9ZUzIX4xmsyA, double _0023_003Dzz_xccxac3hNxWzJ6HQ_003D_003D)
	{
		float[] array = _0023_003DzL53m6xG6wGal3GveHSAv178_003D(_0023_003Dzz_xccxac3hNxWzJ6HQ_003D_003D);
		Point3D[] array2 = new Point3D[10];
		int i = 0;
		int num = 0;
		for (; i < 10; i++)
		{
			array2[i] = _0023_003Dzrgqz890sj_0024X9.PointAt(_0023_003Dz9ZUzIX4xmsyA * new Point2D(array[num++], array[num++]));
		}
		return _0023_003DzHgbLDveinl6lQe7bAl4r3Ac_003D(array2, _0023_003DzOWPHNio_003D: true);
	}

	internal static float[] _0023_003DzL53m6xG6wGal3GveHSAv178_003D(double _0023_003Dzz_xccxac3hNxWzJ6HQ_003D_003D)
	{
		float num = (float)_0023_003Dzz_xccxac3hNxWzJ6HQ_003D_003D / 4f;
		float num2 = (float)((double)num / 1.4142135623730951);
		return new float[20]
		{
			0f,
			0f,
			num,
			0f,
			num2,
			num2,
			0f,
			num,
			0f - num2,
			num2,
			0f - num,
			0f,
			0f - num2,
			0f - num2,
			0f,
			0f - num,
			num2,
			0f - num2,
			num,
			0f
		};
	}

	internal static void _0023_003DzZl3uTZY2SDdp(RenderContextBase _0023_003DzB8iS0QA_003D, EntityGraphicsData _0023_003Dzgv_pSOc_003D, double _0023_003Dzz_xccxac3hNxWzJ6HQ_003D_003D, bool _0023_003Dz4BUHA1c_003D)
	{
		if (_0023_003Dz4BUHA1c_003D)
		{
			float[] vertices = _0023_003DzzCXLkSM73GwupUILb0KaXdM_003D(_0023_003Dzz_xccxac3hNxWzJ6HQ_003D_003D);
			_0023_003DzB8iS0QA_003D.DrawQuads2D(vertices);
		}
		else
		{
			_0023_003Dzgv_pSOc_003D.DrawBuffer(_0023_003DzB8iS0QA_003D, nextPart: true);
		}
	}

	internal static void _0023_003DzpFyrpKXLMt3yujRxSw_003D_003D(RenderContextBase _0023_003DzB8iS0QA_003D, EntityGraphicsData _0023_003Dzgv_pSOc_003D, double _0023_003Dzz_xccxac3hNxWzJ6HQ_003D_003D, bool _0023_003Dz4BUHA1c_003D)
	{
		if (_0023_003Dz4BUHA1c_003D)
		{
			float[] vertices = _0023_003DzdOiIMde42WZspPfFdJkjWOh1QOSS(_0023_003Dzz_xccxac3hNxWzJ6HQ_003D_003D);
			_0023_003DzB8iS0QA_003D.DrawLines2D(vertices);
		}
		else
		{
			_0023_003Dzgv_pSOc_003D.DrawBuffer(_0023_003DzB8iS0QA_003D, nextPart: true);
		}
	}

	internal static void _0023_003DzySK4JX4gwaSvQLZwafPBUrg_003D(RenderContextBase _0023_003DzB8iS0QA_003D, EntityGraphicsData _0023_003Dzgv_pSOc_003D, double _0023_003Dzz_xccxac3hNxWzJ6HQ_003D_003D, bool _0023_003Dz4BUHA1c_003D)
	{
		if (_0023_003Dz4BUHA1c_003D)
		{
			float[] vertices = _0023_003DzCyfKKqrtgq_0024qkD6wFwefLV4C7K4tH5iJYg_003D_003D(_0023_003Dzz_xccxac3hNxWzJ6HQ_003D_003D);
			_0023_003DzB8iS0QA_003D.DrawTriangles2D(vertices);
		}
		else
		{
			_0023_003Dzgv_pSOc_003D.DrawBuffer(_0023_003DzB8iS0QA_003D, nextPart: true);
		}
	}

	internal static void _0023_003DzVzztx8bmo4zSS6PPA7so8sc_003D(RenderContextBase _0023_003DzB8iS0QA_003D, EntityGraphicsData _0023_003Dzgv_pSOc_003D, double _0023_003Dzz_xccxac3hNxWzJ6HQ_003D_003D, bool _0023_003Dz4BUHA1c_003D)
	{
		if (_0023_003Dz4BUHA1c_003D)
		{
			float[] vertices = _0023_003DzBooIHT7HNexxsTsZjU1vFCDtAG36KekHLg_003D_003D(_0023_003Dzz_xccxac3hNxWzJ6HQ_003D_003D);
			_0023_003DzB8iS0QA_003D.DrawTriangles2D(vertices);
		}
		else
		{
			_0023_003Dzgv_pSOc_003D.DrawBuffer(_0023_003DzB8iS0QA_003D, nextPart: true);
		}
	}

	internal static void _0023_003DzT2MIyACvYuZK(RenderContextBase _0023_003DzB8iS0QA_003D, EntityGraphicsData _0023_003Dzgv_pSOc_003D, double _0023_003Dzz_xccxac3hNxWzJ6HQ_003D_003D, bool _0023_003Dz4BUHA1c_003D)
	{
		if (_0023_003Dz4BUHA1c_003D)
		{
			float[] points2D = _0023_003DzL53m6xG6wGal3GveHSAv178_003D(_0023_003Dzz_xccxac3hNxWzJ6HQ_003D_003D);
			_0023_003DzB8iS0QA_003D.DrawTrianglesFan2D(points2D);
		}
		else
		{
			_0023_003Dzgv_pSOc_003D.DrawBuffer(_0023_003DzB8iS0QA_003D, nextPart: true);
		}
	}

	internal static Point3D[] _0023_003DzQvPWxyC95069Svh7qQVH_ZY_003D(arrowheadType _0023_003DzK2gIDbLaRHfX, Plane _0023_003Dzrgqz890sj_0024X9, Transformation _0023_003Dz9ZUzIX4xmsyA, double _0023_003Dzz_xccxac3hNxWzJ6HQ_003D_003D, bool _0023_003DzayrtLKVwA_00247J0a4P9w_003D_003D, bool _0023_003DzEXLcE10_003D)
	{
		Point3D[] result = null;
		switch (_0023_003DzK2gIDbLaRHfX)
		{
		case arrowheadType.Arrow:
			result = ((_0023_003DzEXLcE10_003D ? (!_0023_003DzayrtLKVwA_00247J0a4P9w_003D_003D) : _0023_003DzayrtLKVwA_00247J0a4P9w_003D_003D) ? _0023_003Dzpu_0024SiOrrh6FwVfT56qseBNE9LpJM_DUquw_003D_003D(_0023_003Dzrgqz890sj_0024X9, _0023_003Dz9ZUzIX4xmsyA, _0023_003Dzz_xccxac3hNxWzJ6HQ_003D_003D) : _0023_003DzEnQoWeHJm1_0024iaNzbcZJa97bjT6aF_eoxbQ_003D_003D(_0023_003Dzrgqz890sj_0024X9, _0023_003Dz9ZUzIX4xmsyA, _0023_003Dzz_xccxac3hNxWzJ6HQ_003D_003D));
			break;
		case arrowheadType.Tick:
		{
			Transformation _0023_003Dz9ZUzIX4xmsyA2 = _0023_003Dz9ZUzIX4xmsyA * new Rotation(Math.PI / 4.0, new Vector3D(0.0, 0.0, 1.0));
			result = _0023_003Dze5xydd_0024by0spLc2Qeze91TQ_003D(_0023_003Dzrgqz890sj_0024X9, _0023_003Dz9ZUzIX4xmsyA2, _0023_003Dzz_xccxac3hNxWzJ6HQ_003D_003D);
			break;
		}
		case arrowheadType.Dot:
			result = _0023_003DzlsyUCWF65sos0mUqYJ69FdM_003D(_0023_003Dzrgqz890sj_0024X9, _0023_003Dz9ZUzIX4xmsyA, _0023_003Dzz_xccxac3hNxWzJ6HQ_003D_003D);
			break;
		case arrowheadType.Oblique:
			result = new Point3D[0];
			break;
		}
		return result;
	}

	internal static Point3D[] _0023_003Dz7tEgWrFHxteq(arrowheadType _0023_003DzK2gIDbLaRHfX, Plane _0023_003Dzrgqz890sj_0024X9, Transformation _0023_003Dz9ZUzIX4xmsyA, double _0023_003Dzz_xccxac3hNxWzJ6HQ_003D_003D, bool _0023_003DzayrtLKVwA_00247J0a4P9w_003D_003D, bool _0023_003DzEXLcE10_003D)
	{
		Point3D[] result = null;
		switch (_0023_003DzK2gIDbLaRHfX)
		{
		case arrowheadType.Arrow:
			result = ((_0023_003DzEXLcE10_003D ? (!_0023_003DzayrtLKVwA_00247J0a4P9w_003D_003D) : _0023_003DzayrtLKVwA_00247J0a4P9w_003D_003D) ? _0023_003Dzd7LiuW2xMrAeCjaaV_M04AQ_003D(_0023_003Dzrgqz890sj_0024X9, _0023_003Dz9ZUzIX4xmsyA, _0023_003Dzz_xccxac3hNxWzJ6HQ_003D_003D) : _0023_003DzlvD2fJo5d_yaFUbSOV7UWt4_003D(_0023_003Dzrgqz890sj_0024X9, _0023_003Dz9ZUzIX4xmsyA, _0023_003Dzz_xccxac3hNxWzJ6HQ_003D_003D));
			break;
		case arrowheadType.Tick:
		{
			Transformation _0023_003Dz9ZUzIX4xmsyA2 = _0023_003Dz9ZUzIX4xmsyA * new Rotation(Math.PI / 4.0, new Vector3D(0.0, 0.0, 1.0));
			result = _0023_003DzAsickqGJmWyb(_0023_003Dzrgqz890sj_0024X9, _0023_003Dz9ZUzIX4xmsyA2, _0023_003Dzz_xccxac3hNxWzJ6HQ_003D_003D);
			break;
		}
		case arrowheadType.Dot:
			result = _0023_003DzEDm2bXouvM6M(_0023_003Dzrgqz890sj_0024X9, _0023_003Dz9ZUzIX4xmsyA, _0023_003Dzz_xccxac3hNxWzJ6HQ_003D_003D);
			break;
		case arrowheadType.Oblique:
		{
			Transformation _0023_003Dz9ZUzIX4xmsyA2 = _0023_003Dz9ZUzIX4xmsyA * new Rotation(Math.PI / 4.0, new Vector3D(0.0, 0.0, 1.0));
			result = _0023_003Dz3G4PHFDwqBm63GjtmQ_003D_003D(_0023_003Dzrgqz890sj_0024X9, _0023_003Dz9ZUzIX4xmsyA2, _0023_003Dzz_xccxac3hNxWzJ6HQ_003D_003D);
			break;
		}
		}
		return result;
	}
}
