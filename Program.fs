// Дополнительные сведения о F# см. на http://fsharp.org
// Дополнительную справку см. в проекте "Учебник по F#".

let D a b c = b*b-4.0*a*c

let X1 a b c = 
        (-b+sqrt(D a b c))/(2.0*a)

let X2 a b c = 
        (-b-sqrt(D a b c))/(2.0*a)

let X a b c = 
    let d = D a b c
    if(d > 0.0) then
        Some((X1 a b c, X2 a b c))
    else
        None

[<EntryPoint>]
let main argv = 
    let a = System.Convert.ToDouble(System.Console.ReadLine())
    let b = System.Convert.ToDouble(System.Console.ReadLine())
    let c = System.Convert.ToDouble(System.Console.ReadLine())
    

    let res = X a b c
    if res = None then
        System.Console.WriteLine("Bruh Bruh Bruh")
    else
        System.Console.WriteLine(Option.get(res))
    0 // возвращение целочисленного кода выхода
