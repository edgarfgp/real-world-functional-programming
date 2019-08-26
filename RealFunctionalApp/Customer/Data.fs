namespace Customer

open Customer.Domain

module Data =

  let customers = [
        { Name = "Edgar"
          Surname = "Gonzalez"
          FullName = None
          Active = true
          Total = 05.0M<Euro>
          Discount = Some 0.0M<Euro>
          Address =
              { Street = "Kendal House"
                Town = "Islington"
                City = London
                Country = UK
                PostalCode = "N19DE" } }

        { Name = "Oscar"
          Surname = "Gonzalez"
          FullName = None
          Active = false
          Total = 05.0M<Euro>
          Discount = Some 0.0M<Euro>
          Address =
              { Street = "Kendal House"
                Town = "Getafe"
                City = Madrid
                Country = Spain
                PostalCode = "N19DE" } }

        { Name = "Manuel"
          Surname = "Gonzalez"
          FullName = None
          Active = true
          Total = 05.0M<Euro>
          Discount = Some 0.0M<Euro>
          Address =
              { Street = "Kendal House"
                Town = "District 1"
                City = Paris
                Country = France
                PostalCode = "N19DE" } }

        { Name = "Madelin"
          Surname = "Gonzalez"
          FullName = None
          Active = false
          Total = 05.0M<Euro>
          Discount = Some 0.0M<Euro>
          Address =
              { Street = "Kendal House"
                Town = "Angel"
                City = London
                Country = UK
                PostalCode = "N19DE" } }

        { Name = "Alba"
          Surname = "Gonzalez"
          FullName = None
          Active = true
          Total = 25.0M<Euro>
          Discount = Some 0.0M<Euro>
          Address =
              { Street = "Kendal House"
                Town = "Angel"
                City = Madrid
                Country = Spain
                PostalCode = "N19DE" } }

        { Name = "Eleni"
          Surname = "Gonzalez"
          FullName = None
          Active = false
          Total = 25.0M<Euro>
          Discount = Some 0.0M<Euro>
          Address =
              { Street = "Kendal House"
                Town = "Angel"
                City = London
                Country = UK
                PostalCode = "N19DE" } }

        { Name = "Juan"
          Surname = "Gonzalez"
          FullName = None
          Active = true
          Total = 05.0M<Euro>
          Discount = Some 0.0M<Euro>
          Address = {
              Street = "Kendal House"
              Town = "Angel"
              City = Paris
              Country = France
              PostalCode = "N19DE" } }

        { Name = "Juan"
          Surname = "Gonzalez"
          FullName = None
          Active = false
          Total = 05.0M<Euro>
          Discount = Some 0.0M<Euro>
          Address =
              { Street = "Kendal House"
                Town = "Angel"
                City = Paris
                Country = France
                PostalCode = "N19DE" } }
     ]
