namespace PipesAsClassesBug.Test
open NUnit.Framework

module MockData =
    let stringLength (input: string) =
        input.Length

    let addStrings (a: string)(b: string) =
        a + b

    let addInts (a: int)(b: int) =
        a + b

    [<Test>]
    let methodWithAttribute() =
        "Some string" |> ignore
        Assert.Pass()





