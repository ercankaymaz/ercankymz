namespace devDept.Graphics;

public enum depthStencilStateType : long
{
	DepthTestOff = 0L,
	DepthTestLess = 786432L,
	DepthTestEqual = 819200L,
	DepthTestLessEqual = 851968L,
	DepthTestGreater = 884736L,
	DepthTestAlways = 917504L,
	DepthMaskFalse_DepthTestEqual = 557056L,
	DepthMaskFalse_DepthTestLessEqual = 589824L,
	DepthMaskFalse_DepthTestLess = 524288L,
	DepthMaskFalse_DepthTestGreater = 622592L,
	DepthTestLess_StencilOn_Func_Always_1_1_Op_Replace_Replace_Replace = 803456L,
	DepthTestLess_StencilOn_Func_Always_0_1_Op_Keep_Keep_Replace = 802984L,
	DepthTestLess_StencilOn_Func_Always_0xFF_0xFF_Op_Keep_Keep_Replace = 804136L,
	DepthTestOff_StencilOn_Func_Always_1_1_Op_Replace_Replace_Replace = 180864L,
	DepthTestOff_StencilOn_Func_Always_0_0_Op_Keep_Keep_Increment = 442412L,
	DepthTestOff_StencilOn_Func_Always_0_0_Op_Keep_Keep_Decrement = 442413L,
	DepthTestOn_StencilOn_Func_NotEqual_0_0xFF = 809216L,
	DepthTestOn_StencilOn_Func_Less_1_0xFF = 815872L,
	DepthTestOff_StencilOn_Func_Equal_1_1_Op_Keep_Keep_Keep = 19113L,
	DepthTestEqual_StencilOn_Func_Equal_1_1_Op_Keep_Keep_Keep = 838313L,
	DepthTestLess_StencilOn_Func_Equal_1_1_Op_Keep_Keep_Keep = 805545L,
	DepthTestLessEqual_StencilOn_Func_Equal_1_1_Op_Keep_Keep_Keep = 871081L,
	DepthTestOff_StencilOn_Func_Never_1_FF_Op_Invert_Keep_Keep = 21321L,
	DepthTestOff_StencilOn_Func_Never_1_FF_Op_Zero_Keep_Keep = 21353L,
	DepthTestLess_StencilOn_Func_Never_1_FF_Op_Invert_Keep_Keep = 807753L,
	DepthTestOff_StencilOn_Func_NotEqual_1_FF_Op_Keep_keep_keep = 187177L
}
