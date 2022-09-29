//Cookie Exception is played by gathering 9 chocolate chip cookies and one oatmeal raisin cookie. The cookies are mixed and put in a dark room with 2 players who can't see the cookies. Each player takes a turn picking a cookie randomly and shoving it in their mouth without seeing whether it is a delicious chocolate chip cookie or an awful oatmeal raisin cookie. If they pick wrong and eat the oatmeal raisin cookie, they lose. If their opponent eats the oatmeal raisin cookie, then they win.

//OBJECTIVES:
//The game will pick a random number between 0 and 9 (inclusive) to represent the oatmeal raisin cookie
//The game will allow players to take turns picking numbers between 0 and 9
//If a player repeats a number that has been already used, the program should ake them select another. Hint: If you use a List<int> to store previously chosen numbers, you can use its Contains method to see if a number has been used before
//If the number matches the one the game picked initially, an exception should be thrown, terminating the program. Run the program at least once like this to see it crash
//Put in a try/catch block to handle the exception and display the results
//Answer this question: Did you make a custom exception type or use an existing one, and why did you choose what you did?
//Answer this question: You could write this program without exceptions, but the requirements demanded an exception for learning purposes. If you didn't have that requirement, would you have used an exception? Why or why not?