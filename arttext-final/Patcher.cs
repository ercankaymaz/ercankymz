using System;
using System.IO;
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Cil;

class Patcher
{
    const string Marble = "buCadCamResVer5.Marble.clsMarble";
    const string Menu = "buEyeBaseVer5.Forms.Marble.F_MarbleTextMenu";
    const string Vector = "buControls.Forms.WinControlForms.Drawings.F_VectorText";
    const string Studio = "CMDStoneCAM.ArtText.F_ArtTextStudio";

    static int Main(string[] a)
    {
        try
        {
            if (a.Length != 2) throw new Exception("input output required");
            var rp = new ReaderParameters { InMemory = true };
            using (var asm = AssemblyDefinition.ReadAssembly(a[0], rp))
            {
                var m = asm.MainModule;
                var cls = m.Types.Single(t => t.FullName == Marble);
                var studio = m.Types.Single(t => t.FullName == Studio);
                var cmd = cls.Methods.Single(x => x.Name == "cmdTextMenu" && x.HasBody);
                var ctor = studio.Methods.Single(x => x.IsConstructor && !x.IsStatic && x.Parameters.Count == 0);
                var initNew = studio.Methods.Single(x => x.Name == "Init" && !x.IsStatic && x.Parameters.Count == 0);
                var il = cmd.Body.GetILProcessor();
                var ins = cmd.Body.Instructions;

                var menuInit = ins.FirstOrDefault(x => CallIs(x, Menu, "Init"));
                if (menuInit == null) throw new Exception("menu init missing");
                var textType = ins.Select(x => x.Operand).OfType<FieldReference>().FirstOrDefault(x => x.Name == "TextType" && x.DeclaringType.FullName == Menu);
                if (textType == null) throw new Exception("TextType ref missing");
                var load = menuInit.Previous;
                while (load != null && load.OpCode.Code == Code.Nop) load = load.Previous;
                if (load == null || load.OpCode.Code != Code.Ldsfld) throw new Exception("menu load shape mismatch");
                var l1 = Instruction.Create(OpCodes.Ldsfld, (FieldReference)load.Operand);
                var l2 = Instruction.Create(OpCodes.Ldc_I4_0);
                var l3 = Instruction.Create(OpCodes.Stfld, m.ImportReference(textType));
                il.InsertAfter(menuInit, l1); il.InsertAfter(l1, l2); il.InsertAfter(l2, l3);

                var oldNew = ins.FirstOrDefault(x => x.OpCode.Code == Code.Newobj && x.Operand is MethodReference && ((MethodReference)x.Operand).DeclaringType.FullName == Vector);
                if (oldNew == null) throw new Exception("vector ctor missing");
                var firstDialog = menuInit.Next;
                while (firstDialog != null && firstDialog != oldNew)
                {
                    var mr = firstDialog.Operand as MethodReference;
                    if (mr != null && mr.Name == "ShowDialog") break;
                    firstDialog = firstDialog.Next;
                }
                if (firstDialog == null || firstDialog == oldNew) throw new Exception("first dialog missing");
                firstDialog.OpCode = OpCodes.Pop; firstDialog.Operand = null;
                il.InsertAfter(firstDialog, Instruction.Create(OpCodes.Ldc_I4_1));

                var ret = firstDialog.Next;
                while (ret != null && ret != oldNew && ret.OpCode.Code != Code.Ret) ret = ret.Next;
                if (ret == null || ret == oldNew) throw new Exception("first result return missing");
                ret.OpCode = OpCodes.Nop; ret.Operand = null;

                var news = ins.Where(x => x.OpCode.Code == Code.Newobj && x.Operand is MethodReference && ((MethodReference)x.Operand).DeclaringType.FullName == Vector).ToList();
                if (news.Count != 1) throw new Exception("vector new count=" + news.Count);
                news[0].Operand = m.ImportReference(ctor);

                var inits = ins.Where(x => CallIs(x, Vector, "Init")).ToList();
                if (inits.Count != 1) throw new Exception("vector init count=" + inits.Count);
                il.InsertBefore(inits[0], Instruction.Create(OpCodes.Castclass, m.ImportReference(studio)));
                inits[0].Operand = m.ImportReference(initNew);

                asm.Write(a[1]);
            }
            using (var v = AssemblyDefinition.ReadAssembly(a[1]))
            {
                var m = v.MainModule;
                if (!m.Types.Any(t => t.FullName == Studio)) throw new Exception("studio type absent");
                var cmd = m.Types.Single(t => t.FullName == Marble).Methods.Single(x => x.Name == "cmdTextMenu" && x.HasBody);
                int sn = cmd.Body.Instructions.Count(x => x.OpCode.Code == Code.Newobj && x.Operand is MethodReference && ((MethodReference)x.Operand).DeclaringType.FullName == Studio);
                int ov = cmd.Body.Instructions.Count(x => x.OpCode.Code == Code.Newobj && x.Operand is MethodReference && ((MethodReference)x.Operand).DeclaringType.FullName == Vector);
                if (sn != 1 || ov != 0) throw new Exception("route check failed studio=" + sn + " old=" + ov);
                Console.WriteLine("ARTTEXT ROUTE PASS");
            }
            return 0;
        }
        catch (Exception e) { Console.Error.WriteLine(e); return 1; }
    }

    static bool CallIs(Instruction i, string t, string n)
    {
        if (i.OpCode.Code != Code.Call && i.OpCode.Code != Code.Callvirt) return false;
        var m = i.Operand as MethodReference;
        return m != null && m.DeclaringType.FullName == t && m.Name == n;
    }
}
