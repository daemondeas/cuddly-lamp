namespace cuddly_lamp.solutions.fsharp

module Day06 =
    let rotate direction =
        match direction with
        | (0, -1) -> (1, 0)
        | (1, 0) -> (0, 1)
        | (0, 1) -> (-1, 0)
        | (-1, 0) -> (0, -1)
        | _ -> raise (new System.ArgumentException())

    let rec walkUntilOffMap map x y xMax yMax direction (positionsVisited: Set<(int * int)>) =
        if x < 0 || x >= xMax || y < 0 || y >= yMax then
            positionsVisited
        elif Set.contains (x, y) map then
            walkUntilOffMap
                map
                (x - (fst direction))
                (y - (snd direction))
                xMax
                yMax
                (rotate direction)
                positionsVisited
        else
            walkUntilOffMap
                map
                (x + (fst direction))
                (y + (snd direction))
                xMax
                yMax
                direction
                (positionsVisited.Add((x, y)))

    let firstPuzzle map x y guard =
        walkUntilOffMap map (fst guard) (snd guard) x y (0, -1) Set.empty |> Set.count

    let rec isInLoop map x y xMax yMax direction (previousPositionsWithDirections: Set<(int * int) * (int * int)>) =
        if x < 0 || x >= xMax || y < 0 || y >= yMax then
            false
        elif Set.contains ((x, y), direction) previousPositionsWithDirections then
            true
        elif Set.contains (x, y) map then
            isInLoop
                map
                (x - (fst direction))
                (y - (snd direction))
                xMax
                yMax
                (rotate direction)
                previousPositionsWithDirections
        else
            isInLoop
                map
                (x + (fst direction))
                (y + (snd direction))
                xMax
                yMax
                direction
                (previousPositionsWithDirections.Add(((x, y), direction)))

    let addsLoop map x y posX posY xMax yMax =
        if Set.contains (x, y) map then
            false
        elif x = posX && y = posY then
            false
        else
            isInLoop (map.Add((x, y))) posX posY xMax yMax (0, -1) Set.empty

    let rec positionsAddingLoop map x y posX posY xMax yMax positions =
        if y >= yMax then
            positions
        elif x >= xMax then
            positionsAddingLoop map 0 (y + 1) posX posY xMax yMax positions
        elif addsLoop map x y posX posY xMax yMax then
            positionsAddingLoop map (x + 1) y posX posY xMax yMax ((x, y) :: positions)
        else
            positionsAddingLoop map (x + 1) y posX posY xMax yMax positions

    let secondPuzzle map x y guard =
        positionsAddingLoop map 0 0 (fst guard) (snd guard) x y [] |> List.length
