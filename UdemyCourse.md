# Parallel Programming 

Source : Learn Parallel Programming with C# and .NET     
By : Dmitri Nesteruk             

*All of this source are based on his lecture in Udemy.*

## Task
- Task is a unit of work that takes a function.
  - new Task(function), t.Start()
  - Task.Factory.StartNew(function)
- Task can be passed an object.
- Task can return values.
  - new Task<T>, task.Result
  
  
## Cancellation
- Cancellation of tasks is supported via 
  - CancellationTokenSource, which returns a
  - CancellationToken token = cts.Token
- The token is passed into the function
  - E.g. Task.Factory.StartNew(..., token)
- To cancel, we call cts.Cancel()
- Cancelation is cooperative
  - Task can check token.IsCancellationRequested and 'soft fail' or
  - Throw an exception via token.ThrowIfCancellationRequested()
  

## Waiting for Time to pass
- Thread.Sleep(msec)
- token.Waithandle.WaitOne(msec)
  - Returns a bool indicating whether cancellation was requested in the time period specified.
- Thread.SpinWait()
- SpinWait.SpinUntil(function)
- Spin waiting does not give up the thread's turn.

## Waiting for Tasks
- Waiting for single Task.
  - task.Wait(Optional timeout)
- Waiting for several Tasks
  - Task.WaitAll(), Task.WaitAny
- WaitAny / WaitAll will throw on Cancellation.


## Exception Handling
- An unobserved task exception will not get handled.
- task.Wait() or Task.WaitAny()/ WaitAll() will catch an ...
  - AggregateException
  - Use ae.InnerExceptions to iterate all exceptions caught.
  - Use ae.Handle(e=> {...}) to selectively handle exceptions.
    - Return true if handled, false otherwise.
  
  
