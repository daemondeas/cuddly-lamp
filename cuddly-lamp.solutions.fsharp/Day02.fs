namespace cuddly_lamp.solutions.fsharp

module Day02 =
    let rec isDecr n ns =
        match ns with
        | [] -> true
        | x :: xs -> x < n && (n - x < 4) && (isDecr x xs)

    let rec isIncr n ns =
        match ns with
        | [] -> true
        | x :: xs -> x > n && (x - n < 4) && (isIncr x xs)

    let isSafe ns =
        isIncr (List.head ns) (List.tail ns) || isDecr (List.head ns) (List.tail ns)

    let firstPuzzle input = List.filter isSafe input |> List.length

    let rec isDecrExc n ns noSkip first =
        match ns with
        | [] -> true
        | x :: xs ->
            x < n && (n - x < 4) && (isDecrExc x xs noSkip false)
            || first && isDecr x xs
            || noSkip && (isDecr n xs)

    let rec isIncrExc n ns noSkip first =
        match ns with
        | [] -> true
        | x :: xs ->
            x > n && (x - n < 4) && (isIncrExc x xs noSkip false)
            || first && isIncr x xs
            || noSkip && (isIncr n xs)

    let isSafeExc ns =
        isIncrExc (List.head ns) (List.tail ns) true true
        || isDecrExc (List.head ns) (List.tail ns) true true

    let secondPuzzle input =
        List.filter isSafeExc input |> List.length
