namespace PipesAsClassesBug

open System
open System.Reflection

module SomeMethods =
    let hello name =
        printfn "Hello %s" name


    let containsParameter (name: string)(typename: string) (methodinfo: MethodInfo) =
        methodinfo.GetParameters()
        |> Seq.map(fun paraminfo -> paraminfo.Name + paraminfo.ParameterType.Name)
        |> Seq.contains  (name + typename)

    let getMethodsWithAttributeInType (input: Type)(attributeName: string) =
            input.GetMethods()
            |> Seq.cast<MethodInfo>
            |> Seq.toList
            |> List.filter (fun method ->
                method.CustomAttributes
                |> Seq.exists (fun (e: CustomAttributeData) -> e.AttributeType.Name = attributeName))  

    // The following algoritms are borrowed from https://github.com/TheAlgorithms/F-Sharp
    // with the purpose of filling this module with some logic.

    let rec BubbleSort list: 'T [] =
        let mutable updated = false
        let mutable list = list |> Array.copy
        for index in 0 .. list.Length - 1 do
            if index < list.Length - 1 then
                let current = list.[index]
                let next = list.[index + 1]
                if next < current then
                    list.[index] <- next
                    list.[index + 1] <- current
                    updated <- true
        if updated then list <- BubbleSort list
        list


        
    let quickSort lst =
        let rec aux l cont =
            match l with
            | [] -> cont []
            | pivot :: rest ->
                let left, right =
                    rest |> List.partition (fun i -> i < pivot)

                aux left (fun acc_left -> aux right (fun acc_right -> cont (acc_left @ pivot :: acc_right)))

        aux lst (id)

    let GnomeSort list: 'T [] =
        let mutable list = list |> Array.copy
        let mutable first = 1
        let mutable second = 2
        while first < list.Length do
            if list.[first - 1] <= list.[first] then
                first <- second
                second <- second + 1
            else
                let tmp = list.[first - 1]
                list.[first - 1] <- list.[first]
                list.[first] <- tmp
                first <- first - 1
                if first = 0 then
                    first <- 1
                    second <- 2
        list
