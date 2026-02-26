open System

let inv x:float =
    1./x

let List_input n= 
    [
        for i in 1..n do 
            printf "введите элемент:"
            yield (inv (float (Console.ReadLine()) ))
    ]


let chek_num_on_correct n: int = 
    if n <=0 then
        printfn "количество элементов должно быть натуральным числом"
        1
    else
        0


[<EntryPoint>]
let main _ =
    printf "Введите количество элементов списка:"
    let n = int(Console.ReadLine()) // добавить проверку типов
    if (chek_num_on_correct n)=0 then
        let l = List_input n
        printfn "элементы списка, обратные введённым: %A" l

    0
