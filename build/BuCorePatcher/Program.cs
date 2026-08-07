using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Cil;

internal static class Program
{
    private static readonly List<string> Report = new();

    private static int Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.Error.WriteLine("Usage: BuCorePatcher <input-buCore.dll> <output-buCore.dll> [report.txt]");
            return 2;
        }

        string input = Path.GetFullPath(args[0]);
        string output = Path.GetFullPath(args[1]);
        string report = args.Length > 2 ? Path.GetFullPath(args[2]) : Path.ChangeExtension(output, ".patch.txt");
        Directory.CreateDirectory(Path.GetDirectoryName(output)!);
        Directory.CreateDirectory(Path.GetDirectoryName(report)!);

        var resolver = new DefaultAssemblyResolver();
        resolver.AddSearchDirectory(Path.GetDirectoryName(input)!);
        var rp = new ReaderParameters { AssemblyResolver = resolver, InMemory = true, ReadSymbols = false };
        using var asm = AssemblyDefinition.ReadAssembly(input, rp);
        ModuleDefinition module = asm.MainModule;

        PatchSawProjection(module);
        PatchNumeric(module);
        PatchEllipse(module);

        if (Report.Count < 6)
            throw new InvalidOperationException("Too few verified patches were applied; refusing to write DLL.");

        asm.Write(output, new WriterParameters { WriteSymbols = false });
        File.WriteAllLines(report, Report);
        foreach (var line in Report) Console.WriteLine(line);
        Console.WriteLine($"WROTE: {output}");
        return 0;
    }

    private static TypeDefinition Type(ModuleDefinition m, string fullName) =>
        m.Types.FirstOrDefault(t => t.FullName == fullName)
        ?? throw new InvalidOperationException($"Type not found: {fullName}");

    private static MethodDefinition Method(TypeDefinition t, string name, int parameterCount) =>
        t.Methods.SingleOrDefault(m => m.Name == name && m.Parameters.Count == parameterCount)
        ?? throw new InvalidOperationException($"Method not found/ambiguous: {t.FullName}.{name}/{parameterCount}");

    private static void ResetBody(MethodDefinition m)
    {
        m.Body.ExceptionHandlers.Clear();
        m.Body.Instructions.Clear();
        m.Body.Variables.Clear();
        m.Body.InitLocals = true;
    }

    private static VariableDefinition? LoadedLocal(Instruction i)
    {
        return i.OpCode.Code switch
        {
            Code.Ldloc or Code.Ldloc_S or Code.Ldloca or Code.Ldloca_S => i.Operand as VariableDefinition,
            Code.Ldloc_0 => i.Offset >= 0 ? i.GetMethodBodyVariable(0) : null,
            Code.Ldloc_1 => i.GetMethodBodyVariable(1),
            Code.Ldloc_2 => i.GetMethodBodyVariable(2),
            Code.Ldloc_3 => i.GetMethodBodyVariable(3),
            _ => null
        };
    }

    // Cecil does not expose the owning method from Instruction. For short-form ldloc
    // opcodes we normalize the method body before analysis, so this extension is never
    // needed in practice; it exists only to make the switch exhaustive.
    private static VariableDefinition? GetMethodBodyVariable(this Instruction _, int __) => null;

    private static void PatchSawProjection(ModuleDefinition module)
    {
        var type = Type(module, "buCore.buCamCalc");
        var method = Method(type, "CalculateGrindingContourSaw", 6);
        method.Body.SimplifyMacrosCompat();
        var il = method.Body.GetILProcessor();
        var ins = method.Body.Instructions;

        MethodReference? degreeToRadian = ins.Select(x => x.Operand).OfType<MethodReference>()
            .FirstOrDefault(x => x.Name == "DegreeToRadian" && x.Parameters.Count == 1);
        MethodReference? cos = ins.Select(x => x.Operand).OfType<MethodReference>()
            .FirstOrDefault(x => x.DeclaringType.FullName == "System.Math" && x.Name == "Cos");
        if (degreeToRadian == null || cos == null)
            throw new InvalidOperationException("Saw projection math references were not found.");

        int patched = 0;
        var calls = ins.Where(x => x.Operand is MethodReference mr && mr.Name == "LineWithOrientationAngle").ToList();
        foreach (var call in calls)
        {
            int callIndex = ins.IndexOf(call);
            int subIndex = -1;
            bool alreadyDivided = false;
            for (int i = callIndex - 1; i >= Math.Max(0, callIndex - 12); --i)
            {
                if (ins[i].OpCode.Code == Code.Div) { alreadyDivided = true; break; }
                if (ins[i].OpCode.Code == Code.Sub) { subIndex = i; break; }
            }
            if (subIndex < 0 || alreadyDivided)
                continue;

            VariableDefinition? angleLocal = null;
            MethodReference? getA = null;
            for (int i = subIndex - 1; i >= Math.Max(1, subIndex - 40); --i)
            {
                if (ins[i].Operand is MethodReference mr && mr.Name == "get_A")
                {
                    getA = mr;
                    angleLocal = GetLoadedVariable(method.Body, ins[i - 1]);
                    if (angleLocal != null) break;
                }
            }
            if (angleLocal == null || getA == null)
                continue;

            Instruction anchor = ins[subIndex];
            var a = il.Create(OpCodes.Ldloc, angleLocal);
            var b = il.Create(OpCodes.Callvirt, getA);
            var c = il.Create(OpCodes.Call, degreeToRadian);
            var d = il.Create(OpCodes.Call, cos);
            var e = il.Create(OpCodes.Div);
            il.InsertAfter(anchor, a);
            il.InsertAfter(a, b);
            il.InsertAfter(b, c);
            il.InsertAfter(c, d);
            il.InsertAfter(d, e);
            patched++;
        }

        if (patched < 4)
            throw new InvalidOperationException($"Expected at least 4 raw tilted-saw approach/leave projections, patched {patched}.");
        Report.Add($"buCamCalc.CalculateGrindingContourSaw: {patched} raw A-axis approach/leave lengths changed to delta/cos(A). 45-degree overtravel projection repaired.");
    }

    private static VariableDefinition? GetLoadedVariable(MethodBody body, Instruction i)
    {
        if (i.Operand is VariableDefinition v) return v;
        return i.OpCode.Code switch
        {
            Code.Ldloc_0 => body.Variables.Count > 0 ? body.Variables[0] : null,
            Code.Ldloc_1 => body.Variables.Count > 1 ? body.Variables[1] : null,
            Code.Ldloc_2 => body.Variables.Count > 2 ? body.Variables[2] : null,
            Code.Ldloc_3 => body.Variables.Count > 3 ? body.Variables[3] : null,
            _ => null
        };
    }

    private static void PatchNumeric(ModuleDefinition module)
    {
        var type = Type(module, "buCore.buNumeric");
        PatchEquationLineer(module, Method(type, "EquationLineer", 6));
        PatchValueList(module, Method(type, "GetValueListFromMinMaxByCount", 4));
        PatchDivideValues(module, Method(type, "DevideMinMaxValueByNumber", 4));
    }

    private static void PatchEquationLineer(ModuleDefinition module, MethodDefinition m)
    {
        ResetBody(m);
        var il = m.Body.GetILProcessor();
        var abs = module.ImportReference(typeof(Math).GetMethod(nameof(Math.Abs), new[] { typeof(double) })!);
        var setFirst = il.Create(OpCodes.Nop);

        il.Append(il.Create(OpCodes.Ldarg, m.Parameters[0]));
        il.Append(il.Create(OpCodes.Ldarg, m.Parameters[1]));
        il.Append(il.Create(OpCodes.Sub));
        il.Append(il.Create(OpCodes.Call, abs));
        il.Append(il.Create(OpCodes.Ldc_R8, 1E-10));
        il.Append(il.Create(OpCodes.Blt, setFirst));
        il.Append(il.Create(OpCodes.Ldarg, m.Parameters[3]));
        il.Append(il.Create(OpCodes.Ldarg, m.Parameters[2]));
        il.Append(il.Create(OpCodes.Sub));
        il.Append(il.Create(OpCodes.Call, abs));
        il.Append(il.Create(OpCodes.Ldc_R8, 1E-10));
        il.Append(il.Create(OpCodes.Blt, setFirst));

        il.Append(il.Create(OpCodes.Ldarg, m.Parameters[5]));
        il.Append(il.Create(OpCodes.Ldarg, m.Parameters[4]));
        il.Append(il.Create(OpCodes.Ldarg, m.Parameters[2]));
        il.Append(il.Create(OpCodes.Sub));
        il.Append(il.Create(OpCodes.Ldarg, m.Parameters[3]));
        il.Append(il.Create(OpCodes.Ldarg, m.Parameters[2]));
        il.Append(il.Create(OpCodes.Sub));
        il.Append(il.Create(OpCodes.Ldarg, m.Parameters[1]));
        il.Append(il.Create(OpCodes.Ldarg, m.Parameters[0]));
        il.Append(il.Create(OpCodes.Sub));
        il.Append(il.Create(OpCodes.Div));
        il.Append(il.Create(OpCodes.Div));
        il.Append(il.Create(OpCodes.Ldarg, m.Parameters[0]));
        il.Append(il.Create(OpCodes.Add));
        il.Append(il.Create(OpCodes.Stind_R8));
        il.Append(il.Create(OpCodes.Ret));

        il.Append(setFirst);
        il.Append(il.Create(OpCodes.Ldarg, m.Parameters[5]));
        il.Append(il.Create(OpCodes.Ldarg, m.Parameters[0]));
        il.Append(il.Create(OpCodes.Stind_R8));
        il.Append(il.Create(OpCodes.Ret));
        Report.Add("buNumeric.EquationLineer: zero-X/zero-Y slope divisions guarded.");
    }

    private static MethodReference ListDoubleMethod(ModuleDefinition module, string name)
    {
        var list = new GenericInstanceType(module.ImportReference(typeof(List<>)));
        list.GenericArguments.Add(module.TypeSystem.Double);
        var mr = new MethodReference(name, name == "Clear" ? module.TypeSystem.Void : module.TypeSystem.Void, list) { HasThis = true };
        if (name == "Add") mr.Parameters.Add(new ParameterDefinition(module.TypeSystem.Double));
        return module.ImportReference(mr);
    }

    private static void PatchValueList(ModuleDefinition module, MethodDefinition m)
    {
        ResetBody(m);
        var il = m.Body.GetILProcessor();
        var add = ListDoubleMethod(module, "Add");
        var step = new VariableDefinition(module.TypeSystem.Double);
        var index = new VariableDefinition(module.TypeSystem.Int32);
        m.Body.Variables.Add(step); m.Body.Variables.Add(index);
        var ret = il.Create(OpCodes.Ret);
        var countNotOne = il.Create(OpCodes.Nop);
        var loopCheck = il.Create(OpCodes.Nop);
        var loopBody = il.Create(OpCodes.Nop);

        il.Append(il.Create(OpCodes.Ldarg, m.Parameters[2])); il.Append(il.Create(OpCodes.Ldc_I4_0)); il.Append(il.Create(OpCodes.Ble, ret));
        il.Append(il.Create(OpCodes.Ldarg, m.Parameters[3])); il.Append(il.Create(OpCodes.Ldind_Ref)); il.Append(il.Create(OpCodes.Brfalse, ret));
        il.Append(il.Create(OpCodes.Ldarg, m.Parameters[2])); il.Append(il.Create(OpCodes.Ldc_I4_1)); il.Append(il.Create(OpCodes.Bne_Un, countNotOne));
        il.Append(il.Create(OpCodes.Ldarg, m.Parameters[3])); il.Append(il.Create(OpCodes.Ldind_Ref)); il.Append(il.Create(OpCodes.Ldarg, m.Parameters[0])); il.Append(il.Create(OpCodes.Callvirt, add)); il.Append(il.Create(OpCodes.Br, ret));
        il.Append(countNotOne);
        il.Append(il.Create(OpCodes.Ldarg, m.Parameters[1])); il.Append(il.Create(OpCodes.Ldarg, m.Parameters[0])); il.Append(il.Create(OpCodes.Sub)); il.Append(il.Create(OpCodes.Ldarg, m.Parameters[2])); il.Append(il.Create(OpCodes.Ldc_I4_1)); il.Append(il.Create(OpCodes.Sub)); il.Append(il.Create(OpCodes.Conv_R8)); il.Append(il.Create(OpCodes.Div)); il.Append(il.Create(OpCodes.Stloc, step));
        il.Append(il.Create(OpCodes.Ldc_I4_0)); il.Append(il.Create(OpCodes.Stloc, index)); il.Append(il.Create(OpCodes.Br, loopCheck));
        il.Append(loopBody);
        il.Append(il.Create(OpCodes.Ldarg, m.Parameters[3])); il.Append(il.Create(OpCodes.Ldind_Ref)); il.Append(il.Create(OpCodes.Ldarg, m.Parameters[0])); il.Append(il.Create(OpCodes.Ldloc, step)); il.Append(il.Create(OpCodes.Ldloc, index)); il.Append(il.Create(OpCodes.Conv_R8)); il.Append(il.Create(OpCodes.Mul)); il.Append(il.Create(OpCodes.Add)); il.Append(il.Create(OpCodes.Callvirt, add));
        il.Append(il.Create(OpCodes.Ldloc, index)); il.Append(il.Create(OpCodes.Ldc_I4_1)); il.Append(il.Create(OpCodes.Add)); il.Append(il.Create(OpCodes.Stloc, index));
        il.Append(loopCheck);
        il.Append(il.Create(OpCodes.Ldloc, index)); il.Append(il.Create(OpCodes.Ldarg, m.Parameters[2])); il.Append(il.Create(OpCodes.Ldc_I4_2)); il.Append(il.Create(OpCodes.Sub)); il.Append(il.Create(OpCodes.Ble, loopBody));
        il.Append(il.Create(OpCodes.Ldarg, m.Parameters[3])); il.Append(il.Create(OpCodes.Ldind_Ref)); il.Append(il.Create(OpCodes.Ldarg, m.Parameters[1])); il.Append(il.Create(OpCodes.Callvirt, add));
        il.Append(ret);
        Report.Add("buNumeric.GetValueListFromMinMaxByCount: Count<=1 division guard applied.");
    }

    private static void PatchDivideValues(ModuleDefinition module, MethodDefinition m)
    {
        ResetBody(m);
        var il = m.Body.GetILProcessor();
        var add = ListDoubleMethod(module, "Add");
        var clear = ListDoubleMethod(module, "Clear");
        var step = new VariableDefinition(module.TypeSystem.Double);
        var current = new VariableDefinition(module.TypeSystem.Double);
        var index = new VariableDefinition(module.TypeSystem.Int32);
        m.Body.Variables.Add(step); m.Body.Variables.Add(current); m.Body.Variables.Add(index);
        var ret = il.Create(OpCodes.Ret);
        var countNotOne = il.Create(OpCodes.Nop);
        var loopCheck = il.Create(OpCodes.Nop);
        var loopBody = il.Create(OpCodes.Nop);

        il.Append(il.Create(OpCodes.Ldarg, m.Parameters[3])); il.Append(il.Create(OpCodes.Ldind_Ref)); il.Append(il.Create(OpCodes.Brfalse, ret));
        il.Append(il.Create(OpCodes.Ldarg, m.Parameters[3])); il.Append(il.Create(OpCodes.Ldind_Ref)); il.Append(il.Create(OpCodes.Callvirt, clear));
        il.Append(il.Create(OpCodes.Ldarg, m.Parameters[2])); il.Append(il.Create(OpCodes.Ldc_I4_0)); il.Append(il.Create(OpCodes.Ble, ret));
        il.Append(il.Create(OpCodes.Ldarg, m.Parameters[3])); il.Append(il.Create(OpCodes.Ldind_Ref)); il.Append(il.Create(OpCodes.Ldarg, m.Parameters[0])); il.Append(il.Create(OpCodes.Callvirt, add));
        il.Append(il.Create(OpCodes.Ldarg, m.Parameters[2])); il.Append(il.Create(OpCodes.Ldc_I4_1)); il.Append(il.Create(OpCodes.Bne_Un, countNotOne)); il.Append(il.Create(OpCodes.Br, ret));
        il.Append(countNotOne);
        il.Append(il.Create(OpCodes.Ldarg, m.Parameters[1])); il.Append(il.Create(OpCodes.Ldarg, m.Parameters[0])); il.Append(il.Create(OpCodes.Sub)); il.Append(il.Create(OpCodes.Ldarg, m.Parameters[2])); il.Append(il.Create(OpCodes.Ldc_I4_1)); il.Append(il.Create(OpCodes.Sub)); il.Append(il.Create(OpCodes.Conv_R8)); il.Append(il.Create(OpCodes.Div)); il.Append(il.Create(OpCodes.Stloc, step));
        il.Append(il.Create(OpCodes.Ldarg, m.Parameters[0])); il.Append(il.Create(OpCodes.Stloc, current));
        il.Append(il.Create(OpCodes.Ldc_I4_0)); il.Append(il.Create(OpCodes.Stloc, index)); il.Append(il.Create(OpCodes.Br, loopCheck));
        il.Append(loopBody);
        il.Append(il.Create(OpCodes.Ldloc, current)); il.Append(il.Create(OpCodes.Ldloc, step)); il.Append(il.Create(OpCodes.Add)); il.Append(il.Create(OpCodes.Stloc, current));
        il.Append(il.Create(OpCodes.Ldarg, m.Parameters[3])); il.Append(il.Create(OpCodes.Ldind_Ref)); il.Append(il.Create(OpCodes.Ldloc, current)); il.Append(il.Create(OpCodes.Callvirt, add));
        il.Append(il.Create(OpCodes.Ldloc, index)); il.Append(il.Create(OpCodes.Ldc_I4_1)); il.Append(il.Create(OpCodes.Add)); il.Append(il.Create(OpCodes.Stloc, index));
        il.Append(loopCheck);
        il.Append(il.Create(OpCodes.Ldloc, index)); il.Append(il.Create(OpCodes.Ldarg, m.Parameters[2])); il.Append(il.Create(OpCodes.Ldc_I4_3)); il.Append(il.Create(OpCodes.Sub)); il.Append(il.Create(OpCodes.Ble, loopBody));
        il.Append(il.Create(OpCodes.Ldarg, m.Parameters[3])); il.Append(il.Create(OpCodes.Ldind_Ref)); il.Append(il.Create(OpCodes.Ldarg, m.Parameters[1])); il.Append(il.Create(OpCodes.Callvirt, add));
        il.Append(ret);
        Report.Add("buNumeric.DevideMinMaxValueByNumber: divide-count 0/1 guard applied.");
    }

    private static void PatchEllipse(ModuleDefinition module)
    {
        var type = Type(module, "buCore.buVector");
        var m = Method(type, "EllipseWithCenter", 7);
        var target = type.Methods.Single(x => x.Name == "EllipseArcWithCenter" && x.Parameters.Count == 9);
        ResetBody(m);
        var il = m.Body.GetILProcessor();
        var invalid = il.Create(OpCodes.Ret);
        var isNaN = module.ImportReference(typeof(double).GetMethod(nameof(double.IsNaN), new[] { typeof(double) })!);
        var isInf = module.ImportReference(typeof(double).GetMethod(nameof(double.IsInfinity), new[] { typeof(double) })!);

        il.Append(il.Create(OpCodes.Ldarg, m.Parameters[0])); il.Append(il.Create(OpCodes.Brfalse, invalid));
        foreach (int p in new[] { 1, 2, 3 })
        {
            il.Append(il.Create(OpCodes.Ldarg, m.Parameters[p])); il.Append(il.Create(OpCodes.Call, isNaN)); il.Append(il.Create(OpCodes.Brtrue, invalid));
            il.Append(il.Create(OpCodes.Ldarg, m.Parameters[p])); il.Append(il.Create(OpCodes.Call, isInf)); il.Append(il.Create(OpCodes.Brtrue, invalid));
        }
        il.Append(il.Create(OpCodes.Ldarg, m.Parameters[1])); il.Append(il.Create(OpCodes.Ldc_R8, 1E-9)); il.Append(il.Create(OpCodes.Ble, invalid));
        il.Append(il.Create(OpCodes.Ldarg, m.Parameters[2])); il.Append(il.Create(OpCodes.Ldc_R8, 1E-9)); il.Append(il.Create(OpCodes.Ble, invalid));
        il.Append(il.Create(OpCodes.Ldarg_0));
        il.Append(il.Create(OpCodes.Ldarg, m.Parameters[0]));
        il.Append(il.Create(OpCodes.Ldarg, m.Parameters[1]));
        il.Append(il.Create(OpCodes.Ldarg, m.Parameters[2]));
        il.Append(il.Create(OpCodes.Ldc_R8, 0.0));
        il.Append(il.Create(OpCodes.Ldc_R8, 360.0));
        il.Append(il.Create(OpCodes.Ldarg, m.Parameters[3]));
        il.Append(il.Create(OpCodes.Ldarg, m.Parameters[4]));
        il.Append(il.Create(OpCodes.Ldarg, m.Parameters[5]));
        il.Append(il.Create(OpCodes.Ldarg, m.Parameters[6]));
        il.Append(il.Create(OpCodes.Call, target));
        il.Append(il.Create(OpCodes.Ret));
        il.Append(invalid);
        Report.Add("buVector.EllipseWithCenter: NaN/Infinity/zero/negative ellipse radii rejected before geometry creation.");
    }
}

internal static class CecilMacroCompatibility
{
    // Mono.Cecil.Rocks is intentionally not required. We only need stable local
    // operands; converting short ldloc opcodes makes the analyzer deterministic.
    public static void SimplifyMacrosCompat(this MethodBody body)
    {
        var vars = body.Variables;
        foreach (var i in body.Instructions)
        {
            switch (i.OpCode.Code)
            {
                case Code.Ldloc_0: i.OpCode = OpCodes.Ldloc; i.Operand = vars[0]; break;
                case Code.Ldloc_1: i.OpCode = OpCodes.Ldloc; i.Operand = vars[1]; break;
                case Code.Ldloc_2: i.OpCode = OpCodes.Ldloc; i.Operand = vars[2]; break;
                case Code.Ldloc_3: i.OpCode = OpCodes.Ldloc; i.Operand = vars[3]; break;
                case Code.Stloc_0: i.OpCode = OpCodes.Stloc; i.Operand = vars[0]; break;
                case Code.Stloc_1: i.OpCode = OpCodes.Stloc; i.Operand = vars[1]; break;
                case Code.Stloc_2: i.OpCode = OpCodes.Stloc; i.Operand = vars[2]; break;
                case Code.Stloc_3: i.OpCode = OpCodes.Stloc; i.Operand = vars[3]; break;
            }
        }
    }
}
