namespace real_world_functional_programming.BadToGood

module OptionExamples =
    type BillingDetails =
        {
            name: string
            billing: string
            delivery: string option }

    let addressForPackage details =
        let address = Option.defaultValue details.billing details.delivery
        address

    let address = addressForPackage { name = "Edgar"; billing = "Billing Address"; delivery = None }


    let addressForPackage2 details =
            let address =
                 details.delivery
                 |> Option.defaultValue details.billing
            sprintf "%s\n%s" details.name address
