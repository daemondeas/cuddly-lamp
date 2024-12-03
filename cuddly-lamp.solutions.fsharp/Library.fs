namespace cuddly_lamp.solutions.fsharp

module Library =
    type InstrType = Mul | Do | Dont

    type Instruction =
        { instr: InstrType
          operA: int
          operB: int }

    let executeInstruction instr =
        match instr.instr with
        | Mul  -> instr.operA * instr.operB
        | _    -> 0

    let executeInstructionHelper enabled instr =
        match instr.instr with
        | Do   -> (0, true)
        | Dont -> (0, false)
        | Mul  ->
          if enabled then
            ((instr.operA * instr.operB), enabled)
          else
            (0, enabled)

    let rec executeInstructions instructions sum enabled =
      match instructions with
      | []    -> sum
      | x::xs ->
        let result = executeInstructionHelper enabled x
        executeInstructions xs (sum + (fst result)) (snd result)
