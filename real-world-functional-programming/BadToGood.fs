namespace real_world_functional_programming.BadToGood

module BadCode =
    let addInterest (interestType: int, amt: float, rate: float, y: int) =
        let mutable amt = amt
        let mutable intType = interestType
        if intType <= 0 then intType <- 1
        if intType = 1 then
            let yAmt = amt * rate / 100.
            amt + yAmt * (float y)
        else
            amt * System.Math.Pow(1. + (rate / 100.), float y)
