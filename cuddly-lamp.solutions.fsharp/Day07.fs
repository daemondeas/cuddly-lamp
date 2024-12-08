namespace cuddly_lamp.solutions.fsharp

module Day07 =
    type Oper =
        | Add
        | Multiply
        | Concatenate

    let applyOper (a: int64) (b: int64) oper =
        match oper with
        | Multiply -> a * b
        | Add -> a + b
        | Concatenate -> ((string a) + (string b)) |> int64

    let rec eval target soFar oper remaining =
        match remaining with
        | [] -> target = soFar
        | x :: xs ->
            eval target (applyOper soFar x oper) Add xs
            || eval target (applyOper soFar x oper) Multiply xs

    let firstPuzzle input =
        List.filter (fun a -> eval (fst a) 0 Add (snd a)) input
        |> List.map (fun a -> (fst a))
        |> List.sum

    let rec evalWithConcat target soFar oper remaining =
        match remaining with
        | [] -> target = soFar
        | x :: xs ->
            evalWithConcat target (applyOper soFar x oper) Add xs
            || evalWithConcat target (applyOper soFar x oper) Multiply xs
            || evalWithConcat target (applyOper soFar x oper) Concatenate xs

    let secondPuzzle input =
        List.filter (fun a -> evalWithConcat (fst a) 0 Add (snd a)) input
        |> List.map (fun a -> (fst a))
        |> List.sum
