// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.
open calculation.series
open System

[<EntryPoint>]
let main argv =
  while true do 
    Console.WriteLine "Insert the parameters to calculate the series "
    Console.WriteLine "Please insert the first paramter (x) "
    let x = Console.ReadLine() |> float
    Console.WriteLine "Please insert the second paramter (y) "
    let y = Console.ReadLine() |> float
    Console.WriteLine "Please insert how many element you want to calculate in the series "
    let ln = Console.ReadLine() |> int

    let myseries = CalculateSeries x y ln
    //printfn "%A" myseries

    Console.WriteLine "Now let's calculate the two special number"
    Console.WriteLine "The first special number is " 
    printfn "%A" SpecialNumber1
    Console.WriteLine "Please insert the parameter to calculate 2nd special number (y1/z)"
    Console.WriteLine "Insert the first one (y1) "
    let y1 = Console.ReadLine() |> float
    Console.WriteLine "Insert the second one (z) "
    let z = Console.ReadLine() |> float
    Console.WriteLine "The second special number is " 
    printfn "%f" (SpecialNumber2 y1 z myseries)


  0 // return an integer exit code

