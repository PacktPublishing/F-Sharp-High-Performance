namespace ProviderImplementation

open System.Reflection
open Microsoft.FSharp.Quotations
open Microsoft.FSharp.Core.CompilerServices
open ProviderImplementation.ProvidedTypes

[<TypeProvider>]
type BasicProvider (config : TypeProviderConfig) as this =
    inherit TypeProviderForNamespaces ()

    let ns = "StaticProperty.Provided"
    let asm = Assembly.GetExecutingAssembly()
    let ctxt = ProvidedTypesContext.Create(config)

    let createTypes () =
        let myType = ctxt.ProvidedTypeDefinition(asm, ns, "MyType", Some typeof<obj>)
        let myProp = ctxt.ProvidedProperty("MyProperty", typeof<string>, IsStatic = true, getterCode = (fun args -> <@@ "Hello world" @@>))
        myType.AddMember(myProp)
        [myType]

    do
        this.AddNamespace(ns, createTypes())

[<assembly:TypeProviderAssembly>]
do ()