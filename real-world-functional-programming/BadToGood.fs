namespace real_world_functional_programming.BadToGood
open Microsoft.VisualBasic.CompilerServices

module OptionExamples =
    type BillingDetails = {
        name: string
        billing: string
        delivery: string option }

    let printDeliveryAddress (details: BillingDetails) =
        details.delivery
        |> Option.iter
            (fun address -> printfn "Delivery address:\n%s\n%s" details.name address)

    let myOrder =
        { name = "Edgar Gonzalez"
          billing = "62 Kendall House"
          delivery = Some "62 Kendall House" }

    let result = myOrder |> printDeliveryAddress

    let myApiFunction stringParam =
        let s =
            stringParam
            |> Option.ofObj
            |> Option.defaultValue "(none)"
        // You can do things here knowing that s isn't null
        printfn "%s" (s.ToUpper())

    myApiFunction "hello"

    myApiFunction null

    open System

    let showHeartRate (rate: Nullable<int>) =
        rate
        |> Option.ofNullable
        |> Option.map (fun r -> r.ToString())
        |> Option.defaultValue "N/A"
    //96
    showHeartRate (System.Nullable(96))
    // N/A
    showHeartRate (System.Nullable())

