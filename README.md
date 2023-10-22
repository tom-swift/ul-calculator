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

My initial thoughts on this test were "Hmmm I'm sure I've done this with DataTables before" and a short google search later told me that yes, I could do `Convert.ToDouble(new DataTable().Compute(input, null));` and it would pass all the tests I needed it to in this kata.
However, that felt like cheating so I spent a short while remembering how to do maths again properly.
This led to the commit history in this repo which I hope explains a bit about my thinking when I was working through this exercise.

My next steps with this project would probably be to continue refactoring out the CalculationService particularly simplifying ther methods in there so that the tests would be focussed enough to add other functionality to the calculator such as a modulous operator.

There is also a considerable amount of unhappy path testing and validation required here, but time ran a little short on me.

On a similar note, I would also add some boundary tests for some confidence moving forward into maintenance mode.

## Learnings

As always, much of my time was spent really understanding the problem after realising that I couldn't just use DataTables. I probably spent a bit too long thinking about "Oh god, just get it working" early on in the process, but I genuinely believe the small TDD commits were the only thing that enabled me to get my head around this problem.
