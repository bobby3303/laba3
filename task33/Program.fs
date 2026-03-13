open System
open System.IO

// Проверка расширения
let checkFile (f: string) (c: char) =
    let ext = Path.GetExtension(f)
    ext.Length > 1 && Char.ToLower(ext.[1]) = Char.ToLower(c)

let getFiles path c =
    Directory.EnumerateFiles(path) 
    |> Seq.filter (fun f -> checkFile f c)
    |> Seq.map Path.GetFileName 

// Проверка на существование пути
let rec getPath () =
    printf "Введите путь к папке: "
    let path = Console.ReadLine()
    if Directory.Exists(path) then 
        path 
    else
        printfn "Ошибка: папка не найдена!"
        getPath ()

let rec getChar () =
    printf "Введите символ расширения: "
    let s = Console.ReadLine()
    if not (String.IsNullOrEmpty(s)) then
        s.[0]
    else
        printfn "Ошибка: вы ничего не ввели!"
        getChar ()

[<EntryPoint>]
let main _ =
    let path = getPath()
    let c = getChar() 

    printfn "\nНайденные файлы:"
    getFiles path c
    |> Seq.iter (printfn "- %s")

    0
