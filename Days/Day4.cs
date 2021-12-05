public class Day4 {
    string? tempString;
    string[]? splits;
    int[]? calledNumbers;
    int boardCounter = 0;
    List<board> boardList = new List<board>();
    bool globalBingo = false;

    public void Calc(){
        string path = "Days/inputDay4.txt";
        using (StreamReader sr = File.OpenText(path)){
            tempString = sr.ReadLine();
            Console.WriteLine(tempString);
            splits = tempString.Split(',');
            //Console.WriteLine(splits[0]);

            calledNumbers = Array.ConvertAll(splits, s => int.Parse(s));
            //Console.WriteLine("ints pls : " + calledNumbers[0]);
            while ((tempString = sr.ReadLine()) != null){
                //Console.WriteLine(tempString);

                board tempBoard = new board();
                for (int i = 0; i < 5; i++){
                    tempString = sr.ReadLine();
                    splits = tempString.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    int[]? tempNums = Array.ConvertAll(splits, s => int.Parse(s));
            
                    for (int j = 0; j < 5; j++){
                        tempBoard.grid[i,j] = tempNums[j];
                    }
                }
                tempBoard.sumBoard();
                boardList.Add(tempBoard);
            }
        }

        foreach (int num in calledNumbers){
            foreach (board b in boardList){
                if (!b.bingo){
                    b.searchBoard(num);
                    if (b.bingo){
                        Console.WriteLine("num: " + num);
                        Console.WriteLine("Mult: " + num*b.boardSum);
                    }
                }
                
            }
        }
    }
    public class board{
        public int[,] grid = new int[5,5];
        public int[,] marked = new int[5,5];
        public int boardSum;
        public bool bingo = false;

        public void printBoard(){
            for (int i = 0; i < 5; i++){
                for (int j = 0; j < 5; j++){
                    Console.Write(this.grid[i,j]+" ");
                }
                Console.Write("\n");
            }
        }
        public void searchBoard(int num){
            for (int i = 0; i < 5; i++){
                for (int j = 0; j < 5; j++){
                    if (num == this.grid[i,j]){
                        this.marked[i,j] = 1;
                        if(this.checkBingo(i,j)){
                            Console.WriteLine("Bingo!");
                            Console.WriteLine(this.boardSum);
                            return;
                        }
                    }   
                }
            }
        }
        public bool checkBingo(int i, int j){
            int iSum = 0;
            int jSum = 0;
            for (int k = 0; k < 5; k++){
                iSum+=this.marked[i,k];
                jSum+=this.marked[k,j]; 
            }
            if (iSum == 5){
                for (int g = 0; g < 5; g++){
                    for (int h = 0; h < 5; h++){
                        if(this.marked[g,h] == 1){
                            boardSum-=this.grid[g,h];
                        }
                }
            } 
                this.bingo = true;
            
                return true;
            }
            else if (jSum == 5){
                for (int g = 0; g < 5; g++){
                    for (int h = 0; h < 5; h++){
                        if(this.marked[g,h] == 1){
                            boardSum-=this.grid[g,h];
                        }
                }
            }         
                this.bingo = true;
                return true;
            }
            else
                return false;
        }
        public void sumBoard(){
            for (int i = 0; i < 5; i++){
                for (int j = 0; j < 5; j++){
                    boardSum+=this.grid[i,j];
                }
            }
        }
    }
}