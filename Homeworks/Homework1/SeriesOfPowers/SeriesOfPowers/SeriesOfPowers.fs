module SeriesOfPowers

let seriesOfPowers n m =
    let rec getSeriesOfPowers acc i =
        match i with
        | 0 -> Some(acc)
        | _ -> getSeriesOfPowers ((List.head acc / 2) :: acc) (i - 1)

    if n >= 0 && m >= 0 then getSeriesOfPowers [pown 2 (n + m)] m
    else None
