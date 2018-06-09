
Source : Learn Parallel Programming with C# and .NET     
By : Dmitri Nesteruk             

*All of this source are based on his lecture in Udemy.*
# Chapter 1 
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
  
  
# Chapter 2 - Data Sharing and Synchronization
* Critical Sections
* Interlocked Operations
* Spin Locking and Lock Recursion
* Mutex    
* Reader-Writer Locks

* Atomic?
- An operation is *atomic* if it cannot be interrupted.
  
  ## Critical Sections
- Uses the lock keyword
- Typically locks on an existing object.
  - Best to make a new object to lock on.
- A shorthand for Monitor.Enter() / Exit()
- Blocks until a lock is available 


## Interlocked Operations
- Useful for atomically changing low-level primitives
- Interlocked.Increment() / Decrement()
- Interlocked.Add()
- Exchange() / CompareExchange()

## Spin Locking and Lock Recursion 
- A spin lock waste CPU cycles without yielding.
  - Useful for brief pauses to prevent rescheduling.
- Enter() to take, Exit() release (if taken successfully)
- Lock Recursion = ability to enter a lock twice on the same thread.
- SpinLock X support lock recursion.
- Owner Tracking helps keep a record of thread that acquired the lock.





  ## mutex  
  Source : https://www.dotnetperls.com/mutex       
  Mutex means mutual exclusion. The mutex type ensures blocks of code are executed only once at a time.
  It provides a way to use system-wide synchronization, and synchoronize 
  threads within a single program.
- can be used for interprocess synchronization. 
- Two or more threads need to access a shared resource, the system needs a
  synchronization to ensure that only one thread at a time uses the resource.
  
  
- A WaitHandle-derived synchronization primitive
- WaitOne() to acquire.
- ReleaseMutex() to release.
- Mutex.WaitAll() to acquire several
  
  
  ## ReaderWriterLockSlim 
  resource : https://msdn.microsoft.com/ko-kr/library/system.threading.readerwriterlockslim(v=vs.110).aspx     
  - Represents a lock that is used to manage access to a resource, allowing multiple threads for reading
    or exclusive access for writing.
  - Use this to protect a resource that is read by multiple threads and written to by one
  thread at a time.
  
    
    
  
  
  
