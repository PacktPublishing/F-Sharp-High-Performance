module WPFComputationExpression

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
