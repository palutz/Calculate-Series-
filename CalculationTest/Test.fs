module CalculationTest

open System
open FsUnit
open NUnit.Framework

open calculation.series


[<Test>]
let FirstNumberShouldbeZeroifZeroPassed () =
  let expected = 0.0
  FirstNumber 0.0 |> should equal expected

[<Test>]
let FirstNumberShouldBeReturnTherightNumber () =
  let x = 1.0
  let expected = 1.62
  FirstNumber x |> should equal expected


[<Test>]
let GrowthRateShouldbeZeroifZeroPassed () =
  let expected = 0.0
  GrowthRate 0.0 |> should equal expected

[<Test>]
let GrowthRateShouldBeReturnTherightNumber () =
  let y = 5062.5
  let expected = 2.5
  FirstNumber y |> should equal expected

[<Test>]
let CalculateSeriesReturnTheRightNumberOfElement() = 
  let lnt = 5
  let x = 1.0
  let y = 5062.5
  let series = CalculateSeries x y lnt
  series.Length |> should equal lnt

[<Test>]
let CalcultateSeriesReturnRightElements () =
  let expected = [| 1.5; 4.0; 6.5; 10.75; 17.25 |]
  let lnt = 5
  let x = 1.0
  let y = 5062.5
  let series = CalculateSeries x y lnt
  series = expected |> should equal true

[<Test>]
let SpecialNumber1Return0ifSeriesEmpty () =
  let expected = 0.0
  Array.empty<float> |> SpecialNumber1 |> should equal expected


[<Test>]
let CalculateSpecilaNumber1ReturnRightValue () =
  let expected = 6.5
  let lnt = 5
  let x = 1.0
  let y = 5062.5
  (CalculateSeries x y lnt) |> SpecialNumber1 |> should equal expected 

let CalculateSpecialNumber2ReturnRightValue () = 
  let expected = 6.5
  let lnt = 5
  let x = 1.0
  let y = 5062.5
  let y1 = 1000.0
  let z = 160.0
  (CalculateSeries x y lnt) |> SpecialNumber2 y1 z |> should equal expected 