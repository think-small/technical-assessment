# Technical Assessment
This is my solution for the technical assessment for Provation Medical.  It was built with .NET 4.7.2.

## Dependencies
Packages utilized in this solution include:
* AutoFac
* NUnit
* FluentAssertions

## Solution Architecture
Given the very limited scope of this assessment, I did not feel the need to follow standard architectural patterns such as Clean Architecture or N-Layered Architecture.
The solution contains a console application project with project folders to organize the classes.
```
├───TechnicalAssessment
│   ├───Infrastructure
│   ├───Interfaces
│   ├───Models
│   └───Services
```
The ```infrastructure``` folder contains the concrete classes that implement the various interfaces found in the ```interfaces``` folder. 
These classes represent the various TaxRules and RoundingStrategies used in the ```TaxService``` service. 

One point to note is that AutoFac was used for dependency injection. Container configuration is done in ```Program.cs``` while the main program runs by retreiving an instance 
of ```TechnicalAssessment``` from the container and invoking its ```Run()``` method.

## Features
This code assessment had two primary functionalities that needed to be developed: apply various tax rules to products and rounding sales tax costs to the next highest cent divisible by five.

In order to achieve the ability to have various tax rules, I created a concrete class for each tax rule needed. Each class contains the conditional logic for determining 
which products would be subject to the tax rule, as well as the actual implementation logic of the tax rule itself. Each class implements a common interface, ```ITaxRule```. An ```IEnumerable<ITaxRule>``` 
is injected into the ```TaxService```. A client can then pass a ```Product``` to the tax service to have it subjected to all the available tax rules.  Adding tax rules to be applied is 
as simple as creating the concrete tax rule class and registering it with the IoC container.  This helps ensure adherence to the Open-Closed Principle.

It seemed as if rounding sales tax costs would also need to vary.  Unfortunately, it did not seem that the Decimal struct had any overloaded ```Decimal.Round()``` methods that would 
suit the requirements of this project. As a result, I chose to implement the strategy pattern to inject a custom rounding strategy in to ```TaxService```. Again, changing rounding 
behavior would be as easy as creating a new concrete class that implements ```IRoundingStrategy``` and registering it with the IoC container.
