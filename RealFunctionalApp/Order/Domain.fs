namespace Order

module Domain =

    [<Measure>] type Euro
    [<Measure>] type GBP
    
    let poundsPerEuro = 0.899761M<GBP/Euro>
    let eurosPerPound = 1.111406M<Euro/GBP>
    
    let round (dp:int) (number:decimal) =
        System.Decimal.Round(number, dp)
    
    let eurosToDecimal (euros:decimal<Euro>) : decimal =
        euros / 1.0M<Euro>
    //Can I remove this duplication ^ V ^
    let poundsToDecimal (pounds:decimal<_>) : decimal =
        pounds / 1.0M<GBP>
    
    let toEuros number =
        number * 1.0M<Euro>
        
    let toPounds number =
        number * 1.0M<GBP>
    
    let poundsToEuros (dp:int) pounds =
          pounds * eurosPerPound
          |> eurosToDecimal // would be nice not to have to convert to decimal to round
          |> round dp
          |> toEuros //then anther conversion! 
          
    let eurosToPounds (dp:int) (euros:decimal<Euro>) =
        euros * poundsPerEuro
        |> poundsToDecimal // would be nice not to have to convert to decimal to round
        |> round dp
        |> toPounds //then anther conversion! 
    
    type Country = | Spain | UK | France

    type City = | London | Madrid | Paris

    type Address =
        { Street: string
          Town: string
          City: City
          PostalCode: string
          Country: Country }

    type Gender =
        | Male
        | Female
        | Unspecified
    
        //https://stackoverflow.com/questions/13567081/creating-a-list-with-multiple-units-of-measurements-of-floats-in-f
        //Thank you Tomas Petricek!
        type Currency =
        | Euros of decimal<Euro>
        | BritishPounds of decimal<GBP> 
        
            static member (+) (x,y) =
                match x, y with
                | (BritishPounds a, Euros b) -> BritishPounds (a + eurosToPounds 7 b)
                | (Euros a, BritishPounds b) -> Euros (a + poundsToEuros 7 b)
                | (BritishPounds a, BritishPounds b) -> BritishPounds (a+b)
                | (Euros a, Euros b) -> Euros (a + b)
                
                // Not over the moon with this solution:
                // its not very open close...if/when I add a third currency I need to update this method - exponential growth
                // Plus, several cases would be the same: ie from <'a> + <'a> = <'a>
                
                //Also not really sure that making this a member on the Currency type is the right place to do this.
                //Maybe a 'ConvertTo' function would be better  
        
        
    type Customer =
        { Name: string
          Surname: string
          Gender: Gender
          Active: bool
          Address: Address
          Total: Currency
          Discount: Currency option } with
        
        member this.FullName = 
            this.Name + " " + this.Surname
