# UL Calculator Code Test

## The Exercise

Write a C# web-based API application that evaluates a string expression consisting of nonnegative integers and the + - / *operators only, considering the normal mathematical rules of
operator precedence. Support for brackets is not required.
The calculation should be performed in the API not the UI and by your own code, not a third party library.

### For example

an input string of "4+5*2" should output 14
an input string of "4+5/2" should output 6.5
an input string of "4+5/2-1" should output 5.5

## Planned Approach

There are certain things I want to achieve in this code test. The below will behave as my checklist but I will also try and add some context around the why because, well, code test.

- Automate CI Pipeline: Save time and check my work
- Warnings as Errors: Start with a high bar and pray for sustainability later on
- Keep cyclomatic complexity below 5 where possible: Mark Seeman reckons the average human can hold between 5 and 9 things in their short term memory, I suspect I'm on the lower end of this so keep things small and easy to understand (KISS).
- RGR TDD: Because I love acronyms and also red green refactor is just my preferred way of unit test driving.
- Boundary tests: to confirm that it works overall
- Retrospective approach and log learnings bellow: because not everything goes to plan.

## Approach Taken

## Learnings
