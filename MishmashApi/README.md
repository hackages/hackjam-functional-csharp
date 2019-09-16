# HackJam C#: The Functional Way
In this hackjam you'll learn the main concepts in functional programming and the C# features that makes your code more functional !

## Getting Started
```Bash
git clone https://github.com/hackages/hackjam-functional-csharp.git
cd hackjam-functional-csharp/MishmashApi
dotnet watch run
cd ../TestApp
npm run start
```

## Exercices

* 01. Fibonacci -> FibonacciImplementations.cs
* 02. Function  -> FunctionImplementations.cs
* 03. Inventory -> InventoryImplementations.cs

## Some functional concepts before we start
### Pure Functions
A pure function is a function where the return value is only determined by its input values, without observable side effects.
It means that for each set of inputs, there exists a determined output.

Example: Pure vs Impure
```csharp
//Impure Function
public static bool IsPast (DateTime date){
  return DateTime.Now > date;
}

//Pure Function
public static bool IsPast (DateTime date, DateTime now){
  return now > date;
}
```
Starting from there, we can compose several functions together...

### Function Composition
Function composition means that two or more functions are chained together so that the result of the first function is past as an argument to the next function and so on.

Example: Function Composition
```csharp

//We have two pure functions...

public static int Addition (int first, int second) => first + second;
public static int Square (int number) => number * number;

//We can then compose them to retrieve the square of an addition!

var result = Square(Addition(2,2));
Console.WriteLine(result); // Will print "16"
```

### Memoization
Memoization is an optimization technique where the result of a pure function is stored before retrieving it.
Thereby, the next time that the function is called with the same parameters as before, it will retrieve the cached result instead of recalculate it.

```csharp
public long ComputeWithMemoization(long l)
{
    //We use a dictionary to cache computed values
    
    var cache = new Dictionary<long, long>();
    var computedOrCachedValue = cache.ContainsKey(l) ? cache[l] : Compute(l);
    return computedOrCachedValue;
}

public long Compute(long l)
{
    var computed = 0L;
    //Very expensive calculation
    return computed;
}
```

### Data Immutability
Data Immutability is the concept of having objects wich state doesn't change once they are created. 
If we want to update the state of an object, we should create a new one with the updated properties of the previous one.

In this manner, we can avoid most of the concurrency problems that we run into with mutable object (most of the concurrency bugs are caused by mutable state shared between threads). 

## Some C# functional features

### Extension Methods
An Extension method is a static method of a static class, where the "this" modifier is applied to the first parameter. It enables you to add methods to an exising type (the type of the first parameter) without creating a new derived type, recompiling, or otherwise modifying the original type. 

```csharp
//Definition of an extension method in it static class
public static class StringExtensions {

  public static char LastCharacter (this string str) => str[str.Length -1];
  
}

//We can then use that method inside of our code

var myString = "Hello";
var lastCharacter = myString.LastCharacter(); // Same as StringExtensions.LastCharacter(myString);
Console.WriteLine(lastCharacter);             // Will print "o"
```
Hint : Function composition and Extension methods go well together...

### Pattern Matching
Pattern matching provides more concise syntax for algorithms that test the shape and the data of a particular object.

#### [is](https://docs.microsoft.com/en-us/dotnet/csharp/pattern-matching#the-is-type-pattern-expression) statement
```csharp
var entity = new EntityA { Value = "Hello" }; //EntityA is a custom class...

if(entity is EntityA) {
  // Test passed
}

if(entity is EntityA a && a.Value == "Hello") {
  // Test passed
}

if(entity is EntityA a && a.Value == string.Empty) {
  // Test not passed
}

if(entity is EntityB) {
  // Test not passed
}

```
#### [switch](https://docs.microsoft.com/en-us/dotnet/csharp/pattern-matching#using-pattern-matching-switch-statements) statement
```csharp
var entity = new EntityA { Value = "Hello" }; //EntityA is a custom class...

switch(entity){

  case EntityA a when a.Value == "Hello":
  case EntityA _ : // _ is a dummy placeholder
    Console.WriteLine("Is an EntityA or is an EntityA with a \"Hello\" value"); //This code get reached
    break;
    
  default : 
  Console.WriteLine("entity is not a EntityA"); //This code does not get reached in this example
  
}
```

### Some Linq Methods

#### [.FirstOrDefault()](https://msdn.microsoft.com/en-us/library/bb340482(v=vs.110).aspx) 
#### [.ToList()](https://msdn.microsoft.com/en-us/library/bb342261(v=vs.110).aspx)
#### [.Select()](https://msdn.microsoft.com/en-us/library/bb548891(v=vs.110).aspx)
#### [.SelectMany()](https://msdn.microsoft.com/en-us/library/bb534336(v=vs.110).aspx)
#### [.Count()](https://msdn.microsoft.com/en-us/library/bb338038(v=vs.110).aspx)
#### [.Sum()](https://msdn.microsoft.com/en-us/library/bb338442(v=vs.110).aspx)
#### [.Where()](https://msdn.microsoft.com/en-us/library/bb534803(v=vs.110).aspx)
#### [.Aggregate()](https://msdn.microsoft.com/en-us/library/bb548651(v=vs.110).aspx)
#### [.Zip()](https://msdn.microsoft.com/en-us/library/dd267698(v=vs.110).aspx)
#### [.Distinct()](https://msdn.microsoft.com/en-us/library/bb348436(v=vs.110).aspx)
#### [.GroupBy()](https://docs.microsoft.com/en-us/dotnet/csharp/linq/group-query-results)

### Some .Net Methods

#### [.Split()](https://msdn.microsoft.com/en-us/library/tabh47cf(v=vs.110).aspx)
#### [Convert.ToXXX()](https://docs.microsoft.com/en-us/previous-versions/windows/embedded/dd169375(v=msdn.10))

### For my javascript people !

[JS equivalent function of Linq methods](https://gist.github.com/DanDiplo/30528387da41332ff22b)
