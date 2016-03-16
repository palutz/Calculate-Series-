module calculation.series

open System

/// Calculate the first number of the series based upon the parameter x
let FirstNumber a = 
  match a with
  | 0.0 -> 0.0
  | _ -> ((a * a)/2.0 + (30.0 * a) + 10.0)/25.0

/// Calculate the growth rate of the series, based on the parameter y and the first number previously calculated
let GrowthRate b firstNumb = 
  match firstNumb with 
  | 0.0 -> 0.0
  | _ -> (0.02 * b)/25.0/firstNumb

/// Rounding to the closest 0.25
let RoundtoTheClosest025 x =
  match x with 
  | 0.0 -> 0.0
  | _ -> (x * 4.0 |> System.Math.Round) / 4.0

/// Calculate the parameters for the series, returned in a tuple
let GetSeriesParam x y =
  let first = FirstNumber x |> RoundtoTheClosest025
  let second = GrowthRate y first |> RoundtoTheClosest025
  (first, second)

/// Main method: calculate the series and return the selected range
let CalculateSeries (x:float) (y:float) (ln:int) =
  let param = GetSeriesParam x y
  let myseq = Seq.initInfinite (fun idx ->
    match idx with
    | 0 -> fst param
    | _ -> (snd param) * ((fst param) ** (float idx)) |> RoundtoTheClosest025
  )
  // now converting in a set (ordered and with unique values)
  let setofValues = myseq |> Seq.take (ln * 4) |> Set.ofSeq
  let arrRes = setofValues |> Set.toArray
  // taking the requested subset 
  match ln with 
  | 0 -> Array.empty<float>
  | _ -> if(arrRes.Length > ln) then arrRes.[0 .. (ln - 1)] else arrRes


/// Calculate the third largest number in the series
let SpecialNumber1 (arrSeries : float[]) =
  if arrSeries.Length >= 3 then arrSeries.[arrSeries.Length - 3]
  else 0.0


/// Calculate the second special number, seeking the closest in the series to the result of the calculation y/z (took as input)
let SpecialNumber2 (y:float) (z:float) (arrSeries : float[]) =
  let approxNum = match z with 
                  | 0.0 -> 0.0
                  | _ -> y/z
  // map all the element with the delta to the number to approximate (tuple), then find the min delta
  let mapped = arrSeries |> Array.map (fun x -> Math.Abs (x - approxNum))
  // find the min value (minize the delta
  let minValue = mapped |> Array.min
  // find the poistion for the closest value
  let minIndex = mapped |> Array.findIndex ((=) minValue)
  // check if the next element has the same delta, to pick up the last index of the same min value
  if minIndex < arrSeries.Length - 1 && mapped.[minIndex] = mapped.[minIndex + 1] then arrSeries.[(minIndex + 1)]
  else arrSeries.[minIndex]

//SpecialNumber2 (3.0) (2.0) [|0.5; 1.0; 2.0; 3.0; 4.0 |]
// CalculateSeries 1.0 2.0 30 |> Array.iter(fun s -> printfn "%A" s) 