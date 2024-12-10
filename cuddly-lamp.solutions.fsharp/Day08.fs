namespace cuddly_lamp.solutions.fsharp

module Day08 =
    let distance a b = ((fst a) - (fst b), (snd a) - (snd b))

    let antiNodes a b dist =
        [ ((fst a) + (fst dist), (snd a) + (snd dist))
          ((fst b) - (fst dist), (snd b) - (snd dist)) ]

    let isOnMap a x y =
        (fst a) >= 0 && (fst a) < x && (snd a) >= 0 && (snd a) < y

    let nodesForPair a b x y =
        distance a b |> antiNodes a b |> List.filter (fun a -> isOnMap a x y)

    let rec nodesForPairsHelper n ns x y res =
        match ns with
        | [] -> res
        | b :: bs -> nodesForPairsHelper n bs x y ((nodesForPair n b x y) @ res)

    let rec nodesForPairs ns x y res =
        match ns with
        | [] -> res
        | b :: bs -> nodesForPairs bs x y (nodesForPairsHelper b bs x y []) @ res

    let firstPuzzle x y (nodes: System.Collections.Generic.IReadOnlyDictionary<char, (int * int) list>) =
        List.ofSeq nodes.Keys
        |> List.map (fun a -> nodesForPairs nodes[a] x y [])
        |> List.concat
        |> List.distinct
        |> List.length

    let rec gcd a b =
        let r = a % b
        if r = 0 then b else gcd b r

    let gcdWrapper a b = if a > b then gcd a b else gcd b a

    let getSteps a b =
        let dist = distance a b
        let divisor = gcdWrapper (fst dist |> abs) (snd dist |> abs)
        ((fst dist) / divisor, (snd dist) / divisor)

    let rec getLineDown point steps x y res =
        if (fst point) >= 0 && (fst point) < x && (snd point) >= 0 && (snd point) < y then
            getLineDown ((fst point) - (fst steps), (snd point) - (snd steps)) steps x y (Set.add point res)
        else
            res

    let rec getLineUp point steps x y res =
        if (fst point) >= 0 && (fst point) < x && (snd point) >= 0 && (snd point) < y then
            getLineUp ((fst point) + (fst steps), (snd point) + (snd steps)) steps x y (Set.add point res)
        else
            res

    let getLine a b x y res =
        getSteps a b |> (fun s -> getLineDown a s x y res |> getLineUp a s x y)

    let rec getLines a nodes x y res =
        match nodes with
        | [] -> res
        | n :: ns -> getLines a ns x y (getLine a n x y res)

    let rec getLinesWrapper nodes x y res =
        match nodes with
        | [] -> res
        | n :: ns -> getLinesWrapper ns x y (getLines n ns x y res)

    let rec getAllNodesOnLines
        keys
        (dict: System.Collections.Generic.IReadOnlyDictionary<char, (int * int) list>)
        x
        y
        res
        =
        match keys with
        | [] -> res
        | k :: ks -> getAllNodesOnLines ks dict x y (getLinesWrapper (dict[k]) x y res)

    let secondPuzzle x y (nodes: System.Collections.Generic.IReadOnlyDictionary<char, (int * int) list>) =
        getAllNodesOnLines (List.ofSeq nodes.Keys) nodes x y Set.empty |> Set.count
