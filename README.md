# [Lucas](https://github.com/lucasstarsz)'s daily challenge 2 & 3.

# Conway's Game of Life

Conway's Game of Life is a simple game, with a few core rules:
- If a live cell has < 2 live neighbours it dies
- If a live cell has 2 or 3 live neighbours it lives
- If a live cell has > 3 live neighbours, it dies
- If a dead cell has 3 live neighbours it becomes alive

## Rules for the challenge: 
- 2 hours to make Conway's Game Of Life (Daily challenge 2).
- Clean up the repo and the code (Daily challenge 3)

# Installation
As with most applications, installation is simple, clone the github repository, then open up your preferred IDE with a C# compiler, then hit compile. Boom it gets compiled then it runs!
- Clone repo
- Open up the `.sln` or `.csproj` file
- An IDE should launch, hit build
- It should compile to a `.exe` file, that you can run!

## After it's finished, it's not quite finished

So after I implemented the Conway's Game of Life "gameplay", it wasn't quite finished, the code was all messy, and it was hard to follow with 1's and 0's.

So I had [Yasahiro](https://github.com/oliverbooth) review it, and man did he have things to say, but it was honestly great, and the code is a lot less messy now. Other than my GetLiveNeighbours script which would have to be rebuilt from scratch with a new grid system.

So the big changes are:
- Code is a lot cleaner, and just overall easier to read
- Code is more performant
- It's easier to follow the algorithm running


# Contributions
If you wish to make a contribution, I am not currently looking for them, but you can make a pull request, and I'll check it out

##Licence
MIT liscence
