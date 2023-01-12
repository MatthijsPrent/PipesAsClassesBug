namespace PipesAsClassesBug.Test

open System
open System.Reflection
open NUnit.Framework
open PipesAsClassesBug.SomeMethods

module SomeMethods =

    [<Test>]
    let containsParameterTest () =
        let methodInfo = MockData.stringLength.GetType().GetMethods()

        let result = containsParameter "" "" methodInfo.[0]

        Assert.IsFalse(result)

    [<Test>]
    let getMethodsWithAttributeInTypeTest() =
        let mockType = MockData.methodWithAttribute.GetType()
        let result = getMethodsWithAttributeInType mockType "TestAttribute"
        Assert.AreEqual(result.Length, 0)
