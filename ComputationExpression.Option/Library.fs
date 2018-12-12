namespace ComputationExpression.Option

module OptionBuilder =
    type OptionBuilder() =

        member this.Bind(m, f) = 
            Option.bind f m

        member this.Return(x) = 
            Some x

        member this.ReturnFrom(x) = 
            x

        member this.Zero() = 
            None

        member this.Combine (a,b) = 
            match a with
            | Some _ -> a
            | None -> b()

        member this.Delay(f) = 
            f

        member this.Run(f) = 
            f()

[<AutoOpen>]
module Global =

    let maybe = new OptionBuilder.OptionBuilder()

