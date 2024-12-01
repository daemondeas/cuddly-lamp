namespace cuddly_lamp.solutions.fsharp

module Day01 =
  let firstPuzzle l1 l2 =
    List.zip(List.sort l1) (List.sort l2)
    |> List.map (fun p -> abs ((fst p) - (snd p)))
    |> List.sum

  let rec similarityScore left right sum =
    match left with
    | []    -> sum
    | x::xs -> similarityScore xs right (sum + x * (List.filter (fun a -> a = x) right |> List.length))

  let secondPuzzle l1 l2 =
    similarityScore l1 l2 0
