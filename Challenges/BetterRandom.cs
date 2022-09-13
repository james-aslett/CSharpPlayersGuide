//Random.NextDouble() only returns values between 0 and 1. Need to be able to produce random double values between 0 and another number, eg: 0 and 10
//Need to randomly choose from one of several strings, eg: "up", "down", "left" and "right", with each having an equal probability of being chosen
//Need to do a coin toss, randomly picking a bool, and usually want it to be a fair coin toss (50% heads / 50% tails), but occasionally want unequal probabilities. For example, a 75% chance of true and 25% of false

//OBJECTIVES
//create a new static class to add extension methods for Random
//as described above, add a NextDouble extension method that gives a maximum value for a randomly generated double
//add a NextString extension method for Random that allows you to pass in any number of string values (using params) and randomly pick one of them
//add a CoinFlip method that randomly picks a bool value. It should have an optional parameter that indicates the frequency of heads coming up, which should default to 0.5, or 50% of the time
//in your opinion, would it be better to make a derived AdvancedRandom class that adds these methods or use extension methods?

public static class RandomExtensions
{
    public static 
}