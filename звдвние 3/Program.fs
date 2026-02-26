open System

// операции над комплексными числами. Будем считать, что список из 2 чисел - комплексное число. ( <действительная часть> ,<мнимая часть>)
exception QuitException

let complex_out (d:float, m:float) = 
    if m>0 then
        printfn "%f+%fi" d m
    elif m = 0 then
        printfn "%f" d
    else 
        printfn "%f%fi" d m


let complex_sum (d1, m1) (d2, m2) =
    (d1+d2), (m1 + m2)

let complex_sub (d1, m1) (d2, m2) =
    (d1-d2), (m1 - m2)

let complex_mul (d1, m1) (d2, m2) = 
    (d1*d2 - m1*m2), (d1*d2 + m1*m2)

let complex_div  (d1, m1) (d2, m2) = 
    (d1*d2 + m1*m2)/(d1*d1 + m2*m2), (m1*d2 - d1*m2)/(d2*d2 + m2*m2)


let complex_input () =
    printf "введите действительную часть:"
    let input1 = Console.ReadLine()
    if input1="q" then
        raise QuitException
    printf "введите мнимую часть:"
    let input2 = Console.ReadLine().Replace("i", "")
    if input2 = "q" then
        raise QuitException
    (float(input1)),(float(input2))
        
    


let operation_choise ((a,b), op) =
    if op = "q" then
        raise QuitException
    match op with
    | "+" -> complex_sum a b
    | "-" -> complex_sub a b
    | "*" -> complex_mul a b
    | "/" -> complex_div a b
    
    
[<EntryPoint>]
let main _ =
    printfn "калькулятор комплексных чисел. введите q для выхода" 
    let rec main_loop () = 
        try
            printfn "\nвведите первое комплексное число"
            let first_complex_num = complex_input ()
            complex_out first_complex_num
            printfn "введите второе комплексное число в формате '<действительная часть> + <мнимая часть>i':"
            let second_complex_num = complex_input ()
            complex_out second_complex_num
            printfn "введите операцию (+-*/):"
            let res = operation_choise ( (first_complex_num , second_complex_num), (Console.ReadLine()) )
            printf "результат:"
            complex_out res
            main_loop ()
        with
        | QuitException ->
            printfn "Выход..."
            0
        | _ ->
            printfn "синтаксическая ошибка!"
            main_loop ()
    main_loop()
    0