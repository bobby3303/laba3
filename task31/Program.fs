open System

let rec inputCount () =
    printfn "Введите количество элементов:"
    match Int32.TryParse(Console.ReadLine()) with
    | true, n when n >= 1 -> n
    | _ -> 
        eprintfn "Ошибка: введите целое положительное число!"
        inputCount ()

let rec buildSeq cnt =
    seq {
        if cnt > 0 then
            printf "Введите число (1-9): "
            match Int32.TryParse(Console.ReadLine()) with
            | true, value when value >= 1 && value <= 9 ->
                yield value              
                yield! buildSeq (cnt - 1) 
            | _ ->
                eprintfn "Ошибка: введите целое число от 1 до 9"
                yield! buildSeq cnt     
    }

let rec toBinary n =
    if n = 0 then 
        "0"
    elif n = 1 then 
        "1"
    else 
        (toBinary (n / 2)) + (string (n % 2))

[<EntryPoint>]
let main args = 
    let cnt = inputCount()
    
    let inSeq = buildSeq cnt

    let binSeq = inSeq |> Seq.map toBinary

    printfn "\nРезультат обработки последовательности:"
    binSeq |> Seq.iter (printfn "Число в двоичной системе: %s")

    0
