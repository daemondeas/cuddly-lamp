namespace cuddly_lamp.solutions.fsharp

open Library

module Day03 =
    let firstPuzzle instructions =
        List.map executeInstruction instructions |> List.sum

    let secondPuzzle instructions = executeInstructions instructions 0 true
