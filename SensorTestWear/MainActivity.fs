namespace SensorTestWear

open System
open Android.App
open Android.Content
open Android.OS
open Android.Runtime
open Android.Views
open Android.Widget

[<Activity(Label = "SensorTestWear", MainLauncher = true)>]
type MainActivity() = 
    inherit Activity()
    let mutable count : int = 1
    override this.OnCreate(bundle) = 
        base.OnCreate(bundle)
        // Set our view from the "main" layout resource
        this.SetContentView(Resource_Layout.Main)
        // Get our button from the layout resource, and attach an event to it
        let button = this.FindViewById<Button>(Resource_Id.myButton)
        button.Click.Add(fun args -> 
            button.Text <- sprintf "%d clicks!" count
            count <- count + 1)

    override this.OnStop() = 
       base.OnStop()

    //this is only needed for
    //the linker to not stip out the "OnCompleted" method
    interface IObserver<string> with
        member x.OnCompleted() = ()
        member x.OnError(y) = ()
        member x.OnNext(y) = ()

       
