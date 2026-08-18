using System;
using System.Collections.Generic;
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
    private const string SystemType = "buCadCamResVer5.clsSystem";

    private static readonly HashSet<string> CommentLockedTypes = new HashSet<string>(StringComparer.Ordinal)
    {
        "buCadCamResVer5.clsFiles",
        "buCadCamResVer5.clsCommand",
        "buCadCamResVer5.clsSystem",
        "buCadCamResVer5.Quilting.clsQuilting",
        "buCadCamResVer5.Nesting.clsNesting"
    };

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

            // Every constructor except the five source-comment-locked constructors must stay bytecode-equivalent.
            var untouchedCtorSnapshot = module.Types
                .SelectMany(AllTypes)
                .Where(t => !CommentLockedTypes.Contains(t.FullName))
                .SelectMany(t => t.Methods.Where(m => m.IsConstructor && m.HasBody)
                    .Select(m => new { Key = t.FullName + "::" + m.FullName, Sig = MethodSignature(m) }))
                .ToDictionary(x => x.Key, x => x.Sig);

            PatchArtTextRoute(module, helperType, helperCtor, helperInit);

            int disabledGuards = 0;
            foreach (string typeName in CommentLockedTypes)
            {
                var type = module.Types.SelectMany(AllTypes).Single(t => t.FullName == typeName);
                foreach (var ctor in type.Methods.Where(m => m.IsConstructor && !m.IsStatic && m.HasBody))
                    disabledGuards += DisableRegistrationGuard(ctor);
            }

            Directory.CreateDirectory(Path.GetDirectoryName(output)!);
            asm.Write(output, new WriterParameters { WriteSymbols = false });

            using var verify = AssemblyDefinition.ReadAssembly(output, new ReaderParameters { AssemblyResolver = resolver, InMemory = true });
            var vm = verify.MainModule;

            VerifyArtTextRoute(vm);
            VerifyCommentLocks(vm);

            var afterUntouched = vm.Types
                .SelectMany(AllTypes)
                .Where(t => !CommentLockedTypes.Contains(t.FullName))
                .SelectMany(t => t.Methods.Where(m => m.IsConstructor && m.HasBody)
                    .Select(m => new { Key = t.FullName + "::" + m.FullName, Sig = MethodSignature(m) }))
                .ToDictionary(x => x.Key, x => x.Sig);

            foreach (var kv in untouchedCtorSnapshot)
            {
                if (!afterUntouched.TryGetValue(kv.Key, out var sig) || sig != kv.Value)
                    throw new InvalidOperationException("unrelated constructor IL changed unexpectedly: " + kv.Key);
            }

            Console.WriteLine("ARTTEXT_EXTERNAL_ROUTE_PASS");
            Console.WriteLine("COMMENT_LOCK_PASS=5_TYPES");
            Console.WriteLine("COMMENT_LOCK_ACTIVE_GUARDS_DISABLED=" + disabledGuards);
            Console.WriteLine("UNRELATED_CONSTRUCTOR_IL_PRESERVATION_PASS=" + untouchedCtorSnapshot.Count);
            Console.WriteLine("OUTPUT=" + output);
            return 0;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.ToString());
            return 1;
        }
    }

    private static void PatchArtTextRoute(ModuleDefinition module, TypeDefinition helperType, MethodDefinition helperCtor, MethodDefinition helperInit)
    {
        var cls = module.Types.Single(t => t.FullName == Marble);
        var cmd = cls.Methods.Single(m => m.Name == "cmdTextMenu" && m.HasBody);
        var body = cmd.Body;
        var il = body.GetILProcessor();
        var instructions = body.Instructions;

        int studioExisting = instructions.Count(i => i.OpCode.Code == Code.Newobj && i.Operand is MethodReference mr && mr.DeclaringType.FullName == Studio);
        if (studioExisting == 1)
            return;

        var oldNew = instructions
            .Where(i => i.OpCode.Code == Code.Newobj && i.Operand is MethodReference)
            .Where(i => ((MethodReference)i.Operand).DeclaringType.FullName == Vector)
            .ToList();
        if (oldNew.Count != 1)
            throw new InvalidOperationException("expected one F_VectorText constructor in cmdTextMenu, found " + oldNew.Count);

        var oldInit = instructions
            .Where(i => (i.OpCode.Code == Code.Call || i.OpCode.Code == Code.Callvirt) && i.Operand is MethodReference)
            .Where(i => {
                var mr = (MethodReference)i.Operand;
                return mr.DeclaringType.FullName == Vector && mr.Name == "Init" && mr.Parameters.Count == 0;
            })
            .ToList();
        if (oldInit.Count != 1)
            throw new InvalidOperationException("expected one F_VectorText.Init in cmdTextMenu, found " + oldInit.Count);

        var studioCtorRef = module.ImportReference(helperCtor);
        var studioInitRef = module.ImportReference(helperInit);
        var studioTypeRef = module.ImportReference(helperType);

        oldNew[0].Operand = studioCtorRef;
        il.InsertBefore(oldInit[0], Instruction.Create(OpCodes.Castclass, studioTypeRef));
        oldInit[0].Operand = studioInitRef;
        body.MaxStackSize = Math.Max(body.MaxStackSize, 8);
    }

    // Binary equivalent of the original source lines being prefixed with //:
    // remove the active registration check and RegisterException path from the constructor IL.
    private static int DisableRegistrationGuard(MethodDefinition ctor)
    {
        var ins = ctor.Body.Instructions;
        int changed = 0;

        for (int i = 0; i < ins.Count; i++)
        {
            if (!IsRegistrationCall(ins[i]))
                continue;

            int start = i;
            // The class-name ldstr immediately feeding smethod_0 belongs to the disabled source block.
            for (int p = i - 1; p >= Math.Max(0, i - 4); p--)
            {
                if (ins[p].OpCode.Code == Code.Ldstr)
                {
                    start = p;
                    break;
                }
            }

            int end = -1;
            for (int p = i + 1; p < Math.Min(ins.Count, i + 16); p++)
            {
                if (ins[p].OpCode.Code == Code.Throw)
                {
                    end = p;
                    break;
                }
            }
            if (end < 0)
                throw new InvalidOperationException("registration guard throw not found in " + ctor.FullName);

            for (int p = start; p <= end; p++)
            {
                ins[p].OpCode = OpCodes.Nop;
                ins[p].Operand = null;
            }
            changed++;
            i = end;
        }

        return changed;
    }

    private static bool IsRegistrationCall(Instruction i)
    {
        if ((i.OpCode.Code != Code.Call && i.OpCode.Code != Code.Callvirt) || !(i.Operand is MethodReference mr))
            return false;
        return mr.DeclaringType.FullName == SystemType && mr.Name == "smethod_0";
    }

    private static void VerifyCommentLocks(ModuleDefinition module)
    {
        foreach (string typeName in CommentLockedTypes)
        {
            var type = module.Types.SelectMany(AllTypes).Single(t => t.FullName == typeName);
            foreach (var ctor in type.Methods.Where(m => m.IsConstructor && !m.IsStatic && m.HasBody))
            {
                int regCalls = ctor.Body.Instructions.Count(IsRegistrationCall);
                int regThrows = ctor.Body.Instructions.Count(i => i.OpCode.Code == Code.Newobj && i.Operand is MethodReference mr && mr.DeclaringType.Name == "RegisterException");
                if (regCalls != 0 || regThrows != 0)
                    throw new InvalidOperationException($"comment lock failed for {typeName}: smethod_0={regCalls}, RegisterException={regThrows}");
            }
        }
    }

    private static void VerifyArtTextRoute(ModuleDefinition module)
    {
        var vcmd = module.Types.Single(t => t.FullName == Marble).Methods.Single(m => m.Name == "cmdTextMenu" && m.HasBody);
        int studioNew = vcmd.Body.Instructions.Count(i => i.OpCode.Code == Code.Newobj && i.Operand is MethodReference mr && mr.DeclaringType.FullName == Studio);
        int vectorNew = vcmd.Body.Instructions.Count(i => i.OpCode.Code == Code.Newobj && i.Operand is MethodReference mr && mr.DeclaringType.FullName == Vector);
        int studioInit = vcmd.Body.Instructions.Count(i => (i.OpCode.Code == Code.Call || i.OpCode.Code == Code.Callvirt) && i.Operand is MethodReference mr && mr.DeclaringType.FullName == Studio && mr.Name == "Init");
        if (studioNew != 1 || vectorNew != 0 || studioInit != 1)
            throw new InvalidOperationException($"route validation failed: studioNew={studioNew}, vectorNew={vectorNew}, studioInit={studioInit}");
    }

    private static IEnumerable<TypeDefinition> AllTypes(TypeDefinition t)
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