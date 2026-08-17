using System;
using System.IO;
using System.Linq;
using System.Text;
using Mono.Cecil;
using Mono.Cecil.Cil;

internal static class PatchExternal
{
    private const string Marble = "buCadCamResVer5.Marble.clsMarble";
    private const string Vector = "buControls.Forms.WinControlForms.Drawings.F_VectorText";
    private const string Studio = "CMDStoneCAM.ArtText.F_ArtTextStudio";

    private static int Main(string[] args)
    {
        try
        {
            if (args.Length != 3)
                throw new ArgumentException("usage: PatchExternal <base.dll> <ArtTextHelper.dll> <output.dll>");

            string input = Path.GetFullPath(args[0]);
            string helperPath = Path.GetFullPath(args[1]);
            string output = Path.GetFullPath(args[2]);

            var resolver = new DefaultAssemblyResolver();
            resolver.AddSearchDirectory(Path.GetDirectoryName(input)!);
            resolver.AddSearchDirectory(Path.GetDirectoryName(helperPath)!);

            using var helper = AssemblyDefinition.ReadAssembly(helperPath, new ReaderParameters { AssemblyResolver = resolver, InMemory = true });
            var helperType = helper.MainModule.Types.Single(t => t.FullName == Studio);
            var helperCtor = helperType.Methods.Single(m => m.IsConstructor && !m.IsStatic && m.Parameters.Count == 0);
            var helperInit = helperType.Methods.Single(m => m.Name == "Init" && !m.IsStatic && m.Parameters.Count == 0);

            using var asm = AssemblyDefinition.ReadAssembly(input, new ReaderParameters { AssemblyResolver = resolver, InMemory = true });
            var module = asm.MainModule;
            var cls = module.Types.Single(t => t.FullName == Marble);
            var cmd = cls.Methods.Single(m => m.Name == "cmdTextMenu" && m.HasBody);

            // Snapshot every constructor IL before the route patch. This is used to prove
            // the patch does not touch registration/comment-lock constructor behavior.
            var ctorSnapshot = module.Types
                .SelectMany(AllTypes)
                .SelectMany(t => t.Methods.Where(m => m.IsConstructor && m.HasBody).Select(m => new { Key = t.FullName + "::" + m.FullName, Sig = MethodSignature(m) }))
                .ToDictionary(x => x.Key, x => x.Sig);

            var studioCtorRef = module.ImportReference(helperCtor);
            var studioInitRef = module.ImportReference(helperInit);
            var studioTypeRef = module.ImportReference(helperType);

            var body = cmd.Body;
            var il = body.GetILProcessor();
            var instructions = body.Instructions;

            var oldNew = instructions
                .Where(i => i.OpCode.Code == Code.Newobj && i.Operand is MethodReference)
                .Where(i => ((MethodReference)i.Operand).DeclaringType.FullName == Vector)
                .ToList();
            if (oldNew.Count != 1)
                throw new InvalidOperationException("expected one F_VectorText constructor in cmdTextMenu, found " + oldNew.Count);
            oldNew[0].Operand = studioCtorRef;

            var oldInit = instructions
                .Where(i => (i.OpCode.Code == Code.Call || i.OpCode.Code == Code.Callvirt) && i.Operand is MethodReference)
                .Where(i => {
                    var mr = (MethodReference)i.Operand;
                    return mr.DeclaringType.FullName == Vector && mr.Name == "Init" && mr.Parameters.Count == 0;
                })
                .ToList();
            if (oldInit.Count != 1)
                throw new InvalidOperationException("expected one F_VectorText.Init in cmdTextMenu, found " + oldInit.Count);

            il.InsertBefore(oldInit[0], Instruction.Create(OpCodes.Castclass, studioTypeRef));
            oldInit[0].Operand = studioInitRef;

            body.MaxStackSize = Math.Max(body.MaxStackSize, 8);
            Directory.CreateDirectory(Path.GetDirectoryName(output)!);
            asm.Write(output, new WriterParameters { WriteSymbols = false });

            using var verify = AssemblyDefinition.ReadAssembly(output, new ReaderParameters { AssemblyResolver = resolver, InMemory = true });
            var vm = verify.MainModule;
            var vcmd = vm.Types.Single(t => t.FullName == Marble).Methods.Single(m => m.Name == "cmdTextMenu" && m.HasBody);
            int studioNew = vcmd.Body.Instructions.Count(i => i.OpCode.Code == Code.Newobj && i.Operand is MethodReference mr && mr.DeclaringType.FullName == Studio);
            int vectorNew = vcmd.Body.Instructions.Count(i => i.OpCode.Code == Code.Newobj && i.Operand is MethodReference mr && mr.DeclaringType.FullName == Vector);
            int studioInit = vcmd.Body.Instructions.Count(i => (i.OpCode.Code == Code.Call || i.OpCode.Code == Code.Callvirt) && i.Operand is MethodReference mr && mr.DeclaringType.FullName == Studio && mr.Name == "Init");
            if (studioNew != 1 || vectorNew != 0 || studioInit != 1)
                throw new InvalidOperationException($"route validation failed: studioNew={studioNew}, vectorNew={vectorNew}, studioInit={studioInit}");

            var afterCtor = vm.Types
                .SelectMany(AllTypes)
                .SelectMany(t => t.Methods.Where(m => m.IsConstructor && m.HasBody).Select(m => new { Key = t.FullName + "::" + m.FullName, Sig = MethodSignature(m) }))
                .ToDictionary(x => x.Key, x => x.Sig);

            foreach (var kv in ctorSnapshot)
            {
                if (!afterCtor.TryGetValue(kv.Key, out var sig) || sig != kv.Value)
                    throw new InvalidOperationException("constructor IL changed unexpectedly: " + kv.Key);
            }

            Console.WriteLine("ARTTEXT_EXTERNAL_ROUTE_PASS");
            Console.WriteLine("CONSTRUCTOR_IL_PRESERVATION_PASS=" + ctorSnapshot.Count);
            Console.WriteLine("OUTPUT=" + output);
            return 0;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.ToString());
            return 1;
        }
    }

    private static System.Collections.Generic.IEnumerable<TypeDefinition> AllTypes(TypeDefinition t)
    {
        yield return t;
        foreach (var n in t.NestedTypes)
            foreach (var x in AllTypes(n))
                yield return x;
    }

    private static string MethodSignature(MethodDefinition m)
    {
        var sb = new StringBuilder();
        foreach (var i in m.Body.Instructions)
        {
            sb.Append(i.OpCode.Code).Append('|');
            if (i.Operand is MethodReference mr) sb.Append("M:").Append(mr.FullName);
            else if (i.Operand is FieldReference fr) sb.Append("F:").Append(fr.FullName);
            else if (i.Operand is TypeReference tr) sb.Append("T:").Append(tr.FullName);
            else if (i.Operand is Instruction target) sb.Append("B:").Append(target.Offset);
            else if (i.Operand is Instruction[] targets) sb.Append("S:").Append(string.Join(",", targets.Select(x => x.Offset)));
            else if (i.Operand != null) sb.Append(i.Operand);
            sb.Append(';');
        }
        return sb.ToString();
    }
}
