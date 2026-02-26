open System

let rec count_odd_num n  : int=
    if n>0 then
        if (n%10)%2=0 then
            1+ count_odd_num (n/10)
        else
            count_odd_num (n/10) 
    else 
        0


[<EntryPoint>]
let main _ =
    printfn "счёт чётных цифр числа. введите q для выхода\n"
    let rec main_loop () = 
        printf "введите число: "
        let input = Console.ReadLine()
        if input = "q" then 
            0
        else
            let x = int(input)
            printfn "в числе %i количество чётных цифр = %i " x (count_odd_num x) 
            main_loop ()
    main_loop ()
    0
