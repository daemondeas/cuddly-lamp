namespace cuddly_lamp.solutions.fsharp

module Day04 =
    let rec hasWord
        (chart: System.Collections.Generic.IReadOnlyDictionary<(int * int), char>)
        word
        direction
        x
        y
        xMax
        yMax
        =
        match word with
        | [] -> true
        | l :: ls ->
            if x < 0 || x >= xMax || y < 0 || y >= yMax then
                false
            else
                chart[(x, y)] = l
                && hasWord chart ls direction (x + (fst direction)) (y + (snd direction)) xMax yMax

    let getDirections =
        [ (-1, 0); (-1, -1); (0, -1); (1, -1); (1, 0); (1, 1); (0, 1); (-1, 1) ]

    let rec amountFromPoint chart word x y xMax yMax directions sum =
        match directions with
        | [] -> sum
        | d :: ds ->
            if hasWord chart word d x y xMax yMax then
                amountFromPoint chart word x y xMax yMax ds (sum + 1)
            else
                amountFromPoint chart word x y xMax yMax ds sum

    let firstWord = [ 'X'; 'M'; 'A'; 'S' ]

    let rec amountOnChart chart word x y xMax yMax sum =
        if y = yMax then
            sum
        elif x = xMax then
            amountOnChart chart word 0 (y + 1) xMax yMax sum
        else
            amountOnChart
                chart
                word
                (x + 1)
                y
                xMax
                yMax
                (sum + (amountFromPoint chart word x y xMax yMax getDirections 0))

    let firstPuzzle chart x y = amountOnChart chart firstWord 0 0 x y 0


    let isXmas x y (chart: System.Collections.Generic.IReadOnlyDictionary<(int * int), char>) =
        chart[(x, y)] = 'A'
        && (chart[((x - 1), (y - 1))] = 'M' && chart[((x + 1), (y + 1))] = 'S'
            || chart[((x - 1), (y - 1))] = 'S' && chart[((x + 1), (y + 1))] = 'M')
        && (chart[((x - 1), (y + 1))] = 'M' && chart[((x + 1), (y - 1))] = 'S'
            || chart[((x - 1), (y + 1))] = 'S' && chart[((x + 1), (y - 1))] = 'M')

    let rec countXmases chart x y xMax yMax sum =
        if y = yMax then
            sum
        elif x = xMax then
            countXmases chart 1 (y + 1) xMax yMax sum
        elif isXmas x y chart then
            countXmases chart (x + 1) y xMax yMax (sum + 1)
        else
            countXmases chart (x + 1) y xMax yMax sum

    let secondPuzzle chart x y = countXmases chart 1 1 (x - 1) (y - 1) 0
