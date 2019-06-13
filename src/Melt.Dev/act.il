// Nested Types
	// Token: 0x02000003 RID: 3
	.class nested private auto ansi sealed serializable beforefieldinit '<>c'
		extends [mscorlib]System.Object
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = (
			01 00 00 00
		)
		// Fields
		// Token: 0x04000001 RID: 1
		.field public static initonly class Melt.Dev.Program/'<>c' '<>9'
		// Token: 0x04000002 RID: 2
		.field public static class [mscorlib]System.Func`3<float64, float64, float64> '<>9__0_0'

		// Methods
		// Token: 0x06000003 RID: 3 RVA: 0x000020B6 File Offset: 0x000002B6
		.method private hidebysig specialname rtspecialname static 
			void .cctor () cil managed 
		{
			// Header Size: 1 byte
			// Code Size: 11 (0xB) bytes
			.maxstack 8

			/* 0x000002B7 7304000006   */ IL_0000: newobj    instance void Melt.Dev.Program/'<>c'::.ctor()
			/* 0x000002BC 8001000004   */ IL_0005: stsfld    class Melt.Dev.Program/'<>c' Melt.Dev.Program/'<>c'::'<>9'
			/* 0x000002C1 2A           */ IL_000A: ret
		} // end of method '<>c'::.cctor

		// Token: 0x06000004 RID: 4 RVA: 0x000020C2 File Offset: 0x000002C2
		.method public hidebysig specialname rtspecialname 
			instance void .ctor () cil managed 
		{
			// Header Size: 1 byte
			// Code Size: 8 (0x8) bytes
			.maxstack 8

			/* 0x000002C3 02           */ IL_0000: ldarg.0
			/* 0x000002C4 281500000A   */ IL_0001: call      instance void [mscorlib]System.Object::.ctor()
			/* 0x000002C9 00           */ IL_0006: nop
			/* 0x000002CA 2A           */ IL_0007: ret
		} // end of method '<>c'::.ctor

		// Token: 0x06000005 RID: 5 RVA: 0x000020CC File Offset: 0x000002CC
		.method assembly hidebysig 
			instance float64 '<Main>b__0_0' (
				float64 x,
				float64 y
			) cil managed 
		{
			// Header Size: 12 bytes
			// Code Size: 51 (0x33) bytes
			// LocalVarSig Token: 0x11000002 RID: 2
			.maxstack 2
			.locals init (
				[0] float64 k,
				[1] float64
			)

			/* 0x000002D8 00           */ IL_0000: nop
			/* 0x000002D9 03           */ IL_0001: ldarg.1
			/* 0x000002DA 04           */ IL_0002: ldarg.2
			/* 0x000002DB 58           */ IL_0003: add
			/* 0x000002DC 23000000000000E03F */ IL_0004: ldc.r8    0.5
			/* 0x000002E5 5A           */ IL_000D: mul
			/* 0x000002E6 230000000000003440 */ IL_000E: ldc.r8    20
			/* 0x000002EF 5A           */ IL_0017: mul
			/* 0x000002F0 230000000000001040 */ IL_0018: ldc.r8    4
			/* 0x000002F9 5B           */ IL_0021: div
			/* 0x000002FA 0A           */ IL_0022: stloc.0
			/* 0x000002FB 06           */ IL_0023: ldloc.0
			/* 0x000002FC 230000000000003440 */ IL_0024: ldc.r8    20
			/* 0x00000305 59           */ IL_002D: sub
			/* 0x00000306 0B           */ IL_002E: stloc.1
			/* 0x00000307 2B00         */ IL_002F: br.s      IL_0031

			/* 0x00000309 07           */ IL_0031: ldloc.1
			/* 0x0000030A 2A           */ IL_0032: ret
		} // end of method '<>c'::'<Main>b__0_0'

	} // end of class <>c