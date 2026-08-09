using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using System.Security;
using System.Threading;

internal sealed class _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D
{
	private delegate object _0023_003Dz2X8kE24_003D(object _0023_003Dz9jrlnWk_003D, object[] _0023_003DzBxpHhQ0_003D);

	private struct _0023_003Dz3iPku7s_003D
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly uint _0023_003Dz9jrlnWk_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly object _0023_003DzBxpHhQ0_003D;

		public _0023_003Dz3iPku7s_003D(uint _0023_003Dz9jrlnWk_003D)
		{
			this._0023_003Dz9jrlnWk_003D = _0023_003Dz9jrlnWk_003D;
			_0023_003DzBxpHhQ0_003D = null;
		}

		public _0023_003Dz3iPku7s_003D(uint _0023_003Dz9jrlnWk_003D, object _0023_003DzBxpHhQ0_003D)
		{
			this._0023_003Dz9jrlnWk_003D = _0023_003Dz9jrlnWk_003D;
			this._0023_003DzBxpHhQ0_003D = _0023_003DzBxpHhQ0_003D;
		}

		[_0023_003Dq92i4vUz2r2p0Q1QJdKoErhpd8NU94BS3_00244OxTf7tY8c_003D]
		public uint _0023_003DzO3smQpSarT6vqtUaiMUzV3QK46jU()
		{
			return _0023_003Dz9jrlnWk_003D;
		}

		[_0023_003Dq92i4vUz2r2p0Q1QJdKoErhpd8NU94BS3_00244OxTf7tY8c_003D]
		public object _0023_003DzhfIVm8CotdQwMSGVPJEfHgQ_003D()
		{
			return _0023_003DzBxpHhQ0_003D;
		}
	}

	private delegate void _0023_003Dz9I8ZVlc_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D);

	private static class _0023_003Dz9jrlnWk_003D
	{
		public static _0023_003Dz9I8ZVlc_003D _0023_003Dz9jrlnWk_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzBxpHhQ0_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dztgqm2r4_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzzKDx05I_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dz3iPku7s_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dz2X8kE24_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzJGsRSpg_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dz9I8ZVlc_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzgqvoyJk_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzoEGLyuM_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DziiEv3wQ_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzJ6W8874_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzAndD6oU_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzbSmUaeo_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzaTyQZ6E_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzLi0XoCY_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dz7SVqS2w_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dz_0024bI1JP4_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzGX9QPgk_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzwETOsNI_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzXlMgCsc_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzNl32EAo_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzS5oUG4s_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzCR5Jlyc_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dzn6_Dl38_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzozZCuko_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzbzHeu9w_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzG7m2nd8_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzZpkUTwY_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzWn08U5s_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzMP6kxrk_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzCbpaZow_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzgtUi_7A_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dznx1EMIs_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzFQGDh5A_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DziDh2WHE_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzbLHaDy4_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzP5I_H4I_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzWAsKAZU_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dz5bot44w_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dz6r_b9y4_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzAMMIogc_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzCfC8u_w_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzUOnmQQI_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dz8d5a5Pw_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzGCxjA14_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dz3EgOdOA_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzzuPwqHE_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dzn0mbPio_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzekdNBIU_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzgHIniWs_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzKd0gS4M_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzySRztio_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dz7JCUyRo_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzJyZTmFA_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzZis2nuo_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzOGQZuJA_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzWf7vNYA_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dz79SDY5s_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzULP5vvo_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dzh_kH0OM_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzVAE0pLs_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzXI96hVA_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DznXxxWqg_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dz4LTXyQY_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dz9SQX_O0_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dz00_ZuTY_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dz6eb9B7U_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzmcpthPQ_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzdVZznKI_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dz_0024xYjLtI_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dz_00245yMOf8_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzcnCZW_A_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzAC_0024sduM_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzYEdYVJk_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzWVJjS28_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dz_6ql3Zg_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dzw5_0024MnmA_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dz3s7AUQI_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzOXh2F_c_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dz2X4AXXw_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzKfSONp4_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzUnvXOEk_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dz5V0c9Io_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dzew32rcU_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzgP82UKg_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzIyFZK0E_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dz6PXmkFc_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dz6HVbGgQ_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzeC6iDUE_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzBIlbWgo_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzbTA_0024lYA_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzgSRgyM8_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzN182m5s_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dz98rOKeA_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dz3Uy9H9w_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzYiFDtIE_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzTw3hCm0_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzU6OvM7k_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dz7iNWvSI_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzitN7ZMs_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzcWlt650_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzZnEqe_00248_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dzxk54U4E_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dze23HFx0_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzddrJTVY_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzZ0j8RBQ_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DztEspv5A_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzQyb3wNc_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzWYSSXsk_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DznNCwbu0_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dz_0024gpZG2I_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzSInO_Kw_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzSU8qYOs_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzPDi09LA_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzEG8ah0k_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzWgTBVuo_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzLONmzSE_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dz3cD6RTQ_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dz9TI2kxQ_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzQeKo0NQ_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dz_bAFZgU_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dz_i7s2Dg_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzcVj86iA_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dzz4gyhOM_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dzvc8AGuY_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DznempUdI_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzccgAw4c_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzfwP_0024G00_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzxaPwEN8_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzH7C3gDY_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dzrh2iypQ_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dz6KY0DVQ_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzDGrR9sk_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzgUoyz9s_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dz2iacZ4s_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dz8qFa8JA_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dzid06sM8_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dz2kWmC38_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzHFkmtmM_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dzzrhyls4_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzYVcRoxQ_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzulyKO20_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dzj5auj_I_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzdTrI_0024cs_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzPQJWYOY_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzvKTz1h0_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzVh0er_0024U_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dzc3hmZCQ_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DziH5pnyI_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzHajJwNQ_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzGlgligM_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DztooAniI_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dzmfy7RSo_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dzq19rHAM_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzXIOLRSc_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzTsEU9SA_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzGC1SpJk_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzHdk5DH8_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dz1UJtn6g_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dzc0J1wGk_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dz2jIONZw_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzhSDfgZA_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dz3A_0024Cnfc_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzrHojHlY_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dz9_0024L7s_0024c_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzBv_BB20_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzeJXB7Nw_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzLv_x3i4_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzvB28HNQ_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dz8ixroro_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzjRNWNA0_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dzzlx_RJk_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dzs6fypu0_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzHMc84tQ_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzOG1KvlA_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dzxskgzi0_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzYL9339E_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzlGXy5gk_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzGpPUbQU_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DztbEZjdA_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzaoButTk_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dz_NYtIHc_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzPeqcg9Q_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DziPKktwk_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzGti5nqY_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzCqRcR70_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzunTcbyE_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzgzDbsGk_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzlyRtwFg_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzQlfvBdI_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzncyNPks_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzUytyK4Q_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzVfsoQp4_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzAW64gfU_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DztuAevKc_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003Dzug_0024QZlY_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzBgzwwiA_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzrbcT9Ls_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzI2JskBU_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzXkfaJAo_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzfrLf2Nc_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzionodBQ_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzIYGCIB8_003D;

		public static _0023_003Dz9I8ZVlc_003D _0023_003DzgdJ1wBQ_003D;
	}

	private sealed class _0023_003DzAndD6oU_003D
	{
	}

	[Serializable]
	private sealed class _0023_003DzBxpHhQ0_003D
	{
		public static readonly _0023_003DzBxpHhQ0_003D _0023_003Dz9jrlnWk_003D = new _0023_003DzBxpHhQ0_003D();

		public static Comparison<_0023_003Dqih1RKs7Osg5_0024Rd9gDhKEdqdrC8qgJFChg_7i1V8hZwk_003D> _0023_003DzBxpHhQ0_003D;

		internal int _0023_003Dzhv6lastPXRqr4_0024sRri0_gaVS_it2sDCA5qJ6I3cY2YIK(_0023_003Dqih1RKs7Osg5_0024Rd9gDhKEdqdrC8qgJFChg_7i1V8hZwk_003D _0023_003Dz9jrlnWk_003D, _0023_003Dqih1RKs7Osg5_0024Rd9gDhKEdqdrC8qgJFChg_7i1V8hZwk_003D _0023_003DzBxpHhQ0_003D)
		{
			if (_0023_003Dz9jrlnWk_003D._0023_003DzcmYAH1_0024kgTZIsm37rJAwkR2aPGOw() == _0023_003DzBxpHhQ0_003D._0023_003DzcmYAH1_0024kgTZIsm37rJAwkR2aPGOw())
			{
				return _0023_003DzBxpHhQ0_003D._0023_003DzbCVHSLHjVVzIDZuBMIVB_Phq0P8i_wdHnQ_003D_003D().CompareTo(_0023_003Dz9jrlnWk_003D._0023_003DzbCVHSLHjVVzIDZuBMIVB_Phq0P8i_wdHnQ_003D_003D());
			}
			return _0023_003Dz9jrlnWk_003D._0023_003DzcmYAH1_0024kgTZIsm37rJAwkR2aPGOw().CompareTo(_0023_003DzBxpHhQ0_003D._0023_003DzcmYAH1_0024kgTZIsm37rJAwkR2aPGOw());
		}
	}

	private struct _0023_003DzJ6W8874_003D(MethodBase _0023_003Dz9jrlnWk_003D, bool _0023_003DzBxpHhQ0_003D) : IEquatable<_0023_003DzJ6W8874_003D>
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly MethodBase _0023_003Dz9jrlnWk_003D = _0023_003Dz9jrlnWk_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly bool _0023_003DzBxpHhQ0_003D = _0023_003DzBxpHhQ0_003D;

		[_0023_003Dq92i4vUz2r2p0Q1QJdKoErhpd8NU94BS3_00244OxTf7tY8c_003D]
		public MethodBase _0023_003Dz8r3pP05sQtMBnZwnEKVmjskXZMs_C_s88hrkb1A_003D()
		{
			return _0023_003Dz9jrlnWk_003D;
		}

		[_0023_003Dq92i4vUz2r2p0Q1QJdKoErhpd8NU94BS3_00244OxTf7tY8c_003D]
		public bool _0023_003DzsubU6xBHatCokP4_0024EtWs5qiZU3JrGKJwiJGkVSQ_003D()
		{
			return _0023_003DzBxpHhQ0_003D;
		}

		public override int GetHashCode()
		{
			return _0023_003Dz8r3pP05sQtMBnZwnEKVmjskXZMs_C_s88hrkb1A_003D().GetHashCode() ^ _0023_003DzsubU6xBHatCokP4_0024EtWs5qiZU3JrGKJwiJGkVSQ_003D().GetHashCode();
		}

		public override bool Equals(object _0023_003Dz9jrlnWk_003D)
		{
			if (_0023_003Dz9jrlnWk_003D is _0023_003DzJ6W8874_003D _0023_003DzJ6W8874_003D2)
			{
				return Equals(_0023_003DzJ6W8874_003D2);
			}
			return false;
		}

		public bool Equals(_0023_003DzJ6W8874_003D _0023_003Dz9jrlnWk_003D)
		{
			if (_0023_003Dz8r3pP05sQtMBnZwnEKVmjskXZMs_C_s88hrkb1A_003D() == _0023_003Dz9jrlnWk_003D._0023_003Dz8r3pP05sQtMBnZwnEKVmjskXZMs_C_s88hrkb1A_003D())
			{
				return _0023_003DzsubU6xBHatCokP4_0024EtWs5qiZU3JrGKJwiJGkVSQ_003D() == _0023_003Dz9jrlnWk_003D._0023_003DzsubU6xBHatCokP4_0024EtWs5qiZU3JrGKJwiJGkVSQ_003D();
			}
			return false;
		}
	}

	private sealed class _0023_003DzJGsRSpg_003D
	{
		private string _0023_003Dz9jrlnWk_003D;

		private Type _0023_003DzBxpHhQ0_003D;

		public string _0023_003DzdzBlTI78TmztD7QudxWT5NdBrEf_ccsxH0PeD_0024w_003D()
		{
			return _0023_003Dz9jrlnWk_003D;
		}

		public void _0023_003DzXxIMx7zTecHLd_9YM_0024EHJGyalAM8Hp24KQ_003D_003D(string _0023_003Dz9jrlnWk_003D)
		{
			this._0023_003Dz9jrlnWk_003D = _0023_003Dz9jrlnWk_003D;
		}

		public Type _0023_003DzYB4ZGnaDAPGwHnql1SFikhrHfpua7c4NvQ_003D_003D()
		{
			return _0023_003DzBxpHhQ0_003D;
		}

		public void _0023_003Dz1lATtvoBQFhUGwFE3Zp0VjG3phCR5eeagw_003D_003D(Type _0023_003Dz9jrlnWk_003D)
		{
			_0023_003DzBxpHhQ0_003D = _0023_003Dz9jrlnWk_003D;
		}
	}

	private sealed class _0023_003DzaTyQZ6E_003D<_0023_003Dz9jrlnWk_003D> : IComparer<KeyValuePair<int, _0023_003Dz9jrlnWk_003D>>
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly Comparison<_0023_003Dz9jrlnWk_003D> _0023_003Dz9jrlnWk_003D;

		public _0023_003DzaTyQZ6E_003D(Comparison<_0023_003Dz9jrlnWk_003D> _0023_003Dz9jrlnWk_003D)
		{
			this._0023_003Dz9jrlnWk_003D = _0023_003Dz9jrlnWk_003D;
		}

		public int Compare(KeyValuePair<int, _0023_003Dz9jrlnWk_003D> _0023_003Dz9jrlnWk_003D, KeyValuePair<int, _0023_003Dz9jrlnWk_003D> _0023_003DzBxpHhQ0_003D)
		{
			int num = this._0023_003Dz9jrlnWk_003D(_0023_003Dz9jrlnWk_003D.Value, _0023_003DzBxpHhQ0_003D.Value);
			if (num == 0)
			{
				return _0023_003DzBxpHhQ0_003D.Key.CompareTo(_0023_003Dz9jrlnWk_003D.Key);
			}
			return num;
		}
	}

	private sealed class _0023_003DzbSmUaeo_003D : IDisposable
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public _0023_003Dq9cxJfzt6tx3_00245xLDM_0024HAnrEHrErdbG4Q2r8aUaxhhjk_003D _0023_003Dz9jrlnWk_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public _0023_003DqSrxlws3SuprWxrjyHO1juxJFrTNvlF8gj_KAkF067yA_003D _0023_003DzBxpHhQ0_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public _0023_003Dq6tS8rMV1rGswJPasZDHd76XTcVlfwQMkS5tB1TusLXU_003D _0023_003Dztgqm2r4_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public long _0023_003DzzKDx05I_003D;

		public void Dispose()
		{
			IDisposable disposable = _0023_003DzBxpHhQ0_003D;
			if (disposable != null)
			{
				disposable.Dispose();
				disposable = null;
			}
			if (_0023_003Dztgqm2r4_003D != null)
			{
				_0023_003Dztgqm2r4_003D.Dispose();
				_0023_003Dztgqm2r4_003D = null;
			}
		}
	}

	private struct _0023_003DzgqvoyJk_003D(_0023_003Dqwtg5wf2a70tRxUwrA7Np2l7FtCsssLv2BJLt3fbgC6A_003D _0023_003Dz9jrlnWk_003D, _0023_003Dz9I8ZVlc_003D _0023_003DzBxpHhQ0_003D)
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly byte _0023_003Dz9jrlnWk_003D = _0023_003Dz9jrlnWk_003D._0023_003DzwxVOhU7b9O_T_eppoj4_0024w0ixl7pDHPWWIfsRMUPd4gsi();

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly _0023_003Dz9I8ZVlc_003D _0023_003DzBxpHhQ0_003D = _0023_003DzBxpHhQ0_003D;
	}

	private static class _0023_003DziiEv3wQ_003D
	{
		private static readonly Dictionary<MethodBase, MethodInfo> _0023_003Dz9jrlnWk_003D = new Dictionary<MethodBase, MethodInfo>();

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static MethodBase _0023_003Dz7RMo0OLCQrBAbI7SvykASwg04DNOMpNTqA_003D_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003DqaEtT9DoRRoUP_0024LS5u4B6AojK4YaTqiLM3Vc605IaRGE_003D _0023_003DzBxpHhQ0_003D, MethodBase _0023_003Dztgqm2r4_003D, bool _0023_003DzzKDx05I_003D)
		{
			lock (_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D._0023_003DziiEv3wQ_003D._0023_003Dz9jrlnWk_003D)
			{
				if (_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D._0023_003DziiEv3wQ_003D._0023_003Dz9jrlnWk_003D.TryGetValue(_0023_003Dztgqm2r4_003D, out var value))
				{
					return value;
				}
				Type returnType = ((!(_0023_003Dztgqm2r4_003D is MethodInfo methodInfo)) ? _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D.m__0023_003Dz9I8ZVlc_003D : methodInfo.ReturnType);
				ParameterInfo[] parameters = _0023_003Dztgqm2r4_003D.GetParameters();
				Type[] array;
				if (_0023_003Dztgqm2r4_003D.IsStatic)
				{
					array = new Type[parameters.Length];
					for (int i = 0; i < parameters.Length; i++)
					{
						array[i] = parameters[i].ParameterType;
					}
				}
				else
				{
					array = new Type[parameters.Length + 1];
					Type type = _0023_003Dztgqm2r4_003D.DeclaringType;
					if (type.IsValueType)
					{
						type = type.MakeByRefType();
						_0023_003DzzKDx05I_003D = false;
					}
					array[0] = type;
					for (int j = 0; j < parameters.Length; j++)
					{
						array[j + 1] = parameters[j].ParameterType;
					}
				}
				string empty = string.Empty;
				if (value == null)
				{
					value = new DynamicMethod(empty, returnType, array, _0023_003Dz9jrlnWk_003D._0023_003Dz9_Z5EhGFT4yzpTmOPYjfhZOeNABFeUtCmZ_KeWA_003D(_0023_003DzBxpHhQ0_003D._0023_003DzUaXoJXQwrrbCr0Kl7wUIRwaCDGvQifXoCg_003D_003D(), _0023_003DzBxpHhQ0_003D: true), skipVisibility: true);
				}
				ILGenerator iLGenerator = ((DynamicMethod)value).GetILGenerator();
				for (int k = 0; k < array.Length; k++)
				{
					iLGenerator.Emit(OpCodes.Ldarg, k);
				}
				if (_0023_003Dztgqm2r4_003D is ConstructorInfo con)
				{
					iLGenerator.Emit(_0023_003DzzKDx05I_003D ? OpCodes.Callvirt : OpCodes.Call, con);
				}
				else
				{
					iLGenerator.Emit(_0023_003DzzKDx05I_003D ? OpCodes.Callvirt : OpCodes.Call, (MethodInfo)_0023_003Dztgqm2r4_003D);
				}
				iLGenerator.Emit(OpCodes.Ret);
				_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D._0023_003DziiEv3wQ_003D._0023_003Dz9jrlnWk_003D.Add(_0023_003Dztgqm2r4_003D, value);
				return value;
			}
		}
	}

	private static class _0023_003DzoEGLyuM_003D
	{
		private delegate _0023_003DzJGsRSpg_003D _0023_003Dz_0024bI1JP4_003D<in _0023_003Dz9jrlnWk_003D, in _0023_003DzBxpHhQ0_003D, in _0023_003Dztgqm2r4_003D, in _0023_003DzzKDx05I_003D, in _0023_003Dz3iPku7s_003D, in _0023_003Dz2X8kE24_003D, out _0023_003DzJGsRSpg_003D>(_0023_003Dz9jrlnWk_003D _0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D _0023_003Dztgqm2r4_003D, _0023_003DzzKDx05I_003D _0023_003DzzKDx05I_003D, _0023_003Dz3iPku7s_003D _0023_003Dz3iPku7s_003D, _0023_003Dz2X8kE24_003D _0023_003Dz2X8kE24_003D);

		private delegate void _0023_003Dz2X8kE24_003D<in _0023_003Dz9jrlnWk_003D, in _0023_003DzBxpHhQ0_003D, in _0023_003Dztgqm2r4_003D, in _0023_003DzzKDx05I_003D, in _0023_003Dz3iPku7s_003D>(_0023_003Dz9jrlnWk_003D _0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D _0023_003Dztgqm2r4_003D, _0023_003DzzKDx05I_003D _0023_003DzzKDx05I_003D, _0023_003Dz3iPku7s_003D _0023_003Dz3iPku7s_003D);

		private delegate void _0023_003Dz3iPku7s_003D<in _0023_003Dz9jrlnWk_003D, in _0023_003DzBxpHhQ0_003D, in _0023_003Dztgqm2r4_003D, in _0023_003DzzKDx05I_003D>(_0023_003Dz9jrlnWk_003D _0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D _0023_003Dztgqm2r4_003D, _0023_003DzzKDx05I_003D _0023_003DzzKDx05I_003D);

		private delegate _0023_003Dz2X8kE24_003D _0023_003Dz7SVqS2w_003D<in _0023_003Dz9jrlnWk_003D, in _0023_003DzBxpHhQ0_003D, in _0023_003Dztgqm2r4_003D, in _0023_003DzzKDx05I_003D, in _0023_003Dz3iPku7s_003D, out _0023_003Dz2X8kE24_003D>(_0023_003Dz9jrlnWk_003D _0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D _0023_003Dztgqm2r4_003D, _0023_003DzzKDx05I_003D _0023_003DzzKDx05I_003D, _0023_003Dz3iPku7s_003D _0023_003Dz3iPku7s_003D);

		private delegate void _0023_003Dz9I8ZVlc_003D<in _0023_003Dz9jrlnWk_003D, in _0023_003DzBxpHhQ0_003D, in _0023_003Dztgqm2r4_003D, in _0023_003DzzKDx05I_003D, in _0023_003Dz3iPku7s_003D, in _0023_003Dz2X8kE24_003D, in _0023_003DzJGsRSpg_003D>(_0023_003Dz9jrlnWk_003D _0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D _0023_003Dztgqm2r4_003D, _0023_003DzzKDx05I_003D _0023_003DzzKDx05I_003D, _0023_003Dz3iPku7s_003D _0023_003Dz3iPku7s_003D, _0023_003Dz2X8kE24_003D _0023_003Dz2X8kE24_003D, _0023_003DzJGsRSpg_003D _0023_003DzJGsRSpg_003D);

		private delegate void _0023_003Dz9jrlnWk_003D();

		private delegate _0023_003DzBxpHhQ0_003D _0023_003DzAndD6oU_003D<in _0023_003Dz9jrlnWk_003D, out _0023_003DzBxpHhQ0_003D>(_0023_003Dz9jrlnWk_003D _0023_003Dz9jrlnWk_003D);

		private delegate void _0023_003DzBxpHhQ0_003D<in _0023_003Dz9jrlnWk_003D>(_0023_003Dz9jrlnWk_003D _0023_003Dz9jrlnWk_003D);

		private delegate _0023_003Dz9I8ZVlc_003D _0023_003DzGX9QPgk_003D<in _0023_003Dz9jrlnWk_003D, in _0023_003DzBxpHhQ0_003D, in _0023_003Dztgqm2r4_003D, in _0023_003DzzKDx05I_003D, in _0023_003Dz3iPku7s_003D, in _0023_003Dz2X8kE24_003D, in _0023_003DzJGsRSpg_003D, out _0023_003Dz9I8ZVlc_003D>(_0023_003Dz9jrlnWk_003D _0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D _0023_003Dztgqm2r4_003D, _0023_003DzzKDx05I_003D _0023_003DzzKDx05I_003D, _0023_003Dz3iPku7s_003D _0023_003Dz3iPku7s_003D, _0023_003Dz2X8kE24_003D _0023_003Dz2X8kE24_003D, _0023_003DzJGsRSpg_003D _0023_003DzJGsRSpg_003D);

		private delegate _0023_003DzoEGLyuM_003D _0023_003DzJ6W8874_003D<in _0023_003Dz9jrlnWk_003D, in _0023_003DzBxpHhQ0_003D, in _0023_003Dztgqm2r4_003D, in _0023_003DzzKDx05I_003D, in _0023_003Dz3iPku7s_003D, in _0023_003Dz2X8kE24_003D, in _0023_003DzJGsRSpg_003D, in _0023_003Dz9I8ZVlc_003D, in _0023_003DzgqvoyJk_003D, out _0023_003DzoEGLyuM_003D>(_0023_003Dz9jrlnWk_003D _0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D _0023_003Dztgqm2r4_003D, _0023_003DzzKDx05I_003D _0023_003DzzKDx05I_003D, _0023_003Dz3iPku7s_003D _0023_003Dz3iPku7s_003D, _0023_003Dz2X8kE24_003D _0023_003Dz2X8kE24_003D, _0023_003DzJGsRSpg_003D _0023_003DzJGsRSpg_003D, _0023_003Dz9I8ZVlc_003D _0023_003Dz9I8ZVlc_003D, _0023_003DzgqvoyJk_003D _0023_003DzgqvoyJk_003D);

		private delegate void _0023_003DzJGsRSpg_003D<in _0023_003Dz9jrlnWk_003D, in _0023_003DzBxpHhQ0_003D, in _0023_003Dztgqm2r4_003D, in _0023_003DzzKDx05I_003D, in _0023_003Dz3iPku7s_003D, in _0023_003Dz2X8kE24_003D>(_0023_003Dz9jrlnWk_003D _0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D _0023_003Dztgqm2r4_003D, _0023_003DzzKDx05I_003D _0023_003DzzKDx05I_003D, _0023_003Dz3iPku7s_003D _0023_003Dz3iPku7s_003D, _0023_003Dz2X8kE24_003D _0023_003Dz2X8kE24_003D);

		private delegate _0023_003Dz3iPku7s_003D _0023_003DzLi0XoCY_003D<in _0023_003Dz9jrlnWk_003D, in _0023_003DzBxpHhQ0_003D, in _0023_003Dztgqm2r4_003D, in _0023_003DzzKDx05I_003D, out _0023_003Dz3iPku7s_003D>(_0023_003Dz9jrlnWk_003D _0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D _0023_003Dztgqm2r4_003D, _0023_003DzzKDx05I_003D _0023_003DzzKDx05I_003D);

		private delegate _0023_003DzzKDx05I_003D _0023_003DzaTyQZ6E_003D<in _0023_003Dz9jrlnWk_003D, in _0023_003DzBxpHhQ0_003D, in _0023_003Dztgqm2r4_003D, out _0023_003DzzKDx05I_003D>(_0023_003Dz9jrlnWk_003D _0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D _0023_003Dztgqm2r4_003D);

		private delegate _0023_003Dztgqm2r4_003D _0023_003DzbSmUaeo_003D<in _0023_003Dz9jrlnWk_003D, in _0023_003DzBxpHhQ0_003D, out _0023_003Dztgqm2r4_003D>(_0023_003Dz9jrlnWk_003D _0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D _0023_003DzBxpHhQ0_003D);

		private delegate void _0023_003DzgqvoyJk_003D<in _0023_003Dz9jrlnWk_003D, in _0023_003DzBxpHhQ0_003D, in _0023_003Dztgqm2r4_003D, in _0023_003DzzKDx05I_003D, in _0023_003Dz3iPku7s_003D, in _0023_003Dz2X8kE24_003D, in _0023_003DzJGsRSpg_003D, in _0023_003Dz9I8ZVlc_003D>(_0023_003Dz9jrlnWk_003D _0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D _0023_003Dztgqm2r4_003D, _0023_003DzzKDx05I_003D _0023_003DzzKDx05I_003D, _0023_003Dz3iPku7s_003D _0023_003Dz3iPku7s_003D, _0023_003Dz2X8kE24_003D _0023_003Dz2X8kE24_003D, _0023_003DzJGsRSpg_003D _0023_003DzJGsRSpg_003D, _0023_003Dz9I8ZVlc_003D _0023_003Dz9I8ZVlc_003D);

		private delegate _0023_003Dz9jrlnWk_003D _0023_003DziiEv3wQ_003D<out _0023_003Dz9jrlnWk_003D>();

		private delegate void _0023_003DzoEGLyuM_003D<in _0023_003Dz9jrlnWk_003D, in _0023_003DzBxpHhQ0_003D, in _0023_003Dztgqm2r4_003D, in _0023_003DzzKDx05I_003D, in _0023_003Dz3iPku7s_003D, in _0023_003Dz2X8kE24_003D, in _0023_003DzJGsRSpg_003D, in _0023_003Dz9I8ZVlc_003D, in _0023_003DzgqvoyJk_003D>(_0023_003Dz9jrlnWk_003D _0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D _0023_003Dztgqm2r4_003D, _0023_003DzzKDx05I_003D _0023_003DzzKDx05I_003D, _0023_003Dz3iPku7s_003D _0023_003Dz3iPku7s_003D, _0023_003Dz2X8kE24_003D _0023_003Dz2X8kE24_003D, _0023_003DzJGsRSpg_003D _0023_003DzJGsRSpg_003D, _0023_003Dz9I8ZVlc_003D _0023_003Dz9I8ZVlc_003D, _0023_003DzgqvoyJk_003D _0023_003DzgqvoyJk_003D);

		private delegate void _0023_003Dztgqm2r4_003D<in _0023_003Dz9jrlnWk_003D, in _0023_003DzBxpHhQ0_003D>(_0023_003Dz9jrlnWk_003D _0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D _0023_003DzBxpHhQ0_003D);

		private delegate _0023_003DzgqvoyJk_003D _0023_003DzwETOsNI_003D<in _0023_003Dz9jrlnWk_003D, in _0023_003DzBxpHhQ0_003D, in _0023_003Dztgqm2r4_003D, in _0023_003DzzKDx05I_003D, in _0023_003Dz3iPku7s_003D, in _0023_003Dz2X8kE24_003D, in _0023_003DzJGsRSpg_003D, in _0023_003Dz9I8ZVlc_003D, out _0023_003DzgqvoyJk_003D>(_0023_003Dz9jrlnWk_003D _0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D _0023_003Dztgqm2r4_003D, _0023_003DzzKDx05I_003D _0023_003DzzKDx05I_003D, _0023_003Dz3iPku7s_003D _0023_003Dz3iPku7s_003D, _0023_003Dz2X8kE24_003D _0023_003Dz2X8kE24_003D, _0023_003DzJGsRSpg_003D _0023_003DzJGsRSpg_003D, _0023_003Dz9I8ZVlc_003D _0023_003Dz9I8ZVlc_003D);

		private delegate void _0023_003DzzKDx05I_003D<in _0023_003Dz9jrlnWk_003D, in _0023_003DzBxpHhQ0_003D, in _0023_003Dztgqm2r4_003D>(_0023_003Dz9jrlnWk_003D _0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D _0023_003Dztgqm2r4_003D);

		private static readonly Dictionary<MethodBase, KeyValuePair<Type, MethodInfo>> m__0023_003Dz9jrlnWk_003D;

		static _0023_003DzoEGLyuM_003D()
		{
			_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D._0023_003DzoEGLyuM_003D.m__0023_003Dz9jrlnWk_003D = new Dictionary<MethodBase, KeyValuePair<Type, MethodInfo>>();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static object _0023_003DzvI807xvpFdbQuPiT8AohTOloWLz3k1r_FbUYH7s_003D(object _0023_003Dz9jrlnWk_003D, MethodBase _0023_003DzBxpHhQ0_003D, out MethodInfo _0023_003Dztgqm2r4_003D)
		{
			KeyValuePair<Type, MethodInfo> keyValuePair = _0023_003DzIkf_0024g_00247xcQMBtb2aDuhbPdVeIvN_0024(_0023_003DzBxpHhQ0_003D);
			Delegate result = (Delegate)Activator.CreateInstance(keyValuePair.Key, _0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D.MethodHandle.GetFunctionPointer());
			_0023_003Dztgqm2r4_003D = keyValuePair.Value;
			return result;
		}

		private static KeyValuePair<Type, MethodInfo> _0023_003DzIkf_0024g_00247xcQMBtb2aDuhbPdVeIvN_0024(MethodBase _0023_003Dz9jrlnWk_003D)
		{
			lock (_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D._0023_003DzoEGLyuM_003D.m__0023_003Dz9jrlnWk_003D)
			{
				if (_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D._0023_003DzoEGLyuM_003D.m__0023_003Dz9jrlnWk_003D.TryGetValue(_0023_003Dz9jrlnWk_003D, out var value))
				{
					return value;
				}
				Type type = (_0023_003Dz9jrlnWk_003D as MethodInfo)?.ReturnType ?? _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D.m__0023_003Dz9I8ZVlc_003D;
				bool flag = type != _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D.m__0023_003Dz9I8ZVlc_003D;
				ParameterInfo[] parameters = _0023_003Dz9jrlnWk_003D.GetParameters();
				if (parameters.Length > 9)
				{
					throw new Exception(string.Format(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564314401), parameters.Length));
				}
				Type[] array = new Type[parameters.Length + (flag ? 1 : 0)];
				for (int i = 0; i < parameters.Length; i++)
				{
					Type parameterType = parameters[i].ParameterType;
					if (parameterType.IsByRef || parameterType.IsPointer)
					{
						throw new Exception(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564314463));
					}
					array[i] = parameterType;
				}
				if (flag)
				{
					array[array.Length - 1] = type;
				}
				Type type2 = (flag ? _0023_003Dz3JPOihmO1xN6gF2TwMGdK3g_003D(array) : _0023_003Dzs_0024ZxWm5XaYtJAk06VMxt3pw_003D(array));
				MethodInfo method = type2.GetMethod(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564314256));
				value = new KeyValuePair<Type, MethodInfo>(type2, method);
				_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D._0023_003DzoEGLyuM_003D.m__0023_003Dz9jrlnWk_003D.Add(_0023_003Dz9jrlnWk_003D, value);
				return value;
			}
		}

		private static Type _0023_003Dz3JPOihmO1xN6gF2TwMGdK3g_003D(Type[] _0023_003Dz9jrlnWk_003D)
		{
			return _0023_003Dz9jrlnWk_003D.Length switch
			{
				1 => typeof(_0023_003DziiEv3wQ_003D<>).MakeGenericType(_0023_003Dz9jrlnWk_003D), 
				2 => typeof(_0023_003DzAndD6oU_003D<, >).MakeGenericType(_0023_003Dz9jrlnWk_003D), 
				3 => typeof(_0023_003DzbSmUaeo_003D<, , >).MakeGenericType(_0023_003Dz9jrlnWk_003D), 
				4 => typeof(_0023_003DzaTyQZ6E_003D<, , , >).MakeGenericType(_0023_003Dz9jrlnWk_003D), 
				5 => typeof(_0023_003DzLi0XoCY_003D<, , , , >).MakeGenericType(_0023_003Dz9jrlnWk_003D), 
				6 => typeof(_0023_003Dz7SVqS2w_003D<, , , , , >).MakeGenericType(_0023_003Dz9jrlnWk_003D), 
				7 => typeof(_0023_003Dz_0024bI1JP4_003D<, , , , , , >).MakeGenericType(_0023_003Dz9jrlnWk_003D), 
				8 => typeof(_0023_003DzGX9QPgk_003D<, , , , , , , >).MakeGenericType(_0023_003Dz9jrlnWk_003D), 
				9 => typeof(_0023_003DzwETOsNI_003D<, , , , , , , , >).MakeGenericType(_0023_003Dz9jrlnWk_003D), 
				10 => typeof(_0023_003DzJ6W8874_003D<, , , , , , , , , >).MakeGenericType(_0023_003Dz9jrlnWk_003D), 
				_ => null, 
			};
		}

		private static Type _0023_003Dzs_0024ZxWm5XaYtJAk06VMxt3pw_003D(Type[] _0023_003Dz9jrlnWk_003D)
		{
			return _0023_003Dz9jrlnWk_003D.Length switch
			{
				0 => typeof(_0023_003Dz9jrlnWk_003D), 
				1 => typeof(_0023_003DzBxpHhQ0_003D<>).MakeGenericType(_0023_003Dz9jrlnWk_003D), 
				2 => typeof(_0023_003Dztgqm2r4_003D<, >).MakeGenericType(_0023_003Dz9jrlnWk_003D), 
				3 => typeof(_0023_003DzzKDx05I_003D<, , >).MakeGenericType(_0023_003Dz9jrlnWk_003D), 
				4 => typeof(_0023_003Dz3iPku7s_003D<, , , >).MakeGenericType(_0023_003Dz9jrlnWk_003D), 
				5 => typeof(_0023_003Dz2X8kE24_003D<, , , , >).MakeGenericType(_0023_003Dz9jrlnWk_003D), 
				6 => typeof(_0023_003DzJGsRSpg_003D<, , , , , >).MakeGenericType(_0023_003Dz9jrlnWk_003D), 
				7 => typeof(_0023_003Dz9I8ZVlc_003D<, , , , , , >).MakeGenericType(_0023_003Dz9jrlnWk_003D), 
				8 => typeof(_0023_003DzgqvoyJk_003D<, , , , , , , >).MakeGenericType(_0023_003Dz9jrlnWk_003D), 
				9 => typeof(_0023_003DzoEGLyuM_003D<, , , , , , , , >).MakeGenericType(_0023_003Dz9jrlnWk_003D), 
				_ => null, 
			};
		}
	}

	private struct _0023_003Dztgqm2r4_003D
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool _0023_003Dz9jrlnWk_003D;
	}

	private static class _0023_003DzzKDx05I_003D
	{
		public static readonly bool _0023_003Dz9jrlnWk_003D;

		static _0023_003DzzKDx05I_003D()
		{
			try
			{
				_0023_003Dz9jrlnWk_003D = _0023_003DzXsXF2JM5r9_ZXP9GtrT4Alk_003D();
			}
			catch
			{
				_0023_003Dz9jrlnWk_003D = false;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static bool _0023_003DzXsXF2JM5r9_ZXP9GtrT4Alk_003D()
		{
			if (typeof(DynamicMethod).IsAbstract)
			{
				return false;
			}
			try
			{
				new DynamicMethod(string.Empty, typeof(void), Type.EmptyTypes);
			}
			catch (PlatformNotSupportedException)
			{
				return false;
			}
			return true;
		}
	}

	private static Type _0023_003DzP5I_H4I_003D;

	private long _0023_003DzFQGDh5A_003D;

	private readonly Module m__0023_003DzJ6W8874_003D;

	private _0023_003Dqih1RKs7Osg5_0024Rd9gDhKEdqdrC8qgJFChg_7i1V8hZwk_003D[] _0023_003DzCR5Jlyc_003D;

	private Type[] _0023_003DzS5oUG4s_003D;

	private _0023_003DqaEtT9DoRRoUP_0024LS5u4B6AojK4YaTqiLM3Vc605IaRGE_003D m__0023_003DzaTyQZ6E_003D;

	private object _0023_003DzNl32EAo_003D;

	private static Type _0023_003Dz7SVqS2w_003D;

	private readonly _0023_003DqiA1d0doSeLnh_VY97pG2QI49hVABlW155dgxLJzVyPA_003D _0023_003DzWAsKAZU_003D;

	private _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D m__0023_003Dz3iPku7s_003D;

	private Type[] m__0023_003DzzKDx05I_003D;

	private static readonly Dictionary<_0023_003DzJ6W8874_003D, _0023_003Dz2X8kE24_003D> _0023_003DzG7m2nd8_003D = new Dictionary<_0023_003DzJ6W8874_003D, _0023_003Dz2X8kE24_003D>(256);

	private bool m__0023_003Dz2X8kE24_003D;

	private readonly Stack<_0023_003Dz3iPku7s_003D> m__0023_003Dz9jrlnWk_003D = new Stack<_0023_003Dz3iPku7s_003D>();

	private static readonly Dictionary<int, object> _0023_003DzZpkUTwY_003D;

	private Type _0023_003Dzn6_Dl38_003D;

	private static Type _0023_003DzCbpaZow_003D;

	private static Type m__0023_003DzBxpHhQ0_003D;

	private readonly Stack<_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D> _0023_003DzGX9QPgk_003D = new Stack<_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D>(16);

	private static readonly Dictionary<MethodBase, int> m__0023_003Dztgqm2r4_003D;

	private _0023_003DqSrxlws3SuprWxrjyHO1juxJFrTNvlF8gj_KAkF067yA_003D _0023_003DzXlMgCsc_003D;

	private Stream m__0023_003DzJGsRSpg_003D;

	private static Type m__0023_003DzbSmUaeo_003D;

	private _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dznx1EMIs_003D;

	private object[] m__0023_003DzgqvoyJk_003D;

	private static Type m__0023_003Dz9I8ZVlc_003D;

	private bool _0023_003DzwETOsNI_003D;

	private _0023_003DqSrxlws3SuprWxrjyHO1juxJFrTNvlF8gj_KAkF067yA_003D _0023_003DzLi0XoCY_003D;

	private static Type _0023_003DzozZCuko_003D;

	private _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D[] m__0023_003DziiEv3wQ_003D;

	private _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D[] _0023_003DzWn08U5s_003D;

	private byte[] m__0023_003DzoEGLyuM_003D;

	private Stack<_0023_003DzbSmUaeo_003D> _0023_003DzbzHeu9w_003D;

	private uint? _0023_003DzgtUi_7A_003D;

	private static object _0023_003DzbLHaDy4_003D = new object();

	private uint m__0023_003DzAndD6oU_003D;

	private static Dictionary<int, _0023_003DzgqvoyJk_003D> _0023_003Dz_0024bI1JP4_003D;

	private uint _0023_003DzMP6kxrk_003D;

	private static readonly Dictionary<MethodBase, object> _0023_003Dz5bot44w_003D;

	private uint _0023_003DziDh2WHE_003D;

	public _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D(_0023_003DqiA1d0doSeLnh_VY97pG2QI49hVABlW155dgxLJzVyPA_003D _0023_003Dz9jrlnWk_003D, Module _0023_003DzBxpHhQ0_003D)
	{
		_0023_003DzWAsKAZU_003D = _0023_003Dz9jrlnWk_003D;
		this.m__0023_003DzJ6W8874_003D = _0023_003DzBxpHhQ0_003D;
		_0023_003DzHL66juT5u3Fvk0M2vfId3VwjiZtZCD2oSw_003D_003D();
	}

	public _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D(_0023_003DqiA1d0doSeLnh_VY97pG2QI49hVABlW155dgxLJzVyPA_003D _0023_003Dz9jrlnWk_003D)
		: this(_0023_003Dz9jrlnWk_003D, typeof(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D).Module)
	{
	}

	static _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D()
	{
		_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D.m__0023_003Dztgqm2r4_003D = new Dictionary<MethodBase, int>(256);
		_0023_003Dz5bot44w_003D = new Dictionary<MethodBase, object>();
		_0023_003DzZpkUTwY_003D = new Dictionary<int, object>();
		_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D.m__0023_003DzbSmUaeo_003D = typeof(_0023_003DzAndD6oU_003D);
		_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D.m__0023_003Dz9I8ZVlc_003D = typeof(void);
		_0023_003Dz7SVqS2w_003D = typeof(object[]);
		_0023_003DzozZCuko_003D = typeof(IntPtr);
		_0023_003DzCbpaZow_003D = typeof(Assembly);
		_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D.m__0023_003DzBxpHhQ0_003D = typeof(MethodBase);
		_0023_003DzP5I_H4I_003D = typeof(RuntimeHelpers);
	}

	private void _0023_003Dz4aIsGrkxJXsni29jRFACK21EuSDR(bool _0023_003Dz9jrlnWk_003D, bool _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3 = _0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		_0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(_0023_003DzFkdstI_UtodZr8Xa1HlKSbvfxLczlacX8Q_003D_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2, _0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D));
	}

	private static void _0023_003Dz3bDIE3fUiGuCUA5eOdbUb95mwmeWGz_00247fLdZmVRylLJN(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		bool flag = false;
		if (_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() switch
		{
			1 => ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D() == 0, 
			13 => ((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG() == 0, 
			0 => ((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk() == IntPtr.Zero, 
			20 => ((_0023_003DqVEj3J19zkgEyU6VFymBz6riyi6CxZMJEjhA0KZ2nLKw_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzZlwwYywinAe9h_2ss_0024Wn4RsajDr79HfGCg_003D_003D() == UIntPtr.Zero, 
			7 => ((_0023_003DqcjmfsaS6dKPuf2kSTqJKWfH_rgkc03gEAn6QEKAtpbA_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzKuvp4FpGZEHp_0024htPxx_00248SXawDH8Tdf_0Y48dwaP_bCrZ() == null, 
			19 => !Convert.ToBoolean(((_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D()), 
			_ => _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D() == null, 
		})
		{
			uint num = ((_0023_003DqJFdrGiwz1aJICVkSTb_0024Zko9aS6iSwDcZdo9VS4Dkh_0024s_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzxGjrL4iuhvogLPGFSdnVXdPvbKxem9P4HA_003D_003D();
			_0023_003Dz9jrlnWk_003D._0023_003Dz9r__0024YTGu_0024iN2qFjqe6k1t7s_003D(num);
		}
	}

	private static void _0023_003DzMff7ghi3xzu9qzUmg0EUwZE5LB_QMxJsnXlsM8Y_003D(Exception _0023_003Dz9jrlnWk_003D)
	{
		ExceptionDispatchInfo.Capture(_0023_003Dz9jrlnWk_003D).Throw();
	}

	private static void _0023_003DzLpR1EYbVy6BXf5S_00240VN1z71uPg4W7lt2BQ_003D_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		int num = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
		FieldInfo fieldInfo = _0023_003Dz9jrlnWk_003D._0023_003DzxFlP9j6hwChqbnCQxNoxN7LJpAh_00242zp2XpETVEHUh_9i(num);
		_0023_003Dz9jrlnWk_003D._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(new _0023_003DqrQPc9rwDL7Fl53_0024M2Pi1fo_0024Ac1BCNKiaW0Mx66Ji04U_003D(fieldInfo, null));
	}

	private static void _0023_003DzjZ5TW3fbGkMzeO2SkXJg2RagnG_0024y69MmAg_003D_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DztqiIS5t19tn4D0pTuVrmqGw_003D(((_0023_003DqIC7wdNmeVLrKuHjiCL8jtht_0024ogaMGYTl_vFxiqwcERQ_003D)_0023_003DzBxpHhQ0_003D)._0023_003Dz3fdyocpuocHKnMPBAP0IP10_003D());
	}

	private static void _0023_003DzuZ10UqzC4iKg6tMmM0n7IoeyqBLx1SejBg_003D_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		checked
		{
			_0023_003Dz9jrlnWk_003D._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() switch
			{
				1 => unchecked((uint)((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D()), 
				13 => (long)(ulong)((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG(), 
				19 => (long)Convert.ToUInt64(((_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D()), 
				8 => (long)((_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzCfXuHVIlFp1X1u2Med2_AL4lzej8EifTBw_003D_003D(), 
				0 => (IntPtr.Size != 4) ? ((long)(ulong)(long)((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk()) : unchecked((uint)(int)((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk()), 
				_ => throw new InvalidOperationException(), 
			}));
		}
	}

	private void _0023_003DzXWjhwr3jjg5LgzFsYywdzVTfnUlc(bool _0023_003Dz9jrlnWk_003D)
	{
		uint num = _0023_003DziDh2WHE_003D;
		while (true)
		{
			try
			{
				while (!_0023_003DzwETOsNI_003D)
				{
					if (_0023_003DzgtUi_7A_003D.HasValue)
					{
						_0023_003DzMP6kxrk_003D = _0023_003DzgtUi_7A_003D.Value;
						_0023_003Dz3BejEhUi_0024bSfiEeI8cmkKdw_003D(_0023_003DzMP6kxrk_003D);
						_0023_003DzgtUi_7A_003D = null;
					}
					else if (_0023_003DzMP6kxrk_003D >= num)
					{
						break;
					}
					_0023_003Dz84sjEx3H5BuZJ2m01NLFGcySpi_0024Z();
				}
				break;
			}
			catch (object obj)
			{
				_0023_003DzF6lNdUgp_0024EXaHsYbpiKsz5x9aQWSK_0024MB_mvoQ7s_003D(obj, 0u);
				if (!_0023_003Dz9jrlnWk_003D)
				{
					_0023_003DzXWjhwr3jjg5LgzFsYywdzVTfnUlc(_0023_003Dz9jrlnWk_003D: true);
					break;
				}
			}
		}
	}

	private void _0023_003DzHL66juT5u3Fvk0M2vfId3VwjiZtZCD2oSw_003D_003D()
	{
		if (!_0023_003DzWAsKAZU_003D._0023_003DzvX7z0mfZNY3IwmABd3KStotyfGkQEhUgCQ_003D_003D())
		{
			lock (_0023_003DzWAsKAZU_003D)
			{
				if (!_0023_003DzWAsKAZU_003D._0023_003DzvX7z0mfZNY3IwmABd3KStotyfGkQEhUgCQ_003D_003D())
				{
					_0023_003Dz_0024bI1JP4_003D = _0023_003DzDVqBRKDrgm58Xj1ZkYn9zEF__0024oHn(_0023_003DzWAsKAZU_003D);
					_0023_003DznQ8YDEtmD5Cz_kewxSKvUop4pX_0024MmG6PfA_003D_003D();
					_0023_003DzWAsKAZU_003D._0023_003Dze2fEG8aaIe3BZuE_0024ECrjb2F8wWwH(_0023_003Dz9jrlnWk_003D: true);
				}
			}
		}
		if (_0023_003Dz_0024bI1JP4_003D == null)
		{
			_0023_003Dz_0024bI1JP4_003D = _0023_003DzDVqBRKDrgm58Xj1ZkYn9zEF__0024oHn(_0023_003DzWAsKAZU_003D);
		}
	}

	private static void _0023_003Dz5ClTIsODup3igBphUksyuGwl7r2q__1ycQ_003D_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		throw new NotSupportedException(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564315434));
	}

	private static void _0023_003DzsRFxBLGK2B8XoAVwHY6DMhMWFrHjjo6TqlE3OCw_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		if (_0023_003Dz9jrlnWk_003D._0023_003DzNl32EAo_003D == null)
		{
			throw new InvalidOperationException();
		}
		_0023_003Dz9jrlnWk_003D._0023_003DzzUdLVh6RcJ0qp5eRPoW5he0ADnSX(_0023_003Dz9jrlnWk_003D._0023_003DzNl32EAo_003D);
	}

	private static _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dzr0yXc9pJwMobF4pCiw6aD7c42mVpHuMqcQ_003D_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D, bool _0023_003Dztgqm2r4_003D)
	{
		if (_0023_003Dz9jrlnWk_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 1)
		{
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 1)
			{
				if (!_0023_003Dztgqm2r4_003D)
				{
					int num = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
					int num2 = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
					return new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(num >> num2);
				}
				int num3 = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
				int num4 = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
				return new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(num3 >>> num4);
			}
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 19)
			{
				return _0023_003Dzr0yXc9pJwMobF4pCiw6aD7c42mVpHuMqcQ_003D_003D(_0023_003Dz9jrlnWk_003D, new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(Convert.ToInt32(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D())), _0023_003Dztgqm2r4_003D);
			}
		}
		if (_0023_003Dz9jrlnWk_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 13)
		{
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 1)
			{
				if (!_0023_003Dztgqm2r4_003D)
				{
					long num5 = ((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG();
					int num6 = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
					return new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(num5 >> num6);
				}
				long num7 = ((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG();
				int num8 = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
				return new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(num7 >>> num8);
			}
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 19)
			{
				return _0023_003Dzr0yXc9pJwMobF4pCiw6aD7c42mVpHuMqcQ_003D_003D(_0023_003Dz9jrlnWk_003D, new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(Convert.ToInt32(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D())), _0023_003Dztgqm2r4_003D);
			}
		}
		if (_0023_003Dz9jrlnWk_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 19)
		{
			Type underlyingType = Enum.GetUnderlyingType(_0023_003Dz9jrlnWk_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D().GetType());
			if (underlyingType == typeof(long) || underlyingType == typeof(ulong))
			{
				return _0023_003Dzr0yXc9pJwMobF4pCiw6aD7c42mVpHuMqcQ_003D_003D(new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(Convert.ToInt64(_0023_003Dz9jrlnWk_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D())), _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D);
			}
			return _0023_003Dzr0yXc9pJwMobF4pCiw6aD7c42mVpHuMqcQ_003D_003D(new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(Convert.ToInt32(_0023_003Dz9jrlnWk_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D())), _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D);
		}
		throw new InvalidOperationException();
	}

	private static void _0023_003Dz9mDitRIO0BM5_HPQ2pNhhA8EYRvG(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003Dzy4D_00248buHMHsvaKDXIg_003D_003D(5);
	}

	private static void _0023_003DzHqBZ_0024sERM_0024iDOtbjBhx6bIs_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003DqIC7wdNmeVLrKuHjiCL8jtht_0024ogaMGYTl_vFxiqwcERQ_003D _0023_003DqIC7wdNmeVLrKuHjiCL8jtht_0024ogaMGYTl_vFxiqwcERQ_003D2 = (_0023_003DqIC7wdNmeVLrKuHjiCL8jtht_0024ogaMGYTl_vFxiqwcERQ_003D)_0023_003DzBxpHhQ0_003D;
		_0023_003DqFNN_kH3_Aic_0024vq9s6N7BcnqdUOw1mJpa1yIMZD1vbOQ_003D obj = new _0023_003DqFNN_kH3_Aic_0024vq9s6N7BcnqdUOw1mJpa1yIMZD1vbOQ_003D();
		obj._0023_003DzlpaqC69eD5UfV5QZE9NijsO7MeQh(_0023_003Dz9jrlnWk_003D._0023_003DzWn08U5s_003D[_0023_003DqIC7wdNmeVLrKuHjiCL8jtht_0024ogaMGYTl_vFxiqwcERQ_003D2._0023_003Dz3fdyocpuocHKnMPBAP0IP10_003D()]);
		_0023_003Dz9jrlnWk_003D._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(obj);
	}

	private _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dzeu0x6kGh6v4nZT631vG00XRKXaEe(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		if (_0023_003Dz9jrlnWk_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 1)
		{
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 1)
			{
				int num = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
				int num2 = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
				_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D obj = new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D();
				obj._0023_003DzVS8y6A9spdnllqaw83gW5bpUS8si(num & num2);
				return obj;
			}
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 19)
			{
				int num3 = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
				Type underlyingType = Enum.GetUnderlyingType(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D().GetType());
				if (underlyingType == typeof(long) || underlyingType == typeof(ulong))
				{
					long num4 = Convert.ToInt64(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D());
					return new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(num3 & num4);
				}
				int num5 = Convert.ToInt32(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D());
				_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D obj2 = new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D();
				obj2._0023_003DzVS8y6A9spdnllqaw83gW5bpUS8si(num3 & num5);
				return obj2;
			}
		}
		if (_0023_003Dz9jrlnWk_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 13)
		{
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 13)
			{
				long num6 = ((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG();
				long num7 = ((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG();
				_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D obj3 = new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D();
				obj3._0023_003Dzbu_MJyfs7_Zi8dZPXG8_00248P0_003D(num6 & num7);
				return obj3;
			}
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 19)
			{
				int num8 = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
				long num9 = Convert.ToInt64(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D());
				return new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(num8 & num9);
			}
		}
		if (_0023_003Dz9jrlnWk_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 19)
		{
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 1)
			{
				int num10 = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
				Type underlyingType2 = Enum.GetUnderlyingType(_0023_003Dz9jrlnWk_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D().GetType());
				if (underlyingType2 == typeof(long) || underlyingType2 == typeof(ulong))
				{
					return new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(Convert.ToInt64(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D()) & num10);
				}
				int num11 = Convert.ToInt32(_0023_003Dz9jrlnWk_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D());
				_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D obj4 = new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D();
				obj4._0023_003DzVS8y6A9spdnllqaw83gW5bpUS8si(num11 & num10);
				return obj4;
			}
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 13)
			{
				long num12 = Convert.ToInt64(_0023_003Dz9jrlnWk_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D());
				long num13 = ((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG();
				_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D obj5 = new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D();
				obj5._0023_003Dzbu_MJyfs7_Zi8dZPXG8_00248P0_003D(num12 & num13);
				return obj5;
			}
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 19)
			{
				Type underlyingType3 = Enum.GetUnderlyingType(_0023_003Dz9jrlnWk_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D().GetType());
				Type underlyingType4 = Enum.GetUnderlyingType(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D().GetType());
				if (underlyingType3 == typeof(long) || underlyingType3 == typeof(ulong) || underlyingType4 == typeof(long) || underlyingType4 == typeof(ulong))
				{
					long num14 = Convert.ToInt64(_0023_003Dz9jrlnWk_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D());
					long num15 = Convert.ToInt64(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D());
					return new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(num14 & num15);
				}
				int num16 = Convert.ToInt32(_0023_003Dz9jrlnWk_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D());
				int num17 = Convert.ToInt32(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D());
				return new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(num16 & num17);
			}
		}
		throw new InvalidOperationException();
	}

	private bool _0023_003Dz2jdafFW3tsTms6grmzBm_0024rs_003D(_0023_003DqrQPc9rwDL7Fl53_0024M2Pi1fo_0024Ac1BCNKiaW0Mx66Ji04U_003D _0023_003Dz9jrlnWk_003D)
	{
		if (!_0023_003Dz9jrlnWk_003D._0023_003DzOGfSdf3O2RGD18omagPRFM_0024yH5C6().IsInitOnly)
		{
			return true;
		}
		if (_0023_003Dz9jrlnWk_003D._0023_003DzOGfSdf3O2RGD18omagPRFM_0024yH5C6().IsStatic != m__0023_003DzaTyQZ6E_003D._0023_003DzKttHpAQ_gTjjjLgkDh9KnFaqusae())
		{
			return false;
		}
		if (m__0023_003DzaTyQZ6E_003D._0023_003DzKttHpAQ_gTjjjLgkDh9KnFaqusae() && m__0023_003DzaTyQZ6E_003D._0023_003DznreDdTd5uS_MeC2m0FTHaTTa0lrL() != _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564314789))
		{
			return false;
		}
		Type type = _0023_003Dz9jrlnWk_003D._0023_003DzOGfSdf3O2RGD18omagPRFM_0024yH5C6().DeclaringType;
		if (type.IsGenericType)
		{
			type = type.GetGenericTypeDefinition();
		}
		return _0023_003Dz9_Z5EhGFT4yzpTmOPYjfhZOeNABFeUtCmZ_KeWA_003D(m__0023_003DzaTyQZ6E_003D._0023_003DzUaXoJXQwrrbCr0Kl7wUIRwaCDGvQifXoCg_003D_003D(), _0023_003DzBxpHhQ0_003D: true) == type;
	}

	private static void _0023_003DztlVOq2CzAarFw398vv7BxHCz4WlnH2EQ0BYXX8iLlfd2(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		Array array = (Array)_0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D()._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D();
		_0023_003Dz9jrlnWk_003D._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(array.Length));
	}

	private void _0023_003Dz3BejEhUi_0024bSfiEeI8cmkKdw_003D(long _0023_003Dz9jrlnWk_003D)
	{
		_0023_003DzLi0XoCY_003D._0023_003Dzf_kC_0024hpTUTdHx7uANBVIZvPU6fFbivFk0g_003D_003D()._0023_003DzYoGHUZEwKTu13kV8l1r1tB_0024dht2uqAQcK2u4e7dZySI8XM__Dz3SaTmm5Rtni4wKX3rKkto_003D(_0023_003Dz9jrlnWk_003D - _0023_003DzFQGDh5A_003D);
	}

	private bool _0023_003DzwMu5f4iLu52YPedKYy72lc1yzSdVsEvkWA_003D_003D(MethodBase _0023_003Dz9jrlnWk_003D, object _0023_003DzBxpHhQ0_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D[] _0023_003Dztgqm2r4_003D, object[] _0023_003DzzKDx05I_003D, bool _0023_003Dz3iPku7s_003D, ref object _0023_003Dz2X8kE24_003D)
	{
		Type declaringType = _0023_003Dz9jrlnWk_003D.DeclaringType;
		if (declaringType == null)
		{
			return false;
		}
		if (declaringType == _0023_003DzP5I_H4I_003D && _0023_003Dz9jrlnWk_003D.Name == _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564314776) && _0023_003DzzKDx05I_003D.Length == 2 && _0023_003Dz9jrlnWk_003D.ToString() == _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564314754))
		{
			_0023_003DqkFSllNsBiPRvMVij5CAGvHd4K9mAyOtxficeBXMW0AE_003D._0023_003Dz13Np_0024igY_0024HJ5_0024e5Fw7Anzo2VKOe1((Array)_0023_003DzzKDx05I_003D[0], (RuntimeFieldHandle)_0023_003DzzKDx05I_003D[1]);
			return true;
		}
		return false;
	}

	private static _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzaOO3l1fve8hJTUNmqU1uOQt4IxMJysbh6sK1eeu_6FMJ(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D, bool _0023_003Dztgqm2r4_003D)
	{
		if (_0023_003Dz9jrlnWk_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 1)
		{
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 1)
			{
				if (!_0023_003Dztgqm2r4_003D)
				{
					int num = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
					int num2 = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
					return new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(num % num2);
				}
				int num3 = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
				uint num4 = (uint)((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
				return new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D((int)((uint)num3 % num4));
			}
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 13)
			{
				return _0023_003DzFPp_Az7eVXKTXWr0jHcGgoGRIuFbnIm_0024gdNDLrA_003D(new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D()), _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D);
			}
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 19)
			{
				Type underlyingType = Enum.GetUnderlyingType(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D().GetType());
				if (underlyingType == typeof(long) || underlyingType == typeof(ulong))
				{
					return _0023_003DzFPp_Az7eVXKTXWr0jHcGgoGRIuFbnIm_0024gdNDLrA_003D(new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D()), new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(Convert.ToInt64(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D())), _0023_003Dztgqm2r4_003D);
				}
				return _0023_003DzaOO3l1fve8hJTUNmqU1uOQt4IxMJysbh6sK1eeu_6FMJ(_0023_003Dz9jrlnWk_003D, new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(Convert.ToInt32(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D())), _0023_003Dztgqm2r4_003D);
			}
		}
		if (_0023_003Dz9jrlnWk_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 13)
		{
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 13)
			{
				return _0023_003DzFPp_Az7eVXKTXWr0jHcGgoGRIuFbnIm_0024gdNDLrA_003D(_0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D);
			}
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 1)
			{
				return _0023_003DzFPp_Az7eVXKTXWr0jHcGgoGRIuFbnIm_0024gdNDLrA_003D(_0023_003Dz9jrlnWk_003D, new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D()), _0023_003Dztgqm2r4_003D);
			}
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 19)
			{
				Type underlyingType2 = Enum.GetUnderlyingType(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D().GetType());
				if (underlyingType2 == typeof(long) || underlyingType2 == typeof(ulong))
				{
					return _0023_003DzFPp_Az7eVXKTXWr0jHcGgoGRIuFbnIm_0024gdNDLrA_003D(_0023_003Dz9jrlnWk_003D, new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(Convert.ToInt64(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D())), _0023_003Dztgqm2r4_003D);
				}
				return _0023_003DzFPp_Az7eVXKTXWr0jHcGgoGRIuFbnIm_0024gdNDLrA_003D(_0023_003Dz9jrlnWk_003D, new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(Convert.ToInt32(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D())), _0023_003Dztgqm2r4_003D);
			}
		}
		if (_0023_003Dz9jrlnWk_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 8 && _0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 8)
		{
			_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D obj = new _0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D();
			obj._0023_003DzBGdDQOw_INWgxm_K091ViE8d5B7H7_X_0024gA2NQZA_003D(((_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzCfXuHVIlFp1X1u2Med2_AL4lzej8EifTBw_003D_003D() % ((_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzCfXuHVIlFp1X1u2Med2_AL4lzej8EifTBw_003D_003D());
			return obj;
		}
		if (_0023_003Dz9jrlnWk_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 19)
		{
			Type underlyingType3 = Enum.GetUnderlyingType(_0023_003Dz9jrlnWk_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D().GetType());
			if (underlyingType3 == typeof(long) || underlyingType3 == typeof(ulong))
			{
				return _0023_003DzaOO3l1fve8hJTUNmqU1uOQt4IxMJysbh6sK1eeu_6FMJ(new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(Convert.ToInt64(_0023_003Dz9jrlnWk_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D())), _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D);
			}
			return _0023_003DzaOO3l1fve8hJTUNmqU1uOQt4IxMJysbh6sK1eeu_6FMJ(new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(Convert.ToInt32(_0023_003Dz9jrlnWk_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D())), _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D);
		}
		throw new InvalidOperationException();
	}

	private static bool _0023_003DzbIhMMCpTAtqwcE7EXAzYf_SJEcWXsuXv_0024Q_003D_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		bool result = false;
		switch (_0023_003Dz9jrlnWk_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D())
		{
		case 1:
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 19)
			{
				return _0023_003DzbIhMMCpTAtqwcE7EXAzYf_SJEcWXsuXv_0024Q_003D_003D(_0023_003Dz9jrlnWk_003D, new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(Convert.ToInt32(((_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D())));
			}
			result = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D() < ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
			break;
		case 13:
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 19)
			{
				return _0023_003DzbIhMMCpTAtqwcE7EXAzYf_SJEcWXsuXv_0024Q_003D_003D(_0023_003Dz9jrlnWk_003D, new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(Convert.ToInt64(((_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D())));
			}
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 1)
			{
				return _0023_003DzbIhMMCpTAtqwcE7EXAzYf_SJEcWXsuXv_0024Q_003D_003D(_0023_003Dz9jrlnWk_003D, new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D()));
			}
			result = ((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG() < ((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG();
			break;
		case 19:
			return _0023_003DzbIhMMCpTAtqwcE7EXAzYf_SJEcWXsuXv_0024Q_003D_003D(new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(Convert.ToInt64(((_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D())), _0023_003DzBxpHhQ0_003D);
		case 8:
			result = ((_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzCfXuHVIlFp1X1u2Med2_AL4lzej8EifTBw_003D_003D() < ((_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzCfXuHVIlFp1X1u2Med2_AL4lzej8EifTBw_003D_003D();
			break;
		}
		return result;
	}

	private MethodBase _0023_003DzgrzShoUn5WrtDo5QhPho_W7AjqLuUn6aP8TqLvU_003D(_0023_003Dq9cxJfzt6tx3_00245xLDM_0024HAnunU7Xy_WBpJRmOB2qxzSUo_003D _0023_003Dz9jrlnWk_003D)
	{
		Type type = _0023_003Dz9_Z5EhGFT4yzpTmOPYjfhZOeNABFeUtCmZ_KeWA_003D(_0023_003Dz9jrlnWk_003D._0023_003Dz0VK_0024n5_OzquTMOL7Fv6k0GgpbJ9ODTKP_00243Gx1Ns_003D()._0023_003DztkhwzVeVIldXjs1hyonqsqcuOAEF(), _0023_003DzBxpHhQ0_003D: false);
		BindingFlags bindingAttr = _0023_003DzuaMQqJs9btKMSh09c00zb_0024YVVB_00247VcQqiw_003D_003D(_0023_003Dz9jrlnWk_003D._0023_003DzvLFmklk_0024domRMi1KKFXkHqc_003D());
		Type[] array = null;
		_0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D[] array2 = _0023_003Dz9jrlnWk_003D._0023_003Dz5SLJKaXSSdFcGzANZ5mlfVM8CIKqSp8P5R3lEWI_003D();
		if (array2 != null)
		{
			array = new Type[array2.Length];
			for (int i = 0; i < array.Length; i++)
			{
				_0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D _0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D2 = array2[i];
				if (_0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D2 != null)
				{
					array[i] = _0023_003Dz9_Z5EhGFT4yzpTmOPYjfhZOeNABFeUtCmZ_KeWA_003D(_0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D2._0023_003DztkhwzVeVIldXjs1hyonqsqcuOAEF(), _0023_003DzBxpHhQ0_003D: true);
				}
			}
		}
		MemberInfo[] member = type.GetMember(_0023_003Dz9jrlnWk_003D._0023_003DzTO06eh4ctVi8FQHL1ybi_00249JNJanF(), MemberTypes.Method, bindingAttr);
		MethodInfo methodInfo = null;
		int num = -1;
		MemberInfo[] array3 = member;
		for (int j = 0; j < array3.Length; j++)
		{
			MethodInfo methodInfo2 = (MethodInfo)array3[j];
			if (_0023_003DzBO3Ilbfhn_0024RPcT20FNuhSKE_003D(methodInfo2, _0023_003Dz9jrlnWk_003D, array, out var num2) && num2 > num)
			{
				methodInfo = methodInfo2;
				num = num2;
			}
		}
		if (methodInfo == null)
		{
			throw new Exception(string.Format(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564314212), type.Name, _0023_003Dz9jrlnWk_003D._0023_003DzTO06eh4ctVi8FQHL1ybi_00249JNJanF()));
		}
		return methodInfo.MakeGenericMethod(array);
	}

	private void _0023_003DzF6lNdUgp_0024EXaHsYbpiKsz5x9aQWSK_0024MB_mvoQ7s_003D(object _0023_003Dz9jrlnWk_003D, uint _0023_003DzBxpHhQ0_003D)
	{
		bool flag = _0023_003Dz9jrlnWk_003D != null;
		_0023_003DzNl32EAo_003D = _0023_003Dz9jrlnWk_003D;
		if (flag)
		{
			this.m__0023_003Dz9jrlnWk_003D.Clear();
		}
		this.m__0023_003Dz2X8kE24_003D = flag;
		if (!flag)
		{
			this.m__0023_003Dz9jrlnWk_003D.Push(new _0023_003Dz3iPku7s_003D(_0023_003DzBxpHhQ0_003D));
		}
		_0023_003Dqih1RKs7Osg5_0024Rd9gDhKEdqdrC8qgJFChg_7i1V8hZwk_003D[] array = _0023_003DzCR5Jlyc_003D;
		foreach (_0023_003Dqih1RKs7Osg5_0024Rd9gDhKEdqdrC8qgJFChg_7i1V8hZwk_003D _0023_003Dqih1RKs7Osg5_0024Rd9gDhKEdqdrC8qgJFChg_7i1V8hZwk_003D2 in array)
		{
			if (!_0023_003DzOupOLyU8m7hDuE5_JiPQQJw_003D(this.m__0023_003DzAndD6oU_003D, _0023_003Dqih1RKs7Osg5_0024Rd9gDhKEdqdrC8qgJFChg_7i1V8hZwk_003D2._0023_003DzcmYAH1_0024kgTZIsm37rJAwkR2aPGOw(), _0023_003Dqih1RKs7Osg5_0024Rd9gDhKEdqdrC8qgJFChg_7i1V8hZwk_003D2._0023_003DzbCVHSLHjVVzIDZuBMIVB_Phq0P8i_wdHnQ_003D_003D()))
			{
				continue;
			}
			switch (_0023_003Dqih1RKs7Osg5_0024Rd9gDhKEdqdrC8qgJFChg_7i1V8hZwk_003D2._0023_003Dz4kLSwCqDauEGKVqjsSb61jmmMRf_BJ2wJIwVuuzG6fht())
			{
			case 2:
				if (flag || !_0023_003DzOupOLyU8m7hDuE5_JiPQQJw_003D(_0023_003DzBxpHhQ0_003D, _0023_003Dqih1RKs7Osg5_0024Rd9gDhKEdqdrC8qgJFChg_7i1V8hZwk_003D2._0023_003DzcmYAH1_0024kgTZIsm37rJAwkR2aPGOw(), _0023_003Dqih1RKs7Osg5_0024Rd9gDhKEdqdrC8qgJFChg_7i1V8hZwk_003D2._0023_003DzbCVHSLHjVVzIDZuBMIVB_Phq0P8i_wdHnQ_003D_003D()))
				{
					this.m__0023_003Dz9jrlnWk_003D.Push(new _0023_003Dz3iPku7s_003D(_0023_003Dqih1RKs7Osg5_0024Rd9gDhKEdqdrC8qgJFChg_7i1V8hZwk_003D2._0023_003DzEYtNjSAyA7wXzOYKkA_003D_003D()));
				}
				break;
			case 1:
				if (flag)
				{
					this.m__0023_003Dz9jrlnWk_003D.Push(new _0023_003Dz3iPku7s_003D(_0023_003Dqih1RKs7Osg5_0024Rd9gDhKEdqdrC8qgJFChg_7i1V8hZwk_003D2._0023_003DzEYtNjSAyA7wXzOYKkA_003D_003D()));
				}
				break;
			case 4:
				if (flag)
				{
					this.m__0023_003Dz9jrlnWk_003D.Push(new _0023_003Dz3iPku7s_003D(_0023_003Dqih1RKs7Osg5_0024Rd9gDhKEdqdrC8qgJFChg_7i1V8hZwk_003D2._0023_003DzfWFaX_jEOyxjQsly0r5O8aw_003D(), _0023_003Dz9jrlnWk_003D));
				}
				break;
			case 0:
				if (flag)
				{
					Type type = _0023_003Dz9jrlnWk_003D.GetType();
					Type type2 = _0023_003Dz9_Z5EhGFT4yzpTmOPYjfhZOeNABFeUtCmZ_KeWA_003D(_0023_003Dqih1RKs7Osg5_0024Rd9gDhKEdqdrC8qgJFChg_7i1V8hZwk_003D2._0023_003Dz0kgcBG69CE_0024y8LF08xwLwGlxSxC0yqFBYw_003D_003D(), _0023_003DzBxpHhQ0_003D: true);
					if (type == type2 || type.IsSubclassOf(type2))
					{
						this.m__0023_003Dz9jrlnWk_003D.Push(new _0023_003Dz3iPku7s_003D(_0023_003Dqih1RKs7Osg5_0024Rd9gDhKEdqdrC8qgJFChg_7i1V8hZwk_003D2._0023_003DzEYtNjSAyA7wXzOYKkA_003D_003D(), _0023_003Dz9jrlnWk_003D));
						this.m__0023_003Dz2X8kE24_003D = false;
					}
				}
				break;
			}
		}
		_0023_003DzTSnMxIcnPTKi_0024SHfx9IetV0mvE0F();
	}

	private static bool _0023_003DzXwxIxg08b8kr_hRdUaEBBU7_02q7(object _0023_003Dz9jrlnWk_003D)
	{
		return RemotingServices.IsTransparentProxy(_0023_003Dz9jrlnWk_003D);
	}

	private static void _0023_003Dz41HlMqtoPgA69z9hB_0024LN1aPywwtrdqrNKg_003D_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzGDuTOpKXFiuPe7G4kruEtPUIgmVeEuqxuw_003D_003D(_0023_003Dz9jrlnWk_003D: true);
	}

	private static void _0023_003DzCT6ghv51tVaY_l_00247nZLtms_Db4WWC7ddHQ_003D_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dq9cxJfzt6tx3_00245xLDM_0024HAnrEHrErdbG4Q2r8aUaxhhjk_003D _0023_003Dq9cxJfzt6tx3_00245xLDM_0024HAnrEHrErdbG4Q2r8aUaxhhjk_003D2 = _0023_003DzPh_0024mk5GoEaUtEvshztgcA9SPyTYC(_0023_003Dz9jrlnWk_003D);
		_0023_003Dq6tS8rMV1rGswJPasZDHd76XTcVlfwQMkS5tB1TusLXU_003D _0023_003Dq6tS8rMV1rGswJPasZDHd76XTcVlfwQMkS5tB1TusLXU_003D2 = _0023_003Dz9jrlnWk_003D._0023_003DzLi0XoCY_003D._0023_003Dzf_kC_0024hpTUTdHx7uANBVIZvPU6fFbivFk0g_003D_003D();
		long num = _0023_003Dz9jrlnWk_003D._0023_003DzWcPCdsp22a3yYh4GeH8s_0024I8_003D();
		byte[] array = new _0023_003DqiuPtUBEOXz5ixdMRvtXgU5IT5LVA5oiMhmi3Fees6ng_003D(_0023_003Dq9cxJfzt6tx3_00245xLDM_0024HAnrEHrErdbG4Q2r8aUaxhhjk_003D2._0023_003Dz1qfHC3tVjZZJXiu_0024ys4KOidUAg0LkOs9mqQ5_0024NM3aHVI4gI_F0bGt9Us7tIHYyexPO4GU4kmT7TUUnqKpw_003D_003D(), _0023_003Dq9cxJfzt6tx3_00245xLDM_0024HAnrEHrErdbG4Q2r8aUaxhhjk_003D2._0023_003DzVQEs7QGAKxub_qqbfbOV6bNdQXNiHfZxKtrqeRXPqyPrOtTFXkB7AUCFkY2R_0024J7t4jpvXTdvtRIh_0024ZHw_0024QjCUcQ_003D())._0023_003DzDOPeMXI1OjHdm9Jn7PhQ_0024KMKrDz8(_0023_003Dq6tS8rMV1rGswJPasZDHd76XTcVlfwQMkS5tB1TusLXU_003D2, _0023_003Dq9cxJfzt6tx3_00245xLDM_0024HAnrEHrErdbG4Q2r8aUaxhhjk_003D2);
		_0023_003DzbSmUaeo_003D _0023_003DzbSmUaeo_003D2 = new _0023_003DzbSmUaeo_003D
		{
			_0023_003Dz9jrlnWk_003D = _0023_003Dq9cxJfzt6tx3_00245xLDM_0024HAnrEHrErdbG4Q2r8aUaxhhjk_003D2,
			_0023_003DzzKDx05I_003D = num
		};
		_0023_003Dq9cxJfzt6tx3_00245xLDM_0024HAnrEHrErdbG4Q2r8aUaxhhjk_003D2._0023_003DzFWa94yaz1N_0024HGV6t8Mxpk_IIJH8lL8tDFpFFpoc_003D(_0023_003Dqy79GaFqXfJyGRxADW8SzoS_QgCk0_0024_0024Ut2TwY6OCHt3c_003D._0023_003DzoJTaTomf7RYLavkod89ufvU_003D(array.Length) - array.Length);
		_0023_003DzbSmUaeo_003D2._0023_003DzBxpHhQ0_003D = new _0023_003DqSrxlws3SuprWxrjyHO1juxJFrTNvlF8gj_KAkF067yA_003D(_0023_003DzbSmUaeo_003D2._0023_003Dztgqm2r4_003D = new _0023_003DqtFN_00241TjdaenuCmn9GBmqpoZ3gp2tHyBL0X9WMKdAUQk_003D(array, 0, array.Length, _0023_003DzzKDx05I_003D: false));
		_0023_003Dz9jrlnWk_003D._0023_003DzFbIBOUZukUTRt6X7TpE_uAdTdeMf().Push(_0023_003DzbSmUaeo_003D2);
		_0023_003Dz9jrlnWk_003D._0023_003DzbubspJfKxb0WjXbENdWdGRpLC4D3_0024Y9wrJukd1A_003D(_0023_003DzbSmUaeo_003D2);
	}

	private static void _0023_003DzpmHiMFEOyBXIo0x2tgGuhIBmxBqp(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003Dzl01rdMbhKWqXEDpjHctwRZgIgliJDTg7bQ_003D_003D(0);
	}

	private static void _0023_003DzjCBcg0fghu2E_9ez98qDdz8Z0rfU(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003Dzy4D_00248buHMHsvaKDXIg_003D_003D(4);
	}

	private static void _0023_003DzLR9Qm2hgUReU_0024YBV00z8gJw_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzwbI83bfoaDmYaZBDzj4leqo_003D(2);
	}

	private static void _0023_003DzftSUJzemyLDw1PreLnYGJc8_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DztKL1iK5LvFaLq_0024Salhy_v0MVryh8FAXmFefkbvo_003D();
	}

	private string _0023_003DzxW_0024wA_o40UkoRPgQw4t_0024_wZZnQl5dcP5DiFZrswScyOP(int _0023_003Dz9jrlnWk_003D)
	{
		lock (_0023_003DzZpkUTwY_003D)
		{
			bool flag = true;
			if (flag && _0023_003DzZpkUTwY_003D.TryGetValue(_0023_003Dz9jrlnWk_003D, out var value))
			{
				return (string)value;
			}
			_0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D _0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D2 = _0023_003Dz_kQ6vjzn2xXdxKzdPsJwstuDR14y(_0023_003Dz9jrlnWk_003D);
			if (_0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D2._0023_003DzwH8K7lD_0024cC3gY_RIDCO_Bu8Tp6tgtXa0TA_003D_003D() == 0)
			{
				return this.m__0023_003DzJ6W8874_003D.ResolveString(_0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D2._0023_003DztkhwzVeVIldXjs1hyonqsqcuOAEF());
			}
			string text = ((_0023_003DqP_3FowpRje_0024k54W1SNyQv_0024mF0yo2MyKxXDGfz_0024mVD5o_003D)_0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D2._0023_003DzMDpHhtfRNQDKXWsFcSVSbdd3Ewg6())._0023_003DztHap46gjrtg7S2RrBsVvARySXsWRn1rSaw_003D_003D();
			if (flag)
			{
				_0023_003DzZpkUTwY_003D.Add(_0023_003Dz9jrlnWk_003D, text);
			}
			return text;
		}
	}

	private _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dz7cls5OZUxwV_0024XPFgwwCtM3Ng67uqnWekGg_003D_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		if (_0023_003Dz9jrlnWk_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 1)
		{
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 1)
			{
				int num = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
				int num2 = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
				return new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(num ^ num2);
			}
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 19)
			{
				int num3 = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
				Type underlyingType = Enum.GetUnderlyingType(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D().GetType());
				if (underlyingType == typeof(long) || underlyingType == typeof(ulong))
				{
					long num4 = Convert.ToInt64(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D());
					return new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(num3 ^ num4);
				}
				int num5 = Convert.ToInt32(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D());
				return new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(num3 ^ num5);
			}
		}
		if (_0023_003Dz9jrlnWk_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 13)
		{
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 13)
			{
				long num6 = ((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG();
				long num7 = ((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG();
				return new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(num6 ^ num7);
			}
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 19)
			{
				int num8 = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
				long num9 = Convert.ToInt64(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D());
				return new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(num8 ^ num9);
			}
		}
		if (_0023_003Dz9jrlnWk_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 19)
		{
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 1)
			{
				int num10 = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
				Type underlyingType2 = Enum.GetUnderlyingType(_0023_003Dz9jrlnWk_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D().GetType());
				if (underlyingType2 == typeof(long) || underlyingType2 == typeof(ulong))
				{
					return new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(Convert.ToInt64(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D()) ^ num10);
				}
				return new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(Convert.ToInt32(_0023_003Dz9jrlnWk_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D()) ^ num10);
			}
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 13)
			{
				long num11 = Convert.ToInt64(_0023_003Dz9jrlnWk_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D());
				long num12 = ((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG();
				return new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(num11 ^ num12);
			}
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 19)
			{
				Type underlyingType3 = Enum.GetUnderlyingType(_0023_003Dz9jrlnWk_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D().GetType());
				Type underlyingType4 = Enum.GetUnderlyingType(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D().GetType());
				if (underlyingType3 == typeof(long) || underlyingType3 == typeof(ulong) || underlyingType4 == typeof(long) || underlyingType4 == typeof(ulong))
				{
					long num13 = Convert.ToInt64(_0023_003Dz9jrlnWk_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D());
					long num14 = Convert.ToInt64(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D());
					return new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(num13 ^ num14);
				}
				int num15 = Convert.ToInt32(_0023_003Dz9jrlnWk_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D());
				int num16 = Convert.ToInt32(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D());
				return new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(num15 ^ num16);
			}
		}
		throw new InvalidOperationException();
	}

	private void _0023_003DztKL1iK5LvFaLq_0024Salhy_v0MVryh8FAXmFefkbvo_003D()
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		_0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D _0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D2 = (_0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D)_0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		_0023_003DzlLFsRbFCVJXLxNmd_0024gDP8S8_003D(_0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2);
	}

	private void _0023_003Dz6QIX6pdi7W0E7LFA_PlLav8_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iyaP4iT3cOdFPnt_Mjubq4RU_003D _0023_003Dz9jrlnWk_003D)
	{
		_0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D _0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D2 = _0023_003Dz_kQ6vjzn2xXdxKzdPsJwstuDR14y(_0023_003Dz9jrlnWk_003D._0023_003DzOE5bImQrSCwqDuU_mSqLA81Oej_ueFlDGA_003D_003D());
		MethodBase methodBase = _0023_003DzuQitVVfPXhnVfEemX_NzMcY_riCF0mqY_0024dIcN_0024w_003D(_0023_003Dz9jrlnWk_003D._0023_003DzOE5bImQrSCwqDuU_mSqLA81Oej_ueFlDGA_003D_003D(), _0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D2);
		int num = _0023_003Dz9jrlnWk_003D._0023_003Dz6SQlVJh52wgjviTDOQQtVdXC1YF0PhBJ9bqJWMQ_003D();
		bool flag = (num & 0x40000000) != 0;
		num &= -1073741825;
		Type[] array = _0023_003DzS5oUG4s_003D;
		Type[] array2 = this.m__0023_003DzzKDx05I_003D;
		try
		{
			_0023_003DzS5oUG4s_003D = ((methodBase is ConstructorInfo) ? null : methodBase.GetGenericArguments());
			this.m__0023_003DzzKDx05I_003D = methodBase.DeclaringType.GetGenericArguments();
			_0023_003DzqsLd2orT176bfBS85vdKAL2yi5EJ(num, _0023_003DzS5oUG4s_003D, this.m__0023_003DzzKDx05I_003D, flag);
		}
		finally
		{
			_0023_003DzS5oUG4s_003D = array;
			this.m__0023_003DzzKDx05I_003D = array2;
		}
	}

	private static void _0023_003Dz6PhWodQoj4E3Ru7ttr9WZWIeypje7LAOIRa3FOw_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzQQadI1un9jbZYMS7HdWcDB_Om0ngXN8ke3zjToc_003D(((_0023_003DqJFdrGiwz1aJICVkSTb_0024Zkh7zAYa9iZm47EqlnjrFUg4_003D)_0023_003DzBxpHhQ0_003D)._0023_003Dzi58Fb_0024k5T0u9_0024uYc9Q_003D_003D());
	}

	private static byte[] _0023_003Dzm9G22wIrA7yco991rZwEWJjvF94Ddh0voT425Uw_003D(_0023_003DqSrxlws3SuprWxrjyHO1juxJFrTNvlF8gj_KAkF067yA_003D _0023_003Dz9jrlnWk_003D)
	{
		int num = _0023_003Dz9jrlnWk_003D._0023_003DzzWp83NqubJCg0KBvRVdJ1Clh9XOWlHor0w_003D_003D();
		byte[] result = new byte[num];
		_0023_003Dz9jrlnWk_003D._0023_003Dz63pnmtU9eOqD0MuP96o85H1qyebc1tgnLg_003D_003D(result, 0, num);
		return result;
	}

	private static void _0023_003Dzvo6hfr7_0024ypEN12YjSjK2aH6vSznt(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzH5ozr5LVbpuoOMs7OGq0_HiG1jqsa5wf1w_003D_003D(_0023_003Dz9jrlnWk_003D: false);
	}

	private bool _0023_003DziN43F1gJ5_kxdvp9QNFrCD8_003D(MethodBase _0023_003Dz9jrlnWk_003D)
	{
		if (!_0023_003Dz9jrlnWk_003D.IsVirtual)
		{
			return false;
		}
		if (_0023_003Dz9_Z5EhGFT4yzpTmOPYjfhZOeNABFeUtCmZ_KeWA_003D(m__0023_003DzaTyQZ6E_003D._0023_003DzUaXoJXQwrrbCr0Kl7wUIRwaCDGvQifXoCg_003D_003D(), _0023_003DzBxpHhQ0_003D: true).IsSubclassOf(_0023_003Dz9jrlnWk_003D.DeclaringType))
		{
			return true;
		}
		return false;
	}

	private static void _0023_003DzcYN5dyE_l5hfzBnK_2CtBtFgbDBbEwpClA_003D_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3 = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		_0023_003Dz9jrlnWk_003D._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(_0023_003Dz9jrlnWk_003D._0023_003DzgrTDWpgS75NbjHA0liPooJUwgItpj10tYwGQQMc_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2));
	}

	private void _0023_003DzGDuTOpKXFiuPe7G4kruEtPUIgmVeEuqxuw_003D_003D(bool _0023_003Dz9jrlnWk_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		bool flag = IntPtr.Size == 4;
		IntPtr intPtr;
		switch (_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D())
		{
		case 1:
		{
			int value = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
			intPtr = ((!_0023_003Dz9jrlnWk_003D) ? new IntPtr(value) : new IntPtr(value));
			break;
		}
		case 13:
		{
			long num = ((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG();
			intPtr = ((!flag) ? ((!_0023_003Dz9jrlnWk_003D) ? new IntPtr(num) : new IntPtr(num)) : ((!_0023_003Dz9jrlnWk_003D) ? new IntPtr((int)num) : new IntPtr(checked((int)num))));
			break;
		}
		case 8:
		{
			double num2 = ((_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzCfXuHVIlFp1X1u2Med2_AL4lzej8EifTBw_003D_003D();
			intPtr = ((!flag) ? ((!_0023_003Dz9jrlnWk_003D) ? new IntPtr((long)num2) : new IntPtr(checked((long)num2))) : ((!_0023_003Dz9jrlnWk_003D) ? new IntPtr((int)num2) : new IntPtr(checked((int)num2))));
			break;
		}
		case 19:
			intPtr = ((!_0023_003Dz9jrlnWk_003D) ? new IntPtr((long)Convert.ToUInt64(((_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D())) : new IntPtr(checked((long)Convert.ToUInt64(((_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D()))));
			break;
		default:
			throw new InvalidOperationException();
		}
		_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D obj = new _0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D();
		obj._0023_003DzXFR8k7cM8wiYjjnXjPEa5idSBqAKmHeRH0GHZG0_003D(intPtr);
		_0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(obj);
	}

	private static _0023_003Dqih1RKs7Osg5_0024Rd9gDhKEdqdrC8qgJFChg_7i1V8hZwk_003D[] _0023_003Dz9olXx7j85z1rFKzgjy3B_UQXR8k_0024SNr8oepKn80_003D(_0023_003DqSrxlws3SuprWxrjyHO1juxJFrTNvlF8gj_KAkF067yA_003D _0023_003Dz9jrlnWk_003D)
	{
		int num = _0023_003Dz9jrlnWk_003D._0023_003DzfyBJnRlgDbP3pAMbTWEdJKI_003D();
		_0023_003Dqih1RKs7Osg5_0024Rd9gDhKEdqdrC8qgJFChg_7i1V8hZwk_003D[] array = new _0023_003Dqih1RKs7Osg5_0024Rd9gDhKEdqdrC8qgJFChg_7i1V8hZwk_003D[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = _0023_003Dzwx8fQZA5deSOpjgap_G3u7kbKm21A8xhmCDH2_M_003D(_0023_003Dz9jrlnWk_003D);
		}
		return array;
	}

	private static void _0023_003DzIW_Pcryz9M8r_0024k0urLeCK3EDy4iW(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		if (_0023_003DzbIhMMCpTAtqwcE7EXAzYf_SJEcWXsuXv_0024Q_003D_003D(_0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D(), _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2))
		{
			uint num = ((_0023_003DqJFdrGiwz1aJICVkSTb_0024Zko9aS6iSwDcZdo9VS4Dkh_0024s_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzxGjrL4iuhvogLPGFSdnVXdPvbKxem9P4HA_003D_003D();
			_0023_003Dz9jrlnWk_003D._0023_003Dz9r__0024YTGu_0024iN2qFjqe6k1t7s_003D(num);
		}
	}

	private static void _0023_003DzqtR5mt09tjjlHraIzHt9xqBa1621FTChhtbcrB8_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzUbKftaPsoH4C3o3km5CXFp43OkI85ZTJMKNMSEuJ_LI5(typeof(sbyte));
	}

	private static void _0023_003DzOyLDT_0024AW0dIZqIskxAdghwfulh2htRAYhKTncoA_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		throw new NotSupportedException(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564315181));
	}

	private static void _0023_003Dzjb65nHC5UexrCNymxZCB5UfbLDhZ(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzqVyXuYAwQKQpRX1kaiNBtsUGXia0KVUABA_003D_003D(_0023_003Dz9jrlnWk_003D: false);
	}

	private static void _0023_003DzhabqZwpBFGzhFL32cCvHTYq7TaT_0024(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		int num = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
		Type elementType = _0023_003Dz9jrlnWk_003D._0023_003Dz9_Z5EhGFT4yzpTmOPYjfhZOeNABFeUtCmZ_KeWA_003D(num, _0023_003DzBxpHhQ0_003D: true);
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		int length;
		if (_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 is _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D2)
		{
			length = _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D2._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
		}
		else if (_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 is _0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D _0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D2)
		{
			length = _0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D2._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk().ToInt32();
		}
		else
		{
			if (!(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 is _0023_003DqVEj3J19zkgEyU6VFymBz6riyi6CxZMJEjhA0KZ2nLKw_003D _0023_003DqVEj3J19zkgEyU6VFymBz6riyi6CxZMJEjhA0KZ2nLKw_003D2))
			{
				throw new Exception();
			}
			length = (int)_0023_003DqVEj3J19zkgEyU6VFymBz6riyi6CxZMJEjhA0KZ2nLKw_003D2._0023_003DzZlwwYywinAe9h_2ss_0024Wn4RsajDr79HfGCg_003D_003D().ToUInt32();
		}
		Array array = Array.CreateInstance(elementType, length);
		_0023_003DqJK_4DNDu0bpSDsm8DAlJ97YodsmbnVu7wOTilEHAt2g_003D obj = new _0023_003DqJK_4DNDu0bpSDsm8DAlJ97YodsmbnVu7wOTilEHAt2g_003D();
		obj._0023_003Dzt_0024bTK2Fil3XWqMOVKJBmnX_0024psQCLTyoahp9FMe4_003D(array);
		_0023_003Dz9jrlnWk_003D._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(obj);
	}

	private static void _0023_003Dz1fXExLnpaU4PVqVjjCv3oM8kYT8sTwjWk9C_0024jfw_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzLMJxSSXveUKWgX7ByprFEtw_003D(typeof(uint));
	}

	private static void _0023_003DzJmRqDr6VZQnHGOQJVEpAGWzkds62B3Mk_0024A_003D_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003Dza4nGArD8ohAiv3Oef3SUUBiljhSza0DBmw_003D_003D(_0023_003DzBxpHhQ0_003D);
	}

	private static void _0023_003Dz8Maz3vg_00248Lz0Xl4boZHPgro_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003Dzy4D_00248buHMHsvaKDXIg_003D_003D(2);
	}

	private static void _0023_003DzTj2fTzR_0024_0024t7rnyLoyofSfYo_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzriXIwLFCuwD1GZVAt_00248x4do_003D(_0023_003Dz9jrlnWk_003D: true, _0023_003DzBxpHhQ0_003D: true);
	}

	private static Exception _0023_003DzfE30YNyI_f3LeZRtY0ALj480DwZAzmMJ5y_0024sIbPs4W2n(string _0023_003Dz9jrlnWk_003D, string _0023_003DzBxpHhQ0_003D)
	{
		return new MethodAccessException(_0023_003DzD69sXm7cB8YG4UIz48VVGKMyN5FSSLzspMkf4r0_003D(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313967) + _0023_003Dz9jrlnWk_003D + _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313931), _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313754) + _0023_003DzBxpHhQ0_003D + _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313931)));
	}

	private static _0023_003Dz2X8kE24_003D _0023_003DzMRS7NQzOcE7aSPN_bE8IttOKtzNqQ2biGA_003D_003D(_0023_003DzJ6W8874_003D _0023_003Dz9jrlnWk_003D)
	{
		_0023_003Dz2X8kE24_003D value;
		lock (_0023_003DzG7m2nd8_003D)
		{
			_0023_003DzG7m2nd8_003D.TryGetValue(_0023_003Dz9jrlnWk_003D, out value);
		}
		if (value != null)
		{
			return value;
		}
		MethodBase key = _0023_003Dz9jrlnWk_003D._0023_003Dz8r3pP05sQtMBnZwnEKVmjskXZMs_C_s88hrkb1A_003D();
		lock (_0023_003Dz5bot44w_003D)
		{
			while (_0023_003Dz5bot44w_003D.ContainsKey(key))
			{
				Monitor.Wait(_0023_003Dz5bot44w_003D);
			}
			_0023_003Dz5bot44w_003D[key] = null;
		}
		try
		{
			lock (_0023_003DzG7m2nd8_003D)
			{
				_0023_003DzG7m2nd8_003D.TryGetValue(_0023_003Dz9jrlnWk_003D, out value);
			}
			if (value == null)
			{
				value = _0023_003DzP9DYLkLIEF_53eX_kDzC0nc9_0024AzF(key, _0023_003Dz9jrlnWk_003D._0023_003DzsubU6xBHatCokP4_0024EtWs5qiZU3JrGKJwiJGkVSQ_003D());
				lock (_0023_003DzG7m2nd8_003D)
				{
					_0023_003DzG7m2nd8_003D[_0023_003Dz9jrlnWk_003D] = value;
				}
			}
			return value;
		}
		finally
		{
			lock (_0023_003Dz5bot44w_003D)
			{
				_0023_003Dz5bot44w_003D.Remove(key);
				Monitor.PulseAll(_0023_003Dz5bot44w_003D);
			}
		}
	}

	private static void _0023_003DzCpHI4UrNIV2gVXOU21aAoulfXBvck1cAR2_00248cAU_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		throw new NotSupportedException(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564314321));
	}

	private static void _0023_003DzJ7hfXBj4HBlZoLgBlJ9Au0QQYr07Fs8oGg_003D_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		_0023_003Dz9jrlnWk_003D._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(checked(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() switch
		{
			1 => (sbyte)(uint)((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D(), 
			13 => (sbyte)(ulong)((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG(), 
			19 => (sbyte)Convert.ToUInt64(((_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D()), 
			8 => (sbyte)((_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzCfXuHVIlFp1X1u2Med2_AL4lzej8EifTBw_003D_003D(), 
			0 => (IntPtr.Size != 4) ? ((sbyte)(ulong)(long)((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk()) : ((sbyte)(uint)(int)((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk()), 
			_ => throw new InvalidOperationException(), 
		})));
	}

	private void _0023_003Dz3Kd3rvERK8HcEu6iFYdwh0o_003D(MethodBase _0023_003Dz9jrlnWk_003D, bool _0023_003DzBxpHhQ0_003D)
	{
		bool flag = !_0023_003DzBxpHhQ0_003D && _0023_003DziN43F1gJ5_kxdvp9QNFrCD8_003D(_0023_003Dz9jrlnWk_003D);
		if (flag && _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D._0023_003DzzKDx05I_003D._0023_003Dz9jrlnWk_003D)
		{
			_0023_003Dz9jrlnWk_003D = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D._0023_003DziiEv3wQ_003D._0023_003Dz7RMo0OLCQrBAbI7SvykASwg04DNOMpNTqA_003D_003D(this, m__0023_003DzaTyQZ6E_003D, _0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D);
		}
		ParameterInfo[] parameters = _0023_003Dz9jrlnWk_003D.GetParameters();
		int num = parameters.Length;
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D[] array = new _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D[num];
		object[] array2 = new object[num];
		_0023_003Dztgqm2r4_003D _0023_003Dztgqm2r4_003D2 = default(_0023_003Dztgqm2r4_003D);
		try
		{
			_0023_003DzdjM_2jv3RJCvz2e7G8N4hr_tmbjLldgOzkQHpdc_003D(ref _0023_003Dztgqm2r4_003D2, _0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D);
			for (int num2 = num - 1; num2 >= 0; num2--)
			{
				_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = (array[num2] = _0023_003DzrQFXD5oP9hinX0g4gA_003D_003D());
				if (_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 is _0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D _0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D2)
				{
					_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003DzcyfMbnJemFaR1U9IYqWp0cPmk80NlqUX5LErUtBcWaeU(_0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D2);
				}
				if (_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003Dz55cfCv82_0024cfWUBDPYd5Wu_0024c_003D() != null)
				{
					_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D._0023_003DzCysyOfnrUQB5WqShWAIL_0024X4XGCe9eW67eVeg6HY_003D(null, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003Dz55cfCv82_0024cfWUBDPYd5Wu_0024c_003D())._0023_003DzAPlrN6aYwAg5F1LxHYbv_0024wOBB_0024afgbz6XKGgvF_0024QaP3F7Nvwy8DGE80Q1m63nNv21_00240QxzxHCeC2PtE3mw_003D_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2);
				}
				_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3 = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D._0023_003DzCysyOfnrUQB5WqShWAIL_0024X4XGCe9eW67eVeg6HY_003D(null, parameters[num2].ParameterType)._0023_003DzAPlrN6aYwAg5F1LxHYbv_0024wOBB_0024afgbz6XKGgvF_0024QaP3F7Nvwy8DGE80Q1m63nNv21_00240QxzxHCeC2PtE3mw_003D_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2);
				array2[num2] = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D();
			}
			_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D4 = null;
			if (!_0023_003Dz9jrlnWk_003D.IsStatic)
			{
				_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D4 = _0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
				if (_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D4 != null && _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D4._0023_003Dz55cfCv82_0024cfWUBDPYd5Wu_0024c_003D() != null)
				{
					_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D4 = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D._0023_003DzCysyOfnrUQB5WqShWAIL_0024X4XGCe9eW67eVeg6HY_003D(null, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D4._0023_003Dz55cfCv82_0024cfWUBDPYd5Wu_0024c_003D())._0023_003DzAPlrN6aYwAg5F1LxHYbv_0024wOBB_0024afgbz6XKGgvF_0024QaP3F7Nvwy8DGE80Q1m63nNv21_00240QxzxHCeC2PtE3mw_003D_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D4);
				}
			}
			object obj = null;
			object obj2 = null;
			try
			{
				if (_0023_003Dz9jrlnWk_003D.IsConstructor)
				{
					obj = Activator.CreateInstance(_0023_003Dz9jrlnWk_003D.DeclaringType, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, array2, null);
					if (!(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D4 is _0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D))
					{
						throw new InvalidOperationException();
					}
					obj2 = obj;
				}
				else
				{
					if (_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D4 != null)
					{
						_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D5 = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D4;
						if (_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D4 is _0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D _0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D3)
						{
							_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D5 = _0023_003DzcyfMbnJemFaR1U9IYqWp0cPmk80NlqUX5LErUtBcWaeU(_0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D3);
						}
						obj2 = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D5._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D();
					}
					try
					{
						if (!_0023_003DzaFNJdwovGDUQXvp1HBy7CBoOXI_0024BhOGQeoMc54o_003D(_0023_003Dz9jrlnWk_003D, obj2, ref obj, array2))
						{
							if (_0023_003DzBxpHhQ0_003D && !_0023_003Dz9jrlnWk_003D.IsStatic && obj2 == null)
							{
								throw new NullReferenceException();
							}
							if (!_0023_003DzwMu5f4iLu52YPedKYy72lc1yzSdVsEvkWA_003D_003D(_0023_003Dz9jrlnWk_003D, obj2, array, array2, _0023_003DzBxpHhQ0_003D, ref obj))
							{
								MethodBase methodBase = _0023_003Dz9jrlnWk_003D;
								object obj3 = obj2;
								if (flag && !_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D._0023_003DzzKDx05I_003D._0023_003Dz9jrlnWk_003D)
								{
									obj3 = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D._0023_003DzoEGLyuM_003D._0023_003DzvI807xvpFdbQuPiT8AohTOloWLz3k1r_FbUYH7s_003D(obj2, _0023_003Dz9jrlnWk_003D, out var methodInfo);
									methodBase = methodInfo;
								}
								obj = _0023_003DzTtHhYD7wYomyazLD30cjaJao7oFKwWOoYw_003D_003D(methodBase, obj3, array2, _0023_003DzBxpHhQ0_003D);
							}
						}
					}
					catch (TargetInvocationException ex)
					{
						Exception ex2 = ex.InnerException ?? ex;
						_0023_003DzzUdLVh6RcJ0qp5eRPoW5he0ADnSX(ex2);
					}
				}
			}
			finally
			{
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i] is _0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D _0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D4)
					{
						object obj4 = array2[i];
						_0023_003DzlLFsRbFCVJXLxNmd_0024gDP8S8_003D(_0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D4, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D._0023_003DzCysyOfnrUQB5WqShWAIL_0024X4XGCe9eW67eVeg6HY_003D(obj4, null));
					}
				}
				if (obj2 != null && _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D4 is _0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D _0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D5)
				{
					bool flag2 = true;
					if (_0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D5 is _0023_003DqrQPc9rwDL7Fl53_0024M2Pi1fo_0024Ac1BCNKiaW0Mx66Ji04U_003D _0023_003DqrQPc9rwDL7Fl53_0024M2Pi1fo_0024Ac1BCNKiaW0Mx66Ji04U_003D2)
					{
						flag2 = _0023_003Dz2jdafFW3tsTms6grmzBm_0024rs_003D(_0023_003DqrQPc9rwDL7Fl53_0024M2Pi1fo_0024Ac1BCNKiaW0Mx66Ji04U_003D2);
					}
					if (flag2)
					{
						_0023_003DzlLFsRbFCVJXLxNmd_0024gDP8S8_003D(_0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D5, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D._0023_003DzCysyOfnrUQB5WqShWAIL_0024X4XGCe9eW67eVeg6HY_003D(obj2, _0023_003Dz9jrlnWk_003D.DeclaringType));
					}
				}
			}
			MethodInfo methodInfo2 = _0023_003Dz9jrlnWk_003D as MethodInfo;
			if (methodInfo2 != null)
			{
				Type returnType = methodInfo2.ReturnType;
				if (returnType != _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D.m__0023_003Dz9I8ZVlc_003D)
				{
					_0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D._0023_003DzCysyOfnrUQB5WqShWAIL_0024X4XGCe9eW67eVeg6HY_003D(obj, returnType));
				}
			}
		}
		finally
		{
			_0023_003Dzzeh0T_5ueCdEvFtJacmInxtEps6b(ref _0023_003Dztgqm2r4_003D2);
		}
	}

	private _0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D _0023_003Dz_kQ6vjzn2xXdxKzdPsJwstuDR14y(int _0023_003Dz9jrlnWk_003D)
	{
		if (_0023_003DzXlMgCsc_003D == null)
		{
			throw new InvalidOperationException();
		}
		lock (_0023_003DzXlMgCsc_003D._0023_003Dzf_kC_0024hpTUTdHx7uANBVIZvPU6fFbivFk0g_003D_003D())
		{
			_0023_003DzXlMgCsc_003D._0023_003Dzf_kC_0024hpTUTdHx7uANBVIZvPU6fFbivFk0g_003D_003D()._0023_003Dzz5uSZofwQCQyOcEKwfVQmiivZ_0024bgBfg6QfI4mYf6tHIC42rk18fkszOb_ezLTX5YRgaBPKGRm6aQTYVwBg_003D_003D(_0023_003Dz9jrlnWk_003D, 0);
			_0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D _0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D2 = new _0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D();
			_0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D2._0023_003DzNUPIDmrP1jaRVB3WXD3g1PHN53FX(_0023_003DzXlMgCsc_003D._0023_003Dz2DBTqfW51eVHX_0024PiHey2kryLbqPoOZPrpMXUAwQ_003D());
			if (_0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D2._0023_003DzwH8K7lD_0024cC3gY_RIDCO_Bu8Tp6tgtXa0TA_003D_003D() == 0)
			{
				_0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D2._0023_003DzGEIJPAXG3eETFVay0g_003D_003D(_0023_003DzXlMgCsc_003D._0023_003DzzWp83NqubJCg0KBvRVdJ1Clh9XOWlHor0w_003D_003D());
			}
			else
			{
				_0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D2._0023_003Dz9b4O259OubFqTjcfmY8AqRSadh_LZ5zsNEQkWkRHYZb_0024(_0023_003DziDxs0L9vScEgbR1ms3QkFKQvbydZ2UADH_NmxhatHOH8(_0023_003DzXlMgCsc_003D));
			}
			return _0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D2;
		}
	}

	private static void _0023_003Dz2DGxfXufmqIsJ0gBsJhYVja_00246KUQkLNUmA_003D_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003Dz3oHptl2qBd0xU8cwS6UfOo5vVoXBPMMnW5N0aQU_003D(_0023_003DzBxpHhQ0_003D);
	}

	private static _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dzh8LVZLcNsg9yHp4CEcz4UQY5_69b97CEPJJk5wIgUg4q(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D, bool _0023_003Dztgqm2r4_003D, bool _0023_003DzzKDx05I_003D)
	{
		if (!_0023_003DzzKDx05I_003D)
		{
			long num = ((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG();
			long num2 = ((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG();
			long num3 = ((!_0023_003Dztgqm2r4_003D) ? (num + num2) : checked(num + num2));
			return new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(num3);
		}
		ulong num4 = (ulong)((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG();
		ulong num5 = (ulong)((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG();
		ulong num6 = ((!_0023_003Dztgqm2r4_003D) ? (num4 + num5) : checked(num4 + num5));
		return new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D((long)num6);
	}

	private static void _0023_003DzttpxoGAVg8fKQGcood_0024T2KhabVMN(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		throw new NotSupportedException(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564315458));
	}

	private void _0023_003Dz9r__0024YTGu_0024iN2qFjqe6k1t7s_003D(uint _0023_003Dz9jrlnWk_003D)
	{
		_0023_003DzgtUi_7A_003D = _0023_003Dz9jrlnWk_003D;
	}

	private static void _0023_003DzRGkOU14ZCFOGoo0aFECdzAz7GcZuOk7eYg_003D_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzqVyXuYAwQKQpRX1kaiNBtsUGXia0KVUABA_003D_003D(_0023_003Dz9jrlnWk_003D: true);
	}

	private static object _0023_003Dzen6M6suXozc4dDI9Ng_003D_003D(MethodBase _0023_003Dz9jrlnWk_003D, object _0023_003DzBxpHhQ0_003D, object[] _0023_003Dztgqm2r4_003D)
	{
		if (_0023_003Dz9jrlnWk_003D.IsConstructor)
		{
			try
			{
				return Activator.CreateInstance(_0023_003Dz9jrlnWk_003D.DeclaringType, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, _0023_003Dztgqm2r4_003D, null);
			}
			catch (AmbiguousMatchException)
			{
				return ((ConstructorInfo)_0023_003Dz9jrlnWk_003D).Invoke(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, _0023_003Dztgqm2r4_003D, null);
			}
		}
		return _0023_003Dz9jrlnWk_003D.Invoke(_0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D);
	}

	private static void _0023_003Dz20CyYCKwqoCdB4bORj3efb6W4soNgMQe8Q_003D_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		Debugger.Break();
	}

	[Conditional("DEBUG")]
	public static void _0023_003Dz16qsa_0024gLF_vsl9n5ZwMIS6V2JyiP(string _0023_003Dz9jrlnWk_003D)
	{
	}

	private static Dictionary<int, _0023_003DzgqvoyJk_003D> _0023_003DzDVqBRKDrgm58Xj1ZkYn9zEF__0024oHn(_0023_003DqiA1d0doSeLnh_VY97pG2QI49hVABlW155dgxLJzVyPA_003D _0023_003Dz9jrlnWk_003D)
	{
		return new Dictionary<int, _0023_003DzgqvoyJk_003D>(256)
		{
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzgzDbsGk_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzgzDbsGk_003D, _0023_003DzV7VI1wgZICewv2vuP3DRJYOQWeVU)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzrbcT9Ls_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzrbcT9Ls_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)
				{
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003Dz3oHptl2qBd0xU8cwS6UfOo5vVoXBPMMnW5N0aQU_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2);
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzhSDfgZA_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzhSDfgZA_003D, _0023_003DznJnvcr5FjZtj2QM4mFzBVJs7oa4H)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzBxpHhQ0_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzBxpHhQ0_003D, _0023_003DzeVr4hn41cFroA3B5r0VGbTELEaqR3vGXD2C9kIDD92At)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dznx1EMIs_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dznx1EMIs_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)
				{
					int num = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
					Type type = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003Dz9_Z5EhGFT4yzpTmOPYjfhZOeNABFeUtCmZ_KeWA_003D(num, _0023_003DzBxpHhQ0_003D: true);
					long num2 = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003Dz48d1zHJh3TOQKfAMFYN6p1CRbnL4();
					Array array = (Array)_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D()._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D();
					_0023_003DqqAFF17CqR9tmgwcDOoVXDR8oqWCVrzaSDy4kQfwl5ew_003D obj = new _0023_003DqqAFF17CqR9tmgwcDOoVXDR8oqWCVrzaSDy4kQfwl5ew_003D();
					obj._0023_003DzbcQlnnQg_3k7H5qcGzTOz659_0024_m3R_a058Syv7Y_003D(array);
					obj._0023_003Dz_0024WOmwPiJ7UFMYHpG_kOLOeBLqKyQ(type);
					obj._0023_003DzvvMbYezXK0KJ4emHYcURPozP24bememvbg_003D_003D(num2);
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(obj);
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzunTcbyE_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzunTcbyE_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)
				{
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003Dz4aIsGrkxJXsni29jRFACK21EuSDR(_0023_003Dz9jrlnWk_003D: true, _0023_003DzBxpHhQ0_003D: true);
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzWgTBVuo_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzWgTBVuo_003D, _0023_003DzxKTGSmttQqcAqPZPhlmsseI_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dz2X8kE24_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dz2X8kE24_003D, _0023_003DzDoOcTNxHc4njcGcsUb1eAfojWygnWisZEPNTrYU0gdiL)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzVfsoQp4_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzVfsoQp4_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)
				{
					MethodBase methodBase = ((_0023_003DqZOgqBgNtgFzdL0x3JA7LxzDeXh41TKRK3WDZXmMsiIQ_003D)_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D())._0023_003DzV_0024AWvPoawZAhOMF2e6wIwZo_003D();
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003Dz3Kd3rvERK8HcEu6iFYdwh0o_003D(methodBase, _0023_003DzBxpHhQ0_003D: false);
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzlyRtwFg_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzlyRtwFg_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)
				{
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzwbI83bfoaDmYaZBDzj4leqo_003D(0);
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzJyZTmFA_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzJyZTmFA_003D, _0023_003DzmJON0bKjYo1KqM0lvS1MfA_tMjEt)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzGC1SpJk_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzGC1SpJk_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)
				{
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003Dzy9SLKdQoCebcVxNgldItljkdsD8_0024(_0023_003Dz9jrlnWk_003D: true);
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzSInO_Kw_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzSInO_Kw_003D, _0023_003DzbQmKCX4xeHbdtGF_Q3rSkiQ_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzUOnmQQI_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzUOnmQQI_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)
				{
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzLMJxSSXveUKWgX7ByprFEtw_003D(typeof(ushort));
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzUytyK4Q_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzUytyK4Q_003D, delegate
				{
					throw new NotSupportedException(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564315181));
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dz3iPku7s_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dz3iPku7s_003D, _0023_003DzzJsfHuVbCYURsy7mGxn3wECDm6Rx)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzZnEqe_00248_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzZnEqe_00248_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)
				{
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2);
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzbSmUaeo_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzbSmUaeo_003D, _0023_003DzDzC3KkxeaBB4BCAGXXJy7HqoJmTq)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzBgzwwiA_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzBgzwwiA_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D4)
				{
					object obj = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D()._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D();
					long num = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003Dz48d1zHJh3TOQKfAMFYN6p1CRbnL4();
					Array array = (Array)_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D()._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D();
					Type elementType = array.GetType().GetElementType();
					if (elementType == typeof(int))
					{
						_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D._0023_003DzCysyOfnrUQB5WqShWAIL_0024X4XGCe9eW67eVeg6HY_003D(obj, typeof(int));
						((int[])array)[num] = (int)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D();
					}
					else if (elementType == typeof(uint))
					{
						_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3 = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D._0023_003DzCysyOfnrUQB5WqShWAIL_0024X4XGCe9eW67eVeg6HY_003D(obj, typeof(uint));
						((uint[])array)[num] = (uint)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D();
					}
					else if (elementType.IsEnum)
					{
						_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzlUMFttjizmrsnJvpILZOQbCJdq_9(elementType, obj, num, array);
					}
					else
					{
						_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzlUMFttjizmrsnJvpILZOQbCJdq_9(typeof(int), obj, num, array);
					}
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzOGQZuJA_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzOGQZuJA_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D4)
				{
					object obj = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D()._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D();
					long num = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003Dz48d1zHJh3TOQKfAMFYN6p1CRbnL4();
					Array array = (Array)_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D()._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D();
					Type elementType = array.GetType().GetElementType();
					if (elementType == typeof(long))
					{
						_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D._0023_003DzCysyOfnrUQB5WqShWAIL_0024X4XGCe9eW67eVeg6HY_003D(obj, typeof(long));
						((long[])array)[num] = (long)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D();
					}
					else if (elementType == typeof(ulong))
					{
						_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3 = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D._0023_003DzCysyOfnrUQB5WqShWAIL_0024X4XGCe9eW67eVeg6HY_003D(obj, typeof(ulong));
						((ulong[])array)[num] = (ulong)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D();
					}
					else if (elementType.IsEnum)
					{
						_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzlUMFttjizmrsnJvpILZOQbCJdq_9(elementType, obj, num, array);
					}
					else
					{
						_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzlUMFttjizmrsnJvpILZOQbCJdq_9(typeof(long), obj, num, array);
					}
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzWAsKAZU_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzWAsKAZU_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)
				{
					_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D2 = (_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2;
					MethodBase methodBase = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzRt6UVedmJJGarSZZFciXi_0024twqllky4LsnA_003D_003D(_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D2._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D());
					Type declaringType = methodBase.DeclaringType;
					Type type = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D()._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D().GetType();
					ParameterInfo[] parameters = methodBase.GetParameters();
					Type[] array = new Type[parameters.Length];
					for (int i = 0; i < parameters.Length; i++)
					{
						array[i] = parameters[i].ParameterType;
					}
					MethodBase methodBase2 = null;
					Type type2 = type;
					while (type2 != null && type2 != declaringType)
					{
						MethodInfo method = type2.GetMethod(methodBase.Name, BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetProperty | BindingFlags.SetProperty | BindingFlags.ExactBinding, null, CallingConventions.Any, array, null);
						if (method != null && method.GetBaseDefinition() == methodBase)
						{
							methodBase2 = method;
							break;
						}
						type2 = type2.BaseType;
					}
					if (methodBase2 == null)
					{
						methodBase2 = methodBase;
					}
					_0023_003DqZOgqBgNtgFzdL0x3JA7LxzDeXh41TKRK3WDZXmMsiIQ_003D obj = new _0023_003DqZOgqBgNtgFzdL0x3JA7LxzDeXh41TKRK3WDZXmMsiIQ_003D();
					obj._0023_003DzLewIEoK78TTNwxvWLmSRiD8_003D(methodBase2);
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(obj);
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzOG1KvlA_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzOG1KvlA_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)
				{
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzpU_n7PfnyRyJ1anIgJrsjiSffFPi(2);
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dz6HVbGgQ_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dz6HVbGgQ_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)
				{
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003Dzy4D_00248buHMHsvaKDXIg_003D_003D(2);
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzySRztio_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzySRztio_003D, _0023_003DzFhIzjCbuc9Xt2uEh1LeHzcYFHhqqerBxtg_003D_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzVAE0pLs_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzVAE0pLs_003D, _0023_003DzpQwpRUk9CF7rDYKcaj1Hh4E_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzKfSONp4_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzKfSONp4_003D, _0023_003Dz6PhWodQoj4E3Ru7ttr9WZWIeypje7LAOIRa3FOw_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dz3EgOdOA_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dz3EgOdOA_003D, _0023_003DzRGkOU14ZCFOGoo0aFECdzAz7GcZuOk7eYg_003D_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzgP82UKg_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzgP82UKg_003D, _0023_003Dz9mDitRIO0BM5_HPQ2pNhhA8EYRvG)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dz8d5a5Pw_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dz8d5a5Pw_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3)
				{
					_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
					if (_0023_003DzbIhMMCpTAtqwcE7EXAzYf_SJEcWXsuXv_0024Q_003D_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D(), _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2))
					{
						uint num = ((_0023_003DqJFdrGiwz1aJICVkSTb_0024Zko9aS6iSwDcZdo9VS4Dkh_0024s_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3)._0023_003DzxGjrL4iuhvogLPGFSdnVXdPvbKxem9P4HA_003D_003D();
						_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003Dz9r__0024YTGu_0024iN2qFjqe6k1t7s_003D(num);
					}
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzmcpthPQ_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzmcpthPQ_003D, _0023_003DzXqYlHapQtnE1oNZCx2bGOSKCurR8)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzNl32EAo_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzNl32EAo_003D, _0023_003DzWOsJFhnHB_2MOd1kHZzH12rpSltRgKPvSw_003D_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzIYGCIB8_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzIYGCIB8_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)
				{
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003Dz6SiV_B3RvFCLEeKqYpPV_0024wVhgzqa(_0023_003Dz9jrlnWk_003D: false, _0023_003DzBxpHhQ0_003D: false);
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dzrh2iypQ_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dzrh2iypQ_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D4)
				{
					_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
					_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3 = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(_0023_003Dz85ZnAjLw5GuUis_0024G0X_hQ3rZyzLji_2Y9G_l2yE_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2) ? 1 : 0));
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzXI96hVA_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzXI96hVA_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)
				{
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003Dzy4D_00248buHMHsvaKDXIg_003D_003D(8);
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzH7C3gDY_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzH7C3gDY_003D, _0023_003Dz20CyYCKwqoCdB4bORj3efb6W4soNgMQe8Q_003D_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzQeKo0NQ_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzQeKo0NQ_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)
				{
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzriXIwLFCuwD1GZVAt_00248x4do_003D(_0023_003Dz9jrlnWk_003D: true, _0023_003DzBxpHhQ0_003D: false);
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dzmvoe5yA_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dzmvoe5yA_003D, _0023_003DzyILH5qEc1_42WwJvKJ2LSHNnFjLxkv_Ajw_003D_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dz3Uy9H9w_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dz3Uy9H9w_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)
				{
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzLMJxSSXveUKWgX7ByprFEtw_003D(typeof(double));
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dz_i7s2Dg_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dz_i7s2Dg_003D, _0023_003DzsRFxBLGK2B8XoAVwHY6DMhMWFrHjjo6TqlE3OCw_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzWt2au5Y_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzWt2au5Y_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3)
				{
					_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
					bool flag = false;
					if (_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() switch
					{
						1 => ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D() == 0, 
						13 => ((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG() == 0, 
						0 => ((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk() == IntPtr.Zero, 
						20 => ((_0023_003DqVEj3J19zkgEyU6VFymBz6riyi6CxZMJEjhA0KZ2nLKw_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzZlwwYywinAe9h_2ss_0024Wn4RsajDr79HfGCg_003D_003D() == UIntPtr.Zero, 
						7 => ((_0023_003DqcjmfsaS6dKPuf2kSTqJKWfH_rgkc03gEAn6QEKAtpbA_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzKuvp4FpGZEHp_0024htPxx_00248SXawDH8Tdf_0Y48dwaP_bCrZ() == null, 
						19 => !Convert.ToBoolean(((_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D()), 
						_ => _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D() == null, 
					})
					{
						uint num = ((_0023_003DqJFdrGiwz1aJICVkSTb_0024Zko9aS6iSwDcZdo9VS4Dkh_0024s_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3)._0023_003DzxGjrL4iuhvogLPGFSdnVXdPvbKxem9P4HA_003D_003D();
						_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003Dz9r__0024YTGu_0024iN2qFjqe6k1t7s_003D(num);
					}
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzAndD6oU_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzAndD6oU_003D, _0023_003DztLIUwHBrwm6kCoZvJeUrY2pm6pyqW6Il1w_003D_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzULP5vvo_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzULP5vvo_003D, _0023_003DzicjN6h5VGhwsGH7si3y9EMQtQ2KHkii1tJRHTbQ_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzzuPwqHE_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzzuPwqHE_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D4)
				{
					_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
					_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3 = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(_0023_003DzMUztG58r9K8EH6LstV9cRZc_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2) ? 1 : 0));
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzP5I_H4I_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzP5I_H4I_003D, _0023_003DzZxxCTFOYkwbhg0Yadiz2hB4_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DztEspv5A_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DztEspv5A_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3)
				{
					_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(checked(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() switch
					{
						1 => (ushort)(uint)((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D(), 
						13 => (ushort)(ulong)((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG(), 
						19 => (ushort)Convert.ToUInt64(((_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D()), 
						8 => (ushort)((_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzCfXuHVIlFp1X1u2Med2_AL4lzej8EifTBw_003D_003D(), 
						0 => (IntPtr.Size != 4) ? ((ushort)(ulong)(long)((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk()) : ((ushort)(uint)(int)((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk()), 
						_ => throw new InvalidOperationException(), 
					})));
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dz2iacZ4s_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dz2iacZ4s_003D, _0023_003DzXbOzilw6qhAIyhi6nOF8VRw_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzLv_x3i4_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzLv_x3i4_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3)
				{
					_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
					bool flag = false;
					if (_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() switch
					{
						1 => ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D() != 0, 
						13 => ((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG() != 0, 
						0 => ((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk() != IntPtr.Zero, 
						20 => ((_0023_003DqVEj3J19zkgEyU6VFymBz6riyi6CxZMJEjhA0KZ2nLKw_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzZlwwYywinAe9h_2ss_0024Wn4RsajDr79HfGCg_003D_003D() != UIntPtr.Zero, 
						19 => Convert.ToBoolean(((_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D()), 
						7 => ((_0023_003DqcjmfsaS6dKPuf2kSTqJKWfH_rgkc03gEAn6QEKAtpbA_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzKuvp4FpGZEHp_0024htPxx_00248SXawDH8Tdf_0Y48dwaP_bCrZ() != null, 
						_ => _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D() != null, 
					})
					{
						uint num = ((_0023_003DqJFdrGiwz1aJICVkSTb_0024Zko9aS6iSwDcZdo9VS4Dkh_0024s_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3)._0023_003DzxGjrL4iuhvogLPGFSdnVXdPvbKxem9P4HA_003D_003D();
						_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003Dz9r__0024YTGu_0024iN2qFjqe6k1t7s_003D(num);
					}
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzZis2nuo_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzZis2nuo_003D, _0023_003DztFjfZQi0sawOYacPQjs3zu0_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzQlfvBdI_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzQlfvBdI_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)
				{
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003Dzl01rdMbhKWqXEDpjHctwRZgIgliJDTg7bQ_003D_003D(((_0023_003DqJFdrGiwz1aJICVkSTb_0024Zkh7zAYa9iZm47EqlnjrFUg4_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003Dzi58Fb_0024k5T0u9_0024uYc9Q_003D_003D());
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dz_bAFZgU_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dz_bAFZgU_003D, _0023_003DzpmHiMFEOyBXIo0x2tgGuhIBmxBqp)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzWYSSXsk_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzWYSSXsk_003D, _0023_003Dzn63If8PhwV8CZuLkPqhNFwY_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dzc0J1wGk_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dzc0J1wGk_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)
				{
					int num = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
					_0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D _0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D2 = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003Dz_kQ6vjzn2xXdxKzdPsJwstuDR14y(num);
					object obj = ((_0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D2._0023_003DzwH8K7lD_0024cC3gY_RIDCO_Bu8Tp6tgtXa0TA_003D_003D() == 0) ? _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzsOJ6TahPfKuexMbKFEzmdyoIYrB0j9210g_003D_003D(_0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D2._0023_003DztkhwzVeVIldXjs1hyonqsqcuOAEF()) : (_0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D2._0023_003DzMDpHhtfRNQDKXWsFcSVSbdd3Ewg6()._0023_003DzA9soEnqVH30sCIQyx9TdGqof_UNEHpVR4mfBgLqWxZ1U3_DxME_DE3zKrn8uHRkWGZxJRdIDUxjkiWGrygRHRok_003D() switch
					{
						2 => _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003Dz9_Z5EhGFT4yzpTmOPYjfhZOeNABFeUtCmZ_KeWA_003D(num, _0023_003DzBxpHhQ0_003D: true).TypeHandle, 
						0 => _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzRt6UVedmJJGarSZZFciXi_0024twqllky4LsnA_003D_003D(num).MethodHandle, 
						1 => _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzxFlP9j6hwChqbnCQxNoxN7LJpAh_00242zp2XpETVEHUh_9i(num).FieldHandle, 
						_ => throw new InvalidOperationException(), 
					}));
					_0023_003DqcjmfsaS6dKPuf2kSTqJKWfH_rgkc03gEAn6QEKAtpbA_003D obj2 = new _0023_003DqcjmfsaS6dKPuf2kSTqJKWfH_rgkc03gEAn6QEKAtpbA_003D();
					obj2._0023_003DzcdhpkZLz02cIGzFhiuGuUgo_003D(obj);
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(obj2);
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzojdVnVc_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzojdVnVc_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)
				{
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzLMJxSSXveUKWgX7ByprFEtw_003D(typeof(uint));
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzXlMgCsc_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzXlMgCsc_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D4)
				{
					_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
					_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3 = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
					_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D obj = new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D();
					obj._0023_003DzVS8y6A9spdnllqaw83gW5bpUS8si(_0023_003DzjxnjI9Nvph1jzn_0024_xDbv5Sk_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2) ? 1 : 0);
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(obj);
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzxaPwEN8_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzxaPwEN8_003D, _0023_003DzLWsQxt07lqj4BnmF17wJyBw_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dz9I8ZVlc_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dz9I8ZVlc_003D, _0023_003DzqMIp3NDyBwcXXBaKyCsxzuILKHYDZ2Dlww5ZycTLmD0m)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DziiEv3wQ_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DziiEv3wQ_003D, _0023_003Dz7Lb3u8Wungrg1xqk9rvsAhJPDQRYNidOmQ_003D_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dz5V0c9Io_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dz5V0c9Io_003D, _0023_003Dz2HoM2IIwPNFsnCxO5arQNdM_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dz2jIONZw_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dz2jIONZw_003D, _0023_003DzUB42xEYkXM8nI2TTvrVJ2j9AAzfe24CN1GGPzKI_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzbzHeu9w_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzbzHeu9w_003D, _0023_003DzxmyrqtVjD_GnvVtLnPxwHqc_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dz2kWmC38_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dz2kWmC38_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)
				{
					uint num = ((_0023_003DqJFdrGiwz1aJICVkSTb_0024Zko9aS6iSwDcZdo9VS4Dkh_0024s_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzxGjrL4iuhvogLPGFSdnVXdPvbKxem9P4HA_003D_003D();
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003Dz9r__0024YTGu_0024iN2qFjqe6k1t7s_003D(num);
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzKd0gS4M_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzKd0gS4M_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3)
				{
					_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(checked(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() switch
					{
						1 => (byte)(uint)((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D(), 
						13 => (byte)(ulong)((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG(), 
						19 => (byte)Convert.ToUInt64(((_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D()), 
						8 => (byte)((_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzCfXuHVIlFp1X1u2Med2_AL4lzej8EifTBw_003D_003D(), 
						0 => (IntPtr.Size != 4) ? ((byte)(ulong)(long)((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk()) : ((byte)(uint)(int)((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk()), 
						_ => throw new InvalidOperationException(), 
					})));
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dzmfy7RSo_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dzmfy7RSo_003D, _0023_003DzILv91HML1lmcKl_jpzIJo9WKSh2nyLTztk136Nk_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzPDi09LA_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzPDi09LA_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)
				{
					int num = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003Dzn6_Dl38_003D = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003Dz9_Z5EhGFT4yzpTmOPYjfhZOeNABFeUtCmZ_KeWA_003D(num, _0023_003DzBxpHhQ0_003D: true);
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dz79SDY5s_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dz79SDY5s_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)
				{
					int num = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
					Type type = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003Dz9_Z5EhGFT4yzpTmOPYjfhZOeNABFeUtCmZ_KeWA_003D(num, _0023_003DzBxpHhQ0_003D: true);
					_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3 = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D._0023_003DzCysyOfnrUQB5WqShWAIL_0024X4XGCe9eW67eVeg6HY_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D()._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D(), type);
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3);
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzGCxjA14_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzGCxjA14_003D, _0023_003DzlcZANZLiDUKvnpMSBIp9CKPgBBDc)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DznXxxWqg_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DznXxxWqg_003D, _0023_003Dzs0xSYxiBeHCPEk_4bPzDUwo_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzgqvoyJk_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzgqvoyJk_003D, _0023_003DzqtR5mt09tjjlHraIzHt9xqBa1621FTChhtbcrB8_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzJGsRSpg_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzJGsRSpg_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)
				{
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DztKL1iK5LvFaLq_0024Salhy_v0MVryh8FAXmFefkbvo_003D();
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzZ0j8RBQ_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzZ0j8RBQ_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)
				{
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzUbKftaPsoH4C3o3km5CXFp43OkI85ZTJMKNMSEuJ_LI5(_0023_003DzozZCuko_003D);
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzU6OvM7k_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzU6OvM7k_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)
				{
					int num = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
					FieldInfo fieldInfo = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzxFlP9j6hwChqbnCQxNoxN7LJpAh_00242zp2XpETVEHUh_9i(num);
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(new _0023_003DqrQPc9rwDL7Fl53_0024M2Pi1fo_0024Ac1BCNKiaW0Mx66Ji04U_003D(fieldInfo, null));
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzLi0XoCY_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzLi0XoCY_003D, delegate
				{
					throw new NotSupportedException(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564314142));
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzgtUi_7A_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzgtUi_7A_003D, _0023_003DzxMz0gml3k46fUq48BFnrgrW6ZHEt4EmGNnBi6iY_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzTsEU9SA_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzTsEU9SA_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)
				{
					_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D obj = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
					if (obj._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() != 1)
					{
						throw new InvalidOperationException();
					}
					int num = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)obj)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
					Stack<_0023_003DzbSmUaeo_003D> stack = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzFbIBOUZukUTRt6X7TpE_uAdTdeMf();
					if (stack.Count < 2)
					{
						throw new InvalidOperationException();
					}
					using _0023_003DzbSmUaeo_003D _0023_003DzbSmUaeo_003D2 = stack.Pop();
					if (_0023_003DzbSmUaeo_003D2 == null || _0023_003DzbSmUaeo_003D2._0023_003Dz9jrlnWk_003D._0023_003DzK_Jiocf2MUlKFQb4sVmAMIu57J8HGmj0ja2VBmAzqChCH5gQJ3yPpxphLmNSj91NUXmFCpVeDpos() != num)
					{
						throw new InvalidOperationException();
					}
					_0023_003DzbSmUaeo_003D _0023_003DzbSmUaeo_003D3 = stack.Peek();
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzbubspJfKxb0WjXbENdWdGRpLC4D3_0024Y9wrJukd1A_003D(_0023_003DzbSmUaeo_003D3);
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzMP6kxrk_003D += (uint)_0023_003DzbSmUaeo_003D2._0023_003Dz9jrlnWk_003D._0023_003Dz_0024B4ZWC6pK66TUVOsiQ_003D_003D();
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003Dz3BejEhUi_0024bSfiEeI8cmkKdw_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzMP6kxrk_003D);
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dzzrhyls4_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dzzrhyls4_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)
				{
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DztKL1iK5LvFaLq_0024Salhy_v0MVryh8FAXmFefkbvo_003D();
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzYEdYVJk_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzYEdYVJk_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)
				{
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DztqiIS5t19tn4D0pTuVrmqGw_003D(((_0023_003DqIC7wdNmeVLrKuHjiCL8jtht_0024ogaMGYTl_vFxiqwcERQ_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003Dz3fdyocpuocHKnMPBAP0IP10_003D());
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzvB28HNQ_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzvB28HNQ_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D5)
				{
					object obj = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D()._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D();
					long num = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003Dz48d1zHJh3TOQKfAMFYN6p1CRbnL4();
					Array array = (Array)_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D()._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D();
					Type elementType = array.GetType().GetElementType();
					if (elementType == typeof(sbyte))
					{
						_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D._0023_003DzCysyOfnrUQB5WqShWAIL_0024X4XGCe9eW67eVeg6HY_003D(obj, typeof(sbyte));
						((sbyte[])array)[num] = (sbyte)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D();
					}
					else if (elementType == typeof(byte))
					{
						_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3 = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D._0023_003DzCysyOfnrUQB5WqShWAIL_0024X4XGCe9eW67eVeg6HY_003D(obj, typeof(byte));
						((byte[])array)[num] = (byte)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D();
					}
					else if (elementType == typeof(bool))
					{
						_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D4 = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D._0023_003DzCysyOfnrUQB5WqShWAIL_0024X4XGCe9eW67eVeg6HY_003D(obj, typeof(bool));
						((bool[])array)[num] = (bool)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D4._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D();
					}
					else if (elementType.IsEnum)
					{
						_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzlUMFttjizmrsnJvpILZOQbCJdq_9(elementType, obj, num, array);
					}
					else
					{
						_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzlUMFttjizmrsnJvpILZOQbCJdq_9(typeof(sbyte), obj, num, array);
					}
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DztbEZjdA_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DztbEZjdA_003D, _0023_003DztlVOq2CzAarFw398vv7BxHCz4WlnH2EQ0BYXX8iLlfd2)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzOXh2F_c_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzOXh2F_c_003D, _0023_003DzqW2g8O66zkTqihFfgcElTGm2TBGD)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzJ6W8874_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzJ6W8874_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3)
				{
					_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
					UIntPtr uIntPtr = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() switch
					{
						1 => new UIntPtr((uint)((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D()), 
						13 => new UIntPtr((ulong)((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG()), 
						19 => new UIntPtr(Convert.ToUInt64(((_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D())), 
						8 => new UIntPtr((ulong)((_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzCfXuHVIlFp1X1u2Med2_AL4lzej8EifTBw_003D_003D()), 
						_ => throw new InvalidOperationException(), 
					};
					_0023_003DqVEj3J19zkgEyU6VFymBz6riyi6CxZMJEjhA0KZ2nLKw_003D obj = new _0023_003DqVEj3J19zkgEyU6VFymBz6riyi6CxZMJEjhA0KZ2nLKw_003D();
					obj._0023_003DzCa7EEhgBERhQt3JXzBkemL8_003D(uIntPtr);
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(obj);
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dz8ixroro_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dz8ixroro_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)
				{
					_0023_003DqIC7wdNmeVLrKuHjiCL8jtht_0024ogaMGYTl_vFxiqwcERQ_003D _0023_003DqIC7wdNmeVLrKuHjiCL8jtht_0024ogaMGYTl_vFxiqwcERQ_003D2 = (_0023_003DqIC7wdNmeVLrKuHjiCL8jtht_0024ogaMGYTl_vFxiqwcERQ_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2;
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzpU_n7PfnyRyJ1anIgJrsjiSffFPi(_0023_003DqIC7wdNmeVLrKuHjiCL8jtht_0024ogaMGYTl_vFxiqwcERQ_003D2._0023_003Dz3fdyocpuocHKnMPBAP0IP10_003D());
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dz4LTXyQY_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dz4LTXyQY_003D, _0023_003DzKeF8ji6o3nQuAzsVXJGh1E7BVXZqV7eRddXmWyk_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzWVJjS28_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzWVJjS28_003D, _0023_003DzeBfxZyrbUHs0mNEfAWxCLEf0zuMFLh7dng_003D_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dz7iNWvSI_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dz7iNWvSI_003D, _0023_003DzM6D7npQZr6WEBirIuksodSokN5DWrALNSCf7WtE_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dz00_ZuTY_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dz00_ZuTY_003D, _0023_003DzOYLvYnJBCJzEyI9AQud2tXDNy_KJliMG3A_003D_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzeC6iDUE_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzeC6iDUE_003D, delegate
				{
					throw new NotSupportedException(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564314321));
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzVh0er_0024U_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzVh0er_0024U_003D, _0023_003Dz6rSvcwlzaarKct8UK76RMEe3IoHnX_SkOfscGw4_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzCqRcR70_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzCqRcR70_003D, _0023_003DzD6vEF2gBYEoene6a585Qx0SB_3R8)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzEG8ah0k_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzEG8ah0k_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)
				{
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003Dzy4D_00248buHMHsvaKDXIg_003D_003D(-1);
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzBIlbWgo_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzBIlbWgo_003D, _0023_003DzglcnACcJ8FmUvewFSa0y0mEsYBnF0gkRohBvv4E_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzQyb3wNc_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzQyb3wNc_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)
				{
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003Dz6SiV_B3RvFCLEeKqYpPV_0024wVhgzqa(_0023_003Dz9jrlnWk_003D: true, _0023_003DzBxpHhQ0_003D: false);
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzbTA_0024lYA_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzbTA_0024lYA_003D, _0023_003DzTz1yXaiHnzIOx6D5iMKuiKE6b6WH)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzeJXB7Nw_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzeJXB7Nw_003D, _0023_003DzYgLlyYl3aWGU1mwb2DBmpDs2_LEKHZQsnA_003D_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzrHojHlY_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzrHojHlY_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)
				{
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzgsEHju8wslk_S93hiFuhVTuq_cvn();
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dzid06sM8_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dzid06sM8_003D, delegate
				{
					throw new NotSupportedException(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564314355));
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzTw3hCm0_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzTw3hCm0_003D, _0023_003Dzlii0xfNVsq1Npe23kU7VUK6HqKBRkpxbS2oUmTo_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dzzlx_RJk_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dzzlx_RJk_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)
				{
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003Dza4nGArD8ohAiv3Oef3SUUBiljhSza0DBmw_003D_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2);
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dz7SVqS2w_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzeJXB7Nw_003D, _0023_003DzgMqANIWBbv0AB51QsxGVn2_QkE4KzL4nng_003D_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dz3A_0024Cnfc_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dz3A_0024Cnfc_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)
				{
					int num = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
					FieldInfo fieldInfo = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzxFlP9j6hwChqbnCQxNoxN7LJpAh_00242zp2XpETVEHUh_9i(num);
					_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D obj = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
					_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3 = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
					_0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D _0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D2 = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3 as _0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D;
					object obj2 = ((_0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D2 == null) ? _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D() : _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzcyfMbnJemFaR1U9IYqWp0cPmk80NlqUX5LErUtBcWaeU(_0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D2)._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D());
					if (obj2 == null)
					{
						throw new NullReferenceException();
					}
					_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D4 = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D._0023_003DzCysyOfnrUQB5WqShWAIL_0024X4XGCe9eW67eVeg6HY_003D(obj._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D(), fieldInfo.FieldType);
					fieldInfo.SetValue(obj2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D4._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D());
					if (_0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D2 != null && obj2 != null && obj2.GetType().IsValueType)
					{
						_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzlLFsRbFCVJXLxNmd_0024gDP8S8_003D(_0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D._0023_003DzCysyOfnrUQB5WqShWAIL_0024X4XGCe9eW67eVeg6HY_003D(obj2, null));
					}
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzSU8qYOs_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzSU8qYOs_003D, _0023_003Dz6vOPuVEcKpcRckSiij58VS4_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzCfC8u_w_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzCfC8u_w_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D4)
				{
					_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
					_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3 = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(_0023_003DzFCI8XumDuJuKa_0024WkwlglF8STueBuOL3SGHPfX6c_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2) ? 1 : 0));
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzG7m2nd8_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzG7m2nd8_003D, _0023_003DznU5sME325gIO2bObbq7AjPt7giRRci2Q2HV0Yss_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzlGXy5gk_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzlGXy5gk_003D, _0023_003Dz5DjA4KcpOLUVzQUcuw_003D_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzPeqcg9Q_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzPeqcg9Q_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)
				{
					int num = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
					Type elementType = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003Dz9_Z5EhGFT4yzpTmOPYjfhZOeNABFeUtCmZ_KeWA_003D(num, _0023_003DzBxpHhQ0_003D: true);
					_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3 = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
					int length;
					if (_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3 is _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D2)
					{
						length = _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D2._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
					}
					else if (_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3 is _0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D _0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D2)
					{
						length = _0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D2._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk().ToInt32();
					}
					else
					{
						if (!(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3 is _0023_003DqVEj3J19zkgEyU6VFymBz6riyi6CxZMJEjhA0KZ2nLKw_003D _0023_003DqVEj3J19zkgEyU6VFymBz6riyi6CxZMJEjhA0KZ2nLKw_003D2))
						{
							throw new Exception();
						}
						length = (int)_0023_003DqVEj3J19zkgEyU6VFymBz6riyi6CxZMJEjhA0KZ2nLKw_003D2._0023_003DzZlwwYywinAe9h_2ss_0024Wn4RsajDr79HfGCg_003D_003D().ToUInt32();
					}
					Array array = Array.CreateInstance(elementType, length);
					_0023_003DqJK_4DNDu0bpSDsm8DAlJ97YodsmbnVu7wOTilEHAt2g_003D obj = new _0023_003DqJK_4DNDu0bpSDsm8DAlJ97YodsmbnVu7wOTilEHAt2g_003D();
					obj._0023_003Dzt_0024bTK2Fil3XWqMOVKJBmnX_0024psQCLTyoahp9FMe4_003D(array);
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(obj);
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dzj5auj_I_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dzj5auj_I_003D, _0023_003DzEb3djvv9eM82J3Aj9y7zliu4r86JmvSKveLf7yI_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DztuAevKc_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DztuAevKc_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)
				{
					int num = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
					Type t = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003Dz9_Z5EhGFT4yzpTmOPYjfhZOeNABFeUtCmZ_KeWA_003D(num, _0023_003DzBxpHhQ0_003D: true);
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(Marshal.SizeOf(t)));
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzYL9339E_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzYL9339E_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3)
				{
					_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(checked(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() switch
					{
						1 => (short)(uint)((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D(), 
						13 => (short)(ulong)((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG(), 
						19 => (short)Convert.ToUInt64(((_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D()), 
						8 => (short)((_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzCfXuHVIlFp1X1u2Med2_AL4lzej8EifTBw_003D_003D(), 
						0 => (IntPtr.Size != 4) ? ((short)(ulong)(long)((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk()) : ((short)(uint)(int)((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk()), 
						_ => throw new InvalidOperationException(), 
					})));
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dz9_0024L7s_0024c_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dz9_0024L7s_0024c_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3)
				{
					_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzzUdLVh6RcJ0qp5eRPoW5he0ADnSX(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D());
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzRyJD_002440_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzRyJD_002440_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3)
				{
					_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() switch
					{
						1 => ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D(), 
						13 => (int)checked((uint)(ulong)((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG()), 
						19 => (int)checked((uint)Convert.ToUInt64(((_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D())), 
						8 => (int)checked((uint)((_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzCfXuHVIlFp1X1u2Med2_AL4lzej8EifTBw_003D_003D()), 
						0 => (IntPtr.Size != 4) ? ((int)checked((uint)(ulong)(long)((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk())) : ((int)((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk()), 
						_ => throw new InvalidOperationException(), 
					}));
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dzs6fypu0_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dzs6fypu0_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D4)
				{
					_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
					_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3 = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003Dz7cls5OZUxwV_0024XPFgwwCtM3Ng67uqnWekGg_003D_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2));
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dzc3hmZCQ_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dzc3hmZCQ_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)
				{
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzriXIwLFCuwD1GZVAt_00248x4do_003D(_0023_003Dz9jrlnWk_003D: true, _0023_003DzBxpHhQ0_003D: true);
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dzn0mbPio_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dzn0mbPio_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)
				{
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzGDuTOpKXFiuPe7G4kruEtPUIgmVeEuqxuw_003D_003D(_0023_003Dz9jrlnWk_003D: true);
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dz1UJtn6g_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dz1UJtn6g_003D, _0023_003DzK46PKFEi52UNAqeyg6XC3nY_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzUnvXOEk_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzUnvXOEk_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)
				{
					int num = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
					bool num2 = (num & int.MinValue) != 0;
					bool flag = (num & 0x40000000) != 0;
					num &= 0x3FFFFFFF;
					if (num2)
					{
						_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzqsLd2orT176bfBS85vdKAL2yi5EJ(num, null, null, flag);
					}
					else
					{
						_0023_003Dq6RsKbEvjyFgbikPCxI_0024iyaP4iT3cOdFPnt_Mjubq4RU_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iyaP4iT3cOdFPnt_Mjubq4RU_003D2 = (_0023_003Dq6RsKbEvjyFgbikPCxI_0024iyaP4iT3cOdFPnt_Mjubq4RU_003D)_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003Dz_kQ6vjzn2xXdxKzdPsJwstuDR14y(num)._0023_003DzMDpHhtfRNQDKXWsFcSVSbdd3Ewg6();
						_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003Dz6QIX6pdi7W0E7LFA_PlLav8_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iyaP4iT3cOdFPnt_Mjubq4RU_003D2);
					}
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzgdJ1wBQ_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzgdJ1wBQ_003D, _0023_003DzjCBcg0fghu2E_9ez98qDdz8Z0rfU)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DziPKktwk_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DziPKktwk_003D, _0023_003DzftSUJzemyLDw1PreLnYGJc8_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzAMMIogc_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzAMMIogc_003D, _0023_003DzuRKauI5ALzYpA553dPTVEDB2bFkIpyztog_003D_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DznempUdI_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DznempUdI_003D, _0023_003Dz5ClTIsODup3igBphUksyuGwl7r2q__1ycQ_003D_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dz6PXmkFc_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dz6PXmkFc_003D, _0023_003DzcYN5dyE_l5hfzBnK_2CtBtFgbDBbEwpClA_003D_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzMP6kxrk_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzMP6kxrk_003D, _0023_003DzU30LI6oJRf19TZ9KtA_003D_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzoEGLyuM_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzoEGLyuM_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)
				{
					_0023_003DqJFdrGiwz1aJICVkSTb_0024Zkh7zAYa9iZm47EqlnjrFUg4_003D _0023_003DqJFdrGiwz1aJICVkSTb_0024Zkh7zAYa9iZm47EqlnjrFUg4_003D2 = (_0023_003DqJFdrGiwz1aJICVkSTb_0024Zkh7zAYa9iZm47EqlnjrFUg4_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2;
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzpU_n7PfnyRyJ1anIgJrsjiSffFPi(_0023_003DqJFdrGiwz1aJICVkSTb_0024Zkh7zAYa9iZm47EqlnjrFUg4_003D2._0023_003Dzi58Fb_0024k5T0u9_0024uYc9Q_003D_003D());
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzI2JskBU_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzI2JskBU_003D, _0023_003DzMbnRSPlbW61fGp_7FbWj6N8_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzR24D1yQ_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzR24D1yQ_003D, _0023_003DzTEYm11CLRTx0imq2hCrcy0sSOJst)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzozZCuko_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzozZCuko_003D, _0023_003Dzjz_8KFUPOMFPwXWuMkfTZPg_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dzug_0024QZlY_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dzug_0024QZlY_003D, _0023_003DzE2OU1KKZG3s4TEHf7N0TYYsbkTkNiVkMoU_M3TI_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzfrLf2Nc_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzfrLf2Nc_003D, _0023_003DzcTAM4CX3wDgJRcUfZyhb176LPXa_aydfmJLr5Mgr_sGZ)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dz3s7AUQI_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dz3s7AUQI_003D, _0023_003Dz_N81JJDnAy30bUuWTRUtCER7p6z7h9mIHm5wrLA_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzYIzR67o_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzYIzR67o_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)
				{
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2);
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzHMc84tQ_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzHMc84tQ_003D, _0023_003DzcIA2_1gUPqzR6iw3FWhIisqwd82nfxKx4fozy4_UaKUy)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzHajJwNQ_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzHajJwNQ_003D, _0023_003DzhQsVTSKld4gsbxPG0w1WiesHJdzUNzRZjL_AGuA_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DztooAniI_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DztooAniI_003D, _0023_003DzgIg_mmc6IjmjNfyxC7AVuY8_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzddrJTVY_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzddrJTVY_003D, _0023_003DzIXvhHjXrOk7HeFOYn9Beh0KH7nHz)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DziH5pnyI_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DziH5pnyI_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)
				{
					_0023_003DqJFdrGiwz1aJICVkSTb_0024Zkh7zAYa9iZm47EqlnjrFUg4_003D _0023_003DqJFdrGiwz1aJICVkSTb_0024Zkh7zAYa9iZm47EqlnjrFUg4_003D2 = (_0023_003DqJFdrGiwz1aJICVkSTb_0024Zkh7zAYa9iZm47EqlnjrFUg4_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2;
					_0023_003DqFNN_kH3_Aic_0024vq9s6N7BcnqdUOw1mJpa1yIMZD1vbOQ_003D obj = new _0023_003DqFNN_kH3_Aic_0024vq9s6N7BcnqdUOw1mJpa1yIMZD1vbOQ_003D();
					obj._0023_003DzlpaqC69eD5UfV5QZE9NijsO7MeQh(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzWn08U5s_003D[_0023_003DqJFdrGiwz1aJICVkSTb_0024Zkh7zAYa9iZm47EqlnjrFUg4_003D2._0023_003Dzi58Fb_0024k5T0u9_0024uYc9Q_003D_003D()]);
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(obj);
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dze23HFx0_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dze23HFx0_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)
				{
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzH5ozr5LVbpuoOMs7OGq0_HiG1jqsa5wf1w_003D_003D(_0023_003Dz9jrlnWk_003D: false);
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzHdk5DH8_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzHdk5DH8_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)
				{
					int num = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
					string text = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzxW_0024wA_o40UkoRPgQw4t_0024_wZZnQl5dcP5DiFZrswScyOP(num);
					_0023_003DqU9yZW7eck7EhOE03v76I8g_ZAkOEXEbgxMSUsI3YrFY_003D obj = new _0023_003DqU9yZW7eck7EhOE03v76I8g_ZAkOEXEbgxMSUsI3YrFY_003D();
					obj._0023_003DzmRCWPl2nb6XoVxP_mjXregk_003D(text);
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(obj);
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzSQPnhds_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzSQPnhds_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)
				{
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzrvgYEC2M5vRgH_0024PXC9SqcEgNZWiDqQp3KZTvk3jJwfyB(_0023_003Dz9jrlnWk_003D: false);
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzdTrI_0024cs_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzdTrI_0024cs_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3)
				{
					_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003Dzuk7pFeGyjkSPMmddbHRfYsu48tCb(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2));
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzN182m5s_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzN182m5s_003D, _0023_003DzHXwsvkO66lx0VPpX3hecErMzfinm)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzwETOsNI_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzwETOsNI_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)
				{
					_0023_003DqIC7wdNmeVLrKuHjiCL8jtht_0024ogaMGYTl_vFxiqwcERQ_003D _0023_003DqIC7wdNmeVLrKuHjiCL8jtht_0024ogaMGYTl_vFxiqwcERQ_003D2 = (_0023_003DqIC7wdNmeVLrKuHjiCL8jtht_0024ogaMGYTl_vFxiqwcERQ_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2;
					_0023_003DqFNN_kH3_Aic_0024vq9s6N7BcnqdUOw1mJpa1yIMZD1vbOQ_003D obj = new _0023_003DqFNN_kH3_Aic_0024vq9s6N7BcnqdUOw1mJpa1yIMZD1vbOQ_003D();
					obj._0023_003DzlpaqC69eD5UfV5QZE9NijsO7MeQh(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzWn08U5s_003D[_0023_003DqIC7wdNmeVLrKuHjiCL8jtht_0024ogaMGYTl_vFxiqwcERQ_003D2._0023_003Dz3fdyocpuocHKnMPBAP0IP10_003D()]);
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(obj);
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzYiFDtIE_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzYiFDtIE_003D, _0023_003Dzb5RfoyTFeDVWteVjaUn_5E_L__Nj)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dz9TI2kxQ_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dz9TI2kxQ_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3)
				{
					_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
					double num = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() switch
					{
						1 => (uint)((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D(), 
						13 => (ulong)((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG(), 
						19 => Convert.ToUInt64(((_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D()), 
						_ => throw new InvalidOperationException(), 
					};
					_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D obj = new _0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D();
					obj._0023_003DzBGdDQOw_INWgxm_K091ViE8d5B7H7_X_0024gA2NQZA_003D(num);
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(obj);
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzgSRgyM8_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzgSRgyM8_003D, _0023_003Dz5o3E2IuM_EW8WGhIaM0FLPE8Ytju17uPFfOaAd4hu4Jj)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzWn08U5s_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzWn08U5s_003D, _0023_003Dzoy6tJ0IF4VWgoQntLmmN9hdNlMa9FvipCQ_003D_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzGX9QPgk_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzGX9QPgk_003D, _0023_003DzGo2ziHAVROmZ4uwwO5BGqL67wco6)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DznNCwbu0_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DznNCwbu0_003D, _0023_003DzLPVppnbVBqNuXbHECTtOYzth42v9)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dzjt0YPZc_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dzjt0YPZc_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)
				{
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzLMJxSSXveUKWgX7ByprFEtw_003D(typeof(byte));
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dzn6_Dl38_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dzn6_Dl38_003D, _0023_003DzuZ10UqzC4iKg6tMmM0n7IoeyqBLx1SejBg_003D_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dzh_kH0OM_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dzh_kH0OM_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)
				{
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003Dzy4D_00248buHMHsvaKDXIg_003D_003D(3);
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dzz4gyhOM_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dzz4gyhOM_003D, _0023_003Dz0dtMxE1pQ9G7RAsOHGQ0T_tItxmU)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dzw5_0024MnmA_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dzw5_0024MnmA_003D, _0023_003Dz6rOqji0u8x0FNTkY79wLXDg4UYDq)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dz2X4AXXw_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dz2X4AXXw_003D, _0023_003DzZWd3R5s7W5WWVbSEq2kntbWB8XDeU2bdCg_003D_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzFQGDh5A_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzFQGDh5A_003D, _0023_003DzVWnKEQNiUE5wCpzACttKsUDkEeziV9xrew_003D_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzcWlt650_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzcWlt650_003D, _0023_003DzSd3STdmxORE9rSm9dFFiGLg_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzaoButTk_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzaoButTk_003D, _0023_003DzIM1DohyJsoJC_oySig79wlcqu77vGjLlndSeC6Ib0jZd)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzionodBQ_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzionodBQ_003D, _0023_003DzpNlFQ2zde8bqILHBdfUD3QcJn3oF)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzcVj86iA_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzcVj86iA_003D, _0023_003Dz1TrvUtEkNPeWQKWB_AldL5FFYjgfkX4Rz4tPsA_FY5Sp)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dz_0024bI1JP4_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dz_0024bI1JP4_003D, _0023_003DzigDb8O3hamCs_I4BBKv3Q3tjZO864azkpg_003D_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzAW64gfU_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzAW64gfU_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)
				{
					_0023_003Dq9cxJfzt6tx3_00245xLDM_0024HAnrEHrErdbG4Q2r8aUaxhhjk_003D _0023_003Dq9cxJfzt6tx3_00245xLDM_0024HAnrEHrErdbG4Q2r8aUaxhhjk_003D2 = _0023_003DzPh_0024mk5GoEaUtEvshztgcA9SPyTYC(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2);
					_0023_003Dq6tS8rMV1rGswJPasZDHd76XTcVlfwQMkS5tB1TusLXU_003D _0023_003Dq6tS8rMV1rGswJPasZDHd76XTcVlfwQMkS5tB1TusLXU_003D2 = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzLi0XoCY_003D._0023_003Dzf_kC_0024hpTUTdHx7uANBVIZvPU6fFbivFk0g_003D_003D();
					long num = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzWcPCdsp22a3yYh4GeH8s_0024I8_003D();
					byte[] array = new _0023_003DqiuPtUBEOXz5ixdMRvtXgU5IT5LVA5oiMhmi3Fees6ng_003D(_0023_003Dq9cxJfzt6tx3_00245xLDM_0024HAnrEHrErdbG4Q2r8aUaxhhjk_003D2._0023_003Dz1qfHC3tVjZZJXiu_0024ys4KOidUAg0LkOs9mqQ5_0024NM3aHVI4gI_F0bGt9Us7tIHYyexPO4GU4kmT7TUUnqKpw_003D_003D(), _0023_003Dq9cxJfzt6tx3_00245xLDM_0024HAnrEHrErdbG4Q2r8aUaxhhjk_003D2._0023_003DzVQEs7QGAKxub_qqbfbOV6bNdQXNiHfZxKtrqeRXPqyPrOtTFXkB7AUCFkY2R_0024J7t4jpvXTdvtRIh_0024ZHw_0024QjCUcQ_003D())._0023_003DzDOPeMXI1OjHdm9Jn7PhQ_0024KMKrDz8(_0023_003Dq6tS8rMV1rGswJPasZDHd76XTcVlfwQMkS5tB1TusLXU_003D2, _0023_003Dq9cxJfzt6tx3_00245xLDM_0024HAnrEHrErdbG4Q2r8aUaxhhjk_003D2);
					_0023_003DzbSmUaeo_003D _0023_003DzbSmUaeo_003D2 = new _0023_003DzbSmUaeo_003D
					{
						_0023_003Dz9jrlnWk_003D = _0023_003Dq9cxJfzt6tx3_00245xLDM_0024HAnrEHrErdbG4Q2r8aUaxhhjk_003D2,
						_0023_003DzzKDx05I_003D = num
					};
					_0023_003Dq9cxJfzt6tx3_00245xLDM_0024HAnrEHrErdbG4Q2r8aUaxhhjk_003D2._0023_003DzFWa94yaz1N_0024HGV6t8Mxpk_IIJH8lL8tDFpFFpoc_003D(_0023_003Dqy79GaFqXfJyGRxADW8SzoS_QgCk0_0024_0024Ut2TwY6OCHt3c_003D._0023_003DzoJTaTomf7RYLavkod89ufvU_003D(array.Length) - array.Length);
					_0023_003DzbSmUaeo_003D2._0023_003DzBxpHhQ0_003D = new _0023_003DqSrxlws3SuprWxrjyHO1juxJFrTNvlF8gj_KAkF067yA_003D(_0023_003DzbSmUaeo_003D2._0023_003Dztgqm2r4_003D = new _0023_003DqtFN_00241TjdaenuCmn9GBmqpoZ3gp2tHyBL0X9WMKdAUQk_003D(array, 0, array.Length, _0023_003DzzKDx05I_003D: false));
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzFbIBOUZukUTRt6X7TpE_uAdTdeMf().Push(_0023_003DzbSmUaeo_003D2);
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzbubspJfKxb0WjXbENdWdGRpLC4D3_0024Y9wrJukd1A_003D(_0023_003DzbSmUaeo_003D2);
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzCR5Jlyc_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzCR5Jlyc_003D, _0023_003DzJL90tUbmxXV6xvOjghbthf8_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzjRNWNA0_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzjRNWNA0_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)
				{
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzUbKftaPsoH4C3o3km5CXFp43OkI85ZTJMKNMSEuJ_LI5(typeof(ushort));
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dz_NYtIHc_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dz_NYtIHc_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)
				{
					_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D2 = (_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2;
					MethodBase methodBase = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzRt6UVedmJJGarSZZFciXi_0024twqllky4LsnA_003D_003D(_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D2._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D());
					_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D[] array = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzWn08U5s_003D;
					foreach (_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3 in array)
					{
						_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3);
					}
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003Dz3Kd3rvERK8HcEu6iFYdwh0o_003D(methodBase, _0023_003DzBxpHhQ0_003D: false);
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzYVcRoxQ_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzYVcRoxQ_003D, _0023_003DzrJAYZef3ntu34L31tBN7Pe3NCn8WfmY760ktpNs_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzulyKO20_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzulyKO20_003D, _0023_003DzJ7hfXBj4HBlZoLgBlJ9Au0QQYr07Fs8oGg_003D_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzdVZznKI_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzdVZznKI_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D5)
				{
					object obj = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D()._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D();
					long num = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003Dz48d1zHJh3TOQKfAMFYN6p1CRbnL4();
					Array array = (Array)_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D()._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D();
					Type elementType = array.GetType().GetElementType();
					if (elementType == typeof(short))
					{
						_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D._0023_003DzCysyOfnrUQB5WqShWAIL_0024X4XGCe9eW67eVeg6HY_003D(obj, typeof(short));
						((short[])array)[num] = (short)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D();
					}
					else if (elementType == typeof(ushort))
					{
						_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3 = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D._0023_003DzCysyOfnrUQB5WqShWAIL_0024X4XGCe9eW67eVeg6HY_003D(obj, typeof(ushort));
						((ushort[])array)[num] = (ushort)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D();
					}
					else if (elementType == typeof(char))
					{
						_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D4 = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D._0023_003DzCysyOfnrUQB5WqShWAIL_0024X4XGCe9eW67eVeg6HY_003D(obj, typeof(char));
						((char[])array)[num] = (char)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D4._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D();
					}
					else if (elementType.IsEnum)
					{
						_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzlUMFttjizmrsnJvpILZOQbCJdq_9(elementType, obj, num, array);
					}
					else
					{
						_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzlUMFttjizmrsnJvpILZOQbCJdq_9(typeof(short), obj, num, array);
					}
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dzxk54U4E_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dzxk54U4E_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)
				{
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzUbKftaPsoH4C3o3km5CXFp43OkI85ZTJMKNMSEuJ_LI5(typeof(float));
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dzew32rcU_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dzew32rcU_003D, _0023_003DzRNVoPh1Z7HxC8HfC_fgGQUInZN4LR5JNcXc3xBd_7IRd)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dzq19rHAM_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dzq19rHAM_003D, _0023_003DzurnIJ9utY6G65c7jxx4Dtu4bKkRiqgk6Cw_003D_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dz6eb9B7U_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dz6eb9B7U_003D, delegate
				{
					throw new NotSupportedException(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564315458));
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dz9jrlnWk_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dz9jrlnWk_003D, _0023_003DzfFNwdLqEqbmoSkqUCMUyDUs_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzGti5nqY_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzGti5nqY_003D, _0023_003DzRx5N72BRmErWQARWJNF2v6Hsp8YgtvQ8rfwcwgwNbSJK)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dzta6NXWI_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dzta6NXWI_003D, _0023_003DzmbDvNgREmKTcuJBwbsTAFE0_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzHFkmtmM_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzHFkmtmM_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3)
				{
					_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
					uint num = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() switch
					{
						1 => (uint)((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D(), 
						13 => (uint)((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG(), 
						19 => (uint)Convert.ToInt64(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D()), 
						_ => throw new InvalidOperationException(), 
					};
					_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D[] array = (_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D[])((_0023_003DqJK_4DNDu0bpSDsm8DAlJ97YodsmbnVu7wOTilEHAt2g_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3)._0023_003Dz8x2to_0024HHcSI6D8KXMUd8dEqHnUA_00248eLPE0X_0024zbESTq9X();
					if (num < array.Length)
					{
						uint num2 = (uint)array[num]._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
						_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003Dz9r__0024YTGu_0024iN2qFjqe6k1t7s_003D(num2);
					}
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dz_6ql3Zg_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dz_6ql3Zg_003D, _0023_003Dzfs61Zc4ONKwCwYJAZmRkuhKaXGL64Hb_3w_003D_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dz8qFa8JA_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dz8qFa8JA_003D, _0023_003DzVGWBusHVoszT9gLQJiAnjYc_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzaTyQZ6E_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzaTyQZ6E_003D, _0023_003Dzl4ET6O66nTPkaoTlB5CtG3YGYrH0Q5AC0A_003D_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzekdNBIU_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzekdNBIU_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)
				{
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzwbI83bfoaDmYaZBDzj4leqo_003D(((_0023_003DqIC7wdNmeVLrKuHjiCL8jtht_0024ogaMGYTl_vFxiqwcERQ_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003Dz3fdyocpuocHKnMPBAP0IP10_003D());
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dz6KY0DVQ_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dz6KY0DVQ_003D, _0023_003Dznnsj38k9qQ8Uu8RVDLfixJU_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzWf7vNYA_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzWf7vNYA_003D, _0023_003DzjhFfjTX96eNYjnenBqyJ6uHFt5nU)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dz_00245yMOf8_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dz_00245yMOf8_003D, _0023_003Dzp6ISfHAIbwLkFED39RF6p2rGjwdN)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dzxskgzi0_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dzxskgzi0_003D, _0023_003DzCzYbcsMauOzMdWlfr7yRwhQ_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzgUoyz9s_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzgUoyz9s_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3)
				{
					_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
					if (_0023_003DzjxnjI9Nvph1jzn_0024_xDbv5Sk_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D(), _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2))
					{
						uint num = ((_0023_003DqJFdrGiwz1aJICVkSTb_0024Zko9aS6iSwDcZdo9VS4Dkh_0024s_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3)._0023_003DzxGjrL4iuhvogLPGFSdnVXdPvbKxem9P4HA_003D_003D();
						_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003Dz9r__0024YTGu_0024iN2qFjqe6k1t7s_003D(num);
					}
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzCbpaZow_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzCbpaZow_003D, _0023_003DzoC9YrBtXWPHoabSujyAFKzZ4immOUmP9IpZ1Rak_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzPQJWYOY_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzPQJWYOY_003D, _0023_003Dzzv9ZmkimVib67S8QHkI51Nc_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzGpPUbQU_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzGpPUbQU_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3)
				{
					_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
					double num = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() switch
					{
						1 => ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D(), 
						13 => ((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG(), 
						19 => Convert.ToUInt64(((_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D()), 
						8 => ((_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzCfXuHVIlFp1X1u2Med2_AL4lzej8EifTBw_003D_003D(), 
						_ => throw new InvalidOperationException(), 
					};
					_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D obj = new _0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D();
					obj._0023_003DzBGdDQOw_INWgxm_K091ViE8d5B7H7_X_0024gA2NQZA_003D(num);
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(obj);
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dz_0024xYjLtI_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dz_0024xYjLtI_003D, _0023_003Dz9gxmpIU2aepwmWBxSHchxvEEG6YG)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzBv_BB20_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzBv_BB20_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)
				{
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzLMJxSSXveUKWgX7ByprFEtw_003D(typeof(long));
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzAC_0024sduM_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzAC_0024sduM_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3)
				{
					_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzKWldAQdJ09HXMZAyqMT0BMPufBy1QG1190JaTixk_Dee(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2));
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dz9SQX_O0_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dz9SQX_O0_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)
				{
					int num = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
					Type type = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003Dz9_Z5EhGFT4yzpTmOPYjfhZOeNABFeUtCmZ_KeWA_003D(num, _0023_003DzBxpHhQ0_003D: true);
					_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3 = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
					if (_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzFDdYEW_UBGDFCKATfJ3Fdq4UMQmKapQVSw_003D_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3, type))
					{
						_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3);
						return;
					}
					throw new InvalidCastException();
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dz6r_b9y4_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dz6r_b9y4_003D, _0023_003Dzbs4xIzkJxtqVehNtuavtZ0PqM9Dc)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dz5bot44w_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dz5bot44w_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D4)
				{
					_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
					_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3 = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003Dz7WIqQGaXZefoDBw0v6JVcpCgOJklztcSgMYd8dOHL87g(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2));
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dz98rOKeA_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dz98rOKeA_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)
				{
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzpU_n7PfnyRyJ1anIgJrsjiSffFPi(3);
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzLONmzSE_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzLONmzSE_003D, _0023_003DzCt85HvcPUBOmiwRcmg_003D_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzccgAw4c_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzccgAw4c_003D, _0023_003DzipmHwPhZN9VbWEUGToDppXTMBBG1)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dz7JCUyRo_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dz7JCUyRo_003D, _0023_003Dz4szJUi3IqDOq4Mean1EE1N7GatwCk07LylbIcSU_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dzvc8AGuY_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dzvc8AGuY_003D, _0023_003DzhkeKe0NEj_iaT3Bp4BFFinLIuAEMyhN20A_003D_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzIyFZK0E_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzIyFZK0E_003D, _0023_003DzLhbSkYRWdqShAmUOwpcpKfc_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dz5_0024T8iPw_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dz5_0024T8iPw_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)
				{
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzUbKftaPsoH4C3o3km5CXFp43OkI85ZTJMKNMSEuJ_LI5(typeof(int));
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzncyNPks_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzncyNPks_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)
				{
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzLMJxSSXveUKWgX7ByprFEtw_003D(_0023_003DqqSQMR5x0Ss3kUZAkPHTc7q6IdaUzR_0024BTopvbTI_0024P7DA_003D._0023_003Dz9jrlnWk_003D);
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzfwP_0024G00_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzfwP_0024G00_003D, _0023_003DzhPjf5Sdh0ulTgZ3rHP0uiStT3NEXgyPktA_003D_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003Dz_0024gpZG2I_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003Dz_0024gpZG2I_003D, _0023_003DzeblxSneM3NDUd4WhHGcNy9w_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzXIOLRSc_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzXIOLRSc_003D, _0023_003DzMF2mW49AFbC8qsHhvEgWuCYeHdIk02A6AtvtuRo_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzbLHaDy4_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzbLHaDy4_003D, _0023_003DzcGWq4QF1rySHzpm3QNRqgCcM8mQCcRGoAKY8IQyuzUxJ)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzcnCZW_A_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzcnCZW_A_003D, delegate(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)
				{
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003DzwbI83bfoaDmYaZBDzj4leqo_003D(2);
				})
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DziDh2WHE_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DziDh2WHE_003D, _0023_003DzdiGrOgbBeDUwXUg0GOtll058Q99mxRNNUA_003D_003D)
			},
			{
				_0023_003Dz9jrlnWk_003D._0023_003DzzKDx05I_003D._0023_003DznxG968n4_KvBcEnnM34EK4ralJAOiVZxe841JC6A5bEh(),
				new _0023_003DzgqvoyJk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzzKDx05I_003D, _0023_003Dzjb65nHC5UexrCNymxZCB5UfbLDhZ)
			}
		};
	}

	private static void _0023_003DzxmyrqtVjD_GnvVtLnPxwHqc_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		int num = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
		Type type = _0023_003Dz9jrlnWk_003D._0023_003Dz9_Z5EhGFT4yzpTmOPYjfhZOeNABFeUtCmZ_KeWA_003D(num, _0023_003DzBxpHhQ0_003D: true);
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		if (_0023_003Dz9jrlnWk_003D._0023_003DzFDdYEW_UBGDFCKATfJ3Fdq4UMQmKapQVSw_003D_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2, type))
		{
			_0023_003Dz9jrlnWk_003D._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2);
		}
		else
		{
			_0023_003Dz9jrlnWk_003D._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(new _0023_003DqcjmfsaS6dKPuf2kSTqJKWfH_rgkc03gEAn6QEKAtpbA_003D());
		}
	}

	private static void _0023_003DzOwsTxrvW_0024lw3TpP247qDxtc_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003Dzy4D_00248buHMHsvaKDXIg_003D_003D(3);
	}

	private void _0023_003Dz5YH2PaowZRQpuvM2FluL6E4_003D()
	{
		_0023_003Dznx1EMIs_003D = null;
		this.m__0023_003Dz3iPku7s_003D = null;
		_0023_003DzGX9QPgk_003D.Clear();
	}

	private static void _0023_003DzsAGh9jyxK_ZeIfr005UPKEDdKQ8_0024wBcMKGxnIRtxuIpe(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003Dz6SiV_B3RvFCLEeKqYpPV_0024wVhgzqa(_0023_003Dz9jrlnWk_003D: false, _0023_003DzBxpHhQ0_003D: false);
	}

	private static void _0023_003DzBKBp98y_XPUU_0024_JthYcankUzPTiw(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		int num = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
		Type type = _0023_003Dz9jrlnWk_003D._0023_003Dz9_Z5EhGFT4yzpTmOPYjfhZOeNABFeUtCmZ_KeWA_003D(num, _0023_003DzBxpHhQ0_003D: true);
		long num2 = _0023_003Dz9jrlnWk_003D._0023_003Dz48d1zHJh3TOQKfAMFYN6p1CRbnL4();
		Array array = (Array)_0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D()._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D();
		_0023_003DqqAFF17CqR9tmgwcDOoVXDR8oqWCVrzaSDy4kQfwl5ew_003D obj = new _0023_003DqqAFF17CqR9tmgwcDOoVXDR8oqWCVrzaSDy4kQfwl5ew_003D();
		obj._0023_003DzbcQlnnQg_3k7H5qcGzTOz659_0024_m3R_a058Syv7Y_003D(array);
		obj._0023_003Dz_0024WOmwPiJ7UFMYHpG_kOLOeBLqKyQ(type);
		obj._0023_003DzvvMbYezXK0KJ4emHYcURPozP24bememvbg_003D_003D(num2);
		_0023_003Dz9jrlnWk_003D._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(obj);
	}

	private void _0023_003DzEybOQ_7Jh2tKs9B22pwb8swkxukzO6kvAnN8bkYeK8K5()
	{
		_0023_003DzXWjhwr3jjg5LgzFsYywdzVTfnUlc(_0023_003Dz9jrlnWk_003D: false);
	}

	private static void _0023_003DzCzYbcsMauOzMdWlfr7yRwhQ_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003Dz5ky4pu2_00245NqtcI37a_mjNnb49zcJiJ0NC6G9vYM_003D(_0023_003Dz9jrlnWk_003D: false);
	}

	private static void _0023_003Dzp6ISfHAIbwLkFED39RF6p2rGjwdN(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
	}

	private static void _0023_003DzhkeKe0NEj_iaT3Bp4BFFinLIuAEMyhN20A_003D_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003Dz_bTfuOd_0024_8tksF6orA_003D_003D(typeof(double));
	}

	private static void _0023_003Dznnsj38k9qQ8Uu8RVDLfixJU_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzUbKftaPsoH4C3o3km5CXFp43OkI85ZTJMKNMSEuJ_LI5(typeof(uint));
	}

	private static void _0023_003DzMbK4EdvyM6Zktm4Q_0024w_003D_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3 = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		_0023_003Dz9jrlnWk_003D._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(_0023_003DzFCI8XumDuJuKa_0024WkwlglF8STueBuOL3SGHPfX6c_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2) ? 1 : 0));
	}

	private static void _0023_003DzglcnACcJ8FmUvewFSa0y0mEsYBnF0gkRohBvv4E_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		if (!_0023_003DzMUztG58r9K8EH6LstV9cRZc_003D(_0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D(), _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2))
		{
			uint num = ((_0023_003DqJFdrGiwz1aJICVkSTb_0024Zko9aS6iSwDcZdo9VS4Dkh_0024s_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzxGjrL4iuhvogLPGFSdnVXdPvbKxem9P4HA_003D_003D();
			_0023_003Dz9jrlnWk_003D._0023_003Dz9r__0024YTGu_0024iN2qFjqe6k1t7s_003D(num);
		}
	}

	private static void _0023_003Dzjz_8KFUPOMFPwXWuMkfTZPg_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzQRfyZFRl4R_002477CTSiMe16CpBHDHSToTDKQ_003D_003D(_0023_003Dz9jrlnWk_003D: true);
	}

	private static void _0023_003DzqMIp3NDyBwcXXBaKyCsxzuILKHYDZ2Dlww5ZycTLmD0m(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003Dzy4D_00248buHMHsvaKDXIg_003D_003D(0);
	}

	private static void _0023_003Dz8H8_0024LKwiwJfkmqbzGkTpWL0_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DztKL1iK5LvFaLq_0024Salhy_v0MVryh8FAXmFefkbvo_003D();
	}

	private long _0023_003Dz70nXvMYU0VkkG6IeqPZh9PDfv6k7__0024ejRuztli0_003D(string _0023_003Dz9jrlnWk_003D)
	{
		MemoryStream memoryStream = new MemoryStream(_0023_003DqowHKvOKCRadGRJLlIH7sjaBEg_PB2xc5IAJdSMI8XKA_003D._0023_003DzL3QezyYHWQOCX__iPw_003D_003D(_0023_003Dz9jrlnWk_003D));
		long result = new _0023_003DqSrxlws3SuprWxrjyHO1juxJFrTNvlF8gj_KAkF067yA_003D(new _0023_003Dq0d3UOaLcwAHpHXr73AEsTm4JkA88Pbrxf7l8KMLJdjU_003D(memoryStream, _0023_003DzwLrEupaT_dOFzPwG8LwzVOA_003D()))._0023_003Dz1RtBg1_0024Sse5482v8asVTTPvqL0oBixer7Dch_d3qXLja();
		memoryStream.Dispose();
		return result;
	}

	private static void _0023_003Dz_N81JJDnAy30bUuWTRUtCER7p6z7h9mIHm5wrLA_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003Dzl01rdMbhKWqXEDpjHctwRZgIgliJDTg7bQ_003D_003D(1);
	}

	private void _0023_003Dz6SiV_B3RvFCLEeKqYpPV_0024wVhgzqa(bool _0023_003Dz9jrlnWk_003D, bool _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3 = _0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		_0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(_0023_003DzMh9fpsrV7xUwB1K2EgX2tfUWew5dt6F9NReQZI2de8Um(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2, _0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D));
	}

	private void _0023_003DzqVyXuYAwQKQpRX1kaiNBtsUGXia0KVUABA_003D_003D(bool _0023_003Dz9jrlnWk_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		bool flag = IntPtr.Size == 4;
		checked
		{
			IntPtr intPtr;
			switch (_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D())
			{
			case 1:
			{
				int num = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
				intPtr = ((!flag) ? ((!_0023_003Dz9jrlnWk_003D) ? new IntPtr(unchecked((uint)num)) : new IntPtr((uint)num)) : ((!_0023_003Dz9jrlnWk_003D) ? new IntPtr(num) : new IntPtr((int)(uint)num)));
				break;
			}
			case 13:
			{
				long num2 = ((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG();
				intPtr = ((!flag) ? ((!_0023_003Dz9jrlnWk_003D) ? new IntPtr(num2) : new IntPtr((long)(ulong)num2)) : ((!_0023_003Dz9jrlnWk_003D) ? new IntPtr(unchecked((int)num2)) : new IntPtr((int)(ulong)num2)));
				break;
			}
			case 8:
			{
				double num3 = ((_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzCfXuHVIlFp1X1u2Med2_AL4lzej8EifTBw_003D_003D();
				intPtr = ((!flag) ? ((!_0023_003Dz9jrlnWk_003D) ? new IntPtr(unchecked((long)num3)) : new IntPtr((long)(ulong)num3)) : ((!_0023_003Dz9jrlnWk_003D) ? new IntPtr(unchecked((int)(ulong)num3)) : new IntPtr((int)(ulong)num3)));
				break;
			}
			case 19:
				intPtr = ((!_0023_003Dz9jrlnWk_003D) ? new IntPtr(Convert.ToInt64(((_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D())) : new IntPtr(Convert.ToInt64(((_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D())));
				break;
			default:
				throw new InvalidOperationException();
			}
			_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D obj = new _0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D();
			obj._0023_003DzXFR8k7cM8wiYjjnXjPEa5idSBqAKmHeRH0GHZG0_003D(intPtr);
			_0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(obj);
		}
	}

	private static void _0023_003DziSPfAZ8tnEP9Tf435t5phnGI_0024C9u(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzwbI83bfoaDmYaZBDzj4leqo_003D(((_0023_003DqIC7wdNmeVLrKuHjiCL8jtht_0024ogaMGYTl_vFxiqwcERQ_003D)_0023_003DzBxpHhQ0_003D)._0023_003Dz3fdyocpuocHKnMPBAP0IP10_003D());
	}

	private static bool _0023_003DzHnO_bniO5s0D60KJ0LJSOH0Xtrib()
	{
		return false;
	}

	private static object _0023_003DzTtHhYD7wYomyazLD30cjaJao7oFKwWOoYw_003D_003D(MethodBase _0023_003Dz9jrlnWk_003D, object _0023_003DzBxpHhQ0_003D, object[] _0023_003Dztgqm2r4_003D, bool _0023_003DzzKDx05I_003D)
	{
		if (!_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D._0023_003DzzKDx05I_003D._0023_003Dz9jrlnWk_003D)
		{
			return _0023_003Dzen6M6suXozc4dDI9Ng_003D_003D(_0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D);
		}
		return _0023_003Dz_hjrZDOTOQR8OWbqvQxPmsVMHYb0ynulxddSkJRnCboe(_0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D, _0023_003DzzKDx05I_003D);
	}

	private static void _0023_003DztFjfZQi0sawOYacPQjs3zu0_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		int num = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
		Type type = _0023_003Dz9jrlnWk_003D._0023_003Dz9_Z5EhGFT4yzpTmOPYjfhZOeNABFeUtCmZ_KeWA_003D(num, _0023_003DzBxpHhQ0_003D: true);
		_0023_003Dz9jrlnWk_003D._0023_003DzUbKftaPsoH4C3o3km5CXFp43OkI85ZTJMKNMSEuJ_LI5(type);
	}

	private static void _0023_003DzwHUbBs_0024_0024ESjjtuZM_iev_w2ht_gi(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		int num = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
		_0023_003Dz9jrlnWk_003D._0023_003Dzn6_Dl38_003D = _0023_003Dz9jrlnWk_003D._0023_003Dz9_Z5EhGFT4yzpTmOPYjfhZOeNABFeUtCmZ_KeWA_003D(num, _0023_003DzBxpHhQ0_003D: true);
	}

	private static void _0023_003DzpQwpRUk9CF7rDYKcaj1Hh4E_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003Dzl01rdMbhKWqXEDpjHctwRZgIgliJDTg7bQ_003D_003D(2);
	}

	private static void _0023_003DzigDb8O3hamCs_I4BBKv3Q3tjZO864azkpg_003D_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003Dz_bTfuOd_0024_8tksF6orA_003D_003D(_0023_003DqqSQMR5x0Ss3kUZAkPHTc7q6IdaUzR_0024BTopvbTI_0024P7DA_003D._0023_003Dz9jrlnWk_003D);
	}

	private void _0023_003DzdjM_2jv3RJCvz2e7G8N4hr_tmbjLldgOzkQHpdc_003D(ref _0023_003Dztgqm2r4_003D _0023_003Dz9jrlnWk_003D, MethodBase _0023_003DzBxpHhQ0_003D, bool _0023_003Dztgqm2r4_003D)
	{
		bool flag = false;
		if (_0023_003DzBxpHhQ0_003D.DeclaringType == typeof(Interlocked) && _0023_003DzBxpHhQ0_003D.IsStatic)
		{
			string name = _0023_003DzBxpHhQ0_003D.Name;
			if (name == _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564315383) || name == _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564315389) || name == _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564315351) || name == _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564315335) || name == _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564315192) || name == _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564315176))
			{
				flag = true;
			}
		}
		if (flag)
		{
			try
			{
			}
			finally
			{
				Monitor.Enter(_0023_003DzbLHaDy4_003D);
				_0023_003Dz9jrlnWk_003D._0023_003Dz9jrlnWk_003D = true;
			}
		}
	}

	private static void _0023_003DzsP87gCsFI0Lk2RkmRzlV83zp0c_0024lhMbfTA_003D_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		int num = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
		Type type = _0023_003Dz9jrlnWk_003D._0023_003Dz9_Z5EhGFT4yzpTmOPYjfhZOeNABFeUtCmZ_KeWA_003D(num, _0023_003DzBxpHhQ0_003D: true);
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		if (_0023_003Dz9jrlnWk_003D._0023_003DzFDdYEW_UBGDFCKATfJ3Fdq4UMQmKapQVSw_003D_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2, type))
		{
			_0023_003Dz9jrlnWk_003D._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2);
			return;
		}
		throw new InvalidCastException();
	}

	private string _0023_003Dza3Vg0pbdAn80NfoL4a4_NphXc70V(_0023_003DqaEtT9DoRRoUP_0024LS5u4B6AojK4YaTqiLM3Vc605IaRGE_003D _0023_003Dz9jrlnWk_003D)
	{
		Type type = _0023_003Dz9_Z5EhGFT4yzpTmOPYjfhZOeNABFeUtCmZ_KeWA_003D(_0023_003Dz9jrlnWk_003D._0023_003DzUaXoJXQwrrbCr0Kl7wUIRwaCDGvQifXoCg_003D_003D(), _0023_003DzBxpHhQ0_003D: false);
		_0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024h3HXCPh1byVa5xQgwlyKcE_003D[] array = _0023_003Dz9jrlnWk_003D._0023_003DzPFkh31N3VRlmNc8nf2IWmYdUiYAF();
		string[] array2 = new string[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array2[i] = _0023_003Dz9_Z5EhGFT4yzpTmOPYjfhZOeNABFeUtCmZ_KeWA_003D(array[i]._0023_003DzBLbiSG4pMsCq5QXcv4IAsSJsqlAkD0L7ST9ge5Ogka39(), _0023_003DzBxpHhQ0_003D: false)?.FullName;
		}
		string text = string.Join(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313849), array2);
		return type.FullName + _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313907) + _0023_003Dz9jrlnWk_003D._0023_003DznreDdTd5uS_MeC2m0FTHaTTa0lrL() + _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313840) + text + _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313816);
	}

	private static void _0023_003DzFk7xxymk2d_phfUMshe_0024hocErdzo0jSO_yygYe4_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzLMJxSSXveUKWgX7ByprFEtw_003D(typeof(byte));
	}

	private static void _0023_003DzFj4UeBpunCurXZBNM_0024LoGr15rGb8(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003Dzy4D_00248buHMHsvaKDXIg_003D_003D(-1);
	}

	private static bool _0023_003Dz85ZnAjLw5GuUis_0024G0X_hQ3rZyzLji_2Y9G_l2yE_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		bool flag = false;
		switch (_0023_003Dz9jrlnWk_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D())
		{
		case 1:
			return (uint)((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D() > (uint)((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
		case 13:
			return (ulong)((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG() > (ulong)((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG();
		case 8:
		{
			double num3 = ((_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzCfXuHVIlFp1X1u2Med2_AL4lzej8EifTBw_003D_003D();
			double num4 = ((_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzCfXuHVIlFp1X1u2Med2_AL4lzej8EifTBw_003D_003D();
			return num3 > num4 || double.IsNaN(num3) || double.IsNaN(num4);
		}
		case 0:
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 7 && _0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D() == null)
			{
				return ((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk() != IntPtr.Zero;
			}
			return ((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk() != ((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk();
		case 20:
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 7 && _0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D() == null)
			{
				return ((_0023_003DqVEj3J19zkgEyU6VFymBz6riyi6CxZMJEjhA0KZ2nLKw_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzZlwwYywinAe9h_2ss_0024Wn4RsajDr79HfGCg_003D_003D() != UIntPtr.Zero;
			}
			return ((_0023_003DqVEj3J19zkgEyU6VFymBz6riyi6CxZMJEjhA0KZ2nLKw_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzZlwwYywinAe9h_2ss_0024Wn4RsajDr79HfGCg_003D_003D() != ((_0023_003DqVEj3J19zkgEyU6VFymBz6riyi6CxZMJEjhA0KZ2nLKw_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzZlwwYywinAe9h_2ss_0024Wn4RsajDr79HfGCg_003D_003D();
		case 7:
			return ((_0023_003DqcjmfsaS6dKPuf2kSTqJKWfH_rgkc03gEAn6QEKAtpbA_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzKuvp4FpGZEHp_0024htPxx_00248SXawDH8Tdf_0Y48dwaP_bCrZ() != ((_0023_003DqcjmfsaS6dKPuf2kSTqJKWfH_rgkc03gEAn6QEKAtpbA_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzKuvp4FpGZEHp_0024htPxx_00248SXawDH8Tdf_0Y48dwaP_bCrZ();
		case 25:
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 7 && _0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D() == null)
			{
				return true;
			}
			return ((_0023_003DqCQNt2PbLdd9_Rj2n9YXdbVSA5Tqe2xDUhLSUbOVu_TU_003D)_0023_003Dz9jrlnWk_003D)._0023_003Dz39zZnN4wvB6luYqBEUduvsXAH_XP() != ((_0023_003DqCQNt2PbLdd9_Rj2n9YXdbVSA5Tqe2xDUhLSUbOVu_TU_003D)_0023_003DzBxpHhQ0_003D)._0023_003Dz39zZnN4wvB6luYqBEUduvsXAH_XP();
		case 19:
		{
			long num = Convert.ToInt64(((_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D());
			long num2 = ((_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() != 1) ? Convert.ToInt64(((_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D()) : ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D());
			return num > num2;
		}
		default:
			return _0023_003Dz9jrlnWk_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D() != _0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D();
		}
	}

	private static void _0023_003Dz3xZVxFkZ6ummVo5sYrMj5XF2K0R5eC_WhiWf7_00242vp26e(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzgsEHju8wslk_S93hiFuhVTuq_cvn();
	}

	private static void _0023_003DzEhdKQwi_0024dMz0tJlFcItEZNpDiwGL6RVUtblfp9E_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzUbKftaPsoH4C3o3km5CXFp43OkI85ZTJMKNMSEuJ_LI5(typeof(float));
	}

	private FieldInfo _0023_003DzxFlP9j6hwChqbnCQxNoxN7LJpAh_00242zp2XpETVEHUh_9i(int _0023_003Dz9jrlnWk_003D)
	{
		lock (_0023_003DzZpkUTwY_003D)
		{
			bool flag = true;
			FieldInfo fieldInfo;
			if (flag && _0023_003DzZpkUTwY_003D.TryGetValue(_0023_003Dz9jrlnWk_003D, out var value))
			{
				fieldInfo = (FieldInfo)value;
			}
			else
			{
				_0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D _0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D2 = _0023_003Dz_kQ6vjzn2xXdxKzdPsJwstuDR14y(_0023_003Dz9jrlnWk_003D);
				fieldInfo = _0023_003DzwQg01J_0024guWgqtV0FWjpTbyjA8_c2waAWaEPl_0024sdz0Zct(_0023_003Dz9jrlnWk_003D, _0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D2, ref flag);
				if (flag)
				{
					_0023_003DzZpkUTwY_003D.Add(_0023_003Dz9jrlnWk_003D, fieldInfo);
				}
			}
			_0023_003DzRDsD2tmbbWicD3F3bHfTv5w75vMCZrFqbQ_003D_003D(fieldInfo);
			return fieldInfo;
		}
	}

	private static void _0023_003Dzzv9ZmkimVib67S8QHkI51Nc_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzpU_n7PfnyRyJ1anIgJrsjiSffFPi(1);
	}

	private static bool _0023_003DzFCI8XumDuJuKa_0024WkwlglF8STueBuOL3SGHPfX6c_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		bool result = false;
		switch (_0023_003Dz9jrlnWk_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D())
		{
		case 1:
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 19)
			{
				return _0023_003DzFCI8XumDuJuKa_0024WkwlglF8STueBuOL3SGHPfX6c_003D(_0023_003Dz9jrlnWk_003D, new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(Convert.ToInt32(((_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D())));
			}
			result = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D() > ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
			break;
		case 13:
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 19)
			{
				return _0023_003DzFCI8XumDuJuKa_0024WkwlglF8STueBuOL3SGHPfX6c_003D(_0023_003Dz9jrlnWk_003D, new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(Convert.ToInt64(((_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D())));
			}
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 1)
			{
				return _0023_003DzFCI8XumDuJuKa_0024WkwlglF8STueBuOL3SGHPfX6c_003D(_0023_003Dz9jrlnWk_003D, new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D()));
			}
			result = ((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG() > ((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG();
			break;
		case 19:
			return _0023_003DzFCI8XumDuJuKa_0024WkwlglF8STueBuOL3SGHPfX6c_003D(new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(Convert.ToInt64(((_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D())), _0023_003DzBxpHhQ0_003D);
		case 8:
		{
			double num = ((_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzCfXuHVIlFp1X1u2Med2_AL4lzej8EifTBw_003D_003D();
			double num2 = ((_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzCfXuHVIlFp1X1u2Med2_AL4lzej8EifTBw_003D_003D();
			result = !double.IsNaN(num) && !double.IsNaN(num2) && num > num2;
			break;
		}
		}
		return result;
	}

	private static void _0023_003DzmbDvNgREmKTcuJBwbsTAFE0_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(_0023_003DzBxpHhQ0_003D);
	}

	private static void _0023_003DzjhFfjTX96eNYjnenBqyJ6uHFt5nU(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzLMJxSSXveUKWgX7ByprFEtw_003D(_0023_003DzozZCuko_003D);
	}

	private bool _0023_003DzBO3Ilbfhn_0024RPcT20FNuhSKE_003D(MethodInfo _0023_003Dz9jrlnWk_003D, _0023_003Dq9cxJfzt6tx3_00245xLDM_0024HAnunU7Xy_WBpJRmOB2qxzSUo_003D _0023_003DzBxpHhQ0_003D, Type[] _0023_003Dztgqm2r4_003D, out int _0023_003DzzKDx05I_003D)
	{
		_0023_003DzzKDx05I_003D = 0;
		if (!_0023_003Dz9jrlnWk_003D.IsGenericMethodDefinition)
		{
			return false;
		}
		ParameterInfo[] parameters = _0023_003Dz9jrlnWk_003D.GetParameters();
		if (parameters.Length != _0023_003DzBxpHhQ0_003D._0023_003DzD9Pned40_22MDiBp0NMYEuJd2lu1().Length)
		{
			return false;
		}
		if (_0023_003Dz9jrlnWk_003D.GetGenericArguments().Length != _0023_003DzBxpHhQ0_003D._0023_003Dz5SLJKaXSSdFcGzANZ5mlfVM8CIKqSp8P5R3lEWI_003D().Length)
		{
			return false;
		}
		for (int i = -1; i < parameters.Length; i++)
		{
			Type type = ((i == -1) ? _0023_003Dz9jrlnWk_003D.ReturnType : parameters[i].ParameterType);
			if (_0023_003Dztgqm2r4_003D != null && type.IsGenericParameter && type.DeclaringMethod != null)
			{
				type = _0023_003Dztgqm2r4_003D[type.GenericParameterPosition] ?? type;
			}
			_0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D _0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D2 = ((i == -1) ? _0023_003DzBxpHhQ0_003D._0023_003DzVwJz1Iz1BL8jSL84NMBvRG1hvuNL() : _0023_003DzBxpHhQ0_003D._0023_003DzD9Pned40_22MDiBp0NMYEuJd2lu1()[i]);
			if (_0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D2 != null)
			{
				if (!_0023_003Dz1MV5OPCzVE_0024wxwQZ4aZ07_0_003D(type, _0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D2, out var num))
				{
					return false;
				}
				if (i >= 0)
				{
					_0023_003DzzKDx05I_003D += num;
				}
			}
		}
		return true;
	}

	public object _0023_003Dzba56eiY_00246LwqYYpQhD5mb4nQDFzs9RQkbkZP8yo_003D(Stream _0023_003Dz9jrlnWk_003D, string _0023_003DzBxpHhQ0_003D, object[] _0023_003Dztgqm2r4_003D, Type[] _0023_003DzzKDx05I_003D, Type[] _0023_003Dz3iPku7s_003D, object[] _0023_003Dz2X8kE24_003D)
	{
		this.m__0023_003DzJGsRSpg_003D = _0023_003Dz9jrlnWk_003D;
		_0023_003DzwsEtczsaGDQbpZzX7NSFPNZxAR8k981u4kunv8b09cFx(_0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D);
		return _0023_003DzQ8LhpS1xxZOzfa_xwe0pkshtYH921DtIc7CslMVRHi4c(_0023_003Dztgqm2r4_003D, _0023_003DzzKDx05I_003D, _0023_003Dz3iPku7s_003D, _0023_003Dz2X8kE24_003D);
	}

	private static void _0023_003Dzu_r1Mkbqq_0024s5Hb2QGZYLKyjVXZtaOhXw4GZ_0024Di4_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3 = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		_0023_003Dz9jrlnWk_003D._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(_0023_003Dz85ZnAjLw5GuUis_0024G0X_hQ3rZyzLji_2Y9G_l2yE_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2) ? 1 : 0));
	}

	private static void _0023_003DzVcw_0024XQCvel5p8jZSd02e7PnZ2pJID6fFSQ_003D_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003DqJFdrGiwz1aJICVkSTb_0024Zkh7zAYa9iZm47EqlnjrFUg4_003D _0023_003DqJFdrGiwz1aJICVkSTb_0024Zkh7zAYa9iZm47EqlnjrFUg4_003D2 = (_0023_003DqJFdrGiwz1aJICVkSTb_0024Zkh7zAYa9iZm47EqlnjrFUg4_003D)_0023_003DzBxpHhQ0_003D;
		_0023_003Dz9jrlnWk_003D._0023_003DzpU_n7PfnyRyJ1anIgJrsjiSffFPi(_0023_003DqJFdrGiwz1aJICVkSTb_0024Zkh7zAYa9iZm47EqlnjrFUg4_003D2._0023_003Dzi58Fb_0024k5T0u9_0024uYc9Q_003D_003D());
	}

	private static void _0023_003DzZxxCTFOYkwbhg0Yadiz2hB4_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzRAdSm4DyRDmN2214hLLTypI_003D(_0023_003Dz9jrlnWk_003D: false);
	}

	private static void _0023_003Dz3YOH_0024vniUhBBFdVzivNMBF_0024zvhCsNG7ZnCa7frg_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(_0023_003DzBxpHhQ0_003D);
	}

	private static void _0023_003Dz6rSvcwlzaarKct8UK76RMEe3IoHnX_SkOfscGw4_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzRAdSm4DyRDmN2214hLLTypI_003D(_0023_003Dz9jrlnWk_003D: true);
	}

	private static void _0023_003DzipmHwPhZN9VbWEUGToDppXTMBBG1(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DztKL1iK5LvFaLq_0024Salhy_v0MVryh8FAXmFefkbvo_003D();
	}

	private static void _0023_003Dz06f7_0024LT0nNC_Fu6W0Z5lBuK4cge3SQTX4ubm72I_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DztKL1iK5LvFaLq_0024Salhy_v0MVryh8FAXmFefkbvo_003D();
	}

	private static void _0023_003Dzlii0xfNVsq1Npe23kU7VUK6HqKBRkpxbS2oUmTo_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzUbKftaPsoH4C3o3km5CXFp43OkI85ZTJMKNMSEuJ_LI5(typeof(long));
	}

	private static void _0023_003DzFLxF4ENOvxKxcC_0024w8AaQsxro7CqHRgL9Mu1RQWabtEW4(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzUbKftaPsoH4C3o3km5CXFp43OkI85ZTJMKNMSEuJ_LI5(typeof(ushort));
	}

	private static _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzqWLtQKrpdOoIPJiYig_003D_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D, bool _0023_003Dztgqm2r4_003D, bool _0023_003DzzKDx05I_003D)
	{
		if (_0023_003Dz9jrlnWk_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 1)
		{
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 1)
			{
				if (!_0023_003DzzKDx05I_003D)
				{
					int num = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
					int num2 = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
					int num3 = ((!_0023_003Dztgqm2r4_003D) ? (num - num2) : checked(num - num2));
					return new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(num3);
				}
				uint num4 = (uint)((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
				uint num5 = (uint)((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
				uint num6 = ((!_0023_003Dztgqm2r4_003D) ? (num4 - num5) : checked(num4 - num5));
				return new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D((int)num6);
			}
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 13)
			{
				return _0023_003DzVjfAUuwt5Hcy8zXS_0024Q_003D_003D(new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D()), _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D, _0023_003DzzKDx05I_003D);
			}
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 19)
			{
				Type underlyingType = Enum.GetUnderlyingType(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D().GetType());
				if (underlyingType == typeof(long) || underlyingType == typeof(ulong))
				{
					return _0023_003DzVjfAUuwt5Hcy8zXS_0024Q_003D_003D(new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D()), new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(Convert.ToInt64(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D())), _0023_003Dztgqm2r4_003D, _0023_003DzzKDx05I_003D);
				}
				return _0023_003DzqWLtQKrpdOoIPJiYig_003D_003D(_0023_003Dz9jrlnWk_003D, new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(Convert.ToInt32(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D())), _0023_003Dztgqm2r4_003D, _0023_003DzzKDx05I_003D);
			}
		}
		if (_0023_003Dz9jrlnWk_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 13)
		{
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 13)
			{
				return _0023_003DzVjfAUuwt5Hcy8zXS_0024Q_003D_003D(_0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D, _0023_003DzzKDx05I_003D);
			}
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 1)
			{
				return _0023_003DzVjfAUuwt5Hcy8zXS_0024Q_003D_003D(_0023_003Dz9jrlnWk_003D, new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D()), _0023_003Dztgqm2r4_003D, _0023_003DzzKDx05I_003D);
			}
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 19)
			{
				Type underlyingType2 = Enum.GetUnderlyingType(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D().GetType());
				if (underlyingType2 == typeof(long) || underlyingType2 == typeof(ulong))
				{
					return _0023_003DzVjfAUuwt5Hcy8zXS_0024Q_003D_003D(_0023_003Dz9jrlnWk_003D, new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(Convert.ToInt64(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D())), _0023_003Dztgqm2r4_003D, _0023_003DzzKDx05I_003D);
				}
				return _0023_003DzVjfAUuwt5Hcy8zXS_0024Q_003D_003D(_0023_003Dz9jrlnWk_003D, new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(Convert.ToInt32(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D())), _0023_003Dztgqm2r4_003D, _0023_003DzzKDx05I_003D);
			}
		}
		if (_0023_003Dz9jrlnWk_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 8 && _0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 8)
		{
			_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D obj = new _0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D();
			obj._0023_003DzBGdDQOw_INWgxm_K091ViE8d5B7H7_X_0024gA2NQZA_003D(((_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzCfXuHVIlFp1X1u2Med2_AL4lzej8EifTBw_003D_003D() - ((_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzCfXuHVIlFp1X1u2Med2_AL4lzej8EifTBw_003D_003D());
			return obj;
		}
		if (_0023_003Dz9jrlnWk_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 19)
		{
			Type underlyingType3 = Enum.GetUnderlyingType(_0023_003Dz9jrlnWk_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D().GetType());
			if (underlyingType3 == typeof(long) || underlyingType3 == typeof(ulong))
			{
				return _0023_003DzqWLtQKrpdOoIPJiYig_003D_003D(new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(Convert.ToInt64(_0023_003Dz9jrlnWk_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D())), _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D, _0023_003DzzKDx05I_003D);
			}
			return _0023_003DzqWLtQKrpdOoIPJiYig_003D_003D(new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(Convert.ToInt32(_0023_003Dz9jrlnWk_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D())), _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D, _0023_003DzzKDx05I_003D);
		}
		throw new InvalidOperationException();
	}

	private static void _0023_003DzMbnRSPlbW61fGp_7FbWj6N8_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzUbKftaPsoH4C3o3km5CXFp43OkI85ZTJMKNMSEuJ_LI5(typeof(byte));
	}

	private static void _0023_003DzKeF8ji6o3nQuAzsVXJGh1E7BVXZqV7eRddXmWyk_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		int num = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
		Type type = _0023_003Dz9jrlnWk_003D._0023_003Dz9_Z5EhGFT4yzpTmOPYjfhZOeNABFeUtCmZ_KeWA_003D(num, _0023_003DzBxpHhQ0_003D: true);
		_0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D _0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D2 = (_0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D)_0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		if (type.IsValueType)
		{
			object obj = _0023_003Dz9jrlnWk_003D._0023_003DzcyfMbnJemFaR1U9IYqWp0cPmk80NlqUX5LErUtBcWaeU(_0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D2)._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D();
			if (_0023_003DqqSQMR5x0Ss3kUZAkPHTc7q6IdaUzR_0024BTopvbTI_0024P7DA_003D._0023_003Dzt6IW3o7Q3_0024kDG1z4CqtvMH1iuswjFBlVqVIQyrQ_003D(type))
			{
				_0023_003DqcjmfsaS6dKPuf2kSTqJKWfH_rgkc03gEAn6QEKAtpbA_003D obj2 = new _0023_003DqcjmfsaS6dKPuf2kSTqJKWfH_rgkc03gEAn6QEKAtpbA_003D();
				obj2._0023_003DzsZLDUvjyYZRtLY91huCrFGofhAyP(type);
				_0023_003Dz9jrlnWk_003D._0023_003DzlLFsRbFCVJXLxNmd_0024gDP8S8_003D(_0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D2, obj2);
				return;
			}
			FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy);
			foreach (FieldInfo fieldInfo in fields)
			{
				fieldInfo.SetValue(obj, _0023_003DzW_0024Lnk2nu331k049aW0j9JP6ILlHXsAn69XlYchQ_003D(fieldInfo.FieldType));
			}
		}
		else
		{
			_0023_003Dz9jrlnWk_003D._0023_003DzlLFsRbFCVJXLxNmd_0024gDP8S8_003D(_0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D2, new _0023_003DqcjmfsaS6dKPuf2kSTqJKWfH_rgkc03gEAn6QEKAtpbA_003D());
		}
	}

	private static string _0023_003DzHhUu5sIMPQK8hMO51mJkVwpkxgDLTRh_0024O6_uK4s_003D(MethodBase _0023_003Dz9jrlnWk_003D)
	{
		Type declaringType = _0023_003Dz9jrlnWk_003D.DeclaringType;
		ParameterInfo[] parameters = _0023_003Dz9jrlnWk_003D.GetParameters();
		string[] array = new string[parameters.Length];
		for (int i = 0; i < parameters.Length; i++)
		{
			ParameterInfo parameterInfo = parameters[i];
			array[i] = string.Format(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564315269), parameterInfo.ParameterType, parameterInfo.Name);
		}
		string text = string.Join(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313849), array);
		return declaringType.FullName + _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313907) + _0023_003Dz9jrlnWk_003D.Name + _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313840) + text + _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313816);
	}

	private static void _0023_003Dz0dtMxE1pQ9G7RAsOHGQ0T_tItxmU(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003Dzy4D_00248buHMHsvaKDXIg_003D_003D(6);
	}

	private static void _0023_003DzkgcLGaYKSANQ0zYUBf_0024wNX2_00249iiefdMtg3qtiEnf5A9t(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		_0023_003Dz9jrlnWk_003D._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(checked(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() switch
		{
			1 => (byte)(uint)((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D(), 
			13 => (byte)(ulong)((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG(), 
			19 => (byte)Convert.ToUInt64(((_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D()), 
			8 => (byte)((_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzCfXuHVIlFp1X1u2Med2_AL4lzej8EifTBw_003D_003D(), 
			0 => (IntPtr.Size != 4) ? ((byte)(ulong)(long)((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk()) : ((byte)(uint)(int)((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk()), 
			_ => throw new InvalidOperationException(), 
		})));
	}

	private static void _0023_003Dz5o3E2IuM_EW8WGhIaM0FLPE8Ytju17uPFfOaAd4hu4Jj(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003Dz_bTfuOd_0024_8tksF6orA_003D_003D(typeof(float));
	}

	private FieldInfo _0023_003DzwQg01J_0024guWgqtV0FWjpTbyjA8_c2waAWaEPl_0024sdz0Zct(int _0023_003Dz9jrlnWk_003D, _0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D _0023_003DzBxpHhQ0_003D, ref bool _0023_003Dztgqm2r4_003D)
	{
		if (_0023_003DzBxpHhQ0_003D._0023_003DzwH8K7lD_0024cC3gY_RIDCO_Bu8Tp6tgtXa0TA_003D_003D() == 0)
		{
			_0023_003Dztgqm2r4_003D = false;
			return this.m__0023_003DzJ6W8874_003D.ResolveField(_0023_003DzBxpHhQ0_003D._0023_003DztkhwzVeVIldXjs1hyonqsqcuOAEF());
		}
		_0023_003DqJTjaQmhkW8F60LVdPhnyD_0024jn8xWIZNbFd7YUJbbVpeY_003D _0023_003DqJTjaQmhkW8F60LVdPhnyD_0024jn8xWIZNbFd7YUJbbVpeY_003D2 = (_0023_003DqJTjaQmhkW8F60LVdPhnyD_0024jn8xWIZNbFd7YUJbbVpeY_003D)_0023_003DzBxpHhQ0_003D._0023_003DzMDpHhtfRNQDKXWsFcSVSbdd3Ewg6();
		Type type = _0023_003Dz9_Z5EhGFT4yzpTmOPYjfhZOeNABFeUtCmZ_KeWA_003D(_0023_003DqJTjaQmhkW8F60LVdPhnyD_0024jn8xWIZNbFd7YUJbbVpeY_003D2._0023_003Dz23iVsTeVD87_QZQJJWot6YlfmDtjCrR6ag_003D_003D()._0023_003DztkhwzVeVIldXjs1hyonqsqcuOAEF(), _0023_003DzBxpHhQ0_003D: false);
		if (type.IsGenericType)
		{
			_0023_003Dztgqm2r4_003D = false;
		}
		return type.GetField(bindingAttr: _0023_003DzuaMQqJs9btKMSh09c00zb_0024YVVB_00247VcQqiw_003D_003D(_0023_003DqJTjaQmhkW8F60LVdPhnyD_0024jn8xWIZNbFd7YUJbbVpeY_003D2._0023_003DzyKFk3Dc8ko9Hbbsv2JWIdOg_003D()), name: _0023_003DqJTjaQmhkW8F60LVdPhnyD_0024jn8xWIZNbFd7YUJbbVpeY_003D2._0023_003Dz_bXguEDGPFmhYVikBo58OOXpBk4h());
	}

	private static void _0023_003DzXqYlHapQtnE1oNZCx2bGOSKCurR8(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3 = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		_0023_003Dz9jrlnWk_003D._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(_0023_003Dz9jrlnWk_003D._0023_003Dzeu0x6kGh6v4nZT631vG00XRKXaEe(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2));
	}

	private static void _0023_003DzlcZANZLiDUKvnpMSBIp9CKPgBBDc(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzriXIwLFCuwD1GZVAt_00248x4do_003D(_0023_003Dz9jrlnWk_003D: false, _0023_003DzBxpHhQ0_003D: false);
	}

	public object _0023_003DzBTpzeAE0bM5yqB3CifI7jV0_003D(Stream _0023_003Dz9jrlnWk_003D, string _0023_003DzBxpHhQ0_003D, object[] _0023_003Dztgqm2r4_003D)
	{
		return _0023_003Dzba56eiY_00246LwqYYpQhD5mb4nQDFzs9RQkbkZP8yo_003D(_0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D, null, null, null);
	}

	private static void _0023_003DzlKtSaCzE_0024_Lp1sPUeA_003D_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		double num = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() switch
		{
			1 => ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D(), 
			13 => ((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG(), 
			19 => Convert.ToUInt64(((_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D()), 
			8 => ((_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzCfXuHVIlFp1X1u2Med2_AL4lzej8EifTBw_003D_003D(), 
			_ => throw new InvalidOperationException(), 
		};
		_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D obj = new _0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D();
		obj._0023_003DzBGdDQOw_INWgxm_K091ViE8d5B7H7_X_0024gA2NQZA_003D(num);
		_0023_003Dz9jrlnWk_003D._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(obj);
	}

	private static _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzMh9fpsrV7xUwB1K2EgX2tfUWew5dt6F9NReQZI2de8Um(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D, bool _0023_003Dztgqm2r4_003D, bool _0023_003DzzKDx05I_003D)
	{
		if (_0023_003Dz9jrlnWk_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 1)
		{
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 1)
			{
				if (!_0023_003DzzKDx05I_003D)
				{
					int num = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
					int num2 = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
					int num3 = ((!_0023_003Dztgqm2r4_003D) ? (num * num2) : checked(num * num2));
					return new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(num3);
				}
				uint num4 = (uint)((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
				uint num5 = (uint)((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
				uint num6 = ((!_0023_003Dztgqm2r4_003D) ? (num4 * num5) : checked(num4 * num5));
				return new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D((int)num6);
			}
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 13)
			{
				return _0023_003Dz8PDB4fIscUcZmlCotGqEYZVtBdP3(new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D()), _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D, _0023_003DzzKDx05I_003D);
			}
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 19)
			{
				Type underlyingType = Enum.GetUnderlyingType(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D().GetType());
				if (underlyingType == typeof(long) || underlyingType == typeof(ulong))
				{
					return _0023_003Dz8PDB4fIscUcZmlCotGqEYZVtBdP3(new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D()), new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(Convert.ToInt64(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D())), _0023_003Dztgqm2r4_003D, _0023_003DzzKDx05I_003D);
				}
				return _0023_003DzMh9fpsrV7xUwB1K2EgX2tfUWew5dt6F9NReQZI2de8Um(_0023_003Dz9jrlnWk_003D, new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(Convert.ToInt32(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D())), _0023_003Dztgqm2r4_003D, _0023_003DzzKDx05I_003D);
			}
		}
		if (_0023_003Dz9jrlnWk_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 13)
		{
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 13)
			{
				return _0023_003Dz8PDB4fIscUcZmlCotGqEYZVtBdP3(_0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D, _0023_003DzzKDx05I_003D);
			}
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 1)
			{
				return _0023_003Dz8PDB4fIscUcZmlCotGqEYZVtBdP3(_0023_003Dz9jrlnWk_003D, new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D()), _0023_003Dztgqm2r4_003D, _0023_003DzzKDx05I_003D);
			}
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 19)
			{
				Type underlyingType2 = Enum.GetUnderlyingType(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D().GetType());
				if (underlyingType2 == typeof(long) || underlyingType2 == typeof(ulong))
				{
					return _0023_003Dz8PDB4fIscUcZmlCotGqEYZVtBdP3(_0023_003Dz9jrlnWk_003D, new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(Convert.ToInt64(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D())), _0023_003Dztgqm2r4_003D, _0023_003DzzKDx05I_003D);
				}
				return _0023_003Dz8PDB4fIscUcZmlCotGqEYZVtBdP3(_0023_003Dz9jrlnWk_003D, new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(Convert.ToInt32(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D())), _0023_003Dztgqm2r4_003D, _0023_003DzzKDx05I_003D);
			}
		}
		if (_0023_003Dz9jrlnWk_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 8 && _0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 8)
		{
			_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D obj = new _0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D();
			obj._0023_003DzBGdDQOw_INWgxm_K091ViE8d5B7H7_X_0024gA2NQZA_003D(((_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzCfXuHVIlFp1X1u2Med2_AL4lzej8EifTBw_003D_003D() * ((_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzCfXuHVIlFp1X1u2Med2_AL4lzej8EifTBw_003D_003D());
			return obj;
		}
		if (_0023_003Dz9jrlnWk_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 19)
		{
			Type underlyingType3 = Enum.GetUnderlyingType(_0023_003Dz9jrlnWk_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D().GetType());
			if (underlyingType3 == typeof(long) || underlyingType3 == typeof(ulong))
			{
				return _0023_003DzMh9fpsrV7xUwB1K2EgX2tfUWew5dt6F9NReQZI2de8Um(new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(Convert.ToInt64(_0023_003Dz9jrlnWk_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D())), _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D, _0023_003DzzKDx05I_003D);
			}
			return _0023_003DzMh9fpsrV7xUwB1K2EgX2tfUWew5dt6F9NReQZI2de8Um(new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(Convert.ToInt32(_0023_003Dz9jrlnWk_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D())), _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D, _0023_003DzzKDx05I_003D);
		}
		throw new InvalidOperationException();
	}

	private static _0023_003Dz2X8kE24_003D _0023_003DzP9DYLkLIEF_53eX_kDzC0nc9_0024AzF(MethodBase _0023_003Dz9jrlnWk_003D, bool _0023_003DzBxpHhQ0_003D)
	{
		DynamicMethod dynamicMethod = null;
		if (dynamicMethod == null)
		{
			dynamicMethod = new DynamicMethod(string.Empty, _0023_003DqqSQMR5x0Ss3kUZAkPHTc7q6IdaUzR_0024BTopvbTI_0024P7DA_003D._0023_003Dz9jrlnWk_003D, new Type[2]
			{
				_0023_003DqqSQMR5x0Ss3kUZAkPHTc7q6IdaUzR_0024BTopvbTI_0024P7DA_003D._0023_003Dz9jrlnWk_003D,
				_0023_003Dz7SVqS2w_003D
			}, typeof(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D).Module, skipVisibility: true);
		}
		ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
		ParameterInfo[] parameters = _0023_003Dz9jrlnWk_003D.GetParameters();
		Type[] array = new Type[parameters.Length];
		bool flag = false;
		for (int i = 0; i < parameters.Length; i++)
		{
			Type type = parameters[i].ParameterType;
			if (type.IsByRef)
			{
				flag = true;
				type = type.GetElementType();
			}
			array[i] = type;
		}
		LocalBuilder[] array2 = new LocalBuilder[array.Length];
		if (array2.Length != 0)
		{
			dynamicMethod.InitLocals = true;
		}
		for (int j = 0; j < array.Length; j++)
		{
			array2[j] = iLGenerator.DeclareLocal(array[j]);
		}
		for (int k = 0; k < array.Length; k++)
		{
			iLGenerator.Emit(OpCodes.Ldarg_1);
			_0023_003Dz7F7iqraub_0024O3ZK5xAJxiO7LH96_0024QVm2Bj_0024OTpa4_003D(iLGenerator, k);
			iLGenerator.Emit(OpCodes.Ldelem_Ref);
			_0023_003Dz1UIOus0EBcUi0MGfMQ_003D_003D(iLGenerator, array[k]);
			iLGenerator.Emit(OpCodes.Stloc, array2[k]);
		}
		if (flag)
		{
			iLGenerator.BeginExceptionBlock();
		}
		if (!_0023_003Dz9jrlnWk_003D.IsStatic && !_0023_003Dz9jrlnWk_003D.IsConstructor)
		{
			iLGenerator.Emit(OpCodes.Ldarg_0);
			Type declaringType = _0023_003Dz9jrlnWk_003D.DeclaringType;
			if (declaringType.IsValueType)
			{
				iLGenerator.Emit(OpCodes.Unbox, declaringType);
				_0023_003DzBxpHhQ0_003D = false;
			}
			else
			{
				_0023_003Dz6nneRHMp0xPVkJYRhsJoUZmAa_pC05xKbIhq1AU_003D(iLGenerator, declaringType);
			}
		}
		for (int l = 0; l < array.Length; l++)
		{
			if (parameters[l].ParameterType.IsByRef)
			{
				iLGenerator.Emit(OpCodes.Ldloca_S, array2[l]);
			}
			else
			{
				iLGenerator.Emit(OpCodes.Ldloc, array2[l]);
			}
		}
		if (_0023_003Dz9jrlnWk_003D.IsConstructor)
		{
			iLGenerator.Emit(OpCodes.Newobj, (ConstructorInfo)_0023_003Dz9jrlnWk_003D);
			_0023_003DzsWjrUHYMbuT9YNDGspgo8y5UB_daKaANibPRLoLcp4_w(iLGenerator, _0023_003Dz9jrlnWk_003D.DeclaringType);
		}
		else
		{
			MethodInfo methodInfo = (MethodInfo)_0023_003Dz9jrlnWk_003D;
			if (!_0023_003DzBxpHhQ0_003D || _0023_003Dz9jrlnWk_003D.IsStatic)
			{
				iLGenerator.EmitCall(OpCodes.Call, methodInfo, null);
			}
			else
			{
				iLGenerator.EmitCall(OpCodes.Callvirt, methodInfo, null);
			}
			if (methodInfo.ReturnType == _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D.m__0023_003Dz9I8ZVlc_003D)
			{
				iLGenerator.Emit(OpCodes.Ldnull);
			}
			else
			{
				_0023_003DzsWjrUHYMbuT9YNDGspgo8y5UB_daKaANibPRLoLcp4_w(iLGenerator, methodInfo.ReturnType);
			}
		}
		if (flag)
		{
			LocalBuilder local = iLGenerator.DeclareLocal(_0023_003DqqSQMR5x0Ss3kUZAkPHTc7q6IdaUzR_0024BTopvbTI_0024P7DA_003D._0023_003Dz9jrlnWk_003D);
			iLGenerator.Emit(OpCodes.Stloc, local);
			iLGenerator.BeginFinallyBlock();
			for (int m = 0; m < array.Length; m++)
			{
				if (parameters[m].ParameterType.IsByRef)
				{
					iLGenerator.Emit(OpCodes.Ldarg_1);
					_0023_003Dz7F7iqraub_0024O3ZK5xAJxiO7LH96_0024QVm2Bj_0024OTpa4_003D(iLGenerator, m);
					iLGenerator.Emit(OpCodes.Ldloc, array2[m]);
					if (array2[m].LocalType.IsValueType || _0023_003DqqSQMR5x0Ss3kUZAkPHTc7q6IdaUzR_0024BTopvbTI_0024P7DA_003D._0023_003DzBQnheHq2yWDGzMNL_0024_0024wd0lfnrJLT1XLAlY7MroqHd2xZ(array2[m].LocalType).IsGenericParameter)
					{
						iLGenerator.Emit(OpCodes.Box, array2[m].LocalType);
					}
					iLGenerator.Emit(OpCodes.Stelem_Ref);
				}
			}
			iLGenerator.EndExceptionBlock();
			iLGenerator.Emit(OpCodes.Ldloc, local);
		}
		iLGenerator.Emit(OpCodes.Ret);
		return (_0023_003Dz2X8kE24_003D)dynamicMethod.CreateDelegate(typeof(_0023_003Dz2X8kE24_003D));
	}

	private static void _0023_003DzHXwsvkO66lx0VPpX3hecErMzfinm(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzwbI83bfoaDmYaZBDzj4leqo_003D(((_0023_003DqJFdrGiwz1aJICVkSTb_0024Zkh7zAYa9iZm47EqlnjrFUg4_003D)_0023_003DzBxpHhQ0_003D)._0023_003Dzi58Fb_0024k5T0u9_0024uYc9Q_003D_003D());
	}

	private static BindingFlags _0023_003DzuaMQqJs9btKMSh09c00zb_0024YVVB_00247VcQqiw_003D_003D(bool _0023_003Dz9jrlnWk_003D)
	{
		BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic;
		if (_0023_003Dz9jrlnWk_003D)
		{
			return bindingFlags | BindingFlags.Static;
		}
		return bindingFlags | BindingFlags.Instance;
	}

	private void _0023_003DzlLFsRbFCVJXLxNmd_0024gDP8S8_003D(_0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		switch (_0023_003Dz9jrlnWk_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D())
		{
		case 2:
			((_0023_003DqFNN_kH3_Aic_0024vq9s6N7BcnqdUOw1mJpa1yIMZD1vbOQ_003D)_0023_003Dz9jrlnWk_003D)._0023_003DziVOWcx_00243zo4_0iYh_0024lucKGuN0vuo()._0023_003DzAPlrN6aYwAg5F1LxHYbv_0024wOBB_0024afgbz6XKGgvF_0024QaP3F7Nvwy8DGE80Q1m63nNv21_00240QxzxHCeC2PtE3mw_003D_003D(_0023_003DzBxpHhQ0_003D);
			break;
		case 23:
			this.m__0023_003DziiEv3wQ_003D[((_0023_003DqOnAL2yhFn6qFFxtB3vCWqYNkaIJ5qqh3h6z2BC38Mh4_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzP_6DBNZ2mJNKRaFdqnf64UitOXKm60smb3aoCTTiqt7H()]._0023_003DzAPlrN6aYwAg5F1LxHYbv_0024wOBB_0024afgbz6XKGgvF_0024QaP3F7Nvwy8DGE80Q1m63nNv21_00240QxzxHCeC2PtE3mw_003D_003D(_0023_003DzBxpHhQ0_003D);
			break;
		case 18:
		{
			_0023_003DqrQPc9rwDL7Fl53_0024M2Pi1fo_0024Ac1BCNKiaW0Mx66Ji04U_003D _0023_003DqrQPc9rwDL7Fl53_0024M2Pi1fo_0024Ac1BCNKiaW0Mx66Ji04U_003D2 = (_0023_003DqrQPc9rwDL7Fl53_0024M2Pi1fo_0024Ac1BCNKiaW0Mx66Ji04U_003D)_0023_003Dz9jrlnWk_003D;
			FieldInfo fieldInfo = _0023_003DqrQPc9rwDL7Fl53_0024M2Pi1fo_0024Ac1BCNKiaW0Mx66Ji04U_003D2._0023_003DzOGfSdf3O2RGD18omagPRFM_0024yH5C6();
			_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3 = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D._0023_003DzCysyOfnrUQB5WqShWAIL_0024X4XGCe9eW67eVeg6HY_003D(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D(), fieldInfo.FieldType);
			fieldInfo.SetValue(_0023_003DqrQPc9rwDL7Fl53_0024M2Pi1fo_0024Ac1BCNKiaW0Mx66Ji04U_003D2._0023_003DzcI1_N_0024zFH93ki__00245WrAnggkz3DwKuotj_0024Q_003D_003D(), _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D());
			_0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D _0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D2 = _0023_003DqrQPc9rwDL7Fl53_0024M2Pi1fo_0024Ac1BCNKiaW0Mx66Ji04U_003D2._0023_003Dz74XVG1TQY30pFSMO6nPvwC4_003D();
			if (_0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D2 != null && fieldInfo.DeclaringType.IsValueType)
			{
				_0023_003DzlLFsRbFCVJXLxNmd_0024gDP8S8_003D(_0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D._0023_003DzCysyOfnrUQB5WqShWAIL_0024X4XGCe9eW67eVeg6HY_003D(_0023_003DqrQPc9rwDL7Fl53_0024M2Pi1fo_0024Ac1BCNKiaW0Mx66Ji04U_003D2._0023_003DzcI1_N_0024zFH93ki__00245WrAnggkz3DwKuotj_0024Q_003D_003D(), null));
			}
			break;
		}
		case 11:
		case 24:
		{
			_0023_003Dq0sd17OXY9HyRTHP4MNrXEWjZPbMynKvVMW_pliUAx6w_003D _0023_003Dq0sd17OXY9HyRTHP4MNrXEWjZPbMynKvVMW_pliUAx6w_003D2 = (_0023_003Dq0sd17OXY9HyRTHP4MNrXEWjZPbMynKvVMW_pliUAx6w_003D)_0023_003Dz9jrlnWk_003D;
			_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D._0023_003DzCysyOfnrUQB5WqShWAIL_0024X4XGCe9eW67eVeg6HY_003D(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D(), _0023_003Dq0sd17OXY9HyRTHP4MNrXEWjZPbMynKvVMW_pliUAx6w_003D2._0023_003DznlMw3Z6vPsFd4RZ75Ii7QhJ7FGdgEIeMO4R17cc_003D());
			_0023_003Dq0sd17OXY9HyRTHP4MNrXEWjZPbMynKvVMW_pliUAx6w_003D2._0023_003DzpdkhhN_ttDJPnMOKfwQuVe11pWUTsgOoNzbENBGBc6yaXkicGB6vHpMOhrb8QgDFC_RCmrewfatBmzI78itMRsZRRyaU(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D());
			break;
		}
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	private void _0023_003DzjUe2x_0024RVYtBlxOXpXmBPPvW3h7Kh(Stream _0023_003Dz9jrlnWk_003D, long _0023_003DzBxpHhQ0_003D, string _0023_003Dztgqm2r4_003D)
	{
		int num = _0023_003Dz2C_0024Vv1MraUAp7j_LFzKRCN2Jpwzg();
		_0023_003Dq0d3UOaLcwAHpHXr73AEsTm4JkA88Pbrxf7l8KMLJdjU_003D _0023_003Dq0d3UOaLcwAHpHXr73AEsTm4JkA88Pbrxf7l8KMLJdjU_003D2 = new _0023_003Dq0d3UOaLcwAHpHXr73AEsTm4JkA88Pbrxf7l8KMLJdjU_003D(_0023_003Dz9jrlnWk_003D, num);
		_0023_003DzXlMgCsc_003D = new _0023_003DqSrxlws3SuprWxrjyHO1juxJFrTNvlF8gj_KAkF067yA_003D(_0023_003Dq0d3UOaLcwAHpHXr73AEsTm4JkA88Pbrxf7l8KMLJdjU_003D2);
		if (_0023_003Dztgqm2r4_003D != null)
		{
			_0023_003DzBxpHhQ0_003D = _0023_003Dz70nXvMYU0VkkG6IeqPZh9PDfv6k7__0024ejRuztli0_003D(_0023_003Dztgqm2r4_003D);
		}
		_0023_003Dq6tS8rMV1rGswJPasZDHd76XTcVlfwQMkS5tB1TusLXU_003D _0023_003Dq6tS8rMV1rGswJPasZDHd76XTcVlfwQMkS5tB1TusLXU_003D2 = _0023_003DzXlMgCsc_003D._0023_003Dzf_kC_0024hpTUTdHx7uANBVIZvPU6fFbivFk0g_003D_003D();
		lock (_0023_003Dq6tS8rMV1rGswJPasZDHd76XTcVlfwQMkS5tB1TusLXU_003D2)
		{
			_0023_003Dq6tS8rMV1rGswJPasZDHd76XTcVlfwQMkS5tB1TusLXU_003D2._0023_003Dzz5uSZofwQCQyOcEKwfVQmiivZ_0024bgBfg6QfI4mYf6tHIC42rk18fkszOb_ezLTX5YRgaBPKGRm6aQTYVwBg_003D_003D(_0023_003DzBxpHhQ0_003D, 0);
			_0023_003Dzj23zu2OgBiiaSGUW_0024C7Zbq_00249vIZl(_0023_003DzXlMgCsc_003D);
			m__0023_003DzaTyQZ6E_003D = _0023_003DzDwre1ZXjPmbPlE2pCbnX_0024wo_003D(_0023_003DzXlMgCsc_003D);
			_0023_003DzCR5Jlyc_003D = _0023_003Dz9olXx7j85z1rFKzgjy3B_UQXR8k_0024SNr8oepKn80_003D(_0023_003DzXlMgCsc_003D);
			this.m__0023_003DzoEGLyuM_003D = _0023_003Dzm9G22wIrA7yco991rZwEWJjvF94Ddh0voT425Uw_003D(_0023_003DzXlMgCsc_003D);
		}
		_0023_003DzQyCWZ7MbsQIdA4QPrz8yFa85VUe9_JXAcxg1Fz8_003D();
	}

	private void _0023_003Dzzeh0T_5ueCdEvFtJacmInxtEps6b(ref _0023_003Dztgqm2r4_003D _0023_003Dz9jrlnWk_003D)
	{
		if (_0023_003Dz9jrlnWk_003D._0023_003Dz9jrlnWk_003D)
		{
			Monitor.Exit(_0023_003DzbLHaDy4_003D);
		}
	}

	private static void _0023_003DzEQsfrtBSf8OI9Ggm_0024_0024pd9io_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzLMJxSSXveUKWgX7ByprFEtw_003D(typeof(long));
	}

	private void _0023_003DzrvgYEC2M5vRgH_0024PXC9SqcEgNZWiDqQp3KZTvk3jJwfyB(bool _0023_003Dz9jrlnWk_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3 = _0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		_0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(_0023_003DznAPCPAkEN_xAiihIKQZZQbIvqfogPvaIyQ_003D_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2, _0023_003Dz9jrlnWk_003D));
	}

	private static void _0023_003Dzb5RfoyTFeDVWteVjaUn_5E_L__Nj(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003Dzy9SLKdQoCebcVxNgldItljkdsD8_0024(_0023_003Dz9jrlnWk_003D: false);
	}

	private _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dz7WIqQGaXZefoDBw0v6JVcpCgOJklztcSgMYd8dOHL87g(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		if (_0023_003Dz9jrlnWk_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 1)
		{
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 1)
			{
				int num = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
				int num2 = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
				return new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(num | num2);
			}
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 19)
			{
				int num3 = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
				Type underlyingType = Enum.GetUnderlyingType(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D().GetType());
				if (underlyingType == typeof(long) || underlyingType == typeof(ulong))
				{
					long num4 = Convert.ToInt64(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D());
					return new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(num3 | num4);
				}
				int num5 = Convert.ToInt32(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D());
				return new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(num3 | num5);
			}
		}
		if (_0023_003Dz9jrlnWk_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 13)
		{
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 13)
			{
				long num6 = ((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG();
				long num7 = ((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG();
				return new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(num6 | num7);
			}
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 19)
			{
				int num8 = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
				long num9 = Convert.ToInt64(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D());
				return new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(num8 | num9);
			}
		}
		if (_0023_003Dz9jrlnWk_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 19)
		{
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 1)
			{
				int num10 = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
				Type underlyingType2 = Enum.GetUnderlyingType(_0023_003Dz9jrlnWk_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D().GetType());
				if (underlyingType2 == typeof(long) || underlyingType2 == typeof(ulong))
				{
					return new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(Convert.ToInt64(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D()) | num10);
				}
				return new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(Convert.ToInt32(_0023_003Dz9jrlnWk_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D()) | num10);
			}
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 13)
			{
				long num11 = Convert.ToInt64(_0023_003Dz9jrlnWk_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D());
				long num12 = ((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG();
				return new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(num11 | num12);
			}
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 19)
			{
				Type underlyingType3 = Enum.GetUnderlyingType(_0023_003Dz9jrlnWk_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D().GetType());
				Type underlyingType4 = Enum.GetUnderlyingType(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D().GetType());
				if (underlyingType3 == typeof(long) || underlyingType3 == typeof(ulong) || underlyingType4 == typeof(long) || underlyingType4 == typeof(ulong))
				{
					long num13 = Convert.ToInt64(_0023_003Dz9jrlnWk_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D());
					long num14 = Convert.ToInt64(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D());
					return new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(num13 | num14);
				}
				int num15 = Convert.ToInt32(_0023_003Dz9jrlnWk_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D());
				int num16 = Convert.ToInt32(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D());
				return new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(num15 | num16);
			}
		}
		throw new InvalidOperationException();
	}

	private int _0023_003DzwLrEupaT_dOFzPwG8LwzVOA_003D()
	{
		return 1055444913;
	}

	private static void _0023_003DzkeM9GMQkXgMiG_0024anIOPNI9M_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		throw new NotSupportedException(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564314142));
	}

	private static void _0023_003DzxrPRdqlIwuNa3AL_0024b8LKApw_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003Dzl01rdMbhKWqXEDpjHctwRZgIgliJDTg7bQ_003D_003D(((_0023_003DqJFdrGiwz1aJICVkSTb_0024Zkh7zAYa9iZm47EqlnjrFUg4_003D)_0023_003DzBxpHhQ0_003D)._0023_003Dzi58Fb_0024k5T0u9_0024uYc9Q_003D_003D());
	}

	private static void _0023_003DzKRlkMQZo7j3084pEzWNjeX8xbTe_0024(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		int num = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
		Type type = _0023_003Dz9jrlnWk_003D._0023_003Dz9_Z5EhGFT4yzpTmOPYjfhZOeNABFeUtCmZ_KeWA_003D(num, _0023_003DzBxpHhQ0_003D: true);
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D._0023_003DzCysyOfnrUQB5WqShWAIL_0024X4XGCe9eW67eVeg6HY_003D(_0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D()._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D(), type);
		_0023_003Dz9jrlnWk_003D._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2);
	}

	private static void _0023_003Dz6jTma98_0024lOzz6b3nm6YjYMzVBuccE2cZPodmQlc_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzLMJxSSXveUKWgX7ByprFEtw_003D(typeof(ushort));
	}

	private _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzrQFXD5oP9hinX0g4gA_003D_003D()
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dznx1EMIs_003D;
		if (_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 != null)
		{
			_0023_003Dznx1EMIs_003D = this.m__0023_003Dz3iPku7s_003D;
			this.m__0023_003Dz3iPku7s_003D = null;
			return _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2;
		}
		return _0023_003DzGX9QPgk_003D.Pop();
	}

	private static void _0023_003DzCbFOfBMkqhwusG_0024w0fkdfzeRyI6g7vvwhA_003D_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		UIntPtr uIntPtr = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() switch
		{
			1 => new UIntPtr((uint)((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D()), 
			13 => new UIntPtr((ulong)((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG()), 
			19 => new UIntPtr(Convert.ToUInt64(((_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D())), 
			8 => new UIntPtr((ulong)((_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzCfXuHVIlFp1X1u2Med2_AL4lzej8EifTBw_003D_003D()), 
			_ => throw new InvalidOperationException(), 
		};
		_0023_003DqVEj3J19zkgEyU6VFymBz6riyi6CxZMJEjhA0KZ2nLKw_003D obj = new _0023_003DqVEj3J19zkgEyU6VFymBz6riyi6CxZMJEjhA0KZ2nLKw_003D();
		obj._0023_003DzCa7EEhgBERhQt3JXzBkemL8_003D(uIntPtr);
		_0023_003Dz9jrlnWk_003D._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(obj);
	}

	private static void _0023_003DzGo2ziHAVROmZ4uwwO5BGqL67wco6(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
	}

	private static void _0023_003DzOb7sZQMQv_0024Ul8WBCMVxd_UlkCfE_0024(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		throw new NotSupportedException(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564314355));
	}

	private static void _0023_003DzDoOcTNxHc4njcGcsUb1eAfojWygnWisZEPNTrYU0gdiL(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003Dz5ky4pu2_00245NqtcI37a_mjNnb49zcJiJ0NC6G9vYM_003D(_0023_003Dz9jrlnWk_003D: true);
	}

	private static Exception _0023_003Dz0jAsrMxmdjJ0CZjSeSu8IC3FTAoK(string _0023_003Dz9jrlnWk_003D, string _0023_003DzBxpHhQ0_003D)
	{
		return new TypeLoadException(_0023_003DzD69sXm7cB8YG4UIz48VVGKMyN5FSSLzspMkf4r0_003D(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313967) + _0023_003Dz9jrlnWk_003D + _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313931), _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313779) + _0023_003DzBxpHhQ0_003D + _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313931)));
	}

	private static void _0023_003DzmnhMW_0024MbTxbt1X7b2xJ9BF6BFY_e(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		int num = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
		Type t = _0023_003Dz9jrlnWk_003D._0023_003Dz9_Z5EhGFT4yzpTmOPYjfhZOeNABFeUtCmZ_KeWA_003D(num, _0023_003DzBxpHhQ0_003D: true);
		_0023_003Dz9jrlnWk_003D._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(Marshal.SizeOf(t)));
	}

	private static void _0023_003DzM6D7npQZr6WEBirIuksodSokN5DWrALNSCf7WtE_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DznvlgEOPraWZmqD5ceLuYFnVSbntYJqpYPE8kmaw_003D(_0023_003Dz9jrlnWk_003D: false);
	}

	private void _0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dz9jrlnWk_003D)
	{
		if (_0023_003Dz9jrlnWk_003D == null)
		{
			throw new ArgumentNullException(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313748));
		}
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2;
		if (_0023_003Dz9jrlnWk_003D._0023_003Dz55cfCv82_0024cfWUBDPYd5Wu_0024c_003D() != null)
		{
			_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dz9jrlnWk_003D;
		}
		else
		{
			switch (_0023_003Dz9jrlnWk_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D())
			{
			case 22:
			{
				_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D obj9 = new _0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D();
				obj9._0023_003DzBGdDQOw_INWgxm_K091ViE8d5B7H7_X_0024gA2NQZA_003D(((_0023_003Dq0srKRFBAoKYa1j6vwUtjLsgVLItE_0024pYpGRcCpdIANF0_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzZkz2LbZgy9OyCTsXYNuHXLwAULIV_mhworWrpKY_003D());
				obj9._0023_003DzsZLDUvjyYZRtLY91huCrFGofhAyP(_0023_003Dz9jrlnWk_003D._0023_003Dz55cfCv82_0024cfWUBDPYd5Wu_0024c_003D());
				_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = obj9;
				break;
			}
			case 12:
			{
				_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D obj8 = new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(((_0023_003DqIC7wdNmeVLrKuHjiCL8jtht_0024ogaMGYTl_vFxiqwcERQ_003D)_0023_003Dz9jrlnWk_003D)._0023_003Dz3fdyocpuocHKnMPBAP0IP10_003D());
				obj8._0023_003DzsZLDUvjyYZRtLY91huCrFGofhAyP(_0023_003Dz9jrlnWk_003D._0023_003Dz55cfCv82_0024cfWUBDPYd5Wu_0024c_003D());
				_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = obj8;
				break;
			}
			case 26:
			{
				_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D obj7 = new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(((_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKhNev13fggp5f4ufA3nWzHs_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzBDF3DlQ074aKodeTOll2pF4VaQOat3nVSUNq_0024xFTOS8K());
				obj7._0023_003DzsZLDUvjyYZRtLY91huCrFGofhAyP(_0023_003Dz9jrlnWk_003D._0023_003Dz55cfCv82_0024cfWUBDPYd5Wu_0024c_003D());
				_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = obj7;
				break;
			}
			case 17:
			{
				_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D obj10 = new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(((_0023_003Dq_00249gqa_00242OaFZvUQ9SB2xbDMp_0024CYfNzncySoGOXE8Ah9U_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzEpuI4RoqQkLdzH3adfPxnHyBs4HVedRet_3toAPBhDj8());
				obj10._0023_003DzsZLDUvjyYZRtLY91huCrFGofhAyP(_0023_003Dz9jrlnWk_003D._0023_003Dz55cfCv82_0024cfWUBDPYd5Wu_0024c_003D());
				_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = obj10;
				break;
			}
			case 16:
			{
				_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D obj5 = new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(((_0023_003DqJFdrGiwz1aJICVkSTb_0024Zkh7zAYa9iZm47EqlnjrFUg4_003D)_0023_003Dz9jrlnWk_003D)._0023_003Dzi58Fb_0024k5T0u9_0024uYc9Q_003D_003D());
				obj5._0023_003DzsZLDUvjyYZRtLY91huCrFGofhAyP(_0023_003Dz9jrlnWk_003D._0023_003Dz55cfCv82_0024cfWUBDPYd5Wu_0024c_003D());
				_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = obj5;
				break;
			}
			case 3:
			{
				_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D obj4 = new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D((int)((_0023_003DqJFdrGiwz1aJICVkSTb_0024Zko9aS6iSwDcZdo9VS4Dkh_0024s_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzxGjrL4iuhvogLPGFSdnVXdPvbKxem9P4HA_003D_003D());
				obj4._0023_003DzsZLDUvjyYZRtLY91huCrFGofhAyP(_0023_003Dz9jrlnWk_003D._0023_003Dz55cfCv82_0024cfWUBDPYd5Wu_0024c_003D());
				_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = obj4;
				break;
			}
			case 14:
			{
				_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D obj6 = new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D((long)((_0023_003DqyvT7ICDtp8Yy01kAGSLXn3mwtAnbupk3x8yW8kdZU7Y_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzClRwQSk85BMc6YR1iCr4__0024KZz45ru1unIg_003D_003D());
				obj6._0023_003DzsZLDUvjyYZRtLY91huCrFGofhAyP(_0023_003Dz9jrlnWk_003D._0023_003Dz55cfCv82_0024cfWUBDPYd5Wu_0024c_003D());
				_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = obj6;
				break;
			}
			case 15:
			{
				_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D obj3 = new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(((_0023_003Dqd8JBeTDbtnpIEDoflGijN9w97J4X4ziEKjAq87w7FS8_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzYeIUAGyT015l2k4wo3p445Mq3U4G() ? 1 : 0);
				obj3._0023_003DzsZLDUvjyYZRtLY91huCrFGofhAyP(_0023_003Dz9jrlnWk_003D._0023_003Dz55cfCv82_0024cfWUBDPYd5Wu_0024c_003D());
				_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = obj3;
				break;
			}
			case 6:
			{
				_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D obj2 = new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(((_0023_003DqxDdJs6FlEwuzAP5rV8TAljmSyjMn_0024nO6uZ_l4pJimWY_003D)_0023_003Dz9jrlnWk_003D)._0023_003Dznz6mTi4M2q2cDua70I_0024mjqw_003D());
				obj2._0023_003DzsZLDUvjyYZRtLY91huCrFGofhAyP(_0023_003Dz9jrlnWk_003D._0023_003Dz55cfCv82_0024cfWUBDPYd5Wu_0024c_003D());
				_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = obj2;
				break;
			}
			case 7:
			{
				object obj = _0023_003Dz9jrlnWk_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D();
				if (obj == null)
				{
					_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dz9jrlnWk_003D;
					break;
				}
				Type type = obj.GetType();
				if (type.HasElementType && !type.IsArray)
				{
					type = type.GetElementType();
				}
				_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = ((!(type != null) || type.IsValueType || type.IsEnum) ? _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D._0023_003DzCysyOfnrUQB5WqShWAIL_0024X4XGCe9eW67eVeg6HY_003D(obj, type) : _0023_003Dz9jrlnWk_003D);
				break;
			}
			default:
				_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dz9jrlnWk_003D;
				break;
			}
		}
		if (_0023_003Dznx1EMIs_003D != null)
		{
			if (this.m__0023_003Dz3iPku7s_003D != null)
			{
				_0023_003DzGX9QPgk_003D.Push(this.m__0023_003Dz3iPku7s_003D);
			}
			this.m__0023_003Dz3iPku7s_003D = _0023_003Dznx1EMIs_003D;
		}
		_0023_003Dznx1EMIs_003D = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2;
	}

	private static void _0023_003DzD28s7QCKoY5IscVQDBVCP21AeYXc19jok6_0024jwJbRhFYY(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003Dzy9SLKdQoCebcVxNgldItljkdsD8_0024(_0023_003Dz9jrlnWk_003D: true);
	}

	private _0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024h3HXCPh1byVa5xQgwlyKcE_003D _0023_003DzMyKC5Rx1kInz2yr8VRvXyDtUtIYtBpKLiQ_003D_003D(_0023_003DqSrxlws3SuprWxrjyHO1juxJFrTNvlF8gj_KAkF067yA_003D _0023_003Dz9jrlnWk_003D)
	{
		_0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024h3HXCPh1byVa5xQgwlyKcE_003D obj = new _0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024h3HXCPh1byVa5xQgwlyKcE_003D();
		obj._0023_003DzGZ_0024_NugF8n_0024Gi1ZAXa5PlXv9kltX(_0023_003Dz9jrlnWk_003D._0023_003DzzWp83NqubJCg0KBvRVdJ1Clh9XOWlHor0w_003D_003D());
		obj._0023_003Dz4SuuXzruGHWh8XHb7R_00241wxoewlmcqhuS0A_003D_003D(_0023_003Dz9jrlnWk_003D._0023_003DzIP3AkZdn9WJEiLnJXRyNm40_003D());
		return obj;
	}

	private static void _0023_003DzUB42xEYkXM8nI2TTvrVJ2j9AAzfe24CN1GGPzKI_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003Dz_bTfuOd_0024_8tksF6orA_003D_003D(_0023_003DzozZCuko_003D);
	}

	private static _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzVjfAUuwt5Hcy8zXS_0024Q_003D_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D, bool _0023_003Dztgqm2r4_003D, bool _0023_003DzzKDx05I_003D)
	{
		if (!_0023_003DzzKDx05I_003D)
		{
			long num = ((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG();
			long num2 = ((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG();
			long num3 = ((!_0023_003Dztgqm2r4_003D) ? (num - num2) : checked(num - num2));
			return new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(num3);
		}
		ulong num4 = (ulong)((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG();
		ulong num5 = (ulong)((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG();
		ulong num6 = ((!_0023_003Dztgqm2r4_003D) ? (num4 - num5) : checked(num4 - num5));
		return new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D((long)num6);
	}

	private void _0023_003DzLMJxSSXveUKWgX7ByprFEtw_003D(Type _0023_003Dz9jrlnWk_003D)
	{
		_0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D _0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D2 = (_0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D)_0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		_0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D._0023_003DzCysyOfnrUQB5WqShWAIL_0024X4XGCe9eW67eVeg6HY_003D(_0023_003DzcyfMbnJemFaR1U9IYqWp0cPmk80NlqUX5LErUtBcWaeU(_0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D2)._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D(), _0023_003Dz9jrlnWk_003D));
	}

	private static void _0023_003DzicjN6h5VGhwsGH7si3y9EMQtQ2KHkii1tJRHTbQ_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzrvgYEC2M5vRgH_0024PXC9SqcEgNZWiDqQp3KZTvk3jJwfyB(_0023_003Dz9jrlnWk_003D: true);
	}

	private _0023_003Dq0Rq3kQTx6AA3zzwQ7EVEtV4J_0024npeIRMU04FDxLZcqUs_003D _0023_003DziDxs0L9vScEgbR1ms3QkFKQvbydZ2UADH_NmxhatHOH8(_0023_003DqSrxlws3SuprWxrjyHO1juxJFrTNvlF8gj_KAkF067yA_003D _0023_003Dz9jrlnWk_003D)
	{
		switch (_0023_003Dz9jrlnWk_003D._0023_003Dz2DBTqfW51eVHX_0024PiHey2kryLbqPoOZPrpMXUAwQ_003D())
		{
		case 2:
		{
			_0023_003DqPjU0as5GIhLtc26yxRodCiKMERUKL9IxtNScNVINKZc_003D obj6 = new _0023_003DqPjU0as5GIhLtc26yxRodCiKMERUKL9IxtNScNVINKZc_003D();
			obj6._0023_003Dzryx7vRK69DHH2kfJczkngbA_003D(_0023_003Dz9jrlnWk_003D._0023_003DzYwSkP_0024AT_4cNB1WKv1Bn_0024U2fDpNoCLCIgZMBDZU_003D());
			obj6._0023_003DzJAGyFMO25IgN_00245NPQfDNN6lJFGre(_0023_003Dz9jrlnWk_003D._0023_003DzIP3AkZdn9WJEiLnJXRyNm40_003D());
			obj6._0023_003DzcOUTG4fYghcXWCaKIg_003D_003D(_0023_003Dz9jrlnWk_003D._0023_003DzIP3AkZdn9WJEiLnJXRyNm40_003D());
			obj6._0023_003DzAGsV7YiQDI3pANlRbJsSKTCOz_1Z(_0023_003Dz9jrlnWk_003D._0023_003DzzWp83NqubJCg0KBvRVdJ1Clh9XOWlHor0w_003D_003D());
			obj6._0023_003Dz_zp7jONWioXKH_0024aQehaVmyVq6xtYghn5rA_003D_003D(_0023_003Dz9jrlnWk_003D._0023_003DzzWp83NqubJCg0KBvRVdJ1Clh9XOWlHor0w_003D_003D());
			_0023_003DqPjU0as5GIhLtc26yxRodCiKMERUKL9IxtNScNVINKZc_003D _0023_003DqPjU0as5GIhLtc26yxRodCiKMERUKL9IxtNScNVINKZc_003D2 = obj6;
			int num5 = _0023_003Dz9jrlnWk_003D._0023_003DzenwK8cW1s7NbjzVm6XOeYfWXq5L4();
			_0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D[] array3 = new _0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D[num5];
			for (int k = 0; k < num5; k++)
			{
				int num6 = k;
				_0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D obj7 = new _0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D();
				obj7._0023_003DzNUPIDmrP1jaRVB3WXD3g1PHN53FX(1);
				obj7._0023_003DzGEIJPAXG3eETFVay0g_003D_003D(_0023_003Dz9jrlnWk_003D._0023_003DzzWp83NqubJCg0KBvRVdJ1Clh9XOWlHor0w_003D_003D());
				array3[num6] = obj7;
			}
			_0023_003DqPjU0as5GIhLtc26yxRodCiKMERUKL9IxtNScNVINKZc_003D2._0023_003Dz3kQbkAoBKVhZlyDjbO24NTOHc325_00242WTiNh6cSE_003D(array3);
			return _0023_003DqPjU0as5GIhLtc26yxRodCiKMERUKL9IxtNScNVINKZc_003D2;
		}
		case 1:
		{
			_0023_003DqJTjaQmhkW8F60LVdPhnyD_0024jn8xWIZNbFd7YUJbbVpeY_003D obj9 = new _0023_003DqJTjaQmhkW8F60LVdPhnyD_0024jn8xWIZNbFd7YUJbbVpeY_003D();
			_0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D obj10 = new _0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D();
			obj10._0023_003DzNUPIDmrP1jaRVB3WXD3g1PHN53FX(1);
			obj10._0023_003DzGEIJPAXG3eETFVay0g_003D_003D(_0023_003Dz9jrlnWk_003D._0023_003DzzWp83NqubJCg0KBvRVdJ1Clh9XOWlHor0w_003D_003D());
			obj9._0023_003DzBmu3q7Hcsa_0024mC8FW4ottTfw_003D(obj10);
			obj9._0023_003DzA7Cv_0024kl_0024oN4ALwHFSRdoen5EshGGLZ2Atyl1Hh8_003D(_0023_003Dz9jrlnWk_003D._0023_003DzYwSkP_0024AT_4cNB1WKv1Bn_0024U2fDpNoCLCIgZMBDZU_003D());
			obj9._0023_003DzL2OpmPQnenA_0024yY5h2nuUY18_0024hphKSFVs4g_003D_003D(_0023_003Dz9jrlnWk_003D._0023_003DzIP3AkZdn9WJEiLnJXRyNm40_003D());
			return obj9;
		}
		case 3:
		{
			_0023_003Dq6RsKbEvjyFgbikPCxI_0024iyaP4iT3cOdFPnt_Mjubq4RU_003D obj8 = new _0023_003Dq6RsKbEvjyFgbikPCxI_0024iyaP4iT3cOdFPnt_Mjubq4RU_003D();
			obj8._0023_003DzPtkrjeCGRErdEc0Lmw_003D_003D(_0023_003Dz9jrlnWk_003D._0023_003DzzWp83NqubJCg0KBvRVdJ1Clh9XOWlHor0w_003D_003D());
			obj8._0023_003Dz9aqw8KEsGz_0024jRfLkgUjZQHjhfS5yPYInzBD9BB2dUuq7(_0023_003Dz9jrlnWk_003D._0023_003DzzWp83NqubJCg0KBvRVdJ1Clh9XOWlHor0w_003D_003D());
			return obj8;
		}
		case 0:
		{
			_0023_003Dq9cxJfzt6tx3_00245xLDM_0024HAnunU7Xy_WBpJRmOB2qxzSUo_003D _0023_003Dq9cxJfzt6tx3_00245xLDM_0024HAnunU7Xy_WBpJRmOB2qxzSUo_003D2 = new _0023_003Dq9cxJfzt6tx3_00245xLDM_0024HAnunU7Xy_WBpJRmOB2qxzSUo_003D();
			_0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D obj2 = new _0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D();
			obj2._0023_003DzNUPIDmrP1jaRVB3WXD3g1PHN53FX(1);
			obj2._0023_003DzGEIJPAXG3eETFVay0g_003D_003D(_0023_003Dz9jrlnWk_003D._0023_003DzzWp83NqubJCg0KBvRVdJ1Clh9XOWlHor0w_003D_003D());
			_0023_003Dq9cxJfzt6tx3_00245xLDM_0024HAnunU7Xy_WBpJRmOB2qxzSUo_003D2._0023_003DzWSKYnIu8cpHvokWfbJg5bhKCC_0024_0024IFIOGKg_003D_003D(obj2);
			_0023_003Dq9cxJfzt6tx3_00245xLDM_0024HAnunU7Xy_WBpJRmOB2qxzSUo_003D2._0023_003Dzalrq_cS3cRS2VR8pblbo_0024unNniVYCc_0024nS3RqjXw_003D(_0023_003Dz9jrlnWk_003D._0023_003Dz2DBTqfW51eVHX_0024PiHey2kryLbqPoOZPrpMXUAwQ_003D());
			_0023_003Dq9cxJfzt6tx3_00245xLDM_0024HAnunU7Xy_WBpJRmOB2qxzSUo_003D2._0023_003DzDZxrZ3MJw1UWUh9m5cxQj_0024xsJtp51soAUyY6GcQ_003D(_0023_003Dz9jrlnWk_003D._0023_003DzYwSkP_0024AT_4cNB1WKv1Bn_0024U2fDpNoCLCIgZMBDZU_003D());
			_0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D obj3 = new _0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D();
			obj3._0023_003DzNUPIDmrP1jaRVB3WXD3g1PHN53FX(1);
			obj3._0023_003DzGEIJPAXG3eETFVay0g_003D_003D(_0023_003Dz9jrlnWk_003D._0023_003DzzWp83NqubJCg0KBvRVdJ1Clh9XOWlHor0w_003D_003D());
			_0023_003Dq9cxJfzt6tx3_00245xLDM_0024HAnunU7Xy_WBpJRmOB2qxzSUo_003D2._0023_003DzeVrH117u_0024ptKcilQB4Q8pts_003D(obj3);
			int num = _0023_003Dz9jrlnWk_003D._0023_003DzenwK8cW1s7NbjzVm6XOeYfWXq5L4();
			_0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D[] array = new _0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D[num];
			for (int i = 0; i < num; i++)
			{
				int num2 = i;
				_0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D obj4 = new _0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D();
				obj4._0023_003DzNUPIDmrP1jaRVB3WXD3g1PHN53FX(1);
				obj4._0023_003DzGEIJPAXG3eETFVay0g_003D_003D(_0023_003Dz9jrlnWk_003D._0023_003DzzWp83NqubJCg0KBvRVdJ1Clh9XOWlHor0w_003D_003D());
				array[num2] = obj4;
			}
			_0023_003Dq9cxJfzt6tx3_00245xLDM_0024HAnunU7Xy_WBpJRmOB2qxzSUo_003D2._0023_003Dzt7FixYf50gn7ZUVWBwj4rxjgXUJUZZqNt1H5FSBgcsu1(array);
			int num3 = _0023_003Dz9jrlnWk_003D._0023_003DzenwK8cW1s7NbjzVm6XOeYfWXq5L4();
			_0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D[] array2 = new _0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D[num3];
			for (int j = 0; j < num3; j++)
			{
				int num4 = j;
				_0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D obj5 = new _0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D();
				obj5._0023_003DzNUPIDmrP1jaRVB3WXD3g1PHN53FX(1);
				obj5._0023_003DzGEIJPAXG3eETFVay0g_003D_003D(_0023_003Dz9jrlnWk_003D._0023_003DzzWp83NqubJCg0KBvRVdJ1Clh9XOWlHor0w_003D_003D());
				array2[num4] = obj5;
			}
			_0023_003Dq9cxJfzt6tx3_00245xLDM_0024HAnunU7Xy_WBpJRmOB2qxzSUo_003D2._0023_003Dz88n_0024KE0sFvWC3jgsIrZUmuwMpcDgd_aRrxOGBu79YC_n(array2);
			return _0023_003Dq9cxJfzt6tx3_00245xLDM_0024HAnunU7Xy_WBpJRmOB2qxzSUo_003D2;
		}
		case 4:
		{
			_0023_003DqP_3FowpRje_0024k54W1SNyQv_0024mF0yo2MyKxXDGfz_0024mVD5o_003D obj = new _0023_003DqP_3FowpRje_0024k54W1SNyQv_0024mF0yo2MyKxXDGfz_0024mVD5o_003D();
			obj._0023_003DzyX7e2o8Ja2R53MAWAH3W6CQGtV_0024M9DbiRVW_0024Y40_003D(_0023_003Dz9jrlnWk_003D._0023_003DzYwSkP_0024AT_4cNB1WKv1Bn_0024U2fDpNoCLCIgZMBDZU_003D());
			return obj;
		}
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	private static void _0023_003Dzq5KmISUe8gXaMKZZZqovS8_596gqnl0aA_0024jHJHsXtsno(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		uint num = ((_0023_003DqJFdrGiwz1aJICVkSTb_0024Zko9aS6iSwDcZdo9VS4Dkh_0024s_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzxGjrL4iuhvogLPGFSdnVXdPvbKxem9P4HA_003D_003D();
		_0023_003Dz9jrlnWk_003D._0023_003Dz9r__0024YTGu_0024iN2qFjqe6k1t7s_003D(num);
	}

	private static void _0023_003DzU30LI6oJRf19TZ9KtA_003D_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzLMJxSSXveUKWgX7ByprFEtw_003D(typeof(sbyte));
	}

	private static void _0023_003Dz2HoM2IIwPNFsnCxO5arQNdM_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzLMJxSSXveUKWgX7ByprFEtw_003D(typeof(float));
	}

	private _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DznAPCPAkEN_xAiihIKQZZQbIvqfogPvaIyQ_003D_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D, bool _0023_003Dztgqm2r4_003D)
	{
		if (_0023_003Dz9jrlnWk_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 1)
		{
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 1)
			{
				if (!_0023_003Dztgqm2r4_003D)
				{
					int num = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
					int num2 = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
					return new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(num / num2);
				}
				int num3 = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
				uint num4 = (uint)((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
				return new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D((int)((uint)num3 / num4));
			}
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 13)
			{
				return _0023_003Dzhuv_0024Udp9w3wv9OrPxC6bce0_003D(new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D()), _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D);
			}
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 19)
			{
				Type underlyingType = Enum.GetUnderlyingType(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D().GetType());
				if (underlyingType == typeof(long) || underlyingType == typeof(ulong))
				{
					return _0023_003Dzhuv_0024Udp9w3wv9OrPxC6bce0_003D(new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D()), new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(Convert.ToInt64(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D())), _0023_003Dztgqm2r4_003D);
				}
				return _0023_003DznAPCPAkEN_xAiihIKQZZQbIvqfogPvaIyQ_003D_003D(_0023_003Dz9jrlnWk_003D, new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(Convert.ToInt32(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D())), _0023_003Dztgqm2r4_003D);
			}
		}
		if (_0023_003Dz9jrlnWk_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 13)
		{
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 13)
			{
				return _0023_003Dzhuv_0024Udp9w3wv9OrPxC6bce0_003D(_0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D);
			}
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 1)
			{
				return _0023_003Dzhuv_0024Udp9w3wv9OrPxC6bce0_003D(_0023_003Dz9jrlnWk_003D, new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D()), _0023_003Dztgqm2r4_003D);
			}
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 19)
			{
				Type underlyingType2 = Enum.GetUnderlyingType(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D().GetType());
				if (underlyingType2 == typeof(long) || underlyingType2 == typeof(ulong))
				{
					return _0023_003Dzhuv_0024Udp9w3wv9OrPxC6bce0_003D(_0023_003Dz9jrlnWk_003D, new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(Convert.ToInt64(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D())), _0023_003Dztgqm2r4_003D);
				}
				return _0023_003Dzhuv_0024Udp9w3wv9OrPxC6bce0_003D(_0023_003Dz9jrlnWk_003D, new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(Convert.ToInt32(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D())), _0023_003Dztgqm2r4_003D);
			}
		}
		if (_0023_003Dz9jrlnWk_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 8 && _0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 8)
		{
			_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D obj = new _0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D();
			obj._0023_003DzBGdDQOw_INWgxm_K091ViE8d5B7H7_X_0024gA2NQZA_003D(((_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzCfXuHVIlFp1X1u2Med2_AL4lzej8EifTBw_003D_003D() / ((_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzCfXuHVIlFp1X1u2Med2_AL4lzej8EifTBw_003D_003D());
			return obj;
		}
		if (_0023_003Dz9jrlnWk_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 19)
		{
			Type underlyingType3 = Enum.GetUnderlyingType(_0023_003Dz9jrlnWk_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D().GetType());
			if (underlyingType3 == typeof(long) || underlyingType3 == typeof(ulong))
			{
				return _0023_003DznAPCPAkEN_xAiihIKQZZQbIvqfogPvaIyQ_003D_003D(new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(Convert.ToInt64(_0023_003Dz9jrlnWk_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D())), _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D);
			}
			return _0023_003DznAPCPAkEN_xAiihIKQZZQbIvqfogPvaIyQ_003D_003D(new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(Convert.ToInt32(_0023_003Dz9jrlnWk_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D())), _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D);
		}
		throw new InvalidOperationException();
	}

	private static _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzFPp_Az7eVXKTXWr0jHcGgoGRIuFbnIm_0024gdNDLrA_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D, bool _0023_003Dztgqm2r4_003D)
	{
		if (!_0023_003Dztgqm2r4_003D)
		{
			long num = ((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG();
			long num2 = ((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG();
			return new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(num % num2);
		}
		long num3 = ((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG();
		ulong num4 = (ulong)((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG();
		return new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D((long)((ulong)num3 % num4));
	}

	private static void _0023_003DzU7HW8EA6_8Oce8ehBaOxIxRZZgUcRP1_00249yeSsxtnkXk_0024(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3 = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		_0023_003Dz9jrlnWk_003D._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(_0023_003DzMUztG58r9K8EH6LstV9cRZc_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2) ? 1 : 0));
	}

	private static _0023_003Dqih1RKs7Osg5_0024Rd9gDhKEdqdrC8qgJFChg_7i1V8hZwk_003D _0023_003Dzwx8fQZA5deSOpjgap_G3u7kbKm21A8xhmCDH2_M_003D(_0023_003DqSrxlws3SuprWxrjyHO1juxJFrTNvlF8gj_KAkF067yA_003D _0023_003Dz9jrlnWk_003D)
	{
		_0023_003Dqih1RKs7Osg5_0024Rd9gDhKEdqdrC8qgJFChg_7i1V8hZwk_003D obj = new _0023_003Dqih1RKs7Osg5_0024Rd9gDhKEdqdrC8qgJFChg_7i1V8hZwk_003D();
		obj._0023_003DzfqhkJbN1PUjFhU4w1y8cCRTw_00249ponlkojw_003D_003D(_0023_003Dz9jrlnWk_003D._0023_003Dz2DBTqfW51eVHX_0024PiHey2kryLbqPoOZPrpMXUAwQ_003D());
		obj._0023_003DzixxYULoclK_s6KdinhY93nS_Oy8bZEdp3A_003D_003D(_0023_003Dz9jrlnWk_003D._0023_003DzzWp83NqubJCg0KBvRVdJ1Clh9XOWlHor0w_003D_003D());
		obj._0023_003DzDrRuKx_0024hbiYqgTFrAYfWAHbs_DG4(_0023_003Dz9jrlnWk_003D._0023_003Dz6ZCFHacYN7DiGCTOLVcLt1ROT7gcyKHf_0024OLcW_0_003D());
		obj._0023_003Dz4uOv5HW9jqasbVmLF3YFmZl7EdcZ0j64iw_003D_003D(_0023_003Dz9jrlnWk_003D._0023_003Dz6ZCFHacYN7DiGCTOLVcLt1ROT7gcyKHf_0024OLcW_0_003D());
		obj._0023_003DziGI07kek2KrkOkmb85LtWDLCa_FX(_0023_003Dz9jrlnWk_003D._0023_003Dz6ZCFHacYN7DiGCTOLVcLt1ROT7gcyKHf_0024OLcW_0_003D());
		obj._0023_003DzaPAyBbbFPsc_hSNf_WOVrdl4fup56_b_IOVVJP0_003D(_0023_003Dz9jrlnWk_003D._0023_003Dz6ZCFHacYN7DiGCTOLVcLt1ROT7gcyKHf_0024OLcW_0_003D());
		return obj;
	}

	private static void _0023_003Dz1UIOus0EBcUi0MGfMQ_003D_003D(ILGenerator _0023_003Dz9jrlnWk_003D, Type _0023_003DzBxpHhQ0_003D)
	{
		if (_0023_003DzBxpHhQ0_003D.IsValueType || _0023_003DqqSQMR5x0Ss3kUZAkPHTc7q6IdaUzR_0024BTopvbTI_0024P7DA_003D._0023_003DzBQnheHq2yWDGzMNL_0024_0024wd0lfnrJLT1XLAlY7MroqHd2xZ(_0023_003DzBxpHhQ0_003D).IsGenericParameter)
		{
			_0023_003Dz9jrlnWk_003D.Emit(OpCodes.Unbox_Any, _0023_003DzBxpHhQ0_003D);
		}
		else
		{
			_0023_003Dz6nneRHMp0xPVkJYRhsJoUZmAa_pC05xKbIhq1AU_003D(_0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D);
		}
	}

	private void _0023_003Dzj23zu2OgBiiaSGUW_0024C7Zbq_00249vIZl(_0023_003DqSrxlws3SuprWxrjyHO1juxJFrTNvlF8gj_KAkF067yA_003D _0023_003Dz9jrlnWk_003D)
	{
	}

	private static void _0023_003DzDzC3KkxeaBB4BCAGXXJy7HqoJmTq(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		if (_0023_003DzMUztG58r9K8EH6LstV9cRZc_003D(_0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D(), _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2))
		{
			uint num = ((_0023_003DqJFdrGiwz1aJICVkSTb_0024Zko9aS6iSwDcZdo9VS4Dkh_0024s_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzxGjrL4iuhvogLPGFSdnVXdPvbKxem9P4HA_003D_003D();
			_0023_003Dz9jrlnWk_003D._0023_003Dz9r__0024YTGu_0024iN2qFjqe6k1t7s_003D(num);
		}
	}

	private static void _0023_003DzsWjrUHYMbuT9YNDGspgo8y5UB_daKaANibPRLoLcp4_w(ILGenerator _0023_003Dz9jrlnWk_003D, Type _0023_003DzBxpHhQ0_003D)
	{
		if (_0023_003DzBxpHhQ0_003D.IsValueType || _0023_003DqqSQMR5x0Ss3kUZAkPHTc7q6IdaUzR_0024BTopvbTI_0024P7DA_003D._0023_003DzBQnheHq2yWDGzMNL_0024_0024wd0lfnrJLT1XLAlY7MroqHd2xZ(_0023_003DzBxpHhQ0_003D).IsGenericParameter)
		{
			_0023_003Dz9jrlnWk_003D.Emit(OpCodes.Box, _0023_003DzBxpHhQ0_003D);
		}
	}

	private static void _0023_003DzUAoMpJuhPt0NOQSLS_q_ZqfMxOU_0024BclHXgT1o6c_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		uint num = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() switch
		{
			1 => (uint)((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D(), 
			13 => (uint)((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG(), 
			19 => (uint)Convert.ToInt64(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D()), 
			_ => throw new InvalidOperationException(), 
		};
		_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D[] array = (_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D[])((_0023_003DqJK_4DNDu0bpSDsm8DAlJ97YodsmbnVu7wOTilEHAt2g_003D)_0023_003DzBxpHhQ0_003D)._0023_003Dz8x2to_0024HHcSI6D8KXMUd8dEqHnUA_00248eLPE0X_0024zbESTq9X();
		if (num < array.Length)
		{
			uint num2 = (uint)array[num]._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
			_0023_003Dz9jrlnWk_003D._0023_003Dz9r__0024YTGu_0024iN2qFjqe6k1t7s_003D(num2);
		}
	}

	public void _0023_003Dzrt3xIajy0T6pgx6H6j8jQiFKktCE(Stream _0023_003Dz9jrlnWk_003D, string _0023_003DzBxpHhQ0_003D, object[] _0023_003Dztgqm2r4_003D)
	{
		_0023_003DzBTpzeAE0bM5yqB3CifI7jV0_003D(_0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D);
	}

	[DebuggerNonUserCode]
	private MethodBase _0023_003DzuQitVVfPXhnVfEemX_NzMcY_riCF0mqY_0024dIcN_0024w_003D(int _0023_003Dz9jrlnWk_003D, _0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D _0023_003DzBxpHhQ0_003D)
	{
		lock (_0023_003DzZpkUTwY_003D)
		{
			bool flag = true;
			if (flag && _0023_003DzZpkUTwY_003D.TryGetValue(_0023_003Dz9jrlnWk_003D, out var value))
			{
				return (MethodBase)value;
			}
			if (_0023_003DzBxpHhQ0_003D._0023_003DzwH8K7lD_0024cC3gY_RIDCO_Bu8Tp6tgtXa0TA_003D_003D() == 0)
			{
				MethodBase methodBase = this.m__0023_003DzJ6W8874_003D.ResolveMethod(_0023_003DzBxpHhQ0_003D._0023_003DztkhwzVeVIldXjs1hyonqsqcuOAEF());
				if (flag)
				{
					_0023_003DzZpkUTwY_003D.Add(_0023_003Dz9jrlnWk_003D, methodBase);
				}
				return methodBase;
			}
			_0023_003Dq9cxJfzt6tx3_00245xLDM_0024HAnunU7Xy_WBpJRmOB2qxzSUo_003D _0023_003Dq9cxJfzt6tx3_00245xLDM_0024HAnunU7Xy_WBpJRmOB2qxzSUo_003D2 = (_0023_003Dq9cxJfzt6tx3_00245xLDM_0024HAnunU7Xy_WBpJRmOB2qxzSUo_003D)_0023_003DzBxpHhQ0_003D._0023_003DzMDpHhtfRNQDKXWsFcSVSbdd3Ewg6();
			if (_0023_003Dq9cxJfzt6tx3_00245xLDM_0024HAnunU7Xy_WBpJRmOB2qxzSUo_003D2._0023_003DzUcask6rTTPrpU_0024EGE_r4YY5UEATEUtqMnA_003D_003D())
			{
				return _0023_003DzgrzShoUn5WrtDo5QhPho_W7AjqLuUn6aP8TqLvU_003D(_0023_003Dq9cxJfzt6tx3_00245xLDM_0024HAnunU7Xy_WBpJRmOB2qxzSUo_003D2);
			}
			Type type = _0023_003Dz9_Z5EhGFT4yzpTmOPYjfhZOeNABFeUtCmZ_KeWA_003D(_0023_003Dq9cxJfzt6tx3_00245xLDM_0024HAnunU7Xy_WBpJRmOB2qxzSUo_003D2._0023_003Dz0VK_0024n5_OzquTMOL7Fv6k0GgpbJ9ODTKP_00243Gx1Ns_003D()._0023_003DztkhwzVeVIldXjs1hyonqsqcuOAEF(), _0023_003DzBxpHhQ0_003D: false);
			Type type2 = _0023_003Dz9_Z5EhGFT4yzpTmOPYjfhZOeNABFeUtCmZ_KeWA_003D(_0023_003Dq9cxJfzt6tx3_00245xLDM_0024HAnunU7Xy_WBpJRmOB2qxzSUo_003D2._0023_003DzVwJz1Iz1BL8jSL84NMBvRG1hvuNL()._0023_003DztkhwzVeVIldXjs1hyonqsqcuOAEF(), _0023_003DzBxpHhQ0_003D: true);
			Type[] array = new Type[_0023_003Dq9cxJfzt6tx3_00245xLDM_0024HAnunU7Xy_WBpJRmOB2qxzSUo_003D2._0023_003DzD9Pned40_22MDiBp0NMYEuJd2lu1().Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = _0023_003Dz9_Z5EhGFT4yzpTmOPYjfhZOeNABFeUtCmZ_KeWA_003D(_0023_003Dq9cxJfzt6tx3_00245xLDM_0024HAnunU7Xy_WBpJRmOB2qxzSUo_003D2._0023_003DzD9Pned40_22MDiBp0NMYEuJd2lu1()[i]._0023_003DztkhwzVeVIldXjs1hyonqsqcuOAEF(), _0023_003DzBxpHhQ0_003D: true);
			}
			if (type.IsGenericType)
			{
				flag = false;
			}
			if (_0023_003Dq9cxJfzt6tx3_00245xLDM_0024HAnunU7Xy_WBpJRmOB2qxzSUo_003D2._0023_003DzTO06eh4ctVi8FQHL1ybi_00249JNJanF() == _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564314240))
			{
				ConstructorInfo constructorInfo = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, CallingConventions.Any, array, null) ?? throw new Exception();
				if (flag)
				{
					_0023_003DzZpkUTwY_003D.Add(_0023_003Dz9jrlnWk_003D, constructorInfo);
				}
				return constructorInfo;
			}
			BindingFlags bindingAttr = _0023_003DzuaMQqJs9btKMSh09c00zb_0024YVVB_00247VcQqiw_003D_003D(_0023_003Dq9cxJfzt6tx3_00245xLDM_0024HAnunU7Xy_WBpJRmOB2qxzSUo_003D2._0023_003DzvLFmklk_0024domRMi1KKFXkHqc_003D());
			MethodBase methodBase2 = null;
			try
			{
				methodBase2 = type.GetMethod(_0023_003Dq9cxJfzt6tx3_00245xLDM_0024HAnunU7Xy_WBpJRmOB2qxzSUo_003D2._0023_003DzTO06eh4ctVi8FQHL1ybi_00249JNJanF(), bindingAttr, null, CallingConventions.Any, array, null);
			}
			catch (AmbiguousMatchException)
			{
				MethodInfo[] methods = type.GetMethods(bindingAttr);
				foreach (MethodInfo methodInfo in methods)
				{
					if (methodInfo.Name != _0023_003Dq9cxJfzt6tx3_00245xLDM_0024HAnunU7Xy_WBpJRmOB2qxzSUo_003D2._0023_003DzTO06eh4ctVi8FQHL1ybi_00249JNJanF() || methodInfo.ReturnType != type2)
					{
						continue;
					}
					ParameterInfo[] parameters = methodInfo.GetParameters();
					if (parameters.Length != array.Length)
					{
						continue;
					}
					bool flag2 = false;
					for (int k = 0; k < array.Length; k++)
					{
						if (parameters[k].ParameterType != array[k])
						{
							flag2 = true;
							break;
						}
					}
					if (!flag2)
					{
						methodBase2 = methodInfo;
						break;
					}
				}
			}
			if (methodBase2 == null)
			{
				throw new Exception(string.Format(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564314212), type.Name, _0023_003Dq9cxJfzt6tx3_00245xLDM_0024HAnunU7Xy_WBpJRmOB2qxzSUo_003D2._0023_003DzTO06eh4ctVi8FQHL1ybi_00249JNJanF()));
			}
			if (flag)
			{
				_0023_003DzZpkUTwY_003D.Add(_0023_003Dz9jrlnWk_003D, methodBase2);
			}
			return methodBase2;
		}
	}

	private _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dzuk7pFeGyjkSPMmddbHRfYsu48tCb(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dz9jrlnWk_003D)
	{
		if (_0023_003Dz9jrlnWk_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 1)
		{
			return new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(-((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D());
		}
		if (_0023_003Dz9jrlnWk_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 13)
		{
			return new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(-((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG());
		}
		if (_0023_003Dz9jrlnWk_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 8)
		{
			_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D obj = new _0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D();
			obj._0023_003DzBGdDQOw_INWgxm_K091ViE8d5B7H7_X_0024gA2NQZA_003D(0.0 - ((_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzCfXuHVIlFp1X1u2Med2_AL4lzej8EifTBw_003D_003D());
			return obj;
		}
		if (_0023_003Dz9jrlnWk_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 19)
		{
			Type underlyingType = Enum.GetUnderlyingType(_0023_003Dz9jrlnWk_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D().GetType());
			if (underlyingType == typeof(long) || underlyingType == typeof(ulong))
			{
				return _0023_003Dzuk7pFeGyjkSPMmddbHRfYsu48tCb(new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(Convert.ToInt64(_0023_003Dz9jrlnWk_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D())));
			}
			return _0023_003Dzuk7pFeGyjkSPMmddbHRfYsu48tCb(new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(Convert.ToInt32(_0023_003Dz9jrlnWk_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D())));
		}
		throw new InvalidOperationException();
	}

	private static void _0023_003DzxMz0gml3k46fUq48BFnrgrW6ZHEt4EmGNnBi6iY_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003Dz4aIsGrkxJXsni29jRFACK21EuSDR(_0023_003Dz9jrlnWk_003D: false, _0023_003DzBxpHhQ0_003D: false);
	}

	private bool _0023_003DzFDdYEW_UBGDFCKATfJ3Fdq4UMQmKapQVSw_003D_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dz9jrlnWk_003D, Type _0023_003DzBxpHhQ0_003D)
	{
		object obj = _0023_003Dz9jrlnWk_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D();
		if (obj == null)
		{
			return true;
		}
		Type type = _0023_003Dz9jrlnWk_003D._0023_003Dz55cfCv82_0024cfWUBDPYd5Wu_0024c_003D() ?? obj.GetType();
		if (type == _0023_003DzBxpHhQ0_003D || _0023_003DzBxpHhQ0_003D.IsAssignableFrom(type))
		{
			return true;
		}
		if (!type.IsValueType && !_0023_003DzBxpHhQ0_003D.IsValueType)
		{
			if (Marshal.IsComObject(obj))
			{
				IntPtr intPtr = IntPtr.Zero;
				try
				{
					intPtr = Marshal.GetComInterfaceForObject(obj, _0023_003DzBxpHhQ0_003D);
				}
				catch (ArgumentException)
				{
				}
				catch (InvalidCastException)
				{
				}
				if (intPtr != IntPtr.Zero)
				{
					try
					{
						Marshal.Release(intPtr);
					}
					catch
					{
					}
					return true;
				}
			}
			else if (_0023_003DzXwxIxg08b8kr_hRdUaEBBU7_02q7(obj))
			{
				return true;
			}
		}
		return false;
	}

	private static _0023_003Dz2X8kE24_003D _0023_003DzZ6MTnxiFgca02BIK5SGIFlk_003D(_0023_003DzJ6W8874_003D _0023_003Dz9jrlnWk_003D)
	{
		lock (_0023_003DzG7m2nd8_003D)
		{
			_0023_003DzG7m2nd8_003D.TryGetValue(_0023_003Dz9jrlnWk_003D, out var value);
			return value;
		}
	}

	private static void _0023_003DzeBfxZyrbUHs0mNEfAWxCLEf0zuMFLh7dng_003D_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D2 = (_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D;
		MethodBase methodBase = _0023_003Dz9jrlnWk_003D._0023_003DzRt6UVedmJJGarSZZFciXi_0024twqllky4LsnA_003D_003D(_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D2._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D());
		_0023_003DqZOgqBgNtgFzdL0x3JA7LxzDeXh41TKRK3WDZXmMsiIQ_003D obj = new _0023_003DqZOgqBgNtgFzdL0x3JA7LxzDeXh41TKRK3WDZXmMsiIQ_003D();
		obj._0023_003DzLewIEoK78TTNwxvWLmSRiD8_003D(methodBase);
		_0023_003Dz9jrlnWk_003D._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(obj);
	}

	private static _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzFkdstI_UtodZr8Xa1HlKSbvfxLczlacX8Q_003D_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D, bool _0023_003Dztgqm2r4_003D, bool _0023_003DzzKDx05I_003D)
	{
		if (_0023_003Dz9jrlnWk_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 1)
		{
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 1)
			{
				if (!_0023_003DzzKDx05I_003D)
				{
					int num = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
					int num2 = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
					int num3 = ((!_0023_003Dztgqm2r4_003D) ? (num + num2) : checked(num + num2));
					return new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(num3);
				}
				uint num4 = (uint)((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
				uint num5 = (uint)((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
				uint num6 = ((!_0023_003Dztgqm2r4_003D) ? (num4 + num5) : checked(num4 + num5));
				return new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D((int)num6);
			}
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 13)
			{
				return _0023_003Dzh8LVZLcNsg9yHp4CEcz4UQY5_69b97CEPJJk5wIgUg4q(new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D()), _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D, _0023_003DzzKDx05I_003D);
			}
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 19)
			{
				Type underlyingType = Enum.GetUnderlyingType(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D().GetType());
				if (underlyingType == typeof(long) || underlyingType == typeof(ulong))
				{
					return _0023_003Dzh8LVZLcNsg9yHp4CEcz4UQY5_69b97CEPJJk5wIgUg4q(new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D()), new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(Convert.ToInt64(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D())), _0023_003Dztgqm2r4_003D, _0023_003DzzKDx05I_003D);
				}
				return _0023_003DzFkdstI_UtodZr8Xa1HlKSbvfxLczlacX8Q_003D_003D(_0023_003Dz9jrlnWk_003D, new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(Convert.ToInt32(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D())), _0023_003Dztgqm2r4_003D, _0023_003DzzKDx05I_003D);
			}
		}
		if (_0023_003Dz9jrlnWk_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 13)
		{
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 13)
			{
				return _0023_003Dzh8LVZLcNsg9yHp4CEcz4UQY5_69b97CEPJJk5wIgUg4q(_0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D, _0023_003DzzKDx05I_003D);
			}
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 1)
			{
				return _0023_003Dzh8LVZLcNsg9yHp4CEcz4UQY5_69b97CEPJJk5wIgUg4q(_0023_003Dz9jrlnWk_003D, new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D()), _0023_003Dztgqm2r4_003D, _0023_003DzzKDx05I_003D);
			}
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 19)
			{
				Type underlyingType2 = Enum.GetUnderlyingType(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D().GetType());
				if (underlyingType2 == typeof(long) || underlyingType2 == typeof(ulong))
				{
					return _0023_003Dzh8LVZLcNsg9yHp4CEcz4UQY5_69b97CEPJJk5wIgUg4q(_0023_003Dz9jrlnWk_003D, new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(Convert.ToInt64(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D())), _0023_003Dztgqm2r4_003D, _0023_003DzzKDx05I_003D);
				}
				return _0023_003Dzh8LVZLcNsg9yHp4CEcz4UQY5_69b97CEPJJk5wIgUg4q(_0023_003Dz9jrlnWk_003D, new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(Convert.ToInt32(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D())), _0023_003Dztgqm2r4_003D, _0023_003DzzKDx05I_003D);
			}
		}
		if (_0023_003Dz9jrlnWk_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 8 && _0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 8)
		{
			_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D obj = new _0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D();
			obj._0023_003DzBGdDQOw_INWgxm_K091ViE8d5B7H7_X_0024gA2NQZA_003D(((_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzCfXuHVIlFp1X1u2Med2_AL4lzej8EifTBw_003D_003D() + ((_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzCfXuHVIlFp1X1u2Med2_AL4lzej8EifTBw_003D_003D());
			return obj;
		}
		if (_0023_003Dz9jrlnWk_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 19)
		{
			Type underlyingType3 = Enum.GetUnderlyingType(_0023_003Dz9jrlnWk_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D().GetType());
			if (underlyingType3 == typeof(long) || underlyingType3 == typeof(ulong))
			{
				return _0023_003DzFkdstI_UtodZr8Xa1HlKSbvfxLczlacX8Q_003D_003D(new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(Convert.ToInt64(_0023_003Dz9jrlnWk_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D())), _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D, _0023_003DzzKDx05I_003D);
			}
			return _0023_003DzFkdstI_UtodZr8Xa1HlKSbvfxLczlacX8Q_003D_003D(new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(Convert.ToInt32(_0023_003Dz9jrlnWk_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D())), _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D, _0023_003DzzKDx05I_003D);
		}
		throw new InvalidOperationException();
	}

	private static void _0023_003DzEb3djvv9eM82J3Aj9y7zliu4r86JmvSKveLf7yI_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzGDuTOpKXFiuPe7G4kruEtPUIgmVeEuqxuw_003D_003D(_0023_003Dz9jrlnWk_003D: false);
	}

	private static void _0023_003Dz5_21c2BzPBCiA7YYnHqZl4KDxII_0024(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		_0023_003Dz9jrlnWk_003D._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(_0023_003Dz9jrlnWk_003D._0023_003DzKWldAQdJ09HXMZAyqMT0BMPufBy1QG1190JaTixk_Dee(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2));
	}

	private static void _0023_003DzuP5Ix2A7a_0024Z2RxkISw_003D_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		int num = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
		bool num2 = (num & int.MinValue) != 0;
		bool flag = (num & 0x40000000) != 0;
		num &= 0x3FFFFFFF;
		if (num2)
		{
			_0023_003Dz9jrlnWk_003D._0023_003DzqsLd2orT176bfBS85vdKAL2yi5EJ(num, null, null, flag);
			return;
		}
		_0023_003Dq6RsKbEvjyFgbikPCxI_0024iyaP4iT3cOdFPnt_Mjubq4RU_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iyaP4iT3cOdFPnt_Mjubq4RU_003D2 = (_0023_003Dq6RsKbEvjyFgbikPCxI_0024iyaP4iT3cOdFPnt_Mjubq4RU_003D)_0023_003Dz9jrlnWk_003D._0023_003Dz_kQ6vjzn2xXdxKzdPsJwstuDR14y(num)._0023_003DzMDpHhtfRNQDKXWsFcSVSbdd3Ewg6();
		_0023_003Dz9jrlnWk_003D._0023_003Dz6QIX6pdi7W0E7LFA_PlLav8_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iyaP4iT3cOdFPnt_Mjubq4RU_003D2);
	}

	private static void _0023_003Dzs0xSYxiBeHCPEk_4bPzDUwo_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003Dz6SiV_B3RvFCLEeKqYpPV_0024wVhgzqa(_0023_003Dz9jrlnWk_003D: true, _0023_003DzBxpHhQ0_003D: true);
	}

	private static void _0023_003DzdiGrOgbBeDUwXUg0GOtll058Q99mxRNNUA_003D_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
	}

	private void _0023_003DzzUdLVh6RcJ0qp5eRPoW5he0ADnSX(object _0023_003Dz9jrlnWk_003D)
	{
		if (_0023_003Dz9jrlnWk_003D is Exception ex)
		{
			_0023_003DzMff7ghi3xzu9qzUmg0EUwZE5LB_QMxJsnXlsM8Y_003D(ex);
		}
		_0023_003DzjLjB9OQcoNUwL88DA_IVu5taVPap(_0023_003Dz9jrlnWk_003D);
	}

	private static void _0023_003Dzof_LqC_0024c7kAh7nzMB9hY74hq_002437jG5oMbw_003D_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003Dz4aIsGrkxJXsni29jRFACK21EuSDR(_0023_003Dz9jrlnWk_003D: true, _0023_003DzBxpHhQ0_003D: true);
	}

	private void _0023_003DzqsLd2orT176bfBS85vdKAL2yi5EJ(int _0023_003Dz9jrlnWk_003D, Type[] _0023_003DzBxpHhQ0_003D, Type[] _0023_003Dztgqm2r4_003D, bool _0023_003DzzKDx05I_003D)
	{
		_0023_003DzXlMgCsc_003D._0023_003Dzf_kC_0024hpTUTdHx7uANBVIZvPU6fFbivFk0g_003D_003D()._0023_003Dzz5uSZofwQCQyOcEKwfVQmiivZ_0024bgBfg6QfI4mYf6tHIC42rk18fkszOb_ezLTX5YRgaBPKGRm6aQTYVwBg_003D_003D(_0023_003Dz9jrlnWk_003D, 0);
		_0023_003Dzj23zu2OgBiiaSGUW_0024C7Zbq_00249vIZl(_0023_003DzXlMgCsc_003D);
		_0023_003DqaEtT9DoRRoUP_0024LS5u4B6AojK4YaTqiLM3Vc605IaRGE_003D _0023_003DqaEtT9DoRRoUP_0024LS5u4B6AojK4YaTqiLM3Vc605IaRGE_003D2 = _0023_003DzDwre1ZXjPmbPlE2pCbnX_0024wo_003D(_0023_003DzXlMgCsc_003D);
		_0023_003DzEAO11fx6tMV7coCxBkB8KpJ9e37fAWJxyG_OLJik0M27(_0023_003DqaEtT9DoRRoUP_0024LS5u4B6AojK4YaTqiLM3Vc605IaRGE_003D2);
		int num = _0023_003DqaEtT9DoRRoUP_0024LS5u4B6AojK4YaTqiLM3Vc605IaRGE_003D2._0023_003DzPFkh31N3VRlmNc8nf2IWmYdUiYAF().Length;
		object[] array = new object[num];
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D[] array2 = new _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D[num];
		if (_0023_003Dzn6_Dl38_003D != null && _0023_003DzzKDx05I_003D)
		{
			int num2 = ((!_0023_003DqaEtT9DoRRoUP_0024LS5u4B6AojK4YaTqiLM3Vc605IaRGE_003D2._0023_003DzKttHpAQ_gTjjjLgkDh9KnFaqusae()) ? 1 : 0);
			Type[] array3 = new Type[num - num2];
			for (int num3 = num - 1; num3 >= num2; num3--)
			{
				array3[num3] = _0023_003Dz9_Z5EhGFT4yzpTmOPYjfhZOeNABFeUtCmZ_KeWA_003D(_0023_003DqaEtT9DoRRoUP_0024LS5u4B6AojK4YaTqiLM3Vc605IaRGE_003D2._0023_003DzPFkh31N3VRlmNc8nf2IWmYdUiYAF()[num3]._0023_003DzBLbiSG4pMsCq5QXcv4IAsSJsqlAkD0L7ST9ge5Ogka39(), _0023_003DzBxpHhQ0_003D: true);
			}
			MethodInfo method = _0023_003Dzn6_Dl38_003D.GetMethod(_0023_003DqaEtT9DoRRoUP_0024LS5u4B6AojK4YaTqiLM3Vc605IaRGE_003D2._0023_003DznreDdTd5uS_MeC2m0FTHaTTa0lrL(), BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.InvokeMethod | BindingFlags.GetProperty | BindingFlags.SetProperty, null, array3, null);
			_0023_003Dzn6_Dl38_003D = null;
			if (method != null)
			{
				_0023_003Dz3Kd3rvERK8HcEu6iFYdwh0o_003D(method, _0023_003DzBxpHhQ0_003D: true);
				return;
			}
		}
		for (int num4 = num - 1; num4 >= 0; num4--)
		{
			_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = (array2[num4] = _0023_003DzrQFXD5oP9hinX0g4gA_003D_003D());
			if (_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 is _0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D _0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D2)
			{
				_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003DzcyfMbnJemFaR1U9IYqWp0cPmk80NlqUX5LErUtBcWaeU(_0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D2);
			}
			if (_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003Dz55cfCv82_0024cfWUBDPYd5Wu_0024c_003D() != null)
			{
				_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D._0023_003DzCysyOfnrUQB5WqShWAIL_0024X4XGCe9eW67eVeg6HY_003D(null, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003Dz55cfCv82_0024cfWUBDPYd5Wu_0024c_003D())._0023_003DzAPlrN6aYwAg5F1LxHYbv_0024wOBB_0024afgbz6XKGgvF_0024QaP3F7Nvwy8DGE80Q1m63nNv21_00240QxzxHCeC2PtE3mw_003D_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2);
			}
			_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3 = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D._0023_003DzCysyOfnrUQB5WqShWAIL_0024X4XGCe9eW67eVeg6HY_003D(null, _0023_003Dz9_Z5EhGFT4yzpTmOPYjfhZOeNABFeUtCmZ_KeWA_003D(_0023_003DqaEtT9DoRRoUP_0024LS5u4B6AojK4YaTqiLM3Vc605IaRGE_003D2._0023_003DzPFkh31N3VRlmNc8nf2IWmYdUiYAF()[num4]._0023_003DzBLbiSG4pMsCq5QXcv4IAsSJsqlAkD0L7ST9ge5Ogka39(), _0023_003DzBxpHhQ0_003D: true))._0023_003DzAPlrN6aYwAg5F1LxHYbv_0024wOBB_0024afgbz6XKGgvF_0024QaP3F7Nvwy8DGE80Q1m63nNv21_00240QxzxHCeC2PtE3mw_003D_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2);
			array[num4] = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D();
			if (num4 == 0 && _0023_003DzzKDx05I_003D && !_0023_003DqaEtT9DoRRoUP_0024LS5u4B6AojK4YaTqiLM3Vc605IaRGE_003D2._0023_003DzKttHpAQ_gTjjjLgkDh9KnFaqusae() && array[num4] == null)
			{
				throw new NullReferenceException();
			}
		}
		_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2 = new _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D(_0023_003DzWAsKAZU_003D);
		object[] array4 = new object[1] { this.m__0023_003DzJ6W8874_003D.Assembly };
		object obj;
		try
		{
			obj = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003Dz6kYIsK1ypjf7EBWahwpDMjFtihx3FdF8RvnWYV7gMyYG(this.m__0023_003DzJGsRSpg_003D, _0023_003Dz9jrlnWk_003D, array, _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D, array4);
		}
		finally
		{
			bool flag = !_0023_003DqaEtT9DoRRoUP_0024LS5u4B6AojK4YaTqiLM3Vc605IaRGE_003D2._0023_003DzKttHpAQ_gTjjjLgkDh9KnFaqusae();
			for (int i = 0; i < num; i++)
			{
				int num5;
				if (flag)
				{
					num5 = i + 1;
					if (num5 == num)
					{
						num5 = 0;
					}
				}
				else
				{
					num5 = i;
				}
				if (array2[num5] is _0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D _0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D3)
				{
					_0023_003DzlLFsRbFCVJXLxNmd_0024gDP8S8_003D(_0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D3, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D._0023_003DzCysyOfnrUQB5WqShWAIL_0024X4XGCe9eW67eVeg6HY_003D(array[num5], null));
				}
			}
		}
		Type type = _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2._0023_003Dz9_Z5EhGFT4yzpTmOPYjfhZOeNABFeUtCmZ_KeWA_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D2.m__0023_003DzaTyQZ6E_003D._0023_003Dz4SnewdlRHKMKBUE_0024QZQUmfm_FxaNJj9Jag_003D_003D(), _0023_003DzBxpHhQ0_003D: true);
		if (type != _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D.m__0023_003Dz9I8ZVlc_003D)
		{
			_0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D._0023_003DzCysyOfnrUQB5WqShWAIL_0024X4XGCe9eW67eVeg6HY_003D(obj, type));
		}
	}

	private void _0023_003Dz5ky4pu2_00245NqtcI37a_mjNnb49zcJiJ0NC6G9vYM_003D(bool _0023_003Dz9jrlnWk_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		long num = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() switch
		{
			1 => (!_0023_003Dz9jrlnWk_003D) ? ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D() : ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D(), 
			13 => (!_0023_003Dz9jrlnWk_003D) ? ((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG() : ((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG(), 
			19 => (!_0023_003Dz9jrlnWk_003D) ? ((long)Convert.ToUInt64(((_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D())) : checked((long)Convert.ToUInt64(((_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D())), 
			8 => (!_0023_003Dz9jrlnWk_003D) ? ((long)((_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzCfXuHVIlFp1X1u2Med2_AL4lzej8EifTBw_003D_003D()) : checked((long)((_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzCfXuHVIlFp1X1u2Med2_AL4lzej8EifTBw_003D_003D()), 
			0 => (!_0023_003Dz9jrlnWk_003D) ? ((long)((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk()) : ((long)((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk()), 
			_ => throw new InvalidOperationException(), 
		};
		_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D obj = new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D();
		obj._0023_003Dzbu_MJyfs7_Zi8dZPXG8_00248P0_003D(num);
		_0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(obj);
	}

	private _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzcyfMbnJemFaR1U9IYqWp0cPmk80NlqUX5LErUtBcWaeU(_0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D _0023_003Dz9jrlnWk_003D)
	{
		switch (_0023_003Dz9jrlnWk_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D())
		{
		case 2:
			return ((_0023_003DqFNN_kH3_Aic_0024vq9s6N7BcnqdUOw1mJpa1yIMZD1vbOQ_003D)_0023_003Dz9jrlnWk_003D)._0023_003DziVOWcx_00243zo4_0iYh_0024lucKGuN0vuo();
		case 23:
			return this.m__0023_003DziiEv3wQ_003D[((_0023_003DqOnAL2yhFn6qFFxtB3vCWqYNkaIJ5qqh3h6z2BC38Mh4_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzP_6DBNZ2mJNKRaFdqnf64UitOXKm60smb3aoCTTiqt7H()];
		case 18:
		{
			_0023_003DqrQPc9rwDL7Fl53_0024M2Pi1fo_0024Ac1BCNKiaW0Mx66Ji04U_003D _0023_003DqrQPc9rwDL7Fl53_0024M2Pi1fo_0024Ac1BCNKiaW0Mx66Ji04U_003D2 = (_0023_003DqrQPc9rwDL7Fl53_0024M2Pi1fo_0024Ac1BCNKiaW0Mx66Ji04U_003D)_0023_003Dz9jrlnWk_003D;
			return _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D._0023_003DzCysyOfnrUQB5WqShWAIL_0024X4XGCe9eW67eVeg6HY_003D(_0023_003DqrQPc9rwDL7Fl53_0024M2Pi1fo_0024Ac1BCNKiaW0Mx66Ji04U_003D2._0023_003DzOGfSdf3O2RGD18omagPRFM_0024yH5C6().GetValue(_0023_003DqrQPc9rwDL7Fl53_0024M2Pi1fo_0024Ac1BCNKiaW0Mx66Ji04U_003D2._0023_003DzcI1_N_0024zFH93ki__00245WrAnggkz3DwKuotj_0024Q_003D_003D()), null);
		}
		case 11:
		case 24:
		{
			_0023_003Dq0sd17OXY9HyRTHP4MNrXEWjZPbMynKvVMW_pliUAx6w_003D _0023_003Dq0sd17OXY9HyRTHP4MNrXEWjZPbMynKvVMW_pliUAx6w_003D2 = (_0023_003Dq0sd17OXY9HyRTHP4MNrXEWjZPbMynKvVMW_pliUAx6w_003D)_0023_003Dz9jrlnWk_003D;
			return _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D._0023_003DzCysyOfnrUQB5WqShWAIL_0024X4XGCe9eW67eVeg6HY_003D(_0023_003Dq0sd17OXY9HyRTHP4MNrXEWjZPbMynKvVMW_pliUAx6w_003D2._0023_003DzVdsM_TqzcZphD3EV12i7hTzyWsLk_C1xSWiVqGX0jsgiOLbnX0cnK_lndyxe_nqJxFgf5Pc_003D(), _0023_003Dq0sd17OXY9HyRTHP4MNrXEWjZPbMynKvVMW_pliUAx6w_003D2._0023_003DznlMw3Z6vPsFd4RZ75Ii7QhJ7FGdgEIeMO4R17cc_003D());
		}
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	private static void _0023_003Dz6wusaAiBOD6XjRrvZiaYdT40Dc_0024NKz32tQ_003D_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		int num = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
		string text = _0023_003Dz9jrlnWk_003D._0023_003DzxW_0024wA_o40UkoRPgQw4t_0024_wZZnQl5dcP5DiFZrswScyOP(num);
		_0023_003DqU9yZW7eck7EhOE03v76I8g_ZAkOEXEbgxMSUsI3YrFY_003D obj = new _0023_003DqU9yZW7eck7EhOE03v76I8g_ZAkOEXEbgxMSUsI3YrFY_003D();
		obj._0023_003DzmRCWPl2nb6XoVxP_mjXregk_003D(text);
		_0023_003Dz9jrlnWk_003D._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(obj);
	}

	private static void _0023_003DzLWsQxt07lqj4BnmF17wJyBw_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3 = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		if ((_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() != 8) ? (!_0023_003DzFCI8XumDuJuKa_0024WkwlglF8STueBuOL3SGHPfX6c_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)) : (!_0023_003Dz85ZnAjLw5GuUis_0024G0X_hQ3rZyzLji_2Y9G_l2yE_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)))
		{
			uint num = ((_0023_003DqJFdrGiwz1aJICVkSTb_0024Zko9aS6iSwDcZdo9VS4Dkh_0024s_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzxGjrL4iuhvogLPGFSdnVXdPvbKxem9P4HA_003D_003D();
			_0023_003Dz9jrlnWk_003D._0023_003Dz9r__0024YTGu_0024iN2qFjqe6k1t7s_003D(num);
		}
	}

	private long _0023_003DzWcPCdsp22a3yYh4GeH8s_0024I8_003D()
	{
		return _0023_003DzLi0XoCY_003D._0023_003Dzf_kC_0024hpTUTdHx7uANBVIZvPU6fFbivFk0g_003D_003D()._0023_003Dz_0024PxYTL_nlzJnpvFXwwRZmMj6PIfqbJZrp54foI9tn5jPksqeRkurekdA04xNnozUhhfo4rA_003D() + _0023_003DzFQGDh5A_003D;
	}

	private static void _0023_003Dzbs4xIzkJxtqVehNtuavtZ0PqM9Dc(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		throw new NotSupportedException(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564315501));
	}

	private static void _0023_003DzF_0024OELR5WtbLoLu_NkkYkKkk_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003DqIC7wdNmeVLrKuHjiCL8jtht_0024ogaMGYTl_vFxiqwcERQ_003D _0023_003DqIC7wdNmeVLrKuHjiCL8jtht_0024ogaMGYTl_vFxiqwcERQ_003D2 = (_0023_003DqIC7wdNmeVLrKuHjiCL8jtht_0024ogaMGYTl_vFxiqwcERQ_003D)_0023_003DzBxpHhQ0_003D;
		_0023_003Dz9jrlnWk_003D._0023_003DzpU_n7PfnyRyJ1anIgJrsjiSffFPi(_0023_003DqIC7wdNmeVLrKuHjiCL8jtht_0024ogaMGYTl_vFxiqwcERQ_003D2._0023_003Dz3fdyocpuocHKnMPBAP0IP10_003D());
	}

	private static void _0023_003Dz_0024u8gc5hRApDlrEU9AD_0024bbTzcqqIHCCs49y1_bCI_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D2 = (_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D;
		MethodBase methodBase = _0023_003Dz9jrlnWk_003D._0023_003DzRt6UVedmJJGarSZZFciXi_0024twqllky4LsnA_003D_003D(_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D2._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D());
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D[] array = _0023_003Dz9jrlnWk_003D._0023_003DzWn08U5s_003D;
		foreach (_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 in array)
		{
			_0023_003Dz9jrlnWk_003D._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2);
		}
		_0023_003Dz9jrlnWk_003D._0023_003Dz3Kd3rvERK8HcEu6iFYdwh0o_003D(methodBase, _0023_003DzBxpHhQ0_003D: false);
	}

	private static void _0023_003DzzJsfHuVbCYURsy7mGxn3wECDm6Rx(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzwbI83bfoaDmYaZBDzj4leqo_003D(3);
	}

	private void _0023_003DzH5ozr5LVbpuoOMs7OGq0_HiG1jqsa5wf1w_003D_003D(bool _0023_003Dz9jrlnWk_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		sbyte b = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() switch
		{
			1 => (!_0023_003Dz9jrlnWk_003D) ? ((sbyte)((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D()) : checked((sbyte)((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D()), 
			13 => (!_0023_003Dz9jrlnWk_003D) ? ((sbyte)((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG()) : checked((sbyte)((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG()), 
			19 => (!_0023_003Dz9jrlnWk_003D) ? ((sbyte)Convert.ToUInt64(((_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D())) : checked((sbyte)Convert.ToUInt64(((_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D())), 
			8 => (!_0023_003Dz9jrlnWk_003D) ? ((sbyte)((_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzCfXuHVIlFp1X1u2Med2_AL4lzej8EifTBw_003D_003D()) : checked((sbyte)((_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzCfXuHVIlFp1X1u2Med2_AL4lzej8EifTBw_003D_003D()), 
			0 => (IntPtr.Size != 4) ? ((!_0023_003Dz9jrlnWk_003D) ? ((sbyte)(long)((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk()) : checked((sbyte)(long)((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk())) : ((!_0023_003Dz9jrlnWk_003D) ? ((sbyte)(int)((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk()) : checked((sbyte)(int)((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk())), 
			_ => throw new InvalidOperationException(), 
		};
		_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D obj = new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D();
		obj._0023_003DzVS8y6A9spdnllqaw83gW5bpUS8si(b);
		_0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(obj);
	}

	private static void _0023_003DzTEYm11CLRTx0imq2hCrcy0sSOJst(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		if (!_0023_003DzjxnjI9Nvph1jzn_0024_xDbv5Sk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D(), _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2))
		{
			uint num = ((_0023_003DqJFdrGiwz1aJICVkSTb_0024Zko9aS6iSwDcZdo9VS4Dkh_0024s_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzxGjrL4iuhvogLPGFSdnVXdPvbKxem9P4HA_003D_003D();
			_0023_003Dz9jrlnWk_003D._0023_003Dz9r__0024YTGu_0024iN2qFjqe6k1t7s_003D(num);
		}
	}

	private static void _0023_003DzMF2mW49AFbC8qsHhvEgWuCYeHdIk02A6AtvtuRo_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzH5ozr5LVbpuoOMs7OGq0_HiG1jqsa5wf1w_003D_003D(_0023_003Dz9jrlnWk_003D: true);
	}

	private static void _0023_003Dze9vCPDkq3OU5BaCdbOE02Y9H_00246_00245pYTdNA_003D_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzUbKftaPsoH4C3o3km5CXFp43OkI85ZTJMKNMSEuJ_LI5(typeof(int));
	}

	private long _0023_003Dz48d1zHJh3TOQKfAMFYN6p1CRbnL4()
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		return _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() switch
		{
			1 => ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D(), 
			0 => ((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk().ToInt64(), 
			20 => (long)((_0023_003DqVEj3J19zkgEyU6VFymBz6riyi6CxZMJEjhA0KZ2nLKw_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzZlwwYywinAe9h_2ss_0024Wn4RsajDr79HfGCg_003D_003D().ToUInt64(), 
			19 => Convert.ToInt64(((_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D()), 
			_ => throw new Exception(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564314163)), 
		};
	}

	private static void _0023_003DzhQsVTSKld4gsbxPG0w1WiesHJdzUNzRZjL_AGuA_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzUbKftaPsoH4C3o3km5CXFp43OkI85ZTJMKNMSEuJ_LI5(typeof(short));
	}

	private static void _0023_003DzhBolrhZcl35r8WbUd_0024LgzpA_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003DqJFdrGiwz1aJICVkSTb_0024Zkh7zAYa9iZm47EqlnjrFUg4_003D _0023_003DqJFdrGiwz1aJICVkSTb_0024Zkh7zAYa9iZm47EqlnjrFUg4_003D2 = (_0023_003DqJFdrGiwz1aJICVkSTb_0024Zkh7zAYa9iZm47EqlnjrFUg4_003D)_0023_003DzBxpHhQ0_003D;
		_0023_003DqFNN_kH3_Aic_0024vq9s6N7BcnqdUOw1mJpa1yIMZD1vbOQ_003D obj = new _0023_003DqFNN_kH3_Aic_0024vq9s6N7BcnqdUOw1mJpa1yIMZD1vbOQ_003D();
		obj._0023_003DzlpaqC69eD5UfV5QZE9NijsO7MeQh(_0023_003Dz9jrlnWk_003D._0023_003DzWn08U5s_003D[_0023_003DqJFdrGiwz1aJICVkSTb_0024Zkh7zAYa9iZm47EqlnjrFUg4_003D2._0023_003Dzi58Fb_0024k5T0u9_0024uYc9Q_003D_003D()]);
		_0023_003Dz9jrlnWk_003D._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(obj);
	}

	private void _0023_003DziT_0024hGl890RvhJvA9tQ2z8ve48aG3dsn3uH8b5po_003D(bool _0023_003Dz9jrlnWk_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		int num = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() switch
		{
			1 => (!_0023_003Dz9jrlnWk_003D) ? ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D() : ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D(), 
			13 => (int)((!_0023_003Dz9jrlnWk_003D) ? ((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG() : checked((int)((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG())), 
			19 => (!_0023_003Dz9jrlnWk_003D) ? ((int)Convert.ToUInt64(((_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D())) : checked((int)Convert.ToUInt64(((_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D())), 
			8 => (!_0023_003Dz9jrlnWk_003D) ? ((int)((_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzCfXuHVIlFp1X1u2Med2_AL4lzej8EifTBw_003D_003D()) : checked((int)((_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzCfXuHVIlFp1X1u2Med2_AL4lzej8EifTBw_003D_003D()), 
			0 => (int)((IntPtr.Size != 4) ? ((!_0023_003Dz9jrlnWk_003D) ? ((long)((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk()) : checked((int)(long)((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk())) : ((!_0023_003Dz9jrlnWk_003D) ? ((int)((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk()) : ((int)((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk()))), 
			_ => throw new InvalidOperationException(), 
		};
		_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D obj = new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D();
		obj._0023_003DzVS8y6A9spdnllqaw83gW5bpUS8si(num);
		_0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(obj);
	}

	private void _0023_003DzpU_n7PfnyRyJ1anIgJrsjiSffFPi(int _0023_003Dz9jrlnWk_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		if (_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 is _0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D)
		{
			this.m__0023_003DziiEv3wQ_003D[_0023_003Dz9jrlnWk_003D] = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2;
		}
		else
		{
			this.m__0023_003DziiEv3wQ_003D[_0023_003Dz9jrlnWk_003D]._0023_003DzAPlrN6aYwAg5F1LxHYbv_0024wOBB_0024afgbz6XKGgvF_0024QaP3F7Nvwy8DGE80Q1m63nNv21_00240QxzxHCeC2PtE3mw_003D_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2);
		}
	}

	[_0023_003DqVFAcyYKahdwaFZMP0V7msjS_787Nv39REvMycxmXGBM_003D(2)]
	private bool _0023_003DzaFNJdwovGDUQXvp1HBy7CBoOXI_0024BhOGQeoMc54o_003D([_0023_003Dq9o_OPfa_DuRpdjQlVA0aimj5lmMpAXSbykDZsxdP0k4_003D(1)] MethodBase _0023_003Dz9jrlnWk_003D, object _0023_003DzBxpHhQ0_003D, ref object _0023_003Dztgqm2r4_003D, [_0023_003Dq9o_OPfa_DuRpdjQlVA0aimj5lmMpAXSbykDZsxdP0k4_003D(new byte[] { 1, 2 })] object[] _0023_003DzzKDx05I_003D)
	{
		Type declaringType = _0023_003Dz9jrlnWk_003D.DeclaringType;
		if (declaringType == null)
		{
			return false;
		}
		if (_0023_003DqqSQMR5x0Ss3kUZAkPHTc7q6IdaUzR_0024BTopvbTI_0024P7DA_003D._0023_003Dzt6IW3o7Q3_0024kDG1z4CqtvMH1iuswjFBlVqVIQyrQ_003D(declaringType))
		{
			string name = _0023_003Dz9jrlnWk_003D.Name;
			if (name.Equals(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564315242), StringComparison.Ordinal))
			{
				_0023_003Dztgqm2r4_003D = _0023_003DzBxpHhQ0_003D != null;
			}
			else if (name.Equals(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564315207), StringComparison.Ordinal))
			{
				if (_0023_003DzBxpHhQ0_003D == null)
				{
					return ((bool?)null).Value;
				}
				_0023_003Dztgqm2r4_003D = _0023_003DzBxpHhQ0_003D;
			}
			else if (name.Equals(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564315063), StringComparison.Ordinal))
			{
				switch (_0023_003DzzKDx05I_003D.Length)
				{
				case 0:
					_0023_003Dztgqm2r4_003D = _0023_003DzBxpHhQ0_003D;
					break;
				case 1:
					if (_0023_003DzBxpHhQ0_003D != null)
					{
						_0023_003Dztgqm2r4_003D = _0023_003DzBxpHhQ0_003D;
					}
					else
					{
						_0023_003Dztgqm2r4_003D = _0023_003DzzKDx05I_003D[0];
					}
					break;
				default:
					return false;
				}
			}
			else
			{
				if (_0023_003DzBxpHhQ0_003D != null || _0023_003Dz9jrlnWk_003D.IsStatic)
				{
					return false;
				}
				_0023_003Dztgqm2r4_003D = null;
			}
			return true;
		}
		if (declaringType == _0023_003DzCbpaZow_003D)
		{
			string name2 = _0023_003Dz9jrlnWk_003D.Name;
			if (name2.Equals(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564315055), StringComparison.Ordinal))
			{
				_0023_003Dztgqm2r4_003D = _0023_003DqqSQMR5x0Ss3kUZAkPHTc7q6IdaUzR_0024BTopvbTI_0024P7DA_003D._0023_003Dz2X8kE24_003D;
				return true;
			}
			if (this.m__0023_003DzgqvoyJk_003D != null && name2.Equals(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564315012), StringComparison.Ordinal))
			{
				object[] array = this.m__0023_003DzgqvoyJk_003D;
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i] is Assembly assembly)
					{
						_0023_003Dztgqm2r4_003D = assembly;
						return true;
					}
				}
			}
		}
		else if (declaringType == _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D.m__0023_003DzBxpHhQ0_003D)
		{
			if (_0023_003Dz9jrlnWk_003D.Name.Equals(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564315131), StringComparison.Ordinal))
			{
				if (this.m__0023_003DzgqvoyJk_003D != null)
				{
					object[] array = this.m__0023_003DzgqvoyJk_003D;
					for (int i = 0; i < array.Length; i++)
					{
						if (array[i] is MethodBase methodBase)
						{
							_0023_003Dztgqm2r4_003D = methodBase;
							return true;
						}
					}
				}
				_0023_003Dztgqm2r4_003D = MethodBase.GetCurrentMethod();
				return true;
			}
		}
		else if (declaringType.IsArray && declaringType.GetArrayRank() >= 2)
		{
			return _0023_003Dz2beHmJ0exrgLlf2VcUt4H98_003D(_0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D, ref _0023_003Dztgqm2r4_003D, _0023_003DzzKDx05I_003D);
		}
		return false;
	}

	private static void _0023_003DziRU_xNmpbHm4O0cWUSDN7RH2pwns10aYB_0024UiVN8_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3 = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		_0023_003Dz9jrlnWk_003D._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(_0023_003Dz9jrlnWk_003D._0023_003Dz7WIqQGaXZefoDBw0v6JVcpCgOJklztcSgMYd8dOHL87g(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2));
	}

	private static void _0023_003DzmJON0bKjYo1KqM0lvS1MfA_tMjEt(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DznvlgEOPraWZmqD5ceLuYFnVSbntYJqpYPE8kmaw_003D(_0023_003Dz9jrlnWk_003D: true);
	}

	private static void _0023_003DztLIUwHBrwm6kCoZvJeUrY2pm6pyqW6Il1w_003D_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003Dzvg4CefujOdISFD_Gu2MjrJce5AXn(_0023_003Dz9jrlnWk_003D: true);
	}

	private static void _0023_003DznU5sME325gIO2bObbq7AjPt7giRRci2Q2HV0Yss_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		_0023_003Dz9jrlnWk_003D._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(checked(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() switch
		{
			1 => (int)(uint)((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D(), 
			13 => (int)(ulong)((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG(), 
			19 => (int)Convert.ToUInt64(((_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D()), 
			8 => (int)((_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzCfXuHVIlFp1X1u2Med2_AL4lzej8EifTBw_003D_003D(), 
			0 => (IntPtr.Size != 4) ? ((int)(ulong)(long)((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk()) : ((int)(uint)(int)((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk()), 
			_ => throw new InvalidOperationException(), 
		})));
	}

	private static void _0023_003DzpNlFQ2zde8bqILHBdfUD3QcJn3oF(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3 = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		if ((_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() != 8) ? (!_0023_003Dz85ZnAjLw5GuUis_0024G0X_hQ3rZyzLji_2Y9G_l2yE_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)) : (!_0023_003DzFCI8XumDuJuKa_0024WkwlglF8STueBuOL3SGHPfX6c_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)))
		{
			uint num = ((_0023_003DqJFdrGiwz1aJICVkSTb_0024Zko9aS6iSwDcZdo9VS4Dkh_0024s_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzxGjrL4iuhvogLPGFSdnVXdPvbKxem9P4HA_003D_003D();
			_0023_003Dz9jrlnWk_003D._0023_003Dz9r__0024YTGu_0024iN2qFjqe6k1t7s_003D(num);
		}
	}

	private static void _0023_003DzCt85HvcPUBOmiwRcmg_003D_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzUbKftaPsoH4C3o3km5CXFp43OkI85ZTJMKNMSEuJ_LI5(typeof(double));
	}

	private static _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dz8PDB4fIscUcZmlCotGqEYZVtBdP3(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D, bool _0023_003Dztgqm2r4_003D, bool _0023_003DzzKDx05I_003D)
	{
		if (!_0023_003DzzKDx05I_003D)
		{
			long num = ((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG();
			long num2 = ((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG();
			long num3 = ((!_0023_003Dztgqm2r4_003D) ? (num * num2) : checked(num * num2));
			return new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(num3);
		}
		ulong num4 = (ulong)((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG();
		ulong num5 = (ulong)((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG();
		ulong num6 = ((!_0023_003Dztgqm2r4_003D) ? (num4 * num5) : checked(num4 * num5));
		return new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D((long)num6);
	}

	private static void _0023_003DzV7VI1wgZICewv2vuP3DRJYOQWeVU(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		IntPtr intPtr = checked(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() switch
		{
			1 => new IntPtr((uint)((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D()), 
			13 => new IntPtr((long)(ulong)((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG()), 
			19 => new IntPtr((long)Convert.ToUInt64(((_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D())), 
			8 => new IntPtr((long)((_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzCfXuHVIlFp1X1u2Med2_AL4lzej8EifTBw_003D_003D()), 
			_ => throw new InvalidOperationException(), 
		});
		_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D obj = new _0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D();
		obj._0023_003DzXFR8k7cM8wiYjjnXjPEa5idSBqAKmHeRH0GHZG0_003D(intPtr);
		_0023_003Dz9jrlnWk_003D._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(obj);
	}

	private static void _0023_003Dzu_0024JglTBxvwey0ooGxOjA6Pw_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzriXIwLFCuwD1GZVAt_00248x4do_003D(_0023_003Dz9jrlnWk_003D: true, _0023_003DzBxpHhQ0_003D: false);
	}

	private static void _0023_003Dz5DjA4KcpOLUVzQUcuw_003D_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		int num = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
		Type type = _0023_003Dz9jrlnWk_003D._0023_003Dz9_Z5EhGFT4yzpTmOPYjfhZOeNABFeUtCmZ_KeWA_003D(num, _0023_003DzBxpHhQ0_003D: true);
		_0023_003Dz9jrlnWk_003D._0023_003Dz_bTfuOd_0024_8tksF6orA_003D_003D(type);
	}

	private void _0023_003DztqiIS5t19tn4D0pTuVrmqGw_003D(int _0023_003Dz9jrlnWk_003D)
	{
		_0023_003DqOnAL2yhFn6qFFxtB3vCWqYNkaIJ5qqh3h6z2BC38Mh4_003D obj = new _0023_003DqOnAL2yhFn6qFFxtB3vCWqYNkaIJ5qqh3h6z2BC38Mh4_003D();
		obj._0023_003DzkPebGDdWm7glYUENu5uyKReqqBmF0PdzCKYBxW4_003D(_0023_003Dz9jrlnWk_003D);
		_0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(obj);
	}

	private static void _0023_003Dzwd96clizxQzi8_0024GGhQ37NNZ92BHy(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzLMJxSSXveUKWgX7ByprFEtw_003D(typeof(double));
	}

	private Type _0023_003Dzb4fEknSH0DX3Il_0024eASrQlFwF1j5gkzTROg4mgLg_003D(int _0023_003Dz9jrlnWk_003D, _0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D _0023_003DzBxpHhQ0_003D, ref bool _0023_003Dztgqm2r4_003D, bool _0023_003DzzKDx05I_003D)
	{
		if (_0023_003DzBxpHhQ0_003D._0023_003DzwH8K7lD_0024cC3gY_RIDCO_Bu8Tp6tgtXa0TA_003D_003D() == 0)
		{
			return this.m__0023_003DzJ6W8874_003D.ResolveType(_0023_003DzBxpHhQ0_003D._0023_003DztkhwzVeVIldXjs1hyonqsqcuOAEF());
		}
		_0023_003DqPjU0as5GIhLtc26yxRodCiKMERUKL9IxtNScNVINKZc_003D _0023_003DqPjU0as5GIhLtc26yxRodCiKMERUKL9IxtNScNVINKZc_003D2 = (_0023_003DqPjU0as5GIhLtc26yxRodCiKMERUKL9IxtNScNVINKZc_003D)_0023_003DzBxpHhQ0_003D._0023_003DzMDpHhtfRNQDKXWsFcSVSbdd3Ewg6();
		Type type = null;
		if (_0023_003DqPjU0as5GIhLtc26yxRodCiKMERUKL9IxtNScNVINKZc_003D2._0023_003DzIsjHzdcuzGdSqor3vgD1SoE_003D())
		{
			if (_0023_003DqPjU0as5GIhLtc26yxRodCiKMERUKL9IxtNScNVINKZc_003D2._0023_003DzCA_0024OHBkvYTZ6MGsozJZ6gvPnIeQL() != -1)
			{
				if (_0023_003DzS5oUG4s_003D == null)
				{
					throw new InvalidOperationException(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564314922));
				}
				type = _0023_003DzS5oUG4s_003D[_0023_003DqPjU0as5GIhLtc26yxRodCiKMERUKL9IxtNScNVINKZc_003D2._0023_003DzCA_0024OHBkvYTZ6MGsozJZ6gvPnIeQL()];
			}
			else
			{
				if (_0023_003DqPjU0as5GIhLtc26yxRodCiKMERUKL9IxtNScNVINKZc_003D2._0023_003Dzs1D4_t6sHQk7GUdqTeOqqOlLVEhLdPpZYg_003D_003D() == -1)
				{
					throw new Exception();
				}
				if (this.m__0023_003DzzKDx05I_003D == null)
				{
					throw new InvalidOperationException(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564314905));
				}
				type = this.m__0023_003DzzKDx05I_003D[_0023_003DqPjU0as5GIhLtc26yxRodCiKMERUKL9IxtNScNVINKZc_003D2._0023_003Dzs1D4_t6sHQk7GUdqTeOqqOlLVEhLdPpZYg_003D_003D()];
			}
			Stack<_0023_003DqZ8xUF8j1H1xe23Bhq6AA_00245uetOX5am41AHr7lae5URI_003D> stack = _0023_003DqqSQMR5x0Ss3kUZAkPHTc7q6IdaUzR_0024BTopvbTI_0024P7DA_003D._0023_003Dz7_0024wzmK3JL_0024TbuGQSj3r9ppA_003D(_0023_003DqPjU0as5GIhLtc26yxRodCiKMERUKL9IxtNScNVINKZc_003D2._0023_003DzzVF2AvNQRGpMNR5IK2JnSz2f_0024IAfKZWWlA_003D_003D());
			type = _0023_003DqqSQMR5x0Ss3kUZAkPHTc7q6IdaUzR_0024BTopvbTI_0024P7DA_003D._0023_003DzPt2e8Z0FmuRfy6_0024e86fqym0_003D(type, stack);
			_0023_003Dztgqm2r4_003D = false;
			return type;
		}
		string text = _0023_003DqPjU0as5GIhLtc26yxRodCiKMERUKL9IxtNScNVINKZc_003D2._0023_003DzzVF2AvNQRGpMNR5IK2JnSz2f_0024IAfKZWWlA_003D_003D();
		try
		{
			type = Type.GetType(text);
		}
		catch (BadImageFormatException)
		{
		}
		if (type == null)
		{
			int num = text.IndexOf(',');
			string text2 = text.Substring(0, num);
			string text3 = text.Substring(num + 1).Trim();
			Assembly assembly = _0023_003DqqSQMR5x0Ss3kUZAkPHTc7q6IdaUzR_0024BTopvbTI_0024P7DA_003D._0023_003Dz2X8kE24_003D;
			if (text3.Equals(assembly.FullName, StringComparison.OrdinalIgnoreCase))
			{
				type = ((!text2.Equals(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564315000), StringComparison.Ordinal)) ? assembly.GetType(text2) : _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D.m__0023_003DzbSmUaeo_003D);
			}
			else
			{
				Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
				foreach (Assembly assembly2 in assemblies)
				{
					string value = null;
					try
					{
						value = assembly2.Location;
					}
					catch (NotSupportedException)
					{
					}
					if (string.IsNullOrEmpty(value) && assembly2.FullName.Equals(text3, StringComparison.OrdinalIgnoreCase))
					{
						type = assembly2.GetType(text2);
						if (type != null)
						{
							break;
						}
					}
				}
			}
			if (type == null && text2.StartsWith(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564315001), StringComparison.Ordinal) && text2.Contains(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313907)))
			{
				try
				{
					Type[] types = Assembly.Load(text3).GetTypes();
					foreach (Type type2 in types)
					{
						if (type2.FullName == text2)
						{
							type = type2;
							break;
						}
					}
				}
				catch
				{
				}
			}
		}
		if (type == null)
		{
			throw new TypeLoadException(string.Format(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564314947), text));
		}
		if (_0023_003DqPjU0as5GIhLtc26yxRodCiKMERUKL9IxtNScNVINKZc_003D2._0023_003DzObHTvKyY2hBlP57mHwH_0024RA_gfruA())
		{
			if (_0023_003DqPjU0as5GIhLtc26yxRodCiKMERUKL9IxtNScNVINKZc_003D2._0023_003DzvTrMnwYZXxJb_0024_eF_0024lfOUDQTE6mp().Length != 0)
			{
				Type[] array = new Type[_0023_003DqPjU0as5GIhLtc26yxRodCiKMERUKL9IxtNScNVINKZc_003D2._0023_003DzvTrMnwYZXxJb_0024_eF_0024lfOUDQTE6mp().Length];
				for (int j = 0; j < _0023_003DqPjU0as5GIhLtc26yxRodCiKMERUKL9IxtNScNVINKZc_003D2._0023_003DzvTrMnwYZXxJb_0024_eF_0024lfOUDQTE6mp().Length; j++)
				{
					array[j] = _0023_003Dz9_Z5EhGFT4yzpTmOPYjfhZOeNABFeUtCmZ_KeWA_003D(_0023_003DqPjU0as5GIhLtc26yxRodCiKMERUKL9IxtNScNVINKZc_003D2._0023_003DzvTrMnwYZXxJb_0024_eF_0024lfOUDQTE6mp()[j]._0023_003DztkhwzVeVIldXjs1hyonqsqcuOAEF(), _0023_003DzzKDx05I_003D);
				}
				Type genericTypeDefinition = _0023_003DqqSQMR5x0Ss3kUZAkPHTc7q6IdaUzR_0024BTopvbTI_0024P7DA_003D._0023_003DzBQnheHq2yWDGzMNL_0024_0024wd0lfnrJLT1XLAlY7MroqHd2xZ(type).GetGenericTypeDefinition();
				Stack<_0023_003DqZ8xUF8j1H1xe23Bhq6AA_00245uetOX5am41AHr7lae5URI_003D> stack2 = _0023_003DqqSQMR5x0Ss3kUZAkPHTc7q6IdaUzR_0024BTopvbTI_0024P7DA_003D._0023_003DzEfO7vrWUGY0J6tAcq4pxPpA_003D(type);
				type = genericTypeDefinition.MakeGenericType(array);
				type = _0023_003DqqSQMR5x0Ss3kUZAkPHTc7q6IdaUzR_0024BTopvbTI_0024P7DA_003D._0023_003DzPt2e8Z0FmuRfy6_0024e86fqym0_003D(type, stack2);
			}
			_0023_003Dztgqm2r4_003D = false;
		}
		return type;
	}

	private static void _0023_003DzbWe4366eOxrA0bbTqmv_0024_Di_MCSwOXNx4zmyTtfakPL_0024(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzLMJxSSXveUKWgX7ByprFEtw_003D(_0023_003DqqSQMR5x0Ss3kUZAkPHTc7q6IdaUzR_0024BTopvbTI_0024P7DA_003D._0023_003Dz9jrlnWk_003D);
	}

	private void _0023_003Dza4nGArD8ohAiv3Oef3SUUBiljhSza0DBmw_003D_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dz9jrlnWk_003D)
	{
		if (((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzrQFXD5oP9hinX0g4gA_003D_003D())._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D() != 0)
		{
			this.m__0023_003Dz9jrlnWk_003D.Push(new _0023_003Dz3iPku7s_003D(_0023_003DzMP6kxrk_003D, _0023_003DzNl32EAo_003D));
			this.m__0023_003Dz2X8kE24_003D = false;
		}
		_0023_003DzTSnMxIcnPTKi_0024SHfx9IetV0mvE0F();
	}

	private static void _0023_003DzTz1yXaiHnzIOx6D5iMKuiKE6b6WH(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzpclEbtZt0t_0024JhkHFJukZPrU_003D(_0023_003DzBxpHhQ0_003D);
	}

	private static void _0023_003DzFTsAWFTH_0024vMNGxqtALbChLntmZHX(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		double num = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() switch
		{
			1 => (uint)((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D(), 
			13 => (ulong)((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG(), 
			19 => Convert.ToUInt64(((_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D()), 
			_ => throw new InvalidOperationException(), 
		};
		_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D obj = new _0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D();
		obj._0023_003DzBGdDQOw_INWgxm_K091ViE8d5B7H7_X_0024gA2NQZA_003D(num);
		_0023_003Dz9jrlnWk_003D._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(obj);
	}

	public static object _0023_003DzW_0024Lnk2nu331k049aW0j9JP6ILlHXsAn69XlYchQ_003D(Type _0023_003Dz9jrlnWk_003D)
	{
		if (_0023_003Dz9jrlnWk_003D.IsValueType)
		{
			return Activator.CreateInstance(_0023_003Dz9jrlnWk_003D);
		}
		return null;
	}

	private static void _0023_003DzqW2g8O66zkTqihFfgcElTGm2TBGD(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DztKL1iK5LvFaLq_0024Salhy_v0MVryh8FAXmFefkbvo_003D();
	}

	private _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D[] _0023_003DzRyEZD1c9faTP_0024PxBM_mIybsxsfhDsqr5J9hMFWM_003D(object[] _0023_003Dz9jrlnWk_003D)
	{
		_0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024h3HXCPh1byVa5xQgwlyKcE_003D[] array = m__0023_003DzaTyQZ6E_003D._0023_003DzPFkh31N3VRlmNc8nf2IWmYdUiYAF();
		int num = array.Length;
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D[] array2 = new _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D[num];
		for (int i = 0; i < num; i++)
		{
			object obj = _0023_003Dz9jrlnWk_003D[i];
			Type type = _0023_003Dz9_Z5EhGFT4yzpTmOPYjfhZOeNABFeUtCmZ_KeWA_003D(array[i]._0023_003DzBLbiSG4pMsCq5QXcv4IAsSJsqlAkD0L7ST9ge5Ogka39(), _0023_003DzBxpHhQ0_003D: false);
			Type type2 = null;
			Type type3 = _0023_003DqqSQMR5x0Ss3kUZAkPHTc7q6IdaUzR_0024BTopvbTI_0024P7DA_003D._0023_003Dzi2h2vB8x9Msv3JnhJlPk451cZMzb(type);
			type2 = ((!(type3 == _0023_003DqqSQMR5x0Ss3kUZAkPHTc7q6IdaUzR_0024BTopvbTI_0024P7DA_003D._0023_003Dz9jrlnWk_003D) && !_0023_003DqqSQMR5x0Ss3kUZAkPHTc7q6IdaUzR_0024BTopvbTI_0024P7DA_003D._0023_003Dzt6IW3o7Q3_0024kDG1z4CqtvMH1iuswjFBlVqVIQyrQ_003D(type3)) ? ((obj != null) ? obj.GetType() : type) : type);
			if (obj != null && !type.IsAssignableFrom(type2) && type.IsByRef && !type.GetElementType().IsAssignableFrom(type2))
			{
				throw new ArgumentException(string.Format(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564315092), type2, type));
			}
			array2[i] = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D._0023_003DzCysyOfnrUQB5WqShWAIL_0024X4XGCe9eW67eVeg6HY_003D(obj, type2);
		}
		if (!m__0023_003DzaTyQZ6E_003D._0023_003DzKttHpAQ_gTjjjLgkDh9KnFaqusae() && _0023_003Dz9_Z5EhGFT4yzpTmOPYjfhZOeNABFeUtCmZ_KeWA_003D(m__0023_003DzaTyQZ6E_003D._0023_003DzUaXoJXQwrrbCr0Kl7wUIRwaCDGvQifXoCg_003D_003D(), _0023_003DzBxpHhQ0_003D: false).IsValueType)
		{
			_0023_003DqFNN_kH3_Aic_0024vq9s6N7BcnqdUOw1mJpa1yIMZD1vbOQ_003D obj2 = new _0023_003DqFNN_kH3_Aic_0024vq9s6N7BcnqdUOw1mJpa1yIMZD1vbOQ_003D();
			obj2._0023_003DzlpaqC69eD5UfV5QZE9NijsO7MeQh(array2[0]);
			array2[0] = obj2;
		}
		for (int j = 0; j < num; j++)
		{
			if (array[j]._0023_003DzChnAIIUM6aZbWvxSX_9gOLnhG0Pj0ORlLw_003D_003D())
			{
				int num2 = j;
				_0023_003DqFNN_kH3_Aic_0024vq9s6N7BcnqdUOw1mJpa1yIMZD1vbOQ_003D obj3 = new _0023_003DqFNN_kH3_Aic_0024vq9s6N7BcnqdUOw1mJpa1yIMZD1vbOQ_003D();
				obj3._0023_003DzlpaqC69eD5UfV5QZE9NijsO7MeQh(array2[j]);
				array2[num2] = obj3;
			}
		}
		return array2;
	}

	private static bool _0023_003DzMUztG58r9K8EH6LstV9cRZc_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		bool result = false;
		switch (_0023_003Dz9jrlnWk_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D())
		{
		case 1:
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 19)
			{
				return _0023_003DzMUztG58r9K8EH6LstV9cRZc_003D(_0023_003Dz9jrlnWk_003D, new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(Convert.ToInt32(((_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D())));
			}
			result = (uint)((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D() < (uint)((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
			break;
		case 13:
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 19)
			{
				return _0023_003DzMUztG58r9K8EH6LstV9cRZc_003D(_0023_003Dz9jrlnWk_003D, new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(Convert.ToInt64(((_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D())));
			}
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 1)
			{
				return _0023_003DzMUztG58r9K8EH6LstV9cRZc_003D(_0023_003Dz9jrlnWk_003D, new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D()));
			}
			result = (ulong)((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG() < (ulong)((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG();
			break;
		case 19:
			return _0023_003DzMUztG58r9K8EH6LstV9cRZc_003D(new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(Convert.ToInt64(((_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D())), _0023_003DzBxpHhQ0_003D);
		case 8:
		{
			double num = ((_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzCfXuHVIlFp1X1u2Med2_AL4lzej8EifTBw_003D_003D();
			double num2 = ((_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzCfXuHVIlFp1X1u2Med2_AL4lzej8EifTBw_003D_003D();
			result = num < num2 || double.IsNaN(num) || double.IsNaN(num2);
			break;
		}
		}
		return result;
	}

	private static void _0023_003DzSd3STdmxORE9rSm9dFFiGLg_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzLMJxSSXveUKWgX7ByprFEtw_003D(typeof(int));
	}

	private static void _0023_003Dz4ROExqE_0024CCOgBLNvFKe4Ulo8p2lt(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D obj = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		if (obj._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() != 1)
		{
			throw new InvalidOperationException();
		}
		int num = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)obj)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
		Stack<_0023_003DzbSmUaeo_003D> stack = _0023_003Dz9jrlnWk_003D._0023_003DzFbIBOUZukUTRt6X7TpE_uAdTdeMf();
		if (stack.Count < 2)
		{
			throw new InvalidOperationException();
		}
		using _0023_003DzbSmUaeo_003D _0023_003DzbSmUaeo_003D2 = stack.Pop();
		if (_0023_003DzbSmUaeo_003D2 == null || _0023_003DzbSmUaeo_003D2._0023_003Dz9jrlnWk_003D._0023_003DzK_Jiocf2MUlKFQb4sVmAMIu57J8HGmj0ja2VBmAzqChCH5gQJ3yPpxphLmNSj91NUXmFCpVeDpos() != num)
		{
			throw new InvalidOperationException();
		}
		_0023_003DzbSmUaeo_003D _0023_003DzbSmUaeo_003D3 = stack.Peek();
		_0023_003Dz9jrlnWk_003D._0023_003DzbubspJfKxb0WjXbENdWdGRpLC4D3_0024Y9wrJukd1A_003D(_0023_003DzbSmUaeo_003D3);
		_0023_003Dz9jrlnWk_003D._0023_003DzMP6kxrk_003D += (uint)_0023_003DzbSmUaeo_003D2._0023_003Dz9jrlnWk_003D._0023_003Dz_0024B4ZWC6pK66TUVOsiQ_003D_003D();
		_0023_003Dz9jrlnWk_003D._0023_003Dz3BejEhUi_0024bSfiEeI8cmkKdw_003D(_0023_003Dz9jrlnWk_003D._0023_003DzMP6kxrk_003D);
	}

	private static void _0023_003DzfNFPgYYaTiwOCJmQcS1fDC9F9nY7C2A_0024mkG5Oqo_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003Dzy4D_00248buHMHsvaKDXIg_003D_003D(8);
	}

	private _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzPHrDnw60J5aEG99fBkRHNDGKynpNve4GtVsNHlw_003D(_0023_003DqSrxlws3SuprWxrjyHO1juxJFrTNvlF8gj_KAkF067yA_003D _0023_003Dz9jrlnWk_003D, byte _0023_003DzBxpHhQ0_003D)
	{
		switch (_0023_003DzBxpHhQ0_003D)
		{
		case 11:
			return null;
		case 0:
		{
			_0023_003DzMP6kxrk_003D++;
			_0023_003Dq_00249gqa_00242OaFZvUQ9SB2xbDMp_0024CYfNzncySoGOXE8Ah9U_003D obj2 = new _0023_003Dq_00249gqa_00242OaFZvUQ9SB2xbDMp_0024CYfNzncySoGOXE8Ah9U_003D();
			obj2._0023_003DzWK8DquL2uOVBADnLG3ni7C4_003D(_0023_003Dz9jrlnWk_003D._0023_003DzAR22HP52FDbZdoGnhOF9tck_003D());
			return obj2;
		}
		case 2:
		case 6:
			_0023_003DzMP6kxrk_003D += 4u;
			return new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(_0023_003Dz9jrlnWk_003D._0023_003DzzWp83NqubJCg0KBvRVdJ1Clh9XOWlHor0w_003D_003D());
		case 10:
			_0023_003DzMP6kxrk_003D += 8u;
			return new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(_0023_003Dz9jrlnWk_003D._0023_003Dz1RtBg1_0024Sse5482v8asVTTPvqL0oBixer7Dch_d3qXLja());
		case 3:
		case 7:
		{
			_0023_003DzMP6kxrk_003D++;
			_0023_003DqIC7wdNmeVLrKuHjiCL8jtht_0024ogaMGYTl_vFxiqwcERQ_003D obj7 = new _0023_003DqIC7wdNmeVLrKuHjiCL8jtht_0024ogaMGYTl_vFxiqwcERQ_003D();
			obj7._0023_003Dz7nZBNEHgWTBGg14SzlTP1uAtXCWK(_0023_003Dz9jrlnWk_003D._0023_003Dz2DBTqfW51eVHX_0024PiHey2kryLbqPoOZPrpMXUAwQ_003D());
			return obj7;
		}
		case 5:
		case 12:
		{
			_0023_003DzMP6kxrk_003D += 2u;
			_0023_003DqJFdrGiwz1aJICVkSTb_0024Zkh7zAYa9iZm47EqlnjrFUg4_003D obj6 = new _0023_003DqJFdrGiwz1aJICVkSTb_0024Zkh7zAYa9iZm47EqlnjrFUg4_003D();
			obj6._0023_003DzsQI9nRUPomm3Zpd_0024XA_003D_003D(_0023_003Dz9jrlnWk_003D._0023_003Dz1zMApy2OI0rrWse6_0024UUktlSLP2iUmcLUkpFNZ5lylbxv());
			return obj6;
		}
		case 4:
		{
			_0023_003DzMP6kxrk_003D += 4u;
			_0023_003Dq0srKRFBAoKYa1j6vwUtjLsgVLItE_0024pYpGRcCpdIANF0_003D obj5 = new _0023_003Dq0srKRFBAoKYa1j6vwUtjLsgVLItE_0024pYpGRcCpdIANF0_003D();
			obj5._0023_003Dz9cq23OmbL_dxMoXrfl9YeW80S7sF5VpNYQ_003D_003D(_0023_003Dz9jrlnWk_003D._0023_003DziB0CWaH99iC_0024loCVaOciPifQ5ShPLxAqDHJv5q1KXBjq());
			return obj5;
		}
		case 8:
		{
			_0023_003DzMP6kxrk_003D += 8u;
			_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D obj4 = new _0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D();
			obj4._0023_003DzBGdDQOw_INWgxm_K091ViE8d5B7H7_X_0024gA2NQZA_003D(_0023_003Dz9jrlnWk_003D._0023_003DzHvok0YbFZwLvuWkx5ZfQ_0024EkmAXuc());
			return obj4;
		}
		case 1:
		{
			_0023_003DzMP6kxrk_003D += 4u;
			_0023_003DqJFdrGiwz1aJICVkSTb_0024Zko9aS6iSwDcZdo9VS4Dkh_0024s_003D obj3 = new _0023_003DqJFdrGiwz1aJICVkSTb_0024Zko9aS6iSwDcZdo9VS4Dkh_0024s_003D();
			obj3._0023_003Dzv_0024cKsTmdNUiR7R4bvWgZb3E_003D(_0023_003Dz9jrlnWk_003D._0023_003Dz6ZCFHacYN7DiGCTOLVcLt1ROT7gcyKHf_0024OLcW_0_003D());
			return obj3;
		}
		case 9:
		{
			int num = _0023_003Dz9jrlnWk_003D._0023_003DzzWp83NqubJCg0KBvRVdJ1Clh9XOWlHor0w_003D_003D();
			_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D[] array = new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(_0023_003Dz9jrlnWk_003D._0023_003DzzWp83NqubJCg0KBvRVdJ1Clh9XOWlHor0w_003D_003D());
			}
			_0023_003DzMP6kxrk_003D += (uint)((num + 1) * 4);
			_0023_003DqJK_4DNDu0bpSDsm8DAlJ97YodsmbnVu7wOTilEHAt2g_003D obj = new _0023_003DqJK_4DNDu0bpSDsm8DAlJ97YodsmbnVu7wOTilEHAt2g_003D();
			obj._0023_003Dzt_0024bTK2Fil3XWqMOVKJBmnX_0024psQCLTyoahp9FMe4_003D(array);
			return obj;
		}
		default:
			throw new Exception(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564315297));
		}
	}

	private static void _0023_003DzEHNc6ku_00248fFZWhgR8d0xOe4_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzpU_n7PfnyRyJ1anIgJrsjiSffFPi(2);
	}

	private static void _0023_003DzIXvhHjXrOk7HeFOYn9Beh0KH7nHz(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzzTvE7jftOU_0024XBv6lbA_003D_003D(_0023_003Dz9jrlnWk_003D: true);
	}

	private int _0023_003Dz2C_0024Vv1MraUAp7j_LFzKRCN2Jpwzg()
	{
		return 1447513948;
	}

	private void _0023_003DzwbI83bfoaDmYaZBDzj4leqo_003D(int _0023_003Dz9jrlnWk_003D)
	{
		_0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(_0023_003DzWn08U5s_003D[_0023_003Dz9jrlnWk_003D]._0023_003DzRqSyVpZK2TBKK9sY8BRsK_LOAo2IOUGsrjpuWUR4KGpBSNkJ3BhBNhxCFhqGPqZG8Y5jLLY_m3gD());
	}

	private bool _0023_003Dz1MV5OPCzVE_0024wxwQZ4aZ07_0_003D(Type _0023_003Dz9jrlnWk_003D, _0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D _0023_003DzBxpHhQ0_003D, out int _0023_003Dztgqm2r4_003D)
	{
		_0023_003Dztgqm2r4_003D = 0;
		_0023_003DqPjU0as5GIhLtc26yxRodCiKMERUKL9IxtNScNVINKZc_003D _0023_003DqPjU0as5GIhLtc26yxRodCiKMERUKL9IxtNScNVINKZc_003D2 = (_0023_003DqPjU0as5GIhLtc26yxRodCiKMERUKL9IxtNScNVINKZc_003D)_0023_003DzBxpHhQ0_003D._0023_003DzMDpHhtfRNQDKXWsFcSVSbdd3Ewg6();
		if (_0023_003DqqSQMR5x0Ss3kUZAkPHTc7q6IdaUzR_0024BTopvbTI_0024P7DA_003D._0023_003DzBQnheHq2yWDGzMNL_0024_0024wd0lfnrJLT1XLAlY7MroqHd2xZ(_0023_003Dz9jrlnWk_003D).IsGenericParameter)
		{
			if (_0023_003DqPjU0as5GIhLtc26yxRodCiKMERUKL9IxtNScNVINKZc_003D2 != null && !_0023_003DqPjU0as5GIhLtc26yxRodCiKMERUKL9IxtNScNVINKZc_003D2._0023_003DzIsjHzdcuzGdSqor3vgD1SoE_003D())
			{
				return false;
			}
			return true;
		}
		Type type = _0023_003Dz9_Z5EhGFT4yzpTmOPYjfhZOeNABFeUtCmZ_KeWA_003D(_0023_003DzBxpHhQ0_003D._0023_003DztkhwzVeVIldXjs1hyonqsqcuOAEF(), _0023_003DzBxpHhQ0_003D: false);
		if (!_0023_003DqRfaUN25F_BqlwRMpZvaCa09DuNT8ejEH0U_tA2Pbc1Y_003D._0023_003DzKhkB9_0024rX28FSnG8KONbzBBSPB2ZO(_0023_003Dz9jrlnWk_003D, type, out _0023_003Dztgqm2r4_003D))
		{
			return false;
		}
		return true;
	}

	private static void _0023_003DzSEbd33BmNTCL1Ftx3Na_00247fARgW7R(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003Dz6SiV_B3RvFCLEeKqYpPV_0024wVhgzqa(_0023_003Dz9jrlnWk_003D: true, _0023_003DzBxpHhQ0_003D: false);
	}

	private static string _0023_003DzD69sXm7cB8YG4UIz48VVGKMyN5FSSLzspMkf4r0_003D(string _0023_003Dz9jrlnWk_003D, string _0023_003DzBxpHhQ0_003D)
	{
		string fullName = typeof(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D).Assembly.FullName;
		return _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313824) + _0023_003Dz9jrlnWk_003D + _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313806) + _0023_003DzBxpHhQ0_003D + _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313660) + Environment.NewLine + Environment.NewLine + _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313645) + fullName + _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313628);
	}

	private void _0023_003DznvlgEOPraWZmqD5ceLuYFnVSbntYJqpYPE8kmaw_003D(bool _0023_003Dz9jrlnWk_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3 = _0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		_0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(_0023_003Dzr0yXc9pJwMobF4pCiw6aD7c42mVpHuMqcQ_003D_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2, _0023_003Dz9jrlnWk_003D));
	}

	[_0023_003DqVFAcyYKahdwaFZMP0V7msjS_787Nv39REvMycxmXGBM_003D(2)]
	private bool _0023_003Dz2beHmJ0exrgLlf2VcUt4H98_003D([_0023_003Dq9o_OPfa_DuRpdjQlVA0aimj5lmMpAXSbykDZsxdP0k4_003D(1)] MethodBase _0023_003Dz9jrlnWk_003D, object _0023_003DzBxpHhQ0_003D, ref object _0023_003Dztgqm2r4_003D, [_0023_003Dq9o_OPfa_DuRpdjQlVA0aimj5lmMpAXSbykDZsxdP0k4_003D(new byte[] { 1, 2 })] object[] _0023_003DzzKDx05I_003D)
	{
		if (!_0023_003Dz9jrlnWk_003D.IsStatic && _0023_003DzBxpHhQ0_003D != null && _0023_003Dz9jrlnWk_003D.Name.Equals(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564314830), StringComparison.Ordinal) && _0023_003Dz9jrlnWk_003D is MethodInfo { ReturnType: var returnType } && returnType.IsByRef)
		{
			Type elementType = returnType.GetElementType();
			int num = _0023_003DzzKDx05I_003D.Length;
			if (num >= 1 && _0023_003DzzKDx05I_003D[0] is int)
			{
				int[] array = new int[num];
				for (int i = 0; i < num; i++)
				{
					array[i] = (int)_0023_003DzzKDx05I_003D[i];
				}
				_0023_003DqqSQMR5x0Ss3kUZAkPHTc7rzIwn1QLnTI1rWWf9uCkeM_003D obj = new _0023_003DqqSQMR5x0Ss3kUZAkPHTc7rzIwn1QLnTI1rWWf9uCkeM_003D();
				obj._0023_003DzjTUn7avvHCjoQyr2BPs_cBLRvPdjo9XU6Fvm_0024bMN2v7J((Array)_0023_003DzBxpHhQ0_003D);
				obj._0023_003DzIUGxpgxh17m6HAZmG0sZRkesQyM256eWSw_003D_003D(array);
				obj._0023_003Dz_0024WOmwPiJ7UFMYHpG_kOLOeBLqKyQ(elementType);
				_0023_003Dztgqm2r4_003D = obj;
				return true;
			}
		}
		return false;
	}

	private static void _0023_003DzYgLlyYl3aWGU1mwb2DBmpDs2_LEKHZQsnA_003D_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
	}

	private static void _0023_003Dz6vOPuVEcKpcRckSiij58VS4_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3 = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		_0023_003Dz9jrlnWk_003D._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(_0023_003DzbIhMMCpTAtqwcE7EXAzYf_SJEcWXsuXv_0024Q_003D_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2) ? 1 : 0));
	}

	private void _0023_003DzQQadI1un9jbZYMS7HdWcDB_Om0ngXN8ke3zjToc_003D(int _0023_003Dz9jrlnWk_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		_0023_003DzWn08U5s_003D[_0023_003Dz9jrlnWk_003D]._0023_003DzAPlrN6aYwAg5F1LxHYbv_0024wOBB_0024afgbz6XKGgvF_0024QaP3F7Nvwy8DGE80Q1m63nNv21_00240QxzxHCeC2PtE3mw_003D_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2);
	}

	private static void _0023_003DzIM1DohyJsoJC_oySig79wlcqu77vGjLlndSeC6Ib0jZd(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		int num = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
		Type type = _0023_003Dz9jrlnWk_003D._0023_003Dz9_Z5EhGFT4yzpTmOPYjfhZOeNABFeUtCmZ_KeWA_003D(num, _0023_003DzBxpHhQ0_003D: true);
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D._0023_003DzCysyOfnrUQB5WqShWAIL_0024X4XGCe9eW67eVeg6HY_003D(_0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D()._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D(), type);
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzsZLDUvjyYZRtLY91huCrFGofhAyP(type);
		_0023_003Dz9jrlnWk_003D._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2);
	}

	private static void _0023_003Dzb0ZiaALF_0024ndFccRYAiZhMnunPLF4zFoyLy7ZSZYvgWC5(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		int num = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
		FieldInfo fieldInfo = _0023_003Dz9jrlnWk_003D._0023_003DzxFlP9j6hwChqbnCQxNoxN7LJpAh_00242zp2XpETVEHUh_9i(num);
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D obj = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		_0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D _0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D2 = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 as _0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D;
		object obj2 = ((_0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D2 == null) ? _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D() : _0023_003Dz9jrlnWk_003D._0023_003DzcyfMbnJemFaR1U9IYqWp0cPmk80NlqUX5LErUtBcWaeU(_0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D2)._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D());
		if (obj2 == null)
		{
			throw new NullReferenceException();
		}
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3 = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D._0023_003DzCysyOfnrUQB5WqShWAIL_0024X4XGCe9eW67eVeg6HY_003D(obj._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D(), fieldInfo.FieldType);
		fieldInfo.SetValue(obj2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D());
		if (_0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D2 != null && obj2 != null && obj2.GetType().IsValueType)
		{
			_0023_003Dz9jrlnWk_003D._0023_003DzlLFsRbFCVJXLxNmd_0024gDP8S8_003D(_0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D2, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D._0023_003DzCysyOfnrUQB5WqShWAIL_0024X4XGCe9eW67eVeg6HY_003D(obj2, null));
		}
	}

	private static Exception _0023_003DzfJ4aXO0pOe8J43PKGg89NbhMUmmqNtMeSwNp5tc_003D(string _0023_003Dz9jrlnWk_003D, string _0023_003DzBxpHhQ0_003D)
	{
		return new FieldAccessException(_0023_003DzD69sXm7cB8YG4UIz48VVGKMyN5FSSLzspMkf4r0_003D(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313967) + _0023_003Dz9jrlnWk_003D + _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313931), _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564315146) + _0023_003DzBxpHhQ0_003D + _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313931)));
	}

	private static void _0023_003DzVGWBusHVoszT9gLQJiAnjYc_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		int num = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
		FieldInfo fieldInfo = _0023_003Dz9jrlnWk_003D._0023_003DzxFlP9j6hwChqbnCQxNoxN7LJpAh_00242zp2XpETVEHUh_9i(num);
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D._0023_003DzCysyOfnrUQB5WqShWAIL_0024X4XGCe9eW67eVeg6HY_003D(_0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D()._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D(), fieldInfo.FieldType);
		fieldInfo.SetValue(null, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D());
	}

	private static void _0023_003DzSWPlIsg4IsOZSF_00245Ovh3pm8Yln84(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		object obj = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D()._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D();
		long num = _0023_003Dz9jrlnWk_003D._0023_003Dz48d1zHJh3TOQKfAMFYN6p1CRbnL4();
		Array array = (Array)_0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D()._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D();
		Type elementType = array.GetType().GetElementType();
		if (elementType == typeof(int))
		{
			_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D._0023_003DzCysyOfnrUQB5WqShWAIL_0024X4XGCe9eW67eVeg6HY_003D(obj, typeof(int));
			((int[])array)[num] = (int)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D();
		}
		else if (elementType == typeof(uint))
		{
			_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3 = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D._0023_003DzCysyOfnrUQB5WqShWAIL_0024X4XGCe9eW67eVeg6HY_003D(obj, typeof(uint));
			((uint[])array)[num] = (uint)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D();
		}
		else if (elementType.IsEnum)
		{
			_0023_003Dz9jrlnWk_003D._0023_003DzlUMFttjizmrsnJvpILZOQbCJdq_9(elementType, obj, num, array);
		}
		else
		{
			_0023_003Dz9jrlnWk_003D._0023_003DzlUMFttjizmrsnJvpILZOQbCJdq_9(typeof(int), obj, num, array);
		}
	}

	private void _0023_003DzlUMFttjizmrsnJvpILZOQbCJdq_9(Type _0023_003Dz9jrlnWk_003D, object _0023_003DzBxpHhQ0_003D, long _0023_003Dztgqm2r4_003D, Array _0023_003DzzKDx05I_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D._0023_003DzCysyOfnrUQB5WqShWAIL_0024X4XGCe9eW67eVeg6HY_003D(_0023_003DzBxpHhQ0_003D, _0023_003Dz9jrlnWk_003D);
		_0023_003DzzKDx05I_003D.SetValue(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D(), _0023_003Dztgqm2r4_003D);
	}

	private void _0023_003Dzy9SLKdQoCebcVxNgldItljkdsD8_0024(bool _0023_003Dz9jrlnWk_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		_0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() switch
		{
			1 => (!_0023_003Dz9jrlnWk_003D) ? ((ushort)((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D()) : checked((ushort)(uint)((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D()), 
			13 => (!_0023_003Dz9jrlnWk_003D) ? ((ushort)((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG()) : checked((ushort)(ulong)((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG()), 
			19 => (!_0023_003Dz9jrlnWk_003D) ? ((ushort)Convert.ToUInt64(((_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D())) : checked((ushort)Convert.ToUInt64(((_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D())), 
			8 => (!_0023_003Dz9jrlnWk_003D) ? ((ushort)((_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzCfXuHVIlFp1X1u2Med2_AL4lzej8EifTBw_003D_003D()) : checked((ushort)((_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzCfXuHVIlFp1X1u2Med2_AL4lzej8EifTBw_003D_003D()), 
			0 => (IntPtr.Size != 4) ? ((!_0023_003Dz9jrlnWk_003D) ? ((ushort)(long)((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk()) : checked((ushort)(ulong)(long)((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk())) : ((!_0023_003Dz9jrlnWk_003D) ? ((ushort)(int)((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk()) : checked((ushort)(int)((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk())), 
			20 => (UIntPtr.Size != 4) ? ((!_0023_003Dz9jrlnWk_003D) ? ((ushort)(ulong)((_0023_003DqVEj3J19zkgEyU6VFymBz6riyi6CxZMJEjhA0KZ2nLKw_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzZlwwYywinAe9h_2ss_0024Wn4RsajDr79HfGCg_003D_003D()) : checked((ushort)(ulong)((_0023_003DqVEj3J19zkgEyU6VFymBz6riyi6CxZMJEjhA0KZ2nLKw_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzZlwwYywinAe9h_2ss_0024Wn4RsajDr79HfGCg_003D_003D())) : ((!_0023_003Dz9jrlnWk_003D) ? ((ushort)(uint)((_0023_003DqVEj3J19zkgEyU6VFymBz6riyi6CxZMJEjhA0KZ2nLKw_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzZlwwYywinAe9h_2ss_0024Wn4RsajDr79HfGCg_003D_003D()) : checked((ushort)(uint)((_0023_003DqVEj3J19zkgEyU6VFymBz6riyi6CxZMJEjhA0KZ2nLKw_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzZlwwYywinAe9h_2ss_0024Wn4RsajDr79HfGCg_003D_003D())), 
			_ => throw new InvalidOperationException(), 
		}));
	}

	private static void _0023_003DzcGWq4QF1rySHzpm3QNRqgCcM8mQCcRGoAKY8IQyuzUxJ(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(_0023_003DzBxpHhQ0_003D);
	}

	private _0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024h3HXCPh1byVa5xQgwlyKcE_003D[] _0023_003DzXWifrZKVm_0024wIfJPkPBs2Lm1_0024fd5_0024bF8_0024xwNhGPwY1HV7(_0023_003DqSrxlws3SuprWxrjyHO1juxJFrTNvlF8gj_KAkF067yA_003D _0023_003Dz9jrlnWk_003D)
	{
		_0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024h3HXCPh1byVa5xQgwlyKcE_003D[] array = new _0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024h3HXCPh1byVa5xQgwlyKcE_003D[_0023_003Dz9jrlnWk_003D._0023_003DzfyBJnRlgDbP3pAMbTWEdJKI_003D()];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = _0023_003DzMyKC5Rx1kInz2yr8VRvXyDtUtIYtBpKLiQ_003D_003D(_0023_003Dz9jrlnWk_003D);
		}
		return array;
	}

	private static void _0023_003DzbRlOgmypJ6g_0024pv852RCFulk2bNztklB9hyiN5bs_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		bool flag = false;
		if (_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() switch
		{
			1 => ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D() != 0, 
			13 => ((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG() != 0, 
			0 => ((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk() != IntPtr.Zero, 
			20 => ((_0023_003DqVEj3J19zkgEyU6VFymBz6riyi6CxZMJEjhA0KZ2nLKw_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzZlwwYywinAe9h_2ss_0024Wn4RsajDr79HfGCg_003D_003D() != UIntPtr.Zero, 
			19 => Convert.ToBoolean(((_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D()), 
			7 => ((_0023_003DqcjmfsaS6dKPuf2kSTqJKWfH_rgkc03gEAn6QEKAtpbA_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzKuvp4FpGZEHp_0024htPxx_00248SXawDH8Tdf_0Y48dwaP_bCrZ() != null, 
			_ => _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D() != null, 
		})
		{
			uint num = ((_0023_003DqJFdrGiwz1aJICVkSTb_0024Zko9aS6iSwDcZdo9VS4Dkh_0024s_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzxGjrL4iuhvogLPGFSdnVXdPvbKxem9P4HA_003D_003D();
			_0023_003Dz9jrlnWk_003D._0023_003Dz9r__0024YTGu_0024iN2qFjqe6k1t7s_003D(num);
		}
	}

	private _0023_003DqaEtT9DoRRoUP_0024LS5u4B6AojK4YaTqiLM3Vc605IaRGE_003D _0023_003DzDwre1ZXjPmbPlE2pCbnX_0024wo_003D(_0023_003DqSrxlws3SuprWxrjyHO1juxJFrTNvlF8gj_KAkF067yA_003D _0023_003Dz9jrlnWk_003D)
	{
		_0023_003DqaEtT9DoRRoUP_0024LS5u4B6AojK4YaTqiLM3Vc605IaRGE_003D obj = new _0023_003DqaEtT9DoRRoUP_0024LS5u4B6AojK4YaTqiLM3Vc605IaRGE_003D();
		obj._0023_003DzWxsGfXsW4_aO_0024_rOCtI8rejtorUIOKGJM8s1Jac_003D(_0023_003DzXWifrZKVm_0024wIfJPkPBs2Lm1_0024fd5_0024bF8_0024xwNhGPwY1HV7(_0023_003Dz9jrlnWk_003D));
		obj._0023_003DzKcuUc21Bh6duCuDIVGn_mx4MgQes(_0023_003DzMpJnKU_48c6gOC8H7yb0Yy5Ce7nYYH3xpCbdHeM_003D(_0023_003Dz9jrlnWk_003D));
		obj._0023_003Dzd4DR49EEcFNETH8h__KNT5U_003D(_0023_003Dz9jrlnWk_003D._0023_003DzzWp83NqubJCg0KBvRVdJ1Clh9XOWlHor0w_003D_003D());
		obj._0023_003DzXa7zBwsdRBHzfCVPd8CnfOTfL2dctrXN8S7EZRg_003D(_0023_003Dz9jrlnWk_003D._0023_003Dz2DBTqfW51eVHX_0024PiHey2kryLbqPoOZPrpMXUAwQ_003D());
		obj._0023_003DzlDQAx4KTBqh86uhYpubngjzEOoOvIlecX__0024xU94_003D(_0023_003Dz9jrlnWk_003D._0023_003DzzWp83NqubJCg0KBvRVdJ1Clh9XOWlHor0w_003D_003D());
		obj._0023_003DzYd7Ior_ducCrOxIZHD0D5pq_0024UGG0(_0023_003Dz9jrlnWk_003D._0023_003DzYwSkP_0024AT_4cNB1WKv1Bn_0024U2fDpNoCLCIgZMBDZU_003D());
		return obj;
	}

	private static void _0023_003DzVWnKEQNiUE5wCpzACttKsUDkEeziV9xrew_003D_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003Dzl01rdMbhKWqXEDpjHctwRZgIgliJDTg7bQ_003D_003D(((_0023_003DqIC7wdNmeVLrKuHjiCL8jtht_0024ogaMGYTl_vFxiqwcERQ_003D)_0023_003DzBxpHhQ0_003D)._0023_003Dz3fdyocpuocHKnMPBAP0IP10_003D());
	}

	private static void _0023_003DzkRzpfnw_0024bKgkWzi3uNIpNym5kwewPh5__g_003D_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		_0023_003Dz9jrlnWk_003D._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(_0023_003Dz9jrlnWk_003D._0023_003Dzuk7pFeGyjkSPMmddbHRfYsu48tCb(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2));
	}

	private static void _0023_003DzyILH5qEc1_42WwJvKJ2LSHNnFjLxkv_Ajw_003D_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		int num = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
		Type type = _0023_003Dz9jrlnWk_003D._0023_003Dz9_Z5EhGFT4yzpTmOPYjfhZOeNABFeUtCmZ_KeWA_003D(num, _0023_003DzBxpHhQ0_003D: true);
		_0023_003Dz9jrlnWk_003D._0023_003DzLMJxSSXveUKWgX7ByprFEtw_003D(type);
	}

	private void _0023_003DzleLKu58kbCcompJKcc4ctAk_003D()
	{
		if (m__0023_003DzaTyQZ6E_003D._0023_003DzKttHpAQ_gTjjjLgkDh9KnFaqusae())
		{
			Type type = _0023_003Dz9_Z5EhGFT4yzpTmOPYjfhZOeNABFeUtCmZ_KeWA_003D(m__0023_003DzaTyQZ6E_003D._0023_003DzUaXoJXQwrrbCr0Kl7wUIRwaCDGvQifXoCg_003D_003D(), _0023_003DzBxpHhQ0_003D: false);
			if (type != null)
			{
				RuntimeHelpers.RunClassConstructor(type.TypeHandle);
			}
		}
	}

	private static void _0023_003Dz6rOqji0u8x0FNTkY79wLXDg4UYDq(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DztKL1iK5LvFaLq_0024Salhy_v0MVryh8FAXmFefkbvo_003D();
	}

	private static void _0023_003DzgMqANIWBbv0AB51QsxGVn2_QkE4KzL4nng_003D_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		Thread.MemoryBarrier();
	}

	private static void _0023_003DzpsjmlV8CrT_0024HXfa3k4_ieHIF_0024xa3Wj8QBNlAKiU_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		object obj = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D()._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D();
		long num = _0023_003Dz9jrlnWk_003D._0023_003Dz48d1zHJh3TOQKfAMFYN6p1CRbnL4();
		Array array = (Array)_0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D()._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D();
		Type elementType = array.GetType().GetElementType();
		if (elementType == typeof(short))
		{
			_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D._0023_003DzCysyOfnrUQB5WqShWAIL_0024X4XGCe9eW67eVeg6HY_003D(obj, typeof(short));
			((short[])array)[num] = (short)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D();
		}
		else if (elementType == typeof(ushort))
		{
			_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3 = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D._0023_003DzCysyOfnrUQB5WqShWAIL_0024X4XGCe9eW67eVeg6HY_003D(obj, typeof(ushort));
			((ushort[])array)[num] = (ushort)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D();
		}
		else if (elementType == typeof(char))
		{
			_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D4 = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D._0023_003DzCysyOfnrUQB5WqShWAIL_0024X4XGCe9eW67eVeg6HY_003D(obj, typeof(char));
			((char[])array)[num] = (char)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D4._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D();
		}
		else if (elementType.IsEnum)
		{
			_0023_003Dz9jrlnWk_003D._0023_003DzlUMFttjizmrsnJvpILZOQbCJdq_9(elementType, obj, num, array);
		}
		else
		{
			_0023_003Dz9jrlnWk_003D._0023_003DzlUMFttjizmrsnJvpILZOQbCJdq_9(typeof(short), obj, num, array);
		}
	}

	private static void _0023_003Dzl4ET6O66nTPkaoTlB5CtG3YGYrH0Q5AC0A_003D_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(new _0023_003DqcjmfsaS6dKPuf2kSTqJKWfH_rgkc03gEAn6QEKAtpbA_003D());
	}

	private static void _0023_003Dz5XHiNCs0BAFvUNeNT1MVMc9vm9ZzYro7s95_0024hG8_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(_0023_003DzBxpHhQ0_003D);
	}

	private static void _0023_003DzFhIzjCbuc9Xt2uEh1LeHzcYFHhqqerBxtg_003D_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		int num = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
		FieldInfo fieldInfo = _0023_003Dz9jrlnWk_003D._0023_003DzxFlP9j6hwChqbnCQxNoxN7LJpAh_00242zp2XpETVEHUh_9i(num);
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		if (_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 is _0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D _0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D2)
		{
			_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dz9jrlnWk_003D._0023_003DzcyfMbnJemFaR1U9IYqWp0cPmk80NlqUX5LErUtBcWaeU(_0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D2);
		}
		object obj = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D();
		if (obj == null)
		{
			throw new NullReferenceException();
		}
		_0023_003Dz9jrlnWk_003D._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D._0023_003DzCysyOfnrUQB5WqShWAIL_0024X4XGCe9eW67eVeg6HY_003D(fieldInfo.GetValue(obj), fieldInfo.FieldType));
	}

	private static void _0023_003Dz7Lb3u8Wungrg1xqk9rvsAhJPDQRYNidOmQ_003D_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003Dz4aIsGrkxJXsni29jRFACK21EuSDR(_0023_003Dz9jrlnWk_003D: true, _0023_003DzBxpHhQ0_003D: false);
	}

	private void _0023_003DzRAdSm4DyRDmN2214hLLTypI_003D(bool _0023_003Dz9jrlnWk_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3 = _0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		_0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(_0023_003DzaOO3l1fve8hJTUNmqU1uOQt4IxMJysbh6sK1eeu_6FMJ(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2, _0023_003Dz9jrlnWk_003D));
	}

	private _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzKWldAQdJ09HXMZAyqMT0BMPufBy1QG1190JaTixk_Dee(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dz9jrlnWk_003D)
	{
		if (_0023_003Dz9jrlnWk_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 1)
		{
			int num = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
			_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D obj = new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D();
			obj._0023_003DzVS8y6A9spdnllqaw83gW5bpUS8si(~num);
			return obj;
		}
		if (_0023_003Dz9jrlnWk_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 13)
		{
			long num2 = ((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG();
			_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D obj2 = new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D();
			obj2._0023_003Dzbu_MJyfs7_Zi8dZPXG8_00248P0_003D(~num2);
			return obj2;
		}
		if (_0023_003Dz9jrlnWk_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 19)
		{
			Type underlyingType = Enum.GetUnderlyingType(_0023_003Dz9jrlnWk_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D().GetType());
			if (underlyingType == typeof(long) || underlyingType == typeof(ulong))
			{
				return new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(~Convert.ToInt64(_0023_003Dz9jrlnWk_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D()));
			}
			return new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(~Convert.ToInt32(_0023_003Dz9jrlnWk_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D()));
		}
		throw new InvalidOperationException();
	}

	private static void _0023_003Dz9gxmpIU2aepwmWBxSHchxvEEG6YG(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DztKL1iK5LvFaLq_0024Salhy_v0MVryh8FAXmFefkbvo_003D();
	}

	public static void _0023_003DzFYenke27p8fgDYKwAQilPSQTBV1AA_NKYQ_003D_003D<T>(T[] _0023_003Dz9jrlnWk_003D, Comparison<T> _0023_003DzBxpHhQ0_003D)
	{
		KeyValuePair<int, T>[] array = new KeyValuePair<int, T>[_0023_003Dz9jrlnWk_003D.Length];
		for (int i = 0; i < _0023_003Dz9jrlnWk_003D.Length; i++)
		{
			array[i] = new KeyValuePair<int, T>(i, _0023_003Dz9jrlnWk_003D[i]);
		}
		Array.Sort(array, _0023_003Dz9jrlnWk_003D, new _0023_003DzaTyQZ6E_003D<T>(_0023_003DzBxpHhQ0_003D));
	}

	private void _0023_003DzUbKftaPsoH4C3o3km5CXFp43OkI85ZTJMKNMSEuJ_LI5(Type _0023_003Dz9jrlnWk_003D)
	{
		long index = _0023_003Dz48d1zHJh3TOQKfAMFYN6p1CRbnL4();
		Array array = (Array)_0023_003DzrQFXD5oP9hinX0g4gA_003D_003D()._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D();
		_0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D._0023_003DzCysyOfnrUQB5WqShWAIL_0024X4XGCe9eW67eVeg6HY_003D(array.GetValue(index), _0023_003Dz9jrlnWk_003D));
	}

	private void _0023_003Dzl01rdMbhKWqXEDpjHctwRZgIgliJDTg7bQ_003D_003D(int _0023_003Dz9jrlnWk_003D)
	{
		_0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(this.m__0023_003DziiEv3wQ_003D[_0023_003Dz9jrlnWk_003D]._0023_003DzRqSyVpZK2TBKK9sY8BRsK_LOAo2IOUGsrjpuWUR4KGpBSNkJ3BhBNhxCFhqGPqZG8Y5jLLY_m3gD());
	}

	private static void _0023_003DzeJEr1eBPj_5TeYkEmBiMGsS9SC_0024e(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzrvgYEC2M5vRgH_0024PXC9SqcEgNZWiDqQp3KZTvk3jJwfyB(_0023_003Dz9jrlnWk_003D: false);
	}

	private static _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dzhuv_0024Udp9w3wv9OrPxC6bce0_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D, bool _0023_003Dztgqm2r4_003D)
	{
		if (!_0023_003Dztgqm2r4_003D)
		{
			long num = ((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG();
			long num2 = ((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG();
			return new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(num / num2);
		}
		long num3 = ((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG();
		ulong num4 = (ulong)((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG();
		return new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D((long)((ulong)num3 / num4));
	}

	private _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dza2_0024NLr7gkEcsbzKRAcBoNss_003D()
	{
		return _0023_003Dznx1EMIs_003D ?? _0023_003DzGX9QPgk_003D.Peek();
	}

	private static void _0023_003DzD6vEF2gBYEoene6a585Qx0SB_3R8(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DziT_0024hGl890RvhJvA9tQ2z8ve48aG3dsn3uH8b5po_003D(_0023_003Dz9jrlnWk_003D: true);
	}

	private void _0023_003DznQ8YDEtmD5Cz_kewxSKvUop4pX_0024MmG6PfA_003D_003D()
	{
	}

	private void _0023_003DzQRfyZFRl4R_002477CTSiMe16CpBHDHSToTDKQ_003D_003D(bool _0023_003Dz9jrlnWk_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		_0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() switch
		{
			1 => (int)((!_0023_003Dz9jrlnWk_003D) ? ((ushort)((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D()) : checked((uint)((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D())), 
			13 => (int)((!_0023_003Dz9jrlnWk_003D) ? ((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG() : checked((uint)((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG())), 
			19 => (int)((!_0023_003Dz9jrlnWk_003D) ? Convert.ToUInt64(((_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D()) : checked((uint)Convert.ToUInt64(((_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D()))), 
			8 => (int)((!_0023_003Dz9jrlnWk_003D) ? ((uint)((_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzCfXuHVIlFp1X1u2Med2_AL4lzej8EifTBw_003D_003D()) : checked((uint)((_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzCfXuHVIlFp1X1u2Med2_AL4lzej8EifTBw_003D_003D())), 
			0 => (int)((IntPtr.Size != 4) ? ((!_0023_003Dz9jrlnWk_003D) ? ((long)((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk()) : checked((uint)(ulong)(long)((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk())) : ((!_0023_003Dz9jrlnWk_003D) ? ((int)((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk()) : ((int)checked((uint)(int)((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk())))), 
			20 => (int)((UIntPtr.Size != 4) ? ((!_0023_003Dz9jrlnWk_003D) ? ((ulong)((_0023_003DqVEj3J19zkgEyU6VFymBz6riyi6CxZMJEjhA0KZ2nLKw_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzZlwwYywinAe9h_2ss_0024Wn4RsajDr79HfGCg_003D_003D()) : checked((uint)(ulong)((_0023_003DqVEj3J19zkgEyU6VFymBz6riyi6CxZMJEjhA0KZ2nLKw_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzZlwwYywinAe9h_2ss_0024Wn4RsajDr79HfGCg_003D_003D())) : ((!_0023_003Dz9jrlnWk_003D) ? ((uint)((_0023_003DqVEj3J19zkgEyU6VFymBz6riyi6CxZMJEjhA0KZ2nLKw_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzZlwwYywinAe9h_2ss_0024Wn4RsajDr79HfGCg_003D_003D()) : ((uint)((_0023_003DqVEj3J19zkgEyU6VFymBz6riyi6CxZMJEjhA0KZ2nLKw_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzZlwwYywinAe9h_2ss_0024Wn4RsajDr79HfGCg_003D_003D()))), 
			_ => throw new InvalidOperationException(), 
		}));
	}

	private void _0023_003Dz84sjEx3H5BuZJ2m01NLFGcySpi_0024Z()
	{
		this.m__0023_003DzAndD6oU_003D = _0023_003DzMP6kxrk_003D;
		int key = _0023_003DzLi0XoCY_003D._0023_003DzzWp83NqubJCg0KBvRVdJ1Clh9XOWlHor0w_003D_003D();
		_0023_003DzMP6kxrk_003D += 4u;
		_0023_003Dz_0024bI1JP4_003D.TryGetValue(key, out var value);
		value._0023_003DzBxpHhQ0_003D(this, _0023_003DzPHrDnw60J5aEG99fBkRHNDGKynpNve4GtVsNHlw_003D(_0023_003DzLi0XoCY_003D, value._0023_003Dz9jrlnWk_003D));
	}

	private static void _0023_003DzZ9cvcpzCpOiXu0O_LKIRS_SQ_0024F0V(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3 = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D obj = new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D();
		obj._0023_003DzVS8y6A9spdnllqaw83gW5bpUS8si(_0023_003DzjxnjI9Nvph1jzn_0024_xDbv5Sk_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2) ? 1 : 0);
		_0023_003Dz9jrlnWk_003D._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(obj);
	}

	private void _0023_003DzwsEtczsaGDQbpZzX7NSFPNZxAR8k981u4kunv8b09cFx(Stream _0023_003Dz9jrlnWk_003D, string _0023_003DzBxpHhQ0_003D)
	{
		_0023_003DzjUe2x_0024RVYtBlxOXpXmBPPvW3h7Kh(_0023_003Dz9jrlnWk_003D, 0L, _0023_003DzBxpHhQ0_003D);
	}

	private static void _0023_003DzbQmKCX4xeHbdtGF_Q3rSkiQ_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		_0023_003Dz9jrlnWk_003D._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() switch
		{
			1 => (uint)((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D(), 
			13 => ((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG(), 
			19 => (long)Convert.ToUInt64(((_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D()), 
			8 => (long)checked((ulong)((_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzCfXuHVIlFp1X1u2Med2_AL4lzej8EifTBw_003D_003D()), 
			0 => (IntPtr.Size != 4) ? ((long)((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk()) : ((uint)(int)((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk()), 
			_ => throw new InvalidOperationException(), 
		}));
	}

	private void _0023_003DzgsEHju8wslk_S93hiFuhVTuq_cvn()
	{
		_0023_003DzwETOsNI_003D = true;
	}

	private static void _0023_003DzjLjB9OQcoNUwL88DA_IVu5taVPap(object _0023_003Dz9jrlnWk_003D)
	{
		throw _0023_003Dz9jrlnWk_003D;
	}

	private static bool _0023_003DzjxnjI9Nvph1jzn_0024_xDbv5Sk_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		bool result = false;
		switch (_0023_003Dz9jrlnWk_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D())
		{
		case 1:
			result = ((_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() != 19) ? ((_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() != 7 || _0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D() != null) ? (((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D() == ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D()) : (((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D() == 0)) : (((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D() == Convert.ToInt64(((_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D())));
			break;
		case 13:
			result = ((_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() != 19) ? ((_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() != 7 || _0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D() != null) ? (((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG() == ((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG()) : (((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG() == 0)) : (((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG() == Convert.ToInt64(((_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D())));
			break;
		case 0:
			result = ((_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 7 && _0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D() == null) ? (((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk() == IntPtr.Zero) : ((_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() != 1) ? ((_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() != 13) ? (((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk() == ((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk()) : (((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk() == new IntPtr(((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG()))) : (((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk() == new IntPtr(((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D()))));
			break;
		case 20:
			result = ((_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 7 && _0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D() == null) ? (((_0023_003DqVEj3J19zkgEyU6VFymBz6riyi6CxZMJEjhA0KZ2nLKw_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzZlwwYywinAe9h_2ss_0024Wn4RsajDr79HfGCg_003D_003D() == UIntPtr.Zero) : ((_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() != 1) ? ((_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() != 13) ? (((_0023_003DqVEj3J19zkgEyU6VFymBz6riyi6CxZMJEjhA0KZ2nLKw_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzZlwwYywinAe9h_2ss_0024Wn4RsajDr79HfGCg_003D_003D() == ((_0023_003DqVEj3J19zkgEyU6VFymBz6riyi6CxZMJEjhA0KZ2nLKw_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzZlwwYywinAe9h_2ss_0024Wn4RsajDr79HfGCg_003D_003D()) : (((_0023_003DqVEj3J19zkgEyU6VFymBz6riyi6CxZMJEjhA0KZ2nLKw_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzZlwwYywinAe9h_2ss_0024Wn4RsajDr79HfGCg_003D_003D() == new UIntPtr((ulong)((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG()))) : (((_0023_003DqVEj3J19zkgEyU6VFymBz6riyi6CxZMJEjhA0KZ2nLKw_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzZlwwYywinAe9h_2ss_0024Wn4RsajDr79HfGCg_003D_003D() == new UIntPtr((uint)((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D()))));
			break;
		case 7:
			result = _0023_003Dz9jrlnWk_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D() == _0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D();
			break;
		case 25:
			result = (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() != 7 || _0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D() != null) && ((_0023_003DqCQNt2PbLdd9_Rj2n9YXdbVSA5Tqe2xDUhLSUbOVu_TU_003D)_0023_003Dz9jrlnWk_003D)._0023_003Dz39zZnN4wvB6luYqBEUduvsXAH_XP() == ((_0023_003DqCQNt2PbLdd9_Rj2n9YXdbVSA5Tqe2xDUhLSUbOVu_TU_003D)_0023_003DzBxpHhQ0_003D)._0023_003Dz39zZnN4wvB6luYqBEUduvsXAH_XP();
			break;
		case 19:
		{
			_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D _0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D2 = (_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003Dz9jrlnWk_003D;
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 19)
			{
				result = Convert.ToInt64(_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D2._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D()) == Convert.ToInt64(((_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D());
			}
			else if (_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D2._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D() == null)
			{
				result = _0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D() == null;
			}
			else if (_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D() != null)
			{
				result = Convert.ToInt64(_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D2._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D()) == Convert.ToInt64(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D());
			}
			break;
		}
		case 8:
		{
			double d = ((_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzCfXuHVIlFp1X1u2Med2_AL4lzej8EifTBw_003D_003D();
			double num = ((_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzCfXuHVIlFp1X1u2Med2_AL4lzej8EifTBw_003D_003D();
			result = !double.IsNaN(d) && !double.IsNaN(num) && d.Equals(num);
			break;
		}
		case 11:
		case 24:
		{
			_0023_003Dq0sd17OXY9HyRTHP4MNrXEWjZPbMynKvVMW_pliUAx6w_003D obj3 = (_0023_003Dq0sd17OXY9HyRTHP4MNrXEWjZPbMynKvVMW_pliUAx6w_003D)_0023_003Dz9jrlnWk_003D;
			_0023_003Dq0sd17OXY9HyRTHP4MNrXEWjZPbMynKvVMW_pliUAx6w_003D _0023_003Dq0sd17OXY9HyRTHP4MNrXEWjZPbMynKvVMW_pliUAx6w_003D2 = (_0023_003Dq0sd17OXY9HyRTHP4MNrXEWjZPbMynKvVMW_pliUAx6w_003D)_0023_003DzBxpHhQ0_003D;
			result = obj3._0023_003Dz_0024XWP1lkLfu0cK7NP2crUhlK_0024c2OIc_0024_L_00241EdJIIMr2cAy6qs0odTCwjJuvfwRdcyoYqrMTfqWvIvksobrg_003D_003D(_0023_003Dq0sd17OXY9HyRTHP4MNrXEWjZPbMynKvVMW_pliUAx6w_003D2);
			break;
		}
		case 18:
		{
			_0023_003DqrQPc9rwDL7Fl53_0024M2Pi1fo_0024Ac1BCNKiaW0Mx66Ji04U_003D _0023_003DqrQPc9rwDL7Fl53_0024M2Pi1fo_0024Ac1BCNKiaW0Mx66Ji04U_003D2 = (_0023_003DqrQPc9rwDL7Fl53_0024M2Pi1fo_0024Ac1BCNKiaW0Mx66Ji04U_003D)_0023_003Dz9jrlnWk_003D;
			_0023_003DqrQPc9rwDL7Fl53_0024M2Pi1fo_0024Ac1BCNKiaW0Mx66Ji04U_003D _0023_003DqrQPc9rwDL7Fl53_0024M2Pi1fo_0024Ac1BCNKiaW0Mx66Ji04U_003D3 = (_0023_003DqrQPc9rwDL7Fl53_0024M2Pi1fo_0024Ac1BCNKiaW0Mx66Ji04U_003D)_0023_003DzBxpHhQ0_003D;
			result = _0023_003DqrQPc9rwDL7Fl53_0024M2Pi1fo_0024Ac1BCNKiaW0Mx66Ji04U_003D2._0023_003DzcI1_N_0024zFH93ki__00245WrAnggkz3DwKuotj_0024Q_003D_003D() == _0023_003DqrQPc9rwDL7Fl53_0024M2Pi1fo_0024Ac1BCNKiaW0Mx66Ji04U_003D3._0023_003DzcI1_N_0024zFH93ki__00245WrAnggkz3DwKuotj_0024Q_003D_003D() && _0023_003DqrQPc9rwDL7Fl53_0024M2Pi1fo_0024Ac1BCNKiaW0Mx66Ji04U_003D2._0023_003DzOGfSdf3O2RGD18omagPRFM_0024yH5C6() == _0023_003DqrQPc9rwDL7Fl53_0024M2Pi1fo_0024Ac1BCNKiaW0Mx66Ji04U_003D3._0023_003DzOGfSdf3O2RGD18omagPRFM_0024yH5C6();
			break;
		}
		case 23:
		{
			_0023_003DqOnAL2yhFn6qFFxtB3vCWqYNkaIJ5qqh3h6z2BC38Mh4_003D obj2 = (_0023_003DqOnAL2yhFn6qFFxtB3vCWqYNkaIJ5qqh3h6z2BC38Mh4_003D)_0023_003Dz9jrlnWk_003D;
			_0023_003DqOnAL2yhFn6qFFxtB3vCWqYNkaIJ5qqh3h6z2BC38Mh4_003D _0023_003DqOnAL2yhFn6qFFxtB3vCWqYNkaIJ5qqh3h6z2BC38Mh4_003D2 = (_0023_003DqOnAL2yhFn6qFFxtB3vCWqYNkaIJ5qqh3h6z2BC38Mh4_003D)_0023_003DzBxpHhQ0_003D;
			result = obj2._0023_003DzP_6DBNZ2mJNKRaFdqnf64UitOXKm60smb3aoCTTiqt7H() == _0023_003DqOnAL2yhFn6qFFxtB3vCWqYNkaIJ5qqh3h6z2BC38Mh4_003D2._0023_003DzP_6DBNZ2mJNKRaFdqnf64UitOXKm60smb3aoCTTiqt7H();
			break;
		}
		case 2:
		{
			_0023_003DqFNN_kH3_Aic_0024vq9s6N7BcnqdUOw1mJpa1yIMZD1vbOQ_003D obj = (_0023_003DqFNN_kH3_Aic_0024vq9s6N7BcnqdUOw1mJpa1yIMZD1vbOQ_003D)_0023_003Dz9jrlnWk_003D;
			result = _0023_003DzjxnjI9Nvph1jzn_0024_xDbv5Sk_003D(((_0023_003DqFNN_kH3_Aic_0024vq9s6N7BcnqdUOw1mJpa1yIMZD1vbOQ_003D)_0023_003DzBxpHhQ0_003D)._0023_003DziVOWcx_00243zo4_0iYh_0024lucKGuN0vuo(), obj._0023_003DziVOWcx_00243zo4_0iYh_0024lucKGuN0vuo());
			break;
		}
		default:
			result = _0023_003Dz9jrlnWk_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D() == _0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D();
			break;
		}
		return result;
	}

	private static void _0023_003DzRNVoPh1Z7HxC8HfC_fgGQUInZN4LR5JNcXc3xBd_7IRd(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003Dzy4D_00248buHMHsvaKDXIg_003D_003D(1);
	}

	private static void _0023_003DzQXJ4_0024moj2rv16A9EKCe1D_pLBXZ35k5w9eSDj9w_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzUbKftaPsoH4C3o3km5CXFp43OkI85ZTJMKNMSEuJ_LI5(_0023_003DzozZCuko_003D);
	}

	private static void _0023_003DzRx5N72BRmErWQARWJNF2v6Hsp8YgtvQ8rfwcwgwNbSJK(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DztKL1iK5LvFaLq_0024Salhy_v0MVryh8FAXmFefkbvo_003D();
	}

	private static void _0023_003Dzn63If8PhwV8CZuLkPqhNFwY_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D _0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D2 = (_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D)_0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		if (double.IsNaN(_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D2._0023_003DzCfXuHVIlFp1X1u2Med2_AL4lzej8EifTBw_003D_003D()) || double.IsInfinity(_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D2._0023_003DzCfXuHVIlFp1X1u2Med2_AL4lzej8EifTBw_003D_003D()))
		{
			throw new OverflowException(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564314178));
		}
		_0023_003Dz9jrlnWk_003D._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D2);
	}

	private static void _0023_003DzeblxSneM3NDUd4WhHGcNy9w_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzLMJxSSXveUKWgX7ByprFEtw_003D(typeof(short));
	}

	private static void _0023_003DzxKTGSmttQqcAqPZPhlmsseI_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dz9jrlnWk_003D._0023_003Dza2_0024NLr7gkEcsbzKRAcBoNss_003D();
		_0023_003Dz9jrlnWk_003D._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzRqSyVpZK2TBKK9sY8BRsK_LOAo2IOUGsrjpuWUR4KGpBSNkJ3BhBNhxCFhqGPqZG8Y5jLLY_m3gD());
	}

	private static void _0023_003DzZWd3R5s7W5WWVbSEq2kntbWB8XDeU2bdCg_003D_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		uint num = ((_0023_003DqJFdrGiwz1aJICVkSTb_0024Zko9aS6iSwDcZdo9VS4Dkh_0024s_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzxGjrL4iuhvogLPGFSdnVXdPvbKxem9P4HA_003D_003D();
		_0023_003Dz9jrlnWk_003D._0023_003DzF6lNdUgp_0024EXaHsYbpiKsz5x9aQWSK_0024MB_mvoQ7s_003D(null, num);
	}

	private static void _0023_003DznJnvcr5FjZtj2QM4mFzBVJs7oa4H(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		if (_0023_003DzFCI8XumDuJuKa_0024WkwlglF8STueBuOL3SGHPfX6c_003D(_0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D(), _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2))
		{
			uint num = ((_0023_003DqJFdrGiwz1aJICVkSTb_0024Zko9aS6iSwDcZdo9VS4Dkh_0024s_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzxGjrL4iuhvogLPGFSdnVXdPvbKxem9P4HA_003D_003D();
			_0023_003Dz9jrlnWk_003D._0023_003Dz9r__0024YTGu_0024iN2qFjqe6k1t7s_003D(num);
		}
	}

	private static void _0023_003DzK46PKFEi52UNAqeyg6XC3nY_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(_0023_003DzBxpHhQ0_003D);
	}

	private static void _0023_003DzAQwMiNNI_x8YjJEfbpQsnjoutR_0024_0024(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		object obj = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D()._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D();
		long num = _0023_003Dz9jrlnWk_003D._0023_003Dz48d1zHJh3TOQKfAMFYN6p1CRbnL4();
		Array array = (Array)_0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D()._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D();
		Type elementType = array.GetType().GetElementType();
		if (elementType == typeof(sbyte))
		{
			_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D._0023_003DzCysyOfnrUQB5WqShWAIL_0024X4XGCe9eW67eVeg6HY_003D(obj, typeof(sbyte));
			((sbyte[])array)[num] = (sbyte)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D();
		}
		else if (elementType == typeof(byte))
		{
			_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3 = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D._0023_003DzCysyOfnrUQB5WqShWAIL_0024X4XGCe9eW67eVeg6HY_003D(obj, typeof(byte));
			((byte[])array)[num] = (byte)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D();
		}
		else if (elementType == typeof(bool))
		{
			_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D4 = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D._0023_003DzCysyOfnrUQB5WqShWAIL_0024X4XGCe9eW67eVeg6HY_003D(obj, typeof(bool));
			((bool[])array)[num] = (bool)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D4._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D();
		}
		else if (elementType.IsEnum)
		{
			_0023_003Dz9jrlnWk_003D._0023_003DzlUMFttjizmrsnJvpILZOQbCJdq_9(elementType, obj, num, array);
		}
		else
		{
			_0023_003Dz9jrlnWk_003D._0023_003DzlUMFttjizmrsnJvpILZOQbCJdq_9(typeof(sbyte), obj, num, array);
		}
	}

	private void _0023_003Dz_bTfuOd_0024_8tksF6orA_003D_003D(Type _0023_003Dz9jrlnWk_003D)
	{
		object obj = _0023_003DzrQFXD5oP9hinX0g4gA_003D_003D()._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D();
		long num = _0023_003Dz48d1zHJh3TOQKfAMFYN6p1CRbnL4();
		Array array = (Array)_0023_003DzrQFXD5oP9hinX0g4gA_003D_003D()._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D();
		_0023_003DzlUMFttjizmrsnJvpILZOQbCJdq_9(_0023_003Dz9jrlnWk_003D, obj, num, array);
	}

	private static void _0023_003DzHaZCYtr8EkKwk_0024wGSkVBkds_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D2 = (_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D;
		MethodBase methodBase = _0023_003Dz9jrlnWk_003D._0023_003DzRt6UVedmJJGarSZZFciXi_0024twqllky4LsnA_003D_003D(_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D2._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D());
		Type declaringType = methodBase.DeclaringType;
		Type type = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D()._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D().GetType();
		ParameterInfo[] parameters = methodBase.GetParameters();
		Type[] array = new Type[parameters.Length];
		for (int i = 0; i < parameters.Length; i++)
		{
			array[i] = parameters[i].ParameterType;
		}
		MethodBase methodBase2 = null;
		Type type2 = type;
		while (type2 != null && type2 != declaringType)
		{
			MethodInfo method = type2.GetMethod(methodBase.Name, BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetProperty | BindingFlags.SetProperty | BindingFlags.ExactBinding, null, CallingConventions.Any, array, null);
			if (method != null && method.GetBaseDefinition() == methodBase)
			{
				methodBase2 = method;
				break;
			}
			type2 = type2.BaseType;
		}
		if (methodBase2 == null)
		{
			methodBase2 = methodBase;
		}
		_0023_003DqZOgqBgNtgFzdL0x3JA7LxzDeXh41TKRK3WDZXmMsiIQ_003D obj = new _0023_003DqZOgqBgNtgFzdL0x3JA7LxzDeXh41TKRK3WDZXmMsiIQ_003D();
		obj._0023_003DzLewIEoK78TTNwxvWLmSRiD8_003D(methodBase2);
		_0023_003Dz9jrlnWk_003D._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(obj);
	}

	private _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzgrTDWpgS75NbjHA0liPooJUwgItpj10tYwGQQMc_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		if (_0023_003Dz9jrlnWk_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 1)
		{
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 1)
			{
				int num = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
				int num2 = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
				return new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(num << num2);
			}
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 19)
			{
				return _0023_003DzgrTDWpgS75NbjHA0liPooJUwgItpj10tYwGQQMc_003D(_0023_003Dz9jrlnWk_003D, new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(Convert.ToInt32(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D())));
			}
		}
		if (_0023_003Dz9jrlnWk_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 13)
		{
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 1)
			{
				long num3 = ((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG();
				int num4 = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
				return new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(num3 << num4);
			}
			if (_0023_003DzBxpHhQ0_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 19)
			{
				return _0023_003DzgrTDWpgS75NbjHA0liPooJUwgItpj10tYwGQQMc_003D(_0023_003Dz9jrlnWk_003D, new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(Convert.ToInt32(_0023_003DzBxpHhQ0_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D())));
			}
		}
		if (_0023_003Dz9jrlnWk_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() == 19)
		{
			Type underlyingType = Enum.GetUnderlyingType(_0023_003Dz9jrlnWk_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D().GetType());
			if (underlyingType == typeof(long) || underlyingType == typeof(ulong))
			{
				return _0023_003DzgrTDWpgS75NbjHA0liPooJUwgItpj10tYwGQQMc_003D(new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(Convert.ToInt64(_0023_003Dz9jrlnWk_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D())), _0023_003DzBxpHhQ0_003D);
			}
			return _0023_003DzgrTDWpgS75NbjHA0liPooJUwgItpj10tYwGQQMc_003D(new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(Convert.ToInt32(_0023_003Dz9jrlnWk_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D())), _0023_003DzBxpHhQ0_003D);
		}
		throw new InvalidOperationException();
	}

	private static void _0023_003DzXbOzilw6qhAIyhi6nOF8VRw_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DziT_0024hGl890RvhJvA9tQ2z8ve48aG3dsn3uH8b5po_003D(_0023_003Dz9jrlnWk_003D: false);
	}

	private _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D[] _0023_003DzAQlRPLKeFJ2KprKsiPmRoa4HNWOXCbdDbN6qcBw_003D()
	{
		_0023_003DqI6EWtn7_002464gNhfpc2l8JOYKwX_00246eoYgYemA7pbjj4Hc_003D[] array = m__0023_003DzaTyQZ6E_003D._0023_003DzzBAMLXvtn4FV85kZpakS_QmLDqFMxKl_0024hrLDn5ktak1x();
		int num = array.Length;
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D[] array2 = new _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D[num];
		for (int i = 0; i < num; i++)
		{
			array2[i] = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D._0023_003DzCysyOfnrUQB5WqShWAIL_0024X4XGCe9eW67eVeg6HY_003D(null, _0023_003Dz9_Z5EhGFT4yzpTmOPYjfhZOeNABFeUtCmZ_KeWA_003D(array[i]._0023_003DzM1vdRUY68Q9m9zyu4bX389I_003D(), _0023_003DzBxpHhQ0_003D: false));
		}
		return array2;
	}

	private static void _0023_003Dzj5_0024D_vTKBfOo1BNySte9qq4RrRvr(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		if (_0023_003DzjxnjI9Nvph1jzn_0024_xDbv5Sk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D(), _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2))
		{
			uint num = ((_0023_003DqJFdrGiwz1aJICVkSTb_0024Zko9aS6iSwDcZdo9VS4Dkh_0024s_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzxGjrL4iuhvogLPGFSdnVXdPvbKxem9P4HA_003D_003D();
			_0023_003Dz9jrlnWk_003D._0023_003Dz9r__0024YTGu_0024iN2qFjqe6k1t7s_003D(num);
		}
	}

	private bool _0023_003DztbaWdh6KnRI_6XZXde_Y5Jj1NOinKwzBVCMYMgM_003D()
	{
		if (_0023_003Dznx1EMIs_003D == null)
		{
			return _0023_003DzGX9QPgk_003D.Count != 0;
		}
		return true;
	}

	private void _0023_003DzRDsD2tmbbWicD3F3bHfTv5w75vMCZrFqbQ_003D_003D(MemberInfo _0023_003Dz9jrlnWk_003D)
	{
		if (!_0023_003Dzn7pbC1GD4QYfQd5KWDAQ6flUbSqtwoAqUM7ydik_003D() || m__0023_003DzaTyQZ6E_003D._0023_003DzghS_eb9eUC6u4vM30FyEKH1J_rdGVNlGcYMqXXUZ2TCX())
		{
			return;
		}
		bool flag = false;
		Assembly assembly = typeof(SecurityCriticalAttribute).Assembly;
		MemberInfo memberInfo = _0023_003Dz9jrlnWk_003D;
		while (memberInfo != null)
		{
			object[] customAttributes = memberInfo.GetCustomAttributes(inherit: false);
			for (int i = 0; i < customAttributes.Length; i++)
			{
				Type type = customAttributes[i].GetType();
				if (type.Assembly == assembly)
				{
					string fullName = type.FullName;
					if (_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564314007).Equals(fullName, StringComparison.Ordinal))
					{
						flag = true;
						goto end_IL_009d;
					}
					if (_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564314087).Equals(fullName, StringComparison.Ordinal))
					{
						goto end_IL_009d;
					}
				}
			}
			memberInfo = memberInfo.DeclaringType;
			continue;
			end_IL_009d:
			break;
		}
		if (flag)
		{
			if (_0023_003Dz9jrlnWk_003D is MethodBase)
			{
				string text = _0023_003DzHhUu5sIMPQK8hMO51mJkVwpkxgDLTRh_0024O6_uK4s_003D((MethodBase)_0023_003Dz9jrlnWk_003D);
				throw _0023_003DzfE30YNyI_f3LeZRtY0ALj480DwZAzmMJ5y_0024sIbPs4W2n(_0023_003Dza3Vg0pbdAn80NfoL4a4_NphXc70V(m__0023_003DzaTyQZ6E_003D), text);
			}
			if (_0023_003Dz9jrlnWk_003D is FieldInfo)
			{
				string text2 = _0023_003Dz9jrlnWk_003D.DeclaringType.FullName + _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313907) + _0023_003Dz9jrlnWk_003D.Name;
				throw _0023_003DzfJ4aXO0pOe8J43PKGg89NbhMUmmqNtMeSwNp5tc_003D(_0023_003Dza3Vg0pbdAn80NfoL4a4_NphXc70V(m__0023_003DzaTyQZ6E_003D), text2);
			}
			if (_0023_003Dz9jrlnWk_003D is Type)
			{
				string fullName2 = ((Type)_0023_003Dz9jrlnWk_003D).FullName;
				throw _0023_003Dz0jAsrMxmdjJ0CZjSeSu8IC3FTAoK(_0023_003Dza3Vg0pbdAn80NfoL4a4_NphXc70V(m__0023_003DzaTyQZ6E_003D), fullName2);
			}
			throw new SecurityException(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313915));
		}
	}

	private void _0023_003DzQyCWZ7MbsQIdA4QPrz8yFa85VUe9_JXAcxg1Fz8_003D()
	{
		_0023_003DzFYenke27p8fgDYKwAQilPSQTBV1AA_NKYQ_003D_003D(_0023_003DzCR5Jlyc_003D, (_0023_003Dqih1RKs7Osg5_0024Rd9gDhKEdqdrC8qgJFChg_7i1V8hZwk_003D _0023_003Dqih1RKs7Osg5_0024Rd9gDhKEdqdrC8qgJFChg_7i1V8hZwk_003D2, _0023_003Dqih1RKs7Osg5_0024Rd9gDhKEdqdrC8qgJFChg_7i1V8hZwk_003D _0023_003Dqih1RKs7Osg5_0024Rd9gDhKEdqdrC8qgJFChg_7i1V8hZwk_003D3) => (_0023_003Dqih1RKs7Osg5_0024Rd9gDhKEdqdrC8qgJFChg_7i1V8hZwk_003D2._0023_003DzcmYAH1_0024kgTZIsm37rJAwkR2aPGOw() == _0023_003Dqih1RKs7Osg5_0024Rd9gDhKEdqdrC8qgJFChg_7i1V8hZwk_003D3._0023_003DzcmYAH1_0024kgTZIsm37rJAwkR2aPGOw()) ? _0023_003Dqih1RKs7Osg5_0024Rd9gDhKEdqdrC8qgJFChg_7i1V8hZwk_003D3._0023_003DzbCVHSLHjVVzIDZuBMIVB_Phq0P8i_wdHnQ_003D_003D().CompareTo(_0023_003Dqih1RKs7Osg5_0024Rd9gDhKEdqdrC8qgJFChg_7i1V8hZwk_003D2._0023_003DzbCVHSLHjVVzIDZuBMIVB_Phq0P8i_wdHnQ_003D_003D()) : _0023_003Dqih1RKs7Osg5_0024Rd9gDhKEdqdrC8qgJFChg_7i1V8hZwk_003D2._0023_003DzcmYAH1_0024kgTZIsm37rJAwkR2aPGOw().CompareTo(_0023_003Dqih1RKs7Osg5_0024Rd9gDhKEdqdrC8qgJFChg_7i1V8hZwk_003D3._0023_003DzcmYAH1_0024kgTZIsm37rJAwkR2aPGOw()));
	}

	private void _0023_003DzriXIwLFCuwD1GZVAt_00248x4do_003D(bool _0023_003Dz9jrlnWk_003D, bool _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3 = _0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		_0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(_0023_003DzqWLtQKrpdOoIPJiYig_003D_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2, _0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D));
	}

	private static void _0023_003DzWOsJFhnHB_2MOd1kHZzH12rpSltRgKPvSw_003D_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzDvgKbbDxn0kp4Vzkd2w93ks_003D(_0023_003Dz9jrlnWk_003D: false);
	}

	private static void _0023_003DzE2OU1KKZG3s4TEHf7N0TYYsbkTkNiVkMoU_M3TI_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		int num = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
		FieldInfo fieldInfo = _0023_003Dz9jrlnWk_003D._0023_003DzxFlP9j6hwChqbnCQxNoxN7LJpAh_00242zp2XpETVEHUh_9i(num);
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		_0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D _0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D2 = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 as _0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D;
		object obj = ((_0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D2 == null) ? _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D() : _0023_003Dz9jrlnWk_003D._0023_003DzcyfMbnJemFaR1U9IYqWp0cPmk80NlqUX5LErUtBcWaeU(_0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D2)._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D());
		_0023_003Dz9jrlnWk_003D._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(new _0023_003DqrQPc9rwDL7Fl53_0024M2Pi1fo_0024Ac1BCNKiaW0Mx66Ji04U_003D(fieldInfo, obj, _0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D2));
	}

	private static void _0023_003DzeVr4hn41cFroA3B5r0VGbTELEaqR3vGXD2C9kIDD92At(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		if (!_0023_003DzbIhMMCpTAtqwcE7EXAzYf_SJEcWXsuXv_0024Q_003D_003D(_0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D(), _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2))
		{
			uint num = ((_0023_003DqJFdrGiwz1aJICVkSTb_0024Zko9aS6iSwDcZdo9VS4Dkh_0024s_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzxGjrL4iuhvogLPGFSdnVXdPvbKxem9P4HA_003D_003D();
			_0023_003Dz9jrlnWk_003D._0023_003Dz9r__0024YTGu_0024iN2qFjqe6k1t7s_003D(num);
		}
	}

	private static void _0023_003DzJL90tUbmxXV6xvOjghbthf8_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003Dzl01rdMbhKWqXEDpjHctwRZgIgliJDTg7bQ_003D_003D(3);
	}

	private static void _0023_003Dzbofhd1w4tXP1WR4NR_0024JQsmdJzUjB5ByW_0024A_003D_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		int num = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
		_0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D _0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D2 = _0023_003Dz9jrlnWk_003D._0023_003Dz_kQ6vjzn2xXdxKzdPsJwstuDR14y(num);
		object obj = ((_0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D2._0023_003DzwH8K7lD_0024cC3gY_RIDCO_Bu8Tp6tgtXa0TA_003D_003D() == 0) ? _0023_003Dz9jrlnWk_003D._0023_003DzsOJ6TahPfKuexMbKFEzmdyoIYrB0j9210g_003D_003D(_0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D2._0023_003DztkhwzVeVIldXjs1hyonqsqcuOAEF()) : (_0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D2._0023_003DzMDpHhtfRNQDKXWsFcSVSbdd3Ewg6()._0023_003DzA9soEnqVH30sCIQyx9TdGqof_UNEHpVR4mfBgLqWxZ1U3_DxME_DE3zKrn8uHRkWGZxJRdIDUxjkiWGrygRHRok_003D() switch
		{
			2 => _0023_003Dz9jrlnWk_003D._0023_003Dz9_Z5EhGFT4yzpTmOPYjfhZOeNABFeUtCmZ_KeWA_003D(num, _0023_003DzBxpHhQ0_003D: true).TypeHandle, 
			0 => _0023_003Dz9jrlnWk_003D._0023_003DzRt6UVedmJJGarSZZFciXi_0024twqllky4LsnA_003D_003D(num).MethodHandle, 
			1 => _0023_003Dz9jrlnWk_003D._0023_003DzxFlP9j6hwChqbnCQxNoxN7LJpAh_00242zp2XpETVEHUh_9i(num).FieldHandle, 
			_ => throw new InvalidOperationException(), 
		}));
		_0023_003DqcjmfsaS6dKPuf2kSTqJKWfH_rgkc03gEAn6QEKAtpbA_003D obj2 = new _0023_003DqcjmfsaS6dKPuf2kSTqJKWfH_rgkc03gEAn6QEKAtpbA_003D();
		obj2._0023_003DzcdhpkZLz02cIGzFhiuGuUgo_003D(obj);
		_0023_003Dz9jrlnWk_003D._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(obj2);
	}

	private static void _0023_003Dz1TrvUtEkNPeWQKWB_AldL5FFYjgfkX4Rz4tPsA_FY5Sp(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzwbI83bfoaDmYaZBDzj4leqo_003D(1);
	}

	private void _0023_003Dz3oHptl2qBd0xU8cwS6UfOo5vVoXBPMMnW5N0aQU_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dz9jrlnWk_003D)
	{
		int num = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
		MethodBase methodBase = _0023_003DzRt6UVedmJJGarSZZFciXi_0024twqllky4LsnA_003D_003D(num);
		Type declaringType = methodBase.DeclaringType;
		ParameterInfo[] parameters = methodBase.GetParameters();
		int num2 = parameters.Length;
		object[] array = new object[num2];
		Dictionary<int, _0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D> dictionary = new Dictionary<int, _0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D>();
		for (int num3 = num2 - 1; num3 >= 0; num3--)
		{
			_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
			if (_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 is _0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D value)
			{
				dictionary.Add(num3, value);
				_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003DzcyfMbnJemFaR1U9IYqWp0cPmk80NlqUX5LErUtBcWaeU(value);
			}
			if (_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003Dz55cfCv82_0024cfWUBDPYd5Wu_0024c_003D() != null)
			{
				_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D._0023_003DzCysyOfnrUQB5WqShWAIL_0024X4XGCe9eW67eVeg6HY_003D(null, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003Dz55cfCv82_0024cfWUBDPYd5Wu_0024c_003D())._0023_003DzAPlrN6aYwAg5F1LxHYbv_0024wOBB_0024afgbz6XKGgvF_0024QaP3F7Nvwy8DGE80Q1m63nNv21_00240QxzxHCeC2PtE3mw_003D_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2);
			}
			_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3 = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D._0023_003DzCysyOfnrUQB5WqShWAIL_0024X4XGCe9eW67eVeg6HY_003D(null, parameters[num3].ParameterType)._0023_003DzAPlrN6aYwAg5F1LxHYbv_0024wOBB_0024afgbz6XKGgvF_0024QaP3F7Nvwy8DGE80Q1m63nNv21_00240QxzxHCeC2PtE3mw_003D_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2);
			array[num3] = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D();
		}
		object obj;
		try
		{
			obj = _0023_003DzTtHhYD7wYomyazLD30cjaJao7oFKwWOoYw_003D_003D(methodBase, null, array, _0023_003DzzKDx05I_003D: false);
		}
		catch (TargetInvocationException ex)
		{
			Exception ex2 = ex.InnerException ?? ex;
			_0023_003DzzUdLVh6RcJ0qp5eRPoW5he0ADnSX(ex2);
			return;
		}
		foreach (KeyValuePair<int, _0023_003DqaEtT9DoRRoUP_0024LS5u4B6AmbrhvUvlroRd1oNAew2QJs_003D> item in dictionary)
		{
			_0023_003DzlLFsRbFCVJXLxNmd_0024gDP8S8_003D(item.Value, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D._0023_003DzCysyOfnrUQB5WqShWAIL_0024X4XGCe9eW67eVeg6HY_003D(array[item.Key], null));
		}
		_0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D._0023_003DzCysyOfnrUQB5WqShWAIL_0024X4XGCe9eW67eVeg6HY_003D(obj, declaringType));
	}

	private _0023_003DqI6EWtn7_002464gNhfpc2l8JOYKwX_00246eoYgYemA7pbjj4Hc_003D[] _0023_003DzMpJnKU_48c6gOC8H7yb0Yy5Ce7nYYH3xpCbdHeM_003D(_0023_003DqSrxlws3SuprWxrjyHO1juxJFrTNvlF8gj_KAkF067yA_003D _0023_003Dz9jrlnWk_003D)
	{
		_0023_003DqI6EWtn7_002464gNhfpc2l8JOYKwX_00246eoYgYemA7pbjj4Hc_003D[] array = new _0023_003DqI6EWtn7_002464gNhfpc2l8JOYKwX_00246eoYgYemA7pbjj4Hc_003D[_0023_003Dz9jrlnWk_003D._0023_003DzfyBJnRlgDbP3pAMbTWEdJKI_003D()];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = _0023_003DzQrrMZqhmOpyFZhNVh2nzsivjlr0x(_0023_003Dz9jrlnWk_003D);
		}
		return array;
	}

	private static object _0023_003Dz_hjrZDOTOQR8OWbqvQxPmsVMHYb0ynulxddSkJRnCboe(MethodBase _0023_003Dz9jrlnWk_003D, object _0023_003DzBxpHhQ0_003D, object[] _0023_003Dztgqm2r4_003D, bool _0023_003DzzKDx05I_003D)
	{
		_0023_003DzJ6W8874_003D _0023_003DzJ6W8874_003D2 = new _0023_003DzJ6W8874_003D(_0023_003Dz9jrlnWk_003D, _0023_003DzzKDx05I_003D);
		_0023_003Dz2X8kE24_003D _0023_003Dz2X8kE24_003D2 = _0023_003DzZ6MTnxiFgca02BIK5SGIFlk_003D(_0023_003DzJ6W8874_003D2);
		if (_0023_003Dz2X8kE24_003D2 == null)
		{
			bool flag;
			lock (_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D.m__0023_003Dztgqm2r4_003D)
			{
				_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D.m__0023_003Dztgqm2r4_003D.TryGetValue(_0023_003Dz9jrlnWk_003D, out var value);
				flag = value >= 50;
				if (!flag)
				{
					_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D.m__0023_003Dztgqm2r4_003D[_0023_003Dz9jrlnWk_003D] = value + 1;
				}
			}
			if (!flag && (_0023_003DzzKDx05I_003D || _0023_003DzBxpHhQ0_003D != null || _0023_003Dz9jrlnWk_003D.IsStatic || _0023_003Dz9jrlnWk_003D.IsConstructor) && !_0023_003DzhMaI5Ltf1_0024yc1b5n7pEBDRL7trQMcGFYQR1Kus5CdT1c(_0023_003Dz9jrlnWk_003D) && (_0023_003Dz9jrlnWk_003D.CallingConvention & CallingConventions.Any) != CallingConventions.VarArgs)
			{
				return _0023_003Dzen6M6suXozc4dDI9Ng_003D_003D(_0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D);
			}
			_0023_003Dz2X8kE24_003D2 = _0023_003DzMRS7NQzOcE7aSPN_bE8IttOKtzNqQ2biGA_003D_003D(_0023_003DzJ6W8874_003D2);
			lock (_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D.m__0023_003Dztgqm2r4_003D)
			{
				_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D.m__0023_003Dztgqm2r4_003D.Remove(_0023_003Dz9jrlnWk_003D);
			}
		}
		return _0023_003Dz2X8kE24_003D2(_0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D);
	}

	private void _0023_003Dzy4D_00248buHMHsvaKDXIg_003D_003D(int _0023_003Dz9jrlnWk_003D)
	{
		_0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(_0023_003Dz9jrlnWk_003D));
	}

	private static void _0023_003Dzoy6tJ0IF4VWgoQntLmmN9hdNlMa9FvipCQ_003D_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DztKL1iK5LvFaLq_0024Salhy_v0MVryh8FAXmFefkbvo_003D();
	}

	private static void _0023_003DzILv91HML1lmcKl_jpzIJo9WKSh2nyLTztk136Nk_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		throw new NotSupportedException(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564315402));
	}

	private _0023_003DqI6EWtn7_002464gNhfpc2l8JOYKwX_00246eoYgYemA7pbjj4Hc_003D _0023_003DzQrrMZqhmOpyFZhNVh2nzsivjlr0x(_0023_003DqSrxlws3SuprWxrjyHO1juxJFrTNvlF8gj_KAkF067yA_003D _0023_003Dz9jrlnWk_003D)
	{
		_0023_003DqI6EWtn7_002464gNhfpc2l8JOYKwX_00246eoYgYemA7pbjj4Hc_003D obj = new _0023_003DqI6EWtn7_002464gNhfpc2l8JOYKwX_00246eoYgYemA7pbjj4Hc_003D();
		obj._0023_003Dzbuvc7IqS3AsSSmfZJ6hHQmrFywNGc6c8xA_003D_003D(_0023_003Dz9jrlnWk_003D._0023_003DzzWp83NqubJCg0KBvRVdJ1Clh9XOWlHor0w_003D_003D());
		return obj;
	}

	private Stack<_0023_003DzbSmUaeo_003D> _0023_003DzFbIBOUZukUTRt6X7TpE_uAdTdeMf()
	{
		Stack<_0023_003DzbSmUaeo_003D> stack = _0023_003DzbzHeu9w_003D;
		if (stack == null)
		{
			stack = (_0023_003DzbzHeu9w_003D = new Stack<_0023_003DzbSmUaeo_003D>());
			stack.Push(new _0023_003DzbSmUaeo_003D
			{
				_0023_003DzBxpHhQ0_003D = _0023_003DzLi0XoCY_003D,
				_0023_003Dztgqm2r4_003D = _0023_003DzLi0XoCY_003D._0023_003Dzf_kC_0024hpTUTdHx7uANBVIZvPU6fFbivFk0g_003D_003D(),
				_0023_003DzzKDx05I_003D = _0023_003DzFQGDh5A_003D
			});
		}
		return stack;
	}

	private static void _0023_003Dzzgb2H_0024nnvEozAoXKew_003D_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3 = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		_0023_003Dz9jrlnWk_003D._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(_0023_003Dz9jrlnWk_003D._0023_003Dz7cls5OZUxwV_0024XPFgwwCtM3Ng67uqnWekGg_003D_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2));
	}

	private void _0023_003DzDvgKbbDxn0kp4Vzkd2w93ks_003D(bool _0023_003Dz9jrlnWk_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		short num = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() switch
		{
			1 => (!_0023_003Dz9jrlnWk_003D) ? ((short)((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D()) : checked((short)((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D()), 
			13 => (!_0023_003Dz9jrlnWk_003D) ? ((short)((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG()) : checked((short)((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG()), 
			19 => (!_0023_003Dz9jrlnWk_003D) ? ((short)Convert.ToUInt64(((_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D())) : checked((short)Convert.ToUInt64(((_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D())), 
			8 => (!_0023_003Dz9jrlnWk_003D) ? ((short)((_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzCfXuHVIlFp1X1u2Med2_AL4lzej8EifTBw_003D_003D()) : checked((short)((_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzCfXuHVIlFp1X1u2Med2_AL4lzej8EifTBw_003D_003D()), 
			0 => (IntPtr.Size != 4) ? ((!_0023_003Dz9jrlnWk_003D) ? ((short)(long)((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk()) : checked((short)(long)((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk())) : ((!_0023_003Dz9jrlnWk_003D) ? ((short)(int)((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk()) : checked((short)(int)((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk())), 
			_ => throw new InvalidOperationException(), 
		};
		_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D obj = new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D();
		obj._0023_003DzVS8y6A9spdnllqaw83gW5bpUS8si(num);
		_0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(obj);
	}

	private static void _0023_003DzoC9YrBtXWPHoabSujyAFKzZ4immOUmP9IpZ1Rak_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		int num = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
		FieldInfo fieldInfo = _0023_003Dz9jrlnWk_003D._0023_003DzxFlP9j6hwChqbnCQxNoxN7LJpAh_00242zp2XpETVEHUh_9i(num);
		_0023_003Dz9jrlnWk_003D._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D._0023_003DzCysyOfnrUQB5WqShWAIL_0024X4XGCe9eW67eVeg6HY_003D(fieldInfo.GetValue(null), fieldInfo.FieldType));
	}

	private static void _0023_003DzuRKauI5ALzYpA553dPTVEDB2bFkIpyztog_003D_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzpU_n7PfnyRyJ1anIgJrsjiSffFPi(0);
	}

	private static void _0023_003DzcTAM4CX3wDgJRcUfZyhb176LPXa_aydfmJLr5Mgr_sGZ(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzUbKftaPsoH4C3o3km5CXFp43OkI85ZTJMKNMSEuJ_LI5(_0023_003DqqSQMR5x0Ss3kUZAkPHTc7q6IdaUzR_0024BTopvbTI_0024P7DA_003D._0023_003Dz9jrlnWk_003D);
	}

	private static void _0023_003DzfFNwdLqEqbmoSkqUCMUyDUs_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		float num = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() switch
		{
			1 => ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D(), 
			13 => ((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG(), 
			19 => Convert.ToUInt64(((_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D()), 
			8 => (float)((_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzCfXuHVIlFp1X1u2Med2_AL4lzej8EifTBw_003D_003D(), 
			_ => throw new InvalidOperationException(), 
		};
		_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D obj = new _0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D();
		obj._0023_003DzBGdDQOw_INWgxm_K091ViE8d5B7H7_X_0024gA2NQZA_003D(num);
		_0023_003Dz9jrlnWk_003D._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(obj);
	}

	[DebuggerNonUserCode]
	private MethodBase _0023_003DzRt6UVedmJJGarSZZFciXi_0024twqllky4LsnA_003D_003D(int _0023_003Dz9jrlnWk_003D)
	{
		_0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D _0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D2 = _0023_003Dz_kQ6vjzn2xXdxKzdPsJwstuDR14y(_0023_003Dz9jrlnWk_003D);
		MethodBase result = _0023_003DzuQitVVfPXhnVfEemX_NzMcY_riCF0mqY_0024dIcN_0024w_003D(_0023_003Dz9jrlnWk_003D, _0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D2);
		_0023_003DzRDsD2tmbbWicD3F3bHfTv5w75vMCZrFqbQ_003D_003D(result);
		return result;
	}

	private static void _0023_003Dzfs61Zc4ONKwCwYJAZmRkuhKaXGL64Hb_3w_003D_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzzTvE7jftOU_0024XBv6lbA_003D_003D(_0023_003Dz9jrlnWk_003D: false);
	}

	private static void _0023_003Dz7F7iqraub_0024O3ZK5xAJxiO7LH96_0024QVm2Bj_0024OTpa4_003D(ILGenerator _0023_003Dz9jrlnWk_003D, int _0023_003DzBxpHhQ0_003D)
	{
		switch (_0023_003DzBxpHhQ0_003D)
		{
		case -1:
			_0023_003Dz9jrlnWk_003D.Emit(OpCodes.Ldc_I4_M1);
			return;
		case 0:
			_0023_003Dz9jrlnWk_003D.Emit(OpCodes.Ldc_I4_0);
			return;
		case 1:
			_0023_003Dz9jrlnWk_003D.Emit(OpCodes.Ldc_I4_1);
			return;
		case 2:
			_0023_003Dz9jrlnWk_003D.Emit(OpCodes.Ldc_I4_2);
			return;
		case 3:
			_0023_003Dz9jrlnWk_003D.Emit(OpCodes.Ldc_I4_3);
			return;
		case 4:
			_0023_003Dz9jrlnWk_003D.Emit(OpCodes.Ldc_I4_4);
			return;
		case 5:
			_0023_003Dz9jrlnWk_003D.Emit(OpCodes.Ldc_I4_5);
			return;
		case 6:
			_0023_003Dz9jrlnWk_003D.Emit(OpCodes.Ldc_I4_6);
			return;
		case 7:
			_0023_003Dz9jrlnWk_003D.Emit(OpCodes.Ldc_I4_7);
			return;
		case 8:
			_0023_003Dz9jrlnWk_003D.Emit(OpCodes.Ldc_I4_8);
			return;
		}
		if (_0023_003DzBxpHhQ0_003D > -129 && _0023_003DzBxpHhQ0_003D < 128)
		{
			_0023_003Dz9jrlnWk_003D.Emit(OpCodes.Ldc_I4_S, (sbyte)_0023_003DzBxpHhQ0_003D);
		}
		else
		{
			_0023_003Dz9jrlnWk_003D.Emit(OpCodes.Ldc_I4, _0023_003DzBxpHhQ0_003D);
		}
	}

	private object _0023_003DzQ8LhpS1xxZOzfa_xwe0pkshtYH921DtIc7CslMVRHi4c(object[] _0023_003Dz9jrlnWk_003D, Type[] _0023_003DzBxpHhQ0_003D, Type[] _0023_003Dztgqm2r4_003D, object[] _0023_003DzzKDx05I_003D)
	{
		_0023_003DzleLKu58kbCcompJKcc4ctAk_003D();
		if (_0023_003Dz9jrlnWk_003D == null)
		{
			_0023_003Dz9jrlnWk_003D = global::_0023_003DqpATz8D_jE9d2tWHW_0024puEspyPL8xe_00246SUvCwrSedEg08_003D<object>._0023_003Dz9jrlnWk_003D;
		}
		this.m__0023_003DzgqvoyJk_003D = _0023_003DzzKDx05I_003D;
		_0023_003DzS5oUG4s_003D = _0023_003DzBxpHhQ0_003D;
		this.m__0023_003DzzKDx05I_003D = _0023_003Dztgqm2r4_003D;
		_0023_003DzWn08U5s_003D = _0023_003DzRyEZD1c9faTP_0024PxBM_mIybsxsfhDsqr5J9hMFWM_003D(_0023_003Dz9jrlnWk_003D);
		this.m__0023_003DziiEv3wQ_003D = _0023_003DzAQlRPLKeFJ2KprKsiPmRoa4HNWOXCbdDbN6qcBw_003D();
		try
		{
			_0023_003DqtFN_00241TjdaenuCmn9GBmqpoZ3gp2tHyBL0X9WMKdAUQk_003D _0023_003DqtFN_00241TjdaenuCmn9GBmqpoZ3gp2tHyBL0X9WMKdAUQk_003D2 = new _0023_003DqtFN_00241TjdaenuCmn9GBmqpoZ3gp2tHyBL0X9WMKdAUQk_003D(this.m__0023_003DzoEGLyuM_003D);
			try
			{
				using (_0023_003DzLi0XoCY_003D = new _0023_003DqSrxlws3SuprWxrjyHO1juxJFrTNvlF8gj_KAkF067yA_003D(_0023_003DqtFN_00241TjdaenuCmn9GBmqpoZ3gp2tHyBL0X9WMKdAUQk_003D2))
				{
					_0023_003DziDh2WHE_003D = (uint)_0023_003DqtFN_00241TjdaenuCmn9GBmqpoZ3gp2tHyBL0X9WMKdAUQk_003D2._0023_003Dz0O0V9w8_kQ0BXR7pipw_TeE_0024mwds2QcLM1eCMLEXnNNrcyRNFhfAZq8nMBVy5R5U21yPM54QEfEcLaoIAYOkj80_003D();
					_0023_003DzwETOsNI_003D = false;
					_0023_003DzgtUi_7A_003D = null;
					this.m__0023_003DzAndD6oU_003D = 0u;
					_0023_003DzMP6kxrk_003D = 0u;
					_0023_003Dz5YH2PaowZRQpuvM2FluL6E4_003D();
					_0023_003DzEybOQ_7Jh2tKs9B22pwb8swkxukzO6kvAnN8bkYeK8K5();
				}
			}
			finally
			{
				((IDisposable)_0023_003DqtFN_00241TjdaenuCmn9GBmqpoZ3gp2tHyBL0X9WMKdAUQk_003D2).Dispose();
			}
			Type type = _0023_003Dz9_Z5EhGFT4yzpTmOPYjfhZOeNABFeUtCmZ_KeWA_003D(m__0023_003DzaTyQZ6E_003D._0023_003Dz4SnewdlRHKMKBUE_0024QZQUmfm_FxaNJj9Jag_003D_003D(), _0023_003DzBxpHhQ0_003D: false);
			if (type != _0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D.m__0023_003Dz9I8ZVlc_003D && _0023_003DztbaWdh6KnRI_6XZXde_Y5Jj1NOinKwzBVCMYMgM_003D())
			{
				return _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D._0023_003DzCysyOfnrUQB5WqShWAIL_0024X4XGCe9eW67eVeg6HY_003D(null, type)._0023_003DzAPlrN6aYwAg5F1LxHYbv_0024wOBB_0024afgbz6XKGgvF_0024QaP3F7Nvwy8DGE80Q1m63nNv21_00240QxzxHCeC2PtE3mw_003D_003D(_0023_003DzrQFXD5oP9hinX0g4gA_003D_003D())._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D();
			}
			return null;
		}
		finally
		{
			for (int i = 0; i < m__0023_003DzaTyQZ6E_003D._0023_003DzPFkh31N3VRlmNc8nf2IWmYdUiYAF().Length; i++)
			{
				_0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024h3HXCPh1byVa5xQgwlyKcE_003D _0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024h3HXCPh1byVa5xQgwlyKcE_003D2 = m__0023_003DzaTyQZ6E_003D._0023_003DzPFkh31N3VRlmNc8nf2IWmYdUiYAF()[i];
				if (_0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024h3HXCPh1byVa5xQgwlyKcE_003D2._0023_003DzChnAIIUM6aZbWvxSX_9gOLnhG0Pj0ORlLw_003D_003D())
				{
					_0023_003DqFNN_kH3_Aic_0024vq9s6N7BcnqdUOw1mJpa1yIMZD1vbOQ_003D _0023_003DqFNN_kH3_Aic_0024vq9s6N7BcnqdUOw1mJpa1yIMZD1vbOQ_003D2 = (_0023_003DqFNN_kH3_Aic_0024vq9s6N7BcnqdUOw1mJpa1yIMZD1vbOQ_003D)_0023_003DzWn08U5s_003D[i];
					Type type2 = _0023_003Dz9_Z5EhGFT4yzpTmOPYjfhZOeNABFeUtCmZ_KeWA_003D(_0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024h3HXCPh1byVa5xQgwlyKcE_003D2._0023_003DzBLbiSG4pMsCq5QXcv4IAsSJsqlAkD0L7ST9ge5Ogka39(), _0023_003DzBxpHhQ0_003D: false);
					_0023_003Dz9jrlnWk_003D[i] = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D._0023_003DzCysyOfnrUQB5WqShWAIL_0024X4XGCe9eW67eVeg6HY_003D(null, type2.GetElementType())._0023_003DzAPlrN6aYwAg5F1LxHYbv_0024wOBB_0024afgbz6XKGgvF_0024QaP3F7Nvwy8DGE80Q1m63nNv21_00240QxzxHCeC2PtE3mw_003D_003D(_0023_003DqFNN_kH3_Aic_0024vq9s6N7BcnqdUOw1mJpa1yIMZD1vbOQ_003D2._0023_003DziVOWcx_00243zo4_0iYh_0024lucKGuN0vuo())._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D();
				}
			}
			this.m__0023_003DzgqvoyJk_003D = null;
			_0023_003DzWn08U5s_003D = null;
			this.m__0023_003DziiEv3wQ_003D = null;
		}
	}

	private static void _0023_003Dz6nneRHMp0xPVkJYRhsJoUZmAa_pC05xKbIhq1AU_003D(ILGenerator _0023_003Dz9jrlnWk_003D, Type _0023_003DzBxpHhQ0_003D)
	{
		if (!(_0023_003DzBxpHhQ0_003D == _0023_003DqqSQMR5x0Ss3kUZAkPHTc7q6IdaUzR_0024BTopvbTI_0024P7DA_003D._0023_003Dz9jrlnWk_003D))
		{
			_0023_003Dz9jrlnWk_003D.Emit(OpCodes.Castclass, _0023_003DzBxpHhQ0_003D);
		}
	}

	private static void _0023_003DzgIg_mmc6IjmjNfyxC7AVuY8_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzQQadI1un9jbZYMS7HdWcDB_Om0ngXN8ke3zjToc_003D(((_0023_003DqIC7wdNmeVLrKuHjiCL8jtht_0024ogaMGYTl_vFxiqwcERQ_003D)_0023_003DzBxpHhQ0_003D)._0023_003Dz3fdyocpuocHKnMPBAP0IP10_003D());
	}

	private Type _0023_003Dz9_Z5EhGFT4yzpTmOPYjfhZOeNABFeUtCmZ_KeWA_003D(int _0023_003Dz9jrlnWk_003D, bool _0023_003DzBxpHhQ0_003D)
	{
		Type type;
		lock (_0023_003DzZpkUTwY_003D)
		{
			bool flag = true;
			if (flag && _0023_003DzZpkUTwY_003D.TryGetValue(_0023_003Dz9jrlnWk_003D, out var value))
			{
				type = (Type)value;
			}
			else
			{
				_0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D _0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D2 = _0023_003Dz_kQ6vjzn2xXdxKzdPsJwstuDR14y(_0023_003Dz9jrlnWk_003D);
				type = _0023_003Dzb4fEknSH0DX3Il_0024eASrQlFwF1j5gkzTROg4mgLg_003D(_0023_003Dz9jrlnWk_003D, _0023_003Dq28BnJJozNWuwzNLL0LIeNRt3wSSR_hfSW_y1VXgHr_E_003D2, ref flag, _0023_003DzBxpHhQ0_003D);
				if (flag)
				{
					_0023_003DzZpkUTwY_003D.Add(_0023_003Dz9jrlnWk_003D, type);
				}
			}
		}
		if (_0023_003DzBxpHhQ0_003D)
		{
			_0023_003DzRDsD2tmbbWicD3F3bHfTv5w75vMCZrFqbQ_003D_003D(type);
		}
		return type;
	}

	private static void _0023_003DzVY4ABhSQxhMABRwKJmuJekB1DzqDuCr4_0024y49iN5KOUAK(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		_0023_003Dz9jrlnWk_003D._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(checked(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() switch
		{
			1 => (ushort)(uint)((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D(), 
			13 => (ushort)(ulong)((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG(), 
			19 => (ushort)Convert.ToUInt64(((_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D()), 
			8 => (ushort)((_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzCfXuHVIlFp1X1u2Med2_AL4lzej8EifTBw_003D_003D(), 
			0 => (IntPtr.Size != 4) ? ((ushort)(ulong)(long)((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk()) : ((ushort)(uint)(int)((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk()), 
			_ => throw new InvalidOperationException(), 
		})));
	}

	private static void _0023_003Dz2DddDoSyJUoJrdDsHkyni_0024un7RtPAaLc2w_003D_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		MethodBase methodBase = ((_0023_003DqZOgqBgNtgFzdL0x3JA7LxzDeXh41TKRK3WDZXmMsiIQ_003D)_0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D())._0023_003DzV_0024AWvPoawZAhOMF2e6wIwZo_003D();
		_0023_003Dz9jrlnWk_003D._0023_003Dz3Kd3rvERK8HcEu6iFYdwh0o_003D(methodBase, _0023_003DzBxpHhQ0_003D: false);
	}

	private static _0023_003Dq9cxJfzt6tx3_00245xLDM_0024HAnrEHrErdbG4Q2r8aUaxhhjk_003D _0023_003DzPh_0024mk5GoEaUtEvshztgcA9SPyTYC(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D obj = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3 = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		if (obj._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() != 13)
		{
			throw new InvalidOperationException();
		}
		long num = ((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)obj)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG();
		int num2 = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D();
		if (num2 != 7 && num2 != 9)
		{
			throw new InvalidOperationException();
		}
		byte[] array = _0023_003DqN_Lzrpin_XrYR283pJ4HqqFVXOIqB9OF64C2AZJAFII_003D._0023_003DzngWw6xCDnvqC9f09N73y9vUdquBK(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D());
		if (_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() != 1)
		{
			throw new InvalidOperationException();
		}
		int num3 = ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D();
		_0023_003Dq9cxJfzt6tx3_00245xLDM_0024HAnrEHrErdbG4Q2r8aUaxhhjk_003D obj2 = new _0023_003Dq9cxJfzt6tx3_00245xLDM_0024HAnrEHrErdbG4Q2r8aUaxhhjk_003D();
		obj2._0023_003DzSvur5fYzuS25t75x_IG3edw_003D(num3);
		obj2._0023_003DzDnFaL7yUucI6iimjN8haQ4sVHkOe(array);
		obj2._0023_003DzscZ_XMeuiTzDWU8OEE_QMw8tnWg4(num);
		return obj2;
	}

	private static void _0023_003Dz2aq51zxgZSSbKM63B2r_7WlcmjEoRl6l_0024w_003D_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		_0023_003Dz9jrlnWk_003D._0023_003DzzUdLVh6RcJ0qp5eRPoW5he0ADnSX(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D());
	}

	private void _0023_003DzTSnMxIcnPTKi_0024SHfx9IetV0mvE0F()
	{
		if (this.m__0023_003Dz9jrlnWk_003D.Count == 0)
		{
			if (this.m__0023_003Dz2X8kE24_003D)
			{
				_0023_003DzzUdLVh6RcJ0qp5eRPoW5he0ADnSX(_0023_003DzNl32EAo_003D);
			}
			return;
		}
		_0023_003Dz3iPku7s_003D _0023_003Dz3iPku7s_003D2 = this.m__0023_003Dz9jrlnWk_003D.Pop();
		if (_0023_003Dz3iPku7s_003D2._0023_003DzhfIVm8CotdQwMSGVPJEfHgQ_003D() != null)
		{
			_0023_003DqcjmfsaS6dKPuf2kSTqJKWfH_rgkc03gEAn6QEKAtpbA_003D obj = new _0023_003DqcjmfsaS6dKPuf2kSTqJKWfH_rgkc03gEAn6QEKAtpbA_003D();
			obj._0023_003Dz2BZRDdyC830I_0024QHE7EDcos6_0024Cr2mmsVt68BiG1k4GjsEE14zjUq6ALmAJpU1ti5_3KNno7BueiVKdd3zdlo5X6k_003D(_0023_003Dz3iPku7s_003D2._0023_003DzhfIVm8CotdQwMSGVPJEfHgQ_003D());
			_0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(obj);
		}
		else
		{
			_0023_003Dz5YH2PaowZRQpuvM2FluL6E4_003D();
		}
		_0023_003Dz9r__0024YTGu_0024iN2qFjqe6k1t7s_003D(_0023_003Dz3iPku7s_003D2._0023_003DzO3smQpSarT6vqtUaiMUzV3QK46jU());
	}

	private static void _0023_003DzOYLvYnJBCJzEyI9AQud2tXDNy_KJliMG3A_003D_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D2 = (_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003DzBxpHhQ0_003D;
		MethodBase methodBase = _0023_003Dz9jrlnWk_003D._0023_003DzRt6UVedmJJGarSZZFciXi_0024twqllky4LsnA_003D_003D(_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D2._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D());
		_0023_003Dz9jrlnWk_003D._0023_003Dz3Kd3rvERK8HcEu6iFYdwh0o_003D(methodBase, _0023_003DzBxpHhQ0_003D: false);
	}

	private static void _0023_003DzHXDGHRVrPqrxcpLIM7LlWHoG_0024srfa7F2d_OuFbg_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		_0023_003Dz9jrlnWk_003D._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() switch
		{
			1 => ((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D(), 
			13 => (int)checked((uint)(ulong)((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG()), 
			19 => (int)checked((uint)Convert.ToUInt64(((_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D())), 
			8 => (int)checked((uint)((_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzCfXuHVIlFp1X1u2Med2_AL4lzej8EifTBw_003D_003D()), 
			0 => (IntPtr.Size != 4) ? ((int)checked((uint)(ulong)(long)((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk())) : ((int)((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk()), 
			_ => throw new InvalidOperationException(), 
		}));
	}

	private void _0023_003DzEAO11fx6tMV7coCxBkB8KpJ9e37fAWJxyG_OLJik0M27(_0023_003DqaEtT9DoRRoUP_0024LS5u4B6AojK4YaTqiLM3Vc605IaRGE_003D _0023_003Dz9jrlnWk_003D)
	{
		if (_0023_003Dzn7pbC1GD4QYfQd5KWDAQ6flUbSqtwoAqUM7ydik_003D() && !m__0023_003DzaTyQZ6E_003D._0023_003DzghS_eb9eUC6u4vM30FyEKH1J_rdGVNlGcYMqXXUZ2TCX() && _0023_003Dz9jrlnWk_003D._0023_003DzghS_eb9eUC6u4vM30FyEKH1J_rdGVNlGcYMqXXUZ2TCX() && !_0023_003Dz9jrlnWk_003D._0023_003DzE_0024zlmUbXhdlhfmUYi3VOmeBtKntN())
		{
			string text = _0023_003Dza3Vg0pbdAn80NfoL4a4_NphXc70V(_0023_003Dz9jrlnWk_003D);
			throw _0023_003DzfE30YNyI_f3LeZRtY0ALj480DwZAzmMJ5y_0024sIbPs4W2n(_0023_003Dza3Vg0pbdAn80NfoL4a4_NphXc70V(m__0023_003DzaTyQZ6E_003D), text);
		}
	}

	private object _0023_003DzsOJ6TahPfKuexMbKFEzmdyoIYrB0j9210g_003D_003D(int _0023_003Dz9jrlnWk_003D)
	{
		switch (_0023_003Dq9cxJfzt6tx3_00245xLDM_0024HAngL4hanGG81_0024uBOEcFM6GMA_003D._0023_003DzGJ94mstZVNqydNx_00244l7_0024OLwF03Hc(_0023_003Dz9jrlnWk_003D))
		{
		case 16777216:
		case 33554432:
		case 452984832:
			return this.m__0023_003DzJ6W8874_003D.ModuleHandle.ResolveTypeHandle(_0023_003Dz9jrlnWk_003D);
		case 67108864:
			return this.m__0023_003DzJ6W8874_003D.ModuleHandle.ResolveFieldHandle(_0023_003Dz9jrlnWk_003D);
		case 100663296:
		case 721420288:
			return this.m__0023_003DzJ6W8874_003D.ModuleHandle.ResolveMethodHandle(_0023_003Dz9jrlnWk_003D);
		case 167772160:
			try
			{
				return this.m__0023_003DzJ6W8874_003D.ModuleHandle.ResolveFieldHandle(_0023_003Dz9jrlnWk_003D);
			}
			catch
			{
				try
				{
					return this.m__0023_003DzJ6W8874_003D.ModuleHandle.ResolveMethodHandle(_0023_003Dz9jrlnWk_003D);
				}
				catch
				{
					throw new InvalidOperationException();
				}
			}
		default:
			throw new InvalidOperationException();
		}
	}

	private static void _0023_003DzPN_0024B9mzDGLqJtmIs_0024MTmICZZD1ya(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzpU_n7PfnyRyJ1anIgJrsjiSffFPi(3);
	}

	private object _0023_003Dz6kYIsK1ypjf7EBWahwpDMjFtihx3FdF8RvnWYV7gMyYG(Stream _0023_003Dz9jrlnWk_003D, int _0023_003DzBxpHhQ0_003D, object[] _0023_003Dztgqm2r4_003D, Type[] _0023_003DzzKDx05I_003D, Type[] _0023_003Dz3iPku7s_003D, object[] _0023_003Dz2X8kE24_003D)
	{
		this.m__0023_003DzJGsRSpg_003D = _0023_003Dz9jrlnWk_003D;
		_0023_003DzjUe2x_0024RVYtBlxOXpXmBPPvW3h7Kh(_0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D, null);
		return _0023_003DzQ8LhpS1xxZOzfa_xwe0pkshtYH921DtIc7CslMVRHi4c(_0023_003Dztgqm2r4_003D, _0023_003DzzKDx05I_003D, _0023_003Dz3iPku7s_003D, _0023_003Dz2X8kE24_003D);
	}

	private void _0023_003Dzvg4CefujOdISFD_Gu2MjrJce5AXn(bool _0023_003Dz9jrlnWk_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		_0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(new _0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() switch
		{
			1 => (!_0023_003Dz9jrlnWk_003D) ? ((uint)((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D()) : checked((uint)((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D()), 
			13 => (!_0023_003Dz9jrlnWk_003D) ? ((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG() : ((long)checked((ulong)((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG())), 
			19 => (long)((!_0023_003Dz9jrlnWk_003D) ? Convert.ToUInt64(((_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D()) : Convert.ToUInt64(((_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D())), 
			8 => (long)((!_0023_003Dz9jrlnWk_003D) ? ((ulong)((_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzCfXuHVIlFp1X1u2Med2_AL4lzej8EifTBw_003D_003D()) : checked((ulong)((_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzCfXuHVIlFp1X1u2Med2_AL4lzej8EifTBw_003D_003D())), 
			0 => (IntPtr.Size != 4) ? ((!_0023_003Dz9jrlnWk_003D) ? ((long)((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk()) : ((long)checked((ulong)(long)((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk()))) : ((!_0023_003Dz9jrlnWk_003D) ? ((uint)(int)((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk()) : checked((uint)(int)((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk())), 
			20 => (long)((UIntPtr.Size != 4) ? ((!_0023_003Dz9jrlnWk_003D) ? ((ulong)((_0023_003DqVEj3J19zkgEyU6VFymBz6riyi6CxZMJEjhA0KZ2nLKw_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzZlwwYywinAe9h_2ss_0024Wn4RsajDr79HfGCg_003D_003D()) : ((ulong)((_0023_003DqVEj3J19zkgEyU6VFymBz6riyi6CxZMJEjhA0KZ2nLKw_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzZlwwYywinAe9h_2ss_0024Wn4RsajDr79HfGCg_003D_003D())) : ((!_0023_003Dz9jrlnWk_003D) ? ((uint)((_0023_003DqVEj3J19zkgEyU6VFymBz6riyi6CxZMJEjhA0KZ2nLKw_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzZlwwYywinAe9h_2ss_0024Wn4RsajDr79HfGCg_003D_003D()) : ((uint)((_0023_003DqVEj3J19zkgEyU6VFymBz6riyi6CxZMJEjhA0KZ2nLKw_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzZlwwYywinAe9h_2ss_0024Wn4RsajDr79HfGCg_003D_003D()))), 
			_ => throw new InvalidOperationException(), 
		}));
	}

	private void _0023_003DzpclEbtZt0t_0024JhkHFJukZPrU_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dz9jrlnWk_003D)
	{
		_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D2 = (_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dz9jrlnWk_003D;
		MethodBase methodBase = _0023_003DzRt6UVedmJJGarSZZFciXi_0024twqllky4LsnA_003D_003D(_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D2._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D());
		if (_0023_003Dzn6_Dl38_003D != null)
		{
			ParameterInfo[] parameters = methodBase.GetParameters();
			Type[] array = new Type[parameters.Length];
			int num = 0;
			ParameterInfo[] array2 = parameters;
			foreach (ParameterInfo parameterInfo in array2)
			{
				array[num++] = parameterInfo.ParameterType;
			}
			MethodInfo method = _0023_003Dzn6_Dl38_003D.GetMethod(methodBase.Name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.InvokeMethod | BindingFlags.GetProperty | BindingFlags.SetProperty, null, array, null);
			if (method != null)
			{
				methodBase = method;
			}
			_0023_003Dzn6_Dl38_003D = null;
		}
		_0023_003Dz3Kd3rvERK8HcEu6iFYdwh0o_003D(methodBase, _0023_003DzBxpHhQ0_003D: true);
	}

	private static void _0023_003Dz4szJUi3IqDOq4Mean1EE1N7GatwCk07LylbIcSU_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzDvgKbbDxn0kp4Vzkd2w93ks_003D(_0023_003Dz9jrlnWk_003D: true);
	}

	private static void _0023_003Dzio_0024s9XAqcmjgBcdJ6TfEvpppLWlUWf5p_hCc4uI_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzwbI83bfoaDmYaZBDzj4leqo_003D(0);
	}

	private static void _0023_003Dztu0G4SJVS7XJlvPioLl5N_0024hk0IPeKGdSg1b2yDKtddn8(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		object obj = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D()._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D();
		long num = _0023_003Dz9jrlnWk_003D._0023_003Dz48d1zHJh3TOQKfAMFYN6p1CRbnL4();
		Array array = (Array)_0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D()._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D();
		Type elementType = array.GetType().GetElementType();
		if (elementType == typeof(long))
		{
			_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D._0023_003DzCysyOfnrUQB5WqShWAIL_0024X4XGCe9eW67eVeg6HY_003D(obj, typeof(long));
			((long[])array)[num] = (long)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D();
		}
		else if (elementType == typeof(ulong))
		{
			_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3 = _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D._0023_003DzCysyOfnrUQB5WqShWAIL_0024X4XGCe9eW67eVeg6HY_003D(obj, typeof(ulong));
			((ulong[])array)[num] = (ulong)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D3._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D();
		}
		else if (elementType.IsEnum)
		{
			_0023_003Dz9jrlnWk_003D._0023_003DzlUMFttjizmrsnJvpILZOQbCJdq_9(elementType, obj, num, array);
		}
		else
		{
			_0023_003Dz9jrlnWk_003D._0023_003DzlUMFttjizmrsnJvpILZOQbCJdq_9(typeof(long), obj, num, array);
		}
	}

	private static void _0023_003DzhPjf5Sdh0ulTgZ3rHP0uiStT3NEXgyPktA_003D_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzTSnMxIcnPTKi_0024SHfx9IetV0mvE0F();
	}

	private void _0023_003DzzTvE7jftOU_0024XBv6lbA_003D_003D(bool _0023_003Dz9jrlnWk_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		_0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() switch
		{
			1 => (!_0023_003Dz9jrlnWk_003D) ? ((byte)((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D()) : checked((byte)(uint)((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D()), 
			13 => (!_0023_003Dz9jrlnWk_003D) ? ((byte)((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG()) : checked((byte)(ulong)((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG()), 
			19 => (!_0023_003Dz9jrlnWk_003D) ? ((byte)Convert.ToUInt64(((_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D())) : checked((byte)Convert.ToUInt64(((_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D())), 
			8 => (!_0023_003Dz9jrlnWk_003D) ? ((byte)((_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzCfXuHVIlFp1X1u2Med2_AL4lzej8EifTBw_003D_003D()) : checked((byte)((_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzCfXuHVIlFp1X1u2Med2_AL4lzej8EifTBw_003D_003D()), 
			0 => (IntPtr.Size != 4) ? ((!_0023_003Dz9jrlnWk_003D) ? ((byte)(long)((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk()) : checked((byte)(ulong)(long)((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk())) : ((!_0023_003Dz9jrlnWk_003D) ? ((byte)(int)((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk()) : checked((byte)(int)((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk())), 
			20 => (UIntPtr.Size != 4) ? ((!_0023_003Dz9jrlnWk_003D) ? ((byte)(ulong)((_0023_003DqVEj3J19zkgEyU6VFymBz6riyi6CxZMJEjhA0KZ2nLKw_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzZlwwYywinAe9h_2ss_0024Wn4RsajDr79HfGCg_003D_003D()) : checked((byte)(ulong)((_0023_003DqVEj3J19zkgEyU6VFymBz6riyi6CxZMJEjhA0KZ2nLKw_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzZlwwYywinAe9h_2ss_0024Wn4RsajDr79HfGCg_003D_003D())) : ((!_0023_003Dz9jrlnWk_003D) ? ((byte)(uint)((_0023_003DqVEj3J19zkgEyU6VFymBz6riyi6CxZMJEjhA0KZ2nLKw_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzZlwwYywinAe9h_2ss_0024Wn4RsajDr79HfGCg_003D_003D()) : checked((byte)(uint)((_0023_003DqVEj3J19zkgEyU6VFymBz6riyi6CxZMJEjhA0KZ2nLKw_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzZlwwYywinAe9h_2ss_0024Wn4RsajDr79HfGCg_003D_003D())), 
			_ => throw new InvalidOperationException(), 
		}));
	}

	private static void _0023_003DzJhZiGTuookT3CPHjseDxO72k1jzCEJtZEnuX36_0024zIOyc(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		_0023_003Dz9jrlnWk_003D._0023_003DzGozGjjR_0024PRVeb_0024tL5IqjJNoIemPL(new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D(checked(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D() switch
		{
			1 => (short)(uint)((_0023_003DqJ75rpI46d2e8QXpNMN_0024n8VnAMhl_0024cRyZz9zehEDcBtc_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzaR2jdGT6veUULSXJohsMnZGY4_vaBigFfQ_003D_003D(), 
			13 => (short)(ulong)((_0023_003Dqnm1S8JiabN5PaFT5RW161IrdjX1FzLnIJQZ034iXss0_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzYSVbRc8vIkitiXaudj2HKWH42bFEXUM4Baada1l1VzwG(), 
			19 => (short)Convert.ToUInt64(((_0023_003DqTnc2yZaUcqEcx7uiqB96zmCJgUuqDvH3nyokSqKkybE_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzpOrgBty2iU39l1xh1atTj5g_003D()), 
			8 => (short)((_0023_003DqObQJ81mbIcVfep6ZFtyt_uqf7JNnZUm5z0HZXVOmnZg_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzCfXuHVIlFp1X1u2Med2_AL4lzej8EifTBw_003D_003D(), 
			0 => (IntPtr.Size != 4) ? ((short)(ulong)(long)((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk()) : ((short)(uint)(int)((_0023_003DqgLKG65nYMoFTixsWbeZ91c8mHhK3srCmRYX85oR7TUs_003D)_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2)._0023_003DzkQeIwfhmhgeDCFfNDXE4sp086bQk()), 
			_ => throw new InvalidOperationException(), 
		})));
	}

	private static void _0023_003DzcIA2_1gUPqzR6iw3FWhIisqwd82nfxKx4fozy4_UaKUy(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2 = _0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D();
		if (_0023_003Dz85ZnAjLw5GuUis_0024G0X_hQ3rZyzLji_2Y9G_l2yE_003D(_0023_003Dz9jrlnWk_003D._0023_003DzrQFXD5oP9hinX0g4gA_003D_003D(), _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D2))
		{
			uint num = ((_0023_003DqJFdrGiwz1aJICVkSTb_0024Zko9aS6iSwDcZdo9VS4Dkh_0024s_003D)_0023_003DzBxpHhQ0_003D)._0023_003DzxGjrL4iuhvogLPGFSdnVXdPvbKxem9P4HA_003D_003D();
			_0023_003Dz9jrlnWk_003D._0023_003Dz9r__0024YTGu_0024iN2qFjqe6k1t7s_003D(num);
		}
	}

	private void _0023_003DzbubspJfKxb0WjXbENdWdGRpLC4D3_0024Y9wrJukd1A_003D(_0023_003DzbSmUaeo_003D _0023_003Dz9jrlnWk_003D)
	{
		_0023_003DzLi0XoCY_003D = _0023_003Dz9jrlnWk_003D._0023_003DzBxpHhQ0_003D;
		_0023_003DzFQGDh5A_003D = _0023_003Dz9jrlnWk_003D._0023_003DzzKDx05I_003D;
	}

	private static bool _0023_003Dzn7pbC1GD4QYfQd5KWDAQ6flUbSqtwoAqUM7ydik_003D()
	{
		return false;
	}

	private static bool _0023_003DzhMaI5Ltf1_0024yc1b5n7pEBDRL7trQMcGFYQR1Kus5CdT1c(MethodBase _0023_003Dz9jrlnWk_003D)
	{
		ParameterInfo[] parameters = _0023_003Dz9jrlnWk_003D.GetParameters();
		for (int i = 0; i < parameters.Length; i++)
		{
			if (parameters[i].ParameterType.IsByRef)
			{
				return true;
			}
		}
		return false;
	}

	private static void _0023_003DzLPVppnbVBqNuXbHECTtOYzth42v9(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003Dzvg4CefujOdISFD_Gu2MjrJce5AXn(_0023_003Dz9jrlnWk_003D: false);
	}

	private static void _0023_003DzLhbSkYRWdqShAmUOwpcpKfc_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003Dzy4D_00248buHMHsvaKDXIg_003D_003D(7);
	}

	private static void _0023_003DzurnIJ9utY6G65c7jxx4Dtu4bKkRiqgk6Cw_003D_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DztqiIS5t19tn4D0pTuVrmqGw_003D(((_0023_003DqJFdrGiwz1aJICVkSTb_0024Zkh7zAYa9iZm47EqlnjrFUg4_003D)_0023_003DzBxpHhQ0_003D)._0023_003Dzi58Fb_0024k5T0u9_0024uYc9Q_003D_003D());
	}

	private static void _0023_003DzrJAYZef3ntu34L31tBN7Pe3NCn8WfmY760ktpNs_003D(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D _0023_003Dz9jrlnWk_003D, _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dz9jrlnWk_003D._0023_003DzQRfyZFRl4R_002477CTSiMe16CpBHDHSToTDKQ_003D_003D(_0023_003Dz9jrlnWk_003D: false);
	}

	[Conditional("DEBUG")]
	private void _0023_003DzRqxU8G2xeJ_0024Eck0NQiTb7DVIOHyK(object _0023_003Dz9jrlnWk_003D)
	{
	}

	private static bool _0023_003DzOupOLyU8m7hDuE5_JiPQQJw_003D(uint _0023_003Dz9jrlnWk_003D, uint _0023_003DzBxpHhQ0_003D, uint _0023_003Dztgqm2r4_003D)
	{
		if (_0023_003Dz9jrlnWk_003D >= _0023_003DzBxpHhQ0_003D)
		{
			return _0023_003Dz9jrlnWk_003D <= _0023_003DzBxpHhQ0_003D + _0023_003Dztgqm2r4_003D;
		}
		return false;
	}
}
