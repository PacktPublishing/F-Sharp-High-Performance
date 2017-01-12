
#r "C:\\Program Files (x86)\\Reference Assemblies\\Microsoft\\Framework\\.NETFramework\\v4.6.1\\WindowsBase.dll"
#r "C:\\Program Files (x86)\\Reference Assemblies\\Microsoft\\Framework\\.NETFramework\\v4.6.1\\PresentationCore.dll"
#r "C:\\Program Files (x86)\\Reference Assemblies\\Microsoft\\Framework\\.NETFramework\\v4.6.1\\PresentationFramework.dll"
#r "C:\\Program Files (x86)\\Reference Assemblies\\Microsoft\\Framework\\.NETFramework\\v4.6.1\\System.Xaml.dll"

open System
open System.Windows
open System.Windows.Controls
 
[<AbstractClass>]
type IComposableControl<'a when 'a :> FrameworkElement> () =
    abstract Control : 'a
    abstract Bind : FrameworkElement * (FrameworkElement -> 'a) -> 'a
    abstract Bind : IComposableControl<'b> * (System.Windows.FrameworkElement -> 'a)  -> 'a
    member this.Return (e: unit)  = this.Control
    member this.Zero () = this.Control
 
type WindowBuilder() =
    inherit IComposableControl<Window>()
    let win = Window(Topmost=true)
    override this.Control = win
    override this.Bind(c: FrameworkElement, body: FrameworkElement -> Window) : Window =
        win.Content <- c
        body c
    override this.Bind(c: IComposableControl<'b>, body: FrameworkElement -> Window) : Window =
        win.Content <- c.Control
        body c.Control
 
type PanelBuilder(panel: Panel) =
    inherit IComposableControl<Panel>()
    override this.Control = panel
    override this.Bind(c: FrameworkElement, body: FrameworkElement -> Panel) : Panel=
        if c :? Window then
            raise (ArgumentException("Window cannot be added to panel"))
        else
            panel.Children.Add(c) |> ignore
            body c
    override this.Bind(c: IComposableControl<'b>, body: FrameworkElement -> Panel) : Panel=
        panel.Children.Add(c.Control) |> ignore
        body c.Control
    // Implement the code for constructor with no argument.
    new() = PanelBuilder(StackPanel())
 
let win =
    WindowBuilder()
        {   let! panel =
                PanelBuilder(StackPanel())
                    {   let! btn1 = Button(Content = "Hello")
                        let! btn2 = Button(Content = "World")
                        return () }
            return () }

do win.Show() // Pops up the window in FSI.

let winzero = WindowBuilder() 
               { Console.WriteLine("sample Zero") }

do winzero.Show()

let windowexp = WindowBuilder()
let secondWindow = windowexp 
                        { 
                            let! panel =
                                PanelBuilder(StackPanel())
                                    { 
                                        let! btn1 = Button(Content = "Hello")
                                        let! btn2 = Button(Content = "Second computation expression")
                                        return ()
                                    }
                           return ()
                        }

let testUnimplementedYieldWindow =
    windowexp 
        {
            let! panel = 
                PanelBuilder(StackPanel())
                    {
                        let! textblock01 = TextBox(Text = "test")
                        //yield button = Button("World") // <- use to test not implemented yield
                        return ()
                    }
            return ()
        }