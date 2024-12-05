namespace cuddly_lamp.solutions.fsharp

module Day05 =
    let rec isUpdateOkayHelper forbiddenPages update =
        match update with
        | [] -> true
        | u :: us -> (not (List.contains u forbiddenPages)) && isUpdateOkayHelper forbiddenPages us

    let rec isOkayUpdate (ruleTable: System.Collections.Generic.IReadOnlyDictionary<int, int list>) update =
        match update with
        | [] -> true
        | u :: us ->
            if ruleTable.ContainsKey u then
                (isUpdateOkayHelper ruleTable[u] us) && isOkayUpdate ruleTable us
            else
                isOkayUpdate ruleTable us

    let firstPuzzle ruleTable updates =
        List.filter (isOkayUpdate ruleTable) updates
        |> List.map Library.middleObject
        |> List.sum

    let secondPuzzle ruleTable updates =
        List.filter (fun u -> not (isOkayUpdate ruleTable u)) updates
        |> List.map (fun u -> cuddly_lamp.utils.Utilities.SortUpdate(ruleTable, u))
        |> List.map Library.middleObject
        |> List.sum
