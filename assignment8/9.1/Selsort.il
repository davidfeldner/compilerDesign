// IL code: Selsort
.class private auto ansi '<Module>'
{
} // end of class <Module>

.class private auto ansi beforefieldinit Selsort
	extends [System.Runtime]System.Object
{
	.custom instance void [System.Runtime]System.Runtime.CompilerServices.NullableContextAttribute::.ctor(uint8) = (
		01 00 01 00 00
	)
	.custom instance void [System.Runtime]System.Runtime.CompilerServices.NullableAttribute::.ctor(uint8) = (
		01 00 00 00 00
	)
	// Fields
	.field public static initonly class [System.Runtime]System.Random rnd

	// Methods
	.method public hidebysig static 
		void Main (
			string[] args
		) cil managed 
	{
		// Method begins at RVA 0x2050
		// Header size: 12
		// Code size: 110 (0x6e)
		.maxstack 4
		.entrypoint
		.locals init (
			[0] int32,
			[1] int32[],
			[2] int32,
			[3] bool,
			[4] int32,
			[5] bool
		)

		IL_0000: nop
		IL_0001: ldc.i4.s 10
		IL_0003: stloc.0
		IL_0004: ldloc.0
		IL_0005: newarr [System.Runtime]System.Int32
		IL_000a: stloc.1
		IL_000b: ldc.i4.0
		IL_000c: stloc.2
		IL_000d: br.s IL_0025
		// loop start (head: IL_0025)
			IL_000f: ldloc.1
			IL_0010: ldloc.2
			IL_0011: ldsfld class [System.Runtime]System.Random Selsort::rnd
			IL_0016: ldc.i4 1000000
			IL_001b: callvirt instance int32 [System.Runtime]System.Random::Next(int32)
			IL_0020: stelem.i4
			IL_0021: ldloc.2
			IL_0022: ldc.i4.1
			IL_0023: add
			IL_0024: stloc.2

			IL_0025: ldloc.2
			IL_0026: ldloc.0
			IL_0027: clt
			IL_0029: stloc.3
			IL_002a: ldloc.3
			IL_002b: brtrue.s IL_000f
		// end loop

		IL_002d: ldloc.1
		IL_002e: call void Selsort::SelectionSort(int32[])
		IL_0033: nop
		IL_0034: ldc.i4.0
		IL_0035: stloc.s 4
		IL_0037: br.s IL_005c
		// loop start (head: IL_005c)
			IL_0039: ldloc.1
			IL_003a: ldloc.s 4
			IL_003c: ldelema [System.Runtime]System.Int32
			IL_0041: call instance string [System.Runtime]System.Int32::ToString()
			IL_0046: ldstr " "
			IL_004b: call string [System.Runtime]System.String::Concat(string, string)
			IL_0050: call void [System.Console]System.Console::Write(string)
			IL_0055: nop
			IL_0056: ldloc.s 4
			IL_0058: ldc.i4.1
			IL_0059: add
			IL_005a: stloc.s 4

			IL_005c: ldloc.s 4
			IL_005e: ldloc.0
			IL_005f: clt
			IL_0061: stloc.s 5
			IL_0063: ldloc.s 5
			IL_0065: brtrue.s IL_0039
		// end loop

		IL_0067: call void [System.Console]System.Console::WriteLine()
		IL_006c: nop
		IL_006d: ret
	} // end of method Selsort::Main

	.method public hidebysig static 
		void SelectionSort (
			int32[] arr
		) cil managed 
	{
		// Method begins at RVA 0x20cc
		// Header size: 12
		// Code size: 78 (0x4e)
		.maxstack 4
		.locals init (
			[0] int32,  // i 
			[1] int32,  // least
			[2] int32,  // tmp
			[3] int32,  // j
			[4] bool,
			[5] bool,   // inner loop bool
			[6] bool    // outer loop bool
		)

		IL_0000: nop
		IL_0001: ldc.i4.0                                // push 0 onto the stack as int32
		IL_0002: stloc.0                                 // Pop a value from stack into local variable 0.
		IL_0003: br.s IL_0041                            // branch/jump to line 41
		// loop start (head: IL_0041)
			IL_0005: nop
			IL_0006: ldloc.0			// load i
			IL_0007: stloc.1			// int least = i
			IL_0008: ldloc.0			// load i
			IL_0009: ldc.i4.1			// load cont 1
			IL_000a: add				// calculate i+1
			IL_000b: stloc.3			// let j = i+1
			IL_000c: br.s IL_0022			// jump to line 22
			// loop start (head: IL_0022)
				IL_000e: ldarg.0		// load arr
				IL_000f: ldloc.3		// load j
				IL_0010: ldelem.i4		// get value at arr[j]
				IL_0011: ldarg.0		// load arr
				IL_0012: ldloc.1		// load least
				IL_0013: ldelem.i4		// get value at arr [least]
				IL_0014: clt			// arr[j] < arr[least]
				IL_0016: stloc.s 4		// store res at location 4
				IL_0018: ldloc.s 4		// load stored
				IL_001a: brfalse.s IL_001e	// if false goto 0x1e

				IL_001c: ldloc.3		// load j
				IL_001d: stloc.1		// least = j

				IL_001e: ldloc.3		// load j
				IL_001f: ldc.i4.1		// load const 1
				IL_0020: add			// j+1
				IL_0021: stloc.3		// j++
:wqa




				IL_0022: ldloc.3		// (Jumped to here) Load j
				IL_0023: ldarg.0		// load arg 0 which is arr
				IL_0024: ldlen			// get len of arr
				IL_0025: conv.i4		// conv to int
				IL_0026: clt			// j < arr.length
				IL_0028: stloc.s 5		// store in bool var 5
				IL_002a: ldloc.s 5		// load stored
				IL_002c: brtrue.s IL_000e	// jump to 0xe if true (continue loop)
			// end loop

			IL_002e: ldarg.0			// load arr
			IL_002f: ldloc.0			// load i
			IL_0030: ldelem.i4			// get arr[i]
			IL_0031: stloc.2			// int tmp = arr[i] 
			IL_0032: ldarg.0			// load arr
			IL_0033: ldloc.0			// load i
			IL_0034: ldarg.0			// load arr
			IL_0035: ldloc.1			// load least
			IL_0036: ldelem.i4			// load arr[least]
			IL_0037: stelem.i4			// arr[i] = arr[least]
			IL_0038: ldarg.0			// load arr
			IL_0039: ldloc.1			// load least
			IL_003a: ldloc.2			// load tmp
			IL_003b: stelem.i4			// set arr[least] = tmp
			IL_003c: nop
			IL_003d: ldloc.0			// load i
			IL_003e: ldc.i4.1			// load const 1
			IL_003f: add				// i+1
			IL_0040: stloc.0			// i++

			IL_0041: ldloc.0                              // (Jumped to here) Load local variable 0 onto stack. (load i)
			IL_0042: ldarg.0			      // Load argument 0 onto the stack. (load arr)
			IL_0043: ldlen				      // Push the length (of type native unsigned int) of array on the
stack.
			IL_0044: conv.i4			      // Convert to int32
			IL_0045: clt				      // compare less than push 1 if true (i < arr.Length)
			IL_0047: stloc.s 6			      // store result in var 6
			IL_0049: ldloc.s 6			      // load the stored result
			IL_004b: brtrue.s IL_0005 		      // Jump to line 5 if true (continue)
		// end loop

		IL_004d: ret
	} // end of method Selsort::SelectionSort

	.method public hidebysig specialname rtspecialname 
		instance void .ctor () cil managed 
	{
		// Method begins at RVA 0x2126
		// Header size: 1
		// Code size: 8 (0x8)
		.maxstack 8

		IL_0000: ldarg.0
		IL_0001: call instance void [System.Runtime]System.Object::.ctor()
		IL_0006: nop
		IL_0007: ret
	} // end of method Selsort::.ctor

	.method private hidebysig specialname rtspecialname static 
		void .cctor () cil managed 
	{
		// Method begins at RVA 0x212f
		// Header size: 1
		// Code size: 11 (0xb)
		.maxstack 8

		IL_0000: newobj instance void [System.Runtime]System.Random::.ctor()
		IL_0005: stsfld class [System.Runtime]System.Random Selsort::rnd
		IL_000a: ret
	} // end of method Selsort::.cctor

} // end of class Selsort

