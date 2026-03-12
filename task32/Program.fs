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
            printf "Введите число (0-9): "
            match Int32.TryParse(Console.ReadLine()) with
            | true, value when value >= 0 && value <= 9 ->
                yield value              // Выдаем число
                yield! buildSeq (cnt - 1) // Просим остальное
            | _ ->
                eprintfn "Ошибка: введите число от 0 до 9"
                yield! buildSeq cnt
    }

let digitToWord n =
    match n with
    | 0 -> "ноль"
    | 1 -> "один"
    | 2 -> "два"
    | 3 -> "три"
    | 4 -> "четыре"
    | 5 -> "пять"
    | 6 -> "шесть"
    | 7 -> "семь"
    | 8 -> "восемь"
    | 9 -> "девять"
    | _ -> "неизвестно"

let folder acc n =
    let word = digitToWord n
    if acc = "" then 
        word
    else 
        acc + "; " + word

[<EntryPoint>]
let main args = 
    let cnt = inputCount()
    let inSeq = buildSeq cnt

    // Seq.fold начинает "вытягивать" числа из последовательности по одному и склеивать их в итоговую строку.
    let result = Seq.fold folder "" inSeq

    printfn "\nОбработка завершена."
    printfn "Итоговая строка: «%s»" result

    0
