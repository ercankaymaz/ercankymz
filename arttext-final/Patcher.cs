using System;
using System.IO;
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Cil;

internal static class Patcher
{
    private const string MarbleType = "buCadCamResVer5.Marble.clsMarble";
    private const string OldMenuType = "buEyeBaseVer5.Forms.Marble.F_MarbleTextMenu";
    private const string OldVectorType = "buControls.Forms.WinControlForms.Drawings.F_VectorText";
    private const string NewStudioType = "CMDStoneCAM.ArtText.F_ArtTextStudio";

    public static int Main(string[] args)
    {
        try
        {
            if (args.Length != 2)
                throw new ArgumentException("Usage: Patcher.exe <merged.dll> <output.dll>");

            string input = Path.GetFullPath(args[0]);
            string output = Path.GetFullPath(args[1]);
            string dir = Path.GetDirectoryName(input) ?? Environment.CurrentDirectory;

            var resolver = new DefaultAssemblyResolver();
            resolver.AddSearchDirectory(dir);
            string deps = Path.Combine(dir, "deps");
            if (Directory.Exists(deps)) resolver.AddSearchDirectory(deps);

            var rp = new ReaderParameters { AssemblyResolver = resolver, ReadSymbols = false, InMemory = true };
            using (var asm = AssemblyDefinition.ReadAssembly(input, rp))
            {
                var module = asm.MainModule;
                var marble = module.Types.FirstOrDefault(t => t.FullName == MarbleType)
                    ?? throw new InvalidOperationException("clsMarble not found");
                var studio = module.Types.FirstOrDefault(t => t.FullName == NewStudioType)
                    ?? throw new InvalidOperationException("F_ArtTextStudio not merged");
                var cmd = marble.Methods.FirstOrDefault(m => m.Name == "cmdTextMenu" && m.HasBody)
                    ?? throw new InvalidOperationException("cmdTextMenu not found");

                var studioCtor = studio.Methods.FirstOrDefault(m => m.IsConstructor && !m.IsStatic && m.Parameters.Count == 0)
                    ?? throw new InvalidOperationException("F_ArtTextStudio ctor not found");
                var studioInit = studio.Methods.FirstOrDefault(m => m.Name == "Init" && !m.IsStatic && m.Parameters.Count == 0)
                    ?? throw new InvalidOperationException("F_ArtTextStudio.Init not found");

                var il = cmd.Body.GetILProcessor();
                var ins = cmd.Body.Instructions;

                // 1) Locate the legacy first menu initialization. It must stay allocated because
                // the rest of the original Marble pipeline reads its state, but it must never be shown.
                int menuInitIndex = FindCall(ins, "Init", OldMenuType);
                if (menuInitIndex < 0)
                    throw new InvalidOperationException("Legacy F_MarbleTextMenu.Init route not found");

                // Force the existing pipeline to the Font branch (enum value 0).
                var menuVar = cmd.Body.Variables.FirstOrDefault(v => v.VariableType.FullName == OldMenuType);
                // In this assembly frmTextMenu is normally a static field, not a local. Reuse the
                // exact load sequence immediately preceding the Init call, then store TextType.
                var textTypeField = ins.Select(x => x.Operand).OfType<FieldReference>()
                    .FirstOrDefault(f => f.Name == "TextType" && f.DeclaringType.FullName == OldMenuType);
                if (textTypeField == null)
                    throw new InvalidOperationException("F_MarbleTextMenu.TextType field reference not found");

                var initCall = ins[menuInitIndex];
                var receiverLoad = PreviousMeaningful(initCall.Previous);
                if (receiverLoad == null)
                    throw new InvalidOperationException("Cannot locate F_MarbleTextMenu receiver load");

                // Clone the receiver-producing instruction sequence. The decompiled target uses
                // ldsfld frmTextMenu directly before Init(); handle that deterministic shape.
                if (receiverLoad.OpCode.Code != Code.Ldsfld && receiverLoad.OpCode.Code != Code.Ldloc &&
                    receiverLoad.OpCode.Code != Code.Ldloc_0 && receiverLoad.OpCode.Code != Code.Ldloc_1 &&
                    receiverLoad.OpCode.Code != Code.Ldloc_2 && receiverLoad.OpCode.Code != Code.Ldloc_3 &&
                    receiverLoad.OpCode.Code != Code.Ldloc_S)
                    throw new InvalidOperationException("Unexpected menu receiver opcode: " + receiverLoad.OpCode);

                var clonedReceiver = CloneLoad(receiverLoad);
                il.InsertAfter(initCall, clonedReceiver);
                il.InsertAfter(clonedReceiver, Instruction.Create(OpCodes.Ldc_I4_0));
                il.InsertAfter(clonedReceiver.Next, Instruction.Create(OpCodes.Stfld, module.ImportReference(textTypeField)));

                // 2) Bypass the first legacy menu ShowDialog. We replace the first ShowDialog after
                // F_MarbleTextMenu.Init and before the vector editor construction with pop + OK.
                int vectorCtorIndexBefore = FindNewobj(ins, OldVectorType);
                if (vectorCtorIndexBefore < 0)
                    throw new InvalidOperationException("Legacy F_VectorText constructor not found");

                Instruction legacyShow = null;
                for (int i = menuInitIndex + 1; i < vectorCtorIndexBefore; i++)
                {
                    var mr = ins[i].Operand as MethodReference;
                    if (mr != null && mr.Name == "ShowDialog") { legacyShow = ins[i]; break; }
                }
                if (legacyShow == null)
                    throw new InvalidOperationException("Legacy first ShowDialog not found");
                legacyShow.OpCode = OpCodes.Pop;
                legacyShow.Operand = null;
                il.InsertAfter(legacyShow, Instruction.Create(OpCodes.Ldc_I4_1)); // DialogResult.OK

                // The source checks frmTextMenu.PropertiesForm.Result and returns. Since the legacy
                // window was intentionally not shown, neutralize only that first early return.
                Instruction earlyReturn = null;
                for (var p = legacyShow.Next; p != null; p = p.Next)
                {
                    if (p.OpCode.Code == Code.Newobj)
                    {
                        var mr = p.Operand as MethodReference;
                        if (mr != null && mr.DeclaringType.FullName == OldVectorType) break;
                    }
                    if (p.OpCode.Code == Code.Ret) { earlyReturn = p; break; }
                }
                if (earlyReturn == null)
                    throw new InvalidOperationException("Legacy first-menu result return not found");
                earlyReturn.OpCode = OpCodes.Nop;
                earlyReturn.Operand = null;

                // 3) Replace only the Font editor allocation with the new drop-in subclass.
                var vectorCtors = ins.Where(x => x.OpCode.Code == Code.Newobj)
                    .Where(x => ((MethodReference)x.Operand).DeclaringType.FullName == OldVectorType)
                    .ToList();
                if (vectorCtors.Count != 1)
                    throw new InvalidOperationException("Expected exactly one F_VectorText newobj, found " + vectorCtors.Count);
                vectorCtors[0].Operand = module.ImportReference(studioCtor);

                // 4) Route the corresponding Init() to the subclass. The local remains typed as
                // F_VectorText, so insert castclass to keep the IL verifier/JIT type-safe.
                var vectorInitCalls = ins.Where(x => (x.OpCode.Code == Code.Call || x.OpCode.Code == Code.Callvirt))
                    .Where(x => x.Operand is MethodReference)
                    .Where(x => ((MethodReference)x.Operand).Name == "Init" && ((MethodReference)x.Operand).DeclaringType.FullName == OldVectorType)
                    .ToList();
                if (vectorInitCalls.Count != 1)
                    throw new InvalidOperationException("Expected exactly one F_VectorText.Init call, found " + vectorInitCalls.Count);
                il.InsertBefore(vectorInitCalls[0], Instruction.Create(OpCodes.Castclass, module.ImportReference(studio)));
                vectorInitCalls[0].Operand = module.ImportReference(studioInit);

                cmd.Body.OptimizeMacros();

                Directory.CreateDirectory(Path.GetDirectoryName(output) ?? ".");
                asm.Write(output, new WriterParameters { WriteSymbols = false });
            }

            Validate(output);
            return 0;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("PATCH FAILED: " + ex);
            return 1;
        }
    }

    private static void Validate(string path)
    {
        using (var asm = AssemblyDefinition.ReadAssembly(path, new ReaderParameters { ReadSymbols = false }))
        {
            var module = asm.MainModule;
            var studio = module.Types.FirstOrDefault(t => t.FullName == NewStudioType)
                ?? throw new InvalidOperationException("VALIDATION: F_ArtTextStudio missing");
            var marble = module.Types.First(t => t.FullName == MarbleType);
            var cmd = marble.Methods.First(m => m.Name == "cmdTextMenu" && m.HasBody);

            int studioNew = cmd.Body.Instructions.Count(x => x.OpCode.Code == Code.Newobj &&
                x.Operand is MethodReference && ((MethodReference)x.Operand).DeclaringType.FullName == NewStudioType);
            int oldVectorNew = cmd.Body.Instructions.Count(x => x.OpCode.Code == Code.Newobj &&
                x.Operand is MethodReference && ((MethodReference)x.Operand).DeclaringType.FullName == OldVectorType);

            if (studioNew != 1) throw new InvalidOperationException("VALIDATION: studio newobj count=" + studioNew);
            if (oldVectorNew != 0) throw new InvalidOperationException("VALIDATION: old F_VectorText is still constructed");

            Console.WriteLine("VALIDATION PASS");
            Console.WriteLine("  F_ArtTextStudio present: YES");
            Console.WriteLine("  cmdTextMenu -> F_ArtTextStudio newobj: YES");
            Console.WriteLine("  cmdTextMenu -> old F_VectorText newobj: NO");
            Console.WriteLine("  output: " + path);
        }
    }

    private static int FindCall(Mono.Collections.Generic.Collection<Instruction> ins, string method, string declaringType)
    {
        for (int i = 0; i < ins.Count; i++)
        {
            if (ins[i].OpCode.Code != Code.Call && ins[i].OpCode.Code != Code.Callvirt) continue;
            var mr = ins[i].Operand as MethodReference;
            if (mr != null && mr.Name == method && mr.DeclaringType.FullName == declaringType) return i;
        }
        return -1;
    }

    private static int FindNewobj(Mono.Collections.Generic.Collection<Instruction> ins, string declaringType)
    {
        for (int i = 0; i < ins.Count; i++)
        {
            if (ins[i].OpCode.Code != Code.Newobj) continue;
            var mr = ins[i].Operand as MethodReference;
            if (mr != null && mr.DeclaringType.FullName == declaringType) return i;
        }
        return -1;
    }

    private static Instruction PreviousMeaningful(Instruction p)
    {
        while (p != null && p.OpCode.Code == Code.Nop) p = p.Previous;
        return p;
    }

    private static Instruction CloneLoad(Instruction i)
    {
        switch (i.OpCode.OperandType)
        {
            case OperandType.InlineField: return Instruction.Create(i.OpCode, (FieldReference)i.Operand);
            case OperandType.InlineVar:
            case OperandType.ShortInlineVar:
                return i.Operand is VariableDefinition
                    ? Instruction.Create(i.OpCode, (VariableDefinition)i.Operand)
                    : Instruction.Create(i.OpCode, (ParameterDefinition)i.Operand);
            default:
                // ldloc.0..3 have no operand.
                return Instruction.Create(i.OpCode);
        }
    }
}
